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
   public class empresastransporteswwgetfilterdata : GXProcedure
   {
      public empresastransporteswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public empresastransporteswwgetfilterdata( IGxContext context )
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
         empresastransporteswwgetfilterdata objempresastransporteswwgetfilterdata;
         objempresastransporteswwgetfilterdata = new empresastransporteswwgetfilterdata();
         objempresastransporteswwgetfilterdata.AV22DDOName = aP0_DDOName;
         objempresastransporteswwgetfilterdata.AV20SearchTxt = aP1_SearchTxt;
         objempresastransporteswwgetfilterdata.AV21SearchTxtTo = aP2_SearchTxtTo;
         objempresastransporteswwgetfilterdata.AV26OptionsJson = "" ;
         objempresastransporteswwgetfilterdata.AV29OptionsDescJson = "" ;
         objempresastransporteswwgetfilterdata.AV31OptionIndexesJson = "" ;
         objempresastransporteswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objempresastransporteswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objempresastransporteswwgetfilterdata);
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((empresastransporteswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_EMPTDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPTDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_EMPTDIR") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPTDIROPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_EMPTRUC") == 0 )
         {
            /* Execute user subroutine: 'LOADEMPTRUCOPTIONS' */
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
         if ( StringUtil.StrCmp(AV33Session.Get("Configuracion.EmpresasTransportesWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.EmpresasTransportesWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Configuracion.EmpresasTransportesWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFEMPTCOD") == 0 )
            {
               AV10TFEmpTCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV11TFEmpTCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFEMPTDSC") == 0 )
            {
               AV12TFEmpTDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFEMPTDSC_SEL") == 0 )
            {
               AV13TFEmpTDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFEMPTDIR") == 0 )
            {
               AV14TFEmptDir = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFEMPTDIR_SEL") == 0 )
            {
               AV15TFEmptDir_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFEMPTRUC") == 0 )
            {
               AV16TFEmpTRuc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFEMPTRUC_SEL") == 0 )
            {
               AV17TFEmpTRuc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFEMPTSTS_SEL") == 0 )
            {
               AV18TFEmpTSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV19TFEmpTSts_Sels.FromJSonString(AV18TFEmpTSts_SelsJson, null);
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "EMPTDSC") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV40EmpTDsc1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "EMPTDSC") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV44EmpTDsc2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "EMPTDSC") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV48EmpTDsc3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADEMPTDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFEmpTDsc = AV20SearchTxt;
         AV13TFEmpTDsc_Sel = "";
         AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV55Configuracion_empresastransporteswwds_3_emptdsc1 = AV40EmpTDsc1;
         AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV59Configuracion_empresastransporteswwds_7_emptdsc2 = AV44EmpTDsc2;
         AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV63Configuracion_empresastransporteswwds_11_emptdsc3 = AV48EmpTDsc3;
         AV64Configuracion_empresastransporteswwds_12_tfemptcod = AV10TFEmpTCod;
         AV65Configuracion_empresastransporteswwds_13_tfemptcod_to = AV11TFEmpTCod_To;
         AV66Configuracion_empresastransporteswwds_14_tfemptdsc = AV12TFEmpTDsc;
         AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel = AV13TFEmpTDsc_Sel;
         AV68Configuracion_empresastransporteswwds_16_tfemptdir = AV14TFEmptDir;
         AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel = AV15TFEmptDir_Sel;
         AV70Configuracion_empresastransporteswwds_18_tfemptruc = AV16TFEmpTRuc;
         AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel = AV17TFEmpTRuc_Sel;
         AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels = AV19TFEmpTSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A967EmpTSts ,
                                              AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels ,
                                              AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 ,
                                              AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 ,
                                              AV55Configuracion_empresastransporteswwds_3_emptdsc1 ,
                                              AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 ,
                                              AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 ,
                                              AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 ,
                                              AV59Configuracion_empresastransporteswwds_7_emptdsc2 ,
                                              AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 ,
                                              AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 ,
                                              AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 ,
                                              AV63Configuracion_empresastransporteswwds_11_emptdsc3 ,
                                              AV64Configuracion_empresastransporteswwds_12_tfemptcod ,
                                              AV65Configuracion_empresastransporteswwds_13_tfemptcod_to ,
                                              AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel ,
                                              AV66Configuracion_empresastransporteswwds_14_tfemptdsc ,
                                              AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel ,
                                              AV68Configuracion_empresastransporteswwds_16_tfemptdir ,
                                              AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel ,
                                              AV70Configuracion_empresastransporteswwds_18_tfemptruc ,
                                              AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels.Count ,
                                              A964EmpTDsc ,
                                              A17EmpTCod ,
                                              A963EmptDir ,
                                              A966EmpTRuc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV55Configuracion_empresastransporteswwds_3_emptdsc1 = StringUtil.Concat( StringUtil.RTrim( AV55Configuracion_empresastransporteswwds_3_emptdsc1), "%", "");
         lV55Configuracion_empresastransporteswwds_3_emptdsc1 = StringUtil.Concat( StringUtil.RTrim( AV55Configuracion_empresastransporteswwds_3_emptdsc1), "%", "");
         lV59Configuracion_empresastransporteswwds_7_emptdsc2 = StringUtil.Concat( StringUtil.RTrim( AV59Configuracion_empresastransporteswwds_7_emptdsc2), "%", "");
         lV59Configuracion_empresastransporteswwds_7_emptdsc2 = StringUtil.Concat( StringUtil.RTrim( AV59Configuracion_empresastransporteswwds_7_emptdsc2), "%", "");
         lV63Configuracion_empresastransporteswwds_11_emptdsc3 = StringUtil.Concat( StringUtil.RTrim( AV63Configuracion_empresastransporteswwds_11_emptdsc3), "%", "");
         lV63Configuracion_empresastransporteswwds_11_emptdsc3 = StringUtil.Concat( StringUtil.RTrim( AV63Configuracion_empresastransporteswwds_11_emptdsc3), "%", "");
         lV66Configuracion_empresastransporteswwds_14_tfemptdsc = StringUtil.Concat( StringUtil.RTrim( AV66Configuracion_empresastransporteswwds_14_tfemptdsc), "%", "");
         lV68Configuracion_empresastransporteswwds_16_tfemptdir = StringUtil.Concat( StringUtil.RTrim( AV68Configuracion_empresastransporteswwds_16_tfemptdir), "%", "");
         lV70Configuracion_empresastransporteswwds_18_tfemptruc = StringUtil.Concat( StringUtil.RTrim( AV70Configuracion_empresastransporteswwds_18_tfemptruc), "%", "");
         /* Using cursor P00342 */
         pr_default.execute(0, new Object[] {lV55Configuracion_empresastransporteswwds_3_emptdsc1, lV55Configuracion_empresastransporteswwds_3_emptdsc1, lV59Configuracion_empresastransporteswwds_7_emptdsc2, lV59Configuracion_empresastransporteswwds_7_emptdsc2, lV63Configuracion_empresastransporteswwds_11_emptdsc3, lV63Configuracion_empresastransporteswwds_11_emptdsc3, AV64Configuracion_empresastransporteswwds_12_tfemptcod, AV65Configuracion_empresastransporteswwds_13_tfemptcod_to, lV66Configuracion_empresastransporteswwds_14_tfemptdsc, AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel, lV68Configuracion_empresastransporteswwds_16_tfemptdir, AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel, lV70Configuracion_empresastransporteswwds_18_tfemptruc, AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK342 = false;
            A964EmpTDsc = P00342_A964EmpTDsc[0];
            A967EmpTSts = P00342_A967EmpTSts[0];
            A966EmpTRuc = P00342_A966EmpTRuc[0];
            A963EmptDir = P00342_A963EmptDir[0];
            A17EmpTCod = P00342_A17EmpTCod[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00342_A964EmpTDsc[0], A964EmpTDsc) == 0 ) )
            {
               BRK342 = false;
               A17EmpTCod = P00342_A17EmpTCod[0];
               AV32count = (long)(AV32count+1);
               BRK342 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A964EmpTDsc)) )
            {
               AV24Option = A964EmpTDsc;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK342 )
            {
               BRK342 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADEMPTDIROPTIONS' Routine */
         returnInSub = false;
         AV14TFEmptDir = AV20SearchTxt;
         AV15TFEmptDir_Sel = "";
         AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV55Configuracion_empresastransporteswwds_3_emptdsc1 = AV40EmpTDsc1;
         AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV59Configuracion_empresastransporteswwds_7_emptdsc2 = AV44EmpTDsc2;
         AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV63Configuracion_empresastransporteswwds_11_emptdsc3 = AV48EmpTDsc3;
         AV64Configuracion_empresastransporteswwds_12_tfemptcod = AV10TFEmpTCod;
         AV65Configuracion_empresastransporteswwds_13_tfemptcod_to = AV11TFEmpTCod_To;
         AV66Configuracion_empresastransporteswwds_14_tfemptdsc = AV12TFEmpTDsc;
         AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel = AV13TFEmpTDsc_Sel;
         AV68Configuracion_empresastransporteswwds_16_tfemptdir = AV14TFEmptDir;
         AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel = AV15TFEmptDir_Sel;
         AV70Configuracion_empresastransporteswwds_18_tfemptruc = AV16TFEmpTRuc;
         AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel = AV17TFEmpTRuc_Sel;
         AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels = AV19TFEmpTSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A967EmpTSts ,
                                              AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels ,
                                              AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 ,
                                              AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 ,
                                              AV55Configuracion_empresastransporteswwds_3_emptdsc1 ,
                                              AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 ,
                                              AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 ,
                                              AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 ,
                                              AV59Configuracion_empresastransporteswwds_7_emptdsc2 ,
                                              AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 ,
                                              AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 ,
                                              AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 ,
                                              AV63Configuracion_empresastransporteswwds_11_emptdsc3 ,
                                              AV64Configuracion_empresastransporteswwds_12_tfemptcod ,
                                              AV65Configuracion_empresastransporteswwds_13_tfemptcod_to ,
                                              AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel ,
                                              AV66Configuracion_empresastransporteswwds_14_tfemptdsc ,
                                              AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel ,
                                              AV68Configuracion_empresastransporteswwds_16_tfemptdir ,
                                              AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel ,
                                              AV70Configuracion_empresastransporteswwds_18_tfemptruc ,
                                              AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels.Count ,
                                              A964EmpTDsc ,
                                              A17EmpTCod ,
                                              A963EmptDir ,
                                              A966EmpTRuc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV55Configuracion_empresastransporteswwds_3_emptdsc1 = StringUtil.Concat( StringUtil.RTrim( AV55Configuracion_empresastransporteswwds_3_emptdsc1), "%", "");
         lV55Configuracion_empresastransporteswwds_3_emptdsc1 = StringUtil.Concat( StringUtil.RTrim( AV55Configuracion_empresastransporteswwds_3_emptdsc1), "%", "");
         lV59Configuracion_empresastransporteswwds_7_emptdsc2 = StringUtil.Concat( StringUtil.RTrim( AV59Configuracion_empresastransporteswwds_7_emptdsc2), "%", "");
         lV59Configuracion_empresastransporteswwds_7_emptdsc2 = StringUtil.Concat( StringUtil.RTrim( AV59Configuracion_empresastransporteswwds_7_emptdsc2), "%", "");
         lV63Configuracion_empresastransporteswwds_11_emptdsc3 = StringUtil.Concat( StringUtil.RTrim( AV63Configuracion_empresastransporteswwds_11_emptdsc3), "%", "");
         lV63Configuracion_empresastransporteswwds_11_emptdsc3 = StringUtil.Concat( StringUtil.RTrim( AV63Configuracion_empresastransporteswwds_11_emptdsc3), "%", "");
         lV66Configuracion_empresastransporteswwds_14_tfemptdsc = StringUtil.Concat( StringUtil.RTrim( AV66Configuracion_empresastransporteswwds_14_tfemptdsc), "%", "");
         lV68Configuracion_empresastransporteswwds_16_tfemptdir = StringUtil.Concat( StringUtil.RTrim( AV68Configuracion_empresastransporteswwds_16_tfemptdir), "%", "");
         lV70Configuracion_empresastransporteswwds_18_tfemptruc = StringUtil.Concat( StringUtil.RTrim( AV70Configuracion_empresastransporteswwds_18_tfemptruc), "%", "");
         /* Using cursor P00343 */
         pr_default.execute(1, new Object[] {lV55Configuracion_empresastransporteswwds_3_emptdsc1, lV55Configuracion_empresastransporteswwds_3_emptdsc1, lV59Configuracion_empresastransporteswwds_7_emptdsc2, lV59Configuracion_empresastransporteswwds_7_emptdsc2, lV63Configuracion_empresastransporteswwds_11_emptdsc3, lV63Configuracion_empresastransporteswwds_11_emptdsc3, AV64Configuracion_empresastransporteswwds_12_tfemptcod, AV65Configuracion_empresastransporteswwds_13_tfemptcod_to, lV66Configuracion_empresastransporteswwds_14_tfemptdsc, AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel, lV68Configuracion_empresastransporteswwds_16_tfemptdir, AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel, lV70Configuracion_empresastransporteswwds_18_tfemptruc, AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK344 = false;
            A963EmptDir = P00343_A963EmptDir[0];
            A967EmpTSts = P00343_A967EmpTSts[0];
            A966EmpTRuc = P00343_A966EmpTRuc[0];
            A17EmpTCod = P00343_A17EmpTCod[0];
            A964EmpTDsc = P00343_A964EmpTDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00343_A963EmptDir[0], A963EmptDir) == 0 ) )
            {
               BRK344 = false;
               A17EmpTCod = P00343_A17EmpTCod[0];
               AV32count = (long)(AV32count+1);
               BRK344 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A963EmptDir)) )
            {
               AV24Option = A963EmptDir;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK344 )
            {
               BRK344 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADEMPTRUCOPTIONS' Routine */
         returnInSub = false;
         AV16TFEmpTRuc = AV20SearchTxt;
         AV17TFEmpTRuc_Sel = "";
         AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV55Configuracion_empresastransporteswwds_3_emptdsc1 = AV40EmpTDsc1;
         AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV59Configuracion_empresastransporteswwds_7_emptdsc2 = AV44EmpTDsc2;
         AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV63Configuracion_empresastransporteswwds_11_emptdsc3 = AV48EmpTDsc3;
         AV64Configuracion_empresastransporteswwds_12_tfemptcod = AV10TFEmpTCod;
         AV65Configuracion_empresastransporteswwds_13_tfemptcod_to = AV11TFEmpTCod_To;
         AV66Configuracion_empresastransporteswwds_14_tfemptdsc = AV12TFEmpTDsc;
         AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel = AV13TFEmpTDsc_Sel;
         AV68Configuracion_empresastransporteswwds_16_tfemptdir = AV14TFEmptDir;
         AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel = AV15TFEmptDir_Sel;
         AV70Configuracion_empresastransporteswwds_18_tfemptruc = AV16TFEmpTRuc;
         AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel = AV17TFEmpTRuc_Sel;
         AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels = AV19TFEmpTSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A967EmpTSts ,
                                              AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels ,
                                              AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 ,
                                              AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 ,
                                              AV55Configuracion_empresastransporteswwds_3_emptdsc1 ,
                                              AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 ,
                                              AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 ,
                                              AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 ,
                                              AV59Configuracion_empresastransporteswwds_7_emptdsc2 ,
                                              AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 ,
                                              AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 ,
                                              AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 ,
                                              AV63Configuracion_empresastransporteswwds_11_emptdsc3 ,
                                              AV64Configuracion_empresastransporteswwds_12_tfemptcod ,
                                              AV65Configuracion_empresastransporteswwds_13_tfemptcod_to ,
                                              AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel ,
                                              AV66Configuracion_empresastransporteswwds_14_tfemptdsc ,
                                              AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel ,
                                              AV68Configuracion_empresastransporteswwds_16_tfemptdir ,
                                              AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel ,
                                              AV70Configuracion_empresastransporteswwds_18_tfemptruc ,
                                              AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels.Count ,
                                              A964EmpTDsc ,
                                              A17EmpTCod ,
                                              A963EmptDir ,
                                              A966EmpTRuc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV55Configuracion_empresastransporteswwds_3_emptdsc1 = StringUtil.Concat( StringUtil.RTrim( AV55Configuracion_empresastransporteswwds_3_emptdsc1), "%", "");
         lV55Configuracion_empresastransporteswwds_3_emptdsc1 = StringUtil.Concat( StringUtil.RTrim( AV55Configuracion_empresastransporteswwds_3_emptdsc1), "%", "");
         lV59Configuracion_empresastransporteswwds_7_emptdsc2 = StringUtil.Concat( StringUtil.RTrim( AV59Configuracion_empresastransporteswwds_7_emptdsc2), "%", "");
         lV59Configuracion_empresastransporteswwds_7_emptdsc2 = StringUtil.Concat( StringUtil.RTrim( AV59Configuracion_empresastransporteswwds_7_emptdsc2), "%", "");
         lV63Configuracion_empresastransporteswwds_11_emptdsc3 = StringUtil.Concat( StringUtil.RTrim( AV63Configuracion_empresastransporteswwds_11_emptdsc3), "%", "");
         lV63Configuracion_empresastransporteswwds_11_emptdsc3 = StringUtil.Concat( StringUtil.RTrim( AV63Configuracion_empresastransporteswwds_11_emptdsc3), "%", "");
         lV66Configuracion_empresastransporteswwds_14_tfemptdsc = StringUtil.Concat( StringUtil.RTrim( AV66Configuracion_empresastransporteswwds_14_tfemptdsc), "%", "");
         lV68Configuracion_empresastransporteswwds_16_tfemptdir = StringUtil.Concat( StringUtil.RTrim( AV68Configuracion_empresastransporteswwds_16_tfemptdir), "%", "");
         lV70Configuracion_empresastransporteswwds_18_tfemptruc = StringUtil.Concat( StringUtil.RTrim( AV70Configuracion_empresastransporteswwds_18_tfemptruc), "%", "");
         /* Using cursor P00344 */
         pr_default.execute(2, new Object[] {lV55Configuracion_empresastransporteswwds_3_emptdsc1, lV55Configuracion_empresastransporteswwds_3_emptdsc1, lV59Configuracion_empresastransporteswwds_7_emptdsc2, lV59Configuracion_empresastransporteswwds_7_emptdsc2, lV63Configuracion_empresastransporteswwds_11_emptdsc3, lV63Configuracion_empresastransporteswwds_11_emptdsc3, AV64Configuracion_empresastransporteswwds_12_tfemptcod, AV65Configuracion_empresastransporteswwds_13_tfemptcod_to, lV66Configuracion_empresastransporteswwds_14_tfemptdsc, AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel, lV68Configuracion_empresastransporteswwds_16_tfemptdir, AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel, lV70Configuracion_empresastransporteswwds_18_tfemptruc, AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK346 = false;
            A966EmpTRuc = P00344_A966EmpTRuc[0];
            A967EmpTSts = P00344_A967EmpTSts[0];
            A963EmptDir = P00344_A963EmptDir[0];
            A17EmpTCod = P00344_A17EmpTCod[0];
            A964EmpTDsc = P00344_A964EmpTDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00344_A966EmpTRuc[0], A966EmpTRuc) == 0 ) )
            {
               BRK346 = false;
               A17EmpTCod = P00344_A17EmpTCod[0];
               AV32count = (long)(AV32count+1);
               BRK346 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A966EmpTRuc)) )
            {
               AV24Option = A966EmpTRuc;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK346 )
            {
               BRK346 = true;
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
         AV12TFEmpTDsc = "";
         AV13TFEmpTDsc_Sel = "";
         AV14TFEmptDir = "";
         AV15TFEmptDir_Sel = "";
         AV16TFEmpTRuc = "";
         AV17TFEmpTRuc_Sel = "";
         AV18TFEmpTSts_SelsJson = "";
         AV19TFEmpTSts_Sels = new GxSimpleCollection<short>();
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40EmpTDsc1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44EmpTDsc2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48EmpTDsc3 = "";
         AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 = "";
         AV55Configuracion_empresastransporteswwds_3_emptdsc1 = "";
         AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 = "";
         AV59Configuracion_empresastransporteswwds_7_emptdsc2 = "";
         AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 = "";
         AV63Configuracion_empresastransporteswwds_11_emptdsc3 = "";
         AV66Configuracion_empresastransporteswwds_14_tfemptdsc = "";
         AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel = "";
         AV68Configuracion_empresastransporteswwds_16_tfemptdir = "";
         AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel = "";
         AV70Configuracion_empresastransporteswwds_18_tfemptruc = "";
         AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel = "";
         AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV55Configuracion_empresastransporteswwds_3_emptdsc1 = "";
         lV59Configuracion_empresastransporteswwds_7_emptdsc2 = "";
         lV63Configuracion_empresastransporteswwds_11_emptdsc3 = "";
         lV66Configuracion_empresastransporteswwds_14_tfemptdsc = "";
         lV68Configuracion_empresastransporteswwds_16_tfemptdir = "";
         lV70Configuracion_empresastransporteswwds_18_tfemptruc = "";
         A964EmpTDsc = "";
         A963EmptDir = "";
         A966EmpTRuc = "";
         P00342_A964EmpTDsc = new string[] {""} ;
         P00342_A967EmpTSts = new short[1] ;
         P00342_A966EmpTRuc = new string[] {""} ;
         P00342_A963EmptDir = new string[] {""} ;
         P00342_A17EmpTCod = new int[1] ;
         AV24Option = "";
         P00343_A963EmptDir = new string[] {""} ;
         P00343_A967EmpTSts = new short[1] ;
         P00343_A966EmpTRuc = new string[] {""} ;
         P00343_A17EmpTCod = new int[1] ;
         P00343_A964EmpTDsc = new string[] {""} ;
         P00344_A966EmpTRuc = new string[] {""} ;
         P00344_A967EmpTSts = new short[1] ;
         P00344_A963EmptDir = new string[] {""} ;
         P00344_A17EmpTCod = new int[1] ;
         P00344_A964EmpTDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.empresastransporteswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00342_A964EmpTDsc, P00342_A967EmpTSts, P00342_A966EmpTRuc, P00342_A963EmptDir, P00342_A17EmpTCod
               }
               , new Object[] {
               P00343_A963EmptDir, P00343_A967EmpTSts, P00343_A966EmpTRuc, P00343_A17EmpTCod, P00343_A964EmpTDsc
               }
               , new Object[] {
               P00344_A966EmpTRuc, P00344_A967EmpTSts, P00344_A963EmptDir, P00344_A17EmpTCod, P00344_A964EmpTDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 ;
      private short AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 ;
      private short AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 ;
      private short A967EmpTSts ;
      private int AV51GXV1 ;
      private int AV10TFEmpTCod ;
      private int AV11TFEmpTCod_To ;
      private int AV64Configuracion_empresastransporteswwds_12_tfemptcod ;
      private int AV65Configuracion_empresastransporteswwds_13_tfemptcod_to ;
      private int AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels_Count ;
      private int A17EmpTCod ;
      private long AV32count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 ;
      private bool AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 ;
      private bool BRK342 ;
      private bool BRK344 ;
      private bool BRK346 ;
      private string AV26OptionsJson ;
      private string AV29OptionsDescJson ;
      private string AV31OptionIndexesJson ;
      private string AV18TFEmpTSts_SelsJson ;
      private string AV22DDOName ;
      private string AV20SearchTxt ;
      private string AV21SearchTxtTo ;
      private string AV12TFEmpTDsc ;
      private string AV13TFEmpTDsc_Sel ;
      private string AV14TFEmptDir ;
      private string AV15TFEmptDir_Sel ;
      private string AV16TFEmpTRuc ;
      private string AV17TFEmpTRuc_Sel ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV40EmpTDsc1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV44EmpTDsc2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV48EmpTDsc3 ;
      private string AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 ;
      private string AV55Configuracion_empresastransporteswwds_3_emptdsc1 ;
      private string AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 ;
      private string AV59Configuracion_empresastransporteswwds_7_emptdsc2 ;
      private string AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 ;
      private string AV63Configuracion_empresastransporteswwds_11_emptdsc3 ;
      private string AV66Configuracion_empresastransporteswwds_14_tfemptdsc ;
      private string AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel ;
      private string AV68Configuracion_empresastransporteswwds_16_tfemptdir ;
      private string AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel ;
      private string AV70Configuracion_empresastransporteswwds_18_tfemptruc ;
      private string AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel ;
      private string lV55Configuracion_empresastransporteswwds_3_emptdsc1 ;
      private string lV59Configuracion_empresastransporteswwds_7_emptdsc2 ;
      private string lV63Configuracion_empresastransporteswwds_11_emptdsc3 ;
      private string lV66Configuracion_empresastransporteswwds_14_tfemptdsc ;
      private string lV68Configuracion_empresastransporteswwds_16_tfemptdir ;
      private string lV70Configuracion_empresastransporteswwds_18_tfemptruc ;
      private string A964EmpTDsc ;
      private string A963EmptDir ;
      private string A966EmpTRuc ;
      private string AV24Option ;
      private GxSimpleCollection<short> AV19TFEmpTSts_Sels ;
      private GxSimpleCollection<short> AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00342_A964EmpTDsc ;
      private short[] P00342_A967EmpTSts ;
      private string[] P00342_A966EmpTRuc ;
      private string[] P00342_A963EmptDir ;
      private int[] P00342_A17EmpTCod ;
      private string[] P00343_A963EmptDir ;
      private short[] P00343_A967EmpTSts ;
      private string[] P00343_A966EmpTRuc ;
      private int[] P00343_A17EmpTCod ;
      private string[] P00343_A964EmpTDsc ;
      private string[] P00344_A966EmpTRuc ;
      private short[] P00344_A967EmpTSts ;
      private string[] P00344_A963EmptDir ;
      private int[] P00344_A17EmpTCod ;
      private string[] P00344_A964EmpTDsc ;
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

   public class empresastransporteswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00342( IGxContext context ,
                                             short A967EmpTSts ,
                                             GxSimpleCollection<short> AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels ,
                                             string AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 ,
                                             short AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 ,
                                             string AV55Configuracion_empresastransporteswwds_3_emptdsc1 ,
                                             bool AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 ,
                                             string AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 ,
                                             short AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 ,
                                             string AV59Configuracion_empresastransporteswwds_7_emptdsc2 ,
                                             bool AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 ,
                                             string AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 ,
                                             short AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 ,
                                             string AV63Configuracion_empresastransporteswwds_11_emptdsc3 ,
                                             int AV64Configuracion_empresastransporteswwds_12_tfemptcod ,
                                             int AV65Configuracion_empresastransporteswwds_13_tfemptcod_to ,
                                             string AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel ,
                                             string AV66Configuracion_empresastransporteswwds_14_tfemptdsc ,
                                             string AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel ,
                                             string AV68Configuracion_empresastransporteswwds_16_tfemptdir ,
                                             string AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel ,
                                             string AV70Configuracion_empresastransporteswwds_18_tfemptruc ,
                                             int AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels_Count ,
                                             string A964EmpTDsc ,
                                             int A17EmpTCod ,
                                             string A963EmptDir ,
                                             string A966EmpTRuc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [EmpTDsc], [EmpTSts], [EmpTRuc], [EmptDir], [EmpTCod] FROM [CEMPTRANSPORTE]";
         if ( ( StringUtil.StrCmp(AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1, "EMPTDSC") == 0 ) && ( AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_empresastransporteswwds_3_emptdsc1)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV55Configuracion_empresastransporteswwds_3_emptdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1, "EMPTDSC") == 0 ) && ( AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_empresastransporteswwds_3_emptdsc1)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like '%' + @lV55Configuracion_empresastransporteswwds_3_emptdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2, "EMPTDSC") == 0 ) && ( AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_empresastransporteswwds_7_emptdsc2)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV59Configuracion_empresastransporteswwds_7_emptdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2, "EMPTDSC") == 0 ) && ( AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_empresastransporteswwds_7_emptdsc2)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like '%' + @lV59Configuracion_empresastransporteswwds_7_emptdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3, "EMPTDSC") == 0 ) && ( AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_empresastransporteswwds_11_emptdsc3)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV63Configuracion_empresastransporteswwds_11_emptdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3, "EMPTDSC") == 0 ) && ( AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_empresastransporteswwds_11_emptdsc3)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like '%' + @lV63Configuracion_empresastransporteswwds_11_emptdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV64Configuracion_empresastransporteswwds_12_tfemptcod) )
         {
            AddWhere(sWhereString, "([EmpTCod] >= @AV64Configuracion_empresastransporteswwds_12_tfemptcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV65Configuracion_empresastransporteswwds_13_tfemptcod_to) )
         {
            AddWhere(sWhereString, "([EmpTCod] <= @AV65Configuracion_empresastransporteswwds_13_tfemptcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_empresastransporteswwds_14_tfemptdsc)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV66Configuracion_empresastransporteswwds_14_tfemptdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel)) )
         {
            AddWhere(sWhereString, "([EmpTDsc] = @AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_empresastransporteswwds_16_tfemptdir)) ) )
         {
            AddWhere(sWhereString, "([EmptDir] like @lV68Configuracion_empresastransporteswwds_16_tfemptdir)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel)) )
         {
            AddWhere(sWhereString, "([EmptDir] = @AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_empresastransporteswwds_18_tfemptruc)) ) )
         {
            AddWhere(sWhereString, "([EmpTRuc] like @lV70Configuracion_empresastransporteswwds_18_tfemptruc)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel)) )
         {
            AddWhere(sWhereString, "([EmpTRuc] = @AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels, "[EmpTSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [EmpTDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00343( IGxContext context ,
                                             short A967EmpTSts ,
                                             GxSimpleCollection<short> AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels ,
                                             string AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 ,
                                             short AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 ,
                                             string AV55Configuracion_empresastransporteswwds_3_emptdsc1 ,
                                             bool AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 ,
                                             string AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 ,
                                             short AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 ,
                                             string AV59Configuracion_empresastransporteswwds_7_emptdsc2 ,
                                             bool AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 ,
                                             string AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 ,
                                             short AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 ,
                                             string AV63Configuracion_empresastransporteswwds_11_emptdsc3 ,
                                             int AV64Configuracion_empresastransporteswwds_12_tfemptcod ,
                                             int AV65Configuracion_empresastransporteswwds_13_tfemptcod_to ,
                                             string AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel ,
                                             string AV66Configuracion_empresastransporteswwds_14_tfemptdsc ,
                                             string AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel ,
                                             string AV68Configuracion_empresastransporteswwds_16_tfemptdir ,
                                             string AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel ,
                                             string AV70Configuracion_empresastransporteswwds_18_tfemptruc ,
                                             int AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels_Count ,
                                             string A964EmpTDsc ,
                                             int A17EmpTCod ,
                                             string A963EmptDir ,
                                             string A966EmpTRuc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [EmptDir], [EmpTSts], [EmpTRuc], [EmpTCod], [EmpTDsc] FROM [CEMPTRANSPORTE]";
         if ( ( StringUtil.StrCmp(AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1, "EMPTDSC") == 0 ) && ( AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_empresastransporteswwds_3_emptdsc1)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV55Configuracion_empresastransporteswwds_3_emptdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1, "EMPTDSC") == 0 ) && ( AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_empresastransporteswwds_3_emptdsc1)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like '%' + @lV55Configuracion_empresastransporteswwds_3_emptdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2, "EMPTDSC") == 0 ) && ( AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_empresastransporteswwds_7_emptdsc2)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV59Configuracion_empresastransporteswwds_7_emptdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2, "EMPTDSC") == 0 ) && ( AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_empresastransporteswwds_7_emptdsc2)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like '%' + @lV59Configuracion_empresastransporteswwds_7_emptdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3, "EMPTDSC") == 0 ) && ( AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_empresastransporteswwds_11_emptdsc3)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV63Configuracion_empresastransporteswwds_11_emptdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3, "EMPTDSC") == 0 ) && ( AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_empresastransporteswwds_11_emptdsc3)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like '%' + @lV63Configuracion_empresastransporteswwds_11_emptdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV64Configuracion_empresastransporteswwds_12_tfemptcod) )
         {
            AddWhere(sWhereString, "([EmpTCod] >= @AV64Configuracion_empresastransporteswwds_12_tfemptcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV65Configuracion_empresastransporteswwds_13_tfemptcod_to) )
         {
            AddWhere(sWhereString, "([EmpTCod] <= @AV65Configuracion_empresastransporteswwds_13_tfemptcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_empresastransporteswwds_14_tfemptdsc)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV66Configuracion_empresastransporteswwds_14_tfemptdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel)) )
         {
            AddWhere(sWhereString, "([EmpTDsc] = @AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_empresastransporteswwds_16_tfemptdir)) ) )
         {
            AddWhere(sWhereString, "([EmptDir] like @lV68Configuracion_empresastransporteswwds_16_tfemptdir)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel)) )
         {
            AddWhere(sWhereString, "([EmptDir] = @AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_empresastransporteswwds_18_tfemptruc)) ) )
         {
            AddWhere(sWhereString, "([EmpTRuc] like @lV70Configuracion_empresastransporteswwds_18_tfemptruc)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel)) )
         {
            AddWhere(sWhereString, "([EmpTRuc] = @AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels, "[EmpTSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [EmptDir]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00344( IGxContext context ,
                                             short A967EmpTSts ,
                                             GxSimpleCollection<short> AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels ,
                                             string AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1 ,
                                             short AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 ,
                                             string AV55Configuracion_empresastransporteswwds_3_emptdsc1 ,
                                             bool AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 ,
                                             string AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2 ,
                                             short AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 ,
                                             string AV59Configuracion_empresastransporteswwds_7_emptdsc2 ,
                                             bool AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 ,
                                             string AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3 ,
                                             short AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 ,
                                             string AV63Configuracion_empresastransporteswwds_11_emptdsc3 ,
                                             int AV64Configuracion_empresastransporteswwds_12_tfemptcod ,
                                             int AV65Configuracion_empresastransporteswwds_13_tfemptcod_to ,
                                             string AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel ,
                                             string AV66Configuracion_empresastransporteswwds_14_tfemptdsc ,
                                             string AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel ,
                                             string AV68Configuracion_empresastransporteswwds_16_tfemptdir ,
                                             string AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel ,
                                             string AV70Configuracion_empresastransporteswwds_18_tfemptruc ,
                                             int AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels_Count ,
                                             string A964EmpTDsc ,
                                             int A17EmpTCod ,
                                             string A963EmptDir ,
                                             string A966EmpTRuc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[14];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [EmpTRuc], [EmpTSts], [EmptDir], [EmpTCod], [EmpTDsc] FROM [CEMPTRANSPORTE]";
         if ( ( StringUtil.StrCmp(AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1, "EMPTDSC") == 0 ) && ( AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_empresastransporteswwds_3_emptdsc1)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV55Configuracion_empresastransporteswwds_3_emptdsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Configuracion_empresastransporteswwds_1_dynamicfiltersselector1, "EMPTDSC") == 0 ) && ( AV54Configuracion_empresastransporteswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_empresastransporteswwds_3_emptdsc1)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like '%' + @lV55Configuracion_empresastransporteswwds_3_emptdsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2, "EMPTDSC") == 0 ) && ( AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_empresastransporteswwds_7_emptdsc2)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV59Configuracion_empresastransporteswwds_7_emptdsc2)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV56Configuracion_empresastransporteswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_empresastransporteswwds_5_dynamicfiltersselector2, "EMPTDSC") == 0 ) && ( AV58Configuracion_empresastransporteswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_empresastransporteswwds_7_emptdsc2)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like '%' + @lV59Configuracion_empresastransporteswwds_7_emptdsc2)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3, "EMPTDSC") == 0 ) && ( AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_empresastransporteswwds_11_emptdsc3)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV63Configuracion_empresastransporteswwds_11_emptdsc3)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV60Configuracion_empresastransporteswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_empresastransporteswwds_9_dynamicfiltersselector3, "EMPTDSC") == 0 ) && ( AV62Configuracion_empresastransporteswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_empresastransporteswwds_11_emptdsc3)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like '%' + @lV63Configuracion_empresastransporteswwds_11_emptdsc3)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV64Configuracion_empresastransporteswwds_12_tfemptcod) )
         {
            AddWhere(sWhereString, "([EmpTCod] >= @AV64Configuracion_empresastransporteswwds_12_tfemptcod)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV65Configuracion_empresastransporteswwds_13_tfemptcod_to) )
         {
            AddWhere(sWhereString, "([EmpTCod] <= @AV65Configuracion_empresastransporteswwds_13_tfemptcod_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_empresastransporteswwds_14_tfemptdsc)) ) )
         {
            AddWhere(sWhereString, "([EmpTDsc] like @lV66Configuracion_empresastransporteswwds_14_tfemptdsc)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel)) )
         {
            AddWhere(sWhereString, "([EmpTDsc] = @AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_empresastransporteswwds_16_tfemptdir)) ) )
         {
            AddWhere(sWhereString, "([EmptDir] like @lV68Configuracion_empresastransporteswwds_16_tfemptdir)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel)) )
         {
            AddWhere(sWhereString, "([EmptDir] = @AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_empresastransporteswwds_18_tfemptruc)) ) )
         {
            AddWhere(sWhereString, "([EmpTRuc] like @lV70Configuracion_empresastransporteswwds_18_tfemptruc)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel)) )
         {
            AddWhere(sWhereString, "([EmpTRuc] = @AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Configuracion_empresastransporteswwds_20_tfemptsts_sels, "[EmpTSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [EmpTRuc]";
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
                     return conditional_P00342(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
               case 1 :
                     return conditional_P00343(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
               case 2 :
                     return conditional_P00344(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
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
          Object[] prmP00342;
          prmP00342 = new Object[] {
          new ParDef("@lV55Configuracion_empresastransporteswwds_3_emptdsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Configuracion_empresastransporteswwds_3_emptdsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV59Configuracion_empresastransporteswwds_7_emptdsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV59Configuracion_empresastransporteswwds_7_emptdsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV63Configuracion_empresastransporteswwds_11_emptdsc3",GXType.NVarChar,100,0) ,
          new ParDef("@lV63Configuracion_empresastransporteswwds_11_emptdsc3",GXType.NVarChar,100,0) ,
          new ParDef("@AV64Configuracion_empresastransporteswwds_12_tfemptcod",GXType.Int32,6,0) ,
          new ParDef("@AV65Configuracion_empresastransporteswwds_13_tfemptcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV66Configuracion_empresastransporteswwds_14_tfemptdsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV68Configuracion_empresastransporteswwds_16_tfemptdir",GXType.NVarChar,100,0) ,
          new ParDef("@AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV70Configuracion_empresastransporteswwds_18_tfemptruc",GXType.NVarChar,20,0) ,
          new ParDef("@AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel",GXType.NVarChar,20,0)
          };
          Object[] prmP00343;
          prmP00343 = new Object[] {
          new ParDef("@lV55Configuracion_empresastransporteswwds_3_emptdsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Configuracion_empresastransporteswwds_3_emptdsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV59Configuracion_empresastransporteswwds_7_emptdsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV59Configuracion_empresastransporteswwds_7_emptdsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV63Configuracion_empresastransporteswwds_11_emptdsc3",GXType.NVarChar,100,0) ,
          new ParDef("@lV63Configuracion_empresastransporteswwds_11_emptdsc3",GXType.NVarChar,100,0) ,
          new ParDef("@AV64Configuracion_empresastransporteswwds_12_tfemptcod",GXType.Int32,6,0) ,
          new ParDef("@AV65Configuracion_empresastransporteswwds_13_tfemptcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV66Configuracion_empresastransporteswwds_14_tfemptdsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV68Configuracion_empresastransporteswwds_16_tfemptdir",GXType.NVarChar,100,0) ,
          new ParDef("@AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV70Configuracion_empresastransporteswwds_18_tfemptruc",GXType.NVarChar,20,0) ,
          new ParDef("@AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel",GXType.NVarChar,20,0)
          };
          Object[] prmP00344;
          prmP00344 = new Object[] {
          new ParDef("@lV55Configuracion_empresastransporteswwds_3_emptdsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV55Configuracion_empresastransporteswwds_3_emptdsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV59Configuracion_empresastransporteswwds_7_emptdsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV59Configuracion_empresastransporteswwds_7_emptdsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV63Configuracion_empresastransporteswwds_11_emptdsc3",GXType.NVarChar,100,0) ,
          new ParDef("@lV63Configuracion_empresastransporteswwds_11_emptdsc3",GXType.NVarChar,100,0) ,
          new ParDef("@AV64Configuracion_empresastransporteswwds_12_tfemptcod",GXType.Int32,6,0) ,
          new ParDef("@AV65Configuracion_empresastransporteswwds_13_tfemptcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV66Configuracion_empresastransporteswwds_14_tfemptdsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV67Configuracion_empresastransporteswwds_15_tfemptdsc_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV68Configuracion_empresastransporteswwds_16_tfemptdir",GXType.NVarChar,100,0) ,
          new ParDef("@AV69Configuracion_empresastransporteswwds_17_tfemptdir_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV70Configuracion_empresastransporteswwds_18_tfemptruc",GXType.NVarChar,20,0) ,
          new ParDef("@AV71Configuracion_empresastransporteswwds_19_tfemptruc_sel",GXType.NVarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00342", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00342,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00343", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00343,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00344", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00344,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
       }
    }

 }

}
