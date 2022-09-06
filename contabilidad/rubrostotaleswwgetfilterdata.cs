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
   public class rubrostotaleswwgetfilterdata : GXProcedure
   {
      public rubrostotaleswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rubrostotaleswwgetfilterdata( IGxContext context )
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
         rubrostotaleswwgetfilterdata objrubrostotaleswwgetfilterdata;
         objrubrostotaleswwgetfilterdata = new rubrostotaleswwgetfilterdata();
         objrubrostotaleswwgetfilterdata.AV24DDOName = aP0_DDOName;
         objrubrostotaleswwgetfilterdata.AV22SearchTxt = aP1_SearchTxt;
         objrubrostotaleswwgetfilterdata.AV23SearchTxtTo = aP2_SearchTxtTo;
         objrubrostotaleswwgetfilterdata.AV28OptionsJson = "" ;
         objrubrostotaleswwgetfilterdata.AV31OptionsDescJson = "" ;
         objrubrostotaleswwgetfilterdata.AV33OptionIndexesJson = "" ;
         objrubrostotaleswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objrubrostotaleswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrubrostotaleswwgetfilterdata);
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rubrostotaleswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_TOTDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADTOTDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_TOTDSCTOT") == 0 )
         {
            /* Execute user subroutine: 'LOADTOTDSCTOTOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV35Session.Get("Contabilidad.RubrosTotalesWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.RubrosTotalesWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("Contabilidad.RubrosTotalesWWGridState"), null, "", "");
         }
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV58GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTOTTIPO_SEL") == 0 )
            {
               AV10TFTotTipo_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV11TFTotTipo_Sels.FromJSonString(AV10TFTotTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTOTRUB") == 0 )
            {
               AV12TFTotRub = (int)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."));
               AV13TFTotRub_To = (int)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTOTDSC") == 0 )
            {
               AV14TFTotDsc = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTOTDSC_SEL") == 0 )
            {
               AV15TFTotDsc_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTOTDSCTOT") == 0 )
            {
               AV16TFTotDscTot = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTOTDSCTOT_SEL") == 0 )
            {
               AV17TFTotDscTot_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTOTORD") == 0 )
            {
               AV18TFTotOrd = (short)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."));
               AV19TFTotOrd_To = (short)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFTOTSTS_SEL") == 0 )
            {
               AV20TFTotSts_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV21TFTotSts_Sels.FromJSonString(AV20TFTotSts_SelsJson, null);
            }
            AV58GXV1 = (int)(AV58GXV1+1);
         }
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV39GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "TOTTIPO") == 0 )
            {
               AV51TotTipo1 = AV39GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV43DynamicFiltersEnabled2 = true;
               AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV44DynamicFiltersSelector2 = AV39GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV44DynamicFiltersSelector2, "TOTTIPO") == 0 )
               {
                  AV52TotTipo2 = AV39GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV39GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "TOTTIPO") == 0 )
                  {
                     AV53TotTipo3 = AV39GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTOTDSCOPTIONS' Routine */
         returnInSub = false;
         AV14TFTotDsc = AV22SearchTxt;
         AV15TFTotDsc_Sel = "";
         AV60Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV61Contabilidad_rubrostotaleswwds_2_tottipo1 = AV51TotTipo1;
         AV62Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV63Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV64Contabilidad_rubrostotaleswwds_5_tottipo2 = AV52TotTipo2;
         AV65Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV66Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV67Contabilidad_rubrostotaleswwds_8_tottipo3 = AV53TotTipo3;
         AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels = AV11TFTotTipo_Sels;
         AV69Contabilidad_rubrostotaleswwds_10_tftotrub = AV12TFTotRub;
         AV70Contabilidad_rubrostotaleswwds_11_tftotrub_to = AV13TFTotRub_To;
         AV71Contabilidad_rubrostotaleswwds_12_tftotdsc = AV14TFTotDsc;
         AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel = AV15TFTotDsc_Sel;
         AV73Contabilidad_rubrostotaleswwds_14_tftotdsctot = AV16TFTotDscTot;
         AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel = AV17TFTotDscTot_Sel;
         AV75Contabilidad_rubrostotaleswwds_16_tftotord = AV18TFTotOrd;
         AV76Contabilidad_rubrostotaleswwds_17_tftotord_to = AV19TFTotOrd_To;
         AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels = AV21TFTotSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A114TotTipo ,
                                              AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels ,
                                              A1930TotSts ,
                                              AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels ,
                                              AV60Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 ,
                                              AV61Contabilidad_rubrostotaleswwds_2_tottipo1 ,
                                              AV62Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 ,
                                              AV63Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 ,
                                              AV64Contabilidad_rubrostotaleswwds_5_tottipo2 ,
                                              AV65Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 ,
                                              AV66Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 ,
                                              AV67Contabilidad_rubrostotaleswwds_8_tottipo3 ,
                                              AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels.Count ,
                                              AV69Contabilidad_rubrostotaleswwds_10_tftotrub ,
                                              AV70Contabilidad_rubrostotaleswwds_11_tftotrub_to ,
                                              AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel ,
                                              AV71Contabilidad_rubrostotaleswwds_12_tftotdsc ,
                                              AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel ,
                                              AV73Contabilidad_rubrostotaleswwds_14_tftotdsctot ,
                                              AV75Contabilidad_rubrostotaleswwds_16_tftotord ,
                                              AV76Contabilidad_rubrostotaleswwds_17_tftotord_to ,
                                              AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels.Count ,
                                              A115TotRub ,
                                              A1928TotDsc ,
                                              A1929TotDscTot ,
                                              A120TotOrd } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT
                                              }
         });
         lV71Contabilidad_rubrostotaleswwds_12_tftotdsc = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_rubrostotaleswwds_12_tftotdsc), 100, "%");
         lV73Contabilidad_rubrostotaleswwds_14_tftotdsctot = StringUtil.PadR( StringUtil.RTrim( AV73Contabilidad_rubrostotaleswwds_14_tftotdsctot), 100, "%");
         /* Using cursor P006Z2 */
         pr_default.execute(0, new Object[] {AV61Contabilidad_rubrostotaleswwds_2_tottipo1, AV64Contabilidad_rubrostotaleswwds_5_tottipo2, AV67Contabilidad_rubrostotaleswwds_8_tottipo3, AV69Contabilidad_rubrostotaleswwds_10_tftotrub, AV70Contabilidad_rubrostotaleswwds_11_tftotrub_to, lV71Contabilidad_rubrostotaleswwds_12_tftotdsc, AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel, lV73Contabilidad_rubrostotaleswwds_14_tftotdsctot, AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel, AV75Contabilidad_rubrostotaleswwds_16_tftotord, AV76Contabilidad_rubrostotaleswwds_17_tftotord_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6Z2 = false;
            A1928TotDsc = P006Z2_A1928TotDsc[0];
            A1930TotSts = P006Z2_A1930TotSts[0];
            A120TotOrd = P006Z2_A120TotOrd[0];
            A1929TotDscTot = P006Z2_A1929TotDscTot[0];
            A115TotRub = P006Z2_A115TotRub[0];
            A114TotTipo = P006Z2_A114TotTipo[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006Z2_A1928TotDsc[0], A1928TotDsc) == 0 ) )
            {
               BRK6Z2 = false;
               A115TotRub = P006Z2_A115TotRub[0];
               A114TotTipo = P006Z2_A114TotTipo[0];
               AV34count = (long)(AV34count+1);
               BRK6Z2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1928TotDsc)) )
            {
               AV26Option = A1928TotDsc;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK6Z2 )
            {
               BRK6Z2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTOTDSCTOTOPTIONS' Routine */
         returnInSub = false;
         AV16TFTotDscTot = AV22SearchTxt;
         AV17TFTotDscTot_Sel = "";
         AV60Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV61Contabilidad_rubrostotaleswwds_2_tottipo1 = AV51TotTipo1;
         AV62Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV63Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV64Contabilidad_rubrostotaleswwds_5_tottipo2 = AV52TotTipo2;
         AV65Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV66Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV67Contabilidad_rubrostotaleswwds_8_tottipo3 = AV53TotTipo3;
         AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels = AV11TFTotTipo_Sels;
         AV69Contabilidad_rubrostotaleswwds_10_tftotrub = AV12TFTotRub;
         AV70Contabilidad_rubrostotaleswwds_11_tftotrub_to = AV13TFTotRub_To;
         AV71Contabilidad_rubrostotaleswwds_12_tftotdsc = AV14TFTotDsc;
         AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel = AV15TFTotDsc_Sel;
         AV73Contabilidad_rubrostotaleswwds_14_tftotdsctot = AV16TFTotDscTot;
         AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel = AV17TFTotDscTot_Sel;
         AV75Contabilidad_rubrostotaleswwds_16_tftotord = AV18TFTotOrd;
         AV76Contabilidad_rubrostotaleswwds_17_tftotord_to = AV19TFTotOrd_To;
         AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels = AV21TFTotSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A114TotTipo ,
                                              AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels ,
                                              A1930TotSts ,
                                              AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels ,
                                              AV60Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 ,
                                              AV61Contabilidad_rubrostotaleswwds_2_tottipo1 ,
                                              AV62Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 ,
                                              AV63Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 ,
                                              AV64Contabilidad_rubrostotaleswwds_5_tottipo2 ,
                                              AV65Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 ,
                                              AV66Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 ,
                                              AV67Contabilidad_rubrostotaleswwds_8_tottipo3 ,
                                              AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels.Count ,
                                              AV69Contabilidad_rubrostotaleswwds_10_tftotrub ,
                                              AV70Contabilidad_rubrostotaleswwds_11_tftotrub_to ,
                                              AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel ,
                                              AV71Contabilidad_rubrostotaleswwds_12_tftotdsc ,
                                              AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel ,
                                              AV73Contabilidad_rubrostotaleswwds_14_tftotdsctot ,
                                              AV75Contabilidad_rubrostotaleswwds_16_tftotord ,
                                              AV76Contabilidad_rubrostotaleswwds_17_tftotord_to ,
                                              AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels.Count ,
                                              A115TotRub ,
                                              A1928TotDsc ,
                                              A1929TotDscTot ,
                                              A120TotOrd } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT
                                              }
         });
         lV71Contabilidad_rubrostotaleswwds_12_tftotdsc = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_rubrostotaleswwds_12_tftotdsc), 100, "%");
         lV73Contabilidad_rubrostotaleswwds_14_tftotdsctot = StringUtil.PadR( StringUtil.RTrim( AV73Contabilidad_rubrostotaleswwds_14_tftotdsctot), 100, "%");
         /* Using cursor P006Z3 */
         pr_default.execute(1, new Object[] {AV61Contabilidad_rubrostotaleswwds_2_tottipo1, AV64Contabilidad_rubrostotaleswwds_5_tottipo2, AV67Contabilidad_rubrostotaleswwds_8_tottipo3, AV69Contabilidad_rubrostotaleswwds_10_tftotrub, AV70Contabilidad_rubrostotaleswwds_11_tftotrub_to, lV71Contabilidad_rubrostotaleswwds_12_tftotdsc, AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel, lV73Contabilidad_rubrostotaleswwds_14_tftotdsctot, AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel, AV75Contabilidad_rubrostotaleswwds_16_tftotord, AV76Contabilidad_rubrostotaleswwds_17_tftotord_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6Z4 = false;
            A1929TotDscTot = P006Z3_A1929TotDscTot[0];
            A1930TotSts = P006Z3_A1930TotSts[0];
            A120TotOrd = P006Z3_A120TotOrd[0];
            A1928TotDsc = P006Z3_A1928TotDsc[0];
            A115TotRub = P006Z3_A115TotRub[0];
            A114TotTipo = P006Z3_A114TotTipo[0];
            AV34count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006Z3_A1929TotDscTot[0], A1929TotDscTot) == 0 ) )
            {
               BRK6Z4 = false;
               A115TotRub = P006Z3_A115TotRub[0];
               A114TotTipo = P006Z3_A114TotTipo[0];
               AV34count = (long)(AV34count+1);
               BRK6Z4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1929TotDscTot)) )
            {
               AV26Option = A1929TotDscTot;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK6Z4 )
            {
               BRK6Z4 = true;
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
         AV10TFTotTipo_SelsJson = "";
         AV11TFTotTipo_Sels = new GxSimpleCollection<string>();
         AV14TFTotDsc = "";
         AV15TFTotDsc_Sel = "";
         AV16TFTotDscTot = "";
         AV17TFTotDscTot_Sel = "";
         AV20TFTotSts_SelsJson = "";
         AV21TFTotSts_Sels = new GxSimpleCollection<short>();
         AV39GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV51TotTipo1 = "";
         AV44DynamicFiltersSelector2 = "";
         AV52TotTipo2 = "";
         AV48DynamicFiltersSelector3 = "";
         AV53TotTipo3 = "";
         AV60Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 = "";
         AV61Contabilidad_rubrostotaleswwds_2_tottipo1 = "";
         AV63Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 = "";
         AV64Contabilidad_rubrostotaleswwds_5_tottipo2 = "";
         AV66Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 = "";
         AV67Contabilidad_rubrostotaleswwds_8_tottipo3 = "";
         AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels = new GxSimpleCollection<string>();
         AV71Contabilidad_rubrostotaleswwds_12_tftotdsc = "";
         AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel = "";
         AV73Contabilidad_rubrostotaleswwds_14_tftotdsctot = "";
         AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel = "";
         AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV71Contabilidad_rubrostotaleswwds_12_tftotdsc = "";
         lV73Contabilidad_rubrostotaleswwds_14_tftotdsctot = "";
         A114TotTipo = "";
         A1928TotDsc = "";
         A1929TotDscTot = "";
         P006Z2_A1928TotDsc = new string[] {""} ;
         P006Z2_A1930TotSts = new short[1] ;
         P006Z2_A120TotOrd = new short[1] ;
         P006Z2_A1929TotDscTot = new string[] {""} ;
         P006Z2_A115TotRub = new int[1] ;
         P006Z2_A114TotTipo = new string[] {""} ;
         AV26Option = "";
         P006Z3_A1929TotDscTot = new string[] {""} ;
         P006Z3_A1930TotSts = new short[1] ;
         P006Z3_A120TotOrd = new short[1] ;
         P006Z3_A1928TotDsc = new string[] {""} ;
         P006Z3_A115TotRub = new int[1] ;
         P006Z3_A114TotTipo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rubrostotaleswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006Z2_A1928TotDsc, P006Z2_A1930TotSts, P006Z2_A120TotOrd, P006Z2_A1929TotDscTot, P006Z2_A115TotRub, P006Z2_A114TotTipo
               }
               , new Object[] {
               P006Z3_A1929TotDscTot, P006Z3_A1930TotSts, P006Z3_A120TotOrd, P006Z3_A1928TotDsc, P006Z3_A115TotRub, P006Z3_A114TotTipo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV18TFTotOrd ;
      private short AV19TFTotOrd_To ;
      private short AV75Contabilidad_rubrostotaleswwds_16_tftotord ;
      private short AV76Contabilidad_rubrostotaleswwds_17_tftotord_to ;
      private short A1930TotSts ;
      private short A120TotOrd ;
      private int AV58GXV1 ;
      private int AV12TFTotRub ;
      private int AV13TFTotRub_To ;
      private int AV69Contabilidad_rubrostotaleswwds_10_tftotrub ;
      private int AV70Contabilidad_rubrostotaleswwds_11_tftotrub_to ;
      private int AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels_Count ;
      private int AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels_Count ;
      private int A115TotRub ;
      private long AV34count ;
      private string AV14TFTotDsc ;
      private string AV15TFTotDsc_Sel ;
      private string AV16TFTotDscTot ;
      private string AV17TFTotDscTot_Sel ;
      private string AV51TotTipo1 ;
      private string AV52TotTipo2 ;
      private string AV53TotTipo3 ;
      private string AV61Contabilidad_rubrostotaleswwds_2_tottipo1 ;
      private string AV64Contabilidad_rubrostotaleswwds_5_tottipo2 ;
      private string AV67Contabilidad_rubrostotaleswwds_8_tottipo3 ;
      private string AV71Contabilidad_rubrostotaleswwds_12_tftotdsc ;
      private string AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel ;
      private string AV73Contabilidad_rubrostotaleswwds_14_tftotdsctot ;
      private string AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel ;
      private string scmdbuf ;
      private string lV71Contabilidad_rubrostotaleswwds_12_tftotdsc ;
      private string lV73Contabilidad_rubrostotaleswwds_14_tftotdsctot ;
      private string A114TotTipo ;
      private string A1928TotDsc ;
      private string A1929TotDscTot ;
      private bool returnInSub ;
      private bool AV43DynamicFiltersEnabled2 ;
      private bool AV47DynamicFiltersEnabled3 ;
      private bool AV62Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 ;
      private bool AV65Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 ;
      private bool BRK6Z2 ;
      private bool BRK6Z4 ;
      private string AV28OptionsJson ;
      private string AV31OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV10TFTotTipo_SelsJson ;
      private string AV20TFTotSts_SelsJson ;
      private string AV24DDOName ;
      private string AV22SearchTxt ;
      private string AV23SearchTxtTo ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV44DynamicFiltersSelector2 ;
      private string AV48DynamicFiltersSelector3 ;
      private string AV60Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 ;
      private string AV63Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 ;
      private string AV66Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 ;
      private string AV26Option ;
      private GxSimpleCollection<short> AV21TFTotSts_Sels ;
      private GxSimpleCollection<short> AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006Z2_A1928TotDsc ;
      private short[] P006Z2_A1930TotSts ;
      private short[] P006Z2_A120TotOrd ;
      private string[] P006Z2_A1929TotDscTot ;
      private int[] P006Z2_A115TotRub ;
      private string[] P006Z2_A114TotTipo ;
      private string[] P006Z3_A1929TotDscTot ;
      private short[] P006Z3_A1930TotSts ;
      private short[] P006Z3_A120TotOrd ;
      private string[] P006Z3_A1928TotDsc ;
      private int[] P006Z3_A115TotRub ;
      private string[] P006Z3_A114TotTipo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV11TFTotTipo_Sels ;
      private GxSimpleCollection<string> AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV30OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV39GridStateDynamicFilter ;
   }

   public class rubrostotaleswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006Z2( IGxContext context ,
                                             string A114TotTipo ,
                                             GxSimpleCollection<string> AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels ,
                                             short A1930TotSts ,
                                             GxSimpleCollection<short> AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels ,
                                             string AV60Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 ,
                                             string AV61Contabilidad_rubrostotaleswwds_2_tottipo1 ,
                                             bool AV62Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 ,
                                             string AV63Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 ,
                                             string AV64Contabilidad_rubrostotaleswwds_5_tottipo2 ,
                                             bool AV65Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 ,
                                             string AV66Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 ,
                                             string AV67Contabilidad_rubrostotaleswwds_8_tottipo3 ,
                                             int AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels_Count ,
                                             int AV69Contabilidad_rubrostotaleswwds_10_tftotrub ,
                                             int AV70Contabilidad_rubrostotaleswwds_11_tftotrub_to ,
                                             string AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel ,
                                             string AV71Contabilidad_rubrostotaleswwds_12_tftotdsc ,
                                             string AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel ,
                                             string AV73Contabilidad_rubrostotaleswwds_14_tftotdsctot ,
                                             short AV75Contabilidad_rubrostotaleswwds_16_tftotord ,
                                             short AV76Contabilidad_rubrostotaleswwds_17_tftotord_to ,
                                             int AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels_Count ,
                                             int A115TotRub ,
                                             string A1928TotDsc ,
                                             string A1929TotDscTot ,
                                             short A120TotOrd )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[11];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TotDsc], [TotSts], [TotOrd], [TotDscTot], [TotRub], [TotTipo] FROM [CBRUBROST]";
         if ( ( StringUtil.StrCmp(AV60Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Contabilidad_rubrostotaleswwds_2_tottipo1)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV61Contabilidad_rubrostotaleswwds_2_tottipo1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( AV62Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_rubrostotaleswwds_5_tottipo2)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV64Contabilidad_rubrostotaleswwds_5_tottipo2)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV65Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Contabilidad_rubrostotaleswwds_8_tottipo3)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV67Contabilidad_rubrostotaleswwds_8_tottipo3)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels, "[TotTipo] IN (", ")")+")");
         }
         if ( ! (0==AV69Contabilidad_rubrostotaleswwds_10_tftotrub) )
         {
            AddWhere(sWhereString, "([TotRub] >= @AV69Contabilidad_rubrostotaleswwds_10_tftotrub)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV70Contabilidad_rubrostotaleswwds_11_tftotrub_to) )
         {
            AddWhere(sWhereString, "([TotRub] <= @AV70Contabilidad_rubrostotaleswwds_11_tftotrub_to)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_rubrostotaleswwds_12_tftotdsc)) ) )
         {
            AddWhere(sWhereString, "([TotDsc] like @lV71Contabilidad_rubrostotaleswwds_12_tftotdsc)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel)) )
         {
            AddWhere(sWhereString, "([TotDsc] = @AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_rubrostotaleswwds_14_tftotdsctot)) ) )
         {
            AddWhere(sWhereString, "([TotDscTot] like @lV73Contabilidad_rubrostotaleswwds_14_tftotdsctot)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel)) )
         {
            AddWhere(sWhereString, "([TotDscTot] = @AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV75Contabilidad_rubrostotaleswwds_16_tftotord) )
         {
            AddWhere(sWhereString, "([TotOrd] >= @AV75Contabilidad_rubrostotaleswwds_16_tftotord)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV76Contabilidad_rubrostotaleswwds_17_tftotord_to) )
         {
            AddWhere(sWhereString, "([TotOrd] <= @AV76Contabilidad_rubrostotaleswwds_17_tftotord_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels, "[TotSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TotDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006Z3( IGxContext context ,
                                             string A114TotTipo ,
                                             GxSimpleCollection<string> AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels ,
                                             short A1930TotSts ,
                                             GxSimpleCollection<short> AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels ,
                                             string AV60Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1 ,
                                             string AV61Contabilidad_rubrostotaleswwds_2_tottipo1 ,
                                             bool AV62Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 ,
                                             string AV63Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2 ,
                                             string AV64Contabilidad_rubrostotaleswwds_5_tottipo2 ,
                                             bool AV65Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 ,
                                             string AV66Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3 ,
                                             string AV67Contabilidad_rubrostotaleswwds_8_tottipo3 ,
                                             int AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels_Count ,
                                             int AV69Contabilidad_rubrostotaleswwds_10_tftotrub ,
                                             int AV70Contabilidad_rubrostotaleswwds_11_tftotrub_to ,
                                             string AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel ,
                                             string AV71Contabilidad_rubrostotaleswwds_12_tftotdsc ,
                                             string AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel ,
                                             string AV73Contabilidad_rubrostotaleswwds_14_tftotdsctot ,
                                             short AV75Contabilidad_rubrostotaleswwds_16_tftotord ,
                                             short AV76Contabilidad_rubrostotaleswwds_17_tftotord_to ,
                                             int AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels_Count ,
                                             int A115TotRub ,
                                             string A1928TotDsc ,
                                             string A1929TotDscTot ,
                                             short A120TotOrd )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[11];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TotDscTot], [TotSts], [TotOrd], [TotDsc], [TotRub], [TotTipo] FROM [CBRUBROST]";
         if ( ( StringUtil.StrCmp(AV60Contabilidad_rubrostotaleswwds_1_dynamicfiltersselector1, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Contabilidad_rubrostotaleswwds_2_tottipo1)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV61Contabilidad_rubrostotaleswwds_2_tottipo1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( AV62Contabilidad_rubrostotaleswwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Contabilidad_rubrostotaleswwds_4_dynamicfiltersselector2, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_rubrostotaleswwds_5_tottipo2)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV64Contabilidad_rubrostotaleswwds_5_tottipo2)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV65Contabilidad_rubrostotaleswwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Contabilidad_rubrostotaleswwds_7_dynamicfiltersselector3, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Contabilidad_rubrostotaleswwds_8_tottipo3)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV67Contabilidad_rubrostotaleswwds_8_tottipo3)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Contabilidad_rubrostotaleswwds_9_tftottipo_sels, "[TotTipo] IN (", ")")+")");
         }
         if ( ! (0==AV69Contabilidad_rubrostotaleswwds_10_tftotrub) )
         {
            AddWhere(sWhereString, "([TotRub] >= @AV69Contabilidad_rubrostotaleswwds_10_tftotrub)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV70Contabilidad_rubrostotaleswwds_11_tftotrub_to) )
         {
            AddWhere(sWhereString, "([TotRub] <= @AV70Contabilidad_rubrostotaleswwds_11_tftotrub_to)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_rubrostotaleswwds_12_tftotdsc)) ) )
         {
            AddWhere(sWhereString, "([TotDsc] like @lV71Contabilidad_rubrostotaleswwds_12_tftotdsc)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel)) )
         {
            AddWhere(sWhereString, "([TotDsc] = @AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Contabilidad_rubrostotaleswwds_14_tftotdsctot)) ) )
         {
            AddWhere(sWhereString, "([TotDscTot] like @lV73Contabilidad_rubrostotaleswwds_14_tftotdsctot)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel)) )
         {
            AddWhere(sWhereString, "([TotDscTot] = @AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV75Contabilidad_rubrostotaleswwds_16_tftotord) )
         {
            AddWhere(sWhereString, "([TotOrd] >= @AV75Contabilidad_rubrostotaleswwds_16_tftotord)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (0==AV76Contabilidad_rubrostotaleswwds_17_tftotord_to) )
         {
            AddWhere(sWhereString, "([TotOrd] <= @AV76Contabilidad_rubrostotaleswwds_17_tftotord_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Contabilidad_rubrostotaleswwds_18_tftotsts_sels, "[TotSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TotDscTot]";
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
                     return conditional_P006Z2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (int)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] );
               case 1 :
                     return conditional_P006Z3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (int)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] );
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
          Object[] prmP006Z2;
          prmP006Z2 = new Object[] {
          new ParDef("@AV61Contabilidad_rubrostotaleswwds_2_tottipo1",GXType.NChar,3,0) ,
          new ParDef("@AV64Contabilidad_rubrostotaleswwds_5_tottipo2",GXType.NChar,3,0) ,
          new ParDef("@AV67Contabilidad_rubrostotaleswwds_8_tottipo3",GXType.NChar,3,0) ,
          new ParDef("@AV69Contabilidad_rubrostotaleswwds_10_tftotrub",GXType.Int32,6,0) ,
          new ParDef("@AV70Contabilidad_rubrostotaleswwds_11_tftotrub_to",GXType.Int32,6,0) ,
          new ParDef("@lV71Contabilidad_rubrostotaleswwds_12_tftotdsc",GXType.NChar,100,0) ,
          new ParDef("@AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV73Contabilidad_rubrostotaleswwds_14_tftotdsctot",GXType.NChar,100,0) ,
          new ParDef("@AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel",GXType.NChar,100,0) ,
          new ParDef("@AV75Contabilidad_rubrostotaleswwds_16_tftotord",GXType.Int16,2,0) ,
          new ParDef("@AV76Contabilidad_rubrostotaleswwds_17_tftotord_to",GXType.Int16,2,0)
          };
          Object[] prmP006Z3;
          prmP006Z3 = new Object[] {
          new ParDef("@AV61Contabilidad_rubrostotaleswwds_2_tottipo1",GXType.NChar,3,0) ,
          new ParDef("@AV64Contabilidad_rubrostotaleswwds_5_tottipo2",GXType.NChar,3,0) ,
          new ParDef("@AV67Contabilidad_rubrostotaleswwds_8_tottipo3",GXType.NChar,3,0) ,
          new ParDef("@AV69Contabilidad_rubrostotaleswwds_10_tftotrub",GXType.Int32,6,0) ,
          new ParDef("@AV70Contabilidad_rubrostotaleswwds_11_tftotrub_to",GXType.Int32,6,0) ,
          new ParDef("@lV71Contabilidad_rubrostotaleswwds_12_tftotdsc",GXType.NChar,100,0) ,
          new ParDef("@AV72Contabilidad_rubrostotaleswwds_13_tftotdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV73Contabilidad_rubrostotaleswwds_14_tftotdsctot",GXType.NChar,100,0) ,
          new ParDef("@AV74Contabilidad_rubrostotaleswwds_15_tftotdsctot_sel",GXType.NChar,100,0) ,
          new ParDef("@AV75Contabilidad_rubrostotaleswwds_16_tftotord",GXType.Int16,2,0) ,
          new ParDef("@AV76Contabilidad_rubrostotaleswwds_17_tftotord_to",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Z2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006Z3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Z3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
       }
    }

 }

}
