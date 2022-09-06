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
   public class notificacioneswwgetfilterdata : GXProcedure
   {
      public notificacioneswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public notificacioneswwgetfilterdata( IGxContext context )
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
         notificacioneswwgetfilterdata objnotificacioneswwgetfilterdata;
         objnotificacioneswwgetfilterdata = new notificacioneswwgetfilterdata();
         objnotificacioneswwgetfilterdata.AV28DDOName = aP0_DDOName;
         objnotificacioneswwgetfilterdata.AV26SearchTxt = aP1_SearchTxt;
         objnotificacioneswwgetfilterdata.AV27SearchTxtTo = aP2_SearchTxtTo;
         objnotificacioneswwgetfilterdata.AV32OptionsJson = "" ;
         objnotificacioneswwgetfilterdata.AV35OptionsDescJson = "" ;
         objnotificacioneswwgetfilterdata.AV37OptionIndexesJson = "" ;
         objnotificacioneswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objnotificacioneswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objnotificacioneswwgetfilterdata);
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV37OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((notificacioneswwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_SGNOTIFICACIONTITULO") == 0 )
         {
            /* Execute user subroutine: 'LOADSGNOTIFICACIONTITULOOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_SGNOTIFICACIONDESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADSGNOTIFICACIONDESCRIPCIONOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_SGNOTIFICACIONUSUARIO") == 0 )
         {
            /* Execute user subroutine: 'LOADSGNOTIFICACIONUSUARIOOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV28DDOName), "DDO_SGNOTIFICACIONUSUARIODSC") == 0 )
         {
            /* Execute user subroutine: 'LOADSGNOTIFICACIONUSUARIODSCOPTIONS' */
            S151 ();
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
         if ( StringUtil.StrCmp(AV39Session.Get("Seguridad.NotificacionesWWGridState"), "") == 0 )
         {
            AV41GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Seguridad.NotificacionesWWGridState"), null, "", "");
         }
         else
         {
            AV41GridState.FromXml(AV39Session.Get("Seguridad.NotificacionesWWGridState"), null, "", "");
         }
         AV57GXV1 = 1;
         while ( AV57GXV1 <= AV41GridState.gxTpr_Filtervalues.Count )
         {
            AV42GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV41GridState.gxTpr_Filtervalues.Item(AV57GXV1));
            if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONID") == 0 )
            {
               AV10TFSGNotificacionID = (long)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
               AV11TFSGNotificacionID_To = (long)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONTITULO") == 0 )
            {
               AV12TFSGNotificacionTitulo = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONTITULO_SEL") == 0 )
            {
               AV13TFSGNotificacionTitulo_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONDESCRIPCION") == 0 )
            {
               AV14TFSGNotificacionDescripcion = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONDESCRIPCION_SEL") == 0 )
            {
               AV15TFSGNotificacionDescripcion_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONFECHA") == 0 )
            {
               AV16TFSGNotificacionFecha = context.localUtil.CToT( AV42GridStateFilterValue.gxTpr_Value, 2);
               AV17TFSGNotificacionFecha_To = context.localUtil.CToT( AV42GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIO") == 0 )
            {
               AV18TFSGNotificacionUsuario = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIO_SEL") == 0 )
            {
               AV19TFSGNotificacionUsuario_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIODSC") == 0 )
            {
               AV20TFSGNotificacionUsuarioDsc = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONUSUARIODSC_SEL") == 0 )
            {
               AV21TFSGNotificacionUsuarioDsc_Sel = AV42GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONICONCLASS_SEL") == 0 )
            {
               AV22TFSGNotificacionIconClass_SelsJson = AV42GridStateFilterValue.gxTpr_Value;
               AV23TFSGNotificacionIconClass_Sels.FromJSonString(AV22TFSGNotificacionIconClass_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV42GridStateFilterValue.gxTpr_Name, "TFSGNOTIFICACIONTUSUARIO") == 0 )
            {
               AV24TFSGNotificacionTUsuario = (short)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Value, "."));
               AV25TFSGNotificacionTUsuario_To = (short)(NumberUtil.Val( AV42GridStateFilterValue.gxTpr_Valueto, "."));
            }
            AV57GXV1 = (int)(AV57GXV1+1);
         }
         if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV43GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(1));
            AV44DynamicFiltersSelector1 = AV43GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV44DynamicFiltersSelector1, "SGNOTIFICACIONTITULO") == 0 )
            {
               AV45DynamicFiltersOperator1 = AV43GridStateDynamicFilter.gxTpr_Operator;
               AV46SGNotificacionTitulo1 = AV43GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV47DynamicFiltersEnabled2 = true;
               AV43GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(2));
               AV48DynamicFiltersSelector2 = AV43GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "SGNOTIFICACIONTITULO") == 0 )
               {
                  AV49DynamicFiltersOperator2 = AV43GridStateDynamicFilter.gxTpr_Operator;
                  AV50SGNotificacionTitulo2 = AV43GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV41GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV51DynamicFiltersEnabled3 = true;
                  AV43GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV41GridState.gxTpr_Dynamicfilters.Item(3));
                  AV52DynamicFiltersSelector3 = AV43GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV52DynamicFiltersSelector3, "SGNOTIFICACIONTITULO") == 0 )
                  {
                     AV53DynamicFiltersOperator3 = AV43GridStateDynamicFilter.gxTpr_Operator;
                     AV54SGNotificacionTitulo3 = AV43GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSGNOTIFICACIONTITULOOPTIONS' Routine */
         returnInSub = false;
         AV12TFSGNotificacionTitulo = AV26SearchTxt;
         AV13TFSGNotificacionTitulo_Sel = "";
         AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 = AV45DynamicFiltersOperator1;
         AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = AV46SGNotificacionTitulo1;
         AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 = AV49DynamicFiltersOperator2;
         AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = AV50SGNotificacionTitulo2;
         AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 = AV53DynamicFiltersOperator3;
         AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = AV54SGNotificacionTitulo3;
         AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid = AV10TFSGNotificacionID;
         AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to = AV11TFSGNotificacionID_To;
         AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = AV12TFSGNotificacionTitulo;
         AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = AV13TFSGNotificacionTitulo_Sel;
         AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = AV14TFSGNotificacionDescripcion;
         AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = AV15TFSGNotificacionDescripcion_Sel;
         AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = AV16TFSGNotificacionFecha;
         AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = AV17TFSGNotificacionFecha_To;
         AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = AV18TFSGNotificacionUsuario;
         AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = AV19TFSGNotificacionUsuario_Sel;
         AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = AV20TFSGNotificacionUsuarioDsc;
         AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = AV21TFSGNotificacionUsuarioDsc_Sel;
         AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = AV23TFSGNotificacionIconClass_Sels;
         AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario = AV24TFSGNotificacionTUsuario;
         AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to = AV25TFSGNotificacionTUsuario_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A2243SGNotificacionIconClass ,
                                              AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                              AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                              AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                              AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                              AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                              AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                              AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                              AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                              AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                              AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                              AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                              AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                              AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                              AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                              AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                              AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                              AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                              AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                              AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                              AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                              AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                              AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                              AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                              AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                              AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels.Count ,
                                              AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                              AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                              A2238SGNotificacionTitulo ,
                                              A2237SGNotificacionID ,
                                              A2239SGNotificacionDescripcion ,
                                              A2240SGNotificacionFecha ,
                                              A2241SGNotificacionUsuario ,
                                              A2242SGNotificacionUsuarioDsc ,
                                              A2244SGNotificacionTUsuario } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT
                                              }
         });
         lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
         lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
         lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
         lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
         lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
         lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
         lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = StringUtil.Concat( StringUtil.RTrim( AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo), "%", "");
         lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = StringUtil.Concat( StringUtil.RTrim( AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion), "%", "");
         lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = StringUtil.PadR( StringUtil.RTrim( AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario), 10, "%");
         lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = StringUtil.PadR( StringUtil.RTrim( AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc), 100, "%");
         /* Using cursor P007W2 */
         pr_default.execute(0, new Object[] {lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid, AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to, lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo, AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel, lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion, AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel, AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha, AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to, lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario, AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel, lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc, AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel, AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario, AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7W2 = false;
            A2238SGNotificacionTitulo = P007W2_A2238SGNotificacionTitulo[0];
            A2244SGNotificacionTUsuario = P007W2_A2244SGNotificacionTUsuario[0];
            A2243SGNotificacionIconClass = P007W2_A2243SGNotificacionIconClass[0];
            A2242SGNotificacionUsuarioDsc = P007W2_A2242SGNotificacionUsuarioDsc[0];
            A2241SGNotificacionUsuario = P007W2_A2241SGNotificacionUsuario[0];
            A2240SGNotificacionFecha = P007W2_A2240SGNotificacionFecha[0];
            A2239SGNotificacionDescripcion = P007W2_A2239SGNotificacionDescripcion[0];
            A2237SGNotificacionID = P007W2_A2237SGNotificacionID[0];
            A2242SGNotificacionUsuarioDsc = P007W2_A2242SGNotificacionUsuarioDsc[0];
            AV38count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007W2_A2238SGNotificacionTitulo[0], A2238SGNotificacionTitulo) == 0 ) )
            {
               BRK7W2 = false;
               A2237SGNotificacionID = P007W2_A2237SGNotificacionID[0];
               AV38count = (long)(AV38count+1);
               BRK7W2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2238SGNotificacionTitulo)) )
            {
               AV30Option = A2238SGNotificacionTitulo;
               AV31Options.Add(AV30Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV31Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK7W2 )
            {
               BRK7W2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSGNOTIFICACIONDESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV14TFSGNotificacionDescripcion = AV26SearchTxt;
         AV15TFSGNotificacionDescripcion_Sel = "";
         AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 = AV45DynamicFiltersOperator1;
         AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = AV46SGNotificacionTitulo1;
         AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 = AV49DynamicFiltersOperator2;
         AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = AV50SGNotificacionTitulo2;
         AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 = AV53DynamicFiltersOperator3;
         AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = AV54SGNotificacionTitulo3;
         AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid = AV10TFSGNotificacionID;
         AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to = AV11TFSGNotificacionID_To;
         AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = AV12TFSGNotificacionTitulo;
         AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = AV13TFSGNotificacionTitulo_Sel;
         AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = AV14TFSGNotificacionDescripcion;
         AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = AV15TFSGNotificacionDescripcion_Sel;
         AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = AV16TFSGNotificacionFecha;
         AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = AV17TFSGNotificacionFecha_To;
         AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = AV18TFSGNotificacionUsuario;
         AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = AV19TFSGNotificacionUsuario_Sel;
         AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = AV20TFSGNotificacionUsuarioDsc;
         AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = AV21TFSGNotificacionUsuarioDsc_Sel;
         AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = AV23TFSGNotificacionIconClass_Sels;
         AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario = AV24TFSGNotificacionTUsuario;
         AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to = AV25TFSGNotificacionTUsuario_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A2243SGNotificacionIconClass ,
                                              AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                              AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                              AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                              AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                              AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                              AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                              AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                              AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                              AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                              AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                              AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                              AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                              AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                              AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                              AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                              AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                              AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                              AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                              AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                              AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                              AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                              AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                              AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                              AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                              AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels.Count ,
                                              AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                              AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                              A2238SGNotificacionTitulo ,
                                              A2237SGNotificacionID ,
                                              A2239SGNotificacionDescripcion ,
                                              A2240SGNotificacionFecha ,
                                              A2241SGNotificacionUsuario ,
                                              A2242SGNotificacionUsuarioDsc ,
                                              A2244SGNotificacionTUsuario } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT
                                              }
         });
         lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
         lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
         lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
         lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
         lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
         lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
         lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = StringUtil.Concat( StringUtil.RTrim( AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo), "%", "");
         lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = StringUtil.Concat( StringUtil.RTrim( AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion), "%", "");
         lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = StringUtil.PadR( StringUtil.RTrim( AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario), 10, "%");
         lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = StringUtil.PadR( StringUtil.RTrim( AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc), 100, "%");
         /* Using cursor P007W3 */
         pr_default.execute(1, new Object[] {lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid, AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to, lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo, AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel, lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion, AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel, AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha, AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to, lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario, AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel, lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc, AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel, AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario, AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7W4 = false;
            A2239SGNotificacionDescripcion = P007W3_A2239SGNotificacionDescripcion[0];
            A2244SGNotificacionTUsuario = P007W3_A2244SGNotificacionTUsuario[0];
            A2243SGNotificacionIconClass = P007W3_A2243SGNotificacionIconClass[0];
            A2242SGNotificacionUsuarioDsc = P007W3_A2242SGNotificacionUsuarioDsc[0];
            A2241SGNotificacionUsuario = P007W3_A2241SGNotificacionUsuario[0];
            A2240SGNotificacionFecha = P007W3_A2240SGNotificacionFecha[0];
            A2237SGNotificacionID = P007W3_A2237SGNotificacionID[0];
            A2238SGNotificacionTitulo = P007W3_A2238SGNotificacionTitulo[0];
            A2242SGNotificacionUsuarioDsc = P007W3_A2242SGNotificacionUsuarioDsc[0];
            AV38count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007W3_A2239SGNotificacionDescripcion[0], A2239SGNotificacionDescripcion) == 0 ) )
            {
               BRK7W4 = false;
               A2237SGNotificacionID = P007W3_A2237SGNotificacionID[0];
               AV38count = (long)(AV38count+1);
               BRK7W4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2239SGNotificacionDescripcion)) )
            {
               AV30Option = A2239SGNotificacionDescripcion;
               AV31Options.Add(AV30Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV31Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK7W4 )
            {
               BRK7W4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADSGNOTIFICACIONUSUARIOOPTIONS' Routine */
         returnInSub = false;
         AV18TFSGNotificacionUsuario = AV26SearchTxt;
         AV19TFSGNotificacionUsuario_Sel = "";
         AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 = AV45DynamicFiltersOperator1;
         AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = AV46SGNotificacionTitulo1;
         AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 = AV49DynamicFiltersOperator2;
         AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = AV50SGNotificacionTitulo2;
         AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 = AV53DynamicFiltersOperator3;
         AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = AV54SGNotificacionTitulo3;
         AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid = AV10TFSGNotificacionID;
         AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to = AV11TFSGNotificacionID_To;
         AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = AV12TFSGNotificacionTitulo;
         AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = AV13TFSGNotificacionTitulo_Sel;
         AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = AV14TFSGNotificacionDescripcion;
         AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = AV15TFSGNotificacionDescripcion_Sel;
         AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = AV16TFSGNotificacionFecha;
         AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = AV17TFSGNotificacionFecha_To;
         AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = AV18TFSGNotificacionUsuario;
         AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = AV19TFSGNotificacionUsuario_Sel;
         AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = AV20TFSGNotificacionUsuarioDsc;
         AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = AV21TFSGNotificacionUsuarioDsc_Sel;
         AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = AV23TFSGNotificacionIconClass_Sels;
         AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario = AV24TFSGNotificacionTUsuario;
         AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to = AV25TFSGNotificacionTUsuario_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A2243SGNotificacionIconClass ,
                                              AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                              AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                              AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                              AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                              AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                              AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                              AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                              AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                              AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                              AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                              AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                              AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                              AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                              AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                              AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                              AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                              AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                              AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                              AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                              AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                              AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                              AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                              AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                              AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                              AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels.Count ,
                                              AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                              AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                              A2238SGNotificacionTitulo ,
                                              A2237SGNotificacionID ,
                                              A2239SGNotificacionDescripcion ,
                                              A2240SGNotificacionFecha ,
                                              A2241SGNotificacionUsuario ,
                                              A2242SGNotificacionUsuarioDsc ,
                                              A2244SGNotificacionTUsuario } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT
                                              }
         });
         lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
         lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
         lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
         lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
         lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
         lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
         lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = StringUtil.Concat( StringUtil.RTrim( AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo), "%", "");
         lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = StringUtil.Concat( StringUtil.RTrim( AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion), "%", "");
         lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = StringUtil.PadR( StringUtil.RTrim( AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario), 10, "%");
         lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = StringUtil.PadR( StringUtil.RTrim( AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc), 100, "%");
         /* Using cursor P007W4 */
         pr_default.execute(2, new Object[] {lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid, AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to, lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo, AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel, lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion, AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel, AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha, AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to, lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario, AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel, lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc, AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel, AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario, AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK7W6 = false;
            A2241SGNotificacionUsuario = P007W4_A2241SGNotificacionUsuario[0];
            A2244SGNotificacionTUsuario = P007W4_A2244SGNotificacionTUsuario[0];
            A2243SGNotificacionIconClass = P007W4_A2243SGNotificacionIconClass[0];
            A2242SGNotificacionUsuarioDsc = P007W4_A2242SGNotificacionUsuarioDsc[0];
            A2240SGNotificacionFecha = P007W4_A2240SGNotificacionFecha[0];
            A2239SGNotificacionDescripcion = P007W4_A2239SGNotificacionDescripcion[0];
            A2237SGNotificacionID = P007W4_A2237SGNotificacionID[0];
            A2238SGNotificacionTitulo = P007W4_A2238SGNotificacionTitulo[0];
            A2242SGNotificacionUsuarioDsc = P007W4_A2242SGNotificacionUsuarioDsc[0];
            AV38count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P007W4_A2241SGNotificacionUsuario[0], A2241SGNotificacionUsuario) == 0 ) )
            {
               BRK7W6 = false;
               A2237SGNotificacionID = P007W4_A2237SGNotificacionID[0];
               AV38count = (long)(AV38count+1);
               BRK7W6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2241SGNotificacionUsuario)) )
            {
               AV30Option = A2241SGNotificacionUsuario;
               AV31Options.Add(AV30Option, 0);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV31Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK7W6 )
            {
               BRK7W6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSGNOTIFICACIONUSUARIODSCOPTIONS' Routine */
         returnInSub = false;
         AV20TFSGNotificacionUsuarioDsc = AV26SearchTxt;
         AV21TFSGNotificacionUsuarioDsc_Sel = "";
         AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 = AV45DynamicFiltersOperator1;
         AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = AV46SGNotificacionTitulo1;
         AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 = AV49DynamicFiltersOperator2;
         AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = AV50SGNotificacionTitulo2;
         AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 = AV53DynamicFiltersOperator3;
         AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = AV54SGNotificacionTitulo3;
         AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid = AV10TFSGNotificacionID;
         AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to = AV11TFSGNotificacionID_To;
         AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = AV12TFSGNotificacionTitulo;
         AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = AV13TFSGNotificacionTitulo_Sel;
         AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = AV14TFSGNotificacionDescripcion;
         AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = AV15TFSGNotificacionDescripcion_Sel;
         AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = AV16TFSGNotificacionFecha;
         AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = AV17TFSGNotificacionFecha_To;
         AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = AV18TFSGNotificacionUsuario;
         AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = AV19TFSGNotificacionUsuario_Sel;
         AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = AV20TFSGNotificacionUsuarioDsc;
         AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = AV21TFSGNotificacionUsuarioDsc_Sel;
         AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = AV23TFSGNotificacionIconClass_Sels;
         AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario = AV24TFSGNotificacionTUsuario;
         AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to = AV25TFSGNotificacionTUsuario_To;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A2243SGNotificacionIconClass ,
                                              AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                              AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                              AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                              AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                              AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                              AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                              AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                              AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                              AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                              AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                              AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                              AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                              AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                              AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                              AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                              AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                              AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                              AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                              AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                              AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                              AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                              AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                              AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                              AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                              AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels.Count ,
                                              AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                              AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                              A2238SGNotificacionTitulo ,
                                              A2237SGNotificacionID ,
                                              A2239SGNotificacionDescripcion ,
                                              A2240SGNotificacionFecha ,
                                              A2241SGNotificacionUsuario ,
                                              A2242SGNotificacionUsuarioDsc ,
                                              A2244SGNotificacionTUsuario } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT
                                              }
         });
         lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
         lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = StringUtil.Concat( StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1), "%", "");
         lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
         lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = StringUtil.Concat( StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2), "%", "");
         lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
         lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = StringUtil.Concat( StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3), "%", "");
         lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = StringUtil.Concat( StringUtil.RTrim( AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo), "%", "");
         lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = StringUtil.Concat( StringUtil.RTrim( AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion), "%", "");
         lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = StringUtil.PadR( StringUtil.RTrim( AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario), 10, "%");
         lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = StringUtil.PadR( StringUtil.RTrim( AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc), 100, "%");
         /* Using cursor P007W5 */
         pr_default.execute(3, new Object[] {lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1, lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2, lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3, AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid, AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to, lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo, AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel, lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion, AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel, AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha, AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to, lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario, AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel, lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc, AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel, AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario, AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK7W8 = false;
            A2241SGNotificacionUsuario = P007W5_A2241SGNotificacionUsuario[0];
            A2244SGNotificacionTUsuario = P007W5_A2244SGNotificacionTUsuario[0];
            A2243SGNotificacionIconClass = P007W5_A2243SGNotificacionIconClass[0];
            A2242SGNotificacionUsuarioDsc = P007W5_A2242SGNotificacionUsuarioDsc[0];
            A2240SGNotificacionFecha = P007W5_A2240SGNotificacionFecha[0];
            A2239SGNotificacionDescripcion = P007W5_A2239SGNotificacionDescripcion[0];
            A2237SGNotificacionID = P007W5_A2237SGNotificacionID[0];
            A2238SGNotificacionTitulo = P007W5_A2238SGNotificacionTitulo[0];
            A2242SGNotificacionUsuarioDsc = P007W5_A2242SGNotificacionUsuarioDsc[0];
            AV38count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P007W5_A2241SGNotificacionUsuario[0], A2241SGNotificacionUsuario) == 0 ) )
            {
               BRK7W8 = false;
               A2237SGNotificacionID = P007W5_A2237SGNotificacionID[0];
               AV38count = (long)(AV38count+1);
               BRK7W8 = true;
               pr_default.readNext(3);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2242SGNotificacionUsuarioDsc)) )
            {
               AV30Option = A2242SGNotificacionUsuarioDsc;
               AV29InsertIndex = 1;
               while ( ( AV29InsertIndex <= AV31Options.Count ) && ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), AV30Option) < 0 ) )
               {
                  AV29InsertIndex = (int)(AV29InsertIndex+1);
               }
               AV31Options.Add(AV30Option, AV29InsertIndex);
               AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV38count), "Z,ZZZ,ZZZ,ZZ9")), AV29InsertIndex);
            }
            if ( AV31Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK7W8 )
            {
               BRK7W8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV12TFSGNotificacionTitulo = "";
         AV13TFSGNotificacionTitulo_Sel = "";
         AV14TFSGNotificacionDescripcion = "";
         AV15TFSGNotificacionDescripcion_Sel = "";
         AV16TFSGNotificacionFecha = (DateTime)(DateTime.MinValue);
         AV17TFSGNotificacionFecha_To = (DateTime)(DateTime.MinValue);
         AV18TFSGNotificacionUsuario = "";
         AV19TFSGNotificacionUsuario_Sel = "";
         AV20TFSGNotificacionUsuarioDsc = "";
         AV21TFSGNotificacionUsuarioDsc_Sel = "";
         AV22TFSGNotificacionIconClass_SelsJson = "";
         AV23TFSGNotificacionIconClass_Sels = new GxSimpleCollection<string>();
         AV43GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV44DynamicFiltersSelector1 = "";
         AV46SGNotificacionTitulo1 = "";
         AV48DynamicFiltersSelector2 = "";
         AV50SGNotificacionTitulo2 = "";
         AV52DynamicFiltersSelector3 = "";
         AV54SGNotificacionTitulo3 = "";
         AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1 = "";
         AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = "";
         AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2 = "";
         AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = "";
         AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3 = "";
         AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = "";
         AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = "";
         AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel = "";
         AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = "";
         AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel = "";
         AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha = (DateTime)(DateTime.MinValue);
         AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to = (DateTime)(DateTime.MinValue);
         AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = "";
         AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel = "";
         AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = "";
         AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel = "";
         AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels = new GxSimpleCollection<string>();
         scmdbuf = "";
         lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 = "";
         lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 = "";
         lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 = "";
         lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo = "";
         lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion = "";
         lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario = "";
         lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc = "";
         A2243SGNotificacionIconClass = "";
         A2238SGNotificacionTitulo = "";
         A2239SGNotificacionDescripcion = "";
         A2240SGNotificacionFecha = (DateTime)(DateTime.MinValue);
         A2241SGNotificacionUsuario = "";
         A2242SGNotificacionUsuarioDsc = "";
         P007W2_A2238SGNotificacionTitulo = new string[] {""} ;
         P007W2_A2244SGNotificacionTUsuario = new short[1] ;
         P007W2_A2243SGNotificacionIconClass = new string[] {""} ;
         P007W2_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         P007W2_A2241SGNotificacionUsuario = new string[] {""} ;
         P007W2_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         P007W2_A2239SGNotificacionDescripcion = new string[] {""} ;
         P007W2_A2237SGNotificacionID = new long[1] ;
         AV30Option = "";
         P007W3_A2239SGNotificacionDescripcion = new string[] {""} ;
         P007W3_A2244SGNotificacionTUsuario = new short[1] ;
         P007W3_A2243SGNotificacionIconClass = new string[] {""} ;
         P007W3_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         P007W3_A2241SGNotificacionUsuario = new string[] {""} ;
         P007W3_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         P007W3_A2237SGNotificacionID = new long[1] ;
         P007W3_A2238SGNotificacionTitulo = new string[] {""} ;
         P007W4_A2241SGNotificacionUsuario = new string[] {""} ;
         P007W4_A2244SGNotificacionTUsuario = new short[1] ;
         P007W4_A2243SGNotificacionIconClass = new string[] {""} ;
         P007W4_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         P007W4_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         P007W4_A2239SGNotificacionDescripcion = new string[] {""} ;
         P007W4_A2237SGNotificacionID = new long[1] ;
         P007W4_A2238SGNotificacionTitulo = new string[] {""} ;
         P007W5_A2241SGNotificacionUsuario = new string[] {""} ;
         P007W5_A2244SGNotificacionTUsuario = new short[1] ;
         P007W5_A2243SGNotificacionIconClass = new string[] {""} ;
         P007W5_A2242SGNotificacionUsuarioDsc = new string[] {""} ;
         P007W5_A2240SGNotificacionFecha = new DateTime[] {DateTime.MinValue} ;
         P007W5_A2239SGNotificacionDescripcion = new string[] {""} ;
         P007W5_A2237SGNotificacionID = new long[1] ;
         P007W5_A2238SGNotificacionTitulo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.notificacioneswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007W2_A2238SGNotificacionTitulo, P007W2_A2244SGNotificacionTUsuario, P007W2_A2243SGNotificacionIconClass, P007W2_A2242SGNotificacionUsuarioDsc, P007W2_A2241SGNotificacionUsuario, P007W2_A2240SGNotificacionFecha, P007W2_A2239SGNotificacionDescripcion, P007W2_A2237SGNotificacionID
               }
               , new Object[] {
               P007W3_A2239SGNotificacionDescripcion, P007W3_A2244SGNotificacionTUsuario, P007W3_A2243SGNotificacionIconClass, P007W3_A2242SGNotificacionUsuarioDsc, P007W3_A2241SGNotificacionUsuario, P007W3_A2240SGNotificacionFecha, P007W3_A2237SGNotificacionID, P007W3_A2238SGNotificacionTitulo
               }
               , new Object[] {
               P007W4_A2241SGNotificacionUsuario, P007W4_A2244SGNotificacionTUsuario, P007W4_A2243SGNotificacionIconClass, P007W4_A2242SGNotificacionUsuarioDsc, P007W4_A2240SGNotificacionFecha, P007W4_A2239SGNotificacionDescripcion, P007W4_A2237SGNotificacionID, P007W4_A2238SGNotificacionTitulo
               }
               , new Object[] {
               P007W5_A2241SGNotificacionUsuario, P007W5_A2244SGNotificacionTUsuario, P007W5_A2243SGNotificacionIconClass, P007W5_A2242SGNotificacionUsuarioDsc, P007W5_A2240SGNotificacionFecha, P007W5_A2239SGNotificacionDescripcion, P007W5_A2237SGNotificacionID, P007W5_A2238SGNotificacionTitulo
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV24TFSGNotificacionTUsuario ;
      private short AV25TFSGNotificacionTUsuario_To ;
      private short AV45DynamicFiltersOperator1 ;
      private short AV49DynamicFiltersOperator2 ;
      private short AV53DynamicFiltersOperator3 ;
      private short AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ;
      private short AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ;
      private short AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ;
      private short AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ;
      private short AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ;
      private short A2244SGNotificacionTUsuario ;
      private int AV57GXV1 ;
      private int AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count ;
      private int AV29InsertIndex ;
      private long AV10TFSGNotificacionID ;
      private long AV11TFSGNotificacionID_To ;
      private long AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid ;
      private long AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ;
      private long A2237SGNotificacionID ;
      private long AV38count ;
      private string AV18TFSGNotificacionUsuario ;
      private string AV19TFSGNotificacionUsuario_Sel ;
      private string AV20TFSGNotificacionUsuarioDsc ;
      private string AV21TFSGNotificacionUsuarioDsc_Sel ;
      private string AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ;
      private string AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ;
      private string AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ;
      private string AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ;
      private string scmdbuf ;
      private string lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ;
      private string lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ;
      private string A2241SGNotificacionUsuario ;
      private string A2242SGNotificacionUsuarioDsc ;
      private DateTime AV16TFSGNotificacionFecha ;
      private DateTime AV17TFSGNotificacionFecha_To ;
      private DateTime AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ;
      private DateTime AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ;
      private DateTime A2240SGNotificacionFecha ;
      private bool returnInSub ;
      private bool AV47DynamicFiltersEnabled2 ;
      private bool AV51DynamicFiltersEnabled3 ;
      private bool AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ;
      private bool AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ;
      private bool BRK7W2 ;
      private bool BRK7W4 ;
      private bool BRK7W6 ;
      private bool BRK7W8 ;
      private string AV32OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV37OptionIndexesJson ;
      private string AV22TFSGNotificacionIconClass_SelsJson ;
      private string AV28DDOName ;
      private string AV26SearchTxt ;
      private string AV27SearchTxtTo ;
      private string AV12TFSGNotificacionTitulo ;
      private string AV13TFSGNotificacionTitulo_Sel ;
      private string AV14TFSGNotificacionDescripcion ;
      private string AV15TFSGNotificacionDescripcion_Sel ;
      private string AV44DynamicFiltersSelector1 ;
      private string AV46SGNotificacionTitulo1 ;
      private string AV48DynamicFiltersSelector2 ;
      private string AV50SGNotificacionTitulo2 ;
      private string AV52DynamicFiltersSelector3 ;
      private string AV54SGNotificacionTitulo3 ;
      private string AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ;
      private string AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ;
      private string AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ;
      private string AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ;
      private string AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ;
      private string AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ;
      private string AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ;
      private string AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ;
      private string AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ;
      private string AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ;
      private string lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ;
      private string lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ;
      private string lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ;
      private string lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ;
      private string lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ;
      private string A2243SGNotificacionIconClass ;
      private string A2238SGNotificacionTitulo ;
      private string A2239SGNotificacionDescripcion ;
      private string AV30Option ;
      private IGxSession AV39Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P007W2_A2238SGNotificacionTitulo ;
      private short[] P007W2_A2244SGNotificacionTUsuario ;
      private string[] P007W2_A2243SGNotificacionIconClass ;
      private string[] P007W2_A2242SGNotificacionUsuarioDsc ;
      private string[] P007W2_A2241SGNotificacionUsuario ;
      private DateTime[] P007W2_A2240SGNotificacionFecha ;
      private string[] P007W2_A2239SGNotificacionDescripcion ;
      private long[] P007W2_A2237SGNotificacionID ;
      private string[] P007W3_A2239SGNotificacionDescripcion ;
      private short[] P007W3_A2244SGNotificacionTUsuario ;
      private string[] P007W3_A2243SGNotificacionIconClass ;
      private string[] P007W3_A2242SGNotificacionUsuarioDsc ;
      private string[] P007W3_A2241SGNotificacionUsuario ;
      private DateTime[] P007W3_A2240SGNotificacionFecha ;
      private long[] P007W3_A2237SGNotificacionID ;
      private string[] P007W3_A2238SGNotificacionTitulo ;
      private string[] P007W4_A2241SGNotificacionUsuario ;
      private short[] P007W4_A2244SGNotificacionTUsuario ;
      private string[] P007W4_A2243SGNotificacionIconClass ;
      private string[] P007W4_A2242SGNotificacionUsuarioDsc ;
      private DateTime[] P007W4_A2240SGNotificacionFecha ;
      private string[] P007W4_A2239SGNotificacionDescripcion ;
      private long[] P007W4_A2237SGNotificacionID ;
      private string[] P007W4_A2238SGNotificacionTitulo ;
      private string[] P007W5_A2241SGNotificacionUsuario ;
      private short[] P007W5_A2244SGNotificacionTUsuario ;
      private string[] P007W5_A2243SGNotificacionIconClass ;
      private string[] P007W5_A2242SGNotificacionUsuarioDsc ;
      private DateTime[] P007W5_A2240SGNotificacionFecha ;
      private string[] P007W5_A2239SGNotificacionDescripcion ;
      private long[] P007W5_A2237SGNotificacionID ;
      private string[] P007W5_A2238SGNotificacionTitulo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV34OptionsDesc ;
      private GxSimpleCollection<string> AV36OptionIndexes ;
      private GxSimpleCollection<string> AV23TFSGNotificacionIconClass_Sels ;
      private GxSimpleCollection<string> AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV41GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV42GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV43GridStateDynamicFilter ;
   }

   public class notificacioneswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007W2( IGxContext context ,
                                             string A2243SGNotificacionIconClass ,
                                             GxSimpleCollection<string> AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                             string AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                             short AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                             string AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                             bool AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                             string AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                             short AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                             string AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                             bool AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                             string AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                             short AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                             string AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                             long AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                             long AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                             string AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                             string AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                             string AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                             string AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                             DateTime AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                             DateTime AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                             string AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                             string AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                             string AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                             string AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                             int AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count ,
                                             short AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                             short AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                             string A2238SGNotificacionTitulo ,
                                             long A2237SGNotificacionID ,
                                             string A2239SGNotificacionDescripcion ,
                                             DateTime A2240SGNotificacionFecha ,
                                             string A2241SGNotificacionUsuario ,
                                             string A2242SGNotificacionUsuarioDsc ,
                                             short A2244SGNotificacionTUsuario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[20];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[SGNotificacionTitulo], T1.[SGNotificacionTUsuario], T1.[SGNotificacionIconClass], T2.[UsuNom] AS SGNotificacionUsuarioDsc, T1.[SGNotificacionUsuario] AS SGNotificacionUsuario, T1.[SGNotificacionFecha], T1.[SGNotificacionDescripcion], T1.[SGNotificacionID] FROM ([SGNOTIFICACIONES] T1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = T1.[SGNotificacionUsuario])";
         if ( ( StringUtil.StrCmp(AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] >= @AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (0==AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] <= @AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] = @AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] like @lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] = @AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] >= @AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] <= @AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] like @lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] = @AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] like @lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] = @AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels, "T1.[SGNotificacionIconClass] IN (", ")")+")");
         }
         if ( ! (0==AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] >= @AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! (0==AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] <= @AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SGNotificacionTitulo]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007W3( IGxContext context ,
                                             string A2243SGNotificacionIconClass ,
                                             GxSimpleCollection<string> AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                             string AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                             short AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                             string AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                             bool AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                             string AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                             short AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                             string AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                             bool AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                             string AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                             short AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                             string AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                             long AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                             long AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                             string AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                             string AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                             string AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                             string AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                             DateTime AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                             DateTime AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                             string AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                             string AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                             string AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                             string AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                             int AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count ,
                                             short AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                             short AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                             string A2238SGNotificacionTitulo ,
                                             long A2237SGNotificacionID ,
                                             string A2239SGNotificacionDescripcion ,
                                             DateTime A2240SGNotificacionFecha ,
                                             string A2241SGNotificacionUsuario ,
                                             string A2242SGNotificacionUsuarioDsc ,
                                             short A2244SGNotificacionTUsuario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[20];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[SGNotificacionDescripcion], T1.[SGNotificacionTUsuario], T1.[SGNotificacionIconClass], T2.[UsuNom] AS SGNotificacionUsuarioDsc, T1.[SGNotificacionUsuario] AS SGNotificacionUsuario, T1.[SGNotificacionFecha], T1.[SGNotificacionID], T1.[SGNotificacionTitulo] FROM ([SGNOTIFICACIONES] T1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = T1.[SGNotificacionUsuario])";
         if ( ( StringUtil.StrCmp(AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] >= @AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( ! (0==AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] <= @AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] = @AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] like @lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] = @AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] >= @AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] <= @AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] like @lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] = @AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] like @lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] = @AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels, "T1.[SGNotificacionIconClass] IN (", ")")+")");
         }
         if ( ! (0==AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] >= @AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! (0==AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] <= @AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SGNotificacionDescripcion]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007W4( IGxContext context ,
                                             string A2243SGNotificacionIconClass ,
                                             GxSimpleCollection<string> AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                             string AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                             short AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                             string AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                             bool AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                             string AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                             short AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                             string AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                             bool AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                             string AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                             short AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                             string AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                             long AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                             long AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                             string AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                             string AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                             string AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                             string AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                             DateTime AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                             DateTime AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                             string AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                             string AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                             string AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                             string AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                             int AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count ,
                                             short AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                             short AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                             string A2238SGNotificacionTitulo ,
                                             long A2237SGNotificacionID ,
                                             string A2239SGNotificacionDescripcion ,
                                             DateTime A2240SGNotificacionFecha ,
                                             string A2241SGNotificacionUsuario ,
                                             string A2242SGNotificacionUsuarioDsc ,
                                             short A2244SGNotificacionTUsuario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[20];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[SGNotificacionUsuario] AS SGNotificacionUsuario, T1.[SGNotificacionTUsuario], T1.[SGNotificacionIconClass], T2.[UsuNom] AS SGNotificacionUsuarioDsc, T1.[SGNotificacionFecha], T1.[SGNotificacionDescripcion], T1.[SGNotificacionID], T1.[SGNotificacionTitulo] FROM ([SGNOTIFICACIONES] T1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = T1.[SGNotificacionUsuario])";
         if ( ( StringUtil.StrCmp(AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (0==AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] >= @AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( ! (0==AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] <= @AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] = @AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] like @lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] = @AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] >= @AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] <= @AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] like @lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] = @AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] like @lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] = @AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels, "T1.[SGNotificacionIconClass] IN (", ")")+")");
         }
         if ( ! (0==AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] >= @AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! (0==AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] <= @AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SGNotificacionUsuario]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P007W5( IGxContext context ,
                                             string A2243SGNotificacionIconClass ,
                                             GxSimpleCollection<string> AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels ,
                                             string AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1 ,
                                             short AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 ,
                                             string AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1 ,
                                             bool AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 ,
                                             string AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2 ,
                                             short AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 ,
                                             string AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2 ,
                                             bool AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 ,
                                             string AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3 ,
                                             short AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 ,
                                             string AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3 ,
                                             long AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid ,
                                             long AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to ,
                                             string AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel ,
                                             string AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo ,
                                             string AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel ,
                                             string AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion ,
                                             DateTime AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha ,
                                             DateTime AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to ,
                                             string AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel ,
                                             string AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario ,
                                             string AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel ,
                                             string AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc ,
                                             int AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count ,
                                             short AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario ,
                                             short AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to ,
                                             string A2238SGNotificacionTitulo ,
                                             long A2237SGNotificacionID ,
                                             string A2239SGNotificacionDescripcion ,
                                             DateTime A2240SGNotificacionFecha ,
                                             string A2241SGNotificacionUsuario ,
                                             string A2242SGNotificacionUsuarioDsc ,
                                             short A2244SGNotificacionTUsuario )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[20];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[SGNotificacionUsuario] AS SGNotificacionUsuario, T1.[SGNotificacionTUsuario], T1.[SGNotificacionIconClass], T2.[UsuNom] AS SGNotificacionUsuarioDsc, T1.[SGNotificacionFecha], T1.[SGNotificacionDescripcion], T1.[SGNotificacionID], T1.[SGNotificacionTitulo] FROM ([SGNOTIFICACIONES] T1 INNER JOIN [SGUSUARIOS] T2 ON T2.[UsuCod] = T1.[SGNotificacionUsuario])";
         if ( ( StringUtil.StrCmp(AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Seguridad_notificacioneswwds_1_dynamicfiltersselector1, "SGNOTIFICACIONTITULO") == 0 ) && ( AV60Seguridad_notificacioneswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( AV62Seguridad_notificacioneswwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Seguridad_notificacioneswwds_5_dynamicfiltersselector2, "SGNOTIFICACIONTITULO") == 0 ) && ( AV64Seguridad_notificacioneswwds_6_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( AV66Seguridad_notificacioneswwds_8_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Seguridad_notificacioneswwds_9_dynamicfiltersselector3, "SGNOTIFICACIONTITULO") == 0 ) && ( AV68Seguridad_notificacioneswwds_10_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like '%' + @lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ! (0==AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] >= @AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! (0==AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionID] <= @AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] like @lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTitulo] = @AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] like @lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionDescripcion] = @AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] >= @AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionFecha] <= @AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)) ) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] like @lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionUsuario] = @AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] like @lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[UsuNom] = @AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV82Seguridad_notificacioneswwds_24_tfsgnotificacioniconclass_sels, "T1.[SGNotificacionIconClass] IN (", ")")+")");
         }
         if ( ! (0==AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] >= @AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! (0==AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to) )
         {
            AddWhere(sWhereString, "(T1.[SGNotificacionTUsuario] <= @AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SGNotificacionUsuario]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007W2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (short)dynConstraints[34] );
               case 1 :
                     return conditional_P007W3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (short)dynConstraints[34] );
               case 2 :
                     return conditional_P007W4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (short)dynConstraints[34] );
               case 3 :
                     return conditional_P007W5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (short)dynConstraints[34] );
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
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007W2;
          prmP007W2 = new Object[] {
          new ParDef("@lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid",GXType.Decimal,10,0) ,
          new ParDef("@AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo",GXType.NVarChar,100,0) ,
          new ParDef("@AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion",GXType.NVarChar,200,0) ,
          new ParDef("@AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha",GXType.DateTime,8,5) ,
          new ParDef("@AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario",GXType.NChar,10,0) ,
          new ParDef("@AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel",GXType.NChar,10,0) ,
          new ParDef("@lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc",GXType.NChar,100,0) ,
          new ParDef("@AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario",GXType.Int16,4,0) ,
          new ParDef("@AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to",GXType.Int16,4,0)
          };
          Object[] prmP007W3;
          prmP007W3 = new Object[] {
          new ParDef("@lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid",GXType.Decimal,10,0) ,
          new ParDef("@AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo",GXType.NVarChar,100,0) ,
          new ParDef("@AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion",GXType.NVarChar,200,0) ,
          new ParDef("@AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha",GXType.DateTime,8,5) ,
          new ParDef("@AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario",GXType.NChar,10,0) ,
          new ParDef("@AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel",GXType.NChar,10,0) ,
          new ParDef("@lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc",GXType.NChar,100,0) ,
          new ParDef("@AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario",GXType.Int16,4,0) ,
          new ParDef("@AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to",GXType.Int16,4,0)
          };
          Object[] prmP007W4;
          prmP007W4 = new Object[] {
          new ParDef("@lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid",GXType.Decimal,10,0) ,
          new ParDef("@AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo",GXType.NVarChar,100,0) ,
          new ParDef("@AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion",GXType.NVarChar,200,0) ,
          new ParDef("@AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha",GXType.DateTime,8,5) ,
          new ParDef("@AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario",GXType.NChar,10,0) ,
          new ParDef("@AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel",GXType.NChar,10,0) ,
          new ParDef("@lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc",GXType.NChar,100,0) ,
          new ParDef("@AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario",GXType.Int16,4,0) ,
          new ParDef("@AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to",GXType.Int16,4,0)
          };
          Object[] prmP007W5;
          prmP007W5 = new Object[] {
          new ParDef("@lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV61Seguridad_notificacioneswwds_3_sgnotificaciontitulo1",GXType.NVarChar,100,0) ,
          new ParDef("@lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV65Seguridad_notificacioneswwds_7_sgnotificaciontitulo2",GXType.NVarChar,100,0) ,
          new ParDef("@lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@lV69Seguridad_notificacioneswwds_11_sgnotificaciontitulo3",GXType.NVarChar,100,0) ,
          new ParDef("@AV70Seguridad_notificacioneswwds_12_tfsgnotificacionid",GXType.Decimal,10,0) ,
          new ParDef("@AV71Seguridad_notificacioneswwds_13_tfsgnotificacionid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV72Seguridad_notificacioneswwds_14_tfsgnotificaciontitulo",GXType.NVarChar,100,0) ,
          new ParDef("@AV73Seguridad_notificacioneswwds_15_tfsgnotificaciontitulo_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV74Seguridad_notificacioneswwds_16_tfsgnotificaciondescripcion",GXType.NVarChar,200,0) ,
          new ParDef("@AV75Seguridad_notificacioneswwds_17_tfsgnotificaciondescripcion_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV76Seguridad_notificacioneswwds_18_tfsgnotificacionfecha",GXType.DateTime,8,5) ,
          new ParDef("@AV77Seguridad_notificacioneswwds_19_tfsgnotificacionfecha_to",GXType.DateTime,8,5) ,
          new ParDef("@lV78Seguridad_notificacioneswwds_20_tfsgnotificacionusuario",GXType.NChar,10,0) ,
          new ParDef("@AV79Seguridad_notificacioneswwds_21_tfsgnotificacionusuario_sel",GXType.NChar,10,0) ,
          new ParDef("@lV80Seguridad_notificacioneswwds_22_tfsgnotificacionusuariodsc",GXType.NChar,100,0) ,
          new ParDef("@AV81Seguridad_notificacioneswwds_23_tfsgnotificacionusuariodsc_sel",GXType.NChar,100,0) ,
          new ParDef("@AV83Seguridad_notificacioneswwds_25_tfsgnotificaciontusuario",GXType.Int16,4,0) ,
          new ParDef("@AV84Seguridad_notificacioneswwds_26_tfsgnotificaciontusuario_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007W3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007W4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007W5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007W5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 10);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                return;
       }
    }

 }

}
