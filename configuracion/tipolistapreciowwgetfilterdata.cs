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
   public class tipolistapreciowwgetfilterdata : GXProcedure
   {
      public tipolistapreciowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipolistapreciowwgetfilterdata( IGxContext context )
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
         tipolistapreciowwgetfilterdata objtipolistapreciowwgetfilterdata;
         objtipolistapreciowwgetfilterdata = new tipolistapreciowwgetfilterdata();
         objtipolistapreciowwgetfilterdata.AV20DDOName = aP0_DDOName;
         objtipolistapreciowwgetfilterdata.AV18SearchTxt = aP1_SearchTxt;
         objtipolistapreciowwgetfilterdata.AV19SearchTxtTo = aP2_SearchTxtTo;
         objtipolistapreciowwgetfilterdata.AV24OptionsJson = "" ;
         objtipolistapreciowwgetfilterdata.AV27OptionsDescJson = "" ;
         objtipolistapreciowwgetfilterdata.AV29OptionIndexesJson = "" ;
         objtipolistapreciowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objtipolistapreciowwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipolistapreciowwgetfilterdata);
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipolistapreciowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_TIPLDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPLDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_TIPLABR") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPLABROPTIONS' */
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
         if ( StringUtil.StrCmp(AV31Session.Get("Configuracion.TipoListaPrecioWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoListaPrecioWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Configuracion.TipoListaPrecioWWGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPLCOD") == 0 )
            {
               AV10TFTipLCod = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV11TFTipLCod_To = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPLDSC") == 0 )
            {
               AV12TFTipLDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPLDSC_SEL") == 0 )
            {
               AV13TFTipLDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPLABR") == 0 )
            {
               AV14TFTipLAbr = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPLABR_SEL") == 0 )
            {
               AV15TFTipLAbr_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPLSTS_SEL") == 0 )
            {
               AV16TFTipLSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV17TFTipLSts_Sels.FromJSonString(AV16TFTipLSts_SelsJson, null);
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "TIPLDSC") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV38TipLDsc1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "TIPLDSC") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV42TipLDsc2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "TIPLDSC") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV46TipLDsc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTIPLDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFTipLDsc = AV18SearchTxt;
         AV13TFTipLDsc_Sel = "";
         AV51Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV52Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV53Configuracion_tipolistapreciowwds_3_tipldsc1 = AV38TipLDsc1;
         AV54Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV55Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV56Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV57Configuracion_tipolistapreciowwds_7_tipldsc2 = AV42TipLDsc2;
         AV58Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV59Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV60Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV61Configuracion_tipolistapreciowwds_11_tipldsc3 = AV46TipLDsc3;
         AV62Configuracion_tipolistapreciowwds_12_tftiplcod = AV10TFTipLCod;
         AV63Configuracion_tipolistapreciowwds_13_tftiplcod_to = AV11TFTipLCod_To;
         AV64Configuracion_tipolistapreciowwds_14_tftipldsc = AV12TFTipLDsc;
         AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel = AV13TFTipLDsc_Sel;
         AV66Configuracion_tipolistapreciowwds_16_tftiplabr = AV14TFTipLAbr;
         AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel = AV15TFTipLAbr_Sel;
         AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels = AV17TFTipLSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1914TipLSts ,
                                              AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels ,
                                              AV51Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1 ,
                                              AV52Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 ,
                                              AV53Configuracion_tipolistapreciowwds_3_tipldsc1 ,
                                              AV54Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 ,
                                              AV55Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2 ,
                                              AV56Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 ,
                                              AV57Configuracion_tipolistapreciowwds_7_tipldsc2 ,
                                              AV58Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 ,
                                              AV59Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3 ,
                                              AV60Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 ,
                                              AV61Configuracion_tipolistapreciowwds_11_tipldsc3 ,
                                              AV62Configuracion_tipolistapreciowwds_12_tftiplcod ,
                                              AV63Configuracion_tipolistapreciowwds_13_tftiplcod_to ,
                                              AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel ,
                                              AV64Configuracion_tipolistapreciowwds_14_tftipldsc ,
                                              AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel ,
                                              AV66Configuracion_tipolistapreciowwds_16_tftiplabr ,
                                              AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels.Count ,
                                              A1912TipLDsc ,
                                              A202TipLCod ,
                                              A1911TipLAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV53Configuracion_tipolistapreciowwds_3_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_tipolistapreciowwds_3_tipldsc1), 100, "%");
         lV53Configuracion_tipolistapreciowwds_3_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_tipolistapreciowwds_3_tipldsc1), 100, "%");
         lV57Configuracion_tipolistapreciowwds_7_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipolistapreciowwds_7_tipldsc2), 100, "%");
         lV57Configuracion_tipolistapreciowwds_7_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipolistapreciowwds_7_tipldsc2), 100, "%");
         lV61Configuracion_tipolistapreciowwds_11_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipolistapreciowwds_11_tipldsc3), 100, "%");
         lV61Configuracion_tipolistapreciowwds_11_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipolistapreciowwds_11_tipldsc3), 100, "%");
         lV64Configuracion_tipolistapreciowwds_14_tftipldsc = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_tipolistapreciowwds_14_tftipldsc), 100, "%");
         lV66Configuracion_tipolistapreciowwds_16_tftiplabr = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_tipolistapreciowwds_16_tftiplabr), 5, "%");
         /* Using cursor P004F2 */
         pr_default.execute(0, new Object[] {lV53Configuracion_tipolistapreciowwds_3_tipldsc1, lV53Configuracion_tipolistapreciowwds_3_tipldsc1, lV57Configuracion_tipolistapreciowwds_7_tipldsc2, lV57Configuracion_tipolistapreciowwds_7_tipldsc2, lV61Configuracion_tipolistapreciowwds_11_tipldsc3, lV61Configuracion_tipolistapreciowwds_11_tipldsc3, AV62Configuracion_tipolistapreciowwds_12_tftiplcod, AV63Configuracion_tipolistapreciowwds_13_tftiplcod_to, lV64Configuracion_tipolistapreciowwds_14_tftipldsc, AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel, lV66Configuracion_tipolistapreciowwds_16_tftiplabr, AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4F2 = false;
            A1912TipLDsc = P004F2_A1912TipLDsc[0];
            A1914TipLSts = P004F2_A1914TipLSts[0];
            A1911TipLAbr = P004F2_A1911TipLAbr[0];
            A202TipLCod = P004F2_A202TipLCod[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P004F2_A1912TipLDsc[0], A1912TipLDsc) == 0 ) )
            {
               BRK4F2 = false;
               A202TipLCod = P004F2_A202TipLCod[0];
               AV30count = (long)(AV30count+1);
               BRK4F2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1912TipLDsc)) )
            {
               AV22Option = A1912TipLDsc;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK4F2 )
            {
               BRK4F2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTIPLABROPTIONS' Routine */
         returnInSub = false;
         AV14TFTipLAbr = AV18SearchTxt;
         AV15TFTipLAbr_Sel = "";
         AV51Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV52Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV53Configuracion_tipolistapreciowwds_3_tipldsc1 = AV38TipLDsc1;
         AV54Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV55Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV56Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV57Configuracion_tipolistapreciowwds_7_tipldsc2 = AV42TipLDsc2;
         AV58Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV59Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV60Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV61Configuracion_tipolistapreciowwds_11_tipldsc3 = AV46TipLDsc3;
         AV62Configuracion_tipolistapreciowwds_12_tftiplcod = AV10TFTipLCod;
         AV63Configuracion_tipolistapreciowwds_13_tftiplcod_to = AV11TFTipLCod_To;
         AV64Configuracion_tipolistapreciowwds_14_tftipldsc = AV12TFTipLDsc;
         AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel = AV13TFTipLDsc_Sel;
         AV66Configuracion_tipolistapreciowwds_16_tftiplabr = AV14TFTipLAbr;
         AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel = AV15TFTipLAbr_Sel;
         AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels = AV17TFTipLSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1914TipLSts ,
                                              AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels ,
                                              AV51Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1 ,
                                              AV52Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 ,
                                              AV53Configuracion_tipolistapreciowwds_3_tipldsc1 ,
                                              AV54Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 ,
                                              AV55Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2 ,
                                              AV56Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 ,
                                              AV57Configuracion_tipolistapreciowwds_7_tipldsc2 ,
                                              AV58Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 ,
                                              AV59Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3 ,
                                              AV60Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 ,
                                              AV61Configuracion_tipolistapreciowwds_11_tipldsc3 ,
                                              AV62Configuracion_tipolistapreciowwds_12_tftiplcod ,
                                              AV63Configuracion_tipolistapreciowwds_13_tftiplcod_to ,
                                              AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel ,
                                              AV64Configuracion_tipolistapreciowwds_14_tftipldsc ,
                                              AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel ,
                                              AV66Configuracion_tipolistapreciowwds_16_tftiplabr ,
                                              AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels.Count ,
                                              A1912TipLDsc ,
                                              A202TipLCod ,
                                              A1911TipLAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV53Configuracion_tipolistapreciowwds_3_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_tipolistapreciowwds_3_tipldsc1), 100, "%");
         lV53Configuracion_tipolistapreciowwds_3_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_tipolistapreciowwds_3_tipldsc1), 100, "%");
         lV57Configuracion_tipolistapreciowwds_7_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipolistapreciowwds_7_tipldsc2), 100, "%");
         lV57Configuracion_tipolistapreciowwds_7_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipolistapreciowwds_7_tipldsc2), 100, "%");
         lV61Configuracion_tipolistapreciowwds_11_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipolistapreciowwds_11_tipldsc3), 100, "%");
         lV61Configuracion_tipolistapreciowwds_11_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipolistapreciowwds_11_tipldsc3), 100, "%");
         lV64Configuracion_tipolistapreciowwds_14_tftipldsc = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_tipolistapreciowwds_14_tftipldsc), 100, "%");
         lV66Configuracion_tipolistapreciowwds_16_tftiplabr = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_tipolistapreciowwds_16_tftiplabr), 5, "%");
         /* Using cursor P004F3 */
         pr_default.execute(1, new Object[] {lV53Configuracion_tipolistapreciowwds_3_tipldsc1, lV53Configuracion_tipolistapreciowwds_3_tipldsc1, lV57Configuracion_tipolistapreciowwds_7_tipldsc2, lV57Configuracion_tipolistapreciowwds_7_tipldsc2, lV61Configuracion_tipolistapreciowwds_11_tipldsc3, lV61Configuracion_tipolistapreciowwds_11_tipldsc3, AV62Configuracion_tipolistapreciowwds_12_tftiplcod, AV63Configuracion_tipolistapreciowwds_13_tftiplcod_to, lV64Configuracion_tipolistapreciowwds_14_tftipldsc, AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel, lV66Configuracion_tipolistapreciowwds_16_tftiplabr, AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4F4 = false;
            A1911TipLAbr = P004F3_A1911TipLAbr[0];
            A1914TipLSts = P004F3_A1914TipLSts[0];
            A202TipLCod = P004F3_A202TipLCod[0];
            A1912TipLDsc = P004F3_A1912TipLDsc[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P004F3_A1911TipLAbr[0], A1911TipLAbr) == 0 ) )
            {
               BRK4F4 = false;
               A202TipLCod = P004F3_A202TipLCod[0];
               AV30count = (long)(AV30count+1);
               BRK4F4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1911TipLAbr)) )
            {
               AV22Option = A1911TipLAbr;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK4F4 )
            {
               BRK4F4 = true;
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
         AV12TFTipLDsc = "";
         AV13TFTipLDsc_Sel = "";
         AV14TFTipLAbr = "";
         AV15TFTipLAbr_Sel = "";
         AV16TFTipLSts_SelsJson = "";
         AV17TFTipLSts_Sels = new GxSimpleCollection<short>();
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38TipLDsc1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42TipLDsc2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46TipLDsc3 = "";
         AV51Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1 = "";
         AV53Configuracion_tipolistapreciowwds_3_tipldsc1 = "";
         AV55Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2 = "";
         AV57Configuracion_tipolistapreciowwds_7_tipldsc2 = "";
         AV59Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3 = "";
         AV61Configuracion_tipolistapreciowwds_11_tipldsc3 = "";
         AV64Configuracion_tipolistapreciowwds_14_tftipldsc = "";
         AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel = "";
         AV66Configuracion_tipolistapreciowwds_16_tftiplabr = "";
         AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel = "";
         AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV53Configuracion_tipolistapreciowwds_3_tipldsc1 = "";
         lV57Configuracion_tipolistapreciowwds_7_tipldsc2 = "";
         lV61Configuracion_tipolistapreciowwds_11_tipldsc3 = "";
         lV64Configuracion_tipolistapreciowwds_14_tftipldsc = "";
         lV66Configuracion_tipolistapreciowwds_16_tftiplabr = "";
         A1912TipLDsc = "";
         A1911TipLAbr = "";
         P004F2_A1912TipLDsc = new string[] {""} ;
         P004F2_A1914TipLSts = new short[1] ;
         P004F2_A1911TipLAbr = new string[] {""} ;
         P004F2_A202TipLCod = new int[1] ;
         AV22Option = "";
         P004F3_A1911TipLAbr = new string[] {""} ;
         P004F3_A1914TipLSts = new short[1] ;
         P004F3_A202TipLCod = new int[1] ;
         P004F3_A1912TipLDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipolistapreciowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004F2_A1912TipLDsc, P004F2_A1914TipLSts, P004F2_A1911TipLAbr, P004F2_A202TipLCod
               }
               , new Object[] {
               P004F3_A1911TipLAbr, P004F3_A1914TipLSts, P004F3_A202TipLCod, P004F3_A1912TipLDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV52Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 ;
      private short AV56Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 ;
      private short AV60Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 ;
      private short A1914TipLSts ;
      private int AV49GXV1 ;
      private int AV10TFTipLCod ;
      private int AV11TFTipLCod_To ;
      private int AV62Configuracion_tipolistapreciowwds_12_tftiplcod ;
      private int AV63Configuracion_tipolistapreciowwds_13_tftiplcod_to ;
      private int AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels_Count ;
      private int A202TipLCod ;
      private long AV30count ;
      private string AV12TFTipLDsc ;
      private string AV13TFTipLDsc_Sel ;
      private string AV14TFTipLAbr ;
      private string AV15TFTipLAbr_Sel ;
      private string AV38TipLDsc1 ;
      private string AV42TipLDsc2 ;
      private string AV46TipLDsc3 ;
      private string AV53Configuracion_tipolistapreciowwds_3_tipldsc1 ;
      private string AV57Configuracion_tipolistapreciowwds_7_tipldsc2 ;
      private string AV61Configuracion_tipolistapreciowwds_11_tipldsc3 ;
      private string AV64Configuracion_tipolistapreciowwds_14_tftipldsc ;
      private string AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel ;
      private string AV66Configuracion_tipolistapreciowwds_16_tftiplabr ;
      private string AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel ;
      private string scmdbuf ;
      private string lV53Configuracion_tipolistapreciowwds_3_tipldsc1 ;
      private string lV57Configuracion_tipolistapreciowwds_7_tipldsc2 ;
      private string lV61Configuracion_tipolistapreciowwds_11_tipldsc3 ;
      private string lV64Configuracion_tipolistapreciowwds_14_tftipldsc ;
      private string lV66Configuracion_tipolistapreciowwds_16_tftiplabr ;
      private string A1912TipLDsc ;
      private string A1911TipLAbr ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV54Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 ;
      private bool AV58Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 ;
      private bool BRK4F2 ;
      private bool BRK4F4 ;
      private string AV24OptionsJson ;
      private string AV27OptionsDescJson ;
      private string AV29OptionIndexesJson ;
      private string AV16TFTipLSts_SelsJson ;
      private string AV20DDOName ;
      private string AV18SearchTxt ;
      private string AV19SearchTxtTo ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV51Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1 ;
      private string AV55Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2 ;
      private string AV59Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3 ;
      private string AV22Option ;
      private GxSimpleCollection<short> AV17TFTipLSts_Sels ;
      private GxSimpleCollection<short> AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004F2_A1912TipLDsc ;
      private short[] P004F2_A1914TipLSts ;
      private string[] P004F2_A1911TipLAbr ;
      private int[] P004F2_A202TipLCod ;
      private string[] P004F3_A1911TipLAbr ;
      private short[] P004F3_A1914TipLSts ;
      private int[] P004F3_A202TipLCod ;
      private string[] P004F3_A1912TipLDsc ;
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

   public class tipolistapreciowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004F2( IGxContext context ,
                                             short A1914TipLSts ,
                                             GxSimpleCollection<short> AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels ,
                                             string AV51Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1 ,
                                             short AV52Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 ,
                                             string AV53Configuracion_tipolistapreciowwds_3_tipldsc1 ,
                                             bool AV54Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 ,
                                             string AV55Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2 ,
                                             short AV56Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 ,
                                             string AV57Configuracion_tipolistapreciowwds_7_tipldsc2 ,
                                             bool AV58Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 ,
                                             string AV59Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3 ,
                                             short AV60Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 ,
                                             string AV61Configuracion_tipolistapreciowwds_11_tipldsc3 ,
                                             int AV62Configuracion_tipolistapreciowwds_12_tftiplcod ,
                                             int AV63Configuracion_tipolistapreciowwds_13_tftiplcod_to ,
                                             string AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel ,
                                             string AV64Configuracion_tipolistapreciowwds_14_tftipldsc ,
                                             string AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel ,
                                             string AV66Configuracion_tipolistapreciowwds_16_tftiplabr ,
                                             int AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels_Count ,
                                             string A1912TipLDsc ,
                                             int A202TipLCod ,
                                             string A1911TipLAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TipLDsc], [TipLSts], [TipLAbr], [TipLCod] FROM [CTIPOSLISTAS]";
         if ( ( StringUtil.StrCmp(AV51Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV52Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_tipolistapreciowwds_3_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like @lV53Configuracion_tipolistapreciowwds_3_tipldsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV52Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_tipolistapreciowwds_3_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like '%' + @lV53Configuracion_tipolistapreciowwds_3_tipldsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV54Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV56Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipolistapreciowwds_7_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like @lV57Configuracion_tipolistapreciowwds_7_tipldsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV54Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV56Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipolistapreciowwds_7_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like '%' + @lV57Configuracion_tipolistapreciowwds_7_tipldsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV58Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV60Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipolistapreciowwds_11_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like @lV61Configuracion_tipolistapreciowwds_11_tipldsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV58Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV60Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipolistapreciowwds_11_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like '%' + @lV61Configuracion_tipolistapreciowwds_11_tipldsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV62Configuracion_tipolistapreciowwds_12_tftiplcod) )
         {
            AddWhere(sWhereString, "([TipLCod] >= @AV62Configuracion_tipolistapreciowwds_12_tftiplcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV63Configuracion_tipolistapreciowwds_13_tftiplcod_to) )
         {
            AddWhere(sWhereString, "([TipLCod] <= @AV63Configuracion_tipolistapreciowwds_13_tftiplcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipolistapreciowwds_14_tftipldsc)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like @lV64Configuracion_tipolistapreciowwds_14_tftipldsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel)) )
         {
            AddWhere(sWhereString, "([TipLDsc] = @AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_tipolistapreciowwds_16_tftiplabr)) ) )
         {
            AddWhere(sWhereString, "([TipLAbr] like @lV66Configuracion_tipolistapreciowwds_16_tftiplabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel)) )
         {
            AddWhere(sWhereString, "([TipLAbr] = @AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels, "[TipLSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipLDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P004F3( IGxContext context ,
                                             short A1914TipLSts ,
                                             GxSimpleCollection<short> AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels ,
                                             string AV51Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1 ,
                                             short AV52Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 ,
                                             string AV53Configuracion_tipolistapreciowwds_3_tipldsc1 ,
                                             bool AV54Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 ,
                                             string AV55Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2 ,
                                             short AV56Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 ,
                                             string AV57Configuracion_tipolistapreciowwds_7_tipldsc2 ,
                                             bool AV58Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 ,
                                             string AV59Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3 ,
                                             short AV60Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 ,
                                             string AV61Configuracion_tipolistapreciowwds_11_tipldsc3 ,
                                             int AV62Configuracion_tipolistapreciowwds_12_tftiplcod ,
                                             int AV63Configuracion_tipolistapreciowwds_13_tftiplcod_to ,
                                             string AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel ,
                                             string AV64Configuracion_tipolistapreciowwds_14_tftipldsc ,
                                             string AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel ,
                                             string AV66Configuracion_tipolistapreciowwds_16_tftiplabr ,
                                             int AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels_Count ,
                                             string A1912TipLDsc ,
                                             int A202TipLCod ,
                                             string A1911TipLAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TipLAbr], [TipLSts], [TipLCod], [TipLDsc] FROM [CTIPOSLISTAS]";
         if ( ( StringUtil.StrCmp(AV51Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV52Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_tipolistapreciowwds_3_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like @lV53Configuracion_tipolistapreciowwds_3_tipldsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Configuracion_tipolistapreciowwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV52Configuracion_tipolistapreciowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_tipolistapreciowwds_3_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like '%' + @lV53Configuracion_tipolistapreciowwds_3_tipldsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV54Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV56Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipolistapreciowwds_7_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like @lV57Configuracion_tipolistapreciowwds_7_tipldsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV54Configuracion_tipolistapreciowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_tipolistapreciowwds_5_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV56Configuracion_tipolistapreciowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipolistapreciowwds_7_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like '%' + @lV57Configuracion_tipolistapreciowwds_7_tipldsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV58Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV60Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipolistapreciowwds_11_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like @lV61Configuracion_tipolistapreciowwds_11_tipldsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV58Configuracion_tipolistapreciowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_tipolistapreciowwds_9_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV60Configuracion_tipolistapreciowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipolistapreciowwds_11_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like '%' + @lV61Configuracion_tipolistapreciowwds_11_tipldsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV62Configuracion_tipolistapreciowwds_12_tftiplcod) )
         {
            AddWhere(sWhereString, "([TipLCod] >= @AV62Configuracion_tipolistapreciowwds_12_tftiplcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV63Configuracion_tipolistapreciowwds_13_tftiplcod_to) )
         {
            AddWhere(sWhereString, "([TipLCod] <= @AV63Configuracion_tipolistapreciowwds_13_tftiplcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipolistapreciowwds_14_tftipldsc)) ) )
         {
            AddWhere(sWhereString, "([TipLDsc] like @lV64Configuracion_tipolistapreciowwds_14_tftipldsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel)) )
         {
            AddWhere(sWhereString, "([TipLDsc] = @AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_tipolistapreciowwds_16_tftiplabr)) ) )
         {
            AddWhere(sWhereString, "([TipLAbr] like @lV66Configuracion_tipolistapreciowwds_16_tftiplabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel)) )
         {
            AddWhere(sWhereString, "([TipLAbr] = @AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Configuracion_tipolistapreciowwds_18_tftiplsts_sels, "[TipLSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipLAbr]";
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
                     return conditional_P004F2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] );
               case 1 :
                     return conditional_P004F3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP004F2;
          prmP004F2 = new Object[] {
          new ParDef("@lV53Configuracion_tipolistapreciowwds_3_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Configuracion_tipolistapreciowwds_3_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_tipolistapreciowwds_7_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_tipolistapreciowwds_7_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_tipolistapreciowwds_11_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_tipolistapreciowwds_11_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@AV62Configuracion_tipolistapreciowwds_12_tftiplcod",GXType.Int32,6,0) ,
          new ParDef("@AV63Configuracion_tipolistapreciowwds_13_tftiplcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Configuracion_tipolistapreciowwds_14_tftipldsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_tipolistapreciowwds_16_tftiplabr",GXType.NChar,5,0) ,
          new ParDef("@AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel",GXType.NChar,5,0)
          };
          Object[] prmP004F3;
          prmP004F3 = new Object[] {
          new ParDef("@lV53Configuracion_tipolistapreciowwds_3_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Configuracion_tipolistapreciowwds_3_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_tipolistapreciowwds_7_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_tipolistapreciowwds_7_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_tipolistapreciowwds_11_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_tipolistapreciowwds_11_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@AV62Configuracion_tipolistapreciowwds_12_tftiplcod",GXType.Int32,6,0) ,
          new ParDef("@AV63Configuracion_tipolistapreciowwds_13_tftiplcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Configuracion_tipolistapreciowwds_14_tftipldsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Configuracion_tipolistapreciowwds_15_tftipldsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_tipolistapreciowwds_16_tftiplabr",GXType.NChar,5,0) ,
          new ParDef("@AV67Configuracion_tipolistapreciowwds_17_tftiplabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004F2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004F3,100, GxCacheFrequency.OFF ,true,false )
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
