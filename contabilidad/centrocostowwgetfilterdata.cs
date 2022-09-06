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
   public class centrocostowwgetfilterdata : GXProcedure
   {
      public centrocostowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public centrocostowwgetfilterdata( IGxContext context )
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
         centrocostowwgetfilterdata objcentrocostowwgetfilterdata;
         objcentrocostowwgetfilterdata = new centrocostowwgetfilterdata();
         objcentrocostowwgetfilterdata.AV24DDOName = aP0_DDOName;
         objcentrocostowwgetfilterdata.AV22SearchTxt = aP1_SearchTxt;
         objcentrocostowwgetfilterdata.AV23SearchTxtTo = aP2_SearchTxtTo;
         objcentrocostowwgetfilterdata.AV28OptionsJson = "" ;
         objcentrocostowwgetfilterdata.AV31OptionsDescJson = "" ;
         objcentrocostowwgetfilterdata.AV33OptionIndexesJson = "" ;
         objcentrocostowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objcentrocostowwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcentrocostowwgetfilterdata);
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((centrocostowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_COSCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADCOSCODOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_COSDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCOSDSCOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_COSABR") == 0 )
         {
            /* Execute user subroutine: 'LOADCOSABROPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_COSCUEDESTINO") == 0 )
         {
            /* Execute user subroutine: 'LOADCOSCUEDESTINOOPTIONS' */
            S151 ();
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
         if ( StringUtil.StrCmp(AV35Session.Get("Contabilidad.CentroCostoWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.CentroCostoWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("Contabilidad.CentroCostoWWGridState"), null, "", "");
         }
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV61GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOSCOD") == 0 )
            {
               AV10TFCOSCod = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOSCOD_SEL") == 0 )
            {
               AV11TFCOSCod_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOSDSC") == 0 )
            {
               AV12TFCOSDsc = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOSDSC_SEL") == 0 )
            {
               AV13TFCOSDsc_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOSABR") == 0 )
            {
               AV14TFCOSAbr = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOSABR_SEL") == 0 )
            {
               AV15TFCOSAbr_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOSCUEDESTINO") == 0 )
            {
               AV18TFCOSCueDestino = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOSCUEDESTINO_SEL") == 0 )
            {
               AV19TFCOSCueDestino_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCOSSTS_SEL") == 0 )
            {
               AV54TFCOSSts_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV55TFCOSSts_Sels.FromJSonString(AV54TFCOSSts_SelsJson, null);
            }
            AV61GXV1 = (int)(AV61GXV1+1);
         }
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV39GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "COSDSC") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV42COSDsc1 = AV39GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "COSCOD") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV56COSCod1 = AV39GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV39GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "COSDSC") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV47COSDsc2 = AV39GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "COSCOD") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV57COSCod2 = AV39GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV39GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "COSDSC") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV52COSDsc3 = AV39GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "COSCOD") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV58COSCod3 = AV39GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOSCODOPTIONS' Routine */
         returnInSub = false;
         AV10TFCOSCod = AV22SearchTxt;
         AV11TFCOSCod_Sel = "";
         AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV65Contabilidad_centrocostowwds_3_cosdsc1 = AV42COSDsc1;
         AV66Contabilidad_centrocostowwds_4_coscod1 = AV56COSCod1;
         AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV70Contabilidad_centrocostowwds_8_cosdsc2 = AV47COSDsc2;
         AV71Contabilidad_centrocostowwds_9_coscod2 = AV57COSCod2;
         AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV75Contabilidad_centrocostowwds_13_cosdsc3 = AV52COSDsc3;
         AV76Contabilidad_centrocostowwds_14_coscod3 = AV58COSCod3;
         AV77Contabilidad_centrocostowwds_15_tfcoscod = AV10TFCOSCod;
         AV78Contabilidad_centrocostowwds_16_tfcoscod_sel = AV11TFCOSCod_Sel;
         AV79Contabilidad_centrocostowwds_17_tfcosdsc = AV12TFCOSDsc;
         AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel = AV13TFCOSDsc_Sel;
         AV81Contabilidad_centrocostowwds_19_tfcosabr = AV14TFCOSAbr;
         AV82Contabilidad_centrocostowwds_20_tfcosabr_sel = AV15TFCOSAbr_Sel;
         AV83Contabilidad_centrocostowwds_21_tfcoscuedestino = AV18TFCOSCueDestino;
         AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel = AV19TFCOSCueDestino_Sel;
         AV85Contabilidad_centrocostowwds_23_tfcossts_sels = AV55TFCOSSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A762COSSts ,
                                              AV85Contabilidad_centrocostowwds_23_tfcossts_sels ,
                                              AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1 ,
                                              AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 ,
                                              AV65Contabilidad_centrocostowwds_3_cosdsc1 ,
                                              AV66Contabilidad_centrocostowwds_4_coscod1 ,
                                              AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 ,
                                              AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2 ,
                                              AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 ,
                                              AV70Contabilidad_centrocostowwds_8_cosdsc2 ,
                                              AV71Contabilidad_centrocostowwds_9_coscod2 ,
                                              AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 ,
                                              AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3 ,
                                              AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 ,
                                              AV75Contabilidad_centrocostowwds_13_cosdsc3 ,
                                              AV76Contabilidad_centrocostowwds_14_coscod3 ,
                                              AV78Contabilidad_centrocostowwds_16_tfcoscod_sel ,
                                              AV77Contabilidad_centrocostowwds_15_tfcoscod ,
                                              AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel ,
                                              AV79Contabilidad_centrocostowwds_17_tfcosdsc ,
                                              AV82Contabilidad_centrocostowwds_20_tfcosabr_sel ,
                                              AV81Contabilidad_centrocostowwds_19_tfcosabr ,
                                              AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel ,
                                              AV83Contabilidad_centrocostowwds_21_tfcoscuedestino ,
                                              AV85Contabilidad_centrocostowwds_23_tfcossts_sels.Count ,
                                              A761COSDsc ,
                                              A79COSCod ,
                                              A759COSAbr ,
                                              A80COSCueDestino } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV65Contabilidad_centrocostowwds_3_cosdsc1 = StringUtil.PadR( StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1), 100, "%");
         lV65Contabilidad_centrocostowwds_3_cosdsc1 = StringUtil.PadR( StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1), 100, "%");
         lV66Contabilidad_centrocostowwds_4_coscod1 = StringUtil.PadR( StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1), 10, "%");
         lV66Contabilidad_centrocostowwds_4_coscod1 = StringUtil.PadR( StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1), 10, "%");
         lV70Contabilidad_centrocostowwds_8_cosdsc2 = StringUtil.PadR( StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2), 100, "%");
         lV70Contabilidad_centrocostowwds_8_cosdsc2 = StringUtil.PadR( StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2), 100, "%");
         lV71Contabilidad_centrocostowwds_9_coscod2 = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2), 10, "%");
         lV71Contabilidad_centrocostowwds_9_coscod2 = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2), 10, "%");
         lV75Contabilidad_centrocostowwds_13_cosdsc3 = StringUtil.PadR( StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3), 100, "%");
         lV75Contabilidad_centrocostowwds_13_cosdsc3 = StringUtil.PadR( StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3), 100, "%");
         lV76Contabilidad_centrocostowwds_14_coscod3 = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3), 10, "%");
         lV76Contabilidad_centrocostowwds_14_coscod3 = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3), 10, "%");
         lV77Contabilidad_centrocostowwds_15_tfcoscod = StringUtil.PadR( StringUtil.RTrim( AV77Contabilidad_centrocostowwds_15_tfcoscod), 10, "%");
         lV79Contabilidad_centrocostowwds_17_tfcosdsc = StringUtil.PadR( StringUtil.RTrim( AV79Contabilidad_centrocostowwds_17_tfcosdsc), 100, "%");
         lV81Contabilidad_centrocostowwds_19_tfcosabr = StringUtil.PadR( StringUtil.RTrim( AV81Contabilidad_centrocostowwds_19_tfcosabr), 5, "%");
         lV83Contabilidad_centrocostowwds_21_tfcoscuedestino = StringUtil.PadR( StringUtil.RTrim( AV83Contabilidad_centrocostowwds_21_tfcoscuedestino), 15, "%");
         /* Using cursor P006R2 */
         pr_default.execute(0, new Object[] {lV65Contabilidad_centrocostowwds_3_cosdsc1, lV65Contabilidad_centrocostowwds_3_cosdsc1, lV66Contabilidad_centrocostowwds_4_coscod1, lV66Contabilidad_centrocostowwds_4_coscod1, lV70Contabilidad_centrocostowwds_8_cosdsc2, lV70Contabilidad_centrocostowwds_8_cosdsc2, lV71Contabilidad_centrocostowwds_9_coscod2, lV71Contabilidad_centrocostowwds_9_coscod2, lV75Contabilidad_centrocostowwds_13_cosdsc3, lV75Contabilidad_centrocostowwds_13_cosdsc3, lV76Contabilidad_centrocostowwds_14_coscod3, lV76Contabilidad_centrocostowwds_14_coscod3, lV77Contabilidad_centrocostowwds_15_tfcoscod, AV78Contabilidad_centrocostowwds_16_tfcoscod_sel, lV79Contabilidad_centrocostowwds_17_tfcosdsc, AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel, lV81Contabilidad_centrocostowwds_19_tfcosabr, AV82Contabilidad_centrocostowwds_20_tfcosabr_sel, lV83Contabilidad_centrocostowwds_21_tfcoscuedestino, AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A762COSSts = P006R2_A762COSSts[0];
            A80COSCueDestino = P006R2_A80COSCueDestino[0];
            n80COSCueDestino = P006R2_n80COSCueDestino[0];
            A759COSAbr = P006R2_A759COSAbr[0];
            A79COSCod = P006R2_A79COSCod[0];
            A761COSDsc = P006R2_A761COSDsc[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A79COSCod)) )
            {
               AV26Option = A79COSCod;
               AV27Options.Add(AV26Option, 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCOSDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFCOSDsc = AV22SearchTxt;
         AV13TFCOSDsc_Sel = "";
         AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV65Contabilidad_centrocostowwds_3_cosdsc1 = AV42COSDsc1;
         AV66Contabilidad_centrocostowwds_4_coscod1 = AV56COSCod1;
         AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV70Contabilidad_centrocostowwds_8_cosdsc2 = AV47COSDsc2;
         AV71Contabilidad_centrocostowwds_9_coscod2 = AV57COSCod2;
         AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV75Contabilidad_centrocostowwds_13_cosdsc3 = AV52COSDsc3;
         AV76Contabilidad_centrocostowwds_14_coscod3 = AV58COSCod3;
         AV77Contabilidad_centrocostowwds_15_tfcoscod = AV10TFCOSCod;
         AV78Contabilidad_centrocostowwds_16_tfcoscod_sel = AV11TFCOSCod_Sel;
         AV79Contabilidad_centrocostowwds_17_tfcosdsc = AV12TFCOSDsc;
         AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel = AV13TFCOSDsc_Sel;
         AV81Contabilidad_centrocostowwds_19_tfcosabr = AV14TFCOSAbr;
         AV82Contabilidad_centrocostowwds_20_tfcosabr_sel = AV15TFCOSAbr_Sel;
         AV83Contabilidad_centrocostowwds_21_tfcoscuedestino = AV18TFCOSCueDestino;
         AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel = AV19TFCOSCueDestino_Sel;
         AV85Contabilidad_centrocostowwds_23_tfcossts_sels = AV55TFCOSSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A762COSSts ,
                                              AV85Contabilidad_centrocostowwds_23_tfcossts_sels ,
                                              AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1 ,
                                              AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 ,
                                              AV65Contabilidad_centrocostowwds_3_cosdsc1 ,
                                              AV66Contabilidad_centrocostowwds_4_coscod1 ,
                                              AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 ,
                                              AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2 ,
                                              AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 ,
                                              AV70Contabilidad_centrocostowwds_8_cosdsc2 ,
                                              AV71Contabilidad_centrocostowwds_9_coscod2 ,
                                              AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 ,
                                              AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3 ,
                                              AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 ,
                                              AV75Contabilidad_centrocostowwds_13_cosdsc3 ,
                                              AV76Contabilidad_centrocostowwds_14_coscod3 ,
                                              AV78Contabilidad_centrocostowwds_16_tfcoscod_sel ,
                                              AV77Contabilidad_centrocostowwds_15_tfcoscod ,
                                              AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel ,
                                              AV79Contabilidad_centrocostowwds_17_tfcosdsc ,
                                              AV82Contabilidad_centrocostowwds_20_tfcosabr_sel ,
                                              AV81Contabilidad_centrocostowwds_19_tfcosabr ,
                                              AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel ,
                                              AV83Contabilidad_centrocostowwds_21_tfcoscuedestino ,
                                              AV85Contabilidad_centrocostowwds_23_tfcossts_sels.Count ,
                                              A761COSDsc ,
                                              A79COSCod ,
                                              A759COSAbr ,
                                              A80COSCueDestino } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV65Contabilidad_centrocostowwds_3_cosdsc1 = StringUtil.PadR( StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1), 100, "%");
         lV65Contabilidad_centrocostowwds_3_cosdsc1 = StringUtil.PadR( StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1), 100, "%");
         lV66Contabilidad_centrocostowwds_4_coscod1 = StringUtil.PadR( StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1), 10, "%");
         lV66Contabilidad_centrocostowwds_4_coscod1 = StringUtil.PadR( StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1), 10, "%");
         lV70Contabilidad_centrocostowwds_8_cosdsc2 = StringUtil.PadR( StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2), 100, "%");
         lV70Contabilidad_centrocostowwds_8_cosdsc2 = StringUtil.PadR( StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2), 100, "%");
         lV71Contabilidad_centrocostowwds_9_coscod2 = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2), 10, "%");
         lV71Contabilidad_centrocostowwds_9_coscod2 = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2), 10, "%");
         lV75Contabilidad_centrocostowwds_13_cosdsc3 = StringUtil.PadR( StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3), 100, "%");
         lV75Contabilidad_centrocostowwds_13_cosdsc3 = StringUtil.PadR( StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3), 100, "%");
         lV76Contabilidad_centrocostowwds_14_coscod3 = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3), 10, "%");
         lV76Contabilidad_centrocostowwds_14_coscod3 = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3), 10, "%");
         lV77Contabilidad_centrocostowwds_15_tfcoscod = StringUtil.PadR( StringUtil.RTrim( AV77Contabilidad_centrocostowwds_15_tfcoscod), 10, "%");
         lV79Contabilidad_centrocostowwds_17_tfcosdsc = StringUtil.PadR( StringUtil.RTrim( AV79Contabilidad_centrocostowwds_17_tfcosdsc), 100, "%");
         lV81Contabilidad_centrocostowwds_19_tfcosabr = StringUtil.PadR( StringUtil.RTrim( AV81Contabilidad_centrocostowwds_19_tfcosabr), 5, "%");
         lV83Contabilidad_centrocostowwds_21_tfcoscuedestino = StringUtil.PadR( StringUtil.RTrim( AV83Contabilidad_centrocostowwds_21_tfcoscuedestino), 15, "%");
         /* Using cursor P006R3 */
         pr_default.execute(1, new Object[] {lV65Contabilidad_centrocostowwds_3_cosdsc1, lV65Contabilidad_centrocostowwds_3_cosdsc1, lV66Contabilidad_centrocostowwds_4_coscod1, lV66Contabilidad_centrocostowwds_4_coscod1, lV70Contabilidad_centrocostowwds_8_cosdsc2, lV70Contabilidad_centrocostowwds_8_cosdsc2, lV71Contabilidad_centrocostowwds_9_coscod2, lV71Contabilidad_centrocostowwds_9_coscod2, lV75Contabilidad_centrocostowwds_13_cosdsc3, lV75Contabilidad_centrocostowwds_13_cosdsc3, lV76Contabilidad_centrocostowwds_14_coscod3, lV76Contabilidad_centrocostowwds_14_coscod3, lV77Contabilidad_centrocostowwds_15_tfcoscod, AV78Contabilidad_centrocostowwds_16_tfcoscod_sel, lV79Contabilidad_centrocostowwds_17_tfcosdsc, AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel, lV81Contabilidad_centrocostowwds_19_tfcosabr, AV82Contabilidad_centrocostowwds_20_tfcosabr_sel, lV83Contabilidad_centrocostowwds_21_tfcoscuedestino, AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6R3 = false;
            A761COSDsc = P006R3_A761COSDsc[0];
            A762COSSts = P006R3_A762COSSts[0];
            A80COSCueDestino = P006R3_A80COSCueDestino[0];
            n80COSCueDestino = P006R3_n80COSCueDestino[0];
            A759COSAbr = P006R3_A759COSAbr[0];
            A79COSCod = P006R3_A79COSCod[0];
            AV34count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006R3_A761COSDsc[0], A761COSDsc) == 0 ) )
            {
               BRK6R3 = false;
               A79COSCod = P006R3_A79COSCod[0];
               AV34count = (long)(AV34count+1);
               BRK6R3 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A761COSDsc)) )
            {
               AV26Option = A761COSDsc;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK6R3 )
            {
               BRK6R3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCOSABROPTIONS' Routine */
         returnInSub = false;
         AV14TFCOSAbr = AV22SearchTxt;
         AV15TFCOSAbr_Sel = "";
         AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV65Contabilidad_centrocostowwds_3_cosdsc1 = AV42COSDsc1;
         AV66Contabilidad_centrocostowwds_4_coscod1 = AV56COSCod1;
         AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV70Contabilidad_centrocostowwds_8_cosdsc2 = AV47COSDsc2;
         AV71Contabilidad_centrocostowwds_9_coscod2 = AV57COSCod2;
         AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV75Contabilidad_centrocostowwds_13_cosdsc3 = AV52COSDsc3;
         AV76Contabilidad_centrocostowwds_14_coscod3 = AV58COSCod3;
         AV77Contabilidad_centrocostowwds_15_tfcoscod = AV10TFCOSCod;
         AV78Contabilidad_centrocostowwds_16_tfcoscod_sel = AV11TFCOSCod_Sel;
         AV79Contabilidad_centrocostowwds_17_tfcosdsc = AV12TFCOSDsc;
         AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel = AV13TFCOSDsc_Sel;
         AV81Contabilidad_centrocostowwds_19_tfcosabr = AV14TFCOSAbr;
         AV82Contabilidad_centrocostowwds_20_tfcosabr_sel = AV15TFCOSAbr_Sel;
         AV83Contabilidad_centrocostowwds_21_tfcoscuedestino = AV18TFCOSCueDestino;
         AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel = AV19TFCOSCueDestino_Sel;
         AV85Contabilidad_centrocostowwds_23_tfcossts_sels = AV55TFCOSSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A762COSSts ,
                                              AV85Contabilidad_centrocostowwds_23_tfcossts_sels ,
                                              AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1 ,
                                              AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 ,
                                              AV65Contabilidad_centrocostowwds_3_cosdsc1 ,
                                              AV66Contabilidad_centrocostowwds_4_coscod1 ,
                                              AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 ,
                                              AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2 ,
                                              AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 ,
                                              AV70Contabilidad_centrocostowwds_8_cosdsc2 ,
                                              AV71Contabilidad_centrocostowwds_9_coscod2 ,
                                              AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 ,
                                              AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3 ,
                                              AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 ,
                                              AV75Contabilidad_centrocostowwds_13_cosdsc3 ,
                                              AV76Contabilidad_centrocostowwds_14_coscod3 ,
                                              AV78Contabilidad_centrocostowwds_16_tfcoscod_sel ,
                                              AV77Contabilidad_centrocostowwds_15_tfcoscod ,
                                              AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel ,
                                              AV79Contabilidad_centrocostowwds_17_tfcosdsc ,
                                              AV82Contabilidad_centrocostowwds_20_tfcosabr_sel ,
                                              AV81Contabilidad_centrocostowwds_19_tfcosabr ,
                                              AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel ,
                                              AV83Contabilidad_centrocostowwds_21_tfcoscuedestino ,
                                              AV85Contabilidad_centrocostowwds_23_tfcossts_sels.Count ,
                                              A761COSDsc ,
                                              A79COSCod ,
                                              A759COSAbr ,
                                              A80COSCueDestino } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV65Contabilidad_centrocostowwds_3_cosdsc1 = StringUtil.PadR( StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1), 100, "%");
         lV65Contabilidad_centrocostowwds_3_cosdsc1 = StringUtil.PadR( StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1), 100, "%");
         lV66Contabilidad_centrocostowwds_4_coscod1 = StringUtil.PadR( StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1), 10, "%");
         lV66Contabilidad_centrocostowwds_4_coscod1 = StringUtil.PadR( StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1), 10, "%");
         lV70Contabilidad_centrocostowwds_8_cosdsc2 = StringUtil.PadR( StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2), 100, "%");
         lV70Contabilidad_centrocostowwds_8_cosdsc2 = StringUtil.PadR( StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2), 100, "%");
         lV71Contabilidad_centrocostowwds_9_coscod2 = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2), 10, "%");
         lV71Contabilidad_centrocostowwds_9_coscod2 = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2), 10, "%");
         lV75Contabilidad_centrocostowwds_13_cosdsc3 = StringUtil.PadR( StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3), 100, "%");
         lV75Contabilidad_centrocostowwds_13_cosdsc3 = StringUtil.PadR( StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3), 100, "%");
         lV76Contabilidad_centrocostowwds_14_coscod3 = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3), 10, "%");
         lV76Contabilidad_centrocostowwds_14_coscod3 = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3), 10, "%");
         lV77Contabilidad_centrocostowwds_15_tfcoscod = StringUtil.PadR( StringUtil.RTrim( AV77Contabilidad_centrocostowwds_15_tfcoscod), 10, "%");
         lV79Contabilidad_centrocostowwds_17_tfcosdsc = StringUtil.PadR( StringUtil.RTrim( AV79Contabilidad_centrocostowwds_17_tfcosdsc), 100, "%");
         lV81Contabilidad_centrocostowwds_19_tfcosabr = StringUtil.PadR( StringUtil.RTrim( AV81Contabilidad_centrocostowwds_19_tfcosabr), 5, "%");
         lV83Contabilidad_centrocostowwds_21_tfcoscuedestino = StringUtil.PadR( StringUtil.RTrim( AV83Contabilidad_centrocostowwds_21_tfcoscuedestino), 15, "%");
         /* Using cursor P006R4 */
         pr_default.execute(2, new Object[] {lV65Contabilidad_centrocostowwds_3_cosdsc1, lV65Contabilidad_centrocostowwds_3_cosdsc1, lV66Contabilidad_centrocostowwds_4_coscod1, lV66Contabilidad_centrocostowwds_4_coscod1, lV70Contabilidad_centrocostowwds_8_cosdsc2, lV70Contabilidad_centrocostowwds_8_cosdsc2, lV71Contabilidad_centrocostowwds_9_coscod2, lV71Contabilidad_centrocostowwds_9_coscod2, lV75Contabilidad_centrocostowwds_13_cosdsc3, lV75Contabilidad_centrocostowwds_13_cosdsc3, lV76Contabilidad_centrocostowwds_14_coscod3, lV76Contabilidad_centrocostowwds_14_coscod3, lV77Contabilidad_centrocostowwds_15_tfcoscod, AV78Contabilidad_centrocostowwds_16_tfcoscod_sel, lV79Contabilidad_centrocostowwds_17_tfcosdsc, AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel, lV81Contabilidad_centrocostowwds_19_tfcosabr, AV82Contabilidad_centrocostowwds_20_tfcosabr_sel, lV83Contabilidad_centrocostowwds_21_tfcoscuedestino, AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6R5 = false;
            A759COSAbr = P006R4_A759COSAbr[0];
            A762COSSts = P006R4_A762COSSts[0];
            A80COSCueDestino = P006R4_A80COSCueDestino[0];
            n80COSCueDestino = P006R4_n80COSCueDestino[0];
            A79COSCod = P006R4_A79COSCod[0];
            A761COSDsc = P006R4_A761COSDsc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006R4_A759COSAbr[0], A759COSAbr) == 0 ) )
            {
               BRK6R5 = false;
               A79COSCod = P006R4_A79COSCod[0];
               AV34count = (long)(AV34count+1);
               BRK6R5 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A759COSAbr)) )
            {
               AV26Option = A759COSAbr;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK6R5 )
            {
               BRK6R5 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADCOSCUEDESTINOOPTIONS' Routine */
         returnInSub = false;
         AV18TFCOSCueDestino = AV22SearchTxt;
         AV19TFCOSCueDestino_Sel = "";
         AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV65Contabilidad_centrocostowwds_3_cosdsc1 = AV42COSDsc1;
         AV66Contabilidad_centrocostowwds_4_coscod1 = AV56COSCod1;
         AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV70Contabilidad_centrocostowwds_8_cosdsc2 = AV47COSDsc2;
         AV71Contabilidad_centrocostowwds_9_coscod2 = AV57COSCod2;
         AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV75Contabilidad_centrocostowwds_13_cosdsc3 = AV52COSDsc3;
         AV76Contabilidad_centrocostowwds_14_coscod3 = AV58COSCod3;
         AV77Contabilidad_centrocostowwds_15_tfcoscod = AV10TFCOSCod;
         AV78Contabilidad_centrocostowwds_16_tfcoscod_sel = AV11TFCOSCod_Sel;
         AV79Contabilidad_centrocostowwds_17_tfcosdsc = AV12TFCOSDsc;
         AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel = AV13TFCOSDsc_Sel;
         AV81Contabilidad_centrocostowwds_19_tfcosabr = AV14TFCOSAbr;
         AV82Contabilidad_centrocostowwds_20_tfcosabr_sel = AV15TFCOSAbr_Sel;
         AV83Contabilidad_centrocostowwds_21_tfcoscuedestino = AV18TFCOSCueDestino;
         AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel = AV19TFCOSCueDestino_Sel;
         AV85Contabilidad_centrocostowwds_23_tfcossts_sels = AV55TFCOSSts_Sels;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A762COSSts ,
                                              AV85Contabilidad_centrocostowwds_23_tfcossts_sels ,
                                              AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1 ,
                                              AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 ,
                                              AV65Contabilidad_centrocostowwds_3_cosdsc1 ,
                                              AV66Contabilidad_centrocostowwds_4_coscod1 ,
                                              AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 ,
                                              AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2 ,
                                              AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 ,
                                              AV70Contabilidad_centrocostowwds_8_cosdsc2 ,
                                              AV71Contabilidad_centrocostowwds_9_coscod2 ,
                                              AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 ,
                                              AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3 ,
                                              AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 ,
                                              AV75Contabilidad_centrocostowwds_13_cosdsc3 ,
                                              AV76Contabilidad_centrocostowwds_14_coscod3 ,
                                              AV78Contabilidad_centrocostowwds_16_tfcoscod_sel ,
                                              AV77Contabilidad_centrocostowwds_15_tfcoscod ,
                                              AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel ,
                                              AV79Contabilidad_centrocostowwds_17_tfcosdsc ,
                                              AV82Contabilidad_centrocostowwds_20_tfcosabr_sel ,
                                              AV81Contabilidad_centrocostowwds_19_tfcosabr ,
                                              AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel ,
                                              AV83Contabilidad_centrocostowwds_21_tfcoscuedestino ,
                                              AV85Contabilidad_centrocostowwds_23_tfcossts_sels.Count ,
                                              A761COSDsc ,
                                              A79COSCod ,
                                              A759COSAbr ,
                                              A80COSCueDestino } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV65Contabilidad_centrocostowwds_3_cosdsc1 = StringUtil.PadR( StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1), 100, "%");
         lV65Contabilidad_centrocostowwds_3_cosdsc1 = StringUtil.PadR( StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1), 100, "%");
         lV66Contabilidad_centrocostowwds_4_coscod1 = StringUtil.PadR( StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1), 10, "%");
         lV66Contabilidad_centrocostowwds_4_coscod1 = StringUtil.PadR( StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1), 10, "%");
         lV70Contabilidad_centrocostowwds_8_cosdsc2 = StringUtil.PadR( StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2), 100, "%");
         lV70Contabilidad_centrocostowwds_8_cosdsc2 = StringUtil.PadR( StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2), 100, "%");
         lV71Contabilidad_centrocostowwds_9_coscod2 = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2), 10, "%");
         lV71Contabilidad_centrocostowwds_9_coscod2 = StringUtil.PadR( StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2), 10, "%");
         lV75Contabilidad_centrocostowwds_13_cosdsc3 = StringUtil.PadR( StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3), 100, "%");
         lV75Contabilidad_centrocostowwds_13_cosdsc3 = StringUtil.PadR( StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3), 100, "%");
         lV76Contabilidad_centrocostowwds_14_coscod3 = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3), 10, "%");
         lV76Contabilidad_centrocostowwds_14_coscod3 = StringUtil.PadR( StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3), 10, "%");
         lV77Contabilidad_centrocostowwds_15_tfcoscod = StringUtil.PadR( StringUtil.RTrim( AV77Contabilidad_centrocostowwds_15_tfcoscod), 10, "%");
         lV79Contabilidad_centrocostowwds_17_tfcosdsc = StringUtil.PadR( StringUtil.RTrim( AV79Contabilidad_centrocostowwds_17_tfcosdsc), 100, "%");
         lV81Contabilidad_centrocostowwds_19_tfcosabr = StringUtil.PadR( StringUtil.RTrim( AV81Contabilidad_centrocostowwds_19_tfcosabr), 5, "%");
         lV83Contabilidad_centrocostowwds_21_tfcoscuedestino = StringUtil.PadR( StringUtil.RTrim( AV83Contabilidad_centrocostowwds_21_tfcoscuedestino), 15, "%");
         /* Using cursor P006R5 */
         pr_default.execute(3, new Object[] {lV65Contabilidad_centrocostowwds_3_cosdsc1, lV65Contabilidad_centrocostowwds_3_cosdsc1, lV66Contabilidad_centrocostowwds_4_coscod1, lV66Contabilidad_centrocostowwds_4_coscod1, lV70Contabilidad_centrocostowwds_8_cosdsc2, lV70Contabilidad_centrocostowwds_8_cosdsc2, lV71Contabilidad_centrocostowwds_9_coscod2, lV71Contabilidad_centrocostowwds_9_coscod2, lV75Contabilidad_centrocostowwds_13_cosdsc3, lV75Contabilidad_centrocostowwds_13_cosdsc3, lV76Contabilidad_centrocostowwds_14_coscod3, lV76Contabilidad_centrocostowwds_14_coscod3, lV77Contabilidad_centrocostowwds_15_tfcoscod, AV78Contabilidad_centrocostowwds_16_tfcoscod_sel, lV79Contabilidad_centrocostowwds_17_tfcosdsc, AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel, lV81Contabilidad_centrocostowwds_19_tfcosabr, AV82Contabilidad_centrocostowwds_20_tfcosabr_sel, lV83Contabilidad_centrocostowwds_21_tfcoscuedestino, AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK6R7 = false;
            A80COSCueDestino = P006R5_A80COSCueDestino[0];
            n80COSCueDestino = P006R5_n80COSCueDestino[0];
            A762COSSts = P006R5_A762COSSts[0];
            A759COSAbr = P006R5_A759COSAbr[0];
            A79COSCod = P006R5_A79COSCod[0];
            A761COSDsc = P006R5_A761COSDsc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P006R5_A80COSCueDestino[0], A80COSCueDestino) == 0 ) )
            {
               BRK6R7 = false;
               A79COSCod = P006R5_A79COSCod[0];
               AV34count = (long)(AV34count+1);
               BRK6R7 = true;
               pr_default.readNext(3);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A80COSCueDestino)) )
            {
               AV26Option = A80COSCueDestino;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK6R7 )
            {
               BRK6R7 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV10TFCOSCod = "";
         AV11TFCOSCod_Sel = "";
         AV12TFCOSDsc = "";
         AV13TFCOSDsc_Sel = "";
         AV14TFCOSAbr = "";
         AV15TFCOSAbr_Sel = "";
         AV18TFCOSCueDestino = "";
         AV19TFCOSCueDestino_Sel = "";
         AV54TFCOSSts_SelsJson = "";
         AV55TFCOSSts_Sels = new GxSimpleCollection<short>();
         AV39GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV42COSDsc1 = "";
         AV56COSCod1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV47COSDsc2 = "";
         AV57COSCod2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV52COSDsc3 = "";
         AV58COSCod3 = "";
         AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1 = "";
         AV65Contabilidad_centrocostowwds_3_cosdsc1 = "";
         AV66Contabilidad_centrocostowwds_4_coscod1 = "";
         AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2 = "";
         AV70Contabilidad_centrocostowwds_8_cosdsc2 = "";
         AV71Contabilidad_centrocostowwds_9_coscod2 = "";
         AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3 = "";
         AV75Contabilidad_centrocostowwds_13_cosdsc3 = "";
         AV76Contabilidad_centrocostowwds_14_coscod3 = "";
         AV77Contabilidad_centrocostowwds_15_tfcoscod = "";
         AV78Contabilidad_centrocostowwds_16_tfcoscod_sel = "";
         AV79Contabilidad_centrocostowwds_17_tfcosdsc = "";
         AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel = "";
         AV81Contabilidad_centrocostowwds_19_tfcosabr = "";
         AV82Contabilidad_centrocostowwds_20_tfcosabr_sel = "";
         AV83Contabilidad_centrocostowwds_21_tfcoscuedestino = "";
         AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel = "";
         AV85Contabilidad_centrocostowwds_23_tfcossts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV65Contabilidad_centrocostowwds_3_cosdsc1 = "";
         lV66Contabilidad_centrocostowwds_4_coscod1 = "";
         lV70Contabilidad_centrocostowwds_8_cosdsc2 = "";
         lV71Contabilidad_centrocostowwds_9_coscod2 = "";
         lV75Contabilidad_centrocostowwds_13_cosdsc3 = "";
         lV76Contabilidad_centrocostowwds_14_coscod3 = "";
         lV77Contabilidad_centrocostowwds_15_tfcoscod = "";
         lV79Contabilidad_centrocostowwds_17_tfcosdsc = "";
         lV81Contabilidad_centrocostowwds_19_tfcosabr = "";
         lV83Contabilidad_centrocostowwds_21_tfcoscuedestino = "";
         A761COSDsc = "";
         A79COSCod = "";
         A759COSAbr = "";
         A80COSCueDestino = "";
         P006R2_A762COSSts = new short[1] ;
         P006R2_A80COSCueDestino = new string[] {""} ;
         P006R2_n80COSCueDestino = new bool[] {false} ;
         P006R2_A759COSAbr = new string[] {""} ;
         P006R2_A79COSCod = new string[] {""} ;
         P006R2_A761COSDsc = new string[] {""} ;
         AV26Option = "";
         P006R3_A761COSDsc = new string[] {""} ;
         P006R3_A762COSSts = new short[1] ;
         P006R3_A80COSCueDestino = new string[] {""} ;
         P006R3_n80COSCueDestino = new bool[] {false} ;
         P006R3_A759COSAbr = new string[] {""} ;
         P006R3_A79COSCod = new string[] {""} ;
         P006R4_A759COSAbr = new string[] {""} ;
         P006R4_A762COSSts = new short[1] ;
         P006R4_A80COSCueDestino = new string[] {""} ;
         P006R4_n80COSCueDestino = new bool[] {false} ;
         P006R4_A79COSCod = new string[] {""} ;
         P006R4_A761COSDsc = new string[] {""} ;
         P006R5_A80COSCueDestino = new string[] {""} ;
         P006R5_n80COSCueDestino = new bool[] {false} ;
         P006R5_A762COSSts = new short[1] ;
         P006R5_A759COSAbr = new string[] {""} ;
         P006R5_A79COSCod = new string[] {""} ;
         P006R5_A761COSDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.centrocostowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006R2_A762COSSts, P006R2_A80COSCueDestino, P006R2_n80COSCueDestino, P006R2_A759COSAbr, P006R2_A79COSCod, P006R2_A761COSDsc
               }
               , new Object[] {
               P006R3_A761COSDsc, P006R3_A762COSSts, P006R3_A80COSCueDestino, P006R3_n80COSCueDestino, P006R3_A759COSAbr, P006R3_A79COSCod
               }
               , new Object[] {
               P006R4_A759COSAbr, P006R4_A762COSSts, P006R4_A80COSCueDestino, P006R4_n80COSCueDestino, P006R4_A79COSCod, P006R4_A761COSDsc
               }
               , new Object[] {
               P006R5_A80COSCueDestino, P006R5_n80COSCueDestino, P006R5_A762COSSts, P006R5_A759COSAbr, P006R5_A79COSCod, P006R5_A761COSDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV41DynamicFiltersOperator1 ;
      private short AV46DynamicFiltersOperator2 ;
      private short AV51DynamicFiltersOperator3 ;
      private short AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 ;
      private short AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 ;
      private short AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 ;
      private short A762COSSts ;
      private int AV61GXV1 ;
      private int AV85Contabilidad_centrocostowwds_23_tfcossts_sels_Count ;
      private long AV34count ;
      private string AV10TFCOSCod ;
      private string AV11TFCOSCod_Sel ;
      private string AV12TFCOSDsc ;
      private string AV13TFCOSDsc_Sel ;
      private string AV14TFCOSAbr ;
      private string AV15TFCOSAbr_Sel ;
      private string AV18TFCOSCueDestino ;
      private string AV19TFCOSCueDestino_Sel ;
      private string AV42COSDsc1 ;
      private string AV56COSCod1 ;
      private string AV47COSDsc2 ;
      private string AV57COSCod2 ;
      private string AV52COSDsc3 ;
      private string AV58COSCod3 ;
      private string AV65Contabilidad_centrocostowwds_3_cosdsc1 ;
      private string AV66Contabilidad_centrocostowwds_4_coscod1 ;
      private string AV70Contabilidad_centrocostowwds_8_cosdsc2 ;
      private string AV71Contabilidad_centrocostowwds_9_coscod2 ;
      private string AV75Contabilidad_centrocostowwds_13_cosdsc3 ;
      private string AV76Contabilidad_centrocostowwds_14_coscod3 ;
      private string AV77Contabilidad_centrocostowwds_15_tfcoscod ;
      private string AV78Contabilidad_centrocostowwds_16_tfcoscod_sel ;
      private string AV79Contabilidad_centrocostowwds_17_tfcosdsc ;
      private string AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel ;
      private string AV81Contabilidad_centrocostowwds_19_tfcosabr ;
      private string AV82Contabilidad_centrocostowwds_20_tfcosabr_sel ;
      private string AV83Contabilidad_centrocostowwds_21_tfcoscuedestino ;
      private string AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel ;
      private string scmdbuf ;
      private string lV65Contabilidad_centrocostowwds_3_cosdsc1 ;
      private string lV66Contabilidad_centrocostowwds_4_coscod1 ;
      private string lV70Contabilidad_centrocostowwds_8_cosdsc2 ;
      private string lV71Contabilidad_centrocostowwds_9_coscod2 ;
      private string lV75Contabilidad_centrocostowwds_13_cosdsc3 ;
      private string lV76Contabilidad_centrocostowwds_14_coscod3 ;
      private string lV77Contabilidad_centrocostowwds_15_tfcoscod ;
      private string lV79Contabilidad_centrocostowwds_17_tfcosdsc ;
      private string lV81Contabilidad_centrocostowwds_19_tfcosabr ;
      private string lV83Contabilidad_centrocostowwds_21_tfcoscuedestino ;
      private string A761COSDsc ;
      private string A79COSCod ;
      private string A759COSAbr ;
      private string A80COSCueDestino ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 ;
      private bool AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 ;
      private bool n80COSCueDestino ;
      private bool BRK6R3 ;
      private bool BRK6R5 ;
      private bool BRK6R7 ;
      private string AV28OptionsJson ;
      private string AV31OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV54TFCOSSts_SelsJson ;
      private string AV24DDOName ;
      private string AV22SearchTxt ;
      private string AV23SearchTxtTo ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1 ;
      private string AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2 ;
      private string AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3 ;
      private string AV26Option ;
      private GxSimpleCollection<short> AV55TFCOSSts_Sels ;
      private GxSimpleCollection<short> AV85Contabilidad_centrocostowwds_23_tfcossts_sels ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P006R2_A762COSSts ;
      private string[] P006R2_A80COSCueDestino ;
      private bool[] P006R2_n80COSCueDestino ;
      private string[] P006R2_A759COSAbr ;
      private string[] P006R2_A79COSCod ;
      private string[] P006R2_A761COSDsc ;
      private string[] P006R3_A761COSDsc ;
      private short[] P006R3_A762COSSts ;
      private string[] P006R3_A80COSCueDestino ;
      private bool[] P006R3_n80COSCueDestino ;
      private string[] P006R3_A759COSAbr ;
      private string[] P006R3_A79COSCod ;
      private string[] P006R4_A759COSAbr ;
      private short[] P006R4_A762COSSts ;
      private string[] P006R4_A80COSCueDestino ;
      private bool[] P006R4_n80COSCueDestino ;
      private string[] P006R4_A79COSCod ;
      private string[] P006R4_A761COSDsc ;
      private string[] P006R5_A80COSCueDestino ;
      private bool[] P006R5_n80COSCueDestino ;
      private short[] P006R5_A762COSSts ;
      private string[] P006R5_A759COSAbr ;
      private string[] P006R5_A79COSCod ;
      private string[] P006R5_A761COSDsc ;
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

   public class centrocostowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006R2( IGxContext context ,
                                             short A762COSSts ,
                                             GxSimpleCollection<short> AV85Contabilidad_centrocostowwds_23_tfcossts_sels ,
                                             string AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1 ,
                                             short AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 ,
                                             string AV65Contabilidad_centrocostowwds_3_cosdsc1 ,
                                             string AV66Contabilidad_centrocostowwds_4_coscod1 ,
                                             bool AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 ,
                                             string AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2 ,
                                             short AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 ,
                                             string AV70Contabilidad_centrocostowwds_8_cosdsc2 ,
                                             string AV71Contabilidad_centrocostowwds_9_coscod2 ,
                                             bool AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 ,
                                             string AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3 ,
                                             short AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 ,
                                             string AV75Contabilidad_centrocostowwds_13_cosdsc3 ,
                                             string AV76Contabilidad_centrocostowwds_14_coscod3 ,
                                             string AV78Contabilidad_centrocostowwds_16_tfcoscod_sel ,
                                             string AV77Contabilidad_centrocostowwds_15_tfcoscod ,
                                             string AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel ,
                                             string AV79Contabilidad_centrocostowwds_17_tfcosdsc ,
                                             string AV82Contabilidad_centrocostowwds_20_tfcosabr_sel ,
                                             string AV81Contabilidad_centrocostowwds_19_tfcosabr ,
                                             string AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel ,
                                             string AV83Contabilidad_centrocostowwds_21_tfcoscuedestino ,
                                             int AV85Contabilidad_centrocostowwds_23_tfcossts_sels_Count ,
                                             string A761COSDsc ,
                                             string A79COSCod ,
                                             string A759COSAbr ,
                                             string A80COSCueDestino )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [COSSts], NULL AS [COSCueDestino], NULL AS [COSAbr], [COSCod], NULL AS [COSDsc] FROM ( SELECT TOP(100) PERCENT [COSSts], [COSCueDestino], [COSAbr], [COSCod], [COSDsc] FROM [CBCOSTOS]";
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSDSC") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV65Contabilidad_centrocostowwds_3_cosdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSDSC") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV65Contabilidad_centrocostowwds_3_cosdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSCOD") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV66Contabilidad_centrocostowwds_4_coscod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSCOD") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV66Contabilidad_centrocostowwds_4_coscod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSDSC") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV70Contabilidad_centrocostowwds_8_cosdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSDSC") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV70Contabilidad_centrocostowwds_8_cosdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSCOD") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV71Contabilidad_centrocostowwds_9_coscod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSCOD") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV71Contabilidad_centrocostowwds_9_coscod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSDSC") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV75Contabilidad_centrocostowwds_13_cosdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSDSC") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV75Contabilidad_centrocostowwds_13_cosdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSCOD") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV76Contabilidad_centrocostowwds_14_coscod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSCOD") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV76Contabilidad_centrocostowwds_14_coscod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_centrocostowwds_16_tfcoscod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_centrocostowwds_15_tfcoscod)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV77Contabilidad_centrocostowwds_15_tfcoscod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_centrocostowwds_16_tfcoscod_sel)) )
         {
            AddWhere(sWhereString, "([COSCod] = @AV78Contabilidad_centrocostowwds_16_tfcoscod_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_centrocostowwds_17_tfcosdsc)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV79Contabilidad_centrocostowwds_17_tfcosdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel)) )
         {
            AddWhere(sWhereString, "([COSDsc] = @AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Contabilidad_centrocostowwds_20_tfcosabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_centrocostowwds_19_tfcosabr)) ) )
         {
            AddWhere(sWhereString, "([COSAbr] like @lV81Contabilidad_centrocostowwds_19_tfcosabr)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Contabilidad_centrocostowwds_20_tfcosabr_sel)) )
         {
            AddWhere(sWhereString, "([COSAbr] = @AV82Contabilidad_centrocostowwds_20_tfcosabr_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Contabilidad_centrocostowwds_21_tfcoscuedestino)) ) )
         {
            AddWhere(sWhereString, "([COSCueDestino] like @lV83Contabilidad_centrocostowwds_21_tfcoscuedestino)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)) )
         {
            AddWhere(sWhereString, "([COSCueDestino] = @AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV85Contabilidad_centrocostowwds_23_tfcossts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV85Contabilidad_centrocostowwds_23_tfcossts_sels, "[COSSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [COSCod]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [COSCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P006R3( IGxContext context ,
                                             short A762COSSts ,
                                             GxSimpleCollection<short> AV85Contabilidad_centrocostowwds_23_tfcossts_sels ,
                                             string AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1 ,
                                             short AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 ,
                                             string AV65Contabilidad_centrocostowwds_3_cosdsc1 ,
                                             string AV66Contabilidad_centrocostowwds_4_coscod1 ,
                                             bool AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 ,
                                             string AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2 ,
                                             short AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 ,
                                             string AV70Contabilidad_centrocostowwds_8_cosdsc2 ,
                                             string AV71Contabilidad_centrocostowwds_9_coscod2 ,
                                             bool AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 ,
                                             string AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3 ,
                                             short AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 ,
                                             string AV75Contabilidad_centrocostowwds_13_cosdsc3 ,
                                             string AV76Contabilidad_centrocostowwds_14_coscod3 ,
                                             string AV78Contabilidad_centrocostowwds_16_tfcoscod_sel ,
                                             string AV77Contabilidad_centrocostowwds_15_tfcoscod ,
                                             string AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel ,
                                             string AV79Contabilidad_centrocostowwds_17_tfcosdsc ,
                                             string AV82Contabilidad_centrocostowwds_20_tfcosabr_sel ,
                                             string AV81Contabilidad_centrocostowwds_19_tfcosabr ,
                                             string AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel ,
                                             string AV83Contabilidad_centrocostowwds_21_tfcoscuedestino ,
                                             int AV85Contabilidad_centrocostowwds_23_tfcossts_sels_Count ,
                                             string A761COSDsc ,
                                             string A79COSCod ,
                                             string A759COSAbr ,
                                             string A80COSCueDestino )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [COSDsc], [COSSts], [COSCueDestino], [COSAbr], [COSCod] FROM [CBCOSTOS]";
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSDSC") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV65Contabilidad_centrocostowwds_3_cosdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSDSC") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV65Contabilidad_centrocostowwds_3_cosdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSCOD") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV66Contabilidad_centrocostowwds_4_coscod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSCOD") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV66Contabilidad_centrocostowwds_4_coscod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSDSC") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV70Contabilidad_centrocostowwds_8_cosdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSDSC") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV70Contabilidad_centrocostowwds_8_cosdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSCOD") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV71Contabilidad_centrocostowwds_9_coscod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSCOD") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV71Contabilidad_centrocostowwds_9_coscod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSDSC") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV75Contabilidad_centrocostowwds_13_cosdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSDSC") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV75Contabilidad_centrocostowwds_13_cosdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSCOD") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV76Contabilidad_centrocostowwds_14_coscod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSCOD") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV76Contabilidad_centrocostowwds_14_coscod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_centrocostowwds_16_tfcoscod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_centrocostowwds_15_tfcoscod)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV77Contabilidad_centrocostowwds_15_tfcoscod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_centrocostowwds_16_tfcoscod_sel)) )
         {
            AddWhere(sWhereString, "([COSCod] = @AV78Contabilidad_centrocostowwds_16_tfcoscod_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_centrocostowwds_17_tfcosdsc)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV79Contabilidad_centrocostowwds_17_tfcosdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel)) )
         {
            AddWhere(sWhereString, "([COSDsc] = @AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Contabilidad_centrocostowwds_20_tfcosabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_centrocostowwds_19_tfcosabr)) ) )
         {
            AddWhere(sWhereString, "([COSAbr] like @lV81Contabilidad_centrocostowwds_19_tfcosabr)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Contabilidad_centrocostowwds_20_tfcosabr_sel)) )
         {
            AddWhere(sWhereString, "([COSAbr] = @AV82Contabilidad_centrocostowwds_20_tfcosabr_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Contabilidad_centrocostowwds_21_tfcoscuedestino)) ) )
         {
            AddWhere(sWhereString, "([COSCueDestino] like @lV83Contabilidad_centrocostowwds_21_tfcoscuedestino)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)) )
         {
            AddWhere(sWhereString, "([COSCueDestino] = @AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( AV85Contabilidad_centrocostowwds_23_tfcossts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV85Contabilidad_centrocostowwds_23_tfcossts_sels, "[COSSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [COSDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P006R4( IGxContext context ,
                                             short A762COSSts ,
                                             GxSimpleCollection<short> AV85Contabilidad_centrocostowwds_23_tfcossts_sels ,
                                             string AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1 ,
                                             short AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 ,
                                             string AV65Contabilidad_centrocostowwds_3_cosdsc1 ,
                                             string AV66Contabilidad_centrocostowwds_4_coscod1 ,
                                             bool AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 ,
                                             string AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2 ,
                                             short AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 ,
                                             string AV70Contabilidad_centrocostowwds_8_cosdsc2 ,
                                             string AV71Contabilidad_centrocostowwds_9_coscod2 ,
                                             bool AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 ,
                                             string AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3 ,
                                             short AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 ,
                                             string AV75Contabilidad_centrocostowwds_13_cosdsc3 ,
                                             string AV76Contabilidad_centrocostowwds_14_coscod3 ,
                                             string AV78Contabilidad_centrocostowwds_16_tfcoscod_sel ,
                                             string AV77Contabilidad_centrocostowwds_15_tfcoscod ,
                                             string AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel ,
                                             string AV79Contabilidad_centrocostowwds_17_tfcosdsc ,
                                             string AV82Contabilidad_centrocostowwds_20_tfcosabr_sel ,
                                             string AV81Contabilidad_centrocostowwds_19_tfcosabr ,
                                             string AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel ,
                                             string AV83Contabilidad_centrocostowwds_21_tfcoscuedestino ,
                                             int AV85Contabilidad_centrocostowwds_23_tfcossts_sels_Count ,
                                             string A761COSDsc ,
                                             string A79COSCod ,
                                             string A759COSAbr ,
                                             string A80COSCueDestino )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [COSAbr], [COSSts], [COSCueDestino], [COSCod], [COSDsc] FROM [CBCOSTOS]";
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSDSC") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV65Contabilidad_centrocostowwds_3_cosdsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSDSC") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV65Contabilidad_centrocostowwds_3_cosdsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSCOD") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV66Contabilidad_centrocostowwds_4_coscod1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSCOD") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV66Contabilidad_centrocostowwds_4_coscod1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSDSC") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV70Contabilidad_centrocostowwds_8_cosdsc2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSDSC") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV70Contabilidad_centrocostowwds_8_cosdsc2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSCOD") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV71Contabilidad_centrocostowwds_9_coscod2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSCOD") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV71Contabilidad_centrocostowwds_9_coscod2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSDSC") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV75Contabilidad_centrocostowwds_13_cosdsc3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSDSC") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV75Contabilidad_centrocostowwds_13_cosdsc3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSCOD") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV76Contabilidad_centrocostowwds_14_coscod3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSCOD") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV76Contabilidad_centrocostowwds_14_coscod3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_centrocostowwds_16_tfcoscod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_centrocostowwds_15_tfcoscod)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV77Contabilidad_centrocostowwds_15_tfcoscod)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_centrocostowwds_16_tfcoscod_sel)) )
         {
            AddWhere(sWhereString, "([COSCod] = @AV78Contabilidad_centrocostowwds_16_tfcoscod_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_centrocostowwds_17_tfcosdsc)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV79Contabilidad_centrocostowwds_17_tfcosdsc)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel)) )
         {
            AddWhere(sWhereString, "([COSDsc] = @AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Contabilidad_centrocostowwds_20_tfcosabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_centrocostowwds_19_tfcosabr)) ) )
         {
            AddWhere(sWhereString, "([COSAbr] like @lV81Contabilidad_centrocostowwds_19_tfcosabr)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Contabilidad_centrocostowwds_20_tfcosabr_sel)) )
         {
            AddWhere(sWhereString, "([COSAbr] = @AV82Contabilidad_centrocostowwds_20_tfcosabr_sel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Contabilidad_centrocostowwds_21_tfcoscuedestino)) ) )
         {
            AddWhere(sWhereString, "([COSCueDestino] like @lV83Contabilidad_centrocostowwds_21_tfcoscuedestino)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)) )
         {
            AddWhere(sWhereString, "([COSCueDestino] = @AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( AV85Contabilidad_centrocostowwds_23_tfcossts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV85Contabilidad_centrocostowwds_23_tfcossts_sels, "[COSSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [COSAbr]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P006R5( IGxContext context ,
                                             short A762COSSts ,
                                             GxSimpleCollection<short> AV85Contabilidad_centrocostowwds_23_tfcossts_sels ,
                                             string AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1 ,
                                             short AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 ,
                                             string AV65Contabilidad_centrocostowwds_3_cosdsc1 ,
                                             string AV66Contabilidad_centrocostowwds_4_coscod1 ,
                                             bool AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 ,
                                             string AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2 ,
                                             short AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 ,
                                             string AV70Contabilidad_centrocostowwds_8_cosdsc2 ,
                                             string AV71Contabilidad_centrocostowwds_9_coscod2 ,
                                             bool AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 ,
                                             string AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3 ,
                                             short AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 ,
                                             string AV75Contabilidad_centrocostowwds_13_cosdsc3 ,
                                             string AV76Contabilidad_centrocostowwds_14_coscod3 ,
                                             string AV78Contabilidad_centrocostowwds_16_tfcoscod_sel ,
                                             string AV77Contabilidad_centrocostowwds_15_tfcoscod ,
                                             string AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel ,
                                             string AV79Contabilidad_centrocostowwds_17_tfcosdsc ,
                                             string AV82Contabilidad_centrocostowwds_20_tfcosabr_sel ,
                                             string AV81Contabilidad_centrocostowwds_19_tfcosabr ,
                                             string AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel ,
                                             string AV83Contabilidad_centrocostowwds_21_tfcoscuedestino ,
                                             int AV85Contabilidad_centrocostowwds_23_tfcossts_sels_Count ,
                                             string A761COSDsc ,
                                             string A79COSCod ,
                                             string A759COSAbr ,
                                             string A80COSCueDestino )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[20];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT [COSCueDestino], [COSSts], [COSAbr], [COSCod], [COSDsc] FROM [CBCOSTOS]";
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSDSC") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV65Contabilidad_centrocostowwds_3_cosdsc1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSDSC") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_centrocostowwds_3_cosdsc1)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV65Contabilidad_centrocostowwds_3_cosdsc1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSCOD") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV66Contabilidad_centrocostowwds_4_coscod1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Contabilidad_centrocostowwds_1_dynamicfiltersselector1, "COSCOD") == 0 ) && ( AV64Contabilidad_centrocostowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_centrocostowwds_4_coscod1)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV66Contabilidad_centrocostowwds_4_coscod1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSDSC") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV70Contabilidad_centrocostowwds_8_cosdsc2)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSDSC") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Contabilidad_centrocostowwds_8_cosdsc2)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV70Contabilidad_centrocostowwds_8_cosdsc2)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSCOD") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV71Contabilidad_centrocostowwds_9_coscod2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV67Contabilidad_centrocostowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_centrocostowwds_6_dynamicfiltersselector2, "COSCOD") == 0 ) && ( AV69Contabilidad_centrocostowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Contabilidad_centrocostowwds_9_coscod2)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV71Contabilidad_centrocostowwds_9_coscod2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSDSC") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV75Contabilidad_centrocostowwds_13_cosdsc3)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSDSC") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_centrocostowwds_13_cosdsc3)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like '%' + @lV75Contabilidad_centrocostowwds_13_cosdsc3)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSCOD") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV76Contabilidad_centrocostowwds_14_coscod3)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV72Contabilidad_centrocostowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Contabilidad_centrocostowwds_11_dynamicfiltersselector3, "COSCOD") == 0 ) && ( AV74Contabilidad_centrocostowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Contabilidad_centrocostowwds_14_coscod3)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like '%' + @lV76Contabilidad_centrocostowwds_14_coscod3)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_centrocostowwds_16_tfcoscod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Contabilidad_centrocostowwds_15_tfcoscod)) ) )
         {
            AddWhere(sWhereString, "([COSCod] like @lV77Contabilidad_centrocostowwds_15_tfcoscod)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_centrocostowwds_16_tfcoscod_sel)) )
         {
            AddWhere(sWhereString, "([COSCod] = @AV78Contabilidad_centrocostowwds_16_tfcoscod_sel)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_centrocostowwds_17_tfcosdsc)) ) )
         {
            AddWhere(sWhereString, "([COSDsc] like @lV79Contabilidad_centrocostowwds_17_tfcosdsc)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel)) )
         {
            AddWhere(sWhereString, "([COSDsc] = @AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Contabilidad_centrocostowwds_20_tfcosabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_centrocostowwds_19_tfcosabr)) ) )
         {
            AddWhere(sWhereString, "([COSAbr] like @lV81Contabilidad_centrocostowwds_19_tfcosabr)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Contabilidad_centrocostowwds_20_tfcosabr_sel)) )
         {
            AddWhere(sWhereString, "([COSAbr] = @AV82Contabilidad_centrocostowwds_20_tfcosabr_sel)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Contabilidad_centrocostowwds_21_tfcoscuedestino)) ) )
         {
            AddWhere(sWhereString, "([COSCueDestino] like @lV83Contabilidad_centrocostowwds_21_tfcoscuedestino)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)) )
         {
            AddWhere(sWhereString, "([COSCueDestino] = @AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( AV85Contabilidad_centrocostowwds_23_tfcossts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV85Contabilidad_centrocostowwds_23_tfcossts_sels, "[COSSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [COSCueDestino]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006R2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] );
               case 1 :
                     return conditional_P006R3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] );
               case 2 :
                     return conditional_P006R4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] );
               case 3 :
                     return conditional_P006R5(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] );
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
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006R2;
          prmP006R2 = new Object[] {
          new ParDef("@lV65Contabilidad_centrocostowwds_3_cosdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV65Contabilidad_centrocostowwds_3_cosdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV66Contabilidad_centrocostowwds_4_coscod1",GXType.NChar,10,0) ,
          new ParDef("@lV66Contabilidad_centrocostowwds_4_coscod1",GXType.NChar,10,0) ,
          new ParDef("@lV70Contabilidad_centrocostowwds_8_cosdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV70Contabilidad_centrocostowwds_8_cosdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV71Contabilidad_centrocostowwds_9_coscod2",GXType.NChar,10,0) ,
          new ParDef("@lV71Contabilidad_centrocostowwds_9_coscod2",GXType.NChar,10,0) ,
          new ParDef("@lV75Contabilidad_centrocostowwds_13_cosdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV75Contabilidad_centrocostowwds_13_cosdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV76Contabilidad_centrocostowwds_14_coscod3",GXType.NChar,10,0) ,
          new ParDef("@lV76Contabilidad_centrocostowwds_14_coscod3",GXType.NChar,10,0) ,
          new ParDef("@lV77Contabilidad_centrocostowwds_15_tfcoscod",GXType.NChar,10,0) ,
          new ParDef("@AV78Contabilidad_centrocostowwds_16_tfcoscod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV79Contabilidad_centrocostowwds_17_tfcosdsc",GXType.NChar,100,0) ,
          new ParDef("@AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV81Contabilidad_centrocostowwds_19_tfcosabr",GXType.NChar,5,0) ,
          new ParDef("@AV82Contabilidad_centrocostowwds_20_tfcosabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV83Contabilidad_centrocostowwds_21_tfcoscuedestino",GXType.NChar,15,0) ,
          new ParDef("@AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel",GXType.NChar,15,0)
          };
          Object[] prmP006R3;
          prmP006R3 = new Object[] {
          new ParDef("@lV65Contabilidad_centrocostowwds_3_cosdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV65Contabilidad_centrocostowwds_3_cosdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV66Contabilidad_centrocostowwds_4_coscod1",GXType.NChar,10,0) ,
          new ParDef("@lV66Contabilidad_centrocostowwds_4_coscod1",GXType.NChar,10,0) ,
          new ParDef("@lV70Contabilidad_centrocostowwds_8_cosdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV70Contabilidad_centrocostowwds_8_cosdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV71Contabilidad_centrocostowwds_9_coscod2",GXType.NChar,10,0) ,
          new ParDef("@lV71Contabilidad_centrocostowwds_9_coscod2",GXType.NChar,10,0) ,
          new ParDef("@lV75Contabilidad_centrocostowwds_13_cosdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV75Contabilidad_centrocostowwds_13_cosdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV76Contabilidad_centrocostowwds_14_coscod3",GXType.NChar,10,0) ,
          new ParDef("@lV76Contabilidad_centrocostowwds_14_coscod3",GXType.NChar,10,0) ,
          new ParDef("@lV77Contabilidad_centrocostowwds_15_tfcoscod",GXType.NChar,10,0) ,
          new ParDef("@AV78Contabilidad_centrocostowwds_16_tfcoscod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV79Contabilidad_centrocostowwds_17_tfcosdsc",GXType.NChar,100,0) ,
          new ParDef("@AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV81Contabilidad_centrocostowwds_19_tfcosabr",GXType.NChar,5,0) ,
          new ParDef("@AV82Contabilidad_centrocostowwds_20_tfcosabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV83Contabilidad_centrocostowwds_21_tfcoscuedestino",GXType.NChar,15,0) ,
          new ParDef("@AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel",GXType.NChar,15,0)
          };
          Object[] prmP006R4;
          prmP006R4 = new Object[] {
          new ParDef("@lV65Contabilidad_centrocostowwds_3_cosdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV65Contabilidad_centrocostowwds_3_cosdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV66Contabilidad_centrocostowwds_4_coscod1",GXType.NChar,10,0) ,
          new ParDef("@lV66Contabilidad_centrocostowwds_4_coscod1",GXType.NChar,10,0) ,
          new ParDef("@lV70Contabilidad_centrocostowwds_8_cosdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV70Contabilidad_centrocostowwds_8_cosdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV71Contabilidad_centrocostowwds_9_coscod2",GXType.NChar,10,0) ,
          new ParDef("@lV71Contabilidad_centrocostowwds_9_coscod2",GXType.NChar,10,0) ,
          new ParDef("@lV75Contabilidad_centrocostowwds_13_cosdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV75Contabilidad_centrocostowwds_13_cosdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV76Contabilidad_centrocostowwds_14_coscod3",GXType.NChar,10,0) ,
          new ParDef("@lV76Contabilidad_centrocostowwds_14_coscod3",GXType.NChar,10,0) ,
          new ParDef("@lV77Contabilidad_centrocostowwds_15_tfcoscod",GXType.NChar,10,0) ,
          new ParDef("@AV78Contabilidad_centrocostowwds_16_tfcoscod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV79Contabilidad_centrocostowwds_17_tfcosdsc",GXType.NChar,100,0) ,
          new ParDef("@AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV81Contabilidad_centrocostowwds_19_tfcosabr",GXType.NChar,5,0) ,
          new ParDef("@AV82Contabilidad_centrocostowwds_20_tfcosabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV83Contabilidad_centrocostowwds_21_tfcoscuedestino",GXType.NChar,15,0) ,
          new ParDef("@AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel",GXType.NChar,15,0)
          };
          Object[] prmP006R5;
          prmP006R5 = new Object[] {
          new ParDef("@lV65Contabilidad_centrocostowwds_3_cosdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV65Contabilidad_centrocostowwds_3_cosdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV66Contabilidad_centrocostowwds_4_coscod1",GXType.NChar,10,0) ,
          new ParDef("@lV66Contabilidad_centrocostowwds_4_coscod1",GXType.NChar,10,0) ,
          new ParDef("@lV70Contabilidad_centrocostowwds_8_cosdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV70Contabilidad_centrocostowwds_8_cosdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV71Contabilidad_centrocostowwds_9_coscod2",GXType.NChar,10,0) ,
          new ParDef("@lV71Contabilidad_centrocostowwds_9_coscod2",GXType.NChar,10,0) ,
          new ParDef("@lV75Contabilidad_centrocostowwds_13_cosdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV75Contabilidad_centrocostowwds_13_cosdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV76Contabilidad_centrocostowwds_14_coscod3",GXType.NChar,10,0) ,
          new ParDef("@lV76Contabilidad_centrocostowwds_14_coscod3",GXType.NChar,10,0) ,
          new ParDef("@lV77Contabilidad_centrocostowwds_15_tfcoscod",GXType.NChar,10,0) ,
          new ParDef("@AV78Contabilidad_centrocostowwds_16_tfcoscod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV79Contabilidad_centrocostowwds_17_tfcosdsc",GXType.NChar,100,0) ,
          new ParDef("@AV80Contabilidad_centrocostowwds_18_tfcosdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV81Contabilidad_centrocostowwds_19_tfcosabr",GXType.NChar,5,0) ,
          new ParDef("@AV82Contabilidad_centrocostowwds_20_tfcosabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV83Contabilidad_centrocostowwds_21_tfcoscuedestino",GXType.NChar,15,0) ,
          new ParDef("@AV84Contabilidad_centrocostowwds_22_tfcoscuedestino_sel",GXType.NChar,15,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P006R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006R4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006R5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006R5,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 5);
                ((string[]) buf[4])[0] = rslt.getString(4, 10);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 5);
                ((string[]) buf[5])[0] = rslt.getString(5, 10);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 15);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 10);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 5);
                ((string[]) buf[4])[0] = rslt.getString(4, 10);
                ((string[]) buf[5])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
