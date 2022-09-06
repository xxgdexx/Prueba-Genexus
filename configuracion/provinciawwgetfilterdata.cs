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
   public class provinciawwgetfilterdata : GXProcedure
   {
      public provinciawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public provinciawwgetfilterdata( IGxContext context )
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
         provinciawwgetfilterdata objprovinciawwgetfilterdata;
         objprovinciawwgetfilterdata = new provinciawwgetfilterdata();
         objprovinciawwgetfilterdata.AV24DDOName = aP0_DDOName;
         objprovinciawwgetfilterdata.AV22SearchTxt = aP1_SearchTxt;
         objprovinciawwgetfilterdata.AV23SearchTxtTo = aP2_SearchTxtTo;
         objprovinciawwgetfilterdata.AV28OptionsJson = "" ;
         objprovinciawwgetfilterdata.AV31OptionsDescJson = "" ;
         objprovinciawwgetfilterdata.AV33OptionIndexesJson = "" ;
         objprovinciawwgetfilterdata.context.SetSubmitInitialConfig(context);
         objprovinciawwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objprovinciawwgetfilterdata);
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((provinciawwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_PROVCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADPROVCODOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_PROVDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADPROVDSCOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_PAIDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADPAIDSCOPTIONS' */
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
         if ( StringUtil.StrCmp(AV35Session.Get("Configuracion.ProvinciaWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.ProvinciaWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("Configuracion.ProvinciaWWGridState"), null, "", "");
         }
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVCOD") == 0 )
            {
               AV12TFProvCod = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVCOD_SEL") == 0 )
            {
               AV13TFProvCod_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVDSC") == 0 )
            {
               AV14TFProvDsc = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVDSC_SEL") == 0 )
            {
               AV15TFProvDsc_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPAIDSC") == 0 )
            {
               AV16TFPaiDsc = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPAIDSC_SEL") == 0 )
            {
               AV17TFPaiDsc_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFPROVSTS_SEL") == 0 )
            {
               AV20TFProvSts_SelsJson = AV38GridStateFilterValue.gxTpr_Value;
               AV21TFProvSts_Sels.FromJSonString(AV20TFProvSts_SelsJson, null);
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
         if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV39GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "PROVDSC") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV39GridStateDynamicFilter.gxTpr_Operator;
               AV42ProvDsc1 = AV39GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV43DynamicFiltersEnabled2 = true;
               AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(2));
               AV44DynamicFiltersSelector2 = AV39GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV44DynamicFiltersSelector2, "PROVDSC") == 0 )
               {
                  AV45DynamicFiltersOperator2 = AV39GridStateDynamicFilter.gxTpr_Operator;
                  AV46ProvDsc2 = AV39GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV37GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV39GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV37GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV39GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "PROVDSC") == 0 )
                  {
                     AV49DynamicFiltersOperator3 = AV39GridStateDynamicFilter.gxTpr_Operator;
                     AV50ProvDsc3 = AV39GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPROVCODOPTIONS' Routine */
         returnInSub = false;
         AV12TFProvCod = AV22SearchTxt;
         AV13TFProvCod_Sel = "";
         AV55Configuracion_provinciawwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV57Configuracion_provinciawwds_3_provdsc1 = AV42ProvDsc1;
         AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV59Configuracion_provinciawwds_5_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV61Configuracion_provinciawwds_7_provdsc2 = AV46ProvDsc2;
         AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV63Configuracion_provinciawwds_9_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV65Configuracion_provinciawwds_11_provdsc3 = AV50ProvDsc3;
         AV66Configuracion_provinciawwds_12_tfprovcod = AV12TFProvCod;
         AV67Configuracion_provinciawwds_13_tfprovcod_sel = AV13TFProvCod_Sel;
         AV68Configuracion_provinciawwds_14_tfprovdsc = AV14TFProvDsc;
         AV69Configuracion_provinciawwds_15_tfprovdsc_sel = AV15TFProvDsc_Sel;
         AV70Configuracion_provinciawwds_16_tfpaidsc = AV16TFPaiDsc;
         AV71Configuracion_provinciawwds_17_tfpaidsc_sel = AV17TFPaiDsc_Sel;
         AV72Configuracion_provinciawwds_18_tfprovsts_sels = AV21TFProvSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1742ProvSts ,
                                              AV72Configuracion_provinciawwds_18_tfprovsts_sels ,
                                              AV55Configuracion_provinciawwds_1_dynamicfiltersselector1 ,
                                              AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 ,
                                              AV57Configuracion_provinciawwds_3_provdsc1 ,
                                              AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 ,
                                              AV59Configuracion_provinciawwds_5_dynamicfiltersselector2 ,
                                              AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 ,
                                              AV61Configuracion_provinciawwds_7_provdsc2 ,
                                              AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 ,
                                              AV63Configuracion_provinciawwds_9_dynamicfiltersselector3 ,
                                              AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 ,
                                              AV65Configuracion_provinciawwds_11_provdsc3 ,
                                              AV67Configuracion_provinciawwds_13_tfprovcod_sel ,
                                              AV66Configuracion_provinciawwds_12_tfprovcod ,
                                              AV69Configuracion_provinciawwds_15_tfprovdsc_sel ,
                                              AV68Configuracion_provinciawwds_14_tfprovdsc ,
                                              AV71Configuracion_provinciawwds_17_tfpaidsc_sel ,
                                              AV70Configuracion_provinciawwds_16_tfpaidsc ,
                                              AV72Configuracion_provinciawwds_18_tfprovsts_sels.Count ,
                                              A603ProvDsc ,
                                              A141ProvCod ,
                                              A1500PaiDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV57Configuracion_provinciawwds_3_provdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_provinciawwds_3_provdsc1), 100, "%");
         lV57Configuracion_provinciawwds_3_provdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_provinciawwds_3_provdsc1), 100, "%");
         lV61Configuracion_provinciawwds_7_provdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_provinciawwds_7_provdsc2), 100, "%");
         lV61Configuracion_provinciawwds_7_provdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_provinciawwds_7_provdsc2), 100, "%");
         lV65Configuracion_provinciawwds_11_provdsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_provinciawwds_11_provdsc3), 100, "%");
         lV65Configuracion_provinciawwds_11_provdsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_provinciawwds_11_provdsc3), 100, "%");
         lV66Configuracion_provinciawwds_12_tfprovcod = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_provinciawwds_12_tfprovcod), 4, "%");
         lV68Configuracion_provinciawwds_14_tfprovdsc = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_provinciawwds_14_tfprovdsc), 100, "%");
         lV70Configuracion_provinciawwds_16_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_provinciawwds_16_tfpaidsc), 100, "%");
         /* Using cursor P003S2 */
         pr_default.execute(0, new Object[] {lV57Configuracion_provinciawwds_3_provdsc1, lV57Configuracion_provinciawwds_3_provdsc1, lV61Configuracion_provinciawwds_7_provdsc2, lV61Configuracion_provinciawwds_7_provdsc2, lV65Configuracion_provinciawwds_11_provdsc3, lV65Configuracion_provinciawwds_11_provdsc3, lV66Configuracion_provinciawwds_12_tfprovcod, AV67Configuracion_provinciawwds_13_tfprovcod_sel, lV68Configuracion_provinciawwds_14_tfprovdsc, AV69Configuracion_provinciawwds_15_tfprovdsc_sel, lV70Configuracion_provinciawwds_16_tfpaidsc, AV71Configuracion_provinciawwds_17_tfpaidsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3S2 = false;
            A139PaiCod = P003S2_A139PaiCod[0];
            A141ProvCod = P003S2_A141ProvCod[0];
            A1742ProvSts = P003S2_A1742ProvSts[0];
            A1500PaiDsc = P003S2_A1500PaiDsc[0];
            A603ProvDsc = P003S2_A603ProvDsc[0];
            A140EstCod = P003S2_A140EstCod[0];
            A1500PaiDsc = P003S2_A1500PaiDsc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P003S2_A141ProvCod[0], A141ProvCod) == 0 ) )
            {
               BRK3S2 = false;
               A139PaiCod = P003S2_A139PaiCod[0];
               A140EstCod = P003S2_A140EstCod[0];
               AV34count = (long)(AV34count+1);
               BRK3S2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A141ProvCod)) )
            {
               AV26Option = A141ProvCod;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK3S2 )
            {
               BRK3S2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROVDSCOPTIONS' Routine */
         returnInSub = false;
         AV14TFProvDsc = AV22SearchTxt;
         AV15TFProvDsc_Sel = "";
         AV55Configuracion_provinciawwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV57Configuracion_provinciawwds_3_provdsc1 = AV42ProvDsc1;
         AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV59Configuracion_provinciawwds_5_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV61Configuracion_provinciawwds_7_provdsc2 = AV46ProvDsc2;
         AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV63Configuracion_provinciawwds_9_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV65Configuracion_provinciawwds_11_provdsc3 = AV50ProvDsc3;
         AV66Configuracion_provinciawwds_12_tfprovcod = AV12TFProvCod;
         AV67Configuracion_provinciawwds_13_tfprovcod_sel = AV13TFProvCod_Sel;
         AV68Configuracion_provinciawwds_14_tfprovdsc = AV14TFProvDsc;
         AV69Configuracion_provinciawwds_15_tfprovdsc_sel = AV15TFProvDsc_Sel;
         AV70Configuracion_provinciawwds_16_tfpaidsc = AV16TFPaiDsc;
         AV71Configuracion_provinciawwds_17_tfpaidsc_sel = AV17TFPaiDsc_Sel;
         AV72Configuracion_provinciawwds_18_tfprovsts_sels = AV21TFProvSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1742ProvSts ,
                                              AV72Configuracion_provinciawwds_18_tfprovsts_sels ,
                                              AV55Configuracion_provinciawwds_1_dynamicfiltersselector1 ,
                                              AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 ,
                                              AV57Configuracion_provinciawwds_3_provdsc1 ,
                                              AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 ,
                                              AV59Configuracion_provinciawwds_5_dynamicfiltersselector2 ,
                                              AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 ,
                                              AV61Configuracion_provinciawwds_7_provdsc2 ,
                                              AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 ,
                                              AV63Configuracion_provinciawwds_9_dynamicfiltersselector3 ,
                                              AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 ,
                                              AV65Configuracion_provinciawwds_11_provdsc3 ,
                                              AV67Configuracion_provinciawwds_13_tfprovcod_sel ,
                                              AV66Configuracion_provinciawwds_12_tfprovcod ,
                                              AV69Configuracion_provinciawwds_15_tfprovdsc_sel ,
                                              AV68Configuracion_provinciawwds_14_tfprovdsc ,
                                              AV71Configuracion_provinciawwds_17_tfpaidsc_sel ,
                                              AV70Configuracion_provinciawwds_16_tfpaidsc ,
                                              AV72Configuracion_provinciawwds_18_tfprovsts_sels.Count ,
                                              A603ProvDsc ,
                                              A141ProvCod ,
                                              A1500PaiDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV57Configuracion_provinciawwds_3_provdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_provinciawwds_3_provdsc1), 100, "%");
         lV57Configuracion_provinciawwds_3_provdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_provinciawwds_3_provdsc1), 100, "%");
         lV61Configuracion_provinciawwds_7_provdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_provinciawwds_7_provdsc2), 100, "%");
         lV61Configuracion_provinciawwds_7_provdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_provinciawwds_7_provdsc2), 100, "%");
         lV65Configuracion_provinciawwds_11_provdsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_provinciawwds_11_provdsc3), 100, "%");
         lV65Configuracion_provinciawwds_11_provdsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_provinciawwds_11_provdsc3), 100, "%");
         lV66Configuracion_provinciawwds_12_tfprovcod = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_provinciawwds_12_tfprovcod), 4, "%");
         lV68Configuracion_provinciawwds_14_tfprovdsc = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_provinciawwds_14_tfprovdsc), 100, "%");
         lV70Configuracion_provinciawwds_16_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_provinciawwds_16_tfpaidsc), 100, "%");
         /* Using cursor P003S3 */
         pr_default.execute(1, new Object[] {lV57Configuracion_provinciawwds_3_provdsc1, lV57Configuracion_provinciawwds_3_provdsc1, lV61Configuracion_provinciawwds_7_provdsc2, lV61Configuracion_provinciawwds_7_provdsc2, lV65Configuracion_provinciawwds_11_provdsc3, lV65Configuracion_provinciawwds_11_provdsc3, lV66Configuracion_provinciawwds_12_tfprovcod, AV67Configuracion_provinciawwds_13_tfprovcod_sel, lV68Configuracion_provinciawwds_14_tfprovdsc, AV69Configuracion_provinciawwds_15_tfprovdsc_sel, lV70Configuracion_provinciawwds_16_tfpaidsc, AV71Configuracion_provinciawwds_17_tfpaidsc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK3S4 = false;
            A139PaiCod = P003S3_A139PaiCod[0];
            A603ProvDsc = P003S3_A603ProvDsc[0];
            A1742ProvSts = P003S3_A1742ProvSts[0];
            A1500PaiDsc = P003S3_A1500PaiDsc[0];
            A141ProvCod = P003S3_A141ProvCod[0];
            A140EstCod = P003S3_A140EstCod[0];
            A1500PaiDsc = P003S3_A1500PaiDsc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P003S3_A603ProvDsc[0], A603ProvDsc) == 0 ) )
            {
               BRK3S4 = false;
               A139PaiCod = P003S3_A139PaiCod[0];
               A141ProvCod = P003S3_A141ProvCod[0];
               A140EstCod = P003S3_A140EstCod[0];
               AV34count = (long)(AV34count+1);
               BRK3S4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A603ProvDsc)) )
            {
               AV26Option = A603ProvDsc;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK3S4 )
            {
               BRK3S4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPAIDSCOPTIONS' Routine */
         returnInSub = false;
         AV16TFPaiDsc = AV22SearchTxt;
         AV17TFPaiDsc_Sel = "";
         AV55Configuracion_provinciawwds_1_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV57Configuracion_provinciawwds_3_provdsc1 = AV42ProvDsc1;
         AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV59Configuracion_provinciawwds_5_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV61Configuracion_provinciawwds_7_provdsc2 = AV46ProvDsc2;
         AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV63Configuracion_provinciawwds_9_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV65Configuracion_provinciawwds_11_provdsc3 = AV50ProvDsc3;
         AV66Configuracion_provinciawwds_12_tfprovcod = AV12TFProvCod;
         AV67Configuracion_provinciawwds_13_tfprovcod_sel = AV13TFProvCod_Sel;
         AV68Configuracion_provinciawwds_14_tfprovdsc = AV14TFProvDsc;
         AV69Configuracion_provinciawwds_15_tfprovdsc_sel = AV15TFProvDsc_Sel;
         AV70Configuracion_provinciawwds_16_tfpaidsc = AV16TFPaiDsc;
         AV71Configuracion_provinciawwds_17_tfpaidsc_sel = AV17TFPaiDsc_Sel;
         AV72Configuracion_provinciawwds_18_tfprovsts_sels = AV21TFProvSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A1742ProvSts ,
                                              AV72Configuracion_provinciawwds_18_tfprovsts_sels ,
                                              AV55Configuracion_provinciawwds_1_dynamicfiltersselector1 ,
                                              AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 ,
                                              AV57Configuracion_provinciawwds_3_provdsc1 ,
                                              AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 ,
                                              AV59Configuracion_provinciawwds_5_dynamicfiltersselector2 ,
                                              AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 ,
                                              AV61Configuracion_provinciawwds_7_provdsc2 ,
                                              AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 ,
                                              AV63Configuracion_provinciawwds_9_dynamicfiltersselector3 ,
                                              AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 ,
                                              AV65Configuracion_provinciawwds_11_provdsc3 ,
                                              AV67Configuracion_provinciawwds_13_tfprovcod_sel ,
                                              AV66Configuracion_provinciawwds_12_tfprovcod ,
                                              AV69Configuracion_provinciawwds_15_tfprovdsc_sel ,
                                              AV68Configuracion_provinciawwds_14_tfprovdsc ,
                                              AV71Configuracion_provinciawwds_17_tfpaidsc_sel ,
                                              AV70Configuracion_provinciawwds_16_tfpaidsc ,
                                              AV72Configuracion_provinciawwds_18_tfprovsts_sels.Count ,
                                              A603ProvDsc ,
                                              A141ProvCod ,
                                              A1500PaiDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV57Configuracion_provinciawwds_3_provdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_provinciawwds_3_provdsc1), 100, "%");
         lV57Configuracion_provinciawwds_3_provdsc1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_provinciawwds_3_provdsc1), 100, "%");
         lV61Configuracion_provinciawwds_7_provdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_provinciawwds_7_provdsc2), 100, "%");
         lV61Configuracion_provinciawwds_7_provdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_provinciawwds_7_provdsc2), 100, "%");
         lV65Configuracion_provinciawwds_11_provdsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_provinciawwds_11_provdsc3), 100, "%");
         lV65Configuracion_provinciawwds_11_provdsc3 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_provinciawwds_11_provdsc3), 100, "%");
         lV66Configuracion_provinciawwds_12_tfprovcod = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_provinciawwds_12_tfprovcod), 4, "%");
         lV68Configuracion_provinciawwds_14_tfprovdsc = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_provinciawwds_14_tfprovdsc), 100, "%");
         lV70Configuracion_provinciawwds_16_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_provinciawwds_16_tfpaidsc), 100, "%");
         /* Using cursor P003S4 */
         pr_default.execute(2, new Object[] {lV57Configuracion_provinciawwds_3_provdsc1, lV57Configuracion_provinciawwds_3_provdsc1, lV61Configuracion_provinciawwds_7_provdsc2, lV61Configuracion_provinciawwds_7_provdsc2, lV65Configuracion_provinciawwds_11_provdsc3, lV65Configuracion_provinciawwds_11_provdsc3, lV66Configuracion_provinciawwds_12_tfprovcod, AV67Configuracion_provinciawwds_13_tfprovcod_sel, lV68Configuracion_provinciawwds_14_tfprovdsc, AV69Configuracion_provinciawwds_15_tfprovdsc_sel, lV70Configuracion_provinciawwds_16_tfpaidsc, AV71Configuracion_provinciawwds_17_tfpaidsc_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK3S6 = false;
            A139PaiCod = P003S4_A139PaiCod[0];
            A1500PaiDsc = P003S4_A1500PaiDsc[0];
            A1742ProvSts = P003S4_A1742ProvSts[0];
            A141ProvCod = P003S4_A141ProvCod[0];
            A603ProvDsc = P003S4_A603ProvDsc[0];
            A140EstCod = P003S4_A140EstCod[0];
            A1500PaiDsc = P003S4_A1500PaiDsc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P003S4_A1500PaiDsc[0], A1500PaiDsc) == 0 ) )
            {
               BRK3S6 = false;
               A139PaiCod = P003S4_A139PaiCod[0];
               A141ProvCod = P003S4_A141ProvCod[0];
               A140EstCod = P003S4_A140EstCod[0];
               AV34count = (long)(AV34count+1);
               BRK3S6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1500PaiDsc)) )
            {
               AV26Option = A1500PaiDsc;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK3S6 )
            {
               BRK3S6 = true;
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
         AV12TFProvCod = "";
         AV13TFProvCod_Sel = "";
         AV14TFProvDsc = "";
         AV15TFProvDsc_Sel = "";
         AV16TFPaiDsc = "";
         AV17TFPaiDsc_Sel = "";
         AV20TFProvSts_SelsJson = "";
         AV21TFProvSts_Sels = new GxSimpleCollection<short>();
         AV39GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV42ProvDsc1 = "";
         AV44DynamicFiltersSelector2 = "";
         AV46ProvDsc2 = "";
         AV48DynamicFiltersSelector3 = "";
         AV50ProvDsc3 = "";
         AV55Configuracion_provinciawwds_1_dynamicfiltersselector1 = "";
         AV57Configuracion_provinciawwds_3_provdsc1 = "";
         AV59Configuracion_provinciawwds_5_dynamicfiltersselector2 = "";
         AV61Configuracion_provinciawwds_7_provdsc2 = "";
         AV63Configuracion_provinciawwds_9_dynamicfiltersselector3 = "";
         AV65Configuracion_provinciawwds_11_provdsc3 = "";
         AV66Configuracion_provinciawwds_12_tfprovcod = "";
         AV67Configuracion_provinciawwds_13_tfprovcod_sel = "";
         AV68Configuracion_provinciawwds_14_tfprovdsc = "";
         AV69Configuracion_provinciawwds_15_tfprovdsc_sel = "";
         AV70Configuracion_provinciawwds_16_tfpaidsc = "";
         AV71Configuracion_provinciawwds_17_tfpaidsc_sel = "";
         AV72Configuracion_provinciawwds_18_tfprovsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV57Configuracion_provinciawwds_3_provdsc1 = "";
         lV61Configuracion_provinciawwds_7_provdsc2 = "";
         lV65Configuracion_provinciawwds_11_provdsc3 = "";
         lV66Configuracion_provinciawwds_12_tfprovcod = "";
         lV68Configuracion_provinciawwds_14_tfprovdsc = "";
         lV70Configuracion_provinciawwds_16_tfpaidsc = "";
         A603ProvDsc = "";
         A141ProvCod = "";
         A1500PaiDsc = "";
         P003S2_A139PaiCod = new string[] {""} ;
         P003S2_A141ProvCod = new string[] {""} ;
         P003S2_A1742ProvSts = new short[1] ;
         P003S2_A1500PaiDsc = new string[] {""} ;
         P003S2_A603ProvDsc = new string[] {""} ;
         P003S2_A140EstCod = new string[] {""} ;
         A139PaiCod = "";
         A140EstCod = "";
         AV26Option = "";
         P003S3_A139PaiCod = new string[] {""} ;
         P003S3_A603ProvDsc = new string[] {""} ;
         P003S3_A1742ProvSts = new short[1] ;
         P003S3_A1500PaiDsc = new string[] {""} ;
         P003S3_A141ProvCod = new string[] {""} ;
         P003S3_A140EstCod = new string[] {""} ;
         P003S4_A139PaiCod = new string[] {""} ;
         P003S4_A1500PaiDsc = new string[] {""} ;
         P003S4_A1742ProvSts = new short[1] ;
         P003S4_A141ProvCod = new string[] {""} ;
         P003S4_A603ProvDsc = new string[] {""} ;
         P003S4_A140EstCod = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.provinciawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003S2_A139PaiCod, P003S2_A141ProvCod, P003S2_A1742ProvSts, P003S2_A1500PaiDsc, P003S2_A603ProvDsc, P003S2_A140EstCod
               }
               , new Object[] {
               P003S3_A139PaiCod, P003S3_A603ProvDsc, P003S3_A1742ProvSts, P003S3_A1500PaiDsc, P003S3_A141ProvCod, P003S3_A140EstCod
               }
               , new Object[] {
               P003S4_A139PaiCod, P003S4_A1500PaiDsc, P003S4_A1742ProvSts, P003S4_A141ProvCod, P003S4_A603ProvDsc, P003S4_A140EstCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV41DynamicFiltersOperator1 ;
      private short AV45DynamicFiltersOperator2 ;
      private short AV49DynamicFiltersOperator3 ;
      private short AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 ;
      private short AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 ;
      private short AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 ;
      private short A1742ProvSts ;
      private int AV53GXV1 ;
      private int AV72Configuracion_provinciawwds_18_tfprovsts_sels_Count ;
      private long AV34count ;
      private string AV12TFProvCod ;
      private string AV13TFProvCod_Sel ;
      private string AV14TFProvDsc ;
      private string AV15TFProvDsc_Sel ;
      private string AV16TFPaiDsc ;
      private string AV17TFPaiDsc_Sel ;
      private string AV42ProvDsc1 ;
      private string AV46ProvDsc2 ;
      private string AV50ProvDsc3 ;
      private string AV57Configuracion_provinciawwds_3_provdsc1 ;
      private string AV61Configuracion_provinciawwds_7_provdsc2 ;
      private string AV65Configuracion_provinciawwds_11_provdsc3 ;
      private string AV66Configuracion_provinciawwds_12_tfprovcod ;
      private string AV67Configuracion_provinciawwds_13_tfprovcod_sel ;
      private string AV68Configuracion_provinciawwds_14_tfprovdsc ;
      private string AV69Configuracion_provinciawwds_15_tfprovdsc_sel ;
      private string AV70Configuracion_provinciawwds_16_tfpaidsc ;
      private string AV71Configuracion_provinciawwds_17_tfpaidsc_sel ;
      private string scmdbuf ;
      private string lV57Configuracion_provinciawwds_3_provdsc1 ;
      private string lV61Configuracion_provinciawwds_7_provdsc2 ;
      private string lV65Configuracion_provinciawwds_11_provdsc3 ;
      private string lV66Configuracion_provinciawwds_12_tfprovcod ;
      private string lV68Configuracion_provinciawwds_14_tfprovdsc ;
      private string lV70Configuracion_provinciawwds_16_tfpaidsc ;
      private string A603ProvDsc ;
      private string A141ProvCod ;
      private string A1500PaiDsc ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private bool returnInSub ;
      private bool AV43DynamicFiltersEnabled2 ;
      private bool AV47DynamicFiltersEnabled3 ;
      private bool AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 ;
      private bool AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 ;
      private bool BRK3S2 ;
      private bool BRK3S4 ;
      private bool BRK3S6 ;
      private string AV28OptionsJson ;
      private string AV31OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV20TFProvSts_SelsJson ;
      private string AV24DDOName ;
      private string AV22SearchTxt ;
      private string AV23SearchTxtTo ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV44DynamicFiltersSelector2 ;
      private string AV48DynamicFiltersSelector3 ;
      private string AV55Configuracion_provinciawwds_1_dynamicfiltersselector1 ;
      private string AV59Configuracion_provinciawwds_5_dynamicfiltersselector2 ;
      private string AV63Configuracion_provinciawwds_9_dynamicfiltersselector3 ;
      private string AV26Option ;
      private GxSimpleCollection<short> AV21TFProvSts_Sels ;
      private GxSimpleCollection<short> AV72Configuracion_provinciawwds_18_tfprovsts_sels ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003S2_A139PaiCod ;
      private string[] P003S2_A141ProvCod ;
      private short[] P003S2_A1742ProvSts ;
      private string[] P003S2_A1500PaiDsc ;
      private string[] P003S2_A603ProvDsc ;
      private string[] P003S2_A140EstCod ;
      private string[] P003S3_A139PaiCod ;
      private string[] P003S3_A603ProvDsc ;
      private short[] P003S3_A1742ProvSts ;
      private string[] P003S3_A1500PaiDsc ;
      private string[] P003S3_A141ProvCod ;
      private string[] P003S3_A140EstCod ;
      private string[] P003S4_A139PaiCod ;
      private string[] P003S4_A1500PaiDsc ;
      private short[] P003S4_A1742ProvSts ;
      private string[] P003S4_A141ProvCod ;
      private string[] P003S4_A603ProvDsc ;
      private string[] P003S4_A140EstCod ;
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

   public class provinciawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003S2( IGxContext context ,
                                             short A1742ProvSts ,
                                             GxSimpleCollection<short> AV72Configuracion_provinciawwds_18_tfprovsts_sels ,
                                             string AV55Configuracion_provinciawwds_1_dynamicfiltersselector1 ,
                                             short AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 ,
                                             string AV57Configuracion_provinciawwds_3_provdsc1 ,
                                             bool AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 ,
                                             string AV59Configuracion_provinciawwds_5_dynamicfiltersselector2 ,
                                             short AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 ,
                                             string AV61Configuracion_provinciawwds_7_provdsc2 ,
                                             bool AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 ,
                                             string AV63Configuracion_provinciawwds_9_dynamicfiltersselector3 ,
                                             short AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 ,
                                             string AV65Configuracion_provinciawwds_11_provdsc3 ,
                                             string AV67Configuracion_provinciawwds_13_tfprovcod_sel ,
                                             string AV66Configuracion_provinciawwds_12_tfprovcod ,
                                             string AV69Configuracion_provinciawwds_15_tfprovdsc_sel ,
                                             string AV68Configuracion_provinciawwds_14_tfprovdsc ,
                                             string AV71Configuracion_provinciawwds_17_tfpaidsc_sel ,
                                             string AV70Configuracion_provinciawwds_16_tfpaidsc ,
                                             int AV72Configuracion_provinciawwds_18_tfprovsts_sels_Count ,
                                             string A603ProvDsc ,
                                             string A141ProvCod ,
                                             string A1500PaiDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[PaiCod], T1.[ProvCod], T1.[ProvSts], T2.[PaiDsc], T1.[ProvDsc], T1.[EstCod] FROM ([CPROVINCIA] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod])";
         if ( ( StringUtil.StrCmp(AV55Configuracion_provinciawwds_1_dynamicfiltersselector1, "PROVDSC") == 0 ) && ( AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_provinciawwds_3_provdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV57Configuracion_provinciawwds_3_provdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_provinciawwds_1_dynamicfiltersselector1, "PROVDSC") == 0 ) && ( AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_provinciawwds_3_provdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like '%' + @lV57Configuracion_provinciawwds_3_provdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_provinciawwds_5_dynamicfiltersselector2, "PROVDSC") == 0 ) && ( AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_provinciawwds_7_provdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV61Configuracion_provinciawwds_7_provdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_provinciawwds_5_dynamicfiltersselector2, "PROVDSC") == 0 ) && ( AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_provinciawwds_7_provdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like '%' + @lV61Configuracion_provinciawwds_7_provdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_provinciawwds_9_dynamicfiltersselector3, "PROVDSC") == 0 ) && ( AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_provinciawwds_11_provdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV65Configuracion_provinciawwds_11_provdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_provinciawwds_9_dynamicfiltersselector3, "PROVDSC") == 0 ) && ( AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_provinciawwds_11_provdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like '%' + @lV65Configuracion_provinciawwds_11_provdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_provinciawwds_13_tfprovcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_provinciawwds_12_tfprovcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvCod] like @lV66Configuracion_provinciawwds_12_tfprovcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_provinciawwds_13_tfprovcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProvCod] = @AV67Configuracion_provinciawwds_13_tfprovcod_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_provinciawwds_15_tfprovdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_provinciawwds_14_tfprovdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV68Configuracion_provinciawwds_14_tfprovdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_provinciawwds_15_tfprovdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] = @AV69Configuracion_provinciawwds_15_tfprovdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_provinciawwds_17_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_provinciawwds_16_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] like @lV70Configuracion_provinciawwds_16_tfpaidsc)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_provinciawwds_17_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] = @AV71Configuracion_provinciawwds_17_tfpaidsc_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV72Configuracion_provinciawwds_18_tfprovsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Configuracion_provinciawwds_18_tfprovsts_sels, "T1.[ProvSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProvCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P003S3( IGxContext context ,
                                             short A1742ProvSts ,
                                             GxSimpleCollection<short> AV72Configuracion_provinciawwds_18_tfprovsts_sels ,
                                             string AV55Configuracion_provinciawwds_1_dynamicfiltersselector1 ,
                                             short AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 ,
                                             string AV57Configuracion_provinciawwds_3_provdsc1 ,
                                             bool AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 ,
                                             string AV59Configuracion_provinciawwds_5_dynamicfiltersselector2 ,
                                             short AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 ,
                                             string AV61Configuracion_provinciawwds_7_provdsc2 ,
                                             bool AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 ,
                                             string AV63Configuracion_provinciawwds_9_dynamicfiltersselector3 ,
                                             short AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 ,
                                             string AV65Configuracion_provinciawwds_11_provdsc3 ,
                                             string AV67Configuracion_provinciawwds_13_tfprovcod_sel ,
                                             string AV66Configuracion_provinciawwds_12_tfprovcod ,
                                             string AV69Configuracion_provinciawwds_15_tfprovdsc_sel ,
                                             string AV68Configuracion_provinciawwds_14_tfprovdsc ,
                                             string AV71Configuracion_provinciawwds_17_tfpaidsc_sel ,
                                             string AV70Configuracion_provinciawwds_16_tfpaidsc ,
                                             int AV72Configuracion_provinciawwds_18_tfprovsts_sels_Count ,
                                             string A603ProvDsc ,
                                             string A141ProvCod ,
                                             string A1500PaiDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[PaiCod], T1.[ProvDsc], T1.[ProvSts], T2.[PaiDsc], T1.[ProvCod], T1.[EstCod] FROM ([CPROVINCIA] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod])";
         if ( ( StringUtil.StrCmp(AV55Configuracion_provinciawwds_1_dynamicfiltersselector1, "PROVDSC") == 0 ) && ( AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_provinciawwds_3_provdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV57Configuracion_provinciawwds_3_provdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_provinciawwds_1_dynamicfiltersselector1, "PROVDSC") == 0 ) && ( AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_provinciawwds_3_provdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like '%' + @lV57Configuracion_provinciawwds_3_provdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_provinciawwds_5_dynamicfiltersselector2, "PROVDSC") == 0 ) && ( AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_provinciawwds_7_provdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV61Configuracion_provinciawwds_7_provdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_provinciawwds_5_dynamicfiltersselector2, "PROVDSC") == 0 ) && ( AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_provinciawwds_7_provdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like '%' + @lV61Configuracion_provinciawwds_7_provdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_provinciawwds_9_dynamicfiltersselector3, "PROVDSC") == 0 ) && ( AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_provinciawwds_11_provdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV65Configuracion_provinciawwds_11_provdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_provinciawwds_9_dynamicfiltersselector3, "PROVDSC") == 0 ) && ( AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_provinciawwds_11_provdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like '%' + @lV65Configuracion_provinciawwds_11_provdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_provinciawwds_13_tfprovcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_provinciawwds_12_tfprovcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvCod] like @lV66Configuracion_provinciawwds_12_tfprovcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_provinciawwds_13_tfprovcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProvCod] = @AV67Configuracion_provinciawwds_13_tfprovcod_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_provinciawwds_15_tfprovdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_provinciawwds_14_tfprovdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV68Configuracion_provinciawwds_14_tfprovdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_provinciawwds_15_tfprovdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] = @AV69Configuracion_provinciawwds_15_tfprovdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_provinciawwds_17_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_provinciawwds_16_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] like @lV70Configuracion_provinciawwds_16_tfpaidsc)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_provinciawwds_17_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] = @AV71Configuracion_provinciawwds_17_tfpaidsc_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV72Configuracion_provinciawwds_18_tfprovsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Configuracion_provinciawwds_18_tfprovsts_sels, "T1.[ProvSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProvDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P003S4( IGxContext context ,
                                             short A1742ProvSts ,
                                             GxSimpleCollection<short> AV72Configuracion_provinciawwds_18_tfprovsts_sels ,
                                             string AV55Configuracion_provinciawwds_1_dynamicfiltersselector1 ,
                                             short AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 ,
                                             string AV57Configuracion_provinciawwds_3_provdsc1 ,
                                             bool AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 ,
                                             string AV59Configuracion_provinciawwds_5_dynamicfiltersselector2 ,
                                             short AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 ,
                                             string AV61Configuracion_provinciawwds_7_provdsc2 ,
                                             bool AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 ,
                                             string AV63Configuracion_provinciawwds_9_dynamicfiltersselector3 ,
                                             short AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 ,
                                             string AV65Configuracion_provinciawwds_11_provdsc3 ,
                                             string AV67Configuracion_provinciawwds_13_tfprovcod_sel ,
                                             string AV66Configuracion_provinciawwds_12_tfprovcod ,
                                             string AV69Configuracion_provinciawwds_15_tfprovdsc_sel ,
                                             string AV68Configuracion_provinciawwds_14_tfprovdsc ,
                                             string AV71Configuracion_provinciawwds_17_tfpaidsc_sel ,
                                             string AV70Configuracion_provinciawwds_16_tfpaidsc ,
                                             int AV72Configuracion_provinciawwds_18_tfprovsts_sels_Count ,
                                             string A603ProvDsc ,
                                             string A141ProvCod ,
                                             string A1500PaiDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[12];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[PaiCod], T2.[PaiDsc], T1.[ProvSts], T1.[ProvCod], T1.[ProvDsc], T1.[EstCod] FROM ([CPROVINCIA] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod])";
         if ( ( StringUtil.StrCmp(AV55Configuracion_provinciawwds_1_dynamicfiltersselector1, "PROVDSC") == 0 ) && ( AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_provinciawwds_3_provdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV57Configuracion_provinciawwds_3_provdsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Configuracion_provinciawwds_1_dynamicfiltersselector1, "PROVDSC") == 0 ) && ( AV56Configuracion_provinciawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_provinciawwds_3_provdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like '%' + @lV57Configuracion_provinciawwds_3_provdsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_provinciawwds_5_dynamicfiltersselector2, "PROVDSC") == 0 ) && ( AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_provinciawwds_7_provdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV61Configuracion_provinciawwds_7_provdsc2)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV58Configuracion_provinciawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_provinciawwds_5_dynamicfiltersselector2, "PROVDSC") == 0 ) && ( AV60Configuracion_provinciawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_provinciawwds_7_provdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like '%' + @lV61Configuracion_provinciawwds_7_provdsc2)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_provinciawwds_9_dynamicfiltersselector3, "PROVDSC") == 0 ) && ( AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_provinciawwds_11_provdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV65Configuracion_provinciawwds_11_provdsc3)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV62Configuracion_provinciawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Configuracion_provinciawwds_9_dynamicfiltersselector3, "PROVDSC") == 0 ) && ( AV64Configuracion_provinciawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_provinciawwds_11_provdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like '%' + @lV65Configuracion_provinciawwds_11_provdsc3)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_provinciawwds_13_tfprovcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_provinciawwds_12_tfprovcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvCod] like @lV66Configuracion_provinciawwds_12_tfprovcod)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_provinciawwds_13_tfprovcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProvCod] = @AV67Configuracion_provinciawwds_13_tfprovcod_sel)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_provinciawwds_15_tfprovdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_provinciawwds_14_tfprovdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] like @lV68Configuracion_provinciawwds_14_tfprovdsc)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_provinciawwds_15_tfprovdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[ProvDsc] = @AV69Configuracion_provinciawwds_15_tfprovdsc_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_provinciawwds_17_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_provinciawwds_16_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] like @lV70Configuracion_provinciawwds_16_tfpaidsc)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_provinciawwds_17_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] = @AV71Configuracion_provinciawwds_17_tfpaidsc_sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV72Configuracion_provinciawwds_18_tfprovsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Configuracion_provinciawwds_18_tfprovsts_sels, "T1.[ProvSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[PaiDsc]";
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
                     return conditional_P003S2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] );
               case 1 :
                     return conditional_P003S3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] );
               case 2 :
                     return conditional_P003S4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP003S2;
          prmP003S2 = new Object[] {
          new ParDef("@lV57Configuracion_provinciawwds_3_provdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_provinciawwds_3_provdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_provinciawwds_7_provdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_provinciawwds_7_provdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_provinciawwds_11_provdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_provinciawwds_11_provdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_provinciawwds_12_tfprovcod",GXType.NChar,4,0) ,
          new ParDef("@AV67Configuracion_provinciawwds_13_tfprovcod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV68Configuracion_provinciawwds_14_tfprovdsc",GXType.NChar,100,0) ,
          new ParDef("@AV69Configuracion_provinciawwds_15_tfprovdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_provinciawwds_16_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV71Configuracion_provinciawwds_17_tfpaidsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP003S3;
          prmP003S3 = new Object[] {
          new ParDef("@lV57Configuracion_provinciawwds_3_provdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_provinciawwds_3_provdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_provinciawwds_7_provdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_provinciawwds_7_provdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_provinciawwds_11_provdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_provinciawwds_11_provdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_provinciawwds_12_tfprovcod",GXType.NChar,4,0) ,
          new ParDef("@AV67Configuracion_provinciawwds_13_tfprovcod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV68Configuracion_provinciawwds_14_tfprovdsc",GXType.NChar,100,0) ,
          new ParDef("@AV69Configuracion_provinciawwds_15_tfprovdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_provinciawwds_16_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV71Configuracion_provinciawwds_17_tfpaidsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP003S4;
          prmP003S4 = new Object[] {
          new ParDef("@lV57Configuracion_provinciawwds_3_provdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_provinciawwds_3_provdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_provinciawwds_7_provdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_provinciawwds_7_provdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_provinciawwds_11_provdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_provinciawwds_11_provdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_provinciawwds_12_tfprovcod",GXType.NChar,4,0) ,
          new ParDef("@AV67Configuracion_provinciawwds_13_tfprovcod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV68Configuracion_provinciawwds_14_tfprovdsc",GXType.NChar,100,0) ,
          new ParDef("@AV69Configuracion_provinciawwds_15_tfprovdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_provinciawwds_16_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV71Configuracion_provinciawwds_17_tfpaidsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003S2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003S3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003S4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003S4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getString(6, 4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 4);
                ((string[]) buf[5])[0] = rslt.getString(6, 4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getString(6, 4);
                return;
       }
    }

 }

}
