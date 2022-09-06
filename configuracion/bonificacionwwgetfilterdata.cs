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
   public class bonificacionwwgetfilterdata : GXProcedure
   {
      public bonificacionwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public bonificacionwwgetfilterdata( IGxContext context )
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
         bonificacionwwgetfilterdata objbonificacionwwgetfilterdata;
         objbonificacionwwgetfilterdata = new bonificacionwwgetfilterdata();
         objbonificacionwwgetfilterdata.AV16DDOName = aP0_DDOName;
         objbonificacionwwgetfilterdata.AV14SearchTxt = aP1_SearchTxt;
         objbonificacionwwgetfilterdata.AV15SearchTxtTo = aP2_SearchTxtTo;
         objbonificacionwwgetfilterdata.AV20OptionsJson = "" ;
         objbonificacionwwgetfilterdata.AV23OptionsDescJson = "" ;
         objbonificacionwwgetfilterdata.AV25OptionIndexesJson = "" ;
         objbonificacionwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objbonificacionwwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objbonificacionwwgetfilterdata);
         aP3_OptionsJson=this.AV20OptionsJson;
         aP4_OptionsDescJson=this.AV23OptionsDescJson;
         aP5_OptionIndexesJson=this.AV25OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((bonificacionwwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV16DDOName), "DDO_CBONPRODCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADCBONPRODCODOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV16DDOName), "DDO_CBONPRODDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCBONPRODDSCOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV27Session.Get("Configuracion.BonificacionWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.BonificacionWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("Configuracion.BonificacionWWGridState"), null, "", "");
         }
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV42GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCBONPRODCOD") == 0 )
            {
               AV10TFCBonProdCod = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCBONPRODCOD_SEL") == 0 )
            {
               AV11TFCBonProdCod_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCBONPRODDSC") == 0 )
            {
               AV12TFCBonProdDsc = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCBONPRODDSC_SEL") == 0 )
            {
               AV13TFCBonProdDsc_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV42GXV1 = (int)(AV42GXV1+1);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV32DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "CBONPRODCOD") == 0 )
            {
               AV33CBonProdCod1 = AV31GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV34DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV35DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV35DynamicFiltersSelector2, "CBONPRODCOD") == 0 )
               {
                  AV36CBonProdCod2 = AV31GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV37DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV38DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV38DynamicFiltersSelector3, "CBONPRODCOD") == 0 )
                  {
                     AV39CBonProdCod3 = AV31GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCBONPRODCODOPTIONS' Routine */
         returnInSub = false;
         AV10TFCBonProdCod = AV14SearchTxt;
         AV11TFCBonProdCod_Sel = "";
         AV44Configuracion_bonificacionwwds_1_dynamicfiltersselector1 = AV32DynamicFiltersSelector1;
         AV45Configuracion_bonificacionwwds_2_cbonprodcod1 = AV33CBonProdCod1;
         AV46Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 = AV34DynamicFiltersEnabled2;
         AV47Configuracion_bonificacionwwds_4_dynamicfiltersselector2 = AV35DynamicFiltersSelector2;
         AV48Configuracion_bonificacionwwds_5_cbonprodcod2 = AV36CBonProdCod2;
         AV49Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 = AV37DynamicFiltersEnabled3;
         AV50Configuracion_bonificacionwwds_7_dynamicfiltersselector3 = AV38DynamicFiltersSelector3;
         AV51Configuracion_bonificacionwwds_8_cbonprodcod3 = AV39CBonProdCod3;
         AV52Configuracion_bonificacionwwds_9_tfcbonprodcod = AV10TFCBonProdCod;
         AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel = AV11TFCBonProdCod_Sel;
         AV54Configuracion_bonificacionwwds_11_tfcbonproddsc = AV12TFCBonProdDsc;
         AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel = AV13TFCBonProdDsc_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV44Configuracion_bonificacionwwds_1_dynamicfiltersselector1 ,
                                              AV45Configuracion_bonificacionwwds_2_cbonprodcod1 ,
                                              AV46Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 ,
                                              AV47Configuracion_bonificacionwwds_4_dynamicfiltersselector2 ,
                                              AV48Configuracion_bonificacionwwds_5_cbonprodcod2 ,
                                              AV49Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 ,
                                              AV50Configuracion_bonificacionwwds_7_dynamicfiltersselector3 ,
                                              AV51Configuracion_bonificacionwwds_8_cbonprodcod3 ,
                                              AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel ,
                                              AV52Configuracion_bonificacionwwds_9_tfcbonprodcod ,
                                              AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel ,
                                              AV54Configuracion_bonificacionwwds_11_tfcbonproddsc ,
                                              A81CBonProdCod ,
                                              A503CBonProdDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV52Configuracion_bonificacionwwds_9_tfcbonprodcod = StringUtil.PadR( StringUtil.RTrim( AV52Configuracion_bonificacionwwds_9_tfcbonprodcod), 15, "%");
         lV54Configuracion_bonificacionwwds_11_tfcbonproddsc = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_bonificacionwwds_11_tfcbonproddsc), 100, "%");
         /* Using cursor P00552 */
         pr_default.execute(0, new Object[] {AV45Configuracion_bonificacionwwds_2_cbonprodcod1, AV48Configuracion_bonificacionwwds_5_cbonprodcod2, AV51Configuracion_bonificacionwwds_8_cbonprodcod3, lV52Configuracion_bonificacionwwds_9_tfcbonprodcod, AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel, lV54Configuracion_bonificacionwwds_11_tfcbonproddsc, AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A503CBonProdDsc = P00552_A503CBonProdDsc[0];
            A81CBonProdCod = P00552_A81CBonProdCod[0];
            A503CBonProdDsc = P00552_A503CBonProdDsc[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A81CBonProdCod)) )
            {
               AV18Option = A81CBonProdCod;
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

      protected void S131( )
      {
         /* 'LOADCBONPRODDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFCBonProdDsc = AV14SearchTxt;
         AV13TFCBonProdDsc_Sel = "";
         AV44Configuracion_bonificacionwwds_1_dynamicfiltersselector1 = AV32DynamicFiltersSelector1;
         AV45Configuracion_bonificacionwwds_2_cbonprodcod1 = AV33CBonProdCod1;
         AV46Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 = AV34DynamicFiltersEnabled2;
         AV47Configuracion_bonificacionwwds_4_dynamicfiltersselector2 = AV35DynamicFiltersSelector2;
         AV48Configuracion_bonificacionwwds_5_cbonprodcod2 = AV36CBonProdCod2;
         AV49Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 = AV37DynamicFiltersEnabled3;
         AV50Configuracion_bonificacionwwds_7_dynamicfiltersselector3 = AV38DynamicFiltersSelector3;
         AV51Configuracion_bonificacionwwds_8_cbonprodcod3 = AV39CBonProdCod3;
         AV52Configuracion_bonificacionwwds_9_tfcbonprodcod = AV10TFCBonProdCod;
         AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel = AV11TFCBonProdCod_Sel;
         AV54Configuracion_bonificacionwwds_11_tfcbonproddsc = AV12TFCBonProdDsc;
         AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel = AV13TFCBonProdDsc_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV44Configuracion_bonificacionwwds_1_dynamicfiltersselector1 ,
                                              AV45Configuracion_bonificacionwwds_2_cbonprodcod1 ,
                                              AV46Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 ,
                                              AV47Configuracion_bonificacionwwds_4_dynamicfiltersselector2 ,
                                              AV48Configuracion_bonificacionwwds_5_cbonprodcod2 ,
                                              AV49Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 ,
                                              AV50Configuracion_bonificacionwwds_7_dynamicfiltersselector3 ,
                                              AV51Configuracion_bonificacionwwds_8_cbonprodcod3 ,
                                              AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel ,
                                              AV52Configuracion_bonificacionwwds_9_tfcbonprodcod ,
                                              AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel ,
                                              AV54Configuracion_bonificacionwwds_11_tfcbonproddsc ,
                                              A81CBonProdCod ,
                                              A503CBonProdDsc } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV52Configuracion_bonificacionwwds_9_tfcbonprodcod = StringUtil.PadR( StringUtil.RTrim( AV52Configuracion_bonificacionwwds_9_tfcbonprodcod), 15, "%");
         lV54Configuracion_bonificacionwwds_11_tfcbonproddsc = StringUtil.PadR( StringUtil.RTrim( AV54Configuracion_bonificacionwwds_11_tfcbonproddsc), 100, "%");
         /* Using cursor P00553 */
         pr_default.execute(1, new Object[] {AV45Configuracion_bonificacionwwds_2_cbonprodcod1, AV48Configuracion_bonificacionwwds_5_cbonprodcod2, AV51Configuracion_bonificacionwwds_8_cbonprodcod3, lV52Configuracion_bonificacionwwds_9_tfcbonprodcod, AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel, lV54Configuracion_bonificacionwwds_11_tfcbonproddsc, AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK553 = false;
            A81CBonProdCod = P00553_A81CBonProdCod[0];
            A503CBonProdDsc = P00553_A503CBonProdDsc[0];
            A503CBonProdDsc = P00553_A503CBonProdDsc[0];
            AV26count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00553_A81CBonProdCod[0], A81CBonProdCod) == 0 ) )
            {
               BRK553 = false;
               AV26count = (long)(AV26count+1);
               BRK553 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A503CBonProdDsc)) )
            {
               AV18Option = A503CBonProdDsc;
               AV17InsertIndex = 1;
               while ( ( AV17InsertIndex <= AV19Options.Count ) && ( StringUtil.StrCmp(((string)AV19Options.Item(AV17InsertIndex)), AV18Option) < 0 ) )
               {
                  AV17InsertIndex = (int)(AV17InsertIndex+1);
               }
               AV19Options.Add(AV18Option, AV17InsertIndex);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), AV17InsertIndex);
            }
            if ( AV19Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK553 )
            {
               BRK553 = true;
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
         AV10TFCBonProdCod = "";
         AV11TFCBonProdCod_Sel = "";
         AV12TFCBonProdDsc = "";
         AV13TFCBonProdDsc_Sel = "";
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV32DynamicFiltersSelector1 = "";
         AV33CBonProdCod1 = "";
         AV35DynamicFiltersSelector2 = "";
         AV36CBonProdCod2 = "";
         AV38DynamicFiltersSelector3 = "";
         AV39CBonProdCod3 = "";
         AV44Configuracion_bonificacionwwds_1_dynamicfiltersselector1 = "";
         AV45Configuracion_bonificacionwwds_2_cbonprodcod1 = "";
         AV47Configuracion_bonificacionwwds_4_dynamicfiltersselector2 = "";
         AV48Configuracion_bonificacionwwds_5_cbonprodcod2 = "";
         AV50Configuracion_bonificacionwwds_7_dynamicfiltersselector3 = "";
         AV51Configuracion_bonificacionwwds_8_cbonprodcod3 = "";
         AV52Configuracion_bonificacionwwds_9_tfcbonprodcod = "";
         AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel = "";
         AV54Configuracion_bonificacionwwds_11_tfcbonproddsc = "";
         AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel = "";
         scmdbuf = "";
         lV52Configuracion_bonificacionwwds_9_tfcbonprodcod = "";
         lV54Configuracion_bonificacionwwds_11_tfcbonproddsc = "";
         A81CBonProdCod = "";
         A503CBonProdDsc = "";
         P00552_A503CBonProdDsc = new string[] {""} ;
         P00552_A81CBonProdCod = new string[] {""} ;
         AV18Option = "";
         P00553_A81CBonProdCod = new string[] {""} ;
         P00553_A503CBonProdDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.bonificacionwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00552_A503CBonProdDsc, P00552_A81CBonProdCod
               }
               , new Object[] {
               P00553_A81CBonProdCod, P00553_A503CBonProdDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private int AV42GXV1 ;
      private int AV17InsertIndex ;
      private long AV26count ;
      private string AV10TFCBonProdCod ;
      private string AV11TFCBonProdCod_Sel ;
      private string AV12TFCBonProdDsc ;
      private string AV13TFCBonProdDsc_Sel ;
      private string AV33CBonProdCod1 ;
      private string AV36CBonProdCod2 ;
      private string AV39CBonProdCod3 ;
      private string AV45Configuracion_bonificacionwwds_2_cbonprodcod1 ;
      private string AV48Configuracion_bonificacionwwds_5_cbonprodcod2 ;
      private string AV51Configuracion_bonificacionwwds_8_cbonprodcod3 ;
      private string AV52Configuracion_bonificacionwwds_9_tfcbonprodcod ;
      private string AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel ;
      private string AV54Configuracion_bonificacionwwds_11_tfcbonproddsc ;
      private string AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel ;
      private string scmdbuf ;
      private string lV52Configuracion_bonificacionwwds_9_tfcbonprodcod ;
      private string lV54Configuracion_bonificacionwwds_11_tfcbonproddsc ;
      private string A81CBonProdCod ;
      private string A503CBonProdDsc ;
      private bool returnInSub ;
      private bool AV34DynamicFiltersEnabled2 ;
      private bool AV37DynamicFiltersEnabled3 ;
      private bool AV46Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 ;
      private bool AV49Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 ;
      private bool BRK553 ;
      private string AV20OptionsJson ;
      private string AV23OptionsDescJson ;
      private string AV25OptionIndexesJson ;
      private string AV16DDOName ;
      private string AV14SearchTxt ;
      private string AV15SearchTxtTo ;
      private string AV32DynamicFiltersSelector1 ;
      private string AV35DynamicFiltersSelector2 ;
      private string AV38DynamicFiltersSelector3 ;
      private string AV44Configuracion_bonificacionwwds_1_dynamicfiltersselector1 ;
      private string AV47Configuracion_bonificacionwwds_4_dynamicfiltersselector2 ;
      private string AV50Configuracion_bonificacionwwds_7_dynamicfiltersselector3 ;
      private string AV18Option ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00552_A503CBonProdDsc ;
      private string[] P00552_A81CBonProdCod ;
      private string[] P00553_A81CBonProdCod ;
      private string[] P00553_A503CBonProdDsc ;
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

   public class bonificacionwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00552( IGxContext context ,
                                             string AV44Configuracion_bonificacionwwds_1_dynamicfiltersselector1 ,
                                             string AV45Configuracion_bonificacionwwds_2_cbonprodcod1 ,
                                             bool AV46Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 ,
                                             string AV47Configuracion_bonificacionwwds_4_dynamicfiltersselector2 ,
                                             string AV48Configuracion_bonificacionwwds_5_cbonprodcod2 ,
                                             bool AV49Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 ,
                                             string AV50Configuracion_bonificacionwwds_7_dynamicfiltersselector3 ,
                                             string AV51Configuracion_bonificacionwwds_8_cbonprodcod3 ,
                                             string AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel ,
                                             string AV52Configuracion_bonificacionwwds_9_tfcbonprodcod ,
                                             string AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel ,
                                             string AV54Configuracion_bonificacionwwds_11_tfcbonproddsc ,
                                             string A81CBonProdCod ,
                                             string A503CBonProdDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[7];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [CBonProdDsc], [CBonProdCod] FROM ( SELECT TOP(100) PERCENT T2.[ProdDsc] AS CBonProdDsc, T1.[CBonProdCod] AS CBonProdCod FROM ([CBONIFICACION] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[CBonProdCod])";
         if ( ( StringUtil.StrCmp(AV44Configuracion_bonificacionwwds_1_dynamicfiltersselector1, "CBONPRODCOD") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Configuracion_bonificacionwwds_2_cbonprodcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV45Configuracion_bonificacionwwds_2_cbonprodcod1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( AV46Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV47Configuracion_bonificacionwwds_4_dynamicfiltersselector2, "CBONPRODCOD") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Configuracion_bonificacionwwds_5_cbonprodcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV48Configuracion_bonificacionwwds_5_cbonprodcod2)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV49Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV50Configuracion_bonificacionwwds_7_dynamicfiltersselector3, "CBONPRODCOD") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Configuracion_bonificacionwwds_8_cbonprodcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV51Configuracion_bonificacionwwds_8_cbonprodcod3)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracion_bonificacionwwds_9_tfcbonprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] like @lV52Configuracion_bonificacionwwds_9_tfcbonprodcod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_bonificacionwwds_11_tfcbonproddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[ProdDsc] like @lV54Configuracion_bonificacionwwds_11_tfcbonproddsc)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[ProdDsc] = @AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CBonProdCod]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [CBonProdCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00553( IGxContext context ,
                                             string AV44Configuracion_bonificacionwwds_1_dynamicfiltersselector1 ,
                                             string AV45Configuracion_bonificacionwwds_2_cbonprodcod1 ,
                                             bool AV46Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 ,
                                             string AV47Configuracion_bonificacionwwds_4_dynamicfiltersselector2 ,
                                             string AV48Configuracion_bonificacionwwds_5_cbonprodcod2 ,
                                             bool AV49Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 ,
                                             string AV50Configuracion_bonificacionwwds_7_dynamicfiltersselector3 ,
                                             string AV51Configuracion_bonificacionwwds_8_cbonprodcod3 ,
                                             string AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel ,
                                             string AV52Configuracion_bonificacionwwds_9_tfcbonprodcod ,
                                             string AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel ,
                                             string AV54Configuracion_bonificacionwwds_11_tfcbonproddsc ,
                                             string A81CBonProdCod ,
                                             string A503CBonProdDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[CBonProdCod] AS CBonProdCod, T2.[ProdDsc] AS CBonProdDsc FROM ([CBONIFICACION] T1 INNER JOIN [APRODUCTOS] T2 ON T2.[ProdCod] = T1.[CBonProdCod])";
         if ( ( StringUtil.StrCmp(AV44Configuracion_bonificacionwwds_1_dynamicfiltersselector1, "CBONPRODCOD") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45Configuracion_bonificacionwwds_2_cbonprodcod1)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV45Configuracion_bonificacionwwds_2_cbonprodcod1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( AV46Configuracion_bonificacionwwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV47Configuracion_bonificacionwwds_4_dynamicfiltersselector2, "CBONPRODCOD") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Configuracion_bonificacionwwds_5_cbonprodcod2)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV48Configuracion_bonificacionwwds_5_cbonprodcod2)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV49Configuracion_bonificacionwwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV50Configuracion_bonificacionwwds_7_dynamicfiltersselector3, "CBONPRODCOD") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Configuracion_bonificacionwwds_8_cbonprodcod3)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV51Configuracion_bonificacionwwds_8_cbonprodcod3)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Configuracion_bonificacionwwds_9_tfcbonprodcod)) ) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] like @lV52Configuracion_bonificacionwwds_9_tfcbonprodcod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CBonProdCod] = @AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Configuracion_bonificacionwwds_11_tfcbonproddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[ProdDsc] like @lV54Configuracion_bonificacionwwds_11_tfcbonproddsc)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[ProdDsc] = @AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CBonProdCod]";
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
                     return conditional_P00552(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
               case 1 :
                     return conditional_P00553(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
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
          Object[] prmP00552;
          prmP00552 = new Object[] {
          new ParDef("@AV45Configuracion_bonificacionwwds_2_cbonprodcod1",GXType.NChar,15,0) ,
          new ParDef("@AV48Configuracion_bonificacionwwds_5_cbonprodcod2",GXType.NChar,15,0) ,
          new ParDef("@AV51Configuracion_bonificacionwwds_8_cbonprodcod3",GXType.NChar,15,0) ,
          new ParDef("@lV52Configuracion_bonificacionwwds_9_tfcbonprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV54Configuracion_bonificacionwwds_11_tfcbonproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP00553;
          prmP00553 = new Object[] {
          new ParDef("@AV45Configuracion_bonificacionwwds_2_cbonprodcod1",GXType.NChar,15,0) ,
          new ParDef("@AV48Configuracion_bonificacionwwds_5_cbonprodcod2",GXType.NChar,15,0) ,
          new ParDef("@AV51Configuracion_bonificacionwwds_8_cbonprodcod3",GXType.NChar,15,0) ,
          new ParDef("@lV52Configuracion_bonificacionwwds_9_tfcbonprodcod",GXType.NChar,15,0) ,
          new ParDef("@AV53Configuracion_bonificacionwwds_10_tfcbonprodcod_sel",GXType.NChar,15,0) ,
          new ParDef("@lV54Configuracion_bonificacionwwds_11_tfcbonproddsc",GXType.NChar,100,0) ,
          new ParDef("@AV55Configuracion_bonificacionwwds_12_tfcbonproddsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00552", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00552,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00553", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00553,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 15);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 15);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                return;
       }
    }

 }

}
