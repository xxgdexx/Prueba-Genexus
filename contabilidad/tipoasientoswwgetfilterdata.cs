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
   public class tipoasientoswwgetfilterdata : GXProcedure
   {
      public tipoasientoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipoasientoswwgetfilterdata( IGxContext context )
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
         tipoasientoswwgetfilterdata objtipoasientoswwgetfilterdata;
         objtipoasientoswwgetfilterdata = new tipoasientoswwgetfilterdata();
         objtipoasientoswwgetfilterdata.AV20DDOName = aP0_DDOName;
         objtipoasientoswwgetfilterdata.AV18SearchTxt = aP1_SearchTxt;
         objtipoasientoswwgetfilterdata.AV19SearchTxtTo = aP2_SearchTxtTo;
         objtipoasientoswwgetfilterdata.AV24OptionsJson = "" ;
         objtipoasientoswwgetfilterdata.AV27OptionsDescJson = "" ;
         objtipoasientoswwgetfilterdata.AV29OptionIndexesJson = "" ;
         objtipoasientoswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objtipoasientoswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipoasientoswwgetfilterdata);
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipoasientoswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_TASIDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADTASIDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_TASIABR") == 0 )
         {
            /* Execute user subroutine: 'LOADTASIABROPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV31Session.Get("Contabilidad.TipoAsientosWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.TipoAsientosWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Contabilidad.TipoAsientosWWGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTASICOD") == 0 )
            {
               AV10TFTASICod = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV11TFTASICod_To = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTASIDSC") == 0 )
            {
               AV12TFTASIDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTASIDSC_SEL") == 0 )
            {
               AV13TFTASIDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTASIABR") == 0 )
            {
               AV14TFTASIAbr = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTASIABR_SEL") == 0 )
            {
               AV15TFTASIAbr_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTASISTS_SEL") == 0 )
            {
               AV16TFTASISts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV17TFTASISts_Sels.FromJSonString(AV16TFTASISts_SelsJson, null);
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "TASIDSC") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV38TASIDsc1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "TASIDSC") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV42TASIDsc2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "TASIDSC") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV46TASIDsc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTASIDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFTASIDsc = AV18SearchTxt;
         AV13TFTASIDsc_Sel = "";
         AV51Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV52Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV53Contabilidad_tipoasientoswwds_3_tasidsc1 = AV38TASIDsc1;
         AV54Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV55Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV56Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV57Contabilidad_tipoasientoswwds_7_tasidsc2 = AV42TASIDsc2;
         AV58Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV59Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV60Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV61Contabilidad_tipoasientoswwds_11_tasidsc3 = AV46TASIDsc3;
         AV62Contabilidad_tipoasientoswwds_12_tftasicod = AV10TFTASICod;
         AV63Contabilidad_tipoasientoswwds_13_tftasicod_to = AV11TFTASICod_To;
         AV64Contabilidad_tipoasientoswwds_14_tftasidsc = AV12TFTASIDsc;
         AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel = AV13TFTASIDsc_Sel;
         AV66Contabilidad_tipoasientoswwds_16_tftasiabr = AV14TFTASIAbr;
         AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel = AV15TFTASIAbr_Sel;
         AV68Contabilidad_tipoasientoswwds_18_tftasists_sels = AV17TFTASISts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1896TASISts ,
                                              AV68Contabilidad_tipoasientoswwds_18_tftasists_sels ,
                                              AV51Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1 ,
                                              AV52Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 ,
                                              AV53Contabilidad_tipoasientoswwds_3_tasidsc1 ,
                                              AV54Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 ,
                                              AV55Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2 ,
                                              AV56Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 ,
                                              AV57Contabilidad_tipoasientoswwds_7_tasidsc2 ,
                                              AV58Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 ,
                                              AV59Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3 ,
                                              AV60Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 ,
                                              AV61Contabilidad_tipoasientoswwds_11_tasidsc3 ,
                                              AV62Contabilidad_tipoasientoswwds_12_tftasicod ,
                                              AV63Contabilidad_tipoasientoswwds_13_tftasicod_to ,
                                              AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel ,
                                              AV64Contabilidad_tipoasientoswwds_14_tftasidsc ,
                                              AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel ,
                                              AV66Contabilidad_tipoasientoswwds_16_tftasiabr ,
                                              AV68Contabilidad_tipoasientoswwds_18_tftasists_sels.Count ,
                                              A1895TASIDsc ,
                                              A126TASICod ,
                                              A1894TASIAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV53Contabilidad_tipoasientoswwds_3_tasidsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Contabilidad_tipoasientoswwds_3_tasidsc1), 100, "%");
         lV53Contabilidad_tipoasientoswwds_3_tasidsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Contabilidad_tipoasientoswwds_3_tasidsc1), 100, "%");
         lV57Contabilidad_tipoasientoswwds_7_tasidsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Contabilidad_tipoasientoswwds_7_tasidsc2), 100, "%");
         lV57Contabilidad_tipoasientoswwds_7_tasidsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Contabilidad_tipoasientoswwds_7_tasidsc2), 100, "%");
         lV61Contabilidad_tipoasientoswwds_11_tasidsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Contabilidad_tipoasientoswwds_11_tasidsc3), 100, "%");
         lV61Contabilidad_tipoasientoswwds_11_tasidsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Contabilidad_tipoasientoswwds_11_tasidsc3), 100, "%");
         lV64Contabilidad_tipoasientoswwds_14_tftasidsc = StringUtil.PadR( StringUtil.RTrim( AV64Contabilidad_tipoasientoswwds_14_tftasidsc), 100, "%");
         lV66Contabilidad_tipoasientoswwds_16_tftasiabr = StringUtil.PadR( StringUtil.RTrim( AV66Contabilidad_tipoasientoswwds_16_tftasiabr), 5, "%");
         /* Using cursor P00792 */
         pr_default.execute(0, new Object[] {lV53Contabilidad_tipoasientoswwds_3_tasidsc1, lV53Contabilidad_tipoasientoswwds_3_tasidsc1, lV57Contabilidad_tipoasientoswwds_7_tasidsc2, lV57Contabilidad_tipoasientoswwds_7_tasidsc2, lV61Contabilidad_tipoasientoswwds_11_tasidsc3, lV61Contabilidad_tipoasientoswwds_11_tasidsc3, AV62Contabilidad_tipoasientoswwds_12_tftasicod, AV63Contabilidad_tipoasientoswwds_13_tftasicod_to, lV64Contabilidad_tipoasientoswwds_14_tftasidsc, AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel, lV66Contabilidad_tipoasientoswwds_16_tftasiabr, AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK792 = false;
            A1895TASIDsc = P00792_A1895TASIDsc[0];
            A1896TASISts = P00792_A1896TASISts[0];
            A1894TASIAbr = P00792_A1894TASIAbr[0];
            A126TASICod = P00792_A126TASICod[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00792_A1895TASIDsc[0], A1895TASIDsc) == 0 ) )
            {
               BRK792 = false;
               A126TASICod = P00792_A126TASICod[0];
               AV30count = (long)(AV30count+1);
               BRK792 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1895TASIDsc)) )
            {
               AV22Option = A1895TASIDsc;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK792 )
            {
               BRK792 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTASIABROPTIONS' Routine */
         returnInSub = false;
         AV14TFTASIAbr = AV18SearchTxt;
         AV15TFTASIAbr_Sel = "";
         AV51Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV52Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV53Contabilidad_tipoasientoswwds_3_tasidsc1 = AV38TASIDsc1;
         AV54Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV55Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV56Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV57Contabilidad_tipoasientoswwds_7_tasidsc2 = AV42TASIDsc2;
         AV58Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV59Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV60Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV61Contabilidad_tipoasientoswwds_11_tasidsc3 = AV46TASIDsc3;
         AV62Contabilidad_tipoasientoswwds_12_tftasicod = AV10TFTASICod;
         AV63Contabilidad_tipoasientoswwds_13_tftasicod_to = AV11TFTASICod_To;
         AV64Contabilidad_tipoasientoswwds_14_tftasidsc = AV12TFTASIDsc;
         AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel = AV13TFTASIDsc_Sel;
         AV66Contabilidad_tipoasientoswwds_16_tftasiabr = AV14TFTASIAbr;
         AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel = AV15TFTASIAbr_Sel;
         AV68Contabilidad_tipoasientoswwds_18_tftasists_sels = AV17TFTASISts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1896TASISts ,
                                              AV68Contabilidad_tipoasientoswwds_18_tftasists_sels ,
                                              AV51Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1 ,
                                              AV52Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 ,
                                              AV53Contabilidad_tipoasientoswwds_3_tasidsc1 ,
                                              AV54Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 ,
                                              AV55Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2 ,
                                              AV56Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 ,
                                              AV57Contabilidad_tipoasientoswwds_7_tasidsc2 ,
                                              AV58Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 ,
                                              AV59Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3 ,
                                              AV60Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 ,
                                              AV61Contabilidad_tipoasientoswwds_11_tasidsc3 ,
                                              AV62Contabilidad_tipoasientoswwds_12_tftasicod ,
                                              AV63Contabilidad_tipoasientoswwds_13_tftasicod_to ,
                                              AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel ,
                                              AV64Contabilidad_tipoasientoswwds_14_tftasidsc ,
                                              AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel ,
                                              AV66Contabilidad_tipoasientoswwds_16_tftasiabr ,
                                              AV68Contabilidad_tipoasientoswwds_18_tftasists_sels.Count ,
                                              A1895TASIDsc ,
                                              A126TASICod ,
                                              A1894TASIAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV53Contabilidad_tipoasientoswwds_3_tasidsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Contabilidad_tipoasientoswwds_3_tasidsc1), 100, "%");
         lV53Contabilidad_tipoasientoswwds_3_tasidsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Contabilidad_tipoasientoswwds_3_tasidsc1), 100, "%");
         lV57Contabilidad_tipoasientoswwds_7_tasidsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Contabilidad_tipoasientoswwds_7_tasidsc2), 100, "%");
         lV57Contabilidad_tipoasientoswwds_7_tasidsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Contabilidad_tipoasientoswwds_7_tasidsc2), 100, "%");
         lV61Contabilidad_tipoasientoswwds_11_tasidsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Contabilidad_tipoasientoswwds_11_tasidsc3), 100, "%");
         lV61Contabilidad_tipoasientoswwds_11_tasidsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Contabilidad_tipoasientoswwds_11_tasidsc3), 100, "%");
         lV64Contabilidad_tipoasientoswwds_14_tftasidsc = StringUtil.PadR( StringUtil.RTrim( AV64Contabilidad_tipoasientoswwds_14_tftasidsc), 100, "%");
         lV66Contabilidad_tipoasientoswwds_16_tftasiabr = StringUtil.PadR( StringUtil.RTrim( AV66Contabilidad_tipoasientoswwds_16_tftasiabr), 5, "%");
         /* Using cursor P00793 */
         pr_default.execute(1, new Object[] {lV53Contabilidad_tipoasientoswwds_3_tasidsc1, lV53Contabilidad_tipoasientoswwds_3_tasidsc1, lV57Contabilidad_tipoasientoswwds_7_tasidsc2, lV57Contabilidad_tipoasientoswwds_7_tasidsc2, lV61Contabilidad_tipoasientoswwds_11_tasidsc3, lV61Contabilidad_tipoasientoswwds_11_tasidsc3, AV62Contabilidad_tipoasientoswwds_12_tftasicod, AV63Contabilidad_tipoasientoswwds_13_tftasicod_to, lV64Contabilidad_tipoasientoswwds_14_tftasidsc, AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel, lV66Contabilidad_tipoasientoswwds_16_tftasiabr, AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK794 = false;
            A1894TASIAbr = P00793_A1894TASIAbr[0];
            A1896TASISts = P00793_A1896TASISts[0];
            A126TASICod = P00793_A126TASICod[0];
            A1895TASIDsc = P00793_A1895TASIDsc[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00793_A1894TASIAbr[0], A1894TASIAbr) == 0 ) )
            {
               BRK794 = false;
               A126TASICod = P00793_A126TASICod[0];
               AV30count = (long)(AV30count+1);
               BRK794 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1894TASIAbr)) )
            {
               AV22Option = A1894TASIAbr;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK794 )
            {
               BRK794 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV12TFTASIDsc = "";
         AV13TFTASIDsc_Sel = "";
         AV14TFTASIAbr = "";
         AV15TFTASIAbr_Sel = "";
         AV16TFTASISts_SelsJson = "";
         AV17TFTASISts_Sels = new GxSimpleCollection<short>();
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38TASIDsc1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42TASIDsc2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46TASIDsc3 = "";
         AV51Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1 = "";
         AV53Contabilidad_tipoasientoswwds_3_tasidsc1 = "";
         AV55Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2 = "";
         AV57Contabilidad_tipoasientoswwds_7_tasidsc2 = "";
         AV59Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3 = "";
         AV61Contabilidad_tipoasientoswwds_11_tasidsc3 = "";
         AV64Contabilidad_tipoasientoswwds_14_tftasidsc = "";
         AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel = "";
         AV66Contabilidad_tipoasientoswwds_16_tftasiabr = "";
         AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel = "";
         AV68Contabilidad_tipoasientoswwds_18_tftasists_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV53Contabilidad_tipoasientoswwds_3_tasidsc1 = "";
         lV57Contabilidad_tipoasientoswwds_7_tasidsc2 = "";
         lV61Contabilidad_tipoasientoswwds_11_tasidsc3 = "";
         lV64Contabilidad_tipoasientoswwds_14_tftasidsc = "";
         lV66Contabilidad_tipoasientoswwds_16_tftasiabr = "";
         A1895TASIDsc = "";
         A1894TASIAbr = "";
         P00792_A1895TASIDsc = new string[] {""} ;
         P00792_A1896TASISts = new short[1] ;
         P00792_A1894TASIAbr = new string[] {""} ;
         P00792_A126TASICod = new int[1] ;
         AV22Option = "";
         P00793_A1894TASIAbr = new string[] {""} ;
         P00793_A1896TASISts = new short[1] ;
         P00793_A126TASICod = new int[1] ;
         P00793_A1895TASIDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.tipoasientoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00792_A1895TASIDsc, P00792_A1896TASISts, P00792_A1894TASIAbr, P00792_A126TASICod
               }
               , new Object[] {
               P00793_A1894TASIAbr, P00793_A1896TASISts, P00793_A126TASICod, P00793_A1895TASIDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV52Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 ;
      private short AV56Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 ;
      private short AV60Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 ;
      private short A1896TASISts ;
      private int AV49GXV1 ;
      private int AV10TFTASICod ;
      private int AV11TFTASICod_To ;
      private int AV62Contabilidad_tipoasientoswwds_12_tftasicod ;
      private int AV63Contabilidad_tipoasientoswwds_13_tftasicod_to ;
      private int AV68Contabilidad_tipoasientoswwds_18_tftasists_sels_Count ;
      private int A126TASICod ;
      private long AV30count ;
      private string AV12TFTASIDsc ;
      private string AV13TFTASIDsc_Sel ;
      private string AV14TFTASIAbr ;
      private string AV15TFTASIAbr_Sel ;
      private string AV38TASIDsc1 ;
      private string AV42TASIDsc2 ;
      private string AV46TASIDsc3 ;
      private string AV53Contabilidad_tipoasientoswwds_3_tasidsc1 ;
      private string AV57Contabilidad_tipoasientoswwds_7_tasidsc2 ;
      private string AV61Contabilidad_tipoasientoswwds_11_tasidsc3 ;
      private string AV64Contabilidad_tipoasientoswwds_14_tftasidsc ;
      private string AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel ;
      private string AV66Contabilidad_tipoasientoswwds_16_tftasiabr ;
      private string AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel ;
      private string scmdbuf ;
      private string lV53Contabilidad_tipoasientoswwds_3_tasidsc1 ;
      private string lV57Contabilidad_tipoasientoswwds_7_tasidsc2 ;
      private string lV61Contabilidad_tipoasientoswwds_11_tasidsc3 ;
      private string lV64Contabilidad_tipoasientoswwds_14_tftasidsc ;
      private string lV66Contabilidad_tipoasientoswwds_16_tftasiabr ;
      private string A1895TASIDsc ;
      private string A1894TASIAbr ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV54Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 ;
      private bool AV58Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 ;
      private bool BRK792 ;
      private bool BRK794 ;
      private string AV24OptionsJson ;
      private string AV27OptionsDescJson ;
      private string AV29OptionIndexesJson ;
      private string AV16TFTASISts_SelsJson ;
      private string AV20DDOName ;
      private string AV18SearchTxt ;
      private string AV19SearchTxtTo ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV51Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1 ;
      private string AV55Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2 ;
      private string AV59Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3 ;
      private string AV22Option ;
      private GxSimpleCollection<short> AV17TFTASISts_Sels ;
      private GxSimpleCollection<short> AV68Contabilidad_tipoasientoswwds_18_tftasists_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00792_A1895TASIDsc ;
      private short[] P00792_A1896TASISts ;
      private string[] P00792_A1894TASIAbr ;
      private int[] P00792_A126TASICod ;
      private string[] P00793_A1894TASIAbr ;
      private short[] P00793_A1896TASISts ;
      private int[] P00793_A126TASICod ;
      private string[] P00793_A1895TASIDsc ;
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

   public class tipoasientoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00792( IGxContext context ,
                                             short A1896TASISts ,
                                             GxSimpleCollection<short> AV68Contabilidad_tipoasientoswwds_18_tftasists_sels ,
                                             string AV51Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1 ,
                                             short AV52Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 ,
                                             string AV53Contabilidad_tipoasientoswwds_3_tasidsc1 ,
                                             bool AV54Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 ,
                                             string AV55Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2 ,
                                             short AV56Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 ,
                                             string AV57Contabilidad_tipoasientoswwds_7_tasidsc2 ,
                                             bool AV58Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 ,
                                             string AV59Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3 ,
                                             short AV60Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 ,
                                             string AV61Contabilidad_tipoasientoswwds_11_tasidsc3 ,
                                             int AV62Contabilidad_tipoasientoswwds_12_tftasicod ,
                                             int AV63Contabilidad_tipoasientoswwds_13_tftasicod_to ,
                                             string AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel ,
                                             string AV64Contabilidad_tipoasientoswwds_14_tftasidsc ,
                                             string AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel ,
                                             string AV66Contabilidad_tipoasientoswwds_16_tftasiabr ,
                                             int AV68Contabilidad_tipoasientoswwds_18_tftasists_sels_Count ,
                                             string A1895TASIDsc ,
                                             int A126TASICod ,
                                             string A1894TASIAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TASIDsc], [TASISts], [TASIAbr], [TASICod] FROM [CBTIPOASIENTO]";
         if ( ( StringUtil.StrCmp(AV51Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1, "TASIDSC") == 0 ) && ( AV52Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Contabilidad_tipoasientoswwds_3_tasidsc1)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like @lV53Contabilidad_tipoasientoswwds_3_tasidsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1, "TASIDSC") == 0 ) && ( AV52Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Contabilidad_tipoasientoswwds_3_tasidsc1)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like '%' + @lV53Contabilidad_tipoasientoswwds_3_tasidsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV54Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2, "TASIDSC") == 0 ) && ( AV56Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Contabilidad_tipoasientoswwds_7_tasidsc2)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like @lV57Contabilidad_tipoasientoswwds_7_tasidsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV54Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2, "TASIDSC") == 0 ) && ( AV56Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Contabilidad_tipoasientoswwds_7_tasidsc2)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like '%' + @lV57Contabilidad_tipoasientoswwds_7_tasidsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV58Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3, "TASIDSC") == 0 ) && ( AV60Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Contabilidad_tipoasientoswwds_11_tasidsc3)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like @lV61Contabilidad_tipoasientoswwds_11_tasidsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV58Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3, "TASIDSC") == 0 ) && ( AV60Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Contabilidad_tipoasientoswwds_11_tasidsc3)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like '%' + @lV61Contabilidad_tipoasientoswwds_11_tasidsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV62Contabilidad_tipoasientoswwds_12_tftasicod) )
         {
            AddWhere(sWhereString, "([TASICod] >= @AV62Contabilidad_tipoasientoswwds_12_tftasicod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV63Contabilidad_tipoasientoswwds_13_tftasicod_to) )
         {
            AddWhere(sWhereString, "([TASICod] <= @AV63Contabilidad_tipoasientoswwds_13_tftasicod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_tipoasientoswwds_14_tftasidsc)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like @lV64Contabilidad_tipoasientoswwds_14_tftasidsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel)) )
         {
            AddWhere(sWhereString, "([TASIDsc] = @AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_tipoasientoswwds_16_tftasiabr)) ) )
         {
            AddWhere(sWhereString, "([TASIAbr] like @lV66Contabilidad_tipoasientoswwds_16_tftasiabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel)) )
         {
            AddWhere(sWhereString, "([TASIAbr] = @AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV68Contabilidad_tipoasientoswwds_18_tftasists_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Contabilidad_tipoasientoswwds_18_tftasists_sels, "[TASISts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TASIDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00793( IGxContext context ,
                                             short A1896TASISts ,
                                             GxSimpleCollection<short> AV68Contabilidad_tipoasientoswwds_18_tftasists_sels ,
                                             string AV51Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1 ,
                                             short AV52Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 ,
                                             string AV53Contabilidad_tipoasientoswwds_3_tasidsc1 ,
                                             bool AV54Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 ,
                                             string AV55Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2 ,
                                             short AV56Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 ,
                                             string AV57Contabilidad_tipoasientoswwds_7_tasidsc2 ,
                                             bool AV58Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 ,
                                             string AV59Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3 ,
                                             short AV60Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 ,
                                             string AV61Contabilidad_tipoasientoswwds_11_tasidsc3 ,
                                             int AV62Contabilidad_tipoasientoswwds_12_tftasicod ,
                                             int AV63Contabilidad_tipoasientoswwds_13_tftasicod_to ,
                                             string AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel ,
                                             string AV64Contabilidad_tipoasientoswwds_14_tftasidsc ,
                                             string AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel ,
                                             string AV66Contabilidad_tipoasientoswwds_16_tftasiabr ,
                                             int AV68Contabilidad_tipoasientoswwds_18_tftasists_sels_Count ,
                                             string A1895TASIDsc ,
                                             int A126TASICod ,
                                             string A1894TASIAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TASIAbr], [TASISts], [TASICod], [TASIDsc] FROM [CBTIPOASIENTO]";
         if ( ( StringUtil.StrCmp(AV51Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1, "TASIDSC") == 0 ) && ( AV52Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Contabilidad_tipoasientoswwds_3_tasidsc1)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like @lV53Contabilidad_tipoasientoswwds_3_tasidsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Contabilidad_tipoasientoswwds_1_dynamicfiltersselector1, "TASIDSC") == 0 ) && ( AV52Contabilidad_tipoasientoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Contabilidad_tipoasientoswwds_3_tasidsc1)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like '%' + @lV53Contabilidad_tipoasientoswwds_3_tasidsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV54Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2, "TASIDSC") == 0 ) && ( AV56Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Contabilidad_tipoasientoswwds_7_tasidsc2)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like @lV57Contabilidad_tipoasientoswwds_7_tasidsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV54Contabilidad_tipoasientoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Contabilidad_tipoasientoswwds_5_dynamicfiltersselector2, "TASIDSC") == 0 ) && ( AV56Contabilidad_tipoasientoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Contabilidad_tipoasientoswwds_7_tasidsc2)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like '%' + @lV57Contabilidad_tipoasientoswwds_7_tasidsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV58Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3, "TASIDSC") == 0 ) && ( AV60Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Contabilidad_tipoasientoswwds_11_tasidsc3)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like @lV61Contabilidad_tipoasientoswwds_11_tasidsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV58Contabilidad_tipoasientoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Contabilidad_tipoasientoswwds_9_dynamicfiltersselector3, "TASIDSC") == 0 ) && ( AV60Contabilidad_tipoasientoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Contabilidad_tipoasientoswwds_11_tasidsc3)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like '%' + @lV61Contabilidad_tipoasientoswwds_11_tasidsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV62Contabilidad_tipoasientoswwds_12_tftasicod) )
         {
            AddWhere(sWhereString, "([TASICod] >= @AV62Contabilidad_tipoasientoswwds_12_tftasicod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV63Contabilidad_tipoasientoswwds_13_tftasicod_to) )
         {
            AddWhere(sWhereString, "([TASICod] <= @AV63Contabilidad_tipoasientoswwds_13_tftasicod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_tipoasientoswwds_14_tftasidsc)) ) )
         {
            AddWhere(sWhereString, "([TASIDsc] like @lV64Contabilidad_tipoasientoswwds_14_tftasidsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel)) )
         {
            AddWhere(sWhereString, "([TASIDsc] = @AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_tipoasientoswwds_16_tftasiabr)) ) )
         {
            AddWhere(sWhereString, "([TASIAbr] like @lV66Contabilidad_tipoasientoswwds_16_tftasiabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel)) )
         {
            AddWhere(sWhereString, "([TASIAbr] = @AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV68Contabilidad_tipoasientoswwds_18_tftasists_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Contabilidad_tipoasientoswwds_18_tftasists_sels, "[TASISts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TASIAbr]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00792(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] );
               case 1 :
                     return conditional_P00793(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00792;
          prmP00792 = new Object[] {
          new ParDef("@lV53Contabilidad_tipoasientoswwds_3_tasidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Contabilidad_tipoasientoswwds_3_tasidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Contabilidad_tipoasientoswwds_7_tasidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Contabilidad_tipoasientoswwds_7_tasidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Contabilidad_tipoasientoswwds_11_tasidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Contabilidad_tipoasientoswwds_11_tasidsc3",GXType.NChar,100,0) ,
          new ParDef("@AV62Contabilidad_tipoasientoswwds_12_tftasicod",GXType.Int32,6,0) ,
          new ParDef("@AV63Contabilidad_tipoasientoswwds_13_tftasicod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Contabilidad_tipoasientoswwds_14_tftasidsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV66Contabilidad_tipoasientoswwds_16_tftasiabr",GXType.NChar,5,0) ,
          new ParDef("@AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel",GXType.NChar,5,0)
          };
          Object[] prmP00793;
          prmP00793 = new Object[] {
          new ParDef("@lV53Contabilidad_tipoasientoswwds_3_tasidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Contabilidad_tipoasientoswwds_3_tasidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Contabilidad_tipoasientoswwds_7_tasidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Contabilidad_tipoasientoswwds_7_tasidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Contabilidad_tipoasientoswwds_11_tasidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Contabilidad_tipoasientoswwds_11_tasidsc3",GXType.NChar,100,0) ,
          new ParDef("@AV62Contabilidad_tipoasientoswwds_12_tftasicod",GXType.Int32,6,0) ,
          new ParDef("@AV63Contabilidad_tipoasientoswwds_13_tftasicod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Contabilidad_tipoasientoswwds_14_tftasidsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Contabilidad_tipoasientoswwds_15_tftasidsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV66Contabilidad_tipoasientoswwds_16_tftasiabr",GXType.NChar,5,0) ,
          new ParDef("@AV67Contabilidad_tipoasientoswwds_17_tftasiabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00792", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00792,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00793", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00793,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
       }
    }

 }

}
