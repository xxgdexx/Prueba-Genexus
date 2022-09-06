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
   public class distritoswwgetfilterdata : GXProcedure
   {
      public distritoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public distritoswwgetfilterdata( IGxContext context )
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
         this.AV26DDOName = aP0_DDOName;
         this.AV24SearchTxt = aP1_SearchTxt;
         this.AV25SearchTxtTo = aP2_SearchTxtTo;
         this.AV30OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV30OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV35OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         distritoswwgetfilterdata objdistritoswwgetfilterdata;
         objdistritoswwgetfilterdata = new distritoswwgetfilterdata();
         objdistritoswwgetfilterdata.AV26DDOName = aP0_DDOName;
         objdistritoswwgetfilterdata.AV24SearchTxt = aP1_SearchTxt;
         objdistritoswwgetfilterdata.AV25SearchTxtTo = aP2_SearchTxtTo;
         objdistritoswwgetfilterdata.AV30OptionsJson = "" ;
         objdistritoswwgetfilterdata.AV33OptionsDescJson = "" ;
         objdistritoswwgetfilterdata.AV35OptionIndexesJson = "" ;
         objdistritoswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objdistritoswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdistritoswwgetfilterdata);
         aP3_OptionsJson=this.AV30OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((distritoswwgetfilterdata)stateInfo).executePrivate();
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
         AV29Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV26DDOName), "DDO_DISCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADDISCODOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV26DDOName), "DDO_DISDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADDISDSCOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV26DDOName), "DDO_PAIDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADPAIDSCOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV30OptionsJson = AV29Options.ToJSonString(false);
         AV33OptionsDescJson = AV32OptionsDesc.ToJSonString(false);
         AV35OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get("Configuracion.DistritosWWGridState"), "") == 0 )
         {
            AV39GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.DistritosWWGridState"), null, "", "");
         }
         else
         {
            AV39GridState.FromXml(AV37Session.Get("Configuracion.DistritosWWGridState"), null, "", "");
         }
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV39GridState.gxTpr_Filtervalues.Count )
         {
            AV40GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV39GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFDISCOD") == 0 )
            {
               AV14TFDisCod = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFDISCOD_SEL") == 0 )
            {
               AV15TFDisCod_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFDISDSC") == 0 )
            {
               AV18TFDisDsc = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFDISDSC_SEL") == 0 )
            {
               AV19TFDisDsc_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPAIDSC") == 0 )
            {
               AV16TFPaiDsc = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFPAIDSC_SEL") == 0 )
            {
               AV17TFPaiDsc_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFDISSTS_SEL") == 0 )
            {
               AV22TFDisSts_SelsJson = AV40GridStateFilterValue.gxTpr_Value;
               AV23TFDisSts_Sels.FromJSonString(AV22TFDisSts_SelsJson, null);
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
         if ( AV39GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV41GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV39GridState.gxTpr_Dynamicfilters.Item(1));
            AV42DynamicFiltersSelector1 = AV41GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV42DynamicFiltersSelector1, "DISDSC") == 0 )
            {
               AV43DynamicFiltersOperator1 = AV41GridStateDynamicFilter.gxTpr_Operator;
               AV44DisDsc1 = AV41GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV39GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV45DynamicFiltersEnabled2 = true;
               AV41GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV39GridState.gxTpr_Dynamicfilters.Item(2));
               AV46DynamicFiltersSelector2 = AV41GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "DISDSC") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV41GridStateDynamicFilter.gxTpr_Operator;
                  AV48DisDsc2 = AV41GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV39GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV41GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV39GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV41GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "DISDSC") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV41GridStateDynamicFilter.gxTpr_Operator;
                     AV52DisDsc3 = AV41GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADDISCODOPTIONS' Routine */
         returnInSub = false;
         AV14TFDisCod = AV24SearchTxt;
         AV15TFDisCod_Sel = "";
         AV57Configuracion_distritoswwds_1_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV59Configuracion_distritoswwds_3_disdsc1 = AV44DisDsc1;
         AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV61Configuracion_distritoswwds_5_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV63Configuracion_distritoswwds_7_disdsc2 = AV48DisDsc2;
         AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV65Configuracion_distritoswwds_9_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV67Configuracion_distritoswwds_11_disdsc3 = AV52DisDsc3;
         AV68Configuracion_distritoswwds_12_tfdiscod = AV14TFDisCod;
         AV69Configuracion_distritoswwds_13_tfdiscod_sel = AV15TFDisCod_Sel;
         AV70Configuracion_distritoswwds_14_tfdisdsc = AV18TFDisDsc;
         AV71Configuracion_distritoswwds_15_tfdisdsc_sel = AV19TFDisDsc_Sel;
         AV72Configuracion_distritoswwds_16_tfpaidsc = AV16TFPaiDsc;
         AV73Configuracion_distritoswwds_17_tfpaidsc_sel = AV17TFPaiDsc_Sel;
         AV74Configuracion_distritoswwds_18_tfdissts_sels = AV23TFDisSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A878DisSts ,
                                              AV74Configuracion_distritoswwds_18_tfdissts_sels ,
                                              AV57Configuracion_distritoswwds_1_dynamicfiltersselector1 ,
                                              AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 ,
                                              AV59Configuracion_distritoswwds_3_disdsc1 ,
                                              AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 ,
                                              AV61Configuracion_distritoswwds_5_dynamicfiltersselector2 ,
                                              AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 ,
                                              AV63Configuracion_distritoswwds_7_disdsc2 ,
                                              AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 ,
                                              AV65Configuracion_distritoswwds_9_dynamicfiltersselector3 ,
                                              AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 ,
                                              AV67Configuracion_distritoswwds_11_disdsc3 ,
                                              AV69Configuracion_distritoswwds_13_tfdiscod_sel ,
                                              AV68Configuracion_distritoswwds_12_tfdiscod ,
                                              AV71Configuracion_distritoswwds_15_tfdisdsc_sel ,
                                              AV70Configuracion_distritoswwds_14_tfdisdsc ,
                                              AV73Configuracion_distritoswwds_17_tfpaidsc_sel ,
                                              AV72Configuracion_distritoswwds_16_tfpaidsc ,
                                              AV74Configuracion_distritoswwds_18_tfdissts_sels.Count ,
                                              A604DisDsc ,
                                              A142DisCod ,
                                              A1500PaiDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV59Configuracion_distritoswwds_3_disdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_distritoswwds_3_disdsc1), 100, "%");
         lV59Configuracion_distritoswwds_3_disdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_distritoswwds_3_disdsc1), 100, "%");
         lV63Configuracion_distritoswwds_7_disdsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_distritoswwds_7_disdsc2), 100, "%");
         lV63Configuracion_distritoswwds_7_disdsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_distritoswwds_7_disdsc2), 100, "%");
         lV67Configuracion_distritoswwds_11_disdsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_distritoswwds_11_disdsc3), 100, "%");
         lV67Configuracion_distritoswwds_11_disdsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_distritoswwds_11_disdsc3), 100, "%");
         lV68Configuracion_distritoswwds_12_tfdiscod = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_distritoswwds_12_tfdiscod), 4, "%");
         lV70Configuracion_distritoswwds_14_tfdisdsc = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_distritoswwds_14_tfdisdsc), 100, "%");
         lV72Configuracion_distritoswwds_16_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_distritoswwds_16_tfpaidsc), 100, "%");
         /* Using cursor P003W2 */
         pr_default.execute(0, new Object[] {lV59Configuracion_distritoswwds_3_disdsc1, lV59Configuracion_distritoswwds_3_disdsc1, lV63Configuracion_distritoswwds_7_disdsc2, lV63Configuracion_distritoswwds_7_disdsc2, lV67Configuracion_distritoswwds_11_disdsc3, lV67Configuracion_distritoswwds_11_disdsc3, lV68Configuracion_distritoswwds_12_tfdiscod, AV69Configuracion_distritoswwds_13_tfdiscod_sel, lV70Configuracion_distritoswwds_14_tfdisdsc, AV71Configuracion_distritoswwds_15_tfdisdsc_sel, lV72Configuracion_distritoswwds_16_tfpaidsc, AV73Configuracion_distritoswwds_17_tfpaidsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3W2 = false;
            A139PaiCod = P003W2_A139PaiCod[0];
            A142DisCod = P003W2_A142DisCod[0];
            A878DisSts = P003W2_A878DisSts[0];
            A1500PaiDsc = P003W2_A1500PaiDsc[0];
            A604DisDsc = P003W2_A604DisDsc[0];
            A140EstCod = P003W2_A140EstCod[0];
            A141ProvCod = P003W2_A141ProvCod[0];
            A1500PaiDsc = P003W2_A1500PaiDsc[0];
            AV36count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P003W2_A142DisCod[0], A142DisCod) == 0 ) )
            {
               BRK3W2 = false;
               A139PaiCod = P003W2_A139PaiCod[0];
               A140EstCod = P003W2_A140EstCod[0];
               A141ProvCod = P003W2_A141ProvCod[0];
               AV36count = (long)(AV36count+1);
               BRK3W2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A142DisCod)) )
            {
               AV28Option = A142DisCod;
               AV29Options.Add(AV28Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV36count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV29Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK3W2 )
            {
               BRK3W2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADDISDSCOPTIONS' Routine */
         returnInSub = false;
         AV18TFDisDsc = AV24SearchTxt;
         AV19TFDisDsc_Sel = "";
         AV57Configuracion_distritoswwds_1_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV59Configuracion_distritoswwds_3_disdsc1 = AV44DisDsc1;
         AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV61Configuracion_distritoswwds_5_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV63Configuracion_distritoswwds_7_disdsc2 = AV48DisDsc2;
         AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV65Configuracion_distritoswwds_9_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV67Configuracion_distritoswwds_11_disdsc3 = AV52DisDsc3;
         AV68Configuracion_distritoswwds_12_tfdiscod = AV14TFDisCod;
         AV69Configuracion_distritoswwds_13_tfdiscod_sel = AV15TFDisCod_Sel;
         AV70Configuracion_distritoswwds_14_tfdisdsc = AV18TFDisDsc;
         AV71Configuracion_distritoswwds_15_tfdisdsc_sel = AV19TFDisDsc_Sel;
         AV72Configuracion_distritoswwds_16_tfpaidsc = AV16TFPaiDsc;
         AV73Configuracion_distritoswwds_17_tfpaidsc_sel = AV17TFPaiDsc_Sel;
         AV74Configuracion_distritoswwds_18_tfdissts_sels = AV23TFDisSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A878DisSts ,
                                              AV74Configuracion_distritoswwds_18_tfdissts_sels ,
                                              AV57Configuracion_distritoswwds_1_dynamicfiltersselector1 ,
                                              AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 ,
                                              AV59Configuracion_distritoswwds_3_disdsc1 ,
                                              AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 ,
                                              AV61Configuracion_distritoswwds_5_dynamicfiltersselector2 ,
                                              AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 ,
                                              AV63Configuracion_distritoswwds_7_disdsc2 ,
                                              AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 ,
                                              AV65Configuracion_distritoswwds_9_dynamicfiltersselector3 ,
                                              AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 ,
                                              AV67Configuracion_distritoswwds_11_disdsc3 ,
                                              AV69Configuracion_distritoswwds_13_tfdiscod_sel ,
                                              AV68Configuracion_distritoswwds_12_tfdiscod ,
                                              AV71Configuracion_distritoswwds_15_tfdisdsc_sel ,
                                              AV70Configuracion_distritoswwds_14_tfdisdsc ,
                                              AV73Configuracion_distritoswwds_17_tfpaidsc_sel ,
                                              AV72Configuracion_distritoswwds_16_tfpaidsc ,
                                              AV74Configuracion_distritoswwds_18_tfdissts_sels.Count ,
                                              A604DisDsc ,
                                              A142DisCod ,
                                              A1500PaiDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV59Configuracion_distritoswwds_3_disdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_distritoswwds_3_disdsc1), 100, "%");
         lV59Configuracion_distritoswwds_3_disdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_distritoswwds_3_disdsc1), 100, "%");
         lV63Configuracion_distritoswwds_7_disdsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_distritoswwds_7_disdsc2), 100, "%");
         lV63Configuracion_distritoswwds_7_disdsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_distritoswwds_7_disdsc2), 100, "%");
         lV67Configuracion_distritoswwds_11_disdsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_distritoswwds_11_disdsc3), 100, "%");
         lV67Configuracion_distritoswwds_11_disdsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_distritoswwds_11_disdsc3), 100, "%");
         lV68Configuracion_distritoswwds_12_tfdiscod = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_distritoswwds_12_tfdiscod), 4, "%");
         lV70Configuracion_distritoswwds_14_tfdisdsc = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_distritoswwds_14_tfdisdsc), 100, "%");
         lV72Configuracion_distritoswwds_16_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_distritoswwds_16_tfpaidsc), 100, "%");
         /* Using cursor P003W3 */
         pr_default.execute(1, new Object[] {lV59Configuracion_distritoswwds_3_disdsc1, lV59Configuracion_distritoswwds_3_disdsc1, lV63Configuracion_distritoswwds_7_disdsc2, lV63Configuracion_distritoswwds_7_disdsc2, lV67Configuracion_distritoswwds_11_disdsc3, lV67Configuracion_distritoswwds_11_disdsc3, lV68Configuracion_distritoswwds_12_tfdiscod, AV69Configuracion_distritoswwds_13_tfdiscod_sel, lV70Configuracion_distritoswwds_14_tfdisdsc, AV71Configuracion_distritoswwds_15_tfdisdsc_sel, lV72Configuracion_distritoswwds_16_tfpaidsc, AV73Configuracion_distritoswwds_17_tfpaidsc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK3W4 = false;
            A139PaiCod = P003W3_A139PaiCod[0];
            A604DisDsc = P003W3_A604DisDsc[0];
            A878DisSts = P003W3_A878DisSts[0];
            A1500PaiDsc = P003W3_A1500PaiDsc[0];
            A142DisCod = P003W3_A142DisCod[0];
            A140EstCod = P003W3_A140EstCod[0];
            A141ProvCod = P003W3_A141ProvCod[0];
            A1500PaiDsc = P003W3_A1500PaiDsc[0];
            AV36count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P003W3_A604DisDsc[0], A604DisDsc) == 0 ) )
            {
               BRK3W4 = false;
               A139PaiCod = P003W3_A139PaiCod[0];
               A142DisCod = P003W3_A142DisCod[0];
               A140EstCod = P003W3_A140EstCod[0];
               A141ProvCod = P003W3_A141ProvCod[0];
               AV36count = (long)(AV36count+1);
               BRK3W4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A604DisDsc)) )
            {
               AV28Option = A604DisDsc;
               AV29Options.Add(AV28Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV36count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV29Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK3W4 )
            {
               BRK3W4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPAIDSCOPTIONS' Routine */
         returnInSub = false;
         AV16TFPaiDsc = AV24SearchTxt;
         AV17TFPaiDsc_Sel = "";
         AV57Configuracion_distritoswwds_1_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV59Configuracion_distritoswwds_3_disdsc1 = AV44DisDsc1;
         AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV61Configuracion_distritoswwds_5_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV63Configuracion_distritoswwds_7_disdsc2 = AV48DisDsc2;
         AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV65Configuracion_distritoswwds_9_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV67Configuracion_distritoswwds_11_disdsc3 = AV52DisDsc3;
         AV68Configuracion_distritoswwds_12_tfdiscod = AV14TFDisCod;
         AV69Configuracion_distritoswwds_13_tfdiscod_sel = AV15TFDisCod_Sel;
         AV70Configuracion_distritoswwds_14_tfdisdsc = AV18TFDisDsc;
         AV71Configuracion_distritoswwds_15_tfdisdsc_sel = AV19TFDisDsc_Sel;
         AV72Configuracion_distritoswwds_16_tfpaidsc = AV16TFPaiDsc;
         AV73Configuracion_distritoswwds_17_tfpaidsc_sel = AV17TFPaiDsc_Sel;
         AV74Configuracion_distritoswwds_18_tfdissts_sels = AV23TFDisSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A878DisSts ,
                                              AV74Configuracion_distritoswwds_18_tfdissts_sels ,
                                              AV57Configuracion_distritoswwds_1_dynamicfiltersselector1 ,
                                              AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 ,
                                              AV59Configuracion_distritoswwds_3_disdsc1 ,
                                              AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 ,
                                              AV61Configuracion_distritoswwds_5_dynamicfiltersselector2 ,
                                              AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 ,
                                              AV63Configuracion_distritoswwds_7_disdsc2 ,
                                              AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 ,
                                              AV65Configuracion_distritoswwds_9_dynamicfiltersselector3 ,
                                              AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 ,
                                              AV67Configuracion_distritoswwds_11_disdsc3 ,
                                              AV69Configuracion_distritoswwds_13_tfdiscod_sel ,
                                              AV68Configuracion_distritoswwds_12_tfdiscod ,
                                              AV71Configuracion_distritoswwds_15_tfdisdsc_sel ,
                                              AV70Configuracion_distritoswwds_14_tfdisdsc ,
                                              AV73Configuracion_distritoswwds_17_tfpaidsc_sel ,
                                              AV72Configuracion_distritoswwds_16_tfpaidsc ,
                                              AV74Configuracion_distritoswwds_18_tfdissts_sels.Count ,
                                              A604DisDsc ,
                                              A142DisCod ,
                                              A1500PaiDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV59Configuracion_distritoswwds_3_disdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_distritoswwds_3_disdsc1), 100, "%");
         lV59Configuracion_distritoswwds_3_disdsc1 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_distritoswwds_3_disdsc1), 100, "%");
         lV63Configuracion_distritoswwds_7_disdsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_distritoswwds_7_disdsc2), 100, "%");
         lV63Configuracion_distritoswwds_7_disdsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_distritoswwds_7_disdsc2), 100, "%");
         lV67Configuracion_distritoswwds_11_disdsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_distritoswwds_11_disdsc3), 100, "%");
         lV67Configuracion_distritoswwds_11_disdsc3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_distritoswwds_11_disdsc3), 100, "%");
         lV68Configuracion_distritoswwds_12_tfdiscod = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_distritoswwds_12_tfdiscod), 4, "%");
         lV70Configuracion_distritoswwds_14_tfdisdsc = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_distritoswwds_14_tfdisdsc), 100, "%");
         lV72Configuracion_distritoswwds_16_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_distritoswwds_16_tfpaidsc), 100, "%");
         /* Using cursor P003W4 */
         pr_default.execute(2, new Object[] {lV59Configuracion_distritoswwds_3_disdsc1, lV59Configuracion_distritoswwds_3_disdsc1, lV63Configuracion_distritoswwds_7_disdsc2, lV63Configuracion_distritoswwds_7_disdsc2, lV67Configuracion_distritoswwds_11_disdsc3, lV67Configuracion_distritoswwds_11_disdsc3, lV68Configuracion_distritoswwds_12_tfdiscod, AV69Configuracion_distritoswwds_13_tfdiscod_sel, lV70Configuracion_distritoswwds_14_tfdisdsc, AV71Configuracion_distritoswwds_15_tfdisdsc_sel, lV72Configuracion_distritoswwds_16_tfpaidsc, AV73Configuracion_distritoswwds_17_tfpaidsc_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK3W6 = false;
            A139PaiCod = P003W4_A139PaiCod[0];
            A1500PaiDsc = P003W4_A1500PaiDsc[0];
            A878DisSts = P003W4_A878DisSts[0];
            A142DisCod = P003W4_A142DisCod[0];
            A604DisDsc = P003W4_A604DisDsc[0];
            A140EstCod = P003W4_A140EstCod[0];
            A141ProvCod = P003W4_A141ProvCod[0];
            A1500PaiDsc = P003W4_A1500PaiDsc[0];
            AV36count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P003W4_A1500PaiDsc[0], A1500PaiDsc) == 0 ) )
            {
               BRK3W6 = false;
               A139PaiCod = P003W4_A139PaiCod[0];
               A142DisCod = P003W4_A142DisCod[0];
               A140EstCod = P003W4_A140EstCod[0];
               A141ProvCod = P003W4_A141ProvCod[0];
               AV36count = (long)(AV36count+1);
               BRK3W6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1500PaiDsc)) )
            {
               AV28Option = A1500PaiDsc;
               AV29Options.Add(AV28Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV36count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV29Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK3W6 )
            {
               BRK3W6 = true;
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
         AV30OptionsJson = "";
         AV33OptionsDescJson = "";
         AV35OptionIndexesJson = "";
         AV29Options = new GxSimpleCollection<string>();
         AV32OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV37Session = context.GetSession();
         AV39GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV40GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV14TFDisCod = "";
         AV15TFDisCod_Sel = "";
         AV18TFDisDsc = "";
         AV19TFDisDsc_Sel = "";
         AV16TFPaiDsc = "";
         AV17TFPaiDsc_Sel = "";
         AV22TFDisSts_SelsJson = "";
         AV23TFDisSts_Sels = new GxSimpleCollection<short>();
         AV41GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV42DynamicFiltersSelector1 = "";
         AV44DisDsc1 = "";
         AV46DynamicFiltersSelector2 = "";
         AV48DisDsc2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV52DisDsc3 = "";
         AV57Configuracion_distritoswwds_1_dynamicfiltersselector1 = "";
         AV59Configuracion_distritoswwds_3_disdsc1 = "";
         AV61Configuracion_distritoswwds_5_dynamicfiltersselector2 = "";
         AV63Configuracion_distritoswwds_7_disdsc2 = "";
         AV65Configuracion_distritoswwds_9_dynamicfiltersselector3 = "";
         AV67Configuracion_distritoswwds_11_disdsc3 = "";
         AV68Configuracion_distritoswwds_12_tfdiscod = "";
         AV69Configuracion_distritoswwds_13_tfdiscod_sel = "";
         AV70Configuracion_distritoswwds_14_tfdisdsc = "";
         AV71Configuracion_distritoswwds_15_tfdisdsc_sel = "";
         AV72Configuracion_distritoswwds_16_tfpaidsc = "";
         AV73Configuracion_distritoswwds_17_tfpaidsc_sel = "";
         AV74Configuracion_distritoswwds_18_tfdissts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV59Configuracion_distritoswwds_3_disdsc1 = "";
         lV63Configuracion_distritoswwds_7_disdsc2 = "";
         lV67Configuracion_distritoswwds_11_disdsc3 = "";
         lV68Configuracion_distritoswwds_12_tfdiscod = "";
         lV70Configuracion_distritoswwds_14_tfdisdsc = "";
         lV72Configuracion_distritoswwds_16_tfpaidsc = "";
         A604DisDsc = "";
         A142DisCod = "";
         A1500PaiDsc = "";
         P003W2_A139PaiCod = new string[] {""} ;
         P003W2_A142DisCod = new string[] {""} ;
         P003W2_A878DisSts = new short[1] ;
         P003W2_A1500PaiDsc = new string[] {""} ;
         P003W2_A604DisDsc = new string[] {""} ;
         P003W2_A140EstCod = new string[] {""} ;
         P003W2_A141ProvCod = new string[] {""} ;
         A139PaiCod = "";
         A140EstCod = "";
         A141ProvCod = "";
         AV28Option = "";
         P003W3_A139PaiCod = new string[] {""} ;
         P003W3_A604DisDsc = new string[] {""} ;
         P003W3_A878DisSts = new short[1] ;
         P003W3_A1500PaiDsc = new string[] {""} ;
         P003W3_A142DisCod = new string[] {""} ;
         P003W3_A140EstCod = new string[] {""} ;
         P003W3_A141ProvCod = new string[] {""} ;
         P003W4_A139PaiCod = new string[] {""} ;
         P003W4_A1500PaiDsc = new string[] {""} ;
         P003W4_A878DisSts = new short[1] ;
         P003W4_A142DisCod = new string[] {""} ;
         P003W4_A604DisDsc = new string[] {""} ;
         P003W4_A140EstCod = new string[] {""} ;
         P003W4_A141ProvCod = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.distritoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003W2_A139PaiCod, P003W2_A142DisCod, P003W2_A878DisSts, P003W2_A1500PaiDsc, P003W2_A604DisDsc, P003W2_A140EstCod, P003W2_A141ProvCod
               }
               , new Object[] {
               P003W3_A139PaiCod, P003W3_A604DisDsc, P003W3_A878DisSts, P003W3_A1500PaiDsc, P003W3_A142DisCod, P003W3_A140EstCod, P003W3_A141ProvCod
               }
               , new Object[] {
               P003W4_A139PaiCod, P003W4_A1500PaiDsc, P003W4_A878DisSts, P003W4_A142DisCod, P003W4_A604DisDsc, P003W4_A140EstCod, P003W4_A141ProvCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV43DynamicFiltersOperator1 ;
      private short AV47DynamicFiltersOperator2 ;
      private short AV51DynamicFiltersOperator3 ;
      private short AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 ;
      private short AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 ;
      private short AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 ;
      private short A878DisSts ;
      private int AV55GXV1 ;
      private int AV74Configuracion_distritoswwds_18_tfdissts_sels_Count ;
      private long AV36count ;
      private string AV14TFDisCod ;
      private string AV15TFDisCod_Sel ;
      private string AV18TFDisDsc ;
      private string AV19TFDisDsc_Sel ;
      private string AV16TFPaiDsc ;
      private string AV17TFPaiDsc_Sel ;
      private string AV44DisDsc1 ;
      private string AV48DisDsc2 ;
      private string AV52DisDsc3 ;
      private string AV59Configuracion_distritoswwds_3_disdsc1 ;
      private string AV63Configuracion_distritoswwds_7_disdsc2 ;
      private string AV67Configuracion_distritoswwds_11_disdsc3 ;
      private string AV68Configuracion_distritoswwds_12_tfdiscod ;
      private string AV69Configuracion_distritoswwds_13_tfdiscod_sel ;
      private string AV70Configuracion_distritoswwds_14_tfdisdsc ;
      private string AV71Configuracion_distritoswwds_15_tfdisdsc_sel ;
      private string AV72Configuracion_distritoswwds_16_tfpaidsc ;
      private string AV73Configuracion_distritoswwds_17_tfpaidsc_sel ;
      private string scmdbuf ;
      private string lV59Configuracion_distritoswwds_3_disdsc1 ;
      private string lV63Configuracion_distritoswwds_7_disdsc2 ;
      private string lV67Configuracion_distritoswwds_11_disdsc3 ;
      private string lV68Configuracion_distritoswwds_12_tfdiscod ;
      private string lV70Configuracion_distritoswwds_14_tfdisdsc ;
      private string lV72Configuracion_distritoswwds_16_tfpaidsc ;
      private string A604DisDsc ;
      private string A142DisCod ;
      private string A1500PaiDsc ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A141ProvCod ;
      private bool returnInSub ;
      private bool AV45DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 ;
      private bool AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 ;
      private bool BRK3W2 ;
      private bool BRK3W4 ;
      private bool BRK3W6 ;
      private string AV30OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV35OptionIndexesJson ;
      private string AV22TFDisSts_SelsJson ;
      private string AV26DDOName ;
      private string AV24SearchTxt ;
      private string AV25SearchTxtTo ;
      private string AV42DynamicFiltersSelector1 ;
      private string AV46DynamicFiltersSelector2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV57Configuracion_distritoswwds_1_dynamicfiltersselector1 ;
      private string AV61Configuracion_distritoswwds_5_dynamicfiltersselector2 ;
      private string AV65Configuracion_distritoswwds_9_dynamicfiltersselector3 ;
      private string AV28Option ;
      private GxSimpleCollection<short> AV23TFDisSts_Sels ;
      private GxSimpleCollection<short> AV74Configuracion_distritoswwds_18_tfdissts_sels ;
      private IGxSession AV37Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003W2_A139PaiCod ;
      private string[] P003W2_A142DisCod ;
      private short[] P003W2_A878DisSts ;
      private string[] P003W2_A1500PaiDsc ;
      private string[] P003W2_A604DisDsc ;
      private string[] P003W2_A140EstCod ;
      private string[] P003W2_A141ProvCod ;
      private string[] P003W3_A139PaiCod ;
      private string[] P003W3_A604DisDsc ;
      private short[] P003W3_A878DisSts ;
      private string[] P003W3_A1500PaiDsc ;
      private string[] P003W3_A142DisCod ;
      private string[] P003W3_A140EstCod ;
      private string[] P003W3_A141ProvCod ;
      private string[] P003W4_A139PaiCod ;
      private string[] P003W4_A1500PaiDsc ;
      private short[] P003W4_A878DisSts ;
      private string[] P003W4_A142DisCod ;
      private string[] P003W4_A604DisDsc ;
      private string[] P003W4_A140EstCod ;
      private string[] P003W4_A141ProvCod ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV29Options ;
      private GxSimpleCollection<string> AV32OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV39GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV40GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV41GridStateDynamicFilter ;
   }

   public class distritoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003W2( IGxContext context ,
                                             short A878DisSts ,
                                             GxSimpleCollection<short> AV74Configuracion_distritoswwds_18_tfdissts_sels ,
                                             string AV57Configuracion_distritoswwds_1_dynamicfiltersselector1 ,
                                             short AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 ,
                                             string AV59Configuracion_distritoswwds_3_disdsc1 ,
                                             bool AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 ,
                                             string AV61Configuracion_distritoswwds_5_dynamicfiltersselector2 ,
                                             short AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 ,
                                             string AV63Configuracion_distritoswwds_7_disdsc2 ,
                                             bool AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 ,
                                             string AV65Configuracion_distritoswwds_9_dynamicfiltersselector3 ,
                                             short AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 ,
                                             string AV67Configuracion_distritoswwds_11_disdsc3 ,
                                             string AV69Configuracion_distritoswwds_13_tfdiscod_sel ,
                                             string AV68Configuracion_distritoswwds_12_tfdiscod ,
                                             string AV71Configuracion_distritoswwds_15_tfdisdsc_sel ,
                                             string AV70Configuracion_distritoswwds_14_tfdisdsc ,
                                             string AV73Configuracion_distritoswwds_17_tfpaidsc_sel ,
                                             string AV72Configuracion_distritoswwds_16_tfpaidsc ,
                                             int AV74Configuracion_distritoswwds_18_tfdissts_sels_Count ,
                                             string A604DisDsc ,
                                             string A142DisCod ,
                                             string A1500PaiDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[PaiCod], T1.[DisCod], T1.[DisSts], T2.[PaiDsc], T1.[DisDsc], T1.[EstCod], T1.[ProvCod] FROM ([CDISTRITOS] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod])";
         if ( ( StringUtil.StrCmp(AV57Configuracion_distritoswwds_1_dynamicfiltersselector1, "DISDSC") == 0 ) && ( AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_distritoswwds_3_disdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV59Configuracion_distritoswwds_3_disdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Configuracion_distritoswwds_1_dynamicfiltersselector1, "DISDSC") == 0 ) && ( AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_distritoswwds_3_disdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like '%' + @lV59Configuracion_distritoswwds_3_disdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_distritoswwds_5_dynamicfiltersselector2, "DISDSC") == 0 ) && ( AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_distritoswwds_7_disdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV63Configuracion_distritoswwds_7_disdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_distritoswwds_5_dynamicfiltersselector2, "DISDSC") == 0 ) && ( AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_distritoswwds_7_disdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like '%' + @lV63Configuracion_distritoswwds_7_disdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Configuracion_distritoswwds_9_dynamicfiltersselector3, "DISDSC") == 0 ) && ( AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_distritoswwds_11_disdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV67Configuracion_distritoswwds_11_disdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Configuracion_distritoswwds_9_dynamicfiltersselector3, "DISDSC") == 0 ) && ( AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_distritoswwds_11_disdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like '%' + @lV67Configuracion_distritoswwds_11_disdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_distritoswwds_13_tfdiscod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_distritoswwds_12_tfdiscod)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisCod] like @lV68Configuracion_distritoswwds_12_tfdiscod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_distritoswwds_13_tfdiscod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[DisCod] = @AV69Configuracion_distritoswwds_13_tfdiscod_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_distritoswwds_15_tfdisdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_distritoswwds_14_tfdisdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV70Configuracion_distritoswwds_14_tfdisdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_distritoswwds_15_tfdisdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] = @AV71Configuracion_distritoswwds_15_tfdisdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_distritoswwds_17_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_distritoswwds_16_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] like @lV72Configuracion_distritoswwds_16_tfpaidsc)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_distritoswwds_17_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] = @AV73Configuracion_distritoswwds_17_tfpaidsc_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV74Configuracion_distritoswwds_18_tfdissts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Configuracion_distritoswwds_18_tfdissts_sels, "T1.[DisSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DisCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P003W3( IGxContext context ,
                                             short A878DisSts ,
                                             GxSimpleCollection<short> AV74Configuracion_distritoswwds_18_tfdissts_sels ,
                                             string AV57Configuracion_distritoswwds_1_dynamicfiltersselector1 ,
                                             short AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 ,
                                             string AV59Configuracion_distritoswwds_3_disdsc1 ,
                                             bool AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 ,
                                             string AV61Configuracion_distritoswwds_5_dynamicfiltersselector2 ,
                                             short AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 ,
                                             string AV63Configuracion_distritoswwds_7_disdsc2 ,
                                             bool AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 ,
                                             string AV65Configuracion_distritoswwds_9_dynamicfiltersselector3 ,
                                             short AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 ,
                                             string AV67Configuracion_distritoswwds_11_disdsc3 ,
                                             string AV69Configuracion_distritoswwds_13_tfdiscod_sel ,
                                             string AV68Configuracion_distritoswwds_12_tfdiscod ,
                                             string AV71Configuracion_distritoswwds_15_tfdisdsc_sel ,
                                             string AV70Configuracion_distritoswwds_14_tfdisdsc ,
                                             string AV73Configuracion_distritoswwds_17_tfpaidsc_sel ,
                                             string AV72Configuracion_distritoswwds_16_tfpaidsc ,
                                             int AV74Configuracion_distritoswwds_18_tfdissts_sels_Count ,
                                             string A604DisDsc ,
                                             string A142DisCod ,
                                             string A1500PaiDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[PaiCod], T1.[DisDsc], T1.[DisSts], T2.[PaiDsc], T1.[DisCod], T1.[EstCod], T1.[ProvCod] FROM ([CDISTRITOS] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod])";
         if ( ( StringUtil.StrCmp(AV57Configuracion_distritoswwds_1_dynamicfiltersselector1, "DISDSC") == 0 ) && ( AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_distritoswwds_3_disdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV59Configuracion_distritoswwds_3_disdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Configuracion_distritoswwds_1_dynamicfiltersselector1, "DISDSC") == 0 ) && ( AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_distritoswwds_3_disdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like '%' + @lV59Configuracion_distritoswwds_3_disdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_distritoswwds_5_dynamicfiltersselector2, "DISDSC") == 0 ) && ( AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_distritoswwds_7_disdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV63Configuracion_distritoswwds_7_disdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_distritoswwds_5_dynamicfiltersselector2, "DISDSC") == 0 ) && ( AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_distritoswwds_7_disdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like '%' + @lV63Configuracion_distritoswwds_7_disdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Configuracion_distritoswwds_9_dynamicfiltersselector3, "DISDSC") == 0 ) && ( AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_distritoswwds_11_disdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV67Configuracion_distritoswwds_11_disdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Configuracion_distritoswwds_9_dynamicfiltersselector3, "DISDSC") == 0 ) && ( AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_distritoswwds_11_disdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like '%' + @lV67Configuracion_distritoswwds_11_disdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_distritoswwds_13_tfdiscod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_distritoswwds_12_tfdiscod)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisCod] like @lV68Configuracion_distritoswwds_12_tfdiscod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_distritoswwds_13_tfdiscod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[DisCod] = @AV69Configuracion_distritoswwds_13_tfdiscod_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_distritoswwds_15_tfdisdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_distritoswwds_14_tfdisdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV70Configuracion_distritoswwds_14_tfdisdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_distritoswwds_15_tfdisdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] = @AV71Configuracion_distritoswwds_15_tfdisdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_distritoswwds_17_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_distritoswwds_16_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] like @lV72Configuracion_distritoswwds_16_tfpaidsc)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_distritoswwds_17_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] = @AV73Configuracion_distritoswwds_17_tfpaidsc_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV74Configuracion_distritoswwds_18_tfdissts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Configuracion_distritoswwds_18_tfdissts_sels, "T1.[DisSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[DisDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P003W4( IGxContext context ,
                                             short A878DisSts ,
                                             GxSimpleCollection<short> AV74Configuracion_distritoswwds_18_tfdissts_sels ,
                                             string AV57Configuracion_distritoswwds_1_dynamicfiltersselector1 ,
                                             short AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 ,
                                             string AV59Configuracion_distritoswwds_3_disdsc1 ,
                                             bool AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 ,
                                             string AV61Configuracion_distritoswwds_5_dynamicfiltersselector2 ,
                                             short AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 ,
                                             string AV63Configuracion_distritoswwds_7_disdsc2 ,
                                             bool AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 ,
                                             string AV65Configuracion_distritoswwds_9_dynamicfiltersselector3 ,
                                             short AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 ,
                                             string AV67Configuracion_distritoswwds_11_disdsc3 ,
                                             string AV69Configuracion_distritoswwds_13_tfdiscod_sel ,
                                             string AV68Configuracion_distritoswwds_12_tfdiscod ,
                                             string AV71Configuracion_distritoswwds_15_tfdisdsc_sel ,
                                             string AV70Configuracion_distritoswwds_14_tfdisdsc ,
                                             string AV73Configuracion_distritoswwds_17_tfpaidsc_sel ,
                                             string AV72Configuracion_distritoswwds_16_tfpaidsc ,
                                             int AV74Configuracion_distritoswwds_18_tfdissts_sels_Count ,
                                             string A604DisDsc ,
                                             string A142DisCod ,
                                             string A1500PaiDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[PaiCod], T2.[PaiDsc], T1.[DisSts], T1.[DisCod], T1.[DisDsc], T1.[EstCod], T1.[ProvCod] FROM ([CDISTRITOS] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod])";
         if ( ( StringUtil.StrCmp(AV57Configuracion_distritoswwds_1_dynamicfiltersselector1, "DISDSC") == 0 ) && ( AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_distritoswwds_3_disdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV59Configuracion_distritoswwds_3_disdsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Configuracion_distritoswwds_1_dynamicfiltersselector1, "DISDSC") == 0 ) && ( AV58Configuracion_distritoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_distritoswwds_3_disdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like '%' + @lV59Configuracion_distritoswwds_3_disdsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_distritoswwds_5_dynamicfiltersselector2, "DISDSC") == 0 ) && ( AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_distritoswwds_7_disdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV63Configuracion_distritoswwds_7_disdsc2)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV60Configuracion_distritoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_distritoswwds_5_dynamicfiltersselector2, "DISDSC") == 0 ) && ( AV62Configuracion_distritoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_distritoswwds_7_disdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like '%' + @lV63Configuracion_distritoswwds_7_disdsc2)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Configuracion_distritoswwds_9_dynamicfiltersselector3, "DISDSC") == 0 ) && ( AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_distritoswwds_11_disdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV67Configuracion_distritoswwds_11_disdsc3)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV64Configuracion_distritoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Configuracion_distritoswwds_9_dynamicfiltersselector3, "DISDSC") == 0 ) && ( AV66Configuracion_distritoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_distritoswwds_11_disdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like '%' + @lV67Configuracion_distritoswwds_11_disdsc3)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_distritoswwds_13_tfdiscod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_distritoswwds_12_tfdiscod)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisCod] like @lV68Configuracion_distritoswwds_12_tfdiscod)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_distritoswwds_13_tfdiscod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[DisCod] = @AV69Configuracion_distritoswwds_13_tfdiscod_sel)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_distritoswwds_15_tfdisdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_distritoswwds_14_tfdisdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] like @lV70Configuracion_distritoswwds_14_tfdisdsc)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_distritoswwds_15_tfdisdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[DisDsc] = @AV71Configuracion_distritoswwds_15_tfdisdsc_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_distritoswwds_17_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_distritoswwds_16_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] like @lV72Configuracion_distritoswwds_16_tfpaidsc)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_distritoswwds_17_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] = @AV73Configuracion_distritoswwds_17_tfpaidsc_sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV74Configuracion_distritoswwds_18_tfdissts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Configuracion_distritoswwds_18_tfdissts_sels, "T1.[DisSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[PaiDsc]";
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
                     return conditional_P003W2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] );
               case 1 :
                     return conditional_P003W3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] );
               case 2 :
                     return conditional_P003W4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP003W2;
          prmP003W2 = new Object[] {
          new ParDef("@lV59Configuracion_distritoswwds_3_disdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_distritoswwds_3_disdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_distritoswwds_7_disdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_distritoswwds_7_disdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_distritoswwds_11_disdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_distritoswwds_11_disdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_distritoswwds_12_tfdiscod",GXType.NChar,4,0) ,
          new ParDef("@AV69Configuracion_distritoswwds_13_tfdiscod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV70Configuracion_distritoswwds_14_tfdisdsc",GXType.NChar,100,0) ,
          new ParDef("@AV71Configuracion_distritoswwds_15_tfdisdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_distritoswwds_16_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Configuracion_distritoswwds_17_tfpaidsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP003W3;
          prmP003W3 = new Object[] {
          new ParDef("@lV59Configuracion_distritoswwds_3_disdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_distritoswwds_3_disdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_distritoswwds_7_disdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_distritoswwds_7_disdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_distritoswwds_11_disdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_distritoswwds_11_disdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_distritoswwds_12_tfdiscod",GXType.NChar,4,0) ,
          new ParDef("@AV69Configuracion_distritoswwds_13_tfdiscod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV70Configuracion_distritoswwds_14_tfdisdsc",GXType.NChar,100,0) ,
          new ParDef("@AV71Configuracion_distritoswwds_15_tfdisdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_distritoswwds_16_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Configuracion_distritoswwds_17_tfpaidsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP003W4;
          prmP003W4 = new Object[] {
          new ParDef("@lV59Configuracion_distritoswwds_3_disdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_distritoswwds_3_disdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_distritoswwds_7_disdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_distritoswwds_7_disdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_distritoswwds_11_disdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_distritoswwds_11_disdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_distritoswwds_12_tfdiscod",GXType.NChar,4,0) ,
          new ParDef("@AV69Configuracion_distritoswwds_13_tfdiscod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV70Configuracion_distritoswwds_14_tfdisdsc",GXType.NChar,100,0) ,
          new ParDef("@AV71Configuracion_distritoswwds_15_tfdisdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_distritoswwds_16_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Configuracion_distritoswwds_17_tfpaidsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003W2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003W3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003W4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003W4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getString(6, 4);
                ((string[]) buf[6])[0] = rslt.getString(7, 4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 4);
                ((string[]) buf[5])[0] = rslt.getString(6, 4);
                ((string[]) buf[6])[0] = rslt.getString(7, 4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getString(6, 4);
                ((string[]) buf[6])[0] = rslt.getString(7, 4);
                return;
       }
    }

 }

}
