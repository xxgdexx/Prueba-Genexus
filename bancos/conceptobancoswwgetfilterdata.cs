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
namespace GeneXus.Programs.bancos {
   public class conceptobancoswwgetfilterdata : GXProcedure
   {
      public conceptobancoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptobancoswwgetfilterdata( IGxContext context )
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
         conceptobancoswwgetfilterdata objconceptobancoswwgetfilterdata;
         objconceptobancoswwgetfilterdata = new conceptobancoswwgetfilterdata();
         objconceptobancoswwgetfilterdata.AV22DDOName = aP0_DDOName;
         objconceptobancoswwgetfilterdata.AV20SearchTxt = aP1_SearchTxt;
         objconceptobancoswwgetfilterdata.AV21SearchTxtTo = aP2_SearchTxtTo;
         objconceptobancoswwgetfilterdata.AV26OptionsJson = "" ;
         objconceptobancoswwgetfilterdata.AV29OptionsDescJson = "" ;
         objconceptobancoswwgetfilterdata.AV31OptionIndexesJson = "" ;
         objconceptobancoswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objconceptobancoswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptobancoswwgetfilterdata);
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptobancoswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_CONBDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCONBDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_CONBCUECOD") == 0 )
         {
            /* Execute user subroutine: 'LOADCONBCUECODOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_CONBCUEDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCONBCUEDSCOPTIONS' */
            S141 ();
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
         if ( StringUtil.StrCmp(AV33Session.Get("Bancos.ConceptoBancosWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.ConceptoBancosWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Bancos.ConceptoBancosWWGridState"), null, "", "");
         }
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBCOD") == 0 )
            {
               AV10TFConBCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV11TFConBCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBDSC") == 0 )
            {
               AV12TFConBDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBDSC_SEL") == 0 )
            {
               AV13TFConBDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBCUECOD") == 0 )
            {
               AV14TFConBCueCod = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBCUECOD_SEL") == 0 )
            {
               AV15TFConBCueCod_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBCUEDSC") == 0 )
            {
               AV18TFConBCueDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBCUEDSC_SEL") == 0 )
            {
               AV19TFConBCueDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONBSTS_SEL") == 0 )
            {
               AV52TFConBSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV53TFConBSts_Sels.FromJSonString(AV52TFConBSts_SelsJson, null);
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "CONBDSC") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV40ConBDsc1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "CONBCUECOD") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV54ConBCueCod1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV42DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV43DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV43DynamicFiltersSelector2, "CONBDSC") == 0 )
               {
                  AV44DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV45ConBDsc2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV43DynamicFiltersSelector2, "CONBCUECOD") == 0 )
               {
                  AV44DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV55ConBCueCod2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "CONBDSC") == 0 )
                  {
                     AV49DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV50ConBDsc3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "CONBCUECOD") == 0 )
                  {
                     AV49DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV56ConBCueCod3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCONBDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFConBDsc = AV20SearchTxt;
         AV13TFConBDsc_Sel = "";
         AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV63Bancos_conceptobancoswwds_3_conbdsc1 = AV40ConBDsc1;
         AV64Bancos_conceptobancoswwds_4_conbcuecod1 = AV54ConBCueCod1;
         AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV68Bancos_conceptobancoswwds_8_conbdsc2 = AV45ConBDsc2;
         AV69Bancos_conceptobancoswwds_9_conbcuecod2 = AV55ConBCueCod2;
         AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV73Bancos_conceptobancoswwds_13_conbdsc3 = AV50ConBDsc3;
         AV74Bancos_conceptobancoswwds_14_conbcuecod3 = AV56ConBCueCod3;
         AV75Bancos_conceptobancoswwds_15_tfconbcod = AV10TFConBCod;
         AV76Bancos_conceptobancoswwds_16_tfconbcod_to = AV11TFConBCod_To;
         AV77Bancos_conceptobancoswwds_17_tfconbdsc = AV12TFConBDsc;
         AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel = AV13TFConBDsc_Sel;
         AV79Bancos_conceptobancoswwds_19_tfconbcuecod = AV14TFConBCueCod;
         AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel = AV15TFConBCueCod_Sel;
         AV81Bancos_conceptobancoswwds_21_tfconbcuedsc = AV18TFConBCueDsc;
         AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel = AV19TFConBCueDsc_Sel;
         AV83Bancos_conceptobancoswwds_23_tfconbsts_sels = AV53TFConBSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A746ConBSts ,
                                              AV83Bancos_conceptobancoswwds_23_tfconbsts_sels ,
                                              AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1 ,
                                              AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 ,
                                              AV63Bancos_conceptobancoswwds_3_conbdsc1 ,
                                              AV64Bancos_conceptobancoswwds_4_conbcuecod1 ,
                                              AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 ,
                                              AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2 ,
                                              AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 ,
                                              AV68Bancos_conceptobancoswwds_8_conbdsc2 ,
                                              AV69Bancos_conceptobancoswwds_9_conbcuecod2 ,
                                              AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 ,
                                              AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3 ,
                                              AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 ,
                                              AV73Bancos_conceptobancoswwds_13_conbdsc3 ,
                                              AV74Bancos_conceptobancoswwds_14_conbcuecod3 ,
                                              AV75Bancos_conceptobancoswwds_15_tfconbcod ,
                                              AV76Bancos_conceptobancoswwds_16_tfconbcod_to ,
                                              AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel ,
                                              AV77Bancos_conceptobancoswwds_17_tfconbdsc ,
                                              AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel ,
                                              AV79Bancos_conceptobancoswwds_19_tfconbcuecod ,
                                              AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel ,
                                              AV81Bancos_conceptobancoswwds_21_tfconbcuedsc ,
                                              AV83Bancos_conceptobancoswwds_23_tfconbsts_sels.Count ,
                                              A745ConBDsc ,
                                              A374ConBCueCod ,
                                              A355ConBCod ,
                                              A744ConBCueDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV63Bancos_conceptobancoswwds_3_conbdsc1 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_conceptobancoswwds_3_conbdsc1), 100, "%");
         lV63Bancos_conceptobancoswwds_3_conbdsc1 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_conceptobancoswwds_3_conbdsc1), 100, "%");
         lV64Bancos_conceptobancoswwds_4_conbcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptobancoswwds_4_conbcuecod1), 15, "%");
         lV64Bancos_conceptobancoswwds_4_conbcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptobancoswwds_4_conbcuecod1), 15, "%");
         lV68Bancos_conceptobancoswwds_8_conbdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_conceptobancoswwds_8_conbdsc2), 100, "%");
         lV68Bancos_conceptobancoswwds_8_conbdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_conceptobancoswwds_8_conbdsc2), 100, "%");
         lV69Bancos_conceptobancoswwds_9_conbcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptobancoswwds_9_conbcuecod2), 15, "%");
         lV69Bancos_conceptobancoswwds_9_conbcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptobancoswwds_9_conbcuecod2), 15, "%");
         lV73Bancos_conceptobancoswwds_13_conbdsc3 = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_conceptobancoswwds_13_conbdsc3), 100, "%");
         lV73Bancos_conceptobancoswwds_13_conbdsc3 = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_conceptobancoswwds_13_conbdsc3), 100, "%");
         lV74Bancos_conceptobancoswwds_14_conbcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_conceptobancoswwds_14_conbcuecod3), 15, "%");
         lV74Bancos_conceptobancoswwds_14_conbcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_conceptobancoswwds_14_conbcuecod3), 15, "%");
         lV77Bancos_conceptobancoswwds_17_tfconbdsc = StringUtil.PadR( StringUtil.RTrim( AV77Bancos_conceptobancoswwds_17_tfconbdsc), 100, "%");
         lV79Bancos_conceptobancoswwds_19_tfconbcuecod = StringUtil.PadR( StringUtil.RTrim( AV79Bancos_conceptobancoswwds_19_tfconbcuecod), 15, "%");
         lV81Bancos_conceptobancoswwds_21_tfconbcuedsc = StringUtil.PadR( StringUtil.RTrim( AV81Bancos_conceptobancoswwds_21_tfconbcuedsc), 100, "%");
         /* Using cursor P005G2 */
         pr_default.execute(0, new Object[] {lV63Bancos_conceptobancoswwds_3_conbdsc1, lV63Bancos_conceptobancoswwds_3_conbdsc1, lV64Bancos_conceptobancoswwds_4_conbcuecod1, lV64Bancos_conceptobancoswwds_4_conbcuecod1, lV68Bancos_conceptobancoswwds_8_conbdsc2, lV68Bancos_conceptobancoswwds_8_conbdsc2, lV69Bancos_conceptobancoswwds_9_conbcuecod2, lV69Bancos_conceptobancoswwds_9_conbcuecod2, lV73Bancos_conceptobancoswwds_13_conbdsc3, lV73Bancos_conceptobancoswwds_13_conbdsc3, lV74Bancos_conceptobancoswwds_14_conbcuecod3, lV74Bancos_conceptobancoswwds_14_conbcuecod3, AV75Bancos_conceptobancoswwds_15_tfconbcod, AV76Bancos_conceptobancoswwds_16_tfconbcod_to, lV77Bancos_conceptobancoswwds_17_tfconbdsc, AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel, lV79Bancos_conceptobancoswwds_19_tfconbcuecod, AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel, lV81Bancos_conceptobancoswwds_21_tfconbcuedsc, AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5G2 = false;
            A745ConBDsc = P005G2_A745ConBDsc[0];
            A746ConBSts = P005G2_A746ConBSts[0];
            A744ConBCueDsc = P005G2_A744ConBCueDsc[0];
            A355ConBCod = P005G2_A355ConBCod[0];
            A374ConBCueCod = P005G2_A374ConBCueCod[0];
            A744ConBCueDsc = P005G2_A744ConBCueDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005G2_A745ConBDsc[0], A745ConBDsc) == 0 ) )
            {
               BRK5G2 = false;
               A355ConBCod = P005G2_A355ConBCod[0];
               AV32count = (long)(AV32count+1);
               BRK5G2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A745ConBDsc)) )
            {
               AV24Option = A745ConBDsc;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK5G2 )
            {
               BRK5G2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCONBCUECODOPTIONS' Routine */
         returnInSub = false;
         AV14TFConBCueCod = AV20SearchTxt;
         AV15TFConBCueCod_Sel = "";
         AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV63Bancos_conceptobancoswwds_3_conbdsc1 = AV40ConBDsc1;
         AV64Bancos_conceptobancoswwds_4_conbcuecod1 = AV54ConBCueCod1;
         AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV68Bancos_conceptobancoswwds_8_conbdsc2 = AV45ConBDsc2;
         AV69Bancos_conceptobancoswwds_9_conbcuecod2 = AV55ConBCueCod2;
         AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV73Bancos_conceptobancoswwds_13_conbdsc3 = AV50ConBDsc3;
         AV74Bancos_conceptobancoswwds_14_conbcuecod3 = AV56ConBCueCod3;
         AV75Bancos_conceptobancoswwds_15_tfconbcod = AV10TFConBCod;
         AV76Bancos_conceptobancoswwds_16_tfconbcod_to = AV11TFConBCod_To;
         AV77Bancos_conceptobancoswwds_17_tfconbdsc = AV12TFConBDsc;
         AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel = AV13TFConBDsc_Sel;
         AV79Bancos_conceptobancoswwds_19_tfconbcuecod = AV14TFConBCueCod;
         AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel = AV15TFConBCueCod_Sel;
         AV81Bancos_conceptobancoswwds_21_tfconbcuedsc = AV18TFConBCueDsc;
         AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel = AV19TFConBCueDsc_Sel;
         AV83Bancos_conceptobancoswwds_23_tfconbsts_sels = AV53TFConBSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A746ConBSts ,
                                              AV83Bancos_conceptobancoswwds_23_tfconbsts_sels ,
                                              AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1 ,
                                              AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 ,
                                              AV63Bancos_conceptobancoswwds_3_conbdsc1 ,
                                              AV64Bancos_conceptobancoswwds_4_conbcuecod1 ,
                                              AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 ,
                                              AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2 ,
                                              AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 ,
                                              AV68Bancos_conceptobancoswwds_8_conbdsc2 ,
                                              AV69Bancos_conceptobancoswwds_9_conbcuecod2 ,
                                              AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 ,
                                              AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3 ,
                                              AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 ,
                                              AV73Bancos_conceptobancoswwds_13_conbdsc3 ,
                                              AV74Bancos_conceptobancoswwds_14_conbcuecod3 ,
                                              AV75Bancos_conceptobancoswwds_15_tfconbcod ,
                                              AV76Bancos_conceptobancoswwds_16_tfconbcod_to ,
                                              AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel ,
                                              AV77Bancos_conceptobancoswwds_17_tfconbdsc ,
                                              AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel ,
                                              AV79Bancos_conceptobancoswwds_19_tfconbcuecod ,
                                              AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel ,
                                              AV81Bancos_conceptobancoswwds_21_tfconbcuedsc ,
                                              AV83Bancos_conceptobancoswwds_23_tfconbsts_sels.Count ,
                                              A745ConBDsc ,
                                              A374ConBCueCod ,
                                              A355ConBCod ,
                                              A744ConBCueDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV63Bancos_conceptobancoswwds_3_conbdsc1 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_conceptobancoswwds_3_conbdsc1), 100, "%");
         lV63Bancos_conceptobancoswwds_3_conbdsc1 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_conceptobancoswwds_3_conbdsc1), 100, "%");
         lV64Bancos_conceptobancoswwds_4_conbcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptobancoswwds_4_conbcuecod1), 15, "%");
         lV64Bancos_conceptobancoswwds_4_conbcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptobancoswwds_4_conbcuecod1), 15, "%");
         lV68Bancos_conceptobancoswwds_8_conbdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_conceptobancoswwds_8_conbdsc2), 100, "%");
         lV68Bancos_conceptobancoswwds_8_conbdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_conceptobancoswwds_8_conbdsc2), 100, "%");
         lV69Bancos_conceptobancoswwds_9_conbcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptobancoswwds_9_conbcuecod2), 15, "%");
         lV69Bancos_conceptobancoswwds_9_conbcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptobancoswwds_9_conbcuecod2), 15, "%");
         lV73Bancos_conceptobancoswwds_13_conbdsc3 = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_conceptobancoswwds_13_conbdsc3), 100, "%");
         lV73Bancos_conceptobancoswwds_13_conbdsc3 = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_conceptobancoswwds_13_conbdsc3), 100, "%");
         lV74Bancos_conceptobancoswwds_14_conbcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_conceptobancoswwds_14_conbcuecod3), 15, "%");
         lV74Bancos_conceptobancoswwds_14_conbcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_conceptobancoswwds_14_conbcuecod3), 15, "%");
         lV77Bancos_conceptobancoswwds_17_tfconbdsc = StringUtil.PadR( StringUtil.RTrim( AV77Bancos_conceptobancoswwds_17_tfconbdsc), 100, "%");
         lV79Bancos_conceptobancoswwds_19_tfconbcuecod = StringUtil.PadR( StringUtil.RTrim( AV79Bancos_conceptobancoswwds_19_tfconbcuecod), 15, "%");
         lV81Bancos_conceptobancoswwds_21_tfconbcuedsc = StringUtil.PadR( StringUtil.RTrim( AV81Bancos_conceptobancoswwds_21_tfconbcuedsc), 100, "%");
         /* Using cursor P005G3 */
         pr_default.execute(1, new Object[] {lV63Bancos_conceptobancoswwds_3_conbdsc1, lV63Bancos_conceptobancoswwds_3_conbdsc1, lV64Bancos_conceptobancoswwds_4_conbcuecod1, lV64Bancos_conceptobancoswwds_4_conbcuecod1, lV68Bancos_conceptobancoswwds_8_conbdsc2, lV68Bancos_conceptobancoswwds_8_conbdsc2, lV69Bancos_conceptobancoswwds_9_conbcuecod2, lV69Bancos_conceptobancoswwds_9_conbcuecod2, lV73Bancos_conceptobancoswwds_13_conbdsc3, lV73Bancos_conceptobancoswwds_13_conbdsc3, lV74Bancos_conceptobancoswwds_14_conbcuecod3, lV74Bancos_conceptobancoswwds_14_conbcuecod3, AV75Bancos_conceptobancoswwds_15_tfconbcod, AV76Bancos_conceptobancoswwds_16_tfconbcod_to, lV77Bancos_conceptobancoswwds_17_tfconbdsc, AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel, lV79Bancos_conceptobancoswwds_19_tfconbcuecod, AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel, lV81Bancos_conceptobancoswwds_21_tfconbcuedsc, AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5G4 = false;
            A374ConBCueCod = P005G3_A374ConBCueCod[0];
            A746ConBSts = P005G3_A746ConBSts[0];
            A744ConBCueDsc = P005G3_A744ConBCueDsc[0];
            A355ConBCod = P005G3_A355ConBCod[0];
            A745ConBDsc = P005G3_A745ConBDsc[0];
            A744ConBCueDsc = P005G3_A744ConBCueDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005G3_A374ConBCueCod[0], A374ConBCueCod) == 0 ) )
            {
               BRK5G4 = false;
               A355ConBCod = P005G3_A355ConBCod[0];
               AV32count = (long)(AV32count+1);
               BRK5G4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A374ConBCueCod)) )
            {
               AV24Option = A374ConBCueCod;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK5G4 )
            {
               BRK5G4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCONBCUEDSCOPTIONS' Routine */
         returnInSub = false;
         AV18TFConBCueDsc = AV20SearchTxt;
         AV19TFConBCueDsc_Sel = "";
         AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV63Bancos_conceptobancoswwds_3_conbdsc1 = AV40ConBDsc1;
         AV64Bancos_conceptobancoswwds_4_conbcuecod1 = AV54ConBCueCod1;
         AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV68Bancos_conceptobancoswwds_8_conbdsc2 = AV45ConBDsc2;
         AV69Bancos_conceptobancoswwds_9_conbcuecod2 = AV55ConBCueCod2;
         AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV73Bancos_conceptobancoswwds_13_conbdsc3 = AV50ConBDsc3;
         AV74Bancos_conceptobancoswwds_14_conbcuecod3 = AV56ConBCueCod3;
         AV75Bancos_conceptobancoswwds_15_tfconbcod = AV10TFConBCod;
         AV76Bancos_conceptobancoswwds_16_tfconbcod_to = AV11TFConBCod_To;
         AV77Bancos_conceptobancoswwds_17_tfconbdsc = AV12TFConBDsc;
         AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel = AV13TFConBDsc_Sel;
         AV79Bancos_conceptobancoswwds_19_tfconbcuecod = AV14TFConBCueCod;
         AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel = AV15TFConBCueCod_Sel;
         AV81Bancos_conceptobancoswwds_21_tfconbcuedsc = AV18TFConBCueDsc;
         AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel = AV19TFConBCueDsc_Sel;
         AV83Bancos_conceptobancoswwds_23_tfconbsts_sels = AV53TFConBSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A746ConBSts ,
                                              AV83Bancos_conceptobancoswwds_23_tfconbsts_sels ,
                                              AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1 ,
                                              AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 ,
                                              AV63Bancos_conceptobancoswwds_3_conbdsc1 ,
                                              AV64Bancos_conceptobancoswwds_4_conbcuecod1 ,
                                              AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 ,
                                              AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2 ,
                                              AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 ,
                                              AV68Bancos_conceptobancoswwds_8_conbdsc2 ,
                                              AV69Bancos_conceptobancoswwds_9_conbcuecod2 ,
                                              AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 ,
                                              AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3 ,
                                              AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 ,
                                              AV73Bancos_conceptobancoswwds_13_conbdsc3 ,
                                              AV74Bancos_conceptobancoswwds_14_conbcuecod3 ,
                                              AV75Bancos_conceptobancoswwds_15_tfconbcod ,
                                              AV76Bancos_conceptobancoswwds_16_tfconbcod_to ,
                                              AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel ,
                                              AV77Bancos_conceptobancoswwds_17_tfconbdsc ,
                                              AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel ,
                                              AV79Bancos_conceptobancoswwds_19_tfconbcuecod ,
                                              AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel ,
                                              AV81Bancos_conceptobancoswwds_21_tfconbcuedsc ,
                                              AV83Bancos_conceptobancoswwds_23_tfconbsts_sels.Count ,
                                              A745ConBDsc ,
                                              A374ConBCueCod ,
                                              A355ConBCod ,
                                              A744ConBCueDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV63Bancos_conceptobancoswwds_3_conbdsc1 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_conceptobancoswwds_3_conbdsc1), 100, "%");
         lV63Bancos_conceptobancoswwds_3_conbdsc1 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_conceptobancoswwds_3_conbdsc1), 100, "%");
         lV64Bancos_conceptobancoswwds_4_conbcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptobancoswwds_4_conbcuecod1), 15, "%");
         lV64Bancos_conceptobancoswwds_4_conbcuecod1 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptobancoswwds_4_conbcuecod1), 15, "%");
         lV68Bancos_conceptobancoswwds_8_conbdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_conceptobancoswwds_8_conbdsc2), 100, "%");
         lV68Bancos_conceptobancoswwds_8_conbdsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_conceptobancoswwds_8_conbdsc2), 100, "%");
         lV69Bancos_conceptobancoswwds_9_conbcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptobancoswwds_9_conbcuecod2), 15, "%");
         lV69Bancos_conceptobancoswwds_9_conbcuecod2 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptobancoswwds_9_conbcuecod2), 15, "%");
         lV73Bancos_conceptobancoswwds_13_conbdsc3 = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_conceptobancoswwds_13_conbdsc3), 100, "%");
         lV73Bancos_conceptobancoswwds_13_conbdsc3 = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_conceptobancoswwds_13_conbdsc3), 100, "%");
         lV74Bancos_conceptobancoswwds_14_conbcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_conceptobancoswwds_14_conbcuecod3), 15, "%");
         lV74Bancos_conceptobancoswwds_14_conbcuecod3 = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_conceptobancoswwds_14_conbcuecod3), 15, "%");
         lV77Bancos_conceptobancoswwds_17_tfconbdsc = StringUtil.PadR( StringUtil.RTrim( AV77Bancos_conceptobancoswwds_17_tfconbdsc), 100, "%");
         lV79Bancos_conceptobancoswwds_19_tfconbcuecod = StringUtil.PadR( StringUtil.RTrim( AV79Bancos_conceptobancoswwds_19_tfconbcuecod), 15, "%");
         lV81Bancos_conceptobancoswwds_21_tfconbcuedsc = StringUtil.PadR( StringUtil.RTrim( AV81Bancos_conceptobancoswwds_21_tfconbcuedsc), 100, "%");
         /* Using cursor P005G4 */
         pr_default.execute(2, new Object[] {lV63Bancos_conceptobancoswwds_3_conbdsc1, lV63Bancos_conceptobancoswwds_3_conbdsc1, lV64Bancos_conceptobancoswwds_4_conbcuecod1, lV64Bancos_conceptobancoswwds_4_conbcuecod1, lV68Bancos_conceptobancoswwds_8_conbdsc2, lV68Bancos_conceptobancoswwds_8_conbdsc2, lV69Bancos_conceptobancoswwds_9_conbcuecod2, lV69Bancos_conceptobancoswwds_9_conbcuecod2, lV73Bancos_conceptobancoswwds_13_conbdsc3, lV73Bancos_conceptobancoswwds_13_conbdsc3, lV74Bancos_conceptobancoswwds_14_conbcuecod3, lV74Bancos_conceptobancoswwds_14_conbcuecod3, AV75Bancos_conceptobancoswwds_15_tfconbcod, AV76Bancos_conceptobancoswwds_16_tfconbcod_to, lV77Bancos_conceptobancoswwds_17_tfconbdsc, AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel, lV79Bancos_conceptobancoswwds_19_tfconbcuecod, AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel, lV81Bancos_conceptobancoswwds_21_tfconbcuedsc, AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5G6 = false;
            A374ConBCueCod = P005G4_A374ConBCueCod[0];
            A746ConBSts = P005G4_A746ConBSts[0];
            A744ConBCueDsc = P005G4_A744ConBCueDsc[0];
            A355ConBCod = P005G4_A355ConBCod[0];
            A745ConBDsc = P005G4_A745ConBDsc[0];
            A744ConBCueDsc = P005G4_A744ConBCueDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005G4_A374ConBCueCod[0], A374ConBCueCod) == 0 ) )
            {
               BRK5G6 = false;
               A355ConBCod = P005G4_A355ConBCod[0];
               AV32count = (long)(AV32count+1);
               BRK5G6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A744ConBCueDsc)) )
            {
               AV24Option = A744ConBCueDsc;
               AV23InsertIndex = 1;
               while ( ( AV23InsertIndex <= AV25Options.Count ) && ( StringUtil.StrCmp(((string)AV25Options.Item(AV23InsertIndex)), AV24Option) < 0 ) )
               {
                  AV23InsertIndex = (int)(AV23InsertIndex+1);
               }
               AV25Options.Add(AV24Option, AV23InsertIndex);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), AV23InsertIndex);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK5G6 )
            {
               BRK5G6 = true;
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
         AV12TFConBDsc = "";
         AV13TFConBDsc_Sel = "";
         AV14TFConBCueCod = "";
         AV15TFConBCueCod_Sel = "";
         AV18TFConBCueDsc = "";
         AV19TFConBCueDsc_Sel = "";
         AV52TFConBSts_SelsJson = "";
         AV53TFConBSts_Sels = new GxSimpleCollection<short>();
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40ConBDsc1 = "";
         AV54ConBCueCod1 = "";
         AV43DynamicFiltersSelector2 = "";
         AV45ConBDsc2 = "";
         AV55ConBCueCod2 = "";
         AV48DynamicFiltersSelector3 = "";
         AV50ConBDsc3 = "";
         AV56ConBCueCod3 = "";
         AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1 = "";
         AV63Bancos_conceptobancoswwds_3_conbdsc1 = "";
         AV64Bancos_conceptobancoswwds_4_conbcuecod1 = "";
         AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2 = "";
         AV68Bancos_conceptobancoswwds_8_conbdsc2 = "";
         AV69Bancos_conceptobancoswwds_9_conbcuecod2 = "";
         AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3 = "";
         AV73Bancos_conceptobancoswwds_13_conbdsc3 = "";
         AV74Bancos_conceptobancoswwds_14_conbcuecod3 = "";
         AV77Bancos_conceptobancoswwds_17_tfconbdsc = "";
         AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel = "";
         AV79Bancos_conceptobancoswwds_19_tfconbcuecod = "";
         AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel = "";
         AV81Bancos_conceptobancoswwds_21_tfconbcuedsc = "";
         AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel = "";
         AV83Bancos_conceptobancoswwds_23_tfconbsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV63Bancos_conceptobancoswwds_3_conbdsc1 = "";
         lV64Bancos_conceptobancoswwds_4_conbcuecod1 = "";
         lV68Bancos_conceptobancoswwds_8_conbdsc2 = "";
         lV69Bancos_conceptobancoswwds_9_conbcuecod2 = "";
         lV73Bancos_conceptobancoswwds_13_conbdsc3 = "";
         lV74Bancos_conceptobancoswwds_14_conbcuecod3 = "";
         lV77Bancos_conceptobancoswwds_17_tfconbdsc = "";
         lV79Bancos_conceptobancoswwds_19_tfconbcuecod = "";
         lV81Bancos_conceptobancoswwds_21_tfconbcuedsc = "";
         A745ConBDsc = "";
         A374ConBCueCod = "";
         A744ConBCueDsc = "";
         P005G2_A745ConBDsc = new string[] {""} ;
         P005G2_A746ConBSts = new short[1] ;
         P005G2_A744ConBCueDsc = new string[] {""} ;
         P005G2_A355ConBCod = new int[1] ;
         P005G2_A374ConBCueCod = new string[] {""} ;
         AV24Option = "";
         P005G3_A374ConBCueCod = new string[] {""} ;
         P005G3_A746ConBSts = new short[1] ;
         P005G3_A744ConBCueDsc = new string[] {""} ;
         P005G3_A355ConBCod = new int[1] ;
         P005G3_A745ConBDsc = new string[] {""} ;
         P005G4_A374ConBCueCod = new string[] {""} ;
         P005G4_A746ConBSts = new short[1] ;
         P005G4_A744ConBCueDsc = new string[] {""} ;
         P005G4_A355ConBCod = new int[1] ;
         P005G4_A745ConBDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.conceptobancoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005G2_A745ConBDsc, P005G2_A746ConBSts, P005G2_A744ConBCueDsc, P005G2_A355ConBCod, P005G2_A374ConBCueCod
               }
               , new Object[] {
               P005G3_A374ConBCueCod, P005G3_A746ConBSts, P005G3_A744ConBCueDsc, P005G3_A355ConBCod, P005G3_A745ConBDsc
               }
               , new Object[] {
               P005G4_A374ConBCueCod, P005G4_A746ConBSts, P005G4_A744ConBCueDsc, P005G4_A355ConBCod, P005G4_A745ConBDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV39DynamicFiltersOperator1 ;
      private short AV44DynamicFiltersOperator2 ;
      private short AV49DynamicFiltersOperator3 ;
      private short AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 ;
      private short AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 ;
      private short AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 ;
      private short A746ConBSts ;
      private int AV59GXV1 ;
      private int AV10TFConBCod ;
      private int AV11TFConBCod_To ;
      private int AV75Bancos_conceptobancoswwds_15_tfconbcod ;
      private int AV76Bancos_conceptobancoswwds_16_tfconbcod_to ;
      private int AV83Bancos_conceptobancoswwds_23_tfconbsts_sels_Count ;
      private int A355ConBCod ;
      private int AV23InsertIndex ;
      private long AV32count ;
      private string AV12TFConBDsc ;
      private string AV13TFConBDsc_Sel ;
      private string AV14TFConBCueCod ;
      private string AV15TFConBCueCod_Sel ;
      private string AV18TFConBCueDsc ;
      private string AV19TFConBCueDsc_Sel ;
      private string AV40ConBDsc1 ;
      private string AV54ConBCueCod1 ;
      private string AV45ConBDsc2 ;
      private string AV55ConBCueCod2 ;
      private string AV50ConBDsc3 ;
      private string AV56ConBCueCod3 ;
      private string AV63Bancos_conceptobancoswwds_3_conbdsc1 ;
      private string AV64Bancos_conceptobancoswwds_4_conbcuecod1 ;
      private string AV68Bancos_conceptobancoswwds_8_conbdsc2 ;
      private string AV69Bancos_conceptobancoswwds_9_conbcuecod2 ;
      private string AV73Bancos_conceptobancoswwds_13_conbdsc3 ;
      private string AV74Bancos_conceptobancoswwds_14_conbcuecod3 ;
      private string AV77Bancos_conceptobancoswwds_17_tfconbdsc ;
      private string AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel ;
      private string AV79Bancos_conceptobancoswwds_19_tfconbcuecod ;
      private string AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel ;
      private string AV81Bancos_conceptobancoswwds_21_tfconbcuedsc ;
      private string AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel ;
      private string scmdbuf ;
      private string lV63Bancos_conceptobancoswwds_3_conbdsc1 ;
      private string lV64Bancos_conceptobancoswwds_4_conbcuecod1 ;
      private string lV68Bancos_conceptobancoswwds_8_conbdsc2 ;
      private string lV69Bancos_conceptobancoswwds_9_conbcuecod2 ;
      private string lV73Bancos_conceptobancoswwds_13_conbdsc3 ;
      private string lV74Bancos_conceptobancoswwds_14_conbcuecod3 ;
      private string lV77Bancos_conceptobancoswwds_17_tfconbdsc ;
      private string lV79Bancos_conceptobancoswwds_19_tfconbcuecod ;
      private string lV81Bancos_conceptobancoswwds_21_tfconbcuedsc ;
      private string A745ConBDsc ;
      private string A374ConBCueCod ;
      private string A744ConBCueDsc ;
      private bool returnInSub ;
      private bool AV42DynamicFiltersEnabled2 ;
      private bool AV47DynamicFiltersEnabled3 ;
      private bool AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 ;
      private bool AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 ;
      private bool BRK5G2 ;
      private bool BRK5G4 ;
      private bool BRK5G6 ;
      private string AV26OptionsJson ;
      private string AV29OptionsDescJson ;
      private string AV31OptionIndexesJson ;
      private string AV52TFConBSts_SelsJson ;
      private string AV22DDOName ;
      private string AV20SearchTxt ;
      private string AV21SearchTxtTo ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV43DynamicFiltersSelector2 ;
      private string AV48DynamicFiltersSelector3 ;
      private string AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1 ;
      private string AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2 ;
      private string AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3 ;
      private string AV24Option ;
      private GxSimpleCollection<short> AV53TFConBSts_Sels ;
      private GxSimpleCollection<short> AV83Bancos_conceptobancoswwds_23_tfconbsts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005G2_A745ConBDsc ;
      private short[] P005G2_A746ConBSts ;
      private string[] P005G2_A744ConBCueDsc ;
      private int[] P005G2_A355ConBCod ;
      private string[] P005G2_A374ConBCueCod ;
      private string[] P005G3_A374ConBCueCod ;
      private short[] P005G3_A746ConBSts ;
      private string[] P005G3_A744ConBCueDsc ;
      private int[] P005G3_A355ConBCod ;
      private string[] P005G3_A745ConBDsc ;
      private string[] P005G4_A374ConBCueCod ;
      private short[] P005G4_A746ConBSts ;
      private string[] P005G4_A744ConBCueDsc ;
      private int[] P005G4_A355ConBCod ;
      private string[] P005G4_A745ConBDsc ;
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

   public class conceptobancoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005G2( IGxContext context ,
                                             short A746ConBSts ,
                                             GxSimpleCollection<short> AV83Bancos_conceptobancoswwds_23_tfconbsts_sels ,
                                             string AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1 ,
                                             short AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV63Bancos_conceptobancoswwds_3_conbdsc1 ,
                                             string AV64Bancos_conceptobancoswwds_4_conbcuecod1 ,
                                             bool AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 ,
                                             string AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2 ,
                                             short AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 ,
                                             string AV68Bancos_conceptobancoswwds_8_conbdsc2 ,
                                             string AV69Bancos_conceptobancoswwds_9_conbcuecod2 ,
                                             bool AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 ,
                                             string AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3 ,
                                             short AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 ,
                                             string AV73Bancos_conceptobancoswwds_13_conbdsc3 ,
                                             string AV74Bancos_conceptobancoswwds_14_conbcuecod3 ,
                                             int AV75Bancos_conceptobancoswwds_15_tfconbcod ,
                                             int AV76Bancos_conceptobancoswwds_16_tfconbcod_to ,
                                             string AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel ,
                                             string AV77Bancos_conceptobancoswwds_17_tfconbdsc ,
                                             string AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel ,
                                             string AV79Bancos_conceptobancoswwds_19_tfconbcuecod ,
                                             string AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel ,
                                             string AV81Bancos_conceptobancoswwds_21_tfconbcuedsc ,
                                             int AV83Bancos_conceptobancoswwds_23_tfconbsts_sels_Count ,
                                             string A745ConBDsc ,
                                             string A374ConBCueCod ,
                                             int A355ConBCod ,
                                             string A744ConBCueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ConBDsc], T1.[ConBSts], T2.[CueDsc] AS ConBCueDsc, T1.[ConBCod], T1.[ConBCueCod] AS ConBCueCod FROM ([TSCONCEPTOBANCOS] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[ConBCueCod])";
         if ( ( StringUtil.StrCmp(AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBDSC") == 0 ) && ( AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_conceptobancoswwds_3_conbdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV63Bancos_conceptobancoswwds_3_conbdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBDSC") == 0 ) && ( AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_conceptobancoswwds_3_conbdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like '%' + @lV63Bancos_conceptobancoswwds_3_conbdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBCUECOD") == 0 ) && ( AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptobancoswwds_4_conbcuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV64Bancos_conceptobancoswwds_4_conbcuecod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBCUECOD") == 0 ) && ( AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptobancoswwds_4_conbcuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like '%' + @lV64Bancos_conceptobancoswwds_4_conbcuecod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBDSC") == 0 ) && ( AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_conceptobancoswwds_8_conbdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV68Bancos_conceptobancoswwds_8_conbdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBDSC") == 0 ) && ( AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_conceptobancoswwds_8_conbdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like '%' + @lV68Bancos_conceptobancoswwds_8_conbdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBCUECOD") == 0 ) && ( AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptobancoswwds_9_conbcuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV69Bancos_conceptobancoswwds_9_conbcuecod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBCUECOD") == 0 ) && ( AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptobancoswwds_9_conbcuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like '%' + @lV69Bancos_conceptobancoswwds_9_conbcuecod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBDSC") == 0 ) && ( AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptobancoswwds_13_conbdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV73Bancos_conceptobancoswwds_13_conbdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBDSC") == 0 ) && ( AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptobancoswwds_13_conbdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like '%' + @lV73Bancos_conceptobancoswwds_13_conbdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBCUECOD") == 0 ) && ( AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptobancoswwds_14_conbcuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV74Bancos_conceptobancoswwds_14_conbcuecod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBCUECOD") == 0 ) && ( AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptobancoswwds_14_conbcuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like '%' + @lV74Bancos_conceptobancoswwds_14_conbcuecod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV75Bancos_conceptobancoswwds_15_tfconbcod) )
         {
            AddWhere(sWhereString, "(T1.[ConBCod] >= @AV75Bancos_conceptobancoswwds_15_tfconbcod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV76Bancos_conceptobancoswwds_16_tfconbcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConBCod] <= @AV76Bancos_conceptobancoswwds_16_tfconbcod_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptobancoswwds_17_tfconbdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV77Bancos_conceptobancoswwds_17_tfconbdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] = @AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_conceptobancoswwds_19_tfconbcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV79Bancos_conceptobancoswwds_19_tfconbcuecod)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] = @AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Bancos_conceptobancoswwds_21_tfconbcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV81Bancos_conceptobancoswwds_21_tfconbcuedsc)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV83Bancos_conceptobancoswwds_23_tfconbsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Bancos_conceptobancoswwds_23_tfconbsts_sels, "T1.[ConBSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ConBDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005G3( IGxContext context ,
                                             short A746ConBSts ,
                                             GxSimpleCollection<short> AV83Bancos_conceptobancoswwds_23_tfconbsts_sels ,
                                             string AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1 ,
                                             short AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV63Bancos_conceptobancoswwds_3_conbdsc1 ,
                                             string AV64Bancos_conceptobancoswwds_4_conbcuecod1 ,
                                             bool AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 ,
                                             string AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2 ,
                                             short AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 ,
                                             string AV68Bancos_conceptobancoswwds_8_conbdsc2 ,
                                             string AV69Bancos_conceptobancoswwds_9_conbcuecod2 ,
                                             bool AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 ,
                                             string AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3 ,
                                             short AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 ,
                                             string AV73Bancos_conceptobancoswwds_13_conbdsc3 ,
                                             string AV74Bancos_conceptobancoswwds_14_conbcuecod3 ,
                                             int AV75Bancos_conceptobancoswwds_15_tfconbcod ,
                                             int AV76Bancos_conceptobancoswwds_16_tfconbcod_to ,
                                             string AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel ,
                                             string AV77Bancos_conceptobancoswwds_17_tfconbdsc ,
                                             string AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel ,
                                             string AV79Bancos_conceptobancoswwds_19_tfconbcuecod ,
                                             string AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel ,
                                             string AV81Bancos_conceptobancoswwds_21_tfconbcuedsc ,
                                             int AV83Bancos_conceptobancoswwds_23_tfconbsts_sels_Count ,
                                             string A745ConBDsc ,
                                             string A374ConBCueCod ,
                                             int A355ConBCod ,
                                             string A744ConBCueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[ConBCueCod] AS ConBCueCod, T1.[ConBSts], T2.[CueDsc] AS ConBCueDsc, T1.[ConBCod], T1.[ConBDsc] FROM ([TSCONCEPTOBANCOS] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[ConBCueCod])";
         if ( ( StringUtil.StrCmp(AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBDSC") == 0 ) && ( AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_conceptobancoswwds_3_conbdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV63Bancos_conceptobancoswwds_3_conbdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBDSC") == 0 ) && ( AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_conceptobancoswwds_3_conbdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like '%' + @lV63Bancos_conceptobancoswwds_3_conbdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBCUECOD") == 0 ) && ( AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptobancoswwds_4_conbcuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV64Bancos_conceptobancoswwds_4_conbcuecod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBCUECOD") == 0 ) && ( AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptobancoswwds_4_conbcuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like '%' + @lV64Bancos_conceptobancoswwds_4_conbcuecod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBDSC") == 0 ) && ( AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_conceptobancoswwds_8_conbdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV68Bancos_conceptobancoswwds_8_conbdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBDSC") == 0 ) && ( AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_conceptobancoswwds_8_conbdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like '%' + @lV68Bancos_conceptobancoswwds_8_conbdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBCUECOD") == 0 ) && ( AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptobancoswwds_9_conbcuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV69Bancos_conceptobancoswwds_9_conbcuecod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBCUECOD") == 0 ) && ( AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptobancoswwds_9_conbcuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like '%' + @lV69Bancos_conceptobancoswwds_9_conbcuecod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBDSC") == 0 ) && ( AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptobancoswwds_13_conbdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV73Bancos_conceptobancoswwds_13_conbdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBDSC") == 0 ) && ( AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptobancoswwds_13_conbdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like '%' + @lV73Bancos_conceptobancoswwds_13_conbdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBCUECOD") == 0 ) && ( AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptobancoswwds_14_conbcuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV74Bancos_conceptobancoswwds_14_conbcuecod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBCUECOD") == 0 ) && ( AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptobancoswwds_14_conbcuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like '%' + @lV74Bancos_conceptobancoswwds_14_conbcuecod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV75Bancos_conceptobancoswwds_15_tfconbcod) )
         {
            AddWhere(sWhereString, "(T1.[ConBCod] >= @AV75Bancos_conceptobancoswwds_15_tfconbcod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV76Bancos_conceptobancoswwds_16_tfconbcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConBCod] <= @AV76Bancos_conceptobancoswwds_16_tfconbcod_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptobancoswwds_17_tfconbdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV77Bancos_conceptobancoswwds_17_tfconbdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] = @AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_conceptobancoswwds_19_tfconbcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV79Bancos_conceptobancoswwds_19_tfconbcuecod)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] = @AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Bancos_conceptobancoswwds_21_tfconbcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV81Bancos_conceptobancoswwds_21_tfconbcuedsc)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV83Bancos_conceptobancoswwds_23_tfconbsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Bancos_conceptobancoswwds_23_tfconbsts_sels, "T1.[ConBSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ConBCueCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P005G4( IGxContext context ,
                                             short A746ConBSts ,
                                             GxSimpleCollection<short> AV83Bancos_conceptobancoswwds_23_tfconbsts_sels ,
                                             string AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1 ,
                                             short AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV63Bancos_conceptobancoswwds_3_conbdsc1 ,
                                             string AV64Bancos_conceptobancoswwds_4_conbcuecod1 ,
                                             bool AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 ,
                                             string AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2 ,
                                             short AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 ,
                                             string AV68Bancos_conceptobancoswwds_8_conbdsc2 ,
                                             string AV69Bancos_conceptobancoswwds_9_conbcuecod2 ,
                                             bool AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 ,
                                             string AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3 ,
                                             short AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 ,
                                             string AV73Bancos_conceptobancoswwds_13_conbdsc3 ,
                                             string AV74Bancos_conceptobancoswwds_14_conbcuecod3 ,
                                             int AV75Bancos_conceptobancoswwds_15_tfconbcod ,
                                             int AV76Bancos_conceptobancoswwds_16_tfconbcod_to ,
                                             string AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel ,
                                             string AV77Bancos_conceptobancoswwds_17_tfconbdsc ,
                                             string AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel ,
                                             string AV79Bancos_conceptobancoswwds_19_tfconbcuecod ,
                                             string AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel ,
                                             string AV81Bancos_conceptobancoswwds_21_tfconbcuedsc ,
                                             int AV83Bancos_conceptobancoswwds_23_tfconbsts_sels_Count ,
                                             string A745ConBDsc ,
                                             string A374ConBCueCod ,
                                             int A355ConBCod ,
                                             string A744ConBCueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[ConBCueCod] AS ConBCueCod, T1.[ConBSts], T2.[CueDsc] AS ConBCueDsc, T1.[ConBCod], T1.[ConBDsc] FROM ([TSCONCEPTOBANCOS] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[ConBCueCod])";
         if ( ( StringUtil.StrCmp(AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBDSC") == 0 ) && ( AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_conceptobancoswwds_3_conbdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV63Bancos_conceptobancoswwds_3_conbdsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBDSC") == 0 ) && ( AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_conceptobancoswwds_3_conbdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like '%' + @lV63Bancos_conceptobancoswwds_3_conbdsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBCUECOD") == 0 ) && ( AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptobancoswwds_4_conbcuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV64Bancos_conceptobancoswwds_4_conbcuecod1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV61Bancos_conceptobancoswwds_1_dynamicfiltersselector1, "CONBCUECOD") == 0 ) && ( AV62Bancos_conceptobancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptobancoswwds_4_conbcuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like '%' + @lV64Bancos_conceptobancoswwds_4_conbcuecod1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBDSC") == 0 ) && ( AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_conceptobancoswwds_8_conbdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV68Bancos_conceptobancoswwds_8_conbdsc2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBDSC") == 0 ) && ( AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_conceptobancoswwds_8_conbdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like '%' + @lV68Bancos_conceptobancoswwds_8_conbdsc2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBCUECOD") == 0 ) && ( AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptobancoswwds_9_conbcuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV69Bancos_conceptobancoswwds_9_conbcuecod2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV65Bancos_conceptobancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Bancos_conceptobancoswwds_6_dynamicfiltersselector2, "CONBCUECOD") == 0 ) && ( AV67Bancos_conceptobancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptobancoswwds_9_conbcuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like '%' + @lV69Bancos_conceptobancoswwds_9_conbcuecod2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBDSC") == 0 ) && ( AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptobancoswwds_13_conbdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV73Bancos_conceptobancoswwds_13_conbdsc3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBDSC") == 0 ) && ( AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptobancoswwds_13_conbdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like '%' + @lV73Bancos_conceptobancoswwds_13_conbdsc3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBCUECOD") == 0 ) && ( AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptobancoswwds_14_conbcuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV74Bancos_conceptobancoswwds_14_conbcuecod3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV70Bancos_conceptobancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Bancos_conceptobancoswwds_11_dynamicfiltersselector3, "CONBCUECOD") == 0 ) && ( AV72Bancos_conceptobancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptobancoswwds_14_conbcuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like '%' + @lV74Bancos_conceptobancoswwds_14_conbcuecod3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (0==AV75Bancos_conceptobancoswwds_15_tfconbcod) )
         {
            AddWhere(sWhereString, "(T1.[ConBCod] >= @AV75Bancos_conceptobancoswwds_15_tfconbcod)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (0==AV76Bancos_conceptobancoswwds_16_tfconbcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConBCod] <= @AV76Bancos_conceptobancoswwds_16_tfconbcod_to)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptobancoswwds_17_tfconbdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] like @lV77Bancos_conceptobancoswwds_17_tfconbdsc)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConBDsc] = @AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_conceptobancoswwds_19_tfconbcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] like @lV79Bancos_conceptobancoswwds_19_tfconbcuecod)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConBCueCod] = @AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Bancos_conceptobancoswwds_21_tfconbcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV81Bancos_conceptobancoswwds_21_tfconbcuedsc)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV83Bancos_conceptobancoswwds_23_tfconbsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Bancos_conceptobancoswwds_23_tfconbsts_sels, "T1.[ConBSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ConBCueCod]";
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
                     return conditional_P005G2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
               case 1 :
                     return conditional_P005G3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
               case 2 :
                     return conditional_P005G4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP005G2;
          prmP005G2 = new Object[] {
          new ParDef("@lV63Bancos_conceptobancoswwds_3_conbdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV63Bancos_conceptobancoswwds_3_conbdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV64Bancos_conceptobancoswwds_4_conbcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV64Bancos_conceptobancoswwds_4_conbcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV68Bancos_conceptobancoswwds_8_conbdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Bancos_conceptobancoswwds_8_conbdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV69Bancos_conceptobancoswwds_9_conbcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV69Bancos_conceptobancoswwds_9_conbcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV73Bancos_conceptobancoswwds_13_conbdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV73Bancos_conceptobancoswwds_13_conbdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV74Bancos_conceptobancoswwds_14_conbcuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV74Bancos_conceptobancoswwds_14_conbcuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV75Bancos_conceptobancoswwds_15_tfconbcod",GXType.Int32,6,0) ,
          new ParDef("@AV76Bancos_conceptobancoswwds_16_tfconbcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV77Bancos_conceptobancoswwds_17_tfconbdsc",GXType.NChar,100,0) ,
          new ParDef("@AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV79Bancos_conceptobancoswwds_19_tfconbcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV81Bancos_conceptobancoswwds_21_tfconbcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP005G3;
          prmP005G3 = new Object[] {
          new ParDef("@lV63Bancos_conceptobancoswwds_3_conbdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV63Bancos_conceptobancoswwds_3_conbdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV64Bancos_conceptobancoswwds_4_conbcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV64Bancos_conceptobancoswwds_4_conbcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV68Bancos_conceptobancoswwds_8_conbdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Bancos_conceptobancoswwds_8_conbdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV69Bancos_conceptobancoswwds_9_conbcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV69Bancos_conceptobancoswwds_9_conbcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV73Bancos_conceptobancoswwds_13_conbdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV73Bancos_conceptobancoswwds_13_conbdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV74Bancos_conceptobancoswwds_14_conbcuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV74Bancos_conceptobancoswwds_14_conbcuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV75Bancos_conceptobancoswwds_15_tfconbcod",GXType.Int32,6,0) ,
          new ParDef("@AV76Bancos_conceptobancoswwds_16_tfconbcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV77Bancos_conceptobancoswwds_17_tfconbdsc",GXType.NChar,100,0) ,
          new ParDef("@AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV79Bancos_conceptobancoswwds_19_tfconbcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV81Bancos_conceptobancoswwds_21_tfconbcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP005G4;
          prmP005G4 = new Object[] {
          new ParDef("@lV63Bancos_conceptobancoswwds_3_conbdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV63Bancos_conceptobancoswwds_3_conbdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV64Bancos_conceptobancoswwds_4_conbcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV64Bancos_conceptobancoswwds_4_conbcuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV68Bancos_conceptobancoswwds_8_conbdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Bancos_conceptobancoswwds_8_conbdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV69Bancos_conceptobancoswwds_9_conbcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV69Bancos_conceptobancoswwds_9_conbcuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV73Bancos_conceptobancoswwds_13_conbdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV73Bancos_conceptobancoswwds_13_conbdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV74Bancos_conceptobancoswwds_14_conbcuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV74Bancos_conceptobancoswwds_14_conbcuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV75Bancos_conceptobancoswwds_15_tfconbcod",GXType.Int32,6,0) ,
          new ParDef("@AV76Bancos_conceptobancoswwds_16_tfconbcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV77Bancos_conceptobancoswwds_17_tfconbdsc",GXType.NChar,100,0) ,
          new ParDef("@AV78Bancos_conceptobancoswwds_18_tfconbdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV79Bancos_conceptobancoswwds_19_tfconbcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV80Bancos_conceptobancoswwds_20_tfconbcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV81Bancos_conceptobancoswwds_21_tfconbcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV82Bancos_conceptobancoswwds_22_tfconbcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005G2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005G3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005G3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005G4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005G4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 15);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
