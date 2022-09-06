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
   public class familiawwgetfilterdata : GXProcedure
   {
      public familiawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public familiawwgetfilterdata( IGxContext context )
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
         familiawwgetfilterdata objfamiliawwgetfilterdata;
         objfamiliawwgetfilterdata = new familiawwgetfilterdata();
         objfamiliawwgetfilterdata.AV20DDOName = aP0_DDOName;
         objfamiliawwgetfilterdata.AV18SearchTxt = aP1_SearchTxt;
         objfamiliawwgetfilterdata.AV19SearchTxtTo = aP2_SearchTxtTo;
         objfamiliawwgetfilterdata.AV24OptionsJson = "" ;
         objfamiliawwgetfilterdata.AV27OptionsDescJson = "" ;
         objfamiliawwgetfilterdata.AV29OptionIndexesJson = "" ;
         objfamiliawwgetfilterdata.context.SetSubmitInitialConfig(context);
         objfamiliawwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objfamiliawwgetfilterdata);
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((familiawwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_FAMDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADFAMDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_FAMABR") == 0 )
         {
            /* Execute user subroutine: 'LOADFAMABROPTIONS' */
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
         if ( StringUtil.StrCmp(AV31Session.Get("Configuracion.FamiliaWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.FamiliaWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Configuracion.FamiliaWWGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFFAMCOD") == 0 )
            {
               AV10TFFamCod = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV11TFFamCod_To = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFFAMDSC") == 0 )
            {
               AV12TFFamDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFFAMDSC_SEL") == 0 )
            {
               AV13TFFamDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFFAMABR") == 0 )
            {
               AV14TFFamAbr = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFFAMABR_SEL") == 0 )
            {
               AV15TFFamAbr_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFFAMSTS_SEL") == 0 )
            {
               AV16TFFamSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV17TFFamSts_Sels.FromJSonString(AV16TFFamSts_SelsJson, null);
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "FAMDSC") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV38FamDsc1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "FAMDSC") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV42FamDsc2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "FAMDSC") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV46FamDsc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADFAMDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFFamDsc = AV18SearchTxt;
         AV13TFFamDsc_Sel = "";
         AV51Configuracion_familiawwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV52Configuracion_familiawwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV53Configuracion_familiawwds_3_famdsc1 = AV38FamDsc1;
         AV54Configuracion_familiawwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV55Configuracion_familiawwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV56Configuracion_familiawwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV57Configuracion_familiawwds_7_famdsc2 = AV42FamDsc2;
         AV58Configuracion_familiawwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV59Configuracion_familiawwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV60Configuracion_familiawwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV61Configuracion_familiawwds_11_famdsc3 = AV46FamDsc3;
         AV62Configuracion_familiawwds_12_tffamcod = AV10TFFamCod;
         AV63Configuracion_familiawwds_13_tffamcod_to = AV11TFFamCod_To;
         AV64Configuracion_familiawwds_14_tffamdsc = AV12TFFamDsc;
         AV65Configuracion_familiawwds_15_tffamdsc_sel = AV13TFFamDsc_Sel;
         AV66Configuracion_familiawwds_16_tffamabr = AV14TFFamAbr;
         AV67Configuracion_familiawwds_17_tffamabr_sel = AV15TFFamAbr_Sel;
         AV68Configuracion_familiawwds_18_tffamsts_sels = AV17TFFamSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A979FamSts ,
                                              AV68Configuracion_familiawwds_18_tffamsts_sels ,
                                              AV51Configuracion_familiawwds_1_dynamicfiltersselector1 ,
                                              AV52Configuracion_familiawwds_2_dynamicfiltersoperator1 ,
                                              AV53Configuracion_familiawwds_3_famdsc1 ,
                                              AV54Configuracion_familiawwds_4_dynamicfiltersenabled2 ,
                                              AV55Configuracion_familiawwds_5_dynamicfiltersselector2 ,
                                              AV56Configuracion_familiawwds_6_dynamicfiltersoperator2 ,
                                              AV57Configuracion_familiawwds_7_famdsc2 ,
                                              AV58Configuracion_familiawwds_8_dynamicfiltersenabled3 ,
                                              AV59Configuracion_familiawwds_9_dynamicfiltersselector3 ,
                                              AV60Configuracion_familiawwds_10_dynamicfiltersoperator3 ,
                                              AV61Configuracion_familiawwds_11_famdsc3 ,
                                              AV62Configuracion_familiawwds_12_tffamcod ,
                                              AV63Configuracion_familiawwds_13_tffamcod_to ,
                                              AV65Configuracion_familiawwds_15_tffamdsc_sel ,
                                              AV64Configuracion_familiawwds_14_tffamdsc ,
                                              AV67Configuracion_familiawwds_17_tffamabr_sel ,
                                              AV66Configuracion_familiawwds_16_tffamabr ,
                                              AV68Configuracion_familiawwds_18_tffamsts_sels.Count ,
                                              A977FamDsc ,
                                              A50FamCod ,
                                              A976FamAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV53Configuracion_familiawwds_3_famdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_familiawwds_3_famdsc1), 100, "%");
         lV53Configuracion_familiawwds_3_famdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_familiawwds_3_famdsc1), 100, "%");
         lV57Configuracion_familiawwds_7_famdsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_familiawwds_7_famdsc2), 100, "%");
         lV57Configuracion_familiawwds_7_famdsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_familiawwds_7_famdsc2), 100, "%");
         lV61Configuracion_familiawwds_11_famdsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_familiawwds_11_famdsc3), 100, "%");
         lV61Configuracion_familiawwds_11_famdsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_familiawwds_11_famdsc3), 100, "%");
         lV64Configuracion_familiawwds_14_tffamdsc = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_familiawwds_14_tffamdsc), 100, "%");
         lV66Configuracion_familiawwds_16_tffamabr = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_familiawwds_16_tffamabr), 5, "%");
         /* Using cursor P002Y2 */
         pr_default.execute(0, new Object[] {lV53Configuracion_familiawwds_3_famdsc1, lV53Configuracion_familiawwds_3_famdsc1, lV57Configuracion_familiawwds_7_famdsc2, lV57Configuracion_familiawwds_7_famdsc2, lV61Configuracion_familiawwds_11_famdsc3, lV61Configuracion_familiawwds_11_famdsc3, AV62Configuracion_familiawwds_12_tffamcod, AV63Configuracion_familiawwds_13_tffamcod_to, lV64Configuracion_familiawwds_14_tffamdsc, AV65Configuracion_familiawwds_15_tffamdsc_sel, lV66Configuracion_familiawwds_16_tffamabr, AV67Configuracion_familiawwds_17_tffamabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2Y2 = false;
            A977FamDsc = P002Y2_A977FamDsc[0];
            A979FamSts = P002Y2_A979FamSts[0];
            A976FamAbr = P002Y2_A976FamAbr[0];
            A50FamCod = P002Y2_A50FamCod[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002Y2_A977FamDsc[0], A977FamDsc) == 0 ) )
            {
               BRK2Y2 = false;
               A50FamCod = P002Y2_A50FamCod[0];
               AV30count = (long)(AV30count+1);
               BRK2Y2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A977FamDsc)) )
            {
               AV22Option = A977FamDsc;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK2Y2 )
            {
               BRK2Y2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADFAMABROPTIONS' Routine */
         returnInSub = false;
         AV14TFFamAbr = AV18SearchTxt;
         AV15TFFamAbr_Sel = "";
         AV51Configuracion_familiawwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV52Configuracion_familiawwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV53Configuracion_familiawwds_3_famdsc1 = AV38FamDsc1;
         AV54Configuracion_familiawwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV55Configuracion_familiawwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV56Configuracion_familiawwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV57Configuracion_familiawwds_7_famdsc2 = AV42FamDsc2;
         AV58Configuracion_familiawwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV59Configuracion_familiawwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV60Configuracion_familiawwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV61Configuracion_familiawwds_11_famdsc3 = AV46FamDsc3;
         AV62Configuracion_familiawwds_12_tffamcod = AV10TFFamCod;
         AV63Configuracion_familiawwds_13_tffamcod_to = AV11TFFamCod_To;
         AV64Configuracion_familiawwds_14_tffamdsc = AV12TFFamDsc;
         AV65Configuracion_familiawwds_15_tffamdsc_sel = AV13TFFamDsc_Sel;
         AV66Configuracion_familiawwds_16_tffamabr = AV14TFFamAbr;
         AV67Configuracion_familiawwds_17_tffamabr_sel = AV15TFFamAbr_Sel;
         AV68Configuracion_familiawwds_18_tffamsts_sels = AV17TFFamSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A979FamSts ,
                                              AV68Configuracion_familiawwds_18_tffamsts_sels ,
                                              AV51Configuracion_familiawwds_1_dynamicfiltersselector1 ,
                                              AV52Configuracion_familiawwds_2_dynamicfiltersoperator1 ,
                                              AV53Configuracion_familiawwds_3_famdsc1 ,
                                              AV54Configuracion_familiawwds_4_dynamicfiltersenabled2 ,
                                              AV55Configuracion_familiawwds_5_dynamicfiltersselector2 ,
                                              AV56Configuracion_familiawwds_6_dynamicfiltersoperator2 ,
                                              AV57Configuracion_familiawwds_7_famdsc2 ,
                                              AV58Configuracion_familiawwds_8_dynamicfiltersenabled3 ,
                                              AV59Configuracion_familiawwds_9_dynamicfiltersselector3 ,
                                              AV60Configuracion_familiawwds_10_dynamicfiltersoperator3 ,
                                              AV61Configuracion_familiawwds_11_famdsc3 ,
                                              AV62Configuracion_familiawwds_12_tffamcod ,
                                              AV63Configuracion_familiawwds_13_tffamcod_to ,
                                              AV65Configuracion_familiawwds_15_tffamdsc_sel ,
                                              AV64Configuracion_familiawwds_14_tffamdsc ,
                                              AV67Configuracion_familiawwds_17_tffamabr_sel ,
                                              AV66Configuracion_familiawwds_16_tffamabr ,
                                              AV68Configuracion_familiawwds_18_tffamsts_sels.Count ,
                                              A977FamDsc ,
                                              A50FamCod ,
                                              A976FamAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV53Configuracion_familiawwds_3_famdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_familiawwds_3_famdsc1), 100, "%");
         lV53Configuracion_familiawwds_3_famdsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_familiawwds_3_famdsc1), 100, "%");
         lV57Configuracion_familiawwds_7_famdsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_familiawwds_7_famdsc2), 100, "%");
         lV57Configuracion_familiawwds_7_famdsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_familiawwds_7_famdsc2), 100, "%");
         lV61Configuracion_familiawwds_11_famdsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_familiawwds_11_famdsc3), 100, "%");
         lV61Configuracion_familiawwds_11_famdsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_familiawwds_11_famdsc3), 100, "%");
         lV64Configuracion_familiawwds_14_tffamdsc = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_familiawwds_14_tffamdsc), 100, "%");
         lV66Configuracion_familiawwds_16_tffamabr = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_familiawwds_16_tffamabr), 5, "%");
         /* Using cursor P002Y3 */
         pr_default.execute(1, new Object[] {lV53Configuracion_familiawwds_3_famdsc1, lV53Configuracion_familiawwds_3_famdsc1, lV57Configuracion_familiawwds_7_famdsc2, lV57Configuracion_familiawwds_7_famdsc2, lV61Configuracion_familiawwds_11_famdsc3, lV61Configuracion_familiawwds_11_famdsc3, AV62Configuracion_familiawwds_12_tffamcod, AV63Configuracion_familiawwds_13_tffamcod_to, lV64Configuracion_familiawwds_14_tffamdsc, AV65Configuracion_familiawwds_15_tffamdsc_sel, lV66Configuracion_familiawwds_16_tffamabr, AV67Configuracion_familiawwds_17_tffamabr_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2Y4 = false;
            A976FamAbr = P002Y3_A976FamAbr[0];
            A979FamSts = P002Y3_A979FamSts[0];
            A50FamCod = P002Y3_A50FamCod[0];
            A977FamDsc = P002Y3_A977FamDsc[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002Y3_A976FamAbr[0], A976FamAbr) == 0 ) )
            {
               BRK2Y4 = false;
               A50FamCod = P002Y3_A50FamCod[0];
               AV30count = (long)(AV30count+1);
               BRK2Y4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A976FamAbr)) )
            {
               AV22Option = A976FamAbr;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK2Y4 )
            {
               BRK2Y4 = true;
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
         AV12TFFamDsc = "";
         AV13TFFamDsc_Sel = "";
         AV14TFFamAbr = "";
         AV15TFFamAbr_Sel = "";
         AV16TFFamSts_SelsJson = "";
         AV17TFFamSts_Sels = new GxSimpleCollection<short>();
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38FamDsc1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42FamDsc2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46FamDsc3 = "";
         AV51Configuracion_familiawwds_1_dynamicfiltersselector1 = "";
         AV53Configuracion_familiawwds_3_famdsc1 = "";
         AV55Configuracion_familiawwds_5_dynamicfiltersselector2 = "";
         AV57Configuracion_familiawwds_7_famdsc2 = "";
         AV59Configuracion_familiawwds_9_dynamicfiltersselector3 = "";
         AV61Configuracion_familiawwds_11_famdsc3 = "";
         AV64Configuracion_familiawwds_14_tffamdsc = "";
         AV65Configuracion_familiawwds_15_tffamdsc_sel = "";
         AV66Configuracion_familiawwds_16_tffamabr = "";
         AV67Configuracion_familiawwds_17_tffamabr_sel = "";
         AV68Configuracion_familiawwds_18_tffamsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV53Configuracion_familiawwds_3_famdsc1 = "";
         lV57Configuracion_familiawwds_7_famdsc2 = "";
         lV61Configuracion_familiawwds_11_famdsc3 = "";
         lV64Configuracion_familiawwds_14_tffamdsc = "";
         lV66Configuracion_familiawwds_16_tffamabr = "";
         A977FamDsc = "";
         A976FamAbr = "";
         P002Y2_A977FamDsc = new string[] {""} ;
         P002Y2_A979FamSts = new short[1] ;
         P002Y2_A976FamAbr = new string[] {""} ;
         P002Y2_A50FamCod = new int[1] ;
         AV22Option = "";
         P002Y3_A976FamAbr = new string[] {""} ;
         P002Y3_A979FamSts = new short[1] ;
         P002Y3_A50FamCod = new int[1] ;
         P002Y3_A977FamDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.familiawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002Y2_A977FamDsc, P002Y2_A979FamSts, P002Y2_A976FamAbr, P002Y2_A50FamCod
               }
               , new Object[] {
               P002Y3_A976FamAbr, P002Y3_A979FamSts, P002Y3_A50FamCod, P002Y3_A977FamDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV52Configuracion_familiawwds_2_dynamicfiltersoperator1 ;
      private short AV56Configuracion_familiawwds_6_dynamicfiltersoperator2 ;
      private short AV60Configuracion_familiawwds_10_dynamicfiltersoperator3 ;
      private short A979FamSts ;
      private int AV49GXV1 ;
      private int AV10TFFamCod ;
      private int AV11TFFamCod_To ;
      private int AV62Configuracion_familiawwds_12_tffamcod ;
      private int AV63Configuracion_familiawwds_13_tffamcod_to ;
      private int AV68Configuracion_familiawwds_18_tffamsts_sels_Count ;
      private int A50FamCod ;
      private long AV30count ;
      private string AV12TFFamDsc ;
      private string AV13TFFamDsc_Sel ;
      private string AV14TFFamAbr ;
      private string AV15TFFamAbr_Sel ;
      private string AV38FamDsc1 ;
      private string AV42FamDsc2 ;
      private string AV46FamDsc3 ;
      private string AV53Configuracion_familiawwds_3_famdsc1 ;
      private string AV57Configuracion_familiawwds_7_famdsc2 ;
      private string AV61Configuracion_familiawwds_11_famdsc3 ;
      private string AV64Configuracion_familiawwds_14_tffamdsc ;
      private string AV65Configuracion_familiawwds_15_tffamdsc_sel ;
      private string AV66Configuracion_familiawwds_16_tffamabr ;
      private string AV67Configuracion_familiawwds_17_tffamabr_sel ;
      private string scmdbuf ;
      private string lV53Configuracion_familiawwds_3_famdsc1 ;
      private string lV57Configuracion_familiawwds_7_famdsc2 ;
      private string lV61Configuracion_familiawwds_11_famdsc3 ;
      private string lV64Configuracion_familiawwds_14_tffamdsc ;
      private string lV66Configuracion_familiawwds_16_tffamabr ;
      private string A977FamDsc ;
      private string A976FamAbr ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV54Configuracion_familiawwds_4_dynamicfiltersenabled2 ;
      private bool AV58Configuracion_familiawwds_8_dynamicfiltersenabled3 ;
      private bool BRK2Y2 ;
      private bool BRK2Y4 ;
      private string AV24OptionsJson ;
      private string AV27OptionsDescJson ;
      private string AV29OptionIndexesJson ;
      private string AV16TFFamSts_SelsJson ;
      private string AV20DDOName ;
      private string AV18SearchTxt ;
      private string AV19SearchTxtTo ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV51Configuracion_familiawwds_1_dynamicfiltersselector1 ;
      private string AV55Configuracion_familiawwds_5_dynamicfiltersselector2 ;
      private string AV59Configuracion_familiawwds_9_dynamicfiltersselector3 ;
      private string AV22Option ;
      private GxSimpleCollection<short> AV17TFFamSts_Sels ;
      private GxSimpleCollection<short> AV68Configuracion_familiawwds_18_tffamsts_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002Y2_A977FamDsc ;
      private short[] P002Y2_A979FamSts ;
      private string[] P002Y2_A976FamAbr ;
      private int[] P002Y2_A50FamCod ;
      private string[] P002Y3_A976FamAbr ;
      private short[] P002Y3_A979FamSts ;
      private int[] P002Y3_A50FamCod ;
      private string[] P002Y3_A977FamDsc ;
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

   public class familiawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002Y2( IGxContext context ,
                                             short A979FamSts ,
                                             GxSimpleCollection<short> AV68Configuracion_familiawwds_18_tffamsts_sels ,
                                             string AV51Configuracion_familiawwds_1_dynamicfiltersselector1 ,
                                             short AV52Configuracion_familiawwds_2_dynamicfiltersoperator1 ,
                                             string AV53Configuracion_familiawwds_3_famdsc1 ,
                                             bool AV54Configuracion_familiawwds_4_dynamicfiltersenabled2 ,
                                             string AV55Configuracion_familiawwds_5_dynamicfiltersselector2 ,
                                             short AV56Configuracion_familiawwds_6_dynamicfiltersoperator2 ,
                                             string AV57Configuracion_familiawwds_7_famdsc2 ,
                                             bool AV58Configuracion_familiawwds_8_dynamicfiltersenabled3 ,
                                             string AV59Configuracion_familiawwds_9_dynamicfiltersselector3 ,
                                             short AV60Configuracion_familiawwds_10_dynamicfiltersoperator3 ,
                                             string AV61Configuracion_familiawwds_11_famdsc3 ,
                                             int AV62Configuracion_familiawwds_12_tffamcod ,
                                             int AV63Configuracion_familiawwds_13_tffamcod_to ,
                                             string AV65Configuracion_familiawwds_15_tffamdsc_sel ,
                                             string AV64Configuracion_familiawwds_14_tffamdsc ,
                                             string AV67Configuracion_familiawwds_17_tffamabr_sel ,
                                             string AV66Configuracion_familiawwds_16_tffamabr ,
                                             int AV68Configuracion_familiawwds_18_tffamsts_sels_Count ,
                                             string A977FamDsc ,
                                             int A50FamCod ,
                                             string A976FamAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [FamDsc], [FamSts], [FamAbr], [FamCod] FROM [CFAMILIA]";
         if ( ( StringUtil.StrCmp(AV51Configuracion_familiawwds_1_dynamicfiltersselector1, "FAMDSC") == 0 ) && ( AV52Configuracion_familiawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_familiawwds_3_famdsc1)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV53Configuracion_familiawwds_3_famdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Configuracion_familiawwds_1_dynamicfiltersselector1, "FAMDSC") == 0 ) && ( AV52Configuracion_familiawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_familiawwds_3_famdsc1)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like '%' + @lV53Configuracion_familiawwds_3_famdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV54Configuracion_familiawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_familiawwds_5_dynamicfiltersselector2, "FAMDSC") == 0 ) && ( AV56Configuracion_familiawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_familiawwds_7_famdsc2)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV57Configuracion_familiawwds_7_famdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV54Configuracion_familiawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_familiawwds_5_dynamicfiltersselector2, "FAMDSC") == 0 ) && ( AV56Configuracion_familiawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_familiawwds_7_famdsc2)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like '%' + @lV57Configuracion_familiawwds_7_famdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV58Configuracion_familiawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_familiawwds_9_dynamicfiltersselector3, "FAMDSC") == 0 ) && ( AV60Configuracion_familiawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_familiawwds_11_famdsc3)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV61Configuracion_familiawwds_11_famdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV58Configuracion_familiawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_familiawwds_9_dynamicfiltersselector3, "FAMDSC") == 0 ) && ( AV60Configuracion_familiawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_familiawwds_11_famdsc3)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like '%' + @lV61Configuracion_familiawwds_11_famdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV62Configuracion_familiawwds_12_tffamcod) )
         {
            AddWhere(sWhereString, "([FamCod] >= @AV62Configuracion_familiawwds_12_tffamcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV63Configuracion_familiawwds_13_tffamcod_to) )
         {
            AddWhere(sWhereString, "([FamCod] <= @AV63Configuracion_familiawwds_13_tffamcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_familiawwds_15_tffamdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_familiawwds_14_tffamdsc)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV64Configuracion_familiawwds_14_tffamdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_familiawwds_15_tffamdsc_sel)) )
         {
            AddWhere(sWhereString, "([FamDsc] = @AV65Configuracion_familiawwds_15_tffamdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_familiawwds_17_tffamabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_familiawwds_16_tffamabr)) ) )
         {
            AddWhere(sWhereString, "([FamAbr] like @lV66Configuracion_familiawwds_16_tffamabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_familiawwds_17_tffamabr_sel)) )
         {
            AddWhere(sWhereString, "([FamAbr] = @AV67Configuracion_familiawwds_17_tffamabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV68Configuracion_familiawwds_18_tffamsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Configuracion_familiawwds_18_tffamsts_sels, "[FamSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [FamDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002Y3( IGxContext context ,
                                             short A979FamSts ,
                                             GxSimpleCollection<short> AV68Configuracion_familiawwds_18_tffamsts_sels ,
                                             string AV51Configuracion_familiawwds_1_dynamicfiltersselector1 ,
                                             short AV52Configuracion_familiawwds_2_dynamicfiltersoperator1 ,
                                             string AV53Configuracion_familiawwds_3_famdsc1 ,
                                             bool AV54Configuracion_familiawwds_4_dynamicfiltersenabled2 ,
                                             string AV55Configuracion_familiawwds_5_dynamicfiltersselector2 ,
                                             short AV56Configuracion_familiawwds_6_dynamicfiltersoperator2 ,
                                             string AV57Configuracion_familiawwds_7_famdsc2 ,
                                             bool AV58Configuracion_familiawwds_8_dynamicfiltersenabled3 ,
                                             string AV59Configuracion_familiawwds_9_dynamicfiltersselector3 ,
                                             short AV60Configuracion_familiawwds_10_dynamicfiltersoperator3 ,
                                             string AV61Configuracion_familiawwds_11_famdsc3 ,
                                             int AV62Configuracion_familiawwds_12_tffamcod ,
                                             int AV63Configuracion_familiawwds_13_tffamcod_to ,
                                             string AV65Configuracion_familiawwds_15_tffamdsc_sel ,
                                             string AV64Configuracion_familiawwds_14_tffamdsc ,
                                             string AV67Configuracion_familiawwds_17_tffamabr_sel ,
                                             string AV66Configuracion_familiawwds_16_tffamabr ,
                                             int AV68Configuracion_familiawwds_18_tffamsts_sels_Count ,
                                             string A977FamDsc ,
                                             int A50FamCod ,
                                             string A976FamAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [FamAbr], [FamSts], [FamCod], [FamDsc] FROM [CFAMILIA]";
         if ( ( StringUtil.StrCmp(AV51Configuracion_familiawwds_1_dynamicfiltersselector1, "FAMDSC") == 0 ) && ( AV52Configuracion_familiawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_familiawwds_3_famdsc1)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV53Configuracion_familiawwds_3_famdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Configuracion_familiawwds_1_dynamicfiltersselector1, "FAMDSC") == 0 ) && ( AV52Configuracion_familiawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_familiawwds_3_famdsc1)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like '%' + @lV53Configuracion_familiawwds_3_famdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV54Configuracion_familiawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_familiawwds_5_dynamicfiltersselector2, "FAMDSC") == 0 ) && ( AV56Configuracion_familiawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_familiawwds_7_famdsc2)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV57Configuracion_familiawwds_7_famdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV54Configuracion_familiawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_familiawwds_5_dynamicfiltersselector2, "FAMDSC") == 0 ) && ( AV56Configuracion_familiawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_familiawwds_7_famdsc2)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like '%' + @lV57Configuracion_familiawwds_7_famdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV58Configuracion_familiawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_familiawwds_9_dynamicfiltersselector3, "FAMDSC") == 0 ) && ( AV60Configuracion_familiawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_familiawwds_11_famdsc3)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV61Configuracion_familiawwds_11_famdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV58Configuracion_familiawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_familiawwds_9_dynamicfiltersselector3, "FAMDSC") == 0 ) && ( AV60Configuracion_familiawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_familiawwds_11_famdsc3)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like '%' + @lV61Configuracion_familiawwds_11_famdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV62Configuracion_familiawwds_12_tffamcod) )
         {
            AddWhere(sWhereString, "([FamCod] >= @AV62Configuracion_familiawwds_12_tffamcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV63Configuracion_familiawwds_13_tffamcod_to) )
         {
            AddWhere(sWhereString, "([FamCod] <= @AV63Configuracion_familiawwds_13_tffamcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_familiawwds_15_tffamdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_familiawwds_14_tffamdsc)) ) )
         {
            AddWhere(sWhereString, "([FamDsc] like @lV64Configuracion_familiawwds_14_tffamdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_familiawwds_15_tffamdsc_sel)) )
         {
            AddWhere(sWhereString, "([FamDsc] = @AV65Configuracion_familiawwds_15_tffamdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_familiawwds_17_tffamabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_familiawwds_16_tffamabr)) ) )
         {
            AddWhere(sWhereString, "([FamAbr] like @lV66Configuracion_familiawwds_16_tffamabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_familiawwds_17_tffamabr_sel)) )
         {
            AddWhere(sWhereString, "([FamAbr] = @AV67Configuracion_familiawwds_17_tffamabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV68Configuracion_familiawwds_18_tffamsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Configuracion_familiawwds_18_tffamsts_sels, "[FamSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [FamAbr]";
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
                     return conditional_P002Y2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] );
               case 1 :
                     return conditional_P002Y3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP002Y2;
          prmP002Y2 = new Object[] {
          new ParDef("@lV53Configuracion_familiawwds_3_famdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Configuracion_familiawwds_3_famdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_familiawwds_7_famdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_familiawwds_7_famdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_familiawwds_11_famdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_familiawwds_11_famdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV62Configuracion_familiawwds_12_tffamcod",GXType.Int32,6,0) ,
          new ParDef("@AV63Configuracion_familiawwds_13_tffamcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Configuracion_familiawwds_14_tffamdsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Configuracion_familiawwds_15_tffamdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_familiawwds_16_tffamabr",GXType.NChar,5,0) ,
          new ParDef("@AV67Configuracion_familiawwds_17_tffamabr_sel",GXType.NChar,5,0)
          };
          Object[] prmP002Y3;
          prmP002Y3 = new Object[] {
          new ParDef("@lV53Configuracion_familiawwds_3_famdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Configuracion_familiawwds_3_famdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_familiawwds_7_famdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_familiawwds_7_famdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_familiawwds_11_famdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_familiawwds_11_famdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV62Configuracion_familiawwds_12_tffamcod",GXType.Int32,6,0) ,
          new ParDef("@AV63Configuracion_familiawwds_13_tffamcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Configuracion_familiawwds_14_tffamdsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Configuracion_familiawwds_15_tffamdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_familiawwds_16_tffamabr",GXType.NChar,5,0) ,
          new ParDef("@AV67Configuracion_familiawwds_17_tffamabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Y2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Y3,100, GxCacheFrequency.OFF ,true,false )
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
