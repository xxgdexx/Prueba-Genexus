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
   public class maquinaswwgetfilterdata : GXProcedure
   {
      public maquinaswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public maquinaswwgetfilterdata( IGxContext context )
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
         maquinaswwgetfilterdata objmaquinaswwgetfilterdata;
         objmaquinaswwgetfilterdata = new maquinaswwgetfilterdata();
         objmaquinaswwgetfilterdata.AV18DDOName = aP0_DDOName;
         objmaquinaswwgetfilterdata.AV16SearchTxt = aP1_SearchTxt;
         objmaquinaswwgetfilterdata.AV17SearchTxtTo = aP2_SearchTxtTo;
         objmaquinaswwgetfilterdata.AV22OptionsJson = "" ;
         objmaquinaswwgetfilterdata.AV25OptionsDescJson = "" ;
         objmaquinaswwgetfilterdata.AV27OptionIndexesJson = "" ;
         objmaquinaswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objmaquinaswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmaquinaswwgetfilterdata);
         aP3_OptionsJson=this.AV22OptionsJson;
         aP4_OptionsDescJson=this.AV25OptionsDescJson;
         aP5_OptionIndexesJson=this.AV27OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((maquinaswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV18DDOName), "DDO_MAQCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADMAQCODOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV18DDOName), "DDO_MAQDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADMAQDSCOPTIONS' */
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
         if ( StringUtil.StrCmp(AV29Session.Get("Produccion.MaquinasWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Produccion.MaquinasWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("Produccion.MaquinasWWGridState"), null, "", "");
         }
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAQCOD") == 0 )
            {
               AV10TFMAQCod = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAQCOD_SEL") == 0 )
            {
               AV11TFMAQCod_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAQDSC") == 0 )
            {
               AV12TFMAQDsc = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAQDSC_SEL") == 0 )
            {
               AV13TFMAQDsc_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFMAQSTS_SEL") == 0 )
            {
               AV14TFMAQSts_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV15TFMAQSts_Sels.FromJSonString(AV14TFMAQSts_SelsJson, null);
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV34DynamicFiltersSelector1 = AV33GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV34DynamicFiltersSelector1, "MAQDSC") == 0 )
            {
               AV35DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV36MAQDsc1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV37DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV38DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV38DynamicFiltersSelector2, "MAQDSC") == 0 )
               {
                  AV39DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV40MAQDsc2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV41DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV42DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "MAQDSC") == 0 )
                  {
                     AV43DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV44MAQDsc3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADMAQCODOPTIONS' Routine */
         returnInSub = false;
         AV10TFMAQCod = AV16SearchTxt;
         AV11TFMAQCod_Sel = "";
         AV49Produccion_maquinaswwds_1_dynamicfiltersselector1 = AV34DynamicFiltersSelector1;
         AV50Produccion_maquinaswwds_2_dynamicfiltersoperator1 = AV35DynamicFiltersOperator1;
         AV51Produccion_maquinaswwds_3_maqdsc1 = AV36MAQDsc1;
         AV52Produccion_maquinaswwds_4_dynamicfiltersenabled2 = AV37DynamicFiltersEnabled2;
         AV53Produccion_maquinaswwds_5_dynamicfiltersselector2 = AV38DynamicFiltersSelector2;
         AV54Produccion_maquinaswwds_6_dynamicfiltersoperator2 = AV39DynamicFiltersOperator2;
         AV55Produccion_maquinaswwds_7_maqdsc2 = AV40MAQDsc2;
         AV56Produccion_maquinaswwds_8_dynamicfiltersenabled3 = AV41DynamicFiltersEnabled3;
         AV57Produccion_maquinaswwds_9_dynamicfiltersselector3 = AV42DynamicFiltersSelector3;
         AV58Produccion_maquinaswwds_10_dynamicfiltersoperator3 = AV43DynamicFiltersOperator3;
         AV59Produccion_maquinaswwds_11_maqdsc3 = AV44MAQDsc3;
         AV60Produccion_maquinaswwds_12_tfmaqcod = AV10TFMAQCod;
         AV61Produccion_maquinaswwds_13_tfmaqcod_sel = AV11TFMAQCod_Sel;
         AV62Produccion_maquinaswwds_14_tfmaqdsc = AV12TFMAQDsc;
         AV63Produccion_maquinaswwds_15_tfmaqdsc_sel = AV13TFMAQDsc_Sel;
         AV64Produccion_maquinaswwds_16_tfmaqsts_sels = AV15TFMAQSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1221MAQSts ,
                                              AV64Produccion_maquinaswwds_16_tfmaqsts_sels ,
                                              AV49Produccion_maquinaswwds_1_dynamicfiltersselector1 ,
                                              AV50Produccion_maquinaswwds_2_dynamicfiltersoperator1 ,
                                              AV51Produccion_maquinaswwds_3_maqdsc1 ,
                                              AV52Produccion_maquinaswwds_4_dynamicfiltersenabled2 ,
                                              AV53Produccion_maquinaswwds_5_dynamicfiltersselector2 ,
                                              AV54Produccion_maquinaswwds_6_dynamicfiltersoperator2 ,
                                              AV55Produccion_maquinaswwds_7_maqdsc2 ,
                                              AV56Produccion_maquinaswwds_8_dynamicfiltersenabled3 ,
                                              AV57Produccion_maquinaswwds_9_dynamicfiltersselector3 ,
                                              AV58Produccion_maquinaswwds_10_dynamicfiltersoperator3 ,
                                              AV59Produccion_maquinaswwds_11_maqdsc3 ,
                                              AV61Produccion_maquinaswwds_13_tfmaqcod_sel ,
                                              AV60Produccion_maquinaswwds_12_tfmaqcod ,
                                              AV63Produccion_maquinaswwds_15_tfmaqdsc_sel ,
                                              AV62Produccion_maquinaswwds_14_tfmaqdsc ,
                                              AV64Produccion_maquinaswwds_16_tfmaqsts_sels.Count ,
                                              A1220MAQDsc ,
                                              A320MAQCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV51Produccion_maquinaswwds_3_maqdsc1 = StringUtil.PadR( StringUtil.RTrim( AV51Produccion_maquinaswwds_3_maqdsc1), 100, "%");
         lV51Produccion_maquinaswwds_3_maqdsc1 = StringUtil.PadR( StringUtil.RTrim( AV51Produccion_maquinaswwds_3_maqdsc1), 100, "%");
         lV55Produccion_maquinaswwds_7_maqdsc2 = StringUtil.PadR( StringUtil.RTrim( AV55Produccion_maquinaswwds_7_maqdsc2), 100, "%");
         lV55Produccion_maquinaswwds_7_maqdsc2 = StringUtil.PadR( StringUtil.RTrim( AV55Produccion_maquinaswwds_7_maqdsc2), 100, "%");
         lV59Produccion_maquinaswwds_11_maqdsc3 = StringUtil.PadR( StringUtil.RTrim( AV59Produccion_maquinaswwds_11_maqdsc3), 100, "%");
         lV59Produccion_maquinaswwds_11_maqdsc3 = StringUtil.PadR( StringUtil.RTrim( AV59Produccion_maquinaswwds_11_maqdsc3), 100, "%");
         lV60Produccion_maquinaswwds_12_tfmaqcod = StringUtil.PadR( StringUtil.RTrim( AV60Produccion_maquinaswwds_12_tfmaqcod), 10, "%");
         lV62Produccion_maquinaswwds_14_tfmaqdsc = StringUtil.PadR( StringUtil.RTrim( AV62Produccion_maquinaswwds_14_tfmaqdsc), 100, "%");
         /* Using cursor P00622 */
         pr_default.execute(0, new Object[] {lV51Produccion_maquinaswwds_3_maqdsc1, lV51Produccion_maquinaswwds_3_maqdsc1, lV55Produccion_maquinaswwds_7_maqdsc2, lV55Produccion_maquinaswwds_7_maqdsc2, lV59Produccion_maquinaswwds_11_maqdsc3, lV59Produccion_maquinaswwds_11_maqdsc3, lV60Produccion_maquinaswwds_12_tfmaqcod, AV61Produccion_maquinaswwds_13_tfmaqcod_sel, lV62Produccion_maquinaswwds_14_tfmaqdsc, AV63Produccion_maquinaswwds_15_tfmaqdsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1221MAQSts = P00622_A1221MAQSts[0];
            A320MAQCod = P00622_A320MAQCod[0];
            A1220MAQDsc = P00622_A1220MAQDsc[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A320MAQCod)) )
            {
               AV20Option = A320MAQCod;
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
         /* 'LOADMAQDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFMAQDsc = AV16SearchTxt;
         AV13TFMAQDsc_Sel = "";
         AV49Produccion_maquinaswwds_1_dynamicfiltersselector1 = AV34DynamicFiltersSelector1;
         AV50Produccion_maquinaswwds_2_dynamicfiltersoperator1 = AV35DynamicFiltersOperator1;
         AV51Produccion_maquinaswwds_3_maqdsc1 = AV36MAQDsc1;
         AV52Produccion_maquinaswwds_4_dynamicfiltersenabled2 = AV37DynamicFiltersEnabled2;
         AV53Produccion_maquinaswwds_5_dynamicfiltersselector2 = AV38DynamicFiltersSelector2;
         AV54Produccion_maquinaswwds_6_dynamicfiltersoperator2 = AV39DynamicFiltersOperator2;
         AV55Produccion_maquinaswwds_7_maqdsc2 = AV40MAQDsc2;
         AV56Produccion_maquinaswwds_8_dynamicfiltersenabled3 = AV41DynamicFiltersEnabled3;
         AV57Produccion_maquinaswwds_9_dynamicfiltersselector3 = AV42DynamicFiltersSelector3;
         AV58Produccion_maquinaswwds_10_dynamicfiltersoperator3 = AV43DynamicFiltersOperator3;
         AV59Produccion_maquinaswwds_11_maqdsc3 = AV44MAQDsc3;
         AV60Produccion_maquinaswwds_12_tfmaqcod = AV10TFMAQCod;
         AV61Produccion_maquinaswwds_13_tfmaqcod_sel = AV11TFMAQCod_Sel;
         AV62Produccion_maquinaswwds_14_tfmaqdsc = AV12TFMAQDsc;
         AV63Produccion_maquinaswwds_15_tfmaqdsc_sel = AV13TFMAQDsc_Sel;
         AV64Produccion_maquinaswwds_16_tfmaqsts_sels = AV15TFMAQSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A1221MAQSts ,
                                              AV64Produccion_maquinaswwds_16_tfmaqsts_sels ,
                                              AV49Produccion_maquinaswwds_1_dynamicfiltersselector1 ,
                                              AV50Produccion_maquinaswwds_2_dynamicfiltersoperator1 ,
                                              AV51Produccion_maquinaswwds_3_maqdsc1 ,
                                              AV52Produccion_maquinaswwds_4_dynamicfiltersenabled2 ,
                                              AV53Produccion_maquinaswwds_5_dynamicfiltersselector2 ,
                                              AV54Produccion_maquinaswwds_6_dynamicfiltersoperator2 ,
                                              AV55Produccion_maquinaswwds_7_maqdsc2 ,
                                              AV56Produccion_maquinaswwds_8_dynamicfiltersenabled3 ,
                                              AV57Produccion_maquinaswwds_9_dynamicfiltersselector3 ,
                                              AV58Produccion_maquinaswwds_10_dynamicfiltersoperator3 ,
                                              AV59Produccion_maquinaswwds_11_maqdsc3 ,
                                              AV61Produccion_maquinaswwds_13_tfmaqcod_sel ,
                                              AV60Produccion_maquinaswwds_12_tfmaqcod ,
                                              AV63Produccion_maquinaswwds_15_tfmaqdsc_sel ,
                                              AV62Produccion_maquinaswwds_14_tfmaqdsc ,
                                              AV64Produccion_maquinaswwds_16_tfmaqsts_sels.Count ,
                                              A1220MAQDsc ,
                                              A320MAQCod } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV51Produccion_maquinaswwds_3_maqdsc1 = StringUtil.PadR( StringUtil.RTrim( AV51Produccion_maquinaswwds_3_maqdsc1), 100, "%");
         lV51Produccion_maquinaswwds_3_maqdsc1 = StringUtil.PadR( StringUtil.RTrim( AV51Produccion_maquinaswwds_3_maqdsc1), 100, "%");
         lV55Produccion_maquinaswwds_7_maqdsc2 = StringUtil.PadR( StringUtil.RTrim( AV55Produccion_maquinaswwds_7_maqdsc2), 100, "%");
         lV55Produccion_maquinaswwds_7_maqdsc2 = StringUtil.PadR( StringUtil.RTrim( AV55Produccion_maquinaswwds_7_maqdsc2), 100, "%");
         lV59Produccion_maquinaswwds_11_maqdsc3 = StringUtil.PadR( StringUtil.RTrim( AV59Produccion_maquinaswwds_11_maqdsc3), 100, "%");
         lV59Produccion_maquinaswwds_11_maqdsc3 = StringUtil.PadR( StringUtil.RTrim( AV59Produccion_maquinaswwds_11_maqdsc3), 100, "%");
         lV60Produccion_maquinaswwds_12_tfmaqcod = StringUtil.PadR( StringUtil.RTrim( AV60Produccion_maquinaswwds_12_tfmaqcod), 10, "%");
         lV62Produccion_maquinaswwds_14_tfmaqdsc = StringUtil.PadR( StringUtil.RTrim( AV62Produccion_maquinaswwds_14_tfmaqdsc), 100, "%");
         /* Using cursor P00623 */
         pr_default.execute(1, new Object[] {lV51Produccion_maquinaswwds_3_maqdsc1, lV51Produccion_maquinaswwds_3_maqdsc1, lV55Produccion_maquinaswwds_7_maqdsc2, lV55Produccion_maquinaswwds_7_maqdsc2, lV59Produccion_maquinaswwds_11_maqdsc3, lV59Produccion_maquinaswwds_11_maqdsc3, lV60Produccion_maquinaswwds_12_tfmaqcod, AV61Produccion_maquinaswwds_13_tfmaqcod_sel, lV62Produccion_maquinaswwds_14_tfmaqdsc, AV63Produccion_maquinaswwds_15_tfmaqdsc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK623 = false;
            A1220MAQDsc = P00623_A1220MAQDsc[0];
            A1221MAQSts = P00623_A1221MAQSts[0];
            A320MAQCod = P00623_A320MAQCod[0];
            AV28count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00623_A1220MAQDsc[0], A1220MAQDsc) == 0 ) )
            {
               BRK623 = false;
               A320MAQCod = P00623_A320MAQCod[0];
               AV28count = (long)(AV28count+1);
               BRK623 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1220MAQDsc)) )
            {
               AV20Option = A1220MAQDsc;
               AV21Options.Add(AV20Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV21Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK623 )
            {
               BRK623 = true;
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
         AV10TFMAQCod = "";
         AV11TFMAQCod_Sel = "";
         AV12TFMAQDsc = "";
         AV13TFMAQDsc_Sel = "";
         AV14TFMAQSts_SelsJson = "";
         AV15TFMAQSts_Sels = new GxSimpleCollection<short>();
         AV33GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV34DynamicFiltersSelector1 = "";
         AV36MAQDsc1 = "";
         AV38DynamicFiltersSelector2 = "";
         AV40MAQDsc2 = "";
         AV42DynamicFiltersSelector3 = "";
         AV44MAQDsc3 = "";
         AV49Produccion_maquinaswwds_1_dynamicfiltersselector1 = "";
         AV51Produccion_maquinaswwds_3_maqdsc1 = "";
         AV53Produccion_maquinaswwds_5_dynamicfiltersselector2 = "";
         AV55Produccion_maquinaswwds_7_maqdsc2 = "";
         AV57Produccion_maquinaswwds_9_dynamicfiltersselector3 = "";
         AV59Produccion_maquinaswwds_11_maqdsc3 = "";
         AV60Produccion_maquinaswwds_12_tfmaqcod = "";
         AV61Produccion_maquinaswwds_13_tfmaqcod_sel = "";
         AV62Produccion_maquinaswwds_14_tfmaqdsc = "";
         AV63Produccion_maquinaswwds_15_tfmaqdsc_sel = "";
         AV64Produccion_maquinaswwds_16_tfmaqsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV51Produccion_maquinaswwds_3_maqdsc1 = "";
         lV55Produccion_maquinaswwds_7_maqdsc2 = "";
         lV59Produccion_maquinaswwds_11_maqdsc3 = "";
         lV60Produccion_maquinaswwds_12_tfmaqcod = "";
         lV62Produccion_maquinaswwds_14_tfmaqdsc = "";
         A1220MAQDsc = "";
         A320MAQCod = "";
         P00622_A1221MAQSts = new short[1] ;
         P00622_A320MAQCod = new string[] {""} ;
         P00622_A1220MAQDsc = new string[] {""} ;
         AV20Option = "";
         P00623_A1220MAQDsc = new string[] {""} ;
         P00623_A1221MAQSts = new short[1] ;
         P00623_A320MAQCod = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produccion.maquinaswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00622_A1221MAQSts, P00622_A320MAQCod, P00622_A1220MAQDsc
               }
               , new Object[] {
               P00623_A1220MAQDsc, P00623_A1221MAQSts, P00623_A320MAQCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV35DynamicFiltersOperator1 ;
      private short AV39DynamicFiltersOperator2 ;
      private short AV43DynamicFiltersOperator3 ;
      private short AV50Produccion_maquinaswwds_2_dynamicfiltersoperator1 ;
      private short AV54Produccion_maquinaswwds_6_dynamicfiltersoperator2 ;
      private short AV58Produccion_maquinaswwds_10_dynamicfiltersoperator3 ;
      private short A1221MAQSts ;
      private int AV47GXV1 ;
      private int AV64Produccion_maquinaswwds_16_tfmaqsts_sels_Count ;
      private long AV28count ;
      private string AV10TFMAQCod ;
      private string AV11TFMAQCod_Sel ;
      private string AV12TFMAQDsc ;
      private string AV13TFMAQDsc_Sel ;
      private string AV36MAQDsc1 ;
      private string AV40MAQDsc2 ;
      private string AV44MAQDsc3 ;
      private string AV51Produccion_maquinaswwds_3_maqdsc1 ;
      private string AV55Produccion_maquinaswwds_7_maqdsc2 ;
      private string AV59Produccion_maquinaswwds_11_maqdsc3 ;
      private string AV60Produccion_maquinaswwds_12_tfmaqcod ;
      private string AV61Produccion_maquinaswwds_13_tfmaqcod_sel ;
      private string AV62Produccion_maquinaswwds_14_tfmaqdsc ;
      private string AV63Produccion_maquinaswwds_15_tfmaqdsc_sel ;
      private string scmdbuf ;
      private string lV51Produccion_maquinaswwds_3_maqdsc1 ;
      private string lV55Produccion_maquinaswwds_7_maqdsc2 ;
      private string lV59Produccion_maquinaswwds_11_maqdsc3 ;
      private string lV60Produccion_maquinaswwds_12_tfmaqcod ;
      private string lV62Produccion_maquinaswwds_14_tfmaqdsc ;
      private string A1220MAQDsc ;
      private string A320MAQCod ;
      private bool returnInSub ;
      private bool AV37DynamicFiltersEnabled2 ;
      private bool AV41DynamicFiltersEnabled3 ;
      private bool AV52Produccion_maquinaswwds_4_dynamicfiltersenabled2 ;
      private bool AV56Produccion_maquinaswwds_8_dynamicfiltersenabled3 ;
      private bool BRK623 ;
      private string AV22OptionsJson ;
      private string AV25OptionsDescJson ;
      private string AV27OptionIndexesJson ;
      private string AV14TFMAQSts_SelsJson ;
      private string AV18DDOName ;
      private string AV16SearchTxt ;
      private string AV17SearchTxtTo ;
      private string AV34DynamicFiltersSelector1 ;
      private string AV38DynamicFiltersSelector2 ;
      private string AV42DynamicFiltersSelector3 ;
      private string AV49Produccion_maquinaswwds_1_dynamicfiltersselector1 ;
      private string AV53Produccion_maquinaswwds_5_dynamicfiltersselector2 ;
      private string AV57Produccion_maquinaswwds_9_dynamicfiltersselector3 ;
      private string AV20Option ;
      private GxSimpleCollection<short> AV15TFMAQSts_Sels ;
      private GxSimpleCollection<short> AV64Produccion_maquinaswwds_16_tfmaqsts_sels ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00622_A1221MAQSts ;
      private string[] P00622_A320MAQCod ;
      private string[] P00622_A1220MAQDsc ;
      private string[] P00623_A1220MAQDsc ;
      private short[] P00623_A1221MAQSts ;
      private string[] P00623_A320MAQCod ;
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

   public class maquinaswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00622( IGxContext context ,
                                             short A1221MAQSts ,
                                             GxSimpleCollection<short> AV64Produccion_maquinaswwds_16_tfmaqsts_sels ,
                                             string AV49Produccion_maquinaswwds_1_dynamicfiltersselector1 ,
                                             short AV50Produccion_maquinaswwds_2_dynamicfiltersoperator1 ,
                                             string AV51Produccion_maquinaswwds_3_maqdsc1 ,
                                             bool AV52Produccion_maquinaswwds_4_dynamicfiltersenabled2 ,
                                             string AV53Produccion_maquinaswwds_5_dynamicfiltersselector2 ,
                                             short AV54Produccion_maquinaswwds_6_dynamicfiltersoperator2 ,
                                             string AV55Produccion_maquinaswwds_7_maqdsc2 ,
                                             bool AV56Produccion_maquinaswwds_8_dynamicfiltersenabled3 ,
                                             string AV57Produccion_maquinaswwds_9_dynamicfiltersselector3 ,
                                             short AV58Produccion_maquinaswwds_10_dynamicfiltersoperator3 ,
                                             string AV59Produccion_maquinaswwds_11_maqdsc3 ,
                                             string AV61Produccion_maquinaswwds_13_tfmaqcod_sel ,
                                             string AV60Produccion_maquinaswwds_12_tfmaqcod ,
                                             string AV63Produccion_maquinaswwds_15_tfmaqdsc_sel ,
                                             string AV62Produccion_maquinaswwds_14_tfmaqdsc ,
                                             int AV64Produccion_maquinaswwds_16_tfmaqsts_sels_Count ,
                                             string A1220MAQDsc ,
                                             string A320MAQCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [MAQSts], [MAQCod], NULL AS [MAQDsc] FROM ( SELECT TOP(100) PERCENT [MAQSts], [MAQCod], [MAQDsc] FROM [POMAQUINA]";
         if ( ( StringUtil.StrCmp(AV49Produccion_maquinaswwds_1_dynamicfiltersselector1, "MAQDSC") == 0 ) && ( AV50Produccion_maquinaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Produccion_maquinaswwds_3_maqdsc1)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV51Produccion_maquinaswwds_3_maqdsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV49Produccion_maquinaswwds_1_dynamicfiltersselector1, "MAQDSC") == 0 ) && ( AV50Produccion_maquinaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Produccion_maquinaswwds_3_maqdsc1)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like '%' + @lV51Produccion_maquinaswwds_3_maqdsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV52Produccion_maquinaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Produccion_maquinaswwds_5_dynamicfiltersselector2, "MAQDSC") == 0 ) && ( AV54Produccion_maquinaswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Produccion_maquinaswwds_7_maqdsc2)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV55Produccion_maquinaswwds_7_maqdsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV52Produccion_maquinaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Produccion_maquinaswwds_5_dynamicfiltersselector2, "MAQDSC") == 0 ) && ( AV54Produccion_maquinaswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Produccion_maquinaswwds_7_maqdsc2)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like '%' + @lV55Produccion_maquinaswwds_7_maqdsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV56Produccion_maquinaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV57Produccion_maquinaswwds_9_dynamicfiltersselector3, "MAQDSC") == 0 ) && ( AV58Produccion_maquinaswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Produccion_maquinaswwds_11_maqdsc3)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV59Produccion_maquinaswwds_11_maqdsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV56Produccion_maquinaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV57Produccion_maquinaswwds_9_dynamicfiltersselector3, "MAQDSC") == 0 ) && ( AV58Produccion_maquinaswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Produccion_maquinaswwds_11_maqdsc3)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like '%' + @lV59Produccion_maquinaswwds_11_maqdsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_maquinaswwds_13_tfmaqcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Produccion_maquinaswwds_12_tfmaqcod)) ) )
         {
            AddWhere(sWhereString, "([MAQCod] like @lV60Produccion_maquinaswwds_12_tfmaqcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_maquinaswwds_13_tfmaqcod_sel)) )
         {
            AddWhere(sWhereString, "([MAQCod] = @AV61Produccion_maquinaswwds_13_tfmaqcod_sel)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Produccion_maquinaswwds_15_tfmaqdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Produccion_maquinaswwds_14_tfmaqdsc)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV62Produccion_maquinaswwds_14_tfmaqdsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Produccion_maquinaswwds_15_tfmaqdsc_sel)) )
         {
            AddWhere(sWhereString, "([MAQDsc] = @AV63Produccion_maquinaswwds_15_tfmaqdsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV64Produccion_maquinaswwds_16_tfmaqsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV64Produccion_maquinaswwds_16_tfmaqsts_sels, "[MAQSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MAQCod]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [MAQCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00623( IGxContext context ,
                                             short A1221MAQSts ,
                                             GxSimpleCollection<short> AV64Produccion_maquinaswwds_16_tfmaqsts_sels ,
                                             string AV49Produccion_maquinaswwds_1_dynamicfiltersselector1 ,
                                             short AV50Produccion_maquinaswwds_2_dynamicfiltersoperator1 ,
                                             string AV51Produccion_maquinaswwds_3_maqdsc1 ,
                                             bool AV52Produccion_maquinaswwds_4_dynamicfiltersenabled2 ,
                                             string AV53Produccion_maquinaswwds_5_dynamicfiltersselector2 ,
                                             short AV54Produccion_maquinaswwds_6_dynamicfiltersoperator2 ,
                                             string AV55Produccion_maquinaswwds_7_maqdsc2 ,
                                             bool AV56Produccion_maquinaswwds_8_dynamicfiltersenabled3 ,
                                             string AV57Produccion_maquinaswwds_9_dynamicfiltersselector3 ,
                                             short AV58Produccion_maquinaswwds_10_dynamicfiltersoperator3 ,
                                             string AV59Produccion_maquinaswwds_11_maqdsc3 ,
                                             string AV61Produccion_maquinaswwds_13_tfmaqcod_sel ,
                                             string AV60Produccion_maquinaswwds_12_tfmaqcod ,
                                             string AV63Produccion_maquinaswwds_15_tfmaqdsc_sel ,
                                             string AV62Produccion_maquinaswwds_14_tfmaqdsc ,
                                             int AV64Produccion_maquinaswwds_16_tfmaqsts_sels_Count ,
                                             string A1220MAQDsc ,
                                             string A320MAQCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[10];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [MAQDsc], [MAQSts], [MAQCod] FROM [POMAQUINA]";
         if ( ( StringUtil.StrCmp(AV49Produccion_maquinaswwds_1_dynamicfiltersselector1, "MAQDSC") == 0 ) && ( AV50Produccion_maquinaswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Produccion_maquinaswwds_3_maqdsc1)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV51Produccion_maquinaswwds_3_maqdsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV49Produccion_maquinaswwds_1_dynamicfiltersselector1, "MAQDSC") == 0 ) && ( AV50Produccion_maquinaswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Produccion_maquinaswwds_3_maqdsc1)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like '%' + @lV51Produccion_maquinaswwds_3_maqdsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV52Produccion_maquinaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Produccion_maquinaswwds_5_dynamicfiltersselector2, "MAQDSC") == 0 ) && ( AV54Produccion_maquinaswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Produccion_maquinaswwds_7_maqdsc2)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV55Produccion_maquinaswwds_7_maqdsc2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV52Produccion_maquinaswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV53Produccion_maquinaswwds_5_dynamicfiltersselector2, "MAQDSC") == 0 ) && ( AV54Produccion_maquinaswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Produccion_maquinaswwds_7_maqdsc2)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like '%' + @lV55Produccion_maquinaswwds_7_maqdsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV56Produccion_maquinaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV57Produccion_maquinaswwds_9_dynamicfiltersselector3, "MAQDSC") == 0 ) && ( AV58Produccion_maquinaswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Produccion_maquinaswwds_11_maqdsc3)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV59Produccion_maquinaswwds_11_maqdsc3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV56Produccion_maquinaswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV57Produccion_maquinaswwds_9_dynamicfiltersselector3, "MAQDSC") == 0 ) && ( AV58Produccion_maquinaswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Produccion_maquinaswwds_11_maqdsc3)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like '%' + @lV59Produccion_maquinaswwds_11_maqdsc3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_maquinaswwds_13_tfmaqcod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Produccion_maquinaswwds_12_tfmaqcod)) ) )
         {
            AddWhere(sWhereString, "([MAQCod] like @lV60Produccion_maquinaswwds_12_tfmaqcod)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Produccion_maquinaswwds_13_tfmaqcod_sel)) )
         {
            AddWhere(sWhereString, "([MAQCod] = @AV61Produccion_maquinaswwds_13_tfmaqcod_sel)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Produccion_maquinaswwds_15_tfmaqdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Produccion_maquinaswwds_14_tfmaqdsc)) ) )
         {
            AddWhere(sWhereString, "([MAQDsc] like @lV62Produccion_maquinaswwds_14_tfmaqdsc)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Produccion_maquinaswwds_15_tfmaqdsc_sel)) )
         {
            AddWhere(sWhereString, "([MAQDsc] = @AV63Produccion_maquinaswwds_15_tfmaqdsc_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV64Produccion_maquinaswwds_16_tfmaqsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV64Produccion_maquinaswwds_16_tfmaqsts_sels, "[MAQSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MAQDsc]";
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
                     return conditional_P00622(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
               case 1 :
                     return conditional_P00623(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] );
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
          Object[] prmP00622;
          prmP00622 = new Object[] {
          new ParDef("@lV51Produccion_maquinaswwds_3_maqdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV51Produccion_maquinaswwds_3_maqdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV55Produccion_maquinaswwds_7_maqdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV55Produccion_maquinaswwds_7_maqdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV59Produccion_maquinaswwds_11_maqdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV59Produccion_maquinaswwds_11_maqdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV60Produccion_maquinaswwds_12_tfmaqcod",GXType.NChar,10,0) ,
          new ParDef("@AV61Produccion_maquinaswwds_13_tfmaqcod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV62Produccion_maquinaswwds_14_tfmaqdsc",GXType.NChar,100,0) ,
          new ParDef("@AV63Produccion_maquinaswwds_15_tfmaqdsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP00623;
          prmP00623 = new Object[] {
          new ParDef("@lV51Produccion_maquinaswwds_3_maqdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV51Produccion_maquinaswwds_3_maqdsc1",GXType.NChar,100,0) ,
          new ParDef("@lV55Produccion_maquinaswwds_7_maqdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV55Produccion_maquinaswwds_7_maqdsc2",GXType.NChar,100,0) ,
          new ParDef("@lV59Produccion_maquinaswwds_11_maqdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV59Produccion_maquinaswwds_11_maqdsc3",GXType.NChar,100,0) ,
          new ParDef("@lV60Produccion_maquinaswwds_12_tfmaqcod",GXType.NChar,10,0) ,
          new ParDef("@AV61Produccion_maquinaswwds_13_tfmaqcod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV62Produccion_maquinaswwds_14_tfmaqdsc",GXType.NChar,100,0) ,
          new ParDef("@AV63Produccion_maquinaswwds_15_tfmaqdsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00622", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00622,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00623", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00623,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 10);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                return;
       }
    }

 }

}
