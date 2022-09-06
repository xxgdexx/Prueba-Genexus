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
   public class tipodocumentowwgetfilterdata : GXProcedure
   {
      public tipodocumentowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipodocumentowwgetfilterdata( IGxContext context )
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
         tipodocumentowwgetfilterdata objtipodocumentowwgetfilterdata;
         objtipodocumentowwgetfilterdata = new tipodocumentowwgetfilterdata();
         objtipodocumentowwgetfilterdata.AV32DDOName = aP0_DDOName;
         objtipodocumentowwgetfilterdata.AV30SearchTxt = aP1_SearchTxt;
         objtipodocumentowwgetfilterdata.AV31SearchTxtTo = aP2_SearchTxtTo;
         objtipodocumentowwgetfilterdata.AV36OptionsJson = "" ;
         objtipodocumentowwgetfilterdata.AV39OptionsDescJson = "" ;
         objtipodocumentowwgetfilterdata.AV41OptionIndexesJson = "" ;
         objtipodocumentowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objtipodocumentowwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipodocumentowwgetfilterdata);
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV41OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipodocumentowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_TIPABR") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPABROPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV32DDOName), "DDO_TIPDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPDSCOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV43Session.Get("Configuracion.TipoDocumentoWWGridState"), "") == 0 )
         {
            AV45GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoDocumentoWWGridState"), null, "", "");
         }
         else
         {
            AV45GridState.FromXml(AV43Session.Get("Configuracion.TipoDocumentoWWGridState"), null, "", "");
         }
         AV71GXV1 = 1;
         while ( AV71GXV1 <= AV45GridState.gxTpr_Filtervalues.Count )
         {
            AV46GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV45GridState.gxTpr_Filtervalues.Item(AV71GXV1));
            if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTIPABR") == 0 )
            {
               AV14TFTipAbr = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTIPABR_SEL") == 0 )
            {
               AV15TFTipAbr_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTIPDSC") == 0 )
            {
               AV12TFTipDsc = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTIPDSC_SEL") == 0 )
            {
               AV13TFTipDsc_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTIPVTA_SEL") == 0 )
            {
               AV59TFTipVta_Sel = (short)(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTIPCMP_SEL") == 0 )
            {
               AV60TFTipCmp_Sel = (short)(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTIPRHO_SEL") == 0 )
            {
               AV61TFTipRHo_Sel = (short)(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTIPCXP_SEL") == 0 )
            {
               AV62TFTipCxP_Sel = (short)(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTIPBAN_SEL") == 0 )
            {
               AV63TFTipBan_Sel = (short)(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFTIPSTS_SEL") == 0 )
            {
               AV64TFTipSts_SelsJson = AV46GridStateFilterValue.gxTpr_Value;
               AV65TFTipSts_Sels.FromJSonString(AV64TFTipSts_SelsJson, null);
            }
            AV71GXV1 = (int)(AV71GXV1+1);
         }
         if ( AV45GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV47GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV45GridState.gxTpr_Dynamicfilters.Item(1));
            AV48DynamicFiltersSelector1 = AV47GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "TIPDSC") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV47GridStateDynamicFilter.gxTpr_Operator;
               AV50TipDsc1 = AV47GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "TIPABR") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV47GridStateDynamicFilter.gxTpr_Operator;
               AV66TipAbr1 = AV47GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV45GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV51DynamicFiltersEnabled2 = true;
               AV47GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV45GridState.gxTpr_Dynamicfilters.Item(2));
               AV52DynamicFiltersSelector2 = AV47GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "TIPDSC") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV47GridStateDynamicFilter.gxTpr_Operator;
                  AV54TipDsc2 = AV47GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "TIPABR") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV47GridStateDynamicFilter.gxTpr_Operator;
                  AV67TipAbr2 = AV47GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV45GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV55DynamicFiltersEnabled3 = true;
                  AV47GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV45GridState.gxTpr_Dynamicfilters.Item(3));
                  AV56DynamicFiltersSelector3 = AV47GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "TIPDSC") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV47GridStateDynamicFilter.gxTpr_Operator;
                     AV58TipDsc3 = AV47GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "TIPABR") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV47GridStateDynamicFilter.gxTpr_Operator;
                     AV68TipAbr3 = AV47GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTIPABROPTIONS' Routine */
         returnInSub = false;
         AV14TFTipAbr = AV30SearchTxt;
         AV15TFTipAbr_Sel = "";
         AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV74Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV75Configuracion_tipodocumentowwds_3_tipdsc1 = AV50TipDsc1;
         AV76Configuracion_tipodocumentowwds_4_tipabr1 = AV66TipAbr1;
         AV77Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 = AV51DynamicFiltersEnabled2;
         AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 = AV52DynamicFiltersSelector2;
         AV79Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 = AV53DynamicFiltersOperator2;
         AV80Configuracion_tipodocumentowwds_8_tipdsc2 = AV54TipDsc2;
         AV81Configuracion_tipodocumentowwds_9_tipabr2 = AV67TipAbr2;
         AV82Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV84Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV85Configuracion_tipodocumentowwds_13_tipdsc3 = AV58TipDsc3;
         AV86Configuracion_tipodocumentowwds_14_tipabr3 = AV68TipAbr3;
         AV87Configuracion_tipodocumentowwds_15_tftipabr = AV14TFTipAbr;
         AV88Configuracion_tipodocumentowwds_16_tftipabr_sel = AV15TFTipAbr_Sel;
         AV89Configuracion_tipodocumentowwds_17_tftipdsc = AV12TFTipDsc;
         AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel = AV13TFTipDsc_Sel;
         AV91Configuracion_tipodocumentowwds_19_tftipvta_sel = AV59TFTipVta_Sel;
         AV92Configuracion_tipodocumentowwds_20_tftipcmp_sel = AV60TFTipCmp_Sel;
         AV93Configuracion_tipodocumentowwds_21_tftiprho_sel = AV61TFTipRHo_Sel;
         AV94Configuracion_tipodocumentowwds_22_tftipcxp_sel = AV62TFTipCxP_Sel;
         AV95Configuracion_tipodocumentowwds_23_tftipban_sel = AV63TFTipBan_Sel;
         AV96Configuracion_tipodocumentowwds_24_tftipsts_sels = AV65TFTipSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1919TipSts ,
                                              AV96Configuracion_tipodocumentowwds_24_tftipsts_sels ,
                                              AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ,
                                              AV74Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ,
                                              AV75Configuracion_tipodocumentowwds_3_tipdsc1 ,
                                              AV76Configuracion_tipodocumentowwds_4_tipabr1 ,
                                              AV77Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ,
                                              AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ,
                                              AV79Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ,
                                              AV80Configuracion_tipodocumentowwds_8_tipdsc2 ,
                                              AV81Configuracion_tipodocumentowwds_9_tipabr2 ,
                                              AV82Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ,
                                              AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ,
                                              AV84Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ,
                                              AV85Configuracion_tipodocumentowwds_13_tipdsc3 ,
                                              AV86Configuracion_tipodocumentowwds_14_tipabr3 ,
                                              AV88Configuracion_tipodocumentowwds_16_tftipabr_sel ,
                                              AV87Configuracion_tipodocumentowwds_15_tftipabr ,
                                              AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel ,
                                              AV89Configuracion_tipodocumentowwds_17_tftipdsc ,
                                              AV91Configuracion_tipodocumentowwds_19_tftipvta_sel ,
                                              AV92Configuracion_tipodocumentowwds_20_tftipcmp_sel ,
                                              AV93Configuracion_tipodocumentowwds_21_tftiprho_sel ,
                                              AV94Configuracion_tipodocumentowwds_22_tftipcxp_sel ,
                                              AV95Configuracion_tipodocumentowwds_23_tftipban_sel ,
                                              AV96Configuracion_tipodocumentowwds_24_tftipsts_sels.Count ,
                                              A1910TipDsc ,
                                              A306TipAbr ,
                                              A1921TipVta ,
                                              A1906TipCmp ,
                                              A1915TipRHo ,
                                              A1909TipCxP ,
                                              A1903TipBan } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV75Configuracion_tipodocumentowwds_3_tipdsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_3_tipdsc1), 100, "%");
         lV75Configuracion_tipodocumentowwds_3_tipdsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_3_tipdsc1), 100, "%");
         lV76Configuracion_tipodocumentowwds_4_tipabr1 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_tipodocumentowwds_4_tipabr1), 5, "%");
         lV76Configuracion_tipodocumentowwds_4_tipabr1 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_tipodocumentowwds_4_tipabr1), 5, "%");
         lV80Configuracion_tipodocumentowwds_8_tipdsc2 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_8_tipdsc2), 100, "%");
         lV80Configuracion_tipodocumentowwds_8_tipdsc2 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_8_tipdsc2), 100, "%");
         lV81Configuracion_tipodocumentowwds_9_tipabr2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_tipodocumentowwds_9_tipabr2), 5, "%");
         lV81Configuracion_tipodocumentowwds_9_tipabr2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_tipodocumentowwds_9_tipabr2), 5, "%");
         lV85Configuracion_tipodocumentowwds_13_tipdsc3 = StringUtil.PadR( StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_13_tipdsc3), 100, "%");
         lV85Configuracion_tipodocumentowwds_13_tipdsc3 = StringUtil.PadR( StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_13_tipdsc3), 100, "%");
         lV86Configuracion_tipodocumentowwds_14_tipabr3 = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_tipodocumentowwds_14_tipabr3), 5, "%");
         lV86Configuracion_tipodocumentowwds_14_tipabr3 = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_tipodocumentowwds_14_tipabr3), 5, "%");
         lV87Configuracion_tipodocumentowwds_15_tftipabr = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_tipodocumentowwds_15_tftipabr), 5, "%");
         lV89Configuracion_tipodocumentowwds_17_tftipdsc = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_tipodocumentowwds_17_tftipdsc), 100, "%");
         /* Using cursor P00492 */
         pr_default.execute(0, new Object[] {lV75Configuracion_tipodocumentowwds_3_tipdsc1, lV75Configuracion_tipodocumentowwds_3_tipdsc1, lV76Configuracion_tipodocumentowwds_4_tipabr1, lV76Configuracion_tipodocumentowwds_4_tipabr1, lV80Configuracion_tipodocumentowwds_8_tipdsc2, lV80Configuracion_tipodocumentowwds_8_tipdsc2, lV81Configuracion_tipodocumentowwds_9_tipabr2, lV81Configuracion_tipodocumentowwds_9_tipabr2, lV85Configuracion_tipodocumentowwds_13_tipdsc3, lV85Configuracion_tipodocumentowwds_13_tipdsc3, lV86Configuracion_tipodocumentowwds_14_tipabr3, lV86Configuracion_tipodocumentowwds_14_tipabr3, lV87Configuracion_tipodocumentowwds_15_tftipabr, AV88Configuracion_tipodocumentowwds_16_tftipabr_sel, lV89Configuracion_tipodocumentowwds_17_tftipdsc, AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK492 = false;
            A306TipAbr = P00492_A306TipAbr[0];
            A1919TipSts = P00492_A1919TipSts[0];
            A1903TipBan = P00492_A1903TipBan[0];
            A1909TipCxP = P00492_A1909TipCxP[0];
            A1915TipRHo = P00492_A1915TipRHo[0];
            A1906TipCmp = P00492_A1906TipCmp[0];
            A1921TipVta = P00492_A1921TipVta[0];
            A1910TipDsc = P00492_A1910TipDsc[0];
            A149TipCod = P00492_A149TipCod[0];
            AV42count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00492_A306TipAbr[0], A306TipAbr) == 0 ) )
            {
               BRK492 = false;
               A149TipCod = P00492_A149TipCod[0];
               AV42count = (long)(AV42count+1);
               BRK492 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A306TipAbr)) )
            {
               AV34Option = A306TipAbr;
               AV35Options.Add(AV34Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV42count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV35Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK492 )
            {
               BRK492 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTIPDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFTipDsc = AV30SearchTxt;
         AV13TFTipDsc_Sel = "";
         AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV74Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV75Configuracion_tipodocumentowwds_3_tipdsc1 = AV50TipDsc1;
         AV76Configuracion_tipodocumentowwds_4_tipabr1 = AV66TipAbr1;
         AV77Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 = AV51DynamicFiltersEnabled2;
         AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 = AV52DynamicFiltersSelector2;
         AV79Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 = AV53DynamicFiltersOperator2;
         AV80Configuracion_tipodocumentowwds_8_tipdsc2 = AV54TipDsc2;
         AV81Configuracion_tipodocumentowwds_9_tipabr2 = AV67TipAbr2;
         AV82Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV84Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV85Configuracion_tipodocumentowwds_13_tipdsc3 = AV58TipDsc3;
         AV86Configuracion_tipodocumentowwds_14_tipabr3 = AV68TipAbr3;
         AV87Configuracion_tipodocumentowwds_15_tftipabr = AV14TFTipAbr;
         AV88Configuracion_tipodocumentowwds_16_tftipabr_sel = AV15TFTipAbr_Sel;
         AV89Configuracion_tipodocumentowwds_17_tftipdsc = AV12TFTipDsc;
         AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel = AV13TFTipDsc_Sel;
         AV91Configuracion_tipodocumentowwds_19_tftipvta_sel = AV59TFTipVta_Sel;
         AV92Configuracion_tipodocumentowwds_20_tftipcmp_sel = AV60TFTipCmp_Sel;
         AV93Configuracion_tipodocumentowwds_21_tftiprho_sel = AV61TFTipRHo_Sel;
         AV94Configuracion_tipodocumentowwds_22_tftipcxp_sel = AV62TFTipCxP_Sel;
         AV95Configuracion_tipodocumentowwds_23_tftipban_sel = AV63TFTipBan_Sel;
         AV96Configuracion_tipodocumentowwds_24_tftipsts_sels = AV65TFTipSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1919TipSts ,
                                              AV96Configuracion_tipodocumentowwds_24_tftipsts_sels ,
                                              AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ,
                                              AV74Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ,
                                              AV75Configuracion_tipodocumentowwds_3_tipdsc1 ,
                                              AV76Configuracion_tipodocumentowwds_4_tipabr1 ,
                                              AV77Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ,
                                              AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ,
                                              AV79Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ,
                                              AV80Configuracion_tipodocumentowwds_8_tipdsc2 ,
                                              AV81Configuracion_tipodocumentowwds_9_tipabr2 ,
                                              AV82Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ,
                                              AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ,
                                              AV84Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ,
                                              AV85Configuracion_tipodocumentowwds_13_tipdsc3 ,
                                              AV86Configuracion_tipodocumentowwds_14_tipabr3 ,
                                              AV88Configuracion_tipodocumentowwds_16_tftipabr_sel ,
                                              AV87Configuracion_tipodocumentowwds_15_tftipabr ,
                                              AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel ,
                                              AV89Configuracion_tipodocumentowwds_17_tftipdsc ,
                                              AV91Configuracion_tipodocumentowwds_19_tftipvta_sel ,
                                              AV92Configuracion_tipodocumentowwds_20_tftipcmp_sel ,
                                              AV93Configuracion_tipodocumentowwds_21_tftiprho_sel ,
                                              AV94Configuracion_tipodocumentowwds_22_tftipcxp_sel ,
                                              AV95Configuracion_tipodocumentowwds_23_tftipban_sel ,
                                              AV96Configuracion_tipodocumentowwds_24_tftipsts_sels.Count ,
                                              A1910TipDsc ,
                                              A306TipAbr ,
                                              A1921TipVta ,
                                              A1906TipCmp ,
                                              A1915TipRHo ,
                                              A1909TipCxP ,
                                              A1903TipBan } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV75Configuracion_tipodocumentowwds_3_tipdsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_3_tipdsc1), 100, "%");
         lV75Configuracion_tipodocumentowwds_3_tipdsc1 = StringUtil.PadR( StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_3_tipdsc1), 100, "%");
         lV76Configuracion_tipodocumentowwds_4_tipabr1 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_tipodocumentowwds_4_tipabr1), 5, "%");
         lV76Configuracion_tipodocumentowwds_4_tipabr1 = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_tipodocumentowwds_4_tipabr1), 5, "%");
         lV80Configuracion_tipodocumentowwds_8_tipdsc2 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_8_tipdsc2), 100, "%");
         lV80Configuracion_tipodocumentowwds_8_tipdsc2 = StringUtil.PadR( StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_8_tipdsc2), 100, "%");
         lV81Configuracion_tipodocumentowwds_9_tipabr2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_tipodocumentowwds_9_tipabr2), 5, "%");
         lV81Configuracion_tipodocumentowwds_9_tipabr2 = StringUtil.PadR( StringUtil.RTrim( AV81Configuracion_tipodocumentowwds_9_tipabr2), 5, "%");
         lV85Configuracion_tipodocumentowwds_13_tipdsc3 = StringUtil.PadR( StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_13_tipdsc3), 100, "%");
         lV85Configuracion_tipodocumentowwds_13_tipdsc3 = StringUtil.PadR( StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_13_tipdsc3), 100, "%");
         lV86Configuracion_tipodocumentowwds_14_tipabr3 = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_tipodocumentowwds_14_tipabr3), 5, "%");
         lV86Configuracion_tipodocumentowwds_14_tipabr3 = StringUtil.PadR( StringUtil.RTrim( AV86Configuracion_tipodocumentowwds_14_tipabr3), 5, "%");
         lV87Configuracion_tipodocumentowwds_15_tftipabr = StringUtil.PadR( StringUtil.RTrim( AV87Configuracion_tipodocumentowwds_15_tftipabr), 5, "%");
         lV89Configuracion_tipodocumentowwds_17_tftipdsc = StringUtil.PadR( StringUtil.RTrim( AV89Configuracion_tipodocumentowwds_17_tftipdsc), 100, "%");
         /* Using cursor P00493 */
         pr_default.execute(1, new Object[] {lV75Configuracion_tipodocumentowwds_3_tipdsc1, lV75Configuracion_tipodocumentowwds_3_tipdsc1, lV76Configuracion_tipodocumentowwds_4_tipabr1, lV76Configuracion_tipodocumentowwds_4_tipabr1, lV80Configuracion_tipodocumentowwds_8_tipdsc2, lV80Configuracion_tipodocumentowwds_8_tipdsc2, lV81Configuracion_tipodocumentowwds_9_tipabr2, lV81Configuracion_tipodocumentowwds_9_tipabr2, lV85Configuracion_tipodocumentowwds_13_tipdsc3, lV85Configuracion_tipodocumentowwds_13_tipdsc3, lV86Configuracion_tipodocumentowwds_14_tipabr3, lV86Configuracion_tipodocumentowwds_14_tipabr3, lV87Configuracion_tipodocumentowwds_15_tftipabr, AV88Configuracion_tipodocumentowwds_16_tftipabr_sel, lV89Configuracion_tipodocumentowwds_17_tftipdsc, AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK494 = false;
            A1910TipDsc = P00493_A1910TipDsc[0];
            A1919TipSts = P00493_A1919TipSts[0];
            A1903TipBan = P00493_A1903TipBan[0];
            A1909TipCxP = P00493_A1909TipCxP[0];
            A1915TipRHo = P00493_A1915TipRHo[0];
            A1906TipCmp = P00493_A1906TipCmp[0];
            A1921TipVta = P00493_A1921TipVta[0];
            A306TipAbr = P00493_A306TipAbr[0];
            A149TipCod = P00493_A149TipCod[0];
            AV42count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00493_A1910TipDsc[0], A1910TipDsc) == 0 ) )
            {
               BRK494 = false;
               A149TipCod = P00493_A149TipCod[0];
               AV42count = (long)(AV42count+1);
               BRK494 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1910TipDsc)) )
            {
               AV34Option = A1910TipDsc;
               AV35Options.Add(AV34Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV42count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV35Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK494 )
            {
               BRK494 = true;
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
         AV14TFTipAbr = "";
         AV15TFTipAbr_Sel = "";
         AV12TFTipDsc = "";
         AV13TFTipDsc_Sel = "";
         AV64TFTipSts_SelsJson = "";
         AV65TFTipSts_Sels = new GxSimpleCollection<short>();
         AV47GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV48DynamicFiltersSelector1 = "";
         AV50TipDsc1 = "";
         AV66TipAbr1 = "";
         AV52DynamicFiltersSelector2 = "";
         AV54TipDsc2 = "";
         AV67TipAbr2 = "";
         AV56DynamicFiltersSelector3 = "";
         AV58TipDsc3 = "";
         AV68TipAbr3 = "";
         AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 = "";
         AV75Configuracion_tipodocumentowwds_3_tipdsc1 = "";
         AV76Configuracion_tipodocumentowwds_4_tipabr1 = "";
         AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 = "";
         AV80Configuracion_tipodocumentowwds_8_tipdsc2 = "";
         AV81Configuracion_tipodocumentowwds_9_tipabr2 = "";
         AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 = "";
         AV85Configuracion_tipodocumentowwds_13_tipdsc3 = "";
         AV86Configuracion_tipodocumentowwds_14_tipabr3 = "";
         AV87Configuracion_tipodocumentowwds_15_tftipabr = "";
         AV88Configuracion_tipodocumentowwds_16_tftipabr_sel = "";
         AV89Configuracion_tipodocumentowwds_17_tftipdsc = "";
         AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel = "";
         AV96Configuracion_tipodocumentowwds_24_tftipsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV75Configuracion_tipodocumentowwds_3_tipdsc1 = "";
         lV76Configuracion_tipodocumentowwds_4_tipabr1 = "";
         lV80Configuracion_tipodocumentowwds_8_tipdsc2 = "";
         lV81Configuracion_tipodocumentowwds_9_tipabr2 = "";
         lV85Configuracion_tipodocumentowwds_13_tipdsc3 = "";
         lV86Configuracion_tipodocumentowwds_14_tipabr3 = "";
         lV87Configuracion_tipodocumentowwds_15_tftipabr = "";
         lV89Configuracion_tipodocumentowwds_17_tftipdsc = "";
         A1910TipDsc = "";
         A306TipAbr = "";
         P00492_A306TipAbr = new string[] {""} ;
         P00492_A1919TipSts = new short[1] ;
         P00492_A1903TipBan = new short[1] ;
         P00492_A1909TipCxP = new short[1] ;
         P00492_A1915TipRHo = new short[1] ;
         P00492_A1906TipCmp = new short[1] ;
         P00492_A1921TipVta = new short[1] ;
         P00492_A1910TipDsc = new string[] {""} ;
         P00492_A149TipCod = new string[] {""} ;
         A149TipCod = "";
         AV34Option = "";
         P00493_A1910TipDsc = new string[] {""} ;
         P00493_A1919TipSts = new short[1] ;
         P00493_A1903TipBan = new short[1] ;
         P00493_A1909TipCxP = new short[1] ;
         P00493_A1915TipRHo = new short[1] ;
         P00493_A1906TipCmp = new short[1] ;
         P00493_A1921TipVta = new short[1] ;
         P00493_A306TipAbr = new string[] {""} ;
         P00493_A149TipCod = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipodocumentowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00492_A306TipAbr, P00492_A1919TipSts, P00492_A1903TipBan, P00492_A1909TipCxP, P00492_A1915TipRHo, P00492_A1906TipCmp, P00492_A1921TipVta, P00492_A1910TipDsc, P00492_A149TipCod
               }
               , new Object[] {
               P00493_A1910TipDsc, P00493_A1919TipSts, P00493_A1903TipBan, P00493_A1909TipCxP, P00493_A1915TipRHo, P00493_A1906TipCmp, P00493_A1921TipVta, P00493_A306TipAbr, P00493_A149TipCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV59TFTipVta_Sel ;
      private short AV60TFTipCmp_Sel ;
      private short AV61TFTipRHo_Sel ;
      private short AV62TFTipCxP_Sel ;
      private short AV63TFTipBan_Sel ;
      private short AV49DynamicFiltersOperator1 ;
      private short AV53DynamicFiltersOperator2 ;
      private short AV57DynamicFiltersOperator3 ;
      private short AV74Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ;
      private short AV79Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ;
      private short AV84Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ;
      private short AV91Configuracion_tipodocumentowwds_19_tftipvta_sel ;
      private short AV92Configuracion_tipodocumentowwds_20_tftipcmp_sel ;
      private short AV93Configuracion_tipodocumentowwds_21_tftiprho_sel ;
      private short AV94Configuracion_tipodocumentowwds_22_tftipcxp_sel ;
      private short AV95Configuracion_tipodocumentowwds_23_tftipban_sel ;
      private short A1919TipSts ;
      private short A1921TipVta ;
      private short A1906TipCmp ;
      private short A1915TipRHo ;
      private short A1909TipCxP ;
      private short A1903TipBan ;
      private int AV71GXV1 ;
      private int AV96Configuracion_tipodocumentowwds_24_tftipsts_sels_Count ;
      private long AV42count ;
      private string AV14TFTipAbr ;
      private string AV15TFTipAbr_Sel ;
      private string AV12TFTipDsc ;
      private string AV13TFTipDsc_Sel ;
      private string AV50TipDsc1 ;
      private string AV66TipAbr1 ;
      private string AV54TipDsc2 ;
      private string AV67TipAbr2 ;
      private string AV58TipDsc3 ;
      private string AV68TipAbr3 ;
      private string AV75Configuracion_tipodocumentowwds_3_tipdsc1 ;
      private string AV76Configuracion_tipodocumentowwds_4_tipabr1 ;
      private string AV80Configuracion_tipodocumentowwds_8_tipdsc2 ;
      private string AV81Configuracion_tipodocumentowwds_9_tipabr2 ;
      private string AV85Configuracion_tipodocumentowwds_13_tipdsc3 ;
      private string AV86Configuracion_tipodocumentowwds_14_tipabr3 ;
      private string AV87Configuracion_tipodocumentowwds_15_tftipabr ;
      private string AV88Configuracion_tipodocumentowwds_16_tftipabr_sel ;
      private string AV89Configuracion_tipodocumentowwds_17_tftipdsc ;
      private string AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel ;
      private string scmdbuf ;
      private string lV75Configuracion_tipodocumentowwds_3_tipdsc1 ;
      private string lV76Configuracion_tipodocumentowwds_4_tipabr1 ;
      private string lV80Configuracion_tipodocumentowwds_8_tipdsc2 ;
      private string lV81Configuracion_tipodocumentowwds_9_tipabr2 ;
      private string lV85Configuracion_tipodocumentowwds_13_tipdsc3 ;
      private string lV86Configuracion_tipodocumentowwds_14_tipabr3 ;
      private string lV87Configuracion_tipodocumentowwds_15_tftipabr ;
      private string lV89Configuracion_tipodocumentowwds_17_tftipdsc ;
      private string A1910TipDsc ;
      private string A306TipAbr ;
      private string A149TipCod ;
      private bool returnInSub ;
      private bool AV51DynamicFiltersEnabled2 ;
      private bool AV55DynamicFiltersEnabled3 ;
      private bool AV77Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ;
      private bool AV82Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ;
      private bool BRK492 ;
      private bool BRK494 ;
      private string AV36OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV41OptionIndexesJson ;
      private string AV64TFTipSts_SelsJson ;
      private string AV32DDOName ;
      private string AV30SearchTxt ;
      private string AV31SearchTxtTo ;
      private string AV48DynamicFiltersSelector1 ;
      private string AV52DynamicFiltersSelector2 ;
      private string AV56DynamicFiltersSelector3 ;
      private string AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ;
      private string AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ;
      private string AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ;
      private string AV34Option ;
      private GxSimpleCollection<short> AV65TFTipSts_Sels ;
      private GxSimpleCollection<short> AV96Configuracion_tipodocumentowwds_24_tftipsts_sels ;
      private IGxSession AV43Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00492_A306TipAbr ;
      private short[] P00492_A1919TipSts ;
      private short[] P00492_A1903TipBan ;
      private short[] P00492_A1909TipCxP ;
      private short[] P00492_A1915TipRHo ;
      private short[] P00492_A1906TipCmp ;
      private short[] P00492_A1921TipVta ;
      private string[] P00492_A1910TipDsc ;
      private string[] P00492_A149TipCod ;
      private string[] P00493_A1910TipDsc ;
      private short[] P00493_A1919TipSts ;
      private short[] P00493_A1903TipBan ;
      private short[] P00493_A1909TipCxP ;
      private short[] P00493_A1915TipRHo ;
      private short[] P00493_A1906TipCmp ;
      private short[] P00493_A1921TipVta ;
      private string[] P00493_A306TipAbr ;
      private string[] P00493_A149TipCod ;
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

   public class tipodocumentowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00492( IGxContext context ,
                                             short A1919TipSts ,
                                             GxSimpleCollection<short> AV96Configuracion_tipodocumentowwds_24_tftipsts_sels ,
                                             string AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ,
                                             short AV74Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ,
                                             string AV75Configuracion_tipodocumentowwds_3_tipdsc1 ,
                                             string AV76Configuracion_tipodocumentowwds_4_tipabr1 ,
                                             bool AV77Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ,
                                             string AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ,
                                             short AV79Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ,
                                             string AV80Configuracion_tipodocumentowwds_8_tipdsc2 ,
                                             string AV81Configuracion_tipodocumentowwds_9_tipabr2 ,
                                             bool AV82Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ,
                                             string AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ,
                                             short AV84Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ,
                                             string AV85Configuracion_tipodocumentowwds_13_tipdsc3 ,
                                             string AV86Configuracion_tipodocumentowwds_14_tipabr3 ,
                                             string AV88Configuracion_tipodocumentowwds_16_tftipabr_sel ,
                                             string AV87Configuracion_tipodocumentowwds_15_tftipabr ,
                                             string AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel ,
                                             string AV89Configuracion_tipodocumentowwds_17_tftipdsc ,
                                             short AV91Configuracion_tipodocumentowwds_19_tftipvta_sel ,
                                             short AV92Configuracion_tipodocumentowwds_20_tftipcmp_sel ,
                                             short AV93Configuracion_tipodocumentowwds_21_tftiprho_sel ,
                                             short AV94Configuracion_tipodocumentowwds_22_tftipcxp_sel ,
                                             short AV95Configuracion_tipodocumentowwds_23_tftipban_sel ,
                                             int AV96Configuracion_tipodocumentowwds_24_tftipsts_sels_Count ,
                                             string A1910TipDsc ,
                                             string A306TipAbr ,
                                             short A1921TipVta ,
                                             short A1906TipCmp ,
                                             short A1915TipRHo ,
                                             short A1909TipCxP ,
                                             short A1903TipBan )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[16];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TipAbr], [TipSts], [TipBan], [TipCxP], [TipRHo], [TipCmp], [TipVta], [TipDsc], [TipCod] FROM [CTIPDOC]";
         if ( ( StringUtil.StrCmp(AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPDSC") == 0 ) && ( AV74Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_3_tipdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV75Configuracion_tipodocumentowwds_3_tipdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPDSC") == 0 ) && ( AV74Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_3_tipdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV75Configuracion_tipodocumentowwds_3_tipdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPABR") == 0 ) && ( AV74Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_tipodocumentowwds_4_tipabr1)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV76Configuracion_tipodocumentowwds_4_tipabr1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPABR") == 0 ) && ( AV74Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_tipodocumentowwds_4_tipabr1)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV76Configuracion_tipodocumentowwds_4_tipabr1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV77Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPDSC") == 0 ) && ( AV79Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_8_tipdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV80Configuracion_tipodocumentowwds_8_tipdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV77Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPDSC") == 0 ) && ( AV79Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_8_tipdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV80Configuracion_tipodocumentowwds_8_tipdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV77Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPABR") == 0 ) && ( AV79Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_tipodocumentowwds_9_tipabr2)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV81Configuracion_tipodocumentowwds_9_tipabr2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV77Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPABR") == 0 ) && ( AV79Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_tipodocumentowwds_9_tipabr2)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV81Configuracion_tipodocumentowwds_9_tipabr2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV82Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPDSC") == 0 ) && ( AV84Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_13_tipdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV85Configuracion_tipodocumentowwds_13_tipdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV82Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPDSC") == 0 ) && ( AV84Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_13_tipdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV85Configuracion_tipodocumentowwds_13_tipdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV82Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPABR") == 0 ) && ( AV84Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_tipodocumentowwds_14_tipabr3)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV86Configuracion_tipodocumentowwds_14_tipabr3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV82Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPABR") == 0 ) && ( AV84Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_tipodocumentowwds_14_tipabr3)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV86Configuracion_tipodocumentowwds_14_tipabr3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_tipodocumentowwds_16_tftipabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_tipodocumentowwds_15_tftipabr)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV87Configuracion_tipodocumentowwds_15_tftipabr)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_tipodocumentowwds_16_tftipabr_sel)) )
         {
            AddWhere(sWhereString, "([TipAbr] = @AV88Configuracion_tipodocumentowwds_16_tftipabr_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_tipodocumentowwds_17_tftipdsc)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV89Configuracion_tipodocumentowwds_17_tftipdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel)) )
         {
            AddWhere(sWhereString, "([TipDsc] = @AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV91Configuracion_tipodocumentowwds_19_tftipvta_sel == 1 )
         {
            AddWhere(sWhereString, "([TipVta] = 1)");
         }
         if ( AV91Configuracion_tipodocumentowwds_19_tftipvta_sel == 2 )
         {
            AddWhere(sWhereString, "([TipVta] = 0)");
         }
         if ( AV92Configuracion_tipodocumentowwds_20_tftipcmp_sel == 1 )
         {
            AddWhere(sWhereString, "([TipCmp] = 1)");
         }
         if ( AV92Configuracion_tipodocumentowwds_20_tftipcmp_sel == 2 )
         {
            AddWhere(sWhereString, "([TipCmp] = 0)");
         }
         if ( AV93Configuracion_tipodocumentowwds_21_tftiprho_sel == 1 )
         {
            AddWhere(sWhereString, "([TipRHo] = 1)");
         }
         if ( AV93Configuracion_tipodocumentowwds_21_tftiprho_sel == 2 )
         {
            AddWhere(sWhereString, "([TipRHo] = 0)");
         }
         if ( AV94Configuracion_tipodocumentowwds_22_tftipcxp_sel == 1 )
         {
            AddWhere(sWhereString, "([TipCxP] = 1)");
         }
         if ( AV94Configuracion_tipodocumentowwds_22_tftipcxp_sel == 2 )
         {
            AddWhere(sWhereString, "([TipCxP] = 0)");
         }
         if ( AV95Configuracion_tipodocumentowwds_23_tftipban_sel == 1 )
         {
            AddWhere(sWhereString, "([TipBan] = 1)");
         }
         if ( AV95Configuracion_tipodocumentowwds_23_tftipban_sel == 2 )
         {
            AddWhere(sWhereString, "([TipBan] = 0)");
         }
         if ( AV96Configuracion_tipodocumentowwds_24_tftipsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV96Configuracion_tipodocumentowwds_24_tftipsts_sels, "[TipSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipAbr]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00493( IGxContext context ,
                                             short A1919TipSts ,
                                             GxSimpleCollection<short> AV96Configuracion_tipodocumentowwds_24_tftipsts_sels ,
                                             string AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1 ,
                                             short AV74Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 ,
                                             string AV75Configuracion_tipodocumentowwds_3_tipdsc1 ,
                                             string AV76Configuracion_tipodocumentowwds_4_tipabr1 ,
                                             bool AV77Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 ,
                                             string AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2 ,
                                             short AV79Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 ,
                                             string AV80Configuracion_tipodocumentowwds_8_tipdsc2 ,
                                             string AV81Configuracion_tipodocumentowwds_9_tipabr2 ,
                                             bool AV82Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 ,
                                             string AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3 ,
                                             short AV84Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 ,
                                             string AV85Configuracion_tipodocumentowwds_13_tipdsc3 ,
                                             string AV86Configuracion_tipodocumentowwds_14_tipabr3 ,
                                             string AV88Configuracion_tipodocumentowwds_16_tftipabr_sel ,
                                             string AV87Configuracion_tipodocumentowwds_15_tftipabr ,
                                             string AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel ,
                                             string AV89Configuracion_tipodocumentowwds_17_tftipdsc ,
                                             short AV91Configuracion_tipodocumentowwds_19_tftipvta_sel ,
                                             short AV92Configuracion_tipodocumentowwds_20_tftipcmp_sel ,
                                             short AV93Configuracion_tipodocumentowwds_21_tftiprho_sel ,
                                             short AV94Configuracion_tipodocumentowwds_22_tftipcxp_sel ,
                                             short AV95Configuracion_tipodocumentowwds_23_tftipban_sel ,
                                             int AV96Configuracion_tipodocumentowwds_24_tftipsts_sels_Count ,
                                             string A1910TipDsc ,
                                             string A306TipAbr ,
                                             short A1921TipVta ,
                                             short A1906TipCmp ,
                                             short A1915TipRHo ,
                                             short A1909TipCxP ,
                                             short A1903TipBan )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[16];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [TipDsc], [TipSts], [TipBan], [TipCxP], [TipRHo], [TipCmp], [TipVta], [TipAbr], [TipCod] FROM [CTIPDOC]";
         if ( ( StringUtil.StrCmp(AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPDSC") == 0 ) && ( AV74Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_3_tipdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV75Configuracion_tipodocumentowwds_3_tipdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPDSC") == 0 ) && ( AV74Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_tipodocumentowwds_3_tipdsc1)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV75Configuracion_tipodocumentowwds_3_tipdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPABR") == 0 ) && ( AV74Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_tipodocumentowwds_4_tipabr1)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV76Configuracion_tipodocumentowwds_4_tipabr1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Configuracion_tipodocumentowwds_1_dynamicfiltersselector1, "TIPABR") == 0 ) && ( AV74Configuracion_tipodocumentowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_tipodocumentowwds_4_tipabr1)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV76Configuracion_tipodocumentowwds_4_tipabr1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV77Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPDSC") == 0 ) && ( AV79Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_8_tipdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV80Configuracion_tipodocumentowwds_8_tipdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV77Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPDSC") == 0 ) && ( AV79Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configuracion_tipodocumentowwds_8_tipdsc2)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV80Configuracion_tipodocumentowwds_8_tipdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV77Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPABR") == 0 ) && ( AV79Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_tipodocumentowwds_9_tipabr2)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV81Configuracion_tipodocumentowwds_9_tipabr2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV77Configuracion_tipodocumentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Configuracion_tipodocumentowwds_6_dynamicfiltersselector2, "TIPABR") == 0 ) && ( AV79Configuracion_tipodocumentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Configuracion_tipodocumentowwds_9_tipabr2)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV81Configuracion_tipodocumentowwds_9_tipabr2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV82Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPDSC") == 0 ) && ( AV84Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_13_tipdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV85Configuracion_tipodocumentowwds_13_tipdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV82Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPDSC") == 0 ) && ( AV84Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configuracion_tipodocumentowwds_13_tipdsc3)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like '%' + @lV85Configuracion_tipodocumentowwds_13_tipdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV82Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPABR") == 0 ) && ( AV84Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_tipodocumentowwds_14_tipabr3)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV86Configuracion_tipodocumentowwds_14_tipabr3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV82Configuracion_tipodocumentowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Configuracion_tipodocumentowwds_11_dynamicfiltersselector3, "TIPABR") == 0 ) && ( AV84Configuracion_tipodocumentowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configuracion_tipodocumentowwds_14_tipabr3)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like '%' + @lV86Configuracion_tipodocumentowwds_14_tipabr3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_tipodocumentowwds_16_tftipabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configuracion_tipodocumentowwds_15_tftipabr)) ) )
         {
            AddWhere(sWhereString, "([TipAbr] like @lV87Configuracion_tipodocumentowwds_15_tftipabr)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configuracion_tipodocumentowwds_16_tftipabr_sel)) )
         {
            AddWhere(sWhereString, "([TipAbr] = @AV88Configuracion_tipodocumentowwds_16_tftipabr_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configuracion_tipodocumentowwds_17_tftipdsc)) ) )
         {
            AddWhere(sWhereString, "([TipDsc] like @lV89Configuracion_tipodocumentowwds_17_tftipdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel)) )
         {
            AddWhere(sWhereString, "([TipDsc] = @AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV91Configuracion_tipodocumentowwds_19_tftipvta_sel == 1 )
         {
            AddWhere(sWhereString, "([TipVta] = 1)");
         }
         if ( AV91Configuracion_tipodocumentowwds_19_tftipvta_sel == 2 )
         {
            AddWhere(sWhereString, "([TipVta] = 0)");
         }
         if ( AV92Configuracion_tipodocumentowwds_20_tftipcmp_sel == 1 )
         {
            AddWhere(sWhereString, "([TipCmp] = 1)");
         }
         if ( AV92Configuracion_tipodocumentowwds_20_tftipcmp_sel == 2 )
         {
            AddWhere(sWhereString, "([TipCmp] = 0)");
         }
         if ( AV93Configuracion_tipodocumentowwds_21_tftiprho_sel == 1 )
         {
            AddWhere(sWhereString, "([TipRHo] = 1)");
         }
         if ( AV93Configuracion_tipodocumentowwds_21_tftiprho_sel == 2 )
         {
            AddWhere(sWhereString, "([TipRHo] = 0)");
         }
         if ( AV94Configuracion_tipodocumentowwds_22_tftipcxp_sel == 1 )
         {
            AddWhere(sWhereString, "([TipCxP] = 1)");
         }
         if ( AV94Configuracion_tipodocumentowwds_22_tftipcxp_sel == 2 )
         {
            AddWhere(sWhereString, "([TipCxP] = 0)");
         }
         if ( AV95Configuracion_tipodocumentowwds_23_tftipban_sel == 1 )
         {
            AddWhere(sWhereString, "([TipBan] = 1)");
         }
         if ( AV95Configuracion_tipodocumentowwds_23_tftipban_sel == 2 )
         {
            AddWhere(sWhereString, "([TipBan] = 0)");
         }
         if ( AV96Configuracion_tipodocumentowwds_24_tftipsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV96Configuracion_tipodocumentowwds_24_tftipsts_sels, "[TipSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipDsc]";
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
                     return conditional_P00492(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (short)dynConstraints[28] , (short)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] );
               case 1 :
                     return conditional_P00493(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (short)dynConstraints[28] , (short)dynConstraints[29] , (short)dynConstraints[30] , (short)dynConstraints[31] , (short)dynConstraints[32] );
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
          Object[] prmP00492;
          prmP00492 = new Object[] {
          new ParDef("@lV75Configuracion_tipodocumentowwds_3_tipdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_tipodocumentowwds_3_tipdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_tipodocumentowwds_4_tipabr1",GXType.NChar,5,0) ,
          new ParDef("@lV76Configuracion_tipodocumentowwds_4_tipabr1",GXType.NChar,5,0) ,
          new ParDef("@lV80Configuracion_tipodocumentowwds_8_tipdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_tipodocumentowwds_8_tipdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV81Configuracion_tipodocumentowwds_9_tipabr2",GXType.NChar,5,0) ,
          new ParDef("@lV81Configuracion_tipodocumentowwds_9_tipabr2",GXType.NChar,5,0) ,
          new ParDef("@lV85Configuracion_tipodocumentowwds_13_tipdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV85Configuracion_tipodocumentowwds_13_tipdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV86Configuracion_tipodocumentowwds_14_tipabr3",GXType.NChar,5,0) ,
          new ParDef("@lV86Configuracion_tipodocumentowwds_14_tipabr3",GXType.NChar,5,0) ,
          new ParDef("@lV87Configuracion_tipodocumentowwds_15_tftipabr",GXType.NChar,5,0) ,
          new ParDef("@AV88Configuracion_tipodocumentowwds_16_tftipabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV89Configuracion_tipodocumentowwds_17_tftipdsc",GXType.NChar,100,0) ,
          new ParDef("@AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP00493;
          prmP00493 = new Object[] {
          new ParDef("@lV75Configuracion_tipodocumentowwds_3_tipdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV75Configuracion_tipodocumentowwds_3_tipdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_tipodocumentowwds_4_tipabr1",GXType.NChar,5,0) ,
          new ParDef("@lV76Configuracion_tipodocumentowwds_4_tipabr1",GXType.NChar,5,0) ,
          new ParDef("@lV80Configuracion_tipodocumentowwds_8_tipdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV80Configuracion_tipodocumentowwds_8_tipdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV81Configuracion_tipodocumentowwds_9_tipabr2",GXType.NChar,5,0) ,
          new ParDef("@lV81Configuracion_tipodocumentowwds_9_tipabr2",GXType.NChar,5,0) ,
          new ParDef("@lV85Configuracion_tipodocumentowwds_13_tipdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV85Configuracion_tipodocumentowwds_13_tipdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV86Configuracion_tipodocumentowwds_14_tipabr3",GXType.NChar,5,0) ,
          new ParDef("@lV86Configuracion_tipodocumentowwds_14_tipabr3",GXType.NChar,5,0) ,
          new ParDef("@lV87Configuracion_tipodocumentowwds_15_tftipabr",GXType.NChar,5,0) ,
          new ParDef("@AV88Configuracion_tipodocumentowwds_16_tftipabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV89Configuracion_tipodocumentowwds_17_tftipdsc",GXType.NChar,100,0) ,
          new ParDef("@AV90Configuracion_tipodocumentowwds_18_tftipdsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00492", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00492,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00493", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00493,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                ((string[]) buf[8])[0] = rslt.getString(9, 3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 5);
                ((string[]) buf[8])[0] = rslt.getString(9, 3);
                return;
       }
    }

 }

}
