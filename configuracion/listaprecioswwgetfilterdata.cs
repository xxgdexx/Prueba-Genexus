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
   public class listaprecioswwgetfilterdata : GXProcedure
   {
      public listaprecioswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public listaprecioswwgetfilterdata( IGxContext context )
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
         this.AV32DDOName = aP0_DDOName;
         this.AV30SearchTxt = aP1_SearchTxt;
         this.AV31SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV41OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV41OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV41OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         listaprecioswwgetfilterdata objlistaprecioswwgetfilterdata;
         objlistaprecioswwgetfilterdata = new listaprecioswwgetfilterdata();
         objlistaprecioswwgetfilterdata.AV32DDOName = aP0_DDOName;
         objlistaprecioswwgetfilterdata.AV30SearchTxt = aP1_SearchTxt;
         objlistaprecioswwgetfilterdata.AV31SearchTxtTo = aP2_SearchTxtTo;
         objlistaprecioswwgetfilterdata.AV36OptionsJson = "" ;
         objlistaprecioswwgetfilterdata.AV39OptionsDescJson = "" ;
         objlistaprecioswwgetfilterdata.AV41OptionIndexesJson = "" ;
         objlistaprecioswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objlistaprecioswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objlistaprecioswwgetfilterdata);
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV41OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((listaprecioswwgetfilterdata)stateInfo).executePrivate();
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
         AV35Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_TIPLDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPLDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_PRODCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADPRODCODOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_TIPLPRODDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPLPRODDSCOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_CLICOD") == 0 )
         {
            /* Execute user subroutine: 'LOADCLICODOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV36OptionsJson = AV35Options.ToJSonString(false);
         AV39OptionsDescJson = AV38OptionsDesc.ToJSonString(false);
         AV41OptionIndexesJson = AV40OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV43Session.Get("Configuracion.ListaPreciosWWGridState"), "") == 0 )
         {
            AV45GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.ListaPreciosWWGridState"), null, "", "");
         }
         else
         {
            AV45GridState.FromXml(AV43Session.Get("Configuracion.ListaPreciosWWGridState"), null, "", "");
         }
         AV64GXV1 = 1;
         while ( AV64GXV1 <= AV45GridState.gxTpr_Filtervalues.Count )
         {
            AV46GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV45GridState.gxTpr_Filtervalues.Item(AV64GXV1));
            if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTIPLDSC") == 0 )
            {
               AV18TFTipLDsc = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTIPLDSC_SEL") == 0 )
            {
               AV19TFTipLDsc_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFPRODCOD") == 0 )
            {
               AV14TFProdCod = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFPRODCOD_SEL") == 0 )
            {
               AV15TFProdCod_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTIPLPRODDSC") == 0 )
            {
               AV16TFTipLProdDsc = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTIPLPRODDSC_SEL") == 0 )
            {
               AV17TFTipLProdDsc_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCLICOD") == 0 )
            {
               AV22TFCliCod = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCLICOD_SEL") == 0 )
            {
               AV23TFCliCod_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFPRELIS") == 0 )
            {
               AV20TFPreLis = NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, ".");
               AV21TFPreLis_To = NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFLISFECH") == 0 )
            {
               AV26TFLisFech = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Value, 2);
               AV27TFLisFech_To = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV64GXV1 = (int)(AV64GXV1+1);
         }
         if ( AV45GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV47GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV45GridState.gxTpr_Dynamicfilters.Item(1));
            AV48DynamicFiltersSelector1 = AV47GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "TIPLPRODDSC") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV47GridStateDynamicFilter.gxTpr_Operator;
               AV50TipLProdDsc1 = AV47GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "TIPLDSC") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV47GridStateDynamicFilter.gxTpr_Operator;
               AV51TipLDsc1 = AV47GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV45GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV52DynamicFiltersEnabled2 = true;
               AV47GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV45GridState.gxTpr_Dynamicfilters.Item(2));
               AV53DynamicFiltersSelector2 = AV47GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "TIPLPRODDSC") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV47GridStateDynamicFilter.gxTpr_Operator;
                  AV55TipLProdDsc2 = AV47GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "TIPLDSC") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV47GridStateDynamicFilter.gxTpr_Operator;
                  AV56TipLDsc2 = AV47GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV45GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV57DynamicFiltersEnabled3 = true;
                  AV47GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV45GridState.gxTpr_Dynamicfilters.Item(3));
                  AV58DynamicFiltersSelector3 = AV47GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV58DynamicFiltersSelector3, "TIPLPRODDSC") == 0 )
                  {
                     AV59DynamicFiltersOperator3 = AV47GridStateDynamicFilter.gxTpr_Operator;
                     AV60TipLProdDsc3 = AV47GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector3, "TIPLDSC") == 0 )
                  {
                     AV59DynamicFiltersOperator3 = AV47GridStateDynamicFilter.gxTpr_Operator;
                     AV61TipLDsc3 = AV47GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTIPLDSCOPTIONS' Routine */
         returnInSub = false;
         AV18TFTipLDsc = AV30SearchTxt;
         AV19TFTipLDsc_Sel = "";
         AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV68Configuracion_listaprecioswwds_3_tiplproddsc1 = AV50TipLProdDsc1;
         AV69Configuracion_listaprecioswwds_4_tipldsc1 = AV51TipLDsc1;
         AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV73Configuracion_listaprecioswwds_8_tiplproddsc2 = AV55TipLProdDsc2;
         AV74Configuracion_listaprecioswwds_9_tipldsc2 = AV56TipLDsc2;
         AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV78Configuracion_listaprecioswwds_13_tiplproddsc3 = AV60TipLProdDsc3;
         AV79Configuracion_listaprecioswwds_14_tipldsc3 = AV61TipLDsc3;
         AV80Configuracion_listaprecioswwds_15_tftipldsc = AV18TFTipLDsc;
         AV81Configuracion_listaprecioswwds_16_tftipldsc_sel = AV19TFTipLDsc_Sel;
         AV82Configuracion_listaprecioswwds_17_tfprodcod = AV14TFProdCod;
         AV83Configuracion_listaprecioswwds_18_tfprodcod_sel = AV15TFProdCod_Sel;
         AV84Configuracion_listaprecioswwds_19_tftiplproddsc = AV16TFTipLProdDsc;
         AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel = AV17TFTipLProdDsc_Sel;
         AV86Configuracion_listaprecioswwds_21_tfclicod = AV22TFCliCod;
         AV87Configuracion_listaprecioswwds_22_tfclicod_sel = AV23TFCliCod_Sel;
         AV88Configuracion_listaprecioswwds_23_tfprelis = AV20TFPreLis;
         AV89Configuracion_listaprecioswwds_24_tfprelis_to = AV21TFPreLis_To;
         AV90Configuracion_listaprecioswwds_25_tflisfech = AV26TFLisFech;
         AV91Configuracion_listaprecioswwds_26_tflisfech_to = AV27TFLisFech_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                              AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                              AV68Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                              AV69Configuracion_listaprecioswwds_4_tipldsc1 ,
                                              AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                              AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                              AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                              AV73Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                              AV74Configuracion_listaprecioswwds_9_tipldsc2 ,
                                              AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                              AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                              AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                              AV78Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                              AV79Configuracion_listaprecioswwds_14_tipldsc3 ,
                                              AV81Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                              AV80Configuracion_listaprecioswwds_15_tftipldsc ,
                                              AV83Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                              AV82Configuracion_listaprecioswwds_17_tfprodcod ,
                                              AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                              AV84Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                              AV87Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                              AV86Configuracion_listaprecioswwds_21_tfclicod ,
                                              AV88Configuracion_listaprecioswwds_23_tfprelis ,
                                              AV89Configuracion_listaprecioswwds_24_tfprelis_to ,
                                              AV90Configuracion_listaprecioswwds_25_tflisfech ,
                                              AV91Configuracion_listaprecioswwds_26_tflisfech_to ,
                                              A1913TipLProdDsc ,
                                              A1912TipLDsc ,
                                              A28ProdCod ,
                                              A45CliCod ,
                                              A1651PreLis ,
                                              A1205LisFech } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE
                                              }
         });
         lV68Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
         lV68Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
         lV69Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
         lV69Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
         lV73Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
         lV73Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
         lV74Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
         lV74Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
         lV78Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
         lV78Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
         lV79Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
         lV79Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
         lV80Configuracion_listaprecioswwds_15_tftipldsc = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_listaprecioswwds_15_tftipldsc), 100, "%");
         lV82Configuracion_listaprecioswwds_17_tfprodcod = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_listaprecioswwds_17_tfprodcod), 15, "%");
         lV84Configuracion_listaprecioswwds_19_tftiplproddsc = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_listaprecioswwds_19_tftiplproddsc), 100, "%");
         lV86Configuracion_listaprecioswwds_21_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_listaprecioswwds_21_tfclicod), 20, "%");
         /* Using cursor P004I2 */
         pr_default.execute(0, new Object[] {lV68Configuracion_listaprecioswwds_3_tiplproddsc1, lV68Configuracion_listaprecioswwds_3_tiplproddsc1, lV69Configuracion_listaprecioswwds_4_tipldsc1, lV69Configuracion_listaprecioswwds_4_tipldsc1, lV73Configuracion_listaprecioswwds_8_tiplproddsc2, lV73Configuracion_listaprecioswwds_8_tiplproddsc2, lV74Configuracion_listaprecioswwds_9_tipldsc2, lV74Configuracion_listaprecioswwds_9_tipldsc2, lV78Configuracion_listaprecioswwds_13_tiplproddsc3, lV78Configuracion_listaprecioswwds_13_tiplproddsc3, lV79Configuracion_listaprecioswwds_14_tipldsc3, lV79Configuracion_listaprecioswwds_14_tipldsc3, lV80Configuracion_listaprecioswwds_15_tftipldsc, AV81Configuracion_listaprecioswwds_16_tftipldsc_sel, lV82Configuracion_listaprecioswwds_17_tfprodcod, AV83Configuracion_listaprecioswwds_18_tfprodcod_sel, lV84Configuracion_listaprecioswwds_19_tftiplproddsc, AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel, lV86Configuracion_listaprecioswwds_21_tfclicod, AV87Configuracion_listaprecioswwds_22_tfclicod_sel, AV88Configuracion_listaprecioswwds_23_tfprelis, AV89Configuracion_listaprecioswwds_24_tfprelis_to, AV90Configuracion_listaprecioswwds_25_tflisfech, AV91Configuracion_listaprecioswwds_26_tflisfech_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4I2 = false;
            A202TipLCod = P004I2_A202TipLCod[0];
            A1205LisFech = P004I2_A1205LisFech[0];
            A1651PreLis = P004I2_A1651PreLis[0];
            A45CliCod = P004I2_A45CliCod[0];
            n45CliCod = P004I2_n45CliCod[0];
            A28ProdCod = P004I2_A28ProdCod[0];
            A1912TipLDsc = P004I2_A1912TipLDsc[0];
            A1913TipLProdDsc = P004I2_A1913TipLProdDsc[0];
            A203TipLItem = P004I2_A203TipLItem[0];
            A1912TipLDsc = P004I2_A1912TipLDsc[0];
            AV42count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P004I2_A202TipLCod[0] == A202TipLCod ) )
            {
               BRK4I2 = false;
               A203TipLItem = P004I2_A203TipLItem[0];
               AV42count = (long)(AV42count+1);
               BRK4I2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1912TipLDsc)) )
            {
               AV34Option = A1912TipLDsc;
               AV33InsertIndex = 1;
               while ( ( AV33InsertIndex <= AV35Options.Count ) && ( StringUtil.StrCmp(((string)AV35Options.Item(AV33InsertIndex)), AV34Option) < 0 ) )
               {
                  AV33InsertIndex = (int)(AV33InsertIndex+1);
               }
               AV35Options.Add(AV34Option, AV33InsertIndex);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV42count), "Z,ZZZ,ZZZ,ZZ9")), AV33InsertIndex);
            }
            if ( AV35Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK4I2 )
            {
               BRK4I2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPRODCODOPTIONS' Routine */
         returnInSub = false;
         AV14TFProdCod = AV30SearchTxt;
         AV15TFProdCod_Sel = "";
         AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV68Configuracion_listaprecioswwds_3_tiplproddsc1 = AV50TipLProdDsc1;
         AV69Configuracion_listaprecioswwds_4_tipldsc1 = AV51TipLDsc1;
         AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV73Configuracion_listaprecioswwds_8_tiplproddsc2 = AV55TipLProdDsc2;
         AV74Configuracion_listaprecioswwds_9_tipldsc2 = AV56TipLDsc2;
         AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV78Configuracion_listaprecioswwds_13_tiplproddsc3 = AV60TipLProdDsc3;
         AV79Configuracion_listaprecioswwds_14_tipldsc3 = AV61TipLDsc3;
         AV80Configuracion_listaprecioswwds_15_tftipldsc = AV18TFTipLDsc;
         AV81Configuracion_listaprecioswwds_16_tftipldsc_sel = AV19TFTipLDsc_Sel;
         AV82Configuracion_listaprecioswwds_17_tfprodcod = AV14TFProdCod;
         AV83Configuracion_listaprecioswwds_18_tfprodcod_sel = AV15TFProdCod_Sel;
         AV84Configuracion_listaprecioswwds_19_tftiplproddsc = AV16TFTipLProdDsc;
         AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel = AV17TFTipLProdDsc_Sel;
         AV86Configuracion_listaprecioswwds_21_tfclicod = AV22TFCliCod;
         AV87Configuracion_listaprecioswwds_22_tfclicod_sel = AV23TFCliCod_Sel;
         AV88Configuracion_listaprecioswwds_23_tfprelis = AV20TFPreLis;
         AV89Configuracion_listaprecioswwds_24_tfprelis_to = AV21TFPreLis_To;
         AV90Configuracion_listaprecioswwds_25_tflisfech = AV26TFLisFech;
         AV91Configuracion_listaprecioswwds_26_tflisfech_to = AV27TFLisFech_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                              AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                              AV68Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                              AV69Configuracion_listaprecioswwds_4_tipldsc1 ,
                                              AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                              AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                              AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                              AV73Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                              AV74Configuracion_listaprecioswwds_9_tipldsc2 ,
                                              AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                              AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                              AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                              AV78Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                              AV79Configuracion_listaprecioswwds_14_tipldsc3 ,
                                              AV81Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                              AV80Configuracion_listaprecioswwds_15_tftipldsc ,
                                              AV83Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                              AV82Configuracion_listaprecioswwds_17_tfprodcod ,
                                              AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                              AV84Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                              AV87Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                              AV86Configuracion_listaprecioswwds_21_tfclicod ,
                                              AV88Configuracion_listaprecioswwds_23_tfprelis ,
                                              AV89Configuracion_listaprecioswwds_24_tfprelis_to ,
                                              AV90Configuracion_listaprecioswwds_25_tflisfech ,
                                              AV91Configuracion_listaprecioswwds_26_tflisfech_to ,
                                              A1913TipLProdDsc ,
                                              A1912TipLDsc ,
                                              A28ProdCod ,
                                              A45CliCod ,
                                              A1651PreLis ,
                                              A1205LisFech } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE
                                              }
         });
         lV68Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
         lV68Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
         lV69Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
         lV69Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
         lV73Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
         lV73Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
         lV74Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
         lV74Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
         lV78Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
         lV78Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
         lV79Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
         lV79Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
         lV80Configuracion_listaprecioswwds_15_tftipldsc = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_listaprecioswwds_15_tftipldsc), 100, "%");
         lV82Configuracion_listaprecioswwds_17_tfprodcod = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_listaprecioswwds_17_tfprodcod), 15, "%");
         lV84Configuracion_listaprecioswwds_19_tftiplproddsc = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_listaprecioswwds_19_tftiplproddsc), 100, "%");
         lV86Configuracion_listaprecioswwds_21_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_listaprecioswwds_21_tfclicod), 20, "%");
         /* Using cursor P004I3 */
         pr_default.execute(1, new Object[] {lV68Configuracion_listaprecioswwds_3_tiplproddsc1, lV68Configuracion_listaprecioswwds_3_tiplproddsc1, lV69Configuracion_listaprecioswwds_4_tipldsc1, lV69Configuracion_listaprecioswwds_4_tipldsc1, lV73Configuracion_listaprecioswwds_8_tiplproddsc2, lV73Configuracion_listaprecioswwds_8_tiplproddsc2, lV74Configuracion_listaprecioswwds_9_tipldsc2, lV74Configuracion_listaprecioswwds_9_tipldsc2, lV78Configuracion_listaprecioswwds_13_tiplproddsc3, lV78Configuracion_listaprecioswwds_13_tiplproddsc3, lV79Configuracion_listaprecioswwds_14_tipldsc3, lV79Configuracion_listaprecioswwds_14_tipldsc3, lV80Configuracion_listaprecioswwds_15_tftipldsc, AV81Configuracion_listaprecioswwds_16_tftipldsc_sel, lV82Configuracion_listaprecioswwds_17_tfprodcod, AV83Configuracion_listaprecioswwds_18_tfprodcod_sel, lV84Configuracion_listaprecioswwds_19_tftiplproddsc, AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel, lV86Configuracion_listaprecioswwds_21_tfclicod, AV87Configuracion_listaprecioswwds_22_tfclicod_sel, AV88Configuracion_listaprecioswwds_23_tfprelis, AV89Configuracion_listaprecioswwds_24_tfprelis_to, AV90Configuracion_listaprecioswwds_25_tflisfech, AV91Configuracion_listaprecioswwds_26_tflisfech_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4I4 = false;
            A202TipLCod = P004I3_A202TipLCod[0];
            A28ProdCod = P004I3_A28ProdCod[0];
            A1205LisFech = P004I3_A1205LisFech[0];
            A1651PreLis = P004I3_A1651PreLis[0];
            A45CliCod = P004I3_A45CliCod[0];
            n45CliCod = P004I3_n45CliCod[0];
            A1912TipLDsc = P004I3_A1912TipLDsc[0];
            A1913TipLProdDsc = P004I3_A1913TipLProdDsc[0];
            A203TipLItem = P004I3_A203TipLItem[0];
            A1912TipLDsc = P004I3_A1912TipLDsc[0];
            AV42count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P004I3_A28ProdCod[0], A28ProdCod) == 0 ) )
            {
               BRK4I4 = false;
               A202TipLCod = P004I3_A202TipLCod[0];
               A203TipLItem = P004I3_A203TipLItem[0];
               AV42count = (long)(AV42count+1);
               BRK4I4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A28ProdCod)) )
            {
               AV34Option = A28ProdCod;
               AV37OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A28ProdCod, "@!")));
               AV35Options.Add(AV34Option, 0);
               AV38OptionsDesc.Add(AV37OptionDesc, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV42count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV35Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK4I4 )
            {
               BRK4I4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADTIPLPRODDSCOPTIONS' Routine */
         returnInSub = false;
         AV16TFTipLProdDsc = AV30SearchTxt;
         AV17TFTipLProdDsc_Sel = "";
         AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV68Configuracion_listaprecioswwds_3_tiplproddsc1 = AV50TipLProdDsc1;
         AV69Configuracion_listaprecioswwds_4_tipldsc1 = AV51TipLDsc1;
         AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV73Configuracion_listaprecioswwds_8_tiplproddsc2 = AV55TipLProdDsc2;
         AV74Configuracion_listaprecioswwds_9_tipldsc2 = AV56TipLDsc2;
         AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV78Configuracion_listaprecioswwds_13_tiplproddsc3 = AV60TipLProdDsc3;
         AV79Configuracion_listaprecioswwds_14_tipldsc3 = AV61TipLDsc3;
         AV80Configuracion_listaprecioswwds_15_tftipldsc = AV18TFTipLDsc;
         AV81Configuracion_listaprecioswwds_16_tftipldsc_sel = AV19TFTipLDsc_Sel;
         AV82Configuracion_listaprecioswwds_17_tfprodcod = AV14TFProdCod;
         AV83Configuracion_listaprecioswwds_18_tfprodcod_sel = AV15TFProdCod_Sel;
         AV84Configuracion_listaprecioswwds_19_tftiplproddsc = AV16TFTipLProdDsc;
         AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel = AV17TFTipLProdDsc_Sel;
         AV86Configuracion_listaprecioswwds_21_tfclicod = AV22TFCliCod;
         AV87Configuracion_listaprecioswwds_22_tfclicod_sel = AV23TFCliCod_Sel;
         AV88Configuracion_listaprecioswwds_23_tfprelis = AV20TFPreLis;
         AV89Configuracion_listaprecioswwds_24_tfprelis_to = AV21TFPreLis_To;
         AV90Configuracion_listaprecioswwds_25_tflisfech = AV26TFLisFech;
         AV91Configuracion_listaprecioswwds_26_tflisfech_to = AV27TFLisFech_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                              AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                              AV68Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                              AV69Configuracion_listaprecioswwds_4_tipldsc1 ,
                                              AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                              AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                              AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                              AV73Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                              AV74Configuracion_listaprecioswwds_9_tipldsc2 ,
                                              AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                              AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                              AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                              AV78Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                              AV79Configuracion_listaprecioswwds_14_tipldsc3 ,
                                              AV81Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                              AV80Configuracion_listaprecioswwds_15_tftipldsc ,
                                              AV83Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                              AV82Configuracion_listaprecioswwds_17_tfprodcod ,
                                              AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                              AV84Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                              AV87Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                              AV86Configuracion_listaprecioswwds_21_tfclicod ,
                                              AV88Configuracion_listaprecioswwds_23_tfprelis ,
                                              AV89Configuracion_listaprecioswwds_24_tfprelis_to ,
                                              AV90Configuracion_listaprecioswwds_25_tflisfech ,
                                              AV91Configuracion_listaprecioswwds_26_tflisfech_to ,
                                              A1913TipLProdDsc ,
                                              A1912TipLDsc ,
                                              A28ProdCod ,
                                              A45CliCod ,
                                              A1651PreLis ,
                                              A1205LisFech } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE
                                              }
         });
         lV68Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
         lV68Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
         lV69Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
         lV69Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
         lV73Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
         lV73Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
         lV74Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
         lV74Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
         lV78Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
         lV78Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
         lV79Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
         lV79Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
         lV80Configuracion_listaprecioswwds_15_tftipldsc = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_listaprecioswwds_15_tftipldsc), 100, "%");
         lV82Configuracion_listaprecioswwds_17_tfprodcod = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_listaprecioswwds_17_tfprodcod), 15, "%");
         lV84Configuracion_listaprecioswwds_19_tftiplproddsc = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_listaprecioswwds_19_tftiplproddsc), 100, "%");
         lV86Configuracion_listaprecioswwds_21_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_listaprecioswwds_21_tfclicod), 20, "%");
         /* Using cursor P004I4 */
         pr_default.execute(2, new Object[] {lV68Configuracion_listaprecioswwds_3_tiplproddsc1, lV68Configuracion_listaprecioswwds_3_tiplproddsc1, lV69Configuracion_listaprecioswwds_4_tipldsc1, lV69Configuracion_listaprecioswwds_4_tipldsc1, lV73Configuracion_listaprecioswwds_8_tiplproddsc2, lV73Configuracion_listaprecioswwds_8_tiplproddsc2, lV74Configuracion_listaprecioswwds_9_tipldsc2, lV74Configuracion_listaprecioswwds_9_tipldsc2, lV78Configuracion_listaprecioswwds_13_tiplproddsc3, lV78Configuracion_listaprecioswwds_13_tiplproddsc3, lV79Configuracion_listaprecioswwds_14_tipldsc3, lV79Configuracion_listaprecioswwds_14_tipldsc3, lV80Configuracion_listaprecioswwds_15_tftipldsc, AV81Configuracion_listaprecioswwds_16_tftipldsc_sel, lV82Configuracion_listaprecioswwds_17_tfprodcod, AV83Configuracion_listaprecioswwds_18_tfprodcod_sel, lV84Configuracion_listaprecioswwds_19_tftiplproddsc, AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel, lV86Configuracion_listaprecioswwds_21_tfclicod, AV87Configuracion_listaprecioswwds_22_tfclicod_sel, AV88Configuracion_listaprecioswwds_23_tfprelis, AV89Configuracion_listaprecioswwds_24_tfprelis_to, AV90Configuracion_listaprecioswwds_25_tflisfech, AV91Configuracion_listaprecioswwds_26_tflisfech_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK4I6 = false;
            A202TipLCod = P004I4_A202TipLCod[0];
            A1913TipLProdDsc = P004I4_A1913TipLProdDsc[0];
            A1205LisFech = P004I4_A1205LisFech[0];
            A1651PreLis = P004I4_A1651PreLis[0];
            A45CliCod = P004I4_A45CliCod[0];
            n45CliCod = P004I4_n45CliCod[0];
            A28ProdCod = P004I4_A28ProdCod[0];
            A1912TipLDsc = P004I4_A1912TipLDsc[0];
            A203TipLItem = P004I4_A203TipLItem[0];
            A1912TipLDsc = P004I4_A1912TipLDsc[0];
            AV42count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P004I4_A1913TipLProdDsc[0], A1913TipLProdDsc) == 0 ) )
            {
               BRK4I6 = false;
               A202TipLCod = P004I4_A202TipLCod[0];
               A203TipLItem = P004I4_A203TipLItem[0];
               AV42count = (long)(AV42count+1);
               BRK4I6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1913TipLProdDsc)) )
            {
               AV34Option = A1913TipLProdDsc;
               AV35Options.Add(AV34Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV42count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV35Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK4I6 )
            {
               BRK4I6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADCLICODOPTIONS' Routine */
         returnInSub = false;
         AV22TFCliCod = AV30SearchTxt;
         AV23TFCliCod_Sel = "";
         AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV68Configuracion_listaprecioswwds_3_tiplproddsc1 = AV50TipLProdDsc1;
         AV69Configuracion_listaprecioswwds_4_tipldsc1 = AV51TipLDsc1;
         AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV73Configuracion_listaprecioswwds_8_tiplproddsc2 = AV55TipLProdDsc2;
         AV74Configuracion_listaprecioswwds_9_tipldsc2 = AV56TipLDsc2;
         AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV78Configuracion_listaprecioswwds_13_tiplproddsc3 = AV60TipLProdDsc3;
         AV79Configuracion_listaprecioswwds_14_tipldsc3 = AV61TipLDsc3;
         AV80Configuracion_listaprecioswwds_15_tftipldsc = AV18TFTipLDsc;
         AV81Configuracion_listaprecioswwds_16_tftipldsc_sel = AV19TFTipLDsc_Sel;
         AV82Configuracion_listaprecioswwds_17_tfprodcod = AV14TFProdCod;
         AV83Configuracion_listaprecioswwds_18_tfprodcod_sel = AV15TFProdCod_Sel;
         AV84Configuracion_listaprecioswwds_19_tftiplproddsc = AV16TFTipLProdDsc;
         AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel = AV17TFTipLProdDsc_Sel;
         AV86Configuracion_listaprecioswwds_21_tfclicod = AV22TFCliCod;
         AV87Configuracion_listaprecioswwds_22_tfclicod_sel = AV23TFCliCod_Sel;
         AV88Configuracion_listaprecioswwds_23_tfprelis = AV20TFPreLis;
         AV89Configuracion_listaprecioswwds_24_tfprelis_to = AV21TFPreLis_To;
         AV90Configuracion_listaprecioswwds_25_tflisfech = AV26TFLisFech;
         AV91Configuracion_listaprecioswwds_26_tflisfech_to = AV27TFLisFech_To;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                              AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                              AV68Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                              AV69Configuracion_listaprecioswwds_4_tipldsc1 ,
                                              AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                              AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                              AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                              AV73Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                              AV74Configuracion_listaprecioswwds_9_tipldsc2 ,
                                              AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                              AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                              AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                              AV78Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                              AV79Configuracion_listaprecioswwds_14_tipldsc3 ,
                                              AV81Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                              AV80Configuracion_listaprecioswwds_15_tftipldsc ,
                                              AV83Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                              AV82Configuracion_listaprecioswwds_17_tfprodcod ,
                                              AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                              AV84Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                              AV87Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                              AV86Configuracion_listaprecioswwds_21_tfclicod ,
                                              AV88Configuracion_listaprecioswwds_23_tfprelis ,
                                              AV89Configuracion_listaprecioswwds_24_tfprelis_to ,
                                              AV90Configuracion_listaprecioswwds_25_tflisfech ,
                                              AV91Configuracion_listaprecioswwds_26_tflisfech_to ,
                                              A1913TipLProdDsc ,
                                              A1912TipLDsc ,
                                              A28ProdCod ,
                                              A45CliCod ,
                                              A1651PreLis ,
                                              A1205LisFech } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.DECIMAL, TypeConstants.DATE
                                              }
         });
         lV68Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
         lV68Configuracion_listaprecioswwds_3_tiplproddsc1 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1), 100, "%");
         lV69Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
         lV69Configuracion_listaprecioswwds_4_tipldsc1 = StringUtil.PadR( StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1), 100, "%");
         lV73Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
         lV73Configuracion_listaprecioswwds_8_tiplproddsc2 = StringUtil.PadR( StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2), 100, "%");
         lV74Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
         lV74Configuracion_listaprecioswwds_9_tipldsc2 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2), 100, "%");
         lV78Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
         lV78Configuracion_listaprecioswwds_13_tiplproddsc3 = StringUtil.PadR( StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3), 100, "%");
         lV79Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
         lV79Configuracion_listaprecioswwds_14_tipldsc3 = StringUtil.PadR( StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3), 100, "%");
         lV80Configuracion_listaprecioswwds_15_tftipldsc = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_listaprecioswwds_15_tftipldsc), 100, "%");
         lV82Configuracion_listaprecioswwds_17_tfprodcod = StringUtil.PadR( StringUtil.RTrim( AV82Configuracion_listaprecioswwds_17_tfprodcod), 15, "%");
         lV84Configuracion_listaprecioswwds_19_tftiplproddsc = StringUtil.PadR( StringUtil.RTrim( AV84Configuracion_listaprecioswwds_19_tftiplproddsc), 100, "%");
         lV86Configuracion_listaprecioswwds_21_tfclicod = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_listaprecioswwds_21_tfclicod), 20, "%");
         /* Using cursor P004I5 */
         pr_default.execute(3, new Object[] {lV68Configuracion_listaprecioswwds_3_tiplproddsc1, lV68Configuracion_listaprecioswwds_3_tiplproddsc1, lV69Configuracion_listaprecioswwds_4_tipldsc1, lV69Configuracion_listaprecioswwds_4_tipldsc1, lV73Configuracion_listaprecioswwds_8_tiplproddsc2, lV73Configuracion_listaprecioswwds_8_tiplproddsc2, lV74Configuracion_listaprecioswwds_9_tipldsc2, lV74Configuracion_listaprecioswwds_9_tipldsc2, lV78Configuracion_listaprecioswwds_13_tiplproddsc3, lV78Configuracion_listaprecioswwds_13_tiplproddsc3, lV79Configuracion_listaprecioswwds_14_tipldsc3, lV79Configuracion_listaprecioswwds_14_tipldsc3, lV80Configuracion_listaprecioswwds_15_tftipldsc, AV81Configuracion_listaprecioswwds_16_tftipldsc_sel, lV82Configuracion_listaprecioswwds_17_tfprodcod, AV83Configuracion_listaprecioswwds_18_tfprodcod_sel, lV84Configuracion_listaprecioswwds_19_tftiplproddsc, AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel, lV86Configuracion_listaprecioswwds_21_tfclicod, AV87Configuracion_listaprecioswwds_22_tfclicod_sel, AV88Configuracion_listaprecioswwds_23_tfprelis, AV89Configuracion_listaprecioswwds_24_tfprelis_to, AV90Configuracion_listaprecioswwds_25_tflisfech, AV91Configuracion_listaprecioswwds_26_tflisfech_to});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK4I8 = false;
            A202TipLCod = P004I5_A202TipLCod[0];
            A45CliCod = P004I5_A45CliCod[0];
            n45CliCod = P004I5_n45CliCod[0];
            A1205LisFech = P004I5_A1205LisFech[0];
            A1651PreLis = P004I5_A1651PreLis[0];
            A28ProdCod = P004I5_A28ProdCod[0];
            A1912TipLDsc = P004I5_A1912TipLDsc[0];
            A1913TipLProdDsc = P004I5_A1913TipLProdDsc[0];
            A203TipLItem = P004I5_A203TipLItem[0];
            A1912TipLDsc = P004I5_A1912TipLDsc[0];
            AV42count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P004I5_A45CliCod[0], A45CliCod) == 0 ) )
            {
               BRK4I8 = false;
               A202TipLCod = P004I5_A202TipLCod[0];
               A203TipLItem = P004I5_A203TipLItem[0];
               AV42count = (long)(AV42count+1);
               BRK4I8 = true;
               pr_default.readNext(3);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A45CliCod)) )
            {
               AV34Option = A45CliCod;
               AV35Options.Add(AV34Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV42count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV35Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK4I8 )
            {
               BRK4I8 = true;
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
         AV36OptionsJson = "";
         AV39OptionsDescJson = "";
         AV41OptionIndexesJson = "";
         AV35Options = new GxSimpleCollection<string>();
         AV38OptionsDesc = new GxSimpleCollection<string>();
         AV40OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV43Session = context.GetSession();
         AV45GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV46GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV18TFTipLDsc = "";
         AV19TFTipLDsc_Sel = "";
         AV14TFProdCod = "";
         AV15TFProdCod_Sel = "";
         AV16TFTipLProdDsc = "";
         AV17TFTipLProdDsc_Sel = "";
         AV22TFCliCod = "";
         AV23TFCliCod_Sel = "";
         AV26TFLisFech = DateTime.MinValue;
         AV27TFLisFech_To = DateTime.MinValue;
         AV47GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV48DynamicFiltersSelector1 = "";
         AV50TipLProdDsc1 = "";
         AV51TipLDsc1 = "";
         AV53DynamicFiltersSelector2 = "";
         AV55TipLProdDsc2 = "";
         AV56TipLDsc2 = "";
         AV58DynamicFiltersSelector3 = "";
         AV60TipLProdDsc3 = "";
         AV61TipLDsc3 = "";
         AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1 = "";
         AV68Configuracion_listaprecioswwds_3_tiplproddsc1 = "";
         AV69Configuracion_listaprecioswwds_4_tipldsc1 = "";
         AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2 = "";
         AV73Configuracion_listaprecioswwds_8_tiplproddsc2 = "";
         AV74Configuracion_listaprecioswwds_9_tipldsc2 = "";
         AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3 = "";
         AV78Configuracion_listaprecioswwds_13_tiplproddsc3 = "";
         AV79Configuracion_listaprecioswwds_14_tipldsc3 = "";
         AV80Configuracion_listaprecioswwds_15_tftipldsc = "";
         AV81Configuracion_listaprecioswwds_16_tftipldsc_sel = "";
         AV82Configuracion_listaprecioswwds_17_tfprodcod = "";
         AV83Configuracion_listaprecioswwds_18_tfprodcod_sel = "";
         AV84Configuracion_listaprecioswwds_19_tftiplproddsc = "";
         AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel = "";
         AV86Configuracion_listaprecioswwds_21_tfclicod = "";
         AV87Configuracion_listaprecioswwds_22_tfclicod_sel = "";
         AV90Configuracion_listaprecioswwds_25_tflisfech = DateTime.MinValue;
         AV91Configuracion_listaprecioswwds_26_tflisfech_to = DateTime.MinValue;
         scmdbuf = "";
         lV68Configuracion_listaprecioswwds_3_tiplproddsc1 = "";
         lV69Configuracion_listaprecioswwds_4_tipldsc1 = "";
         lV73Configuracion_listaprecioswwds_8_tiplproddsc2 = "";
         lV74Configuracion_listaprecioswwds_9_tipldsc2 = "";
         lV78Configuracion_listaprecioswwds_13_tiplproddsc3 = "";
         lV79Configuracion_listaprecioswwds_14_tipldsc3 = "";
         lV80Configuracion_listaprecioswwds_15_tftipldsc = "";
         lV82Configuracion_listaprecioswwds_17_tfprodcod = "";
         lV84Configuracion_listaprecioswwds_19_tftiplproddsc = "";
         lV86Configuracion_listaprecioswwds_21_tfclicod = "";
         A1913TipLProdDsc = "";
         A1912TipLDsc = "";
         A28ProdCod = "";
         A45CliCod = "";
         A1205LisFech = DateTime.MinValue;
         P004I2_A202TipLCod = new int[1] ;
         P004I2_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         P004I2_A1651PreLis = new decimal[1] ;
         P004I2_A45CliCod = new string[] {""} ;
         P004I2_n45CliCod = new bool[] {false} ;
         P004I2_A28ProdCod = new string[] {""} ;
         P004I2_A1912TipLDsc = new string[] {""} ;
         P004I2_A1913TipLProdDsc = new string[] {""} ;
         P004I2_A203TipLItem = new int[1] ;
         AV34Option = "";
         P004I3_A202TipLCod = new int[1] ;
         P004I3_A28ProdCod = new string[] {""} ;
         P004I3_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         P004I3_A1651PreLis = new decimal[1] ;
         P004I3_A45CliCod = new string[] {""} ;
         P004I3_n45CliCod = new bool[] {false} ;
         P004I3_A1912TipLDsc = new string[] {""} ;
         P004I3_A1913TipLProdDsc = new string[] {""} ;
         P004I3_A203TipLItem = new int[1] ;
         AV37OptionDesc = "";
         P004I4_A202TipLCod = new int[1] ;
         P004I4_A1913TipLProdDsc = new string[] {""} ;
         P004I4_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         P004I4_A1651PreLis = new decimal[1] ;
         P004I4_A45CliCod = new string[] {""} ;
         P004I4_n45CliCod = new bool[] {false} ;
         P004I4_A28ProdCod = new string[] {""} ;
         P004I4_A1912TipLDsc = new string[] {""} ;
         P004I4_A203TipLItem = new int[1] ;
         P004I5_A202TipLCod = new int[1] ;
         P004I5_A45CliCod = new string[] {""} ;
         P004I5_n45CliCod = new bool[] {false} ;
         P004I5_A1205LisFech = new DateTime[] {DateTime.MinValue} ;
         P004I5_A1651PreLis = new decimal[1] ;
         P004I5_A28ProdCod = new string[] {""} ;
         P004I5_A1912TipLDsc = new string[] {""} ;
         P004I5_A1913TipLProdDsc = new string[] {""} ;
         P004I5_A203TipLItem = new int[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.listaprecioswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004I2_A202TipLCod, P004I2_A1205LisFech, P004I2_A1651PreLis, P004I2_A45CliCod, P004I2_n45CliCod, P004I2_A28ProdCod, P004I2_A1912TipLDsc, P004I2_A1913TipLProdDsc, P004I2_A203TipLItem
               }
               , new Object[] {
               P004I3_A202TipLCod, P004I3_A28ProdCod, P004I3_A1205LisFech, P004I3_A1651PreLis, P004I3_A45CliCod, P004I3_n45CliCod, P004I3_A1912TipLDsc, P004I3_A1913TipLProdDsc, P004I3_A203TipLItem
               }
               , new Object[] {
               P004I4_A202TipLCod, P004I4_A1913TipLProdDsc, P004I4_A1205LisFech, P004I4_A1651PreLis, P004I4_A45CliCod, P004I4_n45CliCod, P004I4_A28ProdCod, P004I4_A1912TipLDsc, P004I4_A203TipLItem
               }
               , new Object[] {
               P004I5_A202TipLCod, P004I5_A45CliCod, P004I5_n45CliCod, P004I5_A1205LisFech, P004I5_A1651PreLis, P004I5_A28ProdCod, P004I5_A1912TipLDsc, P004I5_A1913TipLProdDsc, P004I5_A203TipLItem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV49DynamicFiltersOperator1 ;
      private short AV54DynamicFiltersOperator2 ;
      private short AV59DynamicFiltersOperator3 ;
      private short AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ;
      private short AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ;
      private short AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ;
      private int AV64GXV1 ;
      private int A202TipLCod ;
      private int A203TipLItem ;
      private int AV33InsertIndex ;
      private long AV42count ;
      private decimal AV20TFPreLis ;
      private decimal AV21TFPreLis_To ;
      private decimal AV88Configuracion_listaprecioswwds_23_tfprelis ;
      private decimal AV89Configuracion_listaprecioswwds_24_tfprelis_to ;
      private decimal A1651PreLis ;
      private string AV18TFTipLDsc ;
      private string AV19TFTipLDsc_Sel ;
      private string AV14TFProdCod ;
      private string AV15TFProdCod_Sel ;
      private string AV16TFTipLProdDsc ;
      private string AV17TFTipLProdDsc_Sel ;
      private string AV22TFCliCod ;
      private string AV23TFCliCod_Sel ;
      private string AV50TipLProdDsc1 ;
      private string AV51TipLDsc1 ;
      private string AV55TipLProdDsc2 ;
      private string AV56TipLDsc2 ;
      private string AV60TipLProdDsc3 ;
      private string AV61TipLDsc3 ;
      private string AV68Configuracion_listaprecioswwds_3_tiplproddsc1 ;
      private string AV69Configuracion_listaprecioswwds_4_tipldsc1 ;
      private string AV73Configuracion_listaprecioswwds_8_tiplproddsc2 ;
      private string AV74Configuracion_listaprecioswwds_9_tipldsc2 ;
      private string AV78Configuracion_listaprecioswwds_13_tiplproddsc3 ;
      private string AV79Configuracion_listaprecioswwds_14_tipldsc3 ;
      private string AV80Configuracion_listaprecioswwds_15_tftipldsc ;
      private string AV81Configuracion_listaprecioswwds_16_tftipldsc_sel ;
      private string AV82Configuracion_listaprecioswwds_17_tfprodcod ;
      private string AV83Configuracion_listaprecioswwds_18_tfprodcod_sel ;
      private string AV84Configuracion_listaprecioswwds_19_tftiplproddsc ;
      private string AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel ;
      private string AV86Configuracion_listaprecioswwds_21_tfclicod ;
      private string AV87Configuracion_listaprecioswwds_22_tfclicod_sel ;
      private string scmdbuf ;
      private string lV68Configuracion_listaprecioswwds_3_tiplproddsc1 ;
      private string lV69Configuracion_listaprecioswwds_4_tipldsc1 ;
      private string lV73Configuracion_listaprecioswwds_8_tiplproddsc2 ;
      private string lV74Configuracion_listaprecioswwds_9_tipldsc2 ;
      private string lV78Configuracion_listaprecioswwds_13_tiplproddsc3 ;
      private string lV79Configuracion_listaprecioswwds_14_tipldsc3 ;
      private string lV80Configuracion_listaprecioswwds_15_tftipldsc ;
      private string lV82Configuracion_listaprecioswwds_17_tfprodcod ;
      private string lV84Configuracion_listaprecioswwds_19_tftiplproddsc ;
      private string lV86Configuracion_listaprecioswwds_21_tfclicod ;
      private string A1913TipLProdDsc ;
      private string A1912TipLDsc ;
      private string A28ProdCod ;
      private string A45CliCod ;
      private DateTime AV26TFLisFech ;
      private DateTime AV27TFLisFech_To ;
      private DateTime AV90Configuracion_listaprecioswwds_25_tflisfech ;
      private DateTime AV91Configuracion_listaprecioswwds_26_tflisfech_to ;
      private DateTime A1205LisFech ;
      private bool returnInSub ;
      private bool AV52DynamicFiltersEnabled2 ;
      private bool AV57DynamicFiltersEnabled3 ;
      private bool AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ;
      private bool AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ;
      private bool BRK4I2 ;
      private bool n45CliCod ;
      private bool BRK4I4 ;
      private bool BRK4I6 ;
      private bool BRK4I8 ;
      private string AV36OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV41OptionIndexesJson ;
      private string AV32DDOName ;
      private string AV30SearchTxt ;
      private string AV31SearchTxtTo ;
      private string AV48DynamicFiltersSelector1 ;
      private string AV53DynamicFiltersSelector2 ;
      private string AV58DynamicFiltersSelector3 ;
      private string AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ;
      private string AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ;
      private string AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ;
      private string AV34Option ;
      private string AV37OptionDesc ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P004I2_A202TipLCod ;
      private DateTime[] P004I2_A1205LisFech ;
      private decimal[] P004I2_A1651PreLis ;
      private string[] P004I2_A45CliCod ;
      private bool[] P004I2_n45CliCod ;
      private string[] P004I2_A28ProdCod ;
      private string[] P004I2_A1912TipLDsc ;
      private string[] P004I2_A1913TipLProdDsc ;
      private int[] P004I2_A203TipLItem ;
      private int[] P004I3_A202TipLCod ;
      private string[] P004I3_A28ProdCod ;
      private DateTime[] P004I3_A1205LisFech ;
      private decimal[] P004I3_A1651PreLis ;
      private string[] P004I3_A45CliCod ;
      private bool[] P004I3_n45CliCod ;
      private string[] P004I3_A1912TipLDsc ;
      private string[] P004I3_A1913TipLProdDsc ;
      private int[] P004I3_A203TipLItem ;
      private int[] P004I4_A202TipLCod ;
      private string[] P004I4_A1913TipLProdDsc ;
      private DateTime[] P004I4_A1205LisFech ;
      private decimal[] P004I4_A1651PreLis ;
      private string[] P004I4_A45CliCod ;
      private bool[] P004I4_n45CliCod ;
      private string[] P004I4_A28ProdCod ;
      private string[] P004I4_A1912TipLDsc ;
      private int[] P004I4_A203TipLItem ;
      private int[] P004I5_A202TipLCod ;
      private string[] P004I5_A45CliCod ;
      private bool[] P004I5_n45CliCod ;
      private DateTime[] P004I5_A1205LisFech ;
      private decimal[] P004I5_A1651PreLis ;
      private string[] P004I5_A28ProdCod ;
      private string[] P004I5_A1912TipLDsc ;
      private string[] P004I5_A1913TipLProdDsc ;
      private int[] P004I5_A203TipLItem ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV35Options ;
      private GxSimpleCollection<string> AV38OptionsDesc ;
      private GxSimpleCollection<string> AV40OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV45GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV46GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV47GridStateDynamicFilter ;
   }

   public class listaprecioswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004I2( IGxContext context ,
                                             string AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                             short AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                             string AV68Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                             string AV69Configuracion_listaprecioswwds_4_tipldsc1 ,
                                             bool AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                             string AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                             short AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                             string AV73Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                             string AV74Configuracion_listaprecioswwds_9_tipldsc2 ,
                                             bool AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                             string AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                             short AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                             string AV78Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                             string AV79Configuracion_listaprecioswwds_14_tipldsc3 ,
                                             string AV81Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                             string AV80Configuracion_listaprecioswwds_15_tftipldsc ,
                                             string AV83Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                             string AV82Configuracion_listaprecioswwds_17_tfprodcod ,
                                             string AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                             string AV84Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                             string AV87Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                             string AV86Configuracion_listaprecioswwds_21_tfclicod ,
                                             decimal AV88Configuracion_listaprecioswwds_23_tfprelis ,
                                             decimal AV89Configuracion_listaprecioswwds_24_tfprelis_to ,
                                             DateTime AV90Configuracion_listaprecioswwds_25_tflisfech ,
                                             DateTime AV91Configuracion_listaprecioswwds_26_tflisfech_to ,
                                             string A1913TipLProdDsc ,
                                             string A1912TipLDsc ,
                                             string A28ProdCod ,
                                             string A45CliCod ,
                                             decimal A1651PreLis ,
                                             DateTime A1205LisFech )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[24];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[TipLCod], T1.[LisFech], T1.[PreLis], T1.[CliCod], T1.[ProdCod], T2.[TipLDsc], T1.[TipLProdDsc], T1.[TipLItem] FROM ([CLISTAPRECIOS] T1 INNER JOIN [CTIPOSLISTAS] T2 ON T2.[TipLCod] = T1.[TipLCod])";
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV68Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV68Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV69Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV69Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV73Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV73Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV74Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV74Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV78Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV78Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV79Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV79Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_listaprecioswwds_16_tftipldsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_listaprecioswwds_15_tftipldsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV80Configuracion_listaprecioswwds_15_tftipldsc)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_listaprecioswwds_16_tftipldsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] = @AV81Configuracion_listaprecioswwds_16_tftipldsc_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_listaprecioswwds_18_tfprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_listaprecioswwds_17_tfprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV82Configuracion_listaprecioswwds_17_tfprodcod)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_listaprecioswwds_18_tfprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV83Configuracion_listaprecioswwds_18_tfprodcod_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_listaprecioswwds_19_tftiplproddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV84Configuracion_listaprecioswwds_19_tftiplproddsc)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] = @AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_listaprecioswwds_22_tfclicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_listaprecioswwds_21_tfclicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] like @lV86Configuracion_listaprecioswwds_21_tfclicod)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_listaprecioswwds_22_tfclicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV87Configuracion_listaprecioswwds_22_tfclicod_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Configuracion_listaprecioswwds_23_tfprelis) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] >= @AV88Configuracion_listaprecioswwds_23_tfprelis)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV89Configuracion_listaprecioswwds_24_tfprelis_to) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] <= @AV89Configuracion_listaprecioswwds_24_tfprelis_to)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV90Configuracion_listaprecioswwds_25_tflisfech) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] >= @AV90Configuracion_listaprecioswwds_25_tflisfech)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV91Configuracion_listaprecioswwds_26_tflisfech_to) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] <= @AV91Configuracion_listaprecioswwds_26_tflisfech_to)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipLCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P004I3( IGxContext context ,
                                             string AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                             short AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                             string AV68Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                             string AV69Configuracion_listaprecioswwds_4_tipldsc1 ,
                                             bool AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                             string AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                             short AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                             string AV73Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                             string AV74Configuracion_listaprecioswwds_9_tipldsc2 ,
                                             bool AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                             string AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                             short AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                             string AV78Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                             string AV79Configuracion_listaprecioswwds_14_tipldsc3 ,
                                             string AV81Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                             string AV80Configuracion_listaprecioswwds_15_tftipldsc ,
                                             string AV83Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                             string AV82Configuracion_listaprecioswwds_17_tfprodcod ,
                                             string AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                             string AV84Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                             string AV87Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                             string AV86Configuracion_listaprecioswwds_21_tfclicod ,
                                             decimal AV88Configuracion_listaprecioswwds_23_tfprelis ,
                                             decimal AV89Configuracion_listaprecioswwds_24_tfprelis_to ,
                                             DateTime AV90Configuracion_listaprecioswwds_25_tflisfech ,
                                             DateTime AV91Configuracion_listaprecioswwds_26_tflisfech_to ,
                                             string A1913TipLProdDsc ,
                                             string A1912TipLDsc ,
                                             string A28ProdCod ,
                                             string A45CliCod ,
                                             decimal A1651PreLis ,
                                             DateTime A1205LisFech )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[24];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[TipLCod], T1.[ProdCod], T1.[LisFech], T1.[PreLis], T1.[CliCod], T2.[TipLDsc], T1.[TipLProdDsc], T1.[TipLItem] FROM ([CLISTAPRECIOS] T1 INNER JOIN [CTIPOSLISTAS] T2 ON T2.[TipLCod] = T1.[TipLCod])";
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV68Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV68Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV69Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV69Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV73Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV73Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV74Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV74Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV78Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV78Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV79Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV79Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_listaprecioswwds_16_tftipldsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_listaprecioswwds_15_tftipldsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV80Configuracion_listaprecioswwds_15_tftipldsc)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_listaprecioswwds_16_tftipldsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] = @AV81Configuracion_listaprecioswwds_16_tftipldsc_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_listaprecioswwds_18_tfprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_listaprecioswwds_17_tfprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV82Configuracion_listaprecioswwds_17_tfprodcod)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_listaprecioswwds_18_tfprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV83Configuracion_listaprecioswwds_18_tfprodcod_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_listaprecioswwds_19_tftiplproddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV84Configuracion_listaprecioswwds_19_tftiplproddsc)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] = @AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_listaprecioswwds_22_tfclicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_listaprecioswwds_21_tfclicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] like @lV86Configuracion_listaprecioswwds_21_tfclicod)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_listaprecioswwds_22_tfclicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV87Configuracion_listaprecioswwds_22_tfclicod_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Configuracion_listaprecioswwds_23_tfprelis) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] >= @AV88Configuracion_listaprecioswwds_23_tfprelis)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV89Configuracion_listaprecioswwds_24_tfprelis_to) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] <= @AV89Configuracion_listaprecioswwds_24_tfprelis_to)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV90Configuracion_listaprecioswwds_25_tflisfech) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] >= @AV90Configuracion_listaprecioswwds_25_tflisfech)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV91Configuracion_listaprecioswwds_26_tflisfech_to) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] <= @AV91Configuracion_listaprecioswwds_26_tflisfech_to)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProdCod]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P004I4( IGxContext context ,
                                             string AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                             short AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                             string AV68Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                             string AV69Configuracion_listaprecioswwds_4_tipldsc1 ,
                                             bool AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                             string AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                             short AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                             string AV73Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                             string AV74Configuracion_listaprecioswwds_9_tipldsc2 ,
                                             bool AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                             string AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                             short AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                             string AV78Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                             string AV79Configuracion_listaprecioswwds_14_tipldsc3 ,
                                             string AV81Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                             string AV80Configuracion_listaprecioswwds_15_tftipldsc ,
                                             string AV83Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                             string AV82Configuracion_listaprecioswwds_17_tfprodcod ,
                                             string AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                             string AV84Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                             string AV87Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                             string AV86Configuracion_listaprecioswwds_21_tfclicod ,
                                             decimal AV88Configuracion_listaprecioswwds_23_tfprelis ,
                                             decimal AV89Configuracion_listaprecioswwds_24_tfprelis_to ,
                                             DateTime AV90Configuracion_listaprecioswwds_25_tflisfech ,
                                             DateTime AV91Configuracion_listaprecioswwds_26_tflisfech_to ,
                                             string A1913TipLProdDsc ,
                                             string A1912TipLDsc ,
                                             string A28ProdCod ,
                                             string A45CliCod ,
                                             decimal A1651PreLis ,
                                             DateTime A1205LisFech )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[24];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[TipLCod], T1.[TipLProdDsc], T1.[LisFech], T1.[PreLis], T1.[CliCod], T1.[ProdCod], T2.[TipLDsc], T1.[TipLItem] FROM ([CLISTAPRECIOS] T1 INNER JOIN [CTIPOSLISTAS] T2 ON T2.[TipLCod] = T1.[TipLCod])";
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV68Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV68Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV69Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV69Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV73Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV73Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV74Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV74Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV78Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV78Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV79Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV79Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_listaprecioswwds_16_tftipldsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_listaprecioswwds_15_tftipldsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV80Configuracion_listaprecioswwds_15_tftipldsc)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_listaprecioswwds_16_tftipldsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] = @AV81Configuracion_listaprecioswwds_16_tftipldsc_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_listaprecioswwds_18_tfprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_listaprecioswwds_17_tfprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV82Configuracion_listaprecioswwds_17_tfprodcod)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_listaprecioswwds_18_tfprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV83Configuracion_listaprecioswwds_18_tfprodcod_sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_listaprecioswwds_19_tftiplproddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV84Configuracion_listaprecioswwds_19_tftiplproddsc)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] = @AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_listaprecioswwds_22_tfclicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_listaprecioswwds_21_tfclicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] like @lV86Configuracion_listaprecioswwds_21_tfclicod)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_listaprecioswwds_22_tfclicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV87Configuracion_listaprecioswwds_22_tfclicod_sel)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Configuracion_listaprecioswwds_23_tfprelis) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] >= @AV88Configuracion_listaprecioswwds_23_tfprelis)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV89Configuracion_listaprecioswwds_24_tfprelis_to) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] <= @AV89Configuracion_listaprecioswwds_24_tfprelis_to)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV90Configuracion_listaprecioswwds_25_tflisfech) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] >= @AV90Configuracion_listaprecioswwds_25_tflisfech)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV91Configuracion_listaprecioswwds_26_tflisfech_to) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] <= @AV91Configuracion_listaprecioswwds_26_tflisfech_to)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TipLProdDsc]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P004I5( IGxContext context ,
                                             string AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1 ,
                                             short AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 ,
                                             string AV68Configuracion_listaprecioswwds_3_tiplproddsc1 ,
                                             string AV69Configuracion_listaprecioswwds_4_tipldsc1 ,
                                             bool AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 ,
                                             string AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2 ,
                                             short AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 ,
                                             string AV73Configuracion_listaprecioswwds_8_tiplproddsc2 ,
                                             string AV74Configuracion_listaprecioswwds_9_tipldsc2 ,
                                             bool AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 ,
                                             string AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3 ,
                                             short AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 ,
                                             string AV78Configuracion_listaprecioswwds_13_tiplproddsc3 ,
                                             string AV79Configuracion_listaprecioswwds_14_tipldsc3 ,
                                             string AV81Configuracion_listaprecioswwds_16_tftipldsc_sel ,
                                             string AV80Configuracion_listaprecioswwds_15_tftipldsc ,
                                             string AV83Configuracion_listaprecioswwds_18_tfprodcod_sel ,
                                             string AV82Configuracion_listaprecioswwds_17_tfprodcod ,
                                             string AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel ,
                                             string AV84Configuracion_listaprecioswwds_19_tftiplproddsc ,
                                             string AV87Configuracion_listaprecioswwds_22_tfclicod_sel ,
                                             string AV86Configuracion_listaprecioswwds_21_tfclicod ,
                                             decimal AV88Configuracion_listaprecioswwds_23_tfprelis ,
                                             decimal AV89Configuracion_listaprecioswwds_24_tfprelis_to ,
                                             DateTime AV90Configuracion_listaprecioswwds_25_tflisfech ,
                                             DateTime AV91Configuracion_listaprecioswwds_26_tflisfech_to ,
                                             string A1913TipLProdDsc ,
                                             string A1912TipLDsc ,
                                             string A28ProdCod ,
                                             string A45CliCod ,
                                             decimal A1651PreLis ,
                                             DateTime A1205LisFech )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[24];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[TipLCod], T1.[CliCod], T1.[LisFech], T1.[PreLis], T1.[ProdCod], T2.[TipLDsc], T1.[TipLProdDsc], T1.[TipLItem] FROM ([CLISTAPRECIOS] T1 INNER JOIN [CTIPOSLISTAS] T2 ON T2.[TipLCod] = T1.[TipLCod])";
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV68Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLPRODDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_listaprecioswwds_3_tiplproddsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV68Configuracion_listaprecioswwds_3_tiplproddsc1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV69Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV66Configuracion_listaprecioswwds_1_dynamicfiltersselector1, "TIPLDSC") == 0 ) && ( AV67Configuracion_listaprecioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_listaprecioswwds_4_tipldsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV69Configuracion_listaprecioswwds_4_tipldsc1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV73Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLPRODDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_listaprecioswwds_8_tiplproddsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV73Configuracion_listaprecioswwds_8_tiplproddsc2)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV74Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV70Configuracion_listaprecioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Configuracion_listaprecioswwds_6_dynamicfiltersselector2, "TIPLDSC") == 0 ) && ( AV72Configuracion_listaprecioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_listaprecioswwds_9_tipldsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV74Configuracion_listaprecioswwds_9_tipldsc2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV78Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLPRODDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_listaprecioswwds_13_tiplproddsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like '%' + @lV78Configuracion_listaprecioswwds_13_tiplproddsc3)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV79Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV75Configuracion_listaprecioswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV76Configuracion_listaprecioswwds_11_dynamicfiltersselector3, "TIPLDSC") == 0 ) && ( AV77Configuracion_listaprecioswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configuracion_listaprecioswwds_14_tipldsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like '%' + @lV79Configuracion_listaprecioswwds_14_tipldsc3)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_listaprecioswwds_16_tftipldsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_listaprecioswwds_15_tftipldsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] like @lV80Configuracion_listaprecioswwds_15_tftipldsc)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_listaprecioswwds_16_tftipldsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TipLDsc] = @AV81Configuracion_listaprecioswwds_16_tftipldsc_sel)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_listaprecioswwds_18_tfprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configuracion_listaprecioswwds_17_tfprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] like @lV82Configuracion_listaprecioswwds_17_tfprodcod)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configuracion_listaprecioswwds_18_tfprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProdCod] = @AV83Configuracion_listaprecioswwds_18_tfprodcod_sel)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configuracion_listaprecioswwds_19_tftiplproddsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] like @lV84Configuracion_listaprecioswwds_19_tftiplproddsc)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[TipLProdDsc] = @AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_listaprecioswwds_22_tfclicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_listaprecioswwds_21_tfclicod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] like @lV86Configuracion_listaprecioswwds_21_tfclicod)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_listaprecioswwds_22_tfclicod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CliCod] = @AV87Configuracion_listaprecioswwds_22_tfclicod_sel)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV88Configuracion_listaprecioswwds_23_tfprelis) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] >= @AV88Configuracion_listaprecioswwds_23_tfprelis)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV89Configuracion_listaprecioswwds_24_tfprelis_to) )
         {
            AddWhere(sWhereString, "(T1.[PreLis] <= @AV89Configuracion_listaprecioswwds_24_tfprelis_to)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV90Configuracion_listaprecioswwds_25_tflisfech) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] >= @AV90Configuracion_listaprecioswwds_25_tflisfech)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV91Configuracion_listaprecioswwds_26_tflisfech_to) )
         {
            AddWhere(sWhereString, "(T1.[LisFech] <= @AV91Configuracion_listaprecioswwds_26_tflisfech_to)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CliCod]";
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
                     return conditional_P004I2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (DateTime)dynConstraints[31] );
               case 1 :
                     return conditional_P004I3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (DateTime)dynConstraints[31] );
               case 2 :
                     return conditional_P004I4(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (DateTime)dynConstraints[31] );
               case 3 :
                     return conditional_P004I5(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (DateTime)dynConstraints[31] );
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
          Object[] prmP004I2;
          prmP004I2 = new Object[] {
          new ParDef("@lV68Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_listaprecioswwds_15_tftipldsc",GXType.NChar,100,0) ,
          new ParDef("@AV81Configuracion_listaprecioswwds_16_tftipldsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_listaprecioswwds_17_tfprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV83Configuracion_listaprecioswwds_18_tfprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV84Configuracion_listaprecioswwds_19_tftiplproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV86Configuracion_listaprecioswwds_21_tfclicod",GXType.NChar,20,0) ,
          new ParDef("@AV87Configuracion_listaprecioswwds_22_tfclicod_sel",GXType.NChar,20,0) ,
          new ParDef("@AV88Configuracion_listaprecioswwds_23_tfprelis",GXType.Decimal,15,4) ,
          new ParDef("@AV89Configuracion_listaprecioswwds_24_tfprelis_to",GXType.Decimal,15,4) ,
          new ParDef("@AV90Configuracion_listaprecioswwds_25_tflisfech",GXType.Date,8,0) ,
          new ParDef("@AV91Configuracion_listaprecioswwds_26_tflisfech_to",GXType.Date,8,0)
          };
          Object[] prmP004I3;
          prmP004I3 = new Object[] {
          new ParDef("@lV68Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_listaprecioswwds_15_tftipldsc",GXType.NChar,100,0) ,
          new ParDef("@AV81Configuracion_listaprecioswwds_16_tftipldsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_listaprecioswwds_17_tfprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV83Configuracion_listaprecioswwds_18_tfprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV84Configuracion_listaprecioswwds_19_tftiplproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV86Configuracion_listaprecioswwds_21_tfclicod",GXType.NChar,20,0) ,
          new ParDef("@AV87Configuracion_listaprecioswwds_22_tfclicod_sel",GXType.NChar,20,0) ,
          new ParDef("@AV88Configuracion_listaprecioswwds_23_tfprelis",GXType.Decimal,15,4) ,
          new ParDef("@AV89Configuracion_listaprecioswwds_24_tfprelis_to",GXType.Decimal,15,4) ,
          new ParDef("@AV90Configuracion_listaprecioswwds_25_tflisfech",GXType.Date,8,0) ,
          new ParDef("@AV91Configuracion_listaprecioswwds_26_tflisfech_to",GXType.Date,8,0)
          };
          Object[] prmP004I4;
          prmP004I4 = new Object[] {
          new ParDef("@lV68Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_listaprecioswwds_15_tftipldsc",GXType.NChar,100,0) ,
          new ParDef("@AV81Configuracion_listaprecioswwds_16_tftipldsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_listaprecioswwds_17_tfprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV83Configuracion_listaprecioswwds_18_tfprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV84Configuracion_listaprecioswwds_19_tftiplproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV86Configuracion_listaprecioswwds_21_tfclicod",GXType.NChar,20,0) ,
          new ParDef("@AV87Configuracion_listaprecioswwds_22_tfclicod_sel",GXType.NChar,20,0) ,
          new ParDef("@AV88Configuracion_listaprecioswwds_23_tfprelis",GXType.Decimal,15,4) ,
          new ParDef("@AV89Configuracion_listaprecioswwds_24_tfprelis_to",GXType.Decimal,15,4) ,
          new ParDef("@AV90Configuracion_listaprecioswwds_25_tflisfech",GXType.Date,8,0) ,
          new ParDef("@AV91Configuracion_listaprecioswwds_26_tflisfech_to",GXType.Date,8,0)
          };
          Object[] prmP004I5;
          prmP004I5 = new Object[] {
          new ParDef("@lV68Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_listaprecioswwds_3_tiplproddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV69Configuracion_listaprecioswwds_4_tipldsc1",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV73Configuracion_listaprecioswwds_8_tiplproddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_listaprecioswwds_9_tipldsc2",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV78Configuracion_listaprecioswwds_13_tiplproddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV79Configuracion_listaprecioswwds_14_tipldsc3",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_listaprecioswwds_15_tftipldsc",GXType.NChar,100,0) ,
          new ParDef("@AV81Configuracion_listaprecioswwds_16_tftipldsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV82Configuracion_listaprecioswwds_17_tfprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV83Configuracion_listaprecioswwds_18_tfprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV84Configuracion_listaprecioswwds_19_tftiplproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV85Configuracion_listaprecioswwds_20_tftiplproddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV86Configuracion_listaprecioswwds_21_tfclicod",GXType.NChar,20,0) ,
          new ParDef("@AV87Configuracion_listaprecioswwds_22_tfclicod_sel",GXType.NChar,20,0) ,
          new ParDef("@AV88Configuracion_listaprecioswwds_23_tfprelis",GXType.Decimal,15,4) ,
          new ParDef("@AV89Configuracion_listaprecioswwds_24_tfprelis_to",GXType.Decimal,15,4) ,
          new ParDef("@AV90Configuracion_listaprecioswwds_25_tflisfech",GXType.Date,8,0) ,
          new ParDef("@AV91Configuracion_listaprecioswwds_26_tflisfech_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004I2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004I3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004I4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004I4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004I5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004I5,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 15);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 15);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((string[]) buf[7])[0] = rslt.getString(7, 100);
                ((int[]) buf[8])[0] = rslt.getInt(8);
                return;
       }
    }

 }

}
