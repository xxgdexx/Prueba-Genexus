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
   public class sublineawwgetfilterdata : GXProcedure
   {
      public sublineawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public sublineawwgetfilterdata( IGxContext context )
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
         sublineawwgetfilterdata objsublineawwgetfilterdata;
         objsublineawwgetfilterdata = new sublineawwgetfilterdata();
         objsublineawwgetfilterdata.AV20DDOName = aP0_DDOName;
         objsublineawwgetfilterdata.AV18SearchTxt = aP1_SearchTxt;
         objsublineawwgetfilterdata.AV19SearchTxtTo = aP2_SearchTxtTo;
         objsublineawwgetfilterdata.AV24OptionsJson = "" ;
         objsublineawwgetfilterdata.AV27OptionsDescJson = "" ;
         objsublineawwgetfilterdata.AV29OptionIndexesJson = "" ;
         objsublineawwgetfilterdata.context.SetSubmitInitialConfig(context);
         objsublineawwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objsublineawwgetfilterdata);
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((sublineawwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_SUBLDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADSUBLDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_SUBLABR") == 0 )
         {
            /* Execute user subroutine: 'LOADSUBLABROPTIONS' */
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
         if ( StringUtil.StrCmp(AV31Session.Get("Configuracion.SubLineaWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.SubLineaWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Configuracion.SubLineaWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSUBLCOD") == 0 )
            {
               AV10TFSublCod = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV11TFSublCod_To = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSUBLDSC") == 0 )
            {
               AV12TFSublDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSUBLDSC_SEL") == 0 )
            {
               AV13TFSublDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSUBLABR") == 0 )
            {
               AV14TFSublAbr = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSUBLABR_SEL") == 0 )
            {
               AV15TFSublAbr_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFSUBLSTS_SEL") == 0 )
            {
               AV47TFSublSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV48TFSublSts_Sels.FromJSonString(AV47TFSublSts_SelsJson, null);
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "SUBLDSC") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV38SublDsc1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "SUBLDSC") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV42SublDsc2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "SUBLDSC") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV46SublDsc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSUBLDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFSublDsc = AV18SearchTxt;
         AV13TFSublDsc_Sel = "";
         AV53Configuracion_sublineawwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV54Configuracion_sublineawwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV55Configuracion_sublineawwds_3_subldsc1 = AV38SublDsc1;
         AV56Configuracion_sublineawwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV57Configuracion_sublineawwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV58Configuracion_sublineawwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV59Configuracion_sublineawwds_7_subldsc2 = AV42SublDsc2;
         AV60Configuracion_sublineawwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV61Configuracion_sublineawwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV62Configuracion_sublineawwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV63Configuracion_sublineawwds_11_subldsc3 = AV46SublDsc3;
         AV64Configuracion_sublineawwds_12_tfsublcod = AV10TFSublCod;
         AV65Configuracion_sublineawwds_13_tfsublcod_to = AV11TFSublCod_To;
         AV66Configuracion_sublineawwds_14_tfsubldsc = AV12TFSublDsc;
         AV67Configuracion_sublineawwds_15_tfsubldsc_sel = AV13TFSublDsc_Sel;
         AV68Configuracion_sublineawwds_16_tfsublabr = AV14TFSublAbr;
         AV69Configuracion_sublineawwds_17_tfsublabr_sel = AV15TFSublAbr_Sel;
         AV70Configuracion_sublineawwds_18_tfsublsts_sels = AV48TFSublSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1893SublSts ,
                                              AV70Configuracion_sublineawwds_18_tfsublsts_sels ,
                                              AV53Configuracion_sublineawwds_1_dynamicfiltersselector1 ,
                                              AV54Configuracion_sublineawwds_2_dynamicfiltersoperator1 ,
                                              AV55Configuracion_sublineawwds_3_subldsc1 ,
                                              AV56Configuracion_sublineawwds_4_dynamicfiltersenabled2 ,
                                              AV57Configuracion_sublineawwds_5_dynamicfiltersselector2 ,
                                              AV58Configuracion_sublineawwds_6_dynamicfiltersoperator2 ,
                                              AV59Configuracion_sublineawwds_7_subldsc2 ,
                                              AV60Configuracion_sublineawwds_8_dynamicfiltersenabled3 ,
                                              AV61Configuracion_sublineawwds_9_dynamicfiltersselector3 ,
                                              AV62Configuracion_sublineawwds_10_dynamicfiltersoperator3 ,
                                              AV63Configuracion_sublineawwds_11_subldsc3 ,
                                              AV64Configuracion_sublineawwds_12_tfsublcod ,
                                              AV65Configuracion_sublineawwds_13_tfsublcod_to ,
                                              AV67Configuracion_sublineawwds_15_tfsubldsc_sel ,
                                              AV66Configuracion_sublineawwds_14_tfsubldsc ,
                                              AV69Configuracion_sublineawwds_17_tfsublabr_sel ,
                                              AV68Configuracion_sublineawwds_16_tfsublabr ,
                                              AV70Configuracion_sublineawwds_18_tfsublsts_sels.Count ,
                                              A1892SublDsc ,
                                              A51SublCod ,
                                              A1891SublAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV55Configuracion_sublineawwds_3_subldsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Configuracion_sublineawwds_3_subldsc1), 100, "%");
         lV55Configuracion_sublineawwds_3_subldsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Configuracion_sublineawwds_3_subldsc1), 100, "%");
         lV59Configuracion_sublineawwds_7_subldsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_sublineawwds_7_subldsc2), 100, "%");
         lV59Configuracion_sublineawwds_7_subldsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_sublineawwds_7_subldsc2), 100, "%");
         lV63Configuracion_sublineawwds_11_subldsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_sublineawwds_11_subldsc3), 100, "%");
         lV63Configuracion_sublineawwds_11_subldsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_sublineawwds_11_subldsc3), 100, "%");
         lV66Configuracion_sublineawwds_14_tfsubldsc = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_sublineawwds_14_tfsubldsc), 100, "%");
         lV68Configuracion_sublineawwds_16_tfsublabr = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_sublineawwds_16_tfsublabr), 5, "%");
         /* Using cursor P002S2 */
         pr_default.execute(0, new Object[] {lV55Configuracion_sublineawwds_3_subldsc1, lV55Configuracion_sublineawwds_3_subldsc1, lV59Configuracion_sublineawwds_7_subldsc2, lV59Configuracion_sublineawwds_7_subldsc2, lV63Configuracion_sublineawwds_11_subldsc3, lV63Configuracion_sublineawwds_11_subldsc3, AV64Configuracion_sublineawwds_12_tfsublcod, AV65Configuracion_sublineawwds_13_tfsublcod_to, lV66Configuracion_sublineawwds_14_tfsubldsc, AV67Configuracion_sublineawwds_15_tfsubldsc_sel, lV68Configuracion_sublineawwds_16_tfsublabr, AV69Configuracion_sublineawwds_17_tfsublabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2S2 = false;
            A1892SublDsc = P002S2_A1892SublDsc[0];
            A1893SublSts = P002S2_A1893SublSts[0];
            A1891SublAbr = P002S2_A1891SublAbr[0];
            A51SublCod = P002S2_A51SublCod[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002S2_A1892SublDsc[0], A1892SublDsc) == 0 ) )
            {
               BRK2S2 = false;
               A51SublCod = P002S2_A51SublCod[0];
               AV30count = (long)(AV30count+1);
               BRK2S2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1892SublDsc)) )
            {
               AV22Option = A1892SublDsc;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK2S2 )
            {
               BRK2S2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSUBLABROPTIONS' Routine */
         returnInSub = false;
         AV14TFSublAbr = AV18SearchTxt;
         AV15TFSublAbr_Sel = "";
         AV53Configuracion_sublineawwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV54Configuracion_sublineawwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV55Configuracion_sublineawwds_3_subldsc1 = AV38SublDsc1;
         AV56Configuracion_sublineawwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV57Configuracion_sublineawwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV58Configuracion_sublineawwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV59Configuracion_sublineawwds_7_subldsc2 = AV42SublDsc2;
         AV60Configuracion_sublineawwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV61Configuracion_sublineawwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV62Configuracion_sublineawwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV63Configuracion_sublineawwds_11_subldsc3 = AV46SublDsc3;
         AV64Configuracion_sublineawwds_12_tfsublcod = AV10TFSublCod;
         AV65Configuracion_sublineawwds_13_tfsublcod_to = AV11TFSublCod_To;
         AV66Configuracion_sublineawwds_14_tfsubldsc = AV12TFSublDsc;
         AV67Configuracion_sublineawwds_15_tfsubldsc_sel = AV13TFSublDsc_Sel;
         AV68Configuracion_sublineawwds_16_tfsublabr = AV14TFSublAbr;
         AV69Configuracion_sublineawwds_17_tfsublabr_sel = AV15TFSublAbr_Sel;
         AV70Configuracion_sublineawwds_18_tfsublsts_sels = AV48TFSublSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1893SublSts ,
                                              AV70Configuracion_sublineawwds_18_tfsublsts_sels ,
                                              AV53Configuracion_sublineawwds_1_dynamicfiltersselector1 ,
                                              AV54Configuracion_sublineawwds_2_dynamicfiltersoperator1 ,
                                              AV55Configuracion_sublineawwds_3_subldsc1 ,
                                              AV56Configuracion_sublineawwds_4_dynamicfiltersenabled2 ,
                                              AV57Configuracion_sublineawwds_5_dynamicfiltersselector2 ,
                                              AV58Configuracion_sublineawwds_6_dynamicfiltersoperator2 ,
                                              AV59Configuracion_sublineawwds_7_subldsc2 ,
                                              AV60Configuracion_sublineawwds_8_dynamicfiltersenabled3 ,
                                              AV61Configuracion_sublineawwds_9_dynamicfiltersselector3 ,
                                              AV62Configuracion_sublineawwds_10_dynamicfiltersoperator3 ,
                                              AV63Configuracion_sublineawwds_11_subldsc3 ,
                                              AV64Configuracion_sublineawwds_12_tfsublcod ,
                                              AV65Configuracion_sublineawwds_13_tfsublcod_to ,
                                              AV67Configuracion_sublineawwds_15_tfsubldsc_sel ,
                                              AV66Configuracion_sublineawwds_14_tfsubldsc ,
                                              AV69Configuracion_sublineawwds_17_tfsublabr_sel ,
                                              AV68Configuracion_sublineawwds_16_tfsublabr ,
                                              AV70Configuracion_sublineawwds_18_tfsublsts_sels.Count ,
                                              A1892SublDsc ,
                                              A51SublCod ,
                                              A1891SublAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV55Configuracion_sublineawwds_3_subldsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Configuracion_sublineawwds_3_subldsc1), 100, "%");
         lV55Configuracion_sublineawwds_3_subldsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Configuracion_sublineawwds_3_subldsc1), 100, "%");
         lV59Configuracion_sublineawwds_7_subldsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_sublineawwds_7_subldsc2), 100, "%");
         lV59Configuracion_sublineawwds_7_subldsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_sublineawwds_7_subldsc2), 100, "%");
         lV63Configuracion_sublineawwds_11_subldsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_sublineawwds_11_subldsc3), 100, "%");
         lV63Configuracion_sublineawwds_11_subldsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_sublineawwds_11_subldsc3), 100, "%");
         lV66Configuracion_sublineawwds_14_tfsubldsc = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_sublineawwds_14_tfsubldsc), 100, "%");
         lV68Configuracion_sublineawwds_16_tfsublabr = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_sublineawwds_16_tfsublabr), 5, "%");
         /* Using cursor P002S3 */
         pr_default.execute(1, new Object[] {lV55Configuracion_sublineawwds_3_subldsc1, lV55Configuracion_sublineawwds_3_subldsc1, lV59Configuracion_sublineawwds_7_subldsc2, lV59Configuracion_sublineawwds_7_subldsc2, lV63Configuracion_sublineawwds_11_subldsc3, lV63Configuracion_sublineawwds_11_subldsc3, AV64Configuracion_sublineawwds_12_tfsublcod, AV65Configuracion_sublineawwds_13_tfsublcod_to, lV66Configuracion_sublineawwds_14_tfsubldsc, AV67Configuracion_sublineawwds_15_tfsubldsc_sel, lV68Configuracion_sublineawwds_16_tfsublabr, AV69Configuracion_sublineawwds_17_tfsublabr_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2S4 = false;
            A1891SublAbr = P002S3_A1891SublAbr[0];
            A1893SublSts = P002S3_A1893SublSts[0];
            A51SublCod = P002S3_A51SublCod[0];
            A1892SublDsc = P002S3_A1892SublDsc[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002S3_A1891SublAbr[0], A1891SublAbr) == 0 ) )
            {
               BRK2S4 = false;
               A51SublCod = P002S3_A51SublCod[0];
               AV30count = (long)(AV30count+1);
               BRK2S4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1891SublAbr)) )
            {
               AV22Option = A1891SublAbr;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK2S4 )
            {
               BRK2S4 = true;
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
         AV12TFSublDsc = "";
         AV13TFSublDsc_Sel = "";
         AV14TFSublAbr = "";
         AV15TFSublAbr_Sel = "";
         AV47TFSublSts_SelsJson = "";
         AV48TFSublSts_Sels = new GxSimpleCollection<short>();
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38SublDsc1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42SublDsc2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46SublDsc3 = "";
         AV53Configuracion_sublineawwds_1_dynamicfiltersselector1 = "";
         AV55Configuracion_sublineawwds_3_subldsc1 = "";
         AV57Configuracion_sublineawwds_5_dynamicfiltersselector2 = "";
         AV59Configuracion_sublineawwds_7_subldsc2 = "";
         AV61Configuracion_sublineawwds_9_dynamicfiltersselector3 = "";
         AV63Configuracion_sublineawwds_11_subldsc3 = "";
         AV66Configuracion_sublineawwds_14_tfsubldsc = "";
         AV67Configuracion_sublineawwds_15_tfsubldsc_sel = "";
         AV68Configuracion_sublineawwds_16_tfsublabr = "";
         AV69Configuracion_sublineawwds_17_tfsublabr_sel = "";
         AV70Configuracion_sublineawwds_18_tfsublsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV55Configuracion_sublineawwds_3_subldsc1 = "";
         lV59Configuracion_sublineawwds_7_subldsc2 = "";
         lV63Configuracion_sublineawwds_11_subldsc3 = "";
         lV66Configuracion_sublineawwds_14_tfsubldsc = "";
         lV68Configuracion_sublineawwds_16_tfsublabr = "";
         A1892SublDsc = "";
         A1891SublAbr = "";
         P002S2_A1892SublDsc = new string[] {""} ;
         P002S2_A1893SublSts = new short[1] ;
         P002S2_A1891SublAbr = new string[] {""} ;
         P002S2_A51SublCod = new int[1] ;
         AV22Option = "";
         P002S3_A1891SublAbr = new string[] {""} ;
         P002S3_A1893SublSts = new short[1] ;
         P002S3_A51SublCod = new int[1] ;
         P002S3_A1892SublDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.sublineawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002S2_A1892SublDsc, P002S2_A1893SublSts, P002S2_A1891SublAbr, P002S2_A51SublCod
               }
               , new Object[] {
               P002S3_A1891SublAbr, P002S3_A1893SublSts, P002S3_A51SublCod, P002S3_A1892SublDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV54Configuracion_sublineawwds_2_dynamicfiltersoperator1 ;
      private short AV58Configuracion_sublineawwds_6_dynamicfiltersoperator2 ;
      private short AV62Configuracion_sublineawwds_10_dynamicfiltersoperator3 ;
      private short A1893SublSts ;
      private int AV51GXV1 ;
      private int AV10TFSublCod ;
      private int AV11TFSublCod_To ;
      private int AV64Configuracion_sublineawwds_12_tfsublcod ;
      private int AV65Configuracion_sublineawwds_13_tfsublcod_to ;
      private int AV70Configuracion_sublineawwds_18_tfsublsts_sels_Count ;
      private int A51SublCod ;
      private long AV30count ;
      private string AV12TFSublDsc ;
      private string AV13TFSublDsc_Sel ;
      private string AV14TFSublAbr ;
      private string AV15TFSublAbr_Sel ;
      private string AV38SublDsc1 ;
      private string AV42SublDsc2 ;
      private string AV46SublDsc3 ;
      private string AV55Configuracion_sublineawwds_3_subldsc1 ;
      private string AV59Configuracion_sublineawwds_7_subldsc2 ;
      private string AV63Configuracion_sublineawwds_11_subldsc3 ;
      private string AV66Configuracion_sublineawwds_14_tfsubldsc ;
      private string AV67Configuracion_sublineawwds_15_tfsubldsc_sel ;
      private string AV68Configuracion_sublineawwds_16_tfsublabr ;
      private string AV69Configuracion_sublineawwds_17_tfsublabr_sel ;
      private string scmdbuf ;
      private string lV55Configuracion_sublineawwds_3_subldsc1 ;
      private string lV59Configuracion_sublineawwds_7_subldsc2 ;
      private string lV63Configuracion_sublineawwds_11_subldsc3 ;
      private string lV66Configuracion_sublineawwds_14_tfsubldsc ;
      private string lV68Configuracion_sublineawwds_16_tfsublabr ;
      private string A1892SublDsc ;
      private string A1891SublAbr ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV56Configuracion_sublineawwds_4_dynamicfiltersenabled2 ;
      private bool AV60Configuracion_sublineawwds_8_dynamicfiltersenabled3 ;
      private bool BRK2S2 ;
      private bool BRK2S4 ;
      private string AV24OptionsJson ;
      private string AV27OptionsDescJson ;
      private string AV29OptionIndexesJson ;
      private string AV47TFSublSts_SelsJson ;
      private string AV20DDOName ;
      private string AV18SearchTxt ;
      private string AV19SearchTxtTo ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV53Configuracion_sublineawwds_1_dynamicfiltersselector1 ;
      private string AV57Configuracion_sublineawwds_5_dynamicfiltersselector2 ;
      private string AV61Configuracion_sublineawwds_9_dynamicfiltersselector3 ;
      private string AV22Option ;
      private GxSimpleCollection<short> AV48TFSublSts_Sels ;
      private GxSimpleCollection<short> AV70Configuracion_sublineawwds_18_tfsublsts_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002S2_A1892SublDsc ;
      private short[] P002S2_A1893SublSts ;
      private string[] P002S2_A1891SublAbr ;
      private int[] P002S2_A51SublCod ;
      private string[] P002S3_A1891SublAbr ;
      private short[] P002S3_A1893SublSts ;
      private int[] P002S3_A51SublCod ;
      private string[] P002S3_A1892SublDsc ;
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

   public class sublineawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002S2( IGxContext context ,
                                             short A1893SublSts ,
                                             GxSimpleCollection<short> AV70Configuracion_sublineawwds_18_tfsublsts_sels ,
                                             string AV53Configuracion_sublineawwds_1_dynamicfiltersselector1 ,
                                             short AV54Configuracion_sublineawwds_2_dynamicfiltersoperator1 ,
                                             string AV55Configuracion_sublineawwds_3_subldsc1 ,
                                             bool AV56Configuracion_sublineawwds_4_dynamicfiltersenabled2 ,
                                             string AV57Configuracion_sublineawwds_5_dynamicfiltersselector2 ,
                                             short AV58Configuracion_sublineawwds_6_dynamicfiltersoperator2 ,
                                             string AV59Configuracion_sublineawwds_7_subldsc2 ,
                                             bool AV60Configuracion_sublineawwds_8_dynamicfiltersenabled3 ,
                                             string AV61Configuracion_sublineawwds_9_dynamicfiltersselector3 ,
                                             short AV62Configuracion_sublineawwds_10_dynamicfiltersoperator3 ,
                                             string AV63Configuracion_sublineawwds_11_subldsc3 ,
                                             int AV64Configuracion_sublineawwds_12_tfsublcod ,
                                             int AV65Configuracion_sublineawwds_13_tfsublcod_to ,
                                             string AV67Configuracion_sublineawwds_15_tfsubldsc_sel ,
                                             string AV66Configuracion_sublineawwds_14_tfsubldsc ,
                                             string AV69Configuracion_sublineawwds_17_tfsublabr_sel ,
                                             string AV68Configuracion_sublineawwds_16_tfsublabr ,
                                             int AV70Configuracion_sublineawwds_18_tfsublsts_sels_Count ,
                                             string A1892SublDsc ,
                                             int A51SublCod ,
                                             string A1891SublAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [SublDsc], [SublSts], [SublAbr], [SublCod] FROM [CSUBLPROD]";
         if ( ( StringUtil.StrCmp(AV53Configuracion_sublineawwds_1_dynamicfiltersselector1, "SUBLDSC") == 0 ) && ( AV54Configuracion_sublineawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_sublineawwds_3_subldsc1)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV55Configuracion_sublineawwds_3_subldsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Configuracion_sublineawwds_1_dynamicfiltersselector1, "SUBLDSC") == 0 ) && ( AV54Configuracion_sublineawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_sublineawwds_3_subldsc1)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like '%' + @lV55Configuracion_sublineawwds_3_subldsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV56Configuracion_sublineawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_sublineawwds_5_dynamicfiltersselector2, "SUBLDSC") == 0 ) && ( AV58Configuracion_sublineawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_sublineawwds_7_subldsc2)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV59Configuracion_sublineawwds_7_subldsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV56Configuracion_sublineawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_sublineawwds_5_dynamicfiltersselector2, "SUBLDSC") == 0 ) && ( AV58Configuracion_sublineawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_sublineawwds_7_subldsc2)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like '%' + @lV59Configuracion_sublineawwds_7_subldsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV60Configuracion_sublineawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_sublineawwds_9_dynamicfiltersselector3, "SUBLDSC") == 0 ) && ( AV62Configuracion_sublineawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_sublineawwds_11_subldsc3)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV63Configuracion_sublineawwds_11_subldsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV60Configuracion_sublineawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_sublineawwds_9_dynamicfiltersselector3, "SUBLDSC") == 0 ) && ( AV62Configuracion_sublineawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_sublineawwds_11_subldsc3)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like '%' + @lV63Configuracion_sublineawwds_11_subldsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV64Configuracion_sublineawwds_12_tfsublcod) )
         {
            AddWhere(sWhereString, "([SublCod] >= @AV64Configuracion_sublineawwds_12_tfsublcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV65Configuracion_sublineawwds_13_tfsublcod_to) )
         {
            AddWhere(sWhereString, "([SublCod] <= @AV65Configuracion_sublineawwds_13_tfsublcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_sublineawwds_15_tfsubldsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_sublineawwds_14_tfsubldsc)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV66Configuracion_sublineawwds_14_tfsubldsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_sublineawwds_15_tfsubldsc_sel)) )
         {
            AddWhere(sWhereString, "([SublDsc] = @AV67Configuracion_sublineawwds_15_tfsubldsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_sublineawwds_17_tfsublabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_sublineawwds_16_tfsublabr)) ) )
         {
            AddWhere(sWhereString, "([SublAbr] like @lV68Configuracion_sublineawwds_16_tfsublabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_sublineawwds_17_tfsublabr_sel)) )
         {
            AddWhere(sWhereString, "([SublAbr] = @AV69Configuracion_sublineawwds_17_tfsublabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV70Configuracion_sublineawwds_18_tfsublsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV70Configuracion_sublineawwds_18_tfsublsts_sels, "[SublSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SublDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002S3( IGxContext context ,
                                             short A1893SublSts ,
                                             GxSimpleCollection<short> AV70Configuracion_sublineawwds_18_tfsublsts_sels ,
                                             string AV53Configuracion_sublineawwds_1_dynamicfiltersselector1 ,
                                             short AV54Configuracion_sublineawwds_2_dynamicfiltersoperator1 ,
                                             string AV55Configuracion_sublineawwds_3_subldsc1 ,
                                             bool AV56Configuracion_sublineawwds_4_dynamicfiltersenabled2 ,
                                             string AV57Configuracion_sublineawwds_5_dynamicfiltersselector2 ,
                                             short AV58Configuracion_sublineawwds_6_dynamicfiltersoperator2 ,
                                             string AV59Configuracion_sublineawwds_7_subldsc2 ,
                                             bool AV60Configuracion_sublineawwds_8_dynamicfiltersenabled3 ,
                                             string AV61Configuracion_sublineawwds_9_dynamicfiltersselector3 ,
                                             short AV62Configuracion_sublineawwds_10_dynamicfiltersoperator3 ,
                                             string AV63Configuracion_sublineawwds_11_subldsc3 ,
                                             int AV64Configuracion_sublineawwds_12_tfsublcod ,
                                             int AV65Configuracion_sublineawwds_13_tfsublcod_to ,
                                             string AV67Configuracion_sublineawwds_15_tfsubldsc_sel ,
                                             string AV66Configuracion_sublineawwds_14_tfsubldsc ,
                                             string AV69Configuracion_sublineawwds_17_tfsublabr_sel ,
                                             string AV68Configuracion_sublineawwds_16_tfsublabr ,
                                             int AV70Configuracion_sublineawwds_18_tfsublsts_sels_Count ,
                                             string A1892SublDsc ,
                                             int A51SublCod ,
                                             string A1891SublAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [SublAbr], [SublSts], [SublCod], [SublDsc] FROM [CSUBLPROD]";
         if ( ( StringUtil.StrCmp(AV53Configuracion_sublineawwds_1_dynamicfiltersselector1, "SUBLDSC") == 0 ) && ( AV54Configuracion_sublineawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_sublineawwds_3_subldsc1)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV55Configuracion_sublineawwds_3_subldsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Configuracion_sublineawwds_1_dynamicfiltersselector1, "SUBLDSC") == 0 ) && ( AV54Configuracion_sublineawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_sublineawwds_3_subldsc1)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like '%' + @lV55Configuracion_sublineawwds_3_subldsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV56Configuracion_sublineawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_sublineawwds_5_dynamicfiltersselector2, "SUBLDSC") == 0 ) && ( AV58Configuracion_sublineawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_sublineawwds_7_subldsc2)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV59Configuracion_sublineawwds_7_subldsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV56Configuracion_sublineawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_sublineawwds_5_dynamicfiltersselector2, "SUBLDSC") == 0 ) && ( AV58Configuracion_sublineawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_sublineawwds_7_subldsc2)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like '%' + @lV59Configuracion_sublineawwds_7_subldsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV60Configuracion_sublineawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_sublineawwds_9_dynamicfiltersselector3, "SUBLDSC") == 0 ) && ( AV62Configuracion_sublineawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_sublineawwds_11_subldsc3)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV63Configuracion_sublineawwds_11_subldsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV60Configuracion_sublineawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_sublineawwds_9_dynamicfiltersselector3, "SUBLDSC") == 0 ) && ( AV62Configuracion_sublineawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_sublineawwds_11_subldsc3)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like '%' + @lV63Configuracion_sublineawwds_11_subldsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV64Configuracion_sublineawwds_12_tfsublcod) )
         {
            AddWhere(sWhereString, "([SublCod] >= @AV64Configuracion_sublineawwds_12_tfsublcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV65Configuracion_sublineawwds_13_tfsublcod_to) )
         {
            AddWhere(sWhereString, "([SublCod] <= @AV65Configuracion_sublineawwds_13_tfsublcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_sublineawwds_15_tfsubldsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_sublineawwds_14_tfsubldsc)) ) )
         {
            AddWhere(sWhereString, "([SublDsc] like @lV66Configuracion_sublineawwds_14_tfsubldsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_sublineawwds_15_tfsubldsc_sel)) )
         {
            AddWhere(sWhereString, "([SublDsc] = @AV67Configuracion_sublineawwds_15_tfsubldsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_sublineawwds_17_tfsublabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_sublineawwds_16_tfsublabr)) ) )
         {
            AddWhere(sWhereString, "([SublAbr] like @lV68Configuracion_sublineawwds_16_tfsublabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_sublineawwds_17_tfsublabr_sel)) )
         {
            AddWhere(sWhereString, "([SublAbr] = @AV69Configuracion_sublineawwds_17_tfsublabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV70Configuracion_sublineawwds_18_tfsublsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV70Configuracion_sublineawwds_18_tfsublsts_sels, "[SublSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SublAbr]";
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
                     return conditional_P002S2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] );
               case 1 :
                     return conditional_P002S3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP002S2;
          prmP002S2 = new Object[] {
          new ParDef("@lV55Configuracion_sublineawwds_3_subldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV55Configuracion_sublineawwds_3_subldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_sublineawwds_7_subldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_sublineawwds_7_subldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_sublineawwds_11_subldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_sublineawwds_11_subldsc3",GXType.NChar,100,0) ,
          new ParDef("@AV64Configuracion_sublineawwds_12_tfsublcod",GXType.Int32,6,0) ,
          new ParDef("@AV65Configuracion_sublineawwds_13_tfsublcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV66Configuracion_sublineawwds_14_tfsubldsc",GXType.NChar,100,0) ,
          new ParDef("@AV67Configuracion_sublineawwds_15_tfsubldsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_sublineawwds_16_tfsublabr",GXType.NChar,5,0) ,
          new ParDef("@AV69Configuracion_sublineawwds_17_tfsublabr_sel",GXType.NChar,5,0)
          };
          Object[] prmP002S3;
          prmP002S3 = new Object[] {
          new ParDef("@lV55Configuracion_sublineawwds_3_subldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV55Configuracion_sublineawwds_3_subldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_sublineawwds_7_subldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_sublineawwds_7_subldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_sublineawwds_11_subldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_sublineawwds_11_subldsc3",GXType.NChar,100,0) ,
          new ParDef("@AV64Configuracion_sublineawwds_12_tfsublcod",GXType.Int32,6,0) ,
          new ParDef("@AV65Configuracion_sublineawwds_13_tfsublcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV66Configuracion_sublineawwds_14_tfsubldsc",GXType.NChar,100,0) ,
          new ParDef("@AV67Configuracion_sublineawwds_15_tfsubldsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_sublineawwds_16_tfsublabr",GXType.NChar,5,0) ,
          new ParDef("@AV69Configuracion_sublineawwds_17_tfsublabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002S2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002S3,100, GxCacheFrequency.OFF ,true,false )
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
