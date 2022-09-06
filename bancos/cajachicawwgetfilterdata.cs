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
   public class cajachicawwgetfilterdata : GXProcedure
   {
      public cajachicawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cajachicawwgetfilterdata( IGxContext context )
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
         cajachicawwgetfilterdata objcajachicawwgetfilterdata;
         objcajachicawwgetfilterdata = new cajachicawwgetfilterdata();
         objcajachicawwgetfilterdata.AV22DDOName = aP0_DDOName;
         objcajachicawwgetfilterdata.AV20SearchTxt = aP1_SearchTxt;
         objcajachicawwgetfilterdata.AV21SearchTxtTo = aP2_SearchTxtTo;
         objcajachicawwgetfilterdata.AV26OptionsJson = "" ;
         objcajachicawwgetfilterdata.AV29OptionsDescJson = "" ;
         objcajachicawwgetfilterdata.AV31OptionIndexesJson = "" ;
         objcajachicawwgetfilterdata.context.SetSubmitInitialConfig(context);
         objcajachicawwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcajachicawwgetfilterdata);
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cajachicawwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_CAJDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCAJDSCOPTIONS' */
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
         if ( StringUtil.StrCmp(AV33Session.Get("Bancos.CajaChicaWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.CajaChicaWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Bancos.CajaChicaWWGridState"), null, "", "");
         }
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV58GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCAJCOD") == 0 )
            {
               AV10TFCajCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV11TFCajCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCAJDSC") == 0 )
            {
               AV12TFCajDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCAJDSC_SEL") == 0 )
            {
               AV13TFCajDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV16TFCueCod = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV17TFCueCod_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV51TFCueDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV52TFCueDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCAJSTS_SEL") == 0 )
            {
               AV49TFCajSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV50TFCajSts_Sels.FromJSonString(AV49TFCajSts_SelsJson, null);
            }
            AV58GXV1 = (int)(AV58GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "CAJDSC") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV40CajDsc1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "CUECOD") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV53CueCod1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "CAJDSC") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV44CajDsc2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "CUECOD") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV54CueCod2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "CAJDSC") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV48CajDsc3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "CUECOD") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV55CueCod3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCAJDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFCajDsc = AV20SearchTxt;
         AV13TFCajDsc_Sel = "";
         AV60Bancos_cajachicawwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV62Bancos_cajachicawwds_3_cajdsc1 = AV40CajDsc1;
         AV63Bancos_cajachicawwds_4_cuecod1 = AV53CueCod1;
         AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV65Bancos_cajachicawwds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV67Bancos_cajachicawwds_8_cajdsc2 = AV44CajDsc2;
         AV68Bancos_cajachicawwds_9_cuecod2 = AV54CueCod2;
         AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV70Bancos_cajachicawwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV72Bancos_cajachicawwds_13_cajdsc3 = AV48CajDsc3;
         AV73Bancos_cajachicawwds_14_cuecod3 = AV55CueCod3;
         AV74Bancos_cajachicawwds_15_tfcajcod = AV10TFCajCod;
         AV75Bancos_cajachicawwds_16_tfcajcod_to = AV11TFCajCod_To;
         AV76Bancos_cajachicawwds_17_tfcajdsc = AV12TFCajDsc;
         AV77Bancos_cajachicawwds_18_tfcajdsc_sel = AV13TFCajDsc_Sel;
         AV78Bancos_cajachicawwds_19_tfcuecod = AV16TFCueCod;
         AV79Bancos_cajachicawwds_20_tfcuecod_sel = AV17TFCueCod_Sel;
         AV80Bancos_cajachicawwds_21_tfcuedsc = AV51TFCueDsc;
         AV81Bancos_cajachicawwds_22_tfcuedsc_sel = AV52TFCueDsc_Sel;
         AV82Bancos_cajachicawwds_23_tfcajsts_sels = AV50TFCajSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A487CajSts ,
                                              AV82Bancos_cajachicawwds_23_tfcajsts_sels ,
                                              AV60Bancos_cajachicawwds_1_dynamicfiltersselector1 ,
                                              AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 ,
                                              AV62Bancos_cajachicawwds_3_cajdsc1 ,
                                              AV63Bancos_cajachicawwds_4_cuecod1 ,
                                              AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 ,
                                              AV65Bancos_cajachicawwds_6_dynamicfiltersselector2 ,
                                              AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 ,
                                              AV67Bancos_cajachicawwds_8_cajdsc2 ,
                                              AV68Bancos_cajachicawwds_9_cuecod2 ,
                                              AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 ,
                                              AV70Bancos_cajachicawwds_11_dynamicfiltersselector3 ,
                                              AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 ,
                                              AV72Bancos_cajachicawwds_13_cajdsc3 ,
                                              AV73Bancos_cajachicawwds_14_cuecod3 ,
                                              AV74Bancos_cajachicawwds_15_tfcajcod ,
                                              AV75Bancos_cajachicawwds_16_tfcajcod_to ,
                                              AV77Bancos_cajachicawwds_18_tfcajdsc_sel ,
                                              AV76Bancos_cajachicawwds_17_tfcajdsc ,
                                              AV79Bancos_cajachicawwds_20_tfcuecod_sel ,
                                              AV78Bancos_cajachicawwds_19_tfcuecod ,
                                              AV81Bancos_cajachicawwds_22_tfcuedsc_sel ,
                                              AV80Bancos_cajachicawwds_21_tfcuedsc ,
                                              AV82Bancos_cajachicawwds_23_tfcajsts_sels.Count ,
                                              A486CajDsc ,
                                              A91CueCod ,
                                              A358CajCod ,
                                              A860CueDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV62Bancos_cajachicawwds_3_cajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Bancos_cajachicawwds_3_cajdsc1), 100, "%");
         lV62Bancos_cajachicawwds_3_cajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Bancos_cajachicawwds_3_cajdsc1), 100, "%");
         lV63Bancos_cajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_cajachicawwds_4_cuecod1), 15, "%");
         lV63Bancos_cajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_cajachicawwds_4_cuecod1), 15, "%");
         lV67Bancos_cajachicawwds_8_cajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV67Bancos_cajachicawwds_8_cajdsc2), 100, "%");
         lV67Bancos_cajachicawwds_8_cajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV67Bancos_cajachicawwds_8_cajdsc2), 100, "%");
         lV68Bancos_cajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_cajachicawwds_9_cuecod2), 15, "%");
         lV68Bancos_cajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_cajachicawwds_9_cuecod2), 15, "%");
         lV72Bancos_cajachicawwds_13_cajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_cajachicawwds_13_cajdsc3), 100, "%");
         lV72Bancos_cajachicawwds_13_cajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_cajachicawwds_13_cajdsc3), 100, "%");
         lV73Bancos_cajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_cajachicawwds_14_cuecod3), 15, "%");
         lV73Bancos_cajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_cajachicawwds_14_cuecod3), 15, "%");
         lV76Bancos_cajachicawwds_17_tfcajdsc = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_cajachicawwds_17_tfcajdsc), 100, "%");
         lV78Bancos_cajachicawwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_cajachicawwds_19_tfcuecod), 15, "%");
         lV80Bancos_cajachicawwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV80Bancos_cajachicawwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005K2 */
         pr_default.execute(0, new Object[] {lV62Bancos_cajachicawwds_3_cajdsc1, lV62Bancos_cajachicawwds_3_cajdsc1, lV63Bancos_cajachicawwds_4_cuecod1, lV63Bancos_cajachicawwds_4_cuecod1, lV67Bancos_cajachicawwds_8_cajdsc2, lV67Bancos_cajachicawwds_8_cajdsc2, lV68Bancos_cajachicawwds_9_cuecod2, lV68Bancos_cajachicawwds_9_cuecod2, lV72Bancos_cajachicawwds_13_cajdsc3, lV72Bancos_cajachicawwds_13_cajdsc3, lV73Bancos_cajachicawwds_14_cuecod3, lV73Bancos_cajachicawwds_14_cuecod3, AV74Bancos_cajachicawwds_15_tfcajcod, AV75Bancos_cajachicawwds_16_tfcajcod_to, lV76Bancos_cajachicawwds_17_tfcajdsc, AV77Bancos_cajachicawwds_18_tfcajdsc_sel, lV78Bancos_cajachicawwds_19_tfcuecod, AV79Bancos_cajachicawwds_20_tfcuecod_sel, lV80Bancos_cajachicawwds_21_tfcuedsc, AV81Bancos_cajachicawwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5K2 = false;
            A486CajDsc = P005K2_A486CajDsc[0];
            A487CajSts = P005K2_A487CajSts[0];
            A860CueDsc = P005K2_A860CueDsc[0];
            A358CajCod = P005K2_A358CajCod[0];
            A91CueCod = P005K2_A91CueCod[0];
            A860CueDsc = P005K2_A860CueDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005K2_A486CajDsc[0], A486CajDsc) == 0 ) )
            {
               BRK5K2 = false;
               A358CajCod = P005K2_A358CajCod[0];
               AV32count = (long)(AV32count+1);
               BRK5K2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A486CajDsc)) )
            {
               AV24Option = A486CajDsc;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK5K2 )
            {
               BRK5K2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCUECODOPTIONS' Routine */
         returnInSub = false;
         AV16TFCueCod = AV20SearchTxt;
         AV17TFCueCod_Sel = "";
         AV60Bancos_cajachicawwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV62Bancos_cajachicawwds_3_cajdsc1 = AV40CajDsc1;
         AV63Bancos_cajachicawwds_4_cuecod1 = AV53CueCod1;
         AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV65Bancos_cajachicawwds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV67Bancos_cajachicawwds_8_cajdsc2 = AV44CajDsc2;
         AV68Bancos_cajachicawwds_9_cuecod2 = AV54CueCod2;
         AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV70Bancos_cajachicawwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV72Bancos_cajachicawwds_13_cajdsc3 = AV48CajDsc3;
         AV73Bancos_cajachicawwds_14_cuecod3 = AV55CueCod3;
         AV74Bancos_cajachicawwds_15_tfcajcod = AV10TFCajCod;
         AV75Bancos_cajachicawwds_16_tfcajcod_to = AV11TFCajCod_To;
         AV76Bancos_cajachicawwds_17_tfcajdsc = AV12TFCajDsc;
         AV77Bancos_cajachicawwds_18_tfcajdsc_sel = AV13TFCajDsc_Sel;
         AV78Bancos_cajachicawwds_19_tfcuecod = AV16TFCueCod;
         AV79Bancos_cajachicawwds_20_tfcuecod_sel = AV17TFCueCod_Sel;
         AV80Bancos_cajachicawwds_21_tfcuedsc = AV51TFCueDsc;
         AV81Bancos_cajachicawwds_22_tfcuedsc_sel = AV52TFCueDsc_Sel;
         AV82Bancos_cajachicawwds_23_tfcajsts_sels = AV50TFCajSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A487CajSts ,
                                              AV82Bancos_cajachicawwds_23_tfcajsts_sels ,
                                              AV60Bancos_cajachicawwds_1_dynamicfiltersselector1 ,
                                              AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 ,
                                              AV62Bancos_cajachicawwds_3_cajdsc1 ,
                                              AV63Bancos_cajachicawwds_4_cuecod1 ,
                                              AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 ,
                                              AV65Bancos_cajachicawwds_6_dynamicfiltersselector2 ,
                                              AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 ,
                                              AV67Bancos_cajachicawwds_8_cajdsc2 ,
                                              AV68Bancos_cajachicawwds_9_cuecod2 ,
                                              AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 ,
                                              AV70Bancos_cajachicawwds_11_dynamicfiltersselector3 ,
                                              AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 ,
                                              AV72Bancos_cajachicawwds_13_cajdsc3 ,
                                              AV73Bancos_cajachicawwds_14_cuecod3 ,
                                              AV74Bancos_cajachicawwds_15_tfcajcod ,
                                              AV75Bancos_cajachicawwds_16_tfcajcod_to ,
                                              AV77Bancos_cajachicawwds_18_tfcajdsc_sel ,
                                              AV76Bancos_cajachicawwds_17_tfcajdsc ,
                                              AV79Bancos_cajachicawwds_20_tfcuecod_sel ,
                                              AV78Bancos_cajachicawwds_19_tfcuecod ,
                                              AV81Bancos_cajachicawwds_22_tfcuedsc_sel ,
                                              AV80Bancos_cajachicawwds_21_tfcuedsc ,
                                              AV82Bancos_cajachicawwds_23_tfcajsts_sels.Count ,
                                              A486CajDsc ,
                                              A91CueCod ,
                                              A358CajCod ,
                                              A860CueDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV62Bancos_cajachicawwds_3_cajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Bancos_cajachicawwds_3_cajdsc1), 100, "%");
         lV62Bancos_cajachicawwds_3_cajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Bancos_cajachicawwds_3_cajdsc1), 100, "%");
         lV63Bancos_cajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_cajachicawwds_4_cuecod1), 15, "%");
         lV63Bancos_cajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_cajachicawwds_4_cuecod1), 15, "%");
         lV67Bancos_cajachicawwds_8_cajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV67Bancos_cajachicawwds_8_cajdsc2), 100, "%");
         lV67Bancos_cajachicawwds_8_cajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV67Bancos_cajachicawwds_8_cajdsc2), 100, "%");
         lV68Bancos_cajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_cajachicawwds_9_cuecod2), 15, "%");
         lV68Bancos_cajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_cajachicawwds_9_cuecod2), 15, "%");
         lV72Bancos_cajachicawwds_13_cajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_cajachicawwds_13_cajdsc3), 100, "%");
         lV72Bancos_cajachicawwds_13_cajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_cajachicawwds_13_cajdsc3), 100, "%");
         lV73Bancos_cajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_cajachicawwds_14_cuecod3), 15, "%");
         lV73Bancos_cajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_cajachicawwds_14_cuecod3), 15, "%");
         lV76Bancos_cajachicawwds_17_tfcajdsc = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_cajachicawwds_17_tfcajdsc), 100, "%");
         lV78Bancos_cajachicawwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_cajachicawwds_19_tfcuecod), 15, "%");
         lV80Bancos_cajachicawwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV80Bancos_cajachicawwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005K3 */
         pr_default.execute(1, new Object[] {lV62Bancos_cajachicawwds_3_cajdsc1, lV62Bancos_cajachicawwds_3_cajdsc1, lV63Bancos_cajachicawwds_4_cuecod1, lV63Bancos_cajachicawwds_4_cuecod1, lV67Bancos_cajachicawwds_8_cajdsc2, lV67Bancos_cajachicawwds_8_cajdsc2, lV68Bancos_cajachicawwds_9_cuecod2, lV68Bancos_cajachicawwds_9_cuecod2, lV72Bancos_cajachicawwds_13_cajdsc3, lV72Bancos_cajachicawwds_13_cajdsc3, lV73Bancos_cajachicawwds_14_cuecod3, lV73Bancos_cajachicawwds_14_cuecod3, AV74Bancos_cajachicawwds_15_tfcajcod, AV75Bancos_cajachicawwds_16_tfcajcod_to, lV76Bancos_cajachicawwds_17_tfcajdsc, AV77Bancos_cajachicawwds_18_tfcajdsc_sel, lV78Bancos_cajachicawwds_19_tfcuecod, AV79Bancos_cajachicawwds_20_tfcuecod_sel, lV80Bancos_cajachicawwds_21_tfcuedsc, AV81Bancos_cajachicawwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5K4 = false;
            A91CueCod = P005K3_A91CueCod[0];
            A487CajSts = P005K3_A487CajSts[0];
            A860CueDsc = P005K3_A860CueDsc[0];
            A358CajCod = P005K3_A358CajCod[0];
            A486CajDsc = P005K3_A486CajDsc[0];
            A860CueDsc = P005K3_A860CueDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005K3_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRK5K4 = false;
               A358CajCod = P005K3_A358CajCod[0];
               AV32count = (long)(AV32count+1);
               BRK5K4 = true;
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
            if ( ! BRK5K4 )
            {
               BRK5K4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCUEDSCOPTIONS' Routine */
         returnInSub = false;
         AV51TFCueDsc = AV20SearchTxt;
         AV52TFCueDsc_Sel = "";
         AV60Bancos_cajachicawwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV62Bancos_cajachicawwds_3_cajdsc1 = AV40CajDsc1;
         AV63Bancos_cajachicawwds_4_cuecod1 = AV53CueCod1;
         AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV65Bancos_cajachicawwds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV67Bancos_cajachicawwds_8_cajdsc2 = AV44CajDsc2;
         AV68Bancos_cajachicawwds_9_cuecod2 = AV54CueCod2;
         AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV70Bancos_cajachicawwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV72Bancos_cajachicawwds_13_cajdsc3 = AV48CajDsc3;
         AV73Bancos_cajachicawwds_14_cuecod3 = AV55CueCod3;
         AV74Bancos_cajachicawwds_15_tfcajcod = AV10TFCajCod;
         AV75Bancos_cajachicawwds_16_tfcajcod_to = AV11TFCajCod_To;
         AV76Bancos_cajachicawwds_17_tfcajdsc = AV12TFCajDsc;
         AV77Bancos_cajachicawwds_18_tfcajdsc_sel = AV13TFCajDsc_Sel;
         AV78Bancos_cajachicawwds_19_tfcuecod = AV16TFCueCod;
         AV79Bancos_cajachicawwds_20_tfcuecod_sel = AV17TFCueCod_Sel;
         AV80Bancos_cajachicawwds_21_tfcuedsc = AV51TFCueDsc;
         AV81Bancos_cajachicawwds_22_tfcuedsc_sel = AV52TFCueDsc_Sel;
         AV82Bancos_cajachicawwds_23_tfcajsts_sels = AV50TFCajSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A487CajSts ,
                                              AV82Bancos_cajachicawwds_23_tfcajsts_sels ,
                                              AV60Bancos_cajachicawwds_1_dynamicfiltersselector1 ,
                                              AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 ,
                                              AV62Bancos_cajachicawwds_3_cajdsc1 ,
                                              AV63Bancos_cajachicawwds_4_cuecod1 ,
                                              AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 ,
                                              AV65Bancos_cajachicawwds_6_dynamicfiltersselector2 ,
                                              AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 ,
                                              AV67Bancos_cajachicawwds_8_cajdsc2 ,
                                              AV68Bancos_cajachicawwds_9_cuecod2 ,
                                              AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 ,
                                              AV70Bancos_cajachicawwds_11_dynamicfiltersselector3 ,
                                              AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 ,
                                              AV72Bancos_cajachicawwds_13_cajdsc3 ,
                                              AV73Bancos_cajachicawwds_14_cuecod3 ,
                                              AV74Bancos_cajachicawwds_15_tfcajcod ,
                                              AV75Bancos_cajachicawwds_16_tfcajcod_to ,
                                              AV77Bancos_cajachicawwds_18_tfcajdsc_sel ,
                                              AV76Bancos_cajachicawwds_17_tfcajdsc ,
                                              AV79Bancos_cajachicawwds_20_tfcuecod_sel ,
                                              AV78Bancos_cajachicawwds_19_tfcuecod ,
                                              AV81Bancos_cajachicawwds_22_tfcuedsc_sel ,
                                              AV80Bancos_cajachicawwds_21_tfcuedsc ,
                                              AV82Bancos_cajachicawwds_23_tfcajsts_sels.Count ,
                                              A486CajDsc ,
                                              A91CueCod ,
                                              A358CajCod ,
                                              A860CueDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV62Bancos_cajachicawwds_3_cajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Bancos_cajachicawwds_3_cajdsc1), 100, "%");
         lV62Bancos_cajachicawwds_3_cajdsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Bancos_cajachicawwds_3_cajdsc1), 100, "%");
         lV63Bancos_cajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_cajachicawwds_4_cuecod1), 15, "%");
         lV63Bancos_cajachicawwds_4_cuecod1 = StringUtil.PadR( StringUtil.RTrim( AV63Bancos_cajachicawwds_4_cuecod1), 15, "%");
         lV67Bancos_cajachicawwds_8_cajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV67Bancos_cajachicawwds_8_cajdsc2), 100, "%");
         lV67Bancos_cajachicawwds_8_cajdsc2 = StringUtil.PadR( StringUtil.RTrim( AV67Bancos_cajachicawwds_8_cajdsc2), 100, "%");
         lV68Bancos_cajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_cajachicawwds_9_cuecod2), 15, "%");
         lV68Bancos_cajachicawwds_9_cuecod2 = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_cajachicawwds_9_cuecod2), 15, "%");
         lV72Bancos_cajachicawwds_13_cajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_cajachicawwds_13_cajdsc3), 100, "%");
         lV72Bancos_cajachicawwds_13_cajdsc3 = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_cajachicawwds_13_cajdsc3), 100, "%");
         lV73Bancos_cajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_cajachicawwds_14_cuecod3), 15, "%");
         lV73Bancos_cajachicawwds_14_cuecod3 = StringUtil.PadR( StringUtil.RTrim( AV73Bancos_cajachicawwds_14_cuecod3), 15, "%");
         lV76Bancos_cajachicawwds_17_tfcajdsc = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_cajachicawwds_17_tfcajdsc), 100, "%");
         lV78Bancos_cajachicawwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_cajachicawwds_19_tfcuecod), 15, "%");
         lV80Bancos_cajachicawwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV80Bancos_cajachicawwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005K4 */
         pr_default.execute(2, new Object[] {lV62Bancos_cajachicawwds_3_cajdsc1, lV62Bancos_cajachicawwds_3_cajdsc1, lV63Bancos_cajachicawwds_4_cuecod1, lV63Bancos_cajachicawwds_4_cuecod1, lV67Bancos_cajachicawwds_8_cajdsc2, lV67Bancos_cajachicawwds_8_cajdsc2, lV68Bancos_cajachicawwds_9_cuecod2, lV68Bancos_cajachicawwds_9_cuecod2, lV72Bancos_cajachicawwds_13_cajdsc3, lV72Bancos_cajachicawwds_13_cajdsc3, lV73Bancos_cajachicawwds_14_cuecod3, lV73Bancos_cajachicawwds_14_cuecod3, AV74Bancos_cajachicawwds_15_tfcajcod, AV75Bancos_cajachicawwds_16_tfcajcod_to, lV76Bancos_cajachicawwds_17_tfcajdsc, AV77Bancos_cajachicawwds_18_tfcajdsc_sel, lV78Bancos_cajachicawwds_19_tfcuecod, AV79Bancos_cajachicawwds_20_tfcuecod_sel, lV80Bancos_cajachicawwds_21_tfcuedsc, AV81Bancos_cajachicawwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5K6 = false;
            A860CueDsc = P005K4_A860CueDsc[0];
            A487CajSts = P005K4_A487CajSts[0];
            A358CajCod = P005K4_A358CajCod[0];
            A91CueCod = P005K4_A91CueCod[0];
            A486CajDsc = P005K4_A486CajDsc[0];
            A860CueDsc = P005K4_A860CueDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005K4_A860CueDsc[0], A860CueDsc) == 0 ) )
            {
               BRK5K6 = false;
               A358CajCod = P005K4_A358CajCod[0];
               A91CueCod = P005K4_A91CueCod[0];
               AV32count = (long)(AV32count+1);
               BRK5K6 = true;
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
            if ( ! BRK5K6 )
            {
               BRK5K6 = true;
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
         AV12TFCajDsc = "";
         AV13TFCajDsc_Sel = "";
         AV16TFCueCod = "";
         AV17TFCueCod_Sel = "";
         AV51TFCueDsc = "";
         AV52TFCueDsc_Sel = "";
         AV49TFCajSts_SelsJson = "";
         AV50TFCajSts_Sels = new GxSimpleCollection<short>();
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40CajDsc1 = "";
         AV53CueCod1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44CajDsc2 = "";
         AV54CueCod2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48CajDsc3 = "";
         AV55CueCod3 = "";
         AV60Bancos_cajachicawwds_1_dynamicfiltersselector1 = "";
         AV62Bancos_cajachicawwds_3_cajdsc1 = "";
         AV63Bancos_cajachicawwds_4_cuecod1 = "";
         AV65Bancos_cajachicawwds_6_dynamicfiltersselector2 = "";
         AV67Bancos_cajachicawwds_8_cajdsc2 = "";
         AV68Bancos_cajachicawwds_9_cuecod2 = "";
         AV70Bancos_cajachicawwds_11_dynamicfiltersselector3 = "";
         AV72Bancos_cajachicawwds_13_cajdsc3 = "";
         AV73Bancos_cajachicawwds_14_cuecod3 = "";
         AV76Bancos_cajachicawwds_17_tfcajdsc = "";
         AV77Bancos_cajachicawwds_18_tfcajdsc_sel = "";
         AV78Bancos_cajachicawwds_19_tfcuecod = "";
         AV79Bancos_cajachicawwds_20_tfcuecod_sel = "";
         AV80Bancos_cajachicawwds_21_tfcuedsc = "";
         AV81Bancos_cajachicawwds_22_tfcuedsc_sel = "";
         AV82Bancos_cajachicawwds_23_tfcajsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV62Bancos_cajachicawwds_3_cajdsc1 = "";
         lV63Bancos_cajachicawwds_4_cuecod1 = "";
         lV67Bancos_cajachicawwds_8_cajdsc2 = "";
         lV68Bancos_cajachicawwds_9_cuecod2 = "";
         lV72Bancos_cajachicawwds_13_cajdsc3 = "";
         lV73Bancos_cajachicawwds_14_cuecod3 = "";
         lV76Bancos_cajachicawwds_17_tfcajdsc = "";
         lV78Bancos_cajachicawwds_19_tfcuecod = "";
         lV80Bancos_cajachicawwds_21_tfcuedsc = "";
         A486CajDsc = "";
         A91CueCod = "";
         A860CueDsc = "";
         P005K2_A486CajDsc = new string[] {""} ;
         P005K2_A487CajSts = new short[1] ;
         P005K2_A860CueDsc = new string[] {""} ;
         P005K2_A358CajCod = new int[1] ;
         P005K2_A91CueCod = new string[] {""} ;
         AV24Option = "";
         P005K3_A91CueCod = new string[] {""} ;
         P005K3_A487CajSts = new short[1] ;
         P005K3_A860CueDsc = new string[] {""} ;
         P005K3_A358CajCod = new int[1] ;
         P005K3_A486CajDsc = new string[] {""} ;
         P005K4_A860CueDsc = new string[] {""} ;
         P005K4_A487CajSts = new short[1] ;
         P005K4_A358CajCod = new int[1] ;
         P005K4_A91CueCod = new string[] {""} ;
         P005K4_A486CajDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.cajachicawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005K2_A486CajDsc, P005K2_A487CajSts, P005K2_A860CueDsc, P005K2_A358CajCod, P005K2_A91CueCod
               }
               , new Object[] {
               P005K3_A91CueCod, P005K3_A487CajSts, P005K3_A860CueDsc, P005K3_A358CajCod, P005K3_A486CajDsc
               }
               , new Object[] {
               P005K4_A860CueDsc, P005K4_A487CajSts, P005K4_A358CajCod, P005K4_A91CueCod, P005K4_A486CajDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 ;
      private short AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 ;
      private short AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 ;
      private short A487CajSts ;
      private int AV58GXV1 ;
      private int AV10TFCajCod ;
      private int AV11TFCajCod_To ;
      private int AV74Bancos_cajachicawwds_15_tfcajcod ;
      private int AV75Bancos_cajachicawwds_16_tfcajcod_to ;
      private int AV82Bancos_cajachicawwds_23_tfcajsts_sels_Count ;
      private int A358CajCod ;
      private long AV32count ;
      private string AV12TFCajDsc ;
      private string AV13TFCajDsc_Sel ;
      private string AV16TFCueCod ;
      private string AV17TFCueCod_Sel ;
      private string AV51TFCueDsc ;
      private string AV52TFCueDsc_Sel ;
      private string AV40CajDsc1 ;
      private string AV53CueCod1 ;
      private string AV44CajDsc2 ;
      private string AV54CueCod2 ;
      private string AV48CajDsc3 ;
      private string AV55CueCod3 ;
      private string AV62Bancos_cajachicawwds_3_cajdsc1 ;
      private string AV63Bancos_cajachicawwds_4_cuecod1 ;
      private string AV67Bancos_cajachicawwds_8_cajdsc2 ;
      private string AV68Bancos_cajachicawwds_9_cuecod2 ;
      private string AV72Bancos_cajachicawwds_13_cajdsc3 ;
      private string AV73Bancos_cajachicawwds_14_cuecod3 ;
      private string AV76Bancos_cajachicawwds_17_tfcajdsc ;
      private string AV77Bancos_cajachicawwds_18_tfcajdsc_sel ;
      private string AV78Bancos_cajachicawwds_19_tfcuecod ;
      private string AV79Bancos_cajachicawwds_20_tfcuecod_sel ;
      private string AV80Bancos_cajachicawwds_21_tfcuedsc ;
      private string AV81Bancos_cajachicawwds_22_tfcuedsc_sel ;
      private string scmdbuf ;
      private string lV62Bancos_cajachicawwds_3_cajdsc1 ;
      private string lV63Bancos_cajachicawwds_4_cuecod1 ;
      private string lV67Bancos_cajachicawwds_8_cajdsc2 ;
      private string lV68Bancos_cajachicawwds_9_cuecod2 ;
      private string lV72Bancos_cajachicawwds_13_cajdsc3 ;
      private string lV73Bancos_cajachicawwds_14_cuecod3 ;
      private string lV76Bancos_cajachicawwds_17_tfcajdsc ;
      private string lV78Bancos_cajachicawwds_19_tfcuecod ;
      private string lV80Bancos_cajachicawwds_21_tfcuedsc ;
      private string A486CajDsc ;
      private string A91CueCod ;
      private string A860CueDsc ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 ;
      private bool AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 ;
      private bool BRK5K2 ;
      private bool BRK5K4 ;
      private bool BRK5K6 ;
      private string AV26OptionsJson ;
      private string AV29OptionsDescJson ;
      private string AV31OptionIndexesJson ;
      private string AV49TFCajSts_SelsJson ;
      private string AV22DDOName ;
      private string AV20SearchTxt ;
      private string AV21SearchTxtTo ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV60Bancos_cajachicawwds_1_dynamicfiltersselector1 ;
      private string AV65Bancos_cajachicawwds_6_dynamicfiltersselector2 ;
      private string AV70Bancos_cajachicawwds_11_dynamicfiltersselector3 ;
      private string AV24Option ;
      private GxSimpleCollection<short> AV50TFCajSts_Sels ;
      private GxSimpleCollection<short> AV82Bancos_cajachicawwds_23_tfcajsts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005K2_A486CajDsc ;
      private short[] P005K2_A487CajSts ;
      private string[] P005K2_A860CueDsc ;
      private int[] P005K2_A358CajCod ;
      private string[] P005K2_A91CueCod ;
      private string[] P005K3_A91CueCod ;
      private short[] P005K3_A487CajSts ;
      private string[] P005K3_A860CueDsc ;
      private int[] P005K3_A358CajCod ;
      private string[] P005K3_A486CajDsc ;
      private string[] P005K4_A860CueDsc ;
      private short[] P005K4_A487CajSts ;
      private int[] P005K4_A358CajCod ;
      private string[] P005K4_A91CueCod ;
      private string[] P005K4_A486CajDsc ;
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

   public class cajachicawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005K2( IGxContext context ,
                                             short A487CajSts ,
                                             GxSimpleCollection<short> AV82Bancos_cajachicawwds_23_tfcajsts_sels ,
                                             string AV60Bancos_cajachicawwds_1_dynamicfiltersselector1 ,
                                             short AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 ,
                                             string AV62Bancos_cajachicawwds_3_cajdsc1 ,
                                             string AV63Bancos_cajachicawwds_4_cuecod1 ,
                                             bool AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 ,
                                             string AV65Bancos_cajachicawwds_6_dynamicfiltersselector2 ,
                                             short AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 ,
                                             string AV67Bancos_cajachicawwds_8_cajdsc2 ,
                                             string AV68Bancos_cajachicawwds_9_cuecod2 ,
                                             bool AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 ,
                                             string AV70Bancos_cajachicawwds_11_dynamicfiltersselector3 ,
                                             short AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 ,
                                             string AV72Bancos_cajachicawwds_13_cajdsc3 ,
                                             string AV73Bancos_cajachicawwds_14_cuecod3 ,
                                             int AV74Bancos_cajachicawwds_15_tfcajcod ,
                                             int AV75Bancos_cajachicawwds_16_tfcajcod_to ,
                                             string AV77Bancos_cajachicawwds_18_tfcajdsc_sel ,
                                             string AV76Bancos_cajachicawwds_17_tfcajdsc ,
                                             string AV79Bancos_cajachicawwds_20_tfcuecod_sel ,
                                             string AV78Bancos_cajachicawwds_19_tfcuecod ,
                                             string AV81Bancos_cajachicawwds_22_tfcuedsc_sel ,
                                             string AV80Bancos_cajachicawwds_21_tfcuedsc ,
                                             int AV82Bancos_cajachicawwds_23_tfcajsts_sels_Count ,
                                             string A486CajDsc ,
                                             string A91CueCod ,
                                             int A358CajCod ,
                                             string A860CueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[CajDsc], T1.[CajSts], T2.[CueDsc], T1.[CajCod], T1.[CueCod] FROM ([TSCAJACHICA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV60Bancos_cajachicawwds_1_dynamicfiltersselector1, "CAJDSC") == 0 ) && ( AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Bancos_cajachicawwds_3_cajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV62Bancos_cajachicawwds_3_cajdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Bancos_cajachicawwds_1_dynamicfiltersselector1, "CAJDSC") == 0 ) && ( AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Bancos_cajachicawwds_3_cajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like '%' + @lV62Bancos_cajachicawwds_3_cajdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Bancos_cajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_cajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV63Bancos_cajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Bancos_cajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_cajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV63Bancos_cajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Bancos_cajachicawwds_6_dynamicfiltersselector2, "CAJDSC") == 0 ) && ( AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Bancos_cajachicawwds_8_cajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV67Bancos_cajachicawwds_8_cajdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Bancos_cajachicawwds_6_dynamicfiltersselector2, "CAJDSC") == 0 ) && ( AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Bancos_cajachicawwds_8_cajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like '%' + @lV67Bancos_cajachicawwds_8_cajdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Bancos_cajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_cajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV68Bancos_cajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Bancos_cajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_cajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV68Bancos_cajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Bancos_cajachicawwds_11_dynamicfiltersselector3, "CAJDSC") == 0 ) && ( AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_cajachicawwds_13_cajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV72Bancos_cajachicawwds_13_cajdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Bancos_cajachicawwds_11_dynamicfiltersselector3, "CAJDSC") == 0 ) && ( AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_cajachicawwds_13_cajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like '%' + @lV72Bancos_cajachicawwds_13_cajdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Bancos_cajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_cajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV73Bancos_cajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Bancos_cajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_cajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV73Bancos_cajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV74Bancos_cajachicawwds_15_tfcajcod) )
         {
            AddWhere(sWhereString, "(T1.[CajCod] >= @AV74Bancos_cajachicawwds_15_tfcajcod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV75Bancos_cajachicawwds_16_tfcajcod_to) )
         {
            AddWhere(sWhereString, "(T1.[CajCod] <= @AV75Bancos_cajachicawwds_16_tfcajcod_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_cajachicawwds_18_tfcajdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_cajachicawwds_17_tfcajdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV76Bancos_cajachicawwds_17_tfcajdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_cajachicawwds_18_tfcajdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] = @AV77Bancos_cajachicawwds_18_tfcajdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_cajachicawwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_cajachicawwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV78Bancos_cajachicawwds_19_tfcuecod)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_cajachicawwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV79Bancos_cajachicawwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Bancos_cajachicawwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Bancos_cajachicawwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV80Bancos_cajachicawwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Bancos_cajachicawwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV81Bancos_cajachicawwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV82Bancos_cajachicawwds_23_tfcajsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Bancos_cajachicawwds_23_tfcajsts_sels, "T1.[CajSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CajDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005K3( IGxContext context ,
                                             short A487CajSts ,
                                             GxSimpleCollection<short> AV82Bancos_cajachicawwds_23_tfcajsts_sels ,
                                             string AV60Bancos_cajachicawwds_1_dynamicfiltersselector1 ,
                                             short AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 ,
                                             string AV62Bancos_cajachicawwds_3_cajdsc1 ,
                                             string AV63Bancos_cajachicawwds_4_cuecod1 ,
                                             bool AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 ,
                                             string AV65Bancos_cajachicawwds_6_dynamicfiltersselector2 ,
                                             short AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 ,
                                             string AV67Bancos_cajachicawwds_8_cajdsc2 ,
                                             string AV68Bancos_cajachicawwds_9_cuecod2 ,
                                             bool AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 ,
                                             string AV70Bancos_cajachicawwds_11_dynamicfiltersselector3 ,
                                             short AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 ,
                                             string AV72Bancos_cajachicawwds_13_cajdsc3 ,
                                             string AV73Bancos_cajachicawwds_14_cuecod3 ,
                                             int AV74Bancos_cajachicawwds_15_tfcajcod ,
                                             int AV75Bancos_cajachicawwds_16_tfcajcod_to ,
                                             string AV77Bancos_cajachicawwds_18_tfcajdsc_sel ,
                                             string AV76Bancos_cajachicawwds_17_tfcajdsc ,
                                             string AV79Bancos_cajachicawwds_20_tfcuecod_sel ,
                                             string AV78Bancos_cajachicawwds_19_tfcuecod ,
                                             string AV81Bancos_cajachicawwds_22_tfcuedsc_sel ,
                                             string AV80Bancos_cajachicawwds_21_tfcuedsc ,
                                             int AV82Bancos_cajachicawwds_23_tfcajsts_sels_Count ,
                                             string A486CajDsc ,
                                             string A91CueCod ,
                                             int A358CajCod ,
                                             string A860CueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CueCod], T1.[CajSts], T2.[CueDsc], T1.[CajCod], T1.[CajDsc] FROM ([TSCAJACHICA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV60Bancos_cajachicawwds_1_dynamicfiltersselector1, "CAJDSC") == 0 ) && ( AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Bancos_cajachicawwds_3_cajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV62Bancos_cajachicawwds_3_cajdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Bancos_cajachicawwds_1_dynamicfiltersselector1, "CAJDSC") == 0 ) && ( AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Bancos_cajachicawwds_3_cajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like '%' + @lV62Bancos_cajachicawwds_3_cajdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Bancos_cajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_cajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV63Bancos_cajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Bancos_cajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_cajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV63Bancos_cajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Bancos_cajachicawwds_6_dynamicfiltersselector2, "CAJDSC") == 0 ) && ( AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Bancos_cajachicawwds_8_cajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV67Bancos_cajachicawwds_8_cajdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Bancos_cajachicawwds_6_dynamicfiltersselector2, "CAJDSC") == 0 ) && ( AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Bancos_cajachicawwds_8_cajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like '%' + @lV67Bancos_cajachicawwds_8_cajdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Bancos_cajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_cajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV68Bancos_cajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Bancos_cajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_cajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV68Bancos_cajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Bancos_cajachicawwds_11_dynamicfiltersselector3, "CAJDSC") == 0 ) && ( AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_cajachicawwds_13_cajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV72Bancos_cajachicawwds_13_cajdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Bancos_cajachicawwds_11_dynamicfiltersselector3, "CAJDSC") == 0 ) && ( AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_cajachicawwds_13_cajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like '%' + @lV72Bancos_cajachicawwds_13_cajdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Bancos_cajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_cajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV73Bancos_cajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Bancos_cajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_cajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV73Bancos_cajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV74Bancos_cajachicawwds_15_tfcajcod) )
         {
            AddWhere(sWhereString, "(T1.[CajCod] >= @AV74Bancos_cajachicawwds_15_tfcajcod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV75Bancos_cajachicawwds_16_tfcajcod_to) )
         {
            AddWhere(sWhereString, "(T1.[CajCod] <= @AV75Bancos_cajachicawwds_16_tfcajcod_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_cajachicawwds_18_tfcajdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_cajachicawwds_17_tfcajdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV76Bancos_cajachicawwds_17_tfcajdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_cajachicawwds_18_tfcajdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] = @AV77Bancos_cajachicawwds_18_tfcajdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_cajachicawwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_cajachicawwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV78Bancos_cajachicawwds_19_tfcuecod)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_cajachicawwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV79Bancos_cajachicawwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Bancos_cajachicawwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Bancos_cajachicawwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV80Bancos_cajachicawwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Bancos_cajachicawwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV81Bancos_cajachicawwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV82Bancos_cajachicawwds_23_tfcajsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Bancos_cajachicawwds_23_tfcajsts_sels, "T1.[CajSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P005K4( IGxContext context ,
                                             short A487CajSts ,
                                             GxSimpleCollection<short> AV82Bancos_cajachicawwds_23_tfcajsts_sels ,
                                             string AV60Bancos_cajachicawwds_1_dynamicfiltersselector1 ,
                                             short AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 ,
                                             string AV62Bancos_cajachicawwds_3_cajdsc1 ,
                                             string AV63Bancos_cajachicawwds_4_cuecod1 ,
                                             bool AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 ,
                                             string AV65Bancos_cajachicawwds_6_dynamicfiltersselector2 ,
                                             short AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 ,
                                             string AV67Bancos_cajachicawwds_8_cajdsc2 ,
                                             string AV68Bancos_cajachicawwds_9_cuecod2 ,
                                             bool AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 ,
                                             string AV70Bancos_cajachicawwds_11_dynamicfiltersselector3 ,
                                             short AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 ,
                                             string AV72Bancos_cajachicawwds_13_cajdsc3 ,
                                             string AV73Bancos_cajachicawwds_14_cuecod3 ,
                                             int AV74Bancos_cajachicawwds_15_tfcajcod ,
                                             int AV75Bancos_cajachicawwds_16_tfcajcod_to ,
                                             string AV77Bancos_cajachicawwds_18_tfcajdsc_sel ,
                                             string AV76Bancos_cajachicawwds_17_tfcajdsc ,
                                             string AV79Bancos_cajachicawwds_20_tfcuecod_sel ,
                                             string AV78Bancos_cajachicawwds_19_tfcuecod ,
                                             string AV81Bancos_cajachicawwds_22_tfcuedsc_sel ,
                                             string AV80Bancos_cajachicawwds_21_tfcuedsc ,
                                             int AV82Bancos_cajachicawwds_23_tfcajsts_sels_Count ,
                                             string A486CajDsc ,
                                             string A91CueCod ,
                                             int A358CajCod ,
                                             string A860CueDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T2.[CueDsc], T1.[CajSts], T1.[CajCod], T1.[CueCod], T1.[CajDsc] FROM ([TSCAJACHICA] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV60Bancos_cajachicawwds_1_dynamicfiltersselector1, "CAJDSC") == 0 ) && ( AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Bancos_cajachicawwds_3_cajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV62Bancos_cajachicawwds_3_cajdsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Bancos_cajachicawwds_1_dynamicfiltersselector1, "CAJDSC") == 0 ) && ( AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Bancos_cajachicawwds_3_cajdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like '%' + @lV62Bancos_cajachicawwds_3_cajdsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Bancos_cajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_cajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV63Bancos_cajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Bancos_cajachicawwds_1_dynamicfiltersselector1, "CUECOD") == 0 ) && ( AV61Bancos_cajachicawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Bancos_cajachicawwds_4_cuecod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV63Bancos_cajachicawwds_4_cuecod1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Bancos_cajachicawwds_6_dynamicfiltersselector2, "CAJDSC") == 0 ) && ( AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Bancos_cajachicawwds_8_cajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV67Bancos_cajachicawwds_8_cajdsc2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Bancos_cajachicawwds_6_dynamicfiltersselector2, "CAJDSC") == 0 ) && ( AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Bancos_cajachicawwds_8_cajdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like '%' + @lV67Bancos_cajachicawwds_8_cajdsc2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Bancos_cajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_cajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV68Bancos_cajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV64Bancos_cajachicawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Bancos_cajachicawwds_6_dynamicfiltersselector2, "CUECOD") == 0 ) && ( AV66Bancos_cajachicawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_cajachicawwds_9_cuecod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV68Bancos_cajachicawwds_9_cuecod2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Bancos_cajachicawwds_11_dynamicfiltersselector3, "CAJDSC") == 0 ) && ( AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_cajachicawwds_13_cajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV72Bancos_cajachicawwds_13_cajdsc3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Bancos_cajachicawwds_11_dynamicfiltersselector3, "CAJDSC") == 0 ) && ( AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_cajachicawwds_13_cajdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like '%' + @lV72Bancos_cajachicawwds_13_cajdsc3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Bancos_cajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_cajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV73Bancos_cajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV69Bancos_cajachicawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Bancos_cajachicawwds_11_dynamicfiltersselector3, "CUECOD") == 0 ) && ( AV71Bancos_cajachicawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_cajachicawwds_14_cuecod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like '%' + @lV73Bancos_cajachicawwds_14_cuecod3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (0==AV74Bancos_cajachicawwds_15_tfcajcod) )
         {
            AddWhere(sWhereString, "(T1.[CajCod] >= @AV74Bancos_cajachicawwds_15_tfcajcod)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (0==AV75Bancos_cajachicawwds_16_tfcajcod_to) )
         {
            AddWhere(sWhereString, "(T1.[CajCod] <= @AV75Bancos_cajachicawwds_16_tfcajcod_to)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_cajachicawwds_18_tfcajdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_cajachicawwds_17_tfcajdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] like @lV76Bancos_cajachicawwds_17_tfcajdsc)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_cajachicawwds_18_tfcajdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CajDsc] = @AV77Bancos_cajachicawwds_18_tfcajdsc_sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_cajachicawwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_cajachicawwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV78Bancos_cajachicawwds_19_tfcuecod)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_cajachicawwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV79Bancos_cajachicawwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Bancos_cajachicawwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Bancos_cajachicawwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV80Bancos_cajachicawwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Bancos_cajachicawwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV81Bancos_cajachicawwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV82Bancos_cajachicawwds_23_tfcajsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Bancos_cajachicawwds_23_tfcajsts_sels, "T1.[CajSts] IN (", ")")+")");
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
                     return conditional_P005K2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
               case 1 :
                     return conditional_P005K3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
               case 2 :
                     return conditional_P005K4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP005K2;
          prmP005K2 = new Object[] {
          new ParDef("@lV62Bancos_cajachicawwds_3_cajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV62Bancos_cajachicawwds_3_cajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV63Bancos_cajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV63Bancos_cajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV67Bancos_cajachicawwds_8_cajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV67Bancos_cajachicawwds_8_cajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Bancos_cajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV68Bancos_cajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV72Bancos_cajachicawwds_13_cajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV72Bancos_cajachicawwds_13_cajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV73Bancos_cajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV73Bancos_cajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV74Bancos_cajachicawwds_15_tfcajcod",GXType.Int32,6,0) ,
          new ParDef("@AV75Bancos_cajachicawwds_16_tfcajcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV76Bancos_cajachicawwds_17_tfcajdsc",GXType.NChar,100,0) ,
          new ParDef("@AV77Bancos_cajachicawwds_18_tfcajdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV78Bancos_cajachicawwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV79Bancos_cajachicawwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV80Bancos_cajachicawwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV81Bancos_cajachicawwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP005K3;
          prmP005K3 = new Object[] {
          new ParDef("@lV62Bancos_cajachicawwds_3_cajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV62Bancos_cajachicawwds_3_cajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV63Bancos_cajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV63Bancos_cajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV67Bancos_cajachicawwds_8_cajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV67Bancos_cajachicawwds_8_cajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Bancos_cajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV68Bancos_cajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV72Bancos_cajachicawwds_13_cajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV72Bancos_cajachicawwds_13_cajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV73Bancos_cajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV73Bancos_cajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV74Bancos_cajachicawwds_15_tfcajcod",GXType.Int32,6,0) ,
          new ParDef("@AV75Bancos_cajachicawwds_16_tfcajcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV76Bancos_cajachicawwds_17_tfcajdsc",GXType.NChar,100,0) ,
          new ParDef("@AV77Bancos_cajachicawwds_18_tfcajdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV78Bancos_cajachicawwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV79Bancos_cajachicawwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV80Bancos_cajachicawwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV81Bancos_cajachicawwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP005K4;
          prmP005K4 = new Object[] {
          new ParDef("@lV62Bancos_cajachicawwds_3_cajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV62Bancos_cajachicawwds_3_cajdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV63Bancos_cajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV63Bancos_cajachicawwds_4_cuecod1",GXType.NChar,15,0) ,
          new ParDef("@lV67Bancos_cajachicawwds_8_cajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV67Bancos_cajachicawwds_8_cajdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Bancos_cajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV68Bancos_cajachicawwds_9_cuecod2",GXType.NChar,15,0) ,
          new ParDef("@lV72Bancos_cajachicawwds_13_cajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV72Bancos_cajachicawwds_13_cajdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV73Bancos_cajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@lV73Bancos_cajachicawwds_14_cuecod3",GXType.NChar,15,0) ,
          new ParDef("@AV74Bancos_cajachicawwds_15_tfcajcod",GXType.Int32,6,0) ,
          new ParDef("@AV75Bancos_cajachicawwds_16_tfcajcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV76Bancos_cajachicawwds_17_tfcajdsc",GXType.NChar,100,0) ,
          new ParDef("@AV77Bancos_cajachicawwds_18_tfcajdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV78Bancos_cajachicawwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV79Bancos_cajachicawwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV80Bancos_cajachicawwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV81Bancos_cajachicawwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005K2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005K3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005K4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005K4,100, GxCacheFrequency.OFF ,true,false )
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
