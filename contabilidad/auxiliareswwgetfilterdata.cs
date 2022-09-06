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
   public class auxiliareswwgetfilterdata : GXProcedure
   {
      public auxiliareswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public auxiliareswwgetfilterdata( IGxContext context )
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
         auxiliareswwgetfilterdata objauxiliareswwgetfilterdata;
         objauxiliareswwgetfilterdata = new auxiliareswwgetfilterdata();
         objauxiliareswwgetfilterdata.AV20DDOName = aP0_DDOName;
         objauxiliareswwgetfilterdata.AV18SearchTxt = aP1_SearchTxt;
         objauxiliareswwgetfilterdata.AV19SearchTxtTo = aP2_SearchTxtTo;
         objauxiliareswwgetfilterdata.AV24OptionsJson = "" ;
         objauxiliareswwgetfilterdata.AV27OptionsDescJson = "" ;
         objauxiliareswwgetfilterdata.AV29OptionIndexesJson = "" ;
         objauxiliareswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objauxiliareswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objauxiliareswwgetfilterdata);
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((auxiliareswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_TIPADSC") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPADSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_TIPADCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPADCODOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_TIPADDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPADDSCOPTIONS' */
            S141 ();
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
         if ( StringUtil.StrCmp(AV31Session.Get("Contabilidad.AuxiliaresWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.AuxiliaresWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Contabilidad.AuxiliaresWWGridState"), null, "", "");
         }
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV54GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPADSC") == 0 )
            {
               AV50TFTipADsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPADSC_SEL") == 0 )
            {
               AV51TFTipADsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPADCOD") == 0 )
            {
               AV12TFTipADCod = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPADCOD_SEL") == 0 )
            {
               AV13TFTipADCod_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPADDSC") == 0 )
            {
               AV14TFTipADDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPADDSC_SEL") == 0 )
            {
               AV15TFTipADDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPADSTS_SEL") == 0 )
            {
               AV16TFTipADSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV17TFTipADSts_Sels.FromJSonString(AV16TFTipADSts_SelsJson, null);
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "TIPADDSC") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV38TipADDsc1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "TIPADCOD") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV47TipADCod1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "TIPADDSC") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV42TipADDsc2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "TIPADCOD") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV48TipADCod2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "TIPADDSC") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV46TipADDsc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "TIPADCOD") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV49TipADCod3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTIPADSCOPTIONS' Routine */
         returnInSub = false;
         AV50TFTipADsc = AV18SearchTxt;
         AV51TFTipADsc_Sel = "";
         AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV58Contabilidad_auxiliareswwds_3_tipaddsc1 = AV38TipADDsc1;
         AV59Contabilidad_auxiliareswwds_4_tipadcod1 = AV47TipADCod1;
         AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV63Contabilidad_auxiliareswwds_8_tipaddsc2 = AV42TipADDsc2;
         AV64Contabilidad_auxiliareswwds_9_tipadcod2 = AV48TipADCod2;
         AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV68Contabilidad_auxiliareswwds_13_tipaddsc3 = AV46TipADDsc3;
         AV69Contabilidad_auxiliareswwds_14_tipadcod3 = AV49TipADCod3;
         AV70Contabilidad_auxiliareswwds_15_tftipadsc = AV50TFTipADsc;
         AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel = AV51TFTipADsc_Sel;
         AV72Contabilidad_auxiliareswwds_17_tftipadcod = AV12TFTipADCod;
         AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel = AV13TFTipADCod_Sel;
         AV74Contabilidad_auxiliareswwds_19_tftipaddsc = AV14TFTipADDsc;
         AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel = AV15TFTipADDsc_Sel;
         AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels = AV17TFTipADSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1901TipADSts ,
                                              AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels ,
                                              AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ,
                                              AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ,
                                              AV58Contabilidad_auxiliareswwds_3_tipaddsc1 ,
                                              AV59Contabilidad_auxiliareswwds_4_tipadcod1 ,
                                              AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ,
                                              AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ,
                                              AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ,
                                              AV63Contabilidad_auxiliareswwds_8_tipaddsc2 ,
                                              AV64Contabilidad_auxiliareswwds_9_tipadcod2 ,
                                              AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ,
                                              AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ,
                                              AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ,
                                              AV68Contabilidad_auxiliareswwds_13_tipaddsc3 ,
                                              AV69Contabilidad_auxiliareswwds_14_tipadcod3 ,
                                              AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel ,
                                              AV70Contabilidad_auxiliareswwds_15_tftipadsc ,
                                              AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel ,
                                              AV72Contabilidad_auxiliareswwds_17_tftipadcod ,
                                              AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel ,
                                              AV74Contabilidad_auxiliareswwds_19_tftipaddsc ,
                                              AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels.Count ,
                                              A72TipADDsc ,
                                              A71TipADCod ,
                                              A1900TipADsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV58Contabilidad_auxiliareswwds_3_tipaddsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_3_tipaddsc1), 100, "%");
         lV58Contabilidad_auxiliareswwds_3_tipaddsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_3_tipaddsc1), 100, "%");
         lV59Contabilidad_auxiliareswwds_4_tipadcod1 = StringUtil.PadR( StringUtil.RTrim( AV59Contabilidad_auxiliareswwds_4_tipadcod1), 20, "%");
         lV59Contabilidad_auxiliareswwds_4_tipadcod1 = StringUtil.PadR( StringUtil.RTrim( AV59Contabilidad_auxiliareswwds_4_tipadcod1), 20, "%");
         lV63Contabilidad_auxiliareswwds_8_tipaddsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_8_tipaddsc2), 100, "%");
         lV63Contabilidad_auxiliareswwds_8_tipaddsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_8_tipaddsc2), 100, "%");
         lV64Contabilidad_auxiliareswwds_9_tipadcod2 = StringUtil.PadR( StringUtil.RTrim( AV64Contabilidad_auxiliareswwds_9_tipadcod2), 20, "%");
         lV64Contabilidad_auxiliareswwds_9_tipadcod2 = StringUtil.PadR( StringUtil.RTrim( AV64Contabilidad_auxiliareswwds_9_tipadcod2), 20, "%");
         lV68Contabilidad_auxiliareswwds_13_tipaddsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_13_tipaddsc3), 100, "%");
         lV68Contabilidad_auxiliareswwds_13_tipaddsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_13_tipaddsc3), 100, "%");
         lV69Contabilidad_auxiliareswwds_14_tipadcod3 = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_14_tipadcod3), 20, "%");
         lV69Contabilidad_auxiliareswwds_14_tipadcod3 = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_14_tipadcod3), 20, "%");
         lV70Contabilidad_auxiliareswwds_15_tftipadsc = StringUtil.PadR( StringUtil.RTrim( AV70Contabilidad_auxiliareswwds_15_tftipadsc), 100, "%");
         lV72Contabilidad_auxiliareswwds_17_tftipadcod = StringUtil.PadR( StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_17_tftipadcod), 20, "%");
         lV74Contabilidad_auxiliareswwds_19_tftipaddsc = StringUtil.PadR( StringUtil.RTrim( AV74Contabilidad_auxiliareswwds_19_tftipaddsc), 100, "%");
         /* Using cursor P006N2 */
         pr_default.execute(0, new Object[] {lV58Contabilidad_auxiliareswwds_3_tipaddsc1, lV58Contabilidad_auxiliareswwds_3_tipaddsc1, lV59Contabilidad_auxiliareswwds_4_tipadcod1, lV59Contabilidad_auxiliareswwds_4_tipadcod1, lV63Contabilidad_auxiliareswwds_8_tipaddsc2, lV63Contabilidad_auxiliareswwds_8_tipaddsc2, lV64Contabilidad_auxiliareswwds_9_tipadcod2, lV64Contabilidad_auxiliareswwds_9_tipadcod2, lV68Contabilidad_auxiliareswwds_13_tipaddsc3, lV68Contabilidad_auxiliareswwds_13_tipaddsc3, lV69Contabilidad_auxiliareswwds_14_tipadcod3, lV69Contabilidad_auxiliareswwds_14_tipadcod3, lV70Contabilidad_auxiliareswwds_15_tftipadsc, AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel, lV72Contabilidad_auxiliareswwds_17_tftipadcod, AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel, lV74Contabilidad_auxiliareswwds_19_tftipaddsc, AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6N2 = false;
            A70TipACod = P006N2_A70TipACod[0];
            A1900TipADsc = P006N2_A1900TipADsc[0];
            A1901TipADSts = P006N2_A1901TipADSts[0];
            A71TipADCod = P006N2_A71TipADCod[0];
            A72TipADDsc = P006N2_A72TipADDsc[0];
            A1900TipADsc = P006N2_A1900TipADsc[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006N2_A1900TipADsc[0], A1900TipADsc) == 0 ) )
            {
               BRK6N2 = false;
               A70TipACod = P006N2_A70TipACod[0];
               A71TipADCod = P006N2_A71TipADCod[0];
               AV30count = (long)(AV30count+1);
               BRK6N2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1900TipADsc)) )
            {
               AV22Option = A1900TipADsc;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK6N2 )
            {
               BRK6N2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTIPADCODOPTIONS' Routine */
         returnInSub = false;
         AV12TFTipADCod = AV18SearchTxt;
         AV13TFTipADCod_Sel = "";
         AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV58Contabilidad_auxiliareswwds_3_tipaddsc1 = AV38TipADDsc1;
         AV59Contabilidad_auxiliareswwds_4_tipadcod1 = AV47TipADCod1;
         AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV63Contabilidad_auxiliareswwds_8_tipaddsc2 = AV42TipADDsc2;
         AV64Contabilidad_auxiliareswwds_9_tipadcod2 = AV48TipADCod2;
         AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV68Contabilidad_auxiliareswwds_13_tipaddsc3 = AV46TipADDsc3;
         AV69Contabilidad_auxiliareswwds_14_tipadcod3 = AV49TipADCod3;
         AV70Contabilidad_auxiliareswwds_15_tftipadsc = AV50TFTipADsc;
         AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel = AV51TFTipADsc_Sel;
         AV72Contabilidad_auxiliareswwds_17_tftipadcod = AV12TFTipADCod;
         AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel = AV13TFTipADCod_Sel;
         AV74Contabilidad_auxiliareswwds_19_tftipaddsc = AV14TFTipADDsc;
         AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel = AV15TFTipADDsc_Sel;
         AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels = AV17TFTipADSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1901TipADSts ,
                                              AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels ,
                                              AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ,
                                              AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ,
                                              AV58Contabilidad_auxiliareswwds_3_tipaddsc1 ,
                                              AV59Contabilidad_auxiliareswwds_4_tipadcod1 ,
                                              AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ,
                                              AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ,
                                              AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ,
                                              AV63Contabilidad_auxiliareswwds_8_tipaddsc2 ,
                                              AV64Contabilidad_auxiliareswwds_9_tipadcod2 ,
                                              AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ,
                                              AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ,
                                              AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ,
                                              AV68Contabilidad_auxiliareswwds_13_tipaddsc3 ,
                                              AV69Contabilidad_auxiliareswwds_14_tipadcod3 ,
                                              AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel ,
                                              AV70Contabilidad_auxiliareswwds_15_tftipadsc ,
                                              AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel ,
                                              AV72Contabilidad_auxiliareswwds_17_tftipadcod ,
                                              AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel ,
                                              AV74Contabilidad_auxiliareswwds_19_tftipaddsc ,
                                              AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels.Count ,
                                              A72TipADDsc ,
                                              A71TipADCod ,
                                              A1900TipADsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV58Contabilidad_auxiliareswwds_3_tipaddsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_3_tipaddsc1), 100, "%");
         lV58Contabilidad_auxiliareswwds_3_tipaddsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_3_tipaddsc1), 100, "%");
         lV59Contabilidad_auxiliareswwds_4_tipadcod1 = StringUtil.PadR( StringUtil.RTrim( AV59Contabilidad_auxiliareswwds_4_tipadcod1), 20, "%");
         lV59Contabilidad_auxiliareswwds_4_tipadcod1 = StringUtil.PadR( StringUtil.RTrim( AV59Contabilidad_auxiliareswwds_4_tipadcod1), 20, "%");
         lV63Contabilidad_auxiliareswwds_8_tipaddsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_8_tipaddsc2), 100, "%");
         lV63Contabilidad_auxiliareswwds_8_tipaddsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_8_tipaddsc2), 100, "%");
         lV64Contabilidad_auxiliareswwds_9_tipadcod2 = StringUtil.PadR( StringUtil.RTrim( AV64Contabilidad_auxiliareswwds_9_tipadcod2), 20, "%");
         lV64Contabilidad_auxiliareswwds_9_tipadcod2 = StringUtil.PadR( StringUtil.RTrim( AV64Contabilidad_auxiliareswwds_9_tipadcod2), 20, "%");
         lV68Contabilidad_auxiliareswwds_13_tipaddsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_13_tipaddsc3), 100, "%");
         lV68Contabilidad_auxiliareswwds_13_tipaddsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_13_tipaddsc3), 100, "%");
         lV69Contabilidad_auxiliareswwds_14_tipadcod3 = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_14_tipadcod3), 20, "%");
         lV69Contabilidad_auxiliareswwds_14_tipadcod3 = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_14_tipadcod3), 20, "%");
         lV70Contabilidad_auxiliareswwds_15_tftipadsc = StringUtil.PadR( StringUtil.RTrim( AV70Contabilidad_auxiliareswwds_15_tftipadsc), 100, "%");
         lV72Contabilidad_auxiliareswwds_17_tftipadcod = StringUtil.PadR( StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_17_tftipadcod), 20, "%");
         lV74Contabilidad_auxiliareswwds_19_tftipaddsc = StringUtil.PadR( StringUtil.RTrim( AV74Contabilidad_auxiliareswwds_19_tftipaddsc), 100, "%");
         /* Using cursor P006N3 */
         pr_default.execute(1, new Object[] {lV58Contabilidad_auxiliareswwds_3_tipaddsc1, lV58Contabilidad_auxiliareswwds_3_tipaddsc1, lV59Contabilidad_auxiliareswwds_4_tipadcod1, lV59Contabilidad_auxiliareswwds_4_tipadcod1, lV63Contabilidad_auxiliareswwds_8_tipaddsc2, lV63Contabilidad_auxiliareswwds_8_tipaddsc2, lV64Contabilidad_auxiliareswwds_9_tipadcod2, lV64Contabilidad_auxiliareswwds_9_tipadcod2, lV68Contabilidad_auxiliareswwds_13_tipaddsc3, lV68Contabilidad_auxiliareswwds_13_tipaddsc3, lV69Contabilidad_auxiliareswwds_14_tipadcod3, lV69Contabilidad_auxiliareswwds_14_tipadcod3, lV70Contabilidad_auxiliareswwds_15_tftipadsc, AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel, lV72Contabilidad_auxiliareswwds_17_tftipadcod, AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel, lV74Contabilidad_auxiliareswwds_19_tftipaddsc, AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6N4 = false;
            A70TipACod = P006N3_A70TipACod[0];
            A71TipADCod = P006N3_A71TipADCod[0];
            A1901TipADSts = P006N3_A1901TipADSts[0];
            A1900TipADsc = P006N3_A1900TipADsc[0];
            A72TipADDsc = P006N3_A72TipADDsc[0];
            A1900TipADsc = P006N3_A1900TipADsc[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006N3_A71TipADCod[0], A71TipADCod) == 0 ) )
            {
               BRK6N4 = false;
               A70TipACod = P006N3_A70TipACod[0];
               AV30count = (long)(AV30count+1);
               BRK6N4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A71TipADCod)) )
            {
               AV22Option = A71TipADCod;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK6N4 )
            {
               BRK6N4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADTIPADDSCOPTIONS' Routine */
         returnInSub = false;
         AV14TFTipADDsc = AV18SearchTxt;
         AV15TFTipADDsc_Sel = "";
         AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV58Contabilidad_auxiliareswwds_3_tipaddsc1 = AV38TipADDsc1;
         AV59Contabilidad_auxiliareswwds_4_tipadcod1 = AV47TipADCod1;
         AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV63Contabilidad_auxiliareswwds_8_tipaddsc2 = AV42TipADDsc2;
         AV64Contabilidad_auxiliareswwds_9_tipadcod2 = AV48TipADCod2;
         AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV68Contabilidad_auxiliareswwds_13_tipaddsc3 = AV46TipADDsc3;
         AV69Contabilidad_auxiliareswwds_14_tipadcod3 = AV49TipADCod3;
         AV70Contabilidad_auxiliareswwds_15_tftipadsc = AV50TFTipADsc;
         AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel = AV51TFTipADsc_Sel;
         AV72Contabilidad_auxiliareswwds_17_tftipadcod = AV12TFTipADCod;
         AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel = AV13TFTipADCod_Sel;
         AV74Contabilidad_auxiliareswwds_19_tftipaddsc = AV14TFTipADDsc;
         AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel = AV15TFTipADDsc_Sel;
         AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels = AV17TFTipADSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A1901TipADSts ,
                                              AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels ,
                                              AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ,
                                              AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ,
                                              AV58Contabilidad_auxiliareswwds_3_tipaddsc1 ,
                                              AV59Contabilidad_auxiliareswwds_4_tipadcod1 ,
                                              AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ,
                                              AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ,
                                              AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ,
                                              AV63Contabilidad_auxiliareswwds_8_tipaddsc2 ,
                                              AV64Contabilidad_auxiliareswwds_9_tipadcod2 ,
                                              AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ,
                                              AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ,
                                              AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ,
                                              AV68Contabilidad_auxiliareswwds_13_tipaddsc3 ,
                                              AV69Contabilidad_auxiliareswwds_14_tipadcod3 ,
                                              AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel ,
                                              AV70Contabilidad_auxiliareswwds_15_tftipadsc ,
                                              AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel ,
                                              AV72Contabilidad_auxiliareswwds_17_tftipadcod ,
                                              AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel ,
                                              AV74Contabilidad_auxiliareswwds_19_tftipaddsc ,
                                              AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels.Count ,
                                              A72TipADDsc ,
                                              A71TipADCod ,
                                              A1900TipADsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV58Contabilidad_auxiliareswwds_3_tipaddsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_3_tipaddsc1), 100, "%");
         lV58Contabilidad_auxiliareswwds_3_tipaddsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_3_tipaddsc1), 100, "%");
         lV59Contabilidad_auxiliareswwds_4_tipadcod1 = StringUtil.PadR( StringUtil.RTrim( AV59Contabilidad_auxiliareswwds_4_tipadcod1), 20, "%");
         lV59Contabilidad_auxiliareswwds_4_tipadcod1 = StringUtil.PadR( StringUtil.RTrim( AV59Contabilidad_auxiliareswwds_4_tipadcod1), 20, "%");
         lV63Contabilidad_auxiliareswwds_8_tipaddsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_8_tipaddsc2), 100, "%");
         lV63Contabilidad_auxiliareswwds_8_tipaddsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_8_tipaddsc2), 100, "%");
         lV64Contabilidad_auxiliareswwds_9_tipadcod2 = StringUtil.PadR( StringUtil.RTrim( AV64Contabilidad_auxiliareswwds_9_tipadcod2), 20, "%");
         lV64Contabilidad_auxiliareswwds_9_tipadcod2 = StringUtil.PadR( StringUtil.RTrim( AV64Contabilidad_auxiliareswwds_9_tipadcod2), 20, "%");
         lV68Contabilidad_auxiliareswwds_13_tipaddsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_13_tipaddsc3), 100, "%");
         lV68Contabilidad_auxiliareswwds_13_tipaddsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_13_tipaddsc3), 100, "%");
         lV69Contabilidad_auxiliareswwds_14_tipadcod3 = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_14_tipadcod3), 20, "%");
         lV69Contabilidad_auxiliareswwds_14_tipadcod3 = StringUtil.PadR( StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_14_tipadcod3), 20, "%");
         lV70Contabilidad_auxiliareswwds_15_tftipadsc = StringUtil.PadR( StringUtil.RTrim( AV70Contabilidad_auxiliareswwds_15_tftipadsc), 100, "%");
         lV72Contabilidad_auxiliareswwds_17_tftipadcod = StringUtil.PadR( StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_17_tftipadcod), 20, "%");
         lV74Contabilidad_auxiliareswwds_19_tftipaddsc = StringUtil.PadR( StringUtil.RTrim( AV74Contabilidad_auxiliareswwds_19_tftipaddsc), 100, "%");
         /* Using cursor P006N4 */
         pr_default.execute(2, new Object[] {lV58Contabilidad_auxiliareswwds_3_tipaddsc1, lV58Contabilidad_auxiliareswwds_3_tipaddsc1, lV59Contabilidad_auxiliareswwds_4_tipadcod1, lV59Contabilidad_auxiliareswwds_4_tipadcod1, lV63Contabilidad_auxiliareswwds_8_tipaddsc2, lV63Contabilidad_auxiliareswwds_8_tipaddsc2, lV64Contabilidad_auxiliareswwds_9_tipadcod2, lV64Contabilidad_auxiliareswwds_9_tipadcod2, lV68Contabilidad_auxiliareswwds_13_tipaddsc3, lV68Contabilidad_auxiliareswwds_13_tipaddsc3, lV69Contabilidad_auxiliareswwds_14_tipadcod3, lV69Contabilidad_auxiliareswwds_14_tipadcod3, lV70Contabilidad_auxiliareswwds_15_tftipadsc, AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel, lV72Contabilidad_auxiliareswwds_17_tftipadcod, AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel, lV74Contabilidad_auxiliareswwds_19_tftipaddsc, AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6N6 = false;
            A70TipACod = P006N4_A70TipACod[0];
            A72TipADDsc = P006N4_A72TipADDsc[0];
            A1901TipADSts = P006N4_A1901TipADSts[0];
            A1900TipADsc = P006N4_A1900TipADsc[0];
            A71TipADCod = P006N4_A71TipADCod[0];
            A1900TipADsc = P006N4_A1900TipADsc[0];
            AV30count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006N4_A72TipADDsc[0], A72TipADDsc) == 0 ) )
            {
               BRK6N6 = false;
               A70TipACod = P006N4_A70TipACod[0];
               A71TipADCod = P006N4_A71TipADCod[0];
               AV30count = (long)(AV30count+1);
               BRK6N6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A72TipADDsc)) )
            {
               AV22Option = A72TipADDsc;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK6N6 )
            {
               BRK6N6 = true;
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
         AV50TFTipADsc = "";
         AV51TFTipADsc_Sel = "";
         AV12TFTipADCod = "";
         AV13TFTipADCod_Sel = "";
         AV14TFTipADDsc = "";
         AV15TFTipADDsc_Sel = "";
         AV16TFTipADSts_SelsJson = "";
         AV17TFTipADSts_Sels = new GxSimpleCollection<short>();
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38TipADDsc1 = "";
         AV47TipADCod1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42TipADDsc2 = "";
         AV48TipADCod2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46TipADDsc3 = "";
         AV49TipADCod3 = "";
         AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 = "";
         AV58Contabilidad_auxiliareswwds_3_tipaddsc1 = "";
         AV59Contabilidad_auxiliareswwds_4_tipadcod1 = "";
         AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 = "";
         AV63Contabilidad_auxiliareswwds_8_tipaddsc2 = "";
         AV64Contabilidad_auxiliareswwds_9_tipadcod2 = "";
         AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 = "";
         AV68Contabilidad_auxiliareswwds_13_tipaddsc3 = "";
         AV69Contabilidad_auxiliareswwds_14_tipadcod3 = "";
         AV70Contabilidad_auxiliareswwds_15_tftipadsc = "";
         AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel = "";
         AV72Contabilidad_auxiliareswwds_17_tftipadcod = "";
         AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel = "";
         AV74Contabilidad_auxiliareswwds_19_tftipaddsc = "";
         AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel = "";
         AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV58Contabilidad_auxiliareswwds_3_tipaddsc1 = "";
         lV59Contabilidad_auxiliareswwds_4_tipadcod1 = "";
         lV63Contabilidad_auxiliareswwds_8_tipaddsc2 = "";
         lV64Contabilidad_auxiliareswwds_9_tipadcod2 = "";
         lV68Contabilidad_auxiliareswwds_13_tipaddsc3 = "";
         lV69Contabilidad_auxiliareswwds_14_tipadcod3 = "";
         lV70Contabilidad_auxiliareswwds_15_tftipadsc = "";
         lV72Contabilidad_auxiliareswwds_17_tftipadcod = "";
         lV74Contabilidad_auxiliareswwds_19_tftipaddsc = "";
         A72TipADDsc = "";
         A71TipADCod = "";
         A1900TipADsc = "";
         P006N2_A70TipACod = new int[1] ;
         P006N2_A1900TipADsc = new string[] {""} ;
         P006N2_A1901TipADSts = new short[1] ;
         P006N2_A71TipADCod = new string[] {""} ;
         P006N2_A72TipADDsc = new string[] {""} ;
         AV22Option = "";
         P006N3_A70TipACod = new int[1] ;
         P006N3_A71TipADCod = new string[] {""} ;
         P006N3_A1901TipADSts = new short[1] ;
         P006N3_A1900TipADsc = new string[] {""} ;
         P006N3_A72TipADDsc = new string[] {""} ;
         P006N4_A70TipACod = new int[1] ;
         P006N4_A72TipADDsc = new string[] {""} ;
         P006N4_A1901TipADSts = new short[1] ;
         P006N4_A1900TipADsc = new string[] {""} ;
         P006N4_A71TipADCod = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.auxiliareswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006N2_A70TipACod, P006N2_A1900TipADsc, P006N2_A1901TipADSts, P006N2_A71TipADCod, P006N2_A72TipADDsc
               }
               , new Object[] {
               P006N3_A70TipACod, P006N3_A71TipADCod, P006N3_A1901TipADSts, P006N3_A1900TipADsc, P006N3_A72TipADDsc
               }
               , new Object[] {
               P006N4_A70TipACod, P006N4_A72TipADDsc, P006N4_A1901TipADSts, P006N4_A1900TipADsc, P006N4_A71TipADCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ;
      private short AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ;
      private short AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ;
      private short A1901TipADSts ;
      private int AV54GXV1 ;
      private int AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count ;
      private int A70TipACod ;
      private long AV30count ;
      private string AV50TFTipADsc ;
      private string AV51TFTipADsc_Sel ;
      private string AV12TFTipADCod ;
      private string AV13TFTipADCod_Sel ;
      private string AV14TFTipADDsc ;
      private string AV15TFTipADDsc_Sel ;
      private string AV38TipADDsc1 ;
      private string AV47TipADCod1 ;
      private string AV42TipADDsc2 ;
      private string AV48TipADCod2 ;
      private string AV46TipADDsc3 ;
      private string AV49TipADCod3 ;
      private string AV58Contabilidad_auxiliareswwds_3_tipaddsc1 ;
      private string AV59Contabilidad_auxiliareswwds_4_tipadcod1 ;
      private string AV63Contabilidad_auxiliareswwds_8_tipaddsc2 ;
      private string AV64Contabilidad_auxiliareswwds_9_tipadcod2 ;
      private string AV68Contabilidad_auxiliareswwds_13_tipaddsc3 ;
      private string AV69Contabilidad_auxiliareswwds_14_tipadcod3 ;
      private string AV70Contabilidad_auxiliareswwds_15_tftipadsc ;
      private string AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel ;
      private string AV72Contabilidad_auxiliareswwds_17_tftipadcod ;
      private string AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel ;
      private string AV74Contabilidad_auxiliareswwds_19_tftipaddsc ;
      private string AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel ;
      private string scmdbuf ;
      private string lV58Contabilidad_auxiliareswwds_3_tipaddsc1 ;
      private string lV59Contabilidad_auxiliareswwds_4_tipadcod1 ;
      private string lV63Contabilidad_auxiliareswwds_8_tipaddsc2 ;
      private string lV64Contabilidad_auxiliareswwds_9_tipadcod2 ;
      private string lV68Contabilidad_auxiliareswwds_13_tipaddsc3 ;
      private string lV69Contabilidad_auxiliareswwds_14_tipadcod3 ;
      private string lV70Contabilidad_auxiliareswwds_15_tftipadsc ;
      private string lV72Contabilidad_auxiliareswwds_17_tftipadcod ;
      private string lV74Contabilidad_auxiliareswwds_19_tftipaddsc ;
      private string A72TipADDsc ;
      private string A71TipADCod ;
      private string A1900TipADsc ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ;
      private bool AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ;
      private bool BRK6N2 ;
      private bool BRK6N4 ;
      private bool BRK6N6 ;
      private string AV24OptionsJson ;
      private string AV27OptionsDescJson ;
      private string AV29OptionIndexesJson ;
      private string AV16TFTipADSts_SelsJson ;
      private string AV20DDOName ;
      private string AV18SearchTxt ;
      private string AV19SearchTxtTo ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ;
      private string AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ;
      private string AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ;
      private string AV22Option ;
      private GxSimpleCollection<short> AV17TFTipADSts_Sels ;
      private GxSimpleCollection<short> AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P006N2_A70TipACod ;
      private string[] P006N2_A1900TipADsc ;
      private short[] P006N2_A1901TipADSts ;
      private string[] P006N2_A71TipADCod ;
      private string[] P006N2_A72TipADDsc ;
      private int[] P006N3_A70TipACod ;
      private string[] P006N3_A71TipADCod ;
      private short[] P006N3_A1901TipADSts ;
      private string[] P006N3_A1900TipADsc ;
      private string[] P006N3_A72TipADDsc ;
      private int[] P006N4_A70TipACod ;
      private string[] P006N4_A72TipADDsc ;
      private short[] P006N4_A1901TipADSts ;
      private string[] P006N4_A1900TipADsc ;
      private string[] P006N4_A71TipADCod ;
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

   public class auxiliareswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006N2( IGxContext context ,
                                             short A1901TipADSts ,
                                             GxSimpleCollection<short> AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels ,
                                             string AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ,
                                             short AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ,
                                             string AV58Contabilidad_auxiliareswwds_3_tipaddsc1 ,
                                             string AV59Contabilidad_auxiliareswwds_4_tipadcod1 ,
                                             bool AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ,
                                             string AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ,
                                             short AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ,
                                             string AV63Contabilidad_auxiliareswwds_8_tipaddsc2 ,
                                             string AV64Contabilidad_auxiliareswwds_9_tipadcod2 ,
                                             bool AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ,
                                             string AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ,
                                             short AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ,
                                             string AV68Contabilidad_auxiliareswwds_13_tipaddsc3 ,
                                             string AV69Contabilidad_auxiliareswwds_14_tipadcod3 ,
                                             string AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel ,
                                             string AV70Contabilidad_auxiliareswwds_15_tftipadsc ,
                                             string AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel ,
                                             string AV72Contabilidad_auxiliareswwds_17_tftipadcod ,
                                             string AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel ,
                                             string AV74Contabilidad_auxiliareswwds_19_tftipaddsc ,
                                             int AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count ,
                                             string A72TipADDsc ,
                                             string A71TipADCod ,
                                             string A1900TipADsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[18];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[TipACod], T2.[TipADsc], T1.[TipADSts], T1.[TipADCod], T1.[TipADDsc] FROM ([CBAUXILIARES] T1 INNER JOIN [CBTIPAUXILIAR] T2 ON T2.[TipACod] = T1.[TipACod])";
         if ( ( StringUtil.StrCmp(AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADDSC") == 0 ) && ( AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_3_tipaddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV58Contabilidad_auxiliareswwds_3_tipaddsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADDSC") == 0 ) && ( AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_3_tipaddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV58Contabilidad_auxiliareswwds_3_tipaddsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADCOD") == 0 ) && ( AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Contabilidad_auxiliareswwds_4_tipadcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV59Contabilidad_auxiliareswwds_4_tipadcod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADCOD") == 0 ) && ( AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Contabilidad_auxiliareswwds_4_tipadcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV59Contabilidad_auxiliareswwds_4_tipadcod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADDSC") == 0 ) && ( AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_8_tipaddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV63Contabilidad_auxiliareswwds_8_tipaddsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADDSC") == 0 ) && ( AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_8_tipaddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV63Contabilidad_auxiliareswwds_8_tipaddsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADCOD") == 0 ) && ( AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_auxiliareswwds_9_tipadcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV64Contabilidad_auxiliareswwds_9_tipadcod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADCOD") == 0 ) && ( AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_auxiliareswwds_9_tipadcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV64Contabilidad_auxiliareswwds_9_tipadcod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADDSC") == 0 ) && ( AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_13_tipaddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV68Contabilidad_auxiliareswwds_13_tipaddsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADDSC") == 0 ) && ( AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_13_tipaddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV68Contabilidad_auxiliareswwds_13_tipaddsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADCOD") == 0 ) && ( AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_14_tipadcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV69Contabilidad_auxiliareswwds_14_tipadcod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADCOD") == 0 ) && ( AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_14_tipadcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV69Contabilidad_auxiliareswwds_14_tipadcod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_auxiliareswwds_15_tftipadsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipADsc] like @lV70Contabilidad_auxiliareswwds_15_tftipadsc)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TipADsc] = @AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_17_tftipadcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV72Contabilidad_auxiliareswwds_17_tftipadcod)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] = @AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_auxiliareswwds_19_tftipaddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV74Contabilidad_auxiliareswwds_19_tftipaddsc)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] = @AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels, "T1.[TipADSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[TipADsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006N3( IGxContext context ,
                                             short A1901TipADSts ,
                                             GxSimpleCollection<short> AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels ,
                                             string AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ,
                                             short AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ,
                                             string AV58Contabilidad_auxiliareswwds_3_tipaddsc1 ,
                                             string AV59Contabilidad_auxiliareswwds_4_tipadcod1 ,
                                             bool AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ,
                                             string AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ,
                                             short AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ,
                                             string AV63Contabilidad_auxiliareswwds_8_tipaddsc2 ,
                                             string AV64Contabilidad_auxiliareswwds_9_tipadcod2 ,
                                             bool AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ,
                                             string AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ,
                                             short AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ,
                                             string AV68Contabilidad_auxiliareswwds_13_tipaddsc3 ,
                                             string AV69Contabilidad_auxiliareswwds_14_tipadcod3 ,
                                             string AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel ,
                                             string AV70Contabilidad_auxiliareswwds_15_tftipadsc ,
                                             string AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel ,
                                             string AV72Contabilidad_auxiliareswwds_17_tftipadcod ,
                                             string AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel ,
                                             string AV74Contabilidad_auxiliareswwds_19_tftipaddsc ,
                                             int AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count ,
                                             string A72TipADDsc ,
                                             string A71TipADCod ,
                                             string A1900TipADsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[18];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[TipACod], T1.[TipADCod], T1.[TipADSts], T2.[TipADsc], T1.[TipADDsc] FROM ([CBAUXILIARES] T1 INNER JOIN [CBTIPAUXILIAR] T2 ON T2.[TipACod] = T1.[TipACod])";
         if ( ( StringUtil.StrCmp(AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADDSC") == 0 ) && ( AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_3_tipaddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV58Contabilidad_auxiliareswwds_3_tipaddsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADDSC") == 0 ) && ( AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_3_tipaddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV58Contabilidad_auxiliareswwds_3_tipaddsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADCOD") == 0 ) && ( AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Contabilidad_auxiliareswwds_4_tipadcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV59Contabilidad_auxiliareswwds_4_tipadcod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADCOD") == 0 ) && ( AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Contabilidad_auxiliareswwds_4_tipadcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV59Contabilidad_auxiliareswwds_4_tipadcod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADDSC") == 0 ) && ( AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_8_tipaddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV63Contabilidad_auxiliareswwds_8_tipaddsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADDSC") == 0 ) && ( AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_8_tipaddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV63Contabilidad_auxiliareswwds_8_tipaddsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADCOD") == 0 ) && ( AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_auxiliareswwds_9_tipadcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV64Contabilidad_auxiliareswwds_9_tipadcod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADCOD") == 0 ) && ( AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_auxiliareswwds_9_tipadcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV64Contabilidad_auxiliareswwds_9_tipadcod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADDSC") == 0 ) && ( AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_13_tipaddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV68Contabilidad_auxiliareswwds_13_tipaddsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADDSC") == 0 ) && ( AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_13_tipaddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV68Contabilidad_auxiliareswwds_13_tipaddsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADCOD") == 0 ) && ( AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_14_tipadcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV69Contabilidad_auxiliareswwds_14_tipadcod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADCOD") == 0 ) && ( AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_14_tipadcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV69Contabilidad_auxiliareswwds_14_tipadcod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_auxiliareswwds_15_tftipadsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipADsc] like @lV70Contabilidad_auxiliareswwds_15_tftipadsc)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TipADsc] = @AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_17_tftipadcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV72Contabilidad_auxiliareswwds_17_tftipadcod)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] = @AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_auxiliareswwds_19_tftipaddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV74Contabilidad_auxiliareswwds_19_tftipaddsc)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] = @AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels, "T1.[TipADSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipADCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006N4( IGxContext context ,
                                             short A1901TipADSts ,
                                             GxSimpleCollection<short> AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels ,
                                             string AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1 ,
                                             short AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 ,
                                             string AV58Contabilidad_auxiliareswwds_3_tipaddsc1 ,
                                             string AV59Contabilidad_auxiliareswwds_4_tipadcod1 ,
                                             bool AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 ,
                                             string AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2 ,
                                             short AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 ,
                                             string AV63Contabilidad_auxiliareswwds_8_tipaddsc2 ,
                                             string AV64Contabilidad_auxiliareswwds_9_tipadcod2 ,
                                             bool AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 ,
                                             string AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3 ,
                                             short AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 ,
                                             string AV68Contabilidad_auxiliareswwds_13_tipaddsc3 ,
                                             string AV69Contabilidad_auxiliareswwds_14_tipadcod3 ,
                                             string AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel ,
                                             string AV70Contabilidad_auxiliareswwds_15_tftipadsc ,
                                             string AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel ,
                                             string AV72Contabilidad_auxiliareswwds_17_tftipadcod ,
                                             string AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel ,
                                             string AV74Contabilidad_auxiliareswwds_19_tftipaddsc ,
                                             int AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count ,
                                             string A72TipADDsc ,
                                             string A71TipADCod ,
                                             string A1900TipADsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[18];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[TipACod], T1.[TipADDsc], T1.[TipADSts], T2.[TipADsc], T1.[TipADCod] FROM ([CBAUXILIARES] T1 INNER JOIN [CBTIPAUXILIAR] T2 ON T2.[TipACod] = T1.[TipACod])";
         if ( ( StringUtil.StrCmp(AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADDSC") == 0 ) && ( AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_3_tipaddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV58Contabilidad_auxiliareswwds_3_tipaddsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADDSC") == 0 ) && ( AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Contabilidad_auxiliareswwds_3_tipaddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV58Contabilidad_auxiliareswwds_3_tipaddsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADCOD") == 0 ) && ( AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Contabilidad_auxiliareswwds_4_tipadcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV59Contabilidad_auxiliareswwds_4_tipadcod1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Contabilidad_auxiliareswwds_1_dynamicfiltersselector1, "TIPADCOD") == 0 ) && ( AV57Contabilidad_auxiliareswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Contabilidad_auxiliareswwds_4_tipadcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV59Contabilidad_auxiliareswwds_4_tipadcod1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADDSC") == 0 ) && ( AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_8_tipaddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV63Contabilidad_auxiliareswwds_8_tipaddsc2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADDSC") == 0 ) && ( AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_auxiliareswwds_8_tipaddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV63Contabilidad_auxiliareswwds_8_tipaddsc2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADCOD") == 0 ) && ( AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_auxiliareswwds_9_tipadcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV64Contabilidad_auxiliareswwds_9_tipadcod2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV60Contabilidad_auxiliareswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Contabilidad_auxiliareswwds_6_dynamicfiltersselector2, "TIPADCOD") == 0 ) && ( AV62Contabilidad_auxiliareswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_auxiliareswwds_9_tipadcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV64Contabilidad_auxiliareswwds_9_tipadcod2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADDSC") == 0 ) && ( AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_13_tipaddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV68Contabilidad_auxiliareswwds_13_tipaddsc3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADDSC") == 0 ) && ( AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Contabilidad_auxiliareswwds_13_tipaddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like '%' + @lV68Contabilidad_auxiliareswwds_13_tipaddsc3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADCOD") == 0 ) && ( AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_14_tipadcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV69Contabilidad_auxiliareswwds_14_tipadcod3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV65Contabilidad_auxiliareswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Contabilidad_auxiliareswwds_11_dynamicfiltersselector3, "TIPADCOD") == 0 ) && ( AV67Contabilidad_auxiliareswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_auxiliareswwds_14_tipadcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like '%' + @lV69Contabilidad_auxiliareswwds_14_tipadcod3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_auxiliareswwds_15_tftipadsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipADsc] like @lV70Contabilidad_auxiliareswwds_15_tftipadsc)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TipADsc] = @AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_auxiliareswwds_17_tftipadcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] like @lV72Contabilidad_auxiliareswwds_17_tftipadcod)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipADCod] = @AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_auxiliareswwds_19_tftipaddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] like @lV74Contabilidad_auxiliareswwds_19_tftipaddsc)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipADDsc] = @AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Contabilidad_auxiliareswwds_21_tftipadsts_sels, "T1.[TipADSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipADDsc]";
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
                     return conditional_P006N2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
               case 1 :
                     return conditional_P006N3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
               case 2 :
                     return conditional_P006N4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
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
          Object[] prmP006N2;
          prmP006N2 = new Object[] {
          new ParDef("@lV58Contabilidad_auxiliareswwds_3_tipaddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Contabilidad_auxiliareswwds_3_tipaddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Contabilidad_auxiliareswwds_4_tipadcod1",GXType.NChar,20,0) ,
          new ParDef("@lV59Contabilidad_auxiliareswwds_4_tipadcod1",GXType.NChar,20,0) ,
          new ParDef("@lV63Contabilidad_auxiliareswwds_8_tipaddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Contabilidad_auxiliareswwds_8_tipaddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV64Contabilidad_auxiliareswwds_9_tipadcod2",GXType.NChar,20,0) ,
          new ParDef("@lV64Contabilidad_auxiliareswwds_9_tipadcod2",GXType.NChar,20,0) ,
          new ParDef("@lV68Contabilidad_auxiliareswwds_13_tipaddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Contabilidad_auxiliareswwds_13_tipaddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Contabilidad_auxiliareswwds_14_tipadcod3",GXType.NChar,20,0) ,
          new ParDef("@lV69Contabilidad_auxiliareswwds_14_tipadcod3",GXType.NChar,20,0) ,
          new ParDef("@lV70Contabilidad_auxiliareswwds_15_tftipadsc",GXType.NChar,100,0) ,
          new ParDef("@AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV72Contabilidad_auxiliareswwds_17_tftipadcod",GXType.NChar,20,0) ,
          new ParDef("@AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV74Contabilidad_auxiliareswwds_19_tftipaddsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP006N3;
          prmP006N3 = new Object[] {
          new ParDef("@lV58Contabilidad_auxiliareswwds_3_tipaddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Contabilidad_auxiliareswwds_3_tipaddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Contabilidad_auxiliareswwds_4_tipadcod1",GXType.NChar,20,0) ,
          new ParDef("@lV59Contabilidad_auxiliareswwds_4_tipadcod1",GXType.NChar,20,0) ,
          new ParDef("@lV63Contabilidad_auxiliareswwds_8_tipaddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Contabilidad_auxiliareswwds_8_tipaddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV64Contabilidad_auxiliareswwds_9_tipadcod2",GXType.NChar,20,0) ,
          new ParDef("@lV64Contabilidad_auxiliareswwds_9_tipadcod2",GXType.NChar,20,0) ,
          new ParDef("@lV68Contabilidad_auxiliareswwds_13_tipaddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Contabilidad_auxiliareswwds_13_tipaddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Contabilidad_auxiliareswwds_14_tipadcod3",GXType.NChar,20,0) ,
          new ParDef("@lV69Contabilidad_auxiliareswwds_14_tipadcod3",GXType.NChar,20,0) ,
          new ParDef("@lV70Contabilidad_auxiliareswwds_15_tftipadsc",GXType.NChar,100,0) ,
          new ParDef("@AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV72Contabilidad_auxiliareswwds_17_tftipadcod",GXType.NChar,20,0) ,
          new ParDef("@AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV74Contabilidad_auxiliareswwds_19_tftipaddsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP006N4;
          prmP006N4 = new Object[] {
          new ParDef("@lV58Contabilidad_auxiliareswwds_3_tipaddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Contabilidad_auxiliareswwds_3_tipaddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Contabilidad_auxiliareswwds_4_tipadcod1",GXType.NChar,20,0) ,
          new ParDef("@lV59Contabilidad_auxiliareswwds_4_tipadcod1",GXType.NChar,20,0) ,
          new ParDef("@lV63Contabilidad_auxiliareswwds_8_tipaddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Contabilidad_auxiliareswwds_8_tipaddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV64Contabilidad_auxiliareswwds_9_tipadcod2",GXType.NChar,20,0) ,
          new ParDef("@lV64Contabilidad_auxiliareswwds_9_tipadcod2",GXType.NChar,20,0) ,
          new ParDef("@lV68Contabilidad_auxiliareswwds_13_tipaddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Contabilidad_auxiliareswwds_13_tipaddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Contabilidad_auxiliareswwds_14_tipadcod3",GXType.NChar,20,0) ,
          new ParDef("@lV69Contabilidad_auxiliareswwds_14_tipadcod3",GXType.NChar,20,0) ,
          new ParDef("@lV70Contabilidad_auxiliareswwds_15_tftipadsc",GXType.NChar,100,0) ,
          new ParDef("@AV71Contabilidad_auxiliareswwds_16_tftipadsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV72Contabilidad_auxiliareswwds_17_tftipadcod",GXType.NChar,20,0) ,
          new ParDef("@AV73Contabilidad_auxiliareswwds_18_tftipadcod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV74Contabilidad_auxiliareswwds_19_tftipaddsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Contabilidad_auxiliareswwds_20_tftipaddsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006N2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006N2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006N3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006N3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006N4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006N4,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                return;
       }
    }

 }

}
