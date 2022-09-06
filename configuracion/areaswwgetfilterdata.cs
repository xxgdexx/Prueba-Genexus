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
   public class areaswwgetfilterdata : GXProcedure
   {
      public areaswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public areaswwgetfilterdata( IGxContext context )
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
         areaswwgetfilterdata objareaswwgetfilterdata;
         objareaswwgetfilterdata = new areaswwgetfilterdata();
         objareaswwgetfilterdata.AV18DDOName = aP0_DDOName;
         objareaswwgetfilterdata.AV16SearchTxt = aP1_SearchTxt;
         objareaswwgetfilterdata.AV17SearchTxtTo = aP2_SearchTxtTo;
         objareaswwgetfilterdata.AV22OptionsJson = "" ;
         objareaswwgetfilterdata.AV25OptionsDescJson = "" ;
         objareaswwgetfilterdata.AV27OptionIndexesJson = "" ;
         objareaswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objareaswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objareaswwgetfilterdata);
         aP3_OptionsJson=this.AV22OptionsJson;
         aP4_OptionsDescJson=this.AV25OptionsDescJson;
         aP5_OptionIndexesJson=this.AV27OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((areaswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV18DDOName), "DDO_AREDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADAREDSCOPTIONS' */
            S121 ();
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
         if ( StringUtil.StrCmp(AV29Session.Get("Configuracion.AreasWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.AreasWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("Configuracion.AreasWWGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFARECOD") == 0 )
            {
               AV10TFAreCod = (int)(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."));
               AV11TFAreCod_To = (int)(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFAREDSC") == 0 )
            {
               AV12TFAreDsc = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFAREDSC_SEL") == 0 )
            {
               AV13TFAreDsc_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFARESTS_SEL") == 0 )
            {
               AV45TFAreSts_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV46TFAreSts_Sels.FromJSonString(AV45TFAreSts_SelsJson, null);
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV34DynamicFiltersSelector1 = AV33GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV34DynamicFiltersSelector1, "AREDSC") == 0 )
            {
               AV35DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV36AreDsc1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV37DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV38DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV38DynamicFiltersSelector2, "AREDSC") == 0 )
               {
                  AV39DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV40AreDsc2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV41DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV42DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "AREDSC") == 0 )
                  {
                     AV43DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV44AreDsc3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADAREDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFAreDsc = AV16SearchTxt;
         AV13TFAreDsc_Sel = "";
         AV51Configuracion_areaswwds_1_dynamicfiltersselector1 = AV34DynamicFiltersSelector1;
         AV52Configuracion_areaswwds_2_dynamicfiltersoperator1 = AV35DynamicFiltersOperator1;
         AV53Configuracion_areaswwds_3_aredsc1 = AV36AreDsc1;
         AV54Configuracion_areaswwds_4_dynamicfiltersenabled2 = AV37DynamicFiltersEnabled2;
         AV55Configuracion_areaswwds_5_dynamicfiltersselector2 = AV38DynamicFiltersSelector2;
         AV56Configuracion_areaswwds_6_dynamicfiltersoperator2 = AV39DynamicFiltersOperator2;
         AV57Configuracion_areaswwds_7_aredsc2 = AV40AreDsc2;
         AV58Configuracion_areaswwds_8_dynamicfiltersenabled3 = AV41DynamicFiltersEnabled3;
         AV59Configuracion_areaswwds_9_dynamicfiltersselector3 = AV42DynamicFiltersSelector3;
         AV60Configuracion_areaswwds_10_dynamicfiltersoperator3 = AV43DynamicFiltersOperator3;
         AV61Configuracion_areaswwds_11_aredsc3 = AV44AreDsc3;
         AV62Configuracion_areaswwds_12_tfarecod = AV10TFAreCod;
         AV63Configuracion_areaswwds_13_tfarecod_to = AV11TFAreCod_To;
         AV64Configuracion_areaswwds_14_tfaredsc = AV12TFAreDsc;
         AV65Configuracion_areaswwds_15_tfaredsc_sel = AV13TFAreDsc_Sel;
         AV66Configuracion_areaswwds_16_tfarests_sels = AV46TFAreSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A475AreSts ,
                                              AV66Configuracion_areaswwds_16_tfarests_sels ,
                                              AV51Configuracion_areaswwds_1_dynamicfiltersselector1 ,
                                              AV52Configuracion_areaswwds_2_dynamicfiltersoperator1 ,
                                              AV53Configuracion_areaswwds_3_aredsc1 ,
                                              AV54Configuracion_areaswwds_4_dynamicfiltersenabled2 ,
                                              AV55Configuracion_areaswwds_5_dynamicfiltersselector2 ,
                                              AV56Configuracion_areaswwds_6_dynamicfiltersoperator2 ,
                                              AV57Configuracion_areaswwds_7_aredsc2 ,
                                              AV58Configuracion_areaswwds_8_dynamicfiltersenabled3 ,
                                              AV59Configuracion_areaswwds_9_dynamicfiltersselector3 ,
                                              AV60Configuracion_areaswwds_10_dynamicfiltersoperator3 ,
                                              AV61Configuracion_areaswwds_11_aredsc3 ,
                                              AV62Configuracion_areaswwds_12_tfarecod ,
                                              AV63Configuracion_areaswwds_13_tfarecod_to ,
                                              AV65Configuracion_areaswwds_15_tfaredsc_sel ,
                                              AV64Configuracion_areaswwds_14_tfaredsc ,
                                              AV66Configuracion_areaswwds_16_tfarests_sels.Count ,
                                              A474AreDsc ,
                                              A69AreCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV53Configuracion_areaswwds_3_aredsc1 = StringUtil.Concat( StringUtil.RTrim( AV53Configuracion_areaswwds_3_aredsc1), "%", "");
         lV53Configuracion_areaswwds_3_aredsc1 = StringUtil.Concat( StringUtil.RTrim( AV53Configuracion_areaswwds_3_aredsc1), "%", "");
         lV57Configuracion_areaswwds_7_aredsc2 = StringUtil.Concat( StringUtil.RTrim( AV57Configuracion_areaswwds_7_aredsc2), "%", "");
         lV57Configuracion_areaswwds_7_aredsc2 = StringUtil.Concat( StringUtil.RTrim( AV57Configuracion_areaswwds_7_aredsc2), "%", "");
         lV61Configuracion_areaswwds_11_aredsc3 = StringUtil.Concat( StringUtil.RTrim( AV61Configuracion_areaswwds_11_aredsc3), "%", "");
         lV61Configuracion_areaswwds_11_aredsc3 = StringUtil.Concat( StringUtil.RTrim( AV61Configuracion_areaswwds_11_aredsc3), "%", "");
         lV64Configuracion_areaswwds_14_tfaredsc = StringUtil.Concat( StringUtil.RTrim( AV64Configuracion_areaswwds_14_tfaredsc), "%", "");
         /* Using cursor P004U2 */
         pr_default.execute(0, new Object[] {lV53Configuracion_areaswwds_3_aredsc1, lV53Configuracion_areaswwds_3_aredsc1, lV57Configuracion_areaswwds_7_aredsc2, lV57Configuracion_areaswwds_7_aredsc2, lV61Configuracion_areaswwds_11_aredsc3, lV61Configuracion_areaswwds_11_aredsc3, AV62Configuracion_areaswwds_12_tfarecod, AV63Configuracion_areaswwds_13_tfarecod_to, lV64Configuracion_areaswwds_14_tfaredsc, AV65Configuracion_areaswwds_15_tfaredsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4U2 = false;
            A474AreDsc = P004U2_A474AreDsc[0];
            A475AreSts = P004U2_A475AreSts[0];
            A69AreCod = P004U2_A69AreCod[0];
            AV28count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P004U2_A474AreDsc[0], A474AreDsc) == 0 ) )
            {
               BRK4U2 = false;
               A69AreCod = P004U2_A69AreCod[0];
               AV28count = (long)(AV28count+1);
               BRK4U2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A474AreDsc)) )
            {
               AV20Option = A474AreDsc;
               AV21Options.Add(AV20Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV21Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK4U2 )
            {
               BRK4U2 = true;
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
         AV12TFAreDsc = "";
         AV13TFAreDsc_Sel = "";
         AV45TFAreSts_SelsJson = "";
         AV46TFAreSts_Sels = new GxSimpleCollection<short>();
         AV33GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV34DynamicFiltersSelector1 = "";
         AV36AreDsc1 = "";
         AV38DynamicFiltersSelector2 = "";
         AV40AreDsc2 = "";
         AV42DynamicFiltersSelector3 = "";
         AV44AreDsc3 = "";
         AV51Configuracion_areaswwds_1_dynamicfiltersselector1 = "";
         AV53Configuracion_areaswwds_3_aredsc1 = "";
         AV55Configuracion_areaswwds_5_dynamicfiltersselector2 = "";
         AV57Configuracion_areaswwds_7_aredsc2 = "";
         AV59Configuracion_areaswwds_9_dynamicfiltersselector3 = "";
         AV61Configuracion_areaswwds_11_aredsc3 = "";
         AV64Configuracion_areaswwds_14_tfaredsc = "";
         AV65Configuracion_areaswwds_15_tfaredsc_sel = "";
         AV66Configuracion_areaswwds_16_tfarests_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV53Configuracion_areaswwds_3_aredsc1 = "";
         lV57Configuracion_areaswwds_7_aredsc2 = "";
         lV61Configuracion_areaswwds_11_aredsc3 = "";
         lV64Configuracion_areaswwds_14_tfaredsc = "";
         A474AreDsc = "";
         P004U2_A474AreDsc = new string[] {""} ;
         P004U2_A475AreSts = new short[1] ;
         P004U2_A69AreCod = new int[1] ;
         AV20Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.areaswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004U2_A474AreDsc, P004U2_A475AreSts, P004U2_A69AreCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV35DynamicFiltersOperator1 ;
      private short AV39DynamicFiltersOperator2 ;
      private short AV43DynamicFiltersOperator3 ;
      private short AV52Configuracion_areaswwds_2_dynamicfiltersoperator1 ;
      private short AV56Configuracion_areaswwds_6_dynamicfiltersoperator2 ;
      private short AV60Configuracion_areaswwds_10_dynamicfiltersoperator3 ;
      private short A475AreSts ;
      private int AV49GXV1 ;
      private int AV10TFAreCod ;
      private int AV11TFAreCod_To ;
      private int AV62Configuracion_areaswwds_12_tfarecod ;
      private int AV63Configuracion_areaswwds_13_tfarecod_to ;
      private int AV66Configuracion_areaswwds_16_tfarests_sels_Count ;
      private int A69AreCod ;
      private long AV28count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV37DynamicFiltersEnabled2 ;
      private bool AV41DynamicFiltersEnabled3 ;
      private bool AV54Configuracion_areaswwds_4_dynamicfiltersenabled2 ;
      private bool AV58Configuracion_areaswwds_8_dynamicfiltersenabled3 ;
      private bool BRK4U2 ;
      private string AV22OptionsJson ;
      private string AV25OptionsDescJson ;
      private string AV27OptionIndexesJson ;
      private string AV45TFAreSts_SelsJson ;
      private string AV18DDOName ;
      private string AV16SearchTxt ;
      private string AV17SearchTxtTo ;
      private string AV12TFAreDsc ;
      private string AV13TFAreDsc_Sel ;
      private string AV34DynamicFiltersSelector1 ;
      private string AV36AreDsc1 ;
      private string AV38DynamicFiltersSelector2 ;
      private string AV40AreDsc2 ;
      private string AV42DynamicFiltersSelector3 ;
      private string AV44AreDsc3 ;
      private string AV51Configuracion_areaswwds_1_dynamicfiltersselector1 ;
      private string AV53Configuracion_areaswwds_3_aredsc1 ;
      private string AV55Configuracion_areaswwds_5_dynamicfiltersselector2 ;
      private string AV57Configuracion_areaswwds_7_aredsc2 ;
      private string AV59Configuracion_areaswwds_9_dynamicfiltersselector3 ;
      private string AV61Configuracion_areaswwds_11_aredsc3 ;
      private string AV64Configuracion_areaswwds_14_tfaredsc ;
      private string AV65Configuracion_areaswwds_15_tfaredsc_sel ;
      private string lV53Configuracion_areaswwds_3_aredsc1 ;
      private string lV57Configuracion_areaswwds_7_aredsc2 ;
      private string lV61Configuracion_areaswwds_11_aredsc3 ;
      private string lV64Configuracion_areaswwds_14_tfaredsc ;
      private string A474AreDsc ;
      private string AV20Option ;
      private GxSimpleCollection<short> AV46TFAreSts_Sels ;
      private GxSimpleCollection<short> AV66Configuracion_areaswwds_16_tfarests_sels ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004U2_A474AreDsc ;
      private short[] P004U2_A475AreSts ;
      private int[] P004U2_A69AreCod ;
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

   public class areaswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004U2( IGxContext context ,
                                             short A475AreSts ,
                                             GxSimpleCollection<short> AV66Configuracion_areaswwds_16_tfarests_sels ,
                                             string AV51Configuracion_areaswwds_1_dynamicfiltersselector1 ,
                                             short AV52Configuracion_areaswwds_2_dynamicfiltersoperator1 ,
                                             string AV53Configuracion_areaswwds_3_aredsc1 ,
                                             bool AV54Configuracion_areaswwds_4_dynamicfiltersenabled2 ,
                                             string AV55Configuracion_areaswwds_5_dynamicfiltersselector2 ,
                                             short AV56Configuracion_areaswwds_6_dynamicfiltersoperator2 ,
                                             string AV57Configuracion_areaswwds_7_aredsc2 ,
                                             bool AV58Configuracion_areaswwds_8_dynamicfiltersenabled3 ,
                                             string AV59Configuracion_areaswwds_9_dynamicfiltersselector3 ,
                                             short AV60Configuracion_areaswwds_10_dynamicfiltersoperator3 ,
                                             string AV61Configuracion_areaswwds_11_aredsc3 ,
                                             int AV62Configuracion_areaswwds_12_tfarecod ,
                                             int AV63Configuracion_areaswwds_13_tfarecod_to ,
                                             string AV65Configuracion_areaswwds_15_tfaredsc_sel ,
                                             string AV64Configuracion_areaswwds_14_tfaredsc ,
                                             int AV66Configuracion_areaswwds_16_tfarests_sels_Count ,
                                             string A474AreDsc ,
                                             int A69AreCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [AreDsc], [AreSts], [AreCod] FROM [CAREAS]";
         if ( ( StringUtil.StrCmp(AV51Configuracion_areaswwds_1_dynamicfiltersselector1, "AREDSC") == 0 ) && ( AV52Configuracion_areaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_areaswwds_3_aredsc1)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like @lV53Configuracion_areaswwds_3_aredsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Configuracion_areaswwds_1_dynamicfiltersselector1, "AREDSC") == 0 ) && ( AV52Configuracion_areaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_areaswwds_3_aredsc1)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like '%' + @lV53Configuracion_areaswwds_3_aredsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV54Configuracion_areaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_areaswwds_5_dynamicfiltersselector2, "AREDSC") == 0 ) && ( AV56Configuracion_areaswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_areaswwds_7_aredsc2)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like @lV57Configuracion_areaswwds_7_aredsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV54Configuracion_areaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Configuracion_areaswwds_5_dynamicfiltersselector2, "AREDSC") == 0 ) && ( AV56Configuracion_areaswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Configuracion_areaswwds_7_aredsc2)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like '%' + @lV57Configuracion_areaswwds_7_aredsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV58Configuracion_areaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_areaswwds_9_dynamicfiltersselector3, "AREDSC") == 0 ) && ( AV60Configuracion_areaswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_areaswwds_11_aredsc3)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like @lV61Configuracion_areaswwds_11_aredsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV58Configuracion_areaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Configuracion_areaswwds_9_dynamicfiltersselector3, "AREDSC") == 0 ) && ( AV60Configuracion_areaswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_areaswwds_11_aredsc3)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like '%' + @lV61Configuracion_areaswwds_11_aredsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV62Configuracion_areaswwds_12_tfarecod) )
         {
            AddWhere(sWhereString, "([AreCod] >= @AV62Configuracion_areaswwds_12_tfarecod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV63Configuracion_areaswwds_13_tfarecod_to) )
         {
            AddWhere(sWhereString, "([AreCod] <= @AV63Configuracion_areaswwds_13_tfarecod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_areaswwds_15_tfaredsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_areaswwds_14_tfaredsc)) ) )
         {
            AddWhere(sWhereString, "([AreDsc] like @lV64Configuracion_areaswwds_14_tfaredsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_areaswwds_15_tfaredsc_sel)) )
         {
            AddWhere(sWhereString, "([AreDsc] = @AV65Configuracion_areaswwds_15_tfaredsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV66Configuracion_areaswwds_16_tfarests_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV66Configuracion_areaswwds_16_tfarests_sels, "[AreSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [AreDsc]";
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
                     return conditional_P004U2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] );
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
          Object[] prmP004U2;
          prmP004U2 = new Object[] {
          new ParDef("@lV53Configuracion_areaswwds_3_aredsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV53Configuracion_areaswwds_3_aredsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV57Configuracion_areaswwds_7_aredsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV57Configuracion_areaswwds_7_aredsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV61Configuracion_areaswwds_11_aredsc3",GXType.NVarChar,100,0) ,
          new ParDef("@lV61Configuracion_areaswwds_11_aredsc3",GXType.NVarChar,100,0) ,
          new ParDef("@AV62Configuracion_areaswwds_12_tfarecod",GXType.Int32,6,0) ,
          new ParDef("@AV63Configuracion_areaswwds_13_tfarecod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Configuracion_areaswwds_14_tfaredsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV65Configuracion_areaswwds_15_tfaredsc_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004U2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004U2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
