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
   public class paiseswwgetfilterdata : GXProcedure
   {
      public paiseswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public paiseswwgetfilterdata( IGxContext context )
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
         paiseswwgetfilterdata objpaiseswwgetfilterdata;
         objpaiseswwgetfilterdata = new paiseswwgetfilterdata();
         objpaiseswwgetfilterdata.AV20DDOName = aP0_DDOName;
         objpaiseswwgetfilterdata.AV18SearchTxt = aP1_SearchTxt;
         objpaiseswwgetfilterdata.AV19SearchTxtTo = aP2_SearchTxtTo;
         objpaiseswwgetfilterdata.AV24OptionsJson = "" ;
         objpaiseswwgetfilterdata.AV27OptionsDescJson = "" ;
         objpaiseswwgetfilterdata.AV29OptionIndexesJson = "" ;
         objpaiseswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objpaiseswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objpaiseswwgetfilterdata);
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((paiseswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_PAICOD") == 0 )
         {
            /* Execute user subroutine: 'LOADPAICODOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_PAIDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADPAIDSCOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV31Session.Get("Configuracion.PaisesWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.PaisesWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Configuracion.PaisesWWGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPAICOD") == 0 )
            {
               AV10TFPaiCod = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPAICOD_SEL") == 0 )
            {
               AV11TFPaiCod_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPAIDSC") == 0 )
            {
               AV12TFPaiDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPAIDSC_SEL") == 0 )
            {
               AV13TFPaiDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPAISTS_SEL") == 0 )
            {
               AV16TFPaiSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV17TFPaiSts_Sels.FromJSonString(AV16TFPaiSts_SelsJson, null);
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "PAIDSC") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV38PaiDsc1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "PAIDSC") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV42PaiDsc2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "PAIDSC") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV46PaiDsc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPAICODOPTIONS' Routine */
         returnInSub = false;
         AV10TFPaiCod = AV18SearchTxt;
         AV11TFPaiCod_Sel = "";
         AV51Configuracion_paiseswwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV52Configuracion_paiseswwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV53Configuracion_paiseswwds_3_paidsc1 = AV38PaiDsc1;
         AV54Configuracion_paiseswwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV55Configuracion_paiseswwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV56Configuracion_paiseswwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV57Configuracion_paiseswwds_7_paidsc2 = AV42PaiDsc2;
         AV58Configuracion_paiseswwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV59Configuracion_paiseswwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV60Configuracion_paiseswwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV61Configuracion_paiseswwds_11_paidsc3 = AV46PaiDsc3;
         AV62Configuracion_paiseswwds_12_tfpaicod = AV10TFPaiCod;
         AV63Configuracion_paiseswwds_13_tfpaicod_sel = AV11TFPaiCod_Sel;
         AV64Configuracion_paiseswwds_14_tfpaidsc = AV12TFPaiDsc;
         AV65Configuracion_paiseswwds_15_tfpaidsc_sel = AV13TFPaiDsc_Sel;
         AV66Configuracion_paiseswwds_16_tfpaists_sels = AV17TFPaiSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1501PaiSts ,
                                              AV66Configuracion_paiseswwds_16_tfpaists_sels ,
                                              AV51Configuracion_paiseswwds_1_dynamicfiltersselector1 ,
                                              AV52Configuracion_paiseswwds_2_dynamicfiltersoperator1 ,
                                              AV53Configuracion_paiseswwds_3_paidsc1 ,
                                              AV54Configuracion_paiseswwds_4_dynamicfiltersenabled2 ,
                                              AV55Configuracion_paiseswwds_5_dynamicfiltersselector2 ,
                                              AV56Configuracion_paiseswwds_6_dynamicfiltersoperator2 ,
                                              AV57Configuracion_paiseswwds_7_paidsc2 ,
                                              AV58Configuracion_paiseswwds_8_dynamicfiltersenabled3 ,
                                              AV59Configuracion_paiseswwds_9_dynamicfiltersselector3 ,
                                              AV60Configuracion_paiseswwds_10_dynamicfiltersoperator3 ,
                                              AV61Configuracion_paiseswwds_11_paidsc3 ,
                                              AV63Configuracion_paiseswwds_13_tfpaicod_sel ,
                                              AV62Configuracion_paiseswwds_12_tfpaicod ,
                                              AV65Configuracion_paiseswwds_15_tfpaidsc_sel ,
                                              AV64Configuracion_paiseswwds_14_tfpaidsc ,
                                              AV66Configuracion_paiseswwds_16_tfpaists_sels.Count ,
                                              A1500PaiDsc ,
                                              A139PaiCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV53Configuracion_paiseswwds_3_paidsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_paiseswwds_3_paidsc1), 100, "%");
         lV53Configuracion_paiseswwds_3_paidsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_paiseswwds_3_paidsc1), 100, "%");
         lV57Configuracion_paiseswwds_7_paidsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_paiseswwds_7_paidsc2), 100, "%");
         lV57Configuracion_paiseswwds_7_paidsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_paiseswwds_7_paidsc2), 100, "%");
         lV61Configuracion_paiseswwds_11_paidsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_paiseswwds_11_paidsc3), 100, "%");
         lV61Configuracion_paiseswwds_11_paidsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_paiseswwds_11_paidsc3), 100, "%");
         lV62Configuracion_paiseswwds_12_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_paiseswwds_12_tfpaicod), 4, "%");
         lV64Configuracion_paiseswwds_14_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_paiseswwds_14_tfpaidsc), 100, "%");
         /* Using cursor P003H2 */
         pr_default.execute(0, new Object[] {lV53Configuracion_paiseswwds_3_paidsc1, lV53Configuracion_paiseswwds_3_paidsc1, lV57Configuracion_paiseswwds_7_paidsc2, lV57Configuracion_paiseswwds_7_paidsc2, lV61Configuracion_paiseswwds_11_paidsc3, lV61Configuracion_paiseswwds_11_paidsc3, lV62Configuracion_paiseswwds_12_tfpaicod, AV63Configuracion_paiseswwds_13_tfpaicod_sel, lV64Configuracion_paiseswwds_14_tfpaidsc, AV65Configuracion_paiseswwds_15_tfpaidsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1501PaiSts = P003H2_A1501PaiSts[0];
            A139PaiCod = P003H2_A139PaiCod[0];
            A1500PaiDsc = P003H2_A1500PaiDsc[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A139PaiCod)) )
            {
               AV22Option = A139PaiCod;
               AV23Options.Add(AV22Option, 0);
            }
            if ( AV23Options.Count == 50 )
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
         /* 'LOADPAIDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFPaiDsc = AV18SearchTxt;
         AV13TFPaiDsc_Sel = "";
         AV51Configuracion_paiseswwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV52Configuracion_paiseswwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV53Configuracion_paiseswwds_3_paidsc1 = AV38PaiDsc1;
         AV54Configuracion_paiseswwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV55Configuracion_paiseswwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV56Configuracion_paiseswwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV57Configuracion_paiseswwds_7_paidsc2 = AV42PaiDsc2;
         AV58Configuracion_paiseswwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV59Configuracion_paiseswwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV60Configuracion_paiseswwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV61Configuracion_paiseswwds_11_paidsc3 = AV46PaiDsc3;
         AV62Configuracion_paiseswwds_12_tfpaicod = AV10TFPaiCod;
         AV63Configuracion_paiseswwds_13_tfpaicod_sel = AV11TFPaiCod_Sel;
         AV64Configuracion_paiseswwds_14_tfpaidsc = AV12TFPaiDsc;
         AV65Configuracion_paiseswwds_15_tfpaidsc_sel = AV13TFPaiDsc_Sel;
         AV66Configuracion_paiseswwds_16_tfpaists_sels = AV17TFPaiSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1501PaiSts ,
                                              AV66Configuracion_paiseswwds_16_tfpaists_sels ,
                                              AV51Configuracion_paiseswwds_1_dynamicfiltersselector1 ,
                                              AV52Configuracion_paiseswwds_2_dynamicfiltersoperator1 ,
                                              AV53Configuracion_paiseswwds_3_paidsc1 ,
                                              AV54Configuracion_paiseswwds_4_dynamicfiltersenabled2 ,
                                              AV55Configuracion_paiseswwds_5_dynamicfiltersselector2 ,
                                              AV56Configuracion_paiseswwds_6_dynamicfiltersoperator2 ,
                                              AV57Configuracion_paiseswwds_7_paidsc2 ,
                                              AV58Configuracion_paiseswwds_8_dynamicfiltersenabled3 ,
                                              AV59Configuracion_paiseswwds_9_dynamicfiltersselector3 ,
                                              AV60Configuracion_paiseswwds_10_dynamicfiltersoperator3 ,
                                              AV61Configuracion_paiseswwds_11_paidsc3 ,
                                              AV63Configuracion_paiseswwds_13_tfpaicod_sel ,
                                              AV62Configuracion_paiseswwds_12_tfpaicod ,
                                              AV65Configuracion_paiseswwds_15_tfpaidsc_sel ,
                                              AV64Configuracion_paiseswwds_14_tfpaidsc ,
                                              AV66Configuracion_paiseswwds_16_tfpaists_sels.Count ,
                                              A1500PaiDsc ,
                                              A139PaiCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV53Configuracion_paiseswwds_3_paidsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_paiseswwds_3_paidsc1), 100, "%");
         lV53Configuracion_paiseswwds_3_paidsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Configuracion_paiseswwds_3_paidsc1), 100, "%");
         lV57Configuracion_paiseswwds_7_paidsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_paiseswwds_7_paidsc2), 100, "%");
         lV57Configuracion_paiseswwds_7_paidsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Configuracion_paiseswwds_7_paidsc2), 100, "%");
         lV61Configuracion_paiseswwds_11_paidsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_paiseswwds_11_paidsc3), 100, "%");
         lV61Configuracion_paiseswwds_11_paidsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_paiseswwds_11_paidsc3), 100, "%");
         lV62Configuracion_paiseswwds_12_tfpaicod = StringUtil.PadR( StringUtil.RTrim( AV62Configuracion_paiseswwds_12_tfpaicod), 4, "%");
         lV64Configuracion_paiseswwds_14_tfpaidsc = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_paiseswwds_14_tfpaidsc), 100, "%");
         /* Using cursor P003H3 */
         pr_default.execute(1, new Object[] {lV53Configuracion_paiseswwds_3_paidsc1, lV53Configuracion_paiseswwds_3_paidsc1, lV57Configuracion_paiseswwds_7_paidsc2, lV57Configuracion_paiseswwds_7_paidsc2, lV61Configuracion_paiseswwds_11_paidsc3, lV61Configuracion_paiseswwds_11_paidsc3, lV62Configuracion_paiseswwds_12_tfpaicod, AV63Configuracion_paiseswwds_13_tfpaicod_sel, lV64Configuracion_paiseswwds_14_tfpaidsc, AV65Configuracion_paiseswwds_15_tfpaidsc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK3H3 = false;
            A1500PaiDsc = P003H3_A1500PaiDsc[0];
            A1501PaiSts = P003H3_A1501PaiSts[0];
            A139PaiCod = P003H3_A139PaiCod[0];
            AV30count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P003H3_A1500PaiDsc[0], A1500PaiDsc) == 0 ) )
            {
               BRK3H3 = false;
               A139PaiCod = P003H3_A139PaiCod[0];
               AV30count = (long)(AV30count+1);
               BRK3H3 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1500PaiDsc)) )
            {
               AV22Option = A1500PaiDsc;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK3H3 )
            {
               BRK3H3 = true;
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
         AV10TFPaiCod = "";
         AV11TFPaiCod_Sel = "";
         AV12TFPaiDsc = "";
         AV13TFPaiDsc_Sel = "";
         AV16TFPaiSts_SelsJson = "";
         AV17TFPaiSts_Sels = new GxSimpleCollection<short>();
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38PaiDsc1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42PaiDsc2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46PaiDsc3 = "";
         AV51Configuracion_paiseswwds_1_dynamicfiltersselector1 = "";
         AV53Configuracion_paiseswwds_3_paidsc1 = "";
         AV55Configuracion_paiseswwds_5_dynamicfiltersselector2 = "";
         AV57Configuracion_paiseswwds_7_paidsc2 = "";
         AV59Configuracion_paiseswwds_9_dynamicfiltersselector3 = "";
         AV61Configuracion_paiseswwds_11_paidsc3 = "";
         AV62Configuracion_paiseswwds_12_tfpaicod = "";
         AV63Configuracion_paiseswwds_13_tfpaicod_sel = "";
         AV64Configuracion_paiseswwds_14_tfpaidsc = "";
         AV65Configuracion_paiseswwds_15_tfpaidsc_sel = "";
         AV66Configuracion_paiseswwds_16_tfpaists_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV53Configuracion_paiseswwds_3_paidsc1 = "";
         lV57Configuracion_paiseswwds_7_paidsc2 = "";
         lV61Configuracion_paiseswwds_11_paidsc3 = "";
         lV62Configuracion_paiseswwds_12_tfpaicod = "";
         lV64Configuracion_paiseswwds_14_tfpaidsc = "";
         A1500PaiDsc = "";
         A139PaiCod = "";
         P003H2_A1501PaiSts = new short[1] ;
         P003H2_A139PaiCod = new string[] {""} ;
         P003H2_A1500PaiDsc = new string[] {""} ;
         AV22Option = "";
         P003H3_A1500PaiDsc = new string[] {""} ;
         P003H3_A1501PaiSts = new short[1] ;
         P003H3_A139PaiCod = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.paiseswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003H2_A1501PaiSts, P003H2_A139PaiCod, P003H2_A1500PaiDsc
               }
               , new Object[] {
               P003H3_A1500PaiDsc, P003H3_A1501PaiSts, P003H3_A139PaiCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV52Configuracion_paiseswwds_2_dynamicfiltersoperator1 ;
      private short AV56Configuracion_paiseswwds_6_dynamicfiltersoperator2 ;
      private short AV60Configuracion_paiseswwds_10_dynamicfiltersoperator3 ;
      private short A1501PaiSts ;
      private int AV49GXV1 ;
      private int AV66Configuracion_paiseswwds_16_tfpaists_sels_Count ;
      private long AV30count ;
      private string AV10TFPaiCod ;
      private string AV11TFPaiCod_Sel ;
      private string AV12TFPaiDsc ;
      private string AV13TFPaiDsc_Sel ;
      private string AV38PaiDsc1 ;
      private string AV42PaiDsc2 ;
      private string AV46PaiDsc3 ;
      private string AV53Configuracion_paiseswwds_3_paidsc1 ;
      private string AV57Configuracion_paiseswwds_7_paidsc2 ;
      private string AV61Configuracion_paiseswwds_11_paidsc3 ;
      private string AV62Configuracion_paiseswwds_12_tfpaicod ;
      private string AV63Configuracion_paiseswwds_13_tfpaicod_sel ;
      private string AV64Configuracion_paiseswwds_14_tfpaidsc ;
      private string AV65Configuracion_paiseswwds_15_tfpaidsc_sel ;
      private string scmdbuf ;
      private string lV53Configuracion_paiseswwds_3_paidsc1 ;
      private string lV57Configuracion_paiseswwds_7_paidsc2 ;
      private string lV61Configuracion_paiseswwds_11_paidsc3 ;
      private string lV62Configuracion_paiseswwds_12_tfpaicod ;
      private string lV64Configuracion_paiseswwds_14_tfpaidsc ;
      private string A1500PaiDsc ;
      private string A139PaiCod ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV54Configuracion_paiseswwds_4_dynamicfiltersenabled2 ;
      private bool AV58Configuracion_paiseswwds_8_dynamicfiltersenabled3 ;
      private bool BRK3H3 ;
      private string AV24OptionsJson ;
      private string AV27OptionsDescJson ;
      private string AV29OptionIndexesJson ;
      private string AV16TFPaiSts_SelsJson ;
      private string AV20DDOName ;
      private string AV18SearchTxt ;
      private string AV19SearchTxtTo ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV51Configuracion_paiseswwds_1_dynamicfiltersselector1 ;
      private string AV55Configuracion_paiseswwds_5_dynamicfiltersselector2 ;
      private string AV59Configuracion_paiseswwds_9_dynamicfiltersselector3 ;
      private string AV22Option ;
      private GxSimpleCollection<short> AV17TFPaiSts_Sels ;
      private GxSimpleCollection<short> AV66Configuracion_paiseswwds_16_tfpaists_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P003H2_A1501PaiSts ;
      private string[] P003H2_A139PaiCod ;
      private string[] P003H2_A1500PaiDsc ;
      private string[] P003H3_A1500PaiDsc ;
      private short[] P003H3_A1501PaiSts ;
      private string[] P003H3_A139PaiCod ;
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

   public class paiseswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003H2( IGxContext context ,
                                             short A1501PaiSts ,
                                             GxSimpleCollection<short> AV66Configuracion_paiseswwds_16_tfpaists_sels ,
                                             string AV51Configuracion_paiseswwds_1_dynamicfiltersselector1 ,
                                             short AV52Configuracion_paiseswwds_2_dynamicfiltersoperator1 ,
                                             string AV53Configuracion_paiseswwds_3_paidsc1 ,
                                             bool AV54Configuracion_paiseswwds_4_dynamicfiltersenabled2 ,
                                             string AV55Configuracion_paiseswwds_5_dynamicfiltersselector2 ,
                                             short AV56Configuracion_paiseswwds_6_dynamicfiltersoperator2 ,
                                             string AV57Configuracion_paiseswwds_7_paidsc2 ,
                                             bool AV58Configuracion_paiseswwds_8_dynamicfiltersenabled3 ,
                                             string AV59Configuracion_paiseswwds_9_dynamicfiltersselector3 ,
                                             short AV60Configuracion_paiseswwds_10_dynamicfiltersoperator3 ,
                                             string AV61Configuracion_paiseswwds_11_paidsc3 ,
                                             string AV63Configuracion_paiseswwds_13_tfpaicod_sel ,
                                             string AV62Configuracion_paiseswwds_12_tfpaicod ,
                                             string AV65Configuracion_paiseswwds_15_tfpaidsc_sel ,
                                             string AV64Configuracion_paiseswwds_14_tfpaidsc ,
                                             int AV66Configuracion_paiseswwds_16_tfpaists_sels_Count ,
                                             string A1500PaiDsc ,
                                             string A139PaiCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [PaiSts], [PaiCod], NULL AS [PaiDsc] FROM ( SELECT TOP(100) PERCENT [PaiSts], [PaiCod], [PaiDsc] FROM [CPAISES]";
         if ( ( StringUtil.StrCmp(AV51Configuracion_paiseswwds_1_dynamicfiltersselector1, "PAIDSC") == 0 ) && ( AV52Configuracion_paiseswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_paiseswwds_3_paidsc1)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV53Configuracion_paiseswwds_3_paidsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Configuracion_paiseswwds_1_dynamicfiltersselector1, "PAIDSC") == 0 ) && ( AV52Configuracion_paiseswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_paiseswwds_3_paidsc1)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like '%' + @lV53Configuracion_paiseswwds_3_paidsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV54Configuracion_paiseswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_paiseswwds_5_dynamicfiltersselector2, "PAIDSC") == 0 ) && ( AV56Configuracion_paiseswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_paiseswwds_7_paidsc2)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV57Configuracion_paiseswwds_7_paidsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV54Configuracion_paiseswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_paiseswwds_5_dynamicfiltersselector2, "PAIDSC") == 0 ) && ( AV56Configuracion_paiseswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_paiseswwds_7_paidsc2)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like '%' + @lV57Configuracion_paiseswwds_7_paidsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV58Configuracion_paiseswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_paiseswwds_9_dynamicfiltersselector3, "PAIDSC") == 0 ) && ( AV60Configuracion_paiseswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_paiseswwds_11_paidsc3)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV61Configuracion_paiseswwds_11_paidsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV58Configuracion_paiseswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_paiseswwds_9_dynamicfiltersselector3, "PAIDSC") == 0 ) && ( AV60Configuracion_paiseswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_paiseswwds_11_paidsc3)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like '%' + @lV61Configuracion_paiseswwds_11_paidsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_paiseswwds_13_tfpaicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_paiseswwds_12_tfpaicod)) ) )
         {
            AddWhere(sWhereString, "([PaiCod] like @lV62Configuracion_paiseswwds_12_tfpaicod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_paiseswwds_13_tfpaicod_sel)) )
         {
            AddWhere(sWhereString, "([PaiCod] = @AV63Configuracion_paiseswwds_13_tfpaicod_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_paiseswwds_15_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_paiseswwds_14_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV64Configuracion_paiseswwds_14_tfpaidsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_paiseswwds_15_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "([PaiDsc] = @AV65Configuracion_paiseswwds_15_tfpaidsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV66Configuracion_paiseswwds_16_tfpaists_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV66Configuracion_paiseswwds_16_tfpaists_sels, "[PaiSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PaiCod]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [PaiCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P003H3( IGxContext context ,
                                             short A1501PaiSts ,
                                             GxSimpleCollection<short> AV66Configuracion_paiseswwds_16_tfpaists_sels ,
                                             string AV51Configuracion_paiseswwds_1_dynamicfiltersselector1 ,
                                             short AV52Configuracion_paiseswwds_2_dynamicfiltersoperator1 ,
                                             string AV53Configuracion_paiseswwds_3_paidsc1 ,
                                             bool AV54Configuracion_paiseswwds_4_dynamicfiltersenabled2 ,
                                             string AV55Configuracion_paiseswwds_5_dynamicfiltersselector2 ,
                                             short AV56Configuracion_paiseswwds_6_dynamicfiltersoperator2 ,
                                             string AV57Configuracion_paiseswwds_7_paidsc2 ,
                                             bool AV58Configuracion_paiseswwds_8_dynamicfiltersenabled3 ,
                                             string AV59Configuracion_paiseswwds_9_dynamicfiltersselector3 ,
                                             short AV60Configuracion_paiseswwds_10_dynamicfiltersoperator3 ,
                                             string AV61Configuracion_paiseswwds_11_paidsc3 ,
                                             string AV63Configuracion_paiseswwds_13_tfpaicod_sel ,
                                             string AV62Configuracion_paiseswwds_12_tfpaicod ,
                                             string AV65Configuracion_paiseswwds_15_tfpaidsc_sel ,
                                             string AV64Configuracion_paiseswwds_14_tfpaidsc ,
                                             int AV66Configuracion_paiseswwds_16_tfpaists_sels_Count ,
                                             string A1500PaiDsc ,
                                             string A139PaiCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [PaiDsc], [PaiSts], [PaiCod] FROM [CPAISES]";
         if ( ( StringUtil.StrCmp(AV51Configuracion_paiseswwds_1_dynamicfiltersselector1, "PAIDSC") == 0 ) && ( AV52Configuracion_paiseswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_paiseswwds_3_paidsc1)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV53Configuracion_paiseswwds_3_paidsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Configuracion_paiseswwds_1_dynamicfiltersselector1, "PAIDSC") == 0 ) && ( AV52Configuracion_paiseswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_paiseswwds_3_paidsc1)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like '%' + @lV53Configuracion_paiseswwds_3_paidsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV54Configuracion_paiseswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_paiseswwds_5_dynamicfiltersselector2, "PAIDSC") == 0 ) && ( AV56Configuracion_paiseswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_paiseswwds_7_paidsc2)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV57Configuracion_paiseswwds_7_paidsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV54Configuracion_paiseswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_paiseswwds_5_dynamicfiltersselector2, "PAIDSC") == 0 ) && ( AV56Configuracion_paiseswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_paiseswwds_7_paidsc2)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like '%' + @lV57Configuracion_paiseswwds_7_paidsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV58Configuracion_paiseswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_paiseswwds_9_dynamicfiltersselector3, "PAIDSC") == 0 ) && ( AV60Configuracion_paiseswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_paiseswwds_11_paidsc3)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV61Configuracion_paiseswwds_11_paidsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV58Configuracion_paiseswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_paiseswwds_9_dynamicfiltersselector3, "PAIDSC") == 0 ) && ( AV60Configuracion_paiseswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_paiseswwds_11_paidsc3)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like '%' + @lV61Configuracion_paiseswwds_11_paidsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_paiseswwds_13_tfpaicod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_paiseswwds_12_tfpaicod)) ) )
         {
            AddWhere(sWhereString, "([PaiCod] like @lV62Configuracion_paiseswwds_12_tfpaicod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_paiseswwds_13_tfpaicod_sel)) )
         {
            AddWhere(sWhereString, "([PaiCod] = @AV63Configuracion_paiseswwds_13_tfpaicod_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_paiseswwds_15_tfpaidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_paiseswwds_14_tfpaidsc)) ) )
         {
            AddWhere(sWhereString, "([PaiDsc] like @lV64Configuracion_paiseswwds_14_tfpaidsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_paiseswwds_15_tfpaidsc_sel)) )
         {
            AddWhere(sWhereString, "([PaiDsc] = @AV65Configuracion_paiseswwds_15_tfpaidsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV66Configuracion_paiseswwds_16_tfpaists_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV66Configuracion_paiseswwds_16_tfpaists_sels, "[PaiSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PaiDsc]";
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
                     return conditional_P003H2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
               case 1 :
                     return conditional_P003H3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
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
          Object[] prmP003H2;
          prmP003H2 = new Object[] {
          new ParDef("@lV53Configuracion_paiseswwds_3_paidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Configuracion_paiseswwds_3_paidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_paiseswwds_7_paidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_paiseswwds_7_paidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_paiseswwds_11_paidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_paiseswwds_11_paidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_paiseswwds_12_tfpaicod",GXType.NChar,4,0) ,
          new ParDef("@AV63Configuracion_paiseswwds_13_tfpaicod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV64Configuracion_paiseswwds_14_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Configuracion_paiseswwds_15_tfpaidsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP003H3;
          prmP003H3 = new Object[] {
          new ParDef("@lV53Configuracion_paiseswwds_3_paidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Configuracion_paiseswwds_3_paidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_paiseswwds_7_paidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Configuracion_paiseswwds_7_paidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_paiseswwds_11_paidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Configuracion_paiseswwds_11_paidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV62Configuracion_paiseswwds_12_tfpaicod",GXType.NChar,4,0) ,
          new ParDef("@AV63Configuracion_paiseswwds_13_tfpaicod_sel",GXType.NChar,4,0) ,
          new ParDef("@lV64Configuracion_paiseswwds_14_tfpaidsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Configuracion_paiseswwds_15_tfpaidsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003H2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P003H3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003H3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 4);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                return;
       }
    }

 }

}
