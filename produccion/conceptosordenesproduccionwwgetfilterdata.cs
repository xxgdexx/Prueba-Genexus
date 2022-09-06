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
   public class conceptosordenesproduccionwwgetfilterdata : GXProcedure
   {
      public conceptosordenesproduccionwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptosordenesproduccionwwgetfilterdata( IGxContext context )
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
         conceptosordenesproduccionwwgetfilterdata objconceptosordenesproduccionwwgetfilterdata;
         objconceptosordenesproduccionwwgetfilterdata = new conceptosordenesproduccionwwgetfilterdata();
         objconceptosordenesproduccionwwgetfilterdata.AV20DDOName = aP0_DDOName;
         objconceptosordenesproduccionwwgetfilterdata.AV18SearchTxt = aP1_SearchTxt;
         objconceptosordenesproduccionwwgetfilterdata.AV19SearchTxtTo = aP2_SearchTxtTo;
         objconceptosordenesproduccionwwgetfilterdata.AV24OptionsJson = "" ;
         objconceptosordenesproduccionwwgetfilterdata.AV27OptionsDescJson = "" ;
         objconceptosordenesproduccionwwgetfilterdata.AV29OptionIndexesJson = "" ;
         objconceptosordenesproduccionwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objconceptosordenesproduccionwwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptosordenesproduccionwwgetfilterdata);
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptosordenesproduccionwwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_POCONCDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADPOCONCDSCOPTIONS' */
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
         if ( StringUtil.StrCmp(AV31Session.Get("Produccion.ConceptosOrdenesProduccionWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Produccion.ConceptosOrdenesProduccionWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Produccion.ConceptosOrdenesProduccionWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPOCONCCOD") == 0 )
            {
               AV10TFPoConcCod = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV11TFPoConcCod_To = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPOCONCDSC") == 0 )
            {
               AV12TFPoConcDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPOCONCDSC_SEL") == 0 )
            {
               AV13TFPoConcDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPOCONCTIP_SEL") == 0 )
            {
               AV47TFPoConcTip_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV48TFPoConcTip_Sels.FromJSonString(AV47TFPoConcTip_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPOCONCSTS_SEL") == 0 )
            {
               AV16TFPoConcSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV17TFPoConcSts_Sels.FromJSonString(AV16TFPoConcSts_SelsJson, null);
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "POCONCDSC") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV38PoConcDsc1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "POCONCDSC") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV42PoConcDsc2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "POCONCDSC") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV46PoConcDsc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPOCONCDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFPoConcDsc = AV18SearchTxt;
         AV13TFPoConcDsc_Sel = "";
         AV53Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV54Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = AV38PoConcDsc1;
         AV56Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV57Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV58Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = AV42PoConcDsc2;
         AV60Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV61Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV62Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = AV46PoConcDsc3;
         AV64Produccion_conceptosordenesproduccionwwds_12_tfpoconccod = AV10TFPoConcCod;
         AV65Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to = AV11TFPoConcCod_To;
         AV66Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = AV12TFPoConcDsc;
         AV67Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel = AV13TFPoConcDsc_Sel;
         AV68Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels = AV48TFPoConcTip_Sels;
         AV69Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels = AV17TFPoConcSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1650PoConcTip ,
                                              AV68Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels ,
                                              A1649PoConcSts ,
                                              AV69Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels ,
                                              AV53Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 ,
                                              AV54Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 ,
                                              AV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ,
                                              AV56Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 ,
                                              AV57Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 ,
                                              AV58Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 ,
                                              AV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ,
                                              AV60Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 ,
                                              AV61Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 ,
                                              AV62Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 ,
                                              AV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ,
                                              AV64Produccion_conceptosordenesproduccionwwds_12_tfpoconccod ,
                                              AV65Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to ,
                                              AV67Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel ,
                                              AV66Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ,
                                              AV68Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels.Count ,
                                              AV69Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels.Count ,
                                              A1648PoConcDsc ,
                                              A313PoConcCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT
                                              }
         });
         lV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1), 100, "%");
         lV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1), 100, "%");
         lV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2), 100, "%");
         lV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2), 100, "%");
         lV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3), 100, "%");
         lV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3), 100, "%");
         lV66Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = StringUtil.PadR( StringUtil.RTrim( AV66Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc), 100, "%");
         /* Using cursor P00682 */
         pr_default.execute(0, new Object[] {lV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1, lV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1, lV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2, lV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2, lV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3, lV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3, AV64Produccion_conceptosordenesproduccionwwds_12_tfpoconccod, AV65Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to, lV66Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc, AV67Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK682 = false;
            A1648PoConcDsc = P00682_A1648PoConcDsc[0];
            A1649PoConcSts = P00682_A1649PoConcSts[0];
            A1650PoConcTip = P00682_A1650PoConcTip[0];
            A313PoConcCod = P00682_A313PoConcCod[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00682_A1648PoConcDsc[0], A1648PoConcDsc) == 0 ) )
            {
               BRK682 = false;
               A313PoConcCod = P00682_A313PoConcCod[0];
               AV30count = (long)(AV30count+1);
               BRK682 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1648PoConcDsc)) )
            {
               AV22Option = A1648PoConcDsc;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK682 )
            {
               BRK682 = true;
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
         AV12TFPoConcDsc = "";
         AV13TFPoConcDsc_Sel = "";
         AV47TFPoConcTip_SelsJson = "";
         AV48TFPoConcTip_Sels = new GxSimpleCollection<string>();
         AV16TFPoConcSts_SelsJson = "";
         AV17TFPoConcSts_Sels = new GxSimpleCollection<short>();
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38PoConcDsc1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42PoConcDsc2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46PoConcDsc3 = "";
         AV53Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 = "";
         AV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = "";
         AV57Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 = "";
         AV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = "";
         AV61Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 = "";
         AV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = "";
         AV66Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = "";
         AV67Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel = "";
         AV68Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels = new GxSimpleCollection<string>();
         AV69Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 = "";
         lV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 = "";
         lV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 = "";
         lV66Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc = "";
         A1650PoConcTip = "";
         A1648PoConcDsc = "";
         P00682_A1648PoConcDsc = new string[] {""} ;
         P00682_A1649PoConcSts = new short[1] ;
         P00682_A1650PoConcTip = new string[] {""} ;
         P00682_A313PoConcCod = new int[1] ;
         AV22Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.conceptosordenesproduccionwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00682_A1648PoConcDsc, P00682_A1649PoConcSts, P00682_A1650PoConcTip, P00682_A313PoConcCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV54Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 ;
      private short AV58Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 ;
      private short AV62Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 ;
      private short A1649PoConcSts ;
      private int AV51GXV1 ;
      private int AV10TFPoConcCod ;
      private int AV11TFPoConcCod_To ;
      private int AV64Produccion_conceptosordenesproduccionwwds_12_tfpoconccod ;
      private int AV65Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to ;
      private int AV68Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels_Count ;
      private int AV69Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels_Count ;
      private int A313PoConcCod ;
      private long AV30count ;
      private string AV12TFPoConcDsc ;
      private string AV13TFPoConcDsc_Sel ;
      private string AV38PoConcDsc1 ;
      private string AV42PoConcDsc2 ;
      private string AV46PoConcDsc3 ;
      private string AV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ;
      private string AV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ;
      private string AV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ;
      private string AV66Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ;
      private string AV67Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel ;
      private string scmdbuf ;
      private string lV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ;
      private string lV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ;
      private string lV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ;
      private string lV66Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ;
      private string A1650PoConcTip ;
      private string A1648PoConcDsc ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV56Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 ;
      private bool AV60Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 ;
      private bool BRK682 ;
      private string AV24OptionsJson ;
      private string AV27OptionsDescJson ;
      private string AV29OptionIndexesJson ;
      private string AV47TFPoConcTip_SelsJson ;
      private string AV16TFPoConcSts_SelsJson ;
      private string AV20DDOName ;
      private string AV18SearchTxt ;
      private string AV19SearchTxtTo ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV53Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 ;
      private string AV57Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 ;
      private string AV61Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 ;
      private string AV22Option ;
      private GxSimpleCollection<short> AV17TFPoConcSts_Sels ;
      private GxSimpleCollection<short> AV69Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00682_A1648PoConcDsc ;
      private short[] P00682_A1649PoConcSts ;
      private string[] P00682_A1650PoConcTip ;
      private int[] P00682_A313PoConcCod ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV48TFPoConcTip_Sels ;
      private GxSimpleCollection<string> AV68Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV35GridStateDynamicFilter ;
   }

   public class conceptosordenesproduccionwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00682( IGxContext context ,
                                             string A1650PoConcTip ,
                                             GxSimpleCollection<string> AV68Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels ,
                                             short A1649PoConcSts ,
                                             GxSimpleCollection<short> AV69Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels ,
                                             string AV53Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1 ,
                                             short AV54Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 ,
                                             string AV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1 ,
                                             bool AV56Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 ,
                                             string AV57Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2 ,
                                             short AV58Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 ,
                                             string AV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2 ,
                                             bool AV60Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 ,
                                             string AV61Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3 ,
                                             short AV62Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 ,
                                             string AV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3 ,
                                             int AV64Produccion_conceptosordenesproduccionwwds_12_tfpoconccod ,
                                             int AV65Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to ,
                                             string AV67Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel ,
                                             string AV66Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc ,
                                             int AV68Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels_Count ,
                                             int AV69Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels_Count ,
                                             string A1648PoConcDsc ,
                                             int A313PoConcCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [PoConcDsc], [PoConcSts], [PoConcTip], [PoConcCod] FROM [POCONCEPTOS]";
         if ( ( StringUtil.StrCmp(AV53Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1, "POCONCDSC") == 0 ) && ( AV54Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Produccion_conceptosordenesproduccionwwds_1_dynamicfiltersselector1, "POCONCDSC") == 0 ) && ( AV54Produccion_conceptosordenesproduccionwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like '%' + @lV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV56Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2, "POCONCDSC") == 0 ) && ( AV58Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV56Produccion_conceptosordenesproduccionwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Produccion_conceptosordenesproduccionwwds_5_dynamicfiltersselector2, "POCONCDSC") == 0 ) && ( AV58Produccion_conceptosordenesproduccionwwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like '%' + @lV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV60Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3, "POCONCDSC") == 0 ) && ( AV62Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV60Produccion_conceptosordenesproduccionwwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Produccion_conceptosordenesproduccionwwds_9_dynamicfiltersselector3, "POCONCDSC") == 0 ) && ( AV62Produccion_conceptosordenesproduccionwwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like '%' + @lV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV64Produccion_conceptosordenesproduccionwwds_12_tfpoconccod) )
         {
            AddWhere(sWhereString, "([PoConcCod] >= @AV64Produccion_conceptosordenesproduccionwwds_12_tfpoconccod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV65Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to) )
         {
            AddWhere(sWhereString, "([PoConcCod] <= @AV65Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc)) ) )
         {
            AddWhere(sWhereString, "([PoConcDsc] like @lV66Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel)) )
         {
            AddWhere(sWhereString, "([PoConcDsc] = @AV67Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV68Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV68Produccion_conceptosordenesproduccionwwds_16_tfpoconctip_sels, "[PoConcTip] IN (", ")")+")");
         }
         if ( AV69Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV69Produccion_conceptosordenesproduccionwwds_17_tfpoconcsts_sels, "[PoConcSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PoConcDsc]";
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
                     return conditional_P00682(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] );
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
          Object[] prmP00682;
          prmP00682 = new Object[] {
          new ParDef("@lV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV55Produccion_conceptosordenesproduccionwwds_3_poconcdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV59Produccion_conceptosordenesproduccionwwds_7_poconcdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV63Produccion_conceptosordenesproduccionwwds_11_poconcdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV64Produccion_conceptosordenesproduccionwwds_12_tfpoconccod",GXType.Int32,6,0) ,
          new ParDef("@AV65Produccion_conceptosordenesproduccionwwds_13_tfpoconccod_to",GXType.Int32,6,0) ,
          new ParDef("@lV66Produccion_conceptosordenesproduccionwwds_14_tfpoconcdsc",GXType.NChar,100,0) ,
          new ParDef("@AV67Produccion_conceptosordenesproduccionwwds_15_tfpoconcdsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00682", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00682,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
