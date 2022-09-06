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
namespace GeneXus.Programs.seguridad {
   public class numeraciondocumentoswwgetfilterdata : GXProcedure
   {
      public numeraciondocumentoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public numeraciondocumentoswwgetfilterdata( IGxContext context )
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
         this.AV21DDOName = aP0_DDOName;
         this.AV19SearchTxt = aP1_SearchTxt;
         this.AV20SearchTxtTo = aP2_SearchTxtTo;
         this.AV25OptionsJson = "" ;
         this.AV28OptionsDescJson = "" ;
         this.AV30OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV25OptionsJson;
         aP4_OptionsDescJson=this.AV28OptionsDescJson;
         aP5_OptionIndexesJson=this.AV30OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV30OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         numeraciondocumentoswwgetfilterdata objnumeraciondocumentoswwgetfilterdata;
         objnumeraciondocumentoswwgetfilterdata = new numeraciondocumentoswwgetfilterdata();
         objnumeraciondocumentoswwgetfilterdata.AV21DDOName = aP0_DDOName;
         objnumeraciondocumentoswwgetfilterdata.AV19SearchTxt = aP1_SearchTxt;
         objnumeraciondocumentoswwgetfilterdata.AV20SearchTxtTo = aP2_SearchTxtTo;
         objnumeraciondocumentoswwgetfilterdata.AV25OptionsJson = "" ;
         objnumeraciondocumentoswwgetfilterdata.AV28OptionsDescJson = "" ;
         objnumeraciondocumentoswwgetfilterdata.AV30OptionIndexesJson = "" ;
         objnumeraciondocumentoswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objnumeraciondocumentoswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objnumeraciondocumentoswwgetfilterdata);
         aP3_OptionsJson=this.AV25OptionsJson;
         aP4_OptionsDescJson=this.AV28OptionsDescJson;
         aP5_OptionIndexesJson=this.AV30OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((numeraciondocumentoswwgetfilterdata)stateInfo).executePrivate();
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
         AV24Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV21DDOName), "DDO_CORDOC") == 0 )
         {
            /* Execute user subroutine: 'LOADCORDOCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV21DDOName), "DDO_CORSERIE") == 0 )
         {
            /* Execute user subroutine: 'LOADCORSERIEOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV21DDOName), "DDO_CORFORMATO") == 0 )
         {
            /* Execute user subroutine: 'LOADCORFORMATOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV25OptionsJson = AV24Options.ToJSonString(false);
         AV28OptionsDescJson = AV27OptionsDesc.ToJSonString(false);
         AV30OptionIndexesJson = AV29OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("Seguridad.NumeracionDocumentosWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Seguridad.NumeracionDocumentosWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("Seguridad.NumeracionDocumentosWWGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCORDOC") == 0 )
            {
               AV10TFCorDoc = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCORDOC_SEL") == 0 )
            {
               AV11TFCorDoc_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFNUMDOC") == 0 )
            {
               AV12TFNumDoc = (long)(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."));
               AV13TFNumDoc_To = (long)(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCORSERIE") == 0 )
            {
               AV14TFCorSerie = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCORSERIE_SEL") == 0 )
            {
               AV15TFCorSerie_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCORFE_SEL") == 0 )
            {
               AV16TFCorFE_Sel = (short)(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCORFORMATO") == 0 )
            {
               AV17TFCorFormato = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCORFORMATO_SEL") == 0 )
            {
               AV18TFCorFormato_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
         if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(1));
            AV37DynamicFiltersSelector1 = AV36GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV37DynamicFiltersSelector1, "CORDOC") == 0 )
            {
               AV39CorDoc1 = AV36GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37DynamicFiltersSelector1, "NUMDOC") == 0 )
            {
               AV38DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV40NumDoc1 = (long)(NumberUtil.Val( AV36GridStateDynamicFilter.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV37DynamicFiltersSelector1, "CORSERIE") == 0 )
            {
               AV38DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV41CorSerie1 = AV36GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV42DynamicFiltersEnabled2 = true;
               AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV43DynamicFiltersSelector2 = AV36GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV43DynamicFiltersSelector2, "CORDOC") == 0 )
               {
                  AV45CorDoc2 = AV36GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV43DynamicFiltersSelector2, "NUMDOC") == 0 )
               {
                  AV44DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV46NumDoc2 = (long)(NumberUtil.Val( AV36GridStateDynamicFilter.gxTpr_Value, "."));
               }
               else if ( StringUtil.StrCmp(AV43DynamicFiltersSelector2, "CORSERIE") == 0 )
               {
                  AV44DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV47CorSerie2 = AV36GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV48DynamicFiltersEnabled3 = true;
                  AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV49DynamicFiltersSelector3 = AV36GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV49DynamicFiltersSelector3, "CORDOC") == 0 )
                  {
                     AV51CorDoc3 = AV36GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV49DynamicFiltersSelector3, "NUMDOC") == 0 )
                  {
                     AV50DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV52NumDoc3 = (long)(NumberUtil.Val( AV36GridStateDynamicFilter.gxTpr_Value, "."));
                  }
                  else if ( StringUtil.StrCmp(AV49DynamicFiltersSelector3, "CORSERIE") == 0 )
                  {
                     AV50DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV53CorSerie3 = AV36GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCORDOCOPTIONS' Routine */
         returnInSub = false;
         AV10TFCorDoc = AV19SearchTxt;
         AV11TFCorDoc_Sel = "";
         AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = AV37DynamicFiltersSelector1;
         AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 = AV38DynamicFiltersOperator1;
         AV60Seguridad_numeraciondocumentoswwds_3_cordoc1 = AV39CorDoc1;
         AV61Seguridad_numeraciondocumentoswwds_4_numdoc1 = AV40NumDoc1;
         AV62Seguridad_numeraciondocumentoswwds_5_corserie1 = AV41CorSerie1;
         AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV66Seguridad_numeraciondocumentoswwds_9_cordoc2 = AV45CorDoc2;
         AV67Seguridad_numeraciondocumentoswwds_10_numdoc2 = AV46NumDoc2;
         AV68Seguridad_numeraciondocumentoswwds_11_corserie2 = AV47CorSerie2;
         AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV72Seguridad_numeraciondocumentoswwds_15_cordoc3 = AV51CorDoc3;
         AV73Seguridad_numeraciondocumentoswwds_16_numdoc3 = AV52NumDoc3;
         AV74Seguridad_numeraciondocumentoswwds_17_corserie3 = AV53CorSerie3;
         AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc = AV10TFCorDoc;
         AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = AV11TFCorDoc_Sel;
         AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc = AV12TFNumDoc;
         AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to = AV13TFNumDoc_To;
         AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie = AV14TFCorSerie;
         AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = AV15TFCorSerie_Sel;
         AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel = AV16TFCorFE_Sel;
         AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato = AV17TFCorFormato;
         AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = AV18TFCorFormato_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ,
                                              AV60Seguridad_numeraciondocumentoswwds_3_cordoc1 ,
                                              AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ,
                                              AV61Seguridad_numeraciondocumentoswwds_4_numdoc1 ,
                                              AV62Seguridad_numeraciondocumentoswwds_5_corserie1 ,
                                              AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ,
                                              AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ,
                                              AV66Seguridad_numeraciondocumentoswwds_9_cordoc2 ,
                                              AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ,
                                              AV67Seguridad_numeraciondocumentoswwds_10_numdoc2 ,
                                              AV68Seguridad_numeraciondocumentoswwds_11_corserie2 ,
                                              AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ,
                                              AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ,
                                              AV72Seguridad_numeraciondocumentoswwds_15_cordoc3 ,
                                              AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ,
                                              AV73Seguridad_numeraciondocumentoswwds_16_numdoc3 ,
                                              AV74Seguridad_numeraciondocumentoswwds_17_corserie3 ,
                                              AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ,
                                              AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc ,
                                              AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc ,
                                              AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ,
                                              AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ,
                                              AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie ,
                                              AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ,
                                              AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ,
                                              AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato ,
                                              A339CorDoc ,
                                              A1377NumDoc ,
                                              A340CorSerie ,
                                              A756CorFE ,
                                              A757CorFormato } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV62Seguridad_numeraciondocumentoswwds_5_corserie1 = StringUtil.PadR( StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_5_corserie1), 4, "%");
         lV62Seguridad_numeraciondocumentoswwds_5_corserie1 = StringUtil.PadR( StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_5_corserie1), 4, "%");
         lV68Seguridad_numeraciondocumentoswwds_11_corserie2 = StringUtil.PadR( StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_11_corserie2), 4, "%");
         lV68Seguridad_numeraciondocumentoswwds_11_corserie2 = StringUtil.PadR( StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_11_corserie2), 4, "%");
         lV74Seguridad_numeraciondocumentoswwds_17_corserie3 = StringUtil.PadR( StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_17_corserie3), 4, "%");
         lV74Seguridad_numeraciondocumentoswwds_17_corserie3 = StringUtil.PadR( StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_17_corserie3), 4, "%");
         lV75Seguridad_numeraciondocumentoswwds_18_tfcordoc = StringUtil.PadR( StringUtil.RTrim( AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc), 10, "%");
         lV79Seguridad_numeraciondocumentoswwds_22_tfcorserie = StringUtil.PadR( StringUtil.RTrim( AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie), 4, "%");
         lV82Seguridad_numeraciondocumentoswwds_25_tfcorformato = StringUtil.Concat( StringUtil.RTrim( AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato), "%", "");
         /* Using cursor P001J2 */
         pr_default.execute(0, new Object[] {AV60Seguridad_numeraciondocumentoswwds_3_cordoc1, AV61Seguridad_numeraciondocumentoswwds_4_numdoc1, AV61Seguridad_numeraciondocumentoswwds_4_numdoc1, AV61Seguridad_numeraciondocumentoswwds_4_numdoc1, lV62Seguridad_numeraciondocumentoswwds_5_corserie1, lV62Seguridad_numeraciondocumentoswwds_5_corserie1, AV66Seguridad_numeraciondocumentoswwds_9_cordoc2, AV67Seguridad_numeraciondocumentoswwds_10_numdoc2, AV67Seguridad_numeraciondocumentoswwds_10_numdoc2, AV67Seguridad_numeraciondocumentoswwds_10_numdoc2, lV68Seguridad_numeraciondocumentoswwds_11_corserie2, lV68Seguridad_numeraciondocumentoswwds_11_corserie2, AV72Seguridad_numeraciondocumentoswwds_15_cordoc3, AV73Seguridad_numeraciondocumentoswwds_16_numdoc3, AV73Seguridad_numeraciondocumentoswwds_16_numdoc3, AV73Seguridad_numeraciondocumentoswwds_16_numdoc3, lV74Seguridad_numeraciondocumentoswwds_17_corserie3, lV74Seguridad_numeraciondocumentoswwds_17_corserie3, lV75Seguridad_numeraciondocumentoswwds_18_tfcordoc, AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel, AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc, AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to, lV79Seguridad_numeraciondocumentoswwds_22_tfcorserie, AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel, lV82Seguridad_numeraciondocumentoswwds_25_tfcorformato, AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK1J2 = false;
            A339CorDoc = P001J2_A339CorDoc[0];
            A757CorFormato = P001J2_A757CorFormato[0];
            A756CorFE = P001J2_A756CorFE[0];
            A340CorSerie = P001J2_A340CorSerie[0];
            A1377NumDoc = P001J2_A1377NumDoc[0];
            AV31count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P001J2_A339CorDoc[0], A339CorDoc) == 0 ) )
            {
               BRK1J2 = false;
               A340CorSerie = P001J2_A340CorSerie[0];
               AV31count = (long)(AV31count+1);
               BRK1J2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A339CorDoc)) )
            {
               AV23Option = A339CorDoc;
               AV24Options.Add(AV23Option, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV24Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1J2 )
            {
               BRK1J2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCORSERIEOPTIONS' Routine */
         returnInSub = false;
         AV14TFCorSerie = AV19SearchTxt;
         AV15TFCorSerie_Sel = "";
         AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = AV37DynamicFiltersSelector1;
         AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 = AV38DynamicFiltersOperator1;
         AV60Seguridad_numeraciondocumentoswwds_3_cordoc1 = AV39CorDoc1;
         AV61Seguridad_numeraciondocumentoswwds_4_numdoc1 = AV40NumDoc1;
         AV62Seguridad_numeraciondocumentoswwds_5_corserie1 = AV41CorSerie1;
         AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV66Seguridad_numeraciondocumentoswwds_9_cordoc2 = AV45CorDoc2;
         AV67Seguridad_numeraciondocumentoswwds_10_numdoc2 = AV46NumDoc2;
         AV68Seguridad_numeraciondocumentoswwds_11_corserie2 = AV47CorSerie2;
         AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV72Seguridad_numeraciondocumentoswwds_15_cordoc3 = AV51CorDoc3;
         AV73Seguridad_numeraciondocumentoswwds_16_numdoc3 = AV52NumDoc3;
         AV74Seguridad_numeraciondocumentoswwds_17_corserie3 = AV53CorSerie3;
         AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc = AV10TFCorDoc;
         AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = AV11TFCorDoc_Sel;
         AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc = AV12TFNumDoc;
         AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to = AV13TFNumDoc_To;
         AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie = AV14TFCorSerie;
         AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = AV15TFCorSerie_Sel;
         AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel = AV16TFCorFE_Sel;
         AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato = AV17TFCorFormato;
         AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = AV18TFCorFormato_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ,
                                              AV60Seguridad_numeraciondocumentoswwds_3_cordoc1 ,
                                              AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ,
                                              AV61Seguridad_numeraciondocumentoswwds_4_numdoc1 ,
                                              AV62Seguridad_numeraciondocumentoswwds_5_corserie1 ,
                                              AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ,
                                              AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ,
                                              AV66Seguridad_numeraciondocumentoswwds_9_cordoc2 ,
                                              AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ,
                                              AV67Seguridad_numeraciondocumentoswwds_10_numdoc2 ,
                                              AV68Seguridad_numeraciondocumentoswwds_11_corserie2 ,
                                              AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ,
                                              AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ,
                                              AV72Seguridad_numeraciondocumentoswwds_15_cordoc3 ,
                                              AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ,
                                              AV73Seguridad_numeraciondocumentoswwds_16_numdoc3 ,
                                              AV74Seguridad_numeraciondocumentoswwds_17_corserie3 ,
                                              AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ,
                                              AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc ,
                                              AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc ,
                                              AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ,
                                              AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ,
                                              AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie ,
                                              AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ,
                                              AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ,
                                              AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato ,
                                              A339CorDoc ,
                                              A1377NumDoc ,
                                              A340CorSerie ,
                                              A756CorFE ,
                                              A757CorFormato } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV62Seguridad_numeraciondocumentoswwds_5_corserie1 = StringUtil.PadR( StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_5_corserie1), 4, "%");
         lV62Seguridad_numeraciondocumentoswwds_5_corserie1 = StringUtil.PadR( StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_5_corserie1), 4, "%");
         lV68Seguridad_numeraciondocumentoswwds_11_corserie2 = StringUtil.PadR( StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_11_corserie2), 4, "%");
         lV68Seguridad_numeraciondocumentoswwds_11_corserie2 = StringUtil.PadR( StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_11_corserie2), 4, "%");
         lV74Seguridad_numeraciondocumentoswwds_17_corserie3 = StringUtil.PadR( StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_17_corserie3), 4, "%");
         lV74Seguridad_numeraciondocumentoswwds_17_corserie3 = StringUtil.PadR( StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_17_corserie3), 4, "%");
         lV75Seguridad_numeraciondocumentoswwds_18_tfcordoc = StringUtil.PadR( StringUtil.RTrim( AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc), 10, "%");
         lV79Seguridad_numeraciondocumentoswwds_22_tfcorserie = StringUtil.PadR( StringUtil.RTrim( AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie), 4, "%");
         lV82Seguridad_numeraciondocumentoswwds_25_tfcorformato = StringUtil.Concat( StringUtil.RTrim( AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato), "%", "");
         /* Using cursor P001J3 */
         pr_default.execute(1, new Object[] {AV60Seguridad_numeraciondocumentoswwds_3_cordoc1, AV61Seguridad_numeraciondocumentoswwds_4_numdoc1, AV61Seguridad_numeraciondocumentoswwds_4_numdoc1, AV61Seguridad_numeraciondocumentoswwds_4_numdoc1, lV62Seguridad_numeraciondocumentoswwds_5_corserie1, lV62Seguridad_numeraciondocumentoswwds_5_corserie1, AV66Seguridad_numeraciondocumentoswwds_9_cordoc2, AV67Seguridad_numeraciondocumentoswwds_10_numdoc2, AV67Seguridad_numeraciondocumentoswwds_10_numdoc2, AV67Seguridad_numeraciondocumentoswwds_10_numdoc2, lV68Seguridad_numeraciondocumentoswwds_11_corserie2, lV68Seguridad_numeraciondocumentoswwds_11_corserie2, AV72Seguridad_numeraciondocumentoswwds_15_cordoc3, AV73Seguridad_numeraciondocumentoswwds_16_numdoc3, AV73Seguridad_numeraciondocumentoswwds_16_numdoc3, AV73Seguridad_numeraciondocumentoswwds_16_numdoc3, lV74Seguridad_numeraciondocumentoswwds_17_corserie3, lV74Seguridad_numeraciondocumentoswwds_17_corserie3, lV75Seguridad_numeraciondocumentoswwds_18_tfcordoc, AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel, AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc, AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to, lV79Seguridad_numeraciondocumentoswwds_22_tfcorserie, AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel, lV82Seguridad_numeraciondocumentoswwds_25_tfcorformato, AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK1J4 = false;
            A340CorSerie = P001J3_A340CorSerie[0];
            A757CorFormato = P001J3_A757CorFormato[0];
            A756CorFE = P001J3_A756CorFE[0];
            A1377NumDoc = P001J3_A1377NumDoc[0];
            A339CorDoc = P001J3_A339CorDoc[0];
            AV31count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P001J3_A340CorSerie[0], A340CorSerie) == 0 ) )
            {
               BRK1J4 = false;
               A339CorDoc = P001J3_A339CorDoc[0];
               AV31count = (long)(AV31count+1);
               BRK1J4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A340CorSerie)) )
            {
               AV23Option = A340CorSerie;
               AV24Options.Add(AV23Option, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV24Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1J4 )
            {
               BRK1J4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCORFORMATOOPTIONS' Routine */
         returnInSub = false;
         AV17TFCorFormato = AV19SearchTxt;
         AV18TFCorFormato_Sel = "";
         AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = AV37DynamicFiltersSelector1;
         AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 = AV38DynamicFiltersOperator1;
         AV60Seguridad_numeraciondocumentoswwds_3_cordoc1 = AV39CorDoc1;
         AV61Seguridad_numeraciondocumentoswwds_4_numdoc1 = AV40NumDoc1;
         AV62Seguridad_numeraciondocumentoswwds_5_corserie1 = AV41CorSerie1;
         AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV66Seguridad_numeraciondocumentoswwds_9_cordoc2 = AV45CorDoc2;
         AV67Seguridad_numeraciondocumentoswwds_10_numdoc2 = AV46NumDoc2;
         AV68Seguridad_numeraciondocumentoswwds_11_corserie2 = AV47CorSerie2;
         AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV72Seguridad_numeraciondocumentoswwds_15_cordoc3 = AV51CorDoc3;
         AV73Seguridad_numeraciondocumentoswwds_16_numdoc3 = AV52NumDoc3;
         AV74Seguridad_numeraciondocumentoswwds_17_corserie3 = AV53CorSerie3;
         AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc = AV10TFCorDoc;
         AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = AV11TFCorDoc_Sel;
         AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc = AV12TFNumDoc;
         AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to = AV13TFNumDoc_To;
         AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie = AV14TFCorSerie;
         AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = AV15TFCorSerie_Sel;
         AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel = AV16TFCorFE_Sel;
         AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato = AV17TFCorFormato;
         AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = AV18TFCorFormato_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ,
                                              AV60Seguridad_numeraciondocumentoswwds_3_cordoc1 ,
                                              AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ,
                                              AV61Seguridad_numeraciondocumentoswwds_4_numdoc1 ,
                                              AV62Seguridad_numeraciondocumentoswwds_5_corserie1 ,
                                              AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ,
                                              AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ,
                                              AV66Seguridad_numeraciondocumentoswwds_9_cordoc2 ,
                                              AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ,
                                              AV67Seguridad_numeraciondocumentoswwds_10_numdoc2 ,
                                              AV68Seguridad_numeraciondocumentoswwds_11_corserie2 ,
                                              AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ,
                                              AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ,
                                              AV72Seguridad_numeraciondocumentoswwds_15_cordoc3 ,
                                              AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ,
                                              AV73Seguridad_numeraciondocumentoswwds_16_numdoc3 ,
                                              AV74Seguridad_numeraciondocumentoswwds_17_corserie3 ,
                                              AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ,
                                              AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc ,
                                              AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc ,
                                              AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ,
                                              AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ,
                                              AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie ,
                                              AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ,
                                              AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ,
                                              AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato ,
                                              A339CorDoc ,
                                              A1377NumDoc ,
                                              A340CorSerie ,
                                              A756CorFE ,
                                              A757CorFormato } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV62Seguridad_numeraciondocumentoswwds_5_corserie1 = StringUtil.PadR( StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_5_corserie1), 4, "%");
         lV62Seguridad_numeraciondocumentoswwds_5_corserie1 = StringUtil.PadR( StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_5_corserie1), 4, "%");
         lV68Seguridad_numeraciondocumentoswwds_11_corserie2 = StringUtil.PadR( StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_11_corserie2), 4, "%");
         lV68Seguridad_numeraciondocumentoswwds_11_corserie2 = StringUtil.PadR( StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_11_corserie2), 4, "%");
         lV74Seguridad_numeraciondocumentoswwds_17_corserie3 = StringUtil.PadR( StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_17_corserie3), 4, "%");
         lV74Seguridad_numeraciondocumentoswwds_17_corserie3 = StringUtil.PadR( StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_17_corserie3), 4, "%");
         lV75Seguridad_numeraciondocumentoswwds_18_tfcordoc = StringUtil.PadR( StringUtil.RTrim( AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc), 10, "%");
         lV79Seguridad_numeraciondocumentoswwds_22_tfcorserie = StringUtil.PadR( StringUtil.RTrim( AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie), 4, "%");
         lV82Seguridad_numeraciondocumentoswwds_25_tfcorformato = StringUtil.Concat( StringUtil.RTrim( AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato), "%", "");
         /* Using cursor P001J4 */
         pr_default.execute(2, new Object[] {AV60Seguridad_numeraciondocumentoswwds_3_cordoc1, AV61Seguridad_numeraciondocumentoswwds_4_numdoc1, AV61Seguridad_numeraciondocumentoswwds_4_numdoc1, AV61Seguridad_numeraciondocumentoswwds_4_numdoc1, lV62Seguridad_numeraciondocumentoswwds_5_corserie1, lV62Seguridad_numeraciondocumentoswwds_5_corserie1, AV66Seguridad_numeraciondocumentoswwds_9_cordoc2, AV67Seguridad_numeraciondocumentoswwds_10_numdoc2, AV67Seguridad_numeraciondocumentoswwds_10_numdoc2, AV67Seguridad_numeraciondocumentoswwds_10_numdoc2, lV68Seguridad_numeraciondocumentoswwds_11_corserie2, lV68Seguridad_numeraciondocumentoswwds_11_corserie2, AV72Seguridad_numeraciondocumentoswwds_15_cordoc3, AV73Seguridad_numeraciondocumentoswwds_16_numdoc3, AV73Seguridad_numeraciondocumentoswwds_16_numdoc3, AV73Seguridad_numeraciondocumentoswwds_16_numdoc3, lV74Seguridad_numeraciondocumentoswwds_17_corserie3, lV74Seguridad_numeraciondocumentoswwds_17_corserie3, lV75Seguridad_numeraciondocumentoswwds_18_tfcordoc, AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel, AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc, AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to, lV79Seguridad_numeraciondocumentoswwds_22_tfcorserie, AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel, lV82Seguridad_numeraciondocumentoswwds_25_tfcorformato, AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK1J6 = false;
            A757CorFormato = P001J4_A757CorFormato[0];
            A756CorFE = P001J4_A756CorFE[0];
            A340CorSerie = P001J4_A340CorSerie[0];
            A1377NumDoc = P001J4_A1377NumDoc[0];
            A339CorDoc = P001J4_A339CorDoc[0];
            AV31count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P001J4_A757CorFormato[0], A757CorFormato) == 0 ) )
            {
               BRK1J6 = false;
               A340CorSerie = P001J4_A340CorSerie[0];
               A339CorDoc = P001J4_A339CorDoc[0];
               AV31count = (long)(AV31count+1);
               BRK1J6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A757CorFormato)) )
            {
               AV23Option = A757CorFormato;
               AV24Options.Add(AV23Option, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV24Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1J6 )
            {
               BRK1J6 = true;
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
         AV25OptionsJson = "";
         AV28OptionsDescJson = "";
         AV30OptionIndexesJson = "";
         AV24Options = new GxSimpleCollection<string>();
         AV27OptionsDesc = new GxSimpleCollection<string>();
         AV29OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV32Session = context.GetSession();
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TFCorDoc = "";
         AV11TFCorDoc_Sel = "";
         AV14TFCorSerie = "";
         AV15TFCorSerie_Sel = "";
         AV17TFCorFormato = "";
         AV18TFCorFormato_Sel = "";
         AV36GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV37DynamicFiltersSelector1 = "";
         AV39CorDoc1 = "";
         AV41CorSerie1 = "";
         AV43DynamicFiltersSelector2 = "";
         AV45CorDoc2 = "";
         AV47CorSerie2 = "";
         AV49DynamicFiltersSelector3 = "";
         AV51CorDoc3 = "";
         AV53CorSerie3 = "";
         AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 = "";
         AV60Seguridad_numeraciondocumentoswwds_3_cordoc1 = "";
         AV62Seguridad_numeraciondocumentoswwds_5_corserie1 = "";
         AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 = "";
         AV66Seguridad_numeraciondocumentoswwds_9_cordoc2 = "";
         AV68Seguridad_numeraciondocumentoswwds_11_corserie2 = "";
         AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 = "";
         AV72Seguridad_numeraciondocumentoswwds_15_cordoc3 = "";
         AV74Seguridad_numeraciondocumentoswwds_17_corserie3 = "";
         AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc = "";
         AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel = "";
         AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie = "";
         AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel = "";
         AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato = "";
         AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel = "";
         scmdbuf = "";
         lV62Seguridad_numeraciondocumentoswwds_5_corserie1 = "";
         lV68Seguridad_numeraciondocumentoswwds_11_corserie2 = "";
         lV74Seguridad_numeraciondocumentoswwds_17_corserie3 = "";
         lV75Seguridad_numeraciondocumentoswwds_18_tfcordoc = "";
         lV79Seguridad_numeraciondocumentoswwds_22_tfcorserie = "";
         lV82Seguridad_numeraciondocumentoswwds_25_tfcorformato = "";
         A339CorDoc = "";
         A340CorSerie = "";
         A757CorFormato = "";
         P001J2_A339CorDoc = new string[] {""} ;
         P001J2_A757CorFormato = new string[] {""} ;
         P001J2_A756CorFE = new short[1] ;
         P001J2_A340CorSerie = new string[] {""} ;
         P001J2_A1377NumDoc = new long[1] ;
         AV23Option = "";
         P001J3_A340CorSerie = new string[] {""} ;
         P001J3_A757CorFormato = new string[] {""} ;
         P001J3_A756CorFE = new short[1] ;
         P001J3_A1377NumDoc = new long[1] ;
         P001J3_A339CorDoc = new string[] {""} ;
         P001J4_A757CorFormato = new string[] {""} ;
         P001J4_A756CorFE = new short[1] ;
         P001J4_A340CorSerie = new string[] {""} ;
         P001J4_A1377NumDoc = new long[1] ;
         P001J4_A339CorDoc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.numeraciondocumentoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P001J2_A339CorDoc, P001J2_A757CorFormato, P001J2_A756CorFE, P001J2_A340CorSerie, P001J2_A1377NumDoc
               }
               , new Object[] {
               P001J3_A340CorSerie, P001J3_A757CorFormato, P001J3_A756CorFE, P001J3_A1377NumDoc, P001J3_A339CorDoc
               }
               , new Object[] {
               P001J4_A757CorFormato, P001J4_A756CorFE, P001J4_A340CorSerie, P001J4_A1377NumDoc, P001J4_A339CorDoc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV16TFCorFE_Sel ;
      private short AV38DynamicFiltersOperator1 ;
      private short AV44DynamicFiltersOperator2 ;
      private short AV50DynamicFiltersOperator3 ;
      private short AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ;
      private short AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ;
      private short AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ;
      private short AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ;
      private short A756CorFE ;
      private int AV56GXV1 ;
      private long AV12TFNumDoc ;
      private long AV13TFNumDoc_To ;
      private long AV40NumDoc1 ;
      private long AV46NumDoc2 ;
      private long AV52NumDoc3 ;
      private long AV61Seguridad_numeraciondocumentoswwds_4_numdoc1 ;
      private long AV67Seguridad_numeraciondocumentoswwds_10_numdoc2 ;
      private long AV73Seguridad_numeraciondocumentoswwds_16_numdoc3 ;
      private long AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc ;
      private long AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ;
      private long A1377NumDoc ;
      private long AV31count ;
      private string AV10TFCorDoc ;
      private string AV11TFCorDoc_Sel ;
      private string AV14TFCorSerie ;
      private string AV15TFCorSerie_Sel ;
      private string AV39CorDoc1 ;
      private string AV41CorSerie1 ;
      private string AV45CorDoc2 ;
      private string AV47CorSerie2 ;
      private string AV51CorDoc3 ;
      private string AV53CorSerie3 ;
      private string AV60Seguridad_numeraciondocumentoswwds_3_cordoc1 ;
      private string AV62Seguridad_numeraciondocumentoswwds_5_corserie1 ;
      private string AV66Seguridad_numeraciondocumentoswwds_9_cordoc2 ;
      private string AV68Seguridad_numeraciondocumentoswwds_11_corserie2 ;
      private string AV72Seguridad_numeraciondocumentoswwds_15_cordoc3 ;
      private string AV74Seguridad_numeraciondocumentoswwds_17_corserie3 ;
      private string AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc ;
      private string AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ;
      private string AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie ;
      private string AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ;
      private string scmdbuf ;
      private string lV62Seguridad_numeraciondocumentoswwds_5_corserie1 ;
      private string lV68Seguridad_numeraciondocumentoswwds_11_corserie2 ;
      private string lV74Seguridad_numeraciondocumentoswwds_17_corserie3 ;
      private string lV75Seguridad_numeraciondocumentoswwds_18_tfcordoc ;
      private string lV79Seguridad_numeraciondocumentoswwds_22_tfcorserie ;
      private string A339CorDoc ;
      private string A340CorSerie ;
      private bool returnInSub ;
      private bool AV42DynamicFiltersEnabled2 ;
      private bool AV48DynamicFiltersEnabled3 ;
      private bool AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ;
      private bool AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ;
      private bool BRK1J2 ;
      private bool BRK1J4 ;
      private bool BRK1J6 ;
      private string AV25OptionsJson ;
      private string AV28OptionsDescJson ;
      private string AV30OptionIndexesJson ;
      private string AV21DDOName ;
      private string AV19SearchTxt ;
      private string AV20SearchTxtTo ;
      private string AV17TFCorFormato ;
      private string AV18TFCorFormato_Sel ;
      private string AV37DynamicFiltersSelector1 ;
      private string AV43DynamicFiltersSelector2 ;
      private string AV49DynamicFiltersSelector3 ;
      private string AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ;
      private string AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ;
      private string AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ;
      private string AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato ;
      private string AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ;
      private string lV82Seguridad_numeraciondocumentoswwds_25_tfcorformato ;
      private string A757CorFormato ;
      private string AV23Option ;
      private IGxSession AV32Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P001J2_A339CorDoc ;
      private string[] P001J2_A757CorFormato ;
      private short[] P001J2_A756CorFE ;
      private string[] P001J2_A340CorSerie ;
      private long[] P001J2_A1377NumDoc ;
      private string[] P001J3_A340CorSerie ;
      private string[] P001J3_A757CorFormato ;
      private short[] P001J3_A756CorFE ;
      private long[] P001J3_A1377NumDoc ;
      private string[] P001J3_A339CorDoc ;
      private string[] P001J4_A757CorFormato ;
      private short[] P001J4_A756CorFE ;
      private string[] P001J4_A340CorSerie ;
      private long[] P001J4_A1377NumDoc ;
      private string[] P001J4_A339CorDoc ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV24Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV29OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV36GridStateDynamicFilter ;
   }

   public class numeraciondocumentoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001J2( IGxContext context ,
                                             string AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ,
                                             string AV60Seguridad_numeraciondocumentoswwds_3_cordoc1 ,
                                             short AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ,
                                             long AV61Seguridad_numeraciondocumentoswwds_4_numdoc1 ,
                                             string AV62Seguridad_numeraciondocumentoswwds_5_corserie1 ,
                                             bool AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ,
                                             string AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ,
                                             string AV66Seguridad_numeraciondocumentoswwds_9_cordoc2 ,
                                             short AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ,
                                             long AV67Seguridad_numeraciondocumentoswwds_10_numdoc2 ,
                                             string AV68Seguridad_numeraciondocumentoswwds_11_corserie2 ,
                                             bool AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ,
                                             string AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ,
                                             string AV72Seguridad_numeraciondocumentoswwds_15_cordoc3 ,
                                             short AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ,
                                             long AV73Seguridad_numeraciondocumentoswwds_16_numdoc3 ,
                                             string AV74Seguridad_numeraciondocumentoswwds_17_corserie3 ,
                                             string AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ,
                                             string AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc ,
                                             long AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc ,
                                             long AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ,
                                             string AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ,
                                             string AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie ,
                                             short AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ,
                                             string AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ,
                                             string AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato ,
                                             string A339CorDoc ,
                                             long A1377NumDoc ,
                                             string A340CorSerie ,
                                             short A756CorFE ,
                                             string A757CorFormato )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[26];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [CorDoc], [CorFormato], [CorFE], [CorSerie], [NumDoc] FROM [SGCDOCUMENTOS]";
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Seguridad_numeraciondocumentoswwds_3_cordoc1)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV60Seguridad_numeraciondocumentoswwds_3_cordoc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV61Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV61Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV61Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV61Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV61Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV61Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORSERIE") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_5_corserie1)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV62Seguridad_numeraciondocumentoswwds_5_corserie1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORSERIE") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_5_corserie1)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV62Seguridad_numeraciondocumentoswwds_5_corserie1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Seguridad_numeraciondocumentoswwds_9_cordoc2)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV66Seguridad_numeraciondocumentoswwds_9_cordoc2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV67Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV67Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV67Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV67Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV67Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV67Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORSERIE") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_11_corserie2)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV68Seguridad_numeraciondocumentoswwds_11_corserie2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORSERIE") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_11_corserie2)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV68Seguridad_numeraciondocumentoswwds_11_corserie2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Seguridad_numeraciondocumentoswwds_15_cordoc3)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV72Seguridad_numeraciondocumentoswwds_15_cordoc3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV73Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV73Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV73Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV73Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV73Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV73Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORSERIE") == 0 ) && ( AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_17_corserie3)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV74Seguridad_numeraciondocumentoswwds_17_corserie3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORSERIE") == 0 ) && ( AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_17_corserie3)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV74Seguridad_numeraciondocumentoswwds_17_corserie3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] like @lV75Seguridad_numeraciondocumentoswwds_18_tfcordoc)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( ! (0==AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc) )
         {
            AddWhere(sWhereString, "([NumDoc] >= @AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! (0==AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to) )
         {
            AddWhere(sWhereString, "([NumDoc] <= @AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV79Seguridad_numeraciondocumentoswwds_22_tfcorserie)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)) )
         {
            AddWhere(sWhereString, "([CorSerie] = @AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel == 1 )
         {
            AddWhere(sWhereString, "([CorFE] = 1)");
         }
         if ( AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel == 2 )
         {
            AddWhere(sWhereString, "([CorFE] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato)) ) )
         {
            AddWhere(sWhereString, "([CorFormato] like @lV82Seguridad_numeraciondocumentoswwds_25_tfcorformato)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)) )
         {
            AddWhere(sWhereString, "([CorFormato] = @AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CorDoc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P001J3( IGxContext context ,
                                             string AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ,
                                             string AV60Seguridad_numeraciondocumentoswwds_3_cordoc1 ,
                                             short AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ,
                                             long AV61Seguridad_numeraciondocumentoswwds_4_numdoc1 ,
                                             string AV62Seguridad_numeraciondocumentoswwds_5_corserie1 ,
                                             bool AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ,
                                             string AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ,
                                             string AV66Seguridad_numeraciondocumentoswwds_9_cordoc2 ,
                                             short AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ,
                                             long AV67Seguridad_numeraciondocumentoswwds_10_numdoc2 ,
                                             string AV68Seguridad_numeraciondocumentoswwds_11_corserie2 ,
                                             bool AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ,
                                             string AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ,
                                             string AV72Seguridad_numeraciondocumentoswwds_15_cordoc3 ,
                                             short AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ,
                                             long AV73Seguridad_numeraciondocumentoswwds_16_numdoc3 ,
                                             string AV74Seguridad_numeraciondocumentoswwds_17_corserie3 ,
                                             string AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ,
                                             string AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc ,
                                             long AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc ,
                                             long AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ,
                                             string AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ,
                                             string AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie ,
                                             short AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ,
                                             string AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ,
                                             string AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato ,
                                             string A339CorDoc ,
                                             long A1377NumDoc ,
                                             string A340CorSerie ,
                                             short A756CorFE ,
                                             string A757CorFormato )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[26];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [CorSerie], [CorFormato], [CorFE], [NumDoc], [CorDoc] FROM [SGCDOCUMENTOS]";
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Seguridad_numeraciondocumentoswwds_3_cordoc1)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV60Seguridad_numeraciondocumentoswwds_3_cordoc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV61Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV61Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV61Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV61Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV61Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV61Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORSERIE") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_5_corserie1)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV62Seguridad_numeraciondocumentoswwds_5_corserie1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORSERIE") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_5_corserie1)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV62Seguridad_numeraciondocumentoswwds_5_corserie1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Seguridad_numeraciondocumentoswwds_9_cordoc2)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV66Seguridad_numeraciondocumentoswwds_9_cordoc2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV67Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV67Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV67Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV67Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV67Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV67Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORSERIE") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_11_corserie2)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV68Seguridad_numeraciondocumentoswwds_11_corserie2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORSERIE") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_11_corserie2)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV68Seguridad_numeraciondocumentoswwds_11_corserie2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Seguridad_numeraciondocumentoswwds_15_cordoc3)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV72Seguridad_numeraciondocumentoswwds_15_cordoc3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV73Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV73Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV73Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV73Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV73Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV73Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORSERIE") == 0 ) && ( AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_17_corserie3)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV74Seguridad_numeraciondocumentoswwds_17_corserie3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORSERIE") == 0 ) && ( AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_17_corserie3)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV74Seguridad_numeraciondocumentoswwds_17_corserie3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] like @lV75Seguridad_numeraciondocumentoswwds_18_tfcordoc)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( ! (0==AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc) )
         {
            AddWhere(sWhereString, "([NumDoc] >= @AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! (0==AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to) )
         {
            AddWhere(sWhereString, "([NumDoc] <= @AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV79Seguridad_numeraciondocumentoswwds_22_tfcorserie)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)) )
         {
            AddWhere(sWhereString, "([CorSerie] = @AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel == 1 )
         {
            AddWhere(sWhereString, "([CorFE] = 1)");
         }
         if ( AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel == 2 )
         {
            AddWhere(sWhereString, "([CorFE] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato)) ) )
         {
            AddWhere(sWhereString, "([CorFormato] like @lV82Seguridad_numeraciondocumentoswwds_25_tfcorformato)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)) )
         {
            AddWhere(sWhereString, "([CorFormato] = @AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CorSerie]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P001J4( IGxContext context ,
                                             string AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1 ,
                                             string AV60Seguridad_numeraciondocumentoswwds_3_cordoc1 ,
                                             short AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 ,
                                             long AV61Seguridad_numeraciondocumentoswwds_4_numdoc1 ,
                                             string AV62Seguridad_numeraciondocumentoswwds_5_corserie1 ,
                                             bool AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 ,
                                             string AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2 ,
                                             string AV66Seguridad_numeraciondocumentoswwds_9_cordoc2 ,
                                             short AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 ,
                                             long AV67Seguridad_numeraciondocumentoswwds_10_numdoc2 ,
                                             string AV68Seguridad_numeraciondocumentoswwds_11_corserie2 ,
                                             bool AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 ,
                                             string AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3 ,
                                             string AV72Seguridad_numeraciondocumentoswwds_15_cordoc3 ,
                                             short AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 ,
                                             long AV73Seguridad_numeraciondocumentoswwds_16_numdoc3 ,
                                             string AV74Seguridad_numeraciondocumentoswwds_17_corserie3 ,
                                             string AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel ,
                                             string AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc ,
                                             long AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc ,
                                             long AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to ,
                                             string AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel ,
                                             string AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie ,
                                             short AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel ,
                                             string AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel ,
                                             string AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato ,
                                             string A339CorDoc ,
                                             long A1377NumDoc ,
                                             string A340CorSerie ,
                                             short A756CorFE ,
                                             string A757CorFormato )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[26];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [CorFormato], [CorFE], [CorSerie], [NumDoc], [CorDoc] FROM [SGCDOCUMENTOS]";
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Seguridad_numeraciondocumentoswwds_3_cordoc1)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV60Seguridad_numeraciondocumentoswwds_3_cordoc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV61Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV61Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV61Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV61Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "NUMDOC") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV61Seguridad_numeraciondocumentoswwds_4_numdoc1) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV61Seguridad_numeraciondocumentoswwds_4_numdoc1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORSERIE") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_5_corserie1)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV62Seguridad_numeraciondocumentoswwds_5_corserie1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Seguridad_numeraciondocumentoswwds_1_dynamicfiltersselector1, "CORSERIE") == 0 ) && ( AV59Seguridad_numeraciondocumentoswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Seguridad_numeraciondocumentoswwds_5_corserie1)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV62Seguridad_numeraciondocumentoswwds_5_corserie1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Seguridad_numeraciondocumentoswwds_9_cordoc2)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV66Seguridad_numeraciondocumentoswwds_9_cordoc2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV67Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV67Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV67Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV67Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "NUMDOC") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV67Seguridad_numeraciondocumentoswwds_10_numdoc2) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV67Seguridad_numeraciondocumentoswwds_10_numdoc2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORSERIE") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_11_corserie2)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV68Seguridad_numeraciondocumentoswwds_11_corserie2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV63Seguridad_numeraciondocumentoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Seguridad_numeraciondocumentoswwds_7_dynamicfiltersselector2, "CORSERIE") == 0 ) && ( AV65Seguridad_numeraciondocumentoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Seguridad_numeraciondocumentoswwds_11_corserie2)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV68Seguridad_numeraciondocumentoswwds_11_corserie2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORDOC") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Seguridad_numeraciondocumentoswwds_15_cordoc3)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV72Seguridad_numeraciondocumentoswwds_15_cordoc3)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV73Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] < @AV73Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV73Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] = @AV73Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "NUMDOC") == 0 ) && ( AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV73Seguridad_numeraciondocumentoswwds_16_numdoc3) ) )
         {
            AddWhere(sWhereString, "([NumDoc] > @AV73Seguridad_numeraciondocumentoswwds_16_numdoc3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORSERIE") == 0 ) && ( AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_17_corserie3)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV74Seguridad_numeraciondocumentoswwds_17_corserie3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV69Seguridad_numeraciondocumentoswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Seguridad_numeraciondocumentoswwds_13_dynamicfiltersselector3, "CORSERIE") == 0 ) && ( AV71Seguridad_numeraciondocumentoswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_numeraciondocumentoswwds_17_corserie3)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like '%' + @lV74Seguridad_numeraciondocumentoswwds_17_corserie3)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_numeraciondocumentoswwds_18_tfcordoc)) ) )
         {
            AddWhere(sWhereString, "([CorDoc] like @lV75Seguridad_numeraciondocumentoswwds_18_tfcordoc)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)) )
         {
            AddWhere(sWhereString, "([CorDoc] = @AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( ! (0==AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc) )
         {
            AddWhere(sWhereString, "([NumDoc] >= @AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! (0==AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to) )
         {
            AddWhere(sWhereString, "([NumDoc] <= @AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_numeraciondocumentoswwds_22_tfcorserie)) ) )
         {
            AddWhere(sWhereString, "([CorSerie] like @lV79Seguridad_numeraciondocumentoswwds_22_tfcorserie)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)) )
         {
            AddWhere(sWhereString, "([CorSerie] = @AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel == 1 )
         {
            AddWhere(sWhereString, "([CorFE] = 1)");
         }
         if ( AV81Seguridad_numeraciondocumentoswwds_24_tfcorfe_sel == 2 )
         {
            AddWhere(sWhereString, "([CorFE] = 0)");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Seguridad_numeraciondocumentoswwds_25_tfcorformato)) ) )
         {
            AddWhere(sWhereString, "([CorFormato] like @lV82Seguridad_numeraciondocumentoswwds_25_tfcorformato)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)) )
         {
            AddWhere(sWhereString, "([CorFormato] = @AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CorFormato]";
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
                     return conditional_P001J2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] );
               case 1 :
                     return conditional_P001J3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] );
               case 2 :
                     return conditional_P001J4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (long)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (short)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (string)dynConstraints[30] );
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
          Object[] prmP001J2;
          prmP001J2 = new Object[] {
          new ParDef("@AV60Seguridad_numeraciondocumentoswwds_3_cordoc1",GXType.NChar,10,0) ,
          new ParDef("@AV61Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@AV61Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@AV61Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@lV62Seguridad_numeraciondocumentoswwds_5_corserie1",GXType.NChar,4,0) ,
          new ParDef("@lV62Seguridad_numeraciondocumentoswwds_5_corserie1",GXType.NChar,4,0) ,
          new ParDef("@AV66Seguridad_numeraciondocumentoswwds_9_cordoc2",GXType.NChar,10,0) ,
          new ParDef("@AV67Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@AV67Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@AV67Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@lV68Seguridad_numeraciondocumentoswwds_11_corserie2",GXType.NChar,4,0) ,
          new ParDef("@lV68Seguridad_numeraciondocumentoswwds_11_corserie2",GXType.NChar,4,0) ,
          new ParDef("@AV72Seguridad_numeraciondocumentoswwds_15_cordoc3",GXType.NChar,10,0) ,
          new ParDef("@AV73Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@AV73Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@AV73Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@lV74Seguridad_numeraciondocumentoswwds_17_corserie3",GXType.NChar,4,0) ,
          new ParDef("@lV74Seguridad_numeraciondocumentoswwds_17_corserie3",GXType.NChar,4,0) ,
          new ParDef("@lV75Seguridad_numeraciondocumentoswwds_18_tfcordoc",GXType.NChar,10,0) ,
          new ParDef("@AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel",GXType.NChar,10,0) ,
          new ParDef("@AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc",GXType.Decimal,10,0) ,
          new ParDef("@AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to",GXType.Decimal,10,0) ,
          new ParDef("@lV79Seguridad_numeraciondocumentoswwds_22_tfcorserie",GXType.NChar,4,0) ,
          new ParDef("@AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel",GXType.NChar,4,0) ,
          new ParDef("@lV82Seguridad_numeraciondocumentoswwds_25_tfcorformato",GXType.NVarChar,50,0) ,
          new ParDef("@AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel",GXType.NVarChar,50,0)
          };
          Object[] prmP001J3;
          prmP001J3 = new Object[] {
          new ParDef("@AV60Seguridad_numeraciondocumentoswwds_3_cordoc1",GXType.NChar,10,0) ,
          new ParDef("@AV61Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@AV61Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@AV61Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@lV62Seguridad_numeraciondocumentoswwds_5_corserie1",GXType.NChar,4,0) ,
          new ParDef("@lV62Seguridad_numeraciondocumentoswwds_5_corserie1",GXType.NChar,4,0) ,
          new ParDef("@AV66Seguridad_numeraciondocumentoswwds_9_cordoc2",GXType.NChar,10,0) ,
          new ParDef("@AV67Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@AV67Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@AV67Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@lV68Seguridad_numeraciondocumentoswwds_11_corserie2",GXType.NChar,4,0) ,
          new ParDef("@lV68Seguridad_numeraciondocumentoswwds_11_corserie2",GXType.NChar,4,0) ,
          new ParDef("@AV72Seguridad_numeraciondocumentoswwds_15_cordoc3",GXType.NChar,10,0) ,
          new ParDef("@AV73Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@AV73Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@AV73Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@lV74Seguridad_numeraciondocumentoswwds_17_corserie3",GXType.NChar,4,0) ,
          new ParDef("@lV74Seguridad_numeraciondocumentoswwds_17_corserie3",GXType.NChar,4,0) ,
          new ParDef("@lV75Seguridad_numeraciondocumentoswwds_18_tfcordoc",GXType.NChar,10,0) ,
          new ParDef("@AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel",GXType.NChar,10,0) ,
          new ParDef("@AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc",GXType.Decimal,10,0) ,
          new ParDef("@AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to",GXType.Decimal,10,0) ,
          new ParDef("@lV79Seguridad_numeraciondocumentoswwds_22_tfcorserie",GXType.NChar,4,0) ,
          new ParDef("@AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel",GXType.NChar,4,0) ,
          new ParDef("@lV82Seguridad_numeraciondocumentoswwds_25_tfcorformato",GXType.NVarChar,50,0) ,
          new ParDef("@AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel",GXType.NVarChar,50,0)
          };
          Object[] prmP001J4;
          prmP001J4 = new Object[] {
          new ParDef("@AV60Seguridad_numeraciondocumentoswwds_3_cordoc1",GXType.NChar,10,0) ,
          new ParDef("@AV61Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@AV61Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@AV61Seguridad_numeraciondocumentoswwds_4_numdoc1",GXType.Decimal,10,0) ,
          new ParDef("@lV62Seguridad_numeraciondocumentoswwds_5_corserie1",GXType.NChar,4,0) ,
          new ParDef("@lV62Seguridad_numeraciondocumentoswwds_5_corserie1",GXType.NChar,4,0) ,
          new ParDef("@AV66Seguridad_numeraciondocumentoswwds_9_cordoc2",GXType.NChar,10,0) ,
          new ParDef("@AV67Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@AV67Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@AV67Seguridad_numeraciondocumentoswwds_10_numdoc2",GXType.Decimal,10,0) ,
          new ParDef("@lV68Seguridad_numeraciondocumentoswwds_11_corserie2",GXType.NChar,4,0) ,
          new ParDef("@lV68Seguridad_numeraciondocumentoswwds_11_corserie2",GXType.NChar,4,0) ,
          new ParDef("@AV72Seguridad_numeraciondocumentoswwds_15_cordoc3",GXType.NChar,10,0) ,
          new ParDef("@AV73Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@AV73Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@AV73Seguridad_numeraciondocumentoswwds_16_numdoc3",GXType.Decimal,10,0) ,
          new ParDef("@lV74Seguridad_numeraciondocumentoswwds_17_corserie3",GXType.NChar,4,0) ,
          new ParDef("@lV74Seguridad_numeraciondocumentoswwds_17_corserie3",GXType.NChar,4,0) ,
          new ParDef("@lV75Seguridad_numeraciondocumentoswwds_18_tfcordoc",GXType.NChar,10,0) ,
          new ParDef("@AV76Seguridad_numeraciondocumentoswwds_19_tfcordoc_sel",GXType.NChar,10,0) ,
          new ParDef("@AV77Seguridad_numeraciondocumentoswwds_20_tfnumdoc",GXType.Decimal,10,0) ,
          new ParDef("@AV78Seguridad_numeraciondocumentoswwds_21_tfnumdoc_to",GXType.Decimal,10,0) ,
          new ParDef("@lV79Seguridad_numeraciondocumentoswwds_22_tfcorserie",GXType.NChar,4,0) ,
          new ParDef("@AV80Seguridad_numeraciondocumentoswwds_23_tfcorserie_sel",GXType.NChar,4,0) ,
          new ParDef("@lV82Seguridad_numeraciondocumentoswwds_25_tfcorformato",GXType.NVarChar,50,0) ,
          new ParDef("@AV83Seguridad_numeraciondocumentoswwds_26_tfcorformato_sel",GXType.NVarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001J2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001J3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001J4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001J4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 4);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 4);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                return;
       }
    }

 }

}
