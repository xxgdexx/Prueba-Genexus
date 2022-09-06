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
   public class bancoswwgetfilterdata : GXProcedure
   {
      public bancoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public bancoswwgetfilterdata( IGxContext context )
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
         bancoswwgetfilterdata objbancoswwgetfilterdata;
         objbancoswwgetfilterdata = new bancoswwgetfilterdata();
         objbancoswwgetfilterdata.AV22DDOName = aP0_DDOName;
         objbancoswwgetfilterdata.AV20SearchTxt = aP1_SearchTxt;
         objbancoswwgetfilterdata.AV21SearchTxtTo = aP2_SearchTxtTo;
         objbancoswwgetfilterdata.AV26OptionsJson = "" ;
         objbancoswwgetfilterdata.AV29OptionsDescJson = "" ;
         objbancoswwgetfilterdata.AV31OptionIndexesJson = "" ;
         objbancoswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objbancoswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objbancoswwgetfilterdata);
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((bancoswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_BANDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADBANDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_BANABR") == 0 )
         {
            /* Execute user subroutine: 'LOADBANABROPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_BANSUNAT") == 0 )
         {
            /* Execute user subroutine: 'LOADBANSUNATOPTIONS' */
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
         if ( StringUtil.StrCmp(AV33Session.Get("Bancos.BancosWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.BancosWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Bancos.BancosWWGridState"), null, "", "");
         }
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFBANCOD") == 0 )
            {
               AV10TFBanCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV11TFBanCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFBANDSC") == 0 )
            {
               AV12TFBanDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFBANDSC_SEL") == 0 )
            {
               AV13TFBanDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFBANABR") == 0 )
            {
               AV14TFBanAbr = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFBANABR_SEL") == 0 )
            {
               AV15TFBanAbr_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFBANSUNAT") == 0 )
            {
               AV18TFBanSunat = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFBANSUNAT_SEL") == 0 )
            {
               AV19TFBanSunat_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFBANSTS") == 0 )
            {
               AV16TFBanSts = (short)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV17TFBanSts_To = (short)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "BANDSC") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV40BanDsc1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "BANDSC") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV44BanDsc2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "BANDSC") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV48BanDsc3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADBANDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFBanDsc = AV20SearchTxt;
         AV13TFBanDsc_Sel = "";
         AV55Bancos_bancoswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV57Bancos_bancoswwds_3_bandsc1 = AV40BanDsc1;
         AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV59Bancos_bancoswwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV61Bancos_bancoswwds_7_bandsc2 = AV44BanDsc2;
         AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV63Bancos_bancoswwds_9_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV65Bancos_bancoswwds_11_bandsc3 = AV48BanDsc3;
         AV66Bancos_bancoswwds_12_tfbancod = AV10TFBanCod;
         AV67Bancos_bancoswwds_13_tfbancod_to = AV11TFBanCod_To;
         AV68Bancos_bancoswwds_14_tfbandsc = AV12TFBanDsc;
         AV69Bancos_bancoswwds_15_tfbandsc_sel = AV13TFBanDsc_Sel;
         AV70Bancos_bancoswwds_16_tfbanabr = AV14TFBanAbr;
         AV71Bancos_bancoswwds_17_tfbanabr_sel = AV15TFBanAbr_Sel;
         AV72Bancos_bancoswwds_18_tfbansunat = AV18TFBanSunat;
         AV73Bancos_bancoswwds_19_tfbansunat_sel = AV19TFBanSunat_Sel;
         AV74Bancos_bancoswwds_20_tfbansts = AV16TFBanSts;
         AV75Bancos_bancoswwds_21_tfbansts_to = AV17TFBanSts_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV55Bancos_bancoswwds_1_dynamicfiltersselector1 ,
                                              AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 ,
                                              AV57Bancos_bancoswwds_3_bandsc1 ,
                                              AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 ,
                                              AV59Bancos_bancoswwds_5_dynamicfiltersselector2 ,
                                              AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 ,
                                              AV61Bancos_bancoswwds_7_bandsc2 ,
                                              AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 ,
                                              AV63Bancos_bancoswwds_9_dynamicfiltersselector3 ,
                                              AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 ,
                                              AV65Bancos_bancoswwds_11_bandsc3 ,
                                              AV66Bancos_bancoswwds_12_tfbancod ,
                                              AV67Bancos_bancoswwds_13_tfbancod_to ,
                                              AV69Bancos_bancoswwds_15_tfbandsc_sel ,
                                              AV68Bancos_bancoswwds_14_tfbandsc ,
                                              AV71Bancos_bancoswwds_17_tfbanabr_sel ,
                                              AV70Bancos_bancoswwds_16_tfbanabr ,
                                              AV73Bancos_bancoswwds_19_tfbansunat_sel ,
                                              AV72Bancos_bancoswwds_18_tfbansunat ,
                                              AV74Bancos_bancoswwds_20_tfbansts ,
                                              AV75Bancos_bancoswwds_21_tfbansts_to ,
                                              A482BanDsc ,
                                              A372BanCod ,
                                              A481BanAbr ,
                                              A484BanSunat ,
                                              A483BanSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.SHORT
                                              }
         });
         lV57Bancos_bancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Bancos_bancoswwds_3_bandsc1), 100, "%");
         lV57Bancos_bancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Bancos_bancoswwds_3_bandsc1), 100, "%");
         lV61Bancos_bancoswwds_7_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_bancoswwds_7_bandsc2), 100, "%");
         lV61Bancos_bancoswwds_7_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_bancoswwds_7_bandsc2), 100, "%");
         lV65Bancos_bancoswwds_11_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_bancoswwds_11_bandsc3), 100, "%");
         lV65Bancos_bancoswwds_11_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_bancoswwds_11_bandsc3), 100, "%");
         lV68Bancos_bancoswwds_14_tfbandsc = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_bancoswwds_14_tfbandsc), 100, "%");
         lV70Bancos_bancoswwds_16_tfbanabr = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_bancoswwds_16_tfbanabr), 5, "%");
         lV72Bancos_bancoswwds_18_tfbansunat = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_bancoswwds_18_tfbansunat), 5, "%");
         /* Using cursor P00592 */
         pr_default.execute(0, new Object[] {lV57Bancos_bancoswwds_3_bandsc1, lV57Bancos_bancoswwds_3_bandsc1, lV61Bancos_bancoswwds_7_bandsc2, lV61Bancos_bancoswwds_7_bandsc2, lV65Bancos_bancoswwds_11_bandsc3, lV65Bancos_bancoswwds_11_bandsc3, AV66Bancos_bancoswwds_12_tfbancod, AV67Bancos_bancoswwds_13_tfbancod_to, lV68Bancos_bancoswwds_14_tfbandsc, AV69Bancos_bancoswwds_15_tfbandsc_sel, lV70Bancos_bancoswwds_16_tfbanabr, AV71Bancos_bancoswwds_17_tfbanabr_sel, lV72Bancos_bancoswwds_18_tfbansunat, AV73Bancos_bancoswwds_19_tfbansunat_sel, AV74Bancos_bancoswwds_20_tfbansts, AV75Bancos_bancoswwds_21_tfbansts_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK592 = false;
            A482BanDsc = P00592_A482BanDsc[0];
            A483BanSts = P00592_A483BanSts[0];
            A484BanSunat = P00592_A484BanSunat[0];
            A481BanAbr = P00592_A481BanAbr[0];
            A372BanCod = P00592_A372BanCod[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00592_A482BanDsc[0], A482BanDsc) == 0 ) )
            {
               BRK592 = false;
               A372BanCod = P00592_A372BanCod[0];
               AV32count = (long)(AV32count+1);
               BRK592 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A482BanDsc)) )
            {
               AV24Option = A482BanDsc;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK592 )
            {
               BRK592 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADBANABROPTIONS' Routine */
         returnInSub = false;
         AV14TFBanAbr = AV20SearchTxt;
         AV15TFBanAbr_Sel = "";
         AV55Bancos_bancoswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV57Bancos_bancoswwds_3_bandsc1 = AV40BanDsc1;
         AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV59Bancos_bancoswwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV61Bancos_bancoswwds_7_bandsc2 = AV44BanDsc2;
         AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV63Bancos_bancoswwds_9_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV65Bancos_bancoswwds_11_bandsc3 = AV48BanDsc3;
         AV66Bancos_bancoswwds_12_tfbancod = AV10TFBanCod;
         AV67Bancos_bancoswwds_13_tfbancod_to = AV11TFBanCod_To;
         AV68Bancos_bancoswwds_14_tfbandsc = AV12TFBanDsc;
         AV69Bancos_bancoswwds_15_tfbandsc_sel = AV13TFBanDsc_Sel;
         AV70Bancos_bancoswwds_16_tfbanabr = AV14TFBanAbr;
         AV71Bancos_bancoswwds_17_tfbanabr_sel = AV15TFBanAbr_Sel;
         AV72Bancos_bancoswwds_18_tfbansunat = AV18TFBanSunat;
         AV73Bancos_bancoswwds_19_tfbansunat_sel = AV19TFBanSunat_Sel;
         AV74Bancos_bancoswwds_20_tfbansts = AV16TFBanSts;
         AV75Bancos_bancoswwds_21_tfbansts_to = AV17TFBanSts_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV55Bancos_bancoswwds_1_dynamicfiltersselector1 ,
                                              AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 ,
                                              AV57Bancos_bancoswwds_3_bandsc1 ,
                                              AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 ,
                                              AV59Bancos_bancoswwds_5_dynamicfiltersselector2 ,
                                              AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 ,
                                              AV61Bancos_bancoswwds_7_bandsc2 ,
                                              AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 ,
                                              AV63Bancos_bancoswwds_9_dynamicfiltersselector3 ,
                                              AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 ,
                                              AV65Bancos_bancoswwds_11_bandsc3 ,
                                              AV66Bancos_bancoswwds_12_tfbancod ,
                                              AV67Bancos_bancoswwds_13_tfbancod_to ,
                                              AV69Bancos_bancoswwds_15_tfbandsc_sel ,
                                              AV68Bancos_bancoswwds_14_tfbandsc ,
                                              AV71Bancos_bancoswwds_17_tfbanabr_sel ,
                                              AV70Bancos_bancoswwds_16_tfbanabr ,
                                              AV73Bancos_bancoswwds_19_tfbansunat_sel ,
                                              AV72Bancos_bancoswwds_18_tfbansunat ,
                                              AV74Bancos_bancoswwds_20_tfbansts ,
                                              AV75Bancos_bancoswwds_21_tfbansts_to ,
                                              A482BanDsc ,
                                              A372BanCod ,
                                              A481BanAbr ,
                                              A484BanSunat ,
                                              A483BanSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.SHORT
                                              }
         });
         lV57Bancos_bancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Bancos_bancoswwds_3_bandsc1), 100, "%");
         lV57Bancos_bancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Bancos_bancoswwds_3_bandsc1), 100, "%");
         lV61Bancos_bancoswwds_7_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_bancoswwds_7_bandsc2), 100, "%");
         lV61Bancos_bancoswwds_7_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_bancoswwds_7_bandsc2), 100, "%");
         lV65Bancos_bancoswwds_11_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_bancoswwds_11_bandsc3), 100, "%");
         lV65Bancos_bancoswwds_11_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_bancoswwds_11_bandsc3), 100, "%");
         lV68Bancos_bancoswwds_14_tfbandsc = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_bancoswwds_14_tfbandsc), 100, "%");
         lV70Bancos_bancoswwds_16_tfbanabr = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_bancoswwds_16_tfbanabr), 5, "%");
         lV72Bancos_bancoswwds_18_tfbansunat = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_bancoswwds_18_tfbansunat), 5, "%");
         /* Using cursor P00593 */
         pr_default.execute(1, new Object[] {lV57Bancos_bancoswwds_3_bandsc1, lV57Bancos_bancoswwds_3_bandsc1, lV61Bancos_bancoswwds_7_bandsc2, lV61Bancos_bancoswwds_7_bandsc2, lV65Bancos_bancoswwds_11_bandsc3, lV65Bancos_bancoswwds_11_bandsc3, AV66Bancos_bancoswwds_12_tfbancod, AV67Bancos_bancoswwds_13_tfbancod_to, lV68Bancos_bancoswwds_14_tfbandsc, AV69Bancos_bancoswwds_15_tfbandsc_sel, lV70Bancos_bancoswwds_16_tfbanabr, AV71Bancos_bancoswwds_17_tfbanabr_sel, lV72Bancos_bancoswwds_18_tfbansunat, AV73Bancos_bancoswwds_19_tfbansunat_sel, AV74Bancos_bancoswwds_20_tfbansts, AV75Bancos_bancoswwds_21_tfbansts_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK594 = false;
            A481BanAbr = P00593_A481BanAbr[0];
            A483BanSts = P00593_A483BanSts[0];
            A484BanSunat = P00593_A484BanSunat[0];
            A372BanCod = P00593_A372BanCod[0];
            A482BanDsc = P00593_A482BanDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00593_A481BanAbr[0], A481BanAbr) == 0 ) )
            {
               BRK594 = false;
               A372BanCod = P00593_A372BanCod[0];
               AV32count = (long)(AV32count+1);
               BRK594 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A481BanAbr)) )
            {
               AV24Option = A481BanAbr;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK594 )
            {
               BRK594 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADBANSUNATOPTIONS' Routine */
         returnInSub = false;
         AV18TFBanSunat = AV20SearchTxt;
         AV19TFBanSunat_Sel = "";
         AV55Bancos_bancoswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV57Bancos_bancoswwds_3_bandsc1 = AV40BanDsc1;
         AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV59Bancos_bancoswwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV61Bancos_bancoswwds_7_bandsc2 = AV44BanDsc2;
         AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV63Bancos_bancoswwds_9_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV65Bancos_bancoswwds_11_bandsc3 = AV48BanDsc3;
         AV66Bancos_bancoswwds_12_tfbancod = AV10TFBanCod;
         AV67Bancos_bancoswwds_13_tfbancod_to = AV11TFBanCod_To;
         AV68Bancos_bancoswwds_14_tfbandsc = AV12TFBanDsc;
         AV69Bancos_bancoswwds_15_tfbandsc_sel = AV13TFBanDsc_Sel;
         AV70Bancos_bancoswwds_16_tfbanabr = AV14TFBanAbr;
         AV71Bancos_bancoswwds_17_tfbanabr_sel = AV15TFBanAbr_Sel;
         AV72Bancos_bancoswwds_18_tfbansunat = AV18TFBanSunat;
         AV73Bancos_bancoswwds_19_tfbansunat_sel = AV19TFBanSunat_Sel;
         AV74Bancos_bancoswwds_20_tfbansts = AV16TFBanSts;
         AV75Bancos_bancoswwds_21_tfbansts_to = AV17TFBanSts_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV55Bancos_bancoswwds_1_dynamicfiltersselector1 ,
                                              AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 ,
                                              AV57Bancos_bancoswwds_3_bandsc1 ,
                                              AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 ,
                                              AV59Bancos_bancoswwds_5_dynamicfiltersselector2 ,
                                              AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 ,
                                              AV61Bancos_bancoswwds_7_bandsc2 ,
                                              AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 ,
                                              AV63Bancos_bancoswwds_9_dynamicfiltersselector3 ,
                                              AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 ,
                                              AV65Bancos_bancoswwds_11_bandsc3 ,
                                              AV66Bancos_bancoswwds_12_tfbancod ,
                                              AV67Bancos_bancoswwds_13_tfbancod_to ,
                                              AV69Bancos_bancoswwds_15_tfbandsc_sel ,
                                              AV68Bancos_bancoswwds_14_tfbandsc ,
                                              AV71Bancos_bancoswwds_17_tfbanabr_sel ,
                                              AV70Bancos_bancoswwds_16_tfbanabr ,
                                              AV73Bancos_bancoswwds_19_tfbansunat_sel ,
                                              AV72Bancos_bancoswwds_18_tfbansunat ,
                                              AV74Bancos_bancoswwds_20_tfbansts ,
                                              AV75Bancos_bancoswwds_21_tfbansts_to ,
                                              A482BanDsc ,
                                              A372BanCod ,
                                              A481BanAbr ,
                                              A484BanSunat ,
                                              A483BanSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.SHORT
                                              }
         });
         lV57Bancos_bancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Bancos_bancoswwds_3_bandsc1), 100, "%");
         lV57Bancos_bancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Bancos_bancoswwds_3_bandsc1), 100, "%");
         lV61Bancos_bancoswwds_7_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_bancoswwds_7_bandsc2), 100, "%");
         lV61Bancos_bancoswwds_7_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Bancos_bancoswwds_7_bandsc2), 100, "%");
         lV65Bancos_bancoswwds_11_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_bancoswwds_11_bandsc3), 100, "%");
         lV65Bancos_bancoswwds_11_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Bancos_bancoswwds_11_bandsc3), 100, "%");
         lV68Bancos_bancoswwds_14_tfbandsc = StringUtil.PadR( StringUtil.RTrim( AV68Bancos_bancoswwds_14_tfbandsc), 100, "%");
         lV70Bancos_bancoswwds_16_tfbanabr = StringUtil.PadR( StringUtil.RTrim( AV70Bancos_bancoswwds_16_tfbanabr), 5, "%");
         lV72Bancos_bancoswwds_18_tfbansunat = StringUtil.PadR( StringUtil.RTrim( AV72Bancos_bancoswwds_18_tfbansunat), 5, "%");
         /* Using cursor P00594 */
         pr_default.execute(2, new Object[] {lV57Bancos_bancoswwds_3_bandsc1, lV57Bancos_bancoswwds_3_bandsc1, lV61Bancos_bancoswwds_7_bandsc2, lV61Bancos_bancoswwds_7_bandsc2, lV65Bancos_bancoswwds_11_bandsc3, lV65Bancos_bancoswwds_11_bandsc3, AV66Bancos_bancoswwds_12_tfbancod, AV67Bancos_bancoswwds_13_tfbancod_to, lV68Bancos_bancoswwds_14_tfbandsc, AV69Bancos_bancoswwds_15_tfbandsc_sel, lV70Bancos_bancoswwds_16_tfbanabr, AV71Bancos_bancoswwds_17_tfbanabr_sel, lV72Bancos_bancoswwds_18_tfbansunat, AV73Bancos_bancoswwds_19_tfbansunat_sel, AV74Bancos_bancoswwds_20_tfbansts, AV75Bancos_bancoswwds_21_tfbansts_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK596 = false;
            A484BanSunat = P00594_A484BanSunat[0];
            A483BanSts = P00594_A483BanSts[0];
            A481BanAbr = P00594_A481BanAbr[0];
            A372BanCod = P00594_A372BanCod[0];
            A482BanDsc = P00594_A482BanDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00594_A484BanSunat[0], A484BanSunat) == 0 ) )
            {
               BRK596 = false;
               A372BanCod = P00594_A372BanCod[0];
               AV32count = (long)(AV32count+1);
               BRK596 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A484BanSunat)) )
            {
               AV24Option = A484BanSunat;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK596 )
            {
               BRK596 = true;
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
         AV12TFBanDsc = "";
         AV13TFBanDsc_Sel = "";
         AV14TFBanAbr = "";
         AV15TFBanAbr_Sel = "";
         AV18TFBanSunat = "";
         AV19TFBanSunat_Sel = "";
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40BanDsc1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44BanDsc2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48BanDsc3 = "";
         AV55Bancos_bancoswwds_1_dynamicfiltersselector1 = "";
         AV57Bancos_bancoswwds_3_bandsc1 = "";
         AV59Bancos_bancoswwds_5_dynamicfiltersselector2 = "";
         AV61Bancos_bancoswwds_7_bandsc2 = "";
         AV63Bancos_bancoswwds_9_dynamicfiltersselector3 = "";
         AV65Bancos_bancoswwds_11_bandsc3 = "";
         AV68Bancos_bancoswwds_14_tfbandsc = "";
         AV69Bancos_bancoswwds_15_tfbandsc_sel = "";
         AV70Bancos_bancoswwds_16_tfbanabr = "";
         AV71Bancos_bancoswwds_17_tfbanabr_sel = "";
         AV72Bancos_bancoswwds_18_tfbansunat = "";
         AV73Bancos_bancoswwds_19_tfbansunat_sel = "";
         scmdbuf = "";
         lV57Bancos_bancoswwds_3_bandsc1 = "";
         lV61Bancos_bancoswwds_7_bandsc2 = "";
         lV65Bancos_bancoswwds_11_bandsc3 = "";
         lV68Bancos_bancoswwds_14_tfbandsc = "";
         lV70Bancos_bancoswwds_16_tfbanabr = "";
         lV72Bancos_bancoswwds_18_tfbansunat = "";
         A482BanDsc = "";
         A481BanAbr = "";
         A484BanSunat = "";
         P00592_A482BanDsc = new string[] {""} ;
         P00592_A483BanSts = new short[1] ;
         P00592_A484BanSunat = new string[] {""} ;
         P00592_A481BanAbr = new string[] {""} ;
         P00592_A372BanCod = new int[1] ;
         AV24Option = "";
         P00593_A481BanAbr = new string[] {""} ;
         P00593_A483BanSts = new short[1] ;
         P00593_A484BanSunat = new string[] {""} ;
         P00593_A372BanCod = new int[1] ;
         P00593_A482BanDsc = new string[] {""} ;
         P00594_A484BanSunat = new string[] {""} ;
         P00594_A483BanSts = new short[1] ;
         P00594_A481BanAbr = new string[] {""} ;
         P00594_A372BanCod = new int[1] ;
         P00594_A482BanDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.bancoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00592_A482BanDsc, P00592_A483BanSts, P00592_A484BanSunat, P00592_A481BanAbr, P00592_A372BanCod
               }
               , new Object[] {
               P00593_A481BanAbr, P00593_A483BanSts, P00593_A484BanSunat, P00593_A372BanCod, P00593_A482BanDsc
               }
               , new Object[] {
               P00594_A484BanSunat, P00594_A483BanSts, P00594_A481BanAbr, P00594_A372BanCod, P00594_A482BanDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV16TFBanSts ;
      private short AV17TFBanSts_To ;
      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 ;
      private short AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 ;
      private short AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 ;
      private short AV74Bancos_bancoswwds_20_tfbansts ;
      private short AV75Bancos_bancoswwds_21_tfbansts_to ;
      private short A483BanSts ;
      private int AV53GXV1 ;
      private int AV10TFBanCod ;
      private int AV11TFBanCod_To ;
      private int AV66Bancos_bancoswwds_12_tfbancod ;
      private int AV67Bancos_bancoswwds_13_tfbancod_to ;
      private int A372BanCod ;
      private long AV32count ;
      private string AV12TFBanDsc ;
      private string AV13TFBanDsc_Sel ;
      private string AV14TFBanAbr ;
      private string AV15TFBanAbr_Sel ;
      private string AV18TFBanSunat ;
      private string AV19TFBanSunat_Sel ;
      private string AV40BanDsc1 ;
      private string AV44BanDsc2 ;
      private string AV48BanDsc3 ;
      private string AV57Bancos_bancoswwds_3_bandsc1 ;
      private string AV61Bancos_bancoswwds_7_bandsc2 ;
      private string AV65Bancos_bancoswwds_11_bandsc3 ;
      private string AV68Bancos_bancoswwds_14_tfbandsc ;
      private string AV69Bancos_bancoswwds_15_tfbandsc_sel ;
      private string AV70Bancos_bancoswwds_16_tfbanabr ;
      private string AV71Bancos_bancoswwds_17_tfbanabr_sel ;
      private string AV72Bancos_bancoswwds_18_tfbansunat ;
      private string AV73Bancos_bancoswwds_19_tfbansunat_sel ;
      private string scmdbuf ;
      private string lV57Bancos_bancoswwds_3_bandsc1 ;
      private string lV61Bancos_bancoswwds_7_bandsc2 ;
      private string lV65Bancos_bancoswwds_11_bandsc3 ;
      private string lV68Bancos_bancoswwds_14_tfbandsc ;
      private string lV70Bancos_bancoswwds_16_tfbanabr ;
      private string lV72Bancos_bancoswwds_18_tfbansunat ;
      private string A482BanDsc ;
      private string A481BanAbr ;
      private string A484BanSunat ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 ;
      private bool AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 ;
      private bool BRK592 ;
      private bool BRK594 ;
      private bool BRK596 ;
      private string AV26OptionsJson ;
      private string AV29OptionsDescJson ;
      private string AV31OptionIndexesJson ;
      private string AV22DDOName ;
      private string AV20SearchTxt ;
      private string AV21SearchTxtTo ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV55Bancos_bancoswwds_1_dynamicfiltersselector1 ;
      private string AV59Bancos_bancoswwds_5_dynamicfiltersselector2 ;
      private string AV63Bancos_bancoswwds_9_dynamicfiltersselector3 ;
      private string AV24Option ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00592_A482BanDsc ;
      private short[] P00592_A483BanSts ;
      private string[] P00592_A484BanSunat ;
      private string[] P00592_A481BanAbr ;
      private int[] P00592_A372BanCod ;
      private string[] P00593_A481BanAbr ;
      private short[] P00593_A483BanSts ;
      private string[] P00593_A484BanSunat ;
      private int[] P00593_A372BanCod ;
      private string[] P00593_A482BanDsc ;
      private string[] P00594_A484BanSunat ;
      private short[] P00594_A483BanSts ;
      private string[] P00594_A481BanAbr ;
      private int[] P00594_A372BanCod ;
      private string[] P00594_A482BanDsc ;
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

   public class bancoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00592( IGxContext context ,
                                             string AV55Bancos_bancoswwds_1_dynamicfiltersselector1 ,
                                             short AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV57Bancos_bancoswwds_3_bandsc1 ,
                                             bool AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 ,
                                             string AV59Bancos_bancoswwds_5_dynamicfiltersselector2 ,
                                             short AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 ,
                                             string AV61Bancos_bancoswwds_7_bandsc2 ,
                                             bool AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 ,
                                             string AV63Bancos_bancoswwds_9_dynamicfiltersselector3 ,
                                             short AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 ,
                                             string AV65Bancos_bancoswwds_11_bandsc3 ,
                                             int AV66Bancos_bancoswwds_12_tfbancod ,
                                             int AV67Bancos_bancoswwds_13_tfbancod_to ,
                                             string AV69Bancos_bancoswwds_15_tfbandsc_sel ,
                                             string AV68Bancos_bancoswwds_14_tfbandsc ,
                                             string AV71Bancos_bancoswwds_17_tfbanabr_sel ,
                                             string AV70Bancos_bancoswwds_16_tfbanabr ,
                                             string AV73Bancos_bancoswwds_19_tfbansunat_sel ,
                                             string AV72Bancos_bancoswwds_18_tfbansunat ,
                                             short AV74Bancos_bancoswwds_20_tfbansts ,
                                             short AV75Bancos_bancoswwds_21_tfbansts_to ,
                                             string A482BanDsc ,
                                             int A372BanCod ,
                                             string A481BanAbr ,
                                             string A484BanSunat ,
                                             short A483BanSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[16];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [BanDsc], [BanSts], [BanSunat], [BanAbr], [BanCod] FROM [TSBANCOS]";
         if ( ( StringUtil.StrCmp(AV55Bancos_bancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Bancos_bancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV57Bancos_bancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Bancos_bancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Bancos_bancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV57Bancos_bancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Bancos_bancoswwds_5_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_bancoswwds_7_bandsc2)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV61Bancos_bancoswwds_7_bandsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Bancos_bancoswwds_5_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_bancoswwds_7_bandsc2)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV61Bancos_bancoswwds_7_bandsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Bancos_bancoswwds_9_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_bancoswwds_11_bandsc3)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV65Bancos_bancoswwds_11_bandsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Bancos_bancoswwds_9_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_bancoswwds_11_bandsc3)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV65Bancos_bancoswwds_11_bandsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV66Bancos_bancoswwds_12_tfbancod) )
         {
            AddWhere(sWhereString, "([BanCod] >= @AV66Bancos_bancoswwds_12_tfbancod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV67Bancos_bancoswwds_13_tfbancod_to) )
         {
            AddWhere(sWhereString, "([BanCod] <= @AV67Bancos_bancoswwds_13_tfbancod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_bancoswwds_15_tfbandsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_bancoswwds_14_tfbandsc)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV68Bancos_bancoswwds_14_tfbandsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_bancoswwds_15_tfbandsc_sel)) )
         {
            AddWhere(sWhereString, "([BanDsc] = @AV69Bancos_bancoswwds_15_tfbandsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_bancoswwds_17_tfbanabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_bancoswwds_16_tfbanabr)) ) )
         {
            AddWhere(sWhereString, "([BanAbr] like @lV70Bancos_bancoswwds_16_tfbanabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_bancoswwds_17_tfbanabr_sel)) )
         {
            AddWhere(sWhereString, "([BanAbr] = @AV71Bancos_bancoswwds_17_tfbanabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_bancoswwds_19_tfbansunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_bancoswwds_18_tfbansunat)) ) )
         {
            AddWhere(sWhereString, "([BanSunat] like @lV72Bancos_bancoswwds_18_tfbansunat)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_bancoswwds_19_tfbansunat_sel)) )
         {
            AddWhere(sWhereString, "([BanSunat] = @AV73Bancos_bancoswwds_19_tfbansunat_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (0==AV74Bancos_bancoswwds_20_tfbansts) )
         {
            AddWhere(sWhereString, "([BanSts] >= @AV74Bancos_bancoswwds_20_tfbansts)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (0==AV75Bancos_bancoswwds_21_tfbansts_to) )
         {
            AddWhere(sWhereString, "([BanSts] <= @AV75Bancos_bancoswwds_21_tfbansts_to)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [BanDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00593( IGxContext context ,
                                             string AV55Bancos_bancoswwds_1_dynamicfiltersselector1 ,
                                             short AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV57Bancos_bancoswwds_3_bandsc1 ,
                                             bool AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 ,
                                             string AV59Bancos_bancoswwds_5_dynamicfiltersselector2 ,
                                             short AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 ,
                                             string AV61Bancos_bancoswwds_7_bandsc2 ,
                                             bool AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 ,
                                             string AV63Bancos_bancoswwds_9_dynamicfiltersselector3 ,
                                             short AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 ,
                                             string AV65Bancos_bancoswwds_11_bandsc3 ,
                                             int AV66Bancos_bancoswwds_12_tfbancod ,
                                             int AV67Bancos_bancoswwds_13_tfbancod_to ,
                                             string AV69Bancos_bancoswwds_15_tfbandsc_sel ,
                                             string AV68Bancos_bancoswwds_14_tfbandsc ,
                                             string AV71Bancos_bancoswwds_17_tfbanabr_sel ,
                                             string AV70Bancos_bancoswwds_16_tfbanabr ,
                                             string AV73Bancos_bancoswwds_19_tfbansunat_sel ,
                                             string AV72Bancos_bancoswwds_18_tfbansunat ,
                                             short AV74Bancos_bancoswwds_20_tfbansts ,
                                             short AV75Bancos_bancoswwds_21_tfbansts_to ,
                                             string A482BanDsc ,
                                             int A372BanCod ,
                                             string A481BanAbr ,
                                             string A484BanSunat ,
                                             short A483BanSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [BanAbr], [BanSts], [BanSunat], [BanCod], [BanDsc] FROM [TSBANCOS]";
         if ( ( StringUtil.StrCmp(AV55Bancos_bancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Bancos_bancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV57Bancos_bancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Bancos_bancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Bancos_bancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV57Bancos_bancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Bancos_bancoswwds_5_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_bancoswwds_7_bandsc2)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV61Bancos_bancoswwds_7_bandsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Bancos_bancoswwds_5_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_bancoswwds_7_bandsc2)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV61Bancos_bancoswwds_7_bandsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Bancos_bancoswwds_9_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_bancoswwds_11_bandsc3)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV65Bancos_bancoswwds_11_bandsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Bancos_bancoswwds_9_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_bancoswwds_11_bandsc3)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV65Bancos_bancoswwds_11_bandsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV66Bancos_bancoswwds_12_tfbancod) )
         {
            AddWhere(sWhereString, "([BanCod] >= @AV66Bancos_bancoswwds_12_tfbancod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV67Bancos_bancoswwds_13_tfbancod_to) )
         {
            AddWhere(sWhereString, "([BanCod] <= @AV67Bancos_bancoswwds_13_tfbancod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_bancoswwds_15_tfbandsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_bancoswwds_14_tfbandsc)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV68Bancos_bancoswwds_14_tfbandsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_bancoswwds_15_tfbandsc_sel)) )
         {
            AddWhere(sWhereString, "([BanDsc] = @AV69Bancos_bancoswwds_15_tfbandsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_bancoswwds_17_tfbanabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_bancoswwds_16_tfbanabr)) ) )
         {
            AddWhere(sWhereString, "([BanAbr] like @lV70Bancos_bancoswwds_16_tfbanabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_bancoswwds_17_tfbanabr_sel)) )
         {
            AddWhere(sWhereString, "([BanAbr] = @AV71Bancos_bancoswwds_17_tfbanabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_bancoswwds_19_tfbansunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_bancoswwds_18_tfbansunat)) ) )
         {
            AddWhere(sWhereString, "([BanSunat] like @lV72Bancos_bancoswwds_18_tfbansunat)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_bancoswwds_19_tfbansunat_sel)) )
         {
            AddWhere(sWhereString, "([BanSunat] = @AV73Bancos_bancoswwds_19_tfbansunat_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (0==AV74Bancos_bancoswwds_20_tfbansts) )
         {
            AddWhere(sWhereString, "([BanSts] >= @AV74Bancos_bancoswwds_20_tfbansts)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (0==AV75Bancos_bancoswwds_21_tfbansts_to) )
         {
            AddWhere(sWhereString, "([BanSts] <= @AV75Bancos_bancoswwds_21_tfbansts_to)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [BanAbr]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00594( IGxContext context ,
                                             string AV55Bancos_bancoswwds_1_dynamicfiltersselector1 ,
                                             short AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV57Bancos_bancoswwds_3_bandsc1 ,
                                             bool AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 ,
                                             string AV59Bancos_bancoswwds_5_dynamicfiltersselector2 ,
                                             short AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 ,
                                             string AV61Bancos_bancoswwds_7_bandsc2 ,
                                             bool AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 ,
                                             string AV63Bancos_bancoswwds_9_dynamicfiltersselector3 ,
                                             short AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 ,
                                             string AV65Bancos_bancoswwds_11_bandsc3 ,
                                             int AV66Bancos_bancoswwds_12_tfbancod ,
                                             int AV67Bancos_bancoswwds_13_tfbancod_to ,
                                             string AV69Bancos_bancoswwds_15_tfbandsc_sel ,
                                             string AV68Bancos_bancoswwds_14_tfbandsc ,
                                             string AV71Bancos_bancoswwds_17_tfbanabr_sel ,
                                             string AV70Bancos_bancoswwds_16_tfbanabr ,
                                             string AV73Bancos_bancoswwds_19_tfbansunat_sel ,
                                             string AV72Bancos_bancoswwds_18_tfbansunat ,
                                             short AV74Bancos_bancoswwds_20_tfbansts ,
                                             short AV75Bancos_bancoswwds_21_tfbansts_to ,
                                             string A482BanDsc ,
                                             int A372BanCod ,
                                             string A481BanAbr ,
                                             string A484BanSunat ,
                                             short A483BanSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[16];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [BanSunat], [BanSts], [BanAbr], [BanCod], [BanDsc] FROM [TSBANCOS]";
         if ( ( StringUtil.StrCmp(AV55Bancos_bancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Bancos_bancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV57Bancos_bancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Bancos_bancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV56Bancos_bancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Bancos_bancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV57Bancos_bancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Bancos_bancoswwds_5_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_bancoswwds_7_bandsc2)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV61Bancos_bancoswwds_7_bandsc2)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV58Bancos_bancoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Bancos_bancoswwds_5_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV60Bancos_bancoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Bancos_bancoswwds_7_bandsc2)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV61Bancos_bancoswwds_7_bandsc2)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Bancos_bancoswwds_9_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_bancoswwds_11_bandsc3)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV65Bancos_bancoswwds_11_bandsc3)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV62Bancos_bancoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Bancos_bancoswwds_9_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV64Bancos_bancoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancos_bancoswwds_11_bandsc3)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like '%' + @lV65Bancos_bancoswwds_11_bandsc3)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV66Bancos_bancoswwds_12_tfbancod) )
         {
            AddWhere(sWhereString, "([BanCod] >= @AV66Bancos_bancoswwds_12_tfbancod)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV67Bancos_bancoswwds_13_tfbancod_to) )
         {
            AddWhere(sWhereString, "([BanCod] <= @AV67Bancos_bancoswwds_13_tfbancod_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_bancoswwds_15_tfbandsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancos_bancoswwds_14_tfbandsc)) ) )
         {
            AddWhere(sWhereString, "([BanDsc] like @lV68Bancos_bancoswwds_14_tfbandsc)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancos_bancoswwds_15_tfbandsc_sel)) )
         {
            AddWhere(sWhereString, "([BanDsc] = @AV69Bancos_bancoswwds_15_tfbandsc_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_bancoswwds_17_tfbanabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Bancos_bancoswwds_16_tfbanabr)) ) )
         {
            AddWhere(sWhereString, "([BanAbr] like @lV70Bancos_bancoswwds_16_tfbanabr)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Bancos_bancoswwds_17_tfbanabr_sel)) )
         {
            AddWhere(sWhereString, "([BanAbr] = @AV71Bancos_bancoswwds_17_tfbanabr_sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_bancoswwds_19_tfbansunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Bancos_bancoswwds_18_tfbansunat)) ) )
         {
            AddWhere(sWhereString, "([BanSunat] like @lV72Bancos_bancoswwds_18_tfbansunat)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancos_bancoswwds_19_tfbansunat_sel)) )
         {
            AddWhere(sWhereString, "([BanSunat] = @AV73Bancos_bancoswwds_19_tfbansunat_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (0==AV74Bancos_bancoswwds_20_tfbansts) )
         {
            AddWhere(sWhereString, "([BanSts] >= @AV74Bancos_bancoswwds_20_tfbansts)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (0==AV75Bancos_bancoswwds_21_tfbansts_to) )
         {
            AddWhere(sWhereString, "([BanSts] <= @AV75Bancos_bancoswwds_21_tfbansts_to)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [BanSunat]";
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
                     return conditional_P00592(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] );
               case 1 :
                     return conditional_P00593(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] );
               case 2 :
                     return conditional_P00594(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] );
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
          Object[] prmP00592;
          prmP00592 = new Object[] {
          new ParDef("@lV57Bancos_bancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Bancos_bancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_bancoswwds_7_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_bancoswwds_7_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_bancoswwds_11_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_bancoswwds_11_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@AV66Bancos_bancoswwds_12_tfbancod",GXType.Int32,6,0) ,
          new ParDef("@AV67Bancos_bancoswwds_13_tfbancod_to",GXType.Int32,6,0) ,
          new ParDef("@lV68Bancos_bancoswwds_14_tfbandsc",GXType.NChar,100,0) ,
          new ParDef("@AV69Bancos_bancoswwds_15_tfbandsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_bancoswwds_16_tfbanabr",GXType.NChar,5,0) ,
          new ParDef("@AV71Bancos_bancoswwds_17_tfbanabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV72Bancos_bancoswwds_18_tfbansunat",GXType.NChar,5,0) ,
          new ParDef("@AV73Bancos_bancoswwds_19_tfbansunat_sel",GXType.NChar,5,0) ,
          new ParDef("@AV74Bancos_bancoswwds_20_tfbansts",GXType.Int16,1,0) ,
          new ParDef("@AV75Bancos_bancoswwds_21_tfbansts_to",GXType.Int16,1,0)
          };
          Object[] prmP00593;
          prmP00593 = new Object[] {
          new ParDef("@lV57Bancos_bancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Bancos_bancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_bancoswwds_7_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_bancoswwds_7_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_bancoswwds_11_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_bancoswwds_11_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@AV66Bancos_bancoswwds_12_tfbancod",GXType.Int32,6,0) ,
          new ParDef("@AV67Bancos_bancoswwds_13_tfbancod_to",GXType.Int32,6,0) ,
          new ParDef("@lV68Bancos_bancoswwds_14_tfbandsc",GXType.NChar,100,0) ,
          new ParDef("@AV69Bancos_bancoswwds_15_tfbandsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_bancoswwds_16_tfbanabr",GXType.NChar,5,0) ,
          new ParDef("@AV71Bancos_bancoswwds_17_tfbanabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV72Bancos_bancoswwds_18_tfbansunat",GXType.NChar,5,0) ,
          new ParDef("@AV73Bancos_bancoswwds_19_tfbansunat_sel",GXType.NChar,5,0) ,
          new ParDef("@AV74Bancos_bancoswwds_20_tfbansts",GXType.Int16,1,0) ,
          new ParDef("@AV75Bancos_bancoswwds_21_tfbansts_to",GXType.Int16,1,0)
          };
          Object[] prmP00594;
          prmP00594 = new Object[] {
          new ParDef("@lV57Bancos_bancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Bancos_bancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_bancoswwds_7_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Bancos_bancoswwds_7_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_bancoswwds_11_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@lV65Bancos_bancoswwds_11_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@AV66Bancos_bancoswwds_12_tfbancod",GXType.Int32,6,0) ,
          new ParDef("@AV67Bancos_bancoswwds_13_tfbancod_to",GXType.Int32,6,0) ,
          new ParDef("@lV68Bancos_bancoswwds_14_tfbandsc",GXType.NChar,100,0) ,
          new ParDef("@AV69Bancos_bancoswwds_15_tfbandsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV70Bancos_bancoswwds_16_tfbanabr",GXType.NChar,5,0) ,
          new ParDef("@AV71Bancos_bancoswwds_17_tfbanabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV72Bancos_bancoswwds_18_tfbansunat",GXType.NChar,5,0) ,
          new ParDef("@AV73Bancos_bancoswwds_19_tfbansunat_sel",GXType.NChar,5,0) ,
          new ParDef("@AV74Bancos_bancoswwds_20_tfbansts",GXType.Int16,1,0) ,
          new ParDef("@AV75Bancos_bancoswwds_21_tfbansts_to",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00592", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00592,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00593", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00593,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00594", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00594,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
