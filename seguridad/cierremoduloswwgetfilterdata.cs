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
   public class cierremoduloswwgetfilterdata : GXProcedure
   {
      public cierremoduloswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public cierremoduloswwgetfilterdata( IGxContext context )
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
         this.AV28DDOName = aP0_DDOName;
         this.AV26SearchTxt = aP1_SearchTxt;
         this.AV27SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV37OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV37OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         cierremoduloswwgetfilterdata objcierremoduloswwgetfilterdata;
         objcierremoduloswwgetfilterdata = new cierremoduloswwgetfilterdata();
         objcierremoduloswwgetfilterdata.AV28DDOName = aP0_DDOName;
         objcierremoduloswwgetfilterdata.AV26SearchTxt = aP1_SearchTxt;
         objcierremoduloswwgetfilterdata.AV27SearchTxtTo = aP2_SearchTxtTo;
         objcierremoduloswwgetfilterdata.AV32OptionsJson = "" ;
         objcierremoduloswwgetfilterdata.AV35OptionsDescJson = "" ;
         objcierremoduloswwgetfilterdata.AV37OptionIndexesJson = "" ;
         objcierremoduloswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objcierremoduloswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objcierremoduloswwgetfilterdata);
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((cierremoduloswwgetfilterdata)stateInfo).executePrivate();
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
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_CMMODUSUC") == 0 )
         {
            /* Execute user subroutine: 'LOADCMMODUSUCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_CMMODUSUM") == 0 )
         {
            /* Execute user subroutine: 'LOADCMMODUSUMOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV32OptionsJson = AV31Options.ToJSonString(false);
         AV35OptionsDescJson = AV34OptionsDesc.ToJSonString(false);
         AV37OptionIndexesJson = AV36OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV39Session.Get("Seguridad.CierreModulosWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Seguridad.CierreModulosWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("Seguridad.CierreModulosWWGridState"), null, "", "");
         }
         AV65GXV1 = 1;
         while ( AV65GXV1 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV65GXV1));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "CMMODANO") == 0 )
            {
               AV55CMModAno = (short)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "CMMODMES") == 0 )
            {
               AV56CMModMes = (short)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCMMODANO") == 0 )
            {
               AV12TFCMModAno = (short)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
               AV13TFCMModAno_To = (short)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCMMODMES_SEL") == 0 )
            {
               AV57TFCMModMes_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV58TFCMModMes_Sels.FromJSonString(AV57TFCMModMes_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCMMODCOD_SEL") == 0 )
            {
               AV59TFCMModCod_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV60TFCMModCod_Sels.FromJSonString(AV59TFCMModCod_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCMMODSTS_SEL") == 0 )
            {
               AV61TFCMModSts_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV62TFCMModSts_Sels.FromJSonString(AV61TFCMModSts_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCMMODUSUC") == 0 )
            {
               AV18TFCMModUsuC = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCMMODUSUC_SEL") == 0 )
            {
               AV19TFCMModUsuC_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCMMODFECC") == 0 )
            {
               AV20TFCMModFecC = context.localUtil.CToD( AV42GridStateFilterValue.gxTpr_Value, 2);
               AV21TFCMModFecC_To = context.localUtil.CToD( AV42GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCMMODUSUM") == 0 )
            {
               AV22TFCMModUsuM = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCMMODUSUM_SEL") == 0 )
            {
               AV23TFCMModUsuM_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFCMMODFECM") == 0 )
            {
               AV24TFCMModFecM = context.localUtil.CToD( AV42GridStateFilterValue.gxTpr_Value, 2);
               AV25TFCMModFecM_To = context.localUtil.CToD( AV42GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV65GXV1 = (int)(AV65GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCMMODUSUCOPTIONS' Routine */
         returnInSub = false;
         AV18TFCMModUsuC = AV26SearchTxt;
         AV19TFCMModUsuC_Sel = "";
         AV67Seguridad_cierremoduloswwds_1_cmmodano = AV55CMModAno;
         AV68Seguridad_cierremoduloswwds_2_cmmodmes = AV56CMModMes;
         AV69Seguridad_cierremoduloswwds_3_tfcmmodano = AV12TFCMModAno;
         AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to = AV13TFCMModAno_To;
         AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels = AV58TFCMModMes_Sels;
         AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels = AV60TFCMModCod_Sels;
         AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels = AV62TFCMModSts_Sels;
         AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc = AV18TFCMModUsuC;
         AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel = AV19TFCMModUsuC_Sel;
         AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc = AV20TFCMModFecC;
         AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to = AV21TFCMModFecC_To;
         AV78Seguridad_cierremoduloswwds_12_tfcmmodusum = AV22TFCMModUsuM;
         AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel = AV23TFCMModUsuM_Sel;
         AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm = AV24TFCMModFecM;
         AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to = AV25TFCMModFecM_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A75CMModMes ,
                                              AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ,
                                              A73CMModCod ,
                                              AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ,
                                              A640CMModSts ,
                                              AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ,
                                              AV67Seguridad_cierremoduloswwds_1_cmmodano ,
                                              AV68Seguridad_cierremoduloswwds_2_cmmodmes ,
                                              AV69Seguridad_cierremoduloswwds_3_tfcmmodano ,
                                              AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to ,
                                              AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels.Count ,
                                              AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels.Count ,
                                              AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels.Count ,
                                              AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ,
                                              AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc ,
                                              AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc ,
                                              AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ,
                                              AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ,
                                              AV78Seguridad_cierremoduloswwds_12_tfcmmodusum ,
                                              AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm ,
                                              AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ,
                                              A74CMModAno ,
                                              A641CMModUsuC ,
                                              A638CMModFecC ,
                                              A642CMModUsuM ,
                                              A639CMModFecM } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc = StringUtil.PadR( StringUtil.RTrim( AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc), 10, "%");
         lV78Seguridad_cierremoduloswwds_12_tfcmmodusum = StringUtil.PadR( StringUtil.RTrim( AV78Seguridad_cierremoduloswwds_12_tfcmmodusum), 10, "%");
         /* Using cursor P001B2 */
         pr_default.execute(0, new Object[] {AV67Seguridad_cierremoduloswwds_1_cmmodano, AV68Seguridad_cierremoduloswwds_2_cmmodmes, AV69Seguridad_cierremoduloswwds_3_tfcmmodano, AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to, lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc, AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel, AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc, AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to, lV78Seguridad_cierremoduloswwds_12_tfcmmodusum, AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel, AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm, AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK1B2 = false;
            A641CMModUsuC = P001B2_A641CMModUsuC[0];
            A639CMModFecM = P001B2_A639CMModFecM[0];
            A642CMModUsuM = P001B2_A642CMModUsuM[0];
            A638CMModFecC = P001B2_A638CMModFecC[0];
            A640CMModSts = P001B2_A640CMModSts[0];
            A73CMModCod = P001B2_A73CMModCod[0];
            A75CMModMes = P001B2_A75CMModMes[0];
            A74CMModAno = P001B2_A74CMModAno[0];
            AV38count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P001B2_A641CMModUsuC[0], A641CMModUsuC) == 0 ) )
            {
               BRK1B2 = false;
               A73CMModCod = P001B2_A73CMModCod[0];
               A75CMModMes = P001B2_A75CMModMes[0];
               A74CMModAno = P001B2_A74CMModAno[0];
               AV38count = (long)(AV38count+1);
               BRK1B2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A641CMModUsuC)) )
            {
               AV30Option = A641CMModUsuC;
               AV31Options.Add(AV30Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV31Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1B2 )
            {
               BRK1B2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCMMODUSUMOPTIONS' Routine */
         returnInSub = false;
         AV22TFCMModUsuM = AV26SearchTxt;
         AV23TFCMModUsuM_Sel = "";
         AV67Seguridad_cierremoduloswwds_1_cmmodano = AV55CMModAno;
         AV68Seguridad_cierremoduloswwds_2_cmmodmes = AV56CMModMes;
         AV69Seguridad_cierremoduloswwds_3_tfcmmodano = AV12TFCMModAno;
         AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to = AV13TFCMModAno_To;
         AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels = AV58TFCMModMes_Sels;
         AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels = AV60TFCMModCod_Sels;
         AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels = AV62TFCMModSts_Sels;
         AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc = AV18TFCMModUsuC;
         AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel = AV19TFCMModUsuC_Sel;
         AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc = AV20TFCMModFecC;
         AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to = AV21TFCMModFecC_To;
         AV78Seguridad_cierremoduloswwds_12_tfcmmodusum = AV22TFCMModUsuM;
         AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel = AV23TFCMModUsuM_Sel;
         AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm = AV24TFCMModFecM;
         AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to = AV25TFCMModFecM_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A75CMModMes ,
                                              AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ,
                                              A73CMModCod ,
                                              AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ,
                                              A640CMModSts ,
                                              AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ,
                                              AV67Seguridad_cierremoduloswwds_1_cmmodano ,
                                              AV68Seguridad_cierremoduloswwds_2_cmmodmes ,
                                              AV69Seguridad_cierremoduloswwds_3_tfcmmodano ,
                                              AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to ,
                                              AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels.Count ,
                                              AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels.Count ,
                                              AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels.Count ,
                                              AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ,
                                              AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc ,
                                              AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc ,
                                              AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ,
                                              AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ,
                                              AV78Seguridad_cierremoduloswwds_12_tfcmmodusum ,
                                              AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm ,
                                              AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ,
                                              A74CMModAno ,
                                              A641CMModUsuC ,
                                              A638CMModFecC ,
                                              A642CMModUsuM ,
                                              A639CMModFecM } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc = StringUtil.PadR( StringUtil.RTrim( AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc), 10, "%");
         lV78Seguridad_cierremoduloswwds_12_tfcmmodusum = StringUtil.PadR( StringUtil.RTrim( AV78Seguridad_cierremoduloswwds_12_tfcmmodusum), 10, "%");
         /* Using cursor P001B3 */
         pr_default.execute(1, new Object[] {AV67Seguridad_cierremoduloswwds_1_cmmodano, AV68Seguridad_cierremoduloswwds_2_cmmodmes, AV69Seguridad_cierremoduloswwds_3_tfcmmodano, AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to, lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc, AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel, AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc, AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to, lV78Seguridad_cierremoduloswwds_12_tfcmmodusum, AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel, AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm, AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK1B4 = false;
            A642CMModUsuM = P001B3_A642CMModUsuM[0];
            A639CMModFecM = P001B3_A639CMModFecM[0];
            A638CMModFecC = P001B3_A638CMModFecC[0];
            A641CMModUsuC = P001B3_A641CMModUsuC[0];
            A640CMModSts = P001B3_A640CMModSts[0];
            A73CMModCod = P001B3_A73CMModCod[0];
            A75CMModMes = P001B3_A75CMModMes[0];
            A74CMModAno = P001B3_A74CMModAno[0];
            AV38count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P001B3_A642CMModUsuM[0], A642CMModUsuM) == 0 ) )
            {
               BRK1B4 = false;
               A73CMModCod = P001B3_A73CMModCod[0];
               A75CMModMes = P001B3_A75CMModMes[0];
               A74CMModAno = P001B3_A74CMModAno[0];
               AV38count = (long)(AV38count+1);
               BRK1B4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A642CMModUsuM)) )
            {
               AV30Option = A642CMModUsuM;
               AV31Options.Add(AV30Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV31Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1B4 )
            {
               BRK1B4 = true;
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
         AV32OptionsJson = "";
         AV35OptionsDescJson = "";
         AV37OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV34OptionsDesc = new GxSimpleCollection<string>();
         AV36OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV39Session = context.GetSession();
         AV41GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV42GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV57TFCMModMes_SelsJson = "";
         AV58TFCMModMes_Sels = new GxSimpleCollection<short>();
         AV59TFCMModCod_SelsJson = "";
         AV60TFCMModCod_Sels = new GxSimpleCollection<string>();
         AV61TFCMModSts_SelsJson = "";
         AV62TFCMModSts_Sels = new GxSimpleCollection<short>();
         AV18TFCMModUsuC = "";
         AV19TFCMModUsuC_Sel = "";
         AV20TFCMModFecC = DateTime.MinValue;
         AV21TFCMModFecC_To = DateTime.MinValue;
         AV22TFCMModUsuM = "";
         AV23TFCMModUsuM_Sel = "";
         AV24TFCMModFecM = DateTime.MinValue;
         AV25TFCMModFecM_To = DateTime.MinValue;
         AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels = new GxSimpleCollection<short>();
         AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels = new GxSimpleCollection<string>();
         AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels = new GxSimpleCollection<short>();
         AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc = "";
         AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel = "";
         AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc = DateTime.MinValue;
         AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to = DateTime.MinValue;
         AV78Seguridad_cierremoduloswwds_12_tfcmmodusum = "";
         AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel = "";
         AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm = DateTime.MinValue;
         AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to = DateTime.MinValue;
         scmdbuf = "";
         lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc = "";
         lV78Seguridad_cierremoduloswwds_12_tfcmmodusum = "";
         A73CMModCod = "";
         A641CMModUsuC = "";
         A638CMModFecC = DateTime.MinValue;
         A642CMModUsuM = "";
         A639CMModFecM = DateTime.MinValue;
         P001B2_A641CMModUsuC = new string[] {""} ;
         P001B2_A639CMModFecM = new DateTime[] {DateTime.MinValue} ;
         P001B2_A642CMModUsuM = new string[] {""} ;
         P001B2_A638CMModFecC = new DateTime[] {DateTime.MinValue} ;
         P001B2_A640CMModSts = new short[1] ;
         P001B2_A73CMModCod = new string[] {""} ;
         P001B2_A75CMModMes = new short[1] ;
         P001B2_A74CMModAno = new short[1] ;
         AV30Option = "";
         P001B3_A642CMModUsuM = new string[] {""} ;
         P001B3_A639CMModFecM = new DateTime[] {DateTime.MinValue} ;
         P001B3_A638CMModFecC = new DateTime[] {DateTime.MinValue} ;
         P001B3_A641CMModUsuC = new string[] {""} ;
         P001B3_A640CMModSts = new short[1] ;
         P001B3_A73CMModCod = new string[] {""} ;
         P001B3_A75CMModMes = new short[1] ;
         P001B3_A74CMModAno = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.cierremoduloswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P001B2_A641CMModUsuC, P001B2_A639CMModFecM, P001B2_A642CMModUsuM, P001B2_A638CMModFecC, P001B2_A640CMModSts, P001B2_A73CMModCod, P001B2_A75CMModMes, P001B2_A74CMModAno
               }
               , new Object[] {
               P001B3_A642CMModUsuM, P001B3_A639CMModFecM, P001B3_A638CMModFecC, P001B3_A641CMModUsuC, P001B3_A640CMModSts, P001B3_A73CMModCod, P001B3_A75CMModMes, P001B3_A74CMModAno
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV55CMModAno ;
      private short AV56CMModMes ;
      private short AV12TFCMModAno ;
      private short AV13TFCMModAno_To ;
      private short AV67Seguridad_cierremoduloswwds_1_cmmodano ;
      private short AV68Seguridad_cierremoduloswwds_2_cmmodmes ;
      private short AV69Seguridad_cierremoduloswwds_3_tfcmmodano ;
      private short AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to ;
      private short A75CMModMes ;
      private short A640CMModSts ;
      private short A74CMModAno ;
      private int AV65GXV1 ;
      private int AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count ;
      private int AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count ;
      private int AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count ;
      private long AV38count ;
      private string AV18TFCMModUsuC ;
      private string AV19TFCMModUsuC_Sel ;
      private string AV22TFCMModUsuM ;
      private string AV23TFCMModUsuM_Sel ;
      private string AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc ;
      private string AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ;
      private string AV78Seguridad_cierremoduloswwds_12_tfcmmodusum ;
      private string AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ;
      private string scmdbuf ;
      private string lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc ;
      private string lV78Seguridad_cierremoduloswwds_12_tfcmmodusum ;
      private string A73CMModCod ;
      private string A641CMModUsuC ;
      private string A642CMModUsuM ;
      private DateTime AV20TFCMModFecC ;
      private DateTime AV21TFCMModFecC_To ;
      private DateTime AV24TFCMModFecM ;
      private DateTime AV25TFCMModFecM_To ;
      private DateTime AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc ;
      private DateTime AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ;
      private DateTime AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm ;
      private DateTime AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ;
      private DateTime A638CMModFecC ;
      private DateTime A639CMModFecM ;
      private bool returnInSub ;
      private bool BRK1B2 ;
      private bool BRK1B4 ;
      private string AV32OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string AV57TFCMModMes_SelsJson ;
      private string AV59TFCMModCod_SelsJson ;
      private string AV61TFCMModSts_SelsJson ;
      private string AV28DDOName ;
      private string AV26SearchTxt ;
      private string AV27SearchTxtTo ;
      private string AV30Option ;
      private GxSimpleCollection<short> AV58TFCMModMes_Sels ;
      private GxSimpleCollection<short> AV62TFCMModSts_Sels ;
      private GxSimpleCollection<short> AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ;
      private GxSimpleCollection<short> AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ;
      private IGxSession AV39Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P001B2_A641CMModUsuC ;
      private DateTime[] P001B2_A639CMModFecM ;
      private string[] P001B2_A642CMModUsuM ;
      private DateTime[] P001B2_A638CMModFecC ;
      private short[] P001B2_A640CMModSts ;
      private string[] P001B2_A73CMModCod ;
      private short[] P001B2_A75CMModMes ;
      private short[] P001B2_A74CMModAno ;
      private string[] P001B3_A642CMModUsuM ;
      private DateTime[] P001B3_A639CMModFecM ;
      private DateTime[] P001B3_A638CMModFecC ;
      private string[] P001B3_A641CMModUsuC ;
      private short[] P001B3_A640CMModSts ;
      private string[] P001B3_A73CMModCod ;
      private short[] P001B3_A75CMModMes ;
      private short[] P001B3_A74CMModAno ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV60TFCMModCod_Sels ;
      private GxSimpleCollection<string> AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV34OptionsDesc ;
      private GxSimpleCollection<string> AV36OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
   }

   public class cierremoduloswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001B2( IGxContext context ,
                                             short A75CMModMes ,
                                             GxSimpleCollection<short> AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ,
                                             string A73CMModCod ,
                                             GxSimpleCollection<string> AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ,
                                             short A640CMModSts ,
                                             GxSimpleCollection<short> AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ,
                                             short AV67Seguridad_cierremoduloswwds_1_cmmodano ,
                                             short AV68Seguridad_cierremoduloswwds_2_cmmodmes ,
                                             short AV69Seguridad_cierremoduloswwds_3_tfcmmodano ,
                                             short AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to ,
                                             int AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count ,
                                             int AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count ,
                                             int AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count ,
                                             string AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ,
                                             string AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc ,
                                             DateTime AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc ,
                                             DateTime AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ,
                                             string AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ,
                                             string AV78Seguridad_cierremoduloswwds_12_tfcmmodusum ,
                                             DateTime AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm ,
                                             DateTime AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ,
                                             short A74CMModAno ,
                                             string A641CMModUsuC ,
                                             DateTime A638CMModFecC ,
                                             string A642CMModUsuM ,
                                             DateTime A639CMModFecM )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[12];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [CMModUsuC], [CMModFecM], [CMModUsuM], [CMModFecC], [CMModSts], [CMModCod], [CMModMes], [CMModAno] FROM [CBCIERREMODULO]";
         if ( ! (0==AV67Seguridad_cierremoduloswwds_1_cmmodano) )
         {
            AddWhere(sWhereString, "([CMModAno] = @AV67Seguridad_cierremoduloswwds_1_cmmodano)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV68Seguridad_cierremoduloswwds_2_cmmodmes) )
         {
            AddWhere(sWhereString, "([CMModMes] = @AV68Seguridad_cierremoduloswwds_2_cmmodmes)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (0==AV69Seguridad_cierremoduloswwds_3_tfcmmodano) )
         {
            AddWhere(sWhereString, "([CMModAno] >= @AV69Seguridad_cierremoduloswwds_3_tfcmmodano)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (0==AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to) )
         {
            AddWhere(sWhereString, "([CMModAno] <= @AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels, "[CMModMes] IN (", ")")+")");
         }
         if ( AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels, "[CMModCod] IN (", ")")+")");
         }
         if ( AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels, "[CMModSts] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc)) ) )
         {
            AddWhere(sWhereString, "([CMModUsuC] like @lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)) )
         {
            AddWhere(sWhereString, "([CMModUsuC] = @AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc) )
         {
            AddWhere(sWhereString, "([CMModFecC] >= @AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to) )
         {
            AddWhere(sWhereString, "([CMModFecC] <= @AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Seguridad_cierremoduloswwds_12_tfcmmodusum)) ) )
         {
            AddWhere(sWhereString, "([CMModUsuM] like @lV78Seguridad_cierremoduloswwds_12_tfcmmodusum)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)) )
         {
            AddWhere(sWhereString, "([CMModUsuM] = @AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm) )
         {
            AddWhere(sWhereString, "([CMModFecM] >= @AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to) )
         {
            AddWhere(sWhereString, "([CMModFecM] <= @AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CMModUsuC]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P001B3( IGxContext context ,
                                             short A75CMModMes ,
                                             GxSimpleCollection<short> AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels ,
                                             string A73CMModCod ,
                                             GxSimpleCollection<string> AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels ,
                                             short A640CMModSts ,
                                             GxSimpleCollection<short> AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels ,
                                             short AV67Seguridad_cierremoduloswwds_1_cmmodano ,
                                             short AV68Seguridad_cierremoduloswwds_2_cmmodmes ,
                                             short AV69Seguridad_cierremoduloswwds_3_tfcmmodano ,
                                             short AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to ,
                                             int AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count ,
                                             int AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count ,
                                             int AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count ,
                                             string AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel ,
                                             string AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc ,
                                             DateTime AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc ,
                                             DateTime AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to ,
                                             string AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel ,
                                             string AV78Seguridad_cierremoduloswwds_12_tfcmmodusum ,
                                             DateTime AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm ,
                                             DateTime AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to ,
                                             short A74CMModAno ,
                                             string A641CMModUsuC ,
                                             DateTime A638CMModFecC ,
                                             string A642CMModUsuM ,
                                             DateTime A639CMModFecM )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[12];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [CMModUsuM], [CMModFecM], [CMModFecC], [CMModUsuC], [CMModSts], [CMModCod], [CMModMes], [CMModAno] FROM [CBCIERREMODULO]";
         if ( ! (0==AV67Seguridad_cierremoduloswwds_1_cmmodano) )
         {
            AddWhere(sWhereString, "([CMModAno] = @AV67Seguridad_cierremoduloswwds_1_cmmodano)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV68Seguridad_cierremoduloswwds_2_cmmodmes) )
         {
            AddWhere(sWhereString, "([CMModMes] = @AV68Seguridad_cierremoduloswwds_2_cmmodmes)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! (0==AV69Seguridad_cierremoduloswwds_3_tfcmmodano) )
         {
            AddWhere(sWhereString, "([CMModAno] >= @AV69Seguridad_cierremoduloswwds_3_tfcmmodano)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to) )
         {
            AddWhere(sWhereString, "([CMModAno] <= @AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71Seguridad_cierremoduloswwds_5_tfcmmodmes_sels, "[CMModMes] IN (", ")")+")");
         }
         if ( AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Seguridad_cierremoduloswwds_6_tfcmmodcod_sels, "[CMModCod] IN (", ")")+")");
         }
         if ( AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73Seguridad_cierremoduloswwds_7_tfcmmodsts_sels, "[CMModSts] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_cierremoduloswwds_8_tfcmmodusuc)) ) )
         {
            AddWhere(sWhereString, "([CMModUsuC] like @lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)) )
         {
            AddWhere(sWhereString, "([CMModUsuC] = @AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc) )
         {
            AddWhere(sWhereString, "([CMModFecC] >= @AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to) )
         {
            AddWhere(sWhereString, "([CMModFecC] <= @AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Seguridad_cierremoduloswwds_12_tfcmmodusum)) ) )
         {
            AddWhere(sWhereString, "([CMModUsuM] like @lV78Seguridad_cierremoduloswwds_12_tfcmmodusum)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)) )
         {
            AddWhere(sWhereString, "([CMModUsuM] = @AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm) )
         {
            AddWhere(sWhereString, "([CMModFecM] >= @AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to) )
         {
            AddWhere(sWhereString, "([CMModFecM] <= @AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CMModUsuM]";
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
                     return conditional_P001B2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (GxSimpleCollection<short>)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] );
               case 1 :
                     return conditional_P001B3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (GxSimpleCollection<short>)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (int)dynConstraints[10] , (int)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] , (string)dynConstraints[24] , (DateTime)dynConstraints[25] );
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
          Object[] prmP001B2;
          prmP001B2 = new Object[] {
          new ParDef("@AV67Seguridad_cierremoduloswwds_1_cmmodano",GXType.Int16,4,0) ,
          new ParDef("@AV68Seguridad_cierremoduloswwds_2_cmmodmes",GXType.Int16,2,0) ,
          new ParDef("@AV69Seguridad_cierremoduloswwds_3_tfcmmodano",GXType.Int16,4,0) ,
          new ParDef("@AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to",GXType.Int16,4,0) ,
          new ParDef("@lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc",GXType.NChar,10,0) ,
          new ParDef("@AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel",GXType.NChar,10,0) ,
          new ParDef("@AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc",GXType.Date,8,0) ,
          new ParDef("@AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to",GXType.Date,8,0) ,
          new ParDef("@lV78Seguridad_cierremoduloswwds_12_tfcmmodusum",GXType.NChar,10,0) ,
          new ParDef("@AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel",GXType.NChar,10,0) ,
          new ParDef("@AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm",GXType.Date,8,0) ,
          new ParDef("@AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to",GXType.Date,8,0)
          };
          Object[] prmP001B3;
          prmP001B3 = new Object[] {
          new ParDef("@AV67Seguridad_cierremoduloswwds_1_cmmodano",GXType.Int16,4,0) ,
          new ParDef("@AV68Seguridad_cierremoduloswwds_2_cmmodmes",GXType.Int16,2,0) ,
          new ParDef("@AV69Seguridad_cierremoduloswwds_3_tfcmmodano",GXType.Int16,4,0) ,
          new ParDef("@AV70Seguridad_cierremoduloswwds_4_tfcmmodano_to",GXType.Int16,4,0) ,
          new ParDef("@lV74Seguridad_cierremoduloswwds_8_tfcmmodusuc",GXType.NChar,10,0) ,
          new ParDef("@AV75Seguridad_cierremoduloswwds_9_tfcmmodusuc_sel",GXType.NChar,10,0) ,
          new ParDef("@AV76Seguridad_cierremoduloswwds_10_tfcmmodfecc",GXType.Date,8,0) ,
          new ParDef("@AV77Seguridad_cierremoduloswwds_11_tfcmmodfecc_to",GXType.Date,8,0) ,
          new ParDef("@lV78Seguridad_cierremoduloswwds_12_tfcmmodusum",GXType.NChar,10,0) ,
          new ParDef("@AV79Seguridad_cierremoduloswwds_13_tfcmmodusum_sel",GXType.NChar,10,0) ,
          new ParDef("@AV80Seguridad_cierremoduloswwds_14_tfcmmodfecm",GXType.Date,8,0) ,
          new ParDef("@AV81Seguridad_cierremoduloswwds_15_tfcmmodfecm_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001B2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001B3,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 10);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 10);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
       }
    }

 }

}
