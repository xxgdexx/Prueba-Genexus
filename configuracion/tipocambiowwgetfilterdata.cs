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
   public class tipocambiowwgetfilterdata : GXProcedure
   {
      public tipocambiowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipocambiowwgetfilterdata( IGxContext context )
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
         tipocambiowwgetfilterdata objtipocambiowwgetfilterdata;
         objtipocambiowwgetfilterdata = new tipocambiowwgetfilterdata();
         objtipocambiowwgetfilterdata.AV20DDOName = aP0_DDOName;
         objtipocambiowwgetfilterdata.AV18SearchTxt = aP1_SearchTxt;
         objtipocambiowwgetfilterdata.AV19SearchTxtTo = aP2_SearchTxtTo;
         objtipocambiowwgetfilterdata.AV24OptionsJson = "" ;
         objtipocambiowwgetfilterdata.AV27OptionsDescJson = "" ;
         objtipocambiowwgetfilterdata.AV29OptionIndexesJson = "" ;
         objtipocambiowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objtipocambiowwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipocambiowwgetfilterdata);
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipocambiowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_MONDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADMONDSCOPTIONS' */
            S121 ();
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
         if ( StringUtil.StrCmp(AV31Session.Get("Configuracion.TipoCambioWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoCambioWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Configuracion.TipoCambioWWGridState"), null, "", "");
         }
         AV58GXV1 = 1;
         while ( AV58GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV58GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFMONDSC") == 0 )
            {
               AV10TFMonDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFMONDSC_SEL") == 0 )
            {
               AV11TFMonDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPFECH") == 0 )
            {
               AV12TFTipFech = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Value, 2);
               AV13TFTipFech_To = context.localUtil.CToD( AV34GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPCOMPRA") == 0 )
            {
               AV14TFTipCompra = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV15TFTipCompra_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTIPVENTA") == 0 )
            {
               AV16TFTipVenta = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, ".");
               AV17TFTipVenta_To = NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV58GXV1 = (int)(AV58GXV1+1);
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "MONDSC") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV47MonDsc1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "TIPFECH") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV48TipFech1 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Value, 2);
               AV49TipFech_To1 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Valueto, 2);
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "MONDSC") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV50MonDsc2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "TIPFECH") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV51TipFech2 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Value, 2);
                  AV52TipFech_To2 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Valueto, 2);
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "MONDSC") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV53MonDsc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "TIPFECH") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV54TipFech3 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Value, 2);
                     AV55TipFech_To3 = context.localUtil.CToD( AV35GridStateDynamicFilter.gxTpr_Valueto, 2);
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADMONDSCOPTIONS' Routine */
         returnInSub = false;
         AV10TFMonDsc = AV18SearchTxt;
         AV11TFMonDsc_Sel = "";
         AV60Configuracion_tipocambiowwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV61Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV62Configuracion_tipocambiowwds_3_mondsc1 = AV47MonDsc1;
         AV63Configuracion_tipocambiowwds_4_tipfech1 = AV48TipFech1;
         AV64Configuracion_tipocambiowwds_5_tipfech_to1 = AV49TipFech_To1;
         AV65Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV66Configuracion_tipocambiowwds_7_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV67Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV68Configuracion_tipocambiowwds_9_mondsc2 = AV50MonDsc2;
         AV69Configuracion_tipocambiowwds_10_tipfech2 = AV51TipFech2;
         AV70Configuracion_tipocambiowwds_11_tipfech_to2 = AV52TipFech_To2;
         AV71Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV72Configuracion_tipocambiowwds_13_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV73Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV74Configuracion_tipocambiowwds_15_mondsc3 = AV53MonDsc3;
         AV75Configuracion_tipocambiowwds_16_tipfech3 = AV54TipFech3;
         AV76Configuracion_tipocambiowwds_17_tipfech_to3 = AV55TipFech_To3;
         AV77Configuracion_tipocambiowwds_18_tfmondsc = AV10TFMonDsc;
         AV78Configuracion_tipocambiowwds_19_tfmondsc_sel = AV11TFMonDsc_Sel;
         AV79Configuracion_tipocambiowwds_20_tftipfech = AV12TFTipFech;
         AV80Configuracion_tipocambiowwds_21_tftipfech_to = AV13TFTipFech_To;
         AV81Configuracion_tipocambiowwds_22_tftipcompra = AV14TFTipCompra;
         AV82Configuracion_tipocambiowwds_23_tftipcompra_to = AV15TFTipCompra_To;
         AV83Configuracion_tipocambiowwds_24_tftipventa = AV16TFTipVenta;
         AV84Configuracion_tipocambiowwds_25_tftipventa_to = AV17TFTipVenta_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV60Configuracion_tipocambiowwds_1_dynamicfiltersselector1 ,
                                              AV61Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 ,
                                              AV62Configuracion_tipocambiowwds_3_mondsc1 ,
                                              AV63Configuracion_tipocambiowwds_4_tipfech1 ,
                                              AV64Configuracion_tipocambiowwds_5_tipfech_to1 ,
                                              AV65Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 ,
                                              AV66Configuracion_tipocambiowwds_7_dynamicfiltersselector2 ,
                                              AV67Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 ,
                                              AV68Configuracion_tipocambiowwds_9_mondsc2 ,
                                              AV69Configuracion_tipocambiowwds_10_tipfech2 ,
                                              AV70Configuracion_tipocambiowwds_11_tipfech_to2 ,
                                              AV71Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 ,
                                              AV72Configuracion_tipocambiowwds_13_dynamicfiltersselector3 ,
                                              AV73Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 ,
                                              AV74Configuracion_tipocambiowwds_15_mondsc3 ,
                                              AV75Configuracion_tipocambiowwds_16_tipfech3 ,
                                              AV76Configuracion_tipocambiowwds_17_tipfech_to3 ,
                                              AV78Configuracion_tipocambiowwds_19_tfmondsc_sel ,
                                              AV77Configuracion_tipocambiowwds_18_tfmondsc ,
                                              AV79Configuracion_tipocambiowwds_20_tftipfech ,
                                              AV80Configuracion_tipocambiowwds_21_tftipfech_to ,
                                              AV81Configuracion_tipocambiowwds_22_tftipcompra ,
                                              AV82Configuracion_tipocambiowwds_23_tftipcompra_to ,
                                              AV83Configuracion_tipocambiowwds_24_tftipventa ,
                                              AV84Configuracion_tipocambiowwds_25_tftipventa_to ,
                                              A1234MonDsc ,
                                              A308TipFech ,
                                              A1907TipCompra ,
                                              A1920TipVenta } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL
                                              }
         });
         lV62Configuracion_tipocambiowwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_tipocambiowwds_3_mondsc1), 100, "%");
         lV62Configuracion_tipocambiowwds_3_mondsc1 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_tipocambiowwds_3_mondsc1), 100, "%");
         lV68Configuracion_tipocambiowwds_9_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_tipocambiowwds_9_mondsc2), 100, "%");
         lV68Configuracion_tipocambiowwds_9_mondsc2 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_tipocambiowwds_9_mondsc2), 100, "%");
         lV74Configuracion_tipocambiowwds_15_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_tipocambiowwds_15_mondsc3), 100, "%");
         lV74Configuracion_tipocambiowwds_15_mondsc3 = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_tipocambiowwds_15_mondsc3), 100, "%");
         lV77Configuracion_tipocambiowwds_18_tfmondsc = StringUtil.PadR( StringUtil.RTrim( AV77Configuracion_tipocambiowwds_18_tfmondsc), 100, "%");
         /* Using cursor P00542 */
         pr_default.execute(0, new Object[] {lV62Configuracion_tipocambiowwds_3_mondsc1, lV62Configuracion_tipocambiowwds_3_mondsc1, AV63Configuracion_tipocambiowwds_4_tipfech1, AV63Configuracion_tipocambiowwds_4_tipfech1, AV63Configuracion_tipocambiowwds_4_tipfech1, AV63Configuracion_tipocambiowwds_4_tipfech1, AV64Configuracion_tipocambiowwds_5_tipfech_to1, lV68Configuracion_tipocambiowwds_9_mondsc2, lV68Configuracion_tipocambiowwds_9_mondsc2, AV69Configuracion_tipocambiowwds_10_tipfech2, AV69Configuracion_tipocambiowwds_10_tipfech2, AV69Configuracion_tipocambiowwds_10_tipfech2, AV69Configuracion_tipocambiowwds_10_tipfech2, AV70Configuracion_tipocambiowwds_11_tipfech_to2, lV74Configuracion_tipocambiowwds_15_mondsc3, lV74Configuracion_tipocambiowwds_15_mondsc3, AV75Configuracion_tipocambiowwds_16_tipfech3, AV75Configuracion_tipocambiowwds_16_tipfech3, AV75Configuracion_tipocambiowwds_16_tipfech3, AV75Configuracion_tipocambiowwds_16_tipfech3, AV76Configuracion_tipocambiowwds_17_tipfech_to3, lV77Configuracion_tipocambiowwds_18_tfmondsc, AV78Configuracion_tipocambiowwds_19_tfmondsc_sel, AV79Configuracion_tipocambiowwds_20_tftipfech, AV80Configuracion_tipocambiowwds_21_tftipfech_to, AV81Configuracion_tipocambiowwds_22_tftipcompra, AV82Configuracion_tipocambiowwds_23_tftipcompra_to, AV83Configuracion_tipocambiowwds_24_tftipventa, AV84Configuracion_tipocambiowwds_25_tftipventa_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK542 = false;
            A307TipMonCod = P00542_A307TipMonCod[0];
            A1234MonDsc = P00542_A1234MonDsc[0];
            n1234MonDsc = P00542_n1234MonDsc[0];
            A1920TipVenta = P00542_A1920TipVenta[0];
            A1907TipCompra = P00542_A1907TipCompra[0];
            A308TipFech = P00542_A308TipFech[0];
            A1234MonDsc = P00542_A1234MonDsc[0];
            n1234MonDsc = P00542_n1234MonDsc[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00542_A1234MonDsc[0], A1234MonDsc) == 0 ) )
            {
               BRK542 = false;
               A307TipMonCod = P00542_A307TipMonCod[0];
               A308TipFech = P00542_A308TipFech[0];
               AV30count = (long)(AV30count+1);
               BRK542 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1234MonDsc)) )
            {
               AV22Option = A1234MonDsc;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK542 )
            {
               BRK542 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV10TFMonDsc = "";
         AV11TFMonDsc_Sel = "";
         AV12TFTipFech = DateTime.MinValue;
         AV13TFTipFech_To = DateTime.MinValue;
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV47MonDsc1 = "";
         AV48TipFech1 = DateTime.MinValue;
         AV49TipFech_To1 = DateTime.MinValue;
         AV40DynamicFiltersSelector2 = "";
         AV50MonDsc2 = "";
         AV51TipFech2 = DateTime.MinValue;
         AV52TipFech_To2 = DateTime.MinValue;
         AV44DynamicFiltersSelector3 = "";
         AV53MonDsc3 = "";
         AV54TipFech3 = DateTime.MinValue;
         AV55TipFech_To3 = DateTime.MinValue;
         AV60Configuracion_tipocambiowwds_1_dynamicfiltersselector1 = "";
         AV62Configuracion_tipocambiowwds_3_mondsc1 = "";
         AV63Configuracion_tipocambiowwds_4_tipfech1 = DateTime.MinValue;
         AV64Configuracion_tipocambiowwds_5_tipfech_to1 = DateTime.MinValue;
         AV66Configuracion_tipocambiowwds_7_dynamicfiltersselector2 = "";
         AV68Configuracion_tipocambiowwds_9_mondsc2 = "";
         AV69Configuracion_tipocambiowwds_10_tipfech2 = DateTime.MinValue;
         AV70Configuracion_tipocambiowwds_11_tipfech_to2 = DateTime.MinValue;
         AV72Configuracion_tipocambiowwds_13_dynamicfiltersselector3 = "";
         AV74Configuracion_tipocambiowwds_15_mondsc3 = "";
         AV75Configuracion_tipocambiowwds_16_tipfech3 = DateTime.MinValue;
         AV76Configuracion_tipocambiowwds_17_tipfech_to3 = DateTime.MinValue;
         AV77Configuracion_tipocambiowwds_18_tfmondsc = "";
         AV78Configuracion_tipocambiowwds_19_tfmondsc_sel = "";
         AV79Configuracion_tipocambiowwds_20_tftipfech = DateTime.MinValue;
         AV80Configuracion_tipocambiowwds_21_tftipfech_to = DateTime.MinValue;
         scmdbuf = "";
         lV62Configuracion_tipocambiowwds_3_mondsc1 = "";
         lV68Configuracion_tipocambiowwds_9_mondsc2 = "";
         lV74Configuracion_tipocambiowwds_15_mondsc3 = "";
         lV77Configuracion_tipocambiowwds_18_tfmondsc = "";
         A1234MonDsc = "";
         A308TipFech = DateTime.MinValue;
         P00542_A307TipMonCod = new int[1] ;
         P00542_A1234MonDsc = new string[] {""} ;
         P00542_n1234MonDsc = new bool[] {false} ;
         P00542_A1920TipVenta = new decimal[1] ;
         P00542_A1907TipCompra = new decimal[1] ;
         P00542_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         AV22Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipocambiowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00542_A307TipMonCod, P00542_A1234MonDsc, P00542_n1234MonDsc, P00542_A1920TipVenta, P00542_A1907TipCompra, P00542_A308TipFech
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV61Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 ;
      private short AV67Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 ;
      private short AV73Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 ;
      private int AV58GXV1 ;
      private int A307TipMonCod ;
      private long AV30count ;
      private decimal AV14TFTipCompra ;
      private decimal AV15TFTipCompra_To ;
      private decimal AV16TFTipVenta ;
      private decimal AV17TFTipVenta_To ;
      private decimal AV81Configuracion_tipocambiowwds_22_tftipcompra ;
      private decimal AV82Configuracion_tipocambiowwds_23_tftipcompra_to ;
      private decimal AV83Configuracion_tipocambiowwds_24_tftipventa ;
      private decimal AV84Configuracion_tipocambiowwds_25_tftipventa_to ;
      private decimal A1907TipCompra ;
      private decimal A1920TipVenta ;
      private string AV10TFMonDsc ;
      private string AV11TFMonDsc_Sel ;
      private string AV47MonDsc1 ;
      private string AV50MonDsc2 ;
      private string AV53MonDsc3 ;
      private string AV62Configuracion_tipocambiowwds_3_mondsc1 ;
      private string AV68Configuracion_tipocambiowwds_9_mondsc2 ;
      private string AV74Configuracion_tipocambiowwds_15_mondsc3 ;
      private string AV77Configuracion_tipocambiowwds_18_tfmondsc ;
      private string AV78Configuracion_tipocambiowwds_19_tfmondsc_sel ;
      private string scmdbuf ;
      private string lV62Configuracion_tipocambiowwds_3_mondsc1 ;
      private string lV68Configuracion_tipocambiowwds_9_mondsc2 ;
      private string lV74Configuracion_tipocambiowwds_15_mondsc3 ;
      private string lV77Configuracion_tipocambiowwds_18_tfmondsc ;
      private string A1234MonDsc ;
      private DateTime AV12TFTipFech ;
      private DateTime AV13TFTipFech_To ;
      private DateTime AV48TipFech1 ;
      private DateTime AV49TipFech_To1 ;
      private DateTime AV51TipFech2 ;
      private DateTime AV52TipFech_To2 ;
      private DateTime AV54TipFech3 ;
      private DateTime AV55TipFech_To3 ;
      private DateTime AV63Configuracion_tipocambiowwds_4_tipfech1 ;
      private DateTime AV64Configuracion_tipocambiowwds_5_tipfech_to1 ;
      private DateTime AV69Configuracion_tipocambiowwds_10_tipfech2 ;
      private DateTime AV70Configuracion_tipocambiowwds_11_tipfech_to2 ;
      private DateTime AV75Configuracion_tipocambiowwds_16_tipfech3 ;
      private DateTime AV76Configuracion_tipocambiowwds_17_tipfech_to3 ;
      private DateTime AV79Configuracion_tipocambiowwds_20_tftipfech ;
      private DateTime AV80Configuracion_tipocambiowwds_21_tftipfech_to ;
      private DateTime A308TipFech ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV65Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 ;
      private bool AV71Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 ;
      private bool BRK542 ;
      private bool n1234MonDsc ;
      private string AV24OptionsJson ;
      private string AV27OptionsDescJson ;
      private string AV29OptionIndexesJson ;
      private string AV20DDOName ;
      private string AV18SearchTxt ;
      private string AV19SearchTxtTo ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV60Configuracion_tipocambiowwds_1_dynamicfiltersselector1 ;
      private string AV66Configuracion_tipocambiowwds_7_dynamicfiltersselector2 ;
      private string AV72Configuracion_tipocambiowwds_13_dynamicfiltersselector3 ;
      private string AV22Option ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00542_A307TipMonCod ;
      private string[] P00542_A1234MonDsc ;
      private bool[] P00542_n1234MonDsc ;
      private decimal[] P00542_A1920TipVenta ;
      private decimal[] P00542_A1907TipCompra ;
      private DateTime[] P00542_A308TipFech ;
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

   public class tipocambiowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00542( IGxContext context ,
                                             string AV60Configuracion_tipocambiowwds_1_dynamicfiltersselector1 ,
                                             short AV61Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 ,
                                             string AV62Configuracion_tipocambiowwds_3_mondsc1 ,
                                             DateTime AV63Configuracion_tipocambiowwds_4_tipfech1 ,
                                             DateTime AV64Configuracion_tipocambiowwds_5_tipfech_to1 ,
                                             bool AV65Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 ,
                                             string AV66Configuracion_tipocambiowwds_7_dynamicfiltersselector2 ,
                                             short AV67Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 ,
                                             string AV68Configuracion_tipocambiowwds_9_mondsc2 ,
                                             DateTime AV69Configuracion_tipocambiowwds_10_tipfech2 ,
                                             DateTime AV70Configuracion_tipocambiowwds_11_tipfech_to2 ,
                                             bool AV71Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 ,
                                             string AV72Configuracion_tipocambiowwds_13_dynamicfiltersselector3 ,
                                             short AV73Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 ,
                                             string AV74Configuracion_tipocambiowwds_15_mondsc3 ,
                                             DateTime AV75Configuracion_tipocambiowwds_16_tipfech3 ,
                                             DateTime AV76Configuracion_tipocambiowwds_17_tipfech_to3 ,
                                             string AV78Configuracion_tipocambiowwds_19_tfmondsc_sel ,
                                             string AV77Configuracion_tipocambiowwds_18_tfmondsc ,
                                             DateTime AV79Configuracion_tipocambiowwds_20_tftipfech ,
                                             DateTime AV80Configuracion_tipocambiowwds_21_tftipfech_to ,
                                             decimal AV81Configuracion_tipocambiowwds_22_tftipcompra ,
                                             decimal AV82Configuracion_tipocambiowwds_23_tftipcompra_to ,
                                             decimal AV83Configuracion_tipocambiowwds_24_tftipventa ,
                                             decimal AV84Configuracion_tipocambiowwds_25_tftipventa_to ,
                                             string A1234MonDsc ,
                                             DateTime A308TipFech ,
                                             decimal A1907TipCompra ,
                                             decimal A1920TipVenta )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[29];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[TipMonCod] AS TipMonCod, T2.[MonDsc], T1.[TipVenta], T1.[TipCompra], T1.[TipFech] FROM ([CTIPOCAMBIO] T1 INNER JOIN [CMONEDAS] T2 ON T2.[MonCod] = T1.[TipMonCod])";
         if ( ( StringUtil.StrCmp(AV60Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV61Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_tipocambiowwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV62Configuracion_tipocambiowwds_3_mondsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "MONDSC") == 0 ) && ( AV61Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_tipocambiowwds_3_mondsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like '%' + @lV62Configuracion_tipocambiowwds_3_mondsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV61Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV63Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] < @AV63Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV61Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV63Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] = @AV63Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV61Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV63Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] > @AV63Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV61Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV63Configuracion_tipocambiowwds_4_tipfech1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV63Configuracion_tipocambiowwds_4_tipfech1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Configuracion_tipocambiowwds_1_dynamicfiltersselector1, "TIPFECH") == 0 ) && ( AV61Configuracion_tipocambiowwds_2_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV64Configuracion_tipocambiowwds_5_tipfech_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV64Configuracion_tipocambiowwds_5_tipfech_to1)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV65Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV67Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_tipocambiowwds_9_mondsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV68Configuracion_tipocambiowwds_9_mondsc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV65Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "MONDSC") == 0 ) && ( AV67Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_tipocambiowwds_9_mondsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like '%' + @lV68Configuracion_tipocambiowwds_9_mondsc2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV65Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV67Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV69Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] < @AV69Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV65Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV67Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV69Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] = @AV69Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV65Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV67Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV69Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] > @AV69Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV65Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV67Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV69Configuracion_tipocambiowwds_10_tipfech2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV69Configuracion_tipocambiowwds_10_tipfech2)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV65Configuracion_tipocambiowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Configuracion_tipocambiowwds_7_dynamicfiltersselector2, "TIPFECH") == 0 ) && ( AV67Configuracion_tipocambiowwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV70Configuracion_tipocambiowwds_11_tipfech_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV70Configuracion_tipocambiowwds_11_tipfech_to2)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV71Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV73Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_tipocambiowwds_15_mondsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV74Configuracion_tipocambiowwds_15_mondsc3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV71Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "MONDSC") == 0 ) && ( AV73Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_tipocambiowwds_15_mondsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like '%' + @lV74Configuracion_tipocambiowwds_15_mondsc3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV71Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV73Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV75Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] < @AV75Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV71Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV73Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV75Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] = @AV75Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV71Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV73Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV75Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] > @AV75Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( AV71Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV73Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV75Configuracion_tipocambiowwds_16_tipfech3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV75Configuracion_tipocambiowwds_16_tipfech3)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( AV71Configuracion_tipocambiowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Configuracion_tipocambiowwds_13_dynamicfiltersselector3, "TIPFECH") == 0 ) && ( AV73Configuracion_tipocambiowwds_14_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV76Configuracion_tipocambiowwds_17_tipfech_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV76Configuracion_tipocambiowwds_17_tipfech_to3)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_tipocambiowwds_19_tfmondsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_tipocambiowwds_18_tfmondsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] like @lV77Configuracion_tipocambiowwds_18_tfmondsc)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configuracion_tipocambiowwds_19_tfmondsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[MonDsc] = @AV78Configuracion_tipocambiowwds_19_tfmondsc_sel)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV79Configuracion_tipocambiowwds_20_tftipfech) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] >= @AV79Configuracion_tipocambiowwds_20_tftipfech)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Configuracion_tipocambiowwds_21_tftipfech_to) )
         {
            AddWhere(sWhereString, "(T1.[TipFech] <= @AV80Configuracion_tipocambiowwds_21_tftipfech_to)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV81Configuracion_tipocambiowwds_22_tftipcompra) )
         {
            AddWhere(sWhereString, "(T1.[TipCompra] >= @AV81Configuracion_tipocambiowwds_22_tftipcompra)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Configuracion_tipocambiowwds_23_tftipcompra_to) )
         {
            AddWhere(sWhereString, "(T1.[TipCompra] <= @AV82Configuracion_tipocambiowwds_23_tftipcompra_to)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV83Configuracion_tipocambiowwds_24_tftipventa) )
         {
            AddWhere(sWhereString, "(T1.[TipVenta] >= @AV83Configuracion_tipocambiowwds_24_tftipventa)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV84Configuracion_tipocambiowwds_25_tftipventa_to) )
         {
            AddWhere(sWhereString, "(T1.[TipVenta] <= @AV84Configuracion_tipocambiowwds_25_tftipventa_to)");
         }
         else
         {
            GXv_int1[28] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[MonDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00542(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (string)dynConstraints[25] , (DateTime)dynConstraints[26] , (decimal)dynConstraints[27] , (decimal)dynConstraints[28] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00542;
          prmP00542 = new Object[] {
          new ParDef("@lV62Configuracion_tipocambiowwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_tipocambiowwds_3_mondsc1",GXType.NChar,100,0) ,
          new ParDef("@AV63Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV63Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV63Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV63Configuracion_tipocambiowwds_4_tipfech1",GXType.Date,8,0) ,
          new ParDef("@AV64Configuracion_tipocambiowwds_5_tipfech_to1",GXType.Date,8,0) ,
          new ParDef("@lV68Configuracion_tipocambiowwds_9_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_tipocambiowwds_9_mondsc2",GXType.NChar,100,0) ,
          new ParDef("@AV69Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV69Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV69Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV69Configuracion_tipocambiowwds_10_tipfech2",GXType.Date,8,0) ,
          new ParDef("@AV70Configuracion_tipocambiowwds_11_tipfech_to2",GXType.Date,8,0) ,
          new ParDef("@lV74Configuracion_tipocambiowwds_15_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@lV74Configuracion_tipocambiowwds_15_mondsc3",GXType.NChar,100,0) ,
          new ParDef("@AV75Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV75Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV75Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV75Configuracion_tipocambiowwds_16_tipfech3",GXType.Date,8,0) ,
          new ParDef("@AV76Configuracion_tipocambiowwds_17_tipfech_to3",GXType.Date,8,0) ,
          new ParDef("@lV77Configuracion_tipocambiowwds_18_tfmondsc",GXType.NChar,100,0) ,
          new ParDef("@AV78Configuracion_tipocambiowwds_19_tfmondsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV79Configuracion_tipocambiowwds_20_tftipfech",GXType.Date,8,0) ,
          new ParDef("@AV80Configuracion_tipocambiowwds_21_tftipfech_to",GXType.Date,8,0) ,
          new ParDef("@AV81Configuracion_tipocambiowwds_22_tftipcompra",GXType.Decimal,15,5) ,
          new ParDef("@AV82Configuracion_tipocambiowwds_23_tftipcompra_to",GXType.Decimal,15,5) ,
          new ParDef("@AV83Configuracion_tipocambiowwds_24_tftipventa",GXType.Decimal,15,5) ,
          new ParDef("@AV84Configuracion_tipocambiowwds_25_tftipventa_to",GXType.Decimal,15,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00542", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00542,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(5);
                return;
       }
    }

 }

}
