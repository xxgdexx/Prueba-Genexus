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
namespace GeneXus.Programs.produccion {
   public class operarioswwgetfilterdata : GXProcedure
   {
      public operarioswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public operarioswwgetfilterdata( IGxContext context )
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
         this.AV18DDOName = aP0_DDOName;
         this.AV16SearchTxt = aP1_SearchTxt;
         this.AV17SearchTxtTo = aP2_SearchTxtTo;
         this.AV22OptionsJson = "" ;
         this.AV25OptionsDescJson = "" ;
         this.AV27OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV22OptionsJson;
         aP4_OptionsDescJson=this.AV25OptionsDescJson;
         aP5_OptionIndexesJson=this.AV27OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV27OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         operarioswwgetfilterdata objoperarioswwgetfilterdata;
         objoperarioswwgetfilterdata = new operarioswwgetfilterdata();
         objoperarioswwgetfilterdata.AV18DDOName = aP0_DDOName;
         objoperarioswwgetfilterdata.AV16SearchTxt = aP1_SearchTxt;
         objoperarioswwgetfilterdata.AV17SearchTxtTo = aP2_SearchTxtTo;
         objoperarioswwgetfilterdata.AV22OptionsJson = "" ;
         objoperarioswwgetfilterdata.AV25OptionsDescJson = "" ;
         objoperarioswwgetfilterdata.AV27OptionIndexesJson = "" ;
         objoperarioswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objoperarioswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objoperarioswwgetfilterdata);
         aP3_OptionsJson=this.AV22OptionsJson;
         aP4_OptionsDescJson=this.AV25OptionsDescJson;
         aP5_OptionIndexesJson=this.AV27OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((operarioswwgetfilterdata)stateInfo).executePrivate();
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
         AV21Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV18DDOName), "DDO_OPECOD") == 0 )
         {
            /* Execute user subroutine: 'LOADOPECODOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV18DDOName), "DDO_OPEDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADOPEDSCOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV22OptionsJson = AV21Options.ToJSonString(false);
         AV25OptionsDescJson = AV24OptionsDesc.ToJSonString(false);
         AV27OptionIndexesJson = AV26OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get("Produccion.OperariosWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Produccion.OperariosWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("Produccion.OperariosWWGridState"), null, "", "");
         }
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFOPECOD") == 0 )
            {
               AV10TFOPECod = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFOPECOD_SEL") == 0 )
            {
               AV11TFOPECod_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFOPEDSC") == 0 )
            {
               AV12TFOPEDsc = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFOPEDSC_SEL") == 0 )
            {
               AV13TFOPEDsc_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFOPESTS_SEL") == 0 )
            {
               AV14TFOPESts_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV15TFOPESts_Sels.FromJSonString(AV14TFOPESts_SelsJson, null);
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV34DynamicFiltersSelector1 = AV33GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV34DynamicFiltersSelector1, "OPEDSC") == 0 )
            {
               AV35DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV36OPEDsc1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV37DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV38DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV38DynamicFiltersSelector2, "OPEDSC") == 0 )
               {
                  AV39DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV40OPEDsc2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV41DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV42DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "OPEDSC") == 0 )
                  {
                     AV43DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV44OPEDsc3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADOPECODOPTIONS' Routine */
         returnInSub = false;
         AV10TFOPECod = AV16SearchTxt;
         AV11TFOPECod_Sel = "";
         AV49Produccion_operarioswwds_1_dynamicfiltersselector1 = AV34DynamicFiltersSelector1;
         AV50Produccion_operarioswwds_2_dynamicfiltersoperator1 = AV35DynamicFiltersOperator1;
         AV51Produccion_operarioswwds_3_opedsc1 = AV36OPEDsc1;
         AV52Produccion_operarioswwds_4_dynamicfiltersenabled2 = AV37DynamicFiltersEnabled2;
         AV53Produccion_operarioswwds_5_dynamicfiltersselector2 = AV38DynamicFiltersSelector2;
         AV54Produccion_operarioswwds_6_dynamicfiltersoperator2 = AV39DynamicFiltersOperator2;
         AV55Produccion_operarioswwds_7_opedsc2 = AV40OPEDsc2;
         AV56Produccion_operarioswwds_8_dynamicfiltersenabled3 = AV41DynamicFiltersEnabled3;
         AV57Produccion_operarioswwds_9_dynamicfiltersselector3 = AV42DynamicFiltersSelector3;
         AV58Produccion_operarioswwds_10_dynamicfiltersoperator3 = AV43DynamicFiltersOperator3;
         AV59Produccion_operarioswwds_11_opedsc3 = AV44OPEDsc3;
         AV60Produccion_operarioswwds_12_tfopecod = AV10TFOPECod;
         AV61Produccion_operarioswwds_13_tfopecod_sel = AV11TFOPECod_Sel;
         AV62Produccion_operarioswwds_14_tfopedsc = AV12TFOPEDsc;
         AV63Produccion_operarioswwds_15_tfopedsc_sel = AV13TFOPEDsc_Sel;
         AV64Produccion_operarioswwds_16_tfopests_sels = AV15TFOPESts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1423OPESts ,
                                              AV64Produccion_operarioswwds_16_tfopests_sels ,
                                              AV49Produccion_operarioswwds_1_dynamicfiltersselector1 ,
                                              AV50Produccion_operarioswwds_2_dynamicfiltersoperator1 ,
                                              AV51Produccion_operarioswwds_3_opedsc1 ,
                                              AV52Produccion_operarioswwds_4_dynamicfiltersenabled2 ,
                                              AV53Produccion_operarioswwds_5_dynamicfiltersselector2 ,
                                              AV54Produccion_operarioswwds_6_dynamicfiltersoperator2 ,
                                              AV55Produccion_operarioswwds_7_opedsc2 ,
                                              AV56Produccion_operarioswwds_8_dynamicfiltersenabled3 ,
                                              AV57Produccion_operarioswwds_9_dynamicfiltersselector3 ,
                                              AV58Produccion_operarioswwds_10_dynamicfiltersoperator3 ,
                                              AV59Produccion_operarioswwds_11_opedsc3 ,
                                              AV61Produccion_operarioswwds_13_tfopecod_sel ,
                                              AV60Produccion_operarioswwds_12_tfopecod ,
                                              AV63Produccion_operarioswwds_15_tfopedsc_sel ,
                                              AV62Produccion_operarioswwds_14_tfopedsc ,
                                              AV64Produccion_operarioswwds_16_tfopests_sels.Count ,
                                              A1422OPEDsc ,
                                              A321OPECod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV51Produccion_operarioswwds_3_opedsc1 = StringUtil.PadR( StringUtil.RTrim( AV51Produccion_operarioswwds_3_opedsc1), 100, "%");
         lV51Produccion_operarioswwds_3_opedsc1 = StringUtil.PadR( StringUtil.RTrim( AV51Produccion_operarioswwds_3_opedsc1), 100, "%");
         lV55Produccion_operarioswwds_7_opedsc2 = StringUtil.PadR( StringUtil.RTrim( AV55Produccion_operarioswwds_7_opedsc2), 100, "%");
         lV55Produccion_operarioswwds_7_opedsc2 = StringUtil.PadR( StringUtil.RTrim( AV55Produccion_operarioswwds_7_opedsc2), 100, "%");
         lV59Produccion_operarioswwds_11_opedsc3 = StringUtil.PadR( StringUtil.RTrim( AV59Produccion_operarioswwds_11_opedsc3), 100, "%");
         lV59Produccion_operarioswwds_11_opedsc3 = StringUtil.PadR( StringUtil.RTrim( AV59Produccion_operarioswwds_11_opedsc3), 100, "%");
         lV60Produccion_operarioswwds_12_tfopecod = StringUtil.PadR( StringUtil.RTrim( AV60Produccion_operarioswwds_12_tfopecod), 20, "%");
         lV62Produccion_operarioswwds_14_tfopedsc = StringUtil.PadR( StringUtil.RTrim( AV62Produccion_operarioswwds_14_tfopedsc), 100, "%");
         /* Using cursor P00652 */
         pr_default.execute(0, new Object[] {lV51Produccion_operarioswwds_3_opedsc1, lV51Produccion_operarioswwds_3_opedsc1, lV55Produccion_operarioswwds_7_opedsc2, lV55Produccion_operarioswwds_7_opedsc2, lV59Produccion_operarioswwds_11_opedsc3, lV59Produccion_operarioswwds_11_opedsc3, lV60Produccion_operarioswwds_12_tfopecod, AV61Produccion_operarioswwds_13_tfopecod_sel, lV62Produccion_operarioswwds_14_tfopedsc, AV63Produccion_operarioswwds_15_tfopedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1423OPESts = P00652_A1423OPESts[0];
            A321OPECod = P00652_A321OPECod[0];
            A1422OPEDsc = P00652_A1422OPEDsc[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A321OPECod)) )
            {
               AV20Option = A321OPECod;
               AV21Options.Add(AV20Option, 0);
            }
            if ( AV21Options.Count == 50 )
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
         /* 'LOADOPEDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFOPEDsc = AV16SearchTxt;
         AV13TFOPEDsc_Sel = "";
         AV49Produccion_operarioswwds_1_dynamicfiltersselector1 = AV34DynamicFiltersSelector1;
         AV50Produccion_operarioswwds_2_dynamicfiltersoperator1 = AV35DynamicFiltersOperator1;
         AV51Produccion_operarioswwds_3_opedsc1 = AV36OPEDsc1;
         AV52Produccion_operarioswwds_4_dynamicfiltersenabled2 = AV37DynamicFiltersEnabled2;
         AV53Produccion_operarioswwds_5_dynamicfiltersselector2 = AV38DynamicFiltersSelector2;
         AV54Produccion_operarioswwds_6_dynamicfiltersoperator2 = AV39DynamicFiltersOperator2;
         AV55Produccion_operarioswwds_7_opedsc2 = AV40OPEDsc2;
         AV56Produccion_operarioswwds_8_dynamicfiltersenabled3 = AV41DynamicFiltersEnabled3;
         AV57Produccion_operarioswwds_9_dynamicfiltersselector3 = AV42DynamicFiltersSelector3;
         AV58Produccion_operarioswwds_10_dynamicfiltersoperator3 = AV43DynamicFiltersOperator3;
         AV59Produccion_operarioswwds_11_opedsc3 = AV44OPEDsc3;
         AV60Produccion_operarioswwds_12_tfopecod = AV10TFOPECod;
         AV61Produccion_operarioswwds_13_tfopecod_sel = AV11TFOPECod_Sel;
         AV62Produccion_operarioswwds_14_tfopedsc = AV12TFOPEDsc;
         AV63Produccion_operarioswwds_15_tfopedsc_sel = AV13TFOPEDsc_Sel;
         AV64Produccion_operarioswwds_16_tfopests_sels = AV15TFOPESts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1423OPESts ,
                                              AV64Produccion_operarioswwds_16_tfopests_sels ,
                                              AV49Produccion_operarioswwds_1_dynamicfiltersselector1 ,
                                              AV50Produccion_operarioswwds_2_dynamicfiltersoperator1 ,
                                              AV51Produccion_operarioswwds_3_opedsc1 ,
                                              AV52Produccion_operarioswwds_4_dynamicfiltersenabled2 ,
                                              AV53Produccion_operarioswwds_5_dynamicfiltersselector2 ,
                                              AV54Produccion_operarioswwds_6_dynamicfiltersoperator2 ,
                                              AV55Produccion_operarioswwds_7_opedsc2 ,
                                              AV56Produccion_operarioswwds_8_dynamicfiltersenabled3 ,
                                              AV57Produccion_operarioswwds_9_dynamicfiltersselector3 ,
                                              AV58Produccion_operarioswwds_10_dynamicfiltersoperator3 ,
                                              AV59Produccion_operarioswwds_11_opedsc3 ,
                                              AV61Produccion_operarioswwds_13_tfopecod_sel ,
                                              AV60Produccion_operarioswwds_12_tfopecod ,
                                              AV63Produccion_operarioswwds_15_tfopedsc_sel ,
                                              AV62Produccion_operarioswwds_14_tfopedsc ,
                                              AV64Produccion_operarioswwds_16_tfopests_sels.Count ,
                                              A1422OPEDsc ,
                                              A321OPECod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV51Produccion_operarioswwds_3_opedsc1 = StringUtil.PadR( StringUtil.RTrim( AV51Produccion_operarioswwds_3_opedsc1), 100, "%");
         lV51Produccion_operarioswwds_3_opedsc1 = StringUtil.PadR( StringUtil.RTrim( AV51Produccion_operarioswwds_3_opedsc1), 100, "%");
         lV55Produccion_operarioswwds_7_opedsc2 = StringUtil.PadR( StringUtil.RTrim( AV55Produccion_operarioswwds_7_opedsc2), 100, "%");
         lV55Produccion_operarioswwds_7_opedsc2 = StringUtil.PadR( StringUtil.RTrim( AV55Produccion_operarioswwds_7_opedsc2), 100, "%");
         lV59Produccion_operarioswwds_11_opedsc3 = StringUtil.PadR( StringUtil.RTrim( AV59Produccion_operarioswwds_11_opedsc3), 100, "%");
         lV59Produccion_operarioswwds_11_opedsc3 = StringUtil.PadR( StringUtil.RTrim( AV59Produccion_operarioswwds_11_opedsc3), 100, "%");
         lV60Produccion_operarioswwds_12_tfopecod = StringUtil.PadR( StringUtil.RTrim( AV60Produccion_operarioswwds_12_tfopecod), 20, "%");
         lV62Produccion_operarioswwds_14_tfopedsc = StringUtil.PadR( StringUtil.RTrim( AV62Produccion_operarioswwds_14_tfopedsc), 100, "%");
         /* Using cursor P00653 */
         pr_default.execute(1, new Object[] {lV51Produccion_operarioswwds_3_opedsc1, lV51Produccion_operarioswwds_3_opedsc1, lV55Produccion_operarioswwds_7_opedsc2, lV55Produccion_operarioswwds_7_opedsc2, lV59Produccion_operarioswwds_11_opedsc3, lV59Produccion_operarioswwds_11_opedsc3, lV60Produccion_operarioswwds_12_tfopecod, AV61Produccion_operarioswwds_13_tfopecod_sel, lV62Produccion_operarioswwds_14_tfopedsc, AV63Produccion_operarioswwds_15_tfopedsc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK653 = false;
            A1422OPEDsc = P00653_A1422OPEDsc[0];
            A1423OPESts = P00653_A1423OPESts[0];
            A321OPECod = P00653_A321OPECod[0];
            AV28count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00653_A1422OPEDsc[0], A1422OPEDsc) == 0 ) )
            {
               BRK653 = false;
               A321OPECod = P00653_A321OPECod[0];
               AV28count = (long)(AV28count+1);
               BRK653 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1422OPEDsc)) )
            {
               AV20Option = A1422OPEDsc;
               AV21Options.Add(AV20Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV21Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK653 )
            {
               BRK653 = true;
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
         AV22OptionsJson = "";
         AV25OptionsDescJson = "";
         AV27OptionIndexesJson = "";
         AV21Options = new GxSimpleCollection<string>();
         AV24OptionsDesc = new GxSimpleCollection<string>();
         AV26OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29Session = context.GetSession();
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TFOPECod = "";
         AV11TFOPECod_Sel = "";
         AV12TFOPEDsc = "";
         AV13TFOPEDsc_Sel = "";
         AV14TFOPESts_SelsJson = "";
         AV15TFOPESts_Sels = new GxSimpleCollection<short>();
         AV33GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV34DynamicFiltersSelector1 = "";
         AV36OPEDsc1 = "";
         AV38DynamicFiltersSelector2 = "";
         AV40OPEDsc2 = "";
         AV42DynamicFiltersSelector3 = "";
         AV44OPEDsc3 = "";
         AV49Produccion_operarioswwds_1_dynamicfiltersselector1 = "";
         AV51Produccion_operarioswwds_3_opedsc1 = "";
         AV53Produccion_operarioswwds_5_dynamicfiltersselector2 = "";
         AV55Produccion_operarioswwds_7_opedsc2 = "";
         AV57Produccion_operarioswwds_9_dynamicfiltersselector3 = "";
         AV59Produccion_operarioswwds_11_opedsc3 = "";
         AV60Produccion_operarioswwds_12_tfopecod = "";
         AV61Produccion_operarioswwds_13_tfopecod_sel = "";
         AV62Produccion_operarioswwds_14_tfopedsc = "";
         AV63Produccion_operarioswwds_15_tfopedsc_sel = "";
         AV64Produccion_operarioswwds_16_tfopests_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV51Produccion_operarioswwds_3_opedsc1 = "";
         lV55Produccion_operarioswwds_7_opedsc2 = "";
         lV59Produccion_operarioswwds_11_opedsc3 = "";
         lV60Produccion_operarioswwds_12_tfopecod = "";
         lV62Produccion_operarioswwds_14_tfopedsc = "";
         A1422OPEDsc = "";
         A321OPECod = "";
         P00652_A1423OPESts = new short[1] ;
         P00652_A321OPECod = new string[] {""} ;
         P00652_A1422OPEDsc = new string[] {""} ;
         AV20Option = "";
         P00653_A1422OPEDsc = new string[] {""} ;
         P00653_A1423OPESts = new short[1] ;
         P00653_A321OPECod = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.operarioswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00652_A1423OPESts, P00652_A321OPECod, P00652_A1422OPEDsc
               }
               , new Object[] {
               P00653_A1422OPEDsc, P00653_A1423OPESts, P00653_A321OPECod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV35DynamicFiltersOperator1 ;
      private short AV39DynamicFiltersOperator2 ;
      private short AV43DynamicFiltersOperator3 ;
      private short AV50Produccion_operarioswwds_2_dynamicfiltersoperator1 ;
      private short AV54Produccion_operarioswwds_6_dynamicfiltersoperator2 ;
      private short AV58Produccion_operarioswwds_10_dynamicfiltersoperator3 ;
      private short A1423OPESts ;
      private int AV47GXV1 ;
      private int AV64Produccion_operarioswwds_16_tfopests_sels_Count ;
      private long AV28count ;
      private string AV10TFOPECod ;
      private string AV11TFOPECod_Sel ;
      private string AV12TFOPEDsc ;
      private string AV13TFOPEDsc_Sel ;
      private string AV36OPEDsc1 ;
      private string AV40OPEDsc2 ;
      private string AV44OPEDsc3 ;
      private string AV51Produccion_operarioswwds_3_opedsc1 ;
      private string AV55Produccion_operarioswwds_7_opedsc2 ;
      private string AV59Produccion_operarioswwds_11_opedsc3 ;
      private string AV60Produccion_operarioswwds_12_tfopecod ;
      private string AV61Produccion_operarioswwds_13_tfopecod_sel ;
      private string AV62Produccion_operarioswwds_14_tfopedsc ;
      private string AV63Produccion_operarioswwds_15_tfopedsc_sel ;
      private string scmdbuf ;
      private string lV51Produccion_operarioswwds_3_opedsc1 ;
      private string lV55Produccion_operarioswwds_7_opedsc2 ;
      private string lV59Produccion_operarioswwds_11_opedsc3 ;
      private string lV60Produccion_operarioswwds_12_tfopecod ;
      private string lV62Produccion_operarioswwds_14_tfopedsc ;
      private string A1422OPEDsc ;
      private string A321OPECod ;
      private bool returnInSub ;
      private bool AV37DynamicFiltersEnabled2 ;
      private bool AV41DynamicFiltersEnabled3 ;
      private bool AV52Produccion_operarioswwds_4_dynamicfiltersenabled2 ;
      private bool AV56Produccion_operarioswwds_8_dynamicfiltersenabled3 ;
      private bool BRK653 ;
      private string AV22OptionsJson ;
      private string AV25OptionsDescJson ;
      private string AV27OptionIndexesJson ;
      private string AV14TFOPESts_SelsJson ;
      private string AV18DDOName ;
      private string AV16SearchTxt ;
      private string AV17SearchTxtTo ;
      private string AV34DynamicFiltersSelector1 ;
      private string AV38DynamicFiltersSelector2 ;
      private string AV42DynamicFiltersSelector3 ;
      private string AV49Produccion_operarioswwds_1_dynamicfiltersselector1 ;
      private string AV53Produccion_operarioswwds_5_dynamicfiltersselector2 ;
      private string AV57Produccion_operarioswwds_9_dynamicfiltersselector3 ;
      private string AV20Option ;
      private GxSimpleCollection<short> AV15TFOPESts_Sels ;
      private GxSimpleCollection<short> AV64Produccion_operarioswwds_16_tfopests_sels ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00652_A1423OPESts ;
      private string[] P00652_A321OPECod ;
      private string[] P00652_A1422OPEDsc ;
      private string[] P00653_A1422OPEDsc ;
      private short[] P00653_A1423OPESts ;
      private string[] P00653_A321OPECod ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV24OptionsDesc ;
      private GxSimpleCollection<string> AV26OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV33GridStateDynamicFilter ;
   }

   public class operarioswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00652( IGxContext context ,
                                             short A1423OPESts ,
                                             GxSimpleCollection<short> AV64Produccion_operarioswwds_16_tfopests_sels ,
                                             string AV49Produccion_operarioswwds_1_dynamicfiltersselector1 ,
                                             short AV50Produccion_operarioswwds_2_dynamicfiltersoperator1 ,
                                             string AV51Produccion_operarioswwds_3_opedsc1 ,
                                             bool AV52Produccion_operarioswwds_4_dynamicfiltersenabled2 ,
                                             string AV53Produccion_operarioswwds_5_dynamicfiltersselector2 ,
                                             short AV54Produccion_operarioswwds_6_dynamicfiltersoperator2 ,
                                             string AV55Produccion_operarioswwds_7_opedsc2 ,
                                             bool AV56Produccion_operarioswwds_8_dynamicfiltersenabled3 ,
                                             string AV57Produccion_operarioswwds_9_dynamicfiltersselector3 ,
                                             short AV58Produccion_operarioswwds_10_dynamicfiltersoperator3 ,
                                             string AV59Produccion_operarioswwds_11_opedsc3 ,
                                             string AV61Produccion_operarioswwds_13_tfopecod_sel ,
                                             string AV60Produccion_operarioswwds_12_tfopecod ,
                                             string AV63Produccion_operarioswwds_15_tfopedsc_sel ,
                                             string AV62Produccion_operarioswwds_14_tfopedsc ,
                                             int AV64Produccion_operarioswwds_16_tfopests_sels_Count ,
                                             string A1422OPEDsc ,
                                             string A321OPECod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [OPESts], [OPECod], NULL AS [OPEDsc] FROM ( SELECT TOP(100) PERCENT [OPESts], [OPECod], [OPEDsc] FROM [POOPERARIOS]";
         if ( ( StringUtil.StrCmp(AV49Produccion_operarioswwds_1_dynamicfiltersselector1, "OPEDSC") == 0 ) && ( AV50Produccion_operarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Produccion_operarioswwds_3_opedsc1)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV51Produccion_operarioswwds_3_opedsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV49Produccion_operarioswwds_1_dynamicfiltersselector1, "OPEDSC") == 0 ) && ( AV50Produccion_operarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Produccion_operarioswwds_3_opedsc1)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like '%' + @lV51Produccion_operarioswwds_3_opedsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV52Produccion_operarioswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Produccion_operarioswwds_5_dynamicfiltersselector2, "OPEDSC") == 0 ) && ( AV54Produccion_operarioswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Produccion_operarioswwds_7_opedsc2)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV55Produccion_operarioswwds_7_opedsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV52Produccion_operarioswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Produccion_operarioswwds_5_dynamicfiltersselector2, "OPEDSC") == 0 ) && ( AV54Produccion_operarioswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Produccion_operarioswwds_7_opedsc2)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like '%' + @lV55Produccion_operarioswwds_7_opedsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV56Produccion_operarioswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV57Produccion_operarioswwds_9_dynamicfiltersselector3, "OPEDSC") == 0 ) && ( AV58Produccion_operarioswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Produccion_operarioswwds_11_opedsc3)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV59Produccion_operarioswwds_11_opedsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV56Produccion_operarioswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV57Produccion_operarioswwds_9_dynamicfiltersselector3, "OPEDSC") == 0 ) && ( AV58Produccion_operarioswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Produccion_operarioswwds_11_opedsc3)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like '%' + @lV59Produccion_operarioswwds_11_opedsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_operarioswwds_13_tfopecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Produccion_operarioswwds_12_tfopecod)) ) )
         {
            AddWhere(sWhereString, "([OPECod] like @lV60Produccion_operarioswwds_12_tfopecod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_operarioswwds_13_tfopecod_sel)) )
         {
            AddWhere(sWhereString, "([OPECod] = @AV61Produccion_operarioswwds_13_tfopecod_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Produccion_operarioswwds_15_tfopedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Produccion_operarioswwds_14_tfopedsc)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV62Produccion_operarioswwds_14_tfopedsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Produccion_operarioswwds_15_tfopedsc_sel)) )
         {
            AddWhere(sWhereString, "([OPEDsc] = @AV63Produccion_operarioswwds_15_tfopedsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV64Produccion_operarioswwds_16_tfopests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV64Produccion_operarioswwds_16_tfopests_sels, "[OPESts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [OPECod]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [OPECod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00653( IGxContext context ,
                                             short A1423OPESts ,
                                             GxSimpleCollection<short> AV64Produccion_operarioswwds_16_tfopests_sels ,
                                             string AV49Produccion_operarioswwds_1_dynamicfiltersselector1 ,
                                             short AV50Produccion_operarioswwds_2_dynamicfiltersoperator1 ,
                                             string AV51Produccion_operarioswwds_3_opedsc1 ,
                                             bool AV52Produccion_operarioswwds_4_dynamicfiltersenabled2 ,
                                             string AV53Produccion_operarioswwds_5_dynamicfiltersselector2 ,
                                             short AV54Produccion_operarioswwds_6_dynamicfiltersoperator2 ,
                                             string AV55Produccion_operarioswwds_7_opedsc2 ,
                                             bool AV56Produccion_operarioswwds_8_dynamicfiltersenabled3 ,
                                             string AV57Produccion_operarioswwds_9_dynamicfiltersselector3 ,
                                             short AV58Produccion_operarioswwds_10_dynamicfiltersoperator3 ,
                                             string AV59Produccion_operarioswwds_11_opedsc3 ,
                                             string AV61Produccion_operarioswwds_13_tfopecod_sel ,
                                             string AV60Produccion_operarioswwds_12_tfopecod ,
                                             string AV63Produccion_operarioswwds_15_tfopedsc_sel ,
                                             string AV62Produccion_operarioswwds_14_tfopedsc ,
                                             int AV64Produccion_operarioswwds_16_tfopests_sels_Count ,
                                             string A1422OPEDsc ,
                                             string A321OPECod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [OPEDsc], [OPESts], [OPECod] FROM [POOPERARIOS]";
         if ( ( StringUtil.StrCmp(AV49Produccion_operarioswwds_1_dynamicfiltersselector1, "OPEDSC") == 0 ) && ( AV50Produccion_operarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Produccion_operarioswwds_3_opedsc1)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV51Produccion_operarioswwds_3_opedsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV49Produccion_operarioswwds_1_dynamicfiltersselector1, "OPEDSC") == 0 ) && ( AV50Produccion_operarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Produccion_operarioswwds_3_opedsc1)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like '%' + @lV51Produccion_operarioswwds_3_opedsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV52Produccion_operarioswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Produccion_operarioswwds_5_dynamicfiltersselector2, "OPEDSC") == 0 ) && ( AV54Produccion_operarioswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Produccion_operarioswwds_7_opedsc2)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV55Produccion_operarioswwds_7_opedsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV52Produccion_operarioswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Produccion_operarioswwds_5_dynamicfiltersselector2, "OPEDSC") == 0 ) && ( AV54Produccion_operarioswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Produccion_operarioswwds_7_opedsc2)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like '%' + @lV55Produccion_operarioswwds_7_opedsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV56Produccion_operarioswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV57Produccion_operarioswwds_9_dynamicfiltersselector3, "OPEDSC") == 0 ) && ( AV58Produccion_operarioswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Produccion_operarioswwds_11_opedsc3)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV59Produccion_operarioswwds_11_opedsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV56Produccion_operarioswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV57Produccion_operarioswwds_9_dynamicfiltersselector3, "OPEDSC") == 0 ) && ( AV58Produccion_operarioswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Produccion_operarioswwds_11_opedsc3)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like '%' + @lV59Produccion_operarioswwds_11_opedsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_operarioswwds_13_tfopecod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Produccion_operarioswwds_12_tfopecod)) ) )
         {
            AddWhere(sWhereString, "([OPECod] like @lV60Produccion_operarioswwds_12_tfopecod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_operarioswwds_13_tfopecod_sel)) )
         {
            AddWhere(sWhereString, "([OPECod] = @AV61Produccion_operarioswwds_13_tfopecod_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Produccion_operarioswwds_15_tfopedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Produccion_operarioswwds_14_tfopedsc)) ) )
         {
            AddWhere(sWhereString, "([OPEDsc] like @lV62Produccion_operarioswwds_14_tfopedsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Produccion_operarioswwds_15_tfopedsc_sel)) )
         {
            AddWhere(sWhereString, "([OPEDsc] = @AV63Produccion_operarioswwds_15_tfopedsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV64Produccion_operarioswwds_16_tfopests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV64Produccion_operarioswwds_16_tfopests_sels, "[OPESts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [OPEDsc]";
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
                     return conditional_P00652(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
               case 1 :
                     return conditional_P00653(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
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
          Object[] prmP00652;
          prmP00652 = new Object[] {
          new ParDef("@lV51Produccion_operarioswwds_3_opedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV51Produccion_operarioswwds_3_opedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV55Produccion_operarioswwds_7_opedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV55Produccion_operarioswwds_7_opedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV59Produccion_operarioswwds_11_opedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV59Produccion_operarioswwds_11_opedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV60Produccion_operarioswwds_12_tfopecod",GXType.NChar,20,0) ,
          new ParDef("@AV61Produccion_operarioswwds_13_tfopecod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV62Produccion_operarioswwds_14_tfopedsc",GXType.NChar,100,0) ,
          new ParDef("@AV63Produccion_operarioswwds_15_tfopedsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP00653;
          prmP00653 = new Object[] {
          new ParDef("@lV51Produccion_operarioswwds_3_opedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV51Produccion_operarioswwds_3_opedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV55Produccion_operarioswwds_7_opedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV55Produccion_operarioswwds_7_opedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV59Produccion_operarioswwds_11_opedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV59Produccion_operarioswwds_11_opedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV60Produccion_operarioswwds_12_tfopecod",GXType.NChar,20,0) ,
          new ParDef("@AV61Produccion_operarioswwds_13_tfopecod_sel",GXType.NChar,20,0) ,
          new ParDef("@lV62Produccion_operarioswwds_14_tfopedsc",GXType.NChar,100,0) ,
          new ParDef("@AV63Produccion_operarioswwds_15_tfopedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00652", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00652,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00653", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00653,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                return;
       }
    }

 }

}
