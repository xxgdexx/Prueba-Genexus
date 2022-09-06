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
   public class lineaswwgetfilterdata : GXProcedure
   {
      public lineaswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public lineaswwgetfilterdata( IGxContext context )
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
         this.AV28DDOName = aP0_DDOName;
         this.AV26SearchTxt = aP1_SearchTxt;
         this.AV27SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV37OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         lineaswwgetfilterdata objlineaswwgetfilterdata;
         objlineaswwgetfilterdata = new lineaswwgetfilterdata();
         objlineaswwgetfilterdata.AV28DDOName = aP0_DDOName;
         objlineaswwgetfilterdata.AV26SearchTxt = aP1_SearchTxt;
         objlineaswwgetfilterdata.AV27SearchTxtTo = aP2_SearchTxtTo;
         objlineaswwgetfilterdata.AV32OptionsJson = "" ;
         objlineaswwgetfilterdata.AV35OptionsDescJson = "" ;
         objlineaswwgetfilterdata.AV37OptionIndexesJson = "" ;
         objlineaswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objlineaswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlineaswwgetfilterdata);
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((lineaswwgetfilterdata)stateInfo).executePrivate();
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
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_RUBLINDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADRUBLINDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_RUBLINDSCTOT") == 0 )
         {
            /* Execute user subroutine: 'LOADRUBLINDSCTOTOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV32OptionsJson = AV31Options.ToJSonString(false);
         AV35OptionsDescJson = AV34OptionsDesc.ToJSonString(false);
         AV37OptionIndexesJson = AV36OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV39Session.Get("Contabilidad.LineasWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.LineasWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("Contabilidad.LineasWWGridState"), null, "", "");
         }
         AV60GXV1 = 1;
         while ( AV60GXV1 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV60GXV1));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFTOTTIPO_SEL") == 0 )
            {
               AV10TFTotTipo_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV11TFTotTipo_Sels.FromJSonString(AV10TFTotTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFTOTRUB") == 0 )
            {
               AV12TFTotRub = (int)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
               AV13TFTotRub_To = (int)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFRUBCOD") == 0 )
            {
               AV14TFRubCod = (int)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
               AV15TFRubCod_To = (int)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFRUBLINCOD") == 0 )
            {
               AV16TFRubLinCod = (int)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
               AV17TFRubLinCod_To = (int)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFRUBLINDSC") == 0 )
            {
               AV18TFRubLinDsc = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFRUBLINDSC_SEL") == 0 )
            {
               AV19TFRubLinDsc_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFRUBLINDSCTOT") == 0 )
            {
               AV20TFRubLinDscTot = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFRUBLINDSCTOT_SEL") == 0 )
            {
               AV21TFRubLinDscTot_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFRUBLINORD") == 0 )
            {
               AV22TFRubLinOrd = (short)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
               AV23TFRubLinOrd_To = (short)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFRUBLINSTS_SEL") == 0 )
            {
               AV24TFRubLinSts_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV25TFRubLinSts_Sels.FromJSonString(AV24TFRubLinSts_SelsJson, null);
            }
            AV60GXV1 = (int)(AV60GXV1+1);
         }
         if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV43GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(1));
            AV44DynamicFiltersSelector1 = AV43GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV44DynamicFiltersSelector1, "TOTTIPO") == 0 )
            {
               AV55TotTipo1 = AV43GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV47DynamicFiltersEnabled2 = true;
               AV43GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(2));
               AV48DynamicFiltersSelector2 = AV43GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "TOTTIPO") == 0 )
               {
                  AV56TotTipo2 = AV43GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV51DynamicFiltersEnabled3 = true;
                  AV43GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(3));
                  AV52DynamicFiltersSelector3 = AV43GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV52DynamicFiltersSelector3, "TOTTIPO") == 0 )
                  {
                     AV57TotTipo3 = AV43GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADRUBLINDSCOPTIONS' Routine */
         returnInSub = false;
         AV18TFRubLinDsc = AV26SearchTxt;
         AV19TFRubLinDsc_Sel = "";
         AV62Contabilidad_lineaswwds_1_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV63Contabilidad_lineaswwds_2_tottipo1 = AV55TotTipo1;
         AV64Contabilidad_lineaswwds_3_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV65Contabilidad_lineaswwds_4_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV66Contabilidad_lineaswwds_5_tottipo2 = AV56TotTipo2;
         AV67Contabilidad_lineaswwds_6_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV68Contabilidad_lineaswwds_7_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV69Contabilidad_lineaswwds_8_tottipo3 = AV57TotTipo3;
         AV70Contabilidad_lineaswwds_9_tftottipo_sels = AV11TFTotTipo_Sels;
         AV71Contabilidad_lineaswwds_10_tftotrub = AV12TFTotRub;
         AV72Contabilidad_lineaswwds_11_tftotrub_to = AV13TFTotRub_To;
         AV73Contabilidad_lineaswwds_12_tfrubcod = AV14TFRubCod;
         AV74Contabilidad_lineaswwds_13_tfrubcod_to = AV15TFRubCod_To;
         AV75Contabilidad_lineaswwds_14_tfrublincod = AV16TFRubLinCod;
         AV76Contabilidad_lineaswwds_15_tfrublincod_to = AV17TFRubLinCod_To;
         AV77Contabilidad_lineaswwds_16_tfrublindsc = AV18TFRubLinDsc;
         AV78Contabilidad_lineaswwds_17_tfrublindsc_sel = AV19TFRubLinDsc_Sel;
         AV79Contabilidad_lineaswwds_18_tfrublindsctot = AV20TFRubLinDscTot;
         AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel = AV21TFRubLinDscTot_Sel;
         AV81Contabilidad_lineaswwds_20_tfrublinord = AV22TFRubLinOrd;
         AV82Contabilidad_lineaswwds_21_tfrublinord_to = AV23TFRubLinOrd_To;
         AV83Contabilidad_lineaswwds_22_tfrublinsts_sels = AV25TFRubLinSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A114TotTipo ,
                                              AV70Contabilidad_lineaswwds_9_tftottipo_sels ,
                                              A1828RubLinSts ,
                                              AV83Contabilidad_lineaswwds_22_tfrublinsts_sels ,
                                              AV62Contabilidad_lineaswwds_1_dynamicfiltersselector1 ,
                                              AV63Contabilidad_lineaswwds_2_tottipo1 ,
                                              AV64Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ,
                                              AV65Contabilidad_lineaswwds_4_dynamicfiltersselector2 ,
                                              AV66Contabilidad_lineaswwds_5_tottipo2 ,
                                              AV67Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ,
                                              AV68Contabilidad_lineaswwds_7_dynamicfiltersselector3 ,
                                              AV69Contabilidad_lineaswwds_8_tottipo3 ,
                                              AV70Contabilidad_lineaswwds_9_tftottipo_sels.Count ,
                                              AV71Contabilidad_lineaswwds_10_tftotrub ,
                                              AV72Contabilidad_lineaswwds_11_tftotrub_to ,
                                              AV73Contabilidad_lineaswwds_12_tfrubcod ,
                                              AV74Contabilidad_lineaswwds_13_tfrubcod_to ,
                                              AV75Contabilidad_lineaswwds_14_tfrublincod ,
                                              AV76Contabilidad_lineaswwds_15_tfrublincod_to ,
                                              AV78Contabilidad_lineaswwds_17_tfrublindsc_sel ,
                                              AV77Contabilidad_lineaswwds_16_tfrublindsc ,
                                              AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel ,
                                              AV79Contabilidad_lineaswwds_18_tfrublindsctot ,
                                              AV81Contabilidad_lineaswwds_20_tfrublinord ,
                                              AV82Contabilidad_lineaswwds_21_tfrublinord_to ,
                                              AV83Contabilidad_lineaswwds_22_tfrublinsts_sels.Count ,
                                              A115TotRub ,
                                              A116RubCod ,
                                              A118RubLinCod ,
                                              A1826RubLinDsc ,
                                              A1827RubLinDscTot ,
                                              A119RubLinOrd } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV77Contabilidad_lineaswwds_16_tfrublindsc = StringUtil.PadR( StringUtil.RTrim( AV77Contabilidad_lineaswwds_16_tfrublindsc), 100, "%");
         lV79Contabilidad_lineaswwds_18_tfrublindsctot = StringUtil.PadR( StringUtil.RTrim( AV79Contabilidad_lineaswwds_18_tfrublindsctot), 100, "%");
         /* Using cursor P00752 */
         pr_default.execute(0, new Object[] {AV63Contabilidad_lineaswwds_2_tottipo1, AV66Contabilidad_lineaswwds_5_tottipo2, AV69Contabilidad_lineaswwds_8_tottipo3, AV71Contabilidad_lineaswwds_10_tftotrub, AV72Contabilidad_lineaswwds_11_tftotrub_to, AV73Contabilidad_lineaswwds_12_tfrubcod, AV74Contabilidad_lineaswwds_13_tfrubcod_to, AV75Contabilidad_lineaswwds_14_tfrublincod, AV76Contabilidad_lineaswwds_15_tfrublincod_to, lV77Contabilidad_lineaswwds_16_tfrublindsc, AV78Contabilidad_lineaswwds_17_tfrublindsc_sel, lV79Contabilidad_lineaswwds_18_tfrublindsctot, AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel, AV81Contabilidad_lineaswwds_20_tfrublinord, AV82Contabilidad_lineaswwds_21_tfrublinord_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK752 = false;
            A1826RubLinDsc = P00752_A1826RubLinDsc[0];
            A1828RubLinSts = P00752_A1828RubLinSts[0];
            A119RubLinOrd = P00752_A119RubLinOrd[0];
            A1827RubLinDscTot = P00752_A1827RubLinDscTot[0];
            A118RubLinCod = P00752_A118RubLinCod[0];
            A116RubCod = P00752_A116RubCod[0];
            A115TotRub = P00752_A115TotRub[0];
            A114TotTipo = P00752_A114TotTipo[0];
            AV38count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00752_A1826RubLinDsc[0], A1826RubLinDsc) == 0 ) )
            {
               BRK752 = false;
               A118RubLinCod = P00752_A118RubLinCod[0];
               A116RubCod = P00752_A116RubCod[0];
               A115TotRub = P00752_A115TotRub[0];
               A114TotTipo = P00752_A114TotTipo[0];
               AV38count = (long)(AV38count+1);
               BRK752 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1826RubLinDsc)) )
            {
               AV30Option = A1826RubLinDsc;
               AV31Options.Add(AV30Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV31Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK752 )
            {
               BRK752 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRUBLINDSCTOTOPTIONS' Routine */
         returnInSub = false;
         AV20TFRubLinDscTot = AV26SearchTxt;
         AV21TFRubLinDscTot_Sel = "";
         AV62Contabilidad_lineaswwds_1_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV63Contabilidad_lineaswwds_2_tottipo1 = AV55TotTipo1;
         AV64Contabilidad_lineaswwds_3_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV65Contabilidad_lineaswwds_4_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV66Contabilidad_lineaswwds_5_tottipo2 = AV56TotTipo2;
         AV67Contabilidad_lineaswwds_6_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV68Contabilidad_lineaswwds_7_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV69Contabilidad_lineaswwds_8_tottipo3 = AV57TotTipo3;
         AV70Contabilidad_lineaswwds_9_tftottipo_sels = AV11TFTotTipo_Sels;
         AV71Contabilidad_lineaswwds_10_tftotrub = AV12TFTotRub;
         AV72Contabilidad_lineaswwds_11_tftotrub_to = AV13TFTotRub_To;
         AV73Contabilidad_lineaswwds_12_tfrubcod = AV14TFRubCod;
         AV74Contabilidad_lineaswwds_13_tfrubcod_to = AV15TFRubCod_To;
         AV75Contabilidad_lineaswwds_14_tfrublincod = AV16TFRubLinCod;
         AV76Contabilidad_lineaswwds_15_tfrublincod_to = AV17TFRubLinCod_To;
         AV77Contabilidad_lineaswwds_16_tfrublindsc = AV18TFRubLinDsc;
         AV78Contabilidad_lineaswwds_17_tfrublindsc_sel = AV19TFRubLinDsc_Sel;
         AV79Contabilidad_lineaswwds_18_tfrublindsctot = AV20TFRubLinDscTot;
         AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel = AV21TFRubLinDscTot_Sel;
         AV81Contabilidad_lineaswwds_20_tfrublinord = AV22TFRubLinOrd;
         AV82Contabilidad_lineaswwds_21_tfrublinord_to = AV23TFRubLinOrd_To;
         AV83Contabilidad_lineaswwds_22_tfrublinsts_sels = AV25TFRubLinSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A114TotTipo ,
                                              AV70Contabilidad_lineaswwds_9_tftottipo_sels ,
                                              A1828RubLinSts ,
                                              AV83Contabilidad_lineaswwds_22_tfrublinsts_sels ,
                                              AV62Contabilidad_lineaswwds_1_dynamicfiltersselector1 ,
                                              AV63Contabilidad_lineaswwds_2_tottipo1 ,
                                              AV64Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ,
                                              AV65Contabilidad_lineaswwds_4_dynamicfiltersselector2 ,
                                              AV66Contabilidad_lineaswwds_5_tottipo2 ,
                                              AV67Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ,
                                              AV68Contabilidad_lineaswwds_7_dynamicfiltersselector3 ,
                                              AV69Contabilidad_lineaswwds_8_tottipo3 ,
                                              AV70Contabilidad_lineaswwds_9_tftottipo_sels.Count ,
                                              AV71Contabilidad_lineaswwds_10_tftotrub ,
                                              AV72Contabilidad_lineaswwds_11_tftotrub_to ,
                                              AV73Contabilidad_lineaswwds_12_tfrubcod ,
                                              AV74Contabilidad_lineaswwds_13_tfrubcod_to ,
                                              AV75Contabilidad_lineaswwds_14_tfrublincod ,
                                              AV76Contabilidad_lineaswwds_15_tfrublincod_to ,
                                              AV78Contabilidad_lineaswwds_17_tfrublindsc_sel ,
                                              AV77Contabilidad_lineaswwds_16_tfrublindsc ,
                                              AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel ,
                                              AV79Contabilidad_lineaswwds_18_tfrublindsctot ,
                                              AV81Contabilidad_lineaswwds_20_tfrublinord ,
                                              AV82Contabilidad_lineaswwds_21_tfrublinord_to ,
                                              AV83Contabilidad_lineaswwds_22_tfrublinsts_sels.Count ,
                                              A115TotRub ,
                                              A116RubCod ,
                                              A118RubLinCod ,
                                              A1826RubLinDsc ,
                                              A1827RubLinDscTot ,
                                              A119RubLinOrd } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV77Contabilidad_lineaswwds_16_tfrublindsc = StringUtil.PadR( StringUtil.RTrim( AV77Contabilidad_lineaswwds_16_tfrublindsc), 100, "%");
         lV79Contabilidad_lineaswwds_18_tfrublindsctot = StringUtil.PadR( StringUtil.RTrim( AV79Contabilidad_lineaswwds_18_tfrublindsctot), 100, "%");
         /* Using cursor P00753 */
         pr_default.execute(1, new Object[] {AV63Contabilidad_lineaswwds_2_tottipo1, AV66Contabilidad_lineaswwds_5_tottipo2, AV69Contabilidad_lineaswwds_8_tottipo3, AV71Contabilidad_lineaswwds_10_tftotrub, AV72Contabilidad_lineaswwds_11_tftotrub_to, AV73Contabilidad_lineaswwds_12_tfrubcod, AV74Contabilidad_lineaswwds_13_tfrubcod_to, AV75Contabilidad_lineaswwds_14_tfrublincod, AV76Contabilidad_lineaswwds_15_tfrublincod_to, lV77Contabilidad_lineaswwds_16_tfrublindsc, AV78Contabilidad_lineaswwds_17_tfrublindsc_sel, lV79Contabilidad_lineaswwds_18_tfrublindsctot, AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel, AV81Contabilidad_lineaswwds_20_tfrublinord, AV82Contabilidad_lineaswwds_21_tfrublinord_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK754 = false;
            A1827RubLinDscTot = P00753_A1827RubLinDscTot[0];
            A1828RubLinSts = P00753_A1828RubLinSts[0];
            A119RubLinOrd = P00753_A119RubLinOrd[0];
            A1826RubLinDsc = P00753_A1826RubLinDsc[0];
            A118RubLinCod = P00753_A118RubLinCod[0];
            A116RubCod = P00753_A116RubCod[0];
            A115TotRub = P00753_A115TotRub[0];
            A114TotTipo = P00753_A114TotTipo[0];
            AV38count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00753_A1827RubLinDscTot[0], A1827RubLinDscTot) == 0 ) )
            {
               BRK754 = false;
               A118RubLinCod = P00753_A118RubLinCod[0];
               A116RubCod = P00753_A116RubCod[0];
               A115TotRub = P00753_A115TotRub[0];
               A114TotTipo = P00753_A114TotTipo[0];
               AV38count = (long)(AV38count+1);
               BRK754 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1827RubLinDscTot)) )
            {
               AV30Option = A1827RubLinDscTot;
               AV31Options.Add(AV30Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV31Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK754 )
            {
               BRK754 = true;
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
         AV32OptionsJson = "";
         AV35OptionsDescJson = "";
         AV37OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV34OptionsDesc = new GxSimpleCollection<string>();
         AV36OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV39Session = context.GetSession();
         AV41GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV42GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TFTotTipo_SelsJson = "";
         AV11TFTotTipo_Sels = new GxSimpleCollection<string>();
         AV18TFRubLinDsc = "";
         AV19TFRubLinDsc_Sel = "";
         AV20TFRubLinDscTot = "";
         AV21TFRubLinDscTot_Sel = "";
         AV24TFRubLinSts_SelsJson = "";
         AV25TFRubLinSts_Sels = new GxSimpleCollection<short>();
         AV43GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV44DynamicFiltersSelector1 = "";
         AV55TotTipo1 = "";
         AV48DynamicFiltersSelector2 = "";
         AV56TotTipo2 = "";
         AV52DynamicFiltersSelector3 = "";
         AV57TotTipo3 = "";
         AV62Contabilidad_lineaswwds_1_dynamicfiltersselector1 = "";
         AV63Contabilidad_lineaswwds_2_tottipo1 = "";
         AV65Contabilidad_lineaswwds_4_dynamicfiltersselector2 = "";
         AV66Contabilidad_lineaswwds_5_tottipo2 = "";
         AV68Contabilidad_lineaswwds_7_dynamicfiltersselector3 = "";
         AV69Contabilidad_lineaswwds_8_tottipo3 = "";
         AV70Contabilidad_lineaswwds_9_tftottipo_sels = new GxSimpleCollection<string>();
         AV77Contabilidad_lineaswwds_16_tfrublindsc = "";
         AV78Contabilidad_lineaswwds_17_tfrublindsc_sel = "";
         AV79Contabilidad_lineaswwds_18_tfrublindsctot = "";
         AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel = "";
         AV83Contabilidad_lineaswwds_22_tfrublinsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV77Contabilidad_lineaswwds_16_tfrublindsc = "";
         lV79Contabilidad_lineaswwds_18_tfrublindsctot = "";
         A114TotTipo = "";
         A1826RubLinDsc = "";
         A1827RubLinDscTot = "";
         P00752_A1826RubLinDsc = new string[] {""} ;
         P00752_A1828RubLinSts = new short[1] ;
         P00752_A119RubLinOrd = new short[1] ;
         P00752_A1827RubLinDscTot = new string[] {""} ;
         P00752_A118RubLinCod = new int[1] ;
         P00752_A116RubCod = new int[1] ;
         P00752_A115TotRub = new int[1] ;
         P00752_A114TotTipo = new string[] {""} ;
         AV30Option = "";
         P00753_A1827RubLinDscTot = new string[] {""} ;
         P00753_A1828RubLinSts = new short[1] ;
         P00753_A119RubLinOrd = new short[1] ;
         P00753_A1826RubLinDsc = new string[] {""} ;
         P00753_A118RubLinCod = new int[1] ;
         P00753_A116RubCod = new int[1] ;
         P00753_A115TotRub = new int[1] ;
         P00753_A114TotTipo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.lineaswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00752_A1826RubLinDsc, P00752_A1828RubLinSts, P00752_A119RubLinOrd, P00752_A1827RubLinDscTot, P00752_A118RubLinCod, P00752_A116RubCod, P00752_A115TotRub, P00752_A114TotTipo
               }
               , new Object[] {
               P00753_A1827RubLinDscTot, P00753_A1828RubLinSts, P00753_A119RubLinOrd, P00753_A1826RubLinDsc, P00753_A118RubLinCod, P00753_A116RubCod, P00753_A115TotRub, P00753_A114TotTipo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV22TFRubLinOrd ;
      private short AV23TFRubLinOrd_To ;
      private short AV81Contabilidad_lineaswwds_20_tfrublinord ;
      private short AV82Contabilidad_lineaswwds_21_tfrublinord_to ;
      private short A1828RubLinSts ;
      private short A119RubLinOrd ;
      private int AV60GXV1 ;
      private int AV12TFTotRub ;
      private int AV13TFTotRub_To ;
      private int AV14TFRubCod ;
      private int AV15TFRubCod_To ;
      private int AV16TFRubLinCod ;
      private int AV17TFRubLinCod_To ;
      private int AV71Contabilidad_lineaswwds_10_tftotrub ;
      private int AV72Contabilidad_lineaswwds_11_tftotrub_to ;
      private int AV73Contabilidad_lineaswwds_12_tfrubcod ;
      private int AV74Contabilidad_lineaswwds_13_tfrubcod_to ;
      private int AV75Contabilidad_lineaswwds_14_tfrublincod ;
      private int AV76Contabilidad_lineaswwds_15_tfrublincod_to ;
      private int AV70Contabilidad_lineaswwds_9_tftottipo_sels_Count ;
      private int AV83Contabilidad_lineaswwds_22_tfrublinsts_sels_Count ;
      private int A115TotRub ;
      private int A116RubCod ;
      private int A118RubLinCod ;
      private long AV38count ;
      private string AV18TFRubLinDsc ;
      private string AV19TFRubLinDsc_Sel ;
      private string AV20TFRubLinDscTot ;
      private string AV21TFRubLinDscTot_Sel ;
      private string AV55TotTipo1 ;
      private string AV56TotTipo2 ;
      private string AV57TotTipo3 ;
      private string AV63Contabilidad_lineaswwds_2_tottipo1 ;
      private string AV66Contabilidad_lineaswwds_5_tottipo2 ;
      private string AV69Contabilidad_lineaswwds_8_tottipo3 ;
      private string AV77Contabilidad_lineaswwds_16_tfrublindsc ;
      private string AV78Contabilidad_lineaswwds_17_tfrublindsc_sel ;
      private string AV79Contabilidad_lineaswwds_18_tfrublindsctot ;
      private string AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel ;
      private string scmdbuf ;
      private string lV77Contabilidad_lineaswwds_16_tfrublindsc ;
      private string lV79Contabilidad_lineaswwds_18_tfrublindsctot ;
      private string A114TotTipo ;
      private string A1826RubLinDsc ;
      private string A1827RubLinDscTot ;
      private bool returnInSub ;
      private bool AV47DynamicFiltersEnabled2 ;
      private bool AV51DynamicFiltersEnabled3 ;
      private bool AV64Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ;
      private bool AV67Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ;
      private bool BRK752 ;
      private bool BRK754 ;
      private string AV32OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string AV10TFTotTipo_SelsJson ;
      private string AV24TFRubLinSts_SelsJson ;
      private string AV28DDOName ;
      private string AV26SearchTxt ;
      private string AV27SearchTxtTo ;
      private string AV44DynamicFiltersSelector1 ;
      private string AV48DynamicFiltersSelector2 ;
      private string AV52DynamicFiltersSelector3 ;
      private string AV62Contabilidad_lineaswwds_1_dynamicfiltersselector1 ;
      private string AV65Contabilidad_lineaswwds_4_dynamicfiltersselector2 ;
      private string AV68Contabilidad_lineaswwds_7_dynamicfiltersselector3 ;
      private string AV30Option ;
      private GxSimpleCollection<short> AV25TFRubLinSts_Sels ;
      private GxSimpleCollection<short> AV83Contabilidad_lineaswwds_22_tfrublinsts_sels ;
      private IGxSession AV39Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00752_A1826RubLinDsc ;
      private short[] P00752_A1828RubLinSts ;
      private short[] P00752_A119RubLinOrd ;
      private string[] P00752_A1827RubLinDscTot ;
      private int[] P00752_A118RubLinCod ;
      private int[] P00752_A116RubCod ;
      private int[] P00752_A115TotRub ;
      private string[] P00752_A114TotTipo ;
      private string[] P00753_A1827RubLinDscTot ;
      private short[] P00753_A1828RubLinSts ;
      private short[] P00753_A119RubLinOrd ;
      private string[] P00753_A1826RubLinDsc ;
      private int[] P00753_A118RubLinCod ;
      private int[] P00753_A116RubCod ;
      private int[] P00753_A115TotRub ;
      private string[] P00753_A114TotTipo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV11TFTotTipo_Sels ;
      private GxSimpleCollection<string> AV70Contabilidad_lineaswwds_9_tftottipo_sels ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV34OptionsDesc ;
      private GxSimpleCollection<string> AV36OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV43GridStateDynamicFilter ;
   }

   public class lineaswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00752( IGxContext context ,
                                             string A114TotTipo ,
                                             GxSimpleCollection<string> AV70Contabilidad_lineaswwds_9_tftottipo_sels ,
                                             short A1828RubLinSts ,
                                             GxSimpleCollection<short> AV83Contabilidad_lineaswwds_22_tfrublinsts_sels ,
                                             string AV62Contabilidad_lineaswwds_1_dynamicfiltersselector1 ,
                                             string AV63Contabilidad_lineaswwds_2_tottipo1 ,
                                             bool AV64Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ,
                                             string AV65Contabilidad_lineaswwds_4_dynamicfiltersselector2 ,
                                             string AV66Contabilidad_lineaswwds_5_tottipo2 ,
                                             bool AV67Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ,
                                             string AV68Contabilidad_lineaswwds_7_dynamicfiltersselector3 ,
                                             string AV69Contabilidad_lineaswwds_8_tottipo3 ,
                                             int AV70Contabilidad_lineaswwds_9_tftottipo_sels_Count ,
                                             int AV71Contabilidad_lineaswwds_10_tftotrub ,
                                             int AV72Contabilidad_lineaswwds_11_tftotrub_to ,
                                             int AV73Contabilidad_lineaswwds_12_tfrubcod ,
                                             int AV74Contabilidad_lineaswwds_13_tfrubcod_to ,
                                             int AV75Contabilidad_lineaswwds_14_tfrublincod ,
                                             int AV76Contabilidad_lineaswwds_15_tfrublincod_to ,
                                             string AV78Contabilidad_lineaswwds_17_tfrublindsc_sel ,
                                             string AV77Contabilidad_lineaswwds_16_tfrublindsc ,
                                             string AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel ,
                                             string AV79Contabilidad_lineaswwds_18_tfrublindsctot ,
                                             short AV81Contabilidad_lineaswwds_20_tfrublinord ,
                                             short AV82Contabilidad_lineaswwds_21_tfrublinord_to ,
                                             int AV83Contabilidad_lineaswwds_22_tfrublinsts_sels_Count ,
                                             int A115TotRub ,
                                             int A116RubCod ,
                                             int A118RubLinCod ,
                                             string A1826RubLinDsc ,
                                             string A1827RubLinDscTot ,
                                             short A119RubLinOrd )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [RubLinDsc], [RubLinSts], [RubLinOrd], [RubLinDscTot], [RubLinCod], [RubCod], [TotRub], [TotTipo] FROM [CBRUBROSL]";
         if ( ( StringUtil.StrCmp(AV62Contabilidad_lineaswwds_1_dynamicfiltersselector1, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_lineaswwds_2_tottipo1)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV63Contabilidad_lineaswwds_2_tottipo1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( AV64Contabilidad_lineaswwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Contabilidad_lineaswwds_4_dynamicfiltersselector2, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_lineaswwds_5_tottipo2)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV66Contabilidad_lineaswwds_5_tottipo2)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV67Contabilidad_lineaswwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Contabilidad_lineaswwds_7_dynamicfiltersselector3, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_lineaswwds_8_tottipo3)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV69Contabilidad_lineaswwds_8_tottipo3)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV70Contabilidad_lineaswwds_9_tftottipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV70Contabilidad_lineaswwds_9_tftottipo_sels, "[TotTipo] IN (", ")")+")");
         }
         if ( ! (0==AV71Contabilidad_lineaswwds_10_tftotrub) )
         {
            AddWhere(sWhereString, "([TotRub] >= @AV71Contabilidad_lineaswwds_10_tftotrub)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV72Contabilidad_lineaswwds_11_tftotrub_to) )
         {
            AddWhere(sWhereString, "([TotRub] <= @AV72Contabilidad_lineaswwds_11_tftotrub_to)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV73Contabilidad_lineaswwds_12_tfrubcod) )
         {
            AddWhere(sWhereString, "([RubCod] >= @AV73Contabilidad_lineaswwds_12_tfrubcod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV74Contabilidad_lineaswwds_13_tfrubcod_to) )
         {
            AddWhere(sWhereString, "([RubCod] <= @AV74Contabilidad_lineaswwds_13_tfrubcod_to)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV75Contabilidad_lineaswwds_14_tfrublincod) )
         {
            AddWhere(sWhereString, "([RubLinCod] >= @AV75Contabilidad_lineaswwds_14_tfrublincod)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV76Contabilidad_lineaswwds_15_tfrublincod_to) )
         {
            AddWhere(sWhereString, "([RubLinCod] <= @AV76Contabilidad_lineaswwds_15_tfrublincod_to)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_lineaswwds_17_tfrublindsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_lineaswwds_16_tfrublindsc)) ) )
         {
            AddWhere(sWhereString, "([RubLinDsc] like @lV77Contabilidad_lineaswwds_16_tfrublindsc)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_lineaswwds_17_tfrublindsc_sel)) )
         {
            AddWhere(sWhereString, "([RubLinDsc] = @AV78Contabilidad_lineaswwds_17_tfrublindsc_sel)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_lineaswwds_18_tfrublindsctot)) ) )
         {
            AddWhere(sWhereString, "([RubLinDscTot] like @lV79Contabilidad_lineaswwds_18_tfrublindsctot)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel)) )
         {
            AddWhere(sWhereString, "([RubLinDscTot] = @AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (0==AV81Contabilidad_lineaswwds_20_tfrublinord) )
         {
            AddWhere(sWhereString, "([RubLinOrd] >= @AV81Contabilidad_lineaswwds_20_tfrublinord)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! (0==AV82Contabilidad_lineaswwds_21_tfrublinord_to) )
         {
            AddWhere(sWhereString, "([RubLinOrd] <= @AV82Contabilidad_lineaswwds_21_tfrublinord_to)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV83Contabilidad_lineaswwds_22_tfrublinsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Contabilidad_lineaswwds_22_tfrublinsts_sels, "[RubLinSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [RubLinDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00753( IGxContext context ,
                                             string A114TotTipo ,
                                             GxSimpleCollection<string> AV70Contabilidad_lineaswwds_9_tftottipo_sels ,
                                             short A1828RubLinSts ,
                                             GxSimpleCollection<short> AV83Contabilidad_lineaswwds_22_tfrublinsts_sels ,
                                             string AV62Contabilidad_lineaswwds_1_dynamicfiltersselector1 ,
                                             string AV63Contabilidad_lineaswwds_2_tottipo1 ,
                                             bool AV64Contabilidad_lineaswwds_3_dynamicfiltersenabled2 ,
                                             string AV65Contabilidad_lineaswwds_4_dynamicfiltersselector2 ,
                                             string AV66Contabilidad_lineaswwds_5_tottipo2 ,
                                             bool AV67Contabilidad_lineaswwds_6_dynamicfiltersenabled3 ,
                                             string AV68Contabilidad_lineaswwds_7_dynamicfiltersselector3 ,
                                             string AV69Contabilidad_lineaswwds_8_tottipo3 ,
                                             int AV70Contabilidad_lineaswwds_9_tftottipo_sels_Count ,
                                             int AV71Contabilidad_lineaswwds_10_tftotrub ,
                                             int AV72Contabilidad_lineaswwds_11_tftotrub_to ,
                                             int AV73Contabilidad_lineaswwds_12_tfrubcod ,
                                             int AV74Contabilidad_lineaswwds_13_tfrubcod_to ,
                                             int AV75Contabilidad_lineaswwds_14_tfrublincod ,
                                             int AV76Contabilidad_lineaswwds_15_tfrublincod_to ,
                                             string AV78Contabilidad_lineaswwds_17_tfrublindsc_sel ,
                                             string AV77Contabilidad_lineaswwds_16_tfrublindsc ,
                                             string AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel ,
                                             string AV79Contabilidad_lineaswwds_18_tfrublindsctot ,
                                             short AV81Contabilidad_lineaswwds_20_tfrublinord ,
                                             short AV82Contabilidad_lineaswwds_21_tfrublinord_to ,
                                             int AV83Contabilidad_lineaswwds_22_tfrublinsts_sels_Count ,
                                             int A115TotRub ,
                                             int A116RubCod ,
                                             int A118RubLinCod ,
                                             string A1826RubLinDsc ,
                                             string A1827RubLinDscTot ,
                                             short A119RubLinOrd )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[15];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [RubLinDscTot], [RubLinSts], [RubLinOrd], [RubLinDsc], [RubLinCod], [RubCod], [TotRub], [TotTipo] FROM [CBRUBROSL]";
         if ( ( StringUtil.StrCmp(AV62Contabilidad_lineaswwds_1_dynamicfiltersselector1, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Contabilidad_lineaswwds_2_tottipo1)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV63Contabilidad_lineaswwds_2_tottipo1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( AV64Contabilidad_lineaswwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Contabilidad_lineaswwds_4_dynamicfiltersselector2, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_lineaswwds_5_tottipo2)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV66Contabilidad_lineaswwds_5_tottipo2)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV67Contabilidad_lineaswwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Contabilidad_lineaswwds_7_dynamicfiltersselector3, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_lineaswwds_8_tottipo3)) ) )
         {
            AddWhere(sWhereString, "([TotTipo] = @AV69Contabilidad_lineaswwds_8_tottipo3)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV70Contabilidad_lineaswwds_9_tftottipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV70Contabilidad_lineaswwds_9_tftottipo_sels, "[TotTipo] IN (", ")")+")");
         }
         if ( ! (0==AV71Contabilidad_lineaswwds_10_tftotrub) )
         {
            AddWhere(sWhereString, "([TotRub] >= @AV71Contabilidad_lineaswwds_10_tftotrub)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV72Contabilidad_lineaswwds_11_tftotrub_to) )
         {
            AddWhere(sWhereString, "([TotRub] <= @AV72Contabilidad_lineaswwds_11_tftotrub_to)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV73Contabilidad_lineaswwds_12_tfrubcod) )
         {
            AddWhere(sWhereString, "([RubCod] >= @AV73Contabilidad_lineaswwds_12_tfrubcod)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV74Contabilidad_lineaswwds_13_tfrubcod_to) )
         {
            AddWhere(sWhereString, "([RubCod] <= @AV74Contabilidad_lineaswwds_13_tfrubcod_to)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV75Contabilidad_lineaswwds_14_tfrublincod) )
         {
            AddWhere(sWhereString, "([RubLinCod] >= @AV75Contabilidad_lineaswwds_14_tfrublincod)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! (0==AV76Contabilidad_lineaswwds_15_tfrublincod_to) )
         {
            AddWhere(sWhereString, "([RubLinCod] <= @AV76Contabilidad_lineaswwds_15_tfrublincod_to)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_lineaswwds_17_tfrublindsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_lineaswwds_16_tfrublindsc)) ) )
         {
            AddWhere(sWhereString, "([RubLinDsc] like @lV77Contabilidad_lineaswwds_16_tfrublindsc)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_lineaswwds_17_tfrublindsc_sel)) )
         {
            AddWhere(sWhereString, "([RubLinDsc] = @AV78Contabilidad_lineaswwds_17_tfrublindsc_sel)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_lineaswwds_18_tfrublindsctot)) ) )
         {
            AddWhere(sWhereString, "([RubLinDscTot] like @lV79Contabilidad_lineaswwds_18_tfrublindsctot)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel)) )
         {
            AddWhere(sWhereString, "([RubLinDscTot] = @AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (0==AV81Contabilidad_lineaswwds_20_tfrublinord) )
         {
            AddWhere(sWhereString, "([RubLinOrd] >= @AV81Contabilidad_lineaswwds_20_tfrublinord)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! (0==AV82Contabilidad_lineaswwds_21_tfrublinord_to) )
         {
            AddWhere(sWhereString, "([RubLinOrd] <= @AV82Contabilidad_lineaswwds_21_tfrublinord_to)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV83Contabilidad_lineaswwds_22_tfrublinsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV83Contabilidad_lineaswwds_22_tfrublinsts_sels, "[RubLinSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [RubLinDscTot]";
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
                     return conditional_P00752(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] );
               case 1 :
                     return conditional_P00753(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (short)dynConstraints[31] );
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
          Object[] prmP00752;
          prmP00752 = new Object[] {
          new ParDef("@AV63Contabilidad_lineaswwds_2_tottipo1",GXType.NChar,3,0) ,
          new ParDef("@AV66Contabilidad_lineaswwds_5_tottipo2",GXType.NChar,3,0) ,
          new ParDef("@AV69Contabilidad_lineaswwds_8_tottipo3",GXType.NChar,3,0) ,
          new ParDef("@AV71Contabilidad_lineaswwds_10_tftotrub",GXType.Int32,6,0) ,
          new ParDef("@AV72Contabilidad_lineaswwds_11_tftotrub_to",GXType.Int32,6,0) ,
          new ParDef("@AV73Contabilidad_lineaswwds_12_tfrubcod",GXType.Int32,6,0) ,
          new ParDef("@AV74Contabilidad_lineaswwds_13_tfrubcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV75Contabilidad_lineaswwds_14_tfrublincod",GXType.Int32,6,0) ,
          new ParDef("@AV76Contabilidad_lineaswwds_15_tfrublincod_to",GXType.Int32,6,0) ,
          new ParDef("@lV77Contabilidad_lineaswwds_16_tfrublindsc",GXType.NChar,100,0) ,
          new ParDef("@AV78Contabilidad_lineaswwds_17_tfrublindsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV79Contabilidad_lineaswwds_18_tfrublindsctot",GXType.NChar,100,0) ,
          new ParDef("@AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel",GXType.NChar,100,0) ,
          new ParDef("@AV81Contabilidad_lineaswwds_20_tfrublinord",GXType.Int16,2,0) ,
          new ParDef("@AV82Contabilidad_lineaswwds_21_tfrublinord_to",GXType.Int16,2,0)
          };
          Object[] prmP00753;
          prmP00753 = new Object[] {
          new ParDef("@AV63Contabilidad_lineaswwds_2_tottipo1",GXType.NChar,3,0) ,
          new ParDef("@AV66Contabilidad_lineaswwds_5_tottipo2",GXType.NChar,3,0) ,
          new ParDef("@AV69Contabilidad_lineaswwds_8_tottipo3",GXType.NChar,3,0) ,
          new ParDef("@AV71Contabilidad_lineaswwds_10_tftotrub",GXType.Int32,6,0) ,
          new ParDef("@AV72Contabilidad_lineaswwds_11_tftotrub_to",GXType.Int32,6,0) ,
          new ParDef("@AV73Contabilidad_lineaswwds_12_tfrubcod",GXType.Int32,6,0) ,
          new ParDef("@AV74Contabilidad_lineaswwds_13_tfrubcod_to",GXType.Int32,6,0) ,
          new ParDef("@AV75Contabilidad_lineaswwds_14_tfrublincod",GXType.Int32,6,0) ,
          new ParDef("@AV76Contabilidad_lineaswwds_15_tfrublincod_to",GXType.Int32,6,0) ,
          new ParDef("@lV77Contabilidad_lineaswwds_16_tfrublindsc",GXType.NChar,100,0) ,
          new ParDef("@AV78Contabilidad_lineaswwds_17_tfrublindsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV79Contabilidad_lineaswwds_18_tfrublindsctot",GXType.NChar,100,0) ,
          new ParDef("@AV80Contabilidad_lineaswwds_19_tfrublindsctot_sel",GXType.NChar,100,0) ,
          new ParDef("@AV81Contabilidad_lineaswwds_20_tfrublinord",GXType.Int16,2,0) ,
          new ParDef("@AV82Contabilidad_lineaswwds_21_tfrublinord_to",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00752", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00752,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00753", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00753,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 3);
                return;
       }
    }

 }

}
