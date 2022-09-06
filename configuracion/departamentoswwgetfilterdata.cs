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
   public class departamentoswwgetfilterdata : GXProcedure
   {
      public departamentoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public departamentoswwgetfilterdata( IGxContext context )
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
         departamentoswwgetfilterdata objdepartamentoswwgetfilterdata;
         objdepartamentoswwgetfilterdata = new departamentoswwgetfilterdata();
         objdepartamentoswwgetfilterdata.AV20DDOName = aP0_DDOName;
         objdepartamentoswwgetfilterdata.AV18SearchTxt = aP1_SearchTxt;
         objdepartamentoswwgetfilterdata.AV19SearchTxtTo = aP2_SearchTxtTo;
         objdepartamentoswwgetfilterdata.AV24OptionsJson = "" ;
         objdepartamentoswwgetfilterdata.AV27OptionsDescJson = "" ;
         objdepartamentoswwgetfilterdata.AV29OptionIndexesJson = "" ;
         objdepartamentoswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objdepartamentoswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objdepartamentoswwgetfilterdata);
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((departamentoswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_ESTCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADESTCODOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_ESTDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADESTDSCOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_PAIDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADPAIDSCOPTIONS' */
            S141 ();
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
         if ( StringUtil.StrCmp(AV31Session.Get("Configuracion.DepartamentosWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.DepartamentosWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Configuracion.DepartamentosWWGridState"), null, "", "");
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTCOD") == 0 )
            {
               AV10TFEstCod = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTCOD_SEL") == 0 )
            {
               AV11TFEstCod_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTDSC") == 0 )
            {
               AV12TFEstDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTDSC_SEL") == 0 )
            {
               AV13TFEstDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPAIDSC") == 0 )
            {
               AV14TFPaiDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPAIDSC_SEL") == 0 )
            {
               AV15TFPaiDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFESTSTS_SEL") == 0 )
            {
               AV16TFEstSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV17TFEstSts_Sels.FromJSonString(AV16TFEstSts_SelsJson, null);
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "ESTDSC") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV38EstDsc1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "PAICOD") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV47PaiCod1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "ESTDSC") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV42EstDsc2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "PAICOD") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV48PaiCod2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "ESTDSC") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV46EstDsc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "PAICOD") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV49PaiCod3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADESTCODOPTIONS' Routine */
         returnInSub = false;
         AV10TFEstCod = AV18SearchTxt;
         AV11TFEstCod_Sel = "";
         AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV56Configuracion_departamentoswwds_3_estdsc1 = AV38EstDsc1;
         AV57Configuracion_departamentoswwds_4_paicod1 = AV47PaiCod1;
         AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV61Configuracion_departamentoswwds_8_estdsc2 = AV42EstDsc2;
         AV62Configuracion_departamentoswwds_9_paicod2 = AV48PaiCod2;
         AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV66Configuracion_departamentoswwds_13_estdsc3 = AV46EstDsc3;
         AV67Configuracion_departamentoswwds_14_paicod3 = AV49PaiCod3;
         AV68Configuracion_departamentoswwds_15_tfestcod = AV10TFEstCod;
         AV69Configuracion_departamentoswwds_16_tfestcod_sel = AV11TFEstCod_Sel;
         AV70Configuracion_departamentoswwds_17_tfestdsc = AV12TFEstDsc;
         AV71Configuracion_departamentoswwds_18_tfestdsc_sel = AV13TFEstDsc_Sel;
         AV72Configuracion_departamentoswwds_19_tfpaidsc = AV14TFPaiDsc;
         AV73Configuracion_departamentoswwds_20_tfpaidsc_sel = AV15TFPaiDsc_Sel;
         AV74Configuracion_departamentoswwds_21_tfeststs_sels = AV17TFEstSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A975EstSts ,
                                              AV74Configuracion_departamentoswwds_21_tfeststs_sels ,
                                              AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1 ,
                                              AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 ,
                                              AV56Configuracion_departamentoswwds_3_estdsc1 ,
                                              AV57Configuracion_departamentoswwds_4_paicod1 ,
                                              AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 ,
                                              AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2 ,
                                              AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 ,
                                              AV61Configuracion_departamentoswwds_8_estdsc2 ,
                                              AV62Configuracion_departamentoswwds_9_paicod2 ,
                                              AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 ,
                                              AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3 ,
                                              AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 ,
                                              AV66Configuracion_departamentoswwds_13_estdsc3 ,
                                              AV67Configuracion_departamentoswwds_14_paicod3 ,
                                              AV69Configuracion_departamentoswwds_16_tfestcod_sel ,
                                              AV68Configuracion_departamentoswwds_15_tfestcod ,
                                              AV71Configuracion_departamentoswwds_18_tfestdsc_sel ,
                                              AV70Configuracion_departamentoswwds_17_tfestdsc ,
                                              AV73Configuracion_departamentoswwds_20_tfpaidsc_sel ,
                                              AV72Configuracion_departamentoswwds_19_tfpaidsc ,
                                              AV74Configuracion_departamentoswwds_21_tfeststs_sels.Count ,
                                              A602EstDsc ,
                                              A139PaiCod ,
                                              A140EstCod ,
                                              A1500PaiDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV56Configuracion_departamentoswwds_3_estdsc1 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_departamentoswwds_3_estdsc1), 100, "%");
         lV56Configuracion_departamentoswwds_3_estdsc1 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_departamentoswwds_3_estdsc1), 100, "%");
         lV57Configuracion_departamentoswwds_4_paicod1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_departamentoswwds_4_paicod1), 4, "%");
         lV57Configuracion_departamentoswwds_4_paicod1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_departamentoswwds_4_paicod1), 4, "%");
         lV61Configuracion_departamentoswwds_8_estdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_departamentoswwds_8_estdsc2), 100, "%");
         lV61Configuracion_departamentoswwds_8_estdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_departamentoswwds_8_estdsc2), 100, "%");
         lV62Configuracion_departamentoswwds_9_paicod2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_departamentoswwds_9_paicod2), 4, "%");
         lV62Configuracion_departamentoswwds_9_paicod2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_departamentoswwds_9_paicod2), 4, "%");
         lV66Configuracion_departamentoswwds_13_estdsc3 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_departamentoswwds_13_estdsc3), 100, "%");
         lV66Configuracion_departamentoswwds_13_estdsc3 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_departamentoswwds_13_estdsc3), 100, "%");
         lV67Configuracion_departamentoswwds_14_paicod3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_departamentoswwds_14_paicod3), 4, "%");
         lV67Configuracion_departamentoswwds_14_paicod3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_departamentoswwds_14_paicod3), 4, "%");
         lV68Configuracion_departamentoswwds_15_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_departamentoswwds_15_tfestcod), 4, "%");
         lV70Configuracion_departamentoswwds_17_tfestdsc = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_departamentoswwds_17_tfestdsc), 100, "%");
         lV72Configuracion_departamentoswwds_19_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_departamentoswwds_19_tfpaidsc), 100, "%");
         /* Using cursor P003K2 */
         pr_default.execute(0, new Object[] {lV56Configuracion_departamentoswwds_3_estdsc1, lV56Configuracion_departamentoswwds_3_estdsc1, lV57Configuracion_departamentoswwds_4_paicod1, lV57Configuracion_departamentoswwds_4_paicod1, lV61Configuracion_departamentoswwds_8_estdsc2, lV61Configuracion_departamentoswwds_8_estdsc2, lV62Configuracion_departamentoswwds_9_paicod2, lV62Configuracion_departamentoswwds_9_paicod2, lV66Configuracion_departamentoswwds_13_estdsc3, lV66Configuracion_departamentoswwds_13_estdsc3, lV67Configuracion_departamentoswwds_14_paicod3, lV67Configuracion_departamentoswwds_14_paicod3, lV68Configuracion_departamentoswwds_15_tfestcod, AV69Configuracion_departamentoswwds_16_tfestcod_sel, lV70Configuracion_departamentoswwds_17_tfestdsc, AV71Configuracion_departamentoswwds_18_tfestdsc_sel, lV72Configuracion_departamentoswwds_19_tfpaidsc, AV73Configuracion_departamentoswwds_20_tfpaidsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3K2 = false;
            A140EstCod = P003K2_A140EstCod[0];
            A975EstSts = P003K2_A975EstSts[0];
            A1500PaiDsc = P003K2_A1500PaiDsc[0];
            A139PaiCod = P003K2_A139PaiCod[0];
            A602EstDsc = P003K2_A602EstDsc[0];
            A1500PaiDsc = P003K2_A1500PaiDsc[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P003K2_A140EstCod[0], A140EstCod) == 0 ) )
            {
               BRK3K2 = false;
               A139PaiCod = P003K2_A139PaiCod[0];
               AV30count = (long)(AV30count+1);
               BRK3K2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A140EstCod)) )
            {
               AV22Option = A140EstCod;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK3K2 )
            {
               BRK3K2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADESTDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFEstDsc = AV18SearchTxt;
         AV13TFEstDsc_Sel = "";
         AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV56Configuracion_departamentoswwds_3_estdsc1 = AV38EstDsc1;
         AV57Configuracion_departamentoswwds_4_paicod1 = AV47PaiCod1;
         AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV61Configuracion_departamentoswwds_8_estdsc2 = AV42EstDsc2;
         AV62Configuracion_departamentoswwds_9_paicod2 = AV48PaiCod2;
         AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV66Configuracion_departamentoswwds_13_estdsc3 = AV46EstDsc3;
         AV67Configuracion_departamentoswwds_14_paicod3 = AV49PaiCod3;
         AV68Configuracion_departamentoswwds_15_tfestcod = AV10TFEstCod;
         AV69Configuracion_departamentoswwds_16_tfestcod_sel = AV11TFEstCod_Sel;
         AV70Configuracion_departamentoswwds_17_tfestdsc = AV12TFEstDsc;
         AV71Configuracion_departamentoswwds_18_tfestdsc_sel = AV13TFEstDsc_Sel;
         AV72Configuracion_departamentoswwds_19_tfpaidsc = AV14TFPaiDsc;
         AV73Configuracion_departamentoswwds_20_tfpaidsc_sel = AV15TFPaiDsc_Sel;
         AV74Configuracion_departamentoswwds_21_tfeststs_sels = AV17TFEstSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A975EstSts ,
                                              AV74Configuracion_departamentoswwds_21_tfeststs_sels ,
                                              AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1 ,
                                              AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 ,
                                              AV56Configuracion_departamentoswwds_3_estdsc1 ,
                                              AV57Configuracion_departamentoswwds_4_paicod1 ,
                                              AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 ,
                                              AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2 ,
                                              AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 ,
                                              AV61Configuracion_departamentoswwds_8_estdsc2 ,
                                              AV62Configuracion_departamentoswwds_9_paicod2 ,
                                              AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 ,
                                              AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3 ,
                                              AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 ,
                                              AV66Configuracion_departamentoswwds_13_estdsc3 ,
                                              AV67Configuracion_departamentoswwds_14_paicod3 ,
                                              AV69Configuracion_departamentoswwds_16_tfestcod_sel ,
                                              AV68Configuracion_departamentoswwds_15_tfestcod ,
                                              AV71Configuracion_departamentoswwds_18_tfestdsc_sel ,
                                              AV70Configuracion_departamentoswwds_17_tfestdsc ,
                                              AV73Configuracion_departamentoswwds_20_tfpaidsc_sel ,
                                              AV72Configuracion_departamentoswwds_19_tfpaidsc ,
                                              AV74Configuracion_departamentoswwds_21_tfeststs_sels.Count ,
                                              A602EstDsc ,
                                              A139PaiCod ,
                                              A140EstCod ,
                                              A1500PaiDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV56Configuracion_departamentoswwds_3_estdsc1 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_departamentoswwds_3_estdsc1), 100, "%");
         lV56Configuracion_departamentoswwds_3_estdsc1 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_departamentoswwds_3_estdsc1), 100, "%");
         lV57Configuracion_departamentoswwds_4_paicod1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_departamentoswwds_4_paicod1), 4, "%");
         lV57Configuracion_departamentoswwds_4_paicod1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_departamentoswwds_4_paicod1), 4, "%");
         lV61Configuracion_departamentoswwds_8_estdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_departamentoswwds_8_estdsc2), 100, "%");
         lV61Configuracion_departamentoswwds_8_estdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_departamentoswwds_8_estdsc2), 100, "%");
         lV62Configuracion_departamentoswwds_9_paicod2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_departamentoswwds_9_paicod2), 4, "%");
         lV62Configuracion_departamentoswwds_9_paicod2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_departamentoswwds_9_paicod2), 4, "%");
         lV66Configuracion_departamentoswwds_13_estdsc3 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_departamentoswwds_13_estdsc3), 100, "%");
         lV66Configuracion_departamentoswwds_13_estdsc3 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_departamentoswwds_13_estdsc3), 100, "%");
         lV67Configuracion_departamentoswwds_14_paicod3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_departamentoswwds_14_paicod3), 4, "%");
         lV67Configuracion_departamentoswwds_14_paicod3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_departamentoswwds_14_paicod3), 4, "%");
         lV68Configuracion_departamentoswwds_15_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_departamentoswwds_15_tfestcod), 4, "%");
         lV70Configuracion_departamentoswwds_17_tfestdsc = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_departamentoswwds_17_tfestdsc), 100, "%");
         lV72Configuracion_departamentoswwds_19_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_departamentoswwds_19_tfpaidsc), 100, "%");
         /* Using cursor P003K3 */
         pr_default.execute(1, new Object[] {lV56Configuracion_departamentoswwds_3_estdsc1, lV56Configuracion_departamentoswwds_3_estdsc1, lV57Configuracion_departamentoswwds_4_paicod1, lV57Configuracion_departamentoswwds_4_paicod1, lV61Configuracion_departamentoswwds_8_estdsc2, lV61Configuracion_departamentoswwds_8_estdsc2, lV62Configuracion_departamentoswwds_9_paicod2, lV62Configuracion_departamentoswwds_9_paicod2, lV66Configuracion_departamentoswwds_13_estdsc3, lV66Configuracion_departamentoswwds_13_estdsc3, lV67Configuracion_departamentoswwds_14_paicod3, lV67Configuracion_departamentoswwds_14_paicod3, lV68Configuracion_departamentoswwds_15_tfestcod, AV69Configuracion_departamentoswwds_16_tfestcod_sel, lV70Configuracion_departamentoswwds_17_tfestdsc, AV71Configuracion_departamentoswwds_18_tfestdsc_sel, lV72Configuracion_departamentoswwds_19_tfpaidsc, AV73Configuracion_departamentoswwds_20_tfpaidsc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK3K4 = false;
            A602EstDsc = P003K3_A602EstDsc[0];
            A975EstSts = P003K3_A975EstSts[0];
            A1500PaiDsc = P003K3_A1500PaiDsc[0];
            A140EstCod = P003K3_A140EstCod[0];
            A139PaiCod = P003K3_A139PaiCod[0];
            A1500PaiDsc = P003K3_A1500PaiDsc[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P003K3_A602EstDsc[0], A602EstDsc) == 0 ) )
            {
               BRK3K4 = false;
               A140EstCod = P003K3_A140EstCod[0];
               A139PaiCod = P003K3_A139PaiCod[0];
               AV30count = (long)(AV30count+1);
               BRK3K4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A602EstDsc)) )
            {
               AV22Option = A602EstDsc;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK3K4 )
            {
               BRK3K4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPAIDSCOPTIONS' Routine */
         returnInSub = false;
         AV14TFPaiDsc = AV18SearchTxt;
         AV15TFPaiDsc_Sel = "";
         AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV56Configuracion_departamentoswwds_3_estdsc1 = AV38EstDsc1;
         AV57Configuracion_departamentoswwds_4_paicod1 = AV47PaiCod1;
         AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV61Configuracion_departamentoswwds_8_estdsc2 = AV42EstDsc2;
         AV62Configuracion_departamentoswwds_9_paicod2 = AV48PaiCod2;
         AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV66Configuracion_departamentoswwds_13_estdsc3 = AV46EstDsc3;
         AV67Configuracion_departamentoswwds_14_paicod3 = AV49PaiCod3;
         AV68Configuracion_departamentoswwds_15_tfestcod = AV10TFEstCod;
         AV69Configuracion_departamentoswwds_16_tfestcod_sel = AV11TFEstCod_Sel;
         AV70Configuracion_departamentoswwds_17_tfestdsc = AV12TFEstDsc;
         AV71Configuracion_departamentoswwds_18_tfestdsc_sel = AV13TFEstDsc_Sel;
         AV72Configuracion_departamentoswwds_19_tfpaidsc = AV14TFPaiDsc;
         AV73Configuracion_departamentoswwds_20_tfpaidsc_sel = AV15TFPaiDsc_Sel;
         AV74Configuracion_departamentoswwds_21_tfeststs_sels = AV17TFEstSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A975EstSts ,
                                              AV74Configuracion_departamentoswwds_21_tfeststs_sels ,
                                              AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1 ,
                                              AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 ,
                                              AV56Configuracion_departamentoswwds_3_estdsc1 ,
                                              AV57Configuracion_departamentoswwds_4_paicod1 ,
                                              AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 ,
                                              AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2 ,
                                              AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 ,
                                              AV61Configuracion_departamentoswwds_8_estdsc2 ,
                                              AV62Configuracion_departamentoswwds_9_paicod2 ,
                                              AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 ,
                                              AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3 ,
                                              AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 ,
                                              AV66Configuracion_departamentoswwds_13_estdsc3 ,
                                              AV67Configuracion_departamentoswwds_14_paicod3 ,
                                              AV69Configuracion_departamentoswwds_16_tfestcod_sel ,
                                              AV68Configuracion_departamentoswwds_15_tfestcod ,
                                              AV71Configuracion_departamentoswwds_18_tfestdsc_sel ,
                                              AV70Configuracion_departamentoswwds_17_tfestdsc ,
                                              AV73Configuracion_departamentoswwds_20_tfpaidsc_sel ,
                                              AV72Configuracion_departamentoswwds_19_tfpaidsc ,
                                              AV74Configuracion_departamentoswwds_21_tfeststs_sels.Count ,
                                              A602EstDsc ,
                                              A139PaiCod ,
                                              A140EstCod ,
                                              A1500PaiDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV56Configuracion_departamentoswwds_3_estdsc1 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_departamentoswwds_3_estdsc1), 100, "%");
         lV56Configuracion_departamentoswwds_3_estdsc1 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_departamentoswwds_3_estdsc1), 100, "%");
         lV57Configuracion_departamentoswwds_4_paicod1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_departamentoswwds_4_paicod1), 4, "%");
         lV57Configuracion_departamentoswwds_4_paicod1 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_departamentoswwds_4_paicod1), 4, "%");
         lV61Configuracion_departamentoswwds_8_estdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_departamentoswwds_8_estdsc2), 100, "%");
         lV61Configuracion_departamentoswwds_8_estdsc2 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_departamentoswwds_8_estdsc2), 100, "%");
         lV62Configuracion_departamentoswwds_9_paicod2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_departamentoswwds_9_paicod2), 4, "%");
         lV62Configuracion_departamentoswwds_9_paicod2 = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_departamentoswwds_9_paicod2), 4, "%");
         lV66Configuracion_departamentoswwds_13_estdsc3 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_departamentoswwds_13_estdsc3), 100, "%");
         lV66Configuracion_departamentoswwds_13_estdsc3 = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_departamentoswwds_13_estdsc3), 100, "%");
         lV67Configuracion_departamentoswwds_14_paicod3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_departamentoswwds_14_paicod3), 4, "%");
         lV67Configuracion_departamentoswwds_14_paicod3 = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_departamentoswwds_14_paicod3), 4, "%");
         lV68Configuracion_departamentoswwds_15_tfestcod = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_departamentoswwds_15_tfestcod), 4, "%");
         lV70Configuracion_departamentoswwds_17_tfestdsc = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_departamentoswwds_17_tfestdsc), 100, "%");
         lV72Configuracion_departamentoswwds_19_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_departamentoswwds_19_tfpaidsc), 100, "%");
         /* Using cursor P003K4 */
         pr_default.execute(2, new Object[] {lV56Configuracion_departamentoswwds_3_estdsc1, lV56Configuracion_departamentoswwds_3_estdsc1, lV57Configuracion_departamentoswwds_4_paicod1, lV57Configuracion_departamentoswwds_4_paicod1, lV61Configuracion_departamentoswwds_8_estdsc2, lV61Configuracion_departamentoswwds_8_estdsc2, lV62Configuracion_departamentoswwds_9_paicod2, lV62Configuracion_departamentoswwds_9_paicod2, lV66Configuracion_departamentoswwds_13_estdsc3, lV66Configuracion_departamentoswwds_13_estdsc3, lV67Configuracion_departamentoswwds_14_paicod3, lV67Configuracion_departamentoswwds_14_paicod3, lV68Configuracion_departamentoswwds_15_tfestcod, AV69Configuracion_departamentoswwds_16_tfestcod_sel, lV70Configuracion_departamentoswwds_17_tfestdsc, AV71Configuracion_departamentoswwds_18_tfestdsc_sel, lV72Configuracion_departamentoswwds_19_tfpaidsc, AV73Configuracion_departamentoswwds_20_tfpaidsc_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK3K6 = false;
            A139PaiCod = P003K4_A139PaiCod[0];
            A975EstSts = P003K4_A975EstSts[0];
            A1500PaiDsc = P003K4_A1500PaiDsc[0];
            A140EstCod = P003K4_A140EstCod[0];
            A602EstDsc = P003K4_A602EstDsc[0];
            A1500PaiDsc = P003K4_A1500PaiDsc[0];
            AV30count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P003K4_A139PaiCod[0], A139PaiCod) == 0 ) )
            {
               BRK3K6 = false;
               A140EstCod = P003K4_A140EstCod[0];
               AV30count = (long)(AV30count+1);
               BRK3K6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1500PaiDsc)) )
            {
               AV22Option = A1500PaiDsc;
               AV21InsertIndex = 1;
               while ( ( AV21InsertIndex <= AV23Options.Count ) && ( StringUtil.StrCmp(((string)AV23Options.Item(AV21InsertIndex)), AV22Option) < 0 ) )
               {
                  AV21InsertIndex = (int)(AV21InsertIndex+1);
               }
               AV23Options.Add(AV22Option, AV21InsertIndex);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), AV21InsertIndex);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK3K6 )
            {
               BRK3K6 = true;
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
         AV10TFEstCod = "";
         AV11TFEstCod_Sel = "";
         AV12TFEstDsc = "";
         AV13TFEstDsc_Sel = "";
         AV14TFPaiDsc = "";
         AV15TFPaiDsc_Sel = "";
         AV16TFEstSts_SelsJson = "";
         AV17TFEstSts_Sels = new GxSimpleCollection<short>();
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38EstDsc1 = "";
         AV47PaiCod1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42EstDsc2 = "";
         AV48PaiCod2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46EstDsc3 = "";
         AV49PaiCod3 = "";
         AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1 = "";
         AV56Configuracion_departamentoswwds_3_estdsc1 = "";
         AV57Configuracion_departamentoswwds_4_paicod1 = "";
         AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2 = "";
         AV61Configuracion_departamentoswwds_8_estdsc2 = "";
         AV62Configuracion_departamentoswwds_9_paicod2 = "";
         AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3 = "";
         AV66Configuracion_departamentoswwds_13_estdsc3 = "";
         AV67Configuracion_departamentoswwds_14_paicod3 = "";
         AV68Configuracion_departamentoswwds_15_tfestcod = "";
         AV69Configuracion_departamentoswwds_16_tfestcod_sel = "";
         AV70Configuracion_departamentoswwds_17_tfestdsc = "";
         AV71Configuracion_departamentoswwds_18_tfestdsc_sel = "";
         AV72Configuracion_departamentoswwds_19_tfpaidsc = "";
         AV73Configuracion_departamentoswwds_20_tfpaidsc_sel = "";
         AV74Configuracion_departamentoswwds_21_tfeststs_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV56Configuracion_departamentoswwds_3_estdsc1 = "";
         lV57Configuracion_departamentoswwds_4_paicod1 = "";
         lV61Configuracion_departamentoswwds_8_estdsc2 = "";
         lV62Configuracion_departamentoswwds_9_paicod2 = "";
         lV66Configuracion_departamentoswwds_13_estdsc3 = "";
         lV67Configuracion_departamentoswwds_14_paicod3 = "";
         lV68Configuracion_departamentoswwds_15_tfestcod = "";
         lV70Configuracion_departamentoswwds_17_tfestdsc = "";
         lV72Configuracion_departamentoswwds_19_tfpaidsc = "";
         A602EstDsc = "";
         A139PaiCod = "";
         A140EstCod = "";
         A1500PaiDsc = "";
         P003K2_A140EstCod = new string[] {""} ;
         P003K2_A975EstSts = new short[1] ;
         P003K2_A1500PaiDsc = new string[] {""} ;
         P003K2_A139PaiCod = new string[] {""} ;
         P003K2_A602EstDsc = new string[] {""} ;
         AV22Option = "";
         P003K3_A602EstDsc = new string[] {""} ;
         P003K3_A975EstSts = new short[1] ;
         P003K3_A1500PaiDsc = new string[] {""} ;
         P003K3_A140EstCod = new string[] {""} ;
         P003K3_A139PaiCod = new string[] {""} ;
         P003K4_A139PaiCod = new string[] {""} ;
         P003K4_A975EstSts = new short[1] ;
         P003K4_A1500PaiDsc = new string[] {""} ;
         P003K4_A140EstCod = new string[] {""} ;
         P003K4_A602EstDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.departamentoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003K2_A140EstCod, P003K2_A975EstSts, P003K2_A1500PaiDsc, P003K2_A139PaiCod, P003K2_A602EstDsc
               }
               , new Object[] {
               P003K3_A602EstDsc, P003K3_A975EstSts, P003K3_A1500PaiDsc, P003K3_A140EstCod, P003K3_A139PaiCod
               }
               , new Object[] {
               P003K4_A139PaiCod, P003K4_A975EstSts, P003K4_A1500PaiDsc, P003K4_A140EstCod, P003K4_A602EstDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 ;
      private short AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 ;
      private short AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 ;
      private short A975EstSts ;
      private int AV52GXV1 ;
      private int AV74Configuracion_departamentoswwds_21_tfeststs_sels_Count ;
      private int AV21InsertIndex ;
      private long AV30count ;
      private string AV10TFEstCod ;
      private string AV11TFEstCod_Sel ;
      private string AV12TFEstDsc ;
      private string AV13TFEstDsc_Sel ;
      private string AV14TFPaiDsc ;
      private string AV15TFPaiDsc_Sel ;
      private string AV38EstDsc1 ;
      private string AV47PaiCod1 ;
      private string AV42EstDsc2 ;
      private string AV48PaiCod2 ;
      private string AV46EstDsc3 ;
      private string AV49PaiCod3 ;
      private string AV56Configuracion_departamentoswwds_3_estdsc1 ;
      private string AV57Configuracion_departamentoswwds_4_paicod1 ;
      private string AV61Configuracion_departamentoswwds_8_estdsc2 ;
      private string AV62Configuracion_departamentoswwds_9_paicod2 ;
      private string AV66Configuracion_departamentoswwds_13_estdsc3 ;
      private string AV67Configuracion_departamentoswwds_14_paicod3 ;
      private string AV68Configuracion_departamentoswwds_15_tfestcod ;
      private string AV69Configuracion_departamentoswwds_16_tfestcod_sel ;
      private string AV70Configuracion_departamentoswwds_17_tfestdsc ;
      private string AV71Configuracion_departamentoswwds_18_tfestdsc_sel ;
      private string AV72Configuracion_departamentoswwds_19_tfpaidsc ;
      private string AV73Configuracion_departamentoswwds_20_tfpaidsc_sel ;
      private string scmdbuf ;
      private string lV56Configuracion_departamentoswwds_3_estdsc1 ;
      private string lV57Configuracion_departamentoswwds_4_paicod1 ;
      private string lV61Configuracion_departamentoswwds_8_estdsc2 ;
      private string lV62Configuracion_departamentoswwds_9_paicod2 ;
      private string lV66Configuracion_departamentoswwds_13_estdsc3 ;
      private string lV67Configuracion_departamentoswwds_14_paicod3 ;
      private string lV68Configuracion_departamentoswwds_15_tfestcod ;
      private string lV70Configuracion_departamentoswwds_17_tfestdsc ;
      private string lV72Configuracion_departamentoswwds_19_tfpaidsc ;
      private string A602EstDsc ;
      private string A139PaiCod ;
      private string A140EstCod ;
      private string A1500PaiDsc ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 ;
      private bool AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 ;
      private bool BRK3K2 ;
      private bool BRK3K4 ;
      private bool BRK3K6 ;
      private string AV24OptionsJson ;
      private string AV27OptionsDescJson ;
      private string AV29OptionIndexesJson ;
      private string AV16TFEstSts_SelsJson ;
      private string AV20DDOName ;
      private string AV18SearchTxt ;
      private string AV19SearchTxtTo ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1 ;
      private string AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2 ;
      private string AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3 ;
      private string AV22Option ;
      private GxSimpleCollection<short> AV17TFEstSts_Sels ;
      private GxSimpleCollection<short> AV74Configuracion_departamentoswwds_21_tfeststs_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003K2_A140EstCod ;
      private short[] P003K2_A975EstSts ;
      private string[] P003K2_A1500PaiDsc ;
      private string[] P003K2_A139PaiCod ;
      private string[] P003K2_A602EstDsc ;
      private string[] P003K3_A602EstDsc ;
      private short[] P003K3_A975EstSts ;
      private string[] P003K3_A1500PaiDsc ;
      private string[] P003K3_A140EstCod ;
      private string[] P003K3_A139PaiCod ;
      private string[] P003K4_A139PaiCod ;
      private short[] P003K4_A975EstSts ;
      private string[] P003K4_A1500PaiDsc ;
      private string[] P003K4_A140EstCod ;
      private string[] P003K4_A602EstDsc ;
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

   public class departamentoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003K2( IGxContext context ,
                                             short A975EstSts ,
                                             GxSimpleCollection<short> AV74Configuracion_departamentoswwds_21_tfeststs_sels ,
                                             string AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1 ,
                                             short AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 ,
                                             string AV56Configuracion_departamentoswwds_3_estdsc1 ,
                                             string AV57Configuracion_departamentoswwds_4_paicod1 ,
                                             bool AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 ,
                                             string AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2 ,
                                             short AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 ,
                                             string AV61Configuracion_departamentoswwds_8_estdsc2 ,
                                             string AV62Configuracion_departamentoswwds_9_paicod2 ,
                                             bool AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 ,
                                             string AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3 ,
                                             short AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 ,
                                             string AV66Configuracion_departamentoswwds_13_estdsc3 ,
                                             string AV67Configuracion_departamentoswwds_14_paicod3 ,
                                             string AV69Configuracion_departamentoswwds_16_tfestcod_sel ,
                                             string AV68Configuracion_departamentoswwds_15_tfestcod ,
                                             string AV71Configuracion_departamentoswwds_18_tfestdsc_sel ,
                                             string AV70Configuracion_departamentoswwds_17_tfestdsc ,
                                             string AV73Configuracion_departamentoswwds_20_tfpaidsc_sel ,
                                             string AV72Configuracion_departamentoswwds_19_tfpaidsc ,
                                             int AV74Configuracion_departamentoswwds_21_tfeststs_sels_Count ,
                                             string A602EstDsc ,
                                             string A139PaiCod ,
                                             string A140EstCod ,
                                             string A1500PaiDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[18];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[EstCod], T1.[EstSts], T2.[PaiDsc], T1.[PaiCod], T1.[EstDsc] FROM ([CESTADOS] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod])";
         if ( ( StringUtil.StrCmp(AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1, "ESTDSC") == 0 ) && ( AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_departamentoswwds_3_estdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV56Configuracion_departamentoswwds_3_estdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1, "ESTDSC") == 0 ) && ( AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_departamentoswwds_3_estdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like '%' + @lV56Configuracion_departamentoswwds_3_estdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1, "PAICOD") == 0 ) && ( AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_departamentoswwds_4_paicod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV57Configuracion_departamentoswwds_4_paicod1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1, "PAICOD") == 0 ) && ( AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_departamentoswwds_4_paicod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like '%' + @lV57Configuracion_departamentoswwds_4_paicod1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2, "ESTDSC") == 0 ) && ( AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_departamentoswwds_8_estdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV61Configuracion_departamentoswwds_8_estdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2, "ESTDSC") == 0 ) && ( AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_departamentoswwds_8_estdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like '%' + @lV61Configuracion_departamentoswwds_8_estdsc2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2, "PAICOD") == 0 ) && ( AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_departamentoswwds_9_paicod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV62Configuracion_departamentoswwds_9_paicod2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2, "PAICOD") == 0 ) && ( AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_departamentoswwds_9_paicod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like '%' + @lV62Configuracion_departamentoswwds_9_paicod2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3, "ESTDSC") == 0 ) && ( AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_departamentoswwds_13_estdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV66Configuracion_departamentoswwds_13_estdsc3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3, "ESTDSC") == 0 ) && ( AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_departamentoswwds_13_estdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like '%' + @lV66Configuracion_departamentoswwds_13_estdsc3)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3, "PAICOD") == 0 ) && ( AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_departamentoswwds_14_paicod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV67Configuracion_departamentoswwds_14_paicod3)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3, "PAICOD") == 0 ) && ( AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_departamentoswwds_14_paicod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like '%' + @lV67Configuracion_departamentoswwds_14_paicod3)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_departamentoswwds_16_tfestcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_departamentoswwds_15_tfestcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] like @lV68Configuracion_departamentoswwds_15_tfestcod)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_departamentoswwds_16_tfestcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] = @AV69Configuracion_departamentoswwds_16_tfestcod_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_departamentoswwds_18_tfestdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_departamentoswwds_17_tfestdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV70Configuracion_departamentoswwds_17_tfestdsc)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_departamentoswwds_18_tfestdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] = @AV71Configuracion_departamentoswwds_18_tfestdsc_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_departamentoswwds_20_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_departamentoswwds_19_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] like @lV72Configuracion_departamentoswwds_19_tfpaidsc)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_departamentoswwds_20_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] = @AV73Configuracion_departamentoswwds_20_tfpaidsc_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV74Configuracion_departamentoswwds_21_tfeststs_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Configuracion_departamentoswwds_21_tfeststs_sels, "T1.[EstSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[EstCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P003K3( IGxContext context ,
                                             short A975EstSts ,
                                             GxSimpleCollection<short> AV74Configuracion_departamentoswwds_21_tfeststs_sels ,
                                             string AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1 ,
                                             short AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 ,
                                             string AV56Configuracion_departamentoswwds_3_estdsc1 ,
                                             string AV57Configuracion_departamentoswwds_4_paicod1 ,
                                             bool AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 ,
                                             string AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2 ,
                                             short AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 ,
                                             string AV61Configuracion_departamentoswwds_8_estdsc2 ,
                                             string AV62Configuracion_departamentoswwds_9_paicod2 ,
                                             bool AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 ,
                                             string AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3 ,
                                             short AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 ,
                                             string AV66Configuracion_departamentoswwds_13_estdsc3 ,
                                             string AV67Configuracion_departamentoswwds_14_paicod3 ,
                                             string AV69Configuracion_departamentoswwds_16_tfestcod_sel ,
                                             string AV68Configuracion_departamentoswwds_15_tfestcod ,
                                             string AV71Configuracion_departamentoswwds_18_tfestdsc_sel ,
                                             string AV70Configuracion_departamentoswwds_17_tfestdsc ,
                                             string AV73Configuracion_departamentoswwds_20_tfpaidsc_sel ,
                                             string AV72Configuracion_departamentoswwds_19_tfpaidsc ,
                                             int AV74Configuracion_departamentoswwds_21_tfeststs_sels_Count ,
                                             string A602EstDsc ,
                                             string A139PaiCod ,
                                             string A140EstCod ,
                                             string A1500PaiDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[18];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[EstDsc], T1.[EstSts], T2.[PaiDsc], T1.[EstCod], T1.[PaiCod] FROM ([CESTADOS] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod])";
         if ( ( StringUtil.StrCmp(AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1, "ESTDSC") == 0 ) && ( AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_departamentoswwds_3_estdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV56Configuracion_departamentoswwds_3_estdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1, "ESTDSC") == 0 ) && ( AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_departamentoswwds_3_estdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like '%' + @lV56Configuracion_departamentoswwds_3_estdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1, "PAICOD") == 0 ) && ( AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_departamentoswwds_4_paicod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV57Configuracion_departamentoswwds_4_paicod1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1, "PAICOD") == 0 ) && ( AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_departamentoswwds_4_paicod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like '%' + @lV57Configuracion_departamentoswwds_4_paicod1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2, "ESTDSC") == 0 ) && ( AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_departamentoswwds_8_estdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV61Configuracion_departamentoswwds_8_estdsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2, "ESTDSC") == 0 ) && ( AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_departamentoswwds_8_estdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like '%' + @lV61Configuracion_departamentoswwds_8_estdsc2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2, "PAICOD") == 0 ) && ( AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_departamentoswwds_9_paicod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV62Configuracion_departamentoswwds_9_paicod2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2, "PAICOD") == 0 ) && ( AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_departamentoswwds_9_paicod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like '%' + @lV62Configuracion_departamentoswwds_9_paicod2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3, "ESTDSC") == 0 ) && ( AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_departamentoswwds_13_estdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV66Configuracion_departamentoswwds_13_estdsc3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3, "ESTDSC") == 0 ) && ( AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_departamentoswwds_13_estdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like '%' + @lV66Configuracion_departamentoswwds_13_estdsc3)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3, "PAICOD") == 0 ) && ( AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_departamentoswwds_14_paicod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV67Configuracion_departamentoswwds_14_paicod3)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3, "PAICOD") == 0 ) && ( AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_departamentoswwds_14_paicod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like '%' + @lV67Configuracion_departamentoswwds_14_paicod3)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_departamentoswwds_16_tfestcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_departamentoswwds_15_tfestcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] like @lV68Configuracion_departamentoswwds_15_tfestcod)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_departamentoswwds_16_tfestcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] = @AV69Configuracion_departamentoswwds_16_tfestcod_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_departamentoswwds_18_tfestdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_departamentoswwds_17_tfestdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV70Configuracion_departamentoswwds_17_tfestdsc)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_departamentoswwds_18_tfestdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] = @AV71Configuracion_departamentoswwds_18_tfestdsc_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_departamentoswwds_20_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_departamentoswwds_19_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] like @lV72Configuracion_departamentoswwds_19_tfpaidsc)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_departamentoswwds_20_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] = @AV73Configuracion_departamentoswwds_20_tfpaidsc_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV74Configuracion_departamentoswwds_21_tfeststs_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Configuracion_departamentoswwds_21_tfeststs_sels, "T1.[EstSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[EstDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P003K4( IGxContext context ,
                                             short A975EstSts ,
                                             GxSimpleCollection<short> AV74Configuracion_departamentoswwds_21_tfeststs_sels ,
                                             string AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1 ,
                                             short AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 ,
                                             string AV56Configuracion_departamentoswwds_3_estdsc1 ,
                                             string AV57Configuracion_departamentoswwds_4_paicod1 ,
                                             bool AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 ,
                                             string AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2 ,
                                             short AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 ,
                                             string AV61Configuracion_departamentoswwds_8_estdsc2 ,
                                             string AV62Configuracion_departamentoswwds_9_paicod2 ,
                                             bool AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 ,
                                             string AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3 ,
                                             short AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 ,
                                             string AV66Configuracion_departamentoswwds_13_estdsc3 ,
                                             string AV67Configuracion_departamentoswwds_14_paicod3 ,
                                             string AV69Configuracion_departamentoswwds_16_tfestcod_sel ,
                                             string AV68Configuracion_departamentoswwds_15_tfestcod ,
                                             string AV71Configuracion_departamentoswwds_18_tfestdsc_sel ,
                                             string AV70Configuracion_departamentoswwds_17_tfestdsc ,
                                             string AV73Configuracion_departamentoswwds_20_tfpaidsc_sel ,
                                             string AV72Configuracion_departamentoswwds_19_tfpaidsc ,
                                             int AV74Configuracion_departamentoswwds_21_tfeststs_sels_Count ,
                                             string A602EstDsc ,
                                             string A139PaiCod ,
                                             string A140EstCod ,
                                             string A1500PaiDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[18];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[PaiCod], T1.[EstSts], T2.[PaiDsc], T1.[EstCod], T1.[EstDsc] FROM ([CESTADOS] T1 INNER JOIN [CPAISES] T2 ON T2.[PaiCod] = T1.[PaiCod])";
         if ( ( StringUtil.StrCmp(AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1, "ESTDSC") == 0 ) && ( AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_departamentoswwds_3_estdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV56Configuracion_departamentoswwds_3_estdsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1, "ESTDSC") == 0 ) && ( AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_departamentoswwds_3_estdsc1)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like '%' + @lV56Configuracion_departamentoswwds_3_estdsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1, "PAICOD") == 0 ) && ( AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_departamentoswwds_4_paicod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV57Configuracion_departamentoswwds_4_paicod1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Configuracion_departamentoswwds_1_dynamicfiltersselector1, "PAICOD") == 0 ) && ( AV55Configuracion_departamentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_departamentoswwds_4_paicod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like '%' + @lV57Configuracion_departamentoswwds_4_paicod1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2, "ESTDSC") == 0 ) && ( AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_departamentoswwds_8_estdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV61Configuracion_departamentoswwds_8_estdsc2)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2, "ESTDSC") == 0 ) && ( AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_departamentoswwds_8_estdsc2)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like '%' + @lV61Configuracion_departamentoswwds_8_estdsc2)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2, "PAICOD") == 0 ) && ( AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_departamentoswwds_9_paicod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV62Configuracion_departamentoswwds_9_paicod2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV58Configuracion_departamentoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Configuracion_departamentoswwds_6_dynamicfiltersselector2, "PAICOD") == 0 ) && ( AV60Configuracion_departamentoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_departamentoswwds_9_paicod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like '%' + @lV62Configuracion_departamentoswwds_9_paicod2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3, "ESTDSC") == 0 ) && ( AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_departamentoswwds_13_estdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV66Configuracion_departamentoswwds_13_estdsc3)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3, "ESTDSC") == 0 ) && ( AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_departamentoswwds_13_estdsc3)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like '%' + @lV66Configuracion_departamentoswwds_13_estdsc3)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3, "PAICOD") == 0 ) && ( AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_departamentoswwds_14_paicod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like @lV67Configuracion_departamentoswwds_14_paicod3)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV63Configuracion_departamentoswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Configuracion_departamentoswwds_11_dynamicfiltersselector3, "PAICOD") == 0 ) && ( AV65Configuracion_departamentoswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_departamentoswwds_14_paicod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[PaiCod] like '%' + @lV67Configuracion_departamentoswwds_14_paicod3)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_departamentoswwds_16_tfestcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_departamentoswwds_15_tfestcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] like @lV68Configuracion_departamentoswwds_15_tfestcod)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_departamentoswwds_16_tfestcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EstCod] = @AV69Configuracion_departamentoswwds_16_tfestcod_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_departamentoswwds_18_tfestdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_departamentoswwds_17_tfestdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] like @lV70Configuracion_departamentoswwds_17_tfestdsc)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_departamentoswwds_18_tfestdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[EstDsc] = @AV71Configuracion_departamentoswwds_18_tfestdsc_sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_departamentoswwds_20_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_departamentoswwds_19_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] like @lV72Configuracion_departamentoswwds_19_tfpaidsc)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_departamentoswwds_20_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[PaiDsc] = @AV73Configuracion_departamentoswwds_20_tfpaidsc_sel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV74Configuracion_departamentoswwds_21_tfeststs_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Configuracion_departamentoswwds_21_tfeststs_sels, "T1.[EstSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PaiCod]";
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
                     return conditional_P003K2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
               case 1 :
                     return conditional_P003K3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
               case 2 :
                     return conditional_P003K4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
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
          Object[] prmP003K2;
          prmP003K2 = new Object[] {
          new ParDef("@lV56Configuracion_departamentoswwds_3_estdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV56Configuracion_departamentoswwds_3_estdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_departamentoswwds_4_paicod1",GXType.NChar,4,0) ,
          new ParDef("@lV57Configuracion_departamentoswwds_4_paicod1",GXType.NChar,4,0) ,
          new ParDef("@lV61Configuracion_departamentoswwds_8_estdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_departamentoswwds_8_estdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_departamentoswwds_9_paicod2",GXType.NChar,4,0) ,
          new ParDef("@lV62Configuracion_departamentoswwds_9_paicod2",GXType.NChar,4,0) ,
          new ParDef("@lV66Configuracion_departamentoswwds_13_estdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_departamentoswwds_13_estdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_departamentoswwds_14_paicod3",GXType.NChar,4,0) ,
          new ParDef("@lV67Configuracion_departamentoswwds_14_paicod3",GXType.NChar,4,0) ,
          new ParDef("@lV68Configuracion_departamentoswwds_15_tfestcod",GXType.NChar,4,0) ,
          new ParDef("@AV69Configuracion_departamentoswwds_16_tfestcod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV70Configuracion_departamentoswwds_17_tfestdsc",GXType.NChar,100,0) ,
          new ParDef("@AV71Configuracion_departamentoswwds_18_tfestdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_departamentoswwds_19_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Configuracion_departamentoswwds_20_tfpaidsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP003K3;
          prmP003K3 = new Object[] {
          new ParDef("@lV56Configuracion_departamentoswwds_3_estdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV56Configuracion_departamentoswwds_3_estdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_departamentoswwds_4_paicod1",GXType.NChar,4,0) ,
          new ParDef("@lV57Configuracion_departamentoswwds_4_paicod1",GXType.NChar,4,0) ,
          new ParDef("@lV61Configuracion_departamentoswwds_8_estdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_departamentoswwds_8_estdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_departamentoswwds_9_paicod2",GXType.NChar,4,0) ,
          new ParDef("@lV62Configuracion_departamentoswwds_9_paicod2",GXType.NChar,4,0) ,
          new ParDef("@lV66Configuracion_departamentoswwds_13_estdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_departamentoswwds_13_estdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_departamentoswwds_14_paicod3",GXType.NChar,4,0) ,
          new ParDef("@lV67Configuracion_departamentoswwds_14_paicod3",GXType.NChar,4,0) ,
          new ParDef("@lV68Configuracion_departamentoswwds_15_tfestcod",GXType.NChar,4,0) ,
          new ParDef("@AV69Configuracion_departamentoswwds_16_tfestcod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV70Configuracion_departamentoswwds_17_tfestdsc",GXType.NChar,100,0) ,
          new ParDef("@AV71Configuracion_departamentoswwds_18_tfestdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_departamentoswwds_19_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Configuracion_departamentoswwds_20_tfpaidsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP003K4;
          prmP003K4 = new Object[] {
          new ParDef("@lV56Configuracion_departamentoswwds_3_estdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV56Configuracion_departamentoswwds_3_estdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_departamentoswwds_4_paicod1",GXType.NChar,4,0) ,
          new ParDef("@lV57Configuracion_departamentoswwds_4_paicod1",GXType.NChar,4,0) ,
          new ParDef("@lV61Configuracion_departamentoswwds_8_estdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_departamentoswwds_8_estdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_departamentoswwds_9_paicod2",GXType.NChar,4,0) ,
          new ParDef("@lV62Configuracion_departamentoswwds_9_paicod2",GXType.NChar,4,0) ,
          new ParDef("@lV66Configuracion_departamentoswwds_13_estdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV66Configuracion_departamentoswwds_13_estdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV67Configuracion_departamentoswwds_14_paicod3",GXType.NChar,4,0) ,
          new ParDef("@lV67Configuracion_departamentoswwds_14_paicod3",GXType.NChar,4,0) ,
          new ParDef("@lV68Configuracion_departamentoswwds_15_tfestcod",GXType.NChar,4,0) ,
          new ParDef("@AV69Configuracion_departamentoswwds_16_tfestcod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV70Configuracion_departamentoswwds_17_tfestdsc",GXType.NChar,100,0) ,
          new ParDef("@AV71Configuracion_departamentoswwds_18_tfestdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV72Configuracion_departamentoswwds_19_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Configuracion_departamentoswwds_20_tfpaidsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003K4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003K4,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
