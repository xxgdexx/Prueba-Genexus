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
   public class chofereswwgetfilterdata : GXProcedure
   {
      public chofereswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public chofereswwgetfilterdata( IGxContext context )
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
         this.AV34DDOName = aP0_DDOName;
         this.AV32SearchTxt = aP1_SearchTxt;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV43OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV43OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         chofereswwgetfilterdata objchofereswwgetfilterdata;
         objchofereswwgetfilterdata = new chofereswwgetfilterdata();
         objchofereswwgetfilterdata.AV34DDOName = aP0_DDOName;
         objchofereswwgetfilterdata.AV32SearchTxt = aP1_SearchTxt;
         objchofereswwgetfilterdata.AV33SearchTxtTo = aP2_SearchTxtTo;
         objchofereswwgetfilterdata.AV38OptionsJson = "" ;
         objchofereswwgetfilterdata.AV41OptionsDescJson = "" ;
         objchofereswwgetfilterdata.AV43OptionIndexesJson = "" ;
         objchofereswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objchofereswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objchofereswwgetfilterdata);
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((chofereswwgetfilterdata)stateInfo).executePrivate();
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
         AV37Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV42OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_CHODSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCHODSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_CHODIR") == 0 )
         {
            /* Execute user subroutine: 'LOADCHODIROPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_CHORUC") == 0 )
         {
            /* Execute user subroutine: 'LOADCHORUCOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_CHOPLACA") == 0 )
         {
            /* Execute user subroutine: 'LOADCHOPLACAOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_CHOLICENCIA") == 0 )
         {
            /* Execute user subroutine: 'LOADCHOLICENCIAOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV38OptionsJson = AV37Options.ToJSonString(false);
         AV41OptionsDescJson = AV40OptionsDesc.ToJSonString(false);
         AV43OptionIndexesJson = AV42OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV45Session.Get("Configuracion.ChoferesWWGridState"), "") == 0 )
         {
            AV47GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.ChoferesWWGridState"), null, "", "");
         }
         else
         {
            AV47GridState.FromXml(AV45Session.Get("Configuracion.ChoferesWWGridState"), null, "", "");
         }
         AV71GXV1 = 1;
         while ( AV71GXV1 <= AV47GridState.gxTpr_Filtervalues.Count )
         {
            AV48GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV47GridState.gxTpr_Filtervalues.Item(AV71GXV1));
            if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFCHOCOD") == 0 )
            {
               AV10TFChoCod = (int)(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Value, "."));
               AV11TFChoCod_To = (int)(NumberUtil.Val( AV48GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFCHODSC") == 0 )
            {
               AV12TFChoDsc = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFCHODSC_SEL") == 0 )
            {
               AV13TFChoDsc_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFCHODIR") == 0 )
            {
               AV14TFChoDir = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFCHODIR_SEL") == 0 )
            {
               AV15TFChoDir_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFCHORUC") == 0 )
            {
               AV18TFChoRuc = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFCHORUC_SEL") == 0 )
            {
               AV19TFChoRuc_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFCHOPLACA") == 0 )
            {
               AV22TFChoPlaca = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFCHOPLACA_SEL") == 0 )
            {
               AV23TFChoPlaca_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFCHOLICENCIA") == 0 )
            {
               AV24TFChoLicencia = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFCHOLICENCIA_SEL") == 0 )
            {
               AV25TFChoLicencia_Sel = AV48GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48GridStateFilterValue.gxTpr_Name, "TFCHOSTS_SEL") == 0 )
            {
               AV61TFChoSts_SelsJson = AV48GridStateFilterValue.gxTpr_Value;
               AV62TFChoSts_Sels.FromJSonString(AV61TFChoSts_SelsJson, null);
            }
            AV71GXV1 = (int)(AV71GXV1+1);
         }
         if ( AV47GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV49GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV47GridState.gxTpr_Dynamicfilters.Item(1));
            AV50DynamicFiltersSelector1 = AV49GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV50DynamicFiltersSelector1, "CHODSC") == 0 )
            {
               AV51DynamicFiltersOperator1 = AV49GridStateDynamicFilter.gxTpr_Operator;
               AV52ChoDsc1 = AV49GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50DynamicFiltersSelector1, "CHOPLACA") == 0 )
            {
               AV51DynamicFiltersOperator1 = AV49GridStateDynamicFilter.gxTpr_Operator;
               AV63ChoPlaca1 = AV49GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV50DynamicFiltersSelector1, "CHOLICENCIA") == 0 )
            {
               AV51DynamicFiltersOperator1 = AV49GridStateDynamicFilter.gxTpr_Operator;
               AV64ChoLicencia1 = AV49GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV47GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV53DynamicFiltersEnabled2 = true;
               AV49GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV47GridState.gxTpr_Dynamicfilters.Item(2));
               AV54DynamicFiltersSelector2 = AV49GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV54DynamicFiltersSelector2, "CHODSC") == 0 )
               {
                  AV55DynamicFiltersOperator2 = AV49GridStateDynamicFilter.gxTpr_Operator;
                  AV56ChoDsc2 = AV49GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV54DynamicFiltersSelector2, "CHOPLACA") == 0 )
               {
                  AV55DynamicFiltersOperator2 = AV49GridStateDynamicFilter.gxTpr_Operator;
                  AV65ChoPlaca2 = AV49GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV54DynamicFiltersSelector2, "CHOLICENCIA") == 0 )
               {
                  AV55DynamicFiltersOperator2 = AV49GridStateDynamicFilter.gxTpr_Operator;
                  AV66ChoLicencia2 = AV49GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV47GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV57DynamicFiltersEnabled3 = true;
                  AV49GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV47GridState.gxTpr_Dynamicfilters.Item(3));
                  AV58DynamicFiltersSelector3 = AV49GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV58DynamicFiltersSelector3, "CHODSC") == 0 )
                  {
                     AV59DynamicFiltersOperator3 = AV49GridStateDynamicFilter.gxTpr_Operator;
                     AV60ChoDsc3 = AV49GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector3, "CHOPLACA") == 0 )
                  {
                     AV59DynamicFiltersOperator3 = AV49GridStateDynamicFilter.gxTpr_Operator;
                     AV67ChoPlaca3 = AV49GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector3, "CHOLICENCIA") == 0 )
                  {
                     AV59DynamicFiltersOperator3 = AV49GridStateDynamicFilter.gxTpr_Operator;
                     AV68ChoLicencia3 = AV49GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCHODSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFChoDsc = AV32SearchTxt;
         AV13TFChoDsc_Sel = "";
         AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 = AV50DynamicFiltersSelector1;
         AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 = AV51DynamicFiltersOperator1;
         AV75Configuracion_chofereswwds_3_chodsc1 = AV52ChoDsc1;
         AV76Configuracion_chofereswwds_4_choplaca1 = AV63ChoPlaca1;
         AV77Configuracion_chofereswwds_5_cholicencia1 = AV64ChoLicencia1;
         AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 = AV53DynamicFiltersEnabled2;
         AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 = AV54DynamicFiltersSelector2;
         AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 = AV55DynamicFiltersOperator2;
         AV81Configuracion_chofereswwds_9_chodsc2 = AV56ChoDsc2;
         AV82Configuracion_chofereswwds_10_choplaca2 = AV65ChoPlaca2;
         AV83Configuracion_chofereswwds_11_cholicencia2 = AV66ChoLicencia2;
         AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV87Configuracion_chofereswwds_15_chodsc3 = AV60ChoDsc3;
         AV88Configuracion_chofereswwds_16_choplaca3 = AV67ChoPlaca3;
         AV89Configuracion_chofereswwds_17_cholicencia3 = AV68ChoLicencia3;
         AV90Configuracion_chofereswwds_18_tfchocod = AV10TFChoCod;
         AV91Configuracion_chofereswwds_19_tfchocod_to = AV11TFChoCod_To;
         AV92Configuracion_chofereswwds_20_tfchodsc = AV12TFChoDsc;
         AV93Configuracion_chofereswwds_21_tfchodsc_sel = AV13TFChoDsc_Sel;
         AV94Configuracion_chofereswwds_22_tfchodir = AV14TFChoDir;
         AV95Configuracion_chofereswwds_23_tfchodir_sel = AV15TFChoDir_Sel;
         AV96Configuracion_chofereswwds_24_tfchoruc = AV18TFChoRuc;
         AV97Configuracion_chofereswwds_25_tfchoruc_sel = AV19TFChoRuc_Sel;
         AV98Configuracion_chofereswwds_26_tfchoplaca = AV22TFChoPlaca;
         AV99Configuracion_chofereswwds_27_tfchoplaca_sel = AV23TFChoPlaca_Sel;
         AV100Configuracion_chofereswwds_28_tfcholicencia = AV24TFChoLicencia;
         AV101Configuracion_chofereswwds_29_tfcholicencia_sel = AV25TFChoLicencia_Sel;
         AV102Configuracion_chofereswwds_30_tfchosts_sels = AV62TFChoSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A549ChoSts ,
                                              AV102Configuracion_chofereswwds_30_tfchosts_sels ,
                                              AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 ,
                                              AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 ,
                                              AV75Configuracion_chofereswwds_3_chodsc1 ,
                                              AV76Configuracion_chofereswwds_4_choplaca1 ,
                                              AV77Configuracion_chofereswwds_5_cholicencia1 ,
                                              AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 ,
                                              AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 ,
                                              AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 ,
                                              AV81Configuracion_chofereswwds_9_chodsc2 ,
                                              AV82Configuracion_chofereswwds_10_choplaca2 ,
                                              AV83Configuracion_chofereswwds_11_cholicencia2 ,
                                              AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 ,
                                              AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 ,
                                              AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 ,
                                              AV87Configuracion_chofereswwds_15_chodsc3 ,
                                              AV88Configuracion_chofereswwds_16_choplaca3 ,
                                              AV89Configuracion_chofereswwds_17_cholicencia3 ,
                                              AV90Configuracion_chofereswwds_18_tfchocod ,
                                              AV91Configuracion_chofereswwds_19_tfchocod_to ,
                                              AV93Configuracion_chofereswwds_21_tfchodsc_sel ,
                                              AV92Configuracion_chofereswwds_20_tfchodsc ,
                                              AV95Configuracion_chofereswwds_23_tfchodir_sel ,
                                              AV94Configuracion_chofereswwds_22_tfchodir ,
                                              AV97Configuracion_chofereswwds_25_tfchoruc_sel ,
                                              AV96Configuracion_chofereswwds_24_tfchoruc ,
                                              AV99Configuracion_chofereswwds_27_tfchoplaca_sel ,
                                              AV98Configuracion_chofereswwds_26_tfchoplaca ,
                                              AV101Configuracion_chofereswwds_29_tfcholicencia_sel ,
                                              AV100Configuracion_chofereswwds_28_tfcholicencia ,
                                              AV102Configuracion_chofereswwds_30_tfchosts_sels.Count ,
                                              A542ChoDsc ,
                                              A543ChoPlaca ,
                                              A546ChoLicencia ,
                                              A10ChoCod ,
                                              A545ChoDir ,
                                              A548ChoRuc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV75Configuracion_chofereswwds_3_chodsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1), 100, "%");
         lV75Configuracion_chofereswwds_3_chodsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1), 100, "%");
         lV76Configuracion_chofereswwds_4_choplaca1 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1), 20, "%");
         lV76Configuracion_chofereswwds_4_choplaca1 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1), 20, "%");
         lV77Configuracion_chofereswwds_5_cholicencia1 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1), 20, "%");
         lV77Configuracion_chofereswwds_5_cholicencia1 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1), 20, "%");
         lV81Configuracion_chofereswwds_9_chodsc2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2), 100, "%");
         lV81Configuracion_chofereswwds_9_chodsc2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2), 100, "%");
         lV82Configuracion_chofereswwds_10_choplaca2 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2), 20, "%");
         lV82Configuracion_chofereswwds_10_choplaca2 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2), 20, "%");
         lV83Configuracion_chofereswwds_11_cholicencia2 = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2), 20, "%");
         lV83Configuracion_chofereswwds_11_cholicencia2 = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2), 20, "%");
         lV87Configuracion_chofereswwds_15_chodsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3), 100, "%");
         lV87Configuracion_chofereswwds_15_chodsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3), 100, "%");
         lV88Configuracion_chofereswwds_16_choplaca3 = StringUtil.PadR( StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3), 20, "%");
         lV88Configuracion_chofereswwds_16_choplaca3 = StringUtil.PadR( StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3), 20, "%");
         lV89Configuracion_chofereswwds_17_cholicencia3 = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3), 20, "%");
         lV89Configuracion_chofereswwds_17_cholicencia3 = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3), 20, "%");
         lV92Configuracion_chofereswwds_20_tfchodsc = StringUtil.PadR( StringUtil.RTrim( AV92Configuracion_chofereswwds_20_tfchodsc), 100, "%");
         lV94Configuracion_chofereswwds_22_tfchodir = StringUtil.PadR( StringUtil.RTrim( AV94Configuracion_chofereswwds_22_tfchodir), 100, "%");
         lV96Configuracion_chofereswwds_24_tfchoruc = StringUtil.PadR( StringUtil.RTrim( AV96Configuracion_chofereswwds_24_tfchoruc), 20, "%");
         lV98Configuracion_chofereswwds_26_tfchoplaca = StringUtil.PadR( StringUtil.RTrim( AV98Configuracion_chofereswwds_26_tfchoplaca), 20, "%");
         lV100Configuracion_chofereswwds_28_tfcholicencia = StringUtil.PadR( StringUtil.RTrim( AV100Configuracion_chofereswwds_28_tfcholicencia), 20, "%");
         /* Using cursor P00312 */
         pr_default.execute(0, new Object[] {lV75Configuracion_chofereswwds_3_chodsc1, lV75Configuracion_chofereswwds_3_chodsc1, lV76Configuracion_chofereswwds_4_choplaca1, lV76Configuracion_chofereswwds_4_choplaca1, lV77Configuracion_chofereswwds_5_cholicencia1, lV77Configuracion_chofereswwds_5_cholicencia1, lV81Configuracion_chofereswwds_9_chodsc2, lV81Configuracion_chofereswwds_9_chodsc2, lV82Configuracion_chofereswwds_10_choplaca2, lV82Configuracion_chofereswwds_10_choplaca2, lV83Configuracion_chofereswwds_11_cholicencia2, lV83Configuracion_chofereswwds_11_cholicencia2, lV87Configuracion_chofereswwds_15_chodsc3, lV87Configuracion_chofereswwds_15_chodsc3, lV88Configuracion_chofereswwds_16_choplaca3, lV88Configuracion_chofereswwds_16_choplaca3, lV89Configuracion_chofereswwds_17_cholicencia3, lV89Configuracion_chofereswwds_17_cholicencia3, AV90Configuracion_chofereswwds_18_tfchocod, AV91Configuracion_chofereswwds_19_tfchocod_to, lV92Configuracion_chofereswwds_20_tfchodsc, AV93Configuracion_chofereswwds_21_tfchodsc_sel, lV94Configuracion_chofereswwds_22_tfchodir, AV95Configuracion_chofereswwds_23_tfchodir_sel, lV96Configuracion_chofereswwds_24_tfchoruc, AV97Configuracion_chofereswwds_25_tfchoruc_sel, lV98Configuracion_chofereswwds_26_tfchoplaca, AV99Configuracion_chofereswwds_27_tfchoplaca_sel, lV100Configuracion_chofereswwds_28_tfcholicencia, AV101Configuracion_chofereswwds_29_tfcholicencia_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK312 = false;
            A542ChoDsc = P00312_A542ChoDsc[0];
            A549ChoSts = P00312_A549ChoSts[0];
            A548ChoRuc = P00312_A548ChoRuc[0];
            A545ChoDir = P00312_A545ChoDir[0];
            A10ChoCod = P00312_A10ChoCod[0];
            A546ChoLicencia = P00312_A546ChoLicencia[0];
            A543ChoPlaca = P00312_A543ChoPlaca[0];
            AV44count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00312_A542ChoDsc[0], A542ChoDsc) == 0 ) )
            {
               BRK312 = false;
               A10ChoCod = P00312_A10ChoCod[0];
               AV44count = (long)(AV44count+1);
               BRK312 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A542ChoDsc)) )
            {
               AV36Option = A542ChoDsc;
               AV37Options.Add(AV36Option, 0);
               AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV37Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK312 )
            {
               BRK312 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCHODIROPTIONS' Routine */
         returnInSub = false;
         AV14TFChoDir = AV32SearchTxt;
         AV15TFChoDir_Sel = "";
         AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 = AV50DynamicFiltersSelector1;
         AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 = AV51DynamicFiltersOperator1;
         AV75Configuracion_chofereswwds_3_chodsc1 = AV52ChoDsc1;
         AV76Configuracion_chofereswwds_4_choplaca1 = AV63ChoPlaca1;
         AV77Configuracion_chofereswwds_5_cholicencia1 = AV64ChoLicencia1;
         AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 = AV53DynamicFiltersEnabled2;
         AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 = AV54DynamicFiltersSelector2;
         AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 = AV55DynamicFiltersOperator2;
         AV81Configuracion_chofereswwds_9_chodsc2 = AV56ChoDsc2;
         AV82Configuracion_chofereswwds_10_choplaca2 = AV65ChoPlaca2;
         AV83Configuracion_chofereswwds_11_cholicencia2 = AV66ChoLicencia2;
         AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV87Configuracion_chofereswwds_15_chodsc3 = AV60ChoDsc3;
         AV88Configuracion_chofereswwds_16_choplaca3 = AV67ChoPlaca3;
         AV89Configuracion_chofereswwds_17_cholicencia3 = AV68ChoLicencia3;
         AV90Configuracion_chofereswwds_18_tfchocod = AV10TFChoCod;
         AV91Configuracion_chofereswwds_19_tfchocod_to = AV11TFChoCod_To;
         AV92Configuracion_chofereswwds_20_tfchodsc = AV12TFChoDsc;
         AV93Configuracion_chofereswwds_21_tfchodsc_sel = AV13TFChoDsc_Sel;
         AV94Configuracion_chofereswwds_22_tfchodir = AV14TFChoDir;
         AV95Configuracion_chofereswwds_23_tfchodir_sel = AV15TFChoDir_Sel;
         AV96Configuracion_chofereswwds_24_tfchoruc = AV18TFChoRuc;
         AV97Configuracion_chofereswwds_25_tfchoruc_sel = AV19TFChoRuc_Sel;
         AV98Configuracion_chofereswwds_26_tfchoplaca = AV22TFChoPlaca;
         AV99Configuracion_chofereswwds_27_tfchoplaca_sel = AV23TFChoPlaca_Sel;
         AV100Configuracion_chofereswwds_28_tfcholicencia = AV24TFChoLicencia;
         AV101Configuracion_chofereswwds_29_tfcholicencia_sel = AV25TFChoLicencia_Sel;
         AV102Configuracion_chofereswwds_30_tfchosts_sels = AV62TFChoSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A549ChoSts ,
                                              AV102Configuracion_chofereswwds_30_tfchosts_sels ,
                                              AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 ,
                                              AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 ,
                                              AV75Configuracion_chofereswwds_3_chodsc1 ,
                                              AV76Configuracion_chofereswwds_4_choplaca1 ,
                                              AV77Configuracion_chofereswwds_5_cholicencia1 ,
                                              AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 ,
                                              AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 ,
                                              AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 ,
                                              AV81Configuracion_chofereswwds_9_chodsc2 ,
                                              AV82Configuracion_chofereswwds_10_choplaca2 ,
                                              AV83Configuracion_chofereswwds_11_cholicencia2 ,
                                              AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 ,
                                              AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 ,
                                              AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 ,
                                              AV87Configuracion_chofereswwds_15_chodsc3 ,
                                              AV88Configuracion_chofereswwds_16_choplaca3 ,
                                              AV89Configuracion_chofereswwds_17_cholicencia3 ,
                                              AV90Configuracion_chofereswwds_18_tfchocod ,
                                              AV91Configuracion_chofereswwds_19_tfchocod_to ,
                                              AV93Configuracion_chofereswwds_21_tfchodsc_sel ,
                                              AV92Configuracion_chofereswwds_20_tfchodsc ,
                                              AV95Configuracion_chofereswwds_23_tfchodir_sel ,
                                              AV94Configuracion_chofereswwds_22_tfchodir ,
                                              AV97Configuracion_chofereswwds_25_tfchoruc_sel ,
                                              AV96Configuracion_chofereswwds_24_tfchoruc ,
                                              AV99Configuracion_chofereswwds_27_tfchoplaca_sel ,
                                              AV98Configuracion_chofereswwds_26_tfchoplaca ,
                                              AV101Configuracion_chofereswwds_29_tfcholicencia_sel ,
                                              AV100Configuracion_chofereswwds_28_tfcholicencia ,
                                              AV102Configuracion_chofereswwds_30_tfchosts_sels.Count ,
                                              A542ChoDsc ,
                                              A543ChoPlaca ,
                                              A546ChoLicencia ,
                                              A10ChoCod ,
                                              A545ChoDir ,
                                              A548ChoRuc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV75Configuracion_chofereswwds_3_chodsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1), 100, "%");
         lV75Configuracion_chofereswwds_3_chodsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1), 100, "%");
         lV76Configuracion_chofereswwds_4_choplaca1 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1), 20, "%");
         lV76Configuracion_chofereswwds_4_choplaca1 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1), 20, "%");
         lV77Configuracion_chofereswwds_5_cholicencia1 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1), 20, "%");
         lV77Configuracion_chofereswwds_5_cholicencia1 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1), 20, "%");
         lV81Configuracion_chofereswwds_9_chodsc2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2), 100, "%");
         lV81Configuracion_chofereswwds_9_chodsc2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2), 100, "%");
         lV82Configuracion_chofereswwds_10_choplaca2 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2), 20, "%");
         lV82Configuracion_chofereswwds_10_choplaca2 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2), 20, "%");
         lV83Configuracion_chofereswwds_11_cholicencia2 = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2), 20, "%");
         lV83Configuracion_chofereswwds_11_cholicencia2 = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2), 20, "%");
         lV87Configuracion_chofereswwds_15_chodsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3), 100, "%");
         lV87Configuracion_chofereswwds_15_chodsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3), 100, "%");
         lV88Configuracion_chofereswwds_16_choplaca3 = StringUtil.PadR( StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3), 20, "%");
         lV88Configuracion_chofereswwds_16_choplaca3 = StringUtil.PadR( StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3), 20, "%");
         lV89Configuracion_chofereswwds_17_cholicencia3 = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3), 20, "%");
         lV89Configuracion_chofereswwds_17_cholicencia3 = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3), 20, "%");
         lV92Configuracion_chofereswwds_20_tfchodsc = StringUtil.PadR( StringUtil.RTrim( AV92Configuracion_chofereswwds_20_tfchodsc), 100, "%");
         lV94Configuracion_chofereswwds_22_tfchodir = StringUtil.PadR( StringUtil.RTrim( AV94Configuracion_chofereswwds_22_tfchodir), 100, "%");
         lV96Configuracion_chofereswwds_24_tfchoruc = StringUtil.PadR( StringUtil.RTrim( AV96Configuracion_chofereswwds_24_tfchoruc), 20, "%");
         lV98Configuracion_chofereswwds_26_tfchoplaca = StringUtil.PadR( StringUtil.RTrim( AV98Configuracion_chofereswwds_26_tfchoplaca), 20, "%");
         lV100Configuracion_chofereswwds_28_tfcholicencia = StringUtil.PadR( StringUtil.RTrim( AV100Configuracion_chofereswwds_28_tfcholicencia), 20, "%");
         /* Using cursor P00313 */
         pr_default.execute(1, new Object[] {lV75Configuracion_chofereswwds_3_chodsc1, lV75Configuracion_chofereswwds_3_chodsc1, lV76Configuracion_chofereswwds_4_choplaca1, lV76Configuracion_chofereswwds_4_choplaca1, lV77Configuracion_chofereswwds_5_cholicencia1, lV77Configuracion_chofereswwds_5_cholicencia1, lV81Configuracion_chofereswwds_9_chodsc2, lV81Configuracion_chofereswwds_9_chodsc2, lV82Configuracion_chofereswwds_10_choplaca2, lV82Configuracion_chofereswwds_10_choplaca2, lV83Configuracion_chofereswwds_11_cholicencia2, lV83Configuracion_chofereswwds_11_cholicencia2, lV87Configuracion_chofereswwds_15_chodsc3, lV87Configuracion_chofereswwds_15_chodsc3, lV88Configuracion_chofereswwds_16_choplaca3, lV88Configuracion_chofereswwds_16_choplaca3, lV89Configuracion_chofereswwds_17_cholicencia3, lV89Configuracion_chofereswwds_17_cholicencia3, AV90Configuracion_chofereswwds_18_tfchocod, AV91Configuracion_chofereswwds_19_tfchocod_to, lV92Configuracion_chofereswwds_20_tfchodsc, AV93Configuracion_chofereswwds_21_tfchodsc_sel, lV94Configuracion_chofereswwds_22_tfchodir, AV95Configuracion_chofereswwds_23_tfchodir_sel, lV96Configuracion_chofereswwds_24_tfchoruc, AV97Configuracion_chofereswwds_25_tfchoruc_sel, lV98Configuracion_chofereswwds_26_tfchoplaca, AV99Configuracion_chofereswwds_27_tfchoplaca_sel, lV100Configuracion_chofereswwds_28_tfcholicencia, AV101Configuracion_chofereswwds_29_tfcholicencia_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK314 = false;
            A545ChoDir = P00313_A545ChoDir[0];
            A549ChoSts = P00313_A549ChoSts[0];
            A548ChoRuc = P00313_A548ChoRuc[0];
            A10ChoCod = P00313_A10ChoCod[0];
            A546ChoLicencia = P00313_A546ChoLicencia[0];
            A543ChoPlaca = P00313_A543ChoPlaca[0];
            A542ChoDsc = P00313_A542ChoDsc[0];
            AV44count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00313_A545ChoDir[0], A545ChoDir) == 0 ) )
            {
               BRK314 = false;
               A10ChoCod = P00313_A10ChoCod[0];
               AV44count = (long)(AV44count+1);
               BRK314 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A545ChoDir)) )
            {
               AV36Option = A545ChoDir;
               AV37Options.Add(AV36Option, 0);
               AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV37Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK314 )
            {
               BRK314 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCHORUCOPTIONS' Routine */
         returnInSub = false;
         AV18TFChoRuc = AV32SearchTxt;
         AV19TFChoRuc_Sel = "";
         AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 = AV50DynamicFiltersSelector1;
         AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 = AV51DynamicFiltersOperator1;
         AV75Configuracion_chofereswwds_3_chodsc1 = AV52ChoDsc1;
         AV76Configuracion_chofereswwds_4_choplaca1 = AV63ChoPlaca1;
         AV77Configuracion_chofereswwds_5_cholicencia1 = AV64ChoLicencia1;
         AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 = AV53DynamicFiltersEnabled2;
         AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 = AV54DynamicFiltersSelector2;
         AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 = AV55DynamicFiltersOperator2;
         AV81Configuracion_chofereswwds_9_chodsc2 = AV56ChoDsc2;
         AV82Configuracion_chofereswwds_10_choplaca2 = AV65ChoPlaca2;
         AV83Configuracion_chofereswwds_11_cholicencia2 = AV66ChoLicencia2;
         AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV87Configuracion_chofereswwds_15_chodsc3 = AV60ChoDsc3;
         AV88Configuracion_chofereswwds_16_choplaca3 = AV67ChoPlaca3;
         AV89Configuracion_chofereswwds_17_cholicencia3 = AV68ChoLicencia3;
         AV90Configuracion_chofereswwds_18_tfchocod = AV10TFChoCod;
         AV91Configuracion_chofereswwds_19_tfchocod_to = AV11TFChoCod_To;
         AV92Configuracion_chofereswwds_20_tfchodsc = AV12TFChoDsc;
         AV93Configuracion_chofereswwds_21_tfchodsc_sel = AV13TFChoDsc_Sel;
         AV94Configuracion_chofereswwds_22_tfchodir = AV14TFChoDir;
         AV95Configuracion_chofereswwds_23_tfchodir_sel = AV15TFChoDir_Sel;
         AV96Configuracion_chofereswwds_24_tfchoruc = AV18TFChoRuc;
         AV97Configuracion_chofereswwds_25_tfchoruc_sel = AV19TFChoRuc_Sel;
         AV98Configuracion_chofereswwds_26_tfchoplaca = AV22TFChoPlaca;
         AV99Configuracion_chofereswwds_27_tfchoplaca_sel = AV23TFChoPlaca_Sel;
         AV100Configuracion_chofereswwds_28_tfcholicencia = AV24TFChoLicencia;
         AV101Configuracion_chofereswwds_29_tfcholicencia_sel = AV25TFChoLicencia_Sel;
         AV102Configuracion_chofereswwds_30_tfchosts_sels = AV62TFChoSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A549ChoSts ,
                                              AV102Configuracion_chofereswwds_30_tfchosts_sels ,
                                              AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 ,
                                              AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 ,
                                              AV75Configuracion_chofereswwds_3_chodsc1 ,
                                              AV76Configuracion_chofereswwds_4_choplaca1 ,
                                              AV77Configuracion_chofereswwds_5_cholicencia1 ,
                                              AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 ,
                                              AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 ,
                                              AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 ,
                                              AV81Configuracion_chofereswwds_9_chodsc2 ,
                                              AV82Configuracion_chofereswwds_10_choplaca2 ,
                                              AV83Configuracion_chofereswwds_11_cholicencia2 ,
                                              AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 ,
                                              AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 ,
                                              AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 ,
                                              AV87Configuracion_chofereswwds_15_chodsc3 ,
                                              AV88Configuracion_chofereswwds_16_choplaca3 ,
                                              AV89Configuracion_chofereswwds_17_cholicencia3 ,
                                              AV90Configuracion_chofereswwds_18_tfchocod ,
                                              AV91Configuracion_chofereswwds_19_tfchocod_to ,
                                              AV93Configuracion_chofereswwds_21_tfchodsc_sel ,
                                              AV92Configuracion_chofereswwds_20_tfchodsc ,
                                              AV95Configuracion_chofereswwds_23_tfchodir_sel ,
                                              AV94Configuracion_chofereswwds_22_tfchodir ,
                                              AV97Configuracion_chofereswwds_25_tfchoruc_sel ,
                                              AV96Configuracion_chofereswwds_24_tfchoruc ,
                                              AV99Configuracion_chofereswwds_27_tfchoplaca_sel ,
                                              AV98Configuracion_chofereswwds_26_tfchoplaca ,
                                              AV101Configuracion_chofereswwds_29_tfcholicencia_sel ,
                                              AV100Configuracion_chofereswwds_28_tfcholicencia ,
                                              AV102Configuracion_chofereswwds_30_tfchosts_sels.Count ,
                                              A542ChoDsc ,
                                              A543ChoPlaca ,
                                              A546ChoLicencia ,
                                              A10ChoCod ,
                                              A545ChoDir ,
                                              A548ChoRuc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV75Configuracion_chofereswwds_3_chodsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1), 100, "%");
         lV75Configuracion_chofereswwds_3_chodsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1), 100, "%");
         lV76Configuracion_chofereswwds_4_choplaca1 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1), 20, "%");
         lV76Configuracion_chofereswwds_4_choplaca1 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1), 20, "%");
         lV77Configuracion_chofereswwds_5_cholicencia1 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1), 20, "%");
         lV77Configuracion_chofereswwds_5_cholicencia1 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1), 20, "%");
         lV81Configuracion_chofereswwds_9_chodsc2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2), 100, "%");
         lV81Configuracion_chofereswwds_9_chodsc2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2), 100, "%");
         lV82Configuracion_chofereswwds_10_choplaca2 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2), 20, "%");
         lV82Configuracion_chofereswwds_10_choplaca2 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2), 20, "%");
         lV83Configuracion_chofereswwds_11_cholicencia2 = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2), 20, "%");
         lV83Configuracion_chofereswwds_11_cholicencia2 = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2), 20, "%");
         lV87Configuracion_chofereswwds_15_chodsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3), 100, "%");
         lV87Configuracion_chofereswwds_15_chodsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3), 100, "%");
         lV88Configuracion_chofereswwds_16_choplaca3 = StringUtil.PadR( StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3), 20, "%");
         lV88Configuracion_chofereswwds_16_choplaca3 = StringUtil.PadR( StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3), 20, "%");
         lV89Configuracion_chofereswwds_17_cholicencia3 = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3), 20, "%");
         lV89Configuracion_chofereswwds_17_cholicencia3 = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3), 20, "%");
         lV92Configuracion_chofereswwds_20_tfchodsc = StringUtil.PadR( StringUtil.RTrim( AV92Configuracion_chofereswwds_20_tfchodsc), 100, "%");
         lV94Configuracion_chofereswwds_22_tfchodir = StringUtil.PadR( StringUtil.RTrim( AV94Configuracion_chofereswwds_22_tfchodir), 100, "%");
         lV96Configuracion_chofereswwds_24_tfchoruc = StringUtil.PadR( StringUtil.RTrim( AV96Configuracion_chofereswwds_24_tfchoruc), 20, "%");
         lV98Configuracion_chofereswwds_26_tfchoplaca = StringUtil.PadR( StringUtil.RTrim( AV98Configuracion_chofereswwds_26_tfchoplaca), 20, "%");
         lV100Configuracion_chofereswwds_28_tfcholicencia = StringUtil.PadR( StringUtil.RTrim( AV100Configuracion_chofereswwds_28_tfcholicencia), 20, "%");
         /* Using cursor P00314 */
         pr_default.execute(2, new Object[] {lV75Configuracion_chofereswwds_3_chodsc1, lV75Configuracion_chofereswwds_3_chodsc1, lV76Configuracion_chofereswwds_4_choplaca1, lV76Configuracion_chofereswwds_4_choplaca1, lV77Configuracion_chofereswwds_5_cholicencia1, lV77Configuracion_chofereswwds_5_cholicencia1, lV81Configuracion_chofereswwds_9_chodsc2, lV81Configuracion_chofereswwds_9_chodsc2, lV82Configuracion_chofereswwds_10_choplaca2, lV82Configuracion_chofereswwds_10_choplaca2, lV83Configuracion_chofereswwds_11_cholicencia2, lV83Configuracion_chofereswwds_11_cholicencia2, lV87Configuracion_chofereswwds_15_chodsc3, lV87Configuracion_chofereswwds_15_chodsc3, lV88Configuracion_chofereswwds_16_choplaca3, lV88Configuracion_chofereswwds_16_choplaca3, lV89Configuracion_chofereswwds_17_cholicencia3, lV89Configuracion_chofereswwds_17_cholicencia3, AV90Configuracion_chofereswwds_18_tfchocod, AV91Configuracion_chofereswwds_19_tfchocod_to, lV92Configuracion_chofereswwds_20_tfchodsc, AV93Configuracion_chofereswwds_21_tfchodsc_sel, lV94Configuracion_chofereswwds_22_tfchodir, AV95Configuracion_chofereswwds_23_tfchodir_sel, lV96Configuracion_chofereswwds_24_tfchoruc, AV97Configuracion_chofereswwds_25_tfchoruc_sel, lV98Configuracion_chofereswwds_26_tfchoplaca, AV99Configuracion_chofereswwds_27_tfchoplaca_sel, lV100Configuracion_chofereswwds_28_tfcholicencia, AV101Configuracion_chofereswwds_29_tfcholicencia_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK316 = false;
            A548ChoRuc = P00314_A548ChoRuc[0];
            A549ChoSts = P00314_A549ChoSts[0];
            A545ChoDir = P00314_A545ChoDir[0];
            A10ChoCod = P00314_A10ChoCod[0];
            A546ChoLicencia = P00314_A546ChoLicencia[0];
            A543ChoPlaca = P00314_A543ChoPlaca[0];
            A542ChoDsc = P00314_A542ChoDsc[0];
            AV44count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00314_A548ChoRuc[0], A548ChoRuc) == 0 ) )
            {
               BRK316 = false;
               A10ChoCod = P00314_A10ChoCod[0];
               AV44count = (long)(AV44count+1);
               BRK316 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A548ChoRuc)) )
            {
               AV36Option = A548ChoRuc;
               AV37Options.Add(AV36Option, 0);
               AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV37Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK316 )
            {
               BRK316 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADCHOPLACAOPTIONS' Routine */
         returnInSub = false;
         AV22TFChoPlaca = AV32SearchTxt;
         AV23TFChoPlaca_Sel = "";
         AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 = AV50DynamicFiltersSelector1;
         AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 = AV51DynamicFiltersOperator1;
         AV75Configuracion_chofereswwds_3_chodsc1 = AV52ChoDsc1;
         AV76Configuracion_chofereswwds_4_choplaca1 = AV63ChoPlaca1;
         AV77Configuracion_chofereswwds_5_cholicencia1 = AV64ChoLicencia1;
         AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 = AV53DynamicFiltersEnabled2;
         AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 = AV54DynamicFiltersSelector2;
         AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 = AV55DynamicFiltersOperator2;
         AV81Configuracion_chofereswwds_9_chodsc2 = AV56ChoDsc2;
         AV82Configuracion_chofereswwds_10_choplaca2 = AV65ChoPlaca2;
         AV83Configuracion_chofereswwds_11_cholicencia2 = AV66ChoLicencia2;
         AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV87Configuracion_chofereswwds_15_chodsc3 = AV60ChoDsc3;
         AV88Configuracion_chofereswwds_16_choplaca3 = AV67ChoPlaca3;
         AV89Configuracion_chofereswwds_17_cholicencia3 = AV68ChoLicencia3;
         AV90Configuracion_chofereswwds_18_tfchocod = AV10TFChoCod;
         AV91Configuracion_chofereswwds_19_tfchocod_to = AV11TFChoCod_To;
         AV92Configuracion_chofereswwds_20_tfchodsc = AV12TFChoDsc;
         AV93Configuracion_chofereswwds_21_tfchodsc_sel = AV13TFChoDsc_Sel;
         AV94Configuracion_chofereswwds_22_tfchodir = AV14TFChoDir;
         AV95Configuracion_chofereswwds_23_tfchodir_sel = AV15TFChoDir_Sel;
         AV96Configuracion_chofereswwds_24_tfchoruc = AV18TFChoRuc;
         AV97Configuracion_chofereswwds_25_tfchoruc_sel = AV19TFChoRuc_Sel;
         AV98Configuracion_chofereswwds_26_tfchoplaca = AV22TFChoPlaca;
         AV99Configuracion_chofereswwds_27_tfchoplaca_sel = AV23TFChoPlaca_Sel;
         AV100Configuracion_chofereswwds_28_tfcholicencia = AV24TFChoLicencia;
         AV101Configuracion_chofereswwds_29_tfcholicencia_sel = AV25TFChoLicencia_Sel;
         AV102Configuracion_chofereswwds_30_tfchosts_sels = AV62TFChoSts_Sels;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A549ChoSts ,
                                              AV102Configuracion_chofereswwds_30_tfchosts_sels ,
                                              AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 ,
                                              AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 ,
                                              AV75Configuracion_chofereswwds_3_chodsc1 ,
                                              AV76Configuracion_chofereswwds_4_choplaca1 ,
                                              AV77Configuracion_chofereswwds_5_cholicencia1 ,
                                              AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 ,
                                              AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 ,
                                              AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 ,
                                              AV81Configuracion_chofereswwds_9_chodsc2 ,
                                              AV82Configuracion_chofereswwds_10_choplaca2 ,
                                              AV83Configuracion_chofereswwds_11_cholicencia2 ,
                                              AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 ,
                                              AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 ,
                                              AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 ,
                                              AV87Configuracion_chofereswwds_15_chodsc3 ,
                                              AV88Configuracion_chofereswwds_16_choplaca3 ,
                                              AV89Configuracion_chofereswwds_17_cholicencia3 ,
                                              AV90Configuracion_chofereswwds_18_tfchocod ,
                                              AV91Configuracion_chofereswwds_19_tfchocod_to ,
                                              AV93Configuracion_chofereswwds_21_tfchodsc_sel ,
                                              AV92Configuracion_chofereswwds_20_tfchodsc ,
                                              AV95Configuracion_chofereswwds_23_tfchodir_sel ,
                                              AV94Configuracion_chofereswwds_22_tfchodir ,
                                              AV97Configuracion_chofereswwds_25_tfchoruc_sel ,
                                              AV96Configuracion_chofereswwds_24_tfchoruc ,
                                              AV99Configuracion_chofereswwds_27_tfchoplaca_sel ,
                                              AV98Configuracion_chofereswwds_26_tfchoplaca ,
                                              AV101Configuracion_chofereswwds_29_tfcholicencia_sel ,
                                              AV100Configuracion_chofereswwds_28_tfcholicencia ,
                                              AV102Configuracion_chofereswwds_30_tfchosts_sels.Count ,
                                              A542ChoDsc ,
                                              A543ChoPlaca ,
                                              A546ChoLicencia ,
                                              A10ChoCod ,
                                              A545ChoDir ,
                                              A548ChoRuc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV75Configuracion_chofereswwds_3_chodsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1), 100, "%");
         lV75Configuracion_chofereswwds_3_chodsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1), 100, "%");
         lV76Configuracion_chofereswwds_4_choplaca1 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1), 20, "%");
         lV76Configuracion_chofereswwds_4_choplaca1 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1), 20, "%");
         lV77Configuracion_chofereswwds_5_cholicencia1 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1), 20, "%");
         lV77Configuracion_chofereswwds_5_cholicencia1 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1), 20, "%");
         lV81Configuracion_chofereswwds_9_chodsc2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2), 100, "%");
         lV81Configuracion_chofereswwds_9_chodsc2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2), 100, "%");
         lV82Configuracion_chofereswwds_10_choplaca2 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2), 20, "%");
         lV82Configuracion_chofereswwds_10_choplaca2 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2), 20, "%");
         lV83Configuracion_chofereswwds_11_cholicencia2 = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2), 20, "%");
         lV83Configuracion_chofereswwds_11_cholicencia2 = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2), 20, "%");
         lV87Configuracion_chofereswwds_15_chodsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3), 100, "%");
         lV87Configuracion_chofereswwds_15_chodsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3), 100, "%");
         lV88Configuracion_chofereswwds_16_choplaca3 = StringUtil.PadR( StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3), 20, "%");
         lV88Configuracion_chofereswwds_16_choplaca3 = StringUtil.PadR( StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3), 20, "%");
         lV89Configuracion_chofereswwds_17_cholicencia3 = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3), 20, "%");
         lV89Configuracion_chofereswwds_17_cholicencia3 = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3), 20, "%");
         lV92Configuracion_chofereswwds_20_tfchodsc = StringUtil.PadR( StringUtil.RTrim( AV92Configuracion_chofereswwds_20_tfchodsc), 100, "%");
         lV94Configuracion_chofereswwds_22_tfchodir = StringUtil.PadR( StringUtil.RTrim( AV94Configuracion_chofereswwds_22_tfchodir), 100, "%");
         lV96Configuracion_chofereswwds_24_tfchoruc = StringUtil.PadR( StringUtil.RTrim( AV96Configuracion_chofereswwds_24_tfchoruc), 20, "%");
         lV98Configuracion_chofereswwds_26_tfchoplaca = StringUtil.PadR( StringUtil.RTrim( AV98Configuracion_chofereswwds_26_tfchoplaca), 20, "%");
         lV100Configuracion_chofereswwds_28_tfcholicencia = StringUtil.PadR( StringUtil.RTrim( AV100Configuracion_chofereswwds_28_tfcholicencia), 20, "%");
         /* Using cursor P00315 */
         pr_default.execute(3, new Object[] {lV75Configuracion_chofereswwds_3_chodsc1, lV75Configuracion_chofereswwds_3_chodsc1, lV76Configuracion_chofereswwds_4_choplaca1, lV76Configuracion_chofereswwds_4_choplaca1, lV77Configuracion_chofereswwds_5_cholicencia1, lV77Configuracion_chofereswwds_5_cholicencia1, lV81Configuracion_chofereswwds_9_chodsc2, lV81Configuracion_chofereswwds_9_chodsc2, lV82Configuracion_chofereswwds_10_choplaca2, lV82Configuracion_chofereswwds_10_choplaca2, lV83Configuracion_chofereswwds_11_cholicencia2, lV83Configuracion_chofereswwds_11_cholicencia2, lV87Configuracion_chofereswwds_15_chodsc3, lV87Configuracion_chofereswwds_15_chodsc3, lV88Configuracion_chofereswwds_16_choplaca3, lV88Configuracion_chofereswwds_16_choplaca3, lV89Configuracion_chofereswwds_17_cholicencia3, lV89Configuracion_chofereswwds_17_cholicencia3, AV90Configuracion_chofereswwds_18_tfchocod, AV91Configuracion_chofereswwds_19_tfchocod_to, lV92Configuracion_chofereswwds_20_tfchodsc, AV93Configuracion_chofereswwds_21_tfchodsc_sel, lV94Configuracion_chofereswwds_22_tfchodir, AV95Configuracion_chofereswwds_23_tfchodir_sel, lV96Configuracion_chofereswwds_24_tfchoruc, AV97Configuracion_chofereswwds_25_tfchoruc_sel, lV98Configuracion_chofereswwds_26_tfchoplaca, AV99Configuracion_chofereswwds_27_tfchoplaca_sel, lV100Configuracion_chofereswwds_28_tfcholicencia, AV101Configuracion_chofereswwds_29_tfcholicencia_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK318 = false;
            A543ChoPlaca = P00315_A543ChoPlaca[0];
            A549ChoSts = P00315_A549ChoSts[0];
            A548ChoRuc = P00315_A548ChoRuc[0];
            A545ChoDir = P00315_A545ChoDir[0];
            A10ChoCod = P00315_A10ChoCod[0];
            A546ChoLicencia = P00315_A546ChoLicencia[0];
            A542ChoDsc = P00315_A542ChoDsc[0];
            AV44count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00315_A543ChoPlaca[0], A543ChoPlaca) == 0 ) )
            {
               BRK318 = false;
               A10ChoCod = P00315_A10ChoCod[0];
               AV44count = (long)(AV44count+1);
               BRK318 = true;
               pr_default.readNext(3);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A543ChoPlaca)) )
            {
               AV36Option = A543ChoPlaca;
               AV37Options.Add(AV36Option, 0);
               AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV37Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK318 )
            {
               BRK318 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADCHOLICENCIAOPTIONS' Routine */
         returnInSub = false;
         AV24TFChoLicencia = AV32SearchTxt;
         AV25TFChoLicencia_Sel = "";
         AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 = AV50DynamicFiltersSelector1;
         AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 = AV51DynamicFiltersOperator1;
         AV75Configuracion_chofereswwds_3_chodsc1 = AV52ChoDsc1;
         AV76Configuracion_chofereswwds_4_choplaca1 = AV63ChoPlaca1;
         AV77Configuracion_chofereswwds_5_cholicencia1 = AV64ChoLicencia1;
         AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 = AV53DynamicFiltersEnabled2;
         AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 = AV54DynamicFiltersSelector2;
         AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 = AV55DynamicFiltersOperator2;
         AV81Configuracion_chofereswwds_9_chodsc2 = AV56ChoDsc2;
         AV82Configuracion_chofereswwds_10_choplaca2 = AV65ChoPlaca2;
         AV83Configuracion_chofereswwds_11_cholicencia2 = AV66ChoLicencia2;
         AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV87Configuracion_chofereswwds_15_chodsc3 = AV60ChoDsc3;
         AV88Configuracion_chofereswwds_16_choplaca3 = AV67ChoPlaca3;
         AV89Configuracion_chofereswwds_17_cholicencia3 = AV68ChoLicencia3;
         AV90Configuracion_chofereswwds_18_tfchocod = AV10TFChoCod;
         AV91Configuracion_chofereswwds_19_tfchocod_to = AV11TFChoCod_To;
         AV92Configuracion_chofereswwds_20_tfchodsc = AV12TFChoDsc;
         AV93Configuracion_chofereswwds_21_tfchodsc_sel = AV13TFChoDsc_Sel;
         AV94Configuracion_chofereswwds_22_tfchodir = AV14TFChoDir;
         AV95Configuracion_chofereswwds_23_tfchodir_sel = AV15TFChoDir_Sel;
         AV96Configuracion_chofereswwds_24_tfchoruc = AV18TFChoRuc;
         AV97Configuracion_chofereswwds_25_tfchoruc_sel = AV19TFChoRuc_Sel;
         AV98Configuracion_chofereswwds_26_tfchoplaca = AV22TFChoPlaca;
         AV99Configuracion_chofereswwds_27_tfchoplaca_sel = AV23TFChoPlaca_Sel;
         AV100Configuracion_chofereswwds_28_tfcholicencia = AV24TFChoLicencia;
         AV101Configuracion_chofereswwds_29_tfcholicencia_sel = AV25TFChoLicencia_Sel;
         AV102Configuracion_chofereswwds_30_tfchosts_sels = AV62TFChoSts_Sels;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A549ChoSts ,
                                              AV102Configuracion_chofereswwds_30_tfchosts_sels ,
                                              AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 ,
                                              AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 ,
                                              AV75Configuracion_chofereswwds_3_chodsc1 ,
                                              AV76Configuracion_chofereswwds_4_choplaca1 ,
                                              AV77Configuracion_chofereswwds_5_cholicencia1 ,
                                              AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 ,
                                              AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 ,
                                              AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 ,
                                              AV81Configuracion_chofereswwds_9_chodsc2 ,
                                              AV82Configuracion_chofereswwds_10_choplaca2 ,
                                              AV83Configuracion_chofereswwds_11_cholicencia2 ,
                                              AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 ,
                                              AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 ,
                                              AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 ,
                                              AV87Configuracion_chofereswwds_15_chodsc3 ,
                                              AV88Configuracion_chofereswwds_16_choplaca3 ,
                                              AV89Configuracion_chofereswwds_17_cholicencia3 ,
                                              AV90Configuracion_chofereswwds_18_tfchocod ,
                                              AV91Configuracion_chofereswwds_19_tfchocod_to ,
                                              AV93Configuracion_chofereswwds_21_tfchodsc_sel ,
                                              AV92Configuracion_chofereswwds_20_tfchodsc ,
                                              AV95Configuracion_chofereswwds_23_tfchodir_sel ,
                                              AV94Configuracion_chofereswwds_22_tfchodir ,
                                              AV97Configuracion_chofereswwds_25_tfchoruc_sel ,
                                              AV96Configuracion_chofereswwds_24_tfchoruc ,
                                              AV99Configuracion_chofereswwds_27_tfchoplaca_sel ,
                                              AV98Configuracion_chofereswwds_26_tfchoplaca ,
                                              AV101Configuracion_chofereswwds_29_tfcholicencia_sel ,
                                              AV100Configuracion_chofereswwds_28_tfcholicencia ,
                                              AV102Configuracion_chofereswwds_30_tfchosts_sels.Count ,
                                              A542ChoDsc ,
                                              A543ChoPlaca ,
                                              A546ChoLicencia ,
                                              A10ChoCod ,
                                              A545ChoDir ,
                                              A548ChoRuc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV75Configuracion_chofereswwds_3_chodsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1), 100, "%");
         lV75Configuracion_chofereswwds_3_chodsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1), 100, "%");
         lV76Configuracion_chofereswwds_4_choplaca1 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1), 20, "%");
         lV76Configuracion_chofereswwds_4_choplaca1 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1), 20, "%");
         lV77Configuracion_chofereswwds_5_cholicencia1 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1), 20, "%");
         lV77Configuracion_chofereswwds_5_cholicencia1 = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1), 20, "%");
         lV81Configuracion_chofereswwds_9_chodsc2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2), 100, "%");
         lV81Configuracion_chofereswwds_9_chodsc2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2), 100, "%");
         lV82Configuracion_chofereswwds_10_choplaca2 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2), 20, "%");
         lV82Configuracion_chofereswwds_10_choplaca2 = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2), 20, "%");
         lV83Configuracion_chofereswwds_11_cholicencia2 = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2), 20, "%");
         lV83Configuracion_chofereswwds_11_cholicencia2 = StringUtil.PadR( StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2), 20, "%");
         lV87Configuracion_chofereswwds_15_chodsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3), 100, "%");
         lV87Configuracion_chofereswwds_15_chodsc3 = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3), 100, "%");
         lV88Configuracion_chofereswwds_16_choplaca3 = StringUtil.PadR( StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3), 20, "%");
         lV88Configuracion_chofereswwds_16_choplaca3 = StringUtil.PadR( StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3), 20, "%");
         lV89Configuracion_chofereswwds_17_cholicencia3 = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3), 20, "%");
         lV89Configuracion_chofereswwds_17_cholicencia3 = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3), 20, "%");
         lV92Configuracion_chofereswwds_20_tfchodsc = StringUtil.PadR( StringUtil.RTrim( AV92Configuracion_chofereswwds_20_tfchodsc), 100, "%");
         lV94Configuracion_chofereswwds_22_tfchodir = StringUtil.PadR( StringUtil.RTrim( AV94Configuracion_chofereswwds_22_tfchodir), 100, "%");
         lV96Configuracion_chofereswwds_24_tfchoruc = StringUtil.PadR( StringUtil.RTrim( AV96Configuracion_chofereswwds_24_tfchoruc), 20, "%");
         lV98Configuracion_chofereswwds_26_tfchoplaca = StringUtil.PadR( StringUtil.RTrim( AV98Configuracion_chofereswwds_26_tfchoplaca), 20, "%");
         lV100Configuracion_chofereswwds_28_tfcholicencia = StringUtil.PadR( StringUtil.RTrim( AV100Configuracion_chofereswwds_28_tfcholicencia), 20, "%");
         /* Using cursor P00316 */
         pr_default.execute(4, new Object[] {lV75Configuracion_chofereswwds_3_chodsc1, lV75Configuracion_chofereswwds_3_chodsc1, lV76Configuracion_chofereswwds_4_choplaca1, lV76Configuracion_chofereswwds_4_choplaca1, lV77Configuracion_chofereswwds_5_cholicencia1, lV77Configuracion_chofereswwds_5_cholicencia1, lV81Configuracion_chofereswwds_9_chodsc2, lV81Configuracion_chofereswwds_9_chodsc2, lV82Configuracion_chofereswwds_10_choplaca2, lV82Configuracion_chofereswwds_10_choplaca2, lV83Configuracion_chofereswwds_11_cholicencia2, lV83Configuracion_chofereswwds_11_cholicencia2, lV87Configuracion_chofereswwds_15_chodsc3, lV87Configuracion_chofereswwds_15_chodsc3, lV88Configuracion_chofereswwds_16_choplaca3, lV88Configuracion_chofereswwds_16_choplaca3, lV89Configuracion_chofereswwds_17_cholicencia3, lV89Configuracion_chofereswwds_17_cholicencia3, AV90Configuracion_chofereswwds_18_tfchocod, AV91Configuracion_chofereswwds_19_tfchocod_to, lV92Configuracion_chofereswwds_20_tfchodsc, AV93Configuracion_chofereswwds_21_tfchodsc_sel, lV94Configuracion_chofereswwds_22_tfchodir, AV95Configuracion_chofereswwds_23_tfchodir_sel, lV96Configuracion_chofereswwds_24_tfchoruc, AV97Configuracion_chofereswwds_25_tfchoruc_sel, lV98Configuracion_chofereswwds_26_tfchoplaca, AV99Configuracion_chofereswwds_27_tfchoplaca_sel, lV100Configuracion_chofereswwds_28_tfcholicencia, AV101Configuracion_chofereswwds_29_tfcholicencia_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK3110 = false;
            A546ChoLicencia = P00316_A546ChoLicencia[0];
            A549ChoSts = P00316_A549ChoSts[0];
            A548ChoRuc = P00316_A548ChoRuc[0];
            A545ChoDir = P00316_A545ChoDir[0];
            A10ChoCod = P00316_A10ChoCod[0];
            A543ChoPlaca = P00316_A543ChoPlaca[0];
            A542ChoDsc = P00316_A542ChoDsc[0];
            AV44count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00316_A546ChoLicencia[0], A546ChoLicencia) == 0 ) )
            {
               BRK3110 = false;
               A10ChoCod = P00316_A10ChoCod[0];
               AV44count = (long)(AV44count+1);
               BRK3110 = true;
               pr_default.readNext(4);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A546ChoLicencia)) )
            {
               AV36Option = A546ChoLicencia;
               AV37Options.Add(AV36Option, 0);
               AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV44count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV37Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK3110 )
            {
               BRK3110 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
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
         AV38OptionsJson = "";
         AV41OptionsDescJson = "";
         AV43OptionIndexesJson = "";
         AV37Options = new GxSimpleCollection<string>();
         AV40OptionsDesc = new GxSimpleCollection<string>();
         AV42OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV45Session = context.GetSession();
         AV47GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV48GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV12TFChoDsc = "";
         AV13TFChoDsc_Sel = "";
         AV14TFChoDir = "";
         AV15TFChoDir_Sel = "";
         AV18TFChoRuc = "";
         AV19TFChoRuc_Sel = "";
         AV22TFChoPlaca = "";
         AV23TFChoPlaca_Sel = "";
         AV24TFChoLicencia = "";
         AV25TFChoLicencia_Sel = "";
         AV61TFChoSts_SelsJson = "";
         AV62TFChoSts_Sels = new GxSimpleCollection<short>();
         AV49GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV50DynamicFiltersSelector1 = "";
         AV52ChoDsc1 = "";
         AV63ChoPlaca1 = "";
         AV64ChoLicencia1 = "";
         AV54DynamicFiltersSelector2 = "";
         AV56ChoDsc2 = "";
         AV65ChoPlaca2 = "";
         AV66ChoLicencia2 = "";
         AV58DynamicFiltersSelector3 = "";
         AV60ChoDsc3 = "";
         AV67ChoPlaca3 = "";
         AV68ChoLicencia3 = "";
         AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 = "";
         AV75Configuracion_chofereswwds_3_chodsc1 = "";
         AV76Configuracion_chofereswwds_4_choplaca1 = "";
         AV77Configuracion_chofereswwds_5_cholicencia1 = "";
         AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 = "";
         AV81Configuracion_chofereswwds_9_chodsc2 = "";
         AV82Configuracion_chofereswwds_10_choplaca2 = "";
         AV83Configuracion_chofereswwds_11_cholicencia2 = "";
         AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 = "";
         AV87Configuracion_chofereswwds_15_chodsc3 = "";
         AV88Configuracion_chofereswwds_16_choplaca3 = "";
         AV89Configuracion_chofereswwds_17_cholicencia3 = "";
         AV92Configuracion_chofereswwds_20_tfchodsc = "";
         AV93Configuracion_chofereswwds_21_tfchodsc_sel = "";
         AV94Configuracion_chofereswwds_22_tfchodir = "";
         AV95Configuracion_chofereswwds_23_tfchodir_sel = "";
         AV96Configuracion_chofereswwds_24_tfchoruc = "";
         AV97Configuracion_chofereswwds_25_tfchoruc_sel = "";
         AV98Configuracion_chofereswwds_26_tfchoplaca = "";
         AV99Configuracion_chofereswwds_27_tfchoplaca_sel = "";
         AV100Configuracion_chofereswwds_28_tfcholicencia = "";
         AV101Configuracion_chofereswwds_29_tfcholicencia_sel = "";
         AV102Configuracion_chofereswwds_30_tfchosts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV75Configuracion_chofereswwds_3_chodsc1 = "";
         lV76Configuracion_chofereswwds_4_choplaca1 = "";
         lV77Configuracion_chofereswwds_5_cholicencia1 = "";
         lV81Configuracion_chofereswwds_9_chodsc2 = "";
         lV82Configuracion_chofereswwds_10_choplaca2 = "";
         lV83Configuracion_chofereswwds_11_cholicencia2 = "";
         lV87Configuracion_chofereswwds_15_chodsc3 = "";
         lV88Configuracion_chofereswwds_16_choplaca3 = "";
         lV89Configuracion_chofereswwds_17_cholicencia3 = "";
         lV92Configuracion_chofereswwds_20_tfchodsc = "";
         lV94Configuracion_chofereswwds_22_tfchodir = "";
         lV96Configuracion_chofereswwds_24_tfchoruc = "";
         lV98Configuracion_chofereswwds_26_tfchoplaca = "";
         lV100Configuracion_chofereswwds_28_tfcholicencia = "";
         A542ChoDsc = "";
         A543ChoPlaca = "";
         A546ChoLicencia = "";
         A545ChoDir = "";
         A548ChoRuc = "";
         P00312_A542ChoDsc = new string[] {""} ;
         P00312_A549ChoSts = new short[1] ;
         P00312_A548ChoRuc = new string[] {""} ;
         P00312_A545ChoDir = new string[] {""} ;
         P00312_A10ChoCod = new int[1] ;
         P00312_A546ChoLicencia = new string[] {""} ;
         P00312_A543ChoPlaca = new string[] {""} ;
         AV36Option = "";
         P00313_A545ChoDir = new string[] {""} ;
         P00313_A549ChoSts = new short[1] ;
         P00313_A548ChoRuc = new string[] {""} ;
         P00313_A10ChoCod = new int[1] ;
         P00313_A546ChoLicencia = new string[] {""} ;
         P00313_A543ChoPlaca = new string[] {""} ;
         P00313_A542ChoDsc = new string[] {""} ;
         P00314_A548ChoRuc = new string[] {""} ;
         P00314_A549ChoSts = new short[1] ;
         P00314_A545ChoDir = new string[] {""} ;
         P00314_A10ChoCod = new int[1] ;
         P00314_A546ChoLicencia = new string[] {""} ;
         P00314_A543ChoPlaca = new string[] {""} ;
         P00314_A542ChoDsc = new string[] {""} ;
         P00315_A543ChoPlaca = new string[] {""} ;
         P00315_A549ChoSts = new short[1] ;
         P00315_A548ChoRuc = new string[] {""} ;
         P00315_A545ChoDir = new string[] {""} ;
         P00315_A10ChoCod = new int[1] ;
         P00315_A546ChoLicencia = new string[] {""} ;
         P00315_A542ChoDsc = new string[] {""} ;
         P00316_A546ChoLicencia = new string[] {""} ;
         P00316_A549ChoSts = new short[1] ;
         P00316_A548ChoRuc = new string[] {""} ;
         P00316_A545ChoDir = new string[] {""} ;
         P00316_A10ChoCod = new int[1] ;
         P00316_A543ChoPlaca = new string[] {""} ;
         P00316_A542ChoDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.chofereswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00312_A542ChoDsc, P00312_A549ChoSts, P00312_A548ChoRuc, P00312_A545ChoDir, P00312_A10ChoCod, P00312_A546ChoLicencia, P00312_A543ChoPlaca
               }
               , new Object[] {
               P00313_A545ChoDir, P00313_A549ChoSts, P00313_A548ChoRuc, P00313_A10ChoCod, P00313_A546ChoLicencia, P00313_A543ChoPlaca, P00313_A542ChoDsc
               }
               , new Object[] {
               P00314_A548ChoRuc, P00314_A549ChoSts, P00314_A545ChoDir, P00314_A10ChoCod, P00314_A546ChoLicencia, P00314_A543ChoPlaca, P00314_A542ChoDsc
               }
               , new Object[] {
               P00315_A543ChoPlaca, P00315_A549ChoSts, P00315_A548ChoRuc, P00315_A545ChoDir, P00315_A10ChoCod, P00315_A546ChoLicencia, P00315_A542ChoDsc
               }
               , new Object[] {
               P00316_A546ChoLicencia, P00316_A549ChoSts, P00316_A548ChoRuc, P00316_A545ChoDir, P00316_A10ChoCod, P00316_A543ChoPlaca, P00316_A542ChoDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV51DynamicFiltersOperator1 ;
      private short AV55DynamicFiltersOperator2 ;
      private short AV59DynamicFiltersOperator3 ;
      private short AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 ;
      private short AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 ;
      private short AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 ;
      private short A549ChoSts ;
      private int AV71GXV1 ;
      private int AV10TFChoCod ;
      private int AV11TFChoCod_To ;
      private int AV90Configuracion_chofereswwds_18_tfchocod ;
      private int AV91Configuracion_chofereswwds_19_tfchocod_to ;
      private int AV102Configuracion_chofereswwds_30_tfchosts_sels_Count ;
      private int A10ChoCod ;
      private long AV44count ;
      private string AV12TFChoDsc ;
      private string AV13TFChoDsc_Sel ;
      private string AV14TFChoDir ;
      private string AV15TFChoDir_Sel ;
      private string AV18TFChoRuc ;
      private string AV19TFChoRuc_Sel ;
      private string AV22TFChoPlaca ;
      private string AV23TFChoPlaca_Sel ;
      private string AV24TFChoLicencia ;
      private string AV25TFChoLicencia_Sel ;
      private string AV52ChoDsc1 ;
      private string AV63ChoPlaca1 ;
      private string AV64ChoLicencia1 ;
      private string AV56ChoDsc2 ;
      private string AV65ChoPlaca2 ;
      private string AV66ChoLicencia2 ;
      private string AV60ChoDsc3 ;
      private string AV67ChoPlaca3 ;
      private string AV68ChoLicencia3 ;
      private string AV75Configuracion_chofereswwds_3_chodsc1 ;
      private string AV76Configuracion_chofereswwds_4_choplaca1 ;
      private string AV77Configuracion_chofereswwds_5_cholicencia1 ;
      private string AV81Configuracion_chofereswwds_9_chodsc2 ;
      private string AV82Configuracion_chofereswwds_10_choplaca2 ;
      private string AV83Configuracion_chofereswwds_11_cholicencia2 ;
      private string AV87Configuracion_chofereswwds_15_chodsc3 ;
      private string AV88Configuracion_chofereswwds_16_choplaca3 ;
      private string AV89Configuracion_chofereswwds_17_cholicencia3 ;
      private string AV92Configuracion_chofereswwds_20_tfchodsc ;
      private string AV93Configuracion_chofereswwds_21_tfchodsc_sel ;
      private string AV94Configuracion_chofereswwds_22_tfchodir ;
      private string AV95Configuracion_chofereswwds_23_tfchodir_sel ;
      private string AV96Configuracion_chofereswwds_24_tfchoruc ;
      private string AV97Configuracion_chofereswwds_25_tfchoruc_sel ;
      private string AV98Configuracion_chofereswwds_26_tfchoplaca ;
      private string AV99Configuracion_chofereswwds_27_tfchoplaca_sel ;
      private string AV100Configuracion_chofereswwds_28_tfcholicencia ;
      private string AV101Configuracion_chofereswwds_29_tfcholicencia_sel ;
      private string scmdbuf ;
      private string lV75Configuracion_chofereswwds_3_chodsc1 ;
      private string lV76Configuracion_chofereswwds_4_choplaca1 ;
      private string lV77Configuracion_chofereswwds_5_cholicencia1 ;
      private string lV81Configuracion_chofereswwds_9_chodsc2 ;
      private string lV82Configuracion_chofereswwds_10_choplaca2 ;
      private string lV83Configuracion_chofereswwds_11_cholicencia2 ;
      private string lV87Configuracion_chofereswwds_15_chodsc3 ;
      private string lV88Configuracion_chofereswwds_16_choplaca3 ;
      private string lV89Configuracion_chofereswwds_17_cholicencia3 ;
      private string lV92Configuracion_chofereswwds_20_tfchodsc ;
      private string lV94Configuracion_chofereswwds_22_tfchodir ;
      private string lV96Configuracion_chofereswwds_24_tfchoruc ;
      private string lV98Configuracion_chofereswwds_26_tfchoplaca ;
      private string lV100Configuracion_chofereswwds_28_tfcholicencia ;
      private string A542ChoDsc ;
      private string A543ChoPlaca ;
      private string A546ChoLicencia ;
      private string A545ChoDir ;
      private string A548ChoRuc ;
      private bool returnInSub ;
      private bool AV53DynamicFiltersEnabled2 ;
      private bool AV57DynamicFiltersEnabled3 ;
      private bool AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 ;
      private bool AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 ;
      private bool BRK312 ;
      private bool BRK314 ;
      private bool BRK316 ;
      private bool BRK318 ;
      private bool BRK3110 ;
      private string AV38OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV43OptionIndexesJson ;
      private string AV61TFChoSts_SelsJson ;
      private string AV34DDOName ;
      private string AV32SearchTxt ;
      private string AV33SearchTxtTo ;
      private string AV50DynamicFiltersSelector1 ;
      private string AV54DynamicFiltersSelector2 ;
      private string AV58DynamicFiltersSelector3 ;
      private string AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 ;
      private string AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 ;
      private string AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 ;
      private string AV36Option ;
      private GxSimpleCollection<short> AV62TFChoSts_Sels ;
      private GxSimpleCollection<short> AV102Configuracion_chofereswwds_30_tfchosts_sels ;
      private IGxSession AV45Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00312_A542ChoDsc ;
      private short[] P00312_A549ChoSts ;
      private string[] P00312_A548ChoRuc ;
      private string[] P00312_A545ChoDir ;
      private int[] P00312_A10ChoCod ;
      private string[] P00312_A546ChoLicencia ;
      private string[] P00312_A543ChoPlaca ;
      private string[] P00313_A545ChoDir ;
      private short[] P00313_A549ChoSts ;
      private string[] P00313_A548ChoRuc ;
      private int[] P00313_A10ChoCod ;
      private string[] P00313_A546ChoLicencia ;
      private string[] P00313_A543ChoPlaca ;
      private string[] P00313_A542ChoDsc ;
      private string[] P00314_A548ChoRuc ;
      private short[] P00314_A549ChoSts ;
      private string[] P00314_A545ChoDir ;
      private int[] P00314_A10ChoCod ;
      private string[] P00314_A546ChoLicencia ;
      private string[] P00314_A543ChoPlaca ;
      private string[] P00314_A542ChoDsc ;
      private string[] P00315_A543ChoPlaca ;
      private short[] P00315_A549ChoSts ;
      private string[] P00315_A548ChoRuc ;
      private string[] P00315_A545ChoDir ;
      private int[] P00315_A10ChoCod ;
      private string[] P00315_A546ChoLicencia ;
      private string[] P00315_A542ChoDsc ;
      private string[] P00316_A546ChoLicencia ;
      private short[] P00316_A549ChoSts ;
      private string[] P00316_A548ChoRuc ;
      private string[] P00316_A545ChoDir ;
      private int[] P00316_A10ChoCod ;
      private string[] P00316_A543ChoPlaca ;
      private string[] P00316_A542ChoDsc ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV37Options ;
      private GxSimpleCollection<string> AV40OptionsDesc ;
      private GxSimpleCollection<string> AV42OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV47GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV48GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV49GridStateDynamicFilter ;
   }

   public class chofereswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00312( IGxContext context ,
                                             short A549ChoSts ,
                                             GxSimpleCollection<short> AV102Configuracion_chofereswwds_30_tfchosts_sels ,
                                             string AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 ,
                                             short AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 ,
                                             string AV75Configuracion_chofereswwds_3_chodsc1 ,
                                             string AV76Configuracion_chofereswwds_4_choplaca1 ,
                                             string AV77Configuracion_chofereswwds_5_cholicencia1 ,
                                             bool AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 ,
                                             string AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 ,
                                             short AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 ,
                                             string AV81Configuracion_chofereswwds_9_chodsc2 ,
                                             string AV82Configuracion_chofereswwds_10_choplaca2 ,
                                             string AV83Configuracion_chofereswwds_11_cholicencia2 ,
                                             bool AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 ,
                                             string AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 ,
                                             short AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 ,
                                             string AV87Configuracion_chofereswwds_15_chodsc3 ,
                                             string AV88Configuracion_chofereswwds_16_choplaca3 ,
                                             string AV89Configuracion_chofereswwds_17_cholicencia3 ,
                                             int AV90Configuracion_chofereswwds_18_tfchocod ,
                                             int AV91Configuracion_chofereswwds_19_tfchocod_to ,
                                             string AV93Configuracion_chofereswwds_21_tfchodsc_sel ,
                                             string AV92Configuracion_chofereswwds_20_tfchodsc ,
                                             string AV95Configuracion_chofereswwds_23_tfchodir_sel ,
                                             string AV94Configuracion_chofereswwds_22_tfchodir ,
                                             string AV97Configuracion_chofereswwds_25_tfchoruc_sel ,
                                             string AV96Configuracion_chofereswwds_24_tfchoruc ,
                                             string AV99Configuracion_chofereswwds_27_tfchoplaca_sel ,
                                             string AV98Configuracion_chofereswwds_26_tfchoplaca ,
                                             string AV101Configuracion_chofereswwds_29_tfcholicencia_sel ,
                                             string AV100Configuracion_chofereswwds_28_tfcholicencia ,
                                             int AV102Configuracion_chofereswwds_30_tfchosts_sels_Count ,
                                             string A542ChoDsc ,
                                             string A543ChoPlaca ,
                                             string A546ChoLicencia ,
                                             int A10ChoCod ,
                                             string A545ChoDir ,
                                             string A548ChoRuc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[30];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ChoDsc], [ChoSts], [ChoRuc], [ChoDir], [ChoCod], [ChoLicencia], [ChoPlaca] FROM [CCHOFERES]";
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHODSC") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV75Configuracion_chofereswwds_3_chodsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHODSC") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV75Configuracion_chofereswwds_3_chodsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOPLACA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV76Configuracion_chofereswwds_4_choplaca1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOPLACA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV76Configuracion_chofereswwds_4_choplaca1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOLICENCIA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV77Configuracion_chofereswwds_5_cholicencia1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOLICENCIA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV77Configuracion_chofereswwds_5_cholicencia1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHODSC") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV81Configuracion_chofereswwds_9_chodsc2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHODSC") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV81Configuracion_chofereswwds_9_chodsc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOPLACA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV82Configuracion_chofereswwds_10_choplaca2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOPLACA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV82Configuracion_chofereswwds_10_choplaca2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOLICENCIA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV83Configuracion_chofereswwds_11_cholicencia2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOLICENCIA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV83Configuracion_chofereswwds_11_cholicencia2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHODSC") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV87Configuracion_chofereswwds_15_chodsc3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHODSC") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV87Configuracion_chofereswwds_15_chodsc3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOPLACA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV88Configuracion_chofereswwds_16_choplaca3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOPLACA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV88Configuracion_chofereswwds_16_choplaca3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOLICENCIA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV89Configuracion_chofereswwds_17_cholicencia3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOLICENCIA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV89Configuracion_chofereswwds_17_cholicencia3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( ! (0==AV90Configuracion_chofereswwds_18_tfchocod) )
         {
            AddWhere(sWhereString, "([ChoCod] >= @AV90Configuracion_chofereswwds_18_tfchocod)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! (0==AV91Configuracion_chofereswwds_19_tfchocod_to) )
         {
            AddWhere(sWhereString, "([ChoCod] <= @AV91Configuracion_chofereswwds_19_tfchocod_to)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_chofereswwds_21_tfchodsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Configuracion_chofereswwds_20_tfchodsc)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV92Configuracion_chofereswwds_20_tfchodsc)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_chofereswwds_21_tfchodsc_sel)) )
         {
            AddWhere(sWhereString, "([ChoDsc] = @AV93Configuracion_chofereswwds_21_tfchodsc_sel)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_chofereswwds_23_tfchodir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Configuracion_chofereswwds_22_tfchodir)) ) )
         {
            AddWhere(sWhereString, "([ChoDir] like @lV94Configuracion_chofereswwds_22_tfchodir)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_chofereswwds_23_tfchodir_sel)) )
         {
            AddWhere(sWhereString, "([ChoDir] = @AV95Configuracion_chofereswwds_23_tfchodir_sel)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_chofereswwds_25_tfchoruc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Configuracion_chofereswwds_24_tfchoruc)) ) )
         {
            AddWhere(sWhereString, "([ChoRuc] like @lV96Configuracion_chofereswwds_24_tfchoruc)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_chofereswwds_25_tfchoruc_sel)) )
         {
            AddWhere(sWhereString, "([ChoRuc] = @AV97Configuracion_chofereswwds_25_tfchoruc_sel)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_chofereswwds_27_tfchoplaca_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Configuracion_chofereswwds_26_tfchoplaca)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV98Configuracion_chofereswwds_26_tfchoplaca)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_chofereswwds_27_tfchoplaca_sel)) )
         {
            AddWhere(sWhereString, "([ChoPlaca] = @AV99Configuracion_chofereswwds_27_tfchoplaca_sel)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Configuracion_chofereswwds_29_tfcholicencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Configuracion_chofereswwds_28_tfcholicencia)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV100Configuracion_chofereswwds_28_tfcholicencia)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Configuracion_chofereswwds_29_tfcholicencia_sel)) )
         {
            AddWhere(sWhereString, "([ChoLicencia] = @AV101Configuracion_chofereswwds_29_tfcholicencia_sel)");
         }
         else
         {
            GXv_int1[29] = 1;
         }
         if ( AV102Configuracion_chofereswwds_30_tfchosts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV102Configuracion_chofereswwds_30_tfchosts_sels, "[ChoSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ChoDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00313( IGxContext context ,
                                             short A549ChoSts ,
                                             GxSimpleCollection<short> AV102Configuracion_chofereswwds_30_tfchosts_sels ,
                                             string AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 ,
                                             short AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 ,
                                             string AV75Configuracion_chofereswwds_3_chodsc1 ,
                                             string AV76Configuracion_chofereswwds_4_choplaca1 ,
                                             string AV77Configuracion_chofereswwds_5_cholicencia1 ,
                                             bool AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 ,
                                             string AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 ,
                                             short AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 ,
                                             string AV81Configuracion_chofereswwds_9_chodsc2 ,
                                             string AV82Configuracion_chofereswwds_10_choplaca2 ,
                                             string AV83Configuracion_chofereswwds_11_cholicencia2 ,
                                             bool AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 ,
                                             string AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 ,
                                             short AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 ,
                                             string AV87Configuracion_chofereswwds_15_chodsc3 ,
                                             string AV88Configuracion_chofereswwds_16_choplaca3 ,
                                             string AV89Configuracion_chofereswwds_17_cholicencia3 ,
                                             int AV90Configuracion_chofereswwds_18_tfchocod ,
                                             int AV91Configuracion_chofereswwds_19_tfchocod_to ,
                                             string AV93Configuracion_chofereswwds_21_tfchodsc_sel ,
                                             string AV92Configuracion_chofereswwds_20_tfchodsc ,
                                             string AV95Configuracion_chofereswwds_23_tfchodir_sel ,
                                             string AV94Configuracion_chofereswwds_22_tfchodir ,
                                             string AV97Configuracion_chofereswwds_25_tfchoruc_sel ,
                                             string AV96Configuracion_chofereswwds_24_tfchoruc ,
                                             string AV99Configuracion_chofereswwds_27_tfchoplaca_sel ,
                                             string AV98Configuracion_chofereswwds_26_tfchoplaca ,
                                             string AV101Configuracion_chofereswwds_29_tfcholicencia_sel ,
                                             string AV100Configuracion_chofereswwds_28_tfcholicencia ,
                                             int AV102Configuracion_chofereswwds_30_tfchosts_sels_Count ,
                                             string A542ChoDsc ,
                                             string A543ChoPlaca ,
                                             string A546ChoLicencia ,
                                             int A10ChoCod ,
                                             string A545ChoDir ,
                                             string A548ChoRuc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[30];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [ChoDir], [ChoSts], [ChoRuc], [ChoCod], [ChoLicencia], [ChoPlaca], [ChoDsc] FROM [CCHOFERES]";
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHODSC") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV75Configuracion_chofereswwds_3_chodsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHODSC") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV75Configuracion_chofereswwds_3_chodsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOPLACA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV76Configuracion_chofereswwds_4_choplaca1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOPLACA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV76Configuracion_chofereswwds_4_choplaca1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOLICENCIA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV77Configuracion_chofereswwds_5_cholicencia1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOLICENCIA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV77Configuracion_chofereswwds_5_cholicencia1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHODSC") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV81Configuracion_chofereswwds_9_chodsc2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHODSC") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV81Configuracion_chofereswwds_9_chodsc2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOPLACA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV82Configuracion_chofereswwds_10_choplaca2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOPLACA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV82Configuracion_chofereswwds_10_choplaca2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOLICENCIA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV83Configuracion_chofereswwds_11_cholicencia2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOLICENCIA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV83Configuracion_chofereswwds_11_cholicencia2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHODSC") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV87Configuracion_chofereswwds_15_chodsc3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHODSC") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV87Configuracion_chofereswwds_15_chodsc3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOPLACA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV88Configuracion_chofereswwds_16_choplaca3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOPLACA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV88Configuracion_chofereswwds_16_choplaca3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOLICENCIA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV89Configuracion_chofereswwds_17_cholicencia3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOLICENCIA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV89Configuracion_chofereswwds_17_cholicencia3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( ! (0==AV90Configuracion_chofereswwds_18_tfchocod) )
         {
            AddWhere(sWhereString, "([ChoCod] >= @AV90Configuracion_chofereswwds_18_tfchocod)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! (0==AV91Configuracion_chofereswwds_19_tfchocod_to) )
         {
            AddWhere(sWhereString, "([ChoCod] <= @AV91Configuracion_chofereswwds_19_tfchocod_to)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_chofereswwds_21_tfchodsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Configuracion_chofereswwds_20_tfchodsc)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV92Configuracion_chofereswwds_20_tfchodsc)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_chofereswwds_21_tfchodsc_sel)) )
         {
            AddWhere(sWhereString, "([ChoDsc] = @AV93Configuracion_chofereswwds_21_tfchodsc_sel)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_chofereswwds_23_tfchodir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Configuracion_chofereswwds_22_tfchodir)) ) )
         {
            AddWhere(sWhereString, "([ChoDir] like @lV94Configuracion_chofereswwds_22_tfchodir)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_chofereswwds_23_tfchodir_sel)) )
         {
            AddWhere(sWhereString, "([ChoDir] = @AV95Configuracion_chofereswwds_23_tfchodir_sel)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_chofereswwds_25_tfchoruc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Configuracion_chofereswwds_24_tfchoruc)) ) )
         {
            AddWhere(sWhereString, "([ChoRuc] like @lV96Configuracion_chofereswwds_24_tfchoruc)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_chofereswwds_25_tfchoruc_sel)) )
         {
            AddWhere(sWhereString, "([ChoRuc] = @AV97Configuracion_chofereswwds_25_tfchoruc_sel)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_chofereswwds_27_tfchoplaca_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Configuracion_chofereswwds_26_tfchoplaca)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV98Configuracion_chofereswwds_26_tfchoplaca)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_chofereswwds_27_tfchoplaca_sel)) )
         {
            AddWhere(sWhereString, "([ChoPlaca] = @AV99Configuracion_chofereswwds_27_tfchoplaca_sel)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Configuracion_chofereswwds_29_tfcholicencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Configuracion_chofereswwds_28_tfcholicencia)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV100Configuracion_chofereswwds_28_tfcholicencia)");
         }
         else
         {
            GXv_int3[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Configuracion_chofereswwds_29_tfcholicencia_sel)) )
         {
            AddWhere(sWhereString, "([ChoLicencia] = @AV101Configuracion_chofereswwds_29_tfcholicencia_sel)");
         }
         else
         {
            GXv_int3[29] = 1;
         }
         if ( AV102Configuracion_chofereswwds_30_tfchosts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV102Configuracion_chofereswwds_30_tfchosts_sels, "[ChoSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ChoDir]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00314( IGxContext context ,
                                             short A549ChoSts ,
                                             GxSimpleCollection<short> AV102Configuracion_chofereswwds_30_tfchosts_sels ,
                                             string AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 ,
                                             short AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 ,
                                             string AV75Configuracion_chofereswwds_3_chodsc1 ,
                                             string AV76Configuracion_chofereswwds_4_choplaca1 ,
                                             string AV77Configuracion_chofereswwds_5_cholicencia1 ,
                                             bool AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 ,
                                             string AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 ,
                                             short AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 ,
                                             string AV81Configuracion_chofereswwds_9_chodsc2 ,
                                             string AV82Configuracion_chofereswwds_10_choplaca2 ,
                                             string AV83Configuracion_chofereswwds_11_cholicencia2 ,
                                             bool AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 ,
                                             string AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 ,
                                             short AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 ,
                                             string AV87Configuracion_chofereswwds_15_chodsc3 ,
                                             string AV88Configuracion_chofereswwds_16_choplaca3 ,
                                             string AV89Configuracion_chofereswwds_17_cholicencia3 ,
                                             int AV90Configuracion_chofereswwds_18_tfchocod ,
                                             int AV91Configuracion_chofereswwds_19_tfchocod_to ,
                                             string AV93Configuracion_chofereswwds_21_tfchodsc_sel ,
                                             string AV92Configuracion_chofereswwds_20_tfchodsc ,
                                             string AV95Configuracion_chofereswwds_23_tfchodir_sel ,
                                             string AV94Configuracion_chofereswwds_22_tfchodir ,
                                             string AV97Configuracion_chofereswwds_25_tfchoruc_sel ,
                                             string AV96Configuracion_chofereswwds_24_tfchoruc ,
                                             string AV99Configuracion_chofereswwds_27_tfchoplaca_sel ,
                                             string AV98Configuracion_chofereswwds_26_tfchoplaca ,
                                             string AV101Configuracion_chofereswwds_29_tfcholicencia_sel ,
                                             string AV100Configuracion_chofereswwds_28_tfcholicencia ,
                                             int AV102Configuracion_chofereswwds_30_tfchosts_sels_Count ,
                                             string A542ChoDsc ,
                                             string A543ChoPlaca ,
                                             string A546ChoLicencia ,
                                             int A10ChoCod ,
                                             string A545ChoDir ,
                                             string A548ChoRuc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[30];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [ChoRuc], [ChoSts], [ChoDir], [ChoCod], [ChoLicencia], [ChoPlaca], [ChoDsc] FROM [CCHOFERES]";
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHODSC") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV75Configuracion_chofereswwds_3_chodsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHODSC") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV75Configuracion_chofereswwds_3_chodsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOPLACA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV76Configuracion_chofereswwds_4_choplaca1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOPLACA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV76Configuracion_chofereswwds_4_choplaca1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOLICENCIA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV77Configuracion_chofereswwds_5_cholicencia1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOLICENCIA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV77Configuracion_chofereswwds_5_cholicencia1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHODSC") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV81Configuracion_chofereswwds_9_chodsc2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHODSC") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV81Configuracion_chofereswwds_9_chodsc2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOPLACA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV82Configuracion_chofereswwds_10_choplaca2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOPLACA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV82Configuracion_chofereswwds_10_choplaca2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOLICENCIA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV83Configuracion_chofereswwds_11_cholicencia2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOLICENCIA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV83Configuracion_chofereswwds_11_cholicencia2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHODSC") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV87Configuracion_chofereswwds_15_chodsc3)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHODSC") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV87Configuracion_chofereswwds_15_chodsc3)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOPLACA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV88Configuracion_chofereswwds_16_choplaca3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOPLACA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV88Configuracion_chofereswwds_16_choplaca3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOLICENCIA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV89Configuracion_chofereswwds_17_cholicencia3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOLICENCIA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV89Configuracion_chofereswwds_17_cholicencia3)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( ! (0==AV90Configuracion_chofereswwds_18_tfchocod) )
         {
            AddWhere(sWhereString, "([ChoCod] >= @AV90Configuracion_chofereswwds_18_tfchocod)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! (0==AV91Configuracion_chofereswwds_19_tfchocod_to) )
         {
            AddWhere(sWhereString, "([ChoCod] <= @AV91Configuracion_chofereswwds_19_tfchocod_to)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_chofereswwds_21_tfchodsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Configuracion_chofereswwds_20_tfchodsc)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV92Configuracion_chofereswwds_20_tfchodsc)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_chofereswwds_21_tfchodsc_sel)) )
         {
            AddWhere(sWhereString, "([ChoDsc] = @AV93Configuracion_chofereswwds_21_tfchodsc_sel)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_chofereswwds_23_tfchodir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Configuracion_chofereswwds_22_tfchodir)) ) )
         {
            AddWhere(sWhereString, "([ChoDir] like @lV94Configuracion_chofereswwds_22_tfchodir)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_chofereswwds_23_tfchodir_sel)) )
         {
            AddWhere(sWhereString, "([ChoDir] = @AV95Configuracion_chofereswwds_23_tfchodir_sel)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_chofereswwds_25_tfchoruc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Configuracion_chofereswwds_24_tfchoruc)) ) )
         {
            AddWhere(sWhereString, "([ChoRuc] like @lV96Configuracion_chofereswwds_24_tfchoruc)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_chofereswwds_25_tfchoruc_sel)) )
         {
            AddWhere(sWhereString, "([ChoRuc] = @AV97Configuracion_chofereswwds_25_tfchoruc_sel)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_chofereswwds_27_tfchoplaca_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Configuracion_chofereswwds_26_tfchoplaca)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV98Configuracion_chofereswwds_26_tfchoplaca)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_chofereswwds_27_tfchoplaca_sel)) )
         {
            AddWhere(sWhereString, "([ChoPlaca] = @AV99Configuracion_chofereswwds_27_tfchoplaca_sel)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Configuracion_chofereswwds_29_tfcholicencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Configuracion_chofereswwds_28_tfcholicencia)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV100Configuracion_chofereswwds_28_tfcholicencia)");
         }
         else
         {
            GXv_int5[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Configuracion_chofereswwds_29_tfcholicencia_sel)) )
         {
            AddWhere(sWhereString, "([ChoLicencia] = @AV101Configuracion_chofereswwds_29_tfcholicencia_sel)");
         }
         else
         {
            GXv_int5[29] = 1;
         }
         if ( AV102Configuracion_chofereswwds_30_tfchosts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV102Configuracion_chofereswwds_30_tfchosts_sels, "[ChoSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ChoRuc]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00315( IGxContext context ,
                                             short A549ChoSts ,
                                             GxSimpleCollection<short> AV102Configuracion_chofereswwds_30_tfchosts_sels ,
                                             string AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 ,
                                             short AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 ,
                                             string AV75Configuracion_chofereswwds_3_chodsc1 ,
                                             string AV76Configuracion_chofereswwds_4_choplaca1 ,
                                             string AV77Configuracion_chofereswwds_5_cholicencia1 ,
                                             bool AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 ,
                                             string AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 ,
                                             short AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 ,
                                             string AV81Configuracion_chofereswwds_9_chodsc2 ,
                                             string AV82Configuracion_chofereswwds_10_choplaca2 ,
                                             string AV83Configuracion_chofereswwds_11_cholicencia2 ,
                                             bool AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 ,
                                             string AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 ,
                                             short AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 ,
                                             string AV87Configuracion_chofereswwds_15_chodsc3 ,
                                             string AV88Configuracion_chofereswwds_16_choplaca3 ,
                                             string AV89Configuracion_chofereswwds_17_cholicencia3 ,
                                             int AV90Configuracion_chofereswwds_18_tfchocod ,
                                             int AV91Configuracion_chofereswwds_19_tfchocod_to ,
                                             string AV93Configuracion_chofereswwds_21_tfchodsc_sel ,
                                             string AV92Configuracion_chofereswwds_20_tfchodsc ,
                                             string AV95Configuracion_chofereswwds_23_tfchodir_sel ,
                                             string AV94Configuracion_chofereswwds_22_tfchodir ,
                                             string AV97Configuracion_chofereswwds_25_tfchoruc_sel ,
                                             string AV96Configuracion_chofereswwds_24_tfchoruc ,
                                             string AV99Configuracion_chofereswwds_27_tfchoplaca_sel ,
                                             string AV98Configuracion_chofereswwds_26_tfchoplaca ,
                                             string AV101Configuracion_chofereswwds_29_tfcholicencia_sel ,
                                             string AV100Configuracion_chofereswwds_28_tfcholicencia ,
                                             int AV102Configuracion_chofereswwds_30_tfchosts_sels_Count ,
                                             string A542ChoDsc ,
                                             string A543ChoPlaca ,
                                             string A546ChoLicencia ,
                                             int A10ChoCod ,
                                             string A545ChoDir ,
                                             string A548ChoRuc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[30];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT [ChoPlaca], [ChoSts], [ChoRuc], [ChoDir], [ChoCod], [ChoLicencia], [ChoDsc] FROM [CCHOFERES]";
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHODSC") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV75Configuracion_chofereswwds_3_chodsc1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHODSC") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV75Configuracion_chofereswwds_3_chodsc1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOPLACA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV76Configuracion_chofereswwds_4_choplaca1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOPLACA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV76Configuracion_chofereswwds_4_choplaca1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOLICENCIA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV77Configuracion_chofereswwds_5_cholicencia1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOLICENCIA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV77Configuracion_chofereswwds_5_cholicencia1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHODSC") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV81Configuracion_chofereswwds_9_chodsc2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHODSC") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV81Configuracion_chofereswwds_9_chodsc2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOPLACA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV82Configuracion_chofereswwds_10_choplaca2)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOPLACA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV82Configuracion_chofereswwds_10_choplaca2)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOLICENCIA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV83Configuracion_chofereswwds_11_cholicencia2)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOLICENCIA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV83Configuracion_chofereswwds_11_cholicencia2)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHODSC") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV87Configuracion_chofereswwds_15_chodsc3)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHODSC") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV87Configuracion_chofereswwds_15_chodsc3)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOPLACA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV88Configuracion_chofereswwds_16_choplaca3)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOPLACA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV88Configuracion_chofereswwds_16_choplaca3)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOLICENCIA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV89Configuracion_chofereswwds_17_cholicencia3)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOLICENCIA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV89Configuracion_chofereswwds_17_cholicencia3)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( ! (0==AV90Configuracion_chofereswwds_18_tfchocod) )
         {
            AddWhere(sWhereString, "([ChoCod] >= @AV90Configuracion_chofereswwds_18_tfchocod)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! (0==AV91Configuracion_chofereswwds_19_tfchocod_to) )
         {
            AddWhere(sWhereString, "([ChoCod] <= @AV91Configuracion_chofereswwds_19_tfchocod_to)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_chofereswwds_21_tfchodsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Configuracion_chofereswwds_20_tfchodsc)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV92Configuracion_chofereswwds_20_tfchodsc)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_chofereswwds_21_tfchodsc_sel)) )
         {
            AddWhere(sWhereString, "([ChoDsc] = @AV93Configuracion_chofereswwds_21_tfchodsc_sel)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_chofereswwds_23_tfchodir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Configuracion_chofereswwds_22_tfchodir)) ) )
         {
            AddWhere(sWhereString, "([ChoDir] like @lV94Configuracion_chofereswwds_22_tfchodir)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_chofereswwds_23_tfchodir_sel)) )
         {
            AddWhere(sWhereString, "([ChoDir] = @AV95Configuracion_chofereswwds_23_tfchodir_sel)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_chofereswwds_25_tfchoruc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Configuracion_chofereswwds_24_tfchoruc)) ) )
         {
            AddWhere(sWhereString, "([ChoRuc] like @lV96Configuracion_chofereswwds_24_tfchoruc)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_chofereswwds_25_tfchoruc_sel)) )
         {
            AddWhere(sWhereString, "([ChoRuc] = @AV97Configuracion_chofereswwds_25_tfchoruc_sel)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_chofereswwds_27_tfchoplaca_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Configuracion_chofereswwds_26_tfchoplaca)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV98Configuracion_chofereswwds_26_tfchoplaca)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_chofereswwds_27_tfchoplaca_sel)) )
         {
            AddWhere(sWhereString, "([ChoPlaca] = @AV99Configuracion_chofereswwds_27_tfchoplaca_sel)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Configuracion_chofereswwds_29_tfcholicencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Configuracion_chofereswwds_28_tfcholicencia)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV100Configuracion_chofereswwds_28_tfcholicencia)");
         }
         else
         {
            GXv_int7[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Configuracion_chofereswwds_29_tfcholicencia_sel)) )
         {
            AddWhere(sWhereString, "([ChoLicencia] = @AV101Configuracion_chofereswwds_29_tfcholicencia_sel)");
         }
         else
         {
            GXv_int7[29] = 1;
         }
         if ( AV102Configuracion_chofereswwds_30_tfchosts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV102Configuracion_chofereswwds_30_tfchosts_sels, "[ChoSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ChoPlaca]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P00316( IGxContext context ,
                                             short A549ChoSts ,
                                             GxSimpleCollection<short> AV102Configuracion_chofereswwds_30_tfchosts_sels ,
                                             string AV73Configuracion_chofereswwds_1_dynamicfiltersselector1 ,
                                             short AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 ,
                                             string AV75Configuracion_chofereswwds_3_chodsc1 ,
                                             string AV76Configuracion_chofereswwds_4_choplaca1 ,
                                             string AV77Configuracion_chofereswwds_5_cholicencia1 ,
                                             bool AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 ,
                                             string AV79Configuracion_chofereswwds_7_dynamicfiltersselector2 ,
                                             short AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 ,
                                             string AV81Configuracion_chofereswwds_9_chodsc2 ,
                                             string AV82Configuracion_chofereswwds_10_choplaca2 ,
                                             string AV83Configuracion_chofereswwds_11_cholicencia2 ,
                                             bool AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 ,
                                             string AV85Configuracion_chofereswwds_13_dynamicfiltersselector3 ,
                                             short AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 ,
                                             string AV87Configuracion_chofereswwds_15_chodsc3 ,
                                             string AV88Configuracion_chofereswwds_16_choplaca3 ,
                                             string AV89Configuracion_chofereswwds_17_cholicencia3 ,
                                             int AV90Configuracion_chofereswwds_18_tfchocod ,
                                             int AV91Configuracion_chofereswwds_19_tfchocod_to ,
                                             string AV93Configuracion_chofereswwds_21_tfchodsc_sel ,
                                             string AV92Configuracion_chofereswwds_20_tfchodsc ,
                                             string AV95Configuracion_chofereswwds_23_tfchodir_sel ,
                                             string AV94Configuracion_chofereswwds_22_tfchodir ,
                                             string AV97Configuracion_chofereswwds_25_tfchoruc_sel ,
                                             string AV96Configuracion_chofereswwds_24_tfchoruc ,
                                             string AV99Configuracion_chofereswwds_27_tfchoplaca_sel ,
                                             string AV98Configuracion_chofereswwds_26_tfchoplaca ,
                                             string AV101Configuracion_chofereswwds_29_tfcholicencia_sel ,
                                             string AV100Configuracion_chofereswwds_28_tfcholicencia ,
                                             int AV102Configuracion_chofereswwds_30_tfchosts_sels_Count ,
                                             string A542ChoDsc ,
                                             string A543ChoPlaca ,
                                             string A546ChoLicencia ,
                                             int A10ChoCod ,
                                             string A545ChoDir ,
                                             string A548ChoRuc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[30];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT [ChoLicencia], [ChoSts], [ChoRuc], [ChoDir], [ChoCod], [ChoPlaca], [ChoDsc] FROM [CCHOFERES]";
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHODSC") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV75Configuracion_chofereswwds_3_chodsc1)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHODSC") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_chofereswwds_3_chodsc1)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV75Configuracion_chofereswwds_3_chodsc1)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOPLACA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV76Configuracion_chofereswwds_4_choplaca1)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOPLACA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_chofereswwds_4_choplaca1)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV76Configuracion_chofereswwds_4_choplaca1)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOLICENCIA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV77Configuracion_chofereswwds_5_cholicencia1)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_chofereswwds_1_dynamicfiltersselector1, "CHOLICENCIA") == 0 ) && ( AV74Configuracion_chofereswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_chofereswwds_5_cholicencia1)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV77Configuracion_chofereswwds_5_cholicencia1)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHODSC") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV81Configuracion_chofereswwds_9_chodsc2)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHODSC") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_chofereswwds_9_chodsc2)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV81Configuracion_chofereswwds_9_chodsc2)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOPLACA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV82Configuracion_chofereswwds_10_choplaca2)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOPLACA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_chofereswwds_10_choplaca2)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV82Configuracion_chofereswwds_10_choplaca2)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOLICENCIA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV83Configuracion_chofereswwds_11_cholicencia2)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( AV78Configuracion_chofereswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Configuracion_chofereswwds_7_dynamicfiltersselector2, "CHOLICENCIA") == 0 ) && ( AV80Configuracion_chofereswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_chofereswwds_11_cholicencia2)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV83Configuracion_chofereswwds_11_cholicencia2)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHODSC") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV87Configuracion_chofereswwds_15_chodsc3)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHODSC") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_chofereswwds_15_chodsc3)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like '%' + @lV87Configuracion_chofereswwds_15_chodsc3)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOPLACA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV88Configuracion_chofereswwds_16_choplaca3)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOPLACA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_chofereswwds_16_choplaca3)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like '%' + @lV88Configuracion_chofereswwds_16_choplaca3)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOLICENCIA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV89Configuracion_chofereswwds_17_cholicencia3)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( AV84Configuracion_chofereswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV85Configuracion_chofereswwds_13_dynamicfiltersselector3, "CHOLICENCIA") == 0 ) && ( AV86Configuracion_chofereswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_chofereswwds_17_cholicencia3)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like '%' + @lV89Configuracion_chofereswwds_17_cholicencia3)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( ! (0==AV90Configuracion_chofereswwds_18_tfchocod) )
         {
            AddWhere(sWhereString, "([ChoCod] >= @AV90Configuracion_chofereswwds_18_tfchocod)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ! (0==AV91Configuracion_chofereswwds_19_tfchocod_to) )
         {
            AddWhere(sWhereString, "([ChoCod] <= @AV91Configuracion_chofereswwds_19_tfchocod_to)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_chofereswwds_21_tfchodsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Configuracion_chofereswwds_20_tfchodsc)) ) )
         {
            AddWhere(sWhereString, "([ChoDsc] like @lV92Configuracion_chofereswwds_20_tfchodsc)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Configuracion_chofereswwds_21_tfchodsc_sel)) )
         {
            AddWhere(sWhereString, "([ChoDsc] = @AV93Configuracion_chofereswwds_21_tfchodsc_sel)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_chofereswwds_23_tfchodir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Configuracion_chofereswwds_22_tfchodir)) ) )
         {
            AddWhere(sWhereString, "([ChoDir] like @lV94Configuracion_chofereswwds_22_tfchodir)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Configuracion_chofereswwds_23_tfchodir_sel)) )
         {
            AddWhere(sWhereString, "([ChoDir] = @AV95Configuracion_chofereswwds_23_tfchodir_sel)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_chofereswwds_25_tfchoruc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Configuracion_chofereswwds_24_tfchoruc)) ) )
         {
            AddWhere(sWhereString, "([ChoRuc] like @lV96Configuracion_chofereswwds_24_tfchoruc)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Configuracion_chofereswwds_25_tfchoruc_sel)) )
         {
            AddWhere(sWhereString, "([ChoRuc] = @AV97Configuracion_chofereswwds_25_tfchoruc_sel)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_chofereswwds_27_tfchoplaca_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Configuracion_chofereswwds_26_tfchoplaca)) ) )
         {
            AddWhere(sWhereString, "([ChoPlaca] like @lV98Configuracion_chofereswwds_26_tfchoplaca)");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Configuracion_chofereswwds_27_tfchoplaca_sel)) )
         {
            AddWhere(sWhereString, "([ChoPlaca] = @AV99Configuracion_chofereswwds_27_tfchoplaca_sel)");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Configuracion_chofereswwds_29_tfcholicencia_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Configuracion_chofereswwds_28_tfcholicencia)) ) )
         {
            AddWhere(sWhereString, "([ChoLicencia] like @lV100Configuracion_chofereswwds_28_tfcholicencia)");
         }
         else
         {
            GXv_int9[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Configuracion_chofereswwds_29_tfcholicencia_sel)) )
         {
            AddWhere(sWhereString, "([ChoLicencia] = @AV101Configuracion_chofereswwds_29_tfcholicencia_sel)");
         }
         else
         {
            GXv_int9[29] = 1;
         }
         if ( AV102Configuracion_chofereswwds_30_tfchosts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV102Configuracion_chofereswwds_30_tfchosts_sels, "[ChoSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ChoLicencia]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00312(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (int)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] );
               case 1 :
                     return conditional_P00313(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (int)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] );
               case 2 :
                     return conditional_P00314(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (int)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] );
               case 3 :
                     return conditional_P00315(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (int)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] );
               case 4 :
                     return conditional_P00316(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (int)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] );
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
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00312;
          prmP00312 = new Object[] {
          new ParDef("@lV75Configuracion_chofereswwds_3_chodsc1",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_chofereswwds_3_chodsc1",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_chofereswwds_4_choplaca1",GXType.NChar,20,0) ,
          new ParDef("@lV76Configuracion_chofereswwds_4_choplaca1",GXType.NChar,20,0) ,
          new ParDef("@lV77Configuracion_chofereswwds_5_cholicencia1",GXType.NChar,20,0) ,
          new ParDef("@lV77Configuracion_chofereswwds_5_cholicencia1",GXType.NChar,20,0) ,
          new ParDef("@lV81Configuracion_chofereswwds_9_chodsc2",GXType.NChar,100,0) ,
          new ParDef("@lV81Configuracion_chofereswwds_9_chodsc2",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_chofereswwds_10_choplaca2",GXType.NChar,20,0) ,
          new ParDef("@lV82Configuracion_chofereswwds_10_choplaca2",GXType.NChar,20,0) ,
          new ParDef("@lV83Configuracion_chofereswwds_11_cholicencia2",GXType.NChar,20,0) ,
          new ParDef("@lV83Configuracion_chofereswwds_11_cholicencia2",GXType.NChar,20,0) ,
          new ParDef("@lV87Configuracion_chofereswwds_15_chodsc3",GXType.NChar,100,0) ,
          new ParDef("@lV87Configuracion_chofereswwds_15_chodsc3",GXType.NChar,100,0) ,
          new ParDef("@lV88Configuracion_chofereswwds_16_choplaca3",GXType.NChar,20,0) ,
          new ParDef("@lV88Configuracion_chofereswwds_16_choplaca3",GXType.NChar,20,0) ,
          new ParDef("@lV89Configuracion_chofereswwds_17_cholicencia3",GXType.NChar,20,0) ,
          new ParDef("@lV89Configuracion_chofereswwds_17_cholicencia3",GXType.NChar,20,0) ,
          new ParDef("@AV90Configuracion_chofereswwds_18_tfchocod",GXType.Int32,6,0) ,
          new ParDef("@AV91Configuracion_chofereswwds_19_tfchocod_to",GXType.Int32,6,0) ,
          new ParDef("@lV92Configuracion_chofereswwds_20_tfchodsc",GXType.NChar,100,0) ,
          new ParDef("@AV93Configuracion_chofereswwds_21_tfchodsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV94Configuracion_chofereswwds_22_tfchodir",GXType.NChar,100,0) ,
          new ParDef("@AV95Configuracion_chofereswwds_23_tfchodir_sel",GXType.NChar,100,0) ,
          new ParDef("@lV96Configuracion_chofereswwds_24_tfchoruc",GXType.NChar,20,0) ,
          new ParDef("@AV97Configuracion_chofereswwds_25_tfchoruc_sel",GXType.NChar,20,0) ,
          new ParDef("@lV98Configuracion_chofereswwds_26_tfchoplaca",GXType.NChar,20,0) ,
          new ParDef("@AV99Configuracion_chofereswwds_27_tfchoplaca_sel",GXType.NChar,20,0) ,
          new ParDef("@lV100Configuracion_chofereswwds_28_tfcholicencia",GXType.NChar,20,0) ,
          new ParDef("@AV101Configuracion_chofereswwds_29_tfcholicencia_sel",GXType.NChar,20,0)
          };
          Object[] prmP00313;
          prmP00313 = new Object[] {
          new ParDef("@lV75Configuracion_chofereswwds_3_chodsc1",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_chofereswwds_3_chodsc1",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_chofereswwds_4_choplaca1",GXType.NChar,20,0) ,
          new ParDef("@lV76Configuracion_chofereswwds_4_choplaca1",GXType.NChar,20,0) ,
          new ParDef("@lV77Configuracion_chofereswwds_5_cholicencia1",GXType.NChar,20,0) ,
          new ParDef("@lV77Configuracion_chofereswwds_5_cholicencia1",GXType.NChar,20,0) ,
          new ParDef("@lV81Configuracion_chofereswwds_9_chodsc2",GXType.NChar,100,0) ,
          new ParDef("@lV81Configuracion_chofereswwds_9_chodsc2",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_chofereswwds_10_choplaca2",GXType.NChar,20,0) ,
          new ParDef("@lV82Configuracion_chofereswwds_10_choplaca2",GXType.NChar,20,0) ,
          new ParDef("@lV83Configuracion_chofereswwds_11_cholicencia2",GXType.NChar,20,0) ,
          new ParDef("@lV83Configuracion_chofereswwds_11_cholicencia2",GXType.NChar,20,0) ,
          new ParDef("@lV87Configuracion_chofereswwds_15_chodsc3",GXType.NChar,100,0) ,
          new ParDef("@lV87Configuracion_chofereswwds_15_chodsc3",GXType.NChar,100,0) ,
          new ParDef("@lV88Configuracion_chofereswwds_16_choplaca3",GXType.NChar,20,0) ,
          new ParDef("@lV88Configuracion_chofereswwds_16_choplaca3",GXType.NChar,20,0) ,
          new ParDef("@lV89Configuracion_chofereswwds_17_cholicencia3",GXType.NChar,20,0) ,
          new ParDef("@lV89Configuracion_chofereswwds_17_cholicencia3",GXType.NChar,20,0) ,
          new ParDef("@AV90Configuracion_chofereswwds_18_tfchocod",GXType.Int32,6,0) ,
          new ParDef("@AV91Configuracion_chofereswwds_19_tfchocod_to",GXType.Int32,6,0) ,
          new ParDef("@lV92Configuracion_chofereswwds_20_tfchodsc",GXType.NChar,100,0) ,
          new ParDef("@AV93Configuracion_chofereswwds_21_tfchodsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV94Configuracion_chofereswwds_22_tfchodir",GXType.NChar,100,0) ,
          new ParDef("@AV95Configuracion_chofereswwds_23_tfchodir_sel",GXType.NChar,100,0) ,
          new ParDef("@lV96Configuracion_chofereswwds_24_tfchoruc",GXType.NChar,20,0) ,
          new ParDef("@AV97Configuracion_chofereswwds_25_tfchoruc_sel",GXType.NChar,20,0) ,
          new ParDef("@lV98Configuracion_chofereswwds_26_tfchoplaca",GXType.NChar,20,0) ,
          new ParDef("@AV99Configuracion_chofereswwds_27_tfchoplaca_sel",GXType.NChar,20,0) ,
          new ParDef("@lV100Configuracion_chofereswwds_28_tfcholicencia",GXType.NChar,20,0) ,
          new ParDef("@AV101Configuracion_chofereswwds_29_tfcholicencia_sel",GXType.NChar,20,0)
          };
          Object[] prmP00314;
          prmP00314 = new Object[] {
          new ParDef("@lV75Configuracion_chofereswwds_3_chodsc1",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_chofereswwds_3_chodsc1",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_chofereswwds_4_choplaca1",GXType.NChar,20,0) ,
          new ParDef("@lV76Configuracion_chofereswwds_4_choplaca1",GXType.NChar,20,0) ,
          new ParDef("@lV77Configuracion_chofereswwds_5_cholicencia1",GXType.NChar,20,0) ,
          new ParDef("@lV77Configuracion_chofereswwds_5_cholicencia1",GXType.NChar,20,0) ,
          new ParDef("@lV81Configuracion_chofereswwds_9_chodsc2",GXType.NChar,100,0) ,
          new ParDef("@lV81Configuracion_chofereswwds_9_chodsc2",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_chofereswwds_10_choplaca2",GXType.NChar,20,0) ,
          new ParDef("@lV82Configuracion_chofereswwds_10_choplaca2",GXType.NChar,20,0) ,
          new ParDef("@lV83Configuracion_chofereswwds_11_cholicencia2",GXType.NChar,20,0) ,
          new ParDef("@lV83Configuracion_chofereswwds_11_cholicencia2",GXType.NChar,20,0) ,
          new ParDef("@lV87Configuracion_chofereswwds_15_chodsc3",GXType.NChar,100,0) ,
          new ParDef("@lV87Configuracion_chofereswwds_15_chodsc3",GXType.NChar,100,0) ,
          new ParDef("@lV88Configuracion_chofereswwds_16_choplaca3",GXType.NChar,20,0) ,
          new ParDef("@lV88Configuracion_chofereswwds_16_choplaca3",GXType.NChar,20,0) ,
          new ParDef("@lV89Configuracion_chofereswwds_17_cholicencia3",GXType.NChar,20,0) ,
          new ParDef("@lV89Configuracion_chofereswwds_17_cholicencia3",GXType.NChar,20,0) ,
          new ParDef("@AV90Configuracion_chofereswwds_18_tfchocod",GXType.Int32,6,0) ,
          new ParDef("@AV91Configuracion_chofereswwds_19_tfchocod_to",GXType.Int32,6,0) ,
          new ParDef("@lV92Configuracion_chofereswwds_20_tfchodsc",GXType.NChar,100,0) ,
          new ParDef("@AV93Configuracion_chofereswwds_21_tfchodsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV94Configuracion_chofereswwds_22_tfchodir",GXType.NChar,100,0) ,
          new ParDef("@AV95Configuracion_chofereswwds_23_tfchodir_sel",GXType.NChar,100,0) ,
          new ParDef("@lV96Configuracion_chofereswwds_24_tfchoruc",GXType.NChar,20,0) ,
          new ParDef("@AV97Configuracion_chofereswwds_25_tfchoruc_sel",GXType.NChar,20,0) ,
          new ParDef("@lV98Configuracion_chofereswwds_26_tfchoplaca",GXType.NChar,20,0) ,
          new ParDef("@AV99Configuracion_chofereswwds_27_tfchoplaca_sel",GXType.NChar,20,0) ,
          new ParDef("@lV100Configuracion_chofereswwds_28_tfcholicencia",GXType.NChar,20,0) ,
          new ParDef("@AV101Configuracion_chofereswwds_29_tfcholicencia_sel",GXType.NChar,20,0)
          };
          Object[] prmP00315;
          prmP00315 = new Object[] {
          new ParDef("@lV75Configuracion_chofereswwds_3_chodsc1",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_chofereswwds_3_chodsc1",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_chofereswwds_4_choplaca1",GXType.NChar,20,0) ,
          new ParDef("@lV76Configuracion_chofereswwds_4_choplaca1",GXType.NChar,20,0) ,
          new ParDef("@lV77Configuracion_chofereswwds_5_cholicencia1",GXType.NChar,20,0) ,
          new ParDef("@lV77Configuracion_chofereswwds_5_cholicencia1",GXType.NChar,20,0) ,
          new ParDef("@lV81Configuracion_chofereswwds_9_chodsc2",GXType.NChar,100,0) ,
          new ParDef("@lV81Configuracion_chofereswwds_9_chodsc2",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_chofereswwds_10_choplaca2",GXType.NChar,20,0) ,
          new ParDef("@lV82Configuracion_chofereswwds_10_choplaca2",GXType.NChar,20,0) ,
          new ParDef("@lV83Configuracion_chofereswwds_11_cholicencia2",GXType.NChar,20,0) ,
          new ParDef("@lV83Configuracion_chofereswwds_11_cholicencia2",GXType.NChar,20,0) ,
          new ParDef("@lV87Configuracion_chofereswwds_15_chodsc3",GXType.NChar,100,0) ,
          new ParDef("@lV87Configuracion_chofereswwds_15_chodsc3",GXType.NChar,100,0) ,
          new ParDef("@lV88Configuracion_chofereswwds_16_choplaca3",GXType.NChar,20,0) ,
          new ParDef("@lV88Configuracion_chofereswwds_16_choplaca3",GXType.NChar,20,0) ,
          new ParDef("@lV89Configuracion_chofereswwds_17_cholicencia3",GXType.NChar,20,0) ,
          new ParDef("@lV89Configuracion_chofereswwds_17_cholicencia3",GXType.NChar,20,0) ,
          new ParDef("@AV90Configuracion_chofereswwds_18_tfchocod",GXType.Int32,6,0) ,
          new ParDef("@AV91Configuracion_chofereswwds_19_tfchocod_to",GXType.Int32,6,0) ,
          new ParDef("@lV92Configuracion_chofereswwds_20_tfchodsc",GXType.NChar,100,0) ,
          new ParDef("@AV93Configuracion_chofereswwds_21_tfchodsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV94Configuracion_chofereswwds_22_tfchodir",GXType.NChar,100,0) ,
          new ParDef("@AV95Configuracion_chofereswwds_23_tfchodir_sel",GXType.NChar,100,0) ,
          new ParDef("@lV96Configuracion_chofereswwds_24_tfchoruc",GXType.NChar,20,0) ,
          new ParDef("@AV97Configuracion_chofereswwds_25_tfchoruc_sel",GXType.NChar,20,0) ,
          new ParDef("@lV98Configuracion_chofereswwds_26_tfchoplaca",GXType.NChar,20,0) ,
          new ParDef("@AV99Configuracion_chofereswwds_27_tfchoplaca_sel",GXType.NChar,20,0) ,
          new ParDef("@lV100Configuracion_chofereswwds_28_tfcholicencia",GXType.NChar,20,0) ,
          new ParDef("@AV101Configuracion_chofereswwds_29_tfcholicencia_sel",GXType.NChar,20,0)
          };
          Object[] prmP00316;
          prmP00316 = new Object[] {
          new ParDef("@lV75Configuracion_chofereswwds_3_chodsc1",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_chofereswwds_3_chodsc1",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_chofereswwds_4_choplaca1",GXType.NChar,20,0) ,
          new ParDef("@lV76Configuracion_chofereswwds_4_choplaca1",GXType.NChar,20,0) ,
          new ParDef("@lV77Configuracion_chofereswwds_5_cholicencia1",GXType.NChar,20,0) ,
          new ParDef("@lV77Configuracion_chofereswwds_5_cholicencia1",GXType.NChar,20,0) ,
          new ParDef("@lV81Configuracion_chofereswwds_9_chodsc2",GXType.NChar,100,0) ,
          new ParDef("@lV81Configuracion_chofereswwds_9_chodsc2",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_chofereswwds_10_choplaca2",GXType.NChar,20,0) ,
          new ParDef("@lV82Configuracion_chofereswwds_10_choplaca2",GXType.NChar,20,0) ,
          new ParDef("@lV83Configuracion_chofereswwds_11_cholicencia2",GXType.NChar,20,0) ,
          new ParDef("@lV83Configuracion_chofereswwds_11_cholicencia2",GXType.NChar,20,0) ,
          new ParDef("@lV87Configuracion_chofereswwds_15_chodsc3",GXType.NChar,100,0) ,
          new ParDef("@lV87Configuracion_chofereswwds_15_chodsc3",GXType.NChar,100,0) ,
          new ParDef("@lV88Configuracion_chofereswwds_16_choplaca3",GXType.NChar,20,0) ,
          new ParDef("@lV88Configuracion_chofereswwds_16_choplaca3",GXType.NChar,20,0) ,
          new ParDef("@lV89Configuracion_chofereswwds_17_cholicencia3",GXType.NChar,20,0) ,
          new ParDef("@lV89Configuracion_chofereswwds_17_cholicencia3",GXType.NChar,20,0) ,
          new ParDef("@AV90Configuracion_chofereswwds_18_tfchocod",GXType.Int32,6,0) ,
          new ParDef("@AV91Configuracion_chofereswwds_19_tfchocod_to",GXType.Int32,6,0) ,
          new ParDef("@lV92Configuracion_chofereswwds_20_tfchodsc",GXType.NChar,100,0) ,
          new ParDef("@AV93Configuracion_chofereswwds_21_tfchodsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV94Configuracion_chofereswwds_22_tfchodir",GXType.NChar,100,0) ,
          new ParDef("@AV95Configuracion_chofereswwds_23_tfchodir_sel",GXType.NChar,100,0) ,
          new ParDef("@lV96Configuracion_chofereswwds_24_tfchoruc",GXType.NChar,20,0) ,
          new ParDef("@AV97Configuracion_chofereswwds_25_tfchoruc_sel",GXType.NChar,20,0) ,
          new ParDef("@lV98Configuracion_chofereswwds_26_tfchoplaca",GXType.NChar,20,0) ,
          new ParDef("@AV99Configuracion_chofereswwds_27_tfchoplaca_sel",GXType.NChar,20,0) ,
          new ParDef("@lV100Configuracion_chofereswwds_28_tfcholicencia",GXType.NChar,20,0) ,
          new ParDef("@AV101Configuracion_chofereswwds_29_tfcholicencia_sel",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00312", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00312,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00313", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00313,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00314", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00314,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00315", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00315,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00316", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00316,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 20);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                return;
       }
    }

 }

}
