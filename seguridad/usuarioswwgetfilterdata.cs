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
   public class usuarioswwgetfilterdata : GXProcedure
   {
      public usuarioswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public usuarioswwgetfilterdata( IGxContext context )
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
         this.AV62DDOName = aP0_DDOName;
         this.AV60SearchTxt = aP1_SearchTxt;
         this.AV61SearchTxtTo = aP2_SearchTxtTo;
         this.AV66OptionsJson = "" ;
         this.AV69OptionsDescJson = "" ;
         this.AV71OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV66OptionsJson;
         aP4_OptionsDescJson=this.AV69OptionsDescJson;
         aP5_OptionIndexesJson=this.AV71OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV71OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         usuarioswwgetfilterdata objusuarioswwgetfilterdata;
         objusuarioswwgetfilterdata = new usuarioswwgetfilterdata();
         objusuarioswwgetfilterdata.AV62DDOName = aP0_DDOName;
         objusuarioswwgetfilterdata.AV60SearchTxt = aP1_SearchTxt;
         objusuarioswwgetfilterdata.AV61SearchTxtTo = aP2_SearchTxtTo;
         objusuarioswwgetfilterdata.AV66OptionsJson = "" ;
         objusuarioswwgetfilterdata.AV69OptionsDescJson = "" ;
         objusuarioswwgetfilterdata.AV71OptionIndexesJson = "" ;
         objusuarioswwgetfilterdata.context.SetSubmitInitialConfig(context);
         objusuarioswwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objusuarioswwgetfilterdata);
         aP3_OptionsJson=this.AV66OptionsJson;
         aP4_OptionsDescJson=this.AV69OptionsDescJson;
         aP5_OptionIndexesJson=this.AV71OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((usuarioswwgetfilterdata)stateInfo).executePrivate();
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
         AV65Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV68OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV70OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV62DDOName), "DDO_USUCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUCODOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV62DDOName), "DDO_USUNOM") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUNOMOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV62DDOName), "DDO_USUEMAIL") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUEMAILOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV62DDOName), "DDO_USUVENDDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUVENDDSCOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV62DDOName), "DDO_USUTIEDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADUSUTIEDSCOPTIONS' */
            S161 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV66OptionsJson = AV65Options.ToJSonString(false);
         AV69OptionsDescJson = AV68OptionsDesc.ToJSonString(false);
         AV71OptionIndexesJson = AV70OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV73Session.Get("Seguridad.UsuariosWWGridState"), "") == 0 )
         {
            AV75GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Seguridad.UsuariosWWGridState"), null, "", "");
         }
         else
         {
            AV75GridState.FromXml(AV73Session.Get("Seguridad.UsuariosWWGridState"), null, "", "");
         }
         AV106GXV1 = 1;
         while ( AV106GXV1 <= AV75GridState.gxTpr_Filtervalues.Count )
         {
            AV76GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV75GridState.gxTpr_Filtervalues.Item(AV106GXV1));
            if ( StringUtil.StrCmp(AV76GridStateFilterValue.gxTpr_Name, "TFUSUCOD") == 0 )
            {
               AV10TFUsuCod = AV76GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV76GridStateFilterValue.gxTpr_Name, "TFUSUCOD_SEL") == 0 )
            {
               AV11TFUsuCod_Sel = AV76GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV76GridStateFilterValue.gxTpr_Name, "TFUSUNOM") == 0 )
            {
               AV14TFUsuNom = AV76GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV76GridStateFilterValue.gxTpr_Name, "TFUSUNOM_SEL") == 0 )
            {
               AV15TFUsuNom_Sel = AV76GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV76GridStateFilterValue.gxTpr_Name, "TFUSUEMAIL") == 0 )
            {
               AV46TFUsuEMAIL = AV76GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV76GridStateFilterValue.gxTpr_Name, "TFUSUEMAIL_SEL") == 0 )
            {
               AV47TFUsuEMAIL_Sel = AV76GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV76GridStateFilterValue.gxTpr_Name, "TFUSUSTS_SEL") == 0 )
            {
               AV89TFUsuSts_SelsJson = AV76GridStateFilterValue.gxTpr_Value;
               AV90TFUsuSts_Sels.FromJSonString(AV89TFUsuSts_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV76GridStateFilterValue.gxTpr_Name, "TFUSUVENDDSC") == 0 )
            {
               AV94TFUsuVendDsc = AV76GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV76GridStateFilterValue.gxTpr_Name, "TFUSUVENDDSC_SEL") == 0 )
            {
               AV95TFUsuVendDsc_Sel = AV76GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV76GridStateFilterValue.gxTpr_Name, "TFUSUTIEDSC") == 0 )
            {
               AV96TFUsuTieDsc = AV76GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV76GridStateFilterValue.gxTpr_Name, "TFUSUTIEDSC_SEL") == 0 )
            {
               AV97TFUsuTieDsc_Sel = AV76GridStateFilterValue.gxTpr_Value;
            }
            AV106GXV1 = (int)(AV106GXV1+1);
         }
         if ( AV75GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV77GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV75GridState.gxTpr_Dynamicfilters.Item(1));
            AV78DynamicFiltersSelector1 = AV77GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV78DynamicFiltersSelector1, "USUVENDDSC") == 0 )
            {
               AV79DynamicFiltersOperator1 = AV77GridStateDynamicFilter.gxTpr_Operator;
               AV98UsuVendDsc1 = AV77GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV78DynamicFiltersSelector1, "USUTIEDSC") == 0 )
            {
               AV79DynamicFiltersOperator1 = AV77GridStateDynamicFilter.gxTpr_Operator;
               AV99UsuTieDsc1 = AV77GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV78DynamicFiltersSelector1, "USUNOM") == 0 )
            {
               AV79DynamicFiltersOperator1 = AV77GridStateDynamicFilter.gxTpr_Operator;
               AV91UsuNom1 = AV77GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV75GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV81DynamicFiltersEnabled2 = true;
               AV77GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV75GridState.gxTpr_Dynamicfilters.Item(2));
               AV82DynamicFiltersSelector2 = AV77GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV82DynamicFiltersSelector2, "USUVENDDSC") == 0 )
               {
                  AV83DynamicFiltersOperator2 = AV77GridStateDynamicFilter.gxTpr_Operator;
                  AV100UsuVendDsc2 = AV77GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV82DynamicFiltersSelector2, "USUTIEDSC") == 0 )
               {
                  AV83DynamicFiltersOperator2 = AV77GridStateDynamicFilter.gxTpr_Operator;
                  AV101UsuTieDsc2 = AV77GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV82DynamicFiltersSelector2, "USUNOM") == 0 )
               {
                  AV83DynamicFiltersOperator2 = AV77GridStateDynamicFilter.gxTpr_Operator;
                  AV92UsuNom2 = AV77GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV75GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV85DynamicFiltersEnabled3 = true;
                  AV77GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV75GridState.gxTpr_Dynamicfilters.Item(3));
                  AV86DynamicFiltersSelector3 = AV77GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV86DynamicFiltersSelector3, "USUVENDDSC") == 0 )
                  {
                     AV87DynamicFiltersOperator3 = AV77GridStateDynamicFilter.gxTpr_Operator;
                     AV102UsuVendDsc3 = AV77GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV86DynamicFiltersSelector3, "USUTIEDSC") == 0 )
                  {
                     AV87DynamicFiltersOperator3 = AV77GridStateDynamicFilter.gxTpr_Operator;
                     AV103UsuTieDsc3 = AV77GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV86DynamicFiltersSelector3, "USUNOM") == 0 )
                  {
                     AV87DynamicFiltersOperator3 = AV77GridStateDynamicFilter.gxTpr_Operator;
                     AV93UsuNom3 = AV77GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADUSUCODOPTIONS' Routine */
         returnInSub = false;
         AV10TFUsuCod = AV60SearchTxt;
         AV11TFUsuCod_Sel = "";
         AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 = AV78DynamicFiltersSelector1;
         AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 = AV79DynamicFiltersOperator1;
         AV110Seguridad_usuarioswwds_3_usuvenddsc1 = AV98UsuVendDsc1;
         AV111Seguridad_usuarioswwds_4_usutiedsc1 = AV99UsuTieDsc1;
         AV112Seguridad_usuarioswwds_5_usunom1 = AV91UsuNom1;
         AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 = AV81DynamicFiltersEnabled2;
         AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 = AV82DynamicFiltersSelector2;
         AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 = AV83DynamicFiltersOperator2;
         AV116Seguridad_usuarioswwds_9_usuvenddsc2 = AV100UsuVendDsc2;
         AV117Seguridad_usuarioswwds_10_usutiedsc2 = AV101UsuTieDsc2;
         AV118Seguridad_usuarioswwds_11_usunom2 = AV92UsuNom2;
         AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV122Seguridad_usuarioswwds_15_usuvenddsc3 = AV102UsuVendDsc3;
         AV123Seguridad_usuarioswwds_16_usutiedsc3 = AV103UsuTieDsc3;
         AV124Seguridad_usuarioswwds_17_usunom3 = AV93UsuNom3;
         AV125Seguridad_usuarioswwds_18_tfusucod = AV10TFUsuCod;
         AV126Seguridad_usuarioswwds_19_tfusucod_sel = AV11TFUsuCod_Sel;
         AV127Seguridad_usuarioswwds_20_tfusunom = AV14TFUsuNom;
         AV128Seguridad_usuarioswwds_21_tfusunom_sel = AV15TFUsuNom_Sel;
         AV129Seguridad_usuarioswwds_22_tfusuemail = AV46TFUsuEMAIL;
         AV130Seguridad_usuarioswwds_23_tfusuemail_sel = AV47TFUsuEMAIL_Sel;
         AV131Seguridad_usuarioswwds_24_tfususts_sels = AV90TFUsuSts_Sels;
         AV132Seguridad_usuarioswwds_25_tfusuvenddsc = AV94TFUsuVendDsc;
         AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel = AV95TFUsuVendDsc_Sel;
         AV134Seguridad_usuarioswwds_27_tfusutiedsc = AV96TFUsuTieDsc;
         AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel = AV97TFUsuTieDsc_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A2039UsuSts ,
                                              AV131Seguridad_usuarioswwds_24_tfususts_sels ,
                                              AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                              AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                              AV110Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                              AV111Seguridad_usuarioswwds_4_usutiedsc1 ,
                                              AV112Seguridad_usuarioswwds_5_usunom1 ,
                                              AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                              AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                              AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                              AV116Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                              AV117Seguridad_usuarioswwds_10_usutiedsc2 ,
                                              AV118Seguridad_usuarioswwds_11_usunom2 ,
                                              AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                              AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                              AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                              AV122Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                              AV123Seguridad_usuarioswwds_16_usutiedsc3 ,
                                              AV124Seguridad_usuarioswwds_17_usunom3 ,
                                              AV126Seguridad_usuarioswwds_19_tfusucod_sel ,
                                              AV125Seguridad_usuarioswwds_18_tfusucod ,
                                              AV128Seguridad_usuarioswwds_21_tfusunom_sel ,
                                              AV127Seguridad_usuarioswwds_20_tfusunom ,
                                              AV130Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                              AV129Seguridad_usuarioswwds_22_tfusuemail ,
                                              AV131Seguridad_usuarioswwds_24_tfususts_sels.Count ,
                                              AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                              AV132Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                              AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                              AV134Seguridad_usuarioswwds_27_tfusutiedsc ,
                                              A2097UsuVendDsc ,
                                              A2096UsuTieDsc ,
                                              A2019UsuNom ,
                                              A348UsuCod ,
                                              A2014UsuEMAIL } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV110Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV110Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV111Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV111Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV112Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV112Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV116Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV116Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV117Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV117Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV118Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV118Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV122Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV122Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV123Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV123Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV124Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV124Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV125Seguridad_usuarioswwds_18_tfusucod = StringUtil.PadR( StringUtil.RTrim( AV125Seguridad_usuarioswwds_18_tfusucod), 10, "%");
         lV127Seguridad_usuarioswwds_20_tfusunom = StringUtil.PadR( StringUtil.RTrim( AV127Seguridad_usuarioswwds_20_tfusunom), 100, "%");
         lV129Seguridad_usuarioswwds_22_tfusuemail = StringUtil.Concat( StringUtil.RTrim( AV129Seguridad_usuarioswwds_22_tfusuemail), "%", "");
         lV132Seguridad_usuarioswwds_25_tfusuvenddsc = StringUtil.PadR( StringUtil.RTrim( AV132Seguridad_usuarioswwds_25_tfusuvenddsc), 100, "%");
         lV134Seguridad_usuarioswwds_27_tfusutiedsc = StringUtil.PadR( StringUtil.RTrim( AV134Seguridad_usuarioswwds_27_tfusutiedsc), 100, "%");
         /* Using cursor P001M2 */
         pr_default.execute(0, new Object[] {lV110Seguridad_usuarioswwds_3_usuvenddsc1, lV110Seguridad_usuarioswwds_3_usuvenddsc1, lV111Seguridad_usuarioswwds_4_usutiedsc1, lV111Seguridad_usuarioswwds_4_usutiedsc1, lV112Seguridad_usuarioswwds_5_usunom1, lV112Seguridad_usuarioswwds_5_usunom1, lV116Seguridad_usuarioswwds_9_usuvenddsc2, lV116Seguridad_usuarioswwds_9_usuvenddsc2, lV117Seguridad_usuarioswwds_10_usutiedsc2, lV117Seguridad_usuarioswwds_10_usutiedsc2, lV118Seguridad_usuarioswwds_11_usunom2, lV118Seguridad_usuarioswwds_11_usunom2, lV122Seguridad_usuarioswwds_15_usuvenddsc3, lV122Seguridad_usuarioswwds_15_usuvenddsc3, lV123Seguridad_usuarioswwds_16_usutiedsc3, lV123Seguridad_usuarioswwds_16_usutiedsc3, lV124Seguridad_usuarioswwds_17_usunom3, lV124Seguridad_usuarioswwds_17_usunom3, lV125Seguridad_usuarioswwds_18_tfusucod, AV126Seguridad_usuarioswwds_19_tfusucod_sel, lV127Seguridad_usuarioswwds_20_tfusunom, AV128Seguridad_usuarioswwds_21_tfusunom_sel, lV129Seguridad_usuarioswwds_22_tfusuemail, AV130Seguridad_usuarioswwds_23_tfusuemail_sel, lV132Seguridad_usuarioswwds_25_tfusuvenddsc, AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel, lV134Seguridad_usuarioswwds_27_tfusutiedsc, AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2041UsuVend = P001M2_A2041UsuVend[0];
            A2040UsuTieCod = P001M2_A2040UsuTieCod[0];
            A2039UsuSts = P001M2_A2039UsuSts[0];
            A2014UsuEMAIL = P001M2_A2014UsuEMAIL[0];
            A348UsuCod = P001M2_A348UsuCod[0];
            A2019UsuNom = P001M2_A2019UsuNom[0];
            A2096UsuTieDsc = P001M2_A2096UsuTieDsc[0];
            A2097UsuVendDsc = P001M2_A2097UsuVendDsc[0];
            A2097UsuVendDsc = P001M2_A2097UsuVendDsc[0];
            A2096UsuTieDsc = P001M2_A2096UsuTieDsc[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A348UsuCod)) )
            {
               AV64Option = A348UsuCod;
               AV65Options.Add(AV64Option, 0);
            }
            if ( AV65Options.Count == 50 )
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
         /* 'LOADUSUNOMOPTIONS' Routine */
         returnInSub = false;
         AV14TFUsuNom = AV60SearchTxt;
         AV15TFUsuNom_Sel = "";
         AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 = AV78DynamicFiltersSelector1;
         AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 = AV79DynamicFiltersOperator1;
         AV110Seguridad_usuarioswwds_3_usuvenddsc1 = AV98UsuVendDsc1;
         AV111Seguridad_usuarioswwds_4_usutiedsc1 = AV99UsuTieDsc1;
         AV112Seguridad_usuarioswwds_5_usunom1 = AV91UsuNom1;
         AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 = AV81DynamicFiltersEnabled2;
         AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 = AV82DynamicFiltersSelector2;
         AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 = AV83DynamicFiltersOperator2;
         AV116Seguridad_usuarioswwds_9_usuvenddsc2 = AV100UsuVendDsc2;
         AV117Seguridad_usuarioswwds_10_usutiedsc2 = AV101UsuTieDsc2;
         AV118Seguridad_usuarioswwds_11_usunom2 = AV92UsuNom2;
         AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV122Seguridad_usuarioswwds_15_usuvenddsc3 = AV102UsuVendDsc3;
         AV123Seguridad_usuarioswwds_16_usutiedsc3 = AV103UsuTieDsc3;
         AV124Seguridad_usuarioswwds_17_usunom3 = AV93UsuNom3;
         AV125Seguridad_usuarioswwds_18_tfusucod = AV10TFUsuCod;
         AV126Seguridad_usuarioswwds_19_tfusucod_sel = AV11TFUsuCod_Sel;
         AV127Seguridad_usuarioswwds_20_tfusunom = AV14TFUsuNom;
         AV128Seguridad_usuarioswwds_21_tfusunom_sel = AV15TFUsuNom_Sel;
         AV129Seguridad_usuarioswwds_22_tfusuemail = AV46TFUsuEMAIL;
         AV130Seguridad_usuarioswwds_23_tfusuemail_sel = AV47TFUsuEMAIL_Sel;
         AV131Seguridad_usuarioswwds_24_tfususts_sels = AV90TFUsuSts_Sels;
         AV132Seguridad_usuarioswwds_25_tfusuvenddsc = AV94TFUsuVendDsc;
         AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel = AV95TFUsuVendDsc_Sel;
         AV134Seguridad_usuarioswwds_27_tfusutiedsc = AV96TFUsuTieDsc;
         AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel = AV97TFUsuTieDsc_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A2039UsuSts ,
                                              AV131Seguridad_usuarioswwds_24_tfususts_sels ,
                                              AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                              AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                              AV110Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                              AV111Seguridad_usuarioswwds_4_usutiedsc1 ,
                                              AV112Seguridad_usuarioswwds_5_usunom1 ,
                                              AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                              AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                              AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                              AV116Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                              AV117Seguridad_usuarioswwds_10_usutiedsc2 ,
                                              AV118Seguridad_usuarioswwds_11_usunom2 ,
                                              AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                              AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                              AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                              AV122Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                              AV123Seguridad_usuarioswwds_16_usutiedsc3 ,
                                              AV124Seguridad_usuarioswwds_17_usunom3 ,
                                              AV126Seguridad_usuarioswwds_19_tfusucod_sel ,
                                              AV125Seguridad_usuarioswwds_18_tfusucod ,
                                              AV128Seguridad_usuarioswwds_21_tfusunom_sel ,
                                              AV127Seguridad_usuarioswwds_20_tfusunom ,
                                              AV130Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                              AV129Seguridad_usuarioswwds_22_tfusuemail ,
                                              AV131Seguridad_usuarioswwds_24_tfususts_sels.Count ,
                                              AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                              AV132Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                              AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                              AV134Seguridad_usuarioswwds_27_tfusutiedsc ,
                                              A2097UsuVendDsc ,
                                              A2096UsuTieDsc ,
                                              A2019UsuNom ,
                                              A348UsuCod ,
                                              A2014UsuEMAIL } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV110Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV110Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV111Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV111Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV112Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV112Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV116Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV116Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV117Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV117Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV118Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV118Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV122Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV122Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV123Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV123Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV124Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV124Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV125Seguridad_usuarioswwds_18_tfusucod = StringUtil.PadR( StringUtil.RTrim( AV125Seguridad_usuarioswwds_18_tfusucod), 10, "%");
         lV127Seguridad_usuarioswwds_20_tfusunom = StringUtil.PadR( StringUtil.RTrim( AV127Seguridad_usuarioswwds_20_tfusunom), 100, "%");
         lV129Seguridad_usuarioswwds_22_tfusuemail = StringUtil.Concat( StringUtil.RTrim( AV129Seguridad_usuarioswwds_22_tfusuemail), "%", "");
         lV132Seguridad_usuarioswwds_25_tfusuvenddsc = StringUtil.PadR( StringUtil.RTrim( AV132Seguridad_usuarioswwds_25_tfusuvenddsc), 100, "%");
         lV134Seguridad_usuarioswwds_27_tfusutiedsc = StringUtil.PadR( StringUtil.RTrim( AV134Seguridad_usuarioswwds_27_tfusutiedsc), 100, "%");
         /* Using cursor P001M3 */
         pr_default.execute(1, new Object[] {lV110Seguridad_usuarioswwds_3_usuvenddsc1, lV110Seguridad_usuarioswwds_3_usuvenddsc1, lV111Seguridad_usuarioswwds_4_usutiedsc1, lV111Seguridad_usuarioswwds_4_usutiedsc1, lV112Seguridad_usuarioswwds_5_usunom1, lV112Seguridad_usuarioswwds_5_usunom1, lV116Seguridad_usuarioswwds_9_usuvenddsc2, lV116Seguridad_usuarioswwds_9_usuvenddsc2, lV117Seguridad_usuarioswwds_10_usutiedsc2, lV117Seguridad_usuarioswwds_10_usutiedsc2, lV118Seguridad_usuarioswwds_11_usunom2, lV118Seguridad_usuarioswwds_11_usunom2, lV122Seguridad_usuarioswwds_15_usuvenddsc3, lV122Seguridad_usuarioswwds_15_usuvenddsc3, lV123Seguridad_usuarioswwds_16_usutiedsc3, lV123Seguridad_usuarioswwds_16_usutiedsc3, lV124Seguridad_usuarioswwds_17_usunom3, lV124Seguridad_usuarioswwds_17_usunom3, lV125Seguridad_usuarioswwds_18_tfusucod, AV126Seguridad_usuarioswwds_19_tfusucod_sel, lV127Seguridad_usuarioswwds_20_tfusunom, AV128Seguridad_usuarioswwds_21_tfusunom_sel, lV129Seguridad_usuarioswwds_22_tfusuemail, AV130Seguridad_usuarioswwds_23_tfusuemail_sel, lV132Seguridad_usuarioswwds_25_tfusuvenddsc, AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel, lV134Seguridad_usuarioswwds_27_tfusutiedsc, AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK1M3 = false;
            A2041UsuVend = P001M3_A2041UsuVend[0];
            A2040UsuTieCod = P001M3_A2040UsuTieCod[0];
            A2019UsuNom = P001M3_A2019UsuNom[0];
            A2039UsuSts = P001M3_A2039UsuSts[0];
            A2014UsuEMAIL = P001M3_A2014UsuEMAIL[0];
            A348UsuCod = P001M3_A348UsuCod[0];
            A2096UsuTieDsc = P001M3_A2096UsuTieDsc[0];
            A2097UsuVendDsc = P001M3_A2097UsuVendDsc[0];
            A2097UsuVendDsc = P001M3_A2097UsuVendDsc[0];
            A2096UsuTieDsc = P001M3_A2096UsuTieDsc[0];
            AV72count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P001M3_A2019UsuNom[0], A2019UsuNom) == 0 ) )
            {
               BRK1M3 = false;
               A348UsuCod = P001M3_A348UsuCod[0];
               AV72count = (long)(AV72count+1);
               BRK1M3 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2019UsuNom)) )
            {
               AV64Option = A2019UsuNom;
               AV65Options.Add(AV64Option, 0);
               AV70OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV72count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV65Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1M3 )
            {
               BRK1M3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADUSUEMAILOPTIONS' Routine */
         returnInSub = false;
         AV46TFUsuEMAIL = AV60SearchTxt;
         AV47TFUsuEMAIL_Sel = "";
         AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 = AV78DynamicFiltersSelector1;
         AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 = AV79DynamicFiltersOperator1;
         AV110Seguridad_usuarioswwds_3_usuvenddsc1 = AV98UsuVendDsc1;
         AV111Seguridad_usuarioswwds_4_usutiedsc1 = AV99UsuTieDsc1;
         AV112Seguridad_usuarioswwds_5_usunom1 = AV91UsuNom1;
         AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 = AV81DynamicFiltersEnabled2;
         AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 = AV82DynamicFiltersSelector2;
         AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 = AV83DynamicFiltersOperator2;
         AV116Seguridad_usuarioswwds_9_usuvenddsc2 = AV100UsuVendDsc2;
         AV117Seguridad_usuarioswwds_10_usutiedsc2 = AV101UsuTieDsc2;
         AV118Seguridad_usuarioswwds_11_usunom2 = AV92UsuNom2;
         AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV122Seguridad_usuarioswwds_15_usuvenddsc3 = AV102UsuVendDsc3;
         AV123Seguridad_usuarioswwds_16_usutiedsc3 = AV103UsuTieDsc3;
         AV124Seguridad_usuarioswwds_17_usunom3 = AV93UsuNom3;
         AV125Seguridad_usuarioswwds_18_tfusucod = AV10TFUsuCod;
         AV126Seguridad_usuarioswwds_19_tfusucod_sel = AV11TFUsuCod_Sel;
         AV127Seguridad_usuarioswwds_20_tfusunom = AV14TFUsuNom;
         AV128Seguridad_usuarioswwds_21_tfusunom_sel = AV15TFUsuNom_Sel;
         AV129Seguridad_usuarioswwds_22_tfusuemail = AV46TFUsuEMAIL;
         AV130Seguridad_usuarioswwds_23_tfusuemail_sel = AV47TFUsuEMAIL_Sel;
         AV131Seguridad_usuarioswwds_24_tfususts_sels = AV90TFUsuSts_Sels;
         AV132Seguridad_usuarioswwds_25_tfusuvenddsc = AV94TFUsuVendDsc;
         AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel = AV95TFUsuVendDsc_Sel;
         AV134Seguridad_usuarioswwds_27_tfusutiedsc = AV96TFUsuTieDsc;
         AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel = AV97TFUsuTieDsc_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A2039UsuSts ,
                                              AV131Seguridad_usuarioswwds_24_tfususts_sels ,
                                              AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                              AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                              AV110Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                              AV111Seguridad_usuarioswwds_4_usutiedsc1 ,
                                              AV112Seguridad_usuarioswwds_5_usunom1 ,
                                              AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                              AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                              AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                              AV116Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                              AV117Seguridad_usuarioswwds_10_usutiedsc2 ,
                                              AV118Seguridad_usuarioswwds_11_usunom2 ,
                                              AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                              AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                              AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                              AV122Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                              AV123Seguridad_usuarioswwds_16_usutiedsc3 ,
                                              AV124Seguridad_usuarioswwds_17_usunom3 ,
                                              AV126Seguridad_usuarioswwds_19_tfusucod_sel ,
                                              AV125Seguridad_usuarioswwds_18_tfusucod ,
                                              AV128Seguridad_usuarioswwds_21_tfusunom_sel ,
                                              AV127Seguridad_usuarioswwds_20_tfusunom ,
                                              AV130Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                              AV129Seguridad_usuarioswwds_22_tfusuemail ,
                                              AV131Seguridad_usuarioswwds_24_tfususts_sels.Count ,
                                              AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                              AV132Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                              AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                              AV134Seguridad_usuarioswwds_27_tfusutiedsc ,
                                              A2097UsuVendDsc ,
                                              A2096UsuTieDsc ,
                                              A2019UsuNom ,
                                              A348UsuCod ,
                                              A2014UsuEMAIL } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV110Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV110Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV111Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV111Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV112Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV112Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV116Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV116Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV117Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV117Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV118Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV118Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV122Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV122Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV123Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV123Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV124Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV124Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV125Seguridad_usuarioswwds_18_tfusucod = StringUtil.PadR( StringUtil.RTrim( AV125Seguridad_usuarioswwds_18_tfusucod), 10, "%");
         lV127Seguridad_usuarioswwds_20_tfusunom = StringUtil.PadR( StringUtil.RTrim( AV127Seguridad_usuarioswwds_20_tfusunom), 100, "%");
         lV129Seguridad_usuarioswwds_22_tfusuemail = StringUtil.Concat( StringUtil.RTrim( AV129Seguridad_usuarioswwds_22_tfusuemail), "%", "");
         lV132Seguridad_usuarioswwds_25_tfusuvenddsc = StringUtil.PadR( StringUtil.RTrim( AV132Seguridad_usuarioswwds_25_tfusuvenddsc), 100, "%");
         lV134Seguridad_usuarioswwds_27_tfusutiedsc = StringUtil.PadR( StringUtil.RTrim( AV134Seguridad_usuarioswwds_27_tfusutiedsc), 100, "%");
         /* Using cursor P001M4 */
         pr_default.execute(2, new Object[] {lV110Seguridad_usuarioswwds_3_usuvenddsc1, lV110Seguridad_usuarioswwds_3_usuvenddsc1, lV111Seguridad_usuarioswwds_4_usutiedsc1, lV111Seguridad_usuarioswwds_4_usutiedsc1, lV112Seguridad_usuarioswwds_5_usunom1, lV112Seguridad_usuarioswwds_5_usunom1, lV116Seguridad_usuarioswwds_9_usuvenddsc2, lV116Seguridad_usuarioswwds_9_usuvenddsc2, lV117Seguridad_usuarioswwds_10_usutiedsc2, lV117Seguridad_usuarioswwds_10_usutiedsc2, lV118Seguridad_usuarioswwds_11_usunom2, lV118Seguridad_usuarioswwds_11_usunom2, lV122Seguridad_usuarioswwds_15_usuvenddsc3, lV122Seguridad_usuarioswwds_15_usuvenddsc3, lV123Seguridad_usuarioswwds_16_usutiedsc3, lV123Seguridad_usuarioswwds_16_usutiedsc3, lV124Seguridad_usuarioswwds_17_usunom3, lV124Seguridad_usuarioswwds_17_usunom3, lV125Seguridad_usuarioswwds_18_tfusucod, AV126Seguridad_usuarioswwds_19_tfusucod_sel, lV127Seguridad_usuarioswwds_20_tfusunom, AV128Seguridad_usuarioswwds_21_tfusunom_sel, lV129Seguridad_usuarioswwds_22_tfusuemail, AV130Seguridad_usuarioswwds_23_tfusuemail_sel, lV132Seguridad_usuarioswwds_25_tfusuvenddsc, AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel, lV134Seguridad_usuarioswwds_27_tfusutiedsc, AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK1M5 = false;
            A2041UsuVend = P001M4_A2041UsuVend[0];
            A2040UsuTieCod = P001M4_A2040UsuTieCod[0];
            A2014UsuEMAIL = P001M4_A2014UsuEMAIL[0];
            A2039UsuSts = P001M4_A2039UsuSts[0];
            A348UsuCod = P001M4_A348UsuCod[0];
            A2019UsuNom = P001M4_A2019UsuNom[0];
            A2096UsuTieDsc = P001M4_A2096UsuTieDsc[0];
            A2097UsuVendDsc = P001M4_A2097UsuVendDsc[0];
            A2097UsuVendDsc = P001M4_A2097UsuVendDsc[0];
            A2096UsuTieDsc = P001M4_A2096UsuTieDsc[0];
            AV72count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P001M4_A2014UsuEMAIL[0], A2014UsuEMAIL) == 0 ) )
            {
               BRK1M5 = false;
               A348UsuCod = P001M4_A348UsuCod[0];
               AV72count = (long)(AV72count+1);
               BRK1M5 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2014UsuEMAIL)) )
            {
               AV64Option = A2014UsuEMAIL;
               AV65Options.Add(AV64Option, 0);
               AV70OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV72count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV65Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1M5 )
            {
               BRK1M5 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADUSUVENDDSCOPTIONS' Routine */
         returnInSub = false;
         AV94TFUsuVendDsc = AV60SearchTxt;
         AV95TFUsuVendDsc_Sel = "";
         AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 = AV78DynamicFiltersSelector1;
         AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 = AV79DynamicFiltersOperator1;
         AV110Seguridad_usuarioswwds_3_usuvenddsc1 = AV98UsuVendDsc1;
         AV111Seguridad_usuarioswwds_4_usutiedsc1 = AV99UsuTieDsc1;
         AV112Seguridad_usuarioswwds_5_usunom1 = AV91UsuNom1;
         AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 = AV81DynamicFiltersEnabled2;
         AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 = AV82DynamicFiltersSelector2;
         AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 = AV83DynamicFiltersOperator2;
         AV116Seguridad_usuarioswwds_9_usuvenddsc2 = AV100UsuVendDsc2;
         AV117Seguridad_usuarioswwds_10_usutiedsc2 = AV101UsuTieDsc2;
         AV118Seguridad_usuarioswwds_11_usunom2 = AV92UsuNom2;
         AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV122Seguridad_usuarioswwds_15_usuvenddsc3 = AV102UsuVendDsc3;
         AV123Seguridad_usuarioswwds_16_usutiedsc3 = AV103UsuTieDsc3;
         AV124Seguridad_usuarioswwds_17_usunom3 = AV93UsuNom3;
         AV125Seguridad_usuarioswwds_18_tfusucod = AV10TFUsuCod;
         AV126Seguridad_usuarioswwds_19_tfusucod_sel = AV11TFUsuCod_Sel;
         AV127Seguridad_usuarioswwds_20_tfusunom = AV14TFUsuNom;
         AV128Seguridad_usuarioswwds_21_tfusunom_sel = AV15TFUsuNom_Sel;
         AV129Seguridad_usuarioswwds_22_tfusuemail = AV46TFUsuEMAIL;
         AV130Seguridad_usuarioswwds_23_tfusuemail_sel = AV47TFUsuEMAIL_Sel;
         AV131Seguridad_usuarioswwds_24_tfususts_sels = AV90TFUsuSts_Sels;
         AV132Seguridad_usuarioswwds_25_tfusuvenddsc = AV94TFUsuVendDsc;
         AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel = AV95TFUsuVendDsc_Sel;
         AV134Seguridad_usuarioswwds_27_tfusutiedsc = AV96TFUsuTieDsc;
         AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel = AV97TFUsuTieDsc_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A2039UsuSts ,
                                              AV131Seguridad_usuarioswwds_24_tfususts_sels ,
                                              AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                              AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                              AV110Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                              AV111Seguridad_usuarioswwds_4_usutiedsc1 ,
                                              AV112Seguridad_usuarioswwds_5_usunom1 ,
                                              AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                              AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                              AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                              AV116Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                              AV117Seguridad_usuarioswwds_10_usutiedsc2 ,
                                              AV118Seguridad_usuarioswwds_11_usunom2 ,
                                              AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                              AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                              AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                              AV122Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                              AV123Seguridad_usuarioswwds_16_usutiedsc3 ,
                                              AV124Seguridad_usuarioswwds_17_usunom3 ,
                                              AV126Seguridad_usuarioswwds_19_tfusucod_sel ,
                                              AV125Seguridad_usuarioswwds_18_tfusucod ,
                                              AV128Seguridad_usuarioswwds_21_tfusunom_sel ,
                                              AV127Seguridad_usuarioswwds_20_tfusunom ,
                                              AV130Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                              AV129Seguridad_usuarioswwds_22_tfusuemail ,
                                              AV131Seguridad_usuarioswwds_24_tfususts_sels.Count ,
                                              AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                              AV132Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                              AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                              AV134Seguridad_usuarioswwds_27_tfusutiedsc ,
                                              A2097UsuVendDsc ,
                                              A2096UsuTieDsc ,
                                              A2019UsuNom ,
                                              A348UsuCod ,
                                              A2014UsuEMAIL } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV110Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV110Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV111Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV111Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV112Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV112Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV116Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV116Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV117Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV117Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV118Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV118Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV122Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV122Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV123Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV123Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV124Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV124Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV125Seguridad_usuarioswwds_18_tfusucod = StringUtil.PadR( StringUtil.RTrim( AV125Seguridad_usuarioswwds_18_tfusucod), 10, "%");
         lV127Seguridad_usuarioswwds_20_tfusunom = StringUtil.PadR( StringUtil.RTrim( AV127Seguridad_usuarioswwds_20_tfusunom), 100, "%");
         lV129Seguridad_usuarioswwds_22_tfusuemail = StringUtil.Concat( StringUtil.RTrim( AV129Seguridad_usuarioswwds_22_tfusuemail), "%", "");
         lV132Seguridad_usuarioswwds_25_tfusuvenddsc = StringUtil.PadR( StringUtil.RTrim( AV132Seguridad_usuarioswwds_25_tfusuvenddsc), 100, "%");
         lV134Seguridad_usuarioswwds_27_tfusutiedsc = StringUtil.PadR( StringUtil.RTrim( AV134Seguridad_usuarioswwds_27_tfusutiedsc), 100, "%");
         /* Using cursor P001M5 */
         pr_default.execute(3, new Object[] {lV110Seguridad_usuarioswwds_3_usuvenddsc1, lV110Seguridad_usuarioswwds_3_usuvenddsc1, lV111Seguridad_usuarioswwds_4_usutiedsc1, lV111Seguridad_usuarioswwds_4_usutiedsc1, lV112Seguridad_usuarioswwds_5_usunom1, lV112Seguridad_usuarioswwds_5_usunom1, lV116Seguridad_usuarioswwds_9_usuvenddsc2, lV116Seguridad_usuarioswwds_9_usuvenddsc2, lV117Seguridad_usuarioswwds_10_usutiedsc2, lV117Seguridad_usuarioswwds_10_usutiedsc2, lV118Seguridad_usuarioswwds_11_usunom2, lV118Seguridad_usuarioswwds_11_usunom2, lV122Seguridad_usuarioswwds_15_usuvenddsc3, lV122Seguridad_usuarioswwds_15_usuvenddsc3, lV123Seguridad_usuarioswwds_16_usutiedsc3, lV123Seguridad_usuarioswwds_16_usutiedsc3, lV124Seguridad_usuarioswwds_17_usunom3, lV124Seguridad_usuarioswwds_17_usunom3, lV125Seguridad_usuarioswwds_18_tfusucod, AV126Seguridad_usuarioswwds_19_tfusucod_sel, lV127Seguridad_usuarioswwds_20_tfusunom, AV128Seguridad_usuarioswwds_21_tfusunom_sel, lV129Seguridad_usuarioswwds_22_tfusuemail, AV130Seguridad_usuarioswwds_23_tfusuemail_sel, lV132Seguridad_usuarioswwds_25_tfusuvenddsc, AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel, lV134Seguridad_usuarioswwds_27_tfusutiedsc, AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK1M7 = false;
            A2040UsuTieCod = P001M5_A2040UsuTieCod[0];
            A2041UsuVend = P001M5_A2041UsuVend[0];
            A2039UsuSts = P001M5_A2039UsuSts[0];
            A2014UsuEMAIL = P001M5_A2014UsuEMAIL[0];
            A348UsuCod = P001M5_A348UsuCod[0];
            A2019UsuNom = P001M5_A2019UsuNom[0];
            A2096UsuTieDsc = P001M5_A2096UsuTieDsc[0];
            A2097UsuVendDsc = P001M5_A2097UsuVendDsc[0];
            A2096UsuTieDsc = P001M5_A2096UsuTieDsc[0];
            A2097UsuVendDsc = P001M5_A2097UsuVendDsc[0];
            AV72count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( P001M5_A2041UsuVend[0] == A2041UsuVend ) )
            {
               BRK1M7 = false;
               A348UsuCod = P001M5_A348UsuCod[0];
               AV72count = (long)(AV72count+1);
               BRK1M7 = true;
               pr_default.readNext(3);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2097UsuVendDsc)) )
            {
               AV64Option = A2097UsuVendDsc;
               AV63InsertIndex = 1;
               while ( ( AV63InsertIndex <= AV65Options.Count ) && ( StringUtil.StrCmp(((string)AV65Options.Item(AV63InsertIndex)), AV64Option) < 0 ) )
               {
                  AV63InsertIndex = (int)(AV63InsertIndex+1);
               }
               AV65Options.Add(AV64Option, AV63InsertIndex);
               AV70OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV72count), "Z,ZZZ,ZZZ,ZZ9")), AV63InsertIndex);
            }
            if ( AV65Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1M7 )
            {
               BRK1M7 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADUSUTIEDSCOPTIONS' Routine */
         returnInSub = false;
         AV96TFUsuTieDsc = AV60SearchTxt;
         AV97TFUsuTieDsc_Sel = "";
         AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 = AV78DynamicFiltersSelector1;
         AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 = AV79DynamicFiltersOperator1;
         AV110Seguridad_usuarioswwds_3_usuvenddsc1 = AV98UsuVendDsc1;
         AV111Seguridad_usuarioswwds_4_usutiedsc1 = AV99UsuTieDsc1;
         AV112Seguridad_usuarioswwds_5_usunom1 = AV91UsuNom1;
         AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 = AV81DynamicFiltersEnabled2;
         AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 = AV82DynamicFiltersSelector2;
         AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 = AV83DynamicFiltersOperator2;
         AV116Seguridad_usuarioswwds_9_usuvenddsc2 = AV100UsuVendDsc2;
         AV117Seguridad_usuarioswwds_10_usutiedsc2 = AV101UsuTieDsc2;
         AV118Seguridad_usuarioswwds_11_usunom2 = AV92UsuNom2;
         AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 = AV85DynamicFiltersEnabled3;
         AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 = AV86DynamicFiltersSelector3;
         AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 = AV87DynamicFiltersOperator3;
         AV122Seguridad_usuarioswwds_15_usuvenddsc3 = AV102UsuVendDsc3;
         AV123Seguridad_usuarioswwds_16_usutiedsc3 = AV103UsuTieDsc3;
         AV124Seguridad_usuarioswwds_17_usunom3 = AV93UsuNom3;
         AV125Seguridad_usuarioswwds_18_tfusucod = AV10TFUsuCod;
         AV126Seguridad_usuarioswwds_19_tfusucod_sel = AV11TFUsuCod_Sel;
         AV127Seguridad_usuarioswwds_20_tfusunom = AV14TFUsuNom;
         AV128Seguridad_usuarioswwds_21_tfusunom_sel = AV15TFUsuNom_Sel;
         AV129Seguridad_usuarioswwds_22_tfusuemail = AV46TFUsuEMAIL;
         AV130Seguridad_usuarioswwds_23_tfusuemail_sel = AV47TFUsuEMAIL_Sel;
         AV131Seguridad_usuarioswwds_24_tfususts_sels = AV90TFUsuSts_Sels;
         AV132Seguridad_usuarioswwds_25_tfusuvenddsc = AV94TFUsuVendDsc;
         AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel = AV95TFUsuVendDsc_Sel;
         AV134Seguridad_usuarioswwds_27_tfusutiedsc = AV96TFUsuTieDsc;
         AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel = AV97TFUsuTieDsc_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A2039UsuSts ,
                                              AV131Seguridad_usuarioswwds_24_tfususts_sels ,
                                              AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                              AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                              AV110Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                              AV111Seguridad_usuarioswwds_4_usutiedsc1 ,
                                              AV112Seguridad_usuarioswwds_5_usunom1 ,
                                              AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                              AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                              AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                              AV116Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                              AV117Seguridad_usuarioswwds_10_usutiedsc2 ,
                                              AV118Seguridad_usuarioswwds_11_usunom2 ,
                                              AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                              AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                              AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                              AV122Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                              AV123Seguridad_usuarioswwds_16_usutiedsc3 ,
                                              AV124Seguridad_usuarioswwds_17_usunom3 ,
                                              AV126Seguridad_usuarioswwds_19_tfusucod_sel ,
                                              AV125Seguridad_usuarioswwds_18_tfusucod ,
                                              AV128Seguridad_usuarioswwds_21_tfusunom_sel ,
                                              AV127Seguridad_usuarioswwds_20_tfusunom ,
                                              AV130Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                              AV129Seguridad_usuarioswwds_22_tfusuemail ,
                                              AV131Seguridad_usuarioswwds_24_tfususts_sels.Count ,
                                              AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                              AV132Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                              AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                              AV134Seguridad_usuarioswwds_27_tfusutiedsc ,
                                              A2097UsuVendDsc ,
                                              A2096UsuTieDsc ,
                                              A2019UsuNom ,
                                              A348UsuCod ,
                                              A2014UsuEMAIL } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT
                                              }
         });
         lV110Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV110Seguridad_usuarioswwds_3_usuvenddsc1 = StringUtil.PadR( StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1), 100, "%");
         lV111Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV111Seguridad_usuarioswwds_4_usutiedsc1 = StringUtil.PadR( StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1), 100, "%");
         lV112Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV112Seguridad_usuarioswwds_5_usunom1 = StringUtil.PadR( StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1), 100, "%");
         lV116Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV116Seguridad_usuarioswwds_9_usuvenddsc2 = StringUtil.PadR( StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2), 100, "%");
         lV117Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV117Seguridad_usuarioswwds_10_usutiedsc2 = StringUtil.PadR( StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2), 100, "%");
         lV118Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV118Seguridad_usuarioswwds_11_usunom2 = StringUtil.PadR( StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2), 100, "%");
         lV122Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV122Seguridad_usuarioswwds_15_usuvenddsc3 = StringUtil.PadR( StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3), 100, "%");
         lV123Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV123Seguridad_usuarioswwds_16_usutiedsc3 = StringUtil.PadR( StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3), 100, "%");
         lV124Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV124Seguridad_usuarioswwds_17_usunom3 = StringUtil.PadR( StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3), 100, "%");
         lV125Seguridad_usuarioswwds_18_tfusucod = StringUtil.PadR( StringUtil.RTrim( AV125Seguridad_usuarioswwds_18_tfusucod), 10, "%");
         lV127Seguridad_usuarioswwds_20_tfusunom = StringUtil.PadR( StringUtil.RTrim( AV127Seguridad_usuarioswwds_20_tfusunom), 100, "%");
         lV129Seguridad_usuarioswwds_22_tfusuemail = StringUtil.Concat( StringUtil.RTrim( AV129Seguridad_usuarioswwds_22_tfusuemail), "%", "");
         lV132Seguridad_usuarioswwds_25_tfusuvenddsc = StringUtil.PadR( StringUtil.RTrim( AV132Seguridad_usuarioswwds_25_tfusuvenddsc), 100, "%");
         lV134Seguridad_usuarioswwds_27_tfusutiedsc = StringUtil.PadR( StringUtil.RTrim( AV134Seguridad_usuarioswwds_27_tfusutiedsc), 100, "%");
         /* Using cursor P001M6 */
         pr_default.execute(4, new Object[] {lV110Seguridad_usuarioswwds_3_usuvenddsc1, lV110Seguridad_usuarioswwds_3_usuvenddsc1, lV111Seguridad_usuarioswwds_4_usutiedsc1, lV111Seguridad_usuarioswwds_4_usutiedsc1, lV112Seguridad_usuarioswwds_5_usunom1, lV112Seguridad_usuarioswwds_5_usunom1, lV116Seguridad_usuarioswwds_9_usuvenddsc2, lV116Seguridad_usuarioswwds_9_usuvenddsc2, lV117Seguridad_usuarioswwds_10_usutiedsc2, lV117Seguridad_usuarioswwds_10_usutiedsc2, lV118Seguridad_usuarioswwds_11_usunom2, lV118Seguridad_usuarioswwds_11_usunom2, lV122Seguridad_usuarioswwds_15_usuvenddsc3, lV122Seguridad_usuarioswwds_15_usuvenddsc3, lV123Seguridad_usuarioswwds_16_usutiedsc3, lV123Seguridad_usuarioswwds_16_usutiedsc3, lV124Seguridad_usuarioswwds_17_usunom3, lV124Seguridad_usuarioswwds_17_usunom3, lV125Seguridad_usuarioswwds_18_tfusucod, AV126Seguridad_usuarioswwds_19_tfusucod_sel, lV127Seguridad_usuarioswwds_20_tfusunom, AV128Seguridad_usuarioswwds_21_tfusunom_sel, lV129Seguridad_usuarioswwds_22_tfusuemail, AV130Seguridad_usuarioswwds_23_tfusuemail_sel, lV132Seguridad_usuarioswwds_25_tfusuvenddsc, AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel, lV134Seguridad_usuarioswwds_27_tfusutiedsc, AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK1M9 = false;
            A2041UsuVend = P001M6_A2041UsuVend[0];
            A2040UsuTieCod = P001M6_A2040UsuTieCod[0];
            A2039UsuSts = P001M6_A2039UsuSts[0];
            A2014UsuEMAIL = P001M6_A2014UsuEMAIL[0];
            A348UsuCod = P001M6_A348UsuCod[0];
            A2019UsuNom = P001M6_A2019UsuNom[0];
            A2096UsuTieDsc = P001M6_A2096UsuTieDsc[0];
            A2097UsuVendDsc = P001M6_A2097UsuVendDsc[0];
            A2097UsuVendDsc = P001M6_A2097UsuVendDsc[0];
            A2096UsuTieDsc = P001M6_A2096UsuTieDsc[0];
            AV72count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( P001M6_A2040UsuTieCod[0] == A2040UsuTieCod ) )
            {
               BRK1M9 = false;
               A348UsuCod = P001M6_A348UsuCod[0];
               AV72count = (long)(AV72count+1);
               BRK1M9 = true;
               pr_default.readNext(4);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2096UsuTieDsc)) )
            {
               AV64Option = A2096UsuTieDsc;
               AV63InsertIndex = 1;
               while ( ( AV63InsertIndex <= AV65Options.Count ) && ( StringUtil.StrCmp(((string)AV65Options.Item(AV63InsertIndex)), AV64Option) < 0 ) )
               {
                  AV63InsertIndex = (int)(AV63InsertIndex+1);
               }
               AV65Options.Add(AV64Option, AV63InsertIndex);
               AV70OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV72count), "Z,ZZZ,ZZZ,ZZ9")), AV63InsertIndex);
            }
            if ( AV65Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1M9 )
            {
               BRK1M9 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
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
         AV66OptionsJson = "";
         AV69OptionsDescJson = "";
         AV71OptionIndexesJson = "";
         AV65Options = new GxSimpleCollection<string>();
         AV68OptionsDesc = new GxSimpleCollection<string>();
         AV70OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV73Session = context.GetSession();
         AV75GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV76GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TFUsuCod = "";
         AV11TFUsuCod_Sel = "";
         AV14TFUsuNom = "";
         AV15TFUsuNom_Sel = "";
         AV46TFUsuEMAIL = "";
         AV47TFUsuEMAIL_Sel = "";
         AV89TFUsuSts_SelsJson = "";
         AV90TFUsuSts_Sels = new GxSimpleCollection<short>();
         AV94TFUsuVendDsc = "";
         AV95TFUsuVendDsc_Sel = "";
         AV96TFUsuTieDsc = "";
         AV97TFUsuTieDsc_Sel = "";
         AV77GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV78DynamicFiltersSelector1 = "";
         AV98UsuVendDsc1 = "";
         AV99UsuTieDsc1 = "";
         AV91UsuNom1 = "";
         AV82DynamicFiltersSelector2 = "";
         AV100UsuVendDsc2 = "";
         AV101UsuTieDsc2 = "";
         AV92UsuNom2 = "";
         AV86DynamicFiltersSelector3 = "";
         AV102UsuVendDsc3 = "";
         AV103UsuTieDsc3 = "";
         AV93UsuNom3 = "";
         AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 = "";
         AV110Seguridad_usuarioswwds_3_usuvenddsc1 = "";
         AV111Seguridad_usuarioswwds_4_usutiedsc1 = "";
         AV112Seguridad_usuarioswwds_5_usunom1 = "";
         AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 = "";
         AV116Seguridad_usuarioswwds_9_usuvenddsc2 = "";
         AV117Seguridad_usuarioswwds_10_usutiedsc2 = "";
         AV118Seguridad_usuarioswwds_11_usunom2 = "";
         AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 = "";
         AV122Seguridad_usuarioswwds_15_usuvenddsc3 = "";
         AV123Seguridad_usuarioswwds_16_usutiedsc3 = "";
         AV124Seguridad_usuarioswwds_17_usunom3 = "";
         AV125Seguridad_usuarioswwds_18_tfusucod = "";
         AV126Seguridad_usuarioswwds_19_tfusucod_sel = "";
         AV127Seguridad_usuarioswwds_20_tfusunom = "";
         AV128Seguridad_usuarioswwds_21_tfusunom_sel = "";
         AV129Seguridad_usuarioswwds_22_tfusuemail = "";
         AV130Seguridad_usuarioswwds_23_tfusuemail_sel = "";
         AV131Seguridad_usuarioswwds_24_tfususts_sels = new GxSimpleCollection<short>();
         AV132Seguridad_usuarioswwds_25_tfusuvenddsc = "";
         AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel = "";
         AV134Seguridad_usuarioswwds_27_tfusutiedsc = "";
         AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel = "";
         scmdbuf = "";
         lV110Seguridad_usuarioswwds_3_usuvenddsc1 = "";
         lV111Seguridad_usuarioswwds_4_usutiedsc1 = "";
         lV112Seguridad_usuarioswwds_5_usunom1 = "";
         lV116Seguridad_usuarioswwds_9_usuvenddsc2 = "";
         lV117Seguridad_usuarioswwds_10_usutiedsc2 = "";
         lV118Seguridad_usuarioswwds_11_usunom2 = "";
         lV122Seguridad_usuarioswwds_15_usuvenddsc3 = "";
         lV123Seguridad_usuarioswwds_16_usutiedsc3 = "";
         lV124Seguridad_usuarioswwds_17_usunom3 = "";
         lV125Seguridad_usuarioswwds_18_tfusucod = "";
         lV127Seguridad_usuarioswwds_20_tfusunom = "";
         lV129Seguridad_usuarioswwds_22_tfusuemail = "";
         lV132Seguridad_usuarioswwds_25_tfusuvenddsc = "";
         lV134Seguridad_usuarioswwds_27_tfusutiedsc = "";
         A2097UsuVendDsc = "";
         A2096UsuTieDsc = "";
         A2019UsuNom = "";
         A348UsuCod = "";
         A2014UsuEMAIL = "";
         P001M2_A2041UsuVend = new int[1] ;
         P001M2_A2040UsuTieCod = new int[1] ;
         P001M2_A2039UsuSts = new short[1] ;
         P001M2_A2014UsuEMAIL = new string[] {""} ;
         P001M2_A348UsuCod = new string[] {""} ;
         P001M2_A2019UsuNom = new string[] {""} ;
         P001M2_A2096UsuTieDsc = new string[] {""} ;
         P001M2_A2097UsuVendDsc = new string[] {""} ;
         AV64Option = "";
         P001M3_A2041UsuVend = new int[1] ;
         P001M3_A2040UsuTieCod = new int[1] ;
         P001M3_A2019UsuNom = new string[] {""} ;
         P001M3_A2039UsuSts = new short[1] ;
         P001M3_A2014UsuEMAIL = new string[] {""} ;
         P001M3_A348UsuCod = new string[] {""} ;
         P001M3_A2096UsuTieDsc = new string[] {""} ;
         P001M3_A2097UsuVendDsc = new string[] {""} ;
         P001M4_A2041UsuVend = new int[1] ;
         P001M4_A2040UsuTieCod = new int[1] ;
         P001M4_A2014UsuEMAIL = new string[] {""} ;
         P001M4_A2039UsuSts = new short[1] ;
         P001M4_A348UsuCod = new string[] {""} ;
         P001M4_A2019UsuNom = new string[] {""} ;
         P001M4_A2096UsuTieDsc = new string[] {""} ;
         P001M4_A2097UsuVendDsc = new string[] {""} ;
         P001M5_A2040UsuTieCod = new int[1] ;
         P001M5_A2041UsuVend = new int[1] ;
         P001M5_A2039UsuSts = new short[1] ;
         P001M5_A2014UsuEMAIL = new string[] {""} ;
         P001M5_A348UsuCod = new string[] {""} ;
         P001M5_A2019UsuNom = new string[] {""} ;
         P001M5_A2096UsuTieDsc = new string[] {""} ;
         P001M5_A2097UsuVendDsc = new string[] {""} ;
         P001M6_A2041UsuVend = new int[1] ;
         P001M6_A2040UsuTieCod = new int[1] ;
         P001M6_A2039UsuSts = new short[1] ;
         P001M6_A2014UsuEMAIL = new string[] {""} ;
         P001M6_A348UsuCod = new string[] {""} ;
         P001M6_A2019UsuNom = new string[] {""} ;
         P001M6_A2096UsuTieDsc = new string[] {""} ;
         P001M6_A2097UsuVendDsc = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.usuarioswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P001M2_A2041UsuVend, P001M2_A2040UsuTieCod, P001M2_A2039UsuSts, P001M2_A2014UsuEMAIL, P001M2_A348UsuCod, P001M2_A2019UsuNom, P001M2_A2096UsuTieDsc, P001M2_A2097UsuVendDsc
               }
               , new Object[] {
               P001M3_A2041UsuVend, P001M3_A2040UsuTieCod, P001M3_A2019UsuNom, P001M3_A2039UsuSts, P001M3_A2014UsuEMAIL, P001M3_A348UsuCod, P001M3_A2096UsuTieDsc, P001M3_A2097UsuVendDsc
               }
               , new Object[] {
               P001M4_A2041UsuVend, P001M4_A2040UsuTieCod, P001M4_A2014UsuEMAIL, P001M4_A2039UsuSts, P001M4_A348UsuCod, P001M4_A2019UsuNom, P001M4_A2096UsuTieDsc, P001M4_A2097UsuVendDsc
               }
               , new Object[] {
               P001M5_A2040UsuTieCod, P001M5_A2041UsuVend, P001M5_A2039UsuSts, P001M5_A2014UsuEMAIL, P001M5_A348UsuCod, P001M5_A2019UsuNom, P001M5_A2096UsuTieDsc, P001M5_A2097UsuVendDsc
               }
               , new Object[] {
               P001M6_A2041UsuVend, P001M6_A2040UsuTieCod, P001M6_A2039UsuSts, P001M6_A2014UsuEMAIL, P001M6_A348UsuCod, P001M6_A2019UsuNom, P001M6_A2096UsuTieDsc, P001M6_A2097UsuVendDsc
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV79DynamicFiltersOperator1 ;
      private short AV83DynamicFiltersOperator2 ;
      private short AV87DynamicFiltersOperator3 ;
      private short AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ;
      private short AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ;
      private short AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ;
      private short A2039UsuSts ;
      private int AV106GXV1 ;
      private int AV131Seguridad_usuarioswwds_24_tfususts_sels_Count ;
      private int A2041UsuVend ;
      private int A2040UsuTieCod ;
      private int AV63InsertIndex ;
      private long AV72count ;
      private string AV10TFUsuCod ;
      private string AV11TFUsuCod_Sel ;
      private string AV14TFUsuNom ;
      private string AV15TFUsuNom_Sel ;
      private string AV94TFUsuVendDsc ;
      private string AV95TFUsuVendDsc_Sel ;
      private string AV96TFUsuTieDsc ;
      private string AV97TFUsuTieDsc_Sel ;
      private string AV98UsuVendDsc1 ;
      private string AV99UsuTieDsc1 ;
      private string AV91UsuNom1 ;
      private string AV100UsuVendDsc2 ;
      private string AV101UsuTieDsc2 ;
      private string AV92UsuNom2 ;
      private string AV102UsuVendDsc3 ;
      private string AV103UsuTieDsc3 ;
      private string AV93UsuNom3 ;
      private string AV110Seguridad_usuarioswwds_3_usuvenddsc1 ;
      private string AV111Seguridad_usuarioswwds_4_usutiedsc1 ;
      private string AV112Seguridad_usuarioswwds_5_usunom1 ;
      private string AV116Seguridad_usuarioswwds_9_usuvenddsc2 ;
      private string AV117Seguridad_usuarioswwds_10_usutiedsc2 ;
      private string AV118Seguridad_usuarioswwds_11_usunom2 ;
      private string AV122Seguridad_usuarioswwds_15_usuvenddsc3 ;
      private string AV123Seguridad_usuarioswwds_16_usutiedsc3 ;
      private string AV124Seguridad_usuarioswwds_17_usunom3 ;
      private string AV125Seguridad_usuarioswwds_18_tfusucod ;
      private string AV126Seguridad_usuarioswwds_19_tfusucod_sel ;
      private string AV127Seguridad_usuarioswwds_20_tfusunom ;
      private string AV128Seguridad_usuarioswwds_21_tfusunom_sel ;
      private string AV132Seguridad_usuarioswwds_25_tfusuvenddsc ;
      private string AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel ;
      private string AV134Seguridad_usuarioswwds_27_tfusutiedsc ;
      private string AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel ;
      private string scmdbuf ;
      private string lV110Seguridad_usuarioswwds_3_usuvenddsc1 ;
      private string lV111Seguridad_usuarioswwds_4_usutiedsc1 ;
      private string lV112Seguridad_usuarioswwds_5_usunom1 ;
      private string lV116Seguridad_usuarioswwds_9_usuvenddsc2 ;
      private string lV117Seguridad_usuarioswwds_10_usutiedsc2 ;
      private string lV118Seguridad_usuarioswwds_11_usunom2 ;
      private string lV122Seguridad_usuarioswwds_15_usuvenddsc3 ;
      private string lV123Seguridad_usuarioswwds_16_usutiedsc3 ;
      private string lV124Seguridad_usuarioswwds_17_usunom3 ;
      private string lV125Seguridad_usuarioswwds_18_tfusucod ;
      private string lV127Seguridad_usuarioswwds_20_tfusunom ;
      private string lV132Seguridad_usuarioswwds_25_tfusuvenddsc ;
      private string lV134Seguridad_usuarioswwds_27_tfusutiedsc ;
      private string A2097UsuVendDsc ;
      private string A2096UsuTieDsc ;
      private string A2019UsuNom ;
      private string A348UsuCod ;
      private bool returnInSub ;
      private bool AV81DynamicFiltersEnabled2 ;
      private bool AV85DynamicFiltersEnabled3 ;
      private bool AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ;
      private bool AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ;
      private bool BRK1M3 ;
      private bool BRK1M5 ;
      private bool BRK1M7 ;
      private bool BRK1M9 ;
      private string AV66OptionsJson ;
      private string AV69OptionsDescJson ;
      private string AV71OptionIndexesJson ;
      private string AV89TFUsuSts_SelsJson ;
      private string AV62DDOName ;
      private string AV60SearchTxt ;
      private string AV61SearchTxtTo ;
      private string AV46TFUsuEMAIL ;
      private string AV47TFUsuEMAIL_Sel ;
      private string AV78DynamicFiltersSelector1 ;
      private string AV82DynamicFiltersSelector2 ;
      private string AV86DynamicFiltersSelector3 ;
      private string AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 ;
      private string AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 ;
      private string AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 ;
      private string AV129Seguridad_usuarioswwds_22_tfusuemail ;
      private string AV130Seguridad_usuarioswwds_23_tfusuemail_sel ;
      private string lV129Seguridad_usuarioswwds_22_tfusuemail ;
      private string A2014UsuEMAIL ;
      private string AV64Option ;
      private GxSimpleCollection<short> AV90TFUsuSts_Sels ;
      private GxSimpleCollection<short> AV131Seguridad_usuarioswwds_24_tfususts_sels ;
      private IGxSession AV73Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P001M2_A2041UsuVend ;
      private int[] P001M2_A2040UsuTieCod ;
      private short[] P001M2_A2039UsuSts ;
      private string[] P001M2_A2014UsuEMAIL ;
      private string[] P001M2_A348UsuCod ;
      private string[] P001M2_A2019UsuNom ;
      private string[] P001M2_A2096UsuTieDsc ;
      private string[] P001M2_A2097UsuVendDsc ;
      private int[] P001M3_A2041UsuVend ;
      private int[] P001M3_A2040UsuTieCod ;
      private string[] P001M3_A2019UsuNom ;
      private short[] P001M3_A2039UsuSts ;
      private string[] P001M3_A2014UsuEMAIL ;
      private string[] P001M3_A348UsuCod ;
      private string[] P001M3_A2096UsuTieDsc ;
      private string[] P001M3_A2097UsuVendDsc ;
      private int[] P001M4_A2041UsuVend ;
      private int[] P001M4_A2040UsuTieCod ;
      private string[] P001M4_A2014UsuEMAIL ;
      private short[] P001M4_A2039UsuSts ;
      private string[] P001M4_A348UsuCod ;
      private string[] P001M4_A2019UsuNom ;
      private string[] P001M4_A2096UsuTieDsc ;
      private string[] P001M4_A2097UsuVendDsc ;
      private int[] P001M5_A2040UsuTieCod ;
      private int[] P001M5_A2041UsuVend ;
      private short[] P001M5_A2039UsuSts ;
      private string[] P001M5_A2014UsuEMAIL ;
      private string[] P001M5_A348UsuCod ;
      private string[] P001M5_A2019UsuNom ;
      private string[] P001M5_A2096UsuTieDsc ;
      private string[] P001M5_A2097UsuVendDsc ;
      private int[] P001M6_A2041UsuVend ;
      private int[] P001M6_A2040UsuTieCod ;
      private short[] P001M6_A2039UsuSts ;
      private string[] P001M6_A2014UsuEMAIL ;
      private string[] P001M6_A348UsuCod ;
      private string[] P001M6_A2019UsuNom ;
      private string[] P001M6_A2096UsuTieDsc ;
      private string[] P001M6_A2097UsuVendDsc ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV65Options ;
      private GxSimpleCollection<string> AV68OptionsDesc ;
      private GxSimpleCollection<string> AV70OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV75GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV76GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV77GridStateDynamicFilter ;
   }

   public class usuarioswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001M2( IGxContext context ,
                                             short A2039UsuSts ,
                                             GxSimpleCollection<short> AV131Seguridad_usuarioswwds_24_tfususts_sels ,
                                             string AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                             short AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                             string AV110Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                             string AV111Seguridad_usuarioswwds_4_usutiedsc1 ,
                                             string AV112Seguridad_usuarioswwds_5_usunom1 ,
                                             bool AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                             string AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                             short AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                             string AV116Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                             string AV117Seguridad_usuarioswwds_10_usutiedsc2 ,
                                             string AV118Seguridad_usuarioswwds_11_usunom2 ,
                                             bool AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                             string AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                             short AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                             string AV122Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                             string AV123Seguridad_usuarioswwds_16_usutiedsc3 ,
                                             string AV124Seguridad_usuarioswwds_17_usunom3 ,
                                             string AV126Seguridad_usuarioswwds_19_tfusucod_sel ,
                                             string AV125Seguridad_usuarioswwds_18_tfusucod ,
                                             string AV128Seguridad_usuarioswwds_21_tfusunom_sel ,
                                             string AV127Seguridad_usuarioswwds_20_tfusunom ,
                                             string AV130Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                             string AV129Seguridad_usuarioswwds_22_tfusuemail ,
                                             int AV131Seguridad_usuarioswwds_24_tfususts_sels_Count ,
                                             string AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                             string AV132Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                             string AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                             string AV134Seguridad_usuarioswwds_27_tfusutiedsc ,
                                             string A2097UsuVendDsc ,
                                             string A2096UsuTieDsc ,
                                             string A2019UsuNom ,
                                             string A348UsuCod ,
                                             string A2014UsuEMAIL )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[28];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [UsuVend], NULL AS [UsuTieCod], NULL AS [UsuSts], NULL AS [UsuEMAIL], [UsuCod], NULL AS [UsuNom], NULL AS [UsuTieDsc], NULL AS [UsuVendDsc] FROM ( SELECT TOP(100) PERCENT T1.[UsuVend] AS UsuVend, T1.[UsuTieCod] AS UsuTieCod, T1.[UsuSts], T1.[UsuEMAIL], T1.[UsuCod], T1.[UsuNom], T3.[TieDsc] AS UsuTieDsc, T2.[VenDsc] AS UsuVendDsc FROM (([SGUSUARIOS] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[UsuVend]) INNER JOIN [SGTIENDAS] T3 ON T3.[TieCod] = T1.[UsuTieCod])";
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV110Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV110Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV111Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV111Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV112Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV112Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV116Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV116Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV117Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV117Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV118Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV118Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV122Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV122Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV123Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV123Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV124Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV124Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Seguridad_usuarioswwds_19_tfusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Seguridad_usuarioswwds_18_tfusucod)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] like @lV125Seguridad_usuarioswwds_18_tfusucod)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Seguridad_usuarioswwds_19_tfusucod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] = @AV126Seguridad_usuarioswwds_19_tfusucod_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Seguridad_usuarioswwds_21_tfusunom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Seguridad_usuarioswwds_20_tfusunom)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV127Seguridad_usuarioswwds_20_tfusunom)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Seguridad_usuarioswwds_21_tfusunom_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] = @AV128Seguridad_usuarioswwds_21_tfusunom_sel)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV130Seguridad_usuarioswwds_23_tfusuemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Seguridad_usuarioswwds_22_tfusuemail)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] like @lV129Seguridad_usuarioswwds_22_tfusuemail)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Seguridad_usuarioswwds_23_tfusuemail_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] = @AV130Seguridad_usuarioswwds_23_tfusuemail_sel)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( AV131Seguridad_usuarioswwds_24_tfususts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV131Seguridad_usuarioswwds_24_tfususts_sels, "T1.[UsuSts] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Seguridad_usuarioswwds_25_tfusuvenddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV132Seguridad_usuarioswwds_25_tfusuvenddsc)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] = @AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Seguridad_usuarioswwds_27_tfusutiedsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV134Seguridad_usuarioswwds_27_tfusutiedsc)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] = @AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[UsuCod]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [UsuCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P001M3( IGxContext context ,
                                             short A2039UsuSts ,
                                             GxSimpleCollection<short> AV131Seguridad_usuarioswwds_24_tfususts_sels ,
                                             string AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                             short AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                             string AV110Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                             string AV111Seguridad_usuarioswwds_4_usutiedsc1 ,
                                             string AV112Seguridad_usuarioswwds_5_usunom1 ,
                                             bool AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                             string AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                             short AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                             string AV116Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                             string AV117Seguridad_usuarioswwds_10_usutiedsc2 ,
                                             string AV118Seguridad_usuarioswwds_11_usunom2 ,
                                             bool AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                             string AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                             short AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                             string AV122Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                             string AV123Seguridad_usuarioswwds_16_usutiedsc3 ,
                                             string AV124Seguridad_usuarioswwds_17_usunom3 ,
                                             string AV126Seguridad_usuarioswwds_19_tfusucod_sel ,
                                             string AV125Seguridad_usuarioswwds_18_tfusucod ,
                                             string AV128Seguridad_usuarioswwds_21_tfusunom_sel ,
                                             string AV127Seguridad_usuarioswwds_20_tfusunom ,
                                             string AV130Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                             string AV129Seguridad_usuarioswwds_22_tfusuemail ,
                                             int AV131Seguridad_usuarioswwds_24_tfususts_sels_Count ,
                                             string AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                             string AV132Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                             string AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                             string AV134Seguridad_usuarioswwds_27_tfusutiedsc ,
                                             string A2097UsuVendDsc ,
                                             string A2096UsuTieDsc ,
                                             string A2019UsuNom ,
                                             string A348UsuCod ,
                                             string A2014UsuEMAIL )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[28];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[UsuVend] AS UsuVend, T1.[UsuTieCod] AS UsuTieCod, T1.[UsuNom], T1.[UsuSts], T1.[UsuEMAIL], T1.[UsuCod], T3.[TieDsc] AS UsuTieDsc, T2.[VenDsc] AS UsuVendDsc FROM (([SGUSUARIOS] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[UsuVend]) INNER JOIN [SGTIENDAS] T3 ON T3.[TieCod] = T1.[UsuTieCod])";
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV110Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV110Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV111Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV111Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV112Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV112Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV116Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV116Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV117Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV117Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV118Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV118Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV122Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV122Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV123Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV123Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV124Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV124Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Seguridad_usuarioswwds_19_tfusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Seguridad_usuarioswwds_18_tfusucod)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] like @lV125Seguridad_usuarioswwds_18_tfusucod)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Seguridad_usuarioswwds_19_tfusucod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] = @AV126Seguridad_usuarioswwds_19_tfusucod_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Seguridad_usuarioswwds_21_tfusunom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Seguridad_usuarioswwds_20_tfusunom)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV127Seguridad_usuarioswwds_20_tfusunom)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Seguridad_usuarioswwds_21_tfusunom_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] = @AV128Seguridad_usuarioswwds_21_tfusunom_sel)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV130Seguridad_usuarioswwds_23_tfusuemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Seguridad_usuarioswwds_22_tfusuemail)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] like @lV129Seguridad_usuarioswwds_22_tfusuemail)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Seguridad_usuarioswwds_23_tfusuemail_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] = @AV130Seguridad_usuarioswwds_23_tfusuemail_sel)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( AV131Seguridad_usuarioswwds_24_tfususts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV131Seguridad_usuarioswwds_24_tfususts_sels, "T1.[UsuSts] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Seguridad_usuarioswwds_25_tfusuvenddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV132Seguridad_usuarioswwds_25_tfusuvenddsc)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] = @AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Seguridad_usuarioswwds_27_tfusutiedsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV134Seguridad_usuarioswwds_27_tfusutiedsc)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] = @AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[UsuNom]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P001M4( IGxContext context ,
                                             short A2039UsuSts ,
                                             GxSimpleCollection<short> AV131Seguridad_usuarioswwds_24_tfususts_sels ,
                                             string AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                             short AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                             string AV110Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                             string AV111Seguridad_usuarioswwds_4_usutiedsc1 ,
                                             string AV112Seguridad_usuarioswwds_5_usunom1 ,
                                             bool AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                             string AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                             short AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                             string AV116Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                             string AV117Seguridad_usuarioswwds_10_usutiedsc2 ,
                                             string AV118Seguridad_usuarioswwds_11_usunom2 ,
                                             bool AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                             string AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                             short AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                             string AV122Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                             string AV123Seguridad_usuarioswwds_16_usutiedsc3 ,
                                             string AV124Seguridad_usuarioswwds_17_usunom3 ,
                                             string AV126Seguridad_usuarioswwds_19_tfusucod_sel ,
                                             string AV125Seguridad_usuarioswwds_18_tfusucod ,
                                             string AV128Seguridad_usuarioswwds_21_tfusunom_sel ,
                                             string AV127Seguridad_usuarioswwds_20_tfusunom ,
                                             string AV130Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                             string AV129Seguridad_usuarioswwds_22_tfusuemail ,
                                             int AV131Seguridad_usuarioswwds_24_tfususts_sels_Count ,
                                             string AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                             string AV132Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                             string AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                             string AV134Seguridad_usuarioswwds_27_tfusutiedsc ,
                                             string A2097UsuVendDsc ,
                                             string A2096UsuTieDsc ,
                                             string A2019UsuNom ,
                                             string A348UsuCod ,
                                             string A2014UsuEMAIL )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[28];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[UsuVend] AS UsuVend, T1.[UsuTieCod] AS UsuTieCod, T1.[UsuEMAIL], T1.[UsuSts], T1.[UsuCod], T1.[UsuNom], T3.[TieDsc] AS UsuTieDsc, T2.[VenDsc] AS UsuVendDsc FROM (([SGUSUARIOS] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[UsuVend]) INNER JOIN [SGTIENDAS] T3 ON T3.[TieCod] = T1.[UsuTieCod])";
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV110Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV110Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV111Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV111Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV112Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV112Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV116Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV116Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV117Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV117Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV118Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV118Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV122Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV122Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV123Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV123Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV124Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV124Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Seguridad_usuarioswwds_19_tfusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Seguridad_usuarioswwds_18_tfusucod)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] like @lV125Seguridad_usuarioswwds_18_tfusucod)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Seguridad_usuarioswwds_19_tfusucod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] = @AV126Seguridad_usuarioswwds_19_tfusucod_sel)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Seguridad_usuarioswwds_21_tfusunom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Seguridad_usuarioswwds_20_tfusunom)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV127Seguridad_usuarioswwds_20_tfusunom)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Seguridad_usuarioswwds_21_tfusunom_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] = @AV128Seguridad_usuarioswwds_21_tfusunom_sel)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV130Seguridad_usuarioswwds_23_tfusuemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Seguridad_usuarioswwds_22_tfusuemail)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] like @lV129Seguridad_usuarioswwds_22_tfusuemail)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Seguridad_usuarioswwds_23_tfusuemail_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] = @AV130Seguridad_usuarioswwds_23_tfusuemail_sel)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( AV131Seguridad_usuarioswwds_24_tfususts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV131Seguridad_usuarioswwds_24_tfususts_sels, "T1.[UsuSts] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Seguridad_usuarioswwds_25_tfusuvenddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV132Seguridad_usuarioswwds_25_tfusuvenddsc)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] = @AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Seguridad_usuarioswwds_27_tfusutiedsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV134Seguridad_usuarioswwds_27_tfusutiedsc)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] = @AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[UsuEMAIL]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P001M5( IGxContext context ,
                                             short A2039UsuSts ,
                                             GxSimpleCollection<short> AV131Seguridad_usuarioswwds_24_tfususts_sels ,
                                             string AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                             short AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                             string AV110Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                             string AV111Seguridad_usuarioswwds_4_usutiedsc1 ,
                                             string AV112Seguridad_usuarioswwds_5_usunom1 ,
                                             bool AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                             string AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                             short AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                             string AV116Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                             string AV117Seguridad_usuarioswwds_10_usutiedsc2 ,
                                             string AV118Seguridad_usuarioswwds_11_usunom2 ,
                                             bool AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                             string AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                             short AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                             string AV122Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                             string AV123Seguridad_usuarioswwds_16_usutiedsc3 ,
                                             string AV124Seguridad_usuarioswwds_17_usunom3 ,
                                             string AV126Seguridad_usuarioswwds_19_tfusucod_sel ,
                                             string AV125Seguridad_usuarioswwds_18_tfusucod ,
                                             string AV128Seguridad_usuarioswwds_21_tfusunom_sel ,
                                             string AV127Seguridad_usuarioswwds_20_tfusunom ,
                                             string AV130Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                             string AV129Seguridad_usuarioswwds_22_tfusuemail ,
                                             int AV131Seguridad_usuarioswwds_24_tfususts_sels_Count ,
                                             string AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                             string AV132Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                             string AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                             string AV134Seguridad_usuarioswwds_27_tfusutiedsc ,
                                             string A2097UsuVendDsc ,
                                             string A2096UsuTieDsc ,
                                             string A2019UsuNom ,
                                             string A348UsuCod ,
                                             string A2014UsuEMAIL )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[28];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[UsuTieCod] AS UsuTieCod, T1.[UsuVend] AS UsuVend, T1.[UsuSts], T1.[UsuEMAIL], T1.[UsuCod], T1.[UsuNom], T2.[TieDsc] AS UsuTieDsc, T3.[VenDsc] AS UsuVendDsc FROM (([SGUSUARIOS] T1 INNER JOIN [SGTIENDAS] T2 ON T2.[TieCod] = T1.[UsuTieCod]) INNER JOIN [CVENDEDORES] T3 ON T3.[VenCod] = T1.[UsuVend])";
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[VenDsc] like @lV110Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[VenDsc] like '%' + @lV110Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TieDsc] like @lV111Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[TieDsc] like '%' + @lV111Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV112Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV112Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[VenDsc] like @lV116Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[VenDsc] like '%' + @lV116Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TieDsc] like @lV117Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[TieDsc] like '%' + @lV117Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV118Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV118Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[VenDsc] like @lV122Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[VenDsc] like '%' + @lV122Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TieDsc] like @lV123Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[TieDsc] like '%' + @lV123Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV124Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV124Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Seguridad_usuarioswwds_19_tfusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Seguridad_usuarioswwds_18_tfusucod)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] like @lV125Seguridad_usuarioswwds_18_tfusucod)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Seguridad_usuarioswwds_19_tfusucod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] = @AV126Seguridad_usuarioswwds_19_tfusucod_sel)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Seguridad_usuarioswwds_21_tfusunom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Seguridad_usuarioswwds_20_tfusunom)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV127Seguridad_usuarioswwds_20_tfusunom)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Seguridad_usuarioswwds_21_tfusunom_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] = @AV128Seguridad_usuarioswwds_21_tfusunom_sel)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV130Seguridad_usuarioswwds_23_tfusuemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Seguridad_usuarioswwds_22_tfusuemail)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] like @lV129Seguridad_usuarioswwds_22_tfusuemail)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Seguridad_usuarioswwds_23_tfusuemail_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] = @AV130Seguridad_usuarioswwds_23_tfusuemail_sel)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( AV131Seguridad_usuarioswwds_24_tfususts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV131Seguridad_usuarioswwds_24_tfususts_sels, "T1.[UsuSts] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Seguridad_usuarioswwds_25_tfusuvenddsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[VenDsc] like @lV132Seguridad_usuarioswwds_25_tfusuvenddsc)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[VenDsc] = @AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Seguridad_usuarioswwds_27_tfusutiedsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[TieDsc] like @lV134Seguridad_usuarioswwds_27_tfusutiedsc)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[TieDsc] = @AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[UsuVend]";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_P001M6( IGxContext context ,
                                             short A2039UsuSts ,
                                             GxSimpleCollection<short> AV131Seguridad_usuarioswwds_24_tfususts_sels ,
                                             string AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1 ,
                                             short AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 ,
                                             string AV110Seguridad_usuarioswwds_3_usuvenddsc1 ,
                                             string AV111Seguridad_usuarioswwds_4_usutiedsc1 ,
                                             string AV112Seguridad_usuarioswwds_5_usunom1 ,
                                             bool AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 ,
                                             string AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2 ,
                                             short AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 ,
                                             string AV116Seguridad_usuarioswwds_9_usuvenddsc2 ,
                                             string AV117Seguridad_usuarioswwds_10_usutiedsc2 ,
                                             string AV118Seguridad_usuarioswwds_11_usunom2 ,
                                             bool AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 ,
                                             string AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3 ,
                                             short AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 ,
                                             string AV122Seguridad_usuarioswwds_15_usuvenddsc3 ,
                                             string AV123Seguridad_usuarioswwds_16_usutiedsc3 ,
                                             string AV124Seguridad_usuarioswwds_17_usunom3 ,
                                             string AV126Seguridad_usuarioswwds_19_tfusucod_sel ,
                                             string AV125Seguridad_usuarioswwds_18_tfusucod ,
                                             string AV128Seguridad_usuarioswwds_21_tfusunom_sel ,
                                             string AV127Seguridad_usuarioswwds_20_tfusunom ,
                                             string AV130Seguridad_usuarioswwds_23_tfusuemail_sel ,
                                             string AV129Seguridad_usuarioswwds_22_tfusuemail ,
                                             int AV131Seguridad_usuarioswwds_24_tfususts_sels_Count ,
                                             string AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel ,
                                             string AV132Seguridad_usuarioswwds_25_tfusuvenddsc ,
                                             string AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel ,
                                             string AV134Seguridad_usuarioswwds_27_tfusutiedsc ,
                                             string A2097UsuVendDsc ,
                                             string A2096UsuTieDsc ,
                                             string A2019UsuNom ,
                                             string A348UsuCod ,
                                             string A2014UsuEMAIL )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[28];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT T1.[UsuVend] AS UsuVend, T1.[UsuTieCod] AS UsuTieCod, T1.[UsuSts], T1.[UsuEMAIL], T1.[UsuCod], T1.[UsuNom], T3.[TieDsc] AS UsuTieDsc, T2.[VenDsc] AS UsuVendDsc FROM (([SGUSUARIOS] T1 INNER JOIN [CVENDEDORES] T2 ON T2.[VenCod] = T1.[UsuVend]) INNER JOIN [SGTIENDAS] T3 ON T3.[TieCod] = T1.[UsuTieCod])";
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV110Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int9[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUVENDDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Seguridad_usuarioswwds_3_usuvenddsc1)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV110Seguridad_usuarioswwds_3_usuvenddsc1)");
         }
         else
         {
            GXv_int9[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV111Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int9[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUTIEDSC") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Seguridad_usuarioswwds_4_usutiedsc1)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV111Seguridad_usuarioswwds_4_usutiedsc1)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV112Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV108Seguridad_usuarioswwds_1_dynamicfiltersselector1, "USUNOM") == 0 ) && ( AV109Seguridad_usuarioswwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Seguridad_usuarioswwds_5_usunom1)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV112Seguridad_usuarioswwds_5_usunom1)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV116Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUVENDDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Seguridad_usuarioswwds_9_usuvenddsc2)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV116Seguridad_usuarioswwds_9_usuvenddsc2)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV117Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUTIEDSC") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Seguridad_usuarioswwds_10_usutiedsc2)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV117Seguridad_usuarioswwds_10_usutiedsc2)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV118Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( AV113Seguridad_usuarioswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV114Seguridad_usuarioswwds_7_dynamicfiltersselector2, "USUNOM") == 0 ) && ( AV115Seguridad_usuarioswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118Seguridad_usuarioswwds_11_usunom2)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV118Seguridad_usuarioswwds_11_usunom2)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV122Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUVENDDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV122Seguridad_usuarioswwds_15_usuvenddsc3)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like '%' + @lV122Seguridad_usuarioswwds_15_usuvenddsc3)");
         }
         else
         {
            GXv_int9[13] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV123Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int9[14] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUTIEDSC") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Seguridad_usuarioswwds_16_usutiedsc3)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like '%' + @lV123Seguridad_usuarioswwds_16_usutiedsc3)");
         }
         else
         {
            GXv_int9[15] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV124Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int9[16] = 1;
         }
         if ( AV119Seguridad_usuarioswwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV120Seguridad_usuarioswwds_13_dynamicfiltersselector3, "USUNOM") == 0 ) && ( AV121Seguridad_usuarioswwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Seguridad_usuarioswwds_17_usunom3)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like '%' + @lV124Seguridad_usuarioswwds_17_usunom3)");
         }
         else
         {
            GXv_int9[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV126Seguridad_usuarioswwds_19_tfusucod_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV125Seguridad_usuarioswwds_18_tfusucod)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] like @lV125Seguridad_usuarioswwds_18_tfusucod)");
         }
         else
         {
            GXv_int9[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Seguridad_usuarioswwds_19_tfusucod_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuCod] = @AV126Seguridad_usuarioswwds_19_tfusucod_sel)");
         }
         else
         {
            GXv_int9[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV128Seguridad_usuarioswwds_21_tfusunom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Seguridad_usuarioswwds_20_tfusunom)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] like @lV127Seguridad_usuarioswwds_20_tfusunom)");
         }
         else
         {
            GXv_int9[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Seguridad_usuarioswwds_21_tfusunom_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuNom] = @AV128Seguridad_usuarioswwds_21_tfusunom_sel)");
         }
         else
         {
            GXv_int9[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV130Seguridad_usuarioswwds_23_tfusuemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Seguridad_usuarioswwds_22_tfusuemail)) ) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] like @lV129Seguridad_usuarioswwds_22_tfusuemail)");
         }
         else
         {
            GXv_int9[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Seguridad_usuarioswwds_23_tfusuemail_sel)) )
         {
            AddWhere(sWhereString, "(T1.[UsuEMAIL] = @AV130Seguridad_usuarioswwds_23_tfusuemail_sel)");
         }
         else
         {
            GXv_int9[23] = 1;
         }
         if ( AV131Seguridad_usuarioswwds_24_tfususts_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV131Seguridad_usuarioswwds_24_tfususts_sels, "T1.[UsuSts] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Seguridad_usuarioswwds_25_tfusuvenddsc)) ) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] like @lV132Seguridad_usuarioswwds_25_tfusuvenddsc)");
         }
         else
         {
            GXv_int9[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel)) )
         {
            AddWhere(sWhereString, "(T2.[VenDsc] = @AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel)");
         }
         else
         {
            GXv_int9[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Seguridad_usuarioswwds_27_tfusutiedsc)) ) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] like @lV134Seguridad_usuarioswwds_27_tfusutiedsc)");
         }
         else
         {
            GXv_int9[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel)) )
         {
            AddWhere(sWhereString, "(T3.[TieDsc] = @AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel)");
         }
         else
         {
            GXv_int9[27] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[UsuTieCod]";
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P001M2(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] );
               case 1 :
                     return conditional_P001M3(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] );
               case 2 :
                     return conditional_P001M4(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] );
               case 3 :
                     return conditional_P001M5(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] );
               case 4 :
                     return conditional_P001M6(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] );
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
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP001M2;
          prmP001M2 = new Object[] {
          new ParDef("@lV110Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV110Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV111Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV111Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV112Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV112Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV116Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV116Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV117Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV117Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV118Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV118Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV122Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV122Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV123Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV123Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV124Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV124Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV125Seguridad_usuarioswwds_18_tfusucod",GXType.NChar,10,0) ,
          new ParDef("@AV126Seguridad_usuarioswwds_19_tfusucod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV127Seguridad_usuarioswwds_20_tfusunom",GXType.NChar,100,0) ,
          new ParDef("@AV128Seguridad_usuarioswwds_21_tfusunom_sel",GXType.NChar,100,0) ,
          new ParDef("@lV129Seguridad_usuarioswwds_22_tfusuemail",GXType.NVarChar,100,0) ,
          new ParDef("@AV130Seguridad_usuarioswwds_23_tfusuemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV132Seguridad_usuarioswwds_25_tfusuvenddsc",GXType.NChar,100,0) ,
          new ParDef("@AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV134Seguridad_usuarioswwds_27_tfusutiedsc",GXType.NChar,100,0) ,
          new ParDef("@AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP001M3;
          prmP001M3 = new Object[] {
          new ParDef("@lV110Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV110Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV111Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV111Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV112Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV112Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV116Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV116Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV117Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV117Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV118Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV118Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV122Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV122Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV123Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV123Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV124Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV124Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV125Seguridad_usuarioswwds_18_tfusucod",GXType.NChar,10,0) ,
          new ParDef("@AV126Seguridad_usuarioswwds_19_tfusucod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV127Seguridad_usuarioswwds_20_tfusunom",GXType.NChar,100,0) ,
          new ParDef("@AV128Seguridad_usuarioswwds_21_tfusunom_sel",GXType.NChar,100,0) ,
          new ParDef("@lV129Seguridad_usuarioswwds_22_tfusuemail",GXType.NVarChar,100,0) ,
          new ParDef("@AV130Seguridad_usuarioswwds_23_tfusuemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV132Seguridad_usuarioswwds_25_tfusuvenddsc",GXType.NChar,100,0) ,
          new ParDef("@AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV134Seguridad_usuarioswwds_27_tfusutiedsc",GXType.NChar,100,0) ,
          new ParDef("@AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP001M4;
          prmP001M4 = new Object[] {
          new ParDef("@lV110Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV110Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV111Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV111Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV112Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV112Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV116Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV116Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV117Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV117Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV118Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV118Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV122Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV122Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV123Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV123Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV124Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV124Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV125Seguridad_usuarioswwds_18_tfusucod",GXType.NChar,10,0) ,
          new ParDef("@AV126Seguridad_usuarioswwds_19_tfusucod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV127Seguridad_usuarioswwds_20_tfusunom",GXType.NChar,100,0) ,
          new ParDef("@AV128Seguridad_usuarioswwds_21_tfusunom_sel",GXType.NChar,100,0) ,
          new ParDef("@lV129Seguridad_usuarioswwds_22_tfusuemail",GXType.NVarChar,100,0) ,
          new ParDef("@AV130Seguridad_usuarioswwds_23_tfusuemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV132Seguridad_usuarioswwds_25_tfusuvenddsc",GXType.NChar,100,0) ,
          new ParDef("@AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV134Seguridad_usuarioswwds_27_tfusutiedsc",GXType.NChar,100,0) ,
          new ParDef("@AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP001M5;
          prmP001M5 = new Object[] {
          new ParDef("@lV110Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV110Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV111Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV111Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV112Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV112Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV116Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV116Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV117Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV117Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV118Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV118Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV122Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV122Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV123Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV123Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV124Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV124Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV125Seguridad_usuarioswwds_18_tfusucod",GXType.NChar,10,0) ,
          new ParDef("@AV126Seguridad_usuarioswwds_19_tfusucod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV127Seguridad_usuarioswwds_20_tfusunom",GXType.NChar,100,0) ,
          new ParDef("@AV128Seguridad_usuarioswwds_21_tfusunom_sel",GXType.NChar,100,0) ,
          new ParDef("@lV129Seguridad_usuarioswwds_22_tfusuemail",GXType.NVarChar,100,0) ,
          new ParDef("@AV130Seguridad_usuarioswwds_23_tfusuemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV132Seguridad_usuarioswwds_25_tfusuvenddsc",GXType.NChar,100,0) ,
          new ParDef("@AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV134Seguridad_usuarioswwds_27_tfusutiedsc",GXType.NChar,100,0) ,
          new ParDef("@AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel",GXType.NChar,100,0)
          };
          Object[] prmP001M6;
          prmP001M6 = new Object[] {
          new ParDef("@lV110Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV110Seguridad_usuarioswwds_3_usuvenddsc1",GXType.NChar,100,0) ,
          new ParDef("@lV111Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV111Seguridad_usuarioswwds_4_usutiedsc1",GXType.NChar,100,0) ,
          new ParDef("@lV112Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV112Seguridad_usuarioswwds_5_usunom1",GXType.NChar,100,0) ,
          new ParDef("@lV116Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV116Seguridad_usuarioswwds_9_usuvenddsc2",GXType.NChar,100,0) ,
          new ParDef("@lV117Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV117Seguridad_usuarioswwds_10_usutiedsc2",GXType.NChar,100,0) ,
          new ParDef("@lV118Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV118Seguridad_usuarioswwds_11_usunom2",GXType.NChar,100,0) ,
          new ParDef("@lV122Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV122Seguridad_usuarioswwds_15_usuvenddsc3",GXType.NChar,100,0) ,
          new ParDef("@lV123Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV123Seguridad_usuarioswwds_16_usutiedsc3",GXType.NChar,100,0) ,
          new ParDef("@lV124Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV124Seguridad_usuarioswwds_17_usunom3",GXType.NChar,100,0) ,
          new ParDef("@lV125Seguridad_usuarioswwds_18_tfusucod",GXType.NChar,10,0) ,
          new ParDef("@AV126Seguridad_usuarioswwds_19_tfusucod_sel",GXType.NChar,10,0) ,
          new ParDef("@lV127Seguridad_usuarioswwds_20_tfusunom",GXType.NChar,100,0) ,
          new ParDef("@AV128Seguridad_usuarioswwds_21_tfusunom_sel",GXType.NChar,100,0) ,
          new ParDef("@lV129Seguridad_usuarioswwds_22_tfusuemail",GXType.NVarChar,100,0) ,
          new ParDef("@AV130Seguridad_usuarioswwds_23_tfusuemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV132Seguridad_usuarioswwds_25_tfusuvenddsc",GXType.NChar,100,0) ,
          new ParDef("@AV133Seguridad_usuarioswwds_26_tfusuvenddsc_sel",GXType.NChar,100,0) ,
          new ParDef("@lV134Seguridad_usuarioswwds_27_tfusutiedsc",GXType.NChar,100,0) ,
          new ParDef("@AV135Seguridad_usuarioswwds_28_tfusutiedsc_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001M2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P001M3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001M3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001M4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001M4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001M5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001M5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P001M6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001M6,100, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 10);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                return;
             case 2 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                return;
             case 4 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 10);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((string[]) buf[7])[0] = rslt.getString(8, 100);
                return;
       }
    }

 }

}
