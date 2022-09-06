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
   public class entregarendirwwgetfilterdata : GXProcedure
   {
      public entregarendirwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public entregarendirwwgetfilterdata( IGxContext context )
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
         entregarendirwwgetfilterdata objentregarendirwwgetfilterdata;
         objentregarendirwwgetfilterdata = new entregarendirwwgetfilterdata();
         objentregarendirwwgetfilterdata.AV24DDOName = aP0_DDOName;
         objentregarendirwwgetfilterdata.AV22SearchTxt = aP1_SearchTxt;
         objentregarendirwwgetfilterdata.AV23SearchTxtTo = aP2_SearchTxtTo;
         objentregarendirwwgetfilterdata.AV28OptionsJson = "" ;
         objentregarendirwwgetfilterdata.AV31OptionsDescJson = "" ;
         objentregarendirwwgetfilterdata.AV33OptionIndexesJson = "" ;
         objentregarendirwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objentregarendirwwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objentregarendirwwgetfilterdata);
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((entregarendirwwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_ENTDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADENTDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_CUECOD") == 0 )
         {
            /* Execute user subroutine: 'LOADCUECODOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_CUEDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCUEDSCOPTIONS' */
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
         if ( StringUtil.StrCmp(AV35Session.Get("Bancos.EntregaRendirWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.EntregaRendirWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("Bancos.EntregaRendirWWGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFENTCOD") == 0 )
            {
               AV10TFEntCod = (int)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."));
               AV11TFEntCod_To = (int)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFENTDSC") == 0 )
            {
               AV12TFEntDsc = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFENTDSC_SEL") == 0 )
            {
               AV13TFEntDsc_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCUECOD") == 0 )
            {
               AV16TFCueCod = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCUECOD_SEL") == 0 )
            {
               AV17TFCueCod_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCUEDSC") == 0 )
            {
               AV18TFCueDsc = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCUEDSC_SEL") == 0 )
            {
               AV19TFCueDsc_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFENTSTS_SEL") == 0 )
            {
               AV20TFEntSts_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV21TFEntSts_Sels.FromJSonString(AV20TFEntSts_SelsJson, null);
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV39GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "ENTDSC") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV42EntDsc1 = AV39GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "CUEDSC") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV43CueDsc1 = AV39GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV39GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "ENTDSC") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV47EntDsc2 = AV39GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "CUEDSC") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV48CueDsc2 = AV39GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV39GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "ENTDSC") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV52EntDsc3 = AV39GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "CUEDSC") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV53CueDsc3 = AV39GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADENTDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFEntDsc = AV22SearchTxt;
         AV13TFEntDsc_Sel = "";
         AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV60Bancos_entregarendirwwds_3_entdsc1 = AV42EntDsc1;
         AV61Bancos_entregarendirwwds_4_cuedsc1 = AV43CueDsc1;
         AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV65Bancos_entregarendirwwds_8_entdsc2 = AV47EntDsc2;
         AV66Bancos_entregarendirwwds_9_cuedsc2 = AV48CueDsc2;
         AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV70Bancos_entregarendirwwds_13_entdsc3 = AV52EntDsc3;
         AV71Bancos_entregarendirwwds_14_cuedsc3 = AV53CueDsc3;
         AV72Bancos_entregarendirwwds_15_tfentcod = AV10TFEntCod;
         AV73Bancos_entregarendirwwds_16_tfentcod_to = AV11TFEntCod_To;
         AV74Bancos_entregarendirwwds_17_tfentdsc = AV12TFEntDsc;
         AV75Bancos_entregarendirwwds_18_tfentdsc_sel = AV13TFEntDsc_Sel;
         AV76Bancos_entregarendirwwds_19_tfcuecod = AV16TFCueCod;
         AV77Bancos_entregarendirwwds_20_tfcuecod_sel = AV17TFCueCod_Sel;
         AV78Bancos_entregarendirwwds_21_tfcuedsc = AV18TFCueDsc;
         AV79Bancos_entregarendirwwds_22_tfcuedsc_sel = AV19TFCueDsc_Sel;
         AV80Bancos_entregarendirwwds_23_tfentsts_sels = AV21TFEntSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A973EntSts ,
                                              AV80Bancos_entregarendirwwds_23_tfentsts_sels ,
                                              AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1 ,
                                              AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 ,
                                              AV60Bancos_entregarendirwwds_3_entdsc1 ,
                                              AV61Bancos_entregarendirwwds_4_cuedsc1 ,
                                              AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 ,
                                              AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2 ,
                                              AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 ,
                                              AV65Bancos_entregarendirwwds_8_entdsc2 ,
                                              AV66Bancos_entregarendirwwds_9_cuedsc2 ,
                                              AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 ,
                                              AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3 ,
                                              AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 ,
                                              AV70Bancos_entregarendirwwds_13_entdsc3 ,
                                              AV71Bancos_entregarendirwwds_14_cuedsc3 ,
                                              AV72Bancos_entregarendirwwds_15_tfentcod ,
                                              AV73Bancos_entregarendirwwds_16_tfentcod_to ,
                                              AV75Bancos_entregarendirwwds_18_tfentdsc_sel ,
                                              AV74Bancos_entregarendirwwds_17_tfentdsc ,
                                              AV77Bancos_entregarendirwwds_20_tfcuecod_sel ,
                                              AV76Bancos_entregarendirwwds_19_tfcuecod ,
                                              AV79Bancos_entregarendirwwds_22_tfcuedsc_sel ,
                                              AV78Bancos_entregarendirwwds_21_tfcuedsc ,
                                              AV80Bancos_entregarendirwwds_23_tfentsts_sels.Count ,
                                              A972EntDsc ,
                                              A860CueDsc ,
                                              A365EntCod ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV60Bancos_entregarendirwwds_3_entdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_entregarendirwwds_3_entdsc1), 100, "%");
         lV60Bancos_entregarendirwwds_3_entdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_entregarendirwwds_3_entdsc1), 100, "%");
         lV61Bancos_entregarendirwwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_entregarendirwwds_4_cuedsc1), 100, "%");
         lV61Bancos_entregarendirwwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_entregarendirwwds_4_cuedsc1), 100, "%");
         lV65Bancos_entregarendirwwds_8_entdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_entregarendirwwds_8_entdsc2), 100, "%");
         lV65Bancos_entregarendirwwds_8_entdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_entregarendirwwds_8_entdsc2), 100, "%");
         lV66Bancos_entregarendirwwds_9_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_entregarendirwwds_9_cuedsc2), 100, "%");
         lV66Bancos_entregarendirwwds_9_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_entregarendirwwds_9_cuedsc2), 100, "%");
         lV70Bancos_entregarendirwwds_13_entdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_entregarendirwwds_13_entdsc3), 100, "%");
         lV70Bancos_entregarendirwwds_13_entdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_entregarendirwwds_13_entdsc3), 100, "%");
         lV71Bancos_entregarendirwwds_14_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_entregarendirwwds_14_cuedsc3), 100, "%");
         lV71Bancos_entregarendirwwds_14_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_entregarendirwwds_14_cuedsc3), 100, "%");
         lV74Bancos_entregarendirwwds_17_tfentdsc = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_entregarendirwwds_17_tfentdsc), 100, "%");
         lV76Bancos_entregarendirwwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_entregarendirwwds_19_tfcuecod), 15, "%");
         lV78Bancos_entregarendirwwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_entregarendirwwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005S2 */
         pr_default.execute(0, new Object[] {lV60Bancos_entregarendirwwds_3_entdsc1, lV60Bancos_entregarendirwwds_3_entdsc1, lV61Bancos_entregarendirwwds_4_cuedsc1, lV61Bancos_entregarendirwwds_4_cuedsc1, lV65Bancos_entregarendirwwds_8_entdsc2, lV65Bancos_entregarendirwwds_8_entdsc2, lV66Bancos_entregarendirwwds_9_cuedsc2, lV66Bancos_entregarendirwwds_9_cuedsc2, lV70Bancos_entregarendirwwds_13_entdsc3, lV70Bancos_entregarendirwwds_13_entdsc3, lV71Bancos_entregarendirwwds_14_cuedsc3, lV71Bancos_entregarendirwwds_14_cuedsc3, AV72Bancos_entregarendirwwds_15_tfentcod, AV73Bancos_entregarendirwwds_16_tfentcod_to, lV74Bancos_entregarendirwwds_17_tfentdsc, AV75Bancos_entregarendirwwds_18_tfentdsc_sel, lV76Bancos_entregarendirwwds_19_tfcuecod, AV77Bancos_entregarendirwwds_20_tfcuecod_sel, lV78Bancos_entregarendirwwds_21_tfcuedsc, AV79Bancos_entregarendirwwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5S2 = false;
            A972EntDsc = P005S2_A972EntDsc[0];
            A973EntSts = P005S2_A973EntSts[0];
            A91CueCod = P005S2_A91CueCod[0];
            A365EntCod = P005S2_A365EntCod[0];
            A860CueDsc = P005S2_A860CueDsc[0];
            A860CueDsc = P005S2_A860CueDsc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005S2_A972EntDsc[0], A972EntDsc) == 0 ) )
            {
               BRK5S2 = false;
               A365EntCod = P005S2_A365EntCod[0];
               AV34count = (long)(AV34count+1);
               BRK5S2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A972EntDsc)) )
            {
               AV26Option = A972EntDsc;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK5S2 )
            {
               BRK5S2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCUECODOPTIONS' Routine */
         returnInSub = false;
         AV16TFCueCod = AV22SearchTxt;
         AV17TFCueCod_Sel = "";
         AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV60Bancos_entregarendirwwds_3_entdsc1 = AV42EntDsc1;
         AV61Bancos_entregarendirwwds_4_cuedsc1 = AV43CueDsc1;
         AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV65Bancos_entregarendirwwds_8_entdsc2 = AV47EntDsc2;
         AV66Bancos_entregarendirwwds_9_cuedsc2 = AV48CueDsc2;
         AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV70Bancos_entregarendirwwds_13_entdsc3 = AV52EntDsc3;
         AV71Bancos_entregarendirwwds_14_cuedsc3 = AV53CueDsc3;
         AV72Bancos_entregarendirwwds_15_tfentcod = AV10TFEntCod;
         AV73Bancos_entregarendirwwds_16_tfentcod_to = AV11TFEntCod_To;
         AV74Bancos_entregarendirwwds_17_tfentdsc = AV12TFEntDsc;
         AV75Bancos_entregarendirwwds_18_tfentdsc_sel = AV13TFEntDsc_Sel;
         AV76Bancos_entregarendirwwds_19_tfcuecod = AV16TFCueCod;
         AV77Bancos_entregarendirwwds_20_tfcuecod_sel = AV17TFCueCod_Sel;
         AV78Bancos_entregarendirwwds_21_tfcuedsc = AV18TFCueDsc;
         AV79Bancos_entregarendirwwds_22_tfcuedsc_sel = AV19TFCueDsc_Sel;
         AV80Bancos_entregarendirwwds_23_tfentsts_sels = AV21TFEntSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A973EntSts ,
                                              AV80Bancos_entregarendirwwds_23_tfentsts_sels ,
                                              AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1 ,
                                              AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 ,
                                              AV60Bancos_entregarendirwwds_3_entdsc1 ,
                                              AV61Bancos_entregarendirwwds_4_cuedsc1 ,
                                              AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 ,
                                              AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2 ,
                                              AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 ,
                                              AV65Bancos_entregarendirwwds_8_entdsc2 ,
                                              AV66Bancos_entregarendirwwds_9_cuedsc2 ,
                                              AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 ,
                                              AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3 ,
                                              AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 ,
                                              AV70Bancos_entregarendirwwds_13_entdsc3 ,
                                              AV71Bancos_entregarendirwwds_14_cuedsc3 ,
                                              AV72Bancos_entregarendirwwds_15_tfentcod ,
                                              AV73Bancos_entregarendirwwds_16_tfentcod_to ,
                                              AV75Bancos_entregarendirwwds_18_tfentdsc_sel ,
                                              AV74Bancos_entregarendirwwds_17_tfentdsc ,
                                              AV77Bancos_entregarendirwwds_20_tfcuecod_sel ,
                                              AV76Bancos_entregarendirwwds_19_tfcuecod ,
                                              AV79Bancos_entregarendirwwds_22_tfcuedsc_sel ,
                                              AV78Bancos_entregarendirwwds_21_tfcuedsc ,
                                              AV80Bancos_entregarendirwwds_23_tfentsts_sels.Count ,
                                              A972EntDsc ,
                                              A860CueDsc ,
                                              A365EntCod ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV60Bancos_entregarendirwwds_3_entdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_entregarendirwwds_3_entdsc1), 100, "%");
         lV60Bancos_entregarendirwwds_3_entdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_entregarendirwwds_3_entdsc1), 100, "%");
         lV61Bancos_entregarendirwwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_entregarendirwwds_4_cuedsc1), 100, "%");
         lV61Bancos_entregarendirwwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_entregarendirwwds_4_cuedsc1), 100, "%");
         lV65Bancos_entregarendirwwds_8_entdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_entregarendirwwds_8_entdsc2), 100, "%");
         lV65Bancos_entregarendirwwds_8_entdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_entregarendirwwds_8_entdsc2), 100, "%");
         lV66Bancos_entregarendirwwds_9_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_entregarendirwwds_9_cuedsc2), 100, "%");
         lV66Bancos_entregarendirwwds_9_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_entregarendirwwds_9_cuedsc2), 100, "%");
         lV70Bancos_entregarendirwwds_13_entdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_entregarendirwwds_13_entdsc3), 100, "%");
         lV70Bancos_entregarendirwwds_13_entdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_entregarendirwwds_13_entdsc3), 100, "%");
         lV71Bancos_entregarendirwwds_14_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_entregarendirwwds_14_cuedsc3), 100, "%");
         lV71Bancos_entregarendirwwds_14_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_entregarendirwwds_14_cuedsc3), 100, "%");
         lV74Bancos_entregarendirwwds_17_tfentdsc = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_entregarendirwwds_17_tfentdsc), 100, "%");
         lV76Bancos_entregarendirwwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_entregarendirwwds_19_tfcuecod), 15, "%");
         lV78Bancos_entregarendirwwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_entregarendirwwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005S3 */
         pr_default.execute(1, new Object[] {lV60Bancos_entregarendirwwds_3_entdsc1, lV60Bancos_entregarendirwwds_3_entdsc1, lV61Bancos_entregarendirwwds_4_cuedsc1, lV61Bancos_entregarendirwwds_4_cuedsc1, lV65Bancos_entregarendirwwds_8_entdsc2, lV65Bancos_entregarendirwwds_8_entdsc2, lV66Bancos_entregarendirwwds_9_cuedsc2, lV66Bancos_entregarendirwwds_9_cuedsc2, lV70Bancos_entregarendirwwds_13_entdsc3, lV70Bancos_entregarendirwwds_13_entdsc3, lV71Bancos_entregarendirwwds_14_cuedsc3, lV71Bancos_entregarendirwwds_14_cuedsc3, AV72Bancos_entregarendirwwds_15_tfentcod, AV73Bancos_entregarendirwwds_16_tfentcod_to, lV74Bancos_entregarendirwwds_17_tfentdsc, AV75Bancos_entregarendirwwds_18_tfentdsc_sel, lV76Bancos_entregarendirwwds_19_tfcuecod, AV77Bancos_entregarendirwwds_20_tfcuecod_sel, lV78Bancos_entregarendirwwds_21_tfcuedsc, AV79Bancos_entregarendirwwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5S4 = false;
            A91CueCod = P005S3_A91CueCod[0];
            A973EntSts = P005S3_A973EntSts[0];
            A365EntCod = P005S3_A365EntCod[0];
            A860CueDsc = P005S3_A860CueDsc[0];
            A972EntDsc = P005S3_A972EntDsc[0];
            A860CueDsc = P005S3_A860CueDsc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005S3_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRK5S4 = false;
               A365EntCod = P005S3_A365EntCod[0];
               AV34count = (long)(AV34count+1);
               BRK5S4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A91CueCod)) )
            {
               AV26Option = A91CueCod;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK5S4 )
            {
               BRK5S4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCUEDSCOPTIONS' Routine */
         returnInSub = false;
         AV18TFCueDsc = AV22SearchTxt;
         AV19TFCueDsc_Sel = "";
         AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV60Bancos_entregarendirwwds_3_entdsc1 = AV42EntDsc1;
         AV61Bancos_entregarendirwwds_4_cuedsc1 = AV43CueDsc1;
         AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV65Bancos_entregarendirwwds_8_entdsc2 = AV47EntDsc2;
         AV66Bancos_entregarendirwwds_9_cuedsc2 = AV48CueDsc2;
         AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV70Bancos_entregarendirwwds_13_entdsc3 = AV52EntDsc3;
         AV71Bancos_entregarendirwwds_14_cuedsc3 = AV53CueDsc3;
         AV72Bancos_entregarendirwwds_15_tfentcod = AV10TFEntCod;
         AV73Bancos_entregarendirwwds_16_tfentcod_to = AV11TFEntCod_To;
         AV74Bancos_entregarendirwwds_17_tfentdsc = AV12TFEntDsc;
         AV75Bancos_entregarendirwwds_18_tfentdsc_sel = AV13TFEntDsc_Sel;
         AV76Bancos_entregarendirwwds_19_tfcuecod = AV16TFCueCod;
         AV77Bancos_entregarendirwwds_20_tfcuecod_sel = AV17TFCueCod_Sel;
         AV78Bancos_entregarendirwwds_21_tfcuedsc = AV18TFCueDsc;
         AV79Bancos_entregarendirwwds_22_tfcuedsc_sel = AV19TFCueDsc_Sel;
         AV80Bancos_entregarendirwwds_23_tfentsts_sels = AV21TFEntSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A973EntSts ,
                                              AV80Bancos_entregarendirwwds_23_tfentsts_sels ,
                                              AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1 ,
                                              AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 ,
                                              AV60Bancos_entregarendirwwds_3_entdsc1 ,
                                              AV61Bancos_entregarendirwwds_4_cuedsc1 ,
                                              AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 ,
                                              AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2 ,
                                              AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 ,
                                              AV65Bancos_entregarendirwwds_8_entdsc2 ,
                                              AV66Bancos_entregarendirwwds_9_cuedsc2 ,
                                              AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 ,
                                              AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3 ,
                                              AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 ,
                                              AV70Bancos_entregarendirwwds_13_entdsc3 ,
                                              AV71Bancos_entregarendirwwds_14_cuedsc3 ,
                                              AV72Bancos_entregarendirwwds_15_tfentcod ,
                                              AV73Bancos_entregarendirwwds_16_tfentcod_to ,
                                              AV75Bancos_entregarendirwwds_18_tfentdsc_sel ,
                                              AV74Bancos_entregarendirwwds_17_tfentdsc ,
                                              AV77Bancos_entregarendirwwds_20_tfcuecod_sel ,
                                              AV76Bancos_entregarendirwwds_19_tfcuecod ,
                                              AV79Bancos_entregarendirwwds_22_tfcuedsc_sel ,
                                              AV78Bancos_entregarendirwwds_21_tfcuedsc ,
                                              AV80Bancos_entregarendirwwds_23_tfentsts_sels.Count ,
                                              A972EntDsc ,
                                              A860CueDsc ,
                                              A365EntCod ,
                                              A91CueCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV60Bancos_entregarendirwwds_3_entdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_entregarendirwwds_3_entdsc1), 100, "%");
         lV60Bancos_entregarendirwwds_3_entdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Bancos_entregarendirwwds_3_entdsc1), 100, "%");
         lV61Bancos_entregarendirwwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_entregarendirwwds_4_cuedsc1), 100, "%");
         lV61Bancos_entregarendirwwds_4_cuedsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_entregarendirwwds_4_cuedsc1), 100, "%");
         lV65Bancos_entregarendirwwds_8_entdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_entregarendirwwds_8_entdsc2), 100, "%");
         lV65Bancos_entregarendirwwds_8_entdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_entregarendirwwds_8_entdsc2), 100, "%");
         lV66Bancos_entregarendirwwds_9_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_entregarendirwwds_9_cuedsc2), 100, "%");
         lV66Bancos_entregarendirwwds_9_cuedsc2 = StringUtil.PadR( StringUtil.RTrim( AV66Bancos_entregarendirwwds_9_cuedsc2), 100, "%");
         lV70Bancos_entregarendirwwds_13_entdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_entregarendirwwds_13_entdsc3), 100, "%");
         lV70Bancos_entregarendirwwds_13_entdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_entregarendirwwds_13_entdsc3), 100, "%");
         lV71Bancos_entregarendirwwds_14_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_entregarendirwwds_14_cuedsc3), 100, "%");
         lV71Bancos_entregarendirwwds_14_cuedsc3 = StringUtil.PadR( StringUtil.RTrim( AV71Bancos_entregarendirwwds_14_cuedsc3), 100, "%");
         lV74Bancos_entregarendirwwds_17_tfentdsc = StringUtil.PadR( StringUtil.RTrim( AV74Bancos_entregarendirwwds_17_tfentdsc), 100, "%");
         lV76Bancos_entregarendirwwds_19_tfcuecod = StringUtil.PadR( StringUtil.RTrim( AV76Bancos_entregarendirwwds_19_tfcuecod), 15, "%");
         lV78Bancos_entregarendirwwds_21_tfcuedsc = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_entregarendirwwds_21_tfcuedsc), 100, "%");
         /* Using cursor P005S4 */
         pr_default.execute(2, new Object[] {lV60Bancos_entregarendirwwds_3_entdsc1, lV60Bancos_entregarendirwwds_3_entdsc1, lV61Bancos_entregarendirwwds_4_cuedsc1, lV61Bancos_entregarendirwwds_4_cuedsc1, lV65Bancos_entregarendirwwds_8_entdsc2, lV65Bancos_entregarendirwwds_8_entdsc2, lV66Bancos_entregarendirwwds_9_cuedsc2, lV66Bancos_entregarendirwwds_9_cuedsc2, lV70Bancos_entregarendirwwds_13_entdsc3, lV70Bancos_entregarendirwwds_13_entdsc3, lV71Bancos_entregarendirwwds_14_cuedsc3, lV71Bancos_entregarendirwwds_14_cuedsc3, AV72Bancos_entregarendirwwds_15_tfentcod, AV73Bancos_entregarendirwwds_16_tfentcod_to, lV74Bancos_entregarendirwwds_17_tfentdsc, AV75Bancos_entregarendirwwds_18_tfentdsc_sel, lV76Bancos_entregarendirwwds_19_tfcuecod, AV77Bancos_entregarendirwwds_20_tfcuecod_sel, lV78Bancos_entregarendirwwds_21_tfcuedsc, AV79Bancos_entregarendirwwds_22_tfcuedsc_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5S6 = false;
            A91CueCod = P005S4_A91CueCod[0];
            A973EntSts = P005S4_A973EntSts[0];
            A365EntCod = P005S4_A365EntCod[0];
            A860CueDsc = P005S4_A860CueDsc[0];
            A972EntDsc = P005S4_A972EntDsc[0];
            A860CueDsc = P005S4_A860CueDsc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005S4_A91CueCod[0], A91CueCod) == 0 ) )
            {
               BRK5S6 = false;
               A365EntCod = P005S4_A365EntCod[0];
               AV34count = (long)(AV34count+1);
               BRK5S6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A860CueDsc)) )
            {
               AV26Option = A860CueDsc;
               AV25InsertIndex = 1;
               while ( ( AV25InsertIndex <= AV27Options.Count ) && ( StringUtil.StrCmp(((string)AV27Options.Item(AV25InsertIndex)), AV26Option) < 0 ) )
               {
                  AV25InsertIndex = (int)(AV25InsertIndex+1);
               }
               AV27Options.Add(AV26Option, AV25InsertIndex);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), AV25InsertIndex);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK5S6 )
            {
               BRK5S6 = true;
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
         AV12TFEntDsc = "";
         AV13TFEntDsc_Sel = "";
         AV16TFCueCod = "";
         AV17TFCueCod_Sel = "";
         AV18TFCueDsc = "";
         AV19TFCueDsc_Sel = "";
         AV20TFEntSts_SelsJson = "";
         AV21TFEntSts_Sels = new GxSimpleCollection<short>();
         AV39GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV42EntDsc1 = "";
         AV43CueDsc1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV47EntDsc2 = "";
         AV48CueDsc2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV52EntDsc3 = "";
         AV53CueDsc3 = "";
         AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1 = "";
         AV60Bancos_entregarendirwwds_3_entdsc1 = "";
         AV61Bancos_entregarendirwwds_4_cuedsc1 = "";
         AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2 = "";
         AV65Bancos_entregarendirwwds_8_entdsc2 = "";
         AV66Bancos_entregarendirwwds_9_cuedsc2 = "";
         AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3 = "";
         AV70Bancos_entregarendirwwds_13_entdsc3 = "";
         AV71Bancos_entregarendirwwds_14_cuedsc3 = "";
         AV74Bancos_entregarendirwwds_17_tfentdsc = "";
         AV75Bancos_entregarendirwwds_18_tfentdsc_sel = "";
         AV76Bancos_entregarendirwwds_19_tfcuecod = "";
         AV77Bancos_entregarendirwwds_20_tfcuecod_sel = "";
         AV78Bancos_entregarendirwwds_21_tfcuedsc = "";
         AV79Bancos_entregarendirwwds_22_tfcuedsc_sel = "";
         AV80Bancos_entregarendirwwds_23_tfentsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV60Bancos_entregarendirwwds_3_entdsc1 = "";
         lV61Bancos_entregarendirwwds_4_cuedsc1 = "";
         lV65Bancos_entregarendirwwds_8_entdsc2 = "";
         lV66Bancos_entregarendirwwds_9_cuedsc2 = "";
         lV70Bancos_entregarendirwwds_13_entdsc3 = "";
         lV71Bancos_entregarendirwwds_14_cuedsc3 = "";
         lV74Bancos_entregarendirwwds_17_tfentdsc = "";
         lV76Bancos_entregarendirwwds_19_tfcuecod = "";
         lV78Bancos_entregarendirwwds_21_tfcuedsc = "";
         A972EntDsc = "";
         A860CueDsc = "";
         A91CueCod = "";
         P005S2_A972EntDsc = new string[] {""} ;
         P005S2_A973EntSts = new short[1] ;
         P005S2_A91CueCod = new string[] {""} ;
         P005S2_A365EntCod = new int[1] ;
         P005S2_A860CueDsc = new string[] {""} ;
         AV26Option = "";
         P005S3_A91CueCod = new string[] {""} ;
         P005S3_A973EntSts = new short[1] ;
         P005S3_A365EntCod = new int[1] ;
         P005S3_A860CueDsc = new string[] {""} ;
         P005S3_A972EntDsc = new string[] {""} ;
         P005S4_A91CueCod = new string[] {""} ;
         P005S4_A973EntSts = new short[1] ;
         P005S4_A365EntCod = new int[1] ;
         P005S4_A860CueDsc = new string[] {""} ;
         P005S4_A972EntDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.entregarendirwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005S2_A972EntDsc, P005S2_A973EntSts, P005S2_A91CueCod, P005S2_A365EntCod, P005S2_A860CueDsc
               }
               , new Object[] {
               P005S3_A91CueCod, P005S3_A973EntSts, P005S3_A365EntCod, P005S3_A860CueDsc, P005S3_A972EntDsc
               }
               , new Object[] {
               P005S4_A91CueCod, P005S4_A973EntSts, P005S4_A365EntCod, P005S4_A860CueDsc, P005S4_A972EntDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV41DynamicFiltersOperator1 ;
      private short AV46DynamicFiltersOperator2 ;
      private short AV51DynamicFiltersOperator3 ;
      private short AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 ;
      private short AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 ;
      private short AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 ;
      private short A973EntSts ;
      private int AV56GXV1 ;
      private int AV10TFEntCod ;
      private int AV11TFEntCod_To ;
      private int AV72Bancos_entregarendirwwds_15_tfentcod ;
      private int AV73Bancos_entregarendirwwds_16_tfentcod_to ;
      private int AV80Bancos_entregarendirwwds_23_tfentsts_sels_Count ;
      private int A365EntCod ;
      private int AV25InsertIndex ;
      private long AV34count ;
      private string AV12TFEntDsc ;
      private string AV13TFEntDsc_Sel ;
      private string AV16TFCueCod ;
      private string AV17TFCueCod_Sel ;
      private string AV18TFCueDsc ;
      private string AV19TFCueDsc_Sel ;
      private string AV42EntDsc1 ;
      private string AV43CueDsc1 ;
      private string AV47EntDsc2 ;
      private string AV48CueDsc2 ;
      private string AV52EntDsc3 ;
      private string AV53CueDsc3 ;
      private string AV60Bancos_entregarendirwwds_3_entdsc1 ;
      private string AV61Bancos_entregarendirwwds_4_cuedsc1 ;
      private string AV65Bancos_entregarendirwwds_8_entdsc2 ;
      private string AV66Bancos_entregarendirwwds_9_cuedsc2 ;
      private string AV70Bancos_entregarendirwwds_13_entdsc3 ;
      private string AV71Bancos_entregarendirwwds_14_cuedsc3 ;
      private string AV74Bancos_entregarendirwwds_17_tfentdsc ;
      private string AV75Bancos_entregarendirwwds_18_tfentdsc_sel ;
      private string AV76Bancos_entregarendirwwds_19_tfcuecod ;
      private string AV77Bancos_entregarendirwwds_20_tfcuecod_sel ;
      private string AV78Bancos_entregarendirwwds_21_tfcuedsc ;
      private string AV79Bancos_entregarendirwwds_22_tfcuedsc_sel ;
      private string scmdbuf ;
      private string lV60Bancos_entregarendirwwds_3_entdsc1 ;
      private string lV61Bancos_entregarendirwwds_4_cuedsc1 ;
      private string lV65Bancos_entregarendirwwds_8_entdsc2 ;
      private string lV66Bancos_entregarendirwwds_9_cuedsc2 ;
      private string lV70Bancos_entregarendirwwds_13_entdsc3 ;
      private string lV71Bancos_entregarendirwwds_14_cuedsc3 ;
      private string lV74Bancos_entregarendirwwds_17_tfentdsc ;
      private string lV76Bancos_entregarendirwwds_19_tfcuecod ;
      private string lV78Bancos_entregarendirwwds_21_tfcuedsc ;
      private string A972EntDsc ;
      private string A860CueDsc ;
      private string A91CueCod ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 ;
      private bool AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 ;
      private bool BRK5S2 ;
      private bool BRK5S4 ;
      private bool BRK5S6 ;
      private string AV28OptionsJson ;
      private string AV31OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV20TFEntSts_SelsJson ;
      private string AV24DDOName ;
      private string AV22SearchTxt ;
      private string AV23SearchTxtTo ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1 ;
      private string AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2 ;
      private string AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3 ;
      private string AV26Option ;
      private GxSimpleCollection<short> AV21TFEntSts_Sels ;
      private GxSimpleCollection<short> AV80Bancos_entregarendirwwds_23_tfentsts_sels ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P005S2_A972EntDsc ;
      private short[] P005S2_A973EntSts ;
      private string[] P005S2_A91CueCod ;
      private int[] P005S2_A365EntCod ;
      private string[] P005S2_A860CueDsc ;
      private string[] P005S3_A91CueCod ;
      private short[] P005S3_A973EntSts ;
      private int[] P005S3_A365EntCod ;
      private string[] P005S3_A860CueDsc ;
      private string[] P005S3_A972EntDsc ;
      private string[] P005S4_A91CueCod ;
      private short[] P005S4_A973EntSts ;
      private int[] P005S4_A365EntCod ;
      private string[] P005S4_A860CueDsc ;
      private string[] P005S4_A972EntDsc ;
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

   public class entregarendirwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005S2( IGxContext context ,
                                             short A973EntSts ,
                                             GxSimpleCollection<short> AV80Bancos_entregarendirwwds_23_tfentsts_sels ,
                                             string AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1 ,
                                             short AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 ,
                                             string AV60Bancos_entregarendirwwds_3_entdsc1 ,
                                             string AV61Bancos_entregarendirwwds_4_cuedsc1 ,
                                             bool AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 ,
                                             string AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2 ,
                                             short AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 ,
                                             string AV65Bancos_entregarendirwwds_8_entdsc2 ,
                                             string AV66Bancos_entregarendirwwds_9_cuedsc2 ,
                                             bool AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 ,
                                             string AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3 ,
                                             short AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 ,
                                             string AV70Bancos_entregarendirwwds_13_entdsc3 ,
                                             string AV71Bancos_entregarendirwwds_14_cuedsc3 ,
                                             int AV72Bancos_entregarendirwwds_15_tfentcod ,
                                             int AV73Bancos_entregarendirwwds_16_tfentcod_to ,
                                             string AV75Bancos_entregarendirwwds_18_tfentdsc_sel ,
                                             string AV74Bancos_entregarendirwwds_17_tfentdsc ,
                                             string AV77Bancos_entregarendirwwds_20_tfcuecod_sel ,
                                             string AV76Bancos_entregarendirwwds_19_tfcuecod ,
                                             string AV79Bancos_entregarendirwwds_22_tfcuedsc_sel ,
                                             string AV78Bancos_entregarendirwwds_21_tfcuedsc ,
                                             int AV80Bancos_entregarendirwwds_23_tfentsts_sels_Count ,
                                             string A972EntDsc ,
                                             string A860CueDsc ,
                                             int A365EntCod ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[EntDsc], T1.[EntSts], T1.[CueCod], T1.[EntCod], T2.[CueDsc] FROM ([TSENTREGAS] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1, "ENTDSC") == 0 ) && ( AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_entregarendirwwds_3_entdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV60Bancos_entregarendirwwds_3_entdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1, "ENTDSC") == 0 ) && ( AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_entregarendirwwds_3_entdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like '%' + @lV60Bancos_entregarendirwwds_3_entdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_entregarendirwwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV61Bancos_entregarendirwwds_4_cuedsc1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_entregarendirwwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV61Bancos_entregarendirwwds_4_cuedsc1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2, "ENTDSC") == 0 ) && ( AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_entregarendirwwds_8_entdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV65Bancos_entregarendirwwds_8_entdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2, "ENTDSC") == 0 ) && ( AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_entregarendirwwds_8_entdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like '%' + @lV65Bancos_entregarendirwwds_8_entdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_entregarendirwwds_9_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV66Bancos_entregarendirwwds_9_cuedsc2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_entregarendirwwds_9_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV66Bancos_entregarendirwwds_9_cuedsc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3, "ENTDSC") == 0 ) && ( AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_entregarendirwwds_13_entdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV70Bancos_entregarendirwwds_13_entdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3, "ENTDSC") == 0 ) && ( AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_entregarendirwwds_13_entdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like '%' + @lV70Bancos_entregarendirwwds_13_entdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_entregarendirwwds_14_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV71Bancos_entregarendirwwds_14_cuedsc3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_entregarendirwwds_14_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV71Bancos_entregarendirwwds_14_cuedsc3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV72Bancos_entregarendirwwds_15_tfentcod) )
         {
            AddWhere(sWhereString, "(T1.[EntCod] >= @AV72Bancos_entregarendirwwds_15_tfentcod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV73Bancos_entregarendirwwds_16_tfentcod_to) )
         {
            AddWhere(sWhereString, "(T1.[EntCod] <= @AV73Bancos_entregarendirwwds_16_tfentcod_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_entregarendirwwds_18_tfentdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_entregarendirwwds_17_tfentdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV74Bancos_entregarendirwwds_17_tfentdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_entregarendirwwds_18_tfentdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] = @AV75Bancos_entregarendirwwds_18_tfentdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_entregarendirwwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_entregarendirwwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV76Bancos_entregarendirwwds_19_tfcuecod)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_entregarendirwwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV77Bancos_entregarendirwwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_entregarendirwwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_entregarendirwwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV78Bancos_entregarendirwwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_entregarendirwwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV79Bancos_entregarendirwwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV80Bancos_entregarendirwwds_23_tfentsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV80Bancos_entregarendirwwds_23_tfentsts_sels, "T1.[EntSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[EntDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005S3( IGxContext context ,
                                             short A973EntSts ,
                                             GxSimpleCollection<short> AV80Bancos_entregarendirwwds_23_tfentsts_sels ,
                                             string AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1 ,
                                             short AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 ,
                                             string AV60Bancos_entregarendirwwds_3_entdsc1 ,
                                             string AV61Bancos_entregarendirwwds_4_cuedsc1 ,
                                             bool AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 ,
                                             string AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2 ,
                                             short AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 ,
                                             string AV65Bancos_entregarendirwwds_8_entdsc2 ,
                                             string AV66Bancos_entregarendirwwds_9_cuedsc2 ,
                                             bool AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 ,
                                             string AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3 ,
                                             short AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 ,
                                             string AV70Bancos_entregarendirwwds_13_entdsc3 ,
                                             string AV71Bancos_entregarendirwwds_14_cuedsc3 ,
                                             int AV72Bancos_entregarendirwwds_15_tfentcod ,
                                             int AV73Bancos_entregarendirwwds_16_tfentcod_to ,
                                             string AV75Bancos_entregarendirwwds_18_tfentdsc_sel ,
                                             string AV74Bancos_entregarendirwwds_17_tfentdsc ,
                                             string AV77Bancos_entregarendirwwds_20_tfcuecod_sel ,
                                             string AV76Bancos_entregarendirwwds_19_tfcuecod ,
                                             string AV79Bancos_entregarendirwwds_22_tfcuedsc_sel ,
                                             string AV78Bancos_entregarendirwwds_21_tfcuedsc ,
                                             int AV80Bancos_entregarendirwwds_23_tfentsts_sels_Count ,
                                             string A972EntDsc ,
                                             string A860CueDsc ,
                                             int A365EntCod ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CueCod], T1.[EntSts], T1.[EntCod], T2.[CueDsc], T1.[EntDsc] FROM ([TSENTREGAS] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1, "ENTDSC") == 0 ) && ( AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_entregarendirwwds_3_entdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV60Bancos_entregarendirwwds_3_entdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1, "ENTDSC") == 0 ) && ( AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_entregarendirwwds_3_entdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like '%' + @lV60Bancos_entregarendirwwds_3_entdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_entregarendirwwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV61Bancos_entregarendirwwds_4_cuedsc1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_entregarendirwwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV61Bancos_entregarendirwwds_4_cuedsc1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2, "ENTDSC") == 0 ) && ( AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_entregarendirwwds_8_entdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV65Bancos_entregarendirwwds_8_entdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2, "ENTDSC") == 0 ) && ( AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_entregarendirwwds_8_entdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like '%' + @lV65Bancos_entregarendirwwds_8_entdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_entregarendirwwds_9_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV66Bancos_entregarendirwwds_9_cuedsc2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_entregarendirwwds_9_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV66Bancos_entregarendirwwds_9_cuedsc2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3, "ENTDSC") == 0 ) && ( AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_entregarendirwwds_13_entdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV70Bancos_entregarendirwwds_13_entdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3, "ENTDSC") == 0 ) && ( AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_entregarendirwwds_13_entdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like '%' + @lV70Bancos_entregarendirwwds_13_entdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_entregarendirwwds_14_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV71Bancos_entregarendirwwds_14_cuedsc3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_entregarendirwwds_14_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV71Bancos_entregarendirwwds_14_cuedsc3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV72Bancos_entregarendirwwds_15_tfentcod) )
         {
            AddWhere(sWhereString, "(T1.[EntCod] >= @AV72Bancos_entregarendirwwds_15_tfentcod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV73Bancos_entregarendirwwds_16_tfentcod_to) )
         {
            AddWhere(sWhereString, "(T1.[EntCod] <= @AV73Bancos_entregarendirwwds_16_tfentcod_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_entregarendirwwds_18_tfentdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_entregarendirwwds_17_tfentdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV74Bancos_entregarendirwwds_17_tfentdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_entregarendirwwds_18_tfentdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] = @AV75Bancos_entregarendirwwds_18_tfentdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_entregarendirwwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_entregarendirwwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV76Bancos_entregarendirwwds_19_tfcuecod)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_entregarendirwwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV77Bancos_entregarendirwwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_entregarendirwwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_entregarendirwwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV78Bancos_entregarendirwwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_entregarendirwwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV79Bancos_entregarendirwwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV80Bancos_entregarendirwwds_23_tfentsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV80Bancos_entregarendirwwds_23_tfentsts_sels, "T1.[EntSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CueCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P005S4( IGxContext context ,
                                             short A973EntSts ,
                                             GxSimpleCollection<short> AV80Bancos_entregarendirwwds_23_tfentsts_sels ,
                                             string AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1 ,
                                             short AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 ,
                                             string AV60Bancos_entregarendirwwds_3_entdsc1 ,
                                             string AV61Bancos_entregarendirwwds_4_cuedsc1 ,
                                             bool AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 ,
                                             string AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2 ,
                                             short AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 ,
                                             string AV65Bancos_entregarendirwwds_8_entdsc2 ,
                                             string AV66Bancos_entregarendirwwds_9_cuedsc2 ,
                                             bool AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 ,
                                             string AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3 ,
                                             short AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 ,
                                             string AV70Bancos_entregarendirwwds_13_entdsc3 ,
                                             string AV71Bancos_entregarendirwwds_14_cuedsc3 ,
                                             int AV72Bancos_entregarendirwwds_15_tfentcod ,
                                             int AV73Bancos_entregarendirwwds_16_tfentcod_to ,
                                             string AV75Bancos_entregarendirwwds_18_tfentdsc_sel ,
                                             string AV74Bancos_entregarendirwwds_17_tfentdsc ,
                                             string AV77Bancos_entregarendirwwds_20_tfcuecod_sel ,
                                             string AV76Bancos_entregarendirwwds_19_tfcuecod ,
                                             string AV79Bancos_entregarendirwwds_22_tfcuedsc_sel ,
                                             string AV78Bancos_entregarendirwwds_21_tfcuedsc ,
                                             int AV80Bancos_entregarendirwwds_23_tfentsts_sels_Count ,
                                             string A972EntDsc ,
                                             string A860CueDsc ,
                                             int A365EntCod ,
                                             string A91CueCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[CueCod], T1.[EntSts], T1.[EntCod], T2.[CueDsc], T1.[EntDsc] FROM ([TSENTREGAS] T1 INNER JOIN [CBPLANCUENTA] T2 ON T2.[CueCod] = T1.[CueCod])";
         if ( ( StringUtil.StrCmp(AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1, "ENTDSC") == 0 ) && ( AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_entregarendirwwds_3_entdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV60Bancos_entregarendirwwds_3_entdsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1, "ENTDSC") == 0 ) && ( AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancos_entregarendirwwds_3_entdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like '%' + @lV60Bancos_entregarendirwwds_3_entdsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_entregarendirwwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV61Bancos_entregarendirwwds_4_cuedsc1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Bancos_entregarendirwwds_1_dynamicfiltersselector1, "CUEDSC") == 0 ) && ( AV59Bancos_entregarendirwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_entregarendirwwds_4_cuedsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV61Bancos_entregarendirwwds_4_cuedsc1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2, "ENTDSC") == 0 ) && ( AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_entregarendirwwds_8_entdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV65Bancos_entregarendirwwds_8_entdsc2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2, "ENTDSC") == 0 ) && ( AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_entregarendirwwds_8_entdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like '%' + @lV65Bancos_entregarendirwwds_8_entdsc2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_entregarendirwwds_9_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV66Bancos_entregarendirwwds_9_cuedsc2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV62Bancos_entregarendirwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Bancos_entregarendirwwds_6_dynamicfiltersselector2, "CUEDSC") == 0 ) && ( AV64Bancos_entregarendirwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Bancos_entregarendirwwds_9_cuedsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV66Bancos_entregarendirwwds_9_cuedsc2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3, "ENTDSC") == 0 ) && ( AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_entregarendirwwds_13_entdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV70Bancos_entregarendirwwds_13_entdsc3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3, "ENTDSC") == 0 ) && ( AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_entregarendirwwds_13_entdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like '%' + @lV70Bancos_entregarendirwwds_13_entdsc3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_entregarendirwwds_14_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV71Bancos_entregarendirwwds_14_cuedsc3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV67Bancos_entregarendirwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Bancos_entregarendirwwds_11_dynamicfiltersselector3, "CUEDSC") == 0 ) && ( AV69Bancos_entregarendirwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_entregarendirwwds_14_cuedsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like '%' + @lV71Bancos_entregarendirwwds_14_cuedsc3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (0==AV72Bancos_entregarendirwwds_15_tfentcod) )
         {
            AddWhere(sWhereString, "(T1.[EntCod] >= @AV72Bancos_entregarendirwwds_15_tfentcod)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (0==AV73Bancos_entregarendirwwds_16_tfentcod_to) )
         {
            AddWhere(sWhereString, "(T1.[EntCod] <= @AV73Bancos_entregarendirwwds_16_tfentcod_to)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_entregarendirwwds_18_tfentdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Bancos_entregarendirwwds_17_tfentdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] like @lV74Bancos_entregarendirwwds_17_tfentdsc)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Bancos_entregarendirwwds_18_tfentdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EntDsc] = @AV75Bancos_entregarendirwwds_18_tfentdsc_sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_entregarendirwwds_20_tfcuecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancos_entregarendirwwds_19_tfcuecod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] like @lV76Bancos_entregarendirwwds_19_tfcuecod)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancos_entregarendirwwds_20_tfcuecod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CueCod] = @AV77Bancos_entregarendirwwds_20_tfcuecod_sel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_entregarendirwwds_22_tfcuedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_entregarendirwwds_21_tfcuedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] like @lV78Bancos_entregarendirwwds_21_tfcuedsc)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Bancos_entregarendirwwds_22_tfcuedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[CueDsc] = @AV79Bancos_entregarendirwwds_22_tfcuedsc_sel)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV80Bancos_entregarendirwwds_23_tfentsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV80Bancos_entregarendirwwds_23_tfentsts_sels, "T1.[EntSts] IN (", ")")+")");
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
                     return conditional_P005S2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
               case 1 :
                     return conditional_P005S3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
               case 2 :
                     return conditional_P005S4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP005S2;
          prmP005S2 = new Object[] {
          new ParDef("@lV60Bancos_entregarendirwwds_3_entdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Bancos_entregarendirwwds_3_entdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_entregarendirwwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_entregarendirwwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_entregarendirwwds_8_entdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_entregarendirwwds_8_entdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Bancos_entregarendirwwds_9_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Bancos_entregarendirwwds_9_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_entregarendirwwds_13_entdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_entregarendirwwds_13_entdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV71Bancos_entregarendirwwds_14_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV71Bancos_entregarendirwwds_14_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV72Bancos_entregarendirwwds_15_tfentcod",GXType.Int32,6,0) ,
          new ParDef("@AV73Bancos_entregarendirwwds_16_tfentcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV74Bancos_entregarendirwwds_17_tfentdsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Bancos_entregarendirwwds_18_tfentdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV76Bancos_entregarendirwwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV77Bancos_entregarendirwwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV78Bancos_entregarendirwwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV79Bancos_entregarendirwwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP005S3;
          prmP005S3 = new Object[] {
          new ParDef("@lV60Bancos_entregarendirwwds_3_entdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Bancos_entregarendirwwds_3_entdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_entregarendirwwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_entregarendirwwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_entregarendirwwds_8_entdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_entregarendirwwds_8_entdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Bancos_entregarendirwwds_9_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Bancos_entregarendirwwds_9_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_entregarendirwwds_13_entdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_entregarendirwwds_13_entdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV71Bancos_entregarendirwwds_14_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV71Bancos_entregarendirwwds_14_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV72Bancos_entregarendirwwds_15_tfentcod",GXType.Int32,6,0) ,
          new ParDef("@AV73Bancos_entregarendirwwds_16_tfentcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV74Bancos_entregarendirwwds_17_tfentdsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Bancos_entregarendirwwds_18_tfentdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV76Bancos_entregarendirwwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV77Bancos_entregarendirwwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV78Bancos_entregarendirwwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV79Bancos_entregarendirwwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP005S4;
          prmP005S4 = new Object[] {
          new ParDef("@lV60Bancos_entregarendirwwds_3_entdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Bancos_entregarendirwwds_3_entdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_entregarendirwwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_entregarendirwwds_4_cuedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_entregarendirwwds_8_entdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_entregarendirwwds_8_entdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Bancos_entregarendirwwds_9_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV66Bancos_entregarendirwwds_9_cuedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_entregarendirwwds_13_entdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_entregarendirwwds_13_entdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV71Bancos_entregarendirwwds_14_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV71Bancos_entregarendirwwds_14_cuedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV72Bancos_entregarendirwwds_15_tfentcod",GXType.Int32,6,0) ,
          new ParDef("@AV73Bancos_entregarendirwwds_16_tfentcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV74Bancos_entregarendirwwds_17_tfentdsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Bancos_entregarendirwwds_18_tfentdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV76Bancos_entregarendirwwds_19_tfcuecod",GXType.NChar,15,0) ,
          new ParDef("@AV77Bancos_entregarendirwwds_20_tfcuecod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV78Bancos_entregarendirwwds_21_tfcuedsc",GXType.NChar,100,0) ,
          new ParDef("@AV79Bancos_entregarendirwwds_22_tfcuedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005S2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005S3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005S4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005S4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
