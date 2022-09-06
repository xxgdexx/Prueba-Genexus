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
   public class almaceneswwgetfilterdata : GXProcedure
   {
      public almaceneswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public almaceneswwgetfilterdata( IGxContext context )
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
         this.AV24DDOName = aP0_DDOName;
         this.AV22SearchTxt = aP1_SearchTxt;
         this.AV23SearchTxtTo = aP2_SearchTxtTo;
         this.AV28OptionsJson = "" ;
         this.AV31OptionsDescJson = "" ;
         this.AV33OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV33OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         almaceneswwgetfilterdata objalmaceneswwgetfilterdata;
         objalmaceneswwgetfilterdata = new almaceneswwgetfilterdata();
         objalmaceneswwgetfilterdata.AV24DDOName = aP0_DDOName;
         objalmaceneswwgetfilterdata.AV22SearchTxt = aP1_SearchTxt;
         objalmaceneswwgetfilterdata.AV23SearchTxtTo = aP2_SearchTxtTo;
         objalmaceneswwgetfilterdata.AV28OptionsJson = "" ;
         objalmaceneswwgetfilterdata.AV31OptionsDescJson = "" ;
         objalmaceneswwgetfilterdata.AV33OptionIndexesJson = "" ;
         objalmaceneswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objalmaceneswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objalmaceneswwgetfilterdata);
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((almaceneswwgetfilterdata)stateInfo).executePrivate();
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
         AV27Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_ALMDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADALMDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_ALMDIR") == 0 )
         {
            /* Execute user subroutine: 'LOADALMDIROPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_ALMABR") == 0 )
         {
            /* Execute user subroutine: 'LOADALMABROPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV28OptionsJson = AV27Options.ToJSonString(false);
         AV31OptionsDescJson = AV30OptionsDesc.ToJSonString(false);
         AV33OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV35Session.Get("Configuracion.AlmacenesWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.AlmacenesWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("Configuracion.AlmacenesWWGridState"), null, "", "");
         }
         AV57GXV1 = 1;
         while ( AV57GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV57GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFALMCOD") == 0 )
            {
               AV10TFAlmCod = (int)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."));
               AV11TFAlmCod_To = (int)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFALMDSC") == 0 )
            {
               AV12TFAlmDsc = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFALMDSC_SEL") == 0 )
            {
               AV13TFAlmDsc_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFALMDIR") == 0 )
            {
               AV14TFAlmDir = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFALMDIR_SEL") == 0 )
            {
               AV15TFAlmDir_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFALMABR") == 0 )
            {
               AV16TFAlmAbr = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFALMABR_SEL") == 0 )
            {
               AV17TFAlmAbr_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFALMCOS") == 0 )
            {
               AV53TFAlmCos = (short)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."));
               AV54TFAlmCos_To = (short)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFALMPED_SEL") == 0 )
            {
               AV18TFAlmPed_Sel = (short)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFALMSTS_SEL") == 0 )
            {
               AV51TFAlmSts_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV52TFAlmSts_Sels.FromJSonString(AV51TFAlmSts_SelsJson, null);
            }
            AV57GXV1 = (int)(AV57GXV1+1);
         }
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV39GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "ALMDSC") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV42AlmDsc1 = AV39GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV43DynamicFiltersEnabled2 = true;
               AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV44DynamicFiltersSelector2 = AV39GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV44DynamicFiltersSelector2, "ALMDSC") == 0 )
               {
                  AV45DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV46AlmDsc2 = AV39GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV39GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "ALMDSC") == 0 )
                  {
                     AV49DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV50AlmDsc3 = AV39GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADALMDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFAlmDsc = AV22SearchTxt;
         AV13TFAlmDsc_Sel = "";
         AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV61Configuracion_almaceneswwds_3_almdsc1 = AV42AlmDsc1;
         AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV65Configuracion_almaceneswwds_7_almdsc2 = AV46AlmDsc2;
         AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV69Configuracion_almaceneswwds_11_almdsc3 = AV50AlmDsc3;
         AV70Configuracion_almaceneswwds_12_tfalmcod = AV10TFAlmCod;
         AV71Configuracion_almaceneswwds_13_tfalmcod_to = AV11TFAlmCod_To;
         AV72Configuracion_almaceneswwds_14_tfalmdsc = AV12TFAlmDsc;
         AV73Configuracion_almaceneswwds_15_tfalmdsc_sel = AV13TFAlmDsc_Sel;
         AV74Configuracion_almaceneswwds_16_tfalmdir = AV14TFAlmDir;
         AV75Configuracion_almaceneswwds_17_tfalmdir_sel = AV15TFAlmDir_Sel;
         AV76Configuracion_almaceneswwds_18_tfalmabr = AV16TFAlmAbr;
         AV77Configuracion_almaceneswwds_19_tfalmabr_sel = AV17TFAlmAbr_Sel;
         AV78Configuracion_almaceneswwds_20_tfalmcos = AV53TFAlmCos;
         AV79Configuracion_almaceneswwds_21_tfalmcos_to = AV54TFAlmCos_To;
         AV80Configuracion_almaceneswwds_22_tfalmped_sel = AV18TFAlmPed_Sel;
         AV81Configuracion_almaceneswwds_23_tfalmsts_sels = AV52TFAlmSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A438AlmSts ,
                                              AV81Configuracion_almaceneswwds_23_tfalmsts_sels ,
                                              AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1 ,
                                              AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 ,
                                              AV61Configuracion_almaceneswwds_3_almdsc1 ,
                                              AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 ,
                                              AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2 ,
                                              AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 ,
                                              AV65Configuracion_almaceneswwds_7_almdsc2 ,
                                              AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 ,
                                              AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3 ,
                                              AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 ,
                                              AV69Configuracion_almaceneswwds_11_almdsc3 ,
                                              AV70Configuracion_almaceneswwds_12_tfalmcod ,
                                              AV71Configuracion_almaceneswwds_13_tfalmcod_to ,
                                              AV73Configuracion_almaceneswwds_15_tfalmdsc_sel ,
                                              AV72Configuracion_almaceneswwds_14_tfalmdsc ,
                                              AV75Configuracion_almaceneswwds_17_tfalmdir_sel ,
                                              AV74Configuracion_almaceneswwds_16_tfalmdir ,
                                              AV77Configuracion_almaceneswwds_19_tfalmabr_sel ,
                                              AV76Configuracion_almaceneswwds_18_tfalmabr ,
                                              AV78Configuracion_almaceneswwds_20_tfalmcos ,
                                              AV79Configuracion_almaceneswwds_21_tfalmcos_to ,
                                              AV80Configuracion_almaceneswwds_22_tfalmped_sel ,
                                              AV81Configuracion_almaceneswwds_23_tfalmsts_sels.Count ,
                                              A436AlmDsc ,
                                              A63AlmCod ,
                                              A435AlmDir ,
                                              A433AlmAbr ,
                                              A434AlmCos ,
                                              A437AlmPed } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV61Configuracion_almaceneswwds_3_almdsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_almaceneswwds_3_almdsc1), 100, "%");
         lV61Configuracion_almaceneswwds_3_almdsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_almaceneswwds_3_almdsc1), 100, "%");
         lV65Configuracion_almaceneswwds_7_almdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_almaceneswwds_7_almdsc2), 100, "%");
         lV65Configuracion_almaceneswwds_7_almdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_almaceneswwds_7_almdsc2), 100, "%");
         lV69Configuracion_almaceneswwds_11_almdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_almaceneswwds_11_almdsc3), 100, "%");
         lV69Configuracion_almaceneswwds_11_almdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_almaceneswwds_11_almdsc3), 100, "%");
         lV72Configuracion_almaceneswwds_14_tfalmdsc = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_almaceneswwds_14_tfalmdsc), 100, "%");
         lV74Configuracion_almaceneswwds_16_tfalmdir = StringUtil.Concat( StringUtil.RTrim( AV74Configuracion_almaceneswwds_16_tfalmdir), "%", "");
         lV76Configuracion_almaceneswwds_18_tfalmabr = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_almaceneswwds_18_tfalmabr), 10, "%");
         /* Using cursor P002E2 */
         pr_default.execute(0, new Object[] {lV61Configuracion_almaceneswwds_3_almdsc1, lV61Configuracion_almaceneswwds_3_almdsc1, lV65Configuracion_almaceneswwds_7_almdsc2, lV65Configuracion_almaceneswwds_7_almdsc2, lV69Configuracion_almaceneswwds_11_almdsc3, lV69Configuracion_almaceneswwds_11_almdsc3, AV70Configuracion_almaceneswwds_12_tfalmcod, AV71Configuracion_almaceneswwds_13_tfalmcod_to, lV72Configuracion_almaceneswwds_14_tfalmdsc, AV73Configuracion_almaceneswwds_15_tfalmdsc_sel, lV74Configuracion_almaceneswwds_16_tfalmdir, AV75Configuracion_almaceneswwds_17_tfalmdir_sel, lV76Configuracion_almaceneswwds_18_tfalmabr, AV77Configuracion_almaceneswwds_19_tfalmabr_sel, AV78Configuracion_almaceneswwds_20_tfalmcos, AV79Configuracion_almaceneswwds_21_tfalmcos_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2E2 = false;
            A436AlmDsc = P002E2_A436AlmDsc[0];
            A438AlmSts = P002E2_A438AlmSts[0];
            A437AlmPed = P002E2_A437AlmPed[0];
            A434AlmCos = P002E2_A434AlmCos[0];
            A433AlmAbr = P002E2_A433AlmAbr[0];
            A435AlmDir = P002E2_A435AlmDir[0];
            A63AlmCod = P002E2_A63AlmCod[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002E2_A436AlmDsc[0], A436AlmDsc) == 0 ) )
            {
               BRK2E2 = false;
               A63AlmCod = P002E2_A63AlmCod[0];
               AV34count = (long)(AV34count+1);
               BRK2E2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A436AlmDsc)) )
            {
               AV26Option = A436AlmDsc;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK2E2 )
            {
               BRK2E2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADALMDIROPTIONS' Routine */
         returnInSub = false;
         AV14TFAlmDir = AV22SearchTxt;
         AV15TFAlmDir_Sel = "";
         AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV61Configuracion_almaceneswwds_3_almdsc1 = AV42AlmDsc1;
         AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV65Configuracion_almaceneswwds_7_almdsc2 = AV46AlmDsc2;
         AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV69Configuracion_almaceneswwds_11_almdsc3 = AV50AlmDsc3;
         AV70Configuracion_almaceneswwds_12_tfalmcod = AV10TFAlmCod;
         AV71Configuracion_almaceneswwds_13_tfalmcod_to = AV11TFAlmCod_To;
         AV72Configuracion_almaceneswwds_14_tfalmdsc = AV12TFAlmDsc;
         AV73Configuracion_almaceneswwds_15_tfalmdsc_sel = AV13TFAlmDsc_Sel;
         AV74Configuracion_almaceneswwds_16_tfalmdir = AV14TFAlmDir;
         AV75Configuracion_almaceneswwds_17_tfalmdir_sel = AV15TFAlmDir_Sel;
         AV76Configuracion_almaceneswwds_18_tfalmabr = AV16TFAlmAbr;
         AV77Configuracion_almaceneswwds_19_tfalmabr_sel = AV17TFAlmAbr_Sel;
         AV78Configuracion_almaceneswwds_20_tfalmcos = AV53TFAlmCos;
         AV79Configuracion_almaceneswwds_21_tfalmcos_to = AV54TFAlmCos_To;
         AV80Configuracion_almaceneswwds_22_tfalmped_sel = AV18TFAlmPed_Sel;
         AV81Configuracion_almaceneswwds_23_tfalmsts_sels = AV52TFAlmSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A438AlmSts ,
                                              AV81Configuracion_almaceneswwds_23_tfalmsts_sels ,
                                              AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1 ,
                                              AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 ,
                                              AV61Configuracion_almaceneswwds_3_almdsc1 ,
                                              AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 ,
                                              AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2 ,
                                              AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 ,
                                              AV65Configuracion_almaceneswwds_7_almdsc2 ,
                                              AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 ,
                                              AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3 ,
                                              AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 ,
                                              AV69Configuracion_almaceneswwds_11_almdsc3 ,
                                              AV70Configuracion_almaceneswwds_12_tfalmcod ,
                                              AV71Configuracion_almaceneswwds_13_tfalmcod_to ,
                                              AV73Configuracion_almaceneswwds_15_tfalmdsc_sel ,
                                              AV72Configuracion_almaceneswwds_14_tfalmdsc ,
                                              AV75Configuracion_almaceneswwds_17_tfalmdir_sel ,
                                              AV74Configuracion_almaceneswwds_16_tfalmdir ,
                                              AV77Configuracion_almaceneswwds_19_tfalmabr_sel ,
                                              AV76Configuracion_almaceneswwds_18_tfalmabr ,
                                              AV78Configuracion_almaceneswwds_20_tfalmcos ,
                                              AV79Configuracion_almaceneswwds_21_tfalmcos_to ,
                                              AV80Configuracion_almaceneswwds_22_tfalmped_sel ,
                                              AV81Configuracion_almaceneswwds_23_tfalmsts_sels.Count ,
                                              A436AlmDsc ,
                                              A63AlmCod ,
                                              A435AlmDir ,
                                              A433AlmAbr ,
                                              A434AlmCos ,
                                              A437AlmPed } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV61Configuracion_almaceneswwds_3_almdsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_almaceneswwds_3_almdsc1), 100, "%");
         lV61Configuracion_almaceneswwds_3_almdsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_almaceneswwds_3_almdsc1), 100, "%");
         lV65Configuracion_almaceneswwds_7_almdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_almaceneswwds_7_almdsc2), 100, "%");
         lV65Configuracion_almaceneswwds_7_almdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_almaceneswwds_7_almdsc2), 100, "%");
         lV69Configuracion_almaceneswwds_11_almdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_almaceneswwds_11_almdsc3), 100, "%");
         lV69Configuracion_almaceneswwds_11_almdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_almaceneswwds_11_almdsc3), 100, "%");
         lV72Configuracion_almaceneswwds_14_tfalmdsc = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_almaceneswwds_14_tfalmdsc), 100, "%");
         lV74Configuracion_almaceneswwds_16_tfalmdir = StringUtil.Concat( StringUtil.RTrim( AV74Configuracion_almaceneswwds_16_tfalmdir), "%", "");
         lV76Configuracion_almaceneswwds_18_tfalmabr = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_almaceneswwds_18_tfalmabr), 10, "%");
         /* Using cursor P002E3 */
         pr_default.execute(1, new Object[] {lV61Configuracion_almaceneswwds_3_almdsc1, lV61Configuracion_almaceneswwds_3_almdsc1, lV65Configuracion_almaceneswwds_7_almdsc2, lV65Configuracion_almaceneswwds_7_almdsc2, lV69Configuracion_almaceneswwds_11_almdsc3, lV69Configuracion_almaceneswwds_11_almdsc3, AV70Configuracion_almaceneswwds_12_tfalmcod, AV71Configuracion_almaceneswwds_13_tfalmcod_to, lV72Configuracion_almaceneswwds_14_tfalmdsc, AV73Configuracion_almaceneswwds_15_tfalmdsc_sel, lV74Configuracion_almaceneswwds_16_tfalmdir, AV75Configuracion_almaceneswwds_17_tfalmdir_sel, lV76Configuracion_almaceneswwds_18_tfalmabr, AV77Configuracion_almaceneswwds_19_tfalmabr_sel, AV78Configuracion_almaceneswwds_20_tfalmcos, AV79Configuracion_almaceneswwds_21_tfalmcos_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2E4 = false;
            A435AlmDir = P002E3_A435AlmDir[0];
            A438AlmSts = P002E3_A438AlmSts[0];
            A437AlmPed = P002E3_A437AlmPed[0];
            A434AlmCos = P002E3_A434AlmCos[0];
            A433AlmAbr = P002E3_A433AlmAbr[0];
            A63AlmCod = P002E3_A63AlmCod[0];
            A436AlmDsc = P002E3_A436AlmDsc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002E3_A435AlmDir[0], A435AlmDir) == 0 ) )
            {
               BRK2E4 = false;
               A63AlmCod = P002E3_A63AlmCod[0];
               AV34count = (long)(AV34count+1);
               BRK2E4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A435AlmDir)) )
            {
               AV26Option = A435AlmDir;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK2E4 )
            {
               BRK2E4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADALMABROPTIONS' Routine */
         returnInSub = false;
         AV16TFAlmAbr = AV22SearchTxt;
         AV17TFAlmAbr_Sel = "";
         AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV61Configuracion_almaceneswwds_3_almdsc1 = AV42AlmDsc1;
         AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV65Configuracion_almaceneswwds_7_almdsc2 = AV46AlmDsc2;
         AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV69Configuracion_almaceneswwds_11_almdsc3 = AV50AlmDsc3;
         AV70Configuracion_almaceneswwds_12_tfalmcod = AV10TFAlmCod;
         AV71Configuracion_almaceneswwds_13_tfalmcod_to = AV11TFAlmCod_To;
         AV72Configuracion_almaceneswwds_14_tfalmdsc = AV12TFAlmDsc;
         AV73Configuracion_almaceneswwds_15_tfalmdsc_sel = AV13TFAlmDsc_Sel;
         AV74Configuracion_almaceneswwds_16_tfalmdir = AV14TFAlmDir;
         AV75Configuracion_almaceneswwds_17_tfalmdir_sel = AV15TFAlmDir_Sel;
         AV76Configuracion_almaceneswwds_18_tfalmabr = AV16TFAlmAbr;
         AV77Configuracion_almaceneswwds_19_tfalmabr_sel = AV17TFAlmAbr_Sel;
         AV78Configuracion_almaceneswwds_20_tfalmcos = AV53TFAlmCos;
         AV79Configuracion_almaceneswwds_21_tfalmcos_to = AV54TFAlmCos_To;
         AV80Configuracion_almaceneswwds_22_tfalmped_sel = AV18TFAlmPed_Sel;
         AV81Configuracion_almaceneswwds_23_tfalmsts_sels = AV52TFAlmSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A438AlmSts ,
                                              AV81Configuracion_almaceneswwds_23_tfalmsts_sels ,
                                              AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1 ,
                                              AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 ,
                                              AV61Configuracion_almaceneswwds_3_almdsc1 ,
                                              AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 ,
                                              AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2 ,
                                              AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 ,
                                              AV65Configuracion_almaceneswwds_7_almdsc2 ,
                                              AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 ,
                                              AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3 ,
                                              AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 ,
                                              AV69Configuracion_almaceneswwds_11_almdsc3 ,
                                              AV70Configuracion_almaceneswwds_12_tfalmcod ,
                                              AV71Configuracion_almaceneswwds_13_tfalmcod_to ,
                                              AV73Configuracion_almaceneswwds_15_tfalmdsc_sel ,
                                              AV72Configuracion_almaceneswwds_14_tfalmdsc ,
                                              AV75Configuracion_almaceneswwds_17_tfalmdir_sel ,
                                              AV74Configuracion_almaceneswwds_16_tfalmdir ,
                                              AV77Configuracion_almaceneswwds_19_tfalmabr_sel ,
                                              AV76Configuracion_almaceneswwds_18_tfalmabr ,
                                              AV78Configuracion_almaceneswwds_20_tfalmcos ,
                                              AV79Configuracion_almaceneswwds_21_tfalmcos_to ,
                                              AV80Configuracion_almaceneswwds_22_tfalmped_sel ,
                                              AV81Configuracion_almaceneswwds_23_tfalmsts_sels.Count ,
                                              A436AlmDsc ,
                                              A63AlmCod ,
                                              A435AlmDir ,
                                              A433AlmAbr ,
                                              A434AlmCos ,
                                              A437AlmPed } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV61Configuracion_almaceneswwds_3_almdsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_almaceneswwds_3_almdsc1), 100, "%");
         lV61Configuracion_almaceneswwds_3_almdsc1 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_almaceneswwds_3_almdsc1), 100, "%");
         lV65Configuracion_almaceneswwds_7_almdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_almaceneswwds_7_almdsc2), 100, "%");
         lV65Configuracion_almaceneswwds_7_almdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_almaceneswwds_7_almdsc2), 100, "%");
         lV69Configuracion_almaceneswwds_11_almdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_almaceneswwds_11_almdsc3), 100, "%");
         lV69Configuracion_almaceneswwds_11_almdsc3 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_almaceneswwds_11_almdsc3), 100, "%");
         lV72Configuracion_almaceneswwds_14_tfalmdsc = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_almaceneswwds_14_tfalmdsc), 100, "%");
         lV74Configuracion_almaceneswwds_16_tfalmdir = StringUtil.Concat( StringUtil.RTrim( AV74Configuracion_almaceneswwds_16_tfalmdir), "%", "");
         lV76Configuracion_almaceneswwds_18_tfalmabr = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_almaceneswwds_18_tfalmabr), 10, "%");
         /* Using cursor P002E4 */
         pr_default.execute(2, new Object[] {lV61Configuracion_almaceneswwds_3_almdsc1, lV61Configuracion_almaceneswwds_3_almdsc1, lV65Configuracion_almaceneswwds_7_almdsc2, lV65Configuracion_almaceneswwds_7_almdsc2, lV69Configuracion_almaceneswwds_11_almdsc3, lV69Configuracion_almaceneswwds_11_almdsc3, AV70Configuracion_almaceneswwds_12_tfalmcod, AV71Configuracion_almaceneswwds_13_tfalmcod_to, lV72Configuracion_almaceneswwds_14_tfalmdsc, AV73Configuracion_almaceneswwds_15_tfalmdsc_sel, lV74Configuracion_almaceneswwds_16_tfalmdir, AV75Configuracion_almaceneswwds_17_tfalmdir_sel, lV76Configuracion_almaceneswwds_18_tfalmabr, AV77Configuracion_almaceneswwds_19_tfalmabr_sel, AV78Configuracion_almaceneswwds_20_tfalmcos, AV79Configuracion_almaceneswwds_21_tfalmcos_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2E6 = false;
            A433AlmAbr = P002E4_A433AlmAbr[0];
            A438AlmSts = P002E4_A438AlmSts[0];
            A437AlmPed = P002E4_A437AlmPed[0];
            A434AlmCos = P002E4_A434AlmCos[0];
            A435AlmDir = P002E4_A435AlmDir[0];
            A63AlmCod = P002E4_A63AlmCod[0];
            A436AlmDsc = P002E4_A436AlmDsc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P002E4_A433AlmAbr[0], A433AlmAbr) == 0 ) )
            {
               BRK2E6 = false;
               A63AlmCod = P002E4_A63AlmCod[0];
               AV34count = (long)(AV34count+1);
               BRK2E6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A433AlmAbr)) )
            {
               AV26Option = A433AlmAbr;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK2E6 )
            {
               BRK2E6 = true;
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
         AV28OptionsJson = "";
         AV31OptionsDescJson = "";
         AV33OptionIndexesJson = "";
         AV27Options = new GxSimpleCollection<string>();
         AV30OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV35Session = context.GetSession();
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV12TFAlmDsc = "";
         AV13TFAlmDsc_Sel = "";
         AV14TFAlmDir = "";
         AV15TFAlmDir_Sel = "";
         AV16TFAlmAbr = "";
         AV17TFAlmAbr_Sel = "";
         AV51TFAlmSts_SelsJson = "";
         AV52TFAlmSts_Sels = new GxSimpleCollection<short>();
         AV39GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV42AlmDsc1 = "";
         AV44DynamicFiltersSelector2 = "";
         AV46AlmDsc2 = "";
         AV48DynamicFiltersSelector3 = "";
         AV50AlmDsc3 = "";
         AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1 = "";
         AV61Configuracion_almaceneswwds_3_almdsc1 = "";
         AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2 = "";
         AV65Configuracion_almaceneswwds_7_almdsc2 = "";
         AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3 = "";
         AV69Configuracion_almaceneswwds_11_almdsc3 = "";
         AV72Configuracion_almaceneswwds_14_tfalmdsc = "";
         AV73Configuracion_almaceneswwds_15_tfalmdsc_sel = "";
         AV74Configuracion_almaceneswwds_16_tfalmdir = "";
         AV75Configuracion_almaceneswwds_17_tfalmdir_sel = "";
         AV76Configuracion_almaceneswwds_18_tfalmabr = "";
         AV77Configuracion_almaceneswwds_19_tfalmabr_sel = "";
         AV81Configuracion_almaceneswwds_23_tfalmsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV61Configuracion_almaceneswwds_3_almdsc1 = "";
         lV65Configuracion_almaceneswwds_7_almdsc2 = "";
         lV69Configuracion_almaceneswwds_11_almdsc3 = "";
         lV72Configuracion_almaceneswwds_14_tfalmdsc = "";
         lV74Configuracion_almaceneswwds_16_tfalmdir = "";
         lV76Configuracion_almaceneswwds_18_tfalmabr = "";
         A436AlmDsc = "";
         A435AlmDir = "";
         A433AlmAbr = "";
         P002E2_A436AlmDsc = new string[] {""} ;
         P002E2_A438AlmSts = new short[1] ;
         P002E2_A437AlmPed = new short[1] ;
         P002E2_A434AlmCos = new short[1] ;
         P002E2_A433AlmAbr = new string[] {""} ;
         P002E2_A435AlmDir = new string[] {""} ;
         P002E2_A63AlmCod = new int[1] ;
         AV26Option = "";
         P002E3_A435AlmDir = new string[] {""} ;
         P002E3_A438AlmSts = new short[1] ;
         P002E3_A437AlmPed = new short[1] ;
         P002E3_A434AlmCos = new short[1] ;
         P002E3_A433AlmAbr = new string[] {""} ;
         P002E3_A63AlmCod = new int[1] ;
         P002E3_A436AlmDsc = new string[] {""} ;
         P002E4_A433AlmAbr = new string[] {""} ;
         P002E4_A438AlmSts = new short[1] ;
         P002E4_A437AlmPed = new short[1] ;
         P002E4_A434AlmCos = new short[1] ;
         P002E4_A435AlmDir = new string[] {""} ;
         P002E4_A63AlmCod = new int[1] ;
         P002E4_A436AlmDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.almaceneswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002E2_A436AlmDsc, P002E2_A438AlmSts, P002E2_A437AlmPed, P002E2_A434AlmCos, P002E2_A433AlmAbr, P002E2_A435AlmDir, P002E2_A63AlmCod
               }
               , new Object[] {
               P002E3_A435AlmDir, P002E3_A438AlmSts, P002E3_A437AlmPed, P002E3_A434AlmCos, P002E3_A433AlmAbr, P002E3_A63AlmCod, P002E3_A436AlmDsc
               }
               , new Object[] {
               P002E4_A433AlmAbr, P002E4_A438AlmSts, P002E4_A437AlmPed, P002E4_A434AlmCos, P002E4_A435AlmDir, P002E4_A63AlmCod, P002E4_A436AlmDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV53TFAlmCos ;
      private short AV54TFAlmCos_To ;
      private short AV18TFAlmPed_Sel ;
      private short AV41DynamicFiltersOperator1 ;
      private short AV45DynamicFiltersOperator2 ;
      private short AV49DynamicFiltersOperator3 ;
      private short AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 ;
      private short AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 ;
      private short AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 ;
      private short AV78Configuracion_almaceneswwds_20_tfalmcos ;
      private short AV79Configuracion_almaceneswwds_21_tfalmcos_to ;
      private short AV80Configuracion_almaceneswwds_22_tfalmped_sel ;
      private short A438AlmSts ;
      private short A434AlmCos ;
      private short A437AlmPed ;
      private int AV57GXV1 ;
      private int AV10TFAlmCod ;
      private int AV11TFAlmCod_To ;
      private int AV70Configuracion_almaceneswwds_12_tfalmcod ;
      private int AV71Configuracion_almaceneswwds_13_tfalmcod_to ;
      private int AV81Configuracion_almaceneswwds_23_tfalmsts_sels_Count ;
      private int A63AlmCod ;
      private long AV34count ;
      private string AV12TFAlmDsc ;
      private string AV13TFAlmDsc_Sel ;
      private string AV16TFAlmAbr ;
      private string AV17TFAlmAbr_Sel ;
      private string AV42AlmDsc1 ;
      private string AV46AlmDsc2 ;
      private string AV50AlmDsc3 ;
      private string AV61Configuracion_almaceneswwds_3_almdsc1 ;
      private string AV65Configuracion_almaceneswwds_7_almdsc2 ;
      private string AV69Configuracion_almaceneswwds_11_almdsc3 ;
      private string AV72Configuracion_almaceneswwds_14_tfalmdsc ;
      private string AV73Configuracion_almaceneswwds_15_tfalmdsc_sel ;
      private string AV76Configuracion_almaceneswwds_18_tfalmabr ;
      private string AV77Configuracion_almaceneswwds_19_tfalmabr_sel ;
      private string scmdbuf ;
      private string lV61Configuracion_almaceneswwds_3_almdsc1 ;
      private string lV65Configuracion_almaceneswwds_7_almdsc2 ;
      private string lV69Configuracion_almaceneswwds_11_almdsc3 ;
      private string lV72Configuracion_almaceneswwds_14_tfalmdsc ;
      private string lV76Configuracion_almaceneswwds_18_tfalmabr ;
      private string A436AlmDsc ;
      private string A433AlmAbr ;
      private bool returnInSub ;
      private bool AV43DynamicFiltersEnabled2 ;
      private bool AV47DynamicFiltersEnabled3 ;
      private bool AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 ;
      private bool AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 ;
      private bool BRK2E2 ;
      private bool BRK2E4 ;
      private bool BRK2E6 ;
      private string AV28OptionsJson ;
      private string AV31OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV51TFAlmSts_SelsJson ;
      private string AV24DDOName ;
      private string AV22SearchTxt ;
      private string AV23SearchTxtTo ;
      private string AV14TFAlmDir ;
      private string AV15TFAlmDir_Sel ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV44DynamicFiltersSelector2 ;
      private string AV48DynamicFiltersSelector3 ;
      private string AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1 ;
      private string AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2 ;
      private string AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3 ;
      private string AV74Configuracion_almaceneswwds_16_tfalmdir ;
      private string AV75Configuracion_almaceneswwds_17_tfalmdir_sel ;
      private string lV74Configuracion_almaceneswwds_16_tfalmdir ;
      private string A435AlmDir ;
      private string AV26Option ;
      private GxSimpleCollection<short> AV52TFAlmSts_Sels ;
      private GxSimpleCollection<short> AV81Configuracion_almaceneswwds_23_tfalmsts_sels ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002E2_A436AlmDsc ;
      private short[] P002E2_A438AlmSts ;
      private short[] P002E2_A437AlmPed ;
      private short[] P002E2_A434AlmCos ;
      private string[] P002E2_A433AlmAbr ;
      private string[] P002E2_A435AlmDir ;
      private int[] P002E2_A63AlmCod ;
      private string[] P002E3_A435AlmDir ;
      private short[] P002E3_A438AlmSts ;
      private short[] P002E3_A437AlmPed ;
      private short[] P002E3_A434AlmCos ;
      private string[] P002E3_A433AlmAbr ;
      private int[] P002E3_A63AlmCod ;
      private string[] P002E3_A436AlmDsc ;
      private string[] P002E4_A433AlmAbr ;
      private short[] P002E4_A438AlmSts ;
      private short[] P002E4_A437AlmPed ;
      private short[] P002E4_A434AlmCos ;
      private string[] P002E4_A435AlmDir ;
      private int[] P002E4_A63AlmCod ;
      private string[] P002E4_A436AlmDsc ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV30OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV39GridStateDynamicFilter ;
   }

   public class almaceneswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002E2( IGxContext context ,
                                             short A438AlmSts ,
                                             GxSimpleCollection<short> AV81Configuracion_almaceneswwds_23_tfalmsts_sels ,
                                             string AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1 ,
                                             short AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 ,
                                             string AV61Configuracion_almaceneswwds_3_almdsc1 ,
                                             bool AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 ,
                                             string AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2 ,
                                             short AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 ,
                                             string AV65Configuracion_almaceneswwds_7_almdsc2 ,
                                             bool AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 ,
                                             string AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3 ,
                                             short AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 ,
                                             string AV69Configuracion_almaceneswwds_11_almdsc3 ,
                                             int AV70Configuracion_almaceneswwds_12_tfalmcod ,
                                             int AV71Configuracion_almaceneswwds_13_tfalmcod_to ,
                                             string AV73Configuracion_almaceneswwds_15_tfalmdsc_sel ,
                                             string AV72Configuracion_almaceneswwds_14_tfalmdsc ,
                                             string AV75Configuracion_almaceneswwds_17_tfalmdir_sel ,
                                             string AV74Configuracion_almaceneswwds_16_tfalmdir ,
                                             string AV77Configuracion_almaceneswwds_19_tfalmabr_sel ,
                                             string AV76Configuracion_almaceneswwds_18_tfalmabr ,
                                             short AV78Configuracion_almaceneswwds_20_tfalmcos ,
                                             short AV79Configuracion_almaceneswwds_21_tfalmcos_to ,
                                             short AV80Configuracion_almaceneswwds_22_tfalmped_sel ,
                                             int AV81Configuracion_almaceneswwds_23_tfalmsts_sels_Count ,
                                             string A436AlmDsc ,
                                             int A63AlmCod ,
                                             string A435AlmDir ,
                                             string A433AlmAbr ,
                                             short A434AlmCos ,
                                             short A437AlmPed )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[16];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [AlmDsc], [AlmSts], [AlmPed], [AlmCos], [AlmAbr], [AlmDir], [AlmCod] FROM [CALMACEN]";
         if ( ( StringUtil.StrCmp(AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1, "ALMDSC") == 0 ) && ( AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_almaceneswwds_3_almdsc1)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV61Configuracion_almaceneswwds_3_almdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1, "ALMDSC") == 0 ) && ( AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_almaceneswwds_3_almdsc1)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like '%' + @lV61Configuracion_almaceneswwds_3_almdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2, "ALMDSC") == 0 ) && ( AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_almaceneswwds_7_almdsc2)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV65Configuracion_almaceneswwds_7_almdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2, "ALMDSC") == 0 ) && ( AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_almaceneswwds_7_almdsc2)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like '%' + @lV65Configuracion_almaceneswwds_7_almdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3, "ALMDSC") == 0 ) && ( AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_almaceneswwds_11_almdsc3)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV69Configuracion_almaceneswwds_11_almdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3, "ALMDSC") == 0 ) && ( AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_almaceneswwds_11_almdsc3)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like '%' + @lV69Configuracion_almaceneswwds_11_almdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV70Configuracion_almaceneswwds_12_tfalmcod) )
         {
            AddWhere(sWhereString, "([AlmCod] >= @AV70Configuracion_almaceneswwds_12_tfalmcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV71Configuracion_almaceneswwds_13_tfalmcod_to) )
         {
            AddWhere(sWhereString, "([AlmCod] <= @AV71Configuracion_almaceneswwds_13_tfalmcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_almaceneswwds_15_tfalmdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_almaceneswwds_14_tfalmdsc)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV72Configuracion_almaceneswwds_14_tfalmdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_almaceneswwds_15_tfalmdsc_sel)) )
         {
            AddWhere(sWhereString, "([AlmDsc] = @AV73Configuracion_almaceneswwds_15_tfalmdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_almaceneswwds_17_tfalmdir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_almaceneswwds_16_tfalmdir)) ) )
         {
            AddWhere(sWhereString, "([AlmDir] like @lV74Configuracion_almaceneswwds_16_tfalmdir)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_almaceneswwds_17_tfalmdir_sel)) )
         {
            AddWhere(sWhereString, "([AlmDir] = @AV75Configuracion_almaceneswwds_17_tfalmdir_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_almaceneswwds_19_tfalmabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_almaceneswwds_18_tfalmabr)) ) )
         {
            AddWhere(sWhereString, "([AlmAbr] like @lV76Configuracion_almaceneswwds_18_tfalmabr)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_almaceneswwds_19_tfalmabr_sel)) )
         {
            AddWhere(sWhereString, "([AlmAbr] = @AV77Configuracion_almaceneswwds_19_tfalmabr_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (0==AV78Configuracion_almaceneswwds_20_tfalmcos) )
         {
            AddWhere(sWhereString, "([AlmCos] >= @AV78Configuracion_almaceneswwds_20_tfalmcos)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! (0==AV79Configuracion_almaceneswwds_21_tfalmcos_to) )
         {
            AddWhere(sWhereString, "([AlmCos] <= @AV79Configuracion_almaceneswwds_21_tfalmcos_to)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV80Configuracion_almaceneswwds_22_tfalmped_sel == 1 )
         {
            AddWhere(sWhereString, "([AlmPed] = 1)");
         }
         if ( AV80Configuracion_almaceneswwds_22_tfalmped_sel == 2 )
         {
            AddWhere(sWhereString, "([AlmPed] = 0)");
         }
         if ( AV81Configuracion_almaceneswwds_23_tfalmsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81Configuracion_almaceneswwds_23_tfalmsts_sels, "[AlmSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [AlmDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002E3( IGxContext context ,
                                             short A438AlmSts ,
                                             GxSimpleCollection<short> AV81Configuracion_almaceneswwds_23_tfalmsts_sels ,
                                             string AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1 ,
                                             short AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 ,
                                             string AV61Configuracion_almaceneswwds_3_almdsc1 ,
                                             bool AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 ,
                                             string AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2 ,
                                             short AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 ,
                                             string AV65Configuracion_almaceneswwds_7_almdsc2 ,
                                             bool AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 ,
                                             string AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3 ,
                                             short AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 ,
                                             string AV69Configuracion_almaceneswwds_11_almdsc3 ,
                                             int AV70Configuracion_almaceneswwds_12_tfalmcod ,
                                             int AV71Configuracion_almaceneswwds_13_tfalmcod_to ,
                                             string AV73Configuracion_almaceneswwds_15_tfalmdsc_sel ,
                                             string AV72Configuracion_almaceneswwds_14_tfalmdsc ,
                                             string AV75Configuracion_almaceneswwds_17_tfalmdir_sel ,
                                             string AV74Configuracion_almaceneswwds_16_tfalmdir ,
                                             string AV77Configuracion_almaceneswwds_19_tfalmabr_sel ,
                                             string AV76Configuracion_almaceneswwds_18_tfalmabr ,
                                             short AV78Configuracion_almaceneswwds_20_tfalmcos ,
                                             short AV79Configuracion_almaceneswwds_21_tfalmcos_to ,
                                             short AV80Configuracion_almaceneswwds_22_tfalmped_sel ,
                                             int AV81Configuracion_almaceneswwds_23_tfalmsts_sels_Count ,
                                             string A436AlmDsc ,
                                             int A63AlmCod ,
                                             string A435AlmDir ,
                                             string A433AlmAbr ,
                                             short A434AlmCos ,
                                             short A437AlmPed )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [AlmDir], [AlmSts], [AlmPed], [AlmCos], [AlmAbr], [AlmCod], [AlmDsc] FROM [CALMACEN]";
         if ( ( StringUtil.StrCmp(AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1, "ALMDSC") == 0 ) && ( AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_almaceneswwds_3_almdsc1)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV61Configuracion_almaceneswwds_3_almdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1, "ALMDSC") == 0 ) && ( AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_almaceneswwds_3_almdsc1)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like '%' + @lV61Configuracion_almaceneswwds_3_almdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2, "ALMDSC") == 0 ) && ( AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_almaceneswwds_7_almdsc2)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV65Configuracion_almaceneswwds_7_almdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2, "ALMDSC") == 0 ) && ( AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_almaceneswwds_7_almdsc2)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like '%' + @lV65Configuracion_almaceneswwds_7_almdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3, "ALMDSC") == 0 ) && ( AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_almaceneswwds_11_almdsc3)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV69Configuracion_almaceneswwds_11_almdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3, "ALMDSC") == 0 ) && ( AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_almaceneswwds_11_almdsc3)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like '%' + @lV69Configuracion_almaceneswwds_11_almdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV70Configuracion_almaceneswwds_12_tfalmcod) )
         {
            AddWhere(sWhereString, "([AlmCod] >= @AV70Configuracion_almaceneswwds_12_tfalmcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV71Configuracion_almaceneswwds_13_tfalmcod_to) )
         {
            AddWhere(sWhereString, "([AlmCod] <= @AV71Configuracion_almaceneswwds_13_tfalmcod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_almaceneswwds_15_tfalmdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_almaceneswwds_14_tfalmdsc)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV72Configuracion_almaceneswwds_14_tfalmdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_almaceneswwds_15_tfalmdsc_sel)) )
         {
            AddWhere(sWhereString, "([AlmDsc] = @AV73Configuracion_almaceneswwds_15_tfalmdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_almaceneswwds_17_tfalmdir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_almaceneswwds_16_tfalmdir)) ) )
         {
            AddWhere(sWhereString, "([AlmDir] like @lV74Configuracion_almaceneswwds_16_tfalmdir)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_almaceneswwds_17_tfalmdir_sel)) )
         {
            AddWhere(sWhereString, "([AlmDir] = @AV75Configuracion_almaceneswwds_17_tfalmdir_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_almaceneswwds_19_tfalmabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_almaceneswwds_18_tfalmabr)) ) )
         {
            AddWhere(sWhereString, "([AlmAbr] like @lV76Configuracion_almaceneswwds_18_tfalmabr)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_almaceneswwds_19_tfalmabr_sel)) )
         {
            AddWhere(sWhereString, "([AlmAbr] = @AV77Configuracion_almaceneswwds_19_tfalmabr_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (0==AV78Configuracion_almaceneswwds_20_tfalmcos) )
         {
            AddWhere(sWhereString, "([AlmCos] >= @AV78Configuracion_almaceneswwds_20_tfalmcos)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! (0==AV79Configuracion_almaceneswwds_21_tfalmcos_to) )
         {
            AddWhere(sWhereString, "([AlmCos] <= @AV79Configuracion_almaceneswwds_21_tfalmcos_to)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV80Configuracion_almaceneswwds_22_tfalmped_sel == 1 )
         {
            AddWhere(sWhereString, "([AlmPed] = 1)");
         }
         if ( AV80Configuracion_almaceneswwds_22_tfalmped_sel == 2 )
         {
            AddWhere(sWhereString, "([AlmPed] = 0)");
         }
         if ( AV81Configuracion_almaceneswwds_23_tfalmsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81Configuracion_almaceneswwds_23_tfalmsts_sels, "[AlmSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [AlmDir]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P002E4( IGxContext context ,
                                             short A438AlmSts ,
                                             GxSimpleCollection<short> AV81Configuracion_almaceneswwds_23_tfalmsts_sels ,
                                             string AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1 ,
                                             short AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 ,
                                             string AV61Configuracion_almaceneswwds_3_almdsc1 ,
                                             bool AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 ,
                                             string AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2 ,
                                             short AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 ,
                                             string AV65Configuracion_almaceneswwds_7_almdsc2 ,
                                             bool AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 ,
                                             string AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3 ,
                                             short AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 ,
                                             string AV69Configuracion_almaceneswwds_11_almdsc3 ,
                                             int AV70Configuracion_almaceneswwds_12_tfalmcod ,
                                             int AV71Configuracion_almaceneswwds_13_tfalmcod_to ,
                                             string AV73Configuracion_almaceneswwds_15_tfalmdsc_sel ,
                                             string AV72Configuracion_almaceneswwds_14_tfalmdsc ,
                                             string AV75Configuracion_almaceneswwds_17_tfalmdir_sel ,
                                             string AV74Configuracion_almaceneswwds_16_tfalmdir ,
                                             string AV77Configuracion_almaceneswwds_19_tfalmabr_sel ,
                                             string AV76Configuracion_almaceneswwds_18_tfalmabr ,
                                             short AV78Configuracion_almaceneswwds_20_tfalmcos ,
                                             short AV79Configuracion_almaceneswwds_21_tfalmcos_to ,
                                             short AV80Configuracion_almaceneswwds_22_tfalmped_sel ,
                                             int AV81Configuracion_almaceneswwds_23_tfalmsts_sels_Count ,
                                             string A436AlmDsc ,
                                             int A63AlmCod ,
                                             string A435AlmDir ,
                                             string A433AlmAbr ,
                                             short A434AlmCos ,
                                             short A437AlmPed )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[16];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [AlmAbr], [AlmSts], [AlmPed], [AlmCos], [AlmDir], [AlmCod], [AlmDsc] FROM [CALMACEN]";
         if ( ( StringUtil.StrCmp(AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1, "ALMDSC") == 0 ) && ( AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_almaceneswwds_3_almdsc1)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV61Configuracion_almaceneswwds_3_almdsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Configuracion_almaceneswwds_1_dynamicfiltersselector1, "ALMDSC") == 0 ) && ( AV60Configuracion_almaceneswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_almaceneswwds_3_almdsc1)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like '%' + @lV61Configuracion_almaceneswwds_3_almdsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2, "ALMDSC") == 0 ) && ( AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_almaceneswwds_7_almdsc2)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV65Configuracion_almaceneswwds_7_almdsc2)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV62Configuracion_almaceneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_almaceneswwds_5_dynamicfiltersselector2, "ALMDSC") == 0 ) && ( AV64Configuracion_almaceneswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_almaceneswwds_7_almdsc2)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like '%' + @lV65Configuracion_almaceneswwds_7_almdsc2)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3, "ALMDSC") == 0 ) && ( AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_almaceneswwds_11_almdsc3)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV69Configuracion_almaceneswwds_11_almdsc3)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV66Configuracion_almaceneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Configuracion_almaceneswwds_9_dynamicfiltersselector3, "ALMDSC") == 0 ) && ( AV68Configuracion_almaceneswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_almaceneswwds_11_almdsc3)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like '%' + @lV69Configuracion_almaceneswwds_11_almdsc3)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV70Configuracion_almaceneswwds_12_tfalmcod) )
         {
            AddWhere(sWhereString, "([AlmCod] >= @AV70Configuracion_almaceneswwds_12_tfalmcod)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV71Configuracion_almaceneswwds_13_tfalmcod_to) )
         {
            AddWhere(sWhereString, "([AlmCod] <= @AV71Configuracion_almaceneswwds_13_tfalmcod_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_almaceneswwds_15_tfalmdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_almaceneswwds_14_tfalmdsc)) ) )
         {
            AddWhere(sWhereString, "([AlmDsc] like @lV72Configuracion_almaceneswwds_14_tfalmdsc)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_almaceneswwds_15_tfalmdsc_sel)) )
         {
            AddWhere(sWhereString, "([AlmDsc] = @AV73Configuracion_almaceneswwds_15_tfalmdsc_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_almaceneswwds_17_tfalmdir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_almaceneswwds_16_tfalmdir)) ) )
         {
            AddWhere(sWhereString, "([AlmDir] like @lV74Configuracion_almaceneswwds_16_tfalmdir)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_almaceneswwds_17_tfalmdir_sel)) )
         {
            AddWhere(sWhereString, "([AlmDir] = @AV75Configuracion_almaceneswwds_17_tfalmdir_sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_almaceneswwds_19_tfalmabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_almaceneswwds_18_tfalmabr)) ) )
         {
            AddWhere(sWhereString, "([AlmAbr] like @lV76Configuracion_almaceneswwds_18_tfalmabr)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_almaceneswwds_19_tfalmabr_sel)) )
         {
            AddWhere(sWhereString, "([AlmAbr] = @AV77Configuracion_almaceneswwds_19_tfalmabr_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( ! (0==AV78Configuracion_almaceneswwds_20_tfalmcos) )
         {
            AddWhere(sWhereString, "([AlmCos] >= @AV78Configuracion_almaceneswwds_20_tfalmcos)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! (0==AV79Configuracion_almaceneswwds_21_tfalmcos_to) )
         {
            AddWhere(sWhereString, "([AlmCos] <= @AV79Configuracion_almaceneswwds_21_tfalmcos_to)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV80Configuracion_almaceneswwds_22_tfalmped_sel == 1 )
         {
            AddWhere(sWhereString, "([AlmPed] = 1)");
         }
         if ( AV80Configuracion_almaceneswwds_22_tfalmped_sel == 2 )
         {
            AddWhere(sWhereString, "([AlmPed] = 0)");
         }
         if ( AV81Configuracion_almaceneswwds_23_tfalmsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81Configuracion_almaceneswwds_23_tfalmsts_sels, "[AlmSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [AlmAbr]";
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
                     return conditional_P002E2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (short)dynConstraints[30] );
               case 1 :
                     return conditional_P002E3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (short)dynConstraints[30] );
               case 2 :
                     return conditional_P002E4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (short)dynConstraints[30] );
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
          Object[] prmP002E2;
          prmP002E2 = new Object[] {
          new ParDef("@lV61Configuracion_almaceneswwds_3_almdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_almaceneswwds_3_almdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_almaceneswwds_7_almdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_almaceneswwds_7_almdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_almaceneswwds_11_almdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_almaceneswwds_11_almdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV70Configuracion_almaceneswwds_12_tfalmcod",GXType.Int32,6,0) ,
          new ParDef("@AV71Configuracion_almaceneswwds_13_tfalmcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV72Configuracion_almaceneswwds_14_tfalmdsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Configuracion_almaceneswwds_15_tfalmdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_almaceneswwds_16_tfalmdir",GXType.NVarChar,100,0) ,
          new ParDef("@AV75Configuracion_almaceneswwds_17_tfalmdir_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV76Configuracion_almaceneswwds_18_tfalmabr",GXType.NChar,10,0) ,
          new ParDef("@AV77Configuracion_almaceneswwds_19_tfalmabr_sel",GXType.NChar,10,0) ,
          new ParDef("@AV78Configuracion_almaceneswwds_20_tfalmcos",GXType.Int16,1,0) ,
          new ParDef("@AV79Configuracion_almaceneswwds_21_tfalmcos_to",GXType.Int16,1,0)
          };
          Object[] prmP002E3;
          prmP002E3 = new Object[] {
          new ParDef("@lV61Configuracion_almaceneswwds_3_almdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_almaceneswwds_3_almdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_almaceneswwds_7_almdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_almaceneswwds_7_almdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_almaceneswwds_11_almdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_almaceneswwds_11_almdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV70Configuracion_almaceneswwds_12_tfalmcod",GXType.Int32,6,0) ,
          new ParDef("@AV71Configuracion_almaceneswwds_13_tfalmcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV72Configuracion_almaceneswwds_14_tfalmdsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Configuracion_almaceneswwds_15_tfalmdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_almaceneswwds_16_tfalmdir",GXType.NVarChar,100,0) ,
          new ParDef("@AV75Configuracion_almaceneswwds_17_tfalmdir_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV76Configuracion_almaceneswwds_18_tfalmabr",GXType.NChar,10,0) ,
          new ParDef("@AV77Configuracion_almaceneswwds_19_tfalmabr_sel",GXType.NChar,10,0) ,
          new ParDef("@AV78Configuracion_almaceneswwds_20_tfalmcos",GXType.Int16,1,0) ,
          new ParDef("@AV79Configuracion_almaceneswwds_21_tfalmcos_to",GXType.Int16,1,0)
          };
          Object[] prmP002E4;
          prmP002E4 = new Object[] {
          new ParDef("@lV61Configuracion_almaceneswwds_3_almdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_almaceneswwds_3_almdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_almaceneswwds_7_almdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_almaceneswwds_7_almdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_almaceneswwds_11_almdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_almaceneswwds_11_almdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV70Configuracion_almaceneswwds_12_tfalmcod",GXType.Int32,6,0) ,
          new ParDef("@AV71Configuracion_almaceneswwds_13_tfalmcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV72Configuracion_almaceneswwds_14_tfalmdsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Configuracion_almaceneswwds_15_tfalmdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_almaceneswwds_16_tfalmdir",GXType.NVarChar,100,0) ,
          new ParDef("@AV75Configuracion_almaceneswwds_17_tfalmdir_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV76Configuracion_almaceneswwds_18_tfalmabr",GXType.NChar,10,0) ,
          new ParDef("@AV77Configuracion_almaceneswwds_19_tfalmabr_sel",GXType.NChar,10,0) ,
          new ParDef("@AV78Configuracion_almaceneswwds_20_tfalmcos",GXType.Int16,1,0) ,
          new ParDef("@AV79Configuracion_almaceneswwds_21_tfalmcos_to",GXType.Int16,1,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002E2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002E3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002E4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002E4,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                return;
       }
    }

 }

}
