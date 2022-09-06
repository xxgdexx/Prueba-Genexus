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
   public class vendedoreswwgetfilterdata : GXProcedure
   {
      public vendedoreswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public vendedoreswwgetfilterdata( IGxContext context )
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
         vendedoreswwgetfilterdata objvendedoreswwgetfilterdata;
         objvendedoreswwgetfilterdata = new vendedoreswwgetfilterdata();
         objvendedoreswwgetfilterdata.AV22DDOName = aP0_DDOName;
         objvendedoreswwgetfilterdata.AV20SearchTxt = aP1_SearchTxt;
         objvendedoreswwgetfilterdata.AV21SearchTxtTo = aP2_SearchTxtTo;
         objvendedoreswwgetfilterdata.AV26OptionsJson = "" ;
         objvendedoreswwgetfilterdata.AV29OptionsDescJson = "" ;
         objvendedoreswwgetfilterdata.AV31OptionIndexesJson = "" ;
         objvendedoreswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objvendedoreswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objvendedoreswwgetfilterdata);
         aP3_OptionsJson=this.AV26OptionsJson;
         aP4_OptionsDescJson=this.AV29OptionsDescJson;
         aP5_OptionIndexesJson=this.AV31OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((vendedoreswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_VENDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADVENDSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV22DDOName), "DDO_VENDIR") == 0 )
         {
            /* Execute user subroutine: 'LOADVENDIROPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV33Session.Get("Configuracion.VendedoresWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.VendedoresWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("Configuracion.VendedoresWWGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVENCOD") == 0 )
            {
               AV10TFVenCod = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."));
               AV11TFVenCod_To = (int)(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVENDSC") == 0 )
            {
               AV12TFVenDsc = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVENDSC_SEL") == 0 )
            {
               AV13TFVenDsc_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVENDIR") == 0 )
            {
               AV14TFVenDir = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVENDIR_SEL") == 0 )
            {
               AV15TFVenDir_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVENTIPO_SEL") == 0 )
            {
               AV52TFVenTipo_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV53TFVenTipo_Sels.FromJSonString(AV52TFVenTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFVENSTS_SEL") == 0 )
            {
               AV18TFVenSts_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV19TFVenSts_Sels.FromJSonString(AV18TFVenSts_SelsJson, null);
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "VENDSC") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV41VenDsc1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "VENTIPO") == 0 )
            {
               AV40VenTipo1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV42DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV43DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV43DynamicFiltersSelector2, "VENDSC") == 0 )
               {
                  AV44DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV46VenDsc2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV43DynamicFiltersSelector2, "VENTIPO") == 0 )
               {
                  AV45VenTipo2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "VENDSC") == 0 )
                  {
                     AV49DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV51VenDsc3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "VENTIPO") == 0 )
                  {
                     AV50VenTipo3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADVENDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFVenDsc = AV20SearchTxt;
         AV13TFVenDsc_Sel = "";
         AV58Configuracion_vendedoreswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV59Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV60Configuracion_vendedoreswwds_3_vendsc1 = AV41VenDsc1;
         AV61Configuracion_vendedoreswwds_4_ventipo1 = AV40VenTipo1;
         AV62Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV63Configuracion_vendedoreswwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV64Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV65Configuracion_vendedoreswwds_8_vendsc2 = AV46VenDsc2;
         AV66Configuracion_vendedoreswwds_9_ventipo2 = AV45VenTipo2;
         AV67Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV68Configuracion_vendedoreswwds_11_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV69Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV70Configuracion_vendedoreswwds_13_vendsc3 = AV51VenDsc3;
         AV71Configuracion_vendedoreswwds_14_ventipo3 = AV50VenTipo3;
         AV72Configuracion_vendedoreswwds_15_tfvencod = AV10TFVenCod;
         AV73Configuracion_vendedoreswwds_16_tfvencod_to = AV11TFVenCod_To;
         AV74Configuracion_vendedoreswwds_17_tfvendsc = AV12TFVenDsc;
         AV75Configuracion_vendedoreswwds_18_tfvendsc_sel = AV13TFVenDsc_Sel;
         AV76Configuracion_vendedoreswwds_19_tfvendir = AV14TFVenDir;
         AV77Configuracion_vendedoreswwds_20_tfvendir_sel = AV15TFVenDir_Sel;
         AV78Configuracion_vendedoreswwds_21_tfventipo_sels = AV53TFVenTipo_Sels;
         AV79Configuracion_vendedoreswwds_22_tfvensts_sels = AV19TFVenSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A2049VenTipo ,
                                              AV78Configuracion_vendedoreswwds_21_tfventipo_sels ,
                                              A2047VenSts ,
                                              AV79Configuracion_vendedoreswwds_22_tfvensts_sels ,
                                              AV58Configuracion_vendedoreswwds_1_dynamicfiltersselector1 ,
                                              AV59Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 ,
                                              AV60Configuracion_vendedoreswwds_3_vendsc1 ,
                                              AV61Configuracion_vendedoreswwds_4_ventipo1 ,
                                              AV62Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 ,
                                              AV63Configuracion_vendedoreswwds_6_dynamicfiltersselector2 ,
                                              AV64Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 ,
                                              AV65Configuracion_vendedoreswwds_8_vendsc2 ,
                                              AV66Configuracion_vendedoreswwds_9_ventipo2 ,
                                              AV67Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 ,
                                              AV68Configuracion_vendedoreswwds_11_dynamicfiltersselector3 ,
                                              AV69Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 ,
                                              AV70Configuracion_vendedoreswwds_13_vendsc3 ,
                                              AV71Configuracion_vendedoreswwds_14_ventipo3 ,
                                              AV72Configuracion_vendedoreswwds_15_tfvencod ,
                                              AV73Configuracion_vendedoreswwds_16_tfvencod_to ,
                                              AV75Configuracion_vendedoreswwds_18_tfvendsc_sel ,
                                              AV74Configuracion_vendedoreswwds_17_tfvendsc ,
                                              AV77Configuracion_vendedoreswwds_20_tfvendir_sel ,
                                              AV76Configuracion_vendedoreswwds_19_tfvendir ,
                                              AV78Configuracion_vendedoreswwds_21_tfventipo_sels.Count ,
                                              AV79Configuracion_vendedoreswwds_22_tfvensts_sels.Count ,
                                              A2045VenDsc ,
                                              A309VenCod ,
                                              A2044VenDir } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT
                                              }
         });
         lV60Configuracion_vendedoreswwds_3_vendsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_vendedoreswwds_3_vendsc1), 100, "%");
         lV60Configuracion_vendedoreswwds_3_vendsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_vendedoreswwds_3_vendsc1), 100, "%");
         lV65Configuracion_vendedoreswwds_8_vendsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_vendedoreswwds_8_vendsc2), 100, "%");
         lV65Configuracion_vendedoreswwds_8_vendsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_vendedoreswwds_8_vendsc2), 100, "%");
         lV70Configuracion_vendedoreswwds_13_vendsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_vendedoreswwds_13_vendsc3), 100, "%");
         lV70Configuracion_vendedoreswwds_13_vendsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_vendedoreswwds_13_vendsc3), 100, "%");
         lV74Configuracion_vendedoreswwds_17_tfvendsc = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_vendedoreswwds_17_tfvendsc), 100, "%");
         lV76Configuracion_vendedoreswwds_19_tfvendir = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_vendedoreswwds_19_tfvendir), 100, "%");
         /* Using cursor P00382 */
         pr_default.execute(0, new Object[] {lV60Configuracion_vendedoreswwds_3_vendsc1, lV60Configuracion_vendedoreswwds_3_vendsc1, AV61Configuracion_vendedoreswwds_4_ventipo1, lV65Configuracion_vendedoreswwds_8_vendsc2, lV65Configuracion_vendedoreswwds_8_vendsc2, AV66Configuracion_vendedoreswwds_9_ventipo2, lV70Configuracion_vendedoreswwds_13_vendsc3, lV70Configuracion_vendedoreswwds_13_vendsc3, AV71Configuracion_vendedoreswwds_14_ventipo3, AV72Configuracion_vendedoreswwds_15_tfvencod, AV73Configuracion_vendedoreswwds_16_tfvencod_to, lV74Configuracion_vendedoreswwds_17_tfvendsc, AV75Configuracion_vendedoreswwds_18_tfvendsc_sel, lV76Configuracion_vendedoreswwds_19_tfvendir, AV77Configuracion_vendedoreswwds_20_tfvendir_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK382 = false;
            A2045VenDsc = P00382_A2045VenDsc[0];
            A2047VenSts = P00382_A2047VenSts[0];
            A2044VenDir = P00382_A2044VenDir[0];
            A309VenCod = P00382_A309VenCod[0];
            A2049VenTipo = P00382_A2049VenTipo[0];
            AV32count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00382_A2045VenDsc[0], A2045VenDsc) == 0 ) )
            {
               BRK382 = false;
               A309VenCod = P00382_A309VenCod[0];
               AV32count = (long)(AV32count+1);
               BRK382 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2045VenDsc)) )
            {
               AV24Option = A2045VenDsc;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK382 )
            {
               BRK382 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADVENDIROPTIONS' Routine */
         returnInSub = false;
         AV14TFVenDir = AV20SearchTxt;
         AV15TFVenDir_Sel = "";
         AV58Configuracion_vendedoreswwds_1_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV59Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV60Configuracion_vendedoreswwds_3_vendsc1 = AV41VenDsc1;
         AV61Configuracion_vendedoreswwds_4_ventipo1 = AV40VenTipo1;
         AV62Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 = AV42DynamicFiltersEnabled2;
         AV63Configuracion_vendedoreswwds_6_dynamicfiltersselector2 = AV43DynamicFiltersSelector2;
         AV64Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 = AV44DynamicFiltersOperator2;
         AV65Configuracion_vendedoreswwds_8_vendsc2 = AV46VenDsc2;
         AV66Configuracion_vendedoreswwds_9_ventipo2 = AV45VenTipo2;
         AV67Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV68Configuracion_vendedoreswwds_11_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV69Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV70Configuracion_vendedoreswwds_13_vendsc3 = AV51VenDsc3;
         AV71Configuracion_vendedoreswwds_14_ventipo3 = AV50VenTipo3;
         AV72Configuracion_vendedoreswwds_15_tfvencod = AV10TFVenCod;
         AV73Configuracion_vendedoreswwds_16_tfvencod_to = AV11TFVenCod_To;
         AV74Configuracion_vendedoreswwds_17_tfvendsc = AV12TFVenDsc;
         AV75Configuracion_vendedoreswwds_18_tfvendsc_sel = AV13TFVenDsc_Sel;
         AV76Configuracion_vendedoreswwds_19_tfvendir = AV14TFVenDir;
         AV77Configuracion_vendedoreswwds_20_tfvendir_sel = AV15TFVenDir_Sel;
         AV78Configuracion_vendedoreswwds_21_tfventipo_sels = AV53TFVenTipo_Sels;
         AV79Configuracion_vendedoreswwds_22_tfvensts_sels = AV19TFVenSts_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A2049VenTipo ,
                                              AV78Configuracion_vendedoreswwds_21_tfventipo_sels ,
                                              A2047VenSts ,
                                              AV79Configuracion_vendedoreswwds_22_tfvensts_sels ,
                                              AV58Configuracion_vendedoreswwds_1_dynamicfiltersselector1 ,
                                              AV59Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 ,
                                              AV60Configuracion_vendedoreswwds_3_vendsc1 ,
                                              AV61Configuracion_vendedoreswwds_4_ventipo1 ,
                                              AV62Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 ,
                                              AV63Configuracion_vendedoreswwds_6_dynamicfiltersselector2 ,
                                              AV64Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 ,
                                              AV65Configuracion_vendedoreswwds_8_vendsc2 ,
                                              AV66Configuracion_vendedoreswwds_9_ventipo2 ,
                                              AV67Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 ,
                                              AV68Configuracion_vendedoreswwds_11_dynamicfiltersselector3 ,
                                              AV69Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 ,
                                              AV70Configuracion_vendedoreswwds_13_vendsc3 ,
                                              AV71Configuracion_vendedoreswwds_14_ventipo3 ,
                                              AV72Configuracion_vendedoreswwds_15_tfvencod ,
                                              AV73Configuracion_vendedoreswwds_16_tfvencod_to ,
                                              AV75Configuracion_vendedoreswwds_18_tfvendsc_sel ,
                                              AV74Configuracion_vendedoreswwds_17_tfvendsc ,
                                              AV77Configuracion_vendedoreswwds_20_tfvendir_sel ,
                                              AV76Configuracion_vendedoreswwds_19_tfvendir ,
                                              AV78Configuracion_vendedoreswwds_21_tfventipo_sels.Count ,
                                              AV79Configuracion_vendedoreswwds_22_tfvensts_sels.Count ,
                                              A2045VenDsc ,
                                              A309VenCod ,
                                              A2044VenDir } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.INT
                                              }
         });
         lV60Configuracion_vendedoreswwds_3_vendsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_vendedoreswwds_3_vendsc1), 100, "%");
         lV60Configuracion_vendedoreswwds_3_vendsc1 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_vendedoreswwds_3_vendsc1), 100, "%");
         lV65Configuracion_vendedoreswwds_8_vendsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_vendedoreswwds_8_vendsc2), 100, "%");
         lV65Configuracion_vendedoreswwds_8_vendsc2 = StringUtil.PadR( StringUtil.RTrim( AV65Configuracion_vendedoreswwds_8_vendsc2), 100, "%");
         lV70Configuracion_vendedoreswwds_13_vendsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_vendedoreswwds_13_vendsc3), 100, "%");
         lV70Configuracion_vendedoreswwds_13_vendsc3 = StringUtil.PadR( StringUtil.RTrim( AV70Configuracion_vendedoreswwds_13_vendsc3), 100, "%");
         lV74Configuracion_vendedoreswwds_17_tfvendsc = StringUtil.PadR( StringUtil.RTrim( AV74Configuracion_vendedoreswwds_17_tfvendsc), 100, "%");
         lV76Configuracion_vendedoreswwds_19_tfvendir = StringUtil.PadR( StringUtil.RTrim( AV76Configuracion_vendedoreswwds_19_tfvendir), 100, "%");
         /* Using cursor P00383 */
         pr_default.execute(1, new Object[] {lV60Configuracion_vendedoreswwds_3_vendsc1, lV60Configuracion_vendedoreswwds_3_vendsc1, AV61Configuracion_vendedoreswwds_4_ventipo1, lV65Configuracion_vendedoreswwds_8_vendsc2, lV65Configuracion_vendedoreswwds_8_vendsc2, AV66Configuracion_vendedoreswwds_9_ventipo2, lV70Configuracion_vendedoreswwds_13_vendsc3, lV70Configuracion_vendedoreswwds_13_vendsc3, AV71Configuracion_vendedoreswwds_14_ventipo3, AV72Configuracion_vendedoreswwds_15_tfvencod, AV73Configuracion_vendedoreswwds_16_tfvencod_to, lV74Configuracion_vendedoreswwds_17_tfvendsc, AV75Configuracion_vendedoreswwds_18_tfvendsc_sel, lV76Configuracion_vendedoreswwds_19_tfvendir, AV77Configuracion_vendedoreswwds_20_tfvendir_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK384 = false;
            A2044VenDir = P00383_A2044VenDir[0];
            A2047VenSts = P00383_A2047VenSts[0];
            A309VenCod = P00383_A309VenCod[0];
            A2049VenTipo = P00383_A2049VenTipo[0];
            A2045VenDsc = P00383_A2045VenDsc[0];
            AV32count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00383_A2044VenDir[0], A2044VenDir) == 0 ) )
            {
               BRK384 = false;
               A309VenCod = P00383_A309VenCod[0];
               AV32count = (long)(AV32count+1);
               BRK384 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2044VenDir)) )
            {
               AV24Option = A2044VenDir;
               AV25Options.Add(AV24Option, 0);
               AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV25Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK384 )
            {
               BRK384 = true;
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
         AV12TFVenDsc = "";
         AV13TFVenDsc_Sel = "";
         AV14TFVenDir = "";
         AV15TFVenDir_Sel = "";
         AV52TFVenTipo_SelsJson = "";
         AV53TFVenTipo_Sels = new GxSimpleCollection<string>();
         AV18TFVenSts_SelsJson = "";
         AV19TFVenSts_Sels = new GxSimpleCollection<short>();
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV41VenDsc1 = "";
         AV40VenTipo1 = "";
         AV43DynamicFiltersSelector2 = "";
         AV46VenDsc2 = "";
         AV45VenTipo2 = "";
         AV48DynamicFiltersSelector3 = "";
         AV51VenDsc3 = "";
         AV50VenTipo3 = "";
         AV58Configuracion_vendedoreswwds_1_dynamicfiltersselector1 = "";
         AV60Configuracion_vendedoreswwds_3_vendsc1 = "";
         AV61Configuracion_vendedoreswwds_4_ventipo1 = "";
         AV63Configuracion_vendedoreswwds_6_dynamicfiltersselector2 = "";
         AV65Configuracion_vendedoreswwds_8_vendsc2 = "";
         AV66Configuracion_vendedoreswwds_9_ventipo2 = "";
         AV68Configuracion_vendedoreswwds_11_dynamicfiltersselector3 = "";
         AV70Configuracion_vendedoreswwds_13_vendsc3 = "";
         AV71Configuracion_vendedoreswwds_14_ventipo3 = "";
         AV74Configuracion_vendedoreswwds_17_tfvendsc = "";
         AV75Configuracion_vendedoreswwds_18_tfvendsc_sel = "";
         AV76Configuracion_vendedoreswwds_19_tfvendir = "";
         AV77Configuracion_vendedoreswwds_20_tfvendir_sel = "";
         AV78Configuracion_vendedoreswwds_21_tfventipo_sels = new GxSimpleCollection<string>();
         AV79Configuracion_vendedoreswwds_22_tfvensts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV60Configuracion_vendedoreswwds_3_vendsc1 = "";
         lV65Configuracion_vendedoreswwds_8_vendsc2 = "";
         lV70Configuracion_vendedoreswwds_13_vendsc3 = "";
         lV74Configuracion_vendedoreswwds_17_tfvendsc = "";
         lV76Configuracion_vendedoreswwds_19_tfvendir = "";
         A2049VenTipo = "";
         A2045VenDsc = "";
         A2044VenDir = "";
         P00382_A2045VenDsc = new string[] {""} ;
         P00382_A2047VenSts = new short[1] ;
         P00382_A2044VenDir = new string[] {""} ;
         P00382_A309VenCod = new int[1] ;
         P00382_A2049VenTipo = new string[] {""} ;
         AV24Option = "";
         P00383_A2044VenDir = new string[] {""} ;
         P00383_A2047VenSts = new short[1] ;
         P00383_A309VenCod = new int[1] ;
         P00383_A2049VenTipo = new string[] {""} ;
         P00383_A2045VenDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.vendedoreswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00382_A2045VenDsc, P00382_A2047VenSts, P00382_A2044VenDir, P00382_A309VenCod, P00382_A2049VenTipo
               }
               , new Object[] {
               P00383_A2044VenDir, P00383_A2047VenSts, P00383_A309VenCod, P00383_A2049VenTipo, P00383_A2045VenDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV39DynamicFiltersOperator1 ;
      private short AV44DynamicFiltersOperator2 ;
      private short AV49DynamicFiltersOperator3 ;
      private short AV59Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 ;
      private short AV64Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 ;
      private short AV69Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 ;
      private short A2047VenSts ;
      private int AV56GXV1 ;
      private int AV10TFVenCod ;
      private int AV11TFVenCod_To ;
      private int AV72Configuracion_vendedoreswwds_15_tfvencod ;
      private int AV73Configuracion_vendedoreswwds_16_tfvencod_to ;
      private int AV78Configuracion_vendedoreswwds_21_tfventipo_sels_Count ;
      private int AV79Configuracion_vendedoreswwds_22_tfvensts_sels_Count ;
      private int A309VenCod ;
      private long AV32count ;
      private string AV12TFVenDsc ;
      private string AV13TFVenDsc_Sel ;
      private string AV14TFVenDir ;
      private string AV15TFVenDir_Sel ;
      private string AV41VenDsc1 ;
      private string AV40VenTipo1 ;
      private string AV46VenDsc2 ;
      private string AV45VenTipo2 ;
      private string AV51VenDsc3 ;
      private string AV50VenTipo3 ;
      private string AV60Configuracion_vendedoreswwds_3_vendsc1 ;
      private string AV61Configuracion_vendedoreswwds_4_ventipo1 ;
      private string AV65Configuracion_vendedoreswwds_8_vendsc2 ;
      private string AV66Configuracion_vendedoreswwds_9_ventipo2 ;
      private string AV70Configuracion_vendedoreswwds_13_vendsc3 ;
      private string AV71Configuracion_vendedoreswwds_14_ventipo3 ;
      private string AV74Configuracion_vendedoreswwds_17_tfvendsc ;
      private string AV75Configuracion_vendedoreswwds_18_tfvendsc_sel ;
      private string AV76Configuracion_vendedoreswwds_19_tfvendir ;
      private string AV77Configuracion_vendedoreswwds_20_tfvendir_sel ;
      private string scmdbuf ;
      private string lV60Configuracion_vendedoreswwds_3_vendsc1 ;
      private string lV65Configuracion_vendedoreswwds_8_vendsc2 ;
      private string lV70Configuracion_vendedoreswwds_13_vendsc3 ;
      private string lV74Configuracion_vendedoreswwds_17_tfvendsc ;
      private string lV76Configuracion_vendedoreswwds_19_tfvendir ;
      private string A2049VenTipo ;
      private string A2045VenDsc ;
      private string A2044VenDir ;
      private bool returnInSub ;
      private bool AV42DynamicFiltersEnabled2 ;
      private bool AV47DynamicFiltersEnabled3 ;
      private bool AV62Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 ;
      private bool AV67Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 ;
      private bool BRK382 ;
      private bool BRK384 ;
      private string AV26OptionsJson ;
      private string AV29OptionsDescJson ;
      private string AV31OptionIndexesJson ;
      private string AV52TFVenTipo_SelsJson ;
      private string AV18TFVenSts_SelsJson ;
      private string AV22DDOName ;
      private string AV20SearchTxt ;
      private string AV21SearchTxtTo ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV43DynamicFiltersSelector2 ;
      private string AV48DynamicFiltersSelector3 ;
      private string AV58Configuracion_vendedoreswwds_1_dynamicfiltersselector1 ;
      private string AV63Configuracion_vendedoreswwds_6_dynamicfiltersselector2 ;
      private string AV68Configuracion_vendedoreswwds_11_dynamicfiltersselector3 ;
      private string AV24Option ;
      private GxSimpleCollection<short> AV19TFVenSts_Sels ;
      private GxSimpleCollection<short> AV79Configuracion_vendedoreswwds_22_tfvensts_sels ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00382_A2045VenDsc ;
      private short[] P00382_A2047VenSts ;
      private string[] P00382_A2044VenDir ;
      private int[] P00382_A309VenCod ;
      private string[] P00382_A2049VenTipo ;
      private string[] P00383_A2044VenDir ;
      private short[] P00383_A2047VenSts ;
      private int[] P00383_A309VenCod ;
      private string[] P00383_A2049VenTipo ;
      private string[] P00383_A2045VenDsc ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV53TFVenTipo_Sels ;
      private GxSimpleCollection<string> AV78Configuracion_vendedoreswwds_21_tfventipo_sels ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV28OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV37GridStateDynamicFilter ;
   }

   public class vendedoreswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00382( IGxContext context ,
                                             string A2049VenTipo ,
                                             GxSimpleCollection<string> AV78Configuracion_vendedoreswwds_21_tfventipo_sels ,
                                             short A2047VenSts ,
                                             GxSimpleCollection<short> AV79Configuracion_vendedoreswwds_22_tfvensts_sels ,
                                             string AV58Configuracion_vendedoreswwds_1_dynamicfiltersselector1 ,
                                             short AV59Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 ,
                                             string AV60Configuracion_vendedoreswwds_3_vendsc1 ,
                                             string AV61Configuracion_vendedoreswwds_4_ventipo1 ,
                                             bool AV62Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 ,
                                             string AV63Configuracion_vendedoreswwds_6_dynamicfiltersselector2 ,
                                             short AV64Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 ,
                                             string AV65Configuracion_vendedoreswwds_8_vendsc2 ,
                                             string AV66Configuracion_vendedoreswwds_9_ventipo2 ,
                                             bool AV67Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 ,
                                             string AV68Configuracion_vendedoreswwds_11_dynamicfiltersselector3 ,
                                             short AV69Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 ,
                                             string AV70Configuracion_vendedoreswwds_13_vendsc3 ,
                                             string AV71Configuracion_vendedoreswwds_14_ventipo3 ,
                                             int AV72Configuracion_vendedoreswwds_15_tfvencod ,
                                             int AV73Configuracion_vendedoreswwds_16_tfvencod_to ,
                                             string AV75Configuracion_vendedoreswwds_18_tfvendsc_sel ,
                                             string AV74Configuracion_vendedoreswwds_17_tfvendsc ,
                                             string AV77Configuracion_vendedoreswwds_20_tfvendir_sel ,
                                             string AV76Configuracion_vendedoreswwds_19_tfvendir ,
                                             int AV78Configuracion_vendedoreswwds_21_tfventipo_sels_Count ,
                                             int AV79Configuracion_vendedoreswwds_22_tfvensts_sels_Count ,
                                             string A2045VenDsc ,
                                             int A309VenCod ,
                                             string A2044VenDir )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[15];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [VenDsc], [VenSts], [VenDir], [VenCod], [VenTipo] FROM [CVENDEDORES]";
         if ( ( StringUtil.StrCmp(AV58Configuracion_vendedoreswwds_1_dynamicfiltersselector1, "VENDSC") == 0 ) && ( AV59Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_vendedoreswwds_3_vendsc1)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV60Configuracion_vendedoreswwds_3_vendsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Configuracion_vendedoreswwds_1_dynamicfiltersselector1, "VENDSC") == 0 ) && ( AV59Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_vendedoreswwds_3_vendsc1)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like '%' + @lV60Configuracion_vendedoreswwds_3_vendsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Configuracion_vendedoreswwds_1_dynamicfiltersselector1, "VENTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_vendedoreswwds_4_ventipo1)) ) )
         {
            AddWhere(sWhereString, "([VenTipo] = @AV61Configuracion_vendedoreswwds_4_ventipo1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV62Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_vendedoreswwds_6_dynamicfiltersselector2, "VENDSC") == 0 ) && ( AV64Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_vendedoreswwds_8_vendsc2)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV65Configuracion_vendedoreswwds_8_vendsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV62Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_vendedoreswwds_6_dynamicfiltersselector2, "VENDSC") == 0 ) && ( AV64Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_vendedoreswwds_8_vendsc2)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like '%' + @lV65Configuracion_vendedoreswwds_8_vendsc2)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV62Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_vendedoreswwds_6_dynamicfiltersselector2, "VENTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_vendedoreswwds_9_ventipo2)) ) )
         {
            AddWhere(sWhereString, "([VenTipo] = @AV66Configuracion_vendedoreswwds_9_ventipo2)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV67Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configuracion_vendedoreswwds_11_dynamicfiltersselector3, "VENDSC") == 0 ) && ( AV69Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_vendedoreswwds_13_vendsc3)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV70Configuracion_vendedoreswwds_13_vendsc3)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV67Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configuracion_vendedoreswwds_11_dynamicfiltersselector3, "VENDSC") == 0 ) && ( AV69Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_vendedoreswwds_13_vendsc3)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like '%' + @lV70Configuracion_vendedoreswwds_13_vendsc3)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV67Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configuracion_vendedoreswwds_11_dynamicfiltersselector3, "VENTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_vendedoreswwds_14_ventipo3)) ) )
         {
            AddWhere(sWhereString, "([VenTipo] = @AV71Configuracion_vendedoreswwds_14_ventipo3)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (0==AV72Configuracion_vendedoreswwds_15_tfvencod) )
         {
            AddWhere(sWhereString, "([VenCod] >= @AV72Configuracion_vendedoreswwds_15_tfvencod)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (0==AV73Configuracion_vendedoreswwds_16_tfvencod_to) )
         {
            AddWhere(sWhereString, "([VenCod] <= @AV73Configuracion_vendedoreswwds_16_tfvencod_to)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_vendedoreswwds_18_tfvendsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_vendedoreswwds_17_tfvendsc)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV74Configuracion_vendedoreswwds_17_tfvendsc)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_vendedoreswwds_18_tfvendsc_sel)) )
         {
            AddWhere(sWhereString, "([VenDsc] = @AV75Configuracion_vendedoreswwds_18_tfvendsc_sel)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_vendedoreswwds_20_tfvendir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_vendedoreswwds_19_tfvendir)) ) )
         {
            AddWhere(sWhereString, "([VenDir] like @lV76Configuracion_vendedoreswwds_19_tfvendir)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_vendedoreswwds_20_tfvendir_sel)) )
         {
            AddWhere(sWhereString, "([VenDir] = @AV77Configuracion_vendedoreswwds_20_tfvendir_sel)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV78Configuracion_vendedoreswwds_21_tfventipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Configuracion_vendedoreswwds_21_tfventipo_sels, "[VenTipo] IN (", ")")+")");
         }
         if ( AV79Configuracion_vendedoreswwds_22_tfvensts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Configuracion_vendedoreswwds_22_tfvensts_sels, "[VenSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [VenDsc]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00383( IGxContext context ,
                                             string A2049VenTipo ,
                                             GxSimpleCollection<string> AV78Configuracion_vendedoreswwds_21_tfventipo_sels ,
                                             short A2047VenSts ,
                                             GxSimpleCollection<short> AV79Configuracion_vendedoreswwds_22_tfvensts_sels ,
                                             string AV58Configuracion_vendedoreswwds_1_dynamicfiltersselector1 ,
                                             short AV59Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 ,
                                             string AV60Configuracion_vendedoreswwds_3_vendsc1 ,
                                             string AV61Configuracion_vendedoreswwds_4_ventipo1 ,
                                             bool AV62Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 ,
                                             string AV63Configuracion_vendedoreswwds_6_dynamicfiltersselector2 ,
                                             short AV64Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 ,
                                             string AV65Configuracion_vendedoreswwds_8_vendsc2 ,
                                             string AV66Configuracion_vendedoreswwds_9_ventipo2 ,
                                             bool AV67Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 ,
                                             string AV68Configuracion_vendedoreswwds_11_dynamicfiltersselector3 ,
                                             short AV69Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 ,
                                             string AV70Configuracion_vendedoreswwds_13_vendsc3 ,
                                             string AV71Configuracion_vendedoreswwds_14_ventipo3 ,
                                             int AV72Configuracion_vendedoreswwds_15_tfvencod ,
                                             int AV73Configuracion_vendedoreswwds_16_tfvencod_to ,
                                             string AV75Configuracion_vendedoreswwds_18_tfvendsc_sel ,
                                             string AV74Configuracion_vendedoreswwds_17_tfvendsc ,
                                             string AV77Configuracion_vendedoreswwds_20_tfvendir_sel ,
                                             string AV76Configuracion_vendedoreswwds_19_tfvendir ,
                                             int AV78Configuracion_vendedoreswwds_21_tfventipo_sels_Count ,
                                             int AV79Configuracion_vendedoreswwds_22_tfvensts_sels_Count ,
                                             string A2045VenDsc ,
                                             int A309VenCod ,
                                             string A2044VenDir )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[15];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [VenDir], [VenSts], [VenCod], [VenTipo], [VenDsc] FROM [CVENDEDORES]";
         if ( ( StringUtil.StrCmp(AV58Configuracion_vendedoreswwds_1_dynamicfiltersselector1, "VENDSC") == 0 ) && ( AV59Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_vendedoreswwds_3_vendsc1)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV60Configuracion_vendedoreswwds_3_vendsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Configuracion_vendedoreswwds_1_dynamicfiltersselector1, "VENDSC") == 0 ) && ( AV59Configuracion_vendedoreswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_vendedoreswwds_3_vendsc1)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like '%' + @lV60Configuracion_vendedoreswwds_3_vendsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Configuracion_vendedoreswwds_1_dynamicfiltersselector1, "VENTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Configuracion_vendedoreswwds_4_ventipo1)) ) )
         {
            AddWhere(sWhereString, "([VenTipo] = @AV61Configuracion_vendedoreswwds_4_ventipo1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV62Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_vendedoreswwds_6_dynamicfiltersselector2, "VENDSC") == 0 ) && ( AV64Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_vendedoreswwds_8_vendsc2)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV65Configuracion_vendedoreswwds_8_vendsc2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV62Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_vendedoreswwds_6_dynamicfiltersselector2, "VENDSC") == 0 ) && ( AV64Configuracion_vendedoreswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Configuracion_vendedoreswwds_8_vendsc2)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like '%' + @lV65Configuracion_vendedoreswwds_8_vendsc2)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV62Configuracion_vendedoreswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Configuracion_vendedoreswwds_6_dynamicfiltersselector2, "VENTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configuracion_vendedoreswwds_9_ventipo2)) ) )
         {
            AddWhere(sWhereString, "([VenTipo] = @AV66Configuracion_vendedoreswwds_9_ventipo2)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV67Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configuracion_vendedoreswwds_11_dynamicfiltersselector3, "VENDSC") == 0 ) && ( AV69Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_vendedoreswwds_13_vendsc3)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV70Configuracion_vendedoreswwds_13_vendsc3)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV67Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configuracion_vendedoreswwds_11_dynamicfiltersselector3, "VENDSC") == 0 ) && ( AV69Configuracion_vendedoreswwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configuracion_vendedoreswwds_13_vendsc3)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like '%' + @lV70Configuracion_vendedoreswwds_13_vendsc3)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV67Configuracion_vendedoreswwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configuracion_vendedoreswwds_11_dynamicfiltersselector3, "VENTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configuracion_vendedoreswwds_14_ventipo3)) ) )
         {
            AddWhere(sWhereString, "([VenTipo] = @AV71Configuracion_vendedoreswwds_14_ventipo3)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! (0==AV72Configuracion_vendedoreswwds_15_tfvencod) )
         {
            AddWhere(sWhereString, "([VenCod] >= @AV72Configuracion_vendedoreswwds_15_tfvencod)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (0==AV73Configuracion_vendedoreswwds_16_tfvencod_to) )
         {
            AddWhere(sWhereString, "([VenCod] <= @AV73Configuracion_vendedoreswwds_16_tfvencod_to)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_vendedoreswwds_18_tfvendsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configuracion_vendedoreswwds_17_tfvendsc)) ) )
         {
            AddWhere(sWhereString, "([VenDsc] like @lV74Configuracion_vendedoreswwds_17_tfvendsc)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configuracion_vendedoreswwds_18_tfvendsc_sel)) )
         {
            AddWhere(sWhereString, "([VenDsc] = @AV75Configuracion_vendedoreswwds_18_tfvendsc_sel)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_vendedoreswwds_20_tfvendir_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configuracion_vendedoreswwds_19_tfvendir)) ) )
         {
            AddWhere(sWhereString, "([VenDir] like @lV76Configuracion_vendedoreswwds_19_tfvendir)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configuracion_vendedoreswwds_20_tfvendir_sel)) )
         {
            AddWhere(sWhereString, "([VenDir] = @AV77Configuracion_vendedoreswwds_20_tfvendir_sel)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV78Configuracion_vendedoreswwds_21_tfventipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Configuracion_vendedoreswwds_21_tfventipo_sels, "[VenTipo] IN (", ")")+")");
         }
         if ( AV79Configuracion_vendedoreswwds_22_tfvensts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV79Configuracion_vendedoreswwds_22_tfvensts_sels, "[VenSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [VenDir]";
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
                     return conditional_P00382(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
               case 1 :
                     return conditional_P00383(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (int)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (int)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP00382;
          prmP00382 = new Object[] {
          new ParDef("@lV60Configuracion_vendedoreswwds_3_vendsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Configuracion_vendedoreswwds_3_vendsc1",GXType.NChar,100,0) ,
          new ParDef("@AV61Configuracion_vendedoreswwds_4_ventipo1",GXType.NChar,1,0) ,
          new ParDef("@lV65Configuracion_vendedoreswwds_8_vendsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_vendedoreswwds_8_vendsc2",GXType.NChar,100,0) ,
          new ParDef("@AV66Configuracion_vendedoreswwds_9_ventipo2",GXType.NChar,1,0) ,
          new ParDef("@lV70Configuracion_vendedoreswwds_13_vendsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_vendedoreswwds_13_vendsc3",GXType.NChar,100,0) ,
          new ParDef("@AV71Configuracion_vendedoreswwds_14_ventipo3",GXType.NChar,1,0) ,
          new ParDef("@AV72Configuracion_vendedoreswwds_15_tfvencod",GXType.Int32,6,0) ,
          new ParDef("@AV73Configuracion_vendedoreswwds_16_tfvencod_to",GXType.Int32,6,0) ,
          new ParDef("@lV74Configuracion_vendedoreswwds_17_tfvendsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Configuracion_vendedoreswwds_18_tfvendsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_vendedoreswwds_19_tfvendir",GXType.NChar,100,0) ,
          new ParDef("@AV77Configuracion_vendedoreswwds_20_tfvendir_sel",GXType.NChar,100,0)
          };
          Object[] prmP00383;
          prmP00383 = new Object[] {
          new ParDef("@lV60Configuracion_vendedoreswwds_3_vendsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Configuracion_vendedoreswwds_3_vendsc1",GXType.NChar,100,0) ,
          new ParDef("@AV61Configuracion_vendedoreswwds_4_ventipo1",GXType.NChar,1,0) ,
          new ParDef("@lV65Configuracion_vendedoreswwds_8_vendsc2",GXType.NChar,100,0) ,
          new ParDef("@lV65Configuracion_vendedoreswwds_8_vendsc2",GXType.NChar,100,0) ,
          new ParDef("@AV66Configuracion_vendedoreswwds_9_ventipo2",GXType.NChar,1,0) ,
          new ParDef("@lV70Configuracion_vendedoreswwds_13_vendsc3",GXType.NChar,100,0) ,
          new ParDef("@lV70Configuracion_vendedoreswwds_13_vendsc3",GXType.NChar,100,0) ,
          new ParDef("@AV71Configuracion_vendedoreswwds_14_ventipo3",GXType.NChar,1,0) ,
          new ParDef("@AV72Configuracion_vendedoreswwds_15_tfvencod",GXType.Int32,6,0) ,
          new ParDef("@AV73Configuracion_vendedoreswwds_16_tfvencod_to",GXType.Int32,6,0) ,
          new ParDef("@lV74Configuracion_vendedoreswwds_17_tfvendsc",GXType.NChar,100,0) ,
          new ParDef("@AV75Configuracion_vendedoreswwds_18_tfvendsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV76Configuracion_vendedoreswwds_19_tfvendir",GXType.NChar,100,0) ,
          new ParDef("@AV77Configuracion_vendedoreswwds_20_tfvendir_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00382", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00382,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00383", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00383,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                return;
       }
    }

 }

}
