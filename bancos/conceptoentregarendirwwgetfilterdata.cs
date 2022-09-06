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
   public class conceptoentregarendirwwgetfilterdata : GXProcedure
   {
      public conceptoentregarendirwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptoentregarendirwwgetfilterdata( IGxContext context )
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
         conceptoentregarendirwwgetfilterdata objconceptoentregarendirwwgetfilterdata;
         objconceptoentregarendirwwgetfilterdata = new conceptoentregarendirwwgetfilterdata();
         objconceptoentregarendirwwgetfilterdata.AV22DDOName = aP0_DDOName;
         objconceptoentregarendirwwgetfilterdata.AV20SearchTxt = aP1_SearchTxt;
         objconceptoentregarendirwwgetfilterdata.AV21SearchTxtTo = aP2_SearchTxtTo;
         objconceptoentregarendirwwgetfilterdata.AV26OptionsJson = "" ;
         objconceptoentregarendirwwgetfilterdata.AV29OptionsDescJson = "" ;
         objconceptoentregarendirwwgetfilterdata.AV31OptionIndexesJson = "" ;
         objconceptoentregarendirwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objconceptoentregarendirwwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptoentregarendirwwgetfilterdata);
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptoentregarendirwwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_CONENTDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCONENTDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_CUECOD") == 0 )
         {
            /* Execute user subroutine: 'LOADCUECODOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_CUEDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCUEDSCOPTIONS' */
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
         if ( StringUtil.StrCmp(AV33Session.Get("Bancos.ConceptoEntregaRendirWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.ConceptoEntregaRendirWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Bancos.ConceptoEntregaRendirWWGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONENTCOD") == 0 )
            {
               AV10TFConEntCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV11TFConEntCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONENTDSC") == 0 )
            {
               AV12TFConEntDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONENTDSC_SEL") == 0 )
            {
               AV13TFConEntDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV14TFCueCod = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV15TFCueCod_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV16TFCueDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV17TFCueDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONENTSTS_SEL") == 0 )
            {
               AV52TFConEntSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV53TFConEntSts_Sels.FromJSonString(AV52TFConEntSts_SelsJson, null);
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "CONENTDSC") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV40ConEntDsc1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "CUECOD") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV49CueCod1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "CONENTDSC") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV44ConEntDsc2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "CUECOD") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV50CueCod2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "CONENTDSC") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV48ConEntDsc3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "CUECOD") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV51CueCod3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCONENTDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFConEntDsc = AV20SearchTxt;
         AV13TFConEntDsc_Sel = "";
         AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV60Bancos_conceptoentregarendirwwds_3_conentdsc1 = AV40ConEntDsc1;
         AV61Bancos_conceptoentregarendirwwds_4_cuecod1 = AV49CueCod1;
         AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV65Bancos_conceptoentregarendirwwds_8_conentdsc2 = AV44ConEntDsc2;
         AV66Bancos_conceptoentregarendirwwds_9_cuecod2 = AV50CueCod2;
         AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV70Bancos_conceptoentregarendirwwds_13_conentdsc3 = AV48ConEntDsc3;
         AV71Bancos_conceptoentregarendirwwds_14_cuecod3 = AV51CueCod3;
         AV72Bancos_conceptoentregarendirwwds_15_tfconentcod = AV10TFConEntCod;
         AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to = AV11TFConEntCod_To;
         AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc = AV12TFConEntDsc;
         AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = AV13TFConEntDsc_Sel;
         AV76Bancos_conceptoentregarendirwwds_19_tfcuecod = AV14TFCueCod;
         AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = AV15TFCueCod_Sel;
         AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc = AV16TFCueDsc;
         AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = AV17TFCueDsc_Sel;
         AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = AV53TFConEntSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A750ConEntSts ,
                                              AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ,
                                              AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ,
                                              AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ,
                                              AV60Bancos_conceptoentregarendirwwds_3_conentdsc1 ,
                                              AV61Bancos_conceptoentregarendirwwds_4_cuecod1 ,
                                              AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ,
                                              AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ,
                                              AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ,
                                              AV65Bancos_conceptoentregarendirwwds_8_conentdsc2 ,
                                              AV66Bancos_conceptoentregarendirwwds_9_cuecod2 ,
                                              AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ,
                                              AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ,
                                              AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ,
                                              AV70Bancos_conceptoentregarendirwwds_13_conentdsc3 ,
                                              AV71Bancos_conceptoentregarendirwwds_14_cuecod3 ,
                                              AV72Bancos_conceptoentregarendirwwds_15_tfconentcod ,
                                              AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to ,
                                              AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ,
                                              AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc ,
                                              AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ,
                                              AV76Bancos_conceptoentregarendirwwds_19_tfcuecod ,
                                              AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ,
                                              AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc ,
                                              AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels.Count ,
                                              A749ConEntDsc ,
                                              A91CueCod ,
                                              A376ConEntCod ,
                                              A860CueDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV60Bancos_conceptoentregarendirwwds_3_conentdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_3_conentdsc1), 100, "%");
         lV60Bancos_conceptoentregarendirwwds_3_conentdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_3_conentdsc1), 100, "%");
         lV61Bancos_conceptoentregarendirwwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_conceptoentregarendirwwds_4_cuecod1), 15, "%");
         lV61Bancos_conceptoentregarendirwwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_conceptoentregarendirwwds_4_cuecod1), 15, "%");
         lV65Bancos_conceptoentregarendirwwds_8_conentdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_8_conentdsc2), 100, "%");
         lV65Bancos_conceptoentregarendirwwds_8_conentdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_8_conentdsc2), 100, "%");
         lV66Bancos_conceptoentregarendirwwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_conceptoentregarendirwwds_9_cuecod2), 15, "%");
         lV66Bancos_conceptoentregarendirwwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_conceptoentregarendirwwds_9_cuecod2), 15, "%");
         lV70Bancos_conceptoentregarendirwwds_13_conentdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_13_conentdsc3), 100, "%");
         lV70Bancos_conceptoentregarendirwwds_13_conentdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_13_conentdsc3), 100, "%");
         lV71Bancos_conceptoentregarendirwwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_conceptoentregarendirwwds_14_cuecod3), 15, "%");
         lV71Bancos_conceptoentregarendirwwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_conceptoentregarendirwwds_14_cuecod3), 15, "%");
         lV74Bancos_conceptoentregarendirwwds_17_tfconentdsc = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc), 100, "%");
         lV76Bancos_conceptoentregarendirwwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_conceptoentregarendirwwds_19_tfcuecod), 15, "%");
         lV78Bancos_conceptoentregarendirwwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005W2 */
         pr_default.execute(0, new Object[] {lV60Bancos_conceptoentregarendirwwds_3_conentdsc1, lV60Bancos_conceptoentregarendirwwds_3_conentdsc1, lV61Bancos_conceptoentregarendirwwds_4_cuecod1, lV61Bancos_conceptoentregarendirwwds_4_cuecod1, lV65Bancos_conceptoentregarendirwwds_8_conentdsc2, lV65Bancos_conceptoentregarendirwwds_8_conentdsc2, lV66Bancos_conceptoentregarendirwwds_9_cuecod2, lV66Bancos_conceptoentregarendirwwds_9_cuecod2, lV70Bancos_conceptoentregarendirwwds_13_conentdsc3, lV70Bancos_conceptoentregarendirwwds_13_conentdsc3, lV71Bancos_conceptoentregarendirwwds_14_cuecod3, lV71Bancos_conceptoentregarendirwwds_14_cuecod3, AV72Bancos_conceptoentregarendirwwds_15_tfconentcod, AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to, lV74Bancos_conceptoentregarendirwwds_17_tfconentdsc, AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel, lV76Bancos_conceptoentregarendirwwds_19_tfcuecod, AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel, lV78Bancos_conceptoentregarendirwwds_21_tfcuedsc, AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5W2 = false;
            A749ConEntDsc = P005W2_A749ConEntDsc[0];
            A750ConEntSts = P005W2_A750ConEntSts[0];
            A860CueDsc = P005W2_A860CueDsc[0];
            A376ConEntCod = P005W2_A376ConEntCod[0];
            A91CueCod = P005W2_A91CueCod[0];
            A860CueDsc = P005W2_A860CueDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005W2_A749ConEntDsc[0], A749ConEntDsc) == 0 ) )
            {
               BRK5W2 = false;
               A376ConEntCod = P005W2_A376ConEntCod[0];
               AV32count = (long)(AV32count+1);
               BRK5W2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A749ConEntDsc)) )
            {
               AV24Option = A749ConEntDsc;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK5W2 )
            {
               BRK5W2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCUECODOPTIONS' Routine */
         returnInSub = false;
         AV14TFCueCod = AV20SearchTxt;
         AV15TFCueCod_Sel = "";
         AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV60Bancos_conceptoentregarendirwwds_3_conentdsc1 = AV40ConEntDsc1;
         AV61Bancos_conceptoentregarendirwwds_4_cuecod1 = AV49CueCod1;
         AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV65Bancos_conceptoentregarendirwwds_8_conentdsc2 = AV44ConEntDsc2;
         AV66Bancos_conceptoentregarendirwwds_9_cuecod2 = AV50CueCod2;
         AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV70Bancos_conceptoentregarendirwwds_13_conentdsc3 = AV48ConEntDsc3;
         AV71Bancos_conceptoentregarendirwwds_14_cuecod3 = AV51CueCod3;
         AV72Bancos_conceptoentregarendirwwds_15_tfconentcod = AV10TFConEntCod;
         AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to = AV11TFConEntCod_To;
         AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc = AV12TFConEntDsc;
         AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = AV13TFConEntDsc_Sel;
         AV76Bancos_conceptoentregarendirwwds_19_tfcuecod = AV14TFCueCod;
         AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = AV15TFCueCod_Sel;
         AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc = AV16TFCueDsc;
         AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = AV17TFCueDsc_Sel;
         AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = AV53TFConEntSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A750ConEntSts ,
                                              AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ,
                                              AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ,
                                              AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ,
                                              AV60Bancos_conceptoentregarendirwwds_3_conentdsc1 ,
                                              AV61Bancos_conceptoentregarendirwwds_4_cuecod1 ,
                                              AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ,
                                              AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ,
                                              AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ,
                                              AV65Bancos_conceptoentregarendirwwds_8_conentdsc2 ,
                                              AV66Bancos_conceptoentregarendirwwds_9_cuecod2 ,
                                              AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ,
                                              AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ,
                                              AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ,
                                              AV70Bancos_conceptoentregarendirwwds_13_conentdsc3 ,
                                              AV71Bancos_conceptoentregarendirwwds_14_cuecod3 ,
                                              AV72Bancos_conceptoentregarendirwwds_15_tfconentcod ,
                                              AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to ,
                                              AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ,
                                              AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc ,
                                              AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ,
                                              AV76Bancos_conceptoentregarendirwwds_19_tfcuecod ,
                                              AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ,
                                              AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc ,
                                              AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels.Count ,
                                              A749ConEntDsc ,
                                              A91CueCod ,
                                              A376ConEntCod ,
                                              A860CueDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV60Bancos_conceptoentregarendirwwds_3_conentdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_3_conentdsc1), 100, "%");
         lV60Bancos_conceptoentregarendirwwds_3_conentdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_3_conentdsc1), 100, "%");
         lV61Bancos_conceptoentregarendirwwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_conceptoentregarendirwwds_4_cuecod1), 15, "%");
         lV61Bancos_conceptoentregarendirwwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_conceptoentregarendirwwds_4_cuecod1), 15, "%");
         lV65Bancos_conceptoentregarendirwwds_8_conentdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_8_conentdsc2), 100, "%");
         lV65Bancos_conceptoentregarendirwwds_8_conentdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_8_conentdsc2), 100, "%");
         lV66Bancos_conceptoentregarendirwwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_conceptoentregarendirwwds_9_cuecod2), 15, "%");
         lV66Bancos_conceptoentregarendirwwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_conceptoentregarendirwwds_9_cuecod2), 15, "%");
         lV70Bancos_conceptoentregarendirwwds_13_conentdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_13_conentdsc3), 100, "%");
         lV70Bancos_conceptoentregarendirwwds_13_conentdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_13_conentdsc3), 100, "%");
         lV71Bancos_conceptoentregarendirwwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_conceptoentregarendirwwds_14_cuecod3), 15, "%");
         lV71Bancos_conceptoentregarendirwwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_conceptoentregarendirwwds_14_cuecod3), 15, "%");
         lV74Bancos_conceptoentregarendirwwds_17_tfconentdsc = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc), 100, "%");
         lV76Bancos_conceptoentregarendirwwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_conceptoentregarendirwwds_19_tfcuecod), 15, "%");
         lV78Bancos_conceptoentregarendirwwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005W3 */
         pr_default.execute(1, new Object[] {lV60Bancos_conceptoentregarendirwwds_3_conentdsc1, lV60Bancos_conceptoentregarendirwwds_3_conentdsc1, lV61Bancos_conceptoentregarendirwwds_4_cuecod1, lV61Bancos_conceptoentregarendirwwds_4_cuecod1, lV65Bancos_conceptoentregarendirwwds_8_conentdsc2, lV65Bancos_conceptoentregarendirwwds_8_conentdsc2, lV66Bancos_conceptoentregarendirwwds_9_cuecod2, lV66Bancos_conceptoentregarendirwwds_9_cuecod2, lV70Bancos_conceptoentregarendirwwds_13_conentdsc3, lV70Bancos_conceptoentregarendirwwds_13_conentdsc3, lV71Bancos_conceptoentregarendirwwds_14_cuecod3, lV71Bancos_conceptoentregarendirwwds_14_cuecod3, AV72Bancos_conceptoentregarendirwwds_15_tfconentcod, AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to, lV74Bancos_conceptoentregarendirwwds_17_tfconentdsc, AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel, lV76Bancos_conceptoentregarendirwwds_19_tfcuecod, AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel, lV78Bancos_conceptoentregarendirwwds_21_tfcuedsc, AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5W4 = false;
            A91CueCod = P005W3_A91CueCod[0];
            A750ConEntSts = P005W3_A750ConEntSts[0];
            A860CueDsc = P005W3_A860CueDsc[0];
            A376ConEntCod = P005W3_A376ConEntCod[0];
            A749ConEntDsc = P005W3_A749ConEntDsc[0];
            A860CueDsc = P005W3_A860CueDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005W3_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRK5W4 = false;
               A376ConEntCod = P005W3_A376ConEntCod[0];
               AV32count = (long)(AV32count+1);
               BRK5W4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A91CueCod)) )
            {
               AV24Option = A91CueCod;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK5W4 )
            {
               BRK5W4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCUEDSCOPTIONS' Routine */
         returnInSub = false;
         AV16TFCueDsc = AV20SearchTxt;
         AV17TFCueDsc_Sel = "";
         AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV60Bancos_conceptoentregarendirwwds_3_conentdsc1 = AV40ConEntDsc1;
         AV61Bancos_conceptoentregarendirwwds_4_cuecod1 = AV49CueCod1;
         AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV65Bancos_conceptoentregarendirwwds_8_conentdsc2 = AV44ConEntDsc2;
         AV66Bancos_conceptoentregarendirwwds_9_cuecod2 = AV50CueCod2;
         AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV70Bancos_conceptoentregarendirwwds_13_conentdsc3 = AV48ConEntDsc3;
         AV71Bancos_conceptoentregarendirwwds_14_cuecod3 = AV51CueCod3;
         AV72Bancos_conceptoentregarendirwwds_15_tfconentcod = AV10TFConEntCod;
         AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to = AV11TFConEntCod_To;
         AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc = AV12TFConEntDsc;
         AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = AV13TFConEntDsc_Sel;
         AV76Bancos_conceptoentregarendirwwds_19_tfcuecod = AV14TFCueCod;
         AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = AV15TFCueCod_Sel;
         AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc = AV16TFCueDsc;
         AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = AV17TFCueDsc_Sel;
         AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = AV53TFConEntSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A750ConEntSts ,
                                              AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ,
                                              AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ,
                                              AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ,
                                              AV60Bancos_conceptoentregarendirwwds_3_conentdsc1 ,
                                              AV61Bancos_conceptoentregarendirwwds_4_cuecod1 ,
                                              AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ,
                                              AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ,
                                              AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ,
                                              AV65Bancos_conceptoentregarendirwwds_8_conentdsc2 ,
                                              AV66Bancos_conceptoentregarendirwwds_9_cuecod2 ,
                                              AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ,
                                              AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ,
                                              AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ,
                                              AV70Bancos_conceptoentregarendirwwds_13_conentdsc3 ,
                                              AV71Bancos_conceptoentregarendirwwds_14_cuecod3 ,
                                              AV72Bancos_conceptoentregarendirwwds_15_tfconentcod ,
                                              AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to ,
                                              AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ,
                                              AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc ,
                                              AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ,
                                              AV76Bancos_conceptoentregarendirwwds_19_tfcuecod ,
                                              AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ,
                                              AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc ,
                                              AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels.Count ,
                                              A749ConEntDsc ,
                                              A91CueCod ,
                                              A376ConEntCod ,
                                              A860CueDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV60Bancos_conceptoentregarendirwwds_3_conentdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_3_conentdsc1), 100, "%");
         lV60Bancos_conceptoentregarendirwwds_3_conentdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_3_conentdsc1), 100, "%");
         lV61Bancos_conceptoentregarendirwwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_conceptoentregarendirwwds_4_cuecod1), 15, "%");
         lV61Bancos_conceptoentregarendirwwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_conceptoentregarendirwwds_4_cuecod1), 15, "%");
         lV65Bancos_conceptoentregarendirwwds_8_conentdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_8_conentdsc2), 100, "%");
         lV65Bancos_conceptoentregarendirwwds_8_conentdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_8_conentdsc2), 100, "%");
         lV66Bancos_conceptoentregarendirwwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_conceptoentregarendirwwds_9_cuecod2), 15, "%");
         lV66Bancos_conceptoentregarendirwwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_conceptoentregarendirwwds_9_cuecod2), 15, "%");
         lV70Bancos_conceptoentregarendirwwds_13_conentdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_13_conentdsc3), 100, "%");
         lV70Bancos_conceptoentregarendirwwds_13_conentdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_13_conentdsc3), 100, "%");
         lV71Bancos_conceptoentregarendirwwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_conceptoentregarendirwwds_14_cuecod3), 15, "%");
         lV71Bancos_conceptoentregarendirwwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_conceptoentregarendirwwds_14_cuecod3), 15, "%");
         lV74Bancos_conceptoentregarendirwwds_17_tfconentdsc = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc), 100, "%");
         lV76Bancos_conceptoentregarendirwwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_conceptoentregarendirwwds_19_tfcuecod), 15, "%");
         lV78Bancos_conceptoentregarendirwwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005W4 */
         pr_default.execute(2, new Object[] {lV60Bancos_conceptoentregarendirwwds_3_conentdsc1, lV60Bancos_conceptoentregarendirwwds_3_conentdsc1, lV61Bancos_conceptoentregarendirwwds_4_cuecod1, lV61Bancos_conceptoentregarendirwwds_4_cuecod1, lV65Bancos_conceptoentregarendirwwds_8_conentdsc2, lV65Bancos_conceptoentregarendirwwds_8_conentdsc2, lV66Bancos_conceptoentregarendirwwds_9_cuecod2, lV66Bancos_conceptoentregarendirwwds_9_cuecod2, lV70Bancos_conceptoentregarendirwwds_13_conentdsc3, lV70Bancos_conceptoentregarendirwwds_13_conentdsc3, lV71Bancos_conceptoentregarendirwwds_14_cuecod3, lV71Bancos_conceptoentregarendirwwds_14_cuecod3, AV72Bancos_conceptoentregarendirwwds_15_tfconentcod, AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to, lV74Bancos_conceptoentregarendirwwds_17_tfconentdsc, AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel, lV76Bancos_conceptoentregarendirwwds_19_tfcuecod, AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel, lV78Bancos_conceptoentregarendirwwds_21_tfcuedsc, AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5W6 = false;
            A860CueDsc = P005W4_A860CueDsc[0];
            A750ConEntSts = P005W4_A750ConEntSts[0];
            A376ConEntCod = P005W4_A376ConEntCod[0];
            A91CueCod = P005W4_A91CueCod[0];
            A749ConEntDsc = P005W4_A749ConEntDsc[0];
            A860CueDsc = P005W4_A860CueDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005W4_A860CueDsc[0], A860CueDsc) == 0 ) )
            {
               BRK5W6 = false;
               A376ConEntCod = P005W4_A376ConEntCod[0];
               A91CueCod = P005W4_A91CueCod[0];
               AV32count = (long)(AV32count+1);
               BRK5W6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A860CueDsc)) )
            {
               AV24Option = A860CueDsc;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK5W6 )
            {
               BRK5W6 = true;
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
         AV12TFConEntDsc = "";
         AV13TFConEntDsc_Sel = "";
         AV14TFCueCod = "";
         AV15TFCueCod_Sel = "";
         AV16TFCueDsc = "";
         AV17TFCueDsc_Sel = "";
         AV52TFConEntSts_SelsJson = "";
         AV53TFConEntSts_Sels = new GxSimpleCollection<short>();
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40ConEntDsc1 = "";
         AV49CueCod1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44ConEntDsc2 = "";
         AV50CueCod2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48ConEntDsc3 = "";
         AV51CueCod3 = "";
         AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 = "";
         AV60Bancos_conceptoentregarendirwwds_3_conentdsc1 = "";
         AV61Bancos_conceptoentregarendirwwds_4_cuecod1 = "";
         AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 = "";
         AV65Bancos_conceptoentregarendirwwds_8_conentdsc2 = "";
         AV66Bancos_conceptoentregarendirwwds_9_cuecod2 = "";
         AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 = "";
         AV70Bancos_conceptoentregarendirwwds_13_conentdsc3 = "";
         AV71Bancos_conceptoentregarendirwwds_14_cuecod3 = "";
         AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc = "";
         AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel = "";
         AV76Bancos_conceptoentregarendirwwds_19_tfcuecod = "";
         AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel = "";
         AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc = "";
         AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel = "";
         AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV60Bancos_conceptoentregarendirwwds_3_conentdsc1 = "";
         lV61Bancos_conceptoentregarendirwwds_4_cuecod1 = "";
         lV65Bancos_conceptoentregarendirwwds_8_conentdsc2 = "";
         lV66Bancos_conceptoentregarendirwwds_9_cuecod2 = "";
         lV70Bancos_conceptoentregarendirwwds_13_conentdsc3 = "";
         lV71Bancos_conceptoentregarendirwwds_14_cuecod3 = "";
         lV74Bancos_conceptoentregarendirwwds_17_tfconentdsc = "";
         lV76Bancos_conceptoentregarendirwwds_19_tfcuecod = "";
         lV78Bancos_conceptoentregarendirwwds_21_tfcuedsc = "";
         A749ConEntDsc = "";
         A91CueCod = "";
         A860CueDsc = "";
         P005W2_A749ConEntDsc = new string[] {""} ;
         P005W2_A750ConEntSts = new short[1] ;
         P005W2_A860CueDsc = new string[] {""} ;
         P005W2_A376ConEntCod = new int[1] ;
         P005W2_A91CueCod = new string[] {""} ;
         AV24Option = "";
         P005W3_A91CueCod = new string[] {""} ;
         P005W3_A750ConEntSts = new short[1] ;
         P005W3_A860CueDsc = new string[] {""} ;
         P005W3_A376ConEntCod = new int[1] ;
         P005W3_A749ConEntDsc = new string[] {""} ;
         P005W4_A860CueDsc = new string[] {""} ;
         P005W4_A750ConEntSts = new short[1] ;
         P005W4_A376ConEntCod = new int[1] ;
         P005W4_A91CueCod = new string[] {""} ;
         P005W4_A749ConEntDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.conceptoentregarendirwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005W2_A749ConEntDsc, P005W2_A750ConEntSts, P005W2_A860CueDsc, P005W2_A376ConEntCod, P005W2_A91CueCod
               }
               , new Object[] {
               P005W3_A91CueCod, P005W3_A750ConEntSts, P005W3_A860CueDsc, P005W3_A376ConEntCod, P005W3_A749ConEntDsc
               }
               , new Object[] {
               P005W4_A860CueDsc, P005W4_A750ConEntSts, P005W4_A376ConEntCod, P005W4_A91CueCod, P005W4_A749ConEntDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ;
      private short AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ;
      private short AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ;
      private short A750ConEntSts ;
      private int AV56GXV1 ;
      private int AV10TFConEntCod ;
      private int AV11TFConEntCod_To ;
      private int AV72Bancos_conceptoentregarendirwwds_15_tfconentcod ;
      private int AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to ;
      private int AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count ;
      private int A376ConEntCod ;
      private long AV32count ;
      private string AV12TFConEntDsc ;
      private string AV13TFConEntDsc_Sel ;
      private string AV14TFCueCod ;
      private string AV15TFCueCod_Sel ;
      private string AV16TFCueDsc ;
      private string AV17TFCueDsc_Sel ;
      private string AV40ConEntDsc1 ;
      private string AV49CueCod1 ;
      private string AV44ConEntDsc2 ;
      private string AV50CueCod2 ;
      private string AV48ConEntDsc3 ;
      private string AV51CueCod3 ;
      private string AV60Bancos_conceptoentregarendirwwds_3_conentdsc1 ;
      private string AV61Bancos_conceptoentregarendirwwds_4_cuecod1 ;
      private string AV65Bancos_conceptoentregarendirwwds_8_conentdsc2 ;
      private string AV66Bancos_conceptoentregarendirwwds_9_cuecod2 ;
      private string AV70Bancos_conceptoentregarendirwwds_13_conentdsc3 ;
      private string AV71Bancos_conceptoentregarendirwwds_14_cuecod3 ;
      private string AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc ;
      private string AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ;
      private string AV76Bancos_conceptoentregarendirwwds_19_tfcuecod ;
      private string AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ;
      private string AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc ;
      private string AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ;
      private string scmdbuf ;
      private string lV60Bancos_conceptoentregarendirwwds_3_conentdsc1 ;
      private string lV61Bancos_conceptoentregarendirwwds_4_cuecod1 ;
      private string lV65Bancos_conceptoentregarendirwwds_8_conentdsc2 ;
      private string lV66Bancos_conceptoentregarendirwwds_9_cuecod2 ;
      private string lV70Bancos_conceptoentregarendirwwds_13_conentdsc3 ;
      private string lV71Bancos_conceptoentregarendirwwds_14_cuecod3 ;
      private string lV74Bancos_conceptoentregarendirwwds_17_tfconentdsc ;
      private string lV76Bancos_conceptoentregarendirwwds_19_tfcuecod ;
      private string lV78Bancos_conceptoentregarendirwwds_21_tfcuedsc ;
      private string A749ConEntDsc ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ;
      private bool AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ;
      private bool BRK5W2 ;
      private bool BRK5W4 ;
      private bool BRK5W6 ;
      private string AV26OptionsJson ;
      private string AV29OptionsDescJson ;
      private string AV31OptionIndexesJson ;
      private string AV52TFConEntSts_SelsJson ;
      private string AV22DDOName ;
      private string AV20SearchTxt ;
      private string AV21SearchTxtTo ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ;
      private string AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ;
      private string AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ;
      private string AV24Option ;
      private GxSimpleCollection<short> AV53TFConEntSts_Sels ;
      private GxSimpleCollection<short> AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005W2_A749ConEntDsc ;
      private short[] P005W2_A750ConEntSts ;
      private string[] P005W2_A860CueDsc ;
      private int[] P005W2_A376ConEntCod ;
      private string[] P005W2_A91CueCod ;
      private string[] P005W3_A91CueCod ;
      private short[] P005W3_A750ConEntSts ;
      private string[] P005W3_A860CueDsc ;
      private int[] P005W3_A376ConEntCod ;
      private string[] P005W3_A749ConEntDsc ;
      private string[] P005W4_A860CueDsc ;
      private short[] P005W4_A750ConEntSts ;
      private int[] P005W4_A376ConEntCod ;
      private string[] P005W4_A91CueCod ;
      private string[] P005W4_A749ConEntDsc ;
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

   public class conceptoentregarendirwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005W2( IGxContext context ,
                                             short A750ConEntSts ,
                                             GxSimpleCollection<short> AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ,
                                             string AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ,
                                             short AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ,
                                             string AV60Bancos_conceptoentregarendirwwds_3_conentdsc1 ,
                                             string AV61Bancos_conceptoentregarendirwwds_4_cuecod1 ,
                                             bool AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ,
                                             string AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ,
                                             short AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ,
                                             string AV65Bancos_conceptoentregarendirwwds_8_conentdsc2 ,
                                             string AV66Bancos_conceptoentregarendirwwds_9_cuecod2 ,
                                             bool AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ,
                                             string AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ,
                                             short AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ,
                                             string AV70Bancos_conceptoentregarendirwwds_13_conentdsc3 ,
                                             string AV71Bancos_conceptoentregarendirwwds_14_cuecod3 ,
                                             int AV72Bancos_conceptoentregarendirwwds_15_tfconentcod ,
                                             int AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to ,
                                             string AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ,
                                             string AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc ,
                                             string AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ,
                                             string AV76Bancos_conceptoentregarendirwwds_19_tfcuecod ,
                                             string AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ,
                                             string AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc ,
                                             int AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count ,
                                             string A749ConEntDsc ,
                                             string A91CueCod ,
                                             int A376ConEntCod ,
                                             string A860CueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ConEntDsc], T1.[ConEntSts], T2.[CueDsc], T1.[ConEntCod], T1.[CueCod] FROM ([TSCONCEPTOENTREGA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CONENTDSC") == 0 ) && ( AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_3_conentdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV60Bancos_conceptoentregarendirwwds_3_conentdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CONENTDSC") == 0 ) && ( AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_3_conentdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV60Bancos_conceptoentregarendirwwds_3_conentdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_conceptoentregarendirwwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV61Bancos_conceptoentregarendirwwds_4_cuecod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_conceptoentregarendirwwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV61Bancos_conceptoentregarendirwwds_4_cuecod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CONENTDSC") == 0 ) && ( AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_8_conentdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV65Bancos_conceptoentregarendirwwds_8_conentdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CONENTDSC") == 0 ) && ( AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_8_conentdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV65Bancos_conceptoentregarendirwwds_8_conentdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_conceptoentregarendirwwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV66Bancos_conceptoentregarendirwwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_conceptoentregarendirwwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV66Bancos_conceptoentregarendirwwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CONENTDSC") == 0 ) && ( AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_13_conentdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV70Bancos_conceptoentregarendirwwds_13_conentdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CONENTDSC") == 0 ) && ( AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_13_conentdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV70Bancos_conceptoentregarendirwwds_13_conentdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_conceptoentregarendirwwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV71Bancos_conceptoentregarendirwwds_14_cuecod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_conceptoentregarendirwwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV71Bancos_conceptoentregarendirwwds_14_cuecod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV72Bancos_conceptoentregarendirwwds_15_tfconentcod) )
         {
            AddWhere(sWhereString, "(T1.[ConEntCod] >= @AV72Bancos_conceptoentregarendirwwds_15_tfconentcod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConEntCod] <= @AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV74Bancos_conceptoentregarendirwwds_17_tfconentdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] = @AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_conceptoentregarendirwwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV76Bancos_conceptoentregarendirwwds_19_tfcuecod)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV78Bancos_conceptoentregarendirwwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels, "T1.[ConEntSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ConEntDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005W3( IGxContext context ,
                                             short A750ConEntSts ,
                                             GxSimpleCollection<short> AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ,
                                             string AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ,
                                             short AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ,
                                             string AV60Bancos_conceptoentregarendirwwds_3_conentdsc1 ,
                                             string AV61Bancos_conceptoentregarendirwwds_4_cuecod1 ,
                                             bool AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ,
                                             string AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ,
                                             short AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ,
                                             string AV65Bancos_conceptoentregarendirwwds_8_conentdsc2 ,
                                             string AV66Bancos_conceptoentregarendirwwds_9_cuecod2 ,
                                             bool AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ,
                                             string AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ,
                                             short AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ,
                                             string AV70Bancos_conceptoentregarendirwwds_13_conentdsc3 ,
                                             string AV71Bancos_conceptoentregarendirwwds_14_cuecod3 ,
                                             int AV72Bancos_conceptoentregarendirwwds_15_tfconentcod ,
                                             int AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to ,
                                             string AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ,
                                             string AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc ,
                                             string AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ,
                                             string AV76Bancos_conceptoentregarendirwwds_19_tfcuecod ,
                                             string AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ,
                                             string AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc ,
                                             int AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count ,
                                             string A749ConEntDsc ,
                                             string A91CueCod ,
                                             int A376ConEntCod ,
                                             string A860CueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CueCod], T1.[ConEntSts], T2.[CueDsc], T1.[ConEntCod], T1.[ConEntDsc] FROM ([TSCONCEPTOENTREGA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CONENTDSC") == 0 ) && ( AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_3_conentdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV60Bancos_conceptoentregarendirwwds_3_conentdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CONENTDSC") == 0 ) && ( AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_3_conentdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV60Bancos_conceptoentregarendirwwds_3_conentdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_conceptoentregarendirwwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV61Bancos_conceptoentregarendirwwds_4_cuecod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_conceptoentregarendirwwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV61Bancos_conceptoentregarendirwwds_4_cuecod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CONENTDSC") == 0 ) && ( AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_8_conentdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV65Bancos_conceptoentregarendirwwds_8_conentdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CONENTDSC") == 0 ) && ( AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_8_conentdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV65Bancos_conceptoentregarendirwwds_8_conentdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_conceptoentregarendirwwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV66Bancos_conceptoentregarendirwwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_conceptoentregarendirwwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV66Bancos_conceptoentregarendirwwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CONENTDSC") == 0 ) && ( AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_13_conentdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV70Bancos_conceptoentregarendirwwds_13_conentdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CONENTDSC") == 0 ) && ( AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_13_conentdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV70Bancos_conceptoentregarendirwwds_13_conentdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_conceptoentregarendirwwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV71Bancos_conceptoentregarendirwwds_14_cuecod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_conceptoentregarendirwwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV71Bancos_conceptoentregarendirwwds_14_cuecod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV72Bancos_conceptoentregarendirwwds_15_tfconentcod) )
         {
            AddWhere(sWhereString, "(T1.[ConEntCod] >= @AV72Bancos_conceptoentregarendirwwds_15_tfconentcod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConEntCod] <= @AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV74Bancos_conceptoentregarendirwwds_17_tfconentdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] = @AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_conceptoentregarendirwwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV76Bancos_conceptoentregarendirwwds_19_tfcuecod)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV78Bancos_conceptoentregarendirwwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels, "T1.[ConEntSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P005W4( IGxContext context ,
                                             short A750ConEntSts ,
                                             GxSimpleCollection<short> AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels ,
                                             string AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1 ,
                                             short AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 ,
                                             string AV60Bancos_conceptoentregarendirwwds_3_conentdsc1 ,
                                             string AV61Bancos_conceptoentregarendirwwds_4_cuecod1 ,
                                             bool AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 ,
                                             string AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2 ,
                                             short AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 ,
                                             string AV65Bancos_conceptoentregarendirwwds_8_conentdsc2 ,
                                             string AV66Bancos_conceptoentregarendirwwds_9_cuecod2 ,
                                             bool AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 ,
                                             string AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3 ,
                                             short AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 ,
                                             string AV70Bancos_conceptoentregarendirwwds_13_conentdsc3 ,
                                             string AV71Bancos_conceptoentregarendirwwds_14_cuecod3 ,
                                             int AV72Bancos_conceptoentregarendirwwds_15_tfconentcod ,
                                             int AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to ,
                                             string AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel ,
                                             string AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc ,
                                             string AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel ,
                                             string AV76Bancos_conceptoentregarendirwwds_19_tfcuecod ,
                                             string AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel ,
                                             string AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc ,
                                             int AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count ,
                                             string A749ConEntDsc ,
                                             string A91CueCod ,
                                             int A376ConEntCod ,
                                             string A860CueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T2.[CueDsc], T1.[ConEntSts], T1.[ConEntCod], T1.[CueCod], T1.[ConEntDsc] FROM ([TSCONCEPTOENTREGA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CONENTDSC") == 0 ) && ( AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_3_conentdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV60Bancos_conceptoentregarendirwwds_3_conentdsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CONENTDSC") == 0 ) && ( AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_conceptoentregarendirwwds_3_conentdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV60Bancos_conceptoentregarendirwwds_3_conentdsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_conceptoentregarendirwwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV61Bancos_conceptoentregarendirwwds_4_cuecod1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_conceptoentregarendirwwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV59Bancos_conceptoentregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_conceptoentregarendirwwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV61Bancos_conceptoentregarendirwwds_4_cuecod1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CONENTDSC") == 0 ) && ( AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_8_conentdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV65Bancos_conceptoentregarendirwwds_8_conentdsc2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CONENTDSC") == 0 ) && ( AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_conceptoentregarendirwwds_8_conentdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV65Bancos_conceptoentregarendirwwds_8_conentdsc2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_conceptoentregarendirwwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV66Bancos_conceptoentregarendirwwds_9_cuecod2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV62Bancos_conceptoentregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_conceptoentregarendirwwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV64Bancos_conceptoentregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_conceptoentregarendirwwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV66Bancos_conceptoentregarendirwwds_9_cuecod2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CONENTDSC") == 0 ) && ( AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_13_conentdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV70Bancos_conceptoentregarendirwwds_13_conentdsc3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CONENTDSC") == 0 ) && ( AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_conceptoentregarendirwwds_13_conentdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like '%' + @lV70Bancos_conceptoentregarendirwwds_13_conentdsc3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_conceptoentregarendirwwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV71Bancos_conceptoentregarendirwwds_14_cuecod3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV67Bancos_conceptoentregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_conceptoentregarendirwwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV69Bancos_conceptoentregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_conceptoentregarendirwwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV71Bancos_conceptoentregarendirwwds_14_cuecod3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (0==AV72Bancos_conceptoentregarendirwwds_15_tfconentcod) )
         {
            AddWhere(sWhereString, "(T1.[ConEntCod] >= @AV72Bancos_conceptoentregarendirwwds_15_tfconentcod)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (0==AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConEntCod] <= @AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoentregarendirwwds_17_tfconentdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] like @lV74Bancos_conceptoentregarendirwwds_17_tfconentdsc)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConEntDsc] = @AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_conceptoentregarendirwwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV76Bancos_conceptoentregarendirwwds_19_tfcuecod)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_conceptoentregarendirwwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV78Bancos_conceptoentregarendirwwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV80Bancos_conceptoentregarendirwwds_23_tfconentsts_sels, "T1.[ConEntSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[CueDsc]";
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
                     return conditional_P005W2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
               case 1 :
                     return conditional_P005W3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
               case 2 :
                     return conditional_P005W4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP005W2;
          prmP005W2 = new Object[] {
          new ParDef("@lV60Bancos_conceptoentregarendirwwds_3_conentdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Bancos_conceptoentregarendirwwds_3_conentdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_conceptoentregarendirwwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV61Bancos_conceptoentregarendirwwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV65Bancos_conceptoentregarendirwwds_8_conentdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_conceptoentregarendirwwds_8_conentdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Bancos_conceptoentregarendirwwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV66Bancos_conceptoentregarendirwwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV70Bancos_conceptoentregarendirwwds_13_conentdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_conceptoentregarendirwwds_13_conentdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV71Bancos_conceptoentregarendirwwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV71Bancos_conceptoentregarendirwwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV72Bancos_conceptoentregarendirwwds_15_tfconentcod",GXType.Int32,6,0) ,
          new ParDef("@AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV74Bancos_conceptoentregarendirwwds_17_tfconentdsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV76Bancos_conceptoentregarendirwwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV78Bancos_conceptoentregarendirwwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP005W3;
          prmP005W3 = new Object[] {
          new ParDef("@lV60Bancos_conceptoentregarendirwwds_3_conentdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Bancos_conceptoentregarendirwwds_3_conentdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_conceptoentregarendirwwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV61Bancos_conceptoentregarendirwwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV65Bancos_conceptoentregarendirwwds_8_conentdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_conceptoentregarendirwwds_8_conentdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Bancos_conceptoentregarendirwwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV66Bancos_conceptoentregarendirwwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV70Bancos_conceptoentregarendirwwds_13_conentdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_conceptoentregarendirwwds_13_conentdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV71Bancos_conceptoentregarendirwwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV71Bancos_conceptoentregarendirwwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV72Bancos_conceptoentregarendirwwds_15_tfconentcod",GXType.Int32,6,0) ,
          new ParDef("@AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV74Bancos_conceptoentregarendirwwds_17_tfconentdsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV76Bancos_conceptoentregarendirwwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV78Bancos_conceptoentregarendirwwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP005W4;
          prmP005W4 = new Object[] {
          new ParDef("@lV60Bancos_conceptoentregarendirwwds_3_conentdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Bancos_conceptoentregarendirwwds_3_conentdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_conceptoentregarendirwwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV61Bancos_conceptoentregarendirwwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV65Bancos_conceptoentregarendirwwds_8_conentdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_conceptoentregarendirwwds_8_conentdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Bancos_conceptoentregarendirwwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV66Bancos_conceptoentregarendirwwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV70Bancos_conceptoentregarendirwwds_13_conentdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_conceptoentregarendirwwds_13_conentdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV71Bancos_conceptoentregarendirwwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV71Bancos_conceptoentregarendirwwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV72Bancos_conceptoentregarendirwwds_15_tfconentcod",GXType.Int32,6,0) ,
          new ParDef("@AV73Bancos_conceptoentregarendirwwds_16_tfconentcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV74Bancos_conceptoentregarendirwwds_17_tfconentdsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Bancos_conceptoentregarendirwwds_18_tfconentdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV76Bancos_conceptoentregarendirwwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV77Bancos_conceptoentregarendirwwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV78Bancos_conceptoentregarendirwwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV79Bancos_conceptoentregarendirwwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005W2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005W3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005W4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005W4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 15);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
