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
   public class unidadmedidawwgetfilterdata : GXProcedure
   {
      public unidadmedidawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public unidadmedidawwgetfilterdata( IGxContext context )
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
         this.AV22DDOName = aP0_DDOName;
         this.AV20SearchTxt = aP1_SearchTxt;
         this.AV21SearchTxtTo = aP2_SearchTxtTo;
         this.AV26OptionsJson = "" ;
         this.AV29OptionsDescJson = "" ;
         this.AV31OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV31OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         unidadmedidawwgetfilterdata objunidadmedidawwgetfilterdata;
         objunidadmedidawwgetfilterdata = new unidadmedidawwgetfilterdata();
         objunidadmedidawwgetfilterdata.AV22DDOName = aP0_DDOName;
         objunidadmedidawwgetfilterdata.AV20SearchTxt = aP1_SearchTxt;
         objunidadmedidawwgetfilterdata.AV21SearchTxtTo = aP2_SearchTxtTo;
         objunidadmedidawwgetfilterdata.AV26OptionsJson = "" ;
         objunidadmedidawwgetfilterdata.AV29OptionsDescJson = "" ;
         objunidadmedidawwgetfilterdata.AV31OptionIndexesJson = "" ;
         objunidadmedidawwgetfilterdata.context.SetSubmitInitialConfig(context);
         objunidadmedidawwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objunidadmedidawwgetfilterdata);
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((unidadmedidawwgetfilterdata)stateInfo).executePrivate();
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
         AV25Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_UNIDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADUNIDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_UNIABR") == 0 )
         {
            /* Execute user subroutine: 'LOADUNIABROPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_UNISUNAT") == 0 )
         {
            /* Execute user subroutine: 'LOADUNISUNATOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV26OptionsJson = AV25Options.ToJSonString(false);
         AV29OptionsDescJson = AV28OptionsDesc.ToJSonString(false);
         AV31OptionIndexesJson = AV30OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get("Configuracion.UnidadMedidaWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.UnidadMedidaWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Configuracion.UnidadMedidaWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFUNICOD") == 0 )
            {
               AV10TFUniCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV11TFUniCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFUNIDSC") == 0 )
            {
               AV12TFUniDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFUNIDSC_SEL") == 0 )
            {
               AV13TFUniDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFUNIABR") == 0 )
            {
               AV14TFUniAbr = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFUNIABR_SEL") == 0 )
            {
               AV15TFUniAbr_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFUNISUNAT") == 0 )
            {
               AV16TFUniSunat = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFUNISUNAT_SEL") == 0 )
            {
               AV17TFUniSunat_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFUNISTS_SEL") == 0 )
            {
               AV18TFUniSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV19TFUniSts_Sels.FromJSonString(AV18TFUniSts_SelsJson, null);
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "UNIDSC") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV40UniDsc1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "UNIDSC") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV44UniDsc2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "UNIDSC") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV48UniDsc3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADUNIDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFUniDsc = AV20SearchTxt;
         AV13TFUniDsc_Sel = "";
         AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV55Configuracion_unidadmedidawwds_3_unidsc1 = AV40UniDsc1;
         AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV59Configuracion_unidadmedidawwds_7_unidsc2 = AV44UniDsc2;
         AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV63Configuracion_unidadmedidawwds_11_unidsc3 = AV48UniDsc3;
         AV64Configuracion_unidadmedidawwds_12_tfunicod = AV10TFUniCod;
         AV65Configuracion_unidadmedidawwds_13_tfunicod_to = AV11TFUniCod_To;
         AV66Configuracion_unidadmedidawwds_14_tfunidsc = AV12TFUniDsc;
         AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel = AV13TFUniDsc_Sel;
         AV68Configuracion_unidadmedidawwds_16_tfuniabr = AV14TFUniAbr;
         AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel = AV15TFUniAbr_Sel;
         AV70Configuracion_unidadmedidawwds_18_tfunisunat = AV16TFUniSunat;
         AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel = AV17TFUniSunat_Sel;
         AV72Configuracion_unidadmedidawwds_20_tfunists_sels = AV19TFUniSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1999UniSts ,
                                              AV72Configuracion_unidadmedidawwds_20_tfunists_sels ,
                                              AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 ,
                                              AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 ,
                                              AV55Configuracion_unidadmedidawwds_3_unidsc1 ,
                                              AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 ,
                                              AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 ,
                                              AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 ,
                                              AV59Configuracion_unidadmedidawwds_7_unidsc2 ,
                                              AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 ,
                                              AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 ,
                                              AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 ,
                                              AV63Configuracion_unidadmedidawwds_11_unidsc3 ,
                                              AV64Configuracion_unidadmedidawwds_12_tfunicod ,
                                              AV65Configuracion_unidadmedidawwds_13_tfunicod_to ,
                                              AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel ,
                                              AV66Configuracion_unidadmedidawwds_14_tfunidsc ,
                                              AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel ,
                                              AV68Configuracion_unidadmedidawwds_16_tfuniabr ,
                                              AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel ,
                                              AV70Configuracion_unidadmedidawwds_18_tfunisunat ,
                                              AV72Configuracion_unidadmedidawwds_20_tfunists_sels.Count ,
                                              A1998UniDsc ,
                                              A49UniCod ,
                                              A1997UniAbr ,
                                              A2000UniSunat } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV55Configuracion_unidadmedidawwds_3_unidsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Configuracion_unidadmedidawwds_3_unidsc1), 100, "%");
         lV55Configuracion_unidadmedidawwds_3_unidsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Configuracion_unidadmedidawwds_3_unidsc1), 100, "%");
         lV59Configuracion_unidadmedidawwds_7_unidsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_unidadmedidawwds_7_unidsc2), 100, "%");
         lV59Configuracion_unidadmedidawwds_7_unidsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_unidadmedidawwds_7_unidsc2), 100, "%");
         lV63Configuracion_unidadmedidawwds_11_unidsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_unidadmedidawwds_11_unidsc3), 100, "%");
         lV63Configuracion_unidadmedidawwds_11_unidsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_unidadmedidawwds_11_unidsc3), 100, "%");
         lV66Configuracion_unidadmedidawwds_14_tfunidsc = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_unidadmedidawwds_14_tfunidsc), 100, "%");
         lV68Configuracion_unidadmedidawwds_16_tfuniabr = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_unidadmedidawwds_16_tfuniabr), 5, "%");
         lV70Configuracion_unidadmedidawwds_18_tfunisunat = StringUtil.Concat( StringUtil.RTrim( AV70Configuracion_unidadmedidawwds_18_tfunisunat), "%", "");
         /* Using cursor P002P2 */
         pr_default.execute(0, new Object[] {lV55Configuracion_unidadmedidawwds_3_unidsc1, lV55Configuracion_unidadmedidawwds_3_unidsc1, lV59Configuracion_unidadmedidawwds_7_unidsc2, lV59Configuracion_unidadmedidawwds_7_unidsc2, lV63Configuracion_unidadmedidawwds_11_unidsc3, lV63Configuracion_unidadmedidawwds_11_unidsc3, AV64Configuracion_unidadmedidawwds_12_tfunicod, AV65Configuracion_unidadmedidawwds_13_tfunicod_to, lV66Configuracion_unidadmedidawwds_14_tfunidsc, AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel, lV68Configuracion_unidadmedidawwds_16_tfuniabr, AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel, lV70Configuracion_unidadmedidawwds_18_tfunisunat, AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2P2 = false;
            A1998UniDsc = P002P2_A1998UniDsc[0];
            A1999UniSts = P002P2_A1999UniSts[0];
            A2000UniSunat = P002P2_A2000UniSunat[0];
            A1997UniAbr = P002P2_A1997UniAbr[0];
            A49UniCod = P002P2_A49UniCod[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002P2_A1998UniDsc[0], A1998UniDsc) == 0 ) )
            {
               BRK2P2 = false;
               A49UniCod = P002P2_A49UniCod[0];
               AV32count = (long)(AV32count+1);
               BRK2P2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1998UniDsc)) )
            {
               AV24Option = A1998UniDsc;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK2P2 )
            {
               BRK2P2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADUNIABROPTIONS' Routine */
         returnInSub = false;
         AV14TFUniAbr = AV20SearchTxt;
         AV15TFUniAbr_Sel = "";
         AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV55Configuracion_unidadmedidawwds_3_unidsc1 = AV40UniDsc1;
         AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV59Configuracion_unidadmedidawwds_7_unidsc2 = AV44UniDsc2;
         AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV63Configuracion_unidadmedidawwds_11_unidsc3 = AV48UniDsc3;
         AV64Configuracion_unidadmedidawwds_12_tfunicod = AV10TFUniCod;
         AV65Configuracion_unidadmedidawwds_13_tfunicod_to = AV11TFUniCod_To;
         AV66Configuracion_unidadmedidawwds_14_tfunidsc = AV12TFUniDsc;
         AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel = AV13TFUniDsc_Sel;
         AV68Configuracion_unidadmedidawwds_16_tfuniabr = AV14TFUniAbr;
         AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel = AV15TFUniAbr_Sel;
         AV70Configuracion_unidadmedidawwds_18_tfunisunat = AV16TFUniSunat;
         AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel = AV17TFUniSunat_Sel;
         AV72Configuracion_unidadmedidawwds_20_tfunists_sels = AV19TFUniSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1999UniSts ,
                                              AV72Configuracion_unidadmedidawwds_20_tfunists_sels ,
                                              AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 ,
                                              AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 ,
                                              AV55Configuracion_unidadmedidawwds_3_unidsc1 ,
                                              AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 ,
                                              AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 ,
                                              AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 ,
                                              AV59Configuracion_unidadmedidawwds_7_unidsc2 ,
                                              AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 ,
                                              AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 ,
                                              AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 ,
                                              AV63Configuracion_unidadmedidawwds_11_unidsc3 ,
                                              AV64Configuracion_unidadmedidawwds_12_tfunicod ,
                                              AV65Configuracion_unidadmedidawwds_13_tfunicod_to ,
                                              AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel ,
                                              AV66Configuracion_unidadmedidawwds_14_tfunidsc ,
                                              AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel ,
                                              AV68Configuracion_unidadmedidawwds_16_tfuniabr ,
                                              AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel ,
                                              AV70Configuracion_unidadmedidawwds_18_tfunisunat ,
                                              AV72Configuracion_unidadmedidawwds_20_tfunists_sels.Count ,
                                              A1998UniDsc ,
                                              A49UniCod ,
                                              A1997UniAbr ,
                                              A2000UniSunat } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV55Configuracion_unidadmedidawwds_3_unidsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Configuracion_unidadmedidawwds_3_unidsc1), 100, "%");
         lV55Configuracion_unidadmedidawwds_3_unidsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Configuracion_unidadmedidawwds_3_unidsc1), 100, "%");
         lV59Configuracion_unidadmedidawwds_7_unidsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_unidadmedidawwds_7_unidsc2), 100, "%");
         lV59Configuracion_unidadmedidawwds_7_unidsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_unidadmedidawwds_7_unidsc2), 100, "%");
         lV63Configuracion_unidadmedidawwds_11_unidsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_unidadmedidawwds_11_unidsc3), 100, "%");
         lV63Configuracion_unidadmedidawwds_11_unidsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_unidadmedidawwds_11_unidsc3), 100, "%");
         lV66Configuracion_unidadmedidawwds_14_tfunidsc = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_unidadmedidawwds_14_tfunidsc), 100, "%");
         lV68Configuracion_unidadmedidawwds_16_tfuniabr = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_unidadmedidawwds_16_tfuniabr), 5, "%");
         lV70Configuracion_unidadmedidawwds_18_tfunisunat = StringUtil.Concat( StringUtil.RTrim( AV70Configuracion_unidadmedidawwds_18_tfunisunat), "%", "");
         /* Using cursor P002P3 */
         pr_default.execute(1, new Object[] {lV55Configuracion_unidadmedidawwds_3_unidsc1, lV55Configuracion_unidadmedidawwds_3_unidsc1, lV59Configuracion_unidadmedidawwds_7_unidsc2, lV59Configuracion_unidadmedidawwds_7_unidsc2, lV63Configuracion_unidadmedidawwds_11_unidsc3, lV63Configuracion_unidadmedidawwds_11_unidsc3, AV64Configuracion_unidadmedidawwds_12_tfunicod, AV65Configuracion_unidadmedidawwds_13_tfunicod_to, lV66Configuracion_unidadmedidawwds_14_tfunidsc, AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel, lV68Configuracion_unidadmedidawwds_16_tfuniabr, AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel, lV70Configuracion_unidadmedidawwds_18_tfunisunat, AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2P4 = false;
            A1997UniAbr = P002P3_A1997UniAbr[0];
            A1999UniSts = P002P3_A1999UniSts[0];
            A2000UniSunat = P002P3_A2000UniSunat[0];
            A49UniCod = P002P3_A49UniCod[0];
            A1998UniDsc = P002P3_A1998UniDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002P3_A1997UniAbr[0], A1997UniAbr) == 0 ) )
            {
               BRK2P4 = false;
               A49UniCod = P002P3_A49UniCod[0];
               AV32count = (long)(AV32count+1);
               BRK2P4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1997UniAbr)) )
            {
               AV24Option = A1997UniAbr;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK2P4 )
            {
               BRK2P4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADUNISUNATOPTIONS' Routine */
         returnInSub = false;
         AV16TFUniSunat = AV20SearchTxt;
         AV17TFUniSunat_Sel = "";
         AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV55Configuracion_unidadmedidawwds_3_unidsc1 = AV40UniDsc1;
         AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV59Configuracion_unidadmedidawwds_7_unidsc2 = AV44UniDsc2;
         AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV63Configuracion_unidadmedidawwds_11_unidsc3 = AV48UniDsc3;
         AV64Configuracion_unidadmedidawwds_12_tfunicod = AV10TFUniCod;
         AV65Configuracion_unidadmedidawwds_13_tfunicod_to = AV11TFUniCod_To;
         AV66Configuracion_unidadmedidawwds_14_tfunidsc = AV12TFUniDsc;
         AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel = AV13TFUniDsc_Sel;
         AV68Configuracion_unidadmedidawwds_16_tfuniabr = AV14TFUniAbr;
         AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel = AV15TFUniAbr_Sel;
         AV70Configuracion_unidadmedidawwds_18_tfunisunat = AV16TFUniSunat;
         AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel = AV17TFUniSunat_Sel;
         AV72Configuracion_unidadmedidawwds_20_tfunists_sels = AV19TFUniSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A1999UniSts ,
                                              AV72Configuracion_unidadmedidawwds_20_tfunists_sels ,
                                              AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 ,
                                              AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 ,
                                              AV55Configuracion_unidadmedidawwds_3_unidsc1 ,
                                              AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 ,
                                              AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 ,
                                              AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 ,
                                              AV59Configuracion_unidadmedidawwds_7_unidsc2 ,
                                              AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 ,
                                              AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 ,
                                              AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 ,
                                              AV63Configuracion_unidadmedidawwds_11_unidsc3 ,
                                              AV64Configuracion_unidadmedidawwds_12_tfunicod ,
                                              AV65Configuracion_unidadmedidawwds_13_tfunicod_to ,
                                              AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel ,
                                              AV66Configuracion_unidadmedidawwds_14_tfunidsc ,
                                              AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel ,
                                              AV68Configuracion_unidadmedidawwds_16_tfuniabr ,
                                              AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel ,
                                              AV70Configuracion_unidadmedidawwds_18_tfunisunat ,
                                              AV72Configuracion_unidadmedidawwds_20_tfunists_sels.Count ,
                                              A1998UniDsc ,
                                              A49UniCod ,
                                              A1997UniAbr ,
                                              A2000UniSunat } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV55Configuracion_unidadmedidawwds_3_unidsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Configuracion_unidadmedidawwds_3_unidsc1), 100, "%");
         lV55Configuracion_unidadmedidawwds_3_unidsc1 = StringUtil.PadR( StringUtil.RTrim( AV55Configuracion_unidadmedidawwds_3_unidsc1), 100, "%");
         lV59Configuracion_unidadmedidawwds_7_unidsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_unidadmedidawwds_7_unidsc2), 100, "%");
         lV59Configuracion_unidadmedidawwds_7_unidsc2 = StringUtil.PadR( StringUtil.RTrim( AV59Configuracion_unidadmedidawwds_7_unidsc2), 100, "%");
         lV63Configuracion_unidadmedidawwds_11_unidsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_unidadmedidawwds_11_unidsc3), 100, "%");
         lV63Configuracion_unidadmedidawwds_11_unidsc3 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_unidadmedidawwds_11_unidsc3), 100, "%");
         lV66Configuracion_unidadmedidawwds_14_tfunidsc = StringUtil.PadR( StringUtil.RTrim( AV66Configuracion_unidadmedidawwds_14_tfunidsc), 100, "%");
         lV68Configuracion_unidadmedidawwds_16_tfuniabr = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_unidadmedidawwds_16_tfuniabr), 5, "%");
         lV70Configuracion_unidadmedidawwds_18_tfunisunat = StringUtil.Concat( StringUtil.RTrim( AV70Configuracion_unidadmedidawwds_18_tfunisunat), "%", "");
         /* Using cursor P002P4 */
         pr_default.execute(2, new Object[] {lV55Configuracion_unidadmedidawwds_3_unidsc1, lV55Configuracion_unidadmedidawwds_3_unidsc1, lV59Configuracion_unidadmedidawwds_7_unidsc2, lV59Configuracion_unidadmedidawwds_7_unidsc2, lV63Configuracion_unidadmedidawwds_11_unidsc3, lV63Configuracion_unidadmedidawwds_11_unidsc3, AV64Configuracion_unidadmedidawwds_12_tfunicod, AV65Configuracion_unidadmedidawwds_13_tfunicod_to, lV66Configuracion_unidadmedidawwds_14_tfunidsc, AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel, lV68Configuracion_unidadmedidawwds_16_tfuniabr, AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel, lV70Configuracion_unidadmedidawwds_18_tfunisunat, AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2P6 = false;
            A2000UniSunat = P002P4_A2000UniSunat[0];
            A1999UniSts = P002P4_A1999UniSts[0];
            A1997UniAbr = P002P4_A1997UniAbr[0];
            A49UniCod = P002P4_A49UniCod[0];
            A1998UniDsc = P002P4_A1998UniDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P002P4_A2000UniSunat[0], A2000UniSunat) == 0 ) )
            {
               BRK2P6 = false;
               A49UniCod = P002P4_A49UniCod[0];
               AV32count = (long)(AV32count+1);
               BRK2P6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2000UniSunat)) )
            {
               AV24Option = A2000UniSunat;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK2P6 )
            {
               BRK2P6 = true;
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
         AV26OptionsJson = "";
         AV29OptionsDescJson = "";
         AV31OptionIndexesJson = "";
         AV25Options = new GxSimpleCollection<string>();
         AV28OptionsDesc = new GxSimpleCollection<string>();
         AV30OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV33Session = context.GetSession();
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV12TFUniDsc = "";
         AV13TFUniDsc_Sel = "";
         AV14TFUniAbr = "";
         AV15TFUniAbr_Sel = "";
         AV16TFUniSunat = "";
         AV17TFUniSunat_Sel = "";
         AV18TFUniSts_SelsJson = "";
         AV19TFUniSts_Sels = new GxSimpleCollection<short>();
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40UniDsc1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44UniDsc2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48UniDsc3 = "";
         AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 = "";
         AV55Configuracion_unidadmedidawwds_3_unidsc1 = "";
         AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 = "";
         AV59Configuracion_unidadmedidawwds_7_unidsc2 = "";
         AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 = "";
         AV63Configuracion_unidadmedidawwds_11_unidsc3 = "";
         AV66Configuracion_unidadmedidawwds_14_tfunidsc = "";
         AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel = "";
         AV68Configuracion_unidadmedidawwds_16_tfuniabr = "";
         AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel = "";
         AV70Configuracion_unidadmedidawwds_18_tfunisunat = "";
         AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel = "";
         AV72Configuracion_unidadmedidawwds_20_tfunists_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV55Configuracion_unidadmedidawwds_3_unidsc1 = "";
         lV59Configuracion_unidadmedidawwds_7_unidsc2 = "";
         lV63Configuracion_unidadmedidawwds_11_unidsc3 = "";
         lV66Configuracion_unidadmedidawwds_14_tfunidsc = "";
         lV68Configuracion_unidadmedidawwds_16_tfuniabr = "";
         lV70Configuracion_unidadmedidawwds_18_tfunisunat = "";
         A1998UniDsc = "";
         A1997UniAbr = "";
         A2000UniSunat = "";
         P002P2_A1998UniDsc = new string[] {""} ;
         P002P2_A1999UniSts = new short[1] ;
         P002P2_A2000UniSunat = new string[] {""} ;
         P002P2_A1997UniAbr = new string[] {""} ;
         P002P2_A49UniCod = new int[1] ;
         AV24Option = "";
         P002P3_A1997UniAbr = new string[] {""} ;
         P002P3_A1999UniSts = new short[1] ;
         P002P3_A2000UniSunat = new string[] {""} ;
         P002P3_A49UniCod = new int[1] ;
         P002P3_A1998UniDsc = new string[] {""} ;
         P002P4_A2000UniSunat = new string[] {""} ;
         P002P4_A1999UniSts = new short[1] ;
         P002P4_A1997UniAbr = new string[] {""} ;
         P002P4_A49UniCod = new int[1] ;
         P002P4_A1998UniDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.unidadmedidawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002P2_A1998UniDsc, P002P2_A1999UniSts, P002P2_A2000UniSunat, P002P2_A1997UniAbr, P002P2_A49UniCod
               }
               , new Object[] {
               P002P3_A1997UniAbr, P002P3_A1999UniSts, P002P3_A2000UniSunat, P002P3_A49UniCod, P002P3_A1998UniDsc
               }
               , new Object[] {
               P002P4_A2000UniSunat, P002P4_A1999UniSts, P002P4_A1997UniAbr, P002P4_A49UniCod, P002P4_A1998UniDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 ;
      private short AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 ;
      private short AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 ;
      private short A1999UniSts ;
      private int AV51GXV1 ;
      private int AV10TFUniCod ;
      private int AV11TFUniCod_To ;
      private int AV64Configuracion_unidadmedidawwds_12_tfunicod ;
      private int AV65Configuracion_unidadmedidawwds_13_tfunicod_to ;
      private int AV72Configuracion_unidadmedidawwds_20_tfunists_sels_Count ;
      private int A49UniCod ;
      private long AV32count ;
      private string AV12TFUniDsc ;
      private string AV13TFUniDsc_Sel ;
      private string AV14TFUniAbr ;
      private string AV15TFUniAbr_Sel ;
      private string AV40UniDsc1 ;
      private string AV44UniDsc2 ;
      private string AV48UniDsc3 ;
      private string AV55Configuracion_unidadmedidawwds_3_unidsc1 ;
      private string AV59Configuracion_unidadmedidawwds_7_unidsc2 ;
      private string AV63Configuracion_unidadmedidawwds_11_unidsc3 ;
      private string AV66Configuracion_unidadmedidawwds_14_tfunidsc ;
      private string AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel ;
      private string AV68Configuracion_unidadmedidawwds_16_tfuniabr ;
      private string AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel ;
      private string scmdbuf ;
      private string lV55Configuracion_unidadmedidawwds_3_unidsc1 ;
      private string lV59Configuracion_unidadmedidawwds_7_unidsc2 ;
      private string lV63Configuracion_unidadmedidawwds_11_unidsc3 ;
      private string lV66Configuracion_unidadmedidawwds_14_tfunidsc ;
      private string lV68Configuracion_unidadmedidawwds_16_tfuniabr ;
      private string A1998UniDsc ;
      private string A1997UniAbr ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 ;
      private bool AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 ;
      private bool BRK2P2 ;
      private bool BRK2P4 ;
      private bool BRK2P6 ;
      private string AV26OptionsJson ;
      private string AV29OptionsDescJson ;
      private string AV31OptionIndexesJson ;
      private string AV18TFUniSts_SelsJson ;
      private string AV22DDOName ;
      private string AV20SearchTxt ;
      private string AV21SearchTxtTo ;
      private string AV16TFUniSunat ;
      private string AV17TFUniSunat_Sel ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 ;
      private string AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 ;
      private string AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 ;
      private string AV70Configuracion_unidadmedidawwds_18_tfunisunat ;
      private string AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel ;
      private string lV70Configuracion_unidadmedidawwds_18_tfunisunat ;
      private string A2000UniSunat ;
      private string AV24Option ;
      private GxSimpleCollection<short> AV19TFUniSts_Sels ;
      private GxSimpleCollection<short> AV72Configuracion_unidadmedidawwds_20_tfunists_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P002P2_A1998UniDsc ;
      private short[] P002P2_A1999UniSts ;
      private string[] P002P2_A2000UniSunat ;
      private string[] P002P2_A1997UniAbr ;
      private int[] P002P2_A49UniCod ;
      private string[] P002P3_A1997UniAbr ;
      private short[] P002P3_A1999UniSts ;
      private string[] P002P3_A2000UniSunat ;
      private int[] P002P3_A49UniCod ;
      private string[] P002P3_A1998UniDsc ;
      private string[] P002P4_A2000UniSunat ;
      private short[] P002P4_A1999UniSts ;
      private string[] P002P4_A1997UniAbr ;
      private int[] P002P4_A49UniCod ;
      private string[] P002P4_A1998UniDsc ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV28OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV37GridStateDynamicFilter ;
   }

   public class unidadmedidawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002P2( IGxContext context ,
                                             short A1999UniSts ,
                                             GxSimpleCollection<short> AV72Configuracion_unidadmedidawwds_20_tfunists_sels ,
                                             string AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 ,
                                             short AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 ,
                                             string AV55Configuracion_unidadmedidawwds_3_unidsc1 ,
                                             bool AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 ,
                                             string AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 ,
                                             short AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 ,
                                             string AV59Configuracion_unidadmedidawwds_7_unidsc2 ,
                                             bool AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 ,
                                             string AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 ,
                                             short AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 ,
                                             string AV63Configuracion_unidadmedidawwds_11_unidsc3 ,
                                             int AV64Configuracion_unidadmedidawwds_12_tfunicod ,
                                             int AV65Configuracion_unidadmedidawwds_13_tfunicod_to ,
                                             string AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel ,
                                             string AV66Configuracion_unidadmedidawwds_14_tfunidsc ,
                                             string AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel ,
                                             string AV68Configuracion_unidadmedidawwds_16_tfuniabr ,
                                             string AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel ,
                                             string AV70Configuracion_unidadmedidawwds_18_tfunisunat ,
                                             int AV72Configuracion_unidadmedidawwds_20_tfunists_sels_Count ,
                                             string A1998UniDsc ,
                                             int A49UniCod ,
                                             string A1997UniAbr ,
                                             string A2000UniSunat )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[14];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [UniDsc], [UniSts], [UniSunat], [UniAbr], [UniCod] FROM [CUNIDADMEDIDA]";
         if ( ( StringUtil.StrCmp(AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1, "UNIDSC") == 0 ) && ( AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_unidadmedidawwds_3_unidsc1)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV55Configuracion_unidadmedidawwds_3_unidsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1, "UNIDSC") == 0 ) && ( AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_unidadmedidawwds_3_unidsc1)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV55Configuracion_unidadmedidawwds_3_unidsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2, "UNIDSC") == 0 ) && ( AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_unidadmedidawwds_7_unidsc2)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV59Configuracion_unidadmedidawwds_7_unidsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2, "UNIDSC") == 0 ) && ( AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_unidadmedidawwds_7_unidsc2)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV59Configuracion_unidadmedidawwds_7_unidsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3, "UNIDSC") == 0 ) && ( AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_unidadmedidawwds_11_unidsc3)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV63Configuracion_unidadmedidawwds_11_unidsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3, "UNIDSC") == 0 ) && ( AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_unidadmedidawwds_11_unidsc3)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV63Configuracion_unidadmedidawwds_11_unidsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV64Configuracion_unidadmedidawwds_12_tfunicod) )
         {
            AddWhere(sWhereString, "([UniCod] >= @AV64Configuracion_unidadmedidawwds_12_tfunicod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV65Configuracion_unidadmedidawwds_13_tfunicod_to) )
         {
            AddWhere(sWhereString, "([UniCod] <= @AV65Configuracion_unidadmedidawwds_13_tfunicod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_unidadmedidawwds_14_tfunidsc)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV66Configuracion_unidadmedidawwds_14_tfunidsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel)) )
         {
            AddWhere(sWhereString, "([UniDsc] = @AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_unidadmedidawwds_16_tfuniabr)) ) )
         {
            AddWhere(sWhereString, "([UniAbr] like @lV68Configuracion_unidadmedidawwds_16_tfuniabr)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel)) )
         {
            AddWhere(sWhereString, "([UniAbr] = @AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_unidadmedidawwds_18_tfunisunat)) ) )
         {
            AddWhere(sWhereString, "([UniSunat] like @lV70Configuracion_unidadmedidawwds_18_tfunisunat)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel)) )
         {
            AddWhere(sWhereString, "([UniSunat] = @AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV72Configuracion_unidadmedidawwds_20_tfunists_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Configuracion_unidadmedidawwds_20_tfunists_sels, "[UniSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [UniDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P002P3( IGxContext context ,
                                             short A1999UniSts ,
                                             GxSimpleCollection<short> AV72Configuracion_unidadmedidawwds_20_tfunists_sels ,
                                             string AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 ,
                                             short AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 ,
                                             string AV55Configuracion_unidadmedidawwds_3_unidsc1 ,
                                             bool AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 ,
                                             string AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 ,
                                             short AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 ,
                                             string AV59Configuracion_unidadmedidawwds_7_unidsc2 ,
                                             bool AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 ,
                                             string AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 ,
                                             short AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 ,
                                             string AV63Configuracion_unidadmedidawwds_11_unidsc3 ,
                                             int AV64Configuracion_unidadmedidawwds_12_tfunicod ,
                                             int AV65Configuracion_unidadmedidawwds_13_tfunicod_to ,
                                             string AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel ,
                                             string AV66Configuracion_unidadmedidawwds_14_tfunidsc ,
                                             string AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel ,
                                             string AV68Configuracion_unidadmedidawwds_16_tfuniabr ,
                                             string AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel ,
                                             string AV70Configuracion_unidadmedidawwds_18_tfunisunat ,
                                             int AV72Configuracion_unidadmedidawwds_20_tfunists_sels_Count ,
                                             string A1998UniDsc ,
                                             int A49UniCod ,
                                             string A1997UniAbr ,
                                             string A2000UniSunat )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[14];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [UniAbr], [UniSts], [UniSunat], [UniCod], [UniDsc] FROM [CUNIDADMEDIDA]";
         if ( ( StringUtil.StrCmp(AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1, "UNIDSC") == 0 ) && ( AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_unidadmedidawwds_3_unidsc1)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV55Configuracion_unidadmedidawwds_3_unidsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1, "UNIDSC") == 0 ) && ( AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_unidadmedidawwds_3_unidsc1)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV55Configuracion_unidadmedidawwds_3_unidsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2, "UNIDSC") == 0 ) && ( AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_unidadmedidawwds_7_unidsc2)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV59Configuracion_unidadmedidawwds_7_unidsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2, "UNIDSC") == 0 ) && ( AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_unidadmedidawwds_7_unidsc2)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV59Configuracion_unidadmedidawwds_7_unidsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3, "UNIDSC") == 0 ) && ( AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_unidadmedidawwds_11_unidsc3)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV63Configuracion_unidadmedidawwds_11_unidsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3, "UNIDSC") == 0 ) && ( AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_unidadmedidawwds_11_unidsc3)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV63Configuracion_unidadmedidawwds_11_unidsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV64Configuracion_unidadmedidawwds_12_tfunicod) )
         {
            AddWhere(sWhereString, "([UniCod] >= @AV64Configuracion_unidadmedidawwds_12_tfunicod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV65Configuracion_unidadmedidawwds_13_tfunicod_to) )
         {
            AddWhere(sWhereString, "([UniCod] <= @AV65Configuracion_unidadmedidawwds_13_tfunicod_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_unidadmedidawwds_14_tfunidsc)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV66Configuracion_unidadmedidawwds_14_tfunidsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel)) )
         {
            AddWhere(sWhereString, "([UniDsc] = @AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_unidadmedidawwds_16_tfuniabr)) ) )
         {
            AddWhere(sWhereString, "([UniAbr] like @lV68Configuracion_unidadmedidawwds_16_tfuniabr)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel)) )
         {
            AddWhere(sWhereString, "([UniAbr] = @AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_unidadmedidawwds_18_tfunisunat)) ) )
         {
            AddWhere(sWhereString, "([UniSunat] like @lV70Configuracion_unidadmedidawwds_18_tfunisunat)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel)) )
         {
            AddWhere(sWhereString, "([UniSunat] = @AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV72Configuracion_unidadmedidawwds_20_tfunists_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Configuracion_unidadmedidawwds_20_tfunists_sels, "[UniSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [UniAbr]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P002P4( IGxContext context ,
                                             short A1999UniSts ,
                                             GxSimpleCollection<short> AV72Configuracion_unidadmedidawwds_20_tfunists_sels ,
                                             string AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1 ,
                                             short AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 ,
                                             string AV55Configuracion_unidadmedidawwds_3_unidsc1 ,
                                             bool AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 ,
                                             string AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2 ,
                                             short AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 ,
                                             string AV59Configuracion_unidadmedidawwds_7_unidsc2 ,
                                             bool AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 ,
                                             string AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3 ,
                                             short AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 ,
                                             string AV63Configuracion_unidadmedidawwds_11_unidsc3 ,
                                             int AV64Configuracion_unidadmedidawwds_12_tfunicod ,
                                             int AV65Configuracion_unidadmedidawwds_13_tfunicod_to ,
                                             string AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel ,
                                             string AV66Configuracion_unidadmedidawwds_14_tfunidsc ,
                                             string AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel ,
                                             string AV68Configuracion_unidadmedidawwds_16_tfuniabr ,
                                             string AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel ,
                                             string AV70Configuracion_unidadmedidawwds_18_tfunisunat ,
                                             int AV72Configuracion_unidadmedidawwds_20_tfunists_sels_Count ,
                                             string A1998UniDsc ,
                                             int A49UniCod ,
                                             string A1997UniAbr ,
                                             string A2000UniSunat )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[14];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [UniSunat], [UniSts], [UniAbr], [UniCod], [UniDsc] FROM [CUNIDADMEDIDA]";
         if ( ( StringUtil.StrCmp(AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1, "UNIDSC") == 0 ) && ( AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_unidadmedidawwds_3_unidsc1)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV55Configuracion_unidadmedidawwds_3_unidsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Configuracion_unidadmedidawwds_1_dynamicfiltersselector1, "UNIDSC") == 0 ) && ( AV54Configuracion_unidadmedidawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Configuracion_unidadmedidawwds_3_unidsc1)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV55Configuracion_unidadmedidawwds_3_unidsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2, "UNIDSC") == 0 ) && ( AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_unidadmedidawwds_7_unidsc2)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV59Configuracion_unidadmedidawwds_7_unidsc2)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV56Configuracion_unidadmedidawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Configuracion_unidadmedidawwds_5_dynamicfiltersselector2, "UNIDSC") == 0 ) && ( AV58Configuracion_unidadmedidawwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_unidadmedidawwds_7_unidsc2)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV59Configuracion_unidadmedidawwds_7_unidsc2)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3, "UNIDSC") == 0 ) && ( AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_unidadmedidawwds_11_unidsc3)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV63Configuracion_unidadmedidawwds_11_unidsc3)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV60Configuracion_unidadmedidawwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Configuracion_unidadmedidawwds_9_dynamicfiltersselector3, "UNIDSC") == 0 ) && ( AV62Configuracion_unidadmedidawwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_unidadmedidawwds_11_unidsc3)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like '%' + @lV63Configuracion_unidadmedidawwds_11_unidsc3)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV64Configuracion_unidadmedidawwds_12_tfunicod) )
         {
            AddWhere(sWhereString, "([UniCod] >= @AV64Configuracion_unidadmedidawwds_12_tfunicod)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV65Configuracion_unidadmedidawwds_13_tfunicod_to) )
         {
            AddWhere(sWhereString, "([UniCod] <= @AV65Configuracion_unidadmedidawwds_13_tfunicod_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_unidadmedidawwds_14_tfunidsc)) ) )
         {
            AddWhere(sWhereString, "([UniDsc] like @lV66Configuracion_unidadmedidawwds_14_tfunidsc)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel)) )
         {
            AddWhere(sWhereString, "([UniDsc] = @AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_unidadmedidawwds_16_tfuniabr)) ) )
         {
            AddWhere(sWhereString, "([UniAbr] like @lV68Configuracion_unidadmedidawwds_16_tfuniabr)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel)) )
         {
            AddWhere(sWhereString, "([UniAbr] = @AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_unidadmedidawwds_18_tfunisunat)) ) )
         {
            AddWhere(sWhereString, "([UniSunat] like @lV70Configuracion_unidadmedidawwds_18_tfunisunat)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel)) )
         {
            AddWhere(sWhereString, "([UniSunat] = @AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV72Configuracion_unidadmedidawwds_20_tfunists_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Configuracion_unidadmedidawwds_20_tfunists_sels, "[UniSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [UniSunat]";
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
                     return conditional_P002P2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
               case 1 :
                     return conditional_P002P3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
               case 2 :
                     return conditional_P002P4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
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
          Object[] prmP002P2;
          prmP002P2 = new Object[] {
          new ParDef("@lV55Configuracion_unidadmedidawwds_3_unidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV55Configuracion_unidadmedidawwds_3_unidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_unidadmedidawwds_7_unidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_unidadmedidawwds_7_unidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_unidadmedidawwds_11_unidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_unidadmedidawwds_11_unidsc3",GXType.NChar,100,0) ,
          new ParDef("@AV64Configuracion_unidadmedidawwds_12_tfunicod",GXType.Int32,6,0) ,
          new ParDef("@AV65Configuracion_unidadmedidawwds_13_tfunicod_to",GXType.Int32,6,0) ,
          new ParDef("@lV66Configuracion_unidadmedidawwds_14_tfunidsc",GXType.NChar,100,0) ,
          new ParDef("@AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_unidadmedidawwds_16_tfuniabr",GXType.NChar,5,0) ,
          new ParDef("@AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV70Configuracion_unidadmedidawwds_18_tfunisunat",GXType.NVarChar,5,0) ,
          new ParDef("@AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel",GXType.NVarChar,5,0)
          };
          Object[] prmP002P3;
          prmP002P3 = new Object[] {
          new ParDef("@lV55Configuracion_unidadmedidawwds_3_unidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV55Configuracion_unidadmedidawwds_3_unidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_unidadmedidawwds_7_unidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_unidadmedidawwds_7_unidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_unidadmedidawwds_11_unidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_unidadmedidawwds_11_unidsc3",GXType.NChar,100,0) ,
          new ParDef("@AV64Configuracion_unidadmedidawwds_12_tfunicod",GXType.Int32,6,0) ,
          new ParDef("@AV65Configuracion_unidadmedidawwds_13_tfunicod_to",GXType.Int32,6,0) ,
          new ParDef("@lV66Configuracion_unidadmedidawwds_14_tfunidsc",GXType.NChar,100,0) ,
          new ParDef("@AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_unidadmedidawwds_16_tfuniabr",GXType.NChar,5,0) ,
          new ParDef("@AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV70Configuracion_unidadmedidawwds_18_tfunisunat",GXType.NVarChar,5,0) ,
          new ParDef("@AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel",GXType.NVarChar,5,0)
          };
          Object[] prmP002P4;
          prmP002P4 = new Object[] {
          new ParDef("@lV55Configuracion_unidadmedidawwds_3_unidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV55Configuracion_unidadmedidawwds_3_unidsc1",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_unidadmedidawwds_7_unidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV59Configuracion_unidadmedidawwds_7_unidsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_unidadmedidawwds_11_unidsc3",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_unidadmedidawwds_11_unidsc3",GXType.NChar,100,0) ,
          new ParDef("@AV64Configuracion_unidadmedidawwds_12_tfunicod",GXType.Int32,6,0) ,
          new ParDef("@AV65Configuracion_unidadmedidawwds_13_tfunicod_to",GXType.Int32,6,0) ,
          new ParDef("@lV66Configuracion_unidadmedidawwds_14_tfunidsc",GXType.NChar,100,0) ,
          new ParDef("@AV67Configuracion_unidadmedidawwds_15_tfunidsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_unidadmedidawwds_16_tfuniabr",GXType.NChar,5,0) ,
          new ParDef("@AV69Configuracion_unidadmedidawwds_17_tfuniabr_sel",GXType.NChar,5,0) ,
          new ParDef("@lV70Configuracion_unidadmedidawwds_18_tfunisunat",GXType.NVarChar,5,0) ,
          new ParDef("@AV71Configuracion_unidadmedidawwds_19_tfunisunat_sel",GXType.NVarChar,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002P2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002P2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002P3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002P3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002P4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002P4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 5);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 5);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
