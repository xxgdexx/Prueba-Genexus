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
   public class movimientoalmacenwwgetfilterdata : GXProcedure
   {
      public movimientoalmacenwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public movimientoalmacenwwgetfilterdata( IGxContext context )
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
         movimientoalmacenwwgetfilterdata objmovimientoalmacenwwgetfilterdata;
         objmovimientoalmacenwwgetfilterdata = new movimientoalmacenwwgetfilterdata();
         objmovimientoalmacenwwgetfilterdata.AV24DDOName = aP0_DDOName;
         objmovimientoalmacenwwgetfilterdata.AV22SearchTxt = aP1_SearchTxt;
         objmovimientoalmacenwwgetfilterdata.AV23SearchTxtTo = aP2_SearchTxtTo;
         objmovimientoalmacenwwgetfilterdata.AV28OptionsJson = "" ;
         objmovimientoalmacenwwgetfilterdata.AV31OptionsDescJson = "" ;
         objmovimientoalmacenwwgetfilterdata.AV33OptionIndexesJson = "" ;
         objmovimientoalmacenwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objmovimientoalmacenwwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmovimientoalmacenwwgetfilterdata);
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((movimientoalmacenwwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_MOVDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADMOVDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_MOVABR") == 0 )
         {
            /* Execute user subroutine: 'LOADMOVABROPTIONS' */
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
         if ( StringUtil.StrCmp(AV35Session.Get("Configuracion.MovimientoAlmacenWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.MovimientoAlmacenWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("Configuracion.MovimientoAlmacenWWGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMOVCOD") == 0 )
            {
               AV10TFMovCod = (int)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."));
               AV11TFMovCod_To = (int)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMOVDSC") == 0 )
            {
               AV12TFMovDsc = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMOVDSC_SEL") == 0 )
            {
               AV13TFMovDsc_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMOVABR") == 0 )
            {
               AV14TFMovAbr = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMOVABR_SEL") == 0 )
            {
               AV15TFMovAbr_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMOVTIP_SEL") == 0 )
            {
               AV16TFMovTip_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV17TFMovTip_Sels.FromJSonString(AV16TFMovTip_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFMOVSTS_SEL") == 0 )
            {
               AV18TFMovSts_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV19TFMovSts_Sels.FromJSonString(AV18TFMovSts_SelsJson, null);
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV39GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "MOVDSC") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV42MovDsc1 = AV39GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "MOVTIP") == 0 )
            {
               AV43MovTip1 = (short)(NumberUtil.Val( AV39GridStateDynamicFilter.gxTpr_Value, "."));
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV39GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "MOVDSC") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV47MovDsc2 = AV39GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "MOVTIP") == 0 )
               {
                  AV48MovTip2 = (short)(NumberUtil.Val( AV39GridStateDynamicFilter.gxTpr_Value, "."));
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV39GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "MOVDSC") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV52MovDsc3 = AV39GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "MOVTIP") == 0 )
                  {
                     AV53MovTip3 = (short)(NumberUtil.Val( AV39GridStateDynamicFilter.gxTpr_Value, "."));
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADMOVDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFMovDsc = AV22SearchTxt;
         AV13TFMovDsc_Sel = "";
         AV58Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV59Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV60Configuracion_movimientoalmacenwwds_3_movdsc1 = AV42MovDsc1;
         AV61Configuracion_movimientoalmacenwwds_4_movtip1 = AV43MovTip1;
         AV62Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV63Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV64Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV65Configuracion_movimientoalmacenwwds_8_movdsc2 = AV47MovDsc2;
         AV66Configuracion_movimientoalmacenwwds_9_movtip2 = AV48MovTip2;
         AV67Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV68Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV69Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV70Configuracion_movimientoalmacenwwds_13_movdsc3 = AV52MovDsc3;
         AV71Configuracion_movimientoalmacenwwds_14_movtip3 = AV53MovTip3;
         AV72Configuracion_movimientoalmacenwwds_15_tfmovcod = AV10TFMovCod;
         AV73Configuracion_movimientoalmacenwwds_16_tfmovcod_to = AV11TFMovCod_To;
         AV74Configuracion_movimientoalmacenwwds_17_tfmovdsc = AV12TFMovDsc;
         AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel = AV13TFMovDsc_Sel;
         AV76Configuracion_movimientoalmacenwwds_19_tfmovabr = AV14TFMovAbr;
         AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel = AV15TFMovAbr_Sel;
         AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels = AV17TFMovTip_Sels;
         AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels = AV19TFMovSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1241MovTip ,
                                              AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels ,
                                              A1240MovSts ,
                                              AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels ,
                                              AV58Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 ,
                                              AV59Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 ,
                                              AV60Configuracion_movimientoalmacenwwds_3_movdsc1 ,
                                              AV61Configuracion_movimientoalmacenwwds_4_movtip1 ,
                                              AV62Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 ,
                                              AV63Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 ,
                                              AV64Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 ,
                                              AV65Configuracion_movimientoalmacenwwds_8_movdsc2 ,
                                              AV66Configuracion_movimientoalmacenwwds_9_movtip2 ,
                                              AV67Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 ,
                                              AV68Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 ,
                                              AV69Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 ,
                                              AV70Configuracion_movimientoalmacenwwds_13_movdsc3 ,
                                              AV71Configuracion_movimientoalmacenwwds_14_movtip3 ,
                                              AV72Configuracion_movimientoalmacenwwds_15_tfmovcod ,
                                              AV73Configuracion_movimientoalmacenwwds_16_tfmovcod_to ,
                                              AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel ,
                                              AV74Configuracion_movimientoalmacenwwds_17_tfmovdsc ,
                                              AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel ,
                                              AV76Configuracion_movimientoalmacenwwds_19_tfmovabr ,
                                              AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels.Count ,
                                              AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels.Count ,
                                              A1239MovDsc ,
                                              A234MovCod ,
                                              A1237MovAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV60Configuracion_movimientoalmacenwwds_3_movdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_movimientoalmacenwwds_3_movdsc1), 100, "%");
         lV60Configuracion_movimientoalmacenwwds_3_movdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_movimientoalmacenwwds_3_movdsc1), 100, "%");
         lV65Configuracion_movimientoalmacenwwds_8_movdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_movimientoalmacenwwds_8_movdsc2), 100, "%");
         lV65Configuracion_movimientoalmacenwwds_8_movdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_movimientoalmacenwwds_8_movdsc2), 100, "%");
         lV70Configuracion_movimientoalmacenwwds_13_movdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_movimientoalmacenwwds_13_movdsc3), 100, "%");
         lV70Configuracion_movimientoalmacenwwds_13_movdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_movimientoalmacenwwds_13_movdsc3), 100, "%");
         lV74Configuracion_movimientoalmacenwwds_17_tfmovdsc = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_movimientoalmacenwwds_17_tfmovdsc), 100, "%");
         lV76Configuracion_movimientoalmacenwwds_19_tfmovabr = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_movimientoalmacenwwds_19_tfmovabr), 5, "%");
         /* Using cursor P003B2 */
         pr_default.execute(0, new Object[] {lV60Configuracion_movimientoalmacenwwds_3_movdsc1, lV60Configuracion_movimientoalmacenwwds_3_movdsc1, AV61Configuracion_movimientoalmacenwwds_4_movtip1, lV65Configuracion_movimientoalmacenwwds_8_movdsc2, lV65Configuracion_movimientoalmacenwwds_8_movdsc2, AV66Configuracion_movimientoalmacenwwds_9_movtip2, lV70Configuracion_movimientoalmacenwwds_13_movdsc3, lV70Configuracion_movimientoalmacenwwds_13_movdsc3, AV71Configuracion_movimientoalmacenwwds_14_movtip3, AV72Configuracion_movimientoalmacenwwds_15_tfmovcod, AV73Configuracion_movimientoalmacenwwds_16_tfmovcod_to, lV74Configuracion_movimientoalmacenwwds_17_tfmovdsc, AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel, lV76Configuracion_movimientoalmacenwwds_19_tfmovabr, AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3B2 = false;
            A1239MovDsc = P003B2_A1239MovDsc[0];
            A1240MovSts = P003B2_A1240MovSts[0];
            A1237MovAbr = P003B2_A1237MovAbr[0];
            A234MovCod = P003B2_A234MovCod[0];
            A1241MovTip = P003B2_A1241MovTip[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P003B2_A1239MovDsc[0], A1239MovDsc) == 0 ) )
            {
               BRK3B2 = false;
               A234MovCod = P003B2_A234MovCod[0];
               AV34count = (long)(AV34count+1);
               BRK3B2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1239MovDsc)) )
            {
               AV26Option = A1239MovDsc;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK3B2 )
            {
               BRK3B2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMOVABROPTIONS' Routine */
         returnInSub = false;
         AV14TFMovAbr = AV22SearchTxt;
         AV15TFMovAbr_Sel = "";
         AV58Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV59Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV60Configuracion_movimientoalmacenwwds_3_movdsc1 = AV42MovDsc1;
         AV61Configuracion_movimientoalmacenwwds_4_movtip1 = AV43MovTip1;
         AV62Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV63Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV64Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV65Configuracion_movimientoalmacenwwds_8_movdsc2 = AV47MovDsc2;
         AV66Configuracion_movimientoalmacenwwds_9_movtip2 = AV48MovTip2;
         AV67Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV68Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV69Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV70Configuracion_movimientoalmacenwwds_13_movdsc3 = AV52MovDsc3;
         AV71Configuracion_movimientoalmacenwwds_14_movtip3 = AV53MovTip3;
         AV72Configuracion_movimientoalmacenwwds_15_tfmovcod = AV10TFMovCod;
         AV73Configuracion_movimientoalmacenwwds_16_tfmovcod_to = AV11TFMovCod_To;
         AV74Configuracion_movimientoalmacenwwds_17_tfmovdsc = AV12TFMovDsc;
         AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel = AV13TFMovDsc_Sel;
         AV76Configuracion_movimientoalmacenwwds_19_tfmovabr = AV14TFMovAbr;
         AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel = AV15TFMovAbr_Sel;
         AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels = AV17TFMovTip_Sels;
         AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels = AV19TFMovSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1241MovTip ,
                                              AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels ,
                                              A1240MovSts ,
                                              AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels ,
                                              AV58Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 ,
                                              AV59Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 ,
                                              AV60Configuracion_movimientoalmacenwwds_3_movdsc1 ,
                                              AV61Configuracion_movimientoalmacenwwds_4_movtip1 ,
                                              AV62Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 ,
                                              AV63Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 ,
                                              AV64Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 ,
                                              AV65Configuracion_movimientoalmacenwwds_8_movdsc2 ,
                                              AV66Configuracion_movimientoalmacenwwds_9_movtip2 ,
                                              AV67Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 ,
                                              AV68Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 ,
                                              AV69Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 ,
                                              AV70Configuracion_movimientoalmacenwwds_13_movdsc3 ,
                                              AV71Configuracion_movimientoalmacenwwds_14_movtip3 ,
                                              AV72Configuracion_movimientoalmacenwwds_15_tfmovcod ,
                                              AV73Configuracion_movimientoalmacenwwds_16_tfmovcod_to ,
                                              AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel ,
                                              AV74Configuracion_movimientoalmacenwwds_17_tfmovdsc ,
                                              AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel ,
                                              AV76Configuracion_movimientoalmacenwwds_19_tfmovabr ,
                                              AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels.Count ,
                                              AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels.Count ,
                                              A1239MovDsc ,
                                              A234MovCod ,
                                              A1237MovAbr } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV60Configuracion_movimientoalmacenwwds_3_movdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_movimientoalmacenwwds_3_movdsc1), 100, "%");
         lV60Configuracion_movimientoalmacenwwds_3_movdsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_movimientoalmacenwwds_3_movdsc1), 100, "%");
         lV65Configuracion_movimientoalmacenwwds_8_movdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_movimientoalmacenwwds_8_movdsc2), 100, "%");
         lV65Configuracion_movimientoalmacenwwds_8_movdsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_movimientoalmacenwwds_8_movdsc2), 100, "%");
         lV70Configuracion_movimientoalmacenwwds_13_movdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_movimientoalmacenwwds_13_movdsc3), 100, "%");
         lV70Configuracion_movimientoalmacenwwds_13_movdsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_movimientoalmacenwwds_13_movdsc3), 100, "%");
         lV74Configuracion_movimientoalmacenwwds_17_tfmovdsc = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_movimientoalmacenwwds_17_tfmovdsc), 100, "%");
         lV76Configuracion_movimientoalmacenwwds_19_tfmovabr = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_movimientoalmacenwwds_19_tfmovabr), 5, "%");
         /* Using cursor P003B3 */
         pr_default.execute(1, new Object[] {lV60Configuracion_movimientoalmacenwwds_3_movdsc1, lV60Configuracion_movimientoalmacenwwds_3_movdsc1, AV61Configuracion_movimientoalmacenwwds_4_movtip1, lV65Configuracion_movimientoalmacenwwds_8_movdsc2, lV65Configuracion_movimientoalmacenwwds_8_movdsc2, AV66Configuracion_movimientoalmacenwwds_9_movtip2, lV70Configuracion_movimientoalmacenwwds_13_movdsc3, lV70Configuracion_movimientoalmacenwwds_13_movdsc3, AV71Configuracion_movimientoalmacenwwds_14_movtip3, AV72Configuracion_movimientoalmacenwwds_15_tfmovcod, AV73Configuracion_movimientoalmacenwwds_16_tfmovcod_to, lV74Configuracion_movimientoalmacenwwds_17_tfmovdsc, AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel, lV76Configuracion_movimientoalmacenwwds_19_tfmovabr, AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK3B4 = false;
            A1237MovAbr = P003B3_A1237MovAbr[0];
            A1240MovSts = P003B3_A1240MovSts[0];
            A234MovCod = P003B3_A234MovCod[0];
            A1241MovTip = P003B3_A1241MovTip[0];
            A1239MovDsc = P003B3_A1239MovDsc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P003B3_A1237MovAbr[0], A1237MovAbr) == 0 ) )
            {
               BRK3B4 = false;
               A234MovCod = P003B3_A234MovCod[0];
               AV34count = (long)(AV34count+1);
               BRK3B4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1237MovAbr)) )
            {
               AV26Option = A1237MovAbr;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK3B4 )
            {
               BRK3B4 = true;
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
         AV12TFMovDsc = "";
         AV13TFMovDsc_Sel = "";
         AV14TFMovAbr = "";
         AV15TFMovAbr_Sel = "";
         AV16TFMovTip_SelsJson = "";
         AV17TFMovTip_Sels = new GxSimpleCollection<short>();
         AV18TFMovSts_SelsJson = "";
         AV19TFMovSts_Sels = new GxSimpleCollection<short>();
         AV39GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV42MovDsc1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV47MovDsc2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV52MovDsc3 = "";
         AV58Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 = "";
         AV60Configuracion_movimientoalmacenwwds_3_movdsc1 = "";
         AV63Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 = "";
         AV65Configuracion_movimientoalmacenwwds_8_movdsc2 = "";
         AV68Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 = "";
         AV70Configuracion_movimientoalmacenwwds_13_movdsc3 = "";
         AV74Configuracion_movimientoalmacenwwds_17_tfmovdsc = "";
         AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel = "";
         AV76Configuracion_movimientoalmacenwwds_19_tfmovabr = "";
         AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel = "";
         AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels = new GxSimpleCollection<short>();
         AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV60Configuracion_movimientoalmacenwwds_3_movdsc1 = "";
         lV65Configuracion_movimientoalmacenwwds_8_movdsc2 = "";
         lV70Configuracion_movimientoalmacenwwds_13_movdsc3 = "";
         lV74Configuracion_movimientoalmacenwwds_17_tfmovdsc = "";
         lV76Configuracion_movimientoalmacenwwds_19_tfmovabr = "";
         A1239MovDsc = "";
         A1237MovAbr = "";
         P003B2_A1239MovDsc = new string[] {""} ;
         P003B2_A1240MovSts = new short[1] ;
         P003B2_A1237MovAbr = new string[] {""} ;
         P003B2_A234MovCod = new int[1] ;
         P003B2_A1241MovTip = new short[1] ;
         AV26Option = "";
         P003B3_A1237MovAbr = new string[] {""} ;
         P003B3_A1240MovSts = new short[1] ;
         P003B3_A234MovCod = new int[1] ;
         P003B3_A1241MovTip = new short[1] ;
         P003B3_A1239MovDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.movimientoalmacenwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003B2_A1239MovDsc, P003B2_A1240MovSts, P003B2_A1237MovAbr, P003B2_A234MovCod, P003B2_A1241MovTip
               }
               , new Object[] {
               P003B3_A1237MovAbr, P003B3_A1240MovSts, P003B3_A234MovCod, P003B3_A1241MovTip, P003B3_A1239MovDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV41DynamicFiltersOperator1 ;
      private short AV43MovTip1 ;
      private short AV46DynamicFiltersOperator2 ;
      private short AV48MovTip2 ;
      private short AV51DynamicFiltersOperator3 ;
      private short AV53MovTip3 ;
      private short AV59Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 ;
      private short AV61Configuracion_movimientoalmacenwwds_4_movtip1 ;
      private short AV64Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 ;
      private short AV66Configuracion_movimientoalmacenwwds_9_movtip2 ;
      private short AV69Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 ;
      private short AV71Configuracion_movimientoalmacenwwds_14_movtip3 ;
      private short A1241MovTip ;
      private short A1240MovSts ;
      private int AV56GXV1 ;
      private int AV10TFMovCod ;
      private int AV11TFMovCod_To ;
      private int AV72Configuracion_movimientoalmacenwwds_15_tfmovcod ;
      private int AV73Configuracion_movimientoalmacenwwds_16_tfmovcod_to ;
      private int AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels_Count ;
      private int AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels_Count ;
      private int A234MovCod ;
      private long AV34count ;
      private string AV12TFMovDsc ;
      private string AV13TFMovDsc_Sel ;
      private string AV14TFMovAbr ;
      private string AV15TFMovAbr_Sel ;
      private string AV42MovDsc1 ;
      private string AV47MovDsc2 ;
      private string AV52MovDsc3 ;
      private string AV60Configuracion_movimientoalmacenwwds_3_movdsc1 ;
      private string AV65Configuracion_movimientoalmacenwwds_8_movdsc2 ;
      private string AV70Configuracion_movimientoalmacenwwds_13_movdsc3 ;
      private string AV74Configuracion_movimientoalmacenwwds_17_tfmovdsc ;
      private string AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel ;
      private string AV76Configuracion_movimientoalmacenwwds_19_tfmovabr ;
      private string AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel ;
      private string scmdbuf ;
      private string lV60Configuracion_movimientoalmacenwwds_3_movdsc1 ;
      private string lV65Configuracion_movimientoalmacenwwds_8_movdsc2 ;
      private string lV70Configuracion_movimientoalmacenwwds_13_movdsc3 ;
      private string lV74Configuracion_movimientoalmacenwwds_17_tfmovdsc ;
      private string lV76Configuracion_movimientoalmacenwwds_19_tfmovabr ;
      private string A1239MovDsc ;
      private string A1237MovAbr ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV62Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 ;
      private bool AV67Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 ;
      private bool BRK3B2 ;
      private bool BRK3B4 ;
      private string AV28OptionsJson ;
      private string AV31OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV16TFMovTip_SelsJson ;
      private string AV18TFMovSts_SelsJson ;
      private string AV24DDOName ;
      private string AV22SearchTxt ;
      private string AV23SearchTxtTo ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV58Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 ;
      private string AV63Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 ;
      private string AV68Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 ;
      private string AV26Option ;
      private GxSimpleCollection<short> AV17TFMovTip_Sels ;
      private GxSimpleCollection<short> AV19TFMovSts_Sels ;
      private GxSimpleCollection<short> AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels ;
      private GxSimpleCollection<short> AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003B2_A1239MovDsc ;
      private short[] P003B2_A1240MovSts ;
      private string[] P003B2_A1237MovAbr ;
      private int[] P003B2_A234MovCod ;
      private short[] P003B2_A1241MovTip ;
      private string[] P003B3_A1237MovAbr ;
      private short[] P003B3_A1240MovSts ;
      private int[] P003B3_A234MovCod ;
      private short[] P003B3_A1241MovTip ;
      private string[] P003B3_A1239MovDsc ;
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

   public class movimientoalmacenwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003B2( IGxContext context ,
                                             short A1241MovTip ,
                                             GxSimpleCollection<short> AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels ,
                                             short A1240MovSts ,
                                             GxSimpleCollection<short> AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels ,
                                             string AV58Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 ,
                                             short AV59Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 ,
                                             string AV60Configuracion_movimientoalmacenwwds_3_movdsc1 ,
                                             short AV61Configuracion_movimientoalmacenwwds_4_movtip1 ,
                                             bool AV62Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 ,
                                             string AV63Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 ,
                                             short AV64Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 ,
                                             string AV65Configuracion_movimientoalmacenwwds_8_movdsc2 ,
                                             short AV66Configuracion_movimientoalmacenwwds_9_movtip2 ,
                                             bool AV67Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 ,
                                             string AV68Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 ,
                                             short AV69Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 ,
                                             string AV70Configuracion_movimientoalmacenwwds_13_movdsc3 ,
                                             short AV71Configuracion_movimientoalmacenwwds_14_movtip3 ,
                                             int AV72Configuracion_movimientoalmacenwwds_15_tfmovcod ,
                                             int AV73Configuracion_movimientoalmacenwwds_16_tfmovcod_to ,
                                             string AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel ,
                                             string AV74Configuracion_movimientoalmacenwwds_17_tfmovdsc ,
                                             string AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel ,
                                             string AV76Configuracion_movimientoalmacenwwds_19_tfmovabr ,
                                             int AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels_Count ,
                                             int AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels_Count ,
                                             string A1239MovDsc ,
                                             int A234MovCod ,
                                             string A1237MovAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [MovDsc], [MovSts], [MovAbr], [MovCod], [MovTip] FROM [CMOVALMACEN]";
         if ( ( StringUtil.StrCmp(AV58Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1, "MOVDSC") == 0 ) && ( AV59Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_movimientoalmacenwwds_3_movdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV60Configuracion_movimientoalmacenwwds_3_movdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1, "MOVDSC") == 0 ) && ( AV59Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_movimientoalmacenwwds_3_movdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like '%' + @lV60Configuracion_movimientoalmacenwwds_3_movdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1, "MOVTIP") == 0 ) && ( ! (0==AV61Configuracion_movimientoalmacenwwds_4_movtip1) ) )
         {
            AddWhere(sWhereString, "([MovTip] = @AV61Configuracion_movimientoalmacenwwds_4_movtip1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV62Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2, "MOVDSC") == 0 ) && ( AV64Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_movimientoalmacenwwds_8_movdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV65Configuracion_movimientoalmacenwwds_8_movdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV62Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2, "MOVDSC") == 0 ) && ( AV64Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_movimientoalmacenwwds_8_movdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like '%' + @lV65Configuracion_movimientoalmacenwwds_8_movdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV62Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2, "MOVTIP") == 0 ) && ( ! (0==AV66Configuracion_movimientoalmacenwwds_9_movtip2) ) )
         {
            AddWhere(sWhereString, "([MovTip] = @AV66Configuracion_movimientoalmacenwwds_9_movtip2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV67Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3, "MOVDSC") == 0 ) && ( AV69Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_movimientoalmacenwwds_13_movdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV70Configuracion_movimientoalmacenwwds_13_movdsc3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV67Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3, "MOVDSC") == 0 ) && ( AV69Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_movimientoalmacenwwds_13_movdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like '%' + @lV70Configuracion_movimientoalmacenwwds_13_movdsc3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV67Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3, "MOVTIP") == 0 ) && ( ! (0==AV71Configuracion_movimientoalmacenwwds_14_movtip3) ) )
         {
            AddWhere(sWhereString, "([MovTip] = @AV71Configuracion_movimientoalmacenwwds_14_movtip3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV72Configuracion_movimientoalmacenwwds_15_tfmovcod) )
         {
            AddWhere(sWhereString, "([MovCod] >= @AV72Configuracion_movimientoalmacenwwds_15_tfmovcod)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV73Configuracion_movimientoalmacenwwds_16_tfmovcod_to) )
         {
            AddWhere(sWhereString, "([MovCod] <= @AV73Configuracion_movimientoalmacenwwds_16_tfmovcod_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_movimientoalmacenwwds_17_tfmovdsc)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV74Configuracion_movimientoalmacenwwds_17_tfmovdsc)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel)) )
         {
            AddWhere(sWhereString, "([MovDsc] = @AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_movimientoalmacenwwds_19_tfmovabr)) ) )
         {
            AddWhere(sWhereString, "([MovAbr] like @lV76Configuracion_movimientoalmacenwwds_19_tfmovabr)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel)) )
         {
            AddWhere(sWhereString, "([MovAbr] = @AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels, "[MovTip] IN (", ")")+")");
         }
         if ( AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels, "[MovSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MovDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P003B3( IGxContext context ,
                                             short A1241MovTip ,
                                             GxSimpleCollection<short> AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels ,
                                             short A1240MovSts ,
                                             GxSimpleCollection<short> AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels ,
                                             string AV58Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1 ,
                                             short AV59Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 ,
                                             string AV60Configuracion_movimientoalmacenwwds_3_movdsc1 ,
                                             short AV61Configuracion_movimientoalmacenwwds_4_movtip1 ,
                                             bool AV62Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 ,
                                             string AV63Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2 ,
                                             short AV64Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 ,
                                             string AV65Configuracion_movimientoalmacenwwds_8_movdsc2 ,
                                             short AV66Configuracion_movimientoalmacenwwds_9_movtip2 ,
                                             bool AV67Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 ,
                                             string AV68Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3 ,
                                             short AV69Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 ,
                                             string AV70Configuracion_movimientoalmacenwwds_13_movdsc3 ,
                                             short AV71Configuracion_movimientoalmacenwwds_14_movtip3 ,
                                             int AV72Configuracion_movimientoalmacenwwds_15_tfmovcod ,
                                             int AV73Configuracion_movimientoalmacenwwds_16_tfmovcod_to ,
                                             string AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel ,
                                             string AV74Configuracion_movimientoalmacenwwds_17_tfmovdsc ,
                                             string AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel ,
                                             string AV76Configuracion_movimientoalmacenwwds_19_tfmovabr ,
                                             int AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels_Count ,
                                             int AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels_Count ,
                                             string A1239MovDsc ,
                                             int A234MovCod ,
                                             string A1237MovAbr )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[15];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [MovAbr], [MovSts], [MovCod], [MovTip], [MovDsc] FROM [CMOVALMACEN]";
         if ( ( StringUtil.StrCmp(AV58Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1, "MOVDSC") == 0 ) && ( AV59Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_movimientoalmacenwwds_3_movdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV60Configuracion_movimientoalmacenwwds_3_movdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1, "MOVDSC") == 0 ) && ( AV59Configuracion_movimientoalmacenwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_movimientoalmacenwwds_3_movdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like '%' + @lV60Configuracion_movimientoalmacenwwds_3_movdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Configuracion_movimientoalmacenwwds_1_dynamicfiltersselector1, "MOVTIP") == 0 ) && ( ! (0==AV61Configuracion_movimientoalmacenwwds_4_movtip1) ) )
         {
            AddWhere(sWhereString, "([MovTip] = @AV61Configuracion_movimientoalmacenwwds_4_movtip1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV62Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2, "MOVDSC") == 0 ) && ( AV64Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_movimientoalmacenwwds_8_movdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV65Configuracion_movimientoalmacenwwds_8_movdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV62Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2, "MOVDSC") == 0 ) && ( AV64Configuracion_movimientoalmacenwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_movimientoalmacenwwds_8_movdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like '%' + @lV65Configuracion_movimientoalmacenwwds_8_movdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV62Configuracion_movimientoalmacenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_movimientoalmacenwwds_6_dynamicfiltersselector2, "MOVTIP") == 0 ) && ( ! (0==AV66Configuracion_movimientoalmacenwwds_9_movtip2) ) )
         {
            AddWhere(sWhereString, "([MovTip] = @AV66Configuracion_movimientoalmacenwwds_9_movtip2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV67Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3, "MOVDSC") == 0 ) && ( AV69Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_movimientoalmacenwwds_13_movdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV70Configuracion_movimientoalmacenwwds_13_movdsc3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV67Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3, "MOVDSC") == 0 ) && ( AV69Configuracion_movimientoalmacenwwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_movimientoalmacenwwds_13_movdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like '%' + @lV70Configuracion_movimientoalmacenwwds_13_movdsc3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV67Configuracion_movimientoalmacenwwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configuracion_movimientoalmacenwwds_11_dynamicfiltersselector3, "MOVTIP") == 0 ) && ( ! (0==AV71Configuracion_movimientoalmacenwwds_14_movtip3) ) )
         {
            AddWhere(sWhereString, "([MovTip] = @AV71Configuracion_movimientoalmacenwwds_14_movtip3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV72Configuracion_movimientoalmacenwwds_15_tfmovcod) )
         {
            AddWhere(sWhereString, "([MovCod] >= @AV72Configuracion_movimientoalmacenwwds_15_tfmovcod)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (0==AV73Configuracion_movimientoalmacenwwds_16_tfmovcod_to) )
         {
            AddWhere(sWhereString, "([MovCod] <= @AV73Configuracion_movimientoalmacenwwds_16_tfmovcod_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_movimientoalmacenwwds_17_tfmovdsc)) ) )
         {
            AddWhere(sWhereString, "([MovDsc] like @lV74Configuracion_movimientoalmacenwwds_17_tfmovdsc)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel)) )
         {
            AddWhere(sWhereString, "([MovDsc] = @AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_movimientoalmacenwwds_19_tfmovabr)) ) )
         {
            AddWhere(sWhereString, "([MovAbr] like @lV76Configuracion_movimientoalmacenwwds_19_tfmovabr)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel)) )
         {
            AddWhere(sWhereString, "([MovAbr] = @AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Configuracion_movimientoalmacenwwds_21_tfmovtip_sels, "[MovTip] IN (", ")")+")");
         }
         if ( AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Configuracion_movimientoalmacenwwds_22_tfmovsts_sels, "[MovSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MovAbr]";
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
                     return conditional_P003B2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
               case 1 :
                     return conditional_P003B3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP003B2;
          prmP003B2 = new Object[] {
          new ParDef("@lV60Configuracion_movimientoalmacenwwds_3_movdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Configuracion_movimientoalmacenwwds_3_movdsc1",GXType.NChar,100,0) ,
          new ParDef("@AV61Configuracion_movimientoalmacenwwds_4_movtip1",GXType.Int16,1,0) ,
          new ParDef("@lV65Configuracion_movimientoalmacenwwds_8_movdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_movimientoalmacenwwds_8_movdsc2",GXType.NChar,100,0) ,
          new ParDef("@AV66Configuracion_movimientoalmacenwwds_9_movtip2",GXType.Int16,1,0) ,
          new ParDef("@lV70Configuracion_movimientoalmacenwwds_13_movdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_movimientoalmacenwwds_13_movdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV71Configuracion_movimientoalmacenwwds_14_movtip3",GXType.Int16,1,0) ,
          new ParDef("@AV72Configuracion_movimientoalmacenwwds_15_tfmovcod",GXType.Int32,6,0) ,
          new ParDef("@AV73Configuracion_movimientoalmacenwwds_16_tfmovcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV74Configuracion_movimientoalmacenwwds_17_tfmovdsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_movimientoalmacenwwds_19_tfmovabr",GXType.NChar,5,0) ,
          new ParDef("@AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel",GXType.NChar,5,0)
          };
          Object[] prmP003B3;
          prmP003B3 = new Object[] {
          new ParDef("@lV60Configuracion_movimientoalmacenwwds_3_movdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Configuracion_movimientoalmacenwwds_3_movdsc1",GXType.NChar,100,0) ,
          new ParDef("@AV61Configuracion_movimientoalmacenwwds_4_movtip1",GXType.Int16,1,0) ,
          new ParDef("@lV65Configuracion_movimientoalmacenwwds_8_movdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_movimientoalmacenwwds_8_movdsc2",GXType.NChar,100,0) ,
          new ParDef("@AV66Configuracion_movimientoalmacenwwds_9_movtip2",GXType.Int16,1,0) ,
          new ParDef("@lV70Configuracion_movimientoalmacenwwds_13_movdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_movimientoalmacenwwds_13_movdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV71Configuracion_movimientoalmacenwwds_14_movtip3",GXType.Int16,1,0) ,
          new ParDef("@AV72Configuracion_movimientoalmacenwwds_15_tfmovcod",GXType.Int32,6,0) ,
          new ParDef("@AV73Configuracion_movimientoalmacenwwds_16_tfmovcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV74Configuracion_movimientoalmacenwwds_17_tfmovdsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Configuracion_movimientoalmacenwwds_18_tfmovdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_movimientoalmacenwwds_19_tfmovabr",GXType.NChar,5,0) ,
          new ParDef("@AV77Configuracion_movimientoalmacenwwds_20_tfmovabr_sel",GXType.NChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003B2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003B3,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
