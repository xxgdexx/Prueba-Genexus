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
namespace GeneXus.Programs.seguridad {
   public class localeswwgetfilterdata : GXProcedure
   {
      public localeswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public localeswwgetfilterdata( IGxContext context )
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
         localeswwgetfilterdata objlocaleswwgetfilterdata;
         objlocaleswwgetfilterdata = new localeswwgetfilterdata();
         objlocaleswwgetfilterdata.AV20DDOName = aP0_DDOName;
         objlocaleswwgetfilterdata.AV18SearchTxt = aP1_SearchTxt;
         objlocaleswwgetfilterdata.AV19SearchTxtTo = aP2_SearchTxtTo;
         objlocaleswwgetfilterdata.AV24OptionsJson = "" ;
         objlocaleswwgetfilterdata.AV27OptionsDescJson = "" ;
         objlocaleswwgetfilterdata.AV29OptionIndexesJson = "" ;
         objlocaleswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objlocaleswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlocaleswwgetfilterdata);
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((localeswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_TIEDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADTIEDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_TIEABR") == 0 )
         {
            /* Execute user subroutine: 'LOADTIEABROPTIONS' */
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
         if ( StringUtil.StrCmp(AV31Session.Get("Seguridad.LocalesWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Seguridad.LocalesWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Seguridad.LocalesWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIECOD") == 0 )
            {
               AV10TFTieCod = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV11TFTieCod_To = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIEDSC") == 0 )
            {
               AV12TFTieDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIEDSC_SEL") == 0 )
            {
               AV13TFTieDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIEABR") == 0 )
            {
               AV14TFTieAbr = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIEABR_SEL") == 0 )
            {
               AV15TFTieAbr_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIESTS_SEL") == 0 )
            {
               AV47TFTieSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV48TFTieSts_Sels.FromJSonString(AV47TFTieSts_SelsJson, null);
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "TIEDSC") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV38TieDsc1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "TIEDSC") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV42TieDsc2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "TIEDSC") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV46TieDsc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTIEDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFTieDsc = AV18SearchTxt;
         AV13TFTieDsc_Sel = "";
         AV53Seguridad_localeswwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV54Seguridad_localeswwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV55Seguridad_localeswwds_3_tiedsc1 = AV38TieDsc1;
         AV56Seguridad_localeswwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV57Seguridad_localeswwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV58Seguridad_localeswwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV59Seguridad_localeswwds_7_tiedsc2 = AV42TieDsc2;
         AV60Seguridad_localeswwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV61Seguridad_localeswwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV62Seguridad_localeswwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV63Seguridad_localeswwds_11_tiedsc3 = AV46TieDsc3;
         AV64Seguridad_localeswwds_12_tftiecod = AV10TFTieCod;
         AV65Seguridad_localeswwds_13_tftiecod_to = AV11TFTieCod_To;
         AV66Seguridad_localeswwds_14_tftiedsc = AV12TFTieDsc;
         AV67Seguridad_localeswwds_15_tftiedsc_sel = AV13TFTieDsc_Sel;
         AV68Seguridad_localeswwds_16_tftieabr = AV14TFTieAbr;
         AV69Seguridad_localeswwds_17_tftieabr_sel = AV15TFTieAbr_Sel;
         AV70Seguridad_localeswwds_18_tftiests_sels = AV48TFTieSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1899TieSts ,
                                              AV70Seguridad_localeswwds_18_tftiests_sels ,
                                              AV53Seguridad_localeswwds_1_dynamicfiltersselector1 ,
                                              AV54Seguridad_localeswwds_2_dynamicfiltersoperator1 ,
                                              AV55Seguridad_localeswwds_3_tiedsc1 ,
                                              AV56Seguridad_localeswwds_4_dynamicfiltersenabled2 ,
                                              AV57Seguridad_localeswwds_5_dynamicfiltersselector2 ,
                                              AV58Seguridad_localeswwds_6_dynamicfiltersoperator2 ,
                                              AV59Seguridad_localeswwds_7_tiedsc2 ,
                                              AV60Seguridad_localeswwds_8_dynamicfiltersenabled3 ,
                                              AV61Seguridad_localeswwds_9_dynamicfiltersselector3 ,
                                              AV62Seguridad_localeswwds_10_dynamicfiltersoperator3 ,
                                              AV63Seguridad_localeswwds_11_tiedsc3 ,
                                              AV64Seguridad_localeswwds_12_tftiecod ,
                                              AV65Seguridad_localeswwds_13_tftiecod_to ,
                                              AV67Seguridad_localeswwds_15_tftiedsc_sel ,
                                              AV66Seguridad_localeswwds_14_tftiedsc ,
                                              AV69Seguridad_localeswwds_17_tftieabr_sel ,
                                              AV68Seguridad_localeswwds_16_tftieabr ,
                                              AV70Seguridad_localeswwds_18_tftiests_sels.Count ,
                                              A1898TieDsc ,
                                              A178TieCod ,
                                              A1897TieAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV55Seguridad_localeswwds_3_tiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Seguridad_localeswwds_3_tiedsc1), 100, "%");
         lV55Seguridad_localeswwds_3_tiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Seguridad_localeswwds_3_tiedsc1), 100, "%");
         lV59Seguridad_localeswwds_7_tiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Seguridad_localeswwds_7_tiedsc2), 100, "%");
         lV59Seguridad_localeswwds_7_tiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Seguridad_localeswwds_7_tiedsc2), 100, "%");
         lV63Seguridad_localeswwds_11_tiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Seguridad_localeswwds_11_tiedsc3), 100, "%");
         lV63Seguridad_localeswwds_11_tiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Seguridad_localeswwds_11_tiedsc3), 100, "%");
         lV66Seguridad_localeswwds_14_tftiedsc = StringUtil.PadR( StringUtil.RTrim( AV66Seguridad_localeswwds_14_tftiedsc), 100, "%");
         lV68Seguridad_localeswwds_16_tftieabr = StringUtil.Concat( StringUtil.RTrim( AV68Seguridad_localeswwds_16_tftieabr), "%", "");
         /* Using cursor P001E2 */
         pr_default.execute(0, new Object[] {lV55Seguridad_localeswwds_3_tiedsc1, lV55Seguridad_localeswwds_3_tiedsc1, lV59Seguridad_localeswwds_7_tiedsc2, lV59Seguridad_localeswwds_7_tiedsc2, lV63Seguridad_localeswwds_11_tiedsc3, lV63Seguridad_localeswwds_11_tiedsc3, AV64Seguridad_localeswwds_12_tftiecod, AV65Seguridad_localeswwds_13_tftiecod_to, lV66Seguridad_localeswwds_14_tftiedsc, AV67Seguridad_localeswwds_15_tftiedsc_sel, lV68Seguridad_localeswwds_16_tftieabr, AV69Seguridad_localeswwds_17_tftieabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK1E2 = false;
            A1898TieDsc = P001E2_A1898TieDsc[0];
            A1899TieSts = P001E2_A1899TieSts[0];
            A1897TieAbr = P001E2_A1897TieAbr[0];
            A178TieCod = P001E2_A178TieCod[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P001E2_A1898TieDsc[0], A1898TieDsc) == 0 ) )
            {
               BRK1E2 = false;
               A178TieCod = P001E2_A178TieCod[0];
               AV30count = (long)(AV30count+1);
               BRK1E2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1898TieDsc)) )
            {
               AV22Option = A1898TieDsc;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1E2 )
            {
               BRK1E2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTIEABROPTIONS' Routine */
         returnInSub = false;
         AV14TFTieAbr = AV18SearchTxt;
         AV15TFTieAbr_Sel = "";
         AV53Seguridad_localeswwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV54Seguridad_localeswwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV55Seguridad_localeswwds_3_tiedsc1 = AV38TieDsc1;
         AV56Seguridad_localeswwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV57Seguridad_localeswwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV58Seguridad_localeswwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV59Seguridad_localeswwds_7_tiedsc2 = AV42TieDsc2;
         AV60Seguridad_localeswwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV61Seguridad_localeswwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV62Seguridad_localeswwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV63Seguridad_localeswwds_11_tiedsc3 = AV46TieDsc3;
         AV64Seguridad_localeswwds_12_tftiecod = AV10TFTieCod;
         AV65Seguridad_localeswwds_13_tftiecod_to = AV11TFTieCod_To;
         AV66Seguridad_localeswwds_14_tftiedsc = AV12TFTieDsc;
         AV67Seguridad_localeswwds_15_tftiedsc_sel = AV13TFTieDsc_Sel;
         AV68Seguridad_localeswwds_16_tftieabr = AV14TFTieAbr;
         AV69Seguridad_localeswwds_17_tftieabr_sel = AV15TFTieAbr_Sel;
         AV70Seguridad_localeswwds_18_tftiests_sels = AV48TFTieSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1899TieSts ,
                                              AV70Seguridad_localeswwds_18_tftiests_sels ,
                                              AV53Seguridad_localeswwds_1_dynamicfiltersselector1 ,
                                              AV54Seguridad_localeswwds_2_dynamicfiltersoperator1 ,
                                              AV55Seguridad_localeswwds_3_tiedsc1 ,
                                              AV56Seguridad_localeswwds_4_dynamicfiltersenabled2 ,
                                              AV57Seguridad_localeswwds_5_dynamicfiltersselector2 ,
                                              AV58Seguridad_localeswwds_6_dynamicfiltersoperator2 ,
                                              AV59Seguridad_localeswwds_7_tiedsc2 ,
                                              AV60Seguridad_localeswwds_8_dynamicfiltersenabled3 ,
                                              AV61Seguridad_localeswwds_9_dynamicfiltersselector3 ,
                                              AV62Seguridad_localeswwds_10_dynamicfiltersoperator3 ,
                                              AV63Seguridad_localeswwds_11_tiedsc3 ,
                                              AV64Seguridad_localeswwds_12_tftiecod ,
                                              AV65Seguridad_localeswwds_13_tftiecod_to ,
                                              AV67Seguridad_localeswwds_15_tftiedsc_sel ,
                                              AV66Seguridad_localeswwds_14_tftiedsc ,
                                              AV69Seguridad_localeswwds_17_tftieabr_sel ,
                                              AV68Seguridad_localeswwds_16_tftieabr ,
                                              AV70Seguridad_localeswwds_18_tftiests_sels.Count ,
                                              A1898TieDsc ,
                                              A178TieCod ,
                                              A1897TieAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV55Seguridad_localeswwds_3_tiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Seguridad_localeswwds_3_tiedsc1), 100, "%");
         lV55Seguridad_localeswwds_3_tiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Seguridad_localeswwds_3_tiedsc1), 100, "%");
         lV59Seguridad_localeswwds_7_tiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Seguridad_localeswwds_7_tiedsc2), 100, "%");
         lV59Seguridad_localeswwds_7_tiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Seguridad_localeswwds_7_tiedsc2), 100, "%");
         lV63Seguridad_localeswwds_11_tiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Seguridad_localeswwds_11_tiedsc3), 100, "%");
         lV63Seguridad_localeswwds_11_tiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Seguridad_localeswwds_11_tiedsc3), 100, "%");
         lV66Seguridad_localeswwds_14_tftiedsc = StringUtil.PadR( StringUtil.RTrim( AV66Seguridad_localeswwds_14_tftiedsc), 100, "%");
         lV68Seguridad_localeswwds_16_tftieabr = StringUtil.Concat( StringUtil.RTrim( AV68Seguridad_localeswwds_16_tftieabr), "%", "");
         /* Using cursor P001E3 */
         pr_default.execute(1, new Object[] {lV55Seguridad_localeswwds_3_tiedsc1, lV55Seguridad_localeswwds_3_tiedsc1, lV59Seguridad_localeswwds_7_tiedsc2, lV59Seguridad_localeswwds_7_tiedsc2, lV63Seguridad_localeswwds_11_tiedsc3, lV63Seguridad_localeswwds_11_tiedsc3, AV64Seguridad_localeswwds_12_tftiecod, AV65Seguridad_localeswwds_13_tftiecod_to, lV66Seguridad_localeswwds_14_tftiedsc, AV67Seguridad_localeswwds_15_tftiedsc_sel, lV68Seguridad_localeswwds_16_tftieabr, AV69Seguridad_localeswwds_17_tftieabr_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK1E4 = false;
            A1897TieAbr = P001E3_A1897TieAbr[0];
            A1899TieSts = P001E3_A1899TieSts[0];
            A178TieCod = P001E3_A178TieCod[0];
            A1898TieDsc = P001E3_A1898TieDsc[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P001E3_A1897TieAbr[0], A1897TieAbr) == 0 ) )
            {
               BRK1E4 = false;
               A178TieCod = P001E3_A178TieCod[0];
               AV30count = (long)(AV30count+1);
               BRK1E4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1897TieAbr)) )
            {
               AV22Option = A1897TieAbr;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1E4 )
            {
               BRK1E4 = true;
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
         AV12TFTieDsc = "";
         AV13TFTieDsc_Sel = "";
         AV14TFTieAbr = "";
         AV15TFTieAbr_Sel = "";
         AV47TFTieSts_SelsJson = "";
         AV48TFTieSts_Sels = new GxSimpleCollection<short>();
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38TieDsc1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42TieDsc2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46TieDsc3 = "";
         AV53Seguridad_localeswwds_1_dynamicfiltersselector1 = "";
         AV55Seguridad_localeswwds_3_tiedsc1 = "";
         AV57Seguridad_localeswwds_5_dynamicfiltersselector2 = "";
         AV59Seguridad_localeswwds_7_tiedsc2 = "";
         AV61Seguridad_localeswwds_9_dynamicfiltersselector3 = "";
         AV63Seguridad_localeswwds_11_tiedsc3 = "";
         AV66Seguridad_localeswwds_14_tftiedsc = "";
         AV67Seguridad_localeswwds_15_tftiedsc_sel = "";
         AV68Seguridad_localeswwds_16_tftieabr = "";
         AV69Seguridad_localeswwds_17_tftieabr_sel = "";
         AV70Seguridad_localeswwds_18_tftiests_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV55Seguridad_localeswwds_3_tiedsc1 = "";
         lV59Seguridad_localeswwds_7_tiedsc2 = "";
         lV63Seguridad_localeswwds_11_tiedsc3 = "";
         lV66Seguridad_localeswwds_14_tftiedsc = "";
         lV68Seguridad_localeswwds_16_tftieabr = "";
         A1898TieDsc = "";
         A1897TieAbr = "";
         P001E2_A1898TieDsc = new string[] {""} ;
         P001E2_A1899TieSts = new short[1] ;
         P001E2_A1897TieAbr = new string[] {""} ;
         P001E2_A178TieCod = new int[1] ;
         AV22Option = "";
         P001E3_A1897TieAbr = new string[] {""} ;
         P001E3_A1899TieSts = new short[1] ;
         P001E3_A178TieCod = new int[1] ;
         P001E3_A1898TieDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.localeswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P001E2_A1898TieDsc, P001E2_A1899TieSts, P001E2_A1897TieAbr, P001E2_A178TieCod
               }
               , new Object[] {
               P001E3_A1897TieAbr, P001E3_A1899TieSts, P001E3_A178TieCod, P001E3_A1898TieDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV54Seguridad_localeswwds_2_dynamicfiltersoperator1 ;
      private short AV58Seguridad_localeswwds_6_dynamicfiltersoperator2 ;
      private short AV62Seguridad_localeswwds_10_dynamicfiltersoperator3 ;
      private short A1899TieSts ;
      private int AV51GXV1 ;
      private int AV10TFTieCod ;
      private int AV11TFTieCod_To ;
      private int AV64Seguridad_localeswwds_12_tftiecod ;
      private int AV65Seguridad_localeswwds_13_tftiecod_to ;
      private int AV70Seguridad_localeswwds_18_tftiests_sels_Count ;
      private int A178TieCod ;
      private long AV30count ;
      private string AV12TFTieDsc ;
      private string AV13TFTieDsc_Sel ;
      private string AV38TieDsc1 ;
      private string AV42TieDsc2 ;
      private string AV46TieDsc3 ;
      private string AV55Seguridad_localeswwds_3_tiedsc1 ;
      private string AV59Seguridad_localeswwds_7_tiedsc2 ;
      private string AV63Seguridad_localeswwds_11_tiedsc3 ;
      private string AV66Seguridad_localeswwds_14_tftiedsc ;
      private string AV67Seguridad_localeswwds_15_tftiedsc_sel ;
      private string scmdbuf ;
      private string lV55Seguridad_localeswwds_3_tiedsc1 ;
      private string lV59Seguridad_localeswwds_7_tiedsc2 ;
      private string lV63Seguridad_localeswwds_11_tiedsc3 ;
      private string lV66Seguridad_localeswwds_14_tftiedsc ;
      private string A1898TieDsc ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV56Seguridad_localeswwds_4_dynamicfiltersenabled2 ;
      private bool AV60Seguridad_localeswwds_8_dynamicfiltersenabled3 ;
      private bool BRK1E2 ;
      private bool BRK1E4 ;
      private string AV24OptionsJson ;
      private string AV27OptionsDescJson ;
      private string AV29OptionIndexesJson ;
      private string AV47TFTieSts_SelsJson ;
      private string AV20DDOName ;
      private string AV18SearchTxt ;
      private string AV19SearchTxtTo ;
      private string AV14TFTieAbr ;
      private string AV15TFTieAbr_Sel ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV53Seguridad_localeswwds_1_dynamicfiltersselector1 ;
      private string AV57Seguridad_localeswwds_5_dynamicfiltersselector2 ;
      private string AV61Seguridad_localeswwds_9_dynamicfiltersselector3 ;
      private string AV68Seguridad_localeswwds_16_tftieabr ;
      private string AV69Seguridad_localeswwds_17_tftieabr_sel ;
      private string lV68Seguridad_localeswwds_16_tftieabr ;
      private string A1897TieAbr ;
      private string AV22Option ;
      private GxSimpleCollection<short> AV48TFTieSts_Sels ;
      private GxSimpleCollection<short> AV70Seguridad_localeswwds_18_tftiests_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P001E2_A1898TieDsc ;
      private short[] P001E2_A1899TieSts ;
      private string[] P001E2_A1897TieAbr ;
      private int[] P001E2_A178TieCod ;
      private string[] P001E3_A1897TieAbr ;
      private short[] P001E3_A1899TieSts ;
      private int[] P001E3_A178TieCod ;
      private string[] P001E3_A1898TieDsc ;
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

   public class localeswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001E2( IGxContext context ,
                                             short A1899TieSts ,
                                             GxSimpleCollection<short> AV70Seguridad_localeswwds_18_tftiests_sels ,
                                             string AV53Seguridad_localeswwds_1_dynamicfiltersselector1 ,
                                             short AV54Seguridad_localeswwds_2_dynamicfiltersoperator1 ,
                                             string AV55Seguridad_localeswwds_3_tiedsc1 ,
                                             bool AV56Seguridad_localeswwds_4_dynamicfiltersenabled2 ,
                                             string AV57Seguridad_localeswwds_5_dynamicfiltersselector2 ,
                                             short AV58Seguridad_localeswwds_6_dynamicfiltersoperator2 ,
                                             string AV59Seguridad_localeswwds_7_tiedsc2 ,
                                             bool AV60Seguridad_localeswwds_8_dynamicfiltersenabled3 ,
                                             string AV61Seguridad_localeswwds_9_dynamicfiltersselector3 ,
                                             short AV62Seguridad_localeswwds_10_dynamicfiltersoperator3 ,
                                             string AV63Seguridad_localeswwds_11_tiedsc3 ,
                                             int AV64Seguridad_localeswwds_12_tftiecod ,
                                             int AV65Seguridad_localeswwds_13_tftiecod_to ,
                                             string AV67Seguridad_localeswwds_15_tftiedsc_sel ,
                                             string AV66Seguridad_localeswwds_14_tftiedsc ,
                                             string AV69Seguridad_localeswwds_17_tftieabr_sel ,
                                             string AV68Seguridad_localeswwds_16_tftieabr ,
                                             int AV70Seguridad_localeswwds_18_tftiests_sels_Count ,
                                             string A1898TieDsc ,
                                             int A178TieCod ,
                                             string A1897TieAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TieDsc], [TieSts], [TieAbr], [TieCod] FROM [SGTIENDAS]";
         if ( ( StringUtil.StrCmp(AV53Seguridad_localeswwds_1_dynamicfiltersselector1, "TIEDSC") == 0 ) && ( AV54Seguridad_localeswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Seguridad_localeswwds_3_tiedsc1)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV55Seguridad_localeswwds_3_tiedsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Seguridad_localeswwds_1_dynamicfiltersselector1, "TIEDSC") == 0 ) && ( AV54Seguridad_localeswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Seguridad_localeswwds_3_tiedsc1)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like '%' + @lV55Seguridad_localeswwds_3_tiedsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV56Seguridad_localeswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Seguridad_localeswwds_5_dynamicfiltersselector2, "TIEDSC") == 0 ) && ( AV58Seguridad_localeswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Seguridad_localeswwds_7_tiedsc2)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV59Seguridad_localeswwds_7_tiedsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV56Seguridad_localeswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Seguridad_localeswwds_5_dynamicfiltersselector2, "TIEDSC") == 0 ) && ( AV58Seguridad_localeswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Seguridad_localeswwds_7_tiedsc2)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like '%' + @lV59Seguridad_localeswwds_7_tiedsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV60Seguridad_localeswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Seguridad_localeswwds_9_dynamicfiltersselector3, "TIEDSC") == 0 ) && ( AV62Seguridad_localeswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Seguridad_localeswwds_11_tiedsc3)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV63Seguridad_localeswwds_11_tiedsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV60Seguridad_localeswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Seguridad_localeswwds_9_dynamicfiltersselector3, "TIEDSC") == 0 ) && ( AV62Seguridad_localeswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Seguridad_localeswwds_11_tiedsc3)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like '%' + @lV63Seguridad_localeswwds_11_tiedsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV64Seguridad_localeswwds_12_tftiecod) )
         {
            AddWhere(sWhereString, "([TieCod] >= @AV64Seguridad_localeswwds_12_tftiecod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV65Seguridad_localeswwds_13_tftiecod_to) )
         {
            AddWhere(sWhereString, "([TieCod] <= @AV65Seguridad_localeswwds_13_tftiecod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Seguridad_localeswwds_15_tftiedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Seguridad_localeswwds_14_tftiedsc)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV66Seguridad_localeswwds_14_tftiedsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Seguridad_localeswwds_15_tftiedsc_sel)) )
         {
            AddWhere(sWhereString, "([TieDsc] = @AV67Seguridad_localeswwds_15_tftiedsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Seguridad_localeswwds_17_tftieabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Seguridad_localeswwds_16_tftieabr)) ) )
         {
            AddWhere(sWhereString, "([TieAbr] like @lV68Seguridad_localeswwds_16_tftieabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Seguridad_localeswwds_17_tftieabr_sel)) )
         {
            AddWhere(sWhereString, "([TieAbr] = @AV69Seguridad_localeswwds_17_tftieabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV70Seguridad_localeswwds_18_tftiests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV70Seguridad_localeswwds_18_tftiests_sels, "[TieSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TieDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P001E3( IGxContext context ,
                                             short A1899TieSts ,
                                             GxSimpleCollection<short> AV70Seguridad_localeswwds_18_tftiests_sels ,
                                             string AV53Seguridad_localeswwds_1_dynamicfiltersselector1 ,
                                             short AV54Seguridad_localeswwds_2_dynamicfiltersoperator1 ,
                                             string AV55Seguridad_localeswwds_3_tiedsc1 ,
                                             bool AV56Seguridad_localeswwds_4_dynamicfiltersenabled2 ,
                                             string AV57Seguridad_localeswwds_5_dynamicfiltersselector2 ,
                                             short AV58Seguridad_localeswwds_6_dynamicfiltersoperator2 ,
                                             string AV59Seguridad_localeswwds_7_tiedsc2 ,
                                             bool AV60Seguridad_localeswwds_8_dynamicfiltersenabled3 ,
                                             string AV61Seguridad_localeswwds_9_dynamicfiltersselector3 ,
                                             short AV62Seguridad_localeswwds_10_dynamicfiltersoperator3 ,
                                             string AV63Seguridad_localeswwds_11_tiedsc3 ,
                                             int AV64Seguridad_localeswwds_12_tftiecod ,
                                             int AV65Seguridad_localeswwds_13_tftiecod_to ,
                                             string AV67Seguridad_localeswwds_15_tftiedsc_sel ,
                                             string AV66Seguridad_localeswwds_14_tftiedsc ,
                                             string AV69Seguridad_localeswwds_17_tftieabr_sel ,
                                             string AV68Seguridad_localeswwds_16_tftieabr ,
                                             int AV70Seguridad_localeswwds_18_tftiests_sels_Count ,
                                             string A1898TieDsc ,
                                             int A178TieCod ,
                                             string A1897TieAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TieAbr], [TieSts], [TieCod], [TieDsc] FROM [SGTIENDAS]";
         if ( ( StringUtil.StrCmp(AV53Seguridad_localeswwds_1_dynamicfiltersselector1, "TIEDSC") == 0 ) && ( AV54Seguridad_localeswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Seguridad_localeswwds_3_tiedsc1)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV55Seguridad_localeswwds_3_tiedsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Seguridad_localeswwds_1_dynamicfiltersselector1, "TIEDSC") == 0 ) && ( AV54Seguridad_localeswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Seguridad_localeswwds_3_tiedsc1)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like '%' + @lV55Seguridad_localeswwds_3_tiedsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV56Seguridad_localeswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Seguridad_localeswwds_5_dynamicfiltersselector2, "TIEDSC") == 0 ) && ( AV58Seguridad_localeswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Seguridad_localeswwds_7_tiedsc2)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV59Seguridad_localeswwds_7_tiedsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV56Seguridad_localeswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Seguridad_localeswwds_5_dynamicfiltersselector2, "TIEDSC") == 0 ) && ( AV58Seguridad_localeswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Seguridad_localeswwds_7_tiedsc2)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like '%' + @lV59Seguridad_localeswwds_7_tiedsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV60Seguridad_localeswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Seguridad_localeswwds_9_dynamicfiltersselector3, "TIEDSC") == 0 ) && ( AV62Seguridad_localeswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Seguridad_localeswwds_11_tiedsc3)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV63Seguridad_localeswwds_11_tiedsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV60Seguridad_localeswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Seguridad_localeswwds_9_dynamicfiltersselector3, "TIEDSC") == 0 ) && ( AV62Seguridad_localeswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Seguridad_localeswwds_11_tiedsc3)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like '%' + @lV63Seguridad_localeswwds_11_tiedsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV64Seguridad_localeswwds_12_tftiecod) )
         {
            AddWhere(sWhereString, "([TieCod] >= @AV64Seguridad_localeswwds_12_tftiecod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV65Seguridad_localeswwds_13_tftiecod_to) )
         {
            AddWhere(sWhereString, "([TieCod] <= @AV65Seguridad_localeswwds_13_tftiecod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Seguridad_localeswwds_15_tftiedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Seguridad_localeswwds_14_tftiedsc)) ) )
         {
            AddWhere(sWhereString, "([TieDsc] like @lV66Seguridad_localeswwds_14_tftiedsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Seguridad_localeswwds_15_tftiedsc_sel)) )
         {
            AddWhere(sWhereString, "([TieDsc] = @AV67Seguridad_localeswwds_15_tftiedsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Seguridad_localeswwds_17_tftieabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Seguridad_localeswwds_16_tftieabr)) ) )
         {
            AddWhere(sWhereString, "([TieAbr] like @lV68Seguridad_localeswwds_16_tftieabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Seguridad_localeswwds_17_tftieabr_sel)) )
         {
            AddWhere(sWhereString, "([TieAbr] = @AV69Seguridad_localeswwds_17_tftieabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV70Seguridad_localeswwds_18_tftiests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV70Seguridad_localeswwds_18_tftiests_sels, "[TieSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TieAbr]";
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
                     return conditional_P001E2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] );
               case 1 :
                     return conditional_P001E3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP001E2;
          prmP001E2 = new Object[] {
          new ParDef("@lV55Seguridad_localeswwds_3_tiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV55Seguridad_localeswwds_3_tiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Seguridad_localeswwds_7_tiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV59Seguridad_localeswwds_7_tiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Seguridad_localeswwds_11_tiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV63Seguridad_localeswwds_11_tiedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV64Seguridad_localeswwds_12_tftiecod",GXType.Int32,6,0) ,
          new ParDef("@AV65Seguridad_localeswwds_13_tftiecod_to",GXType.Int32,6,0) ,
          new ParDef("@lV66Seguridad_localeswwds_14_tftiedsc",GXType.NChar,100,0) ,
          new ParDef("@AV67Seguridad_localeswwds_15_tftiedsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV68Seguridad_localeswwds_16_tftieabr",GXType.NVarChar,10,0) ,
          new ParDef("@AV69Seguridad_localeswwds_17_tftieabr_sel",GXType.NVarChar,10,0)
          };
          Object[] prmP001E3;
          prmP001E3 = new Object[] {
          new ParDef("@lV55Seguridad_localeswwds_3_tiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV55Seguridad_localeswwds_3_tiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Seguridad_localeswwds_7_tiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV59Seguridad_localeswwds_7_tiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Seguridad_localeswwds_11_tiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV63Seguridad_localeswwds_11_tiedsc3",GXType.NChar,100,0) ,
          new ParDef("@AV64Seguridad_localeswwds_12_tftiecod",GXType.Int32,6,0) ,
          new ParDef("@AV65Seguridad_localeswwds_13_tftiecod_to",GXType.Int32,6,0) ,
          new ParDef("@lV66Seguridad_localeswwds_14_tftiedsc",GXType.NChar,100,0) ,
          new ParDef("@AV67Seguridad_localeswwds_15_tftiedsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV68Seguridad_localeswwds_16_tftieabr",GXType.NVarChar,10,0) ,
          new ParDef("@AV69Seguridad_localeswwds_17_tftieabr_sel",GXType.NVarChar,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001E2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001E3,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
       }
    }

 }

}
