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
   public class cuentabancoswwgetfilterdata : GXProcedure
   {
      public cuentabancoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cuentabancoswwgetfilterdata( IGxContext context )
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
         this.AV30DDOName = aP0_DDOName;
         this.AV28SearchTxt = aP1_SearchTxt;
         this.AV29SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV39OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         cuentabancoswwgetfilterdata objcuentabancoswwgetfilterdata;
         objcuentabancoswwgetfilterdata = new cuentabancoswwgetfilterdata();
         objcuentabancoswwgetfilterdata.AV30DDOName = aP0_DDOName;
         objcuentabancoswwgetfilterdata.AV28SearchTxt = aP1_SearchTxt;
         objcuentabancoswwgetfilterdata.AV29SearchTxtTo = aP2_SearchTxtTo;
         objcuentabancoswwgetfilterdata.AV34OptionsJson = "" ;
         objcuentabancoswwgetfilterdata.AV37OptionsDescJson = "" ;
         objcuentabancoswwgetfilterdata.AV39OptionIndexesJson = "" ;
         objcuentabancoswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objcuentabancoswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcuentabancoswwgetfilterdata);
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cuentabancoswwgetfilterdata)stateInfo).executePrivate();
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
         AV33Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_BANDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADBANDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_CBCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADCBCODOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_MONDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADMONDSCOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV34OptionsJson = AV33Options.ToJSonString(false);
         AV37OptionsDescJson = AV36OptionsDesc.ToJSonString(false);
         AV39OptionIndexesJson = AV38OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV41Session.Get("Bancos.CuentaBancosWWGridState"), "") == 0 )
         {
            AV43GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Bancos.CuentaBancosWWGridState"), null, "", "");
         }
         else
         {
            AV43GridState.FromXml(AV41Session.Get("Bancos.CuentaBancosWWGridState"), null, "", "");
         }
         AV74GXV1 = 1;
         while ( AV74GXV1 <= AV43GridState.gxTpr_Filtervalues.Count )
         {
            AV44GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV43GridState.gxTpr_Filtervalues.Item(AV74GXV1));
            if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFBANDSC") == 0 )
            {
               AV60TFBanDsc = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFBANDSC_SEL") == 0 )
            {
               AV61TFBanDsc_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCBCOD") == 0 )
            {
               AV12TFCBCod = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCBCOD_SEL") == 0 )
            {
               AV13TFCBCod_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFMONDSC") == 0 )
            {
               AV62TFMonDsc = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFMONDSC_SEL") == 0 )
            {
               AV63TFMonDsc_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCBSTS") == 0 )
            {
               AV18TFCBSts = (short)(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."));
               AV19TFCBSts_To = (short)(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV74GXV1 = (int)(AV74GXV1+1);
         }
         if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV45GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(1));
            AV46DynamicFiltersSelector1 = AV45GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "BANDSC") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV45GridStateDynamicFilter.gxTpr_Operator;
               AV66BanDsc1 = AV45GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "MONCOD") == 0 )
            {
               AV67MonCod1 = (int)(NumberUtil.Val( AV45GridStateDynamicFilter.gxTpr_Value, "."));
            }
            if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV50DynamicFiltersEnabled2 = true;
               AV45GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(2));
               AV51DynamicFiltersSelector2 = AV45GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV51DynamicFiltersSelector2, "BANDSC") == 0 )
               {
                  AV52DynamicFiltersOperator2 = AV45GridStateDynamicFilter.gxTpr_Operator;
                  AV68BanDsc2 = AV45GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV51DynamicFiltersSelector2, "MONCOD") == 0 )
               {
                  AV69MonCod2 = (int)(NumberUtil.Val( AV45GridStateDynamicFilter.gxTpr_Value, "."));
               }
               if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV55DynamicFiltersEnabled3 = true;
                  AV45GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(3));
                  AV56DynamicFiltersSelector3 = AV45GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "BANDSC") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV45GridStateDynamicFilter.gxTpr_Operator;
                     AV70BanDsc3 = AV45GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "MONCOD") == 0 )
                  {
                     AV71MonCod3 = (int)(NumberUtil.Val( AV45GridStateDynamicFilter.gxTpr_Value, "."));
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADBANDSCOPTIONS' Routine */
         returnInSub = false;
         AV60TFBanDsc = AV28SearchTxt;
         AV61TFBanDsc_Sel = "";
         AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV78Bancos_cuentabancoswwds_3_bandsc1 = AV66BanDsc1;
         AV79Bancos_cuentabancoswwds_4_moncod1 = AV67MonCod1;
         AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV83Bancos_cuentabancoswwds_8_bandsc2 = AV68BanDsc2;
         AV84Bancos_cuentabancoswwds_9_moncod2 = AV69MonCod2;
         AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV88Bancos_cuentabancoswwds_13_bandsc3 = AV70BanDsc3;
         AV89Bancos_cuentabancoswwds_14_moncod3 = AV71MonCod3;
         AV90Bancos_cuentabancoswwds_15_tfbandsc = AV60TFBanDsc;
         AV91Bancos_cuentabancoswwds_16_tfbandsc_sel = AV61TFBanDsc_Sel;
         AV92Bancos_cuentabancoswwds_17_tfcbcod = AV12TFCBCod;
         AV93Bancos_cuentabancoswwds_18_tfcbcod_sel = AV13TFCBCod_Sel;
         AV94Bancos_cuentabancoswwds_19_tfmondsc = AV62TFMonDsc;
         AV95Bancos_cuentabancoswwds_20_tfmondsc_sel = AV63TFMonDsc_Sel;
         AV96Bancos_cuentabancoswwds_21_tfcbsts = AV18TFCBSts;
         AV97Bancos_cuentabancoswwds_22_tfcbsts_to = AV19TFCBSts_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ,
                                              AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ,
                                              AV78Bancos_cuentabancoswwds_3_bandsc1 ,
                                              AV79Bancos_cuentabancoswwds_4_moncod1 ,
                                              AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ,
                                              AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ,
                                              AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ,
                                              AV83Bancos_cuentabancoswwds_8_bandsc2 ,
                                              AV84Bancos_cuentabancoswwds_9_moncod2 ,
                                              AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ,
                                              AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ,
                                              AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ,
                                              AV88Bancos_cuentabancoswwds_13_bandsc3 ,
                                              AV89Bancos_cuentabancoswwds_14_moncod3 ,
                                              AV91Bancos_cuentabancoswwds_16_tfbandsc_sel ,
                                              AV90Bancos_cuentabancoswwds_15_tfbandsc ,
                                              AV93Bancos_cuentabancoswwds_18_tfcbcod_sel ,
                                              AV92Bancos_cuentabancoswwds_17_tfcbcod ,
                                              AV95Bancos_cuentabancoswwds_20_tfmondsc_sel ,
                                              AV94Bancos_cuentabancoswwds_19_tfmondsc ,
                                              AV96Bancos_cuentabancoswwds_21_tfcbsts ,
                                              AV97Bancos_cuentabancoswwds_22_tfcbsts_to ,
                                              A482BanDsc ,
                                              A180MonCod ,
                                              A377CBCod ,
                                              A1234MonDsc ,
                                              A504CBSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV78Bancos_cuentabancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_cuentabancoswwds_3_bandsc1), 100, "%");
         lV78Bancos_cuentabancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_cuentabancoswwds_3_bandsc1), 100, "%");
         lV83Bancos_cuentabancoswwds_8_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV83Bancos_cuentabancoswwds_8_bandsc2), 100, "%");
         lV83Bancos_cuentabancoswwds_8_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV83Bancos_cuentabancoswwds_8_bandsc2), 100, "%");
         lV88Bancos_cuentabancoswwds_13_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV88Bancos_cuentabancoswwds_13_bandsc3), 100, "%");
         lV88Bancos_cuentabancoswwds_13_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV88Bancos_cuentabancoswwds_13_bandsc3), 100, "%");
         lV90Bancos_cuentabancoswwds_15_tfbandsc = StringUtil.PadR( StringUtil.RTrim( AV90Bancos_cuentabancoswwds_15_tfbandsc), 100, "%");
         lV92Bancos_cuentabancoswwds_17_tfcbcod = StringUtil.PadR( StringUtil.RTrim( AV92Bancos_cuentabancoswwds_17_tfcbcod), 20, "%");
         lV94Bancos_cuentabancoswwds_19_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV94Bancos_cuentabancoswwds_19_tfmondsc), 100, "%");
         /* Using cursor P005C2 */
         pr_default.execute(0, new Object[] {lV78Bancos_cuentabancoswwds_3_bandsc1, lV78Bancos_cuentabancoswwds_3_bandsc1, AV79Bancos_cuentabancoswwds_4_moncod1, lV83Bancos_cuentabancoswwds_8_bandsc2, lV83Bancos_cuentabancoswwds_8_bandsc2, AV84Bancos_cuentabancoswwds_9_moncod2, lV88Bancos_cuentabancoswwds_13_bandsc3, lV88Bancos_cuentabancoswwds_13_bandsc3, AV89Bancos_cuentabancoswwds_14_moncod3, lV90Bancos_cuentabancoswwds_15_tfbandsc, AV91Bancos_cuentabancoswwds_16_tfbandsc_sel, lV92Bancos_cuentabancoswwds_17_tfcbcod, AV93Bancos_cuentabancoswwds_18_tfcbcod_sel, lV94Bancos_cuentabancoswwds_19_tfmondsc, AV95Bancos_cuentabancoswwds_20_tfmondsc_sel, AV96Bancos_cuentabancoswwds_21_tfcbsts, AV97Bancos_cuentabancoswwds_22_tfcbsts_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5C2 = false;
            A372BanCod = P005C2_A372BanCod[0];
            A504CBSts = P005C2_A504CBSts[0];
            A1234MonDsc = P005C2_A1234MonDsc[0];
            A377CBCod = P005C2_A377CBCod[0];
            A180MonCod = P005C2_A180MonCod[0];
            A482BanDsc = P005C2_A482BanDsc[0];
            A482BanDsc = P005C2_A482BanDsc[0];
            A1234MonDsc = P005C2_A1234MonDsc[0];
            AV40count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P005C2_A372BanCod[0] == A372BanCod ) )
            {
               BRK5C2 = false;
               A377CBCod = P005C2_A377CBCod[0];
               AV40count = (long)(AV40count+1);
               BRK5C2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A482BanDsc)) )
            {
               AV32Option = A482BanDsc;
               AV31InsertIndex = 1;
               while ( ( AV31InsertIndex <= AV33Options.Count ) && ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), AV32Option) < 0 ) )
               {
                  AV31InsertIndex = (int)(AV31InsertIndex+1);
               }
               AV33Options.Add(AV32Option, AV31InsertIndex);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), AV31InsertIndex);
            }
            if ( AV33Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK5C2 )
            {
               BRK5C2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCBCODOPTIONS' Routine */
         returnInSub = false;
         AV12TFCBCod = AV28SearchTxt;
         AV13TFCBCod_Sel = "";
         AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV78Bancos_cuentabancoswwds_3_bandsc1 = AV66BanDsc1;
         AV79Bancos_cuentabancoswwds_4_moncod1 = AV67MonCod1;
         AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV83Bancos_cuentabancoswwds_8_bandsc2 = AV68BanDsc2;
         AV84Bancos_cuentabancoswwds_9_moncod2 = AV69MonCod2;
         AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV88Bancos_cuentabancoswwds_13_bandsc3 = AV70BanDsc3;
         AV89Bancos_cuentabancoswwds_14_moncod3 = AV71MonCod3;
         AV90Bancos_cuentabancoswwds_15_tfbandsc = AV60TFBanDsc;
         AV91Bancos_cuentabancoswwds_16_tfbandsc_sel = AV61TFBanDsc_Sel;
         AV92Bancos_cuentabancoswwds_17_tfcbcod = AV12TFCBCod;
         AV93Bancos_cuentabancoswwds_18_tfcbcod_sel = AV13TFCBCod_Sel;
         AV94Bancos_cuentabancoswwds_19_tfmondsc = AV62TFMonDsc;
         AV95Bancos_cuentabancoswwds_20_tfmondsc_sel = AV63TFMonDsc_Sel;
         AV96Bancos_cuentabancoswwds_21_tfcbsts = AV18TFCBSts;
         AV97Bancos_cuentabancoswwds_22_tfcbsts_to = AV19TFCBSts_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ,
                                              AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ,
                                              AV78Bancos_cuentabancoswwds_3_bandsc1 ,
                                              AV79Bancos_cuentabancoswwds_4_moncod1 ,
                                              AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ,
                                              AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ,
                                              AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ,
                                              AV83Bancos_cuentabancoswwds_8_bandsc2 ,
                                              AV84Bancos_cuentabancoswwds_9_moncod2 ,
                                              AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ,
                                              AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ,
                                              AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ,
                                              AV88Bancos_cuentabancoswwds_13_bandsc3 ,
                                              AV89Bancos_cuentabancoswwds_14_moncod3 ,
                                              AV91Bancos_cuentabancoswwds_16_tfbandsc_sel ,
                                              AV90Bancos_cuentabancoswwds_15_tfbandsc ,
                                              AV93Bancos_cuentabancoswwds_18_tfcbcod_sel ,
                                              AV92Bancos_cuentabancoswwds_17_tfcbcod ,
                                              AV95Bancos_cuentabancoswwds_20_tfmondsc_sel ,
                                              AV94Bancos_cuentabancoswwds_19_tfmondsc ,
                                              AV96Bancos_cuentabancoswwds_21_tfcbsts ,
                                              AV97Bancos_cuentabancoswwds_22_tfcbsts_to ,
                                              A482BanDsc ,
                                              A180MonCod ,
                                              A377CBCod ,
                                              A1234MonDsc ,
                                              A504CBSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV78Bancos_cuentabancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_cuentabancoswwds_3_bandsc1), 100, "%");
         lV78Bancos_cuentabancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_cuentabancoswwds_3_bandsc1), 100, "%");
         lV83Bancos_cuentabancoswwds_8_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV83Bancos_cuentabancoswwds_8_bandsc2), 100, "%");
         lV83Bancos_cuentabancoswwds_8_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV83Bancos_cuentabancoswwds_8_bandsc2), 100, "%");
         lV88Bancos_cuentabancoswwds_13_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV88Bancos_cuentabancoswwds_13_bandsc3), 100, "%");
         lV88Bancos_cuentabancoswwds_13_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV88Bancos_cuentabancoswwds_13_bandsc3), 100, "%");
         lV90Bancos_cuentabancoswwds_15_tfbandsc = StringUtil.PadR( StringUtil.RTrim( AV90Bancos_cuentabancoswwds_15_tfbandsc), 100, "%");
         lV92Bancos_cuentabancoswwds_17_tfcbcod = StringUtil.PadR( StringUtil.RTrim( AV92Bancos_cuentabancoswwds_17_tfcbcod), 20, "%");
         lV94Bancos_cuentabancoswwds_19_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV94Bancos_cuentabancoswwds_19_tfmondsc), 100, "%");
         /* Using cursor P005C3 */
         pr_default.execute(1, new Object[] {lV78Bancos_cuentabancoswwds_3_bandsc1, lV78Bancos_cuentabancoswwds_3_bandsc1, AV79Bancos_cuentabancoswwds_4_moncod1, lV83Bancos_cuentabancoswwds_8_bandsc2, lV83Bancos_cuentabancoswwds_8_bandsc2, AV84Bancos_cuentabancoswwds_9_moncod2, lV88Bancos_cuentabancoswwds_13_bandsc3, lV88Bancos_cuentabancoswwds_13_bandsc3, AV89Bancos_cuentabancoswwds_14_moncod3, lV90Bancos_cuentabancoswwds_15_tfbandsc, AV91Bancos_cuentabancoswwds_16_tfbandsc_sel, lV92Bancos_cuentabancoswwds_17_tfcbcod, AV93Bancos_cuentabancoswwds_18_tfcbcod_sel, lV94Bancos_cuentabancoswwds_19_tfmondsc, AV95Bancos_cuentabancoswwds_20_tfmondsc_sel, AV96Bancos_cuentabancoswwds_21_tfcbsts, AV97Bancos_cuentabancoswwds_22_tfcbsts_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5C4 = false;
            A372BanCod = P005C3_A372BanCod[0];
            A377CBCod = P005C3_A377CBCod[0];
            A504CBSts = P005C3_A504CBSts[0];
            A1234MonDsc = P005C3_A1234MonDsc[0];
            A180MonCod = P005C3_A180MonCod[0];
            A482BanDsc = P005C3_A482BanDsc[0];
            A482BanDsc = P005C3_A482BanDsc[0];
            A1234MonDsc = P005C3_A1234MonDsc[0];
            AV40count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005C3_A377CBCod[0], A377CBCod) == 0 ) )
            {
               BRK5C4 = false;
               A372BanCod = P005C3_A372BanCod[0];
               AV40count = (long)(AV40count+1);
               BRK5C4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A377CBCod)) )
            {
               AV32Option = A377CBCod;
               AV33Options.Add(AV32Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV33Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK5C4 )
            {
               BRK5C4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADMONDSCOPTIONS' Routine */
         returnInSub = false;
         AV62TFMonDsc = AV28SearchTxt;
         AV63TFMonDsc_Sel = "";
         AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV78Bancos_cuentabancoswwds_3_bandsc1 = AV66BanDsc1;
         AV79Bancos_cuentabancoswwds_4_moncod1 = AV67MonCod1;
         AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 = AV50DynamicFiltersEnabled2;
         AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = AV51DynamicFiltersSelector2;
         AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 = AV52DynamicFiltersOperator2;
         AV83Bancos_cuentabancoswwds_8_bandsc2 = AV68BanDsc2;
         AV84Bancos_cuentabancoswwds_9_moncod2 = AV69MonCod2;
         AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV88Bancos_cuentabancoswwds_13_bandsc3 = AV70BanDsc3;
         AV89Bancos_cuentabancoswwds_14_moncod3 = AV71MonCod3;
         AV90Bancos_cuentabancoswwds_15_tfbandsc = AV60TFBanDsc;
         AV91Bancos_cuentabancoswwds_16_tfbandsc_sel = AV61TFBanDsc_Sel;
         AV92Bancos_cuentabancoswwds_17_tfcbcod = AV12TFCBCod;
         AV93Bancos_cuentabancoswwds_18_tfcbcod_sel = AV13TFCBCod_Sel;
         AV94Bancos_cuentabancoswwds_19_tfmondsc = AV62TFMonDsc;
         AV95Bancos_cuentabancoswwds_20_tfmondsc_sel = AV63TFMonDsc_Sel;
         AV96Bancos_cuentabancoswwds_21_tfcbsts = AV18TFCBSts;
         AV97Bancos_cuentabancoswwds_22_tfcbsts_to = AV19TFCBSts_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ,
                                              AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ,
                                              AV78Bancos_cuentabancoswwds_3_bandsc1 ,
                                              AV79Bancos_cuentabancoswwds_4_moncod1 ,
                                              AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ,
                                              AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ,
                                              AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ,
                                              AV83Bancos_cuentabancoswwds_8_bandsc2 ,
                                              AV84Bancos_cuentabancoswwds_9_moncod2 ,
                                              AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ,
                                              AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ,
                                              AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ,
                                              AV88Bancos_cuentabancoswwds_13_bandsc3 ,
                                              AV89Bancos_cuentabancoswwds_14_moncod3 ,
                                              AV91Bancos_cuentabancoswwds_16_tfbandsc_sel ,
                                              AV90Bancos_cuentabancoswwds_15_tfbandsc ,
                                              AV93Bancos_cuentabancoswwds_18_tfcbcod_sel ,
                                              AV92Bancos_cuentabancoswwds_17_tfcbcod ,
                                              AV95Bancos_cuentabancoswwds_20_tfmondsc_sel ,
                                              AV94Bancos_cuentabancoswwds_19_tfmondsc ,
                                              AV96Bancos_cuentabancoswwds_21_tfcbsts ,
                                              AV97Bancos_cuentabancoswwds_22_tfcbsts_to ,
                                              A482BanDsc ,
                                              A180MonCod ,
                                              A377CBCod ,
                                              A1234MonDsc ,
                                              A504CBSts } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV78Bancos_cuentabancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_cuentabancoswwds_3_bandsc1), 100, "%");
         lV78Bancos_cuentabancoswwds_3_bandsc1 = StringUtil.PadR( StringUtil.RTrim( AV78Bancos_cuentabancoswwds_3_bandsc1), 100, "%");
         lV83Bancos_cuentabancoswwds_8_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV83Bancos_cuentabancoswwds_8_bandsc2), 100, "%");
         lV83Bancos_cuentabancoswwds_8_bandsc2 = StringUtil.PadR( StringUtil.RTrim( AV83Bancos_cuentabancoswwds_8_bandsc2), 100, "%");
         lV88Bancos_cuentabancoswwds_13_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV88Bancos_cuentabancoswwds_13_bandsc3), 100, "%");
         lV88Bancos_cuentabancoswwds_13_bandsc3 = StringUtil.PadR( StringUtil.RTrim( AV88Bancos_cuentabancoswwds_13_bandsc3), 100, "%");
         lV90Bancos_cuentabancoswwds_15_tfbandsc = StringUtil.PadR( StringUtil.RTrim( AV90Bancos_cuentabancoswwds_15_tfbandsc), 100, "%");
         lV92Bancos_cuentabancoswwds_17_tfcbcod = StringUtil.PadR( StringUtil.RTrim( AV92Bancos_cuentabancoswwds_17_tfcbcod), 20, "%");
         lV94Bancos_cuentabancoswwds_19_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV94Bancos_cuentabancoswwds_19_tfmondsc), 100, "%");
         /* Using cursor P005C4 */
         pr_default.execute(2, new Object[] {lV78Bancos_cuentabancoswwds_3_bandsc1, lV78Bancos_cuentabancoswwds_3_bandsc1, AV79Bancos_cuentabancoswwds_4_moncod1, lV83Bancos_cuentabancoswwds_8_bandsc2, lV83Bancos_cuentabancoswwds_8_bandsc2, AV84Bancos_cuentabancoswwds_9_moncod2, lV88Bancos_cuentabancoswwds_13_bandsc3, lV88Bancos_cuentabancoswwds_13_bandsc3, AV89Bancos_cuentabancoswwds_14_moncod3, lV90Bancos_cuentabancoswwds_15_tfbandsc, AV91Bancos_cuentabancoswwds_16_tfbandsc_sel, lV92Bancos_cuentabancoswwds_17_tfcbcod, AV93Bancos_cuentabancoswwds_18_tfcbcod_sel, lV94Bancos_cuentabancoswwds_19_tfmondsc, AV95Bancos_cuentabancoswwds_20_tfmondsc_sel, AV96Bancos_cuentabancoswwds_21_tfcbsts, AV97Bancos_cuentabancoswwds_22_tfcbsts_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5C6 = false;
            A372BanCod = P005C4_A372BanCod[0];
            A1234MonDsc = P005C4_A1234MonDsc[0];
            A504CBSts = P005C4_A504CBSts[0];
            A377CBCod = P005C4_A377CBCod[0];
            A180MonCod = P005C4_A180MonCod[0];
            A482BanDsc = P005C4_A482BanDsc[0];
            A482BanDsc = P005C4_A482BanDsc[0];
            A1234MonDsc = P005C4_A1234MonDsc[0];
            AV40count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005C4_A1234MonDsc[0], A1234MonDsc) == 0 ) )
            {
               BRK5C6 = false;
               A372BanCod = P005C4_A372BanCod[0];
               A377CBCod = P005C4_A377CBCod[0];
               A180MonCod = P005C4_A180MonCod[0];
               AV40count = (long)(AV40count+1);
               BRK5C6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1234MonDsc)) )
            {
               AV32Option = A1234MonDsc;
               AV33Options.Add(AV32Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV33Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK5C6 )
            {
               BRK5C6 = true;
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
         AV34OptionsJson = "";
         AV37OptionsDescJson = "";
         AV39OptionIndexesJson = "";
         AV33Options = new GxSimpleCollection<string>();
         AV36OptionsDesc = new GxSimpleCollection<string>();
         AV38OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV41Session = context.GetSession();
         AV43GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV44GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV60TFBanDsc = "";
         AV61TFBanDsc_Sel = "";
         AV12TFCBCod = "";
         AV13TFCBCod_Sel = "";
         AV62TFMonDsc = "";
         AV63TFMonDsc_Sel = "";
         AV45GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV46DynamicFiltersSelector1 = "";
         AV66BanDsc1 = "";
         AV51DynamicFiltersSelector2 = "";
         AV68BanDsc2 = "";
         AV56DynamicFiltersSelector3 = "";
         AV70BanDsc3 = "";
         AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1 = "";
         AV78Bancos_cuentabancoswwds_3_bandsc1 = "";
         AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2 = "";
         AV83Bancos_cuentabancoswwds_8_bandsc2 = "";
         AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3 = "";
         AV88Bancos_cuentabancoswwds_13_bandsc3 = "";
         AV90Bancos_cuentabancoswwds_15_tfbandsc = "";
         AV91Bancos_cuentabancoswwds_16_tfbandsc_sel = "";
         AV92Bancos_cuentabancoswwds_17_tfcbcod = "";
         AV93Bancos_cuentabancoswwds_18_tfcbcod_sel = "";
         AV94Bancos_cuentabancoswwds_19_tfmondsc = "";
         AV95Bancos_cuentabancoswwds_20_tfmondsc_sel = "";
         scmdbuf = "";
         lV78Bancos_cuentabancoswwds_3_bandsc1 = "";
         lV83Bancos_cuentabancoswwds_8_bandsc2 = "";
         lV88Bancos_cuentabancoswwds_13_bandsc3 = "";
         lV90Bancos_cuentabancoswwds_15_tfbandsc = "";
         lV92Bancos_cuentabancoswwds_17_tfcbcod = "";
         lV94Bancos_cuentabancoswwds_19_tfmondsc = "";
         A482BanDsc = "";
         A377CBCod = "";
         A1234MonDsc = "";
         P005C2_A372BanCod = new int[1] ;
         P005C2_A504CBSts = new short[1] ;
         P005C2_A1234MonDsc = new string[] {""} ;
         P005C2_A377CBCod = new string[] {""} ;
         P005C2_A180MonCod = new int[1] ;
         P005C2_A482BanDsc = new string[] {""} ;
         AV32Option = "";
         P005C3_A372BanCod = new int[1] ;
         P005C3_A377CBCod = new string[] {""} ;
         P005C3_A504CBSts = new short[1] ;
         P005C3_A1234MonDsc = new string[] {""} ;
         P005C3_A180MonCod = new int[1] ;
         P005C3_A482BanDsc = new string[] {""} ;
         P005C4_A372BanCod = new int[1] ;
         P005C4_A1234MonDsc = new string[] {""} ;
         P005C4_A504CBSts = new short[1] ;
         P005C4_A377CBCod = new string[] {""} ;
         P005C4_A180MonCod = new int[1] ;
         P005C4_A482BanDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.cuentabancoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005C2_A372BanCod, P005C2_A504CBSts, P005C2_A1234MonDsc, P005C2_A377CBCod, P005C2_A180MonCod, P005C2_A482BanDsc
               }
               , new Object[] {
               P005C3_A372BanCod, P005C3_A377CBCod, P005C3_A504CBSts, P005C3_A1234MonDsc, P005C3_A180MonCod, P005C3_A482BanDsc
               }
               , new Object[] {
               P005C4_A372BanCod, P005C4_A1234MonDsc, P005C4_A504CBSts, P005C4_A377CBCod, P005C4_A180MonCod, P005C4_A482BanDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV18TFCBSts ;
      private short AV19TFCBSts_To ;
      private short AV47DynamicFiltersOperator1 ;
      private short AV52DynamicFiltersOperator2 ;
      private short AV57DynamicFiltersOperator3 ;
      private short AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ;
      private short AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ;
      private short AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ;
      private short AV96Bancos_cuentabancoswwds_21_tfcbsts ;
      private short AV97Bancos_cuentabancoswwds_22_tfcbsts_to ;
      private short A504CBSts ;
      private int AV74GXV1 ;
      private int AV67MonCod1 ;
      private int AV69MonCod2 ;
      private int AV71MonCod3 ;
      private int AV79Bancos_cuentabancoswwds_4_moncod1 ;
      private int AV84Bancos_cuentabancoswwds_9_moncod2 ;
      private int AV89Bancos_cuentabancoswwds_14_moncod3 ;
      private int A180MonCod ;
      private int A372BanCod ;
      private int AV31InsertIndex ;
      private long AV40count ;
      private string AV60TFBanDsc ;
      private string AV61TFBanDsc_Sel ;
      private string AV12TFCBCod ;
      private string AV13TFCBCod_Sel ;
      private string AV62TFMonDsc ;
      private string AV63TFMonDsc_Sel ;
      private string AV66BanDsc1 ;
      private string AV68BanDsc2 ;
      private string AV70BanDsc3 ;
      private string AV78Bancos_cuentabancoswwds_3_bandsc1 ;
      private string AV83Bancos_cuentabancoswwds_8_bandsc2 ;
      private string AV88Bancos_cuentabancoswwds_13_bandsc3 ;
      private string AV90Bancos_cuentabancoswwds_15_tfbandsc ;
      private string AV91Bancos_cuentabancoswwds_16_tfbandsc_sel ;
      private string AV92Bancos_cuentabancoswwds_17_tfcbcod ;
      private string AV93Bancos_cuentabancoswwds_18_tfcbcod_sel ;
      private string AV94Bancos_cuentabancoswwds_19_tfmondsc ;
      private string AV95Bancos_cuentabancoswwds_20_tfmondsc_sel ;
      private string scmdbuf ;
      private string lV78Bancos_cuentabancoswwds_3_bandsc1 ;
      private string lV83Bancos_cuentabancoswwds_8_bandsc2 ;
      private string lV88Bancos_cuentabancoswwds_13_bandsc3 ;
      private string lV90Bancos_cuentabancoswwds_15_tfbandsc ;
      private string lV92Bancos_cuentabancoswwds_17_tfcbcod ;
      private string lV94Bancos_cuentabancoswwds_19_tfmondsc ;
      private string A482BanDsc ;
      private string A377CBCod ;
      private string A1234MonDsc ;
      private bool returnInSub ;
      private bool AV50DynamicFiltersEnabled2 ;
      private bool AV55DynamicFiltersEnabled3 ;
      private bool AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ;
      private bool AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ;
      private bool BRK5C2 ;
      private bool BRK5C4 ;
      private bool BRK5C6 ;
      private string AV34OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV39OptionIndexesJson ;
      private string AV30DDOName ;
      private string AV28SearchTxt ;
      private string AV29SearchTxtTo ;
      private string AV46DynamicFiltersSelector1 ;
      private string AV51DynamicFiltersSelector2 ;
      private string AV56DynamicFiltersSelector3 ;
      private string AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ;
      private string AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ;
      private string AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ;
      private string AV32Option ;
      private IGxSession AV41Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P005C2_A372BanCod ;
      private short[] P005C2_A504CBSts ;
      private string[] P005C2_A1234MonDsc ;
      private string[] P005C2_A377CBCod ;
      private int[] P005C2_A180MonCod ;
      private string[] P005C2_A482BanDsc ;
      private int[] P005C3_A372BanCod ;
      private string[] P005C3_A377CBCod ;
      private short[] P005C3_A504CBSts ;
      private string[] P005C3_A1234MonDsc ;
      private int[] P005C3_A180MonCod ;
      private string[] P005C3_A482BanDsc ;
      private int[] P005C4_A372BanCod ;
      private string[] P005C4_A1234MonDsc ;
      private short[] P005C4_A504CBSts ;
      private string[] P005C4_A377CBCod ;
      private int[] P005C4_A180MonCod ;
      private string[] P005C4_A482BanDsc ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV33Options ;
      private GxSimpleCollection<string> AV36OptionsDesc ;
      private GxSimpleCollection<string> AV38OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV43GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV44GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV45GridStateDynamicFilter ;
   }

   public class cuentabancoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005C2( IGxContext context ,
                                             string AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ,
                                             short AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV78Bancos_cuentabancoswwds_3_bandsc1 ,
                                             int AV79Bancos_cuentabancoswwds_4_moncod1 ,
                                             bool AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ,
                                             string AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ,
                                             short AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ,
                                             string AV83Bancos_cuentabancoswwds_8_bandsc2 ,
                                             int AV84Bancos_cuentabancoswwds_9_moncod2 ,
                                             bool AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ,
                                             string AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ,
                                             short AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ,
                                             string AV88Bancos_cuentabancoswwds_13_bandsc3 ,
                                             int AV89Bancos_cuentabancoswwds_14_moncod3 ,
                                             string AV91Bancos_cuentabancoswwds_16_tfbandsc_sel ,
                                             string AV90Bancos_cuentabancoswwds_15_tfbandsc ,
                                             string AV93Bancos_cuentabancoswwds_18_tfcbcod_sel ,
                                             string AV92Bancos_cuentabancoswwds_17_tfcbcod ,
                                             string AV95Bancos_cuentabancoswwds_20_tfmondsc_sel ,
                                             string AV94Bancos_cuentabancoswwds_19_tfmondsc ,
                                             short AV96Bancos_cuentabancoswwds_21_tfcbsts ,
                                             short AV97Bancos_cuentabancoswwds_22_tfcbsts_to ,
                                             string A482BanDsc ,
                                             int A180MonCod ,
                                             string A377CBCod ,
                                             string A1234MonDsc ,
                                             short A504CBSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[17];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[BanCod], T1.[CBSts], T3.[MonDsc], T1.[CBCod], T1.[MonCod], T2.[BanDsc] FROM (([TSCUENTABANCO] T1 INNER JOIN [TSBANCOS] T2 ON T2.[BanCod] = T1.[BanCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[MonCod])";
         if ( ( StringUtil.StrCmp(AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_cuentabancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV78Bancos_cuentabancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_cuentabancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like '%' + @lV78Bancos_cuentabancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "MONCOD") == 0 ) && ( ! (0==AV79Bancos_cuentabancoswwds_4_moncod1) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV79Bancos_cuentabancoswwds_4_moncod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Bancos_cuentabancoswwds_8_bandsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV83Bancos_cuentabancoswwds_8_bandsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Bancos_cuentabancoswwds_8_bandsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like '%' + @lV83Bancos_cuentabancoswwds_8_bandsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "MONCOD") == 0 ) && ( ! (0==AV84Bancos_cuentabancoswwds_9_moncod2) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV84Bancos_cuentabancoswwds_9_moncod2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Bancos_cuentabancoswwds_13_bandsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV88Bancos_cuentabancoswwds_13_bandsc3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Bancos_cuentabancoswwds_13_bandsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like '%' + @lV88Bancos_cuentabancoswwds_13_bandsc3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "MONCOD") == 0 ) && ( ! (0==AV89Bancos_cuentabancoswwds_14_moncod3) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV89Bancos_cuentabancoswwds_14_moncod3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Bancos_cuentabancoswwds_16_tfbandsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_cuentabancoswwds_15_tfbandsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV90Bancos_cuentabancoswwds_15_tfbandsc)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Bancos_cuentabancoswwds_16_tfbandsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] = @AV91Bancos_cuentabancoswwds_16_tfbandsc_sel)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Bancos_cuentabancoswwds_18_tfcbcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Bancos_cuentabancoswwds_17_tfcbcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBCod] like @lV92Bancos_cuentabancoswwds_17_tfcbcod)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Bancos_cuentabancoswwds_18_tfcbcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CBCod] = @AV93Bancos_cuentabancoswwds_18_tfcbcod_sel)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Bancos_cuentabancoswwds_20_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Bancos_cuentabancoswwds_19_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[MonDsc] like @lV94Bancos_cuentabancoswwds_19_tfmondsc)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Bancos_cuentabancoswwds_20_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[MonDsc] = @AV95Bancos_cuentabancoswwds_20_tfmondsc_sel)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (0==AV96Bancos_cuentabancoswwds_21_tfcbsts) )
         {
            AddWhere(sWhereString, "(T1.[CBSts] >= @AV96Bancos_cuentabancoswwds_21_tfcbsts)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( ! (0==AV97Bancos_cuentabancoswwds_22_tfcbsts_to) )
         {
            AddWhere(sWhereString, "(T1.[CBSts] <= @AV97Bancos_cuentabancoswwds_22_tfcbsts_to)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[BanCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P005C3( IGxContext context ,
                                             string AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ,
                                             short AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV78Bancos_cuentabancoswwds_3_bandsc1 ,
                                             int AV79Bancos_cuentabancoswwds_4_moncod1 ,
                                             bool AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ,
                                             string AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ,
                                             short AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ,
                                             string AV83Bancos_cuentabancoswwds_8_bandsc2 ,
                                             int AV84Bancos_cuentabancoswwds_9_moncod2 ,
                                             bool AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ,
                                             string AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ,
                                             short AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ,
                                             string AV88Bancos_cuentabancoswwds_13_bandsc3 ,
                                             int AV89Bancos_cuentabancoswwds_14_moncod3 ,
                                             string AV91Bancos_cuentabancoswwds_16_tfbandsc_sel ,
                                             string AV90Bancos_cuentabancoswwds_15_tfbandsc ,
                                             string AV93Bancos_cuentabancoswwds_18_tfcbcod_sel ,
                                             string AV92Bancos_cuentabancoswwds_17_tfcbcod ,
                                             string AV95Bancos_cuentabancoswwds_20_tfmondsc_sel ,
                                             string AV94Bancos_cuentabancoswwds_19_tfmondsc ,
                                             short AV96Bancos_cuentabancoswwds_21_tfcbsts ,
                                             short AV97Bancos_cuentabancoswwds_22_tfcbsts_to ,
                                             string A482BanDsc ,
                                             int A180MonCod ,
                                             string A377CBCod ,
                                             string A1234MonDsc ,
                                             short A504CBSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[17];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[BanCod], T1.[CBCod], T1.[CBSts], T3.[MonDsc], T1.[MonCod], T2.[BanDsc] FROM (([TSCUENTABANCO] T1 INNER JOIN [TSBANCOS] T2 ON T2.[BanCod] = T1.[BanCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[MonCod])";
         if ( ( StringUtil.StrCmp(AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_cuentabancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV78Bancos_cuentabancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_cuentabancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like '%' + @lV78Bancos_cuentabancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "MONCOD") == 0 ) && ( ! (0==AV79Bancos_cuentabancoswwds_4_moncod1) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV79Bancos_cuentabancoswwds_4_moncod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Bancos_cuentabancoswwds_8_bandsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV83Bancos_cuentabancoswwds_8_bandsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Bancos_cuentabancoswwds_8_bandsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like '%' + @lV83Bancos_cuentabancoswwds_8_bandsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "MONCOD") == 0 ) && ( ! (0==AV84Bancos_cuentabancoswwds_9_moncod2) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV84Bancos_cuentabancoswwds_9_moncod2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Bancos_cuentabancoswwds_13_bandsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV88Bancos_cuentabancoswwds_13_bandsc3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Bancos_cuentabancoswwds_13_bandsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like '%' + @lV88Bancos_cuentabancoswwds_13_bandsc3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "MONCOD") == 0 ) && ( ! (0==AV89Bancos_cuentabancoswwds_14_moncod3) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV89Bancos_cuentabancoswwds_14_moncod3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Bancos_cuentabancoswwds_16_tfbandsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_cuentabancoswwds_15_tfbandsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV90Bancos_cuentabancoswwds_15_tfbandsc)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Bancos_cuentabancoswwds_16_tfbandsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] = @AV91Bancos_cuentabancoswwds_16_tfbandsc_sel)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Bancos_cuentabancoswwds_18_tfcbcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Bancos_cuentabancoswwds_17_tfcbcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBCod] like @lV92Bancos_cuentabancoswwds_17_tfcbcod)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Bancos_cuentabancoswwds_18_tfcbcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CBCod] = @AV93Bancos_cuentabancoswwds_18_tfcbcod_sel)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Bancos_cuentabancoswwds_20_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Bancos_cuentabancoswwds_19_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[MonDsc] like @lV94Bancos_cuentabancoswwds_19_tfmondsc)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Bancos_cuentabancoswwds_20_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[MonDsc] = @AV95Bancos_cuentabancoswwds_20_tfmondsc_sel)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (0==AV96Bancos_cuentabancoswwds_21_tfcbsts) )
         {
            AddWhere(sWhereString, "(T1.[CBSts] >= @AV96Bancos_cuentabancoswwds_21_tfcbsts)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( ! (0==AV97Bancos_cuentabancoswwds_22_tfcbsts_to) )
         {
            AddWhere(sWhereString, "(T1.[CBSts] <= @AV97Bancos_cuentabancoswwds_22_tfcbsts_to)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CBCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P005C4( IGxContext context ,
                                             string AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1 ,
                                             short AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 ,
                                             string AV78Bancos_cuentabancoswwds_3_bandsc1 ,
                                             int AV79Bancos_cuentabancoswwds_4_moncod1 ,
                                             bool AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 ,
                                             string AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2 ,
                                             short AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 ,
                                             string AV83Bancos_cuentabancoswwds_8_bandsc2 ,
                                             int AV84Bancos_cuentabancoswwds_9_moncod2 ,
                                             bool AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 ,
                                             string AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3 ,
                                             short AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 ,
                                             string AV88Bancos_cuentabancoswwds_13_bandsc3 ,
                                             int AV89Bancos_cuentabancoswwds_14_moncod3 ,
                                             string AV91Bancos_cuentabancoswwds_16_tfbandsc_sel ,
                                             string AV90Bancos_cuentabancoswwds_15_tfbandsc ,
                                             string AV93Bancos_cuentabancoswwds_18_tfcbcod_sel ,
                                             string AV92Bancos_cuentabancoswwds_17_tfcbcod ,
                                             string AV95Bancos_cuentabancoswwds_20_tfmondsc_sel ,
                                             string AV94Bancos_cuentabancoswwds_19_tfmondsc ,
                                             short AV96Bancos_cuentabancoswwds_21_tfcbsts ,
                                             short AV97Bancos_cuentabancoswwds_22_tfcbsts_to ,
                                             string A482BanDsc ,
                                             int A180MonCod ,
                                             string A377CBCod ,
                                             string A1234MonDsc ,
                                             short A504CBSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[17];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[BanCod], T3.[MonDsc], T1.[CBSts], T1.[CBCod], T1.[MonCod], T2.[BanDsc] FROM (([TSCUENTABANCO] T1 INNER JOIN [TSBANCOS] T2 ON T2.[BanCod] = T1.[BanCod]) INNER JOIN [CMONEDAS] T3 ON T3.[MonCod] = T1.[MonCod])";
         if ( ( StringUtil.StrCmp(AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_cuentabancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV78Bancos_cuentabancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "BANDSC") == 0 ) && ( AV77Bancos_cuentabancoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Bancos_cuentabancoswwds_3_bandsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like '%' + @lV78Bancos_cuentabancoswwds_3_bandsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Bancos_cuentabancoswwds_1_dynamicfiltersselector1, "MONCOD") == 0 ) && ( ! (0==AV79Bancos_cuentabancoswwds_4_moncod1) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV79Bancos_cuentabancoswwds_4_moncod1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Bancos_cuentabancoswwds_8_bandsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV83Bancos_cuentabancoswwds_8_bandsc2)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "BANDSC") == 0 ) && ( AV82Bancos_cuentabancoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Bancos_cuentabancoswwds_8_bandsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like '%' + @lV83Bancos_cuentabancoswwds_8_bandsc2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV80Bancos_cuentabancoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV81Bancos_cuentabancoswwds_6_dynamicfiltersselector2, "MONCOD") == 0 ) && ( ! (0==AV84Bancos_cuentabancoswwds_9_moncod2) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV84Bancos_cuentabancoswwds_9_moncod2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Bancos_cuentabancoswwds_13_bandsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV88Bancos_cuentabancoswwds_13_bandsc3)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "BANDSC") == 0 ) && ( AV87Bancos_cuentabancoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Bancos_cuentabancoswwds_13_bandsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like '%' + @lV88Bancos_cuentabancoswwds_13_bandsc3)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV85Bancos_cuentabancoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Bancos_cuentabancoswwds_11_dynamicfiltersselector3, "MONCOD") == 0 ) && ( ! (0==AV89Bancos_cuentabancoswwds_14_moncod3) ) )
         {
            AddWhere(sWhereString, "(T1.[MonCod] = @AV89Bancos_cuentabancoswwds_14_moncod3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Bancos_cuentabancoswwds_16_tfbandsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Bancos_cuentabancoswwds_15_tfbandsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] like @lV90Bancos_cuentabancoswwds_15_tfbandsc)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Bancos_cuentabancoswwds_16_tfbandsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[BanDsc] = @AV91Bancos_cuentabancoswwds_16_tfbandsc_sel)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Bancos_cuentabancoswwds_18_tfcbcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Bancos_cuentabancoswwds_17_tfcbcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBCod] like @lV92Bancos_cuentabancoswwds_17_tfcbcod)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Bancos_cuentabancoswwds_18_tfcbcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CBCod] = @AV93Bancos_cuentabancoswwds_18_tfcbcod_sel)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Bancos_cuentabancoswwds_20_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Bancos_cuentabancoswwds_19_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[MonDsc] like @lV94Bancos_cuentabancoswwds_19_tfmondsc)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Bancos_cuentabancoswwds_20_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[MonDsc] = @AV95Bancos_cuentabancoswwds_20_tfmondsc_sel)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (0==AV96Bancos_cuentabancoswwds_21_tfcbsts) )
         {
            AddWhere(sWhereString, "(T1.[CBSts] >= @AV96Bancos_cuentabancoswwds_21_tfcbsts)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( ! (0==AV97Bancos_cuentabancoswwds_22_tfcbsts_to) )
         {
            AddWhere(sWhereString, "(T1.[CBSts] <= @AV97Bancos_cuentabancoswwds_22_tfcbsts_to)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[MonDsc]";
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
                     return conditional_P005C2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] );
               case 1 :
                     return conditional_P005C3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] );
               case 2 :
                     return conditional_P005C4(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (int)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] );
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
          Object[] prmP005C2;
          prmP005C2 = new Object[] {
          new ParDef("@lV78Bancos_cuentabancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV78Bancos_cuentabancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@AV79Bancos_cuentabancoswwds_4_moncod1",GXType.Int32,6,0) ,
          new ParDef("@lV83Bancos_cuentabancoswwds_8_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV83Bancos_cuentabancoswwds_8_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@AV84Bancos_cuentabancoswwds_9_moncod2",GXType.Int32,6,0) ,
          new ParDef("@lV88Bancos_cuentabancoswwds_13_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@lV88Bancos_cuentabancoswwds_13_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@AV89Bancos_cuentabancoswwds_14_moncod3",GXType.Int32,6,0) ,
          new ParDef("@lV90Bancos_cuentabancoswwds_15_tfbandsc",GXType.NChar,100,0) ,
          new ParDef("@AV91Bancos_cuentabancoswwds_16_tfbandsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV92Bancos_cuentabancoswwds_17_tfcbcod",GXType.NChar,20,0) ,
          new ParDef("@AV93Bancos_cuentabancoswwds_18_tfcbcod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV94Bancos_cuentabancoswwds_19_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV95Bancos_cuentabancoswwds_20_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV96Bancos_cuentabancoswwds_21_tfcbsts",GXType.Int16,1,0) ,
          new ParDef("@AV97Bancos_cuentabancoswwds_22_tfcbsts_to",GXType.Int16,1,0)
          };
          Object[] prmP005C3;
          prmP005C3 = new Object[] {
          new ParDef("@lV78Bancos_cuentabancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV78Bancos_cuentabancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@AV79Bancos_cuentabancoswwds_4_moncod1",GXType.Int32,6,0) ,
          new ParDef("@lV83Bancos_cuentabancoswwds_8_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV83Bancos_cuentabancoswwds_8_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@AV84Bancos_cuentabancoswwds_9_moncod2",GXType.Int32,6,0) ,
          new ParDef("@lV88Bancos_cuentabancoswwds_13_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@lV88Bancos_cuentabancoswwds_13_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@AV89Bancos_cuentabancoswwds_14_moncod3",GXType.Int32,6,0) ,
          new ParDef("@lV90Bancos_cuentabancoswwds_15_tfbandsc",GXType.NChar,100,0) ,
          new ParDef("@AV91Bancos_cuentabancoswwds_16_tfbandsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV92Bancos_cuentabancoswwds_17_tfcbcod",GXType.NChar,20,0) ,
          new ParDef("@AV93Bancos_cuentabancoswwds_18_tfcbcod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV94Bancos_cuentabancoswwds_19_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV95Bancos_cuentabancoswwds_20_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV96Bancos_cuentabancoswwds_21_tfcbsts",GXType.Int16,1,0) ,
          new ParDef("@AV97Bancos_cuentabancoswwds_22_tfcbsts_to",GXType.Int16,1,0)
          };
          Object[] prmP005C4;
          prmP005C4 = new Object[] {
          new ParDef("@lV78Bancos_cuentabancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@lV78Bancos_cuentabancoswwds_3_bandsc1",GXType.NChar,100,0) ,
          new ParDef("@AV79Bancos_cuentabancoswwds_4_moncod1",GXType.Int32,6,0) ,
          new ParDef("@lV83Bancos_cuentabancoswwds_8_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@lV83Bancos_cuentabancoswwds_8_bandsc2",GXType.NChar,100,0) ,
          new ParDef("@AV84Bancos_cuentabancoswwds_9_moncod2",GXType.Int32,6,0) ,
          new ParDef("@lV88Bancos_cuentabancoswwds_13_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@lV88Bancos_cuentabancoswwds_13_bandsc3",GXType.NChar,100,0) ,
          new ParDef("@AV89Bancos_cuentabancoswwds_14_moncod3",GXType.Int32,6,0) ,
          new ParDef("@lV90Bancos_cuentabancoswwds_15_tfbandsc",GXType.NChar,100,0) ,
          new ParDef("@AV91Bancos_cuentabancoswwds_16_tfbandsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV92Bancos_cuentabancoswwds_17_tfcbcod",GXType.NChar,20,0) ,
          new ParDef("@AV93Bancos_cuentabancoswwds_18_tfcbcod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV94Bancos_cuentabancoswwds_19_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV95Bancos_cuentabancoswwds_20_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV96Bancos_cuentabancoswwds_21_tfcbsts",GXType.Int16,1,0) ,
          new ParDef("@AV97Bancos_cuentabancoswwds_22_tfcbsts_to",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005C2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005C3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005C3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005C4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005C4,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                return;
       }
    }

 }

}
