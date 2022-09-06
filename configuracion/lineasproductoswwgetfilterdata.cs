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
   public class lineasproductoswwgetfilterdata : GXProcedure
   {
      public lineasproductoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public lineasproductoswwgetfilterdata( IGxContext context )
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
         lineasproductoswwgetfilterdata objlineasproductoswwgetfilterdata;
         objlineasproductoswwgetfilterdata = new lineasproductoswwgetfilterdata();
         objlineasproductoswwgetfilterdata.AV24DDOName = aP0_DDOName;
         objlineasproductoswwgetfilterdata.AV22SearchTxt = aP1_SearchTxt;
         objlineasproductoswwgetfilterdata.AV23SearchTxtTo = aP2_SearchTxtTo;
         objlineasproductoswwgetfilterdata.AV28OptionsJson = "" ;
         objlineasproductoswwgetfilterdata.AV31OptionsDescJson = "" ;
         objlineasproductoswwgetfilterdata.AV33OptionIndexesJson = "" ;
         objlineasproductoswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objlineasproductoswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlineasproductoswwgetfilterdata);
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((lineasproductoswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_LINDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADLINDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_LINABR") == 0 )
         {
            /* Execute user subroutine: 'LOADLINABROPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_LINSUNAT") == 0 )
         {
            /* Execute user subroutine: 'LOADLINSUNATOPTIONS' */
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
         if ( StringUtil.StrCmp(AV35Session.Get("Configuracion.LineasProductosWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.LineasProductosWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("Configuracion.LineasProductosWWGridState"), null, "", "");
         }
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV58GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFLINCOD") == 0 )
            {
               AV10TFLinCod = (int)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."));
               AV11TFLinCod_To = (int)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFLINDSC") == 0 )
            {
               AV12TFLinDsc = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFLINDSC_SEL") == 0 )
            {
               AV13TFLinDsc_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFLINABR") == 0 )
            {
               AV14TFLinAbr = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFLINABR_SEL") == 0 )
            {
               AV15TFLinAbr_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFLINSUNAT") == 0 )
            {
               AV16TFLinSunat = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFLINSUNAT_SEL") == 0 )
            {
               AV17TFLinSunat_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFLINSTK_SEL") == 0 )
            {
               AV54TFLinStk_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV55TFLinStk_Sels.FromJSonString(AV54TFLinStk_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFLINSTS_SEL") == 0 )
            {
               AV51TFLinSts_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV52TFLinSts_Sels.FromJSonString(AV51TFLinSts_SelsJson, null);
            }
            AV58GXV1 = (int)(AV58GXV1+1);
         }
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV39GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "LINDSC") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV42LinDsc1 = AV39GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV43DynamicFiltersEnabled2 = true;
               AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV44DynamicFiltersSelector2 = AV39GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV44DynamicFiltersSelector2, "LINDSC") == 0 )
               {
                  AV45DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV46LinDsc2 = AV39GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV39GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "LINDSC") == 0 )
                  {
                     AV49DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV50LinDsc3 = AV39GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADLINDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFLinDsc = AV22SearchTxt;
         AV13TFLinDsc_Sel = "";
         AV60Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV61Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV62Configuracion_lineasproductoswwds_3_lindsc1 = AV42LinDsc1;
         AV63Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV64Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV65Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV66Configuracion_lineasproductoswwds_7_lindsc2 = AV46LinDsc2;
         AV67Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV68Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV69Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV70Configuracion_lineasproductoswwds_11_lindsc3 = AV50LinDsc3;
         AV71Configuracion_lineasproductoswwds_12_tflincod = AV10TFLinCod;
         AV72Configuracion_lineasproductoswwds_13_tflincod_to = AV11TFLinCod_To;
         AV73Configuracion_lineasproductoswwds_14_tflindsc = AV12TFLinDsc;
         AV74Configuracion_lineasproductoswwds_15_tflindsc_sel = AV13TFLinDsc_Sel;
         AV75Configuracion_lineasproductoswwds_16_tflinabr = AV14TFLinAbr;
         AV76Configuracion_lineasproductoswwds_17_tflinabr_sel = AV15TFLinAbr_Sel;
         AV77Configuracion_lineasproductoswwds_18_tflinsunat = AV16TFLinSunat;
         AV78Configuracion_lineasproductoswwds_19_tflinsunat_sel = AV17TFLinSunat_Sel;
         AV79Configuracion_lineasproductoswwds_20_tflinstk_sels = AV55TFLinStk_Sels;
         AV80Configuracion_lineasproductoswwds_21_tflinsts_sels = AV52TFLinSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1158LinStk ,
                                              AV79Configuracion_lineasproductoswwds_20_tflinstk_sels ,
                                              A1159LinSts ,
                                              AV80Configuracion_lineasproductoswwds_21_tflinsts_sels ,
                                              AV60Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 ,
                                              AV61Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 ,
                                              AV62Configuracion_lineasproductoswwds_3_lindsc1 ,
                                              AV63Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 ,
                                              AV64Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 ,
                                              AV65Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 ,
                                              AV66Configuracion_lineasproductoswwds_7_lindsc2 ,
                                              AV67Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 ,
                                              AV68Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 ,
                                              AV69Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 ,
                                              AV70Configuracion_lineasproductoswwds_11_lindsc3 ,
                                              AV71Configuracion_lineasproductoswwds_12_tflincod ,
                                              AV72Configuracion_lineasproductoswwds_13_tflincod_to ,
                                              AV74Configuracion_lineasproductoswwds_15_tflindsc_sel ,
                                              AV73Configuracion_lineasproductoswwds_14_tflindsc ,
                                              AV76Configuracion_lineasproductoswwds_17_tflinabr_sel ,
                                              AV75Configuracion_lineasproductoswwds_16_tflinabr ,
                                              AV78Configuracion_lineasproductoswwds_19_tflinsunat_sel ,
                                              AV77Configuracion_lineasproductoswwds_18_tflinsunat ,
                                              AV79Configuracion_lineasproductoswwds_20_tflinstk_sels.Count ,
                                              AV80Configuracion_lineasproductoswwds_21_tflinsts_sels.Count ,
                                              A1153LinDsc ,
                                              A52LinCod ,
                                              A1152LinAbr ,
                                              A1160LinSunat } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV62Configuracion_lineasproductoswwds_3_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_lineasproductoswwds_3_lindsc1), 100, "%");
         lV62Configuracion_lineasproductoswwds_3_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_lineasproductoswwds_3_lindsc1), 100, "%");
         lV66Configuracion_lineasproductoswwds_7_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_lineasproductoswwds_7_lindsc2), 100, "%");
         lV66Configuracion_lineasproductoswwds_7_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_lineasproductoswwds_7_lindsc2), 100, "%");
         lV70Configuracion_lineasproductoswwds_11_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_lineasproductoswwds_11_lindsc3), 100, "%");
         lV70Configuracion_lineasproductoswwds_11_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_lineasproductoswwds_11_lindsc3), 100, "%");
         lV73Configuracion_lineasproductoswwds_14_tflindsc = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_lineasproductoswwds_14_tflindsc), 100, "%");
         lV75Configuracion_lineasproductoswwds_16_tflinabr = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_lineasproductoswwds_16_tflinabr), 5, "%");
         lV77Configuracion_lineasproductoswwds_18_tflinsunat = StringUtil.Concat( StringUtil.RTrim( AV77Configuracion_lineasproductoswwds_18_tflinsunat), "%", "");
         /* Using cursor P001C2 */
         pr_default.execute(0, new Object[] {lV62Configuracion_lineasproductoswwds_3_lindsc1, lV62Configuracion_lineasproductoswwds_3_lindsc1, lV66Configuracion_lineasproductoswwds_7_lindsc2, lV66Configuracion_lineasproductoswwds_7_lindsc2, lV70Configuracion_lineasproductoswwds_11_lindsc3, lV70Configuracion_lineasproductoswwds_11_lindsc3, AV71Configuracion_lineasproductoswwds_12_tflincod, AV72Configuracion_lineasproductoswwds_13_tflincod_to, lV73Configuracion_lineasproductoswwds_14_tflindsc, AV74Configuracion_lineasproductoswwds_15_tflindsc_sel, lV75Configuracion_lineasproductoswwds_16_tflinabr, AV76Configuracion_lineasproductoswwds_17_tflinabr_sel, lV77Configuracion_lineasproductoswwds_18_tflinsunat, AV78Configuracion_lineasproductoswwds_19_tflinsunat_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK1C2 = false;
            A1153LinDsc = P001C2_A1153LinDsc[0];
            A1159LinSts = P001C2_A1159LinSts[0];
            A1158LinStk = P001C2_A1158LinStk[0];
            A1160LinSunat = P001C2_A1160LinSunat[0];
            A1152LinAbr = P001C2_A1152LinAbr[0];
            A52LinCod = P001C2_A52LinCod[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P001C2_A1153LinDsc[0], A1153LinDsc) == 0 ) )
            {
               BRK1C2 = false;
               A52LinCod = P001C2_A52LinCod[0];
               AV34count = (long)(AV34count+1);
               BRK1C2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1153LinDsc)) )
            {
               AV26Option = A1153LinDsc;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1C2 )
            {
               BRK1C2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADLINABROPTIONS' Routine */
         returnInSub = false;
         AV14TFLinAbr = AV22SearchTxt;
         AV15TFLinAbr_Sel = "";
         AV60Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV61Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV62Configuracion_lineasproductoswwds_3_lindsc1 = AV42LinDsc1;
         AV63Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV64Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV65Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV66Configuracion_lineasproductoswwds_7_lindsc2 = AV46LinDsc2;
         AV67Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV68Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV69Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV70Configuracion_lineasproductoswwds_11_lindsc3 = AV50LinDsc3;
         AV71Configuracion_lineasproductoswwds_12_tflincod = AV10TFLinCod;
         AV72Configuracion_lineasproductoswwds_13_tflincod_to = AV11TFLinCod_To;
         AV73Configuracion_lineasproductoswwds_14_tflindsc = AV12TFLinDsc;
         AV74Configuracion_lineasproductoswwds_15_tflindsc_sel = AV13TFLinDsc_Sel;
         AV75Configuracion_lineasproductoswwds_16_tflinabr = AV14TFLinAbr;
         AV76Configuracion_lineasproductoswwds_17_tflinabr_sel = AV15TFLinAbr_Sel;
         AV77Configuracion_lineasproductoswwds_18_tflinsunat = AV16TFLinSunat;
         AV78Configuracion_lineasproductoswwds_19_tflinsunat_sel = AV17TFLinSunat_Sel;
         AV79Configuracion_lineasproductoswwds_20_tflinstk_sels = AV55TFLinStk_Sels;
         AV80Configuracion_lineasproductoswwds_21_tflinsts_sels = AV52TFLinSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1158LinStk ,
                                              AV79Configuracion_lineasproductoswwds_20_tflinstk_sels ,
                                              A1159LinSts ,
                                              AV80Configuracion_lineasproductoswwds_21_tflinsts_sels ,
                                              AV60Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 ,
                                              AV61Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 ,
                                              AV62Configuracion_lineasproductoswwds_3_lindsc1 ,
                                              AV63Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 ,
                                              AV64Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 ,
                                              AV65Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 ,
                                              AV66Configuracion_lineasproductoswwds_7_lindsc2 ,
                                              AV67Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 ,
                                              AV68Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 ,
                                              AV69Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 ,
                                              AV70Configuracion_lineasproductoswwds_11_lindsc3 ,
                                              AV71Configuracion_lineasproductoswwds_12_tflincod ,
                                              AV72Configuracion_lineasproductoswwds_13_tflincod_to ,
                                              AV74Configuracion_lineasproductoswwds_15_tflindsc_sel ,
                                              AV73Configuracion_lineasproductoswwds_14_tflindsc ,
                                              AV76Configuracion_lineasproductoswwds_17_tflinabr_sel ,
                                              AV75Configuracion_lineasproductoswwds_16_tflinabr ,
                                              AV78Configuracion_lineasproductoswwds_19_tflinsunat_sel ,
                                              AV77Configuracion_lineasproductoswwds_18_tflinsunat ,
                                              AV79Configuracion_lineasproductoswwds_20_tflinstk_sels.Count ,
                                              AV80Configuracion_lineasproductoswwds_21_tflinsts_sels.Count ,
                                              A1153LinDsc ,
                                              A52LinCod ,
                                              A1152LinAbr ,
                                              A1160LinSunat } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV62Configuracion_lineasproductoswwds_3_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_lineasproductoswwds_3_lindsc1), 100, "%");
         lV62Configuracion_lineasproductoswwds_3_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_lineasproductoswwds_3_lindsc1), 100, "%");
         lV66Configuracion_lineasproductoswwds_7_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_lineasproductoswwds_7_lindsc2), 100, "%");
         lV66Configuracion_lineasproductoswwds_7_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_lineasproductoswwds_7_lindsc2), 100, "%");
         lV70Configuracion_lineasproductoswwds_11_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_lineasproductoswwds_11_lindsc3), 100, "%");
         lV70Configuracion_lineasproductoswwds_11_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_lineasproductoswwds_11_lindsc3), 100, "%");
         lV73Configuracion_lineasproductoswwds_14_tflindsc = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_lineasproductoswwds_14_tflindsc), 100, "%");
         lV75Configuracion_lineasproductoswwds_16_tflinabr = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_lineasproductoswwds_16_tflinabr), 5, "%");
         lV77Configuracion_lineasproductoswwds_18_tflinsunat = StringUtil.Concat( StringUtil.RTrim( AV77Configuracion_lineasproductoswwds_18_tflinsunat), "%", "");
         /* Using cursor P001C3 */
         pr_default.execute(1, new Object[] {lV62Configuracion_lineasproductoswwds_3_lindsc1, lV62Configuracion_lineasproductoswwds_3_lindsc1, lV66Configuracion_lineasproductoswwds_7_lindsc2, lV66Configuracion_lineasproductoswwds_7_lindsc2, lV70Configuracion_lineasproductoswwds_11_lindsc3, lV70Configuracion_lineasproductoswwds_11_lindsc3, AV71Configuracion_lineasproductoswwds_12_tflincod, AV72Configuracion_lineasproductoswwds_13_tflincod_to, lV73Configuracion_lineasproductoswwds_14_tflindsc, AV74Configuracion_lineasproductoswwds_15_tflindsc_sel, lV75Configuracion_lineasproductoswwds_16_tflinabr, AV76Configuracion_lineasproductoswwds_17_tflinabr_sel, lV77Configuracion_lineasproductoswwds_18_tflinsunat, AV78Configuracion_lineasproductoswwds_19_tflinsunat_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK1C4 = false;
            A1152LinAbr = P001C3_A1152LinAbr[0];
            A1159LinSts = P001C3_A1159LinSts[0];
            A1158LinStk = P001C3_A1158LinStk[0];
            A1160LinSunat = P001C3_A1160LinSunat[0];
            A52LinCod = P001C3_A52LinCod[0];
            A1153LinDsc = P001C3_A1153LinDsc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P001C3_A1152LinAbr[0], A1152LinAbr) == 0 ) )
            {
               BRK1C4 = false;
               A52LinCod = P001C3_A52LinCod[0];
               AV34count = (long)(AV34count+1);
               BRK1C4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1152LinAbr)) )
            {
               AV26Option = A1152LinAbr;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1C4 )
            {
               BRK1C4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADLINSUNATOPTIONS' Routine */
         returnInSub = false;
         AV16TFLinSunat = AV22SearchTxt;
         AV17TFLinSunat_Sel = "";
         AV60Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV61Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV62Configuracion_lineasproductoswwds_3_lindsc1 = AV42LinDsc1;
         AV63Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV64Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV65Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV66Configuracion_lineasproductoswwds_7_lindsc2 = AV46LinDsc2;
         AV67Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV68Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV69Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV70Configuracion_lineasproductoswwds_11_lindsc3 = AV50LinDsc3;
         AV71Configuracion_lineasproductoswwds_12_tflincod = AV10TFLinCod;
         AV72Configuracion_lineasproductoswwds_13_tflincod_to = AV11TFLinCod_To;
         AV73Configuracion_lineasproductoswwds_14_tflindsc = AV12TFLinDsc;
         AV74Configuracion_lineasproductoswwds_15_tflindsc_sel = AV13TFLinDsc_Sel;
         AV75Configuracion_lineasproductoswwds_16_tflinabr = AV14TFLinAbr;
         AV76Configuracion_lineasproductoswwds_17_tflinabr_sel = AV15TFLinAbr_Sel;
         AV77Configuracion_lineasproductoswwds_18_tflinsunat = AV16TFLinSunat;
         AV78Configuracion_lineasproductoswwds_19_tflinsunat_sel = AV17TFLinSunat_Sel;
         AV79Configuracion_lineasproductoswwds_20_tflinstk_sels = AV55TFLinStk_Sels;
         AV80Configuracion_lineasproductoswwds_21_tflinsts_sels = AV52TFLinSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A1158LinStk ,
                                              AV79Configuracion_lineasproductoswwds_20_tflinstk_sels ,
                                              A1159LinSts ,
                                              AV80Configuracion_lineasproductoswwds_21_tflinsts_sels ,
                                              AV60Configuracion_lineasproductoswwds_1_dynamicfiltersselector1 ,
                                              AV61Configuracion_lineasproductoswwds_2_dynamicfiltersoperator1 ,
                                              AV62Configuracion_lineasproductoswwds_3_lindsc1 ,
                                              AV63Configuracion_lineasproductoswwds_4_dynamicfiltersenabled2 ,
                                              AV64Configuracion_lineasproductoswwds_5_dynamicfiltersselector2 ,
                                              AV65Configuracion_lineasproductoswwds_6_dynamicfiltersoperator2 ,
                                              AV66Configuracion_lineasproductoswwds_7_lindsc2 ,
                                              AV67Configuracion_lineasproductoswwds_8_dynamicfiltersenabled3 ,
                                              AV68Configuracion_lineasproductoswwds_9_dynamicfiltersselector3 ,
                                              AV69Configuracion_lineasproductoswwds_10_dynamicfiltersoperator3 ,
                                              AV70Configuracion_lineasproductoswwds_11_lindsc3 ,
                                              AV71Configuracion_lineasproductoswwds_12_tflincod ,
                                              AV72Configuracion_lineasproductoswwds_13_tflincod_to ,
                                              AV74Configuracion_lineasproductoswwds_15_tflindsc_sel ,
                                              AV73Configuracion_lineasproductoswwds_14_tflindsc ,
                                              AV76Configuracion_lineasproductoswwds_17_tflinabr_sel ,
                                              AV75Configuracion_lineasproductoswwds_16_tflinabr ,
                                              AV78Configuracion_lineasproductoswwds_19_tflinsunat_sel ,
                                              AV77Configuracion_lineasproductoswwds_18_tflinsunat ,
                                              AV79Configuracion_lineasproductoswwds_20_tflinstk_sels.Count ,
                                              AV80Configuracion_lineasproductoswwds_21_tflinsts_sels.Count ,
                                              A1153LinDsc ,
                                              A52LinCod ,
                                              A1152LinAbr ,
                                              A1160LinSunat } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV62Configuracion_lineasproductoswwds_3_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_lineasproductoswwds_3_lindsc1), 100, "%");
         lV62Configuracion_lineasproductoswwds_3_lindsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_lineasproductoswwds_3_lindsc1), 100, "%");
         lV66Configuracion_lineasproductoswwds_7_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_lineasproductoswwds_7_lindsc2), 100, "%");
         lV66Configuracion_lineasproductoswwds_7_lindsc2 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_lineasproductoswwds_7_lindsc2), 100, "%");
         lV70Configuracion_lineasproductoswwds_11_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_lineasproductoswwds_11_lindsc3), 100, "%");
         lV70Configuracion_lineasproductoswwds_11_lindsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_lineasproductoswwds_11_lindsc3), 100, "%");
         lV73Configuracion_lineasproductoswwds_14_tflindsc = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_lineasproductoswwds_14_tflindsc), 100, "%");
         lV75Configuracion_lineasproductoswwds_16_tflinabr = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_lineasproductoswwds_16_tflinabr), 5, "%");
         lV77Configuracion_lineasproductoswwds_18_tflinsunat = StringUtil.Concat( StringUtil.RTrim( AV77Configuracion_lineasproductoswwds_18_tflinsunat), "%", "");
         /* Using cursor P001C4 */
         pr_default.execute(2, new Object[] {lV62Configuracion_lineasproductoswwds_3_lindsc1, lV62Configuracion_lineasproductoswwds_3_lindsc1, lV66Configuracion_lineasproductoswwds_7_lindsc2, lV66Configuracion_lineasproductoswwds_7_lindsc2, lV70Configuracion_lineasproductoswwds_11_lindsc3, lV70Configuracion_lineasproductoswwds_11_lindsc3, AV71Configuracion_lineasproductoswwds_12_tflincod, AV72Configuracion_lineasproductoswwds_13_tflincod_to, lV73Configuracion_lineasproductoswwds_14_tflindsc, AV74Configuracion_lineasproductoswwds_15_tflindsc_sel, lV75Configuracion_lineasproductoswwds_16_tflinabr, AV76Configuracion_lineasproductoswwds_17_tflinabr_sel, lV77Configuracion_lineasproductoswwds_18_tflinsunat, AV78Configuracion_lineasproductoswwds_19_tflinsunat_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK1C6 = false;
            A1160LinSunat = P001C4_A1160LinSunat[0];
            A1159LinSts = P001C4_A1159LinSts[0];
            A1158LinStk = P001C4_A1158LinStk[0];
            A1152LinAbr = P001C4_A1152LinAbr[0];
            A52LinCod = P001C4_A52LinCod[0];
            A