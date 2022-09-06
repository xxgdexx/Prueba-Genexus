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
   public class conceptoscajachicawwgetfilterdata : GXProcedure
   {
      public conceptoscajachicawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptoscajachicawwgetfilterdata( IGxContext context )
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
         conceptoscajachicawwgetfilterdata objconceptoscajachicawwgetfilterdata;
         objconceptoscajachicawwgetfilterdata = new conceptoscajachicawwgetfilterdata();
         objconceptoscajachicawwgetfilterdata.AV22DDOName = aP0_DDOName;
         objconceptoscajachicawwgetfilterdata.AV20SearchTxt = aP1_SearchTxt;
         objconceptoscajachicawwgetfilterdata.AV21SearchTxtTo = aP2_SearchTxtTo;
         objconceptoscajachicawwgetfilterdata.AV26OptionsJson = "" ;
         objconceptoscajachicawwgetfilterdata.AV29OptionsDescJson = "" ;
         objconceptoscajachicawwgetfilterdata.AV31OptionIndexesJson = "" ;
         objconceptoscajachicawwgetfilterdata.context.SetSubmitInitialConfig(context);
         objconceptoscajachicawwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptoscajachicawwgetfilterdata);
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptoscajachicawwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_CONCAJDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCONCAJDSCOPTIONS' */
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
         if ( StringUtil.StrCmp(AV33Session.Get("Bancos.ConceptosCajaChicaWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.ConceptosCajaChicaWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Bancos.ConceptosCajaChicaWWGridState"), null, "", "");
         }
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV54GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONCAJCOD") == 0 )
            {
               AV10TFConCajCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV11TFConCajCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONCAJDSC") == 0 )
            {
               AV12TFConCajDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONCAJDSC_SEL") == 0 )
            {
               AV13TFConCajDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
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
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONCAJSTS_SEL") == 0 )
            {
               AV18TFConCajSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV19TFConCajSts_Sels.FromJSonString(AV18TFConCajSts_SelsJson, null);
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "CONCAJDSC") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV40ConCajDsc1 = AV37GridStateDynamicFilter.gxTpr_Value;
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
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "CONCAJDSC") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV44ConCajDsc2 = AV37GridStateDynamicFilter.gxTpr_Value;
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
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "CONCAJDSC") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV48ConCajDsc3 = AV37GridStateDynamicFilter.gxTpr_Value;
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
         /* 'LOADCONCAJDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFConCajDsc = AV20SearchTxt;
         AV13TFConCajDsc_Sel = "";
         AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV58Bancos_conceptoscajachicawwds_3_concajdsc1 = AV40ConCajDsc1;
         AV59Bancos_conceptoscajachicawwds_4_cuecod1 = AV49CueCod1;
         AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV63Bancos_conceptoscajachicawwds_8_concajdsc2 = AV44ConCajDsc2;
         AV64Bancos_conceptoscajachicawwds_9_cuecod2 = AV50CueCod2;
         AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV68Bancos_conceptoscajachicawwds_13_concajdsc3 = AV48ConCajDsc3;
         AV69Bancos_conceptoscajachicawwds_14_cuecod3 = AV51CueCod3;
         AV70Bancos_conceptoscajachicawwds_15_tfconcajcod = AV10TFConCajCod;
         AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to = AV11TFConCajCod_To;
         AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc = AV12TFConCajDsc;
         AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel = AV13TFConCajDsc_Sel;
         AV74Bancos_conceptoscajachicawwds_19_tfcuecod = AV14TFCueCod;
         AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel = AV15TFCueCod_Sel;
         AV76Bancos_conceptoscajachicawwds_21_tfcuedsc = AV16TFCueDsc;
         AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel = AV17TFCueDsc_Sel;
         AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels = AV19TFConCajSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A748ConCajSts ,
                                              AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels ,
                                              AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 ,
                                              AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 ,
                                              AV58Bancos_conceptoscajachicawwds_3_concajdsc1 ,
                                              AV59Bancos_conceptoscajachicawwds_4_cuecod1 ,
                                              AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 ,
                                              AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 ,
                                              AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 ,
                                              AV63Bancos_conceptoscajachicawwds_8_concajdsc2 ,
                                              AV64Bancos_conceptoscajachicawwds_9_cuecod2 ,
                                              AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 ,
                                              AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 ,
                                              AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 ,
                                              AV68Bancos_conceptoscajachicawwds_13_concajdsc3 ,
                                              AV69Bancos_conceptoscajachicawwds_14_cuecod3 ,
                                              AV70Bancos_conceptoscajachicawwds_15_tfconcajcod ,
                                              AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to ,
                                              AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel ,
                                              AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc ,
                                              AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel ,
                                              AV74Bancos_conceptoscajachicawwds_19_tfcuecod ,
                                              AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel ,
                                              AV76Bancos_conceptoscajachicawwds_21_tfcuedsc ,
                                              AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels.Count ,
                                              A747ConCajDsc ,
                                              A91CueCod ,
                                              A375ConCajCod ,
                                              A860CueDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV58Bancos_conceptoscajachicawwds_3_concajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Bancos_conceptoscajachicawwds_3_concajdsc1), 100, "%");
         lV58Bancos_conceptoscajachicawwds_3_concajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Bancos_conceptoscajachicawwds_3_concajdsc1), 100, "%");
         lV59Bancos_conceptoscajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV59Bancos_conceptoscajachicawwds_4_cuecod1), 15, "%");
         lV59Bancos_conceptoscajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV59Bancos_conceptoscajachicawwds_4_cuecod1), 15, "%");
         lV63Bancos_conceptoscajachicawwds_8_concajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_conceptoscajachicawwds_8_concajdsc2), 100, "%");
         lV63Bancos_conceptoscajachicawwds_8_concajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_conceptoscajachicawwds_8_concajdsc2), 100, "%");
         lV64Bancos_conceptoscajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptoscajachicawwds_9_cuecod2), 15, "%");
         lV64Bancos_conceptoscajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptoscajachicawwds_9_cuecod2), 15, "%");
         lV68Bancos_conceptoscajachicawwds_13_concajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_conceptoscajachicawwds_13_concajdsc3), 100, "%");
         lV68Bancos_conceptoscajachicawwds_13_concajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_conceptoscajachicawwds_13_concajdsc3), 100, "%");
         lV69Bancos_conceptoscajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptoscajachicawwds_14_cuecod3), 15, "%");
         lV69Bancos_conceptoscajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptoscajachicawwds_14_cuecod3), 15, "%");
         lV72Bancos_conceptoscajachicawwds_17_tfconcajdsc = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc), 100, "%");
         lV74Bancos_conceptoscajachicawwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_conceptoscajachicawwds_19_tfcuecod), 15, "%");
         lV76Bancos_conceptoscajachicawwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_conceptoscajachicawwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005O2 */
         pr_default.execute(0, new Object[] {lV58Bancos_conceptoscajachicawwds_3_concajdsc1, lV58Bancos_conceptoscajachicawwds_3_concajdsc1, lV59Bancos_conceptoscajachicawwds_4_cuecod1, lV59Bancos_conceptoscajachicawwds_4_cuecod1, lV63Bancos_conceptoscajachicawwds_8_concajdsc2, lV63Bancos_conceptoscajachicawwds_8_concajdsc2, lV64Bancos_conceptoscajachicawwds_9_cuecod2, lV64Bancos_conceptoscajachicawwds_9_cuecod2, lV68Bancos_conceptoscajachicawwds_13_concajdsc3, lV68Bancos_conceptoscajachicawwds_13_concajdsc3, lV69Bancos_conceptoscajachicawwds_14_cuecod3, lV69Bancos_conceptoscajachicawwds_14_cuecod3, AV70Bancos_conceptoscajachicawwds_15_tfconcajcod, AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to, lV72Bancos_conceptoscajachicawwds_17_tfconcajdsc, AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel, lV74Bancos_conceptoscajachicawwds_19_tfcuecod, AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel, lV76Bancos_conceptoscajachicawwds_21_tfcuedsc, AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5O2 = false;
            A747ConCajDsc = P005O2_A747ConCajDsc[0];
            A748ConCajSts = P005O2_A748ConCajSts[0];
            A860CueDsc = P005O2_A860CueDsc[0];
            A375ConCajCod = P005O2_A375ConCajCod[0];
            A91CueCod = P005O2_A91CueCod[0];
            A860CueDsc = P005O2_A860CueDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005O2_A747ConCajDsc[0], A747ConCajDsc) == 0 ) )
            {
               BRK5O2 = false;
               A375ConCajCod = P005O2_A375ConCajCod[0];
               AV32count = (long)(AV32count+1);
               BRK5O2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A747ConCajDsc)) )
            {
               AV24Option = A747ConCajDsc;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK5O2 )
            {
               BRK5O2 = true;
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
         AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV58Bancos_conceptoscajachicawwds_3_concajdsc1 = AV40ConCajDsc1;
         AV59Bancos_conceptoscajachicawwds_4_cuecod1 = AV49CueCod1;
         AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV63Bancos_conceptoscajachicawwds_8_concajdsc2 = AV44ConCajDsc2;
         AV64Bancos_conceptoscajachicawwds_9_cuecod2 = AV50CueCod2;
         AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV68Bancos_conceptoscajachicawwds_13_concajdsc3 = AV48ConCajDsc3;
         AV69Bancos_conceptoscajachicawwds_14_cuecod3 = AV51CueCod3;
         AV70Bancos_conceptoscajachicawwds_15_tfconcajcod = AV10TFConCajCod;
         AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to = AV11TFConCajCod_To;
         AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc = AV12TFConCajDsc;
         AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel = AV13TFConCajDsc_Sel;
         AV74Bancos_conceptoscajachicawwds_19_tfcuecod = AV14TFCueCod;
         AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel = AV15TFCueCod_Sel;
         AV76Bancos_conceptoscajachicawwds_21_tfcuedsc = AV16TFCueDsc;
         AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel = AV17TFCueDsc_Sel;
         AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels = AV19TFConCajSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A748ConCajSts ,
                                              AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels ,
                                              AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 ,
                                              AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 ,
                                              AV58Bancos_conceptoscajachicawwds_3_concajdsc1 ,
                                              AV59Bancos_conceptoscajachicawwds_4_cuecod1 ,
                                              AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 ,
                                              AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 ,
                                              AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 ,
                                              AV63Bancos_conceptoscajachicawwds_8_concajdsc2 ,
                                              AV64Bancos_conceptoscajachicawwds_9_cuecod2 ,
                                              AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 ,
                                              AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 ,
                                              AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 ,
                                              AV68Bancos_conceptoscajachicawwds_13_concajdsc3 ,
                                              AV69Bancos_conceptoscajachicawwds_14_cuecod3 ,
                                              AV70Bancos_conceptoscajachicawwds_15_tfconcajcod ,
                                              AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to ,
                                              AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel ,
                                              AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc ,
                                              AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel ,
                                              AV74Bancos_conceptoscajachicawwds_19_tfcuecod ,
                                              AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel ,
                                              AV76Bancos_conceptoscajachicawwds_21_tfcuedsc ,
                                              AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels.Count ,
                                              A747ConCajDsc ,
                                              A91CueCod ,
                                              A375ConCajCod ,
                                              A860CueDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV58Bancos_conceptoscajachicawwds_3_concajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Bancos_conceptoscajachicawwds_3_concajdsc1), 100, "%");
         lV58Bancos_conceptoscajachicawwds_3_concajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Bancos_conceptoscajachicawwds_3_concajdsc1), 100, "%");
         lV59Bancos_conceptoscajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV59Bancos_conceptoscajachicawwds_4_cuecod1), 15, "%");
         lV59Bancos_conceptoscajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV59Bancos_conceptoscajachicawwds_4_cuecod1), 15, "%");
         lV63Bancos_conceptoscajachicawwds_8_concajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_conceptoscajachicawwds_8_concajdsc2), 100, "%");
         lV63Bancos_conceptoscajachicawwds_8_concajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_conceptoscajachicawwds_8_concajdsc2), 100, "%");
         lV64Bancos_conceptoscajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptoscajachicawwds_9_cuecod2), 15, "%");
         lV64Bancos_conceptoscajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptoscajachicawwds_9_cuecod2), 15, "%");
         lV68Bancos_conceptoscajachicawwds_13_concajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_conceptoscajachicawwds_13_concajdsc3), 100, "%");
         lV68Bancos_conceptoscajachicawwds_13_concajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_conceptoscajachicawwds_13_concajdsc3), 100, "%");
         lV69Bancos_conceptoscajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptoscajachicawwds_14_cuecod3), 15, "%");
         lV69Bancos_conceptoscajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptoscajachicawwds_14_cuecod3), 15, "%");
         lV72Bancos_conceptoscajachicawwds_17_tfconcajdsc = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc), 100, "%");
         lV74Bancos_conceptoscajachicawwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_conceptoscajachicawwds_19_tfcuecod), 15, "%");
         lV76Bancos_conceptoscajachicawwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_conceptoscajachicawwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005O3 */
         pr_default.execute(1, new Object[] {lV58Bancos_conceptoscajachicawwds_3_concajdsc1, lV58Bancos_conceptoscajachicawwds_3_concajdsc1, lV59Bancos_conceptoscajachicawwds_4_cuecod1, lV59Bancos_conceptoscajachicawwds_4_cuecod1, lV63Bancos_conceptoscajachicawwds_8_concajdsc2, lV63Bancos_conceptoscajachicawwds_8_concajdsc2, lV64Bancos_conceptoscajachicawwds_9_cuecod2, lV64Bancos_conceptoscajachicawwds_9_cuecod2, lV68Bancos_conceptoscajachicawwds_13_concajdsc3, lV68Bancos_conceptoscajachicawwds_13_concajdsc3, lV69Bancos_conceptoscajachicawwds_14_cuecod3, lV69Bancos_conceptoscajachicawwds_14_cuecod3, AV70Bancos_conceptoscajachicawwds_15_tfconcajcod, AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to, lV72Bancos_conceptoscajachicawwds_17_tfconcajdsc, AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel, lV74Bancos_conceptoscajachicawwds_19_tfcuecod, AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel, lV76Bancos_conceptoscajachicawwds_21_tfcuedsc, AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5O4 = false;
            A91CueCod = P005O3_A91CueCod[0];
            A748ConCajSts = P005O3_A748ConCajSts[0];
            A860CueDsc = P005O3_A860CueDsc[0];
            A375ConCajCod = P005O3_A375ConCajCod[0];
            A747ConCajDsc = P005O3_A747ConCajDsc[0];
            A860CueDsc = P005O3_A860CueDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005O3_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRK5O4 = false;
               A375ConCajCod = P005O3_A375ConCajCod[0];
               AV32count = (long)(AV32count+1);
               BRK5O4 = true;
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
            if ( ! BRK5O4 )
            {
               BRK5O4 = true;
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
         AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV58Bancos_conceptoscajachicawwds_3_concajdsc1 = AV40ConCajDsc1;
         AV59Bancos_conceptoscajachicawwds_4_cuecod1 = AV49CueCod1;
         AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV63Bancos_conceptoscajachicawwds_8_concajdsc2 = AV44ConCajDsc2;
         AV64Bancos_conceptoscajachicawwds_9_cuecod2 = AV50CueCod2;
         AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV68Bancos_conceptoscajachicawwds_13_concajdsc3 = AV48ConCajDsc3;
         AV69Bancos_conceptoscajachicawwds_14_cuecod3 = AV51CueCod3;
         AV70Bancos_conceptoscajachicawwds_15_tfconcajcod = AV10TFConCajCod;
         AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to = AV11TFConCajCod_To;
         AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc = AV12TFConCajDsc;
         AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel = AV13TFConCajDsc_Sel;
         AV74Bancos_conceptoscajachicawwds_19_tfcuecod = AV14TFCueCod;
         AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel = AV15TFCueCod_Sel;
         AV76Bancos_conceptoscajachicawwds_21_tfcuedsc = AV16TFCueDsc;
         AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel = AV17TFCueDsc_Sel;
         AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels = AV19TFConCajSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A748ConCajSts ,
                                              AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels ,
                                              AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 ,
                                              AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 ,
                                              AV58Bancos_conceptoscajachicawwds_3_concajdsc1 ,
                                              AV59Bancos_conceptoscajachicawwds_4_cuecod1 ,
                                              AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 ,
                                              AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 ,
                                              AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 ,
                                              AV63Bancos_conceptoscajachicawwds_8_concajdsc2 ,
                                              AV64Bancos_conceptoscajachicawwds_9_cuecod2 ,
                                              AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 ,
                                              AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 ,
                                              AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 ,
                                              AV68Bancos_conceptoscajachicawwds_13_concajdsc3 ,
                                              AV69Bancos_conceptoscajachicawwds_14_cuecod3 ,
                                              AV70Bancos_conceptoscajachicawwds_15_tfconcajcod ,
                                              AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to ,
                                              AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel ,
                                              AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc ,
                                              AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel ,
                                              AV74Bancos_conceptoscajachicawwds_19_tfcuecod ,
                                              AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel ,
                                              AV76Bancos_conceptoscajachicawwds_21_tfcuedsc ,
                                              AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels.Count ,
                                              A747ConCajDsc ,
                                              A91CueCod ,
                                              A375ConCajCod ,
                                              A860CueDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV58Bancos_conceptoscajachicawwds_3_concajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Bancos_conceptoscajachicawwds_3_concajdsc1), 100, "%");
         lV58Bancos_conceptoscajachicawwds_3_concajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Bancos_conceptoscajachicawwds_3_concajdsc1), 100, "%");
         lV59Bancos_conceptoscajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV59Bancos_conceptoscajachicawwds_4_cuecod1), 15, "%");
         lV59Bancos_conceptoscajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV59Bancos_conceptoscajachicawwds_4_cuecod1), 15, "%");
         lV63Bancos_conceptoscajachicawwds_8_concajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_conceptoscajachicawwds_8_concajdsc2), 100, "%");
         lV63Bancos_conceptoscajachicawwds_8_concajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_conceptoscajachicawwds_8_concajdsc2), 100, "%");
         lV64Bancos_conceptoscajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptoscajachicawwds_9_cuecod2), 15, "%");
         lV64Bancos_conceptoscajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV64Bancos_conceptoscajachicawwds_9_cuecod2), 15, "%");
         lV68Bancos_conceptoscajachicawwds_13_concajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_conceptoscajachicawwds_13_concajdsc3), 100, "%");
         lV68Bancos_conceptoscajachicawwds_13_concajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_conceptoscajachicawwds_13_concajdsc3), 100, "%");
         lV69Bancos_conceptoscajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptoscajachicawwds_14_cuecod3), 15, "%");
         lV69Bancos_conceptoscajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV69Bancos_conceptoscajachicawwds_14_cuecod3), 15, "%");
         lV72Bancos_conceptoscajachicawwds_17_tfconcajdsc = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc), 100, "%");
         lV74Bancos_conceptoscajachicawwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_conceptoscajachicawwds_19_tfcuecod), 15, "%");
         lV76Bancos_conceptoscajachicawwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_conceptoscajachicawwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005O4 */
         pr_default.execute(2, new Object[] {lV58Bancos_conceptoscajachicawwds_3_concajdsc1, lV58Bancos_conceptoscajachicawwds_3_concajdsc1, lV59Bancos_conceptoscajachicawwds_4_cuecod1, lV59Bancos_conceptoscajachicawwds_4_cuecod1, lV63Bancos_conceptoscajachicawwds_8_concajdsc2, lV63Bancos_conceptoscajachicawwds_8_concajdsc2, lV64Bancos_conceptoscajachicawwds_9_cuecod2, lV64Bancos_conceptoscajachicawwds_9_cuecod2, lV68Bancos_conceptoscajachicawwds_13_concajdsc3, lV68Bancos_conceptoscajachicawwds_13_concajdsc3, lV69Bancos_conceptoscajachicawwds_14_cuecod3, lV69Bancos_conceptoscajachicawwds_14_cuecod3, AV70Bancos_conceptoscajachicawwds_15_tfconcajcod, AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to, lV72Bancos_conceptoscajachicawwds_17_tfconcajdsc, AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel, lV74Bancos_conceptoscajachicawwds_19_tfcuecod, AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel, lV76Bancos_conceptoscajachicawwds_21_tfcuedsc, AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5O6 = false;
            A91CueCod = P005O4_A91CueCod[0];
            A748ConCajSts = P005O4_A748ConCajSts[0];
            A860CueDsc = P005O4_A860CueDsc[0];
            A375ConCajCod = P005O4_A375ConCajCod[0];
            A747ConCajDsc = P005O4_A747ConCajDsc[0];
            A860CueDsc = P005O4_A860CueDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005O4_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRK5O6 = false;
               A375ConCajCod = P005O4_A375ConCajCod[0];
               AV32count = (long)(AV32count+1);
               BRK5O6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A860CueDsc)) )
            {
               AV24Option = A860CueDsc;
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
            if ( ! BRK5O6 )
            {
               BRK5O6 = true;
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
         AV12TFConCajDsc = "";
         AV13TFConCajDsc_Sel = "";
         AV14TFCueCod = "";
         AV15TFCueCod_Sel = "";
         AV16TFCueDsc = "";
         AV17TFCueDsc_Sel = "";
         AV18TFConCajSts_SelsJson = "";
         AV19TFConCajSts_Sels = new GxSimpleCollection<short>();
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40ConCajDsc1 = "";
         AV49CueCod1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44ConCajDsc2 = "";
         AV50CueCod2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48ConCajDsc3 = "";
         AV51CueCod3 = "";
         AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 = "";
         AV58Bancos_conceptoscajachicawwds_3_concajdsc1 = "";
         AV59Bancos_conceptoscajachicawwds_4_cuecod1 = "";
         AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 = "";
         AV63Bancos_conceptoscajachicawwds_8_concajdsc2 = "";
         AV64Bancos_conceptoscajachicawwds_9_cuecod2 = "";
         AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 = "";
         AV68Bancos_conceptoscajachicawwds_13_concajdsc3 = "";
         AV69Bancos_conceptoscajachicawwds_14_cuecod3 = "";
         AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc = "";
         AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel = "";
         AV74Bancos_conceptoscajachicawwds_19_tfcuecod = "";
         AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel = "";
         AV76Bancos_conceptoscajachicawwds_21_tfcuedsc = "";
         AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel = "";
         AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV58Bancos_conceptoscajachicawwds_3_concajdsc1 = "";
         lV59Bancos_conceptoscajachicawwds_4_cuecod1 = "";
         lV63Bancos_conceptoscajachicawwds_8_concajdsc2 = "";
         lV64Bancos_conceptoscajachicawwds_9_cuecod2 = "";
         lV68Bancos_conceptoscajachicawwds_13_concajdsc3 = "";
         lV69Bancos_conceptoscajachicawwds_14_cuecod3 = "";
         lV72Bancos_conceptoscajachicawwds_17_tfconcajdsc = "";
         lV74Bancos_conceptoscajachicawwds_19_tfcuecod = "";
         lV76Bancos_conceptoscajachicawwds_21_tfcuedsc = "";
         A747ConCajDsc = "";
         A91CueCod = "";
         A860CueDsc = "";
         P005O2_A747ConCajDsc = new string[] {""} ;
         P005O2_A748ConCajSts = new short[1] ;
         P005O2_A860CueDsc = new string[] {""} ;
         P005O2_A375ConCajCod = new int[1] ;
         P005O2_A91CueCod = new string[] {""} ;
         AV24Option = "";
         P005O3_A91CueCod = new string[] {""} ;
         P005O3_A748ConCajSts = new short[1] ;
         P005O3_A860CueDsc = new string[] {""} ;
         P005O3_A375ConCajCod = new int[1] ;
         P005O3_A747ConCajDsc = new string[] {""} ;
         P005O4_A91CueCod = new string[] {""} ;
         P005O4_A748ConCajSts = new short[1] ;
         P005O4_A860CueDsc = new string[] {""} ;
         P005O4_A375ConCajCod = new int[1] ;
         P005O4_A747ConCajDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.conceptoscajachicawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005O2_A747ConCajDsc, P005O2_A748ConCajSts, P005O2_A860CueDsc, P005O2_A375ConCajCod, P005O2_A91CueCod
               }
               , new Object[] {
               P005O3_A91CueCod, P005O3_A748ConCajSts, P005O3_A860CueDsc, P005O3_A375ConCajCod, P005O3_A747ConCajDsc
               }
               , new Object[] {
               P005O4_A91CueCod, P005O4_A748ConCajSts, P005O4_A860CueDsc, P005O4_A375ConCajCod, P005O4_A747ConCajDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 ;
      private short AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 ;
      private short AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 ;
      private short A748ConCajSts ;
      private int AV54GXV1 ;
      private int AV10TFConCajCod ;
      private int AV11TFConCajCod_To ;
      private int AV70Bancos_conceptoscajachicawwds_15_tfconcajcod ;
      private int AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to ;
      private int AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels_Count ;
      private int A375ConCajCod ;
      private int AV23InsertIndex ;
      private long AV32count ;
      private string AV12TFConCajDsc ;
      private string AV13TFConCajDsc_Sel ;
      private string AV14TFCueCod ;
      private string AV15TFCueCod_Sel ;
      private string AV16TFCueDsc ;
      private string AV17TFCueDsc_Sel ;
      private string AV40ConCajDsc1 ;
      private string AV49CueCod1 ;
      private string AV44ConCajDsc2 ;
      private string AV50CueCod2 ;
      private string AV48ConCajDsc3 ;
      private string AV51CueCod3 ;
      private string AV58Bancos_conceptoscajachicawwds_3_concajdsc1 ;
      private string AV59Bancos_conceptoscajachicawwds_4_cuecod1 ;
      private string AV63Bancos_conceptoscajachicawwds_8_concajdsc2 ;
      private string AV64Bancos_conceptoscajachicawwds_9_cuecod2 ;
      private string AV68Bancos_conceptoscajachicawwds_13_concajdsc3 ;
      private string AV69Bancos_conceptoscajachicawwds_14_cuecod3 ;
      private string AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc ;
      private string AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel ;
      private string AV74Bancos_conceptoscajachicawwds_19_tfcuecod ;
      private string AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel ;
      private string AV76Bancos_conceptoscajachicawwds_21_tfcuedsc ;
      private string AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel ;
      private string scmdbuf ;
      private string lV58Bancos_conceptoscajachicawwds_3_concajdsc1 ;
      private string lV59Bancos_conceptoscajachicawwds_4_cuecod1 ;
      private string lV63Bancos_conceptoscajachicawwds_8_concajdsc2 ;
      private string lV64Bancos_conceptoscajachicawwds_9_cuecod2 ;
      private string lV68Bancos_conceptoscajachicawwds_13_concajdsc3 ;
      private string lV69Bancos_conceptoscajachicawwds_14_cuecod3 ;
      private string lV72Bancos_conceptoscajachicawwds_17_tfconcajdsc ;
      private string lV74Bancos_conceptoscajachicawwds_19_tfcuecod ;
      private string lV76Bancos_conceptoscajachicawwds_21_tfcuedsc ;
      private string A747ConCajDsc ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 ;
      private bool AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 ;
      private bool BRK5O2 ;
      private bool BRK5O4 ;
      private bool BRK5O6 ;
      private string AV26OptionsJson ;
      private string AV29OptionsDescJson ;
      private string AV31OptionIndexesJson ;
      private string AV18TFConCajSts_SelsJson ;
      private string AV22DDOName ;
      private string AV20SearchTxt ;
      private string AV21SearchTxtTo ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 ;
      private string AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 ;
      private string AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 ;
      private string AV24Option ;
      private GxSimpleCollection<short> AV19TFConCajSts_Sels ;
      private GxSimpleCollection<short> AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005O2_A747ConCajDsc ;
      private short[] P005O2_A748ConCajSts ;
      private string[] P005O2_A860CueDsc ;
      private int[] P005O2_A375ConCajCod ;
      private string[] P005O2_A91CueCod ;
      private string[] P005O3_A91CueCod ;
      private short[] P005O3_A748ConCajSts ;
      private string[] P005O3_A860CueDsc ;
      private int[] P005O3_A375ConCajCod ;
      private string[] P005O3_A747ConCajDsc ;
      private string[] P005O4_A91CueCod ;
      private short[] P005O4_A748ConCajSts ;
      private string[] P005O4_A860CueDsc ;
      private int[] P005O4_A375ConCajCod ;
      private string[] P005O4_A747ConCajDsc ;
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

   public class conceptoscajachicawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005O2( IGxContext context ,
                                             short A748ConCajSts ,
                                             GxSimpleCollection<short> AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels ,
                                             string AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 ,
                                             short AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 ,
                                             string AV58Bancos_conceptoscajachicawwds_3_concajdsc1 ,
                                             string AV59Bancos_conceptoscajachicawwds_4_cuecod1 ,
                                             bool AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 ,
                                             string AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 ,
                                             short AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 ,
                                             string AV63Bancos_conceptoscajachicawwds_8_concajdsc2 ,
                                             string AV64Bancos_conceptoscajachicawwds_9_cuecod2 ,
                                             bool AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 ,
                                             string AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 ,
                                             short AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 ,
                                             string AV68Bancos_conceptoscajachicawwds_13_concajdsc3 ,
                                             string AV69Bancos_conceptoscajachicawwds_14_cuecod3 ,
                                             int AV70Bancos_conceptoscajachicawwds_15_tfconcajcod ,
                                             int AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to ,
                                             string AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel ,
                                             string AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc ,
                                             string AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel ,
                                             string AV74Bancos_conceptoscajachicawwds_19_tfcuecod ,
                                             string AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel ,
                                             string AV76Bancos_conceptoscajachicawwds_21_tfcuedsc ,
                                             int AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels_Count ,
                                             string A747ConCajDsc ,
                                             string A91CueCod ,
                                             int A375ConCajCod ,
                                             string A860CueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[ConCajDsc], T1.[ConCajSts], T2.[CueDsc], T1.[ConCajCod], T1.[CueCod] FROM ([TSCONCEPTOCAJA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CONCAJDSC") == 0 ) && ( AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Bancos_conceptoscajachicawwds_3_concajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV58Bancos_conceptoscajachicawwds_3_concajdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CONCAJDSC") == 0 ) && ( AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Bancos_conceptoscajachicawwds_3_concajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like '%' + @lV58Bancos_conceptoscajachicawwds_3_concajdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Bancos_conceptoscajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV59Bancos_conceptoscajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Bancos_conceptoscajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV59Bancos_conceptoscajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CONCAJDSC") == 0 ) && ( AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_conceptoscajachicawwds_8_concajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV63Bancos_conceptoscajachicawwds_8_concajdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CONCAJDSC") == 0 ) && ( AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_conceptoscajachicawwds_8_concajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like '%' + @lV63Bancos_conceptoscajachicawwds_8_concajdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptoscajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV64Bancos_conceptoscajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptoscajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV64Bancos_conceptoscajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CONCAJDSC") == 0 ) && ( AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_conceptoscajachicawwds_13_concajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV68Bancos_conceptoscajachicawwds_13_concajdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CONCAJDSC") == 0 ) && ( AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_conceptoscajachicawwds_13_concajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like '%' + @lV68Bancos_conceptoscajachicawwds_13_concajdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptoscajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV69Bancos_conceptoscajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptoscajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV69Bancos_conceptoscajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV70Bancos_conceptoscajachicawwds_15_tfconcajcod) )
         {
            AddWhere(sWhereString, "(T1.[ConCajCod] >= @AV70Bancos_conceptoscajachicawwds_15_tfconcajcod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConCajCod] <= @AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV72Bancos_conceptoscajachicawwds_17_tfconcajdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] = @AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoscajachicawwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV74Bancos_conceptoscajachicawwds_19_tfcuecod)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_conceptoscajachicawwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV76Bancos_conceptoscajachicawwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels, "T1.[ConCajSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ConCajDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005O3( IGxContext context ,
                                             short A748ConCajSts ,
                                             GxSimpleCollection<short> AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels ,
                                             string AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 ,
                                             short AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 ,
                                             string AV58Bancos_conceptoscajachicawwds_3_concajdsc1 ,
                                             string AV59Bancos_conceptoscajachicawwds_4_cuecod1 ,
                                             bool AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 ,
                                             string AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 ,
                                             short AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 ,
                                             string AV63Bancos_conceptoscajachicawwds_8_concajdsc2 ,
                                             string AV64Bancos_conceptoscajachicawwds_9_cuecod2 ,
                                             bool AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 ,
                                             string AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 ,
                                             short AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 ,
                                             string AV68Bancos_conceptoscajachicawwds_13_concajdsc3 ,
                                             string AV69Bancos_conceptoscajachicawwds_14_cuecod3 ,
                                             int AV70Bancos_conceptoscajachicawwds_15_tfconcajcod ,
                                             int AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to ,
                                             string AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel ,
                                             string AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc ,
                                             string AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel ,
                                             string AV74Bancos_conceptoscajachicawwds_19_tfcuecod ,
                                             string AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel ,
                                             string AV76Bancos_conceptoscajachicawwds_21_tfcuedsc ,
                                             int AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels_Count ,
                                             string A747ConCajDsc ,
                                             string A91CueCod ,
                                             int A375ConCajCod ,
                                             string A860CueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CueCod], T1.[ConCajSts], T2.[CueDsc], T1.[ConCajCod], T1.[ConCajDsc] FROM ([TSCONCEPTOCAJA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CONCAJDSC") == 0 ) && ( AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Bancos_conceptoscajachicawwds_3_concajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV58Bancos_conceptoscajachicawwds_3_concajdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CONCAJDSC") == 0 ) && ( AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Bancos_conceptoscajachicawwds_3_concajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like '%' + @lV58Bancos_conceptoscajachicawwds_3_concajdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Bancos_conceptoscajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV59Bancos_conceptoscajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Bancos_conceptoscajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV59Bancos_conceptoscajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CONCAJDSC") == 0 ) && ( AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_conceptoscajachicawwds_8_concajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV63Bancos_conceptoscajachicawwds_8_concajdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CONCAJDSC") == 0 ) && ( AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_conceptoscajachicawwds_8_concajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like '%' + @lV63Bancos_conceptoscajachicawwds_8_concajdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptoscajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV64Bancos_conceptoscajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptoscajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV64Bancos_conceptoscajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CONCAJDSC") == 0 ) && ( AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_conceptoscajachicawwds_13_concajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV68Bancos_conceptoscajachicawwds_13_concajdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CONCAJDSC") == 0 ) && ( AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_conceptoscajachicawwds_13_concajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like '%' + @lV68Bancos_conceptoscajachicawwds_13_concajdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptoscajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV69Bancos_conceptoscajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptoscajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV69Bancos_conceptoscajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV70Bancos_conceptoscajachicawwds_15_tfconcajcod) )
         {
            AddWhere(sWhereString, "(T1.[ConCajCod] >= @AV70Bancos_conceptoscajachicawwds_15_tfconcajcod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConCajCod] <= @AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV72Bancos_conceptoscajachicawwds_17_tfconcajdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] = @AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoscajachicawwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV74Bancos_conceptoscajachicawwds_19_tfcuecod)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_conceptoscajachicawwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV76Bancos_conceptoscajachicawwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels, "T1.[ConCajSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P005O4( IGxContext context ,
                                             short A748ConCajSts ,
                                             GxSimpleCollection<short> AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels ,
                                             string AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1 ,
                                             short AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 ,
                                             string AV58Bancos_conceptoscajachicawwds_3_concajdsc1 ,
                                             string AV59Bancos_conceptoscajachicawwds_4_cuecod1 ,
                                             bool AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 ,
                                             string AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2 ,
                                             short AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 ,
                                             string AV63Bancos_conceptoscajachicawwds_8_concajdsc2 ,
                                             string AV64Bancos_conceptoscajachicawwds_9_cuecod2 ,
                                             bool AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 ,
                                             string AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3 ,
                                             short AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 ,
                                             string AV68Bancos_conceptoscajachicawwds_13_concajdsc3 ,
                                             string AV69Bancos_conceptoscajachicawwds_14_cuecod3 ,
                                             int AV70Bancos_conceptoscajachicawwds_15_tfconcajcod ,
                                             int AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to ,
                                             string AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel ,
                                             string AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc ,
                                             string AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel ,
                                             string AV74Bancos_conceptoscajachicawwds_19_tfcuecod ,
                                             string AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel ,
                                             string AV76Bancos_conceptoscajachicawwds_21_tfcuedsc ,
                                             int AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels_Count ,
                                             string A747ConCajDsc ,
                                             string A91CueCod ,
                                             int A375ConCajCod ,
                                             string A860CueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[CueCod], T1.[ConCajSts], T2.[CueDsc], T1.[ConCajCod], T1.[ConCajDsc] FROM ([TSCONCEPTOCAJA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CONCAJDSC") == 0 ) && ( AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Bancos_conceptoscajachicawwds_3_concajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV58Bancos_conceptoscajachicawwds_3_concajdsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CONCAJDSC") == 0 ) && ( AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Bancos_conceptoscajachicawwds_3_concajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like '%' + @lV58Bancos_conceptoscajachicawwds_3_concajdsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Bancos_conceptoscajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV59Bancos_conceptoscajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Bancos_conceptoscajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV57Bancos_conceptoscajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Bancos_conceptoscajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV59Bancos_conceptoscajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CONCAJDSC") == 0 ) && ( AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_conceptoscajachicawwds_8_concajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV63Bancos_conceptoscajachicawwds_8_concajdsc2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CONCAJDSC") == 0 ) && ( AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_conceptoscajachicawwds_8_concajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like '%' + @lV63Bancos_conceptoscajachicawwds_8_concajdsc2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptoscajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV64Bancos_conceptoscajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV60Bancos_conceptoscajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Bancos_conceptoscajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV62Bancos_conceptoscajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancos_conceptoscajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV64Bancos_conceptoscajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CONCAJDSC") == 0 ) && ( AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_conceptoscajachicawwds_13_concajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV68Bancos_conceptoscajachicawwds_13_concajdsc3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CONCAJDSC") == 0 ) && ( AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_conceptoscajachicawwds_13_concajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like '%' + @lV68Bancos_conceptoscajachicawwds_13_concajdsc3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptoscajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV69Bancos_conceptoscajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV65Bancos_conceptoscajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Bancos_conceptoscajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV67Bancos_conceptoscajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_conceptoscajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV69Bancos_conceptoscajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (0==AV70Bancos_conceptoscajachicawwds_15_tfconcajcod) )
         {
            AddWhere(sWhereString, "(T1.[ConCajCod] >= @AV70Bancos_conceptoscajachicawwds_15_tfconcajcod)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (0==AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to) )
         {
            AddWhere(sWhereString, "(T1.[ConCajCod] <= @AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_conceptoscajachicawwds_17_tfconcajdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] like @lV72Bancos_conceptoscajachicawwds_17_tfconcajdsc)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ConCajDsc] = @AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_conceptoscajachicawwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV74Bancos_conceptoscajachicawwds_19_tfcuecod)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_conceptoscajachicawwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV76Bancos_conceptoscajachicawwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Bancos_conceptoscajachicawwds_23_tfconcajsts_sels, "T1.[ConCajSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod]";
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
                     return conditional_P005O2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
               case 1 :
                     return conditional_P005O3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
               case 2 :
                     return conditional_P005O4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP005O2;
          prmP005O2 = new Object[] {
          new ParDef("@lV58Bancos_conceptoscajachicawwds_3_concajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Bancos_conceptoscajachicawwds_3_concajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Bancos_conceptoscajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV59Bancos_conceptoscajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV63Bancos_conceptoscajachicawwds_8_concajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Bancos_conceptoscajachicawwds_8_concajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV64Bancos_conceptoscajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV64Bancos_conceptoscajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV68Bancos_conceptoscajachicawwds_13_concajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Bancos_conceptoscajachicawwds_13_concajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Bancos_conceptoscajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV69Bancos_conceptoscajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV70Bancos_conceptoscajachicawwds_15_tfconcajcod",GXType.Int32,6,0) ,
          new ParDef("@AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV72Bancos_conceptoscajachicawwds_17_tfconcajdsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV74Bancos_conceptoscajachicawwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV76Bancos_conceptoscajachicawwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP005O3;
          prmP005O3 = new Object[] {
          new ParDef("@lV58Bancos_conceptoscajachicawwds_3_concajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Bancos_conceptoscajachicawwds_3_concajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Bancos_conceptoscajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV59Bancos_conceptoscajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV63Bancos_conceptoscajachicawwds_8_concajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Bancos_conceptoscajachicawwds_8_concajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV64Bancos_conceptoscajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV64Bancos_conceptoscajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV68Bancos_conceptoscajachicawwds_13_concajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Bancos_conceptoscajachicawwds_13_concajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Bancos_conceptoscajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV69Bancos_conceptoscajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV70Bancos_conceptoscajachicawwds_15_tfconcajcod",GXType.Int32,6,0) ,
          new ParDef("@AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV72Bancos_conceptoscajachicawwds_17_tfconcajdsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV74Bancos_conceptoscajachicawwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV76Bancos_conceptoscajachicawwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP005O4;
          prmP005O4 = new Object[] {
          new ParDef("@lV58Bancos_conceptoscajachicawwds_3_concajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Bancos_conceptoscajachicawwds_3_concajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Bancos_conceptoscajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV59Bancos_conceptoscajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV63Bancos_conceptoscajachicawwds_8_concajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Bancos_conceptoscajachicawwds_8_concajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV64Bancos_conceptoscajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV64Bancos_conceptoscajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV68Bancos_conceptoscajachicawwds_13_concajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Bancos_conceptoscajachicawwds_13_concajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Bancos_conceptoscajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV69Bancos_conceptoscajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV70Bancos_conceptoscajachicawwds_15_tfconcajcod",GXType.Int32,6,0) ,
          new ParDef("@AV71Bancos_conceptoscajachicawwds_16_tfconcajcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV72Bancos_conceptoscajachicawwds_17_tfconcajdsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Bancos_conceptoscajachicawwds_18_tfconcajdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV74Bancos_conceptoscajachicawwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV75Bancos_conceptoscajachicawwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV76Bancos_conceptoscajachicawwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV77Bancos_conceptoscajachicawwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005O2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005O3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005O3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005O4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005O4,100, GxCacheFrequency.OFF ,true,false )
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
