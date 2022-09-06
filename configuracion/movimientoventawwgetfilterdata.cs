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
   public class movimientoventawwgetfilterdata : GXProcedure
   {
      public movimientoventawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public movimientoventawwgetfilterdata( IGxContext context )
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
         movimientoventawwgetfilterdata objmovimientoventawwgetfilterdata;
         objmovimientoventawwgetfilterdata = new movimientoventawwgetfilterdata();
         objmovimientoventawwgetfilterdata.AV22DDOName = aP0_DDOName;
         objmovimientoventawwgetfilterdata.AV20SearchTxt = aP1_SearchTxt;
         objmovimientoventawwgetfilterdata.AV21SearchTxtTo = aP2_SearchTxtTo;
         objmovimientoventawwgetfilterdata.AV26OptionsJson = "" ;
         objmovimientoventawwgetfilterdata.AV29OptionsDescJson = "" ;
         objmovimientoventawwgetfilterdata.AV31OptionIndexesJson = "" ;
         objmovimientoventawwgetfilterdata.context.SetSubmitInitialConfig(context);
         objmovimientoventawwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmovimientoventawwgetfilterdata);
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((movimientoventawwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_MOVVDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADMOVVDSCOPTIONS' */
            S121 ();
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
         if ( StringUtil.StrCmp(AV33Session.Get("Configuracion.MovimientoVentaWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.MovimientoVentaWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Configuracion.MovimientoVentaWWGridState"), null, "", "");
         }
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV54GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMOVVCOD") == 0 )
            {
               AV10TFMovVCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV11TFMovVCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMOVVDSC") == 0 )
            {
               AV12TFMovVDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMOVVDSC_SEL") == 0 )
            {
               AV13TFMovVDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMOVVABR_SEL") == 0 )
            {
               AV14TFMovVAbr_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV15TFMovVAbr_Sels.FromJSonString(AV14TFMovVAbr_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMOVVTIP_SEL") == 0 )
            {
               AV16TFMovVTip_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV17TFMovVTip_Sels.FromJSonString(AV16TFMovVTip_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFMOVVSTS_SEL") == 0 )
            {
               AV18TFMovVSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV19TFMovVSts_Sels.FromJSonString(AV18TFMovVSts_SelsJson, null);
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "MOVVDSC") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV40MovVDsc1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "MOVVTIP") == 0 )
            {
               AV49MovVTip1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "MOVVDSC") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV44MovVDsc2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "MOVVTIP") == 0 )
               {
                  AV50MovVTip2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "MOVVDSC") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV48MovVDsc3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "MOVVTIP") == 0 )
                  {
                     AV51MovVTip3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADMOVVDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFMovVDsc = AV20SearchTxt;
         AV13TFMovVDsc_Sel = "";
         AV56Configuracion_movimientoventawwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV57Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV58Configuracion_movimientoventawwds_3_movvdsc1 = AV40MovVDsc1;
         AV59Configuracion_movimientoventawwds_4_movvtip1 = AV49MovVTip1;
         AV60Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV61Configuracion_movimientoventawwds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV62Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV63Configuracion_movimientoventawwds_8_movvdsc2 = AV44MovVDsc2;
         AV64Configuracion_movimientoventawwds_9_movvtip2 = AV50MovVTip2;
         AV65Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV66Configuracion_movimientoventawwds_11_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV67Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV68Configuracion_movimientoventawwds_13_movvdsc3 = AV48MovVDsc3;
         AV69Configuracion_movimientoventawwds_14_movvtip3 = AV51MovVTip3;
         AV70Configuracion_movimientoventawwds_15_tfmovvcod = AV10TFMovVCod;
         AV71Configuracion_movimientoventawwds_16_tfmovvcod_to = AV11TFMovVCod_To;
         AV72Configuracion_movimientoventawwds_17_tfmovvdsc = AV12TFMovVDsc;
         AV73Configuracion_movimientoventawwds_18_tfmovvdsc_sel = AV13TFMovVDsc_Sel;
         AV74Configuracion_movimientoventawwds_19_tfmovvabr_sels = AV15TFMovVAbr_Sels;
         AV75Configuracion_movimientoventawwds_20_tfmovvtip_sels = AV17TFMovVTip_Sels;
         AV76Configuracion_movimientoventawwds_21_tfmovvsts_sels = AV19TFMovVSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1242MovVAbr ,
                                              AV74Configuracion_movimientoventawwds_19_tfmovvabr_sels ,
                                              A1245MovVTip ,
                                              AV75Configuracion_movimientoventawwds_20_tfmovvtip_sels ,
                                              A1244MovVSts ,
                                              AV76Configuracion_movimientoventawwds_21_tfmovvsts_sels ,
                                              AV56Configuracion_movimientoventawwds_1_dynamicfiltersselector1 ,
                                              AV57Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 ,
                                              AV58Configuracion_movimientoventawwds_3_movvdsc1 ,
                                              AV59Configuracion_movimientoventawwds_4_movvtip1 ,
                                              AV60Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 ,
                                              AV61Configuracion_movimientoventawwds_6_dynamicfiltersselector2 ,
                                              AV62Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 ,
                                              AV63Configuracion_movimientoventawwds_8_movvdsc2 ,
                                              AV64Configuracion_movimientoventawwds_9_movvtip2 ,
                                              AV65Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 ,
                                              AV66Configuracion_movimientoventawwds_11_dynamicfiltersselector3 ,
                                              AV67Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 ,
                                              AV68Configuracion_movimientoventawwds_13_movvdsc3 ,
                                              AV69Configuracion_movimientoventawwds_14_movvtip3 ,
                                              AV70Configuracion_movimientoventawwds_15_tfmovvcod ,
                                              AV71Configuracion_movimientoventawwds_16_tfmovvcod_to ,
                                              AV73Configuracion_movimientoventawwds_18_tfmovvdsc_sel ,
                                              AV72Configuracion_movimientoventawwds_17_tfmovvdsc ,
                                              AV74Configuracion_movimientoventawwds_19_tfmovvabr_sels.Count ,
                                              AV75Configuracion_movimientoventawwds_20_tfmovvtip_sels.Count ,
                                              AV76Configuracion_movimientoventawwds_21_tfmovvsts_sels.Count ,
                                              A1243MovVDsc ,
                                              A235MovVCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV58Configuracion_movimientoventawwds_3_movvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_movimientoventawwds_3_movvdsc1), 100, "%");
         lV58Configuracion_movimientoventawwds_3_movvdsc1 = StringUtil.PadR( StringUtil.RTrim( AV58Configuracion_movimientoventawwds_3_movvdsc1), 100, "%");
         lV63Configuracion_movimientoventawwds_8_movvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_movimientoventawwds_8_movvdsc2), 100, "%");
         lV63Configuracion_movimientoventawwds_8_movvdsc2 = StringUtil.PadR( StringUtil.RTrim( AV63Configuracion_movimientoventawwds_8_movvdsc2), 100, "%");
         lV68Configuracion_movimientoventawwds_13_movvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_movimientoventawwds_13_movvdsc3), 100, "%");
         lV68Configuracion_movimientoventawwds_13_movvdsc3 = StringUtil.PadR( StringUtil.RTrim( AV68Configuracion_movimientoventawwds_13_movvdsc3), 100, "%");
         lV72Configuracion_movimientoventawwds_17_tfmovvdsc = StringUtil.PadR( StringUtil.RTrim( AV72Configuracion_movimientoventawwds_17_tfmovvdsc), 100, "%");
         /* Using cursor P003E2 */
         pr_default.execute(0, new Object[] {lV58Configuracion_movimientoventawwds_3_movvdsc1, lV58Configuracion_movimientoventawwds_3_movvdsc1, AV59Configuracion_movimientoventawwds_4_movvtip1, lV63Configuracion_movimientoventawwds_8_movvdsc2, lV63Configuracion_movimientoventawwds_8_movvdsc2, AV64Configuracion_movimientoventawwds_9_movvtip2, lV68Configuracion_movimientoventawwds_13_movvdsc3, lV68Configuracion_movimientoventawwds_13_movvdsc3, AV69Configuracion_movimientoventawwds_14_movvtip3, AV70Configuracion_movimientoventawwds_15_tfmovvcod, AV71Configuracion_movimientoventawwds_16_tfmovvcod_to, lV72Configuracion_movimientoventawwds_17_tfmovvdsc, AV73Configuracion_movimientoventawwds_18_tfmovvdsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3E2 = false;
            A1243MovVDsc = P003E2_A1243MovVDsc[0];
            A1244MovVSts = P003E2_A1244MovVSts[0];
            A1242MovVAbr = P003E2_A1242MovVAbr[0];
            A235MovVCod = P003E2_A235MovVCod[0];
            A1245MovVTip = P003E2_A1245MovVTip[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P003E2_A1243MovVDsc[0], A1243MovVDsc) == 0 ) )
            {
               BRK3E2 = false;
               A235MovVCod = P003E2_A235MovVCod[0];
               AV32count = (long)(AV32count+1);
               BRK3E2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1243MovVDsc)) )
            {
               AV24Option = A1243MovVDsc;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK3E2 )
            {
               BRK3E2 = true;
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
         AV12TFMovVDsc = "";
         AV13TFMovVDsc_Sel = "";
         AV14TFMovVAbr_SelsJson = "";
         AV15TFMovVAbr_Sels = new GxSimpleCollection<string>();
         AV16TFMovVTip_SelsJson = "";
         AV17TFMovVTip_Sels = new GxSimpleCollection<string>();
         AV18TFMovVSts_SelsJson = "";
         AV19TFMovVSts_Sels = new GxSimpleCollection<short>();
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40MovVDsc1 = "";
         AV49MovVTip1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44MovVDsc2 = "";
         AV50MovVTip2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48MovVDsc3 = "";
         AV51MovVTip3 = "";
         AV56Configuracion_movimientoventawwds_1_dynamicfiltersselector1 = "";
         AV58Configuracion_movimientoventawwds_3_movvdsc1 = "";
         AV59Configuracion_movimientoventawwds_4_movvtip1 = "";
         AV61Configuracion_movimientoventawwds_6_dynamicfiltersselector2 = "";
         AV63Configuracion_movimientoventawwds_8_movvdsc2 = "";
         AV64Configuracion_movimientoventawwds_9_movvtip2 = "";
         AV66Configuracion_movimientoventawwds_11_dynamicfiltersselector3 = "";
         AV68Configuracion_movimientoventawwds_13_movvdsc3 = "";
         AV69Configuracion_movimientoventawwds_14_movvtip3 = "";
         AV72Configuracion_movimientoventawwds_17_tfmovvdsc = "";
         AV73Configuracion_movimientoventawwds_18_tfmovvdsc_sel = "";
         AV74Configuracion_movimientoventawwds_19_tfmovvabr_sels = new GxSimpleCollection<string>();
         AV75Configuracion_movimientoventawwds_20_tfmovvtip_sels = new GxSimpleCollection<string>();
         AV76Configuracion_movimientoventawwds_21_tfmovvsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV58Configuracion_movimientoventawwds_3_movvdsc1 = "";
         lV63Configuracion_movimientoventawwds_8_movvdsc2 = "";
         lV68Configuracion_movimientoventawwds_13_movvdsc3 = "";
         lV72Configuracion_movimientoventawwds_17_tfmovvdsc = "";
         A1242MovVAbr = "";
         A1245MovVTip = "";
         A1243MovVDsc = "";
         P003E2_A1243MovVDsc = new string[] {""} ;
         P003E2_A1244MovVSts = new short[1] ;
         P003E2_A1242MovVAbr = new string[] {""} ;
         P003E2_A235MovVCod = new int[1] ;
         P003E2_A1245MovVTip = new string[] {""} ;
         AV24Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.movimientoventawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003E2_A1243MovVDsc, P003E2_A1244MovVSts, P003E2_A1242MovVAbr, P003E2_A235MovVCod, P003E2_A1245MovVTip
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV57Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 ;
      private short AV62Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 ;
      private short AV67Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 ;
      private short A1244MovVSts ;
      private int AV54GXV1 ;
      private int AV10TFMovVCod ;
      private int AV11TFMovVCod_To ;
      private int AV70Configuracion_movimientoventawwds_15_tfmovvcod ;
      private int AV71Configuracion_movimientoventawwds_16_tfmovvcod_to ;
      private int AV74Configuracion_movimientoventawwds_19_tfmovvabr_sels_Count ;
      private int AV75Configuracion_movimientoventawwds_20_tfmovvtip_sels_Count ;
      private int AV76Configuracion_movimientoventawwds_21_tfmovvsts_sels_Count ;
      private int A235MovVCod ;
      private long AV32count ;
      private string AV12TFMovVDsc ;
      private string AV13TFMovVDsc_Sel ;
      private string AV40MovVDsc1 ;
      private string AV49MovVTip1 ;
      private string AV44MovVDsc2 ;
      private string AV50MovVTip2 ;
      private string AV48MovVDsc3 ;
      private string AV51MovVTip3 ;
      private string AV58Configuracion_movimientoventawwds_3_movvdsc1 ;
      private string AV59Configuracion_movimientoventawwds_4_movvtip1 ;
      private string AV63Configuracion_movimientoventawwds_8_movvdsc2 ;
      private string AV64Configuracion_movimientoventawwds_9_movvtip2 ;
      private string AV68Configuracion_movimientoventawwds_13_movvdsc3 ;
      private string AV69Configuracion_movimientoventawwds_14_movvtip3 ;
      private string AV72Configuracion_movimientoventawwds_17_tfmovvdsc ;
      private string AV73Configuracion_movimientoventawwds_18_tfmovvdsc_sel ;
      private string scmdbuf ;
      private string lV58Configuracion_movimientoventawwds_3_movvdsc1 ;
      private string lV63Configuracion_movimientoventawwds_8_movvdsc2 ;
      private string lV68Configuracion_movimientoventawwds_13_movvdsc3 ;
      private string lV72Configuracion_movimientoventawwds_17_tfmovvdsc ;
      private string A1242MovVAbr ;
      private string A1245MovVTip ;
      private string A1243MovVDsc ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV60Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 ;
      private bool AV65Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 ;
      private bool BRK3E2 ;
      private string AV26OptionsJson ;
      private string AV29OptionsDescJson ;
      private string AV31OptionIndexesJson ;
      private string AV14TFMovVAbr_SelsJson ;
      private string AV16TFMovVTip_SelsJson ;
      private string AV18TFMovVSts_SelsJson ;
      private string AV22DDOName ;
      private string AV20SearchTxt ;
      private string AV21SearchTxtTo ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV56Configuracion_movimientoventawwds_1_dynamicfiltersselector1 ;
      private string AV61Configuracion_movimientoventawwds_6_dynamicfiltersselector2 ;
      private string AV66Configuracion_movimientoventawwds_11_dynamicfiltersselector3 ;
      private string AV24Option ;
      private GxSimpleCollection<short> AV19TFMovVSts_Sels ;
      private GxSimpleCollection<short> AV76Configuracion_movimientoventawwds_21_tfmovvsts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003E2_A1243MovVDsc ;
      private short[] P003E2_A1244MovVSts ;
      private string[] P003E2_A1242MovVAbr ;
      private int[] P003E2_A235MovVCod ;
      private string[] P003E2_A1245MovVTip ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV15TFMovVAbr_Sels ;
      private GxSimpleCollection<string> AV17TFMovVTip_Sels ;
      private GxSimpleCollection<string> AV74Configuracion_movimientoventawwds_19_tfmovvabr_sels ;
      private GxSimpleCollection<string> AV75Configuracion_movimientoventawwds_20_tfmovvtip_sels ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV28OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV37GridStateDynamicFilter ;
   }

   public class movimientoventawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003E2( IGxContext context ,
                                             string A1242MovVAbr ,
                                             GxSimpleCollection<string> AV74Configuracion_movimientoventawwds_19_tfmovvabr_sels ,
                                             string A1245MovVTip ,
                                             GxSimpleCollection<string> AV75Configuracion_movimientoventawwds_20_tfmovvtip_sels ,
                                             short A1244MovVSts ,
                                             GxSimpleCollection<short> AV76Configuracion_movimientoventawwds_21_tfmovvsts_sels ,
                                             string AV56Configuracion_movimientoventawwds_1_dynamicfiltersselector1 ,
                                             short AV57Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 ,
                                             string AV58Configuracion_movimientoventawwds_3_movvdsc1 ,
                                             string AV59Configuracion_movimientoventawwds_4_movvtip1 ,
                                             bool AV60Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 ,
                                             string AV61Configuracion_movimientoventawwds_6_dynamicfiltersselector2 ,
                                             short AV62Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 ,
                                             string AV63Configuracion_movimientoventawwds_8_movvdsc2 ,
                                             string AV64Configuracion_movimientoventawwds_9_movvtip2 ,
                                             bool AV65Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 ,
                                             string AV66Configuracion_movimientoventawwds_11_dynamicfiltersselector3 ,
                                             short AV67Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 ,
                                             string AV68Configuracion_movimientoventawwds_13_movvdsc3 ,
                                             string AV69Configuracion_movimientoventawwds_14_movvtip3 ,
                                             int AV70Configuracion_movimientoventawwds_15_tfmovvcod ,
                                             int AV71Configuracion_movimientoventawwds_16_tfmovvcod_to ,
                                             string AV73Configuracion_movimientoventawwds_18_tfmovvdsc_sel ,
                                             string AV72Configuracion_movimientoventawwds_17_tfmovvdsc ,
                                             int AV74Configuracion_movimientoventawwds_19_tfmovvabr_sels_Count ,
                                             int AV75Configuracion_movimientoventawwds_20_tfmovvtip_sels_Count ,
                                             int AV76Configuracion_movimientoventawwds_21_tfmovvsts_sels_Count ,
                                             string A1243MovVDsc ,
                                             int A235MovVCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[13];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [MovVDsc], [MovVSts], [MovVAbr], [MovVCod], [MovVTip] FROM [CMOVVENTAS]";
         if ( ( StringUtil.StrCmp(AV56Configuracion_movimientoventawwds_1_dynamicfiltersselector1, "MOVVDSC") == 0 ) && ( AV57Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_movimientoventawwds_3_movvdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV58Configuracion_movimientoventawwds_3_movvdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Configuracion_movimientoventawwds_1_dynamicfiltersselector1, "MOVVDSC") == 0 ) && ( AV57Configuracion_movimientoventawwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Configuracion_movimientoventawwds_3_movvdsc1)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like '%' + @lV58Configuracion_movimientoventawwds_3_movvdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Configuracion_movimientoventawwds_1_dynamicfiltersselector1, "MOVVTIP") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Configuracion_movimientoventawwds_4_movvtip1)) ) )
         {
            AddWhere(sWhereString, "([MovVTip] = @AV59Configuracion_movimientoventawwds_4_movvtip1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV60Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_movimientoventawwds_6_dynamicfiltersselector2, "MOVVDSC") == 0 ) && ( AV62Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_movimientoventawwds_8_movvdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV63Configuracion_movimientoventawwds_8_movvdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV60Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_movimientoventawwds_6_dynamicfiltersselector2, "MOVVDSC") == 0 ) && ( AV62Configuracion_movimientoventawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Configuracion_movimientoventawwds_8_movvdsc2)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like '%' + @lV63Configuracion_movimientoventawwds_8_movvdsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV60Configuracion_movimientoventawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Configuracion_movimientoventawwds_6_dynamicfiltersselector2, "MOVVTIP") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_movimientoventawwds_9_movvtip2)) ) )
         {
            AddWhere(sWhereString, "([MovVTip] = @AV64Configuracion_movimientoventawwds_9_movvtip2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV65Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Configuracion_movimientoventawwds_11_dynamicfiltersselector3, "MOVVDSC") == 0 ) && ( AV67Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_movimientoventawwds_13_movvdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV68Configuracion_movimientoventawwds_13_movvdsc3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV65Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Configuracion_movimientoventawwds_11_dynamicfiltersselector3, "MOVVDSC") == 0 ) && ( AV67Configuracion_movimientoventawwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_movimientoventawwds_13_movvdsc3)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like '%' + @lV68Configuracion_movimientoventawwds_13_movvdsc3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV65Configuracion_movimientoventawwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Configuracion_movimientoventawwds_11_dynamicfiltersselector3, "MOVVTIP") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Configuracion_movimientoventawwds_14_movvtip3)) ) )
         {
            AddWhere(sWhereString, "([MovVTip] = @AV69Configuracion_movimientoventawwds_14_movvtip3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV70Configuracion_movimientoventawwds_15_tfmovvcod) )
         {
            AddWhere(sWhereString, "([MovVCod] >= @AV70Configuracion_movimientoventawwds_15_tfmovvcod)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV71Configuracion_movimientoventawwds_16_tfmovvcod_to) )
         {
            AddWhere(sWhereString, "([MovVCod] <= @AV71Configuracion_movimientoventawwds_16_tfmovvcod_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_movimientoventawwds_18_tfmovvdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Configuracion_movimientoventawwds_17_tfmovvdsc)) ) )
         {
            AddWhere(sWhereString, "([MovVDsc] like @lV72Configuracion_movimientoventawwds_17_tfmovvdsc)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configuracion_movimientoventawwds_18_tfmovvdsc_sel)) )
         {
            AddWhere(sWhereString, "([MovVDsc] = @AV73Configuracion_movimientoventawwds_18_tfmovvdsc_sel)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV74Configuracion_movimientoventawwds_19_tfmovvabr_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Configuracion_movimientoventawwds_19_tfmovvabr_sels, "[MovVAbr] IN (", ")")+")");
         }
         if ( AV75Configuracion_movimientoventawwds_20_tfmovvtip_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Configuracion_movimientoventawwds_20_tfmovvtip_sels, "[MovVTip] IN (", ")")+")");
         }
         if ( AV76Configuracion_movimientoventawwds_21_tfmovvsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Configuracion_movimientoventawwds_21_tfmovvsts_sels, "[MovVSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MovVDsc]";
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
                     return conditional_P003E2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (GxSimpleCollection<short>)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (int)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (string)dynConstraints[27] , (int)dynConstraints[28] );
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
          Object[] prmP003E2;
          prmP003E2 = new Object[] {
          new ParDef("@lV58Configuracion_movimientoventawwds_3_movvdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV58Configuracion_movimientoventawwds_3_movvdsc1",GXType.NChar,100,0) ,
          new ParDef("@AV59Configuracion_movimientoventawwds_4_movvtip1",GXType.NChar,1,0) ,
          new ParDef("@lV63Configuracion_movimientoventawwds_8_movvdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV63Configuracion_movimientoventawwds_8_movvdsc2",GXType.NChar,100,0) ,
          new ParDef("@AV64Configuracion_movimientoventawwds_9_movvtip2",GXType.NChar,1,0) ,
          new ParDef("@lV68Configuracion_movimientoventawwds_13_movvdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV68Configuracion_movimientoventawwds_13_movvdsc3",GXType.NChar,100,0) ,
          new ParDef("@AV69Configuracion_movimientoventawwds_14_movvtip3",GXType.NChar,1,0) ,
          new ParDef("@AV70Configuracion_movimientoventawwds_15_tfmovvcod",GXType.Int32,6,0) ,
          new ParDef("@AV71Configuracion_movimientoventawwds_16_tfmovvcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV72Configuracion_movimientoventawwds_17_tfmovvdsc",GXType.NChar,100,0) ,
          new ParDef("@AV73Configuracion_movimientoventawwds_18_tfmovvdsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003E2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 5);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                return;
       }
    }

 }

}
