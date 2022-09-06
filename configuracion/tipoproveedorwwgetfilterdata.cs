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
   public class tipoproveedorwwgetfilterdata : GXProcedure
   {
      public tipoproveedorwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipoproveedorwwgetfilterdata( IGxContext context )
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
         tipoproveedorwwgetfilterdata objtipoproveedorwwgetfilterdata;
         objtipoproveedorwwgetfilterdata = new tipoproveedorwwgetfilterdata();
         objtipoproveedorwwgetfilterdata.AV20DDOName = aP0_DDOName;
         objtipoproveedorwwgetfilterdata.AV18SearchTxt = aP1_SearchTxt;
         objtipoproveedorwwgetfilterdata.AV19SearchTxtTo = aP2_SearchTxtTo;
         objtipoproveedorwwgetfilterdata.AV24OptionsJson = "" ;
         objtipoproveedorwwgetfilterdata.AV27OptionsDescJson = "" ;
         objtipoproveedorwwgetfilterdata.AV29OptionIndexesJson = "" ;
         objtipoproveedorwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objtipoproveedorwwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipoproveedorwwgetfilterdata);
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipoproveedorwwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_TPRVDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADTPRVDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_TPRVABR") == 0 )
         {
            /* Execute user subroutine: 'LOADTPRVABROPTIONS' */
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
         if ( StringUtil.StrCmp(AV31Session.Get("Configuracion.TipoProveedorWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoProveedorWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Configuracion.TipoProveedorWWGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTPRVCOD") == 0 )
            {
               AV10TFTprvCod = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV11TFTprvCod_To = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTPRVDSC") == 0 )
            {
               AV12TFTprvDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTPRVDSC_SEL") == 0 )
            {
               AV13TFTprvDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTPRVABR") == 0 )
            {
               AV14TFTprvAbr = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTPRVABR_SEL") == 0 )
            {
               AV15TFTprvAbr_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTPRVSTS_SEL") == 0 )
            {
               AV16TFTprvSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV17TFTprvSts_Sels.FromJSonString(AV16TFTprvSts_SelsJson, null);
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "TPRVDSC") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV38TprvDsc1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "TPRVDSC") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV42TprvDsc2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "TPRVDSC") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV46TprvDsc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTPRVDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFTprvDsc = AV18SearchTxt;
         AV13TFTprvDsc_Sel = "";
         AV51Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV52Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV53Configuracion_tipoproveedorwwds_3_tprvdsc1 = AV38TprvDsc1;
         AV54Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV55Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV56Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV57Configuracion_tipoproveedorwwds_7_tprvdsc2 = AV42TprvDsc2;
         AV58Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV59Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV60Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV61Configuracion_tipoproveedorwwds_11_tprvdsc3 = AV46TprvDsc3;
         AV62Configuracion_tipoproveedorwwds_12_tftprvcod = AV10TFTprvCod;
         AV63Configuracion_tipoproveedorwwds_13_tftprvcod_to = AV11TFTprvCod_To;
         AV64Configuracion_tipoproveedorwwds_14_tftprvdsc = AV12TFTprvDsc;
         AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel = AV13TFTprvDsc_Sel;
         AV66Configuracion_tipoproveedorwwds_16_tftprvabr = AV14TFTprvAbr;
         AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel = AV15TFTprvAbr_Sel;
         AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels = AV17TFTprvSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1942TprvSts ,
                                              AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels ,
                                              AV51Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1 ,
                                              AV52Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 ,
                                              AV53Configuracion_tipoproveedorwwds_3_tprvdsc1 ,
                                              AV54Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 ,
                                              AV55Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2 ,
                                              AV56Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 ,
                                              AV57Configuracion_tipoproveedorwwds_7_tprvdsc2 ,
                                              AV58Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 ,
                                              AV59Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3 ,
                                              AV60Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 ,
                                              AV61Configuracion_tipoproveedorwwds_11_tprvdsc3 ,
                                              AV62Configuracion_tipoproveedorwwds_12_tftprvcod ,
                                              AV63Configuracion_tipoproveedorwwds_13_tftprvcod_to ,
                                              AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel ,
                                              AV64Configuracion_tipoproveedorwwds_14_tftprvdsc ,
                                              AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel ,
                                              AV66Configuracion_tipoproveedorwwds_16_tftprvabr ,
                                              AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels.Count ,
                                              A1941TprvDsc ,
                                              A298TprvCod ,
                                              A1940TprvAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV53Configuracion_tipoproveedorwwds_3_tprvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_tipoproveedorwwds_3_tprvdsc1), 100, "%");
         lV53Configuracion_tipoproveedorwwds_3_tprvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_tipoproveedorwwds_3_tprvdsc1), 100, "%");
         lV57Configuracion_tipoproveedorwwds_7_tprvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipoproveedorwwds_7_tprvdsc2), 100, "%");
         lV57Configuracion_tipoproveedorwwds_7_tprvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipoproveedorwwds_7_tprvdsc2), 100, "%");
         lV61Configuracion_tipoproveedorwwds_11_tprvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipoproveedorwwds_11_tprvdsc3), 100, "%");
         lV61Configuracion_tipoproveedorwwds_11_tprvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipoproveedorwwds_11_tprvdsc3), 100, "%");
         lV64Configuracion_tipoproveedorwwds_14_tftprvdsc = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_tipoproveedorwwds_14_tftprvdsc), 100, "%");
         lV66Configuracion_tipoproveedorwwds_16_tftprvabr = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_tipoproveedorwwds_16_tftprvabr), 5, "%");
         /* Using cursor P00462 */
         pr_default.execute(0, new Object[] {lV53Configuracion_tipoproveedorwwds_3_tprvdsc1, lV53Configuracion_tipoproveedorwwds_3_tprvdsc1, lV57Configuracion_tipoproveedorwwds_7_tprvdsc2, lV57Configuracion_tipoproveedorwwds_7_tprvdsc2, lV61Configuracion_tipoproveedorwwds_11_tprvdsc3, lV61Configuracion_tipoproveedorwwds_11_tprvdsc3, AV62Configuracion_tipoproveedorwwds_12_tftprvcod, AV63Configuracion_tipoproveedorwwds_13_tftprvcod_to, lV64Configuracion_tipoproveedorwwds_14_tftprvdsc, AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel, lV66Configuracion_tipoproveedorwwds_16_tftprvabr, AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK462 = false;
            A1941TprvDsc = P00462_A1941TprvDsc[0];
            A1942TprvSts = P00462_A1942TprvSts[0];
            A1940TprvAbr = P00462_A1940TprvAbr[0];
            A298TprvCod = P00462_A298TprvCod[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00462_A1941TprvDsc[0], A1941TprvDsc) == 0 ) )
            {
               BRK462 = false;
               A298TprvCod = P00462_A298TprvCod[0];
               AV30count = (long)(AV30count+1);
               BRK462 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1941TprvDsc)) )
            {
               AV22Option = A1941TprvDsc;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK462 )
            {
               BRK462 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTPRVABROPTIONS' Routine */
         returnInSub = false;
         AV14TFTprvAbr = AV18SearchTxt;
         AV15TFTprvAbr_Sel = "";
         AV51Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV52Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV53Configuracion_tipoproveedorwwds_3_tprvdsc1 = AV38TprvDsc1;
         AV54Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV55Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV56Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV57Configuracion_tipoproveedorwwds_7_tprvdsc2 = AV42TprvDsc2;
         AV58Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV59Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV60Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV61Configuracion_tipoproveedorwwds_11_tprvdsc3 = AV46TprvDsc3;
         AV62Configuracion_tipoproveedorwwds_12_tftprvcod = AV10TFTprvCod;
         AV63Configuracion_tipoproveedorwwds_13_tftprvcod_to = AV11TFTprvCod_To;
         AV64Configuracion_tipoproveedorwwds_14_tftprvdsc = AV12TFTprvDsc;
         AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel = AV13TFTprvDsc_Sel;
         AV66Configuracion_tipoproveedorwwds_16_tftprvabr = AV14TFTprvAbr;
         AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel = AV15TFTprvAbr_Sel;
         AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels = AV17TFTprvSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1942TprvSts ,
                                              AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels ,
                                              AV51Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1 ,
                                              AV52Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 ,
                                              AV53Configuracion_tipoproveedorwwds_3_tprvdsc1 ,
                                              AV54Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 ,
                                              AV55Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2 ,
                                              AV56Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 ,
                                              AV57Configuracion_tipoproveedorwwds_7_tprvdsc2 ,
                                              AV58Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 ,
                                              AV59Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3 ,
                                              AV60Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 ,
                                              AV61Configuracion_tipoproveedorwwds_11_tprvdsc3 ,
                                              AV62Configuracion_tipoproveedorwwds_12_tftprvcod ,
                                              AV63Configuracion_tipoproveedorwwds_13_tftprvcod_to ,
                                              AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel ,
                                              AV64Configuracion_tipoproveedorwwds_14_tftprvdsc ,
                                              AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel ,
                                              AV66Configuracion_tipoproveedorwwds_16_tftprvabr ,
                                              AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels.Count ,
                                              A1941TprvDsc ,
                                              A298TprvCod ,
                                              A1940TprvAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV53Configuracion_tipoproveedorwwds_3_tprvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_tipoproveedorwwds_3_tprvdsc1), 100, "%");
         lV53Configuracion_tipoproveedorwwds_3_tprvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_tipoproveedorwwds_3_tprvdsc1), 100, "%");
         lV57Configuracion_tipoproveedorwwds_7_tprvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipoproveedorwwds_7_tprvdsc2), 100, "%");
         lV57Configuracion_tipoproveedorwwds_7_tprvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_tipoproveedorwwds_7_tprvdsc2), 100, "%");
         lV61Configuracion_tipoproveedorwwds_11_tprvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipoproveedorwwds_11_tprvdsc3), 100, "%");
         lV61Configuracion_tipoproveedorwwds_11_tprvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_tipoproveedorwwds_11_tprvdsc3), 100, "%");
         lV64Configuracion_tipoproveedorwwds_14_tftprvdsc = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_tipoproveedorwwds_14_tftprvdsc), 100, "%");
         lV66Configuracion_tipoproveedorwwds_16_tftprvabr = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_tipoproveedorwwds_16_tftprvabr), 5, "%");
         /* Using cursor P00463 */
         pr_default.execute(1, new Object[] {lV53Configuracion_tipoproveedorwwds_3_tprvdsc1, lV53Configuracion_tipoproveedorwwds_3_tprvdsc1, lV57Configuracion_tipoproveedorwwds_7_tprvdsc2, lV57Configuracion_tipoproveedorwwds_7_tprvdsc2, lV61Configuracion_tipoproveedorwwds_11_tprvdsc3, lV61Configuracion_tipoproveedorwwds_11_tprvdsc3, AV62Configuracion_tipoproveedorwwds_12_tftprvcod, AV63Configuracion_tipoproveedorwwds_13_tftprvcod_to, lV64Configuracion_tipoproveedorwwds_14_tftprvdsc, AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel, lV66Configuracion_tipoproveedorwwds_16_tftprvabr, AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK464 = false;
            A1940TprvAbr = P00463_A1940TprvAbr[0];
            A1942TprvSts = P00463_A1942TprvSts[0];
            A298TprvCod = P00463_A298TprvCod[0];
            A1941TprvDsc = P00463_A1941TprvDsc[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00463_A1940TprvAbr[0], A1940TprvAbr) == 0 ) )
            {
               BRK464 = false;
               A298TprvCod = P00463_A298TprvCod[0];
               AV30count = (long)(AV30count+1);
               BRK464 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1940TprvAbr)) )
            {
               AV22Option = A1940TprvAbr;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK464 )
            {
               BRK464 = true;
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
         AV12TFTprvDsc = "";
         AV13TFTprvDsc_Sel = "";
         AV14TFTprvAbr = "";
         AV15TFTprvAbr_Sel = "";
         AV16TFTprvSts_SelsJson = "";
         AV17TFTprvSts_Sels = new GxSimpleCollection<short>();
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38TprvDsc1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42TprvDsc2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46TprvDsc3 = "";
         AV51Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1 = "";
         AV53Configuracion_tipoproveedorwwds_3_tprvdsc1 = "";
         AV55Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2 = "";
         AV57Configuracion_tipoproveedorwwds_7_tprvdsc2 = "";
         AV59Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3 = "";
         AV61Configuracion_tipoproveedorwwds_11_tprvdsc3 = "";
         AV64Configuracion_tipoproveedorwwds_14_tftprvdsc = "";
         AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel = "";
         AV66Configuracion_tipoproveedorwwds_16_tftprvabr = "";
         AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel = "";
         AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV53Configuracion_tipoproveedorwwds_3_tprvdsc1 = "";
         lV57Configuracion_tipoproveedorwwds_7_tprvdsc2 = "";
         lV61Configuracion_tipoproveedorwwds_11_tprvdsc3 = "";
         lV64Configuracion_tipoproveedorwwds_14_tftprvdsc = "";
         lV66Configuracion_tipoproveedorwwds_16_tftprvabr = "";
         A1941TprvDsc = "";
         A1940TprvAbr = "";
         P00462_A1941TprvDsc = new string[] {""} ;
         P00462_A1942TprvSts = new short[1] ;
         P00462_A1940TprvAbr = new string[] {""} ;
         P00462_A298TprvCod = new int[1] ;
         AV22Option = "";
         P00463_A1940TprvAbr = new string[] {""} ;
         P00463_A1942TprvSts = new short[1] ;
         P00463_A298TprvCod = new int[1] ;
         P00463_A1941TprvDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipoproveedorwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00462_A1941TprvDsc, P00462_A1942TprvSts, P00462_A1940TprvAbr, P00462_A298TprvCod
               }
               , new Object[] {
               P00463_A1940TprvAbr, P00463_A1942TprvSts, P00463_A298TprvCod, P00463_A1941TprvDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV52Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 ;
      private short AV56Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 ;
      private short AV60Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 ;
      private short A1942TprvSts ;
      private int AV49GXV1 ;
      private int AV10TFTprvCod ;
      private int AV11TFTprvCod_To ;
      private int AV62Configuracion_tipoproveedorwwds_12_tftprvcod ;
      private int AV63Configuracion_tipoproveedorwwds_13_tftprvcod_to ;
      private int AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels_Count ;
      private int A298TprvCod ;
      private long AV30count ;
      private string AV12TFTprvDsc ;
      private string AV13TFTprvDsc_Sel ;
      private string AV14TFTprvAbr ;
      private string AV15TFTprvAbr_Sel ;
      private string AV38TprvDsc1 ;
      private string AV42TprvDsc2 ;
      private string AV46TprvDsc3 ;
      private string AV53Configuracion_tipoproveedorwwds_3_tprvdsc1 ;
      private string AV57Configuracion_tipoproveedorwwds_7_tprvdsc2 ;
      private string AV61Configuracion_tipoproveedorwwds_11_tprvdsc3 ;
      private string AV64Configuracion_tipoproveedorwwds_14_tftprvdsc ;
      private string AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel ;
      private string AV66Configuracion_tipoproveedorwwds_16_tftprvabr ;
      private string AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel ;
      private string scmdbuf ;
      private string lV53Configuracion_tipoproveedorwwds_3_tprvdsc1 ;
      private string lV57Configuracion_tipoproveedorwwds_7_tprvdsc2 ;
      private string lV61Configuracion_tipoproveedorwwds_11_tprvdsc3 ;
      private string lV64Configuracion_tipoproveedorwwds_14_tftprvdsc ;
      private string lV66Configuracion_tipoproveedorwwds_16_tftprvabr ;
      private string A1941TprvDsc ;
      private string A1940TprvAbr ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV54Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 ;
      private bool AV58Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 ;
      private bool BRK462 ;
      private bool BRK464 ;
      private string AV24OptionsJson ;
      private string AV27OptionsDescJson ;
      private string AV29OptionIndexesJson ;
      private string AV16TFTprvSts_SelsJson ;
      private string AV20DDOName ;
      private string AV18SearchTxt ;
      private string AV19SearchTxtTo ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV51Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1 ;
      private string AV55Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2 ;
      private string AV59Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3 ;
      private string AV22Option ;
      private GxSimpleCollection<short> AV17TFTprvSts_Sels ;
      private GxSimpleCollection<short> AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00462_A1941TprvDsc ;
      private short[] P00462_A1942TprvSts ;
      private string[] P00462_A1940TprvAbr ;
      private int[] P00462_A298TprvCod ;
      private string[] P00463_A1940TprvAbr ;
      private short[] P00463_A1942TprvSts ;
      private int[] P00463_A298TprvCod ;
      private string[] P00463_A1941TprvDsc ;
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

   public class tipoproveedorwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00462( IGxContext context ,
                                             short A1942TprvSts ,
                                             GxSimpleCollection<short> AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels ,
                                             string AV51Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1 ,
                                             short AV52Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 ,
                                             string AV53Configuracion_tipoproveedorwwds_3_tprvdsc1 ,
                                             bool AV54Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 ,
                                             string AV55Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2 ,
                                             short AV56Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 ,
                                             string AV57Configuracion_tipoproveedorwwds_7_tprvdsc2 ,
                                             bool AV58Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 ,
                                             string AV59Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3 ,
                                             short AV60Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 ,
                                             string AV61Configuracion_tipoproveedorwwds_11_tprvdsc3 ,
                                             int AV62Configuracion_tipoproveedorwwds_12_tftprvcod ,
                                             int AV63Configuracion_tipoproveedorwwds_13_tftprvcod_to ,
                                             string AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel ,
                                             string AV64Configuracion_tipoproveedorwwds_14_tftprvdsc ,
                                             string AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel ,
                                             string AV66Configuracion_tipoproveedorwwds_16_tftprvabr ,
                                             int AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels_Count ,
                                             string A1941TprvDsc ,
                                             int A298TprvCod ,
                                             string A1940TprvAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TprvDsc], [TprvSts], [TprvAbr], [TprvCod] FROM [CTIPOPROVEEDOR]";
         if ( ( StringUtil.StrCmp(AV51Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1, "TPRVDSC") == 0 ) && ( AV52Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_tipoproveedorwwds_3_tprvdsc1)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like @lV53Configuracion_tipoproveedorwwds_3_tprvdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1, "TPRVDSC") == 0 ) && ( AV52Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_tipoproveedorwwds_3_tprvdsc1)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like '%' + @lV53Configuracion_tipoproveedorwwds_3_tprvdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV54Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2, "TPRVDSC") == 0 ) && ( AV56Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipoproveedorwwds_7_tprvdsc2)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like @lV57Configuracion_tipoproveedorwwds_7_tprvdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV54Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2, "TPRVDSC") == 0 ) && ( AV56Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipoproveedorwwds_7_tprvdsc2)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like '%' + @lV57Configuracion_tipoproveedorwwds_7_tprvdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV58Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3, "TPRVDSC") == 0 ) && ( AV60Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipoproveedorwwds_11_tprvdsc3)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like @lV61Configuracion_tipoproveedorwwds_11_tprvdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV58Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3, "TPRVDSC") == 0 ) && ( AV60Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipoproveedorwwds_11_tprvdsc3)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like '%' + @lV61Configuracion_tipoproveedorwwds_11_tprvdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV62Configuracion_tipoproveedorwwds_12_tftprvcod) )
         {
            AddWhere(sWhereString, "([TprvCod] >= @AV62Configuracion_tipoproveedorwwds_12_tftprvcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV63Configuracion_tipoproveedorwwds_13_tftprvcod_to) )
         {
            AddWhere(sWhereString, "([TprvCod] <= @AV63Configuracion_tipoproveedorwwds_13_tftprvcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipoproveedorwwds_14_tftprvdsc)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like @lV64Configuracion_tipoproveedorwwds_14_tftprvdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel)) )
         {
            AddWhere(sWhereString, "([TprvDsc] = @AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_tipoproveedorwwds_16_tftprvabr)) ) )
         {
            AddWhere(sWhereString, "([TprvAbr] like @lV66Configuracion_tipoproveedorwwds_16_tftprvabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel)) )
         {
            AddWhere(sWhereString, "([TprvAbr] = @AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels, "[TprvSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TprvDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00463( IGxContext context ,
                                             short A1942TprvSts ,
                                             GxSimpleCollection<short> AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels ,
                                             string AV51Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1 ,
                                             short AV52Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 ,
                                             string AV53Configuracion_tipoproveedorwwds_3_tprvdsc1 ,
                                             bool AV54Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 ,
                                             string AV55Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2 ,
                                             short AV56Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 ,
                                             string AV57Configuracion_tipoproveedorwwds_7_tprvdsc2 ,
                                             bool AV58Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 ,
                                             string AV59Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3 ,
                                             short AV60Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 ,
                                             string AV61Configuracion_tipoproveedorwwds_11_tprvdsc3 ,
                                             int AV62Configuracion_tipoproveedorwwds_12_tftprvcod ,
                                             int AV63Configuracion_tipoproveedorwwds_13_tftprvcod_to ,
                                             string AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel ,
                                             string AV64Configuracion_tipoproveedorwwds_14_tftprvdsc ,
                                             string AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel ,
                                             string AV66Configuracion_tipoproveedorwwds_16_tftprvabr ,
                                             int AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels_Count ,
                                             string A1941TprvDsc ,
                                             int A298TprvCod ,
                                             string A1940TprvAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TprvAbr], [TprvSts], [TprvCod], [TprvDsc] FROM [CTIPOPROVEEDOR]";
         if ( ( StringUtil.StrCmp(AV51Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1, "TPRVDSC") == 0 ) && ( AV52Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_tipoproveedorwwds_3_tprvdsc1)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like @lV53Configuracion_tipoproveedorwwds_3_tprvdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Configuracion_tipoproveedorwwds_1_dynamicfiltersselector1, "TPRVDSC") == 0 ) && ( AV52Configuracion_tipoproveedorwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_tipoproveedorwwds_3_tprvdsc1)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like '%' + @lV53Configuracion_tipoproveedorwwds_3_tprvdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV54Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2, "TPRVDSC") == 0 ) && ( AV56Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipoproveedorwwds_7_tprvdsc2)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like @lV57Configuracion_tipoproveedorwwds_7_tprvdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV54Configuracion_tipoproveedorwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_tipoproveedorwwds_5_dynamicfiltersselector2, "TPRVDSC") == 0 ) && ( AV56Configuracion_tipoproveedorwwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_tipoproveedorwwds_7_tprvdsc2)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like '%' + @lV57Configuracion_tipoproveedorwwds_7_tprvdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV58Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3, "TPRVDSC") == 0 ) && ( AV60Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipoproveedorwwds_11_tprvdsc3)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like @lV61Configuracion_tipoproveedorwwds_11_tprvdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV58Configuracion_tipoproveedorwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_tipoproveedorwwds_9_dynamicfiltersselector3, "TPRVDSC") == 0 ) && ( AV60Configuracion_tipoproveedorwwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_tipoproveedorwwds_11_tprvdsc3)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like '%' + @lV61Configuracion_tipoproveedorwwds_11_tprvdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV62Configuracion_tipoproveedorwwds_12_tftprvcod) )
         {
            AddWhere(sWhereString, "([TprvCod] >= @AV62Configuracion_tipoproveedorwwds_12_tftprvcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV63Configuracion_tipoproveedorwwds_13_tftprvcod_to) )
         {
            AddWhere(sWhereString, "([TprvCod] <= @AV63Configuracion_tipoproveedorwwds_13_tftprvcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipoproveedorwwds_14_tftprvdsc)) ) )
         {
            AddWhere(sWhereString, "([TprvDsc] like @lV64Configuracion_tipoproveedorwwds_14_tftprvdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel)) )
         {
            AddWhere(sWhereString, "([TprvDsc] = @AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_tipoproveedorwwds_16_tftprvabr)) ) )
         {
            AddWhere(sWhereString, "([TprvAbr] like @lV66Configuracion_tipoproveedorwwds_16_tftprvabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel)) )
         {
            AddWhere(sWhereString, "([TprvAbr] = @AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Configuracion_tipoproveedorwwds_18_tftprvsts_sels, "[TprvSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TprvAbr]";
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
                     return conditional_P00462(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] );
               case 1 :
                     return conditional_P00463(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP00462;
          prmP00462 = new Object[] {
          new ParDef("@lV53Configuracion_tipoproveedorwwds_3_tprvdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Configuracion_tipoproveedorwwds_3_tprvdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_tipoproveedorwwds_7_tprvdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_tipoproveedorwwds_7_tprvdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_tipoproveedorwwds_11_tprvdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_tipoproveedorwwds_11_tprvdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV62Configuracion_tipoproveedorwwds_12_tftprvcod",GXType.Int32,6,0) ,
          new ParDef("@AV63Configuracion_tipoproveedorwwds_13_tftprvcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Configuracion_tipoproveedorwwds_14_tftprvdsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_tipoproveedorwwds_16_tftprvabr",GXType.NChar,5,0) ,
          new ParDef("@AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel",GXType.NChar,5,0)
          };
          Object[] prmP00463;
          prmP00463 = new Object[] {
          new ParDef("@lV53Configuracion_tipoproveedorwwds_3_tprvdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Configuracion_tipoproveedorwwds_3_tprvdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_tipoproveedorwwds_7_tprvdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_tipoproveedorwwds_7_tprvdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_tipoproveedorwwds_11_tprvdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_tipoproveedorwwds_11_tprvdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV62Configuracion_tipoproveedorwwds_12_tftprvcod",GXType.Int32,6,0) ,
          new ParDef("@AV63Configuracion_tipoproveedorwwds_13_tftprvcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Configuracion_tipoproveedorwwds_14_tftprvdsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Configuracion_tipoproveedorwwds_15_tftprvdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_tipoproveedorwwds_16_tftprvabr",GXType.NChar,5,0) ,
          new ParDef("@AV67Configuracion_tipoproveedorwwds_17_tftprvabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00462", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00462,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00463", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00463,100, GxCacheFrequency.OFF ,true,false )
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
