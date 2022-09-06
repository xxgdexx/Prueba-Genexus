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
   public class condicionpagowwgetfilterdata : GXProcedure
   {
      public condicionpagowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public condicionpagowwgetfilterdata( IGxContext context )
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
         condicionpagowwgetfilterdata objcondicionpagowwgetfilterdata;
         objcondicionpagowwgetfilterdata = new condicionpagowwgetfilterdata();
         objcondicionpagowwgetfilterdata.AV22DDOName = aP0_DDOName;
         objcondicionpagowwgetfilterdata.AV20SearchTxt = aP1_SearchTxt;
         objcondicionpagowwgetfilterdata.AV21SearchTxtTo = aP2_SearchTxtTo;
         objcondicionpagowwgetfilterdata.AV26OptionsJson = "" ;
         objcondicionpagowwgetfilterdata.AV29OptionsDescJson = "" ;
         objcondicionpagowwgetfilterdata.AV31OptionIndexesJson = "" ;
         objcondicionpagowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objcondicionpagowwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcondicionpagowwgetfilterdata);
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((condicionpagowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_CONPDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCONPDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_CONPABR") == 0 )
         {
            /* Execute user subroutine: 'LOADCONPABROPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV33Session.Get("Configuracion.CondicionPagoWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.CondicionPagoWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Configuracion.CondicionPagoWWGridState"), null, "", "");
         }
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONPCOD") == 0 )
            {
               AV10TFConpcod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV11TFConpcod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONPDSC") == 0 )
            {
               AV12TFConpDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONPDSC_SEL") == 0 )
            {
               AV13TFConpDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONPABR") == 0 )
            {
               AV14TFConpAbr = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONPABR_SEL") == 0 )
            {
               AV15TFConpAbr_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONPDIAS") == 0 )
            {
               AV16TFConpDias = (short)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV17TFConpDias_To = (short)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCONPSTS_SEL") == 0 )
            {
               AV49TFConpSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV50TFConpSts_Sels.FromJSonString(AV49TFConpSts_SelsJson, null);
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "CONPDSC") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV40ConpDsc1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "CONPDSC") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV44ConpDsc2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "CONPDSC") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV48ConpDsc3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCONPDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFConpDsc = AV20SearchTxt;
         AV13TFConpDsc_Sel = "";
         AV55Configuracion_condicionpagowwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV56Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV57Configuracion_condicionpagowwds_3_conpdsc1 = AV40ConpDsc1;
         AV58Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV59Configuracion_condicionpagowwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV60Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV61Configuracion_condicionpagowwds_7_conpdsc2 = AV44ConpDsc2;
         AV62Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV63Configuracion_condicionpagowwds_9_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV64Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV65Configuracion_condicionpagowwds_11_conpdsc3 = AV48ConpDsc3;
         AV66Configuracion_condicionpagowwds_12_tfconpcod = AV10TFConpcod;
         AV67Configuracion_condicionpagowwds_13_tfconpcod_to = AV11TFConpcod_To;
         AV68Configuracion_condicionpagowwds_14_tfconpdsc = AV12TFConpDsc;
         AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel = AV13TFConpDsc_Sel;
         AV70Configuracion_condicionpagowwds_16_tfconpabr = AV14TFConpAbr;
         AV71Configuracion_condicionpagowwds_17_tfconpabr_sel = AV15TFConpAbr_Sel;
         AV72Configuracion_condicionpagowwds_18_tfconpdias = AV16TFConpDias;
         AV73Configuracion_condicionpagowwds_19_tfconpdias_to = AV17TFConpDias_To;
         AV74Configuracion_condicionpagowwds_20_tfconpsts_sels = AV50TFConpSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A754ConpSts ,
                                              AV74Configuracion_condicionpagowwds_20_tfconpsts_sels ,
                                              AV55Configuracion_condicionpagowwds_1_dynamicfiltersselector1 ,
                                              AV56Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 ,
                                              AV57Configuracion_condicionpagowwds_3_conpdsc1 ,
                                              AV58Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 ,
                                              AV59Configuracion_condicionpagowwds_5_dynamicfiltersselector2 ,
                                              AV60Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 ,
                                              AV61Configuracion_condicionpagowwds_7_conpdsc2 ,
                                              AV62Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 ,
                                              AV63Configuracion_condicionpagowwds_9_dynamicfiltersselector3 ,
                                              AV64Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 ,
                                              AV65Configuracion_condicionpagowwds_11_conpdsc3 ,
                                              AV66Configuracion_condicionpagowwds_12_tfconpcod ,
                                              AV67Configuracion_condicionpagowwds_13_tfconpcod_to ,
                                              AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel ,
                                              AV68Configuracion_condicionpagowwds_14_tfconpdsc ,
                                              AV71Configuracion_condicionpagowwds_17_tfconpabr_sel ,
                                              AV70Configuracion_condicionpagowwds_16_tfconpabr ,
                                              AV72Configuracion_condicionpagowwds_18_tfconpdias ,
                                              AV73Configuracion_condicionpagowwds_19_tfconpdias_to ,
                                              AV74Configuracion_condicionpagowwds_20_tfconpsts_sels.Count ,
                                              A753ConpDsc ,
                                              A137Conpcod ,
                                              A751ConpAbr ,
                                              A752ConpDias } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV57Configuracion_condicionpagowwds_3_conpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_condicionpagowwds_3_conpdsc1), 100, "%");
         lV57Configuracion_condicionpagowwds_3_conpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_condicionpagowwds_3_conpdsc1), 100, "%");
         lV61Configuracion_condicionpagowwds_7_conpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_condicionpagowwds_7_conpdsc2), 100, "%");
         lV61Configuracion_condicionpagowwds_7_conpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_condicionpagowwds_7_conpdsc2), 100, "%");
         lV65Configuracion_condicionpagowwds_11_conpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_condicionpagowwds_11_conpdsc3), 100, "%");
         lV65Configuracion_condicionpagowwds_11_conpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_condicionpagowwds_11_conpdsc3), 100, "%");
         lV68Configuracion_condicionpagowwds_14_tfconpdsc = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_condicionpagowwds_14_tfconpdsc), 100, "%");
         lV70Configuracion_condicionpagowwds_16_tfconpabr = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_condicionpagowwds_16_tfconpabr), 5, "%");
         /* Using cursor P002I2 */
         pr_default.execute(0, new Object[] {lV57Configuracion_condicionpagowwds_3_conpdsc1, lV57Configuracion_condicionpagowwds_3_conpdsc1, lV61Configuracion_condicionpagowwds_7_conpdsc2, lV61Configuracion_condicionpagowwds_7_conpdsc2, lV65Configuracion_condicionpagowwds_11_conpdsc3, lV65Configuracion_condicionpagowwds_11_conpdsc3, AV66Configuracion_condicionpagowwds_12_tfconpcod, AV67Configuracion_condicionpagowwds_13_tfconpcod_to, lV68Configuracion_condicionpagowwds_14_tfconpdsc, AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel, lV70Configuracion_condicionpagowwds_16_tfconpabr, AV71Configuracion_condicionpagowwds_17_tfconpabr_sel, AV72Configuracion_condicionpagowwds_18_tfconpdias, AV73Configuracion_condicionpagowwds_19_tfconpdias_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2I2 = false;
            A753ConpDsc = P002I2_A753ConpDsc[0];
            A754ConpSts = P002I2_A754ConpSts[0];
            A752ConpDias = P002I2_A752ConpDias[0];
            A751ConpAbr = P002I2_A751ConpAbr[0];
            A137Conpcod = P002I2_A137Conpcod[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002I2_A753ConpDsc[0], A753ConpDsc) == 0 ) )
            {
               BRK2I2 = false;
               A137Conpcod = P002I2_A137Conpcod[0];
               AV32count = (long)(AV32count+1);
               BRK2I2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A753ConpDsc)) )
            {
               AV24Option = A753ConpDsc;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK2I2 )
            {
               BRK2I2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCONPABROPTIONS' Routine */
         returnInSub = false;
         AV14TFConpAbr = AV20SearchTxt;
         AV15TFConpAbr_Sel = "";
         AV55Configuracion_condicionpagowwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV56Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV57Configuracion_condicionpagowwds_3_conpdsc1 = AV40ConpDsc1;
         AV58Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV59Configuracion_condicionpagowwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV60Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV61Configuracion_condicionpagowwds_7_conpdsc2 = AV44ConpDsc2;
         AV62Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV63Configuracion_condicionpagowwds_9_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV64Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV65Configuracion_condicionpagowwds_11_conpdsc3 = AV48ConpDsc3;
         AV66Configuracion_condicionpagowwds_12_tfconpcod = AV10TFConpcod;
         AV67Configuracion_condicionpagowwds_13_tfconpcod_to = AV11TFConpcod_To;
         AV68Configuracion_condicionpagowwds_14_tfconpdsc = AV12TFConpDsc;
         AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel = AV13TFConpDsc_Sel;
         AV70Configuracion_condicionpagowwds_16_tfconpabr = AV14TFConpAbr;
         AV71Configuracion_condicionpagowwds_17_tfconpabr_sel = AV15TFConpAbr_Sel;
         AV72Configuracion_condicionpagowwds_18_tfconpdias = AV16TFConpDias;
         AV73Configuracion_condicionpagowwds_19_tfconpdias_to = AV17TFConpDias_To;
         AV74Configuracion_condicionpagowwds_20_tfconpsts_sels = AV50TFConpSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A754ConpSts ,
                                              AV74Configuracion_condicionpagowwds_20_tfconpsts_sels ,
                                              AV55Configuracion_condicionpagowwds_1_dynamicfiltersselector1 ,
                                              AV56Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 ,
                                              AV57Configuracion_condicionpagowwds_3_conpdsc1 ,
                                              AV58Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 ,
                                              AV59Configuracion_condicionpagowwds_5_dynamicfiltersselector2 ,
                                              AV60Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 ,
                                              AV61Configuracion_condicionpagowwds_7_conpdsc2 ,
                                              AV62Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 ,
                                              AV63Configuracion_condicionpagowwds_9_dynamicfiltersselector3 ,
                                              AV64Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 ,
                                              AV65Configuracion_condicionpagowwds_11_conpdsc3 ,
                                              AV66Configuracion_condicionpagowwds_12_tfconpcod ,
                                              AV67Configuracion_condicionpagowwds_13_tfconpcod_to ,
                                              AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel ,
                                              AV68Configuracion_condicionpagowwds_14_tfconpdsc ,
                                              AV71Configuracion_condicionpagowwds_17_tfconpabr_sel ,
                                              AV70Configuracion_condicionpagowwds_16_tfconpabr ,
                                              AV72Configuracion_condicionpagowwds_18_tfconpdias ,
                                              AV73Configuracion_condicionpagowwds_19_tfconpdias_to ,
                                              AV74Configuracion_condicionpagowwds_20_tfconpsts_sels.Count ,
                                              A753ConpDsc ,
                                              A137Conpcod ,
                                              A751ConpAbr ,
                                              A752ConpDias } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV57Configuracion_condicionpagowwds_3_conpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_condicionpagowwds_3_conpdsc1), 100, "%");
         lV57Configuracion_condicionpagowwds_3_conpdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_condicionpagowwds_3_conpdsc1), 100, "%");
         lV61Configuracion_condicionpagowwds_7_conpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_condicionpagowwds_7_conpdsc2), 100, "%");
         lV61Configuracion_condicionpagowwds_7_conpdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_condicionpagowwds_7_conpdsc2), 100, "%");
         lV65Configuracion_condicionpagowwds_11_conpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_condicionpagowwds_11_conpdsc3), 100, "%");
         lV65Configuracion_condicionpagowwds_11_conpdsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_condicionpagowwds_11_conpdsc3), 100, "%");
         lV68Configuracion_condicionpagowwds_14_tfconpdsc = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_condicionpagowwds_14_tfconpdsc), 100, "%");
         lV70Configuracion_condicionpagowwds_16_tfconpabr = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_condicionpagowwds_16_tfconpabr), 5, "%");
         /* Using cursor P002I3 */
         pr_default.execute(1, new Object[] {lV57Configuracion_condicionpagowwds_3_conpdsc1, lV57Configuracion_condicionpagowwds_3_conpdsc1, lV61Configuracion_condicionpagowwds_7_conpdsc2, lV61Configuracion_condicionpagowwds_7_conpdsc2, lV65Configuracion_condicionpagowwds_11_conpdsc3, lV65Configuracion_condicionpagowwds_11_conpdsc3, AV66Configuracion_condicionpagowwds_12_tfconpcod, AV67Configuracion_condicionpagowwds_13_tfconpcod_to, lV68Configuracion_condicionpagowwds_14_tfconpdsc, AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel, lV70Configuracion_condicionpagowwds_16_tfconpabr, AV71Configuracion_condicionpagowwds_17_tfconpabr_sel, AV72Configuracion_condicionpagowwds_18_tfconpdias, AV73Configuracion_condicionpagowwds_19_tfconpdias_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2I4 = false;
            A751ConpAbr = P002I3_A751ConpAbr[0];
            A754ConpSts = P002I3_A754ConpSts[0];
            A752ConpDias = P002I3_A752ConpDias[0];
            A137Conpcod = P002I3_A137Conpcod[0];
            A753ConpDsc = P002I3_A753ConpDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002I3_A751ConpAbr[0], A751ConpAbr) == 0 ) )
            {
               BRK2I4 = false;
               A137Conpcod = P002I3_A137Conpcod[0];
               AV32count = (long)(AV32count+1);
               BRK2I4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A751ConpAbr)) )
            {
               AV24Option = A751ConpAbr;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK2I4 )
            {
               BRK2I4 = true;
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
         AV12TFConpDsc = "";
         AV13TFConpDsc_Sel = "";
         AV14TFConpAbr = "";
         AV15TFConpAbr_Sel = "";
         AV49TFConpSts_SelsJson = "";
         AV50TFConpSts_Sels = new GxSimpleCollection<short>();
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40ConpDsc1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44ConpDsc2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48ConpDsc3 = "";
         AV55Configuracion_condicionpagowwds_1_dynamicfiltersselector1 = "";
         AV57Configuracion_condicionpagowwds_3_conpdsc1 = "";
         AV59Configuracion_condicionpagowwds_5_dynamicfiltersselector2 = "";
         AV61Configuracion_condicionpagowwds_7_conpdsc2 = "";
         AV63Configuracion_condicionpagowwds_9_dynamicfiltersselector3 = "";
         AV65Configuracion_condicionpagowwds_11_conpdsc3 = "";
         AV68Configuracion_condicionpagowwds_14_tfconpdsc = "";
         AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel = "";
         AV70Configuracion_condicionpagowwds_16_tfconpabr = "";
         AV71Configuracion_condicionpagowwds_17_tfconpabr_sel = "";
         AV74Configuracion_condicionpagowwds_20_tfconpsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV57Configuracion_condicionpagowwds_3_conpdsc1 = "";
         lV61Configuracion_condicionpagowwds_7_conpdsc2 = "";
         lV65Configuracion_condicionpagowwds_11_conpdsc3 = "";
         lV68Configuracion_condicionpagowwds_14_tfconpdsc = "";
         lV70Configuracion_condicionpagowwds_16_tfconpabr = "";
         A753ConpDsc = "";
         A751ConpAbr = "";
         P002I2_A753ConpDsc = new string[] {""} ;
         P002I2_A754ConpSts = new short[1] ;
         P002I2_A752ConpDias = new short[1] ;
         P002I2_A751ConpAbr = new string[] {""} ;
         P002I2_A137Conpcod = new int[1] ;
         AV24Option = "";
         P002I3_A751ConpAbr = new string[] {""} ;
         P002I3_A754ConpSts = new short[1] ;
         P002I3_A752ConpDias = new short[1] ;
         P002I3_A137Conpcod = new int[1] ;
         P002I3_A753ConpDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.condicionpagowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002I2_A753ConpDsc, P002I2_A754ConpSts, P002I2_A752ConpDias, P002I2_A751ConpAbr, P002I2_A137Conpcod
               }
               , new Object[] {
               P002I3_A751ConpAbr, P002I3_A754ConpSts, P002I3_A752ConpDias, P002I3_A137Conpcod, P002I3_A753ConpDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV16TFConpDias ;
      private short AV17TFConpDias_To ;
      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV56Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 ;
      private short AV60Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 ;
      private short AV64Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 ;
      private short AV72Configuracion_condicionpagowwds_18_tfconpdias ;
      private short AV73Configuracion_condicionpagowwds_19_tfconpdias_to ;
      private short A754ConpSts ;
      private short A752ConpDias ;
      private int AV53GXV1 ;
      private int AV10TFConpcod ;
      private int AV11TFConpcod_To ;
      private int AV66Configuracion_condicionpagowwds_12_tfconpcod ;
      private int AV67Configuracion_condicionpagowwds_13_tfconpcod_to ;
      private int AV74Configuracion_condicionpagowwds_20_tfconpsts_sels_Count ;
      private int A137Conpcod ;
      private long AV32count ;
      private string AV12TFConpDsc ;
      private string AV13TFConpDsc_Sel ;
      private string AV14TFConpAbr ;
      private string AV15TFConpAbr_Sel ;
      private string AV40ConpDsc1 ;
      private string AV44ConpDsc2 ;
      private string AV48ConpDsc3 ;
      private string AV57Configuracion_condicionpagowwds_3_conpdsc1 ;
      private string AV61Configuracion_condicionpagowwds_7_conpdsc2 ;
      private string AV65Configuracion_condicionpagowwds_11_conpdsc3 ;
      private string AV68Configuracion_condicionpagowwds_14_tfconpdsc ;
      private string AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel ;
      private string AV70Configuracion_condicionpagowwds_16_tfconpabr ;
      private string AV71Configuracion_condicionpagowwds_17_tfconpabr_sel ;
      private string scmdbuf ;
      private string lV57Configuracion_condicionpagowwds_3_conpdsc1 ;
      private string lV61Configuracion_condicionpagowwds_7_conpdsc2 ;
      private string lV65Configuracion_condicionpagowwds_11_conpdsc3 ;
      private string lV68Configuracion_condicionpagowwds_14_tfconpdsc ;
      private string lV70Configuracion_condicionpagowwds_16_tfconpabr ;
      private string A753ConpDsc ;
      private string A751ConpAbr ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV58Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 ;
      private bool AV62Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 ;
      private bool BRK2I2 ;
      private bool BRK2I4 ;
      private string AV26OptionsJson ;
      private string AV29OptionsDescJson ;
      private string AV31OptionIndexesJson ;
      private string AV49TFConpSts_SelsJson ;
      private string AV22DDOName ;
      private string AV20SearchTxt ;
      private string AV21SearchTxtTo ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV55Configuracion_condicionpagowwds_1_dynamicfiltersselector1 ;
      private string AV59Configuracion_condicionpagowwds_5_dynamicfiltersselector2 ;
      private string AV63Configuracion_condicionpagowwds_9_dynamicfiltersselector3 ;
      private string AV24Option ;
      private GxSimpleCollection<short> AV50TFConpSts_Sels ;
      private GxSimpleCollection<short> AV74Configuracion_condicionpagowwds_20_tfconpsts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002I2_A753ConpDsc ;
      private short[] P002I2_A754ConpSts ;
      private short[] P002I2_A752ConpDias ;
      private string[] P002I2_A751ConpAbr ;
      private int[] P002I2_A137Conpcod ;
      private string[] P002I3_A751ConpAbr ;
      private short[] P002I3_A754ConpSts ;
      private short[] P002I3_A752ConpDias ;
      private int[] P002I3_A137Conpcod ;
      private string[] P002I3_A753ConpDsc ;
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

   public class condicionpagowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002I2( IGxContext context ,
                                             short A754ConpSts ,
                                             GxSimpleCollection<short> AV74Configuracion_condicionpagowwds_20_tfconpsts_sels ,
                                             string AV55Configuracion_condicionpagowwds_1_dynamicfiltersselector1 ,
                                             short AV56Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 ,
                                             string AV57Configuracion_condicionpagowwds_3_conpdsc1 ,
                                             bool AV58Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 ,
                                             string AV59Configuracion_condicionpagowwds_5_dynamicfiltersselector2 ,
                                             short AV60Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 ,
                                             string AV61Configuracion_condicionpagowwds_7_conpdsc2 ,
                                             bool AV62Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 ,
                                             string AV63Configuracion_condicionpagowwds_9_dynamicfiltersselector3 ,
                                             short AV64Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 ,
                                             string AV65Configuracion_condicionpagowwds_11_conpdsc3 ,
                                             int AV66Configuracion_condicionpagowwds_12_tfconpcod ,
                                             int AV67Configuracion_condicionpagowwds_13_tfconpcod_to ,
                                             string AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel ,
                                             string AV68Configuracion_condicionpagowwds_14_tfconpdsc ,
                                             string AV71Configuracion_condicionpagowwds_17_tfconpabr_sel ,
                                             string AV70Configuracion_condicionpagowwds_16_tfconpabr ,
                                             short AV72Configuracion_condicionpagowwds_18_tfconpdias ,
                                             short AV73Configuracion_condicionpagowwds_19_tfconpdias_to ,
                                             int AV74Configuracion_condicionpagowwds_20_tfconpsts_sels_Count ,
                                             string A753ConpDsc ,
                                             int A137Conpcod ,
                                             string A751ConpAbr ,
                                             short A752ConpDias )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [ConpDsc], [ConpSts], [ConpDias], [ConpAbr], [Conpcod] FROM [CCONDICIONPAGO]";
         if ( ( StringUtil.StrCmp(AV55Configuracion_condicionpagowwds_1_dynamicfiltersselector1, "CONPDSC") == 0 ) && ( AV56Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_condicionpagowwds_3_conpdsc1)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV57Configuracion_condicionpagowwds_3_conpdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_condicionpagowwds_1_dynamicfiltersselector1, "CONPDSC") == 0 ) && ( AV56Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_condicionpagowwds_3_conpdsc1)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like '%' + @lV57Configuracion_condicionpagowwds_3_conpdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV58Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_condicionpagowwds_5_dynamicfiltersselector2, "CONPDSC") == 0 ) && ( AV60Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_condicionpagowwds_7_conpdsc2)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV61Configuracion_condicionpagowwds_7_conpdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV58Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_condicionpagowwds_5_dynamicfiltersselector2, "CONPDSC") == 0 ) && ( AV60Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_condicionpagowwds_7_conpdsc2)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like '%' + @lV61Configuracion_condicionpagowwds_7_conpdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV62Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_condicionpagowwds_9_dynamicfiltersselector3, "CONPDSC") == 0 ) && ( AV64Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_condicionpagowwds_11_conpdsc3)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV65Configuracion_condicionpagowwds_11_conpdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV62Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_condicionpagowwds_9_dynamicfiltersselector3, "CONPDSC") == 0 ) && ( AV64Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_condicionpagowwds_11_conpdsc3)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like '%' + @lV65Configuracion_condicionpagowwds_11_conpdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV66Configuracion_condicionpagowwds_12_tfconpcod) )
         {
            AddWhere(sWhereString, "([Conpcod] >= @AV66Configuracion_condicionpagowwds_12_tfconpcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV67Configuracion_condicionpagowwds_13_tfconpcod_to) )
         {
            AddWhere(sWhereString, "([Conpcod] <= @AV67Configuracion_condicionpagowwds_13_tfconpcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_condicionpagowwds_14_tfconpdsc)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV68Configuracion_condicionpagowwds_14_tfconpdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel)) )
         {
            AddWhere(sWhereString, "([ConpDsc] = @AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_condicionpagowwds_17_tfconpabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_condicionpagowwds_16_tfconpabr)) ) )
         {
            AddWhere(sWhereString, "([ConpAbr] like @lV70Configuracion_condicionpagowwds_16_tfconpabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_condicionpagowwds_17_tfconpabr_sel)) )
         {
            AddWhere(sWhereString, "([ConpAbr] = @AV71Configuracion_condicionpagowwds_17_tfconpabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV72Configuracion_condicionpagowwds_18_tfconpdias) )
         {
            AddWhere(sWhereString, "([ConpDias] >= @AV72Configuracion_condicionpagowwds_18_tfconpdias)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV73Configuracion_condicionpagowwds_19_tfconpdias_to) )
         {
            AddWhere(sWhereString, "([ConpDias] <= @AV73Configuracion_condicionpagowwds_19_tfconpdias_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV74Configuracion_condicionpagowwds_20_tfconpsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Configuracion_condicionpagowwds_20_tfconpsts_sels, "[ConpSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ConpDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002I3( IGxContext context ,
                                             short A754ConpSts ,
                                             GxSimpleCollection<short> AV74Configuracion_condicionpagowwds_20_tfconpsts_sels ,
                                             string AV55Configuracion_condicionpagowwds_1_dynamicfiltersselector1 ,
                                             short AV56Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 ,
                                             string AV57Configuracion_condicionpagowwds_3_conpdsc1 ,
                                             bool AV58Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 ,
                                             string AV59Configuracion_condicionpagowwds_5_dynamicfiltersselector2 ,
                                             short AV60Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 ,
                                             string AV61Configuracion_condicionpagowwds_7_conpdsc2 ,
                                             bool AV62Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 ,
                                             string AV63Configuracion_condicionpagowwds_9_dynamicfiltersselector3 ,
                                             short AV64Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 ,
                                             string AV65Configuracion_condicionpagowwds_11_conpdsc3 ,
                                             int AV66Configuracion_condicionpagowwds_12_tfconpcod ,
                                             int AV67Configuracion_condicionpagowwds_13_tfconpcod_to ,
                                             string AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel ,
                                             string AV68Configuracion_condicionpagowwds_14_tfconpdsc ,
                                             string AV71Configuracion_condicionpagowwds_17_tfconpabr_sel ,
                                             string AV70Configuracion_condicionpagowwds_16_tfconpabr ,
                                             short AV72Configuracion_condicionpagowwds_18_tfconpdias ,
                                             short AV73Configuracion_condicionpagowwds_19_tfconpdias_to ,
                                             int AV74Configuracion_condicionpagowwds_20_tfconpsts_sels_Count ,
                                             string A753ConpDsc ,
                                             int A137Conpcod ,
                                             string A751ConpAbr ,
                                             short A752ConpDias )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [ConpAbr], [ConpSts], [ConpDias], [Conpcod], [ConpDsc] FROM [CCONDICIONPAGO]";
         if ( ( StringUtil.StrCmp(AV55Configuracion_condicionpagowwds_1_dynamicfiltersselector1, "CONPDSC") == 0 ) && ( AV56Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_condicionpagowwds_3_conpdsc1)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV57Configuracion_condicionpagowwds_3_conpdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_condicionpagowwds_1_dynamicfiltersselector1, "CONPDSC") == 0 ) && ( AV56Configuracion_condicionpagowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_condicionpagowwds_3_conpdsc1)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like '%' + @lV57Configuracion_condicionpagowwds_3_conpdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV58Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_condicionpagowwds_5_dynamicfiltersselector2, "CONPDSC") == 0 ) && ( AV60Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_condicionpagowwds_7_conpdsc2)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV61Configuracion_condicionpagowwds_7_conpdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV58Configuracion_condicionpagowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_condicionpagowwds_5_dynamicfiltersselector2, "CONPDSC") == 0 ) && ( AV60Configuracion_condicionpagowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_condicionpagowwds_7_conpdsc2)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like '%' + @lV61Configuracion_condicionpagowwds_7_conpdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV62Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_condicionpagowwds_9_dynamicfiltersselector3, "CONPDSC") == 0 ) && ( AV64Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_condicionpagowwds_11_conpdsc3)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV65Configuracion_condicionpagowwds_11_conpdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV62Configuracion_condicionpagowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_condicionpagowwds_9_dynamicfiltersselector3, "CONPDSC") == 0 ) && ( AV64Configuracion_condicionpagowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_condicionpagowwds_11_conpdsc3)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like '%' + @lV65Configuracion_condicionpagowwds_11_conpdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV66Configuracion_condicionpagowwds_12_tfconpcod) )
         {
            AddWhere(sWhereString, "([Conpcod] >= @AV66Configuracion_condicionpagowwds_12_tfconpcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV67Configuracion_condicionpagowwds_13_tfconpcod_to) )
         {
            AddWhere(sWhereString, "([Conpcod] <= @AV67Configuracion_condicionpagowwds_13_tfconpcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_condicionpagowwds_14_tfconpdsc)) ) )
         {
            AddWhere(sWhereString, "([ConpDsc] like @lV68Configuracion_condicionpagowwds_14_tfconpdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel)) )
         {
            AddWhere(sWhereString, "([ConpDsc] = @AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_condicionpagowwds_17_tfconpabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_condicionpagowwds_16_tfconpabr)) ) )
         {
            AddWhere(sWhereString, "([ConpAbr] like @lV70Configuracion_condicionpagowwds_16_tfconpabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_condicionpagowwds_17_tfconpabr_sel)) )
         {
            AddWhere(sWhereString, "([ConpAbr] = @AV71Configuracion_condicionpagowwds_17_tfconpabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV72Configuracion_condicionpagowwds_18_tfconpdias) )
         {
            AddWhere(sWhereString, "([ConpDias] >= @AV72Configuracion_condicionpagowwds_18_tfconpdias)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV73Configuracion_condicionpagowwds_19_tfconpdias_to) )
         {
            AddWhere(sWhereString, "([ConpDias] <= @AV73Configuracion_condicionpagowwds_19_tfconpdias_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV74Configuracion_condicionpagowwds_20_tfconpsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Configuracion_condicionpagowwds_20_tfconpsts_sels, "[ConpSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ConpAbr]";
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
                     return conditional_P002I2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] );
               case 1 :
                     return conditional_P002I3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] );
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
          Object[] prmP002I2;
          prmP002I2 = new Object[] {
          new ParDef("@lV57Configuracion_condicionpagowwds_3_conpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_condicionpagowwds_3_conpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_condicionpagowwds_7_conpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_condicionpagowwds_7_conpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_condicionpagowwds_11_conpdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_condicionpagowwds_11_conpdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV66Configuracion_condicionpagowwds_12_tfconpcod",GXType.Int32,6,0) ,
          new ParDef("@AV67Configuracion_condicionpagowwds_13_tfconpcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV68Configuracion_condicionpagowwds_14_tfconpdsc",GXType.NChar,100,0) ,
          new ParDef("@AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_condicionpagowwds_16_tfconpabr",GXType.NChar,5,0) ,
          new ParDef("@AV71Configuracion_condicionpagowwds_17_tfconpabr_sel",GXType.NChar,5,0) ,
          new ParDef("@AV72Configuracion_condicionpagowwds_18_tfconpdias",GXType.Int16,4,0) ,
          new ParDef("@AV73Configuracion_condicionpagowwds_19_tfconpdias_to",GXType.Int16,4,0)
          };
          Object[] prmP002I3;
          prmP002I3 = new Object[] {
          new ParDef("@lV57Configuracion_condicionpagowwds_3_conpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_condicionpagowwds_3_conpdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_condicionpagowwds_7_conpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_condicionpagowwds_7_conpdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_condicionpagowwds_11_conpdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_condicionpagowwds_11_conpdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV66Configuracion_condicionpagowwds_12_tfconpcod",GXType.Int32,6,0) ,
          new ParDef("@AV67Configuracion_condicionpagowwds_13_tfconpcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV68Configuracion_condicionpagowwds_14_tfconpdsc",GXType.NChar,100,0) ,
          new ParDef("@AV69Configuracion_condicionpagowwds_15_tfconpdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_condicionpagowwds_16_tfconpabr",GXType.NChar,5,0) ,
          new ParDef("@AV71Configuracion_condicionpagowwds_17_tfconpabr_sel",GXType.NChar,5,0) ,
          new ParDef("@AV72Configuracion_condicionpagowwds_18_tfconpdias",GXType.Int16,4,0) ,
          new ParDef("@AV73Configuracion_condicionpagowwds_19_tfconpdias_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002I2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002I3,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
