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
   public class monedaswwgetfilterdata : GXProcedure
   {
      public monedaswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public monedaswwgetfilterdata( IGxContext context )
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
         monedaswwgetfilterdata objmonedaswwgetfilterdata;
         objmonedaswwgetfilterdata = new monedaswwgetfilterdata();
         objmonedaswwgetfilterdata.AV22DDOName = aP0_DDOName;
         objmonedaswwgetfilterdata.AV20SearchTxt = aP1_SearchTxt;
         objmonedaswwgetfilterdata.AV21SearchTxtTo = aP2_SearchTxtTo;
         objmonedaswwgetfilterdata.AV26OptionsJson = "" ;
         objmonedaswwgetfilterdata.AV29OptionsDescJson = "" ;
         objmonedaswwgetfilterdata.AV31OptionIndexesJson = "" ;
         objmonedaswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objmonedaswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmonedaswwgetfilterdata);
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((monedaswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_MONDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADMONDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_MONABR") == 0 )
         {
            /* Execute user subroutine: 'LOADMONABROPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_MONSUNAT") == 0 )
         {
            /* Execute user subroutine: 'LOADMONSUNATOPTIONS' */
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
         if ( StringUtil.StrCmp(AV33Session.Get("Configuracion.MonedasWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.MonedasWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Configuracion.MonedasWWGridState"), null, "", "");
         }
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMONCOD") == 0 )
            {
               AV10TFMonCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV11TFMonCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMONDSC") == 0 )
            {
               AV12TFMonDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMONDSC_SEL") == 0 )
            {
               AV13TFMonDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMONABR") == 0 )
            {
               AV14TFMonAbr = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMONABR_SEL") == 0 )
            {
               AV15TFMonAbr_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMONSUNAT") == 0 )
            {
               AV18TFMonSunat = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMONSUNAT_SEL") == 0 )
            {
               AV19TFMonSunat_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMONSTS_SEL") == 0 )
            {
               AV49TFMonSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV50TFMonSts_Sels.FromJSonString(AV49TFMonSts_SelsJson, null);
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "MONDSC") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV40MonDsc1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "MONDSC") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV44MonDsc2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "MONDSC") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV48MonDsc3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADMONDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFMonDsc = AV20SearchTxt;
         AV13TFMonDsc_Sel = "";
         AV55Configuracion_monedaswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV57Configuracion_monedaswwds_3_mondsc1 = AV40MonDsc1;
         AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV59Configuracion_monedaswwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV61Configuracion_monedaswwds_7_mondsc2 = AV44MonDsc2;
         AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV63Configuracion_monedaswwds_9_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV65Configuracion_monedaswwds_11_mondsc3 = AV48MonDsc3;
         AV66Configuracion_monedaswwds_12_tfmoncod = AV10TFMonCod;
         AV67Configuracion_monedaswwds_13_tfmoncod_to = AV11TFMonCod_To;
         AV68Configuracion_monedaswwds_14_tfmondsc = AV12TFMonDsc;
         AV69Configuracion_monedaswwds_15_tfmondsc_sel = AV13TFMonDsc_Sel;
         AV70Configuracion_monedaswwds_16_tfmonabr = AV14TFMonAbr;
         AV71Configuracion_monedaswwds_17_tfmonabr_sel = AV15TFMonAbr_Sel;
         AV72Configuracion_monedaswwds_18_tfmonsunat = AV18TFMonSunat;
         AV73Configuracion_monedaswwds_19_tfmonsunat_sel = AV19TFMonSunat_Sel;
         AV74Configuracion_monedaswwds_20_tfmonsts_sels = AV50TFMonSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1235MonSts ,
                                              AV74Configuracion_monedaswwds_20_tfmonsts_sels ,
                                              AV55Configuracion_monedaswwds_1_dynamicfiltersselector1 ,
                                              AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 ,
                                              AV57Configuracion_monedaswwds_3_mondsc1 ,
                                              AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 ,
                                              AV59Configuracion_monedaswwds_5_dynamicfiltersselector2 ,
                                              AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 ,
                                              AV61Configuracion_monedaswwds_7_mondsc2 ,
                                              AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 ,
                                              AV63Configuracion_monedaswwds_9_dynamicfiltersselector3 ,
                                              AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 ,
                                              AV65Configuracion_monedaswwds_11_mondsc3 ,
                                              AV66Configuracion_monedaswwds_12_tfmoncod ,
                                              AV67Configuracion_monedaswwds_13_tfmoncod_to ,
                                              AV69Configuracion_monedaswwds_15_tfmondsc_sel ,
                                              AV68Configuracion_monedaswwds_14_tfmondsc ,
                                              AV71Configuracion_monedaswwds_17_tfmonabr_sel ,
                                              AV70Configuracion_monedaswwds_16_tfmonabr ,
                                              AV73Configuracion_monedaswwds_19_tfmonsunat_sel ,
                                              AV72Configuracion_monedaswwds_18_tfmonsunat ,
                                              AV74Configuracion_monedaswwds_20_tfmonsts_sels.Count ,
                                              A1234MonDsc ,
                                              A180MonCod ,
                                              A1233MonAbr ,
                                              A1236MonSunat } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV57Configuracion_monedaswwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_monedaswwds_3_mondsc1), 100, "%");
         lV57Configuracion_monedaswwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_monedaswwds_3_mondsc1), 100, "%");
         lV61Configuracion_monedaswwds_7_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_monedaswwds_7_mondsc2), 100, "%");
         lV61Configuracion_monedaswwds_7_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_monedaswwds_7_mondsc2), 100, "%");
         lV65Configuracion_monedaswwds_11_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_monedaswwds_11_mondsc3), 100, "%");
         lV65Configuracion_monedaswwds_11_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_monedaswwds_11_mondsc3), 100, "%");
         lV68Configuracion_monedaswwds_14_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_monedaswwds_14_tfmondsc), 100, "%");
         lV70Configuracion_monedaswwds_16_tfmonabr = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_monedaswwds_16_tfmonabr), 5, "%");
         lV72Configuracion_monedaswwds_18_tfmonsunat = StringUtil.Concat( StringUtil.RTrim( AV72Configuracion_monedaswwds_18_tfmonsunat), "%", "");
         /* Using cursor P004C2 */
         pr_default.execute(0, new Object[] {lV57Configuracion_monedaswwds_3_mondsc1, lV57Configuracion_monedaswwds_3_mondsc1, lV61Configuracion_monedaswwds_7_mondsc2, lV61Configuracion_monedaswwds_7_mondsc2, lV65Configuracion_monedaswwds_11_mondsc3, lV65Configuracion_monedaswwds_11_mondsc3, AV66Configuracion_monedaswwds_12_tfmoncod, AV67Configuracion_monedaswwds_13_tfmoncod_to, lV68Configuracion_monedaswwds_14_tfmondsc, AV69Configuracion_monedaswwds_15_tfmondsc_sel, lV70Configuracion_monedaswwds_16_tfmonabr, AV71Configuracion_monedaswwds_17_tfmonabr_sel, lV72Configuracion_monedaswwds_18_tfmonsunat, AV73Configuracion_monedaswwds_19_tfmonsunat_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4C2 = false;
            A1234MonDsc = P004C2_A1234MonDsc[0];
            A1235MonSts = P004C2_A1235MonSts[0];
            A1236MonSunat = P004C2_A1236MonSunat[0];
            A1233MonAbr = P004C2_A1233MonAbr[0];
            A180MonCod = P004C2_A180MonCod[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P004C2_A1234MonDsc[0], A1234MonDsc) == 0 ) )
            {
               BRK4C2 = false;
               A180MonCod = P004C2_A180MonCod[0];
               AV32count = (long)(AV32count+1);
               BRK4C2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1234MonDsc)) )
            {
               AV24Option = A1234MonDsc;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK4C2 )
            {
               BRK4C2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMONABROPTIONS' Routine */
         returnInSub = false;
         AV14TFMonAbr = AV20SearchTxt;
         AV15TFMonAbr_Sel = "";
         AV55Configuracion_monedaswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV57Configuracion_monedaswwds_3_mondsc1 = AV40MonDsc1;
         AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV59Configuracion_monedaswwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV61Configuracion_monedaswwds_7_mondsc2 = AV44MonDsc2;
         AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV63Configuracion_monedaswwds_9_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV65Configuracion_monedaswwds_11_mondsc3 = AV48MonDsc3;
         AV66Configuracion_monedaswwds_12_tfmoncod = AV10TFMonCod;
         AV67Configuracion_monedaswwds_13_tfmoncod_to = AV11TFMonCod_To;
         AV68Configuracion_monedaswwds_14_tfmondsc = AV12TFMonDsc;
         AV69Configuracion_monedaswwds_15_tfmondsc_sel = AV13TFMonDsc_Sel;
         AV70Configuracion_monedaswwds_16_tfmonabr = AV14TFMonAbr;
         AV71Configuracion_monedaswwds_17_tfmonabr_sel = AV15TFMonAbr_Sel;
         AV72Configuracion_monedaswwds_18_tfmonsunat = AV18TFMonSunat;
         AV73Configuracion_monedaswwds_19_tfmonsunat_sel = AV19TFMonSunat_Sel;
         AV74Configuracion_monedaswwds_20_tfmonsts_sels = AV50TFMonSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1235MonSts ,
                                              AV74Configuracion_monedaswwds_20_tfmonsts_sels ,
                                              AV55Configuracion_monedaswwds_1_dynamicfiltersselector1 ,
                                              AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 ,
                                              AV57Configuracion_monedaswwds_3_mondsc1 ,
                                              AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 ,
                                              AV59Configuracion_monedaswwds_5_dynamicfiltersselector2 ,
                                              AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 ,
                                              AV61Configuracion_monedaswwds_7_mondsc2 ,
                                              AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 ,
                                              AV63Configuracion_monedaswwds_9_dynamicfiltersselector3 ,
                                              AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 ,
                                              AV65Configuracion_monedaswwds_11_mondsc3 ,
                                              AV66Configuracion_monedaswwds_12_tfmoncod ,
                                              AV67Configuracion_monedaswwds_13_tfmoncod_to ,
                                              AV69Configuracion_monedaswwds_15_tfmondsc_sel ,
                                              AV68Configuracion_monedaswwds_14_tfmondsc ,
                                              AV71Configuracion_monedaswwds_17_tfmonabr_sel ,
                                              AV70Configuracion_monedaswwds_16_tfmonabr ,
                                              AV73Configuracion_monedaswwds_19_tfmonsunat_sel ,
                                              AV72Configuracion_monedaswwds_18_tfmonsunat ,
                                              AV74Configuracion_monedaswwds_20_tfmonsts_sels.Count ,
                                              A1234MonDsc ,
                                              A180MonCod ,
                                              A1233MonAbr ,
                                              A1236MonSunat } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV57Configuracion_monedaswwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_monedaswwds_3_mondsc1), 100, "%");
         lV57Configuracion_monedaswwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_monedaswwds_3_mondsc1), 100, "%");
         lV61Configuracion_monedaswwds_7_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_monedaswwds_7_mondsc2), 100, "%");
         lV61Configuracion_monedaswwds_7_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_monedaswwds_7_mondsc2), 100, "%");
         lV65Configuracion_monedaswwds_11_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_monedaswwds_11_mondsc3), 100, "%");
         lV65Configuracion_monedaswwds_11_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_monedaswwds_11_mondsc3), 100, "%");
         lV68Configuracion_monedaswwds_14_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_monedaswwds_14_tfmondsc), 100, "%");
         lV70Configuracion_monedaswwds_16_tfmonabr = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_monedaswwds_16_tfmonabr), 5, "%");
         lV72Configuracion_monedaswwds_18_tfmonsunat = StringUtil.Concat( StringUtil.RTrim( AV72Configuracion_monedaswwds_18_tfmonsunat), "%", "");
         /* Using cursor P004C3 */
         pr_default.execute(1, new Object[] {lV57Configuracion_monedaswwds_3_mondsc1, lV57Configuracion_monedaswwds_3_mondsc1, lV61Configuracion_monedaswwds_7_mondsc2, lV61Configuracion_monedaswwds_7_mondsc2, lV65Configuracion_monedaswwds_11_mondsc3, lV65Configuracion_monedaswwds_11_mondsc3, AV66Configuracion_monedaswwds_12_tfmoncod, AV67Configuracion_monedaswwds_13_tfmoncod_to, lV68Configuracion_monedaswwds_14_tfmondsc, AV69Configuracion_monedaswwds_15_tfmondsc_sel, lV70Configuracion_monedaswwds_16_tfmonabr, AV71Configuracion_monedaswwds_17_tfmonabr_sel, lV72Configuracion_monedaswwds_18_tfmonsunat, AV73Configuracion_monedaswwds_19_tfmonsunat_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4C4 = false;
            A1233MonAbr = P004C3_A1233MonAbr[0];
            A1235MonSts = P004C3_A1235MonSts[0];
            A1236MonSunat = P004C3_A1236MonSunat[0];
            A180MonCod = P004C3_A180MonCod[0];
            A1234MonDsc = P004C3_A1234MonDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P004C3_A1233MonAbr[0], A1233MonAbr) == 0 ) )
            {
               BRK4C4 = false;
               A180MonCod = P004C3_A180MonCod[0];
               AV32count = (long)(AV32count+1);
               BRK4C4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1233MonAbr)) )
            {
               AV24Option = A1233MonAbr;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK4C4 )
            {
               BRK4C4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADMONSUNATOPTIONS' Routine */
         returnInSub = false;
         AV18TFMonSunat = AV20SearchTxt;
         AV19TFMonSunat_Sel = "";
         AV55Configuracion_monedaswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV57Configuracion_monedaswwds_3_mondsc1 = AV40MonDsc1;
         AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV59Configuracion_monedaswwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV61Configuracion_monedaswwds_7_mondsc2 = AV44MonDsc2;
         AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV63Configuracion_monedaswwds_9_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV65Configuracion_monedaswwds_11_mondsc3 = AV48MonDsc3;
         AV66Configuracion_monedaswwds_12_tfmoncod = AV10TFMonCod;
         AV67Configuracion_monedaswwds_13_tfmoncod_to = AV11TFMonCod_To;
         AV68Configuracion_monedaswwds_14_tfmondsc = AV12TFMonDsc;
         AV69Configuracion_monedaswwds_15_tfmondsc_sel = AV13TFMonDsc_Sel;
         AV70Configuracion_monedaswwds_16_tfmonabr = AV14TFMonAbr;
         AV71Configuracion_monedaswwds_17_tfmonabr_sel = AV15TFMonAbr_Sel;
         AV72Configuracion_monedaswwds_18_tfmonsunat = AV18TFMonSunat;
         AV73Configuracion_monedaswwds_19_tfmonsunat_sel = AV19TFMonSunat_Sel;
         AV74Configuracion_monedaswwds_20_tfmonsts_sels = AV50TFMonSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A1235MonSts ,
                                              AV74Configuracion_monedaswwds_20_tfmonsts_sels ,
                                              AV55Configuracion_monedaswwds_1_dynamicfiltersselector1 ,
                                              AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 ,
                                              AV57Configuracion_monedaswwds_3_mondsc1 ,
                                              AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 ,
                                              AV59Configuracion_monedaswwds_5_dynamicfiltersselector2 ,
                                              AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 ,
                                              AV61Configuracion_monedaswwds_7_mondsc2 ,
                                              AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 ,
                                              AV63Configuracion_monedaswwds_9_dynamicfiltersselector3 ,
                                              AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 ,
                                              AV65Configuracion_monedaswwds_11_mondsc3 ,
                                              AV66Configuracion_monedaswwds_12_tfmoncod ,
                                              AV67Configuracion_monedaswwds_13_tfmoncod_to ,
                                              AV69Configuracion_monedaswwds_15_tfmondsc_sel ,
                                              AV68Configuracion_monedaswwds_14_tfmondsc ,
                                              AV71Configuracion_monedaswwds_17_tfmonabr_sel ,
                                              AV70Configuracion_monedaswwds_16_tfmonabr ,
                                              AV73Configuracion_monedaswwds_19_tfmonsunat_sel ,
                                              AV72Configuracion_monedaswwds_18_tfmonsunat ,
                                              AV74Configuracion_monedaswwds_20_tfmonsts_sels.Count ,
                                              A1234MonDsc ,
                                              A180MonCod ,
                                              A1233MonAbr ,
                                              A1236MonSunat } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV57Configuracion_monedaswwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_monedaswwds_3_mondsc1), 100, "%");
         lV57Configuracion_monedaswwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_monedaswwds_3_mondsc1), 100, "%");
         lV61Configuracion_monedaswwds_7_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_monedaswwds_7_mondsc2), 100, "%");
         lV61Configuracion_monedaswwds_7_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_monedaswwds_7_mondsc2), 100, "%");
         lV65Configuracion_monedaswwds_11_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_monedaswwds_11_mondsc3), 100, "%");
         lV65Configuracion_monedaswwds_11_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_monedaswwds_11_mondsc3), 100, "%");
         lV68Configuracion_monedaswwds_14_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_monedaswwds_14_tfmondsc), 100, "%");
         lV70Configuracion_monedaswwds_16_tfmonabr = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_monedaswwds_16_tfmonabr), 5, "%");
         lV72Configuracion_monedaswwds_18_tfmonsunat = StringUtil.Concat( StringUtil.RTrim( AV72Configuracion_monedaswwds_18_tfmonsunat), "%", "");
         /* Using cursor P004C4 */
         pr_default.execute(2, new Object[] {lV57Configuracion_monedaswwds_3_mondsc1, lV57Configuracion_monedaswwds_3_mondsc1, lV61Configuracion_monedaswwds_7_mondsc2, lV61Configuracion_monedaswwds_7_mondsc2, lV65Configuracion_monedaswwds_11_mondsc3, lV65Configuracion_monedaswwds_11_mondsc3, AV66Configuracion_monedaswwds_12_tfmoncod, AV67Configuracion_monedaswwds_13_tfmoncod_to, lV68Configuracion_monedaswwds_14_tfmondsc, AV69Configuracion_monedaswwds_15_tfmondsc_sel, lV70Configuracion_monedaswwds_16_tfmonabr, AV71Configuracion_monedaswwds_17_tfmonabr_sel, lV72Configuracion_monedaswwds_18_tfmonsunat, AV73Configuracion_monedaswwds_19_tfmonsunat_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK4C6 = false;
            A1236MonSunat = P004C4_A1236MonSunat[0];
            A1235MonSts = P004C4_A1235MonSts[0];
            A1233MonAbr = P004C4_A1233MonAbr[0];
            A180MonCod = P004C4_A180MonCod[0];
            A1234MonDsc = P004C4_A1234MonDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P004C4_A1236MonSunat[0], A1236MonSunat) == 0 ) )
            {
               BRK4C6 = false;
               A180MonCod = P004C4_A180MonCod[0];
               AV32count = (long)(AV32count+1);
               BRK4C6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1236MonSunat)) )
            {
               AV24Option = A1236MonSunat;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK4C6 )
            {
               BRK4C6 = true;
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
         AV12TFMonDsc = "";
         AV13TFMonDsc_Sel = "";
         AV14TFMonAbr = "";
         AV15TFMonAbr_Sel = "";
         AV18TFMonSunat = "";
         AV19TFMonSunat_Sel = "";
         AV49TFMonSts_SelsJson = "";
         AV50TFMonSts_Sels = new GxSimpleCollection<short>();
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40MonDsc1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44MonDsc2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48MonDsc3 = "";
         AV55Configuracion_monedaswwds_1_dynamicfiltersselector1 = "";
         AV57Configuracion_monedaswwds_3_mondsc1 = "";
         AV59Configuracion_monedaswwds_5_dynamicfiltersselector2 = "";
         AV61Configuracion_monedaswwds_7_mondsc2 = "";
         AV63Configuracion_monedaswwds_9_dynamicfiltersselector3 = "";
         AV65Configuracion_monedaswwds_11_mondsc3 = "";
         AV68Configuracion_monedaswwds_14_tfmondsc = "";
         AV69Configuracion_monedaswwds_15_tfmondsc_sel = "";
         AV70Configuracion_monedaswwds_16_tfmonabr = "";
         AV71Configuracion_monedaswwds_17_tfmonabr_sel = "";
         AV72Configuracion_monedaswwds_18_tfmonsunat = "";
         AV73Configuracion_monedaswwds_19_tfmonsunat_sel = "";
         AV74Configuracion_monedaswwds_20_tfmonsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV57Configuracion_monedaswwds_3_mondsc1 = "";
         lV61Configuracion_monedaswwds_7_mondsc2 = "";
         lV65Configuracion_monedaswwds_11_mondsc3 = "";
         lV68Configuracion_monedaswwds_14_tfmondsc = "";
         lV70Configuracion_monedaswwds_16_tfmonabr = "";
         lV72Configuracion_monedaswwds_18_tfmonsunat = "";
         A1234MonDsc = "";
         A1233MonAbr = "";
         A1236MonSunat = "";
         P004C2_A1234MonDsc = new string[] {""} ;
         P004C2_A1235MonSts = new short[1] ;
         P004C2_A1236MonSunat = new string[] {""} ;
         P004C2_A1233MonAbr = new string[] {""} ;
         P004C2_A180MonCod = new int[1] ;
         AV24Option = "";
         P004C3_A1233MonAbr = new string[] {""} ;
         P004C3_A1235MonSts = new short[1] ;
         P004C3_A1236MonSunat = new string[] {""} ;
         P004C3_A180MonCod = new int[1] ;
         P004C3_A1234MonDsc = new string[] {""} ;
         P004C4_A1236MonSunat = new string[] {""} ;
         P004C4_A1235MonSts = new short[1] ;
         P004C4_A1233MonAbr = new string[] {""} ;
         P004C4_A180MonCod = new int[1] ;
         P004C4_A1234MonDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.monedaswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004C2_A1234MonDsc, P004C2_A1235MonSts, P004C2_A1236MonSunat, P004C2_A1233MonAbr, P004C2_A180MonCod
               }
               , new Object[] {
               P004C3_A1233MonAbr, P004C3_A1235MonSts, P004C3_A1236MonSunat, P004C3_A180MonCod, P004C3_A1234MonDsc
               }
               , new Object[] {
               P004C4_A1236MonSunat, P004C4_A1235MonSts, P004C4_A1233MonAbr, P004C4_A180MonCod, P004C4_A1234MonDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 ;
      private short AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 ;
      private short AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 ;
      private short A1235MonSts ;
      private int AV53GXV1 ;
      private int AV10TFMonCod ;
      private int AV11TFMonCod_To ;
      private int AV66Configuracion_monedaswwds_12_tfmoncod ;
      private int AV67Configuracion_monedaswwds_13_tfmoncod_to ;
      private int AV74Configuracion_monedaswwds_20_tfmonsts_sels_Count ;
      private int A180MonCod ;
      private long AV32count ;
      private string AV12TFMonDsc ;
      private string AV13TFMonDsc_Sel ;
      private string AV14TFMonAbr ;
      private string AV15TFMonAbr_Sel ;
      private string AV40MonDsc1 ;
      private string AV44MonDsc2 ;
      private string AV48MonDsc3 ;
      private string AV57Configuracion_monedaswwds_3_mondsc1 ;
      private string AV61Configuracion_monedaswwds_7_mondsc2 ;
      private string AV65Configuracion_monedaswwds_11_mondsc3 ;
      private string AV68Configuracion_monedaswwds_14_tfmondsc ;
      private string AV69Configuracion_monedaswwds_15_tfmondsc_sel ;
      private string AV70Configuracion_monedaswwds_16_tfmonabr ;
      private string AV71Configuracion_monedaswwds_17_tfmonabr_sel ;
      private string scmdbuf ;
      private string lV57Configuracion_monedaswwds_3_mondsc1 ;
      private string lV61Configuracion_monedaswwds_7_mondsc2 ;
      private string lV65Configuracion_monedaswwds_11_mondsc3 ;
      private string lV68Configuracion_monedaswwds_14_tfmondsc ;
      private string lV70Configuracion_monedaswwds_16_tfmonabr ;
      private string A1234MonDsc ;
      private string A1233MonAbr ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 ;
      private bool AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 ;
      private bool BRK4C2 ;
      private bool BRK4C4 ;
      private bool BRK4C6 ;
      private string AV26OptionsJson ;
      private string AV29OptionsDescJson ;
      private string AV31OptionIndexesJson ;
      private string AV49TFMonSts_SelsJson ;
      private string AV22DDOName ;
      private string AV20SearchTxt ;
      private string AV21SearchTxtTo ;
      private string AV18TFMonSunat ;
      private string AV19TFMonSunat_Sel ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV55Configuracion_monedaswwds_1_dynamicfiltersselector1 ;
      private string AV59Configuracion_monedaswwds_5_dynamicfiltersselector2 ;
      private string AV63Configuracion_monedaswwds_9_dynamicfiltersselector3 ;
      private string AV72Configuracion_monedaswwds_18_tfmonsunat ;
      private string AV73Configuracion_monedaswwds_19_tfmonsunat_sel ;
      private string lV72Configuracion_monedaswwds_18_tfmonsunat ;
      private string A1236MonSunat ;
      private string AV24Option ;
      private GxSimpleCollection<short> AV50TFMonSts_Sels ;
      private GxSimpleCollection<short> AV74Configuracion_monedaswwds_20_tfmonsts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004C2_A1234MonDsc ;
      private short[] P004C2_A1235MonSts ;
      private string[] P004C2_A1236MonSunat ;
      private string[] P004C2_A1233MonAbr ;
      private int[] P004C2_A180MonCod ;
      private string[] P004C3_A1233MonAbr ;
      private short[] P004C3_A1235MonSts ;
      private string[] P004C3_A1236MonSunat ;
      private int[] P004C3_A180MonCod ;
      private string[] P004C3_A1234MonDsc ;
      private string[] P004C4_A1236MonSunat ;
      private short[] P004C4_A1235MonSts ;
      private string[] P004C4_A1233MonAbr ;
      private int[] P004C4_A180MonCod ;
      private string[] P004C4_A1234MonDsc ;
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

   public class monedaswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004C2( IGxContext context ,
                                             short A1235MonSts ,
                                             GxSimpleCollection<short> AV74Configuracion_monedaswwds_20_tfmonsts_sels ,
                                             string AV55Configuracion_monedaswwds_1_dynamicfiltersselector1 ,
                                             short AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 ,
                                             string AV57Configuracion_monedaswwds_3_mondsc1 ,
                                             bool AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 ,
                                             string AV59Configuracion_monedaswwds_5_dynamicfiltersselector2 ,
                                             short AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 ,
                                             string AV61Configuracion_monedaswwds_7_mondsc2 ,
                                             bool AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 ,
                                             string AV63Configuracion_monedaswwds_9_dynamicfiltersselector3 ,
                                             short AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 ,
                                             string AV65Configuracion_monedaswwds_11_mondsc3 ,
                                             int AV66Configuracion_monedaswwds_12_tfmoncod ,
                                             int AV67Configuracion_monedaswwds_13_tfmoncod_to ,
                                             string AV69Configuracion_monedaswwds_15_tfmondsc_sel ,
                                             string AV68Configuracion_monedaswwds_14_tfmondsc ,
                                             string AV71Configuracion_monedaswwds_17_tfmonabr_sel ,
                                             string AV70Configuracion_monedaswwds_16_tfmonabr ,
                                             string AV73Configuracion_monedaswwds_19_tfmonsunat_sel ,
                                             string AV72Configuracion_monedaswwds_18_tfmonsunat ,
                                             int AV74Configuracion_monedaswwds_20_tfmonsts_sels_Count ,
                                             string A1234MonDsc ,
                                             int A180MonCod ,
                                             string A1233MonAbr ,
                                             string A1236MonSunat )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [MonDsc], [MonSts], [MonSunat], [MonAbr], [MonCod] FROM [CMONEDAS]";
         if ( ( StringUtil.StrCmp(AV55Configuracion_monedaswwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_monedaswwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV57Configuracion_monedaswwds_3_mondsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_monedaswwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_monedaswwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV57Configuracion_monedaswwds_3_mondsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_monedaswwds_5_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_monedaswwds_7_mondsc2)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV61Configuracion_monedaswwds_7_mondsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_monedaswwds_5_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_monedaswwds_7_mondsc2)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV61Configuracion_monedaswwds_7_mondsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_monedaswwds_9_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_monedaswwds_11_mondsc3)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV65Configuracion_monedaswwds_11_mondsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_monedaswwds_9_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_monedaswwds_11_mondsc3)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV65Configuracion_monedaswwds_11_mondsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV66Configuracion_monedaswwds_12_tfmoncod) )
         {
            AddWhere(sWhereString, "([MonCod] >= @AV66Configuracion_monedaswwds_12_tfmoncod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV67Configuracion_monedaswwds_13_tfmoncod_to) )
         {
            AddWhere(sWhereString, "([MonCod] <= @AV67Configuracion_monedaswwds_13_tfmoncod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_monedaswwds_15_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_monedaswwds_14_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV68Configuracion_monedaswwds_14_tfmondsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_monedaswwds_15_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "([MonDsc] = @AV69Configuracion_monedaswwds_15_tfmondsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_monedaswwds_17_tfmonabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_monedaswwds_16_tfmonabr)) ) )
         {
            AddWhere(sWhereString, "([MonAbr] like @lV70Configuracion_monedaswwds_16_tfmonabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_monedaswwds_17_tfmonabr_sel)) )
         {
            AddWhere(sWhereString, "([MonAbr] = @AV71Configuracion_monedaswwds_17_tfmonabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_monedaswwds_19_tfmonsunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_monedaswwds_18_tfmonsunat)) ) )
         {
            AddWhere(sWhereString, "([MonSunat] like @lV72Configuracion_monedaswwds_18_tfmonsunat)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_monedaswwds_19_tfmonsunat_sel)) )
         {
            AddWhere(sWhereString, "([MonSunat] = @AV73Configuracion_monedaswwds_19_tfmonsunat_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV74Configuracion_monedaswwds_20_tfmonsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Configuracion_monedaswwds_20_tfmonsts_sels, "[MonSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MonDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P004C3( IGxContext context ,
                                             short A1235MonSts ,
                                             GxSimpleCollection<short> AV74Configuracion_monedaswwds_20_tfmonsts_sels ,
                                             string AV55Configuracion_monedaswwds_1_dynamicfiltersselector1 ,
                                             short AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 ,
                                             string AV57Configuracion_monedaswwds_3_mondsc1 ,
                                             bool AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 ,
                                             string AV59Configuracion_monedaswwds_5_dynamicfiltersselector2 ,
                                             short AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 ,
                                             string AV61Configuracion_monedaswwds_7_mondsc2 ,
                                             bool AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 ,
                                             string AV63Configuracion_monedaswwds_9_dynamicfiltersselector3 ,
                                             short AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 ,
                                             string AV65Configuracion_monedaswwds_11_mondsc3 ,
                                             int AV66Configuracion_monedaswwds_12_tfmoncod ,
                                             int AV67Configuracion_monedaswwds_13_tfmoncod_to ,
                                             string AV69Configuracion_monedaswwds_15_tfmondsc_sel ,
                                             string AV68Configuracion_monedaswwds_14_tfmondsc ,
                                             string AV71Configuracion_monedaswwds_17_tfmonabr_sel ,
                                             string AV70Configuracion_monedaswwds_16_tfmonabr ,
                                             string AV73Configuracion_monedaswwds_19_tfmonsunat_sel ,
                                             string AV72Configuracion_monedaswwds_18_tfmonsunat ,
                                             int AV74Configuracion_monedaswwds_20_tfmonsts_sels_Count ,
                                             string A1234MonDsc ,
                                             int A180MonCod ,
                                             string A1233MonAbr ,
                                             string A1236MonSunat )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [MonAbr], [MonSts], [MonSunat], [MonCod], [MonDsc] FROM [CMONEDAS]";
         if ( ( StringUtil.StrCmp(AV55Configuracion_monedaswwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_monedaswwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV57Configuracion_monedaswwds_3_mondsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_monedaswwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_monedaswwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV57Configuracion_monedaswwds_3_mondsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_monedaswwds_5_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_monedaswwds_7_mondsc2)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV61Configuracion_monedaswwds_7_mondsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_monedaswwds_5_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_monedaswwds_7_mondsc2)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV61Configuracion_monedaswwds_7_mondsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_monedaswwds_9_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_monedaswwds_11_mondsc3)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV65Configuracion_monedaswwds_11_mondsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_monedaswwds_9_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_monedaswwds_11_mondsc3)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV65Configuracion_monedaswwds_11_mondsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV66Configuracion_monedaswwds_12_tfmoncod) )
         {
            AddWhere(sWhereString, "([MonCod] >= @AV66Configuracion_monedaswwds_12_tfmoncod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV67Configuracion_monedaswwds_13_tfmoncod_to) )
         {
            AddWhere(sWhereString, "([MonCod] <= @AV67Configuracion_monedaswwds_13_tfmoncod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_monedaswwds_15_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_monedaswwds_14_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV68Configuracion_monedaswwds_14_tfmondsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_monedaswwds_15_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "([MonDsc] = @AV69Configuracion_monedaswwds_15_tfmondsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_monedaswwds_17_tfmonabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_monedaswwds_16_tfmonabr)) ) )
         {
            AddWhere(sWhereString, "([MonAbr] like @lV70Configuracion_monedaswwds_16_tfmonabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_monedaswwds_17_tfmonabr_sel)) )
         {
            AddWhere(sWhereString, "([MonAbr] = @AV71Configuracion_monedaswwds_17_tfmonabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_monedaswwds_19_tfmonsunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_monedaswwds_18_tfmonsunat)) ) )
         {
            AddWhere(sWhereString, "([MonSunat] like @lV72Configuracion_monedaswwds_18_tfmonsunat)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_monedaswwds_19_tfmonsunat_sel)) )
         {
            AddWhere(sWhereString, "([MonSunat] = @AV73Configuracion_monedaswwds_19_tfmonsunat_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV74Configuracion_monedaswwds_20_tfmonsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Configuracion_monedaswwds_20_tfmonsts_sels, "[MonSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MonAbr]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P004C4( IGxContext context ,
                                             short A1235MonSts ,
                                             GxSimpleCollection<short> AV74Configuracion_monedaswwds_20_tfmonsts_sels ,
                                             string AV55Configuracion_monedaswwds_1_dynamicfiltersselector1 ,
                                             short AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 ,
                                             string AV57Configuracion_monedaswwds_3_mondsc1 ,
                                             bool AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 ,
                                             string AV59Configuracion_monedaswwds_5_dynamicfiltersselector2 ,
                                             short AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 ,
                                             string AV61Configuracion_monedaswwds_7_mondsc2 ,
                                             bool AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 ,
                                             string AV63Configuracion_monedaswwds_9_dynamicfiltersselector3 ,
                                             short AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 ,
                                             string AV65Configuracion_monedaswwds_11_mondsc3 ,
                                             int AV66Configuracion_monedaswwds_12_tfmoncod ,
                                             int AV67Configuracion_monedaswwds_13_tfmoncod_to ,
                                             string AV69Configuracion_monedaswwds_15_tfmondsc_sel ,
                                             string AV68Configuracion_monedaswwds_14_tfmondsc ,
                                             string AV71Configuracion_monedaswwds_17_tfmonabr_sel ,
                                             string AV70Configuracion_monedaswwds_16_tfmonabr ,
                                             string AV73Configuracion_monedaswwds_19_tfmonsunat_sel ,
                                             string AV72Configuracion_monedaswwds_18_tfmonsunat ,
                                             int AV74Configuracion_monedaswwds_20_tfmonsts_sels_Count ,
                                             string A1234MonDsc ,
                                             int A180MonCod ,
                                             string A1233MonAbr ,
                                             string A1236MonSunat )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[14];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [MonSunat], [MonSts], [MonAbr], [MonCod], [MonDsc] FROM [CMONEDAS]";
         if ( ( StringUtil.StrCmp(AV55Configuracion_monedaswwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_monedaswwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV57Configuracion_monedaswwds_3_mondsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_monedaswwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV56Configuracion_monedaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_monedaswwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV57Configuracion_monedaswwds_3_mondsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_monedaswwds_5_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_monedaswwds_7_mondsc2)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV61Configuracion_monedaswwds_7_mondsc2)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV58Configuracion_monedaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_monedaswwds_5_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV60Configuracion_monedaswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_monedaswwds_7_mondsc2)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV61Configuracion_monedaswwds_7_mondsc2)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_monedaswwds_9_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_monedaswwds_11_mondsc3)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV65Configuracion_monedaswwds_11_mondsc3)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV62Configuracion_monedaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_monedaswwds_9_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV64Configuracion_monedaswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_monedaswwds_11_mondsc3)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like '%' + @lV65Configuracion_monedaswwds_11_mondsc3)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV66Configuracion_monedaswwds_12_tfmoncod) )
         {
            AddWhere(sWhereString, "([MonCod] >= @AV66Configuracion_monedaswwds_12_tfmoncod)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV67Configuracion_monedaswwds_13_tfmoncod_to) )
         {
            AddWhere(sWhereString, "([MonCod] <= @AV67Configuracion_monedaswwds_13_tfmoncod_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_monedaswwds_15_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_monedaswwds_14_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "([MonDsc] like @lV68Configuracion_monedaswwds_14_tfmondsc)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_monedaswwds_15_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "([MonDsc] = @AV69Configuracion_monedaswwds_15_tfmondsc_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_monedaswwds_17_tfmonabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_monedaswwds_16_tfmonabr)) ) )
         {
            AddWhere(sWhereString, "([MonAbr] like @lV70Configuracion_monedaswwds_16_tfmonabr)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_monedaswwds_17_tfmonabr_sel)) )
         {
            AddWhere(sWhereString, "([MonAbr] = @AV71Configuracion_monedaswwds_17_tfmonabr_sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_monedaswwds_19_tfmonsunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_monedaswwds_18_tfmonsunat)) ) )
         {
            AddWhere(sWhereString, "([MonSunat] like @lV72Configuracion_monedaswwds_18_tfmonsunat)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_monedaswwds_19_tfmonsunat_sel)) )
         {
            AddWhere(sWhereString, "([MonSunat] = @AV73Configuracion_monedaswwds_19_tfmonsunat_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV74Configuracion_monedaswwds_20_tfmonsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Configuracion_monedaswwds_20_tfmonsts_sels, "[MonSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MonSunat]";
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
                     return conditional_P004C2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
               case 1 :
                     return conditional_P004C3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
               case 2 :
                     return conditional_P004C4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
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
          Object[] prmP004C2;
          prmP004C2 = new Object[] {
          new ParDef("@lV57Configuracion_monedaswwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_monedaswwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_monedaswwds_7_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_monedaswwds_7_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_monedaswwds_11_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_monedaswwds_11_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@AV66Configuracion_monedaswwds_12_tfmoncod",GXType.Int32,6,0) ,
          new ParDef("@AV67Configuracion_monedaswwds_13_tfmoncod_to",GXType.Int32,6,0) ,
          new ParDef("@lV68Configuracion_monedaswwds_14_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV69Configuracion_monedaswwds_15_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_monedaswwds_16_tfmonabr",GXType.NChar,5,0) ,
          new ParDef("@AV71Configuracion_monedaswwds_17_tfmonabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV72Configuracion_monedaswwds_18_tfmonsunat",GXType.NVarChar,3,0) ,
          new ParDef("@AV73Configuracion_monedaswwds_19_tfmonsunat_sel",GXType.NVarChar,3,0)
          };
          Object[] prmP004C3;
          prmP004C3 = new Object[] {
          new ParDef("@lV57Configuracion_monedaswwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_monedaswwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_monedaswwds_7_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_monedaswwds_7_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_monedaswwds_11_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_monedaswwds_11_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@AV66Configuracion_monedaswwds_12_tfmoncod",GXType.Int32,6,0) ,
          new ParDef("@AV67Configuracion_monedaswwds_13_tfmoncod_to",GXType.Int32,6,0) ,
          new ParDef("@lV68Configuracion_monedaswwds_14_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV69Configuracion_monedaswwds_15_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_monedaswwds_16_tfmonabr",GXType.NChar,5,0) ,
          new ParDef("@AV71Configuracion_monedaswwds_17_tfmonabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV72Configuracion_monedaswwds_18_tfmonsunat",GXType.NVarChar,3,0) ,
          new ParDef("@AV73Configuracion_monedaswwds_19_tfmonsunat_sel",GXType.NVarChar,3,0)
          };
          Object[] prmP004C4;
          prmP004C4 = new Object[] {
          new ParDef("@lV57Configuracion_monedaswwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_monedaswwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_monedaswwds_7_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_monedaswwds_7_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_monedaswwds_11_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_monedaswwds_11_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@AV66Configuracion_monedaswwds_12_tfmoncod",GXType.Int32,6,0) ,
          new ParDef("@AV67Configuracion_monedaswwds_13_tfmoncod_to",GXType.Int32,6,0) ,
          new ParDef("@lV68Configuracion_monedaswwds_14_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV69Configuracion_monedaswwds_15_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_monedaswwds_16_tfmonabr",GXType.NChar,5,0) ,
          new ParDef("@AV71Configuracion_monedaswwds_17_tfmonabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV72Configuracion_monedaswwds_18_tfmonsunat",GXType.NVarChar,3,0) ,
          new ParDef("@AV73Configuracion_monedaswwds_19_tfmonsunat_sel",GXType.NVarChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004C2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004C3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004C4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004C4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
