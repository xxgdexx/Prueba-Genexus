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
namespace GeneXus.Programs.contabilidad {
   public class tipoauxiliarwwgetfilterdata : GXProcedure
   {
      public tipoauxiliarwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipoauxiliarwwgetfilterdata( IGxContext context )
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
         tipoauxiliarwwgetfilterdata objtipoauxiliarwwgetfilterdata;
         objtipoauxiliarwwgetfilterdata = new tipoauxiliarwwgetfilterdata();
         objtipoauxiliarwwgetfilterdata.AV18DDOName = aP0_DDOName;
         objtipoauxiliarwwgetfilterdata.AV16SearchTxt = aP1_SearchTxt;
         objtipoauxiliarwwgetfilterdata.AV17SearchTxtTo = aP2_SearchTxtTo;
         objtipoauxiliarwwgetfilterdata.AV22OptionsJson = "" ;
         objtipoauxiliarwwgetfilterdata.AV25OptionsDescJson = "" ;
         objtipoauxiliarwwgetfilterdata.AV27OptionIndexesJson = "" ;
         objtipoauxiliarwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objtipoauxiliarwwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipoauxiliarwwgetfilterdata);
         aP3_OptionsJson=this.AV22OptionsJson;
         aP4_OptionsDescJson=this.AV25OptionsDescJson;
         aP5_OptionIndexesJson=this.AV27OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipoauxiliarwwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV18DDOName), "DDO_TIPADSC") == 0 )
         {
            /* Execute user subroutine: 'LOADTIPADSCOPTIONS' */
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
         if ( StringUtil.StrCmp(AV29Session.Get("Contabilidad.TipoAuxiliarWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.TipoAuxiliarWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("Contabilidad.TipoAuxiliarWWGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFTIPACOD") == 0 )
            {
               AV10TFTipACod = (int)(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."));
               AV11TFTipACod_To = (int)(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFTIPADSC") == 0 )
            {
               AV12TFTipADsc = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFTIPADSC_SEL") == 0 )
            {
               AV13TFTipADsc_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFTIPASTS_SEL") == 0 )
            {
               AV14TFTipASts_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV15TFTipASts_Sels.FromJSonString(AV14TFTipASts_SelsJson, null);
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV34DynamicFiltersSelector1 = AV33GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV34DynamicFiltersSelector1, "TIPADSC") == 0 )
            {
               AV35DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV36TipADsc1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV37DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV38DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV38DynamicFiltersSelector2, "TIPADSC") == 0 )
               {
                  AV39DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV40TipADsc2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV41DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV42DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "TIPADSC") == 0 )
                  {
                     AV43DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV44TipADsc3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTIPADSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFTipADsc = AV16SearchTxt;
         AV13TFTipADsc_Sel = "";
         AV51Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1 = AV34DynamicFiltersSelector1;
         AV52Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 = AV35DynamicFiltersOperator1;
         AV53Contabilidad_tipoauxiliarwwds_3_tipadsc1 = AV36TipADsc1;
         AV54Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 = AV37DynamicFiltersEnabled2;
         AV55Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2 = AV38DynamicFiltersSelector2;
         AV56Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 = AV39DynamicFiltersOperator2;
         AV57Contabilidad_tipoauxiliarwwds_7_tipadsc2 = AV40TipADsc2;
         AV58Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 = AV41DynamicFiltersEnabled3;
         AV59Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3 = AV42DynamicFiltersSelector3;
         AV60Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 = AV43DynamicFiltersOperator3;
         AV61Contabilidad_tipoauxiliarwwds_11_tipadsc3 = AV44TipADsc3;
         AV62Contabilidad_tipoauxiliarwwds_12_tftipacod = AV10TFTipACod;
         AV63Contabilidad_tipoauxiliarwwds_13_tftipacod_to = AV11TFTipACod_To;
         AV64Contabilidad_tipoauxiliarwwds_14_tftipadsc = AV12TFTipADsc;
         AV65Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel = AV13TFTipADsc_Sel;
         AV66Contabilidad_tipoauxiliarwwds_16_tftipasts_sels = AV15TFTipASts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1902TipASts ,
                                              AV66Contabilidad_tipoauxiliarwwds_16_tftipasts_sels ,
                                              AV51Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1 ,
                                              AV52Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 ,
                                              AV53Contabilidad_tipoauxiliarwwds_3_tipadsc1 ,
                                              AV54Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 ,
                                              AV55Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2 ,
                                              AV56Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 ,
                                              AV57Contabilidad_tipoauxiliarwwds_7_tipadsc2 ,
                                              AV58Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 ,
                                              AV59Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3 ,
                                              AV60Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 ,
                                              AV61Contabilidad_tipoauxiliarwwds_11_tipadsc3 ,
                                              AV62Contabilidad_tipoauxiliarwwds_12_tftipacod ,
                                              AV63Contabilidad_tipoauxiliarwwds_13_tftipacod_to ,
                                              AV65Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel ,
                                              AV64Contabilidad_tipoauxiliarwwds_14_tftipadsc ,
                                              AV66Contabilidad_tipoauxiliarwwds_16_tftipasts_sels.Count ,
                                              A1900TipADsc ,
                                              A70TipACod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV53Contabilidad_tipoauxiliarwwds_3_tipadsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Contabilidad_tipoauxiliarwwds_3_tipadsc1), 100, "%");
         lV53Contabilidad_tipoauxiliarwwds_3_tipadsc1 = StringUtil.PadR( StringUtil.RTrim( AV53Contabilidad_tipoauxiliarwwds_3_tipadsc1), 100, "%");
         lV57Contabilidad_tipoauxiliarwwds_7_tipadsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Contabilidad_tipoauxiliarwwds_7_tipadsc2), 100, "%");
         lV57Contabilidad_tipoauxiliarwwds_7_tipadsc2 = StringUtil.PadR( StringUtil.RTrim( AV57Contabilidad_tipoauxiliarwwds_7_tipadsc2), 100, "%");
         lV61Contabilidad_tipoauxiliarwwds_11_tipadsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Contabilidad_tipoauxiliarwwds_11_tipadsc3), 100, "%");
         lV61Contabilidad_tipoauxiliarwwds_11_tipadsc3 = StringUtil.PadR( StringUtil.RTrim( AV61Contabilidad_tipoauxiliarwwds_11_tipadsc3), 100, "%");
         lV64Contabilidad_tipoauxiliarwwds_14_tftipadsc = StringUtil.PadR( StringUtil.RTrim( AV64Contabilidad_tipoauxiliarwwds_14_tftipadsc), 100, "%");
         /* Using cursor P006K2 */
         pr_default.execute(0, new Object[] {lV53Contabilidad_tipoauxiliarwwds_3_tipadsc1, lV53Contabilidad_tipoauxiliarwwds_3_tipadsc1, lV57Contabilidad_tipoauxiliarwwds_7_tipadsc2, lV57Contabilidad_tipoauxiliarwwds_7_tipadsc2, lV61Contabilidad_tipoauxiliarwwds_11_tipadsc3, lV61Contabilidad_tipoauxiliarwwds_11_tipadsc3, AV62Contabilidad_tipoauxiliarwwds_12_tftipacod, AV63Contabilidad_tipoauxiliarwwds_13_tftipacod_to, lV64Contabilidad_tipoauxiliarwwds_14_tftipadsc, AV65Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6K2 = false;
            A1900TipADsc = P006K2_A1900TipADsc[0];
            A1902TipASts = P006K2_A1902TipASts[0];
            A70TipACod = P006K2_A70TipACod[0];
            AV28count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006K2_A1900TipADsc[0], A1900TipADsc) == 0 ) )
            {
               BRK6K2 = false;
               A70TipACod = P006K2_A70TipACod[0];
               AV28count = (long)(AV28count+1);
               BRK6K2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1900TipADsc)) )
            {
               AV20Option = A1900TipADsc;
               AV21Options.Add(AV20Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV21Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK6K2 )
            {
               BRK6K2 = true;
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
         AV12TFTipADsc = "";
         AV13TFTipADsc_Sel = "";
         AV14TFTipASts_SelsJson = "";
         AV15TFTipASts_Sels = new GxSimpleCollection<short>();
         AV33GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV34DynamicFiltersSelector1 = "";
         AV36TipADsc1 = "";
         AV38DynamicFiltersSelector2 = "";
         AV40TipADsc2 = "";
         AV42DynamicFiltersSelector3 = "";
         AV44TipADsc3 = "";
         AV51Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1 = "";
         AV53Contabilidad_tipoauxiliarwwds_3_tipadsc1 = "";
         AV55Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2 = "";
         AV57Contabilidad_tipoauxiliarwwds_7_tipadsc2 = "";
         AV59Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3 = "";
         AV61Contabilidad_tipoauxiliarwwds_11_tipadsc3 = "";
         AV64Contabilidad_tipoauxiliarwwds_14_tftipadsc = "";
         AV65Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel = "";
         AV66Contabilidad_tipoauxiliarwwds_16_tftipasts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV53Contabilidad_tipoauxiliarwwds_3_tipadsc1 = "";
         lV57Contabilidad_tipoauxiliarwwds_7_tipadsc2 = "";
         lV61Contabilidad_tipoauxiliarwwds_11_tipadsc3 = "";
         lV64Contabilidad_tipoauxiliarwwds_14_tftipadsc = "";
         A1900TipADsc = "";
         P006K2_A1900TipADsc = new string[] {""} ;
         P006K2_A1902TipASts = new short[1] ;
         P006K2_A70TipACod = new int[1] ;
         AV20Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.tipoauxiliarwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006K2_A1900TipADsc, P006K2_A1902TipASts, P006K2_A70TipACod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV35DynamicFiltersOperator1 ;
      private short AV39DynamicFiltersOperator2 ;
      private short AV43DynamicFiltersOperator3 ;
      private short AV52Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 ;
      private short AV56Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 ;
      private short AV60Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 ;
      private short A1902TipASts ;
      private int AV49GXV1 ;
      private int AV10TFTipACod ;
      private int AV11TFTipACod_To ;
      private int AV62Contabilidad_tipoauxiliarwwds_12_tftipacod ;
      private int AV63Contabilidad_tipoauxiliarwwds_13_tftipacod_to ;
      private int AV66Contabilidad_tipoauxiliarwwds_16_tftipasts_sels_Count ;
      private int A70TipACod ;
      private long AV28count ;
      private string AV12TFTipADsc ;
      private string AV13TFTipADsc_Sel ;
      private string AV36TipADsc1 ;
      private string AV40TipADsc2 ;
      private string AV44TipADsc3 ;
      private string AV53Contabilidad_tipoauxiliarwwds_3_tipadsc1 ;
      private string AV57Contabilidad_tipoauxiliarwwds_7_tipadsc2 ;
      private string AV61Contabilidad_tipoauxiliarwwds_11_tipadsc3 ;
      private string AV64Contabilidad_tipoauxiliarwwds_14_tftipadsc ;
      private string AV65Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel ;
      private string scmdbuf ;
      private string lV53Contabilidad_tipoauxiliarwwds_3_tipadsc1 ;
      private string lV57Contabilidad_tipoauxiliarwwds_7_tipadsc2 ;
      private string lV61Contabilidad_tipoauxiliarwwds_11_tipadsc3 ;
      private string lV64Contabilidad_tipoauxiliarwwds_14_tftipadsc ;
      private string A1900TipADsc ;
      private bool returnInSub ;
      private bool AV37DynamicFiltersEnabled2 ;
      private bool AV41DynamicFiltersEnabled3 ;
      private bool AV54Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 ;
      private bool AV58Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 ;
      private bool BRK6K2 ;
      private string AV22OptionsJson ;
      private string AV25OptionsDescJson ;
      private string AV27OptionIndexesJson ;
      private string AV14TFTipASts_SelsJson ;
      private string AV18DDOName ;
      private string AV16SearchTxt ;
      private string AV17SearchTxtTo ;
      private string AV34DynamicFiltersSelector1 ;
      private string AV38DynamicFiltersSelector2 ;
      private string AV42DynamicFiltersSelector3 ;
      private string AV51Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1 ;
      private string AV55Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2 ;
      private string AV59Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3 ;
      private string AV20Option ;
      private GxSimpleCollection<short> AV15TFTipASts_Sels ;
      private GxSimpleCollection<short> AV66Contabilidad_tipoauxiliarwwds_16_tftipasts_sels ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006K2_A1900TipADsc ;
      private short[] P006K2_A1902TipASts ;
      private int[] P006K2_A70TipACod ;
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

   public class tipoauxiliarwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006K2( IGxContext context ,
                                             short A1902TipASts ,
                                             GxSimpleCollection<short> AV66Contabilidad_tipoauxiliarwwds_16_tftipasts_sels ,
                                             string AV51Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1 ,
                                             short AV52Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 ,
                                             string AV53Contabilidad_tipoauxiliarwwds_3_tipadsc1 ,
                                             bool AV54Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 ,
                                             string AV55Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2 ,
                                             short AV56Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 ,
                                             string AV57Contabilidad_tipoauxiliarwwds_7_tipadsc2 ,
                                             bool AV58Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 ,
                                             string AV59Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3 ,
                                             short AV60Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 ,
                                             string AV61Contabilidad_tipoauxiliarwwds_11_tipadsc3 ,
                                             int AV62Contabilidad_tipoauxiliarwwds_12_tftipacod ,
                                             int AV63Contabilidad_tipoauxiliarwwds_13_tftipacod_to ,
                                             string AV65Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel ,
                                             string AV64Contabilidad_tipoauxiliarwwds_14_tftipadsc ,
                                             int AV66Contabilidad_tipoauxiliarwwds_16_tftipasts_sels_Count ,
                                             string A1900TipADsc ,
                                             int A70TipACod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TipADsc], [TipASts], [TipACod] FROM [CBTIPAUXILIAR]";
         if ( ( StringUtil.StrCmp(AV51Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1, "TIPADSC") == 0 ) && ( AV52Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Contabilidad_tipoauxiliarwwds_3_tipadsc1)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like @lV53Contabilidad_tipoauxiliarwwds_3_tipadsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Contabilidad_tipoauxiliarwwds_1_dynamicfiltersselector1, "TIPADSC") == 0 ) && ( AV52Contabilidad_tipoauxiliarwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Contabilidad_tipoauxiliarwwds_3_tipadsc1)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like '%' + @lV53Contabilidad_tipoauxiliarwwds_3_tipadsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV54Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2, "TIPADSC") == 0 ) && ( AV56Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Contabilidad_tipoauxiliarwwds_7_tipadsc2)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like @lV57Contabilidad_tipoauxiliarwwds_7_tipadsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV54Contabilidad_tipoauxiliarwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Contabilidad_tipoauxiliarwwds_5_dynamicfiltersselector2, "TIPADSC") == 0 ) && ( AV56Contabilidad_tipoauxiliarwwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Contabilidad_tipoauxiliarwwds_7_tipadsc2)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like '%' + @lV57Contabilidad_tipoauxiliarwwds_7_tipadsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV58Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3, "TIPADSC") == 0 ) && ( AV60Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Contabilidad_tipoauxiliarwwds_11_tipadsc3)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like @lV61Contabilidad_tipoauxiliarwwds_11_tipadsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV58Contabilidad_tipoauxiliarwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Contabilidad_tipoauxiliarwwds_9_dynamicfiltersselector3, "TIPADSC") == 0 ) && ( AV60Contabilidad_tipoauxiliarwwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Contabilidad_tipoauxiliarwwds_11_tipadsc3)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like '%' + @lV61Contabilidad_tipoauxiliarwwds_11_tipadsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV62Contabilidad_tipoauxiliarwwds_12_tftipacod) )
         {
            AddWhere(sWhereString, "([TipACod] >= @AV62Contabilidad_tipoauxiliarwwds_12_tftipacod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV63Contabilidad_tipoauxiliarwwds_13_tftipacod_to) )
         {
            AddWhere(sWhereString, "([TipACod] <= @AV63Contabilidad_tipoauxiliarwwds_13_tftipacod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Contabilidad_tipoauxiliarwwds_14_tftipadsc)) ) )
         {
            AddWhere(sWhereString, "([TipADsc] like @lV64Contabilidad_tipoauxiliarwwds_14_tftipadsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel)) )
         {
            AddWhere(sWhereString, "([TipADsc] = @AV65Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV66Contabilidad_tipoauxiliarwwds_16_tftipasts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV66Contabilidad_tipoauxiliarwwds_16_tftipasts_sels, "[TipASts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TipADsc]";
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
                     return conditional_P006K2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] );
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
          Object[] prmP006K2;
          prmP006K2 = new Object[] {
          new ParDef("@lV53Contabilidad_tipoauxiliarwwds_3_tipadsc1",GXType.NChar,100,0) ,
          new ParDef("@lV53Contabilidad_tipoauxiliarwwds_3_tipadsc1",GXType.NChar,100,0) ,
          new ParDef("@lV57Contabilidad_tipoauxiliarwwds_7_tipadsc2",GXType.NChar,100,0) ,
          new ParDef("@lV57Contabilidad_tipoauxiliarwwds_7_tipadsc2",GXType.NChar,100,0) ,
          new ParDef("@lV61Contabilidad_tipoauxiliarwwds_11_tipadsc3",GXType.NChar,100,0) ,
          new ParDef("@lV61Contabilidad_tipoauxiliarwwds_11_tipadsc3",GXType.NChar,100,0) ,
          new ParDef("@AV62Contabilidad_tipoauxiliarwwds_12_tftipacod",GXType.Int32,6,0) ,
          new ParDef("@AV63Contabilidad_tipoauxiliarwwds_13_tftipacod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Contabilidad_tipoauxiliarwwds_14_tftipadsc",GXType.NChar,100,0) ,
          new ParDef("@AV65Contabilidad_tipoauxiliarwwds_15_tftipadsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006K2,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
