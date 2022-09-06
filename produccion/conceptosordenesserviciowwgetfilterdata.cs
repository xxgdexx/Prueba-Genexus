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
   public class conceptosordenesserviciowwgetfilterdata : GXProcedure
   {
      public conceptosordenesserviciowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public conceptosordenesserviciowwgetfilterdata( IGxContext context )
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
         conceptosordenesserviciowwgetfilterdata objconceptosordenesserviciowwgetfilterdata;
         objconceptosordenesserviciowwgetfilterdata = new conceptosordenesserviciowwgetfilterdata();
         objconceptosordenesserviciowwgetfilterdata.AV20DDOName = aP0_DDOName;
         objconceptosordenesserviciowwgetfilterdata.AV18SearchTxt = aP1_SearchTxt;
         objconceptosordenesserviciowwgetfilterdata.AV19SearchTxtTo = aP2_SearchTxtTo;
         objconceptosordenesserviciowwgetfilterdata.AV24OptionsJson = "" ;
         objconceptosordenesserviciowwgetfilterdata.AV27OptionsDescJson = "" ;
         objconceptosordenesserviciowwgetfilterdata.AV29OptionIndexesJson = "" ;
         objconceptosordenesserviciowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objconceptosordenesserviciowwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objconceptosordenesserviciowwgetfilterdata);
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((conceptosordenesserviciowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_PSERCONCDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADPSERCONCDSCOPTIONS' */
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
         if ( StringUtil.StrCmp(AV31Session.Get("Produccion.ConceptosOrdenesServicioWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Produccion.ConceptosOrdenesServicioWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Produccion.ConceptosOrdenesServicioWWGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPSERCONCCOD") == 0 )
            {
               AV10TFPSerConcCod = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV11TFPSerConcCod_To = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPSERCONCDSC") == 0 )
            {
               AV12TFPSerConcDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPSERCONCDSC_SEL") == 0 )
            {
               AV13TFPSerConcDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPSERCONCTIPO_SEL") == 0 )
            {
               AV14TFPSerConcTipo_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV15TFPSerConcTipo_Sels.FromJSonString(AV14TFPSerConcTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFPSERCONCSTS_SEL") == 0 )
            {
               AV16TFPSerConcSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV17TFPSerConcSts_Sels.FromJSonString(AV16TFPSerConcSts_SelsJson, null);
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "PSERCONCDSC") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV38PSerConcDsc1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "PSERCONCDSC") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV42PSerConcDsc2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "PSERCONCDSC") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV46PSerConcDsc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPSERCONCDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFPSerConcDsc = AV18SearchTxt;
         AV13TFPSerConcDsc_Sel = "";
         AV51Produccion_conceptosordenesserviciowwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV52Produccion_conceptosordenesserviciowwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 = AV38PSerConcDsc1;
         AV54Produccion_conceptosordenesserviciowwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV55Produccion_conceptosordenesserviciowwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV56Produccion_conceptosordenesserviciowwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 = AV42PSerConcDsc2;
         AV58Produccion_conceptosordenesserviciowwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV59Produccion_conceptosordenesserviciowwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV60Produccion_conceptosordenesserviciowwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 = AV46PSerConcDsc3;
         AV62Produccion_conceptosordenesserviciowwds_12_tfpserconccod = AV10TFPSerConcCod;
         AV63Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to = AV11TFPSerConcCod_To;
         AV64Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc = AV12TFPSerConcDsc;
         AV65Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel = AV13TFPSerConcDsc_Sel;
         AV66Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels = AV15TFPSerConcTipo_Sels;
         AV67Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels = AV17TFPSerConcSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1797PSerConcTipo ,
                                              AV66Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels ,
                                              A1796PSerConcSts ,
                                              AV67Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels ,
                                              AV51Produccion_conceptosordenesserviciowwds_1_dynamicfiltersselector1 ,
                                              AV52Produccion_conceptosordenesserviciowwds_2_dynamicfiltersoperator1 ,
                                              AV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 ,
                                              AV54Produccion_conceptosordenesserviciowwds_4_dynamicfiltersenabled2 ,
                                              AV55Produccion_conceptosordenesserviciowwds_5_dynamicfiltersselector2 ,
                                              AV56Produccion_conceptosordenesserviciowwds_6_dynamicfiltersoperator2 ,
                                              AV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 ,
                                              AV58Produccion_conceptosordenesserviciowwds_8_dynamicfiltersenabled3 ,
                                              AV59Produccion_conceptosordenesserviciowwds_9_dynamicfiltersselector3 ,
                                              AV60Produccion_conceptosordenesserviciowwds_10_dynamicfiltersoperator3 ,
                                              AV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 ,
                                              AV62Produccion_conceptosordenesserviciowwds_12_tfpserconccod ,
                                              AV63Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to ,
                                              AV65Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel ,
                                              AV64Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc ,
                                              AV66Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels.Count ,
                                              AV67Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels.Count ,
                                              A1795PSerConcDsc ,
                                              A332PSerConcCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT
                                              }
         });
         lV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 = StringUtil.Concat( StringUtil.RTrim( AV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1), "%", "");
         lV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 = StringUtil.Concat( StringUtil.RTrim( AV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1), "%", "");
         lV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 = StringUtil.Concat( StringUtil.RTrim( AV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2), "%", "");
         lV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 = StringUtil.Concat( StringUtil.RTrim( AV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2), "%", "");
         lV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 = StringUtil.Concat( StringUtil.RTrim( AV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3), "%", "");
         lV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 = StringUtil.Concat( StringUtil.RTrim( AV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3), "%", "");
         lV64Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc = StringUtil.Concat( StringUtil.RTrim( AV64Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc), "%", "");
         /* Using cursor P006C2 */
         pr_default.execute(0, new Object[] {lV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1, lV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1, lV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2, lV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2, lV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3, lV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3, AV62Produccion_conceptosordenesserviciowwds_12_tfpserconccod, AV63Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to, lV64Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc, AV65Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6C2 = false;
            A1795PSerConcDsc = P006C2_A1795PSerConcDsc[0];
            A1796PSerConcSts = P006C2_A1796PSerConcSts[0];
            A1797PSerConcTipo = P006C2_A1797PSerConcTipo[0];
            A332PSerConcCod = P006C2_A332PSerConcCod[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006C2_A1795PSerConcDsc[0], A1795PSerConcDsc) == 0 ) )
            {
               BRK6C2 = false;
               A332PSerConcCod = P006C2_A332PSerConcCod[0];
               AV30count = (long)(AV30count+1);
               BRK6C2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1795PSerConcDsc)) )
            {
               AV22Option = A1795PSerConcDsc;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK6C2 )
            {
               BRK6C2 = true;
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
         AV12TFPSerConcDsc = "";
         AV13TFPSerConcDsc_Sel = "";
         AV14TFPSerConcTipo_SelsJson = "";
         AV15TFPSerConcTipo_Sels = new GxSimpleCollection<string>();
         AV16TFPSerConcSts_SelsJson = "";
         AV17TFPSerConcSts_Sels = new GxSimpleCollection<short>();
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38PSerConcDsc1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42PSerConcDsc2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46PSerConcDsc3 = "";
         AV51Produccion_conceptosordenesserviciowwds_1_dynamicfiltersselector1 = "";
         AV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 = "";
         AV55Produccion_conceptosordenesserviciowwds_5_dynamicfiltersselector2 = "";
         AV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 = "";
         AV59Produccion_conceptosordenesserviciowwds_9_dynamicfiltersselector3 = "";
         AV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 = "";
         AV64Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc = "";
         AV65Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel = "";
         AV66Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels = new GxSimpleCollection<string>();
         AV67Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 = "";
         lV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 = "";
         lV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 = "";
         lV64Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc = "";
         A1797PSerConcTipo = "";
         A1795PSerConcDsc = "";
         P006C2_A1795PSerConcDsc = new string[] {""} ;
         P006C2_A1796PSerConcSts = new short[1] ;
         P006C2_A1797PSerConcTipo = new string[] {""} ;
         P006C2_A332PSerConcCod = new int[1] ;
         AV22Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.conceptosordenesserviciowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006C2_A1795PSerConcDsc, P006C2_A1796PSerConcSts, P006C2_A1797PSerConcTipo, P006C2_A332PSerConcCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV52Produccion_conceptosordenesserviciowwds_2_dynamicfiltersoperator1 ;
      private short AV56Produccion_conceptosordenesserviciowwds_6_dynamicfiltersoperator2 ;
      private short AV60Produccion_conceptosordenesserviciowwds_10_dynamicfiltersoperator3 ;
      private short A1796PSerConcSts ;
      private int AV49GXV1 ;
      private int AV10TFPSerConcCod ;
      private int AV11TFPSerConcCod_To ;
      private int AV62Produccion_conceptosordenesserviciowwds_12_tfpserconccod ;
      private int AV63Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to ;
      private int AV66Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels_Count ;
      private int AV67Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels_Count ;
      private int A332PSerConcCod ;
      private long AV30count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV54Produccion_conceptosordenesserviciowwds_4_dynamicfiltersenabled2 ;
      private bool AV58Produccion_conceptosordenesserviciowwds_8_dynamicfiltersenabled3 ;
      private bool BRK6C2 ;
      private string AV24OptionsJson ;
      private string AV27OptionsDescJson ;
      private string AV29OptionIndexesJson ;
      private string AV14TFPSerConcTipo_SelsJson ;
      private string AV16TFPSerConcSts_SelsJson ;
      private string AV20DDOName ;
      private string AV18SearchTxt ;
      private string AV19SearchTxtTo ;
      private string AV12TFPSerConcDsc ;
      private string AV13TFPSerConcDsc_Sel ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV38PSerConcDsc1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV42PSerConcDsc2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV46PSerConcDsc3 ;
      private string AV51Produccion_conceptosordenesserviciowwds_1_dynamicfiltersselector1 ;
      private string AV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 ;
      private string AV55Produccion_conceptosordenesserviciowwds_5_dynamicfiltersselector2 ;
      private string AV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 ;
      private string AV59Produccion_conceptosordenesserviciowwds_9_dynamicfiltersselector3 ;
      private string AV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 ;
      private string AV64Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc ;
      private string AV65Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel ;
      private string lV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 ;
      private string lV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 ;
      private string lV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 ;
      private string lV64Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc ;
      private string A1797PSerConcTipo ;
      private string A1795PSerConcDsc ;
      private string AV22Option ;
      private GxSimpleCollection<short> AV17TFPSerConcSts_Sels ;
      private GxSimpleCollection<short> AV67Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P006C2_A1795PSerConcDsc ;
      private short[] P006C2_A1796PSerConcSts ;
      private string[] P006C2_A1797PSerConcTipo ;
      private int[] P006C2_A332PSerConcCod ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GxSimpleCollection<string> AV15TFPSerConcTipo_Sels ;
      private GxSimpleCollection<string> AV66Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV35GridStateDynamicFilter ;
   }

   public class conceptosordenesserviciowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006C2( IGxContext context ,
                                             string A1797PSerConcTipo ,
                                             GxSimpleCollection<string> AV66Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels ,
                                             short A1796PSerConcSts ,
                                             GxSimpleCollection<short> AV67Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels ,
                                             string AV51Produccion_conceptosordenesserviciowwds_1_dynamicfiltersselector1 ,
                                             short AV52Produccion_conceptosordenesserviciowwds_2_dynamicfiltersoperator1 ,
                                             string AV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1 ,
                                             bool AV54Produccion_conceptosordenesserviciowwds_4_dynamicfiltersenabled2 ,
                                             string AV55Produccion_conceptosordenesserviciowwds_5_dynamicfiltersselector2 ,
                                             short AV56Produccion_conceptosordenesserviciowwds_6_dynamicfiltersoperator2 ,
                                             string AV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2 ,
                                             bool AV58Produccion_conceptosordenesserviciowwds_8_dynamicfiltersenabled3 ,
                                             string AV59Produccion_conceptosordenesserviciowwds_9_dynamicfiltersselector3 ,
                                             short AV60Produccion_conceptosordenesserviciowwds_10_dynamicfiltersoperator3 ,
                                             string AV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3 ,
                                             int AV62Produccion_conceptosordenesserviciowwds_12_tfpserconccod ,
                                             int AV63Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to ,
                                             string AV65Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel ,
                                             string AV64Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc ,
                                             int AV66Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels_Count ,
                                             int AV67Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels_Count ,
                                             string A1795PSerConcDsc ,
                                             int A332PSerConcCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [PSerConcDsc], [PSerConcSts], [PSerConcTipo], [PSerConcCod] FROM [POSERCONCEPTOS]";
         if ( ( StringUtil.StrCmp(AV51Produccion_conceptosordenesserviciowwds_1_dynamicfiltersselector1, "PSERCONCDSC") == 0 ) && ( AV52Produccion_conceptosordenesserviciowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1)) ) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] like @lV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Produccion_conceptosordenesserviciowwds_1_dynamicfiltersselector1, "PSERCONCDSC") == 0 ) && ( AV52Produccion_conceptosordenesserviciowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1)) ) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] like '%' + @lV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV54Produccion_conceptosordenesserviciowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Produccion_conceptosordenesserviciowwds_5_dynamicfiltersselector2, "PSERCONCDSC") == 0 ) && ( AV56Produccion_conceptosordenesserviciowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2)) ) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] like @lV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV54Produccion_conceptosordenesserviciowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Produccion_conceptosordenesserviciowwds_5_dynamicfiltersselector2, "PSERCONCDSC") == 0 ) && ( AV56Produccion_conceptosordenesserviciowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2)) ) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] like '%' + @lV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV58Produccion_conceptosordenesserviciowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Produccion_conceptosordenesserviciowwds_9_dynamicfiltersselector3, "PSERCONCDSC") == 0 ) && ( AV60Produccion_conceptosordenesserviciowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3)) ) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] like @lV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV58Produccion_conceptosordenesserviciowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Produccion_conceptosordenesserviciowwds_9_dynamicfiltersselector3, "PSERCONCDSC") == 0 ) && ( AV60Produccion_conceptosordenesserviciowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3)) ) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] like '%' + @lV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV62Produccion_conceptosordenesserviciowwds_12_tfpserconccod) )
         {
            AddWhere(sWhereString, "([PSerConcCod] >= @AV62Produccion_conceptosordenesserviciowwds_12_tfpserconccod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV63Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to) )
         {
            AddWhere(sWhereString, "([PSerConcCod] <= @AV63Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc)) ) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] like @lV64Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel)) )
         {
            AddWhere(sWhereString, "([PSerConcDsc] = @AV65Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV66Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV66Produccion_conceptosordenesserviciowwds_16_tfpserconctipo_sels, "[PSerConcTipo] IN (", ")")+")");
         }
         if ( AV67Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV67Produccion_conceptosordenesserviciowwds_17_tfpserconcsts_sels, "[PSerConcSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PSerConcDsc]";
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
                     return conditional_P006C2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (int)dynConstraints[22] );
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
          Object[] prmP006C2;
          prmP006C2 = new Object[] {
          new ParDef("@lV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV53Produccion_conceptosordenesserviciowwds_3_pserconcdsc1",GXType.NVarChar,100,0) ,
          new ParDef("@lV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV57Produccion_conceptosordenesserviciowwds_7_pserconcdsc2",GXType.NVarChar,100,0) ,
          new ParDef("@lV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3",GXType.NVarChar,100,0) ,
          new ParDef("@lV61Produccion_conceptosordenesserviciowwds_11_pserconcdsc3",GXType.NVarChar,100,0) ,
          new ParDef("@AV62Produccion_conceptosordenesserviciowwds_12_tfpserconccod",GXType.Int32,6,0) ,
          new ParDef("@AV63Produccion_conceptosordenesserviciowwds_13_tfpserconccod_to",GXType.Int32,6,0) ,
          new ParDef("@lV64Produccion_conceptosordenesserviciowwds_14_tfpserconcdsc",GXType.NVarChar,100,0) ,
          new ParDef("@AV65Produccion_conceptosordenesserviciowwds_15_tfpserconcdsc_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006C2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
