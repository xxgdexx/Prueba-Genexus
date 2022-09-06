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
   public class tipoclientewwgetfilterdata : GXProcedure
   {
      public tipoclientewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipoclientewwgetfilterdata( IGxContext context )
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
         this.AV20DDOName = aP0_DDOName;
         this.AV18SearchTxt = aP1_SearchTxt;
         this.AV19SearchTxtTo = aP2_SearchTxtTo;
         this.AV24OptionsJson = "" ;
         this.AV27OptionsDescJson = "" ;
         this.AV29OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV29OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         tipoclientewwgetfilterdata objtipoclientewwgetfilterdata;
         objtipoclientewwgetfilterdata = new tipoclientewwgetfilterdata();
         objtipoclientewwgetfilterdata.AV20DDOName = aP0_DDOName;
         objtipoclientewwgetfilterdata.AV18SearchTxt = aP1_SearchTxt;
         objtipoclientewwgetfilterdata.AV19SearchTxtTo = aP2_SearchTxtTo;
         objtipoclientewwgetfilterdata.AV24OptionsJson = "" ;
         objtipoclientewwgetfilterdata.AV27OptionsDescJson = "" ;
         objtipoclientewwgetfilterdata.AV29OptionIndexesJson = "" ;
         objtipoclientewwgetfilterdata.context.SetSubmitInitialConfig(context);
         objtipoclientewwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipoclientewwgetfilterdata);
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipoclientewwgetfilterdata)stateInfo).executePrivate();
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
         AV23Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_TIPCDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPCDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_TIPCABR") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPCABROPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV24OptionsJson = AV23Options.ToJSonString(false);
         AV27OptionsDescJson = AV26OptionsDesc.ToJSonString(false);
         AV29OptionIndexesJson = AV28OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV31Session.Get("Configuracion.TipoClienteWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoClienteWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Configuracion.TipoClienteWWGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPCCOD") == 0 )
            {
               AV10TFTipCCod = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV11TFTipCCod_To = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPCDSC") == 0 )
            {
               AV12TFTipCDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPCDSC_SEL") == 0 )
            {
               AV13TFTipCDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPCABR") == 0 )
            {
               AV14TFTipCAbr = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPCABR_SEL") == 0 )
            {
               AV15TFTipCAbr_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPCSTS_SEL") == 0 )
            {
               AV16TFTipCSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV17TFTipCSts_Sels.FromJSonString(AV16TFTipCSts_SelsJson, null);
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "TIPCDSC") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV38TipCDsc1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "TIPCDSC") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV42TipCDsc2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "TIPCDSC") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV46TipCDsc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTIPCDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFTipCDsc = AV18SearchTxt;
         AV13TFTipCDsc_Sel = "";
         AV51Configuracion_tipoclientewwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV52Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV53Configuracion_tipoclientewwds_3_tipcdsc1 = AV38TipCDsc1;
         AV54Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV55Configuracion_tipoclientewwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV56Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV57Configuracion_tipoclientewwds_7_tipcdsc2 = AV42TipCDsc2;
         AV58Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV59Configuracion_tipoclientewwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV60Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV61Configuracion_tipoclientewwds_11_tipcdsc3 = AV46TipCDsc3;
         AV62Configuracion_tipoclientewwds_12_tftipccod = AV10TFTipCCod;
         AV63Configuracion_tipoclientewwds_13_tftipccod_to = AV11TFTipCCod_To;
         AV64Configuracion_tipoclientewwds_14_tftipcdsc = AV12TFTipCDsc;
         AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel = AV13TFTipCDsc_Sel;
         AV66Configuracion_tipoclientewwds_16_tftipcabr = AV14TFTipCAbr;
         AV67Configuracion_tipoclientewwds_17_tftipcabr_sel = AV15TFTipCAbr_Sel;
         AV68Configuracion_tipoclientewwds_18_tftipcsts_sels = AV17TFTipCSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1908TipCSts ,
                                              AV68Configuracion_tipoclientewwds_18_tftipcsts_sels ,
                                              AV51Configuracion_tipoclientewwds_1_dynamicfiltersselector1 ,
                                              AV52Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 ,
                                              AV53Configuracion_tipoclientewwds_3_tipcdsc1 ,
                                              AV54Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 ,
                                              AV55Configuracion_tipoclientewwds_5_dynamicfiltersselector2 ,
                                              AV56Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 ,
                                              AV57Configuracion_tipoclientewwds_7_tipcdsc2 ,
                                              AV58Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 ,
                                              AV59Configuracion_tipoclientewwds_9_dynamicfiltersselector3 ,
                                              AV60Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 ,
                                              AV61Configuracion_tipoclientewwds_11_tipcdsc3 ,
                                              AV62Configuracion_tipoclientewwds_12_tftipccod ,
                                              AV63Configuracion_tipoclientewwds_13_tftipccod_to ,
                                              AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel ,
                                              AV64Configuracion_tipoclientewwds_14_tftipcdsc ,
                                              AV67Configuracion_tipoclientewwds_17_tftipcabr_sel ,
                                              AV66Configuracion_tipoclientewwds_16_tftipcabr ,
                                              AV68Configuracion_tipoclientewwds_18_tftipcsts_sels.Count ,
                                              A1905TipCDsc ,
                                              A159TipCCod ,
                                              A1904TipCAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV53Configuracion_tipoclientewwds_3_tipcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_tipoclientewwds_3_tipcdsc1), 100, "%");
         lV53Configuracion_tipoclientewwds_3_tipcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_tipoclientewwds_3_tipcdsc1), 100, "%");
         lV57Configuracion_tipoclientewwds_7_tipcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipoclientewwds_7_tipcdsc2), 100, "%");
         lV57Configuracion_tipoclientewwds_7_tipcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipoclientewwds_7_tipcdsc2), 100, "%");
         lV61Configuracion_tipoclientewwds_11_tipcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipoclientewwds_11_tipcdsc3), 100, "%");
         lV61Configuracion_tipoclientewwds_11_tipcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipoclientewwds_11_tipcdsc3), 100, "%");
         lV64Configuracion_tipoclientewwds_14_tftipcdsc = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_tipoclientewwds_14_tftipcdsc), 100, "%");
         lV66Configuracion_tipoclientewwds_16_tftipcabr = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_tipoclientewwds_16_tftipcabr), 5, "%");
         /* Using cursor P00432 */
         pr_default.execute(0, new Object[] {lV53Configuracion_tipoclientewwds_3_tipcdsc1, lV53Configuracion_tipoclientewwds_3_tipcdsc1, lV57Configuracion_tipoclientewwds_7_tipcdsc2, lV57Configuracion_tipoclientewwds_7_tipcdsc2, lV61Configuracion_tipoclientewwds_11_tipcdsc3, lV61Configuracion_tipoclientewwds_11_tipcdsc3, AV62Configuracion_tipoclientewwds_12_tftipccod, AV63Configuracion_tipoclientewwds_13_tftipccod_to, lV64Configuracion_tipoclientewwds_14_tftipcdsc, AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel, lV66Configuracion_tipoclientewwds_16_tftipcabr, AV67Configuracion_tipoclientewwds_17_tftipcabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK432 = false;
            A1905TipCDsc = P00432_A1905TipCDsc[0];
            A1908TipCSts = P00432_A1908TipCSts[0];
            A1904TipCAbr = P00432_A1904TipCAbr[0];
            A159TipCCod = P00432_A159TipCCod[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00432_A1905TipCDsc[0], A1905TipCDsc) == 0 ) )
            {
               BRK432 = false;
               A159TipCCod = P00432_A159TipCCod[0];
               AV30count = (long)(AV30count+1);
               BRK432 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1905TipCDsc)) )
            {
               AV22Option = A1905TipCDsc;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK432 )
            {
               BRK432 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTIPCABROPTIONS' Routine */
         returnInSub = false;
         AV14TFTipCAbr = AV18SearchTxt;
         AV15TFTipCAbr_Sel = "";
         AV51Configuracion_tipoclientewwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV52Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV53Configuracion_tipoclientewwds_3_tipcdsc1 = AV38TipCDsc1;
         AV54Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV55Configuracion_tipoclientewwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV56Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV57Configuracion_tipoclientewwds_7_tipcdsc2 = AV42TipCDsc2;
         AV58Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV59Configuracion_tipoclientewwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV60Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV61Configuracion_tipoclientewwds_11_tipcdsc3 = AV46TipCDsc3;
         AV62Configuracion_tipoclientewwds_12_tftipccod = AV10TFTipCCod;
         AV63Configuracion_tipoclientewwds_13_tftipccod_to = AV11TFTipCCod_To;
         AV64Configuracion_tipoclientewwds_14_tftipcdsc = AV12TFTipCDsc;
         AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel = AV13TFTipCDsc_Sel;
         AV66Configuracion_tipoclientewwds_16_tftipcabr = AV14TFTipCAbr;
         AV67Configuracion_tipoclientewwds_17_tftipcabr_sel = AV15TFTipCAbr_Sel;
         AV68Configuracion_tipoclientewwds_18_tftipcsts_sels = AV17TFTipCSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1908TipCSts ,
                                              AV68Configuracion_tipoclientewwds_18_tftipcsts_sels ,
                                              AV51Configuracion_tipoclientewwds_1_dynamicfiltersselector1 ,
                                              AV52Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 ,
                                              AV53Configuracion_tipoclientewwds_3_tipcdsc1 ,
                                              AV54Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 ,
                                              AV55Configuracion_tipoclientewwds_5_dynamicfiltersselector2 ,
                                              AV56Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 ,
                                              AV57Configuracion_tipoclientewwds_7_tipcdsc2 ,
                                              AV58Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 ,
                                              AV59Configuracion_tipoclientewwds_9_dynamicfiltersselector3 ,
                                              AV60Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 ,
                                              AV61Configuracion_tipoclientewwds_11_tipcdsc3 ,
                                              AV62Configuracion_tipoclientewwds_12_tftipccod ,
                                              AV63Configuracion_tipoclientewwds_13_tftipccod_to ,
                                              AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel ,
                                              AV64Configuracion_tipoclientewwds_14_tftipcdsc ,
                                              AV67Configuracion_tipoclientewwds_17_tftipcabr_sel ,
                                              AV66Configuracion_tipoclientewwds_16_tftipcabr ,
                                              AV68Configuracion_tipoclientewwds_18_tftipcsts_sels.Count ,
                                              A1905TipCDsc ,
                                              A159TipCCod ,
                                              A1904TipCAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV53Configuracion_tipoclientewwds_3_tipcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_tipoclientewwds_3_tipcdsc1), 100, "%");
         lV53Configuracion_tipoclientewwds_3_tipcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_tipoclientewwds_3_tipcdsc1), 100, "%");
         lV57Configuracion_tipoclientewwds_7_tipcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipoclientewwds_7_tipcdsc2), 100, "%");
         lV57Configuracion_tipoclientewwds_7_tipcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipoclientewwds_7_tipcdsc2), 100, "%");
         lV61Configuracion_tipoclientewwds_11_tipcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipoclientewwds_11_tipcdsc3), 100, "%");
         lV61Configuracion_tipoclientewwds_11_tipcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipoclientewwds_11_tipcdsc3), 100, "%");
         lV64Configuracion_tipoclientewwds_14_tftipcdsc = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_tipoclientewwds_14_tftipcdsc), 100, "%");
         lV66Configuracion_tipoclientewwds_16_tftipcabr = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_tipoclientewwds_16_tftipcabr), 5, "%");
         /* Using cursor P00433 */
         pr_default.execute(1, new Object[] {lV53Configuracion_tipoclientewwds_3_tipcdsc1, lV53Configuracion_tipoclientewwds_3_tipcdsc1, lV57Configuracion_tipoclientewwds_7_tipcdsc2, lV57Configuracion_tipoclientewwds_7_tipcdsc2, lV61Configuracion_tipoclientewwds_11_tipcdsc3, lV61Configuracion_tipoclientewwds_11_tipcdsc3, AV62Configuracion_tipoclientewwds_12_tftipccod, AV63Configuracion_tipoclientewwds_13_tftipccod_to, lV64Configuracion_tipoclientewwds_14_tftipcdsc, AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel, lV66Configuracion_tipoclientewwds_16_tftipcabr, AV67Configuracion_tipoclientewwds_17_tftipcabr_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK434 = false;
            A1904TipCAbr = P00433_A1904TipCAbr[0];
            A1908TipCSts = P00433_A1908TipCSts[0];
            A159TipCCod = P00433_A159TipCCod[0];
            A1905TipCDsc = P00433_A1905TipCDsc[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00433_A1904TipCAbr[0], A1904TipCAbr) == 0 ) )
            {
               BRK434 = false;
               A159TipCCod = P00433_A159TipCCod[0];
               AV30count = (long)(AV30count+1);
               BRK434 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1904TipCAbr)) )
            {
               AV22Option = A1904TipCAbr;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK434 )
            {
               BRK434 = true;
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
         AV24OptionsJson = "";
         AV27OptionsDescJson = "";
         AV29OptionIndexesJson = "";
         AV23Options = new GxSimpleCollection<string>();
         AV26OptionsDesc = new GxSimpleCollection<string>();
         AV28OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV31Session = context.GetSession();
         AV33GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV34GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV12TFTipCDsc = "";
         AV13TFTipCDsc_Sel = "";
         AV14TFTipCAbr = "";
         AV15TFTipCAbr_Sel = "";
         AV16TFTipCSts_SelsJson = "";
         AV17TFTipCSts_Sels = new GxSimpleCollection<short>();
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38TipCDsc1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42TipCDsc2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46TipCDsc3 = "";
         AV51Configuracion_tipoclientewwds_1_dynamicfiltersselector1 = "";
         AV53Configuracion_tipoclientewwds_3_tipcdsc1 = "";
         AV55Configuracion_tipoclientewwds_5_dynamicfiltersselector2 = "";
         AV57Configuracion_tipoclientewwds_7_tipcdsc2 = "";
         AV59Configuracion_tipoclientewwds_9_dynamicfiltersselector3 = "";
         AV61Configuracion_tipoclientewwds_11_tipcdsc3 = "";
         AV64Configuracion_tipoclientewwds_14_tftipcdsc = "";
         AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel = "";
         AV66Configuracion_tipoclientewwds_16_tftipcabr = "";
         AV67Configuracion_tipoclientewwds_17_tftipcabr_sel = "";
         AV68Configuracion_tipoclientewwds_18_tftipcsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV53Configuracion_tipoclientewwds_3_tipcdsc1 = "";
         lV57Configuracion_tipoclientewwds_7_tipcdsc2 = "";
         lV61Configuracion_tipoclientewwds_11_tipcdsc3 = "";
         lV64Configuracion_tipoclientewwds_14_tftipcdsc = "";
         lV66Configuracion_tipoclientewwds_16_tftipcabr = "";
         A1905TipCDsc = "";
         A1904TipCAbr = "";
         P00432_A1905TipCDsc = new string[] {""} ;
         P00432_A1908TipCSts = new short[1] ;
         P00432_A1904TipCAbr = new string[] {""} ;
         P00432_A159TipCCod = new int[1] ;
         AV22Option = "";
         P00433_A1904TipCAbr = new string[] {""} ;
         P00433_A1908TipCSts = new short[1] ;
         P00433_A159TipCCod = new int[1] ;
         P00433_A1905TipCDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipoclientewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00432_A1905TipCDsc, P00432_A1908TipCSts, P00432_A1904TipCAbr, P00432_A159TipCCod
               }
               , new Object[] {
               P00433_A1904TipCAbr, P00433_A1908TipCSts, P00433_A159TipCCod, P00433_A1905TipCDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV52Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 ;
      private short AV56Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 ;
      private short AV60Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 ;
      private short A1908TipCSts ;
      private int AV49GXV1 ;
      private int AV10TFTipCCod ;
      private int AV11TFTipCCod_To ;
      private int AV62Configuracion_tipoclientewwds_12_tftipccod ;
      private int AV63Configuracion_tipoclientewwds_13_tftipccod_to ;
      private int AV68Configuracion_tipoclientewwds_18_tftipcsts_sels_Count ;
      private int A159TipCCod ;
      private long AV30count ;
      private string AV12TFTipCDsc ;
      private string AV13TFTipCDsc_Sel ;
      private string AV14TFTipCAbr ;
      private string AV15TFTipCAbr_Sel ;
      private string AV38TipCDsc1 ;
      private string AV42TipCDsc2 ;
      private string AV46TipCDsc3 ;
      private string AV53Configuracion_tipoclientewwds_3_tipcdsc1 ;
      private string AV57Configuracion_tipoclientewwds_7_tipcdsc2 ;
      private string AV61Configuracion_tipoclientewwds_11_tipcdsc3 ;
      private string AV64Configuracion_tipoclientewwds_14_tftipcdsc ;
      private string AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel ;
      private string AV66Configuracion_tipoclientewwds_16_tftipcabr ;
      private string AV67Configuracion_tipoclientewwds_17_tftipcabr_sel ;
      private string scmdbuf ;
      private string lV53Configuracion_tipoclientewwds_3_tipcdsc1 ;
      private string lV57Configuracion_tipoclientewwds_7_tipcdsc2 ;
      private string lV61Configuracion_tipoclientewwds_11_tipcdsc3 ;
      private string lV64Configuracion_tipoclientewwds_14_tftipcdsc ;
      private string lV66Configuracion_tipoclientewwds_16_tftipcabr ;
      private string A1905TipCDsc ;
      private string A1904TipCAbr ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV54Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 ;
      private bool AV58Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 ;
      private bool BRK432 ;
      private bool BRK434 ;
      private string AV24OptionsJson ;
      private string AV27OptionsDescJson ;
      private string AV29OptionIndexesJson ;
      private string AV16TFTipCSts_SelsJson ;
      private string AV20DDOName ;
      private string AV18SearchTxt ;
      private string AV19SearchTxtTo ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV51Configuracion_tipoclientewwds_1_dynamicfiltersselector1 ;
      private string AV55Configuracion_tipoclientewwds_5_dynamicfiltersselector2 ;
      private string AV59Configuracion_tipoclientewwds_9_dynamicfiltersselector3 ;
      private string AV22Option ;
      private GxSimpleCollection<short> AV17TFTipCSts_Sels ;
      private GxSimpleCollection<short> AV68Configuracion_tipoclientewwds_18_tftipcsts_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00432_A1905TipCDsc ;
      private short[] P00432_A1908TipCSts ;
      private string[] P00432_A1904TipCAbr ;
      private int[] P00432_A159TipCCod ;
      private string[] P00433_A1904TipCAbr ;
      private short[] P00433_A1908TipCSts ;
      private int[] P00433_A159TipCCod ;
      private string[] P00433_A1905TipCDsc ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV35GridStateDynamicFilter ;
   }

   public class tipoclientewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00432( IGxContext context ,
                                             short A1908TipCSts ,
                                             GxSimpleCollection<short> AV68Configuracion_tipoclientewwds_18_tftipcsts_sels ,
                                             string AV51Configuracion_tipoclientewwds_1_dynamicfiltersselector1 ,
                                             short AV52Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 ,
                                             string AV53Configuracion_tipoclientewwds_3_tipcdsc1 ,
                                             bool AV54Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 ,
                                             string AV55Configuracion_tipoclientewwds_5_dynamicfiltersselector2 ,
                                             short AV56Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 ,
                                             string AV57Configuracion_tipoclientewwds_7_tipcdsc2 ,
                                             bool AV58Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 ,
                                             string AV59Configuracion_tipoclientewwds_9_dynamicfiltersselector3 ,
                                             short AV60Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 ,
                                             string AV61Configuracion_tipoclientewwds_11_tipcdsc3 ,
                                             int AV62Configuracion_tipoclientewwds_12_tftipccod ,
                                             int AV63Configuracion_tipoclientewwds_13_tftipccod_to ,
                                             string AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel ,
                                             string AV64Configuracion_tipoclientewwds_14_tftipcdsc ,
                                             string AV67Configuracion_tipoclientewwds_17_tftipcabr_sel ,
                                             string AV66Configuracion_tipoclientewwds_16_tftipcabr ,
                                             int AV68Configuracion_tipoclientewwds_18_tftipcsts_sels_Count ,
                                             string A1905TipCDsc ,
                                             int A159TipCCod ,
                                             string A1904TipCAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TipCDsc], [TipCSts], [TipCAbr], [TipCCod] FROM [CTIPOCLIENTE]";
         if ( ( StringUtil.StrCmp(AV51Configuracion_tipoclientewwds_1_dynamicfiltersselector1, "TIPCDSC") == 0 ) && ( AV52Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_tipoclientewwds_3_tipcdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV53Configuracion_tipoclientewwds_3_tipcdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Configuracion_tipoclientewwds_1_dynamicfiltersselector1, "TIPCDSC") == 0 ) && ( AV52Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_tipoclientewwds_3_tipcdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like '%' + @lV53Configuracion_tipoclientewwds_3_tipcdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV54Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_tipoclientewwds_5_dynamicfiltersselector2, "TIPCDSC") == 0 ) && ( AV56Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipoclientewwds_7_tipcdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV57Configuracion_tipoclientewwds_7_tipcdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV54Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_tipoclientewwds_5_dynamicfiltersselector2, "TIPCDSC") == 0 ) && ( AV56Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipoclientewwds_7_tipcdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like '%' + @lV57Configuracion_tipoclientewwds_7_tipcdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV58Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_tipoclientewwds_9_dynamicfiltersselector3, "TIPCDSC") == 0 ) && ( AV60Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipoclientewwds_11_tipcdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV61Configuracion_tipoclientewwds_11_tipcdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV58Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_tipoclientewwds_9_dynamicfiltersselector3, "TIPCDSC") == 0 ) && ( AV60Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipoclientewwds_11_tipcdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like '%' + @lV61Configuracion_tipoclientewwds_11_tipcdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV62Configuracion_tipoclientewwds_12_tftipccod) )
         {
            AddWhere(sWhereString, "([TipCCod] >= @AV62Configuracion_tipoclientewwds_12_tftipccod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV63Configuracion_tipoclientewwds_13_tftipccod_to) )
         {
            AddWhere(sWhereString, "([TipCCod] <= @AV63Configuracion_tipoclientewwds_13_tftipccod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipoclientewwds_14_tftipcdsc)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV64Configuracion_tipoclientewwds_14_tftipcdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel)) )
         {
            AddWhere(sWhereString, "([TipCDsc] = @AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipoclientewwds_17_tftipcabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_tipoclientewwds_16_tftipcabr)) ) )
         {
            AddWhere(sWhereString, "([TipCAbr] like @lV66Configuracion_tipoclientewwds_16_tftipcabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipoclientewwds_17_tftipcabr_sel)) )
         {
            AddWhere(sWhereString, "([TipCAbr] = @AV67Configuracion_tipoclientewwds_17_tftipcabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV68Configuracion_tipoclientewwds_18_tftipcsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Configuracion_tipoclientewwds_18_tftipcsts_sels, "[TipCSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipCDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00433( IGxContext context ,
                                             short A1908TipCSts ,
                                             GxSimpleCollection<short> AV68Configuracion_tipoclientewwds_18_tftipcsts_sels ,
                                             string AV51Configuracion_tipoclientewwds_1_dynamicfiltersselector1 ,
                                             short AV52Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 ,
                                             string AV53Configuracion_tipoclientewwds_3_tipcdsc1 ,
                                             bool AV54Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 ,
                                             string AV55Configuracion_tipoclientewwds_5_dynamicfiltersselector2 ,
                                             short AV56Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 ,
                                             string AV57Configuracion_tipoclientewwds_7_tipcdsc2 ,
                                             bool AV58Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 ,
                                             string AV59Configuracion_tipoclientewwds_9_dynamicfiltersselector3 ,
                                             short AV60Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 ,
                                             string AV61Configuracion_tipoclientewwds_11_tipcdsc3 ,
                                             int AV62Configuracion_tipoclientewwds_12_tftipccod ,
                                             int AV63Configuracion_tipoclientewwds_13_tftipccod_to ,
                                             string AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel ,
                                             string AV64Configuracion_tipoclientewwds_14_tftipcdsc ,
                                             string AV67Configuracion_tipoclientewwds_17_tftipcabr_sel ,
                                             string AV66Configuracion_tipoclientewwds_16_tftipcabr ,
                                             int AV68Configuracion_tipoclientewwds_18_tftipcsts_sels_Count ,
                                             string A1905TipCDsc ,
                                             int A159TipCCod ,
                                             string A1904TipCAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TipCAbr], [TipCSts], [TipCCod], [TipCDsc] FROM [CTIPOCLIENTE]";
         if ( ( StringUtil.StrCmp(AV51Configuracion_tipoclientewwds_1_dynamicfiltersselector1, "TIPCDSC") == 0 ) && ( AV52Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_tipoclientewwds_3_tipcdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV53Configuracion_tipoclientewwds_3_tipcdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Configuracion_tipoclientewwds_1_dynamicfiltersselector1, "TIPCDSC") == 0 ) && ( AV52Configuracion_tipoclientewwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_tipoclientewwds_3_tipcdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like '%' + @lV53Configuracion_tipoclientewwds_3_tipcdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV54Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_tipoclientewwds_5_dynamicfiltersselector2, "TIPCDSC") == 0 ) && ( AV56Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipoclientewwds_7_tipcdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV57Configuracion_tipoclientewwds_7_tipcdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV54Configuracion_tipoclientewwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_tipoclientewwds_5_dynamicfiltersselector2, "TIPCDSC") == 0 ) && ( AV56Configuracion_tipoclientewwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipoclientewwds_7_tipcdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like '%' + @lV57Configuracion_tipoclientewwds_7_tipcdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV58Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_tipoclientewwds_9_dynamicfiltersselector3, "TIPCDSC") == 0 ) && ( AV60Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipoclientewwds_11_tipcdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV61Configuracion_tipoclientewwds_11_tipcdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV58Configuracion_tipoclientewwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_tipoclientewwds_9_dynamicfiltersselector3, "TIPCDSC") == 0 ) && ( AV60Configuracion_tipoclientewwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipoclientewwds_11_tipcdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like '%' + @lV61Configuracion_tipoclientewwds_11_tipcdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV62Configuracion_tipoclientewwds_12_tftipccod) )
         {
            AddWhere(sWhereString, "([TipCCod] >= @AV62Configuracion_tipoclientewwds_12_tftipccod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV63Configuracion_tipoclientewwds_13_tftipccod_to) )
         {
            AddWhere(sWhereString, "([TipCCod] <= @AV63Configuracion_tipoclientewwds_13_tftipccod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipoclientewwds_14_tftipcdsc)) ) )
         {
            AddWhere(sWhereString, "([TipCDsc] like @lV64Configuracion_tipoclientewwds_14_tftipcdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel)) )
         {
            AddWhere(sWhereString, "([TipCDsc] = @AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipoclientewwds_17_tftipcabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_tipoclientewwds_16_tftipcabr)) ) )
         {
            AddWhere(sWhereString, "([TipCAbr] like @lV66Configuracion_tipoclientewwds_16_tftipcabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipoclientewwds_17_tftipcabr_sel)) )
         {
            AddWhere(sWhereString, "([TipCAbr] = @AV67Configuracion_tipoclientewwds_17_tftipcabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV68Configuracion_tipoclientewwds_18_tftipcsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Configuracion_tipoclientewwds_18_tftipcsts_sels, "[TipCSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipCAbr]";
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
                     return conditional_P00432(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] );
               case 1 :
                     return conditional_P00433(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP00432;
          prmP00432 = new Object[] {
          new ParDef("@lV53Configuracion_tipoclientewwds_3_tipcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Configuracion_tipoclientewwds_3_tipcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_tipoclientewwds_7_tipcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_tipoclientewwds_7_tipcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_tipoclientewwds_11_tipcdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_tipoclientewwds_11_tipcdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV62Configuracion_tipoclientewwds_12_tftipccod",GXType.Int32,6,0) ,
          new ParDef("@AV63Configuracion_tipoclientewwds_13_tftipccod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Configuracion_tipoclientewwds_14_tftipcdsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_tipoclientewwds_16_tftipcabr",GXType.NChar,5,0) ,
          new ParDef("@AV67Configuracion_tipoclientewwds_17_tftipcabr_sel",GXType.NChar,5,0)
          };
          Object[] prmP00433;
          prmP00433 = new Object[] {
          new ParDef("@lV53Configuracion_tipoclientewwds_3_tipcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Configuracion_tipoclientewwds_3_tipcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_tipoclientewwds_7_tipcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_tipoclientewwds_7_tipcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_tipoclientewwds_11_tipcdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_tipoclientewwds_11_tipcdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV62Configuracion_tipoclientewwds_12_tftipccod",GXType.Int32,6,0) ,
          new ParDef("@AV63Configuracion_tipoclientewwds_13_tftipccod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Configuracion_tipoclientewwds_14_tftipcdsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Configuracion_tipoclientewwds_15_tftipcdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_tipoclientewwds_16_tftipcabr",GXType.NChar,5,0) ,
          new ParDef("@AV67Configuracion_tipoclientewwds_17_tftipcabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00432", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00432,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00433", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00433,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
       }
    }

 }

}
