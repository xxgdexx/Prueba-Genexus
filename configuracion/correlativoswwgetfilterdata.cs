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
   public class correlativoswwgetfilterdata : GXProcedure
   {
      public correlativoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public correlativoswwgetfilterdata( IGxContext context )
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
         this.AV16DDOName = aP0_DDOName;
         this.AV14SearchTxt = aP1_SearchTxt;
         this.AV15SearchTxtTo = aP2_SearchTxtTo;
         this.AV20OptionsJson = "" ;
         this.AV23OptionsDescJson = "" ;
         this.AV25OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV20OptionsJson;
         aP4_OptionsDescJson=this.AV23OptionsDescJson;
         aP5_OptionIndexesJson=this.AV25OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV25OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         correlativoswwgetfilterdata objcorrelativoswwgetfilterdata;
         objcorrelativoswwgetfilterdata = new correlativoswwgetfilterdata();
         objcorrelativoswwgetfilterdata.AV16DDOName = aP0_DDOName;
         objcorrelativoswwgetfilterdata.AV14SearchTxt = aP1_SearchTxt;
         objcorrelativoswwgetfilterdata.AV15SearchTxtTo = aP2_SearchTxtTo;
         objcorrelativoswwgetfilterdata.AV20OptionsJson = "" ;
         objcorrelativoswwgetfilterdata.AV23OptionsDescJson = "" ;
         objcorrelativoswwgetfilterdata.AV25OptionIndexesJson = "" ;
         objcorrelativoswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objcorrelativoswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcorrelativoswwgetfilterdata);
         aP3_OptionsJson=this.AV20OptionsJson;
         aP4_OptionsDescJson=this.AV23OptionsDescJson;
         aP5_OptionIndexesJson=this.AV25OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((correlativoswwgetfilterdata)stateInfo).executePrivate();
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
         AV19Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV16DDOName), "DDO_CORTIP") == 0 )
         {
            /* Execute user subroutine: 'LOADCORTIPOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV20OptionsJson = AV19Options.ToJSonString(false);
         AV23OptionsDescJson = AV22OptionsDesc.ToJSonString(false);
         AV25OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get("Configuracion.CorrelativosWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.CorrelativosWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Configuracion.CorrelativosWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCORTIP") == 0 )
            {
               AV10TFCorTip = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCORTIP_SEL") == 0 )
            {
               AV11TFCorTip_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCORNUM") == 0 )
            {
               AV12TFCorNum = (long)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."));
               AV13TFCorNum_To = (long)(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV32DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "CORTIP") == 0 )
            {
               AV33DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV43CorTip1 = AV31GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV35DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV36DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "CORTIP") == 0 )
               {
                  AV37DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV44CorTip2 = AV31GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV39DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV40DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "CORTIP") == 0 )
                  {
                     AV41DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV45CorTip3 = AV31GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCORTIPOPTIONS' Routine */
         returnInSub = false;
         AV10TFCorTip = AV14SearchTxt;
         AV11TFCorTip_Sel = "";
         AV50Configuracion_correlativoswwds_1_dynamicfiltersselector1 = AV32DynamicFiltersSelector1;
         AV51Configuracion_correlativoswwds_2_dynamicfiltersoperator1 = AV33DynamicFiltersOperator1;
         AV52Configuracion_correlativoswwds_3_cortip1 = AV43CorTip1;
         AV53Configuracion_correlativoswwds_4_dynamicfiltersenabled2 = AV35DynamicFiltersEnabled2;
         AV54Configuracion_correlativoswwds_5_dynamicfiltersselector2 = AV36DynamicFiltersSelector2;
         AV55Configuracion_correlativoswwds_6_dynamicfiltersoperator2 = AV37DynamicFiltersOperator2;
         AV56Configuracion_correlativoswwds_7_cortip2 = AV44CorTip2;
         AV57Configuracion_correlativoswwds_8_dynamicfiltersenabled3 = AV39DynamicFiltersEnabled3;
         AV58Configuracion_correlativoswwds_9_dynamicfiltersselector3 = AV40DynamicFiltersSelector3;
         AV59Configuracion_correlativoswwds_10_dynamicfiltersoperator3 = AV41DynamicFiltersOperator3;
         AV60Configuracion_correlativoswwds_11_cortip3 = AV45CorTip3;
         AV61Configuracion_correlativoswwds_12_tfcortip = AV10TFCorTip;
         AV62Configuracion_correlativoswwds_13_tfcortip_sel = AV11TFCorTip_Sel;
         AV63Configuracion_correlativoswwds_14_tfcornum = AV12TFCorNum;
         AV64Configuracion_correlativoswwds_15_tfcornum_to = AV13TFCorNum_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50Configuracion_correlativoswwds_1_dynamicfiltersselector1 ,
                                              AV51Configuracion_correlativoswwds_2_dynamicfiltersoperator1 ,
                                              AV52Configuracion_correlativoswwds_3_cortip1 ,
                                              AV53Configuracion_correlativoswwds_4_dynamicfiltersenabled2 ,
                                              AV54Configuracion_correlativoswwds_5_dynamicfiltersselector2 ,
                                              AV55Configuracion_correlativoswwds_6_dynamicfiltersoperator2 ,
                                              AV56Configuracion_correlativoswwds_7_cortip2 ,
                                              AV57Configuracion_correlativoswwds_8_dynamicfiltersenabled3 ,
                                              AV58Configuracion_correlativoswwds_9_dynamicfiltersselector3 ,
                                              AV59Configuracion_correlativoswwds_10_dynamicfiltersoperator3 ,
                                              AV60Configuracion_correlativoswwds_11_cortip3 ,
                                              AV62Configuracion_correlativoswwds_13_tfcortip_sel ,
                                              AV61Configuracion_correlativoswwds_12_tfcortip ,
                                              AV63Configuracion_correlativoswwds_14_tfcornum ,
                                              AV64Configuracion_correlativoswwds_15_tfcornum_to ,
                                              A138CorTip ,
                                              A758CorNum } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV52Configuracion_correlativoswwds_3_cortip1 = StringUtil.PadR( StringUtil.RTrim( AV52Configuracion_correlativoswwds_3_cortip1), 10, "%");
         lV52Configuracion_correlativoswwds_3_cortip1 = StringUtil.PadR( StringUtil.RTrim( AV52Configuracion_correlativoswwds_3_cortip1), 10, "%");
         lV56Configuracion_correlativoswwds_7_cortip2 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_correlativoswwds_7_cortip2), 10, "%");
         lV56Configuracion_correlativoswwds_7_cortip2 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_correlativoswwds_7_cortip2), 10, "%");
         lV60Configuracion_correlativoswwds_11_cortip3 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_correlativoswwds_11_cortip3), 10, "%");
         lV60Configuracion_correlativoswwds_11_cortip3 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_correlativoswwds_11_cortip3), 10, "%");
         lV61Configuracion_correlativoswwds_12_tfcortip = StringUtil.PadR( StringUtil.RTrim( AV61Configuracion_correlativoswwds_12_tfcortip), 10, "%");
         /* Using cursor P004Y2 */
         pr_default.execute(0, new Object[] {lV52Configuracion_correlativoswwds_3_cortip1, lV52Configuracion_correlativoswwds_3_cortip1, lV56Configuracion_correlativoswwds_7_cortip2, lV56Configuracion_correlativoswwds_7_cortip2, lV60Configuracion_correlativoswwds_11_cortip3, lV60Configuracion_correlativoswwds_11_cortip3, lV61Configuracion_correlativoswwds_12_tfcortip, AV62Configuracion_correlativoswwds_13_tfcortip_sel, AV63Configuracion_correlativoswwds_14_tfcornum, AV64Configuracion_correlativoswwds_15_tfcornum_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A758CorNum = P004Y2_A758CorNum[0];
            A138CorTip = P004Y2_A138CorTip[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A138CorTip)) )
            {
               AV18Option = A138CorTip;
               AV19Options.Add(AV18Option, 0);
            }
            if ( AV19Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
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
         AV20OptionsJson = "";
         AV23OptionsDescJson = "";
         AV25OptionIndexesJson = "";
         AV19Options = new GxSimpleCollection<string>();
         AV22OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27Session = context.GetSession();
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TFCorTip = "";
         AV11TFCorTip_Sel = "";
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV32DynamicFiltersSelector1 = "";
         AV43CorTip1 = "";
         AV36DynamicFiltersSelector2 = "";
         AV44CorTip2 = "";
         AV40DynamicFiltersSelector3 = "";
         AV45CorTip3 = "";
         AV50Configuracion_correlativoswwds_1_dynamicfiltersselector1 = "";
         AV52Configuracion_correlativoswwds_3_cortip1 = "";
         AV54Configuracion_correlativoswwds_5_dynamicfiltersselector2 = "";
         AV56Configuracion_correlativoswwds_7_cortip2 = "";
         AV58Configuracion_correlativoswwds_9_dynamicfiltersselector3 = "";
         AV60Configuracion_correlativoswwds_11_cortip3 = "";
         AV61Configuracion_correlativoswwds_12_tfcortip = "";
         AV62Configuracion_correlativoswwds_13_tfcortip_sel = "";
         scmdbuf = "";
         lV52Configuracion_correlativoswwds_3_cortip1 = "";
         lV56Configuracion_correlativoswwds_7_cortip2 = "";
         lV60Configuracion_correlativoswwds_11_cortip3 = "";
         lV61Configuracion_correlativoswwds_12_tfcortip = "";
         A138CorTip = "";
         P004Y2_A758CorNum = new long[1] ;
         P004Y2_A138CorTip = new string[] {""} ;
         AV18Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.correlativoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004Y2_A758CorNum, P004Y2_A138CorTip
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV33DynamicFiltersOperator1 ;
      private short AV37DynamicFiltersOperator2 ;
      private short AV41DynamicFiltersOperator3 ;
      private short AV51Configuracion_correlativoswwds_2_dynamicfiltersoperator1 ;
      private short AV55Configuracion_correlativoswwds_6_dynamicfiltersoperator2 ;
      private short AV59Configuracion_correlativoswwds_10_dynamicfiltersoperator3 ;
      private int AV48GXV1 ;
      private long AV12TFCorNum ;
      private long AV13TFCorNum_To ;
      private long AV63Configuracion_correlativoswwds_14_tfcornum ;
      private long AV64Configuracion_correlativoswwds_15_tfcornum_to ;
      private long A758CorNum ;
      private string AV10TFCorTip ;
      private string AV11TFCorTip_Sel ;
      private string AV43CorTip1 ;
      private string AV44CorTip2 ;
      private string AV45CorTip3 ;
      private string AV52Configuracion_correlativoswwds_3_cortip1 ;
      private string AV56Configuracion_correlativoswwds_7_cortip2 ;
      private string AV60Configuracion_correlativoswwds_11_cortip3 ;
      private string AV61Configuracion_correlativoswwds_12_tfcortip ;
      private string AV62Configuracion_correlativoswwds_13_tfcortip_sel ;
      private string scmdbuf ;
      private string lV52Configuracion_correlativoswwds_3_cortip1 ;
      private string lV56Configuracion_correlativoswwds_7_cortip2 ;
      private string lV60Configuracion_correlativoswwds_11_cortip3 ;
      private string lV61Configuracion_correlativoswwds_12_tfcortip ;
      private string A138CorTip ;
      private bool returnInSub ;
      private bool AV35DynamicFiltersEnabled2 ;
      private bool AV39DynamicFiltersEnabled3 ;
      private bool AV53Configuracion_correlativoswwds_4_dynamicfiltersenabled2 ;
      private bool AV57Configuracion_correlativoswwds_8_dynamicfiltersenabled3 ;
      private string AV20OptionsJson ;
      private string AV23OptionsDescJson ;
      private string AV25OptionIndexesJson ;
      private string AV16DDOName ;
      private string AV14SearchTxt ;
      private string AV15SearchTxtTo ;
      private string AV32DynamicFiltersSelector1 ;
      private string AV36DynamicFiltersSelector2 ;
      private string AV40DynamicFiltersSelector3 ;
      private string AV50Configuracion_correlativoswwds_1_dynamicfiltersselector1 ;
      private string AV54Configuracion_correlativoswwds_5_dynamicfiltersselector2 ;
      private string AV58Configuracion_correlativoswwds_9_dynamicfiltersselector3 ;
      private string AV18Option ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P004Y2_A758CorNum ;
      private string[] P004Y2_A138CorTip ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV19Options ;
      private GxSimpleCollection<string> AV22OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
   }

   public class correlativoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004Y2( IGxContext context ,
                                             string AV50Configuracion_correlativoswwds_1_dynamicfiltersselector1 ,
                                             short AV51Configuracion_correlativoswwds_2_dynamicfiltersoperator1 ,
                                             string AV52Configuracion_correlativoswwds_3_cortip1 ,
                                             bool AV53Configuracion_correlativoswwds_4_dynamicfiltersenabled2 ,
                                             string AV54Configuracion_correlativoswwds_5_dynamicfiltersselector2 ,
                                             short AV55Configuracion_correlativoswwds_6_dynamicfiltersoperator2 ,
                                             string AV56Configuracion_correlativoswwds_7_cortip2 ,
                                             bool AV57Configuracion_correlativoswwds_8_dynamicfiltersenabled3 ,
                                             string AV58Configuracion_correlativoswwds_9_dynamicfiltersselector3 ,
                                             short AV59Configuracion_correlativoswwds_10_dynamicfiltersoperator3 ,
                                             string AV60Configuracion_correlativoswwds_11_cortip3 ,
                                             string AV62Configuracion_correlativoswwds_13_tfcortip_sel ,
                                             string AV61Configuracion_correlativoswwds_12_tfcortip ,
                                             long AV63Configuracion_correlativoswwds_14_tfcornum ,
                                             long AV64Configuracion_correlativoswwds_15_tfcornum_to ,
                                             string A138CorTip ,
                                             long A758CorNum )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [CorNum], [CorTip] FROM ( SELECT TOP(100) PERCENT [CorNum], [CorTip] FROM [CCORRELATIVOS]";
         if ( ( StringUtil.StrCmp(AV50Configuracion_correlativoswwds_1_dynamicfiltersselector1, "CORTIP") == 0 ) && ( AV51Configuracion_correlativoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracion_correlativoswwds_3_cortip1)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like @lV52Configuracion_correlativoswwds_3_cortip1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Configuracion_correlativoswwds_1_dynamicfiltersselector1, "CORTIP") == 0 ) && ( AV51Configuracion_correlativoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracion_correlativoswwds_3_cortip1)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like '%' + @lV52Configuracion_correlativoswwds_3_cortip1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV53Configuracion_correlativoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Configuracion_correlativoswwds_5_dynamicfiltersselector2, "CORTIP") == 0 ) && ( AV55Configuracion_correlativoswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_correlativoswwds_7_cortip2)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like @lV56Configuracion_correlativoswwds_7_cortip2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV53Configuracion_correlativoswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Configuracion_correlativoswwds_5_dynamicfiltersselector2, "CORTIP") == 0 ) && ( AV55Configuracion_correlativoswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_correlativoswwds_7_cortip2)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like '%' + @lV56Configuracion_correlativoswwds_7_cortip2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV57Configuracion_correlativoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Configuracion_correlativoswwds_9_dynamicfiltersselector3, "CORTIP") == 0 ) && ( AV59Configuracion_correlativoswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_correlativoswwds_11_cortip3)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like @lV60Configuracion_correlativoswwds_11_cortip3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV57Configuracion_correlativoswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Configuracion_correlativoswwds_9_dynamicfiltersselector3, "CORTIP") == 0 ) && ( AV59Configuracion_correlativoswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_correlativoswwds_11_cortip3)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like '%' + @lV60Configuracion_correlativoswwds_11_cortip3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_correlativoswwds_13_tfcortip_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_correlativoswwds_12_tfcortip)) ) )
         {
            AddWhere(sWhereString, "([CorTip] like @lV61Configuracion_correlativoswwds_12_tfcortip)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configuracion_correlativoswwds_13_tfcortip_sel)) )
         {
            AddWhere(sWhereString, "([CorTip] = @AV62Configuracion_correlativoswwds_13_tfcortip_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (0==AV63Configuracion_correlativoswwds_14_tfcornum) )
         {
            AddWhere(sWhereString, "([CorNum] >= @AV63Configuracion_correlativoswwds_14_tfcornum)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV64Configuracion_correlativoswwds_15_tfcornum_to) )
         {
            AddWhere(sWhereString, "([CorNum] <= @AV64Configuracion_correlativoswwds_15_tfcornum_to)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CorTip]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [CorTip]";
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
                     return conditional_P004Y2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] );
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
          Object[] prmP004Y2;
          prmP004Y2 = new Object[] {
          new ParDef("@lV52Configuracion_correlativoswwds_3_cortip1",GXType.NChar,10,0) ,
          new ParDef("@lV52Configuracion_correlativoswwds_3_cortip1",GXType.NChar,10,0) ,
          new ParDef("@lV56Configuracion_correlativoswwds_7_cortip2",GXType.NChar,10,0) ,
          new ParDef("@lV56Configuracion_correlativoswwds_7_cortip2",GXType.NChar,10,0) ,
          new ParDef("@lV60Configuracion_correlativoswwds_11_cortip3",GXType.NChar,10,0) ,
          new ParDef("@lV60Configuracion_correlativoswwds_11_cortip3",GXType.NChar,10,0) ,
          new ParDef("@lV61Configuracion_correlativoswwds_12_tfcortip",GXType.NChar,10,0) ,
          new ParDef("@AV62Configuracion_correlativoswwds_13_tfcortip_sel",GXType.NChar,10,0) ,
          new ParDef("@AV63Configuracion_correlativoswwds_14_tfcornum",GXType.Decimal,10,0) ,
          new ParDef("@AV64Configuracion_correlativoswwds_15_tfcornum_to",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004Y2,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                return;
       }
    }

 }

}
