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
   public class rubroswwgetfilterdata : GXProcedure
   {
      public rubroswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public rubroswwgetfilterdata( IGxContext context )
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
         this.AV26DDOName = aP0_DDOName;
         this.AV24SearchTxt = aP1_SearchTxt;
         this.AV25SearchTxtTo = aP2_SearchTxtTo;
         this.AV30OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV35OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV30OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV35OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         rubroswwgetfilterdata objrubroswwgetfilterdata;
         objrubroswwgetfilterdata = new rubroswwgetfilterdata();
         objrubroswwgetfilterdata.AV26DDOName = aP0_DDOName;
         objrubroswwgetfilterdata.AV24SearchTxt = aP1_SearchTxt;
         objrubroswwgetfilterdata.AV25SearchTxtTo = aP2_SearchTxtTo;
         objrubroswwgetfilterdata.AV30OptionsJson = "" ;
         objrubroswwgetfilterdata.AV33OptionsDescJson = "" ;
         objrubroswwgetfilterdata.AV35OptionIndexesJson = "" ;
         objrubroswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objrubroswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objrubroswwgetfilterdata);
         aP3_OptionsJson=this.AV30OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV35OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((rubroswwgetfilterdata)stateInfo).executePrivate();
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
         AV29Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV26DDOName), "DDO_TOTDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADTOTDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV26DDOName), "DDO_RUBDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADRUBDSCOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV26DDOName), "DDO_RUBDSCTOT") == 0 )
         {
            /* Execute user subroutine: 'LOADRUBDSCTOTOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV30OptionsJson = AV29Options.ToJSonString(false);
         AV33OptionsDescJson = AV32OptionsDesc.ToJSonString(false);
         AV35OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get("Contabilidad.RubrosWWGridState"), "") == 0 )
         {
            AV39GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Contabilidad.RubrosWWGridState"), null, "", "");
         }
         else
         {
            AV39GridState.FromXml(AV37Session.Get("Contabilidad.RubrosWWGridState"), null, "", "");
         }
         AV63GXV1 = 1;
         while ( AV63GXV1 <= AV39GridState.gxTpr_Filtervalues.Count )
         {
            AV40GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV39GridState.gxTpr_Filtervalues.Item(AV63GXV1));
            if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFTOTTIPO_SEL") == 0 )
            {
               AV10TFTotTipo_SelsJson = AV40GridStateFilterValue.gxTpr_Value;
               AV11TFTotTipo_Sels.FromJSonString(AV10TFTotTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFTOTDSC") == 0 )
            {
               AV53TFTotDsc = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFTOTDSC_SEL") == 0 )
            {
               AV54TFTotDsc_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFRUBCOD") == 0 )
            {
               AV14TFRubCod = (int)(NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Value, "."));
               AV15TFRubCod_To = (int)(NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFRUBDSC") == 0 )
            {
               AV16TFRubDsc = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFRUBDSC_SEL") == 0 )
            {
               AV17TFRubDsc_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFRUBDSCTOT") == 0 )
            {
               AV18TFRubDscTot = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFRUBDSCTOT_SEL") == 0 )
            {
               AV19TFRubDscTot_Sel = AV40GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFRUBORD") == 0 )
            {
               AV20TFRubOrd = (short)(NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Value, "."));
               AV21TFRubOrd_To = (short)(NumberUtil.Val( AV40GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV40GridStateFilterValue.gxTpr_Name, "TFRUBSTS_SEL") == 0 )
            {
               AV22TFRubSts_SelsJson = AV40GridStateFilterValue.gxTpr_Value;
               AV23TFRubSts_Sels.FromJSonString(AV22TFRubSts_SelsJson, null);
            }
            AV63GXV1 = (int)(AV63GXV1+1);
         }
         if ( AV39GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV41GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV39GridState.gxTpr_Dynamicfilters.Item(1));
            AV42DynamicFiltersSelector1 = AV41GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV42DynamicFiltersSelector1, "TOTTIPO") == 0 )
            {
               AV55TotTipo1 = AV41GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV39GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV45DynamicFiltersEnabled2 = true;
               AV41GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV39GridState.gxTpr_Dynamicfilters.Item(2));
               AV46DynamicFiltersSelector2 = AV41GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "TOTTIPO") == 0 )
               {
                  AV56TotTipo2 = AV41GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV39GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV41GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV39GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV41GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "TOTTIPO") == 0 )
                  {
                     AV57TotTipo3 = AV41GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTOTDSCOPTIONS' Routine */
         returnInSub = false;
         AV53TFTotDsc = AV24SearchTxt;
         AV54TFTotDsc_Sel = "";
         AV65Contabilidad_rubroswwds_1_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV66Contabilidad_rubroswwds_2_tottipo1 = AV55TotTipo1;
         AV67Contabilidad_rubroswwds_3_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV68Contabilidad_rubroswwds_4_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV69Contabilidad_rubroswwds_5_tottipo2 = AV56TotTipo2;
         AV70Contabilidad_rubroswwds_6_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV71Contabilidad_rubroswwds_7_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV72Contabilidad_rubroswwds_8_tottipo3 = AV57TotTipo3;
         AV73Contabilidad_rubroswwds_9_tftottipo_sels = AV11TFTotTipo_Sels;
         AV74Contabilidad_rubroswwds_10_tftotdsc = AV53TFTotDsc;
         AV75Contabilidad_rubroswwds_11_tftotdsc_sel = AV54TFTotDsc_Sel;
         AV76Contabilidad_rubroswwds_12_tfrubcod = AV14TFRubCod;
         AV77Contabilidad_rubroswwds_13_tfrubcod_to = AV15TFRubCod_To;
         AV78Contabilidad_rubroswwds_14_tfrubdsc = AV16TFRubDsc;
         AV79Contabilidad_rubroswwds_15_tfrubdsc_sel = AV17TFRubDsc_Sel;
         AV80Contabilidad_rubroswwds_16_tfrubdsctot = AV18TFRubDscTot;
         AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel = AV19TFRubDscTot_Sel;
         AV82Contabilidad_rubroswwds_18_tfrubord = AV20TFRubOrd;
         AV83Contabilidad_rubroswwds_19_tfrubord_to = AV21TFRubOrd_To;
         AV84Contabilidad_rubroswwds_20_tfrubsts_sels = AV23TFRubSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A114TotTipo ,
                                              AV73Contabilidad_rubroswwds_9_tftottipo_sels ,
                                              A1829RubSts ,
                                              AV84Contabilidad_rubroswwds_20_tfrubsts_sels ,
                                              AV65Contabilidad_rubroswwds_1_dynamicfiltersselector1 ,
                                              AV66Contabilidad_rubroswwds_2_tottipo1 ,
                                              AV67Contabilidad_rubroswwds_3_dynamicfiltersenabled2 ,
                                              AV68Contabilidad_rubroswwds_4_dynamicfiltersselector2 ,
                                              AV69Contabilidad_rubroswwds_5_tottipo2 ,
                                              AV70Contabilidad_rubroswwds_6_dynamicfiltersenabled3 ,
                                              AV71Contabilidad_rubroswwds_7_dynamicfiltersselector3 ,
                                              AV72Contabilidad_rubroswwds_8_tottipo3 ,
                                              AV73Contabilidad_rubroswwds_9_tftottipo_sels.Count ,
                                              AV75Contabilidad_rubroswwds_11_tftotdsc_sel ,
                                              AV74Contabilidad_rubroswwds_10_tftotdsc ,
                                              AV76Contabilidad_rubroswwds_12_tfrubcod ,
                                              AV77Contabilidad_rubroswwds_13_tfrubcod_to ,
                                              AV79Contabilidad_rubroswwds_15_tfrubdsc_sel ,
                                              AV78Contabilidad_rubroswwds_14_tfrubdsc ,
                                              AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel ,
                                              AV80Contabilidad_rubroswwds_16_tfrubdsctot ,
                                              AV82Contabilidad_rubroswwds_18_tfrubord ,
                                              AV83Contabilidad_rubroswwds_19_tfrubord_to ,
                                              AV84Contabilidad_rubroswwds_20_tfrubsts_sels.Count ,
                                              A1928TotDsc ,
                                              A116RubCod ,
                                              A1822RubDsc ,
                                              A1823RubDscTot ,
                                              A117RubOrd } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT
                                              }
         });
         lV74Contabilidad_rubroswwds_10_tftotdsc = StringUtil.PadR( StringUtil.RTrim( AV74Contabilidad_rubroswwds_10_tftotdsc), 100, "%");
         lV78Contabilidad_rubroswwds_14_tfrubdsc = StringUtil.PadR( StringUtil.RTrim( AV78Contabilidad_rubroswwds_14_tfrubdsc), 100, "%");
         lV80Contabilidad_rubroswwds_16_tfrubdsctot = StringUtil.PadR( StringUtil.RTrim( AV80Contabilidad_rubroswwds_16_tfrubdsctot), 100, "%");
         /* Using cursor P00722 */
         pr_default.execute(0, new Object[] {AV66Contabilidad_rubroswwds_2_tottipo1, AV69Contabilidad_rubroswwds_5_tottipo2, AV72Contabilidad_rubroswwds_8_tottipo3, lV74Contabilidad_rubroswwds_10_tftotdsc, AV75Contabilidad_rubroswwds_11_tftotdsc_sel, AV76Contabilidad_rubroswwds_12_tfrubcod, AV77Contabilidad_rubroswwds_13_tfrubcod_to, lV78Contabilidad_rubroswwds_14_tfrubdsc, AV79Contabilidad_rubroswwds_15_tfrubdsc_sel, lV80Contabilidad_rubroswwds_16_tfrubdsctot, AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel, AV82Contabilidad_rubroswwds_18_tfrubord, AV83Contabilidad_rubroswwds_19_tfrubord_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK722 = false;
            A115TotRub = P00722_A115TotRub[0];
            A114TotTipo = P00722_A114TotTipo[0];
            A1829RubSts = P00722_A1829RubSts[0];
            A117RubOrd = P00722_A117RubOrd[0];
            A1823RubDscTot = P00722_A1823RubDscTot[0];
            A1822RubDsc = P00722_A1822RubDsc[0];
            A116RubCod = P00722_A116RubCod[0];
            A1928TotDsc = P00722_A1928TotDsc[0];
            A1928TotDsc = P00722_A1928TotDsc[0];
            AV36count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00722_A114TotTipo[0], A114TotTipo) == 0 ) && ( P00722_A115TotRub[0] == A115TotRub ) )
            {
               BRK722 = false;
               A116RubCod = P00722_A116RubCod[0];
               AV36count = (long)(AV36count+1);
               BRK722 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1928TotDsc)) )
            {
               AV28Option = A1928TotDsc;
               AV27InsertIndex = 1;
               while ( ( AV27InsertIndex <= AV29Options.Count ) && ( StringUtil.StrCmp(((string)AV29Options.Item(AV27InsertIndex)), AV28Option) < 0 ) )
               {
                  AV27InsertIndex = (int)(AV27InsertIndex+1);
               }
               AV29Options.Add(AV28Option, AV27InsertIndex);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV36count), "Z,ZZZ,ZZZ,ZZ9")), AV27InsertIndex);
            }
            if ( AV29Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK722 )
            {
               BRK722 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRUBDSCOPTIONS' Routine */
         returnInSub = false;
         AV16TFRubDsc = AV24SearchTxt;
         AV17TFRubDsc_Sel = "";
         AV65Contabilidad_rubroswwds_1_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV66Contabilidad_rubroswwds_2_tottipo1 = AV55TotTipo1;
         AV67Contabilidad_rubroswwds_3_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV68Contabilidad_rubroswwds_4_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV69Contabilidad_rubroswwds_5_tottipo2 = AV56TotTipo2;
         AV70Contabilidad_rubroswwds_6_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV71Contabilidad_rubroswwds_7_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV72Contabilidad_rubroswwds_8_tottipo3 = AV57TotTipo3;
         AV73Contabilidad_rubroswwds_9_tftottipo_sels = AV11TFTotTipo_Sels;
         AV74Contabilidad_rubroswwds_10_tftotdsc = AV53TFTotDsc;
         AV75Contabilidad_rubroswwds_11_tftotdsc_sel = AV54TFTotDsc_Sel;
         AV76Contabilidad_rubroswwds_12_tfrubcod = AV14TFRubCod;
         AV77Contabilidad_rubroswwds_13_tfrubcod_to = AV15TFRubCod_To;
         AV78Contabilidad_rubroswwds_14_tfrubdsc = AV16TFRubDsc;
         AV79Contabilidad_rubroswwds_15_tfrubdsc_sel = AV17TFRubDsc_Sel;
         AV80Contabilidad_rubroswwds_16_tfrubdsctot = AV18TFRubDscTot;
         AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel = AV19TFRubDscTot_Sel;
         AV82Contabilidad_rubroswwds_18_tfrubord = AV20TFRubOrd;
         AV83Contabilidad_rubroswwds_19_tfrubord_to = AV21TFRubOrd_To;
         AV84Contabilidad_rubroswwds_20_tfrubsts_sels = AV23TFRubSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A114TotTipo ,
                                              AV73Contabilidad_rubroswwds_9_tftottipo_sels ,
                                              A1829RubSts ,
                                              AV84Contabilidad_rubroswwds_20_tfrubsts_sels ,
                                              AV65Contabilidad_rubroswwds_1_dynamicfiltersselector1 ,
                                              AV66Contabilidad_rubroswwds_2_tottipo1 ,
                                              AV67Contabilidad_rubroswwds_3_dynamicfiltersenabled2 ,
                                              AV68Contabilidad_rubroswwds_4_dynamicfiltersselector2 ,
                                              AV69Contabilidad_rubroswwds_5_tottipo2 ,
                                              AV70Contabilidad_rubroswwds_6_dynamicfiltersenabled3 ,
                                              AV71Contabilidad_rubroswwds_7_dynamicfiltersselector3 ,
                                              AV72Contabilidad_rubroswwds_8_tottipo3 ,
                                              AV73Contabilidad_rubroswwds_9_tftottipo_sels.Count ,
                                              AV75Contabilidad_rubroswwds_11_tftotdsc_sel ,
                                              AV74Contabilidad_rubroswwds_10_tftotdsc ,
                                              AV76Contabilidad_rubroswwds_12_tfrubcod ,
                                              AV77Contabilidad_rubroswwds_13_tfrubcod_to ,
                                              AV79Contabilidad_rubroswwds_15_tfrubdsc_sel ,
                                              AV78Contabilidad_rubroswwds_14_tfrubdsc ,
                                              AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel ,
                                              AV80Contabilidad_rubroswwds_16_tfrubdsctot ,
                                              AV82Contabilidad_rubroswwds_18_tfrubord ,
                                              AV83Contabilidad_rubroswwds_19_tfrubord_to ,
                                              AV84Contabilidad_rubroswwds_20_tfrubsts_sels.Count ,
                                              A1928TotDsc ,
                                              A116RubCod ,
                                              A1822RubDsc ,
                                              A1823RubDscTot ,
                                              A117RubOrd } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT
                                              }
         });
         lV74Contabilidad_rubroswwds_10_tftotdsc = StringUtil.PadR( StringUtil.RTrim( AV74Contabilidad_rubroswwds_10_tftotdsc), 100, "%");
         lV78Contabilidad_rubroswwds_14_tfrubdsc = StringUtil.PadR( StringUtil.RTrim( AV78Contabilidad_rubroswwds_14_tfrubdsc), 100, "%");
         lV80Contabilidad_rubroswwds_16_tfrubdsctot = StringUtil.PadR( StringUtil.RTrim( AV80Contabilidad_rubroswwds_16_tfrubdsctot), 100, "%");
         /* Using cursor P00723 */
         pr_default.execute(1, new Object[] {AV66Contabilidad_rubroswwds_2_tottipo1, AV69Contabilidad_rubroswwds_5_tottipo2, AV72Contabilidad_rubroswwds_8_tottipo3, lV74Contabilidad_rubroswwds_10_tftotdsc, AV75Contabilidad_rubroswwds_11_tftotdsc_sel, AV76Contabilidad_rubroswwds_12_tfrubcod, AV77Contabilidad_rubroswwds_13_tfrubcod_to, lV78Contabilidad_rubroswwds_14_tfrubdsc, AV79Contabilidad_rubroswwds_15_tfrubdsc_sel, lV80Contabilidad_rubroswwds_16_tfrubdsctot, AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel, AV82Contabilidad_rubroswwds_18_tfrubord, AV83Contabilidad_rubroswwds_19_tfrubord_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK724 = false;
            A115TotRub = P00723_A115TotRub[0];
            A1822RubDsc = P00723_A1822RubDsc[0];
            A1829RubSts = P00723_A1829RubSts[0];
            A117RubOrd = P00723_A117RubOrd[0];
            A1823RubDscTot = P00723_A1823RubDscTot[0];
            A116RubCod = P00723_A116RubCod[0];
            A1928TotDsc = P00723_A1928TotDsc[0];
            A114TotTipo = P00723_A114TotTipo[0];
            A1928TotDsc = P00723_A1928TotDsc[0];
            AV36count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00723_A1822RubDsc[0], A1822RubDsc) == 0 ) )
            {
               BRK724 = false;
               A115TotRub = P00723_A115TotRub[0];
               A116RubCod = P00723_A116RubCod[0];
               A114TotTipo = P00723_A114TotTipo[0];
               AV36count = (long)(AV36count+1);
               BRK724 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1822RubDsc)) )
            {
               AV28Option = A1822RubDsc;
               AV29Options.Add(AV28Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV36count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV29Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK724 )
            {
               BRK724 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADRUBDSCTOTOPTIONS' Routine */
         returnInSub = false;
         AV18TFRubDscTot = AV24SearchTxt;
         AV19TFRubDscTot_Sel = "";
         AV65Contabilidad_rubroswwds_1_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV66Contabilidad_rubroswwds_2_tottipo1 = AV55TotTipo1;
         AV67Contabilidad_rubroswwds_3_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV68Contabilidad_rubroswwds_4_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV69Contabilidad_rubroswwds_5_tottipo2 = AV56TotTipo2;
         AV70Contabilidad_rubroswwds_6_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV71Contabilidad_rubroswwds_7_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV72Contabilidad_rubroswwds_8_tottipo3 = AV57TotTipo3;
         AV73Contabilidad_rubroswwds_9_tftottipo_sels = AV11TFTotTipo_Sels;
         AV74Contabilidad_rubroswwds_10_tftotdsc = AV53TFTotDsc;
         AV75Contabilidad_rubroswwds_11_tftotdsc_sel = AV54TFTotDsc_Sel;
         AV76Contabilidad_rubroswwds_12_tfrubcod = AV14TFRubCod;
         AV77Contabilidad_rubroswwds_13_tfrubcod_to = AV15TFRubCod_To;
         AV78Contabilidad_rubroswwds_14_tfrubdsc = AV16TFRubDsc;
         AV79Contabilidad_rubroswwds_15_tfrubdsc_sel = AV17TFRubDsc_Sel;
         AV80Contabilidad_rubroswwds_16_tfrubdsctot = AV18TFRubDscTot;
         AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel = AV19TFRubDscTot_Sel;
         AV82Contabilidad_rubroswwds_18_tfrubord = AV20TFRubOrd;
         AV83Contabilidad_rubroswwds_19_tfrubord_to = AV21TFRubOrd_To;
         AV84Contabilidad_rubroswwds_20_tfrubsts_sels = AV23TFRubSts_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A114TotTipo ,
                                              AV73Contabilidad_rubroswwds_9_tftottipo_sels ,
                                              A1829RubSts ,
                                              AV84Contabilidad_rubroswwds_20_tfrubsts_sels ,
                                              AV65Contabilidad_rubroswwds_1_dynamicfiltersselector1 ,
                                              AV66Contabilidad_rubroswwds_2_tottipo1 ,
                                              AV67Contabilidad_rubroswwds_3_dynamicfiltersenabled2 ,
                                              AV68Contabilidad_rubroswwds_4_dynamicfiltersselector2 ,
                                              AV69Contabilidad_rubroswwds_5_tottipo2 ,
                                              AV70Contabilidad_rubroswwds_6_dynamicfiltersenabled3 ,
                                              AV71Contabilidad_rubroswwds_7_dynamicfiltersselector3 ,
                                              AV72Contabilidad_rubroswwds_8_tottipo3 ,
                                              AV73Contabilidad_rubroswwds_9_tftottipo_sels.Count ,
                                              AV75Contabilidad_rubroswwds_11_tftotdsc_sel ,
                                              AV74Contabilidad_rubroswwds_10_tftotdsc ,
                                              AV76Contabilidad_rubroswwds_12_tfrubcod ,
                                              AV77Contabilidad_rubroswwds_13_tfrubcod_to ,
                                              AV79Contabilidad_rubroswwds_15_tfrubdsc_sel ,
                                              AV78Contabilidad_rubroswwds_14_tfrubdsc ,
                                              AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel ,
                                              AV80Contabilidad_rubroswwds_16_tfrubdsctot ,
                                              AV82Contabilidad_rubroswwds_18_tfrubord ,
                                              AV83Contabilidad_rubroswwds_19_tfrubord_to ,
                                              AV84Contabilidad_rubroswwds_20_tfrubsts_sels.Count ,
                                              A1928TotDsc ,
                                              A116RubCod ,
                                              A1822RubDsc ,
                                              A1823RubDscTot ,
                                              A117RubOrd } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.SHORT
                                              }
         });
         lV74Contabilidad_rubroswwds_10_tftotdsc = StringUtil.PadR( StringUtil.RTrim( AV74Contabilidad_rubroswwds_10_tftotdsc), 100, "%");
         lV78Contabilidad_rubroswwds_14_tfrubdsc = StringUtil.PadR( StringUtil.RTrim( AV78Contabilidad_rubroswwds_14_tfrubdsc), 100, "%");
         lV80Contabilidad_rubroswwds_16_tfrubdsctot = StringUtil.PadR( StringUtil.RTrim( AV80Contabilidad_rubroswwds_16_tfrubdsctot), 100, "%");
         /* Using cursor P00724 */
         pr_default.execute(2, new Object[] {AV66Contabilidad_rubroswwds_2_tottipo1, AV69Contabilidad_rubroswwds_5_tottipo2, AV72Contabilidad_rubroswwds_8_tottipo3, lV74Contabilidad_rubroswwds_10_tftotdsc, AV75Contabilidad_rubroswwds_11_tftotdsc_sel, AV76Contabilidad_rubroswwds_12_tfrubcod, AV77Contabilidad_rubroswwds_13_tfrubcod_to, lV78Contabilidad_rubroswwds_14_tfrubdsc, AV79Contabilidad_rubroswwds_15_tfrubdsc_sel, lV80Contabilidad_rubroswwds_16_tfrubdsctot, AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel, AV82Contabilidad_rubroswwds_18_tfrubord, AV83Contabilidad_rubroswwds_19_tfrubord_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK726 = false;
            A115TotRub = P00724_A115TotRub[0];
            A1823RubDscTot = P00724_A1823RubDscTot[0];
            A1829RubSts = P00724_A1829RubSts[0];
            A117RubOrd = P00724_A117RubOrd[0];
            A1822RubDsc = P00724_A1822RubDsc[0];
            A116RubCod = P00724_A116RubCod[0];
            A1928TotDsc = P00724_A1928TotDsc[0];
            A114TotTipo = P00724_A114TotTipo[0];
            A1928TotDsc = P00724_A1928TotDsc[0];
            AV36count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00724_A1823RubDscTot[0], A1823RubDscTot) == 0 ) )
            {
               BRK726 = false;
               A115TotRub = P00724_A115TotRub[0];
               A116RubCod = P00724_A116RubCod[0];
               A114TotTipo = P00724_A114TotTipo[0];
               AV36count = (long)(AV36count+1);
               BRK726 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1823RubDscTot)) )
            {
               AV28Option = A1823RubDscTot;
               AV29Options.Add(AV28Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV36count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV29Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK726 )
            {
               BRK726 = true;
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
         AV30OptionsJson = "";
         AV33OptionsDescJson = "";
         AV35OptionIndexesJson = "";
         AV29Options = new GxSimpleCollection<string>();
         AV32OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV37Session = context.GetSession();
         AV39GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV40GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TFTotTipo_SelsJson = "";
         AV11TFTotTipo_Sels = new GxSimpleCollection<string>();
         AV53TFTotDsc = "";
         AV54TFTotDsc_Sel = "";
         AV16TFRubDsc = "";
         AV17TFRubDsc_Sel = "";
         AV18TFRubDscTot = "";
         AV19TFRubDscTot_Sel = "";
         AV22TFRubSts_SelsJson = "";
         AV23TFRubSts_Sels = new GxSimpleCollection<short>();
         AV41GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV42DynamicFiltersSelector1 = "";
         AV55TotTipo1 = "";
         AV46DynamicFiltersSelector2 = "";
         AV56TotTipo2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV57TotTipo3 = "";
         AV65Contabilidad_rubroswwds_1_dynamicfiltersselector1 = "";
         AV66Contabilidad_rubroswwds_2_tottipo1 = "";
         AV68Contabilidad_rubroswwds_4_dynamicfiltersselector2 = "";
         AV69Contabilidad_rubroswwds_5_tottipo2 = "";
         AV71Contabilidad_rubroswwds_7_dynamicfiltersselector3 = "";
         AV72Contabilidad_rubroswwds_8_tottipo3 = "";
         AV73Contabilidad_rubroswwds_9_tftottipo_sels = new GxSimpleCollection<string>();
         AV74Contabilidad_rubroswwds_10_tftotdsc = "";
         AV75Contabilidad_rubroswwds_11_tftotdsc_sel = "";
         AV78Contabilidad_rubroswwds_14_tfrubdsc = "";
         AV79Contabilidad_rubroswwds_15_tfrubdsc_sel = "";
         AV80Contabilidad_rubroswwds_16_tfrubdsctot = "";
         AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel = "";
         AV84Contabilidad_rubroswwds_20_tfrubsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV74Contabilidad_rubroswwds_10_tftotdsc = "";
         lV78Contabilidad_rubroswwds_14_tfrubdsc = "";
         lV80Contabilidad_rubroswwds_16_tfrubdsctot = "";
         A114TotTipo = "";
         A1928TotDsc = "";
         A1822RubDsc = "";
         A1823RubDscTot = "";
         P00722_A115TotRub = new int[1] ;
         P00722_A114TotTipo = new string[] {""} ;
         P00722_A1829RubSts = new short[1] ;
         P00722_A117RubOrd = new short[1] ;
         P00722_A1823RubDscTot = new string[] {""} ;
         P00722_A1822RubDsc = new string[] {""} ;
         P00722_A116RubCod = new int[1] ;
         P00722_A1928TotDsc = new string[] {""} ;
         AV28Option = "";
         P00723_A115TotRub = new int[1] ;
         P00723_A1822RubDsc = new string[] {""} ;
         P00723_A1829RubSts = new short[1] ;
         P00723_A117RubOrd = new short[1] ;
         P00723_A1823RubDscTot = new string[] {""} ;
         P00723_A116RubCod = new int[1] ;
         P00723_A1928TotDsc = new string[] {""} ;
         P00723_A114TotTipo = new string[] {""} ;
         P00724_A115TotRub = new int[1] ;
         P00724_A1823RubDscTot = new string[] {""} ;
         P00724_A1829RubSts = new short[1] ;
         P00724_A117RubOrd = new short[1] ;
         P00724_A1822RubDsc = new string[] {""} ;
         P00724_A116RubCod = new int[1] ;
         P00724_A1928TotDsc = new string[] {""} ;
         P00724_A114TotTipo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.contabilidad.rubroswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00722_A115TotRub, P00722_A114TotTipo, P00722_A1829RubSts, P00722_A117RubOrd, P00722_A1823RubDscTot, P00722_A1822RubDsc, P00722_A116RubCod, P00722_A1928TotDsc
               }
               , new Object[] {
               P00723_A115TotRub, P00723_A1822RubDsc, P00723_A1829RubSts, P00723_A117RubOrd, P00723_A1823RubDscTot, P00723_A116RubCod, P00723_A1928TotDsc, P00723_A114TotTipo
               }
               , new Object[] {
               P00724_A115TotRub, P00724_A1823RubDscTot, P00724_A1829RubSts, P00724_A117RubOrd, P00724_A1822RubDsc, P00724_A116RubCod, P00724_A1928TotDsc, P00724_A114TotTipo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV20TFRubOrd ;
      private short AV21TFRubOrd_To ;
      private short AV82Contabilidad_rubroswwds_18_tfrubord ;
      private short AV83Contabilidad_rubroswwds_19_tfrubord_to ;
      private short A1829RubSts ;
      private short A117RubOrd ;
      private int AV63GXV1 ;
      private int AV14TFRubCod ;
      private int AV15TFRubCod_To ;
      private int AV76Contabilidad_rubroswwds_12_tfrubcod ;
      private int AV77Contabilidad_rubroswwds_13_tfrubcod_to ;
      private int AV73Contabilidad_rubroswwds_9_tftottipo_sels_Count ;
      private int AV84Contabilidad_rubroswwds_20_tfrubsts_sels_Count ;
      private int A116RubCod ;
      private int A115TotRub ;
      private int AV27InsertIndex ;
      private long AV36count ;
      private string AV53TFTotDsc ;
      private string AV54TFTotDsc_Sel ;
      private string AV16TFRubDsc ;
      private string AV17TFRubDsc_Sel ;
      private string AV18TFRubDscTot ;
      private string AV19TFRubDscTot_Sel ;
      private string AV55TotTipo1 ;
      private string AV56TotTipo2 ;
      private string AV57TotTipo3 ;
      private string AV66Contabilidad_rubroswwds_2_tottipo1 ;
      private string AV69Contabilidad_rubroswwds_5_tottipo2 ;
      private string AV72Contabilidad_rubroswwds_8_tottipo3 ;
      private string AV74Contabilidad_rubroswwds_10_tftotdsc ;
      private string AV75Contabilidad_rubroswwds_11_tftotdsc_sel ;
      private string AV78Contabilidad_rubroswwds_14_tfrubdsc ;
      private string AV79Contabilidad_rubroswwds_15_tfrubdsc_sel ;
      private string AV80Contabilidad_rubroswwds_16_tfrubdsctot ;
      private string AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel ;
      private string scmdbuf ;
      private string lV74Contabilidad_rubroswwds_10_tftotdsc ;
      private string lV78Contabilidad_rubroswwds_14_tfrubdsc ;
      private string lV80Contabilidad_rubroswwds_16_tfrubdsctot ;
      private string A114TotTipo ;
      private string A1928TotDsc ;
      private string A1822RubDsc ;
      private string A1823RubDscTot ;
      private bool returnInSub ;
      private bool AV45DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV67Contabilidad_rubroswwds_3_dynamicfiltersenabled2 ;
      private bool AV70Contabilidad_rubroswwds_6_dynamicfiltersenabled3 ;
      private bool BRK722 ;
      private bool BRK724 ;
      private bool BRK726 ;
      private string AV30OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV35OptionIndexesJson ;
      private string AV10TFTotTipo_SelsJson ;
      private string AV22TFRubSts_SelsJson ;
      private string AV26DDOName ;
      private string AV24SearchTxt ;
      private string AV25SearchTxtTo ;
      private string AV42DynamicFiltersSelector1 ;
      private string AV46DynamicFiltersSelector2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV65Contabilidad_rubroswwds_1_dynamicfiltersselector1 ;
      private string AV68Contabilidad_rubroswwds_4_dynamicfiltersselector2 ;
      private string AV71Contabilidad_rubroswwds_7_dynamicfiltersselector3 ;
      private string AV28Option ;
      private GxSimpleCollection<short> AV23TFRubSts_Sels ;
      private GxSimpleCollection<short> AV84Contabilidad_rubroswwds_20_tfrubsts_sels ;
      private IGxSession AV37Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00722_A115TotRub ;
      private string[] P00722_A114TotTipo ;
      private short[] P00722_A1829RubSts ;
      private short[] P00722_A117RubOrd ;
      private string[] P00722_A1823RubDscTot ;
      private string[] P00722_A1822RubDsc ;
      private int[] P00722_A116RubCod ;
      private string[] P00722_A1928TotDsc ;
      private int[] P00723_A115TotRub ;
      private string[] P00723_A1822RubDsc ;
      private short[] P00723_A1829RubSts ;
      private short[] P00723_A117RubOrd ;
      private string[] P00723_A1823RubDscTot ;
      private int[] P00723_A116RubCod ;
      private string[] P00723_A1928TotDsc ;
      private string[] P00723_A114TotTipo ;
      private int[] P00724_A115TotRub ;
      private string[] P00724_A1823RubDscTot ;
      private short[] P00724_A1829RubSts ;
      private short[] P00724_A117RubOrd ;
      private string[] P00724_A1822RubDsc ;
      private int[] P00724_A116RubCod ;
      private string[] P00724_A1928TotDsc ;
      private string[] P00724_A114TotTipo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV11TFTotTipo_Sels ;
      private GxSimpleCollection<string> AV73Contabilidad_rubroswwds_9_tftottipo_sels ;
      private GxSimpleCollection<string> AV29Options ;
      private GxSimpleCollection<string> AV32OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV39GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV40GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV41GridStateDynamicFilter ;
   }

   public class rubroswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00722( IGxContext context ,
                                             string A114TotTipo ,
                                             GxSimpleCollection<string> AV73Contabilidad_rubroswwds_9_tftottipo_sels ,
                                             short A1829RubSts ,
                                             GxSimpleCollection<short> AV84Contabilidad_rubroswwds_20_tfrubsts_sels ,
                                             string AV65Contabilidad_rubroswwds_1_dynamicfiltersselector1 ,
                                             string AV66Contabilidad_rubroswwds_2_tottipo1 ,
                                             bool AV67Contabilidad_rubroswwds_3_dynamicfiltersenabled2 ,
                                             string AV68Contabilidad_rubroswwds_4_dynamicfiltersselector2 ,
                                             string AV69Contabilidad_rubroswwds_5_tottipo2 ,
                                             bool AV70Contabilidad_rubroswwds_6_dynamicfiltersenabled3 ,
                                             string AV71Contabilidad_rubroswwds_7_dynamicfiltersselector3 ,
                                             string AV72Contabilidad_rubroswwds_8_tottipo3 ,
                                             int AV73Contabilidad_rubroswwds_9_tftottipo_sels_Count ,
                                             string AV75Contabilidad_rubroswwds_11_tftotdsc_sel ,
                                             string AV74Contabilidad_rubroswwds_10_tftotdsc ,
                                             int AV76Contabilidad_rubroswwds_12_tfrubcod ,
                                             int AV77Contabilidad_rubroswwds_13_tfrubcod_to ,
                                             string AV79Contabilidad_rubroswwds_15_tfrubdsc_sel ,
                                             string AV78Contabilidad_rubroswwds_14_tfrubdsc ,
                                             string AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel ,
                                             string AV80Contabilidad_rubroswwds_16_tfrubdsctot ,
                                             short AV82Contabilidad_rubroswwds_18_tfrubord ,
                                             short AV83Contabilidad_rubroswwds_19_tfrubord_to ,
                                             int AV84Contabilidad_rubroswwds_20_tfrubsts_sels_Count ,
                                             string A1928TotDsc ,
                                             int A116RubCod ,
                                             string A1822RubDsc ,
                                             string A1823RubDscTot ,
                                             short A117RubOrd )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[13];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[TotRub], T1.[TotTipo], T1.[RubSts], T1.[RubOrd], T1.[RubDscTot], T1.[RubDsc], T1.[RubCod], T2.[TotDsc] FROM ([CBRUBROS] T1 INNER JOIN [CBRUBROST] T2 ON T2.[TotTipo] = T1.[TotTipo] AND T2.[TotRub] = T1.[TotRub])";
         if ( ( StringUtil.StrCmp(AV65Contabilidad_rubroswwds_1_dynamicfiltersselector1, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_rubroswwds_2_tottipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TotTipo] = @AV66Contabilidad_rubroswwds_2_tottipo1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( AV67Contabilidad_rubroswwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_rubroswwds_4_dynamicfiltersselector2, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_rubroswwds_5_tottipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TotTipo] = @AV69Contabilidad_rubroswwds_5_tottipo2)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV70Contabilidad_rubroswwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Contabilidad_rubroswwds_7_dynamicfiltersselector3, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_rubroswwds_8_tottipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TotTipo] = @AV72Contabilidad_rubroswwds_8_tottipo3)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV73Contabilidad_rubroswwds_9_tftottipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73Contabilidad_rubroswwds_9_tftottipo_sels, "T1.[TotTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_rubroswwds_11_tftotdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_rubroswwds_10_tftotdsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TotDsc] like @lV74Contabilidad_rubroswwds_10_tftotdsc)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_rubroswwds_11_tftotdsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TotDsc] = @AV75Contabilidad_rubroswwds_11_tftotdsc_sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV76Contabilidad_rubroswwds_12_tfrubcod) )
         {
            AddWhere(sWhereString, "(T1.[RubCod] >= @AV76Contabilidad_rubroswwds_12_tfrubcod)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV77Contabilidad_rubroswwds_13_tfrubcod_to) )
         {
            AddWhere(sWhereString, "(T1.[RubCod] <= @AV77Contabilidad_rubroswwds_13_tfrubcod_to)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_rubroswwds_15_tfrubdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_rubroswwds_14_tfrubdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[RubDsc] like @lV78Contabilidad_rubroswwds_14_tfrubdsc)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_rubroswwds_15_tfrubdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[RubDsc] = @AV79Contabilidad_rubroswwds_15_tfrubdsc_sel)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_rubroswwds_16_tfrubdsctot)) ) )
         {
            AddWhere(sWhereString, "(T1.[RubDscTot] like @lV80Contabilidad_rubroswwds_16_tfrubdsctot)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel)) )
         {
            AddWhere(sWhereString, "(T1.[RubDscTot] = @AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (0==AV82Contabilidad_rubroswwds_18_tfrubord) )
         {
            AddWhere(sWhereString, "(T1.[RubOrd] >= @AV82Contabilidad_rubroswwds_18_tfrubord)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (0==AV83Contabilidad_rubroswwds_19_tfrubord_to) )
         {
            AddWhere(sWhereString, "(T1.[RubOrd] <= @AV83Contabilidad_rubroswwds_19_tfrubord_to)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV84Contabilidad_rubroswwds_20_tfrubsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV84Contabilidad_rubroswwds_20_tfrubsts_sels, "T1.[RubSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[TotTipo], T1.[TotRub]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00723( IGxContext context ,
                                             string A114TotTipo ,
                                             GxSimpleCollection<string> AV73Contabilidad_rubroswwds_9_tftottipo_sels ,
                                             short A1829RubSts ,
                                             GxSimpleCollection<short> AV84Contabilidad_rubroswwds_20_tfrubsts_sels ,
                                             string AV65Contabilidad_rubroswwds_1_dynamicfiltersselector1 ,
                                             string AV66Contabilidad_rubroswwds_2_tottipo1 ,
                                             bool AV67Contabilidad_rubroswwds_3_dynamicfiltersenabled2 ,
                                             string AV68Contabilidad_rubroswwds_4_dynamicfiltersselector2 ,
                                             string AV69Contabilidad_rubroswwds_5_tottipo2 ,
                                             bool AV70Contabilidad_rubroswwds_6_dynamicfiltersenabled3 ,
                                             string AV71Contabilidad_rubroswwds_7_dynamicfiltersselector3 ,
                                             string AV72Contabilidad_rubroswwds_8_tottipo3 ,
                                             int AV73Contabilidad_rubroswwds_9_tftottipo_sels_Count ,
                                             string AV75Contabilidad_rubroswwds_11_tftotdsc_sel ,
                                             string AV74Contabilidad_rubroswwds_10_tftotdsc ,
                                             int AV76Contabilidad_rubroswwds_12_tfrubcod ,
                                             int AV77Contabilidad_rubroswwds_13_tfrubcod_to ,
                                             string AV79Contabilidad_rubroswwds_15_tfrubdsc_sel ,
                                             string AV78Contabilidad_rubroswwds_14_tfrubdsc ,
                                             string AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel ,
                                             string AV80Contabilidad_rubroswwds_16_tfrubdsctot ,
                                             short AV82Contabilidad_rubroswwds_18_tfrubord ,
                                             short AV83Contabilidad_rubroswwds_19_tfrubord_to ,
                                             int AV84Contabilidad_rubroswwds_20_tfrubsts_sels_Count ,
                                             string A1928TotDsc ,
                                             int A116RubCod ,
                                             string A1822RubDsc ,
                                             string A1823RubDscTot ,
                                             short A117RubOrd )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[13];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[TotRub], T1.[RubDsc], T1.[RubSts], T1.[RubOrd], T1.[RubDscTot], T1.[RubCod], T2.[TotDsc], T1.[TotTipo] FROM ([CBRUBROS] T1 INNER JOIN [CBRUBROST] T2 ON T2.[TotTipo] = T1.[TotTipo] AND T2.[TotRub] = T1.[TotRub])";
         if ( ( StringUtil.StrCmp(AV65Contabilidad_rubroswwds_1_dynamicfiltersselector1, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_rubroswwds_2_tottipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TotTipo] = @AV66Contabilidad_rubroswwds_2_tottipo1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( AV67Contabilidad_rubroswwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_rubroswwds_4_dynamicfiltersselector2, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_rubroswwds_5_tottipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TotTipo] = @AV69Contabilidad_rubroswwds_5_tottipo2)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV70Contabilidad_rubroswwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Contabilidad_rubroswwds_7_dynamicfiltersselector3, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_rubroswwds_8_tottipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TotTipo] = @AV72Contabilidad_rubroswwds_8_tottipo3)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV73Contabilidad_rubroswwds_9_tftottipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73Contabilidad_rubroswwds_9_tftottipo_sels, "T1.[TotTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_rubroswwds_11_tftotdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_rubroswwds_10_tftotdsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TotDsc] like @lV74Contabilidad_rubroswwds_10_tftotdsc)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_rubroswwds_11_tftotdsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TotDsc] = @AV75Contabilidad_rubroswwds_11_tftotdsc_sel)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV76Contabilidad_rubroswwds_12_tfrubcod) )
         {
            AddWhere(sWhereString, "(T1.[RubCod] >= @AV76Contabilidad_rubroswwds_12_tfrubcod)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV77Contabilidad_rubroswwds_13_tfrubcod_to) )
         {
            AddWhere(sWhereString, "(T1.[RubCod] <= @AV77Contabilidad_rubroswwds_13_tfrubcod_to)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_rubroswwds_15_tfrubdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_rubroswwds_14_tfrubdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[RubDsc] like @lV78Contabilidad_rubroswwds_14_tfrubdsc)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_rubroswwds_15_tfrubdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[RubDsc] = @AV79Contabilidad_rubroswwds_15_tfrubdsc_sel)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_rubroswwds_16_tfrubdsctot)) ) )
         {
            AddWhere(sWhereString, "(T1.[RubDscTot] like @lV80Contabilidad_rubroswwds_16_tfrubdsctot)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel)) )
         {
            AddWhere(sWhereString, "(T1.[RubDscTot] = @AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (0==AV82Contabilidad_rubroswwds_18_tfrubord) )
         {
            AddWhere(sWhereString, "(T1.[RubOrd] >= @AV82Contabilidad_rubroswwds_18_tfrubord)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (0==AV83Contabilidad_rubroswwds_19_tfrubord_to) )
         {
            AddWhere(sWhereString, "(T1.[RubOrd] <= @AV83Contabilidad_rubroswwds_19_tfrubord_to)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV84Contabilidad_rubroswwds_20_tfrubsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV84Contabilidad_rubroswwds_20_tfrubsts_sels, "T1.[RubSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00724( IGxContext context ,
                                             string A114TotTipo ,
                                             GxSimpleCollection<string> AV73Contabilidad_rubroswwds_9_tftottipo_sels ,
                                             short A1829RubSts ,
                                             GxSimpleCollection<short> AV84Contabilidad_rubroswwds_20_tfrubsts_sels ,
                                             string AV65Contabilidad_rubroswwds_1_dynamicfiltersselector1 ,
                                             string AV66Contabilidad_rubroswwds_2_tottipo1 ,
                                             bool AV67Contabilidad_rubroswwds_3_dynamicfiltersenabled2 ,
                                             string AV68Contabilidad_rubroswwds_4_dynamicfiltersselector2 ,
                                             string AV69Contabilidad_rubroswwds_5_tottipo2 ,
                                             bool AV70Contabilidad_rubroswwds_6_dynamicfiltersenabled3 ,
                                             string AV71Contabilidad_rubroswwds_7_dynamicfiltersselector3 ,
                                             string AV72Contabilidad_rubroswwds_8_tottipo3 ,
                                             int AV73Contabilidad_rubroswwds_9_tftottipo_sels_Count ,
                                             string AV75Contabilidad_rubroswwds_11_tftotdsc_sel ,
                                             string AV74Contabilidad_rubroswwds_10_tftotdsc ,
                                             int AV76Contabilidad_rubroswwds_12_tfrubcod ,
                                             int AV77Contabilidad_rubroswwds_13_tfrubcod_to ,
                                             string AV79Contabilidad_rubroswwds_15_tfrubdsc_sel ,
                                             string AV78Contabilidad_rubroswwds_14_tfrubdsc ,
                                             string AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel ,
                                             string AV80Contabilidad_rubroswwds_16_tfrubdsctot ,
                                             short AV82Contabilidad_rubroswwds_18_tfrubord ,
                                             short AV83Contabilidad_rubroswwds_19_tfrubord_to ,
                                             int AV84Contabilidad_rubroswwds_20_tfrubsts_sels_Count ,
                                             string A1928TotDsc ,
                                             int A116RubCod ,
                                             string A1822RubDsc ,
                                             string A1823RubDscTot ,
                                             short A117RubOrd )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[13];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[TotRub], T1.[RubDscTot], T1.[RubSts], T1.[RubOrd], T1.[RubDsc], T1.[RubCod], T2.[TotDsc], T1.[TotTipo] FROM ([CBRUBROS] T1 INNER JOIN [CBRUBROST] T2 ON T2.[TotTipo] = T1.[TotTipo] AND T2.[TotRub] = T1.[TotRub])";
         if ( ( StringUtil.StrCmp(AV65Contabilidad_rubroswwds_1_dynamicfiltersselector1, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Contabilidad_rubroswwds_2_tottipo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[TotTipo] = @AV66Contabilidad_rubroswwds_2_tottipo1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( AV67Contabilidad_rubroswwds_3_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Contabilidad_rubroswwds_4_dynamicfiltersselector2, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Contabilidad_rubroswwds_5_tottipo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[TotTipo] = @AV69Contabilidad_rubroswwds_5_tottipo2)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( AV70Contabilidad_rubroswwds_6_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Contabilidad_rubroswwds_7_dynamicfiltersselector3, "TOTTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Contabilidad_rubroswwds_8_tottipo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[TotTipo] = @AV72Contabilidad_rubroswwds_8_tottipo3)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV73Contabilidad_rubroswwds_9_tftottipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73Contabilidad_rubroswwds_9_tftottipo_sels, "T1.[TotTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_rubroswwds_11_tftotdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Contabilidad_rubroswwds_10_tftotdsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TotDsc] like @lV74Contabilidad_rubroswwds_10_tftotdsc)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Contabilidad_rubroswwds_11_tftotdsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TotDsc] = @AV75Contabilidad_rubroswwds_11_tftotdsc_sel)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (0==AV76Contabilidad_rubroswwds_12_tfrubcod) )
         {
            AddWhere(sWhereString, "(T1.[RubCod] >= @AV76Contabilidad_rubroswwds_12_tfrubcod)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV77Contabilidad_rubroswwds_13_tfrubcod_to) )
         {
            AddWhere(sWhereString, "(T1.[RubCod] <= @AV77Contabilidad_rubroswwds_13_tfrubcod_to)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_rubroswwds_15_tfrubdsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Contabilidad_rubroswwds_14_tfrubdsc)) ) )
         {
            AddWhere(sWhereString, "(T1.[RubDsc] like @lV78Contabilidad_rubroswwds_14_tfrubdsc)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Contabilidad_rubroswwds_15_tfrubdsc_sel)) )
         {
            AddWhere(sWhereString, "(T1.[RubDsc] = @AV79Contabilidad_rubroswwds_15_tfrubdsc_sel)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Contabilidad_rubroswwds_16_tfrubdsctot)) ) )
         {
            AddWhere(sWhereString, "(T1.[RubDscTot] like @lV80Contabilidad_rubroswwds_16_tfrubdsctot)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel)) )
         {
            AddWhere(sWhereString, "(T1.[RubDscTot] = @AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! (0==AV82Contabilidad_rubroswwds_18_tfrubord) )
         {
            AddWhere(sWhereString, "(T1.[RubOrd] >= @AV82Contabilidad_rubroswwds_18_tfrubord)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (0==AV83Contabilidad_rubroswwds_19_tfrubord_to) )
         {
            AddWhere(sWhereString, "(T1.[RubOrd] <= @AV83Contabilidad_rubroswwds_19_tfrubord_to)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV84Contabilidad_rubroswwds_20_tfrubsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV84Contabilidad_rubroswwds_20_tfrubsts_sels, "T1.[RubSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubDscTot]";
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
                     return conditional_P00722(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (short)dynConstraints[28] );
               case 1 :
                     return conditional_P00723(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (short)dynConstraints[28] );
               case 2 :
                     return conditional_P00724(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (int)dynConstraints[15] , (int)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (short)dynConstraints[21] , (short)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (short)dynConstraints[28] );
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
          Object[] prmP00722;
          prmP00722 = new Object[] {
          new ParDef("@AV66Contabilidad_rubroswwds_2_tottipo1",GXType.NChar,3,0) ,
          new ParDef("@AV69Contabilidad_rubroswwds_5_tottipo2",GXType.NChar,3,0) ,
          new ParDef("@AV72Contabilidad_rubroswwds_8_tottipo3",GXType.NChar,3,0) ,
          new ParDef("@lV74Contabilidad_rubroswwds_10_tftotdsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Contabilidad_rubroswwds_11_tftotdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV76Contabilidad_rubroswwds_12_tfrubcod",GXType.Int32,6,0) ,
          new ParDef("@AV77Contabilidad_rubroswwds_13_tfrubcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV78Contabilidad_rubroswwds_14_tfrubdsc",GXType.NChar,100,0) ,
          new ParDef("@AV79Contabilidad_rubroswwds_15_tfrubdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV80Contabilidad_rubroswwds_16_tfrubdsctot",GXType.NChar,100,0) ,
          new ParDef("@AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel",GXType.NChar,100,0) ,
          new ParDef("@AV82Contabilidad_rubroswwds_18_tfrubord",GXType.Int16,2,0) ,
          new ParDef("@AV83Contabilidad_rubroswwds_19_tfrubord_to",GXType.Int16,2,0)
          };
          Object[] prmP00723;
          prmP00723 = new Object[] {
          new ParDef("@AV66Contabilidad_rubroswwds_2_tottipo1",GXType.NChar,3,0) ,
          new ParDef("@AV69Contabilidad_rubroswwds_5_tottipo2",GXType.NChar,3,0) ,
          new ParDef("@AV72Contabilidad_rubroswwds_8_tottipo3",GXType.NChar,3,0) ,
          new ParDef("@lV74Contabilidad_rubroswwds_10_tftotdsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Contabilidad_rubroswwds_11_tftotdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV76Contabilidad_rubroswwds_12_tfrubcod",GXType.Int32,6,0) ,
          new ParDef("@AV77Contabilidad_rubroswwds_13_tfrubcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV78Contabilidad_rubroswwds_14_tfrubdsc",GXType.NChar,100,0) ,
          new ParDef("@AV79Contabilidad_rubroswwds_15_tfrubdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV80Contabilidad_rubroswwds_16_tfrubdsctot",GXType.NChar,100,0) ,
          new ParDef("@AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel",GXType.NChar,100,0) ,
          new ParDef("@AV82Contabilidad_rubroswwds_18_tfrubord",GXType.Int16,2,0) ,
          new ParDef("@AV83Contabilidad_rubroswwds_19_tfrubord_to",GXType.Int16,2,0)
          };
          Object[] prmP00724;
          prmP00724 = new Object[] {
          new ParDef("@AV66Contabilidad_rubroswwds_2_tottipo1",GXType.NChar,3,0) ,
          new ParDef("@AV69Contabilidad_rubroswwds_5_tottipo2",GXType.NChar,3,0) ,
          new ParDef("@AV72Contabilidad_rubroswwds_8_tottipo3",GXType.NChar,3,0) ,
          new ParDef("@lV74Contabilidad_rubroswwds_10_tftotdsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Contabilidad_rubroswwds_11_tftotdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV76Contabilidad_rubroswwds_12_tfrubcod",GXType.Int32,6,0) ,
          new ParDef("@AV77Contabilidad_rubroswwds_13_tfrubcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV78Contabilidad_rubroswwds_14_tfrubdsc",GXType.NChar,100,0) ,
          new ParDef("@AV79Contabilidad_rubroswwds_15_tfrubdsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV80Contabilidad_rubroswwds_16_tfrubdsctot",GXType.NChar,100,0) ,
          new ParDef("@AV81Contabilidad_rubroswwds_17_tfrubdsctot_sel",GXType.NChar,100,0) ,
          new ParDef("@AV82Contabilidad_rubroswwds_18_tfrubord",GXType.Int16,2,0) ,
          new ParDef("@AV83Contabilidad_rubroswwds_19_tfrubord_to",GXType.Int16,2,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00722", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00722,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00723", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00723,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00724", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00724,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((int[]) buf[6])[0] = rslt.getInt(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 3);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 3);
                return;
       }
    }

 }

}
