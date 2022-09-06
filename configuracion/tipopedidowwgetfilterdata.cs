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
   public class tipopedidowwgetfilterdata : GXProcedure
   {
      public tipopedidowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipopedidowwgetfilterdata( IGxContext context )
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
         tipopedidowwgetfilterdata objtipopedidowwgetfilterdata;
         objtipopedidowwgetfilterdata = new tipopedidowwgetfilterdata();
         objtipopedidowwgetfilterdata.AV20DDOName = aP0_DDOName;
         objtipopedidowwgetfilterdata.AV18SearchTxt = aP1_SearchTxt;
         objtipopedidowwgetfilterdata.AV19SearchTxtTo = aP2_SearchTxtTo;
         objtipopedidowwgetfilterdata.AV24OptionsJson = "" ;
         objtipopedidowwgetfilterdata.AV27OptionsDescJson = "" ;
         objtipopedidowwgetfilterdata.AV29OptionIndexesJson = "" ;
         objtipopedidowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objtipopedidowwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objtipopedidowwgetfilterdata);
         aP3_OptionsJson=this.AV24OptionsJson;
         aP4_OptionsDescJson=this.AV27OptionsDescJson;
         aP5_OptionIndexesJson=this.AV29OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tipopedidowwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV20DDOName), "DDO_TPEDDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADTPEDDSCOPTIONS' */
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
         if ( StringUtil.StrCmp(AV31Session.Get("Configuracion.TipoPedidoWWGridState"), "") == 0 )
         {
            AV33GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Configuracion.TipoPedidoWWGridState"), null, "", "");
         }
         else
         {
            AV33GridState.FromXml(AV31Session.Get("Configuracion.TipoPedidoWWGridState"), null, "", "");
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV33GridState.gxTpr_Filtervalues.Count )
         {
            AV34GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV33GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTPEDCOD") == 0 )
            {
               AV10TFTPedCod = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
               AV11TFTPedCod_To = (int)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTPEDDSC") == 0 )
            {
               AV12TFTPedDsc = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTPEDDSC_SEL") == 0 )
            {
               AV13TFTPedDsc_Sel = AV34GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTPEDGUIA_SEL") == 0 )
            {
               AV15TFTPedGuia_Sel = (short)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTPEDFAC_SEL") == 0 )
            {
               AV14TFTPedFac_Sel = (short)(NumberUtil.Val( AV34GridStateFilterValue.gxTpr_Value, "."));
            }
            else if ( StringUtil.StrCmp(AV34GridStateFilterValue.gxTpr_Name, "TFTPEDSTS_SEL") == 0 )
            {
               AV16TFTPedSts_SelsJson = AV34GridStateFilterValue.gxTpr_Value;
               AV17TFTPedSts_Sels.FromJSonString(AV16TFTPedSts_SelsJson, null);
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
         if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV35GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "TPEDDSC") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV35GridStateDynamicFilter.gxTpr_Operator;
               AV38TPedDsc1 = AV35GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV35GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "TPEDDSC") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV35GridStateDynamicFilter.gxTpr_Operator;
                  AV42TPedDsc2 = AV35GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV33GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV35GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV33GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV35GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "TPEDDSC") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV35GridStateDynamicFilter.gxTpr_Operator;
                     AV46TPedDsc3 = AV35GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTPEDDSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFTPedDsc = AV18SearchTxt;
         AV13TFTPedDsc_Sel = "";
         AV54Configuracion_tipopedidowwds_1_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV55Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV56Configuracion_tipopedidowwds_3_tpeddsc1 = AV38TPedDsc1;
         AV57Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV58Configuracion_tipopedidowwds_5_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV59Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV60Configuracion_tipopedidowwds_7_tpeddsc2 = AV42TPedDsc2;
         AV61Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV62Configuracion_tipopedidowwds_9_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV63Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV64Configuracion_tipopedidowwds_11_tpeddsc3 = AV46TPedDsc3;
         AV65Configuracion_tipopedidowwds_12_tftpedcod = AV10TFTPedCod;
         AV66Configuracion_tipopedidowwds_13_tftpedcod_to = AV11TFTPedCod_To;
         AV67Configuracion_tipopedidowwds_14_tftpeddsc = AV12TFTPedDsc;
         AV68Configuracion_tipopedidowwds_15_tftpeddsc_sel = AV13TFTPedDsc_Sel;
         AV69Configuracion_tipopedidowwds_16_tftpedguia_sel = AV15TFTPedGuia_Sel;
         AV70Configuracion_tipopedidowwds_17_tftpedfac_sel = AV14TFTPedFac_Sel;
         AV71Configuracion_tipopedidowwds_18_tftpedsts_sels = AV17TFTPedSts_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A1936TPedSts ,
                                              AV71Configuracion_tipopedidowwds_18_tftpedsts_sels ,
                                              AV54Configuracion_tipopedidowwds_1_dynamicfiltersselector1 ,
                                              AV55Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 ,
                                              AV56Configuracion_tipopedidowwds_3_tpeddsc1 ,
                                              AV57Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 ,
                                              AV58Configuracion_tipopedidowwds_5_dynamicfiltersselector2 ,
                                              AV59Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 ,
                                              AV60Configuracion_tipopedidowwds_7_tpeddsc2 ,
                                              AV61Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 ,
                                              AV62Configuracion_tipopedidowwds_9_dynamicfiltersselector3 ,
                                              AV63Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 ,
                                              AV64Configuracion_tipopedidowwds_11_tpeddsc3 ,
                                              AV65Configuracion_tipopedidowwds_12_tftpedcod ,
                                              AV66Configuracion_tipopedidowwds_13_tftpedcod_to ,
                                              AV68Configuracion_tipopedidowwds_15_tftpeddsc_sel ,
                                              AV67Configuracion_tipopedidowwds_14_tftpeddsc ,
                                              AV69Configuracion_tipopedidowwds_16_tftpedguia_sel ,
                                              AV70Configuracion_tipopedidowwds_17_tftpedfac_sel ,
                                              AV71Configuracion_tipopedidowwds_18_tftpedsts_sels.Count ,
                                              A1931TPedDsc ,
                                              A212TPedCod ,
                                              A1933TPedGuia ,
                                              A1932TPedFac } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV56Configuracion_tipopedidowwds_3_tpeddsc1 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_tipopedidowwds_3_tpeddsc1), 100, "%");
         lV56Configuracion_tipopedidowwds_3_tpeddsc1 = StringUtil.PadR( StringUtil.RTrim( AV56Configuracion_tipopedidowwds_3_tpeddsc1), 100, "%");
         lV60Configuracion_tipopedidowwds_7_tpeddsc2 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_tipopedidowwds_7_tpeddsc2), 100, "%");
         lV60Configuracion_tipopedidowwds_7_tpeddsc2 = StringUtil.PadR( StringUtil.RTrim( AV60Configuracion_tipopedidowwds_7_tpeddsc2), 100, "%");
         lV64Configuracion_tipopedidowwds_11_tpeddsc3 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_tipopedidowwds_11_tpeddsc3), 100, "%");
         lV64Configuracion_tipopedidowwds_11_tpeddsc3 = StringUtil.PadR( StringUtil.RTrim( AV64Configuracion_tipopedidowwds_11_tpeddsc3), 100, "%");
         lV67Configuracion_tipopedidowwds_14_tftpeddsc = StringUtil.PadR( StringUtil.RTrim( AV67Configuracion_tipopedidowwds_14_tftpeddsc), 100, "%");
         /* Using cursor P004R2 */
         pr_default.execute(0, new Object[] {lV56Configuracion_tipopedidowwds_3_tpeddsc1, lV56Configuracion_tipopedidowwds_3_tpeddsc1, lV60Configuracion_tipopedidowwds_7_tpeddsc2, lV60Configuracion_tipopedidowwds_7_tpeddsc2, lV64Configuracion_tipopedidowwds_11_tpeddsc3, lV64Configuracion_tipopedidowwds_11_tpeddsc3, AV65Configuracion_tipopedidowwds_12_tftpedcod, AV66Configuracion_tipopedidowwds_13_tftpedcod_to, lV67Configuracion_tipopedidowwds_14_tftpeddsc, AV68Configuracion_tipopedidowwds_15_tftpeddsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4R2 = false;
            A1931TPedDsc = P004R2_A1931TPedDsc[0];
            A1936TPedSts = P004R2_A1936TPedSts[0];
            A1932TPedFac = P004R2_A1932TPedFac[0];
            A1933TPedGuia = P004R2_A1933TPedGuia[0];
            A212TPedCod = P004R2_A212TPedCod[0];
            AV30count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P004R2_A1931TPedDsc[0], A1931TPedDsc) == 0 ) )
            {
               BRK4R2 = false;
               A212TPedCod = P004R2_A212TPedCod[0];
               AV30count = (long)(AV30count+1);
               BRK4R2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1931TPedDsc)) )
            {
               AV22Option = A1931TPedDsc;
               AV23Options.Add(AV22Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV30count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV23Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK4R2 )
            {
               BRK4R2 = true;
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
         AV12TFTPedDsc = "";
         AV13TFTPedDsc_Sel = "";
         AV16TFTPedSts_SelsJson = "";
         AV17TFTPedSts_Sels = new GxSimpleCollection<short>();
         AV35GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38TPedDsc1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42TPedDsc2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46TPedDsc3 = "";
         AV54Configuracion_tipopedidowwds_1_dynamicfiltersselector1 = "";
         AV56Configuracion_tipopedidowwds_3_tpeddsc1 = "";
         AV58Configuracion_tipopedidowwds_5_dynamicfiltersselector2 = "";
         AV60Configuracion_tipopedidowwds_7_tpeddsc2 = "";
         AV62Configuracion_tipopedidowwds_9_dynamicfiltersselector3 = "";
         AV64Configuracion_tipopedidowwds_11_tpeddsc3 = "";
         AV67Configuracion_tipopedidowwds_14_tftpeddsc = "";
         AV68Configuracion_tipopedidowwds_15_tftpeddsc_sel = "";
         AV71Configuracion_tipopedidowwds_18_tftpedsts_sels = new GxSimpleCollection<short>();
         scmdbuf = "";
         lV56Configuracion_tipopedidowwds_3_tpeddsc1 = "";
         lV60Configuracion_tipopedidowwds_7_tpeddsc2 = "";
         lV64Configuracion_tipopedidowwds_11_tpeddsc3 = "";
         lV67Configuracion_tipopedidowwds_14_tftpeddsc = "";
         A1931TPedDsc = "";
         P004R2_A1931TPedDsc = new string[] {""} ;
         P004R2_A1936TPedSts = new short[1] ;
         P004R2_A1932TPedFac = new short[1] ;
         P004R2_A1933TPedGuia = new short[1] ;
         P004R2_A212TPedCod = new int[1] ;
         AV22Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipopedidowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004R2_A1931TPedDsc, P004R2_A1936TPedSts, P004R2_A1932TPedFac, P004R2_A1933TPedGuia, P004R2_A212TPedCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV15TFTPedGuia_Sel ;
      private short AV14TFTPedFac_Sel ;
      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV55Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 ;
      private short AV59Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 ;
      private short AV63Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 ;
      private short AV69Configuracion_tipopedidowwds_16_tftpedguia_sel ;
      private short AV70Configuracion_tipopedidowwds_17_tftpedfac_sel ;
      private short A1936TPedSts ;
      private short A1933TPedGuia ;
      private short A1932TPedFac ;
      private int AV52GXV1 ;
      private int AV10TFTPedCod ;
      private int AV11TFTPedCod_To ;
      private int AV65Configuracion_tipopedidowwds_12_tftpedcod ;
      private int AV66Configuracion_tipopedidowwds_13_tftpedcod_to ;
      private int AV71Configuracion_tipopedidowwds_18_tftpedsts_sels_Count ;
      private int A212TPedCod ;
      private long AV30count ;
      private string AV12TFTPedDsc ;
      private string AV13TFTPedDsc_Sel ;
      private string AV38TPedDsc1 ;
      private string AV42TPedDsc2 ;
      private string AV46TPedDsc3 ;
      private string AV56Configuracion_tipopedidowwds_3_tpeddsc1 ;
      private string AV60Configuracion_tipopedidowwds_7_tpeddsc2 ;
      private string AV64Configuracion_tipopedidowwds_11_tpeddsc3 ;
      private string AV67Configuracion_tipopedidowwds_14_tftpeddsc ;
      private string AV68Configuracion_tipopedidowwds_15_tftpeddsc_sel ;
      private string scmdbuf ;
      private string lV56Configuracion_tipopedidowwds_3_tpeddsc1 ;
      private string lV60Configuracion_tipopedidowwds_7_tpeddsc2 ;
      private string lV64Configuracion_tipopedidowwds_11_tpeddsc3 ;
      private string lV67Configuracion_tipopedidowwds_14_tftpeddsc ;
      private string A1931TPedDsc ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV57Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 ;
      private bool AV61Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 ;
      private bool BRK4R2 ;
      private string AV24OptionsJson ;
      private string AV27OptionsDescJson ;
      private string AV29OptionIndexesJson ;
      private string AV16TFTPedSts_SelsJson ;
      private string AV20DDOName ;
      private string AV18SearchTxt ;
      private string AV19SearchTxtTo ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV54Configuracion_tipopedidowwds_1_dynamicfiltersselector1 ;
      private string AV58Configuracion_tipopedidowwds_5_dynamicfiltersselector2 ;
      private string AV62Configuracion_tipopedidowwds_9_dynamicfiltersselector3 ;
      private string AV22Option ;
      private GxSimpleCollection<short> AV17TFTPedSts_Sels ;
      private GxSimpleCollection<short> AV71Configuracion_tipopedidowwds_18_tftpedsts_sels ;
      private IGxSession AV31Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004R2_A1931TPedDsc ;
      private short[] P004R2_A1936TPedSts ;
      private short[] P004R2_A1932TPedFac ;
      private short[] P004R2_A1933TPedGuia ;
      private int[] P004R2_A212TPedCod ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV33GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV34GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV35GridStateDynamicFilter ;
   }

   public class tipopedidowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004R2( IGxContext context ,
                                             short A1936TPedSts ,
                                             GxSimpleCollection<short> AV71Configuracion_tipopedidowwds_18_tftpedsts_sels ,
                                             string AV54Configuracion_tipopedidowwds_1_dynamicfiltersselector1 ,
                                             short AV55Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 ,
                                             string AV56Configuracion_tipopedidowwds_3_tpeddsc1 ,
                                             bool AV57Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 ,
                                             string AV58Configuracion_tipopedidowwds_5_dynamicfiltersselector2 ,
                                             short AV59Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 ,
                                             string AV60Configuracion_tipopedidowwds_7_tpeddsc2 ,
                                             bool AV61Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 ,
                                             string AV62Configuracion_tipopedidowwds_9_dynamicfiltersselector3 ,
                                             short AV63Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 ,
                                             string AV64Configuracion_tipopedidowwds_11_tpeddsc3 ,
                                             int AV65Configuracion_tipopedidowwds_12_tftpedcod ,
                                             int AV66Configuracion_tipopedidowwds_13_tftpedcod_to ,
                                             string AV68Configuracion_tipopedidowwds_15_tftpeddsc_sel ,
                                             string AV67Configuracion_tipopedidowwds_14_tftpeddsc ,
                                             short AV69Configuracion_tipopedidowwds_16_tftpedguia_sel ,
                                             short AV70Configuracion_tipopedidowwds_17_tftpedfac_sel ,
                                             int AV71Configuracion_tipopedidowwds_18_tftpedsts_sels_Count ,
                                             string A1931TPedDsc ,
                                             int A212TPedCod ,
                                             short A1933TPedGuia ,
                                             short A1932TPedFac )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [TPedDsc], [TPedSts], [TPedFac], [TPedGuia], [TPedCod] FROM [CTIPPEDIDO]";
         if ( ( StringUtil.StrCmp(AV54Configuracion_tipopedidowwds_1_dynamicfiltersselector1, "TPEDDSC") == 0 ) && ( AV55Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_tipopedidowwds_3_tpeddsc1)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like @lV56Configuracion_tipopedidowwds_3_tpeddsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Configuracion_tipopedidowwds_1_dynamicfiltersselector1, "TPEDDSC") == 0 ) && ( AV55Configuracion_tipopedidowwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Configuracion_tipopedidowwds_3_tpeddsc1)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like '%' + @lV56Configuracion_tipopedidowwds_3_tpeddsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV57Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Configuracion_tipopedidowwds_5_dynamicfiltersselector2, "TPEDDSC") == 0 ) && ( AV59Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_tipopedidowwds_7_tpeddsc2)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like @lV60Configuracion_tipopedidowwds_7_tpeddsc2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV57Configuracion_tipopedidowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Configuracion_tipopedidowwds_5_dynamicfiltersselector2, "TPEDDSC") == 0 ) && ( AV59Configuracion_tipopedidowwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Configuracion_tipopedidowwds_7_tpeddsc2)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like '%' + @lV60Configuracion_tipopedidowwds_7_tpeddsc2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV61Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Configuracion_tipopedidowwds_9_dynamicfiltersselector3, "TPEDDSC") == 0 ) && ( AV63Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipopedidowwds_11_tpeddsc3)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like @lV64Configuracion_tipopedidowwds_11_tpeddsc3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV61Configuracion_tipopedidowwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Configuracion_tipopedidowwds_9_dynamicfiltersselector3, "TPEDDSC") == 0 ) && ( AV63Configuracion_tipopedidowwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Configuracion_tipopedidowwds_11_tpeddsc3)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like '%' + @lV64Configuracion_tipopedidowwds_11_tpeddsc3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV65Configuracion_tipopedidowwds_12_tftpedcod) )
         {
            AddWhere(sWhereString, "([TPedCod] >= @AV65Configuracion_tipopedidowwds_12_tftpedcod)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV66Configuracion_tipopedidowwds_13_tftpedcod_to) )
         {
            AddWhere(sWhereString, "([TPedCod] <= @AV66Configuracion_tipopedidowwds_13_tftpedcod_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_tipopedidowwds_15_tftpeddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Configuracion_tipopedidowwds_14_tftpeddsc)) ) )
         {
            AddWhere(sWhereString, "([TPedDsc] like @lV67Configuracion_tipopedidowwds_14_tftpeddsc)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Configuracion_tipopedidowwds_15_tftpeddsc_sel)) )
         {
            AddWhere(sWhereString, "([TPedDsc] = @AV68Configuracion_tipopedidowwds_15_tftpeddsc_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV69Configuracion_tipopedidowwds_16_tftpedguia_sel == 1 )
         {
            AddWhere(sWhereString, "([TPedGuia] = 1)");
         }
         if ( AV69Configuracion_tipopedidowwds_16_tftpedguia_sel == 2 )
         {
            AddWhere(sWhereString, "([TPedGuia] = 0)");
         }
         if ( AV70Configuracion_tipopedidowwds_17_tftpedfac_sel == 1 )
         {
            AddWhere(sWhereString, "([TPedFac] = 1)");
         }
         if ( AV70Configuracion_tipopedidowwds_17_tftpedfac_sel == 2 )
         {
            AddWhere(sWhereString, "([TPedFac] = 0)");
         }
         if ( AV71Configuracion_tipopedidowwds_18_tftpedsts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV71Configuracion_tipopedidowwds_18_tftpedsts_sels, "[TPedSts] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TPedDsc]";
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
                     return conditional_P004R2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (short)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (short)dynConstraints[22] , (short)dynConstraints[23] );
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
          Object[] prmP004R2;
          prmP004R2 = new Object[] {
          new ParDef("@lV56Configuracion_tipopedidowwds_3_tpeddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV56Configuracion_tipopedidowwds_3_tpeddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV60Configuracion_tipopedidowwds_7_tpeddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV60Configuracion_tipopedidowwds_7_tpeddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV64Configuracion_tipopedidowwds_11_tpeddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV64Configuracion_tipopedidowwds_11_tpeddsc3",GXType.NChar,100,0) ,
          new ParDef("@AV65Configuracion_tipopedidowwds_12_tftpedcod",GXType.Int32,6,0) ,
          new ParDef("@AV66Configuracion_tipopedidowwds_13_tftpedcod_to",GXType.Int32,6,0) ,
          new ParDef("@lV67Configuracion_tipopedidowwds_14_tftpeddsc",GXType.NChar,100,0) ,
          new ParDef("@AV68Configuracion_tipopedidowwds_15_tftpeddsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004R2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                return;
       }
    }

 }

}
