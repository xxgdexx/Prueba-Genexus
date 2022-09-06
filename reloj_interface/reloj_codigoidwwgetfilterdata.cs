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
namespace GeneXus.Programs.reloj_interface {
   public class reloj_codigoidwwgetfilterdata : GXProcedure
   {
      public reloj_codigoidwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public reloj_codigoidwwgetfilterdata( IGxContext context )
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
         this.AV30DDOName = aP0_DDOName;
         this.AV28SearchTxt = aP1_SearchTxt;
         this.AV29SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV39OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         reloj_codigoidwwgetfilterdata objreloj_codigoidwwgetfilterdata;
         objreloj_codigoidwwgetfilterdata = new reloj_codigoidwwgetfilterdata();
         objreloj_codigoidwwgetfilterdata.AV30DDOName = aP0_DDOName;
         objreloj_codigoidwwgetfilterdata.AV28SearchTxt = aP1_SearchTxt;
         objreloj_codigoidwwgetfilterdata.AV29SearchTxtTo = aP2_SearchTxtTo;
         objreloj_codigoidwwgetfilterdata.AV34OptionsJson = "" ;
         objreloj_codigoidwwgetfilterdata.AV37OptionsDescJson = "" ;
         objreloj_codigoidwwgetfilterdata.AV39OptionIndexesJson = "" ;
         objreloj_codigoidwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objreloj_codigoidwwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreloj_codigoidwwgetfilterdata);
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reloj_codigoidwwgetfilterdata)stateInfo).executePrivate();
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
         AV33Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_CODIGOID") == 0 )
         {
            /* Execute user subroutine: 'LOADCODIGOIDOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_RELOJ_NOMBRE") == 0 )
         {
            /* Execute user subroutine: 'LOADRELOJ_NOMBREOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_RHTRABAJADORNOMBRES") == 0 )
         {
            /* Execute user subroutine: 'LOADRHTRABAJADORNOMBRESOPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV30DDOName), "DDO_HORARIODESCRIPCION") == 0 )
         {
            /* Execute user subroutine: 'LOADHORARIODESCRIPCIONOPTIONS' */
            S151 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV34OptionsJson = AV33Options.ToJSonString(false);
         AV37OptionsDescJson = AV36OptionsDesc.ToJSonString(false);
         AV39OptionIndexesJson = AV38OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV41Session.Get("Reloj_Interface.Reloj_CodigoIDWWGridState"), "") == 0 )
         {
            AV43GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Reloj_Interface.Reloj_CodigoIDWWGridState"), null, "", "");
         }
         else
         {
            AV43GridState.FromXml(AV41Session.Get("Reloj_Interface.Reloj_CodigoIDWWGridState"), null, "", "");
         }
         AV65GXV1 = 1;
         while ( AV65GXV1 <= AV43GridState.gxTpr_Filtervalues.Count )
         {
            AV44GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV43GridState.gxTpr_Filtervalues.Item(AV65GXV1));
            if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCODIGOID") == 0 )
            {
               AV10TFCodigoId = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFCODIGOID_SEL") == 0 )
            {
               AV11TFCodigoId_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFRELOJ_NOMBRE") == 0 )
            {
               AV14TFReloj_Nombre = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFRELOJ_NOMBRE_SEL") == 0 )
            {
               AV15TFReloj_Nombre_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFLECTURA_INI") == 0 )
            {
               AV16TFLectura_Ini = context.localUtil.CToT( AV44GridStateFilterValue.gxTpr_Value, 2);
               AV17TFLectura_Ini_To = context.localUtil.CToT( AV44GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFRHTRABAJADORNOMBRES") == 0 )
            {
               AV22TFRHTrabajadorNombres = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFRHTRABAJADORNOMBRES_SEL") == 0 )
            {
               AV23TFRHTrabajadorNombres_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFHORARIODESCRIPCION") == 0 )
            {
               AV26TFHorarioDescripcion = AV44GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "TFHORARIODESCRIPCION_SEL") == 0 )
            {
               AV27TFHorarioDescripcion_Sel = AV44GridStateFilterValue.gxTpr_Value;
            }
            AV65GXV1 = (int)(AV65GXV1+1);
         }
         if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV45GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(1));
            AV46DynamicFiltersSelector1 = AV45GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "RHTRABAJADORNOMBRES") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV45GridStateDynamicFilter.gxTpr_Operator;
               AV48RHTrabajadorNombres1 = AV45GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "RELOJ_NOMBRE") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV45GridStateDynamicFilter.gxTpr_Operator;
               AV49Reloj_Nombre1 = AV45GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "HORARIODESCRIPCION") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV45GridStateDynamicFilter.gxTpr_Operator;
               AV50HorarioDescripcion1 = AV45GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV51DynamicFiltersEnabled2 = true;
               AV45GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(2));
               AV52DynamicFiltersSelector2 = AV45GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "RHTRABAJADORNOMBRES") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV45GridStateDynamicFilter.gxTpr_Operator;
                  AV54RHTrabajadorNombres2 = AV45GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "RELOJ_NOMBRE") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV45GridStateDynamicFilter.gxTpr_Operator;
                  AV55Reloj_Nombre2 = AV45GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "HORARIODESCRIPCION") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV45GridStateDynamicFilter.gxTpr_Operator;
                  AV56HorarioDescripcion2 = AV45GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV43GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV57DynamicFiltersEnabled3 = true;
                  AV45GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV43GridState.gxTpr_Dynamicfilters.Item(3));
                  AV58DynamicFiltersSelector3 = AV45GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV58DynamicFiltersSelector3, "RHTRABAJADORNOMBRES") == 0 )
                  {
                     AV59DynamicFiltersOperator3 = AV45GridStateDynamicFilter.gxTpr_Operator;
                     AV60RHTrabajadorNombres3 = AV45GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector3, "RELOJ_NOMBRE") == 0 )
                  {
                     AV59DynamicFiltersOperator3 = AV45GridStateDynamicFilter.gxTpr_Operator;
                     AV61Reloj_Nombre3 = AV45GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector3, "HORARIODESCRIPCION") == 0 )
                  {
                     AV59DynamicFiltersOperator3 = AV45GridStateDynamicFilter.gxTpr_Operator;
                     AV62HorarioDescripcion3 = AV45GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCODIGOIDOPTIONS' Routine */
         returnInSub = false;
         AV10TFCodigoId = AV28SearchTxt;
         AV11TFCodigoId_Sel = "";
         AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = AV48RHTrabajadorNombres1;
         AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = AV49Reloj_Nombre1;
         AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = AV50HorarioDescripcion1;
         AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 = AV51DynamicFiltersEnabled2;
         AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = AV52DynamicFiltersSelector2;
         AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 = AV53DynamicFiltersOperator2;
         AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = AV54RHTrabajadorNombres2;
         AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = AV55Reloj_Nombre2;
         AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = AV56HorarioDescripcion2;
         AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = AV60RHTrabajadorNombres3;
         AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = AV61Reloj_Nombre3;
         AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = AV62HorarioDescripcion3;
         AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = AV10TFCodigoId;
         AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = AV11TFCodigoId_Sel;
         AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = AV14TFReloj_Nombre;
         AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = AV15TFReloj_Nombre_Sel;
         AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = AV16TFLectura_Ini;
         AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = AV17TFLectura_Ini_To;
         AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = AV22TFRHTrabajadorNombres;
         AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = AV23TFRHTrabajadorNombres_Sel;
         AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = AV26TFHorarioDescripcion;
         AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = AV27TFHorarioDescripcion_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                              AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                              AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                              AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                              AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                              AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                              AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                              AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                              AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                              AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                              AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                              AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                              AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                              AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                              AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                              AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                              AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                              AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                              AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                              AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                              AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                              AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                              AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                              AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                              AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                              AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                              AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                              A2525TrabApePat ,
                                              A2526TrabApeMat ,
                                              A2527TrabNombres ,
                                              A2592Reloj_Nombre ,
                                              A2593HorarioDescripcion ,
                                              A2431CodigoId ,
                                              A2415Lectura_Ini } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE
                                              }
         });
         lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
         lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
         lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
         lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
         lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
         lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
         lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
         lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
         lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
         lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
         lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
         lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
         lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
         lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
         lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
         lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
         lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
         lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
         lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = StringUtil.Concat( StringUtil.RTrim( AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid), "%", "");
         lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = StringUtil.Concat( StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre), "%", "");
         lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = StringUtil.Concat( StringUtil.RTrim( AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres), "%", "");
         lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = StringUtil.Concat( StringUtil.RTrim( AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion), "%", "");
         /* Using cursor P00H22 */
         pr_default.execute(0, new Object[] {lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid, AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel, lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre, AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel, AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini, AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to, lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres, AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel, lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion, AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A2589RHTrabajadorCodigo = P00H22_A2589RHTrabajadorCodigo[0];
            A2498Reloj_ID = P00H22_A2498Reloj_ID[0];
            A2591HorarioID = P00H22_A2591HorarioID[0];
            A2415Lectura_Ini = P00H22_A2415Lectura_Ini[0];
            A2431CodigoId = P00H22_A2431CodigoId[0];
            A2593HorarioDescripcion = P00H22_A2593HorarioDescripcion[0];
            A2592Reloj_Nombre = P00H22_A2592Reloj_Nombre[0];
            A2527TrabNombres = P00H22_A2527TrabNombres[0];
            n2527TrabNombres = P00H22_n2527TrabNombres[0];
            A2526TrabApeMat = P00H22_A2526TrabApeMat[0];
            n2526TrabApeMat = P00H22_n2526TrabApeMat[0];
            A2525TrabApePat = P00H22_A2525TrabApePat[0];
            n2525TrabApePat = P00H22_n2525TrabApePat[0];
            A2527TrabNombres = P00H22_A2527TrabNombres[0];
            n2527TrabNombres = P00H22_n2527TrabNombres[0];
            A2526TrabApeMat = P00H22_A2526TrabApeMat[0];
            n2526TrabApeMat = P00H22_n2526TrabApeMat[0];
            A2525TrabApePat = P00H22_A2525TrabApePat[0];
            n2525TrabApePat = P00H22_n2525TrabApePat[0];
            A2592Reloj_Nombre = P00H22_A2592Reloj_Nombre[0];
            A2593HorarioDescripcion = P00H22_A2593HorarioDescripcion[0];
            A2590RHTrabajadorNombres = StringUtil.Trim( A2525TrabApePat) + " " + StringUtil.Trim( A2526TrabApeMat) + " " + StringUtil.Trim( A2527TrabNombres);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2431CodigoId)) )
            {
               AV32Option = A2431CodigoId;
               AV33Options.Add(AV32Option, 0);
            }
            if ( AV33Options.Count == 50 )
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
         /* 'LOADRELOJ_NOMBREOPTIONS' Routine */
         returnInSub = false;
         AV14TFReloj_Nombre = AV28SearchTxt;
         AV15TFReloj_Nombre_Sel = "";
         AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = AV48RHTrabajadorNombres1;
         AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = AV49Reloj_Nombre1;
         AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = AV50HorarioDescripcion1;
         AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 = AV51DynamicFiltersEnabled2;
         AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = AV52DynamicFiltersSelector2;
         AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 = AV53DynamicFiltersOperator2;
         AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = AV54RHTrabajadorNombres2;
         AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = AV55Reloj_Nombre2;
         AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = AV56HorarioDescripcion2;
         AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = AV60RHTrabajadorNombres3;
         AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = AV61Reloj_Nombre3;
         AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = AV62HorarioDescripcion3;
         AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = AV10TFCodigoId;
         AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = AV11TFCodigoId_Sel;
         AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = AV14TFReloj_Nombre;
         AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = AV15TFReloj_Nombre_Sel;
         AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = AV16TFLectura_Ini;
         AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = AV17TFLectura_Ini_To;
         AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = AV22TFRHTrabajadorNombres;
         AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = AV23TFRHTrabajadorNombres_Sel;
         AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = AV26TFHorarioDescripcion;
         AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = AV27TFHorarioDescripcion_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                              AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                              AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                              AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                              AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                              AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                              AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                              AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                              AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                              AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                              AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                              AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                              AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                              AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                              AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                              AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                              AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                              AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                              AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                              AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                              AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                              AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                              AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                              AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                              AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                              AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                              AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                              A2525TrabApePat ,
                                              A2526TrabApeMat ,
                                              A2527TrabNombres ,
                                              A2592Reloj_Nombre ,
                                              A2593HorarioDescripcion ,
                                              A2431CodigoId ,
                                              A2415Lectura_Ini } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE
                                              }
         });
         lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
         lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
         lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
         lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
         lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
         lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
         lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
         lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
         lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
         lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
         lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
         lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
         lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
         lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
         lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
         lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
         lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
         lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
         lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = StringUtil.Concat( StringUtil.RTrim( AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid), "%", "");
         lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = StringUtil.Concat( StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre), "%", "");
         lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = StringUtil.Concat( StringUtil.RTrim( AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres), "%", "");
         lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = StringUtil.Concat( StringUtil.RTrim( AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion), "%", "");
         /* Using cursor P00H23 */
         pr_default.execute(1, new Object[] {lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid, AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel, lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre, AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel, AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini, AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to, lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres, AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel, lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion, AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKH23 = false;
            A2589RHTrabajadorCodigo = P00H23_A2589RHTrabajadorCodigo[0];
            A2591HorarioID = P00H23_A2591HorarioID[0];
            A2498Reloj_ID = P00H23_A2498Reloj_ID[0];
            A2415Lectura_Ini = P00H23_A2415Lectura_Ini[0];
            A2431CodigoId = P00H23_A2431CodigoId[0];
            A2593HorarioDescripcion = P00H23_A2593HorarioDescripcion[0];
            A2592Reloj_Nombre = P00H23_A2592Reloj_Nombre[0];
            A2527TrabNombres = P00H23_A2527TrabNombres[0];
            n2527TrabNombres = P00H23_n2527TrabNombres[0];
            A2526TrabApeMat = P00H23_A2526TrabApeMat[0];
            n2526TrabApeMat = P00H23_n2526TrabApeMat[0];
            A2525TrabApePat = P00H23_A2525TrabApePat[0];
            n2525TrabApePat = P00H23_n2525TrabApePat[0];
            A2527TrabNombres = P00H23_A2527TrabNombres[0];
            n2527TrabNombres = P00H23_n2527TrabNombres[0];
            A2526TrabApeMat = P00H23_A2526TrabApeMat[0];
            n2526TrabApeMat = P00H23_n2526TrabApeMat[0];
            A2525TrabApePat = P00H23_A2525TrabApePat[0];
            n2525TrabApePat = P00H23_n2525TrabApePat[0];
            A2593HorarioDescripcion = P00H23_A2593HorarioDescripcion[0];
            A2592Reloj_Nombre = P00H23_A2592Reloj_Nombre[0];
            A2590RHTrabajadorNombres = StringUtil.Trim( A2525TrabApePat) + " " + StringUtil.Trim( A2526TrabApeMat) + " " + StringUtil.Trim( A2527TrabNombres);
            AV40count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( P00H23_A2498Reloj_ID[0] == A2498Reloj_ID ) )
            {
               BRKH23 = false;
               A2431CodigoId = P00H23_A2431CodigoId[0];
               AV40count = (long)(AV40count+1);
               BRKH23 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2592Reloj_Nombre)) )
            {
               AV32Option = A2592Reloj_Nombre;
               AV31InsertIndex = 1;
               while ( ( AV31InsertIndex <= AV33Options.Count ) && ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), AV32Option) < 0 ) )
               {
                  AV31InsertIndex = (int)(AV31InsertIndex+1);
               }
               AV33Options.Add(AV32Option, AV31InsertIndex);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), AV31InsertIndex);
            }
            if ( AV33Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKH23 )
            {
               BRKH23 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADRHTRABAJADORNOMBRESOPTIONS' Routine */
         returnInSub = false;
         AV22TFRHTrabajadorNombres = AV28SearchTxt;
         AV23TFRHTrabajadorNombres_Sel = "";
         AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = AV48RHTrabajadorNombres1;
         AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = AV49Reloj_Nombre1;
         AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = AV50HorarioDescripcion1;
         AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 = AV51DynamicFiltersEnabled2;
         AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = AV52DynamicFiltersSelector2;
         AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 = AV53DynamicFiltersOperator2;
         AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = AV54RHTrabajadorNombres2;
         AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = AV55Reloj_Nombre2;
         AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = AV56HorarioDescripcion2;
         AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = AV60RHTrabajadorNombres3;
         AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = AV61Reloj_Nombre3;
         AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = AV62HorarioDescripcion3;
         AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = AV10TFCodigoId;
         AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = AV11TFCodigoId_Sel;
         AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = AV14TFReloj_Nombre;
         AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = AV15TFReloj_Nombre_Sel;
         AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = AV16TFLectura_Ini;
         AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = AV17TFLectura_Ini_To;
         AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = AV22TFRHTrabajadorNombres;
         AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = AV23TFRHTrabajadorNombres_Sel;
         AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = AV26TFHorarioDescripcion;
         AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = AV27TFHorarioDescripcion_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                              AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                              AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                              AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                              AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                              AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                              AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                              AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                              AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                              AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                              AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                              AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                              AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                              AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                              AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                              AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                              AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                              AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                              AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                              AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                              AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                              AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                              AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                              AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                              AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                              AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                              AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                              A2525TrabApePat ,
                                              A2526TrabApeMat ,
                                              A2527TrabNombres ,
                                              A2592Reloj_Nombre ,
                                              A2593HorarioDescripcion ,
                                              A2431CodigoId ,
                                              A2415Lectura_Ini } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE
                                              }
         });
         lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
         lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
         lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
         lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
         lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
         lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
         lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
         lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
         lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
         lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
         lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
         lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
         lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
         lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
         lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
         lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
         lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
         lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
         lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = StringUtil.Concat( StringUtil.RTrim( AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid), "%", "");
         lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = StringUtil.Concat( StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre), "%", "");
         lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = StringUtil.Concat( StringUtil.RTrim( AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres), "%", "");
         lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = StringUtil.Concat( StringUtil.RTrim( AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion), "%", "");
         /* Using cursor P00H24 */
         pr_default.execute(2, new Object[] {lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid, AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel, lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre, AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel, AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini, AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to, lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres, AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel, lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion, AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKH25 = false;
            A2589RHTrabajadorCodigo = P00H24_A2589RHTrabajadorCodigo[0];
            A2498Reloj_ID = P00H24_A2498Reloj_ID[0];
            A2591HorarioID = P00H24_A2591HorarioID[0];
            A2590RHTrabajadorNombres = P00H24_A2590RHTrabajadorNombres[0];
            A2415Lectura_Ini = P00H24_A2415Lectura_Ini[0];
            A2431CodigoId = P00H24_A2431CodigoId[0];
            A2593HorarioDescripcion = P00H24_A2593HorarioDescripcion[0];
            A2592Reloj_Nombre = P00H24_A2592Reloj_Nombre[0];
            A2525TrabApePat = P00H24_A2525TrabApePat[0];
            n2525TrabApePat = P00H24_n2525TrabApePat[0];
            A2526TrabApeMat = P00H24_A2526TrabApeMat[0];
            n2526TrabApeMat = P00H24_n2526TrabApeMat[0];
            A2527TrabNombres = P00H24_A2527TrabNombres[0];
            n2527TrabNombres = P00H24_n2527TrabNombres[0];
            A2525TrabApePat = P00H24_A2525TrabApePat[0];
            n2525TrabApePat = P00H24_n2525TrabApePat[0];
            A2526TrabApeMat = P00H24_A2526TrabApeMat[0];
            n2526TrabApeMat = P00H24_n2526TrabApeMat[0];
            A2527TrabNombres = P00H24_A2527TrabNombres[0];
            n2527TrabNombres = P00H24_n2527TrabNombres[0];
            A2592Reloj_Nombre = P00H24_A2592Reloj_Nombre[0];
            A2593HorarioDescripcion = P00H24_A2593HorarioDescripcion[0];
            AV40count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00H24_A2590RHTrabajadorNombres[0], A2590RHTrabajadorNombres) == 0 ) )
            {
               BRKH25 = false;
               A2589RHTrabajadorCodigo = P00H24_A2589RHTrabajadorCodigo[0];
               A2431CodigoId = P00H24_A2431CodigoId[0];
               A2525TrabApePat = P00H24_A2525TrabApePat[0];
               n2525TrabApePat = P00H24_n2525TrabApePat[0];
               A2526TrabApeMat = P00H24_A2526TrabApeMat[0];
               n2526TrabApeMat = P00H24_n2526TrabApeMat[0];
               A2527TrabNombres = P00H24_A2527TrabNombres[0];
               n2527TrabNombres = P00H24_n2527TrabNombres[0];
               A2525TrabApePat = P00H24_A2525TrabApePat[0];
               n2525TrabApePat = P00H24_n2525TrabApePat[0];
               A2526TrabApeMat = P00H24_A2526TrabApeMat[0];
               n2526TrabApeMat = P00H24_n2526TrabApeMat[0];
               A2527TrabNombres = P00H24_A2527TrabNombres[0];
               n2527TrabNombres = P00H24_n2527TrabNombres[0];
               AV40count = (long)(AV40count+1);
               BRKH25 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2590RHTrabajadorNombres)) )
            {
               AV32Option = A2590RHTrabajadorNombres;
               AV33Options.Add(AV32Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV33Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKH25 )
            {
               BRKH25 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADHORARIODESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV26TFHorarioDescripcion = AV28SearchTxt;
         AV27TFHorarioDescripcion_Sel = "";
         AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = AV48RHTrabajadorNombres1;
         AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = AV49Reloj_Nombre1;
         AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = AV50HorarioDescripcion1;
         AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 = AV51DynamicFiltersEnabled2;
         AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = AV52DynamicFiltersSelector2;
         AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 = AV53DynamicFiltersOperator2;
         AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = AV54RHTrabajadorNombres2;
         AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = AV55Reloj_Nombre2;
         AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = AV56HorarioDescripcion2;
         AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = AV60RHTrabajadorNombres3;
         AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = AV61Reloj_Nombre3;
         AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = AV62HorarioDescripcion3;
         AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = AV10TFCodigoId;
         AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = AV11TFCodigoId_Sel;
         AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = AV14TFReloj_Nombre;
         AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = AV15TFReloj_Nombre_Sel;
         AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = AV16TFLectura_Ini;
         AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = AV17TFLectura_Ini_To;
         AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = AV22TFRHTrabajadorNombres;
         AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = AV23TFRHTrabajadorNombres_Sel;
         AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = AV26TFHorarioDescripcion;
         AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = AV27TFHorarioDescripcion_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                              AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                              AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                              AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                              AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                              AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                              AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                              AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                              AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                              AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                              AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                              AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                              AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                              AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                              AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                              AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                              AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                              AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                              AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                              AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                              AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                              AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                              AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                              AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                              AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                              AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                              AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                              A2525TrabApePat ,
                                              A2526TrabApeMat ,
                                              A2527TrabNombres ,
                                              A2592Reloj_Nombre ,
                                              A2593HorarioDescripcion ,
                                              A2431CodigoId ,
                                              A2415Lectura_Ini } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.DATE
                                              }
         });
         lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
         lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = StringUtil.Concat( StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1), "%", "");
         lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
         lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = StringUtil.Concat( StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1), "%", "");
         lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
         lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = StringUtil.Concat( StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1), "%", "");
         lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
         lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = StringUtil.Concat( StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2), "%", "");
         lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
         lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = StringUtil.Concat( StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2), "%", "");
         lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
         lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = StringUtil.Concat( StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2), "%", "");
         lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
         lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = StringUtil.Concat( StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3), "%", "");
         lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
         lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = StringUtil.Concat( StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3), "%", "");
         lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
         lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = StringUtil.Concat( StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3), "%", "");
         lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = StringUtil.Concat( StringUtil.RTrim( AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid), "%", "");
         lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = StringUtil.Concat( StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre), "%", "");
         lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = StringUtil.Concat( StringUtil.RTrim( AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres), "%", "");
         lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = StringUtil.Concat( StringUtil.RTrim( AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion), "%", "");
         /* Using cursor P00H25 */
         pr_default.execute(3, new Object[] {lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1, lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1, lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1, lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2, lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2, lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2, lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3, lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3, lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3, lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid, AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel, lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre, AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel, AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini, AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to, lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres, AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel, lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion, AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKH27 = false;
            A2589RHTrabajadorCodigo = P00H25_A2589RHTrabajadorCodigo[0];
            A2498Reloj_ID = P00H25_A2498Reloj_ID[0];
            A2591HorarioID = P00H25_A2591HorarioID[0];
            A2415Lectura_Ini = P00H25_A2415Lectura_Ini[0];
            A2431CodigoId = P00H25_A2431CodigoId[0];
            A2593HorarioDescripcion = P00H25_A2593HorarioDescripcion[0];
            A2592Reloj_Nombre = P00H25_A2592Reloj_Nombre[0];
            A2527TrabNombres = P00H25_A2527TrabNombres[0];
            n2527TrabNombres = P00H25_n2527TrabNombres[0];
            A2526TrabApeMat = P00H25_A2526TrabApeMat[0];
            n2526TrabApeMat = P00H25_n2526TrabApeMat[0];
            A2525TrabApePat = P00H25_A2525TrabApePat[0];
            n2525TrabApePat = P00H25_n2525TrabApePat[0];
            A2527TrabNombres = P00H25_A2527TrabNombres[0];
            n2527TrabNombres = P00H25_n2527TrabNombres[0];
            A2526TrabApeMat = P00H25_A2526TrabApeMat[0];
            n2526TrabApeMat = P00H25_n2526TrabApeMat[0];
            A2525TrabApePat = P00H25_A2525TrabApePat[0];
            n2525TrabApePat = P00H25_n2525TrabApePat[0];
            A2592Reloj_Nombre = P00H25_A2592Reloj_Nombre[0];
            A2593HorarioDescripcion = P00H25_A2593HorarioDescripcion[0];
            A2590RHTrabajadorNombres = StringUtil.Trim( A2525TrabApePat) + " " + StringUtil.Trim( A2526TrabApeMat) + " " + StringUtil.Trim( A2527TrabNombres);
            AV40count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( P00H25_A2591HorarioID[0] == A2591HorarioID ) )
            {
               BRKH27 = false;
               A2431CodigoId = P00H25_A2431CodigoId[0];
               AV40count = (long)(AV40count+1);
               BRKH27 = true;
               pr_default.readNext(3);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2593HorarioDescripcion)) )
            {
               AV32Option = A2593HorarioDescripcion;
               AV31InsertIndex = 1;
               while ( ( AV31InsertIndex <= AV33Options.Count ) && ( StringUtil.StrCmp(((string)AV33Options.Item(AV31InsertIndex)), AV32Option) < 0 ) )
               {
                  AV31InsertIndex = (int)(AV31InsertIndex+1);
               }
               AV33Options.Add(AV32Option, AV31InsertIndex);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV40count), "Z,ZZZ,ZZZ,ZZ9")), AV31InsertIndex);
            }
            if ( AV33Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKH27 )
            {
               BRKH27 = true;
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
         AV34OptionsJson = "";
         AV37OptionsDescJson = "";
         AV39OptionIndexesJson = "";
         AV33Options = new GxSimpleCollection<string>();
         AV36OptionsDesc = new GxSimpleCollection<string>();
         AV38OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV41Session = context.GetSession();
         AV43GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV44GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV10TFCodigoId = "";
         AV11TFCodigoId_Sel = "";
         AV14TFReloj_Nombre = "";
         AV15TFReloj_Nombre_Sel = "";
         AV16TFLectura_Ini = (DateTime)(DateTime.MinValue);
         AV17TFLectura_Ini_To = (DateTime)(DateTime.MinValue);
         AV22TFRHTrabajadorNombres = "";
         AV23TFRHTrabajadorNombres_Sel = "";
         AV26TFHorarioDescripcion = "";
         AV27TFHorarioDescripcion_Sel = "";
         AV45GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV46DynamicFiltersSelector1 = "";
         AV48RHTrabajadorNombres1 = "";
         AV49Reloj_Nombre1 = "";
         AV50HorarioDescripcion1 = "";
         AV52DynamicFiltersSelector2 = "";
         AV54RHTrabajadorNombres2 = "";
         AV55Reloj_Nombre2 = "";
         AV56HorarioDescripcion2 = "";
         AV58DynamicFiltersSelector3 = "";
         AV60RHTrabajadorNombres3 = "";
         AV61Reloj_Nombre3 = "";
         AV62HorarioDescripcion3 = "";
         AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 = "";
         AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = "";
         AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = "";
         AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = "";
         AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 = "";
         AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = "";
         AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = "";
         AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = "";
         AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 = "";
         AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = "";
         AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = "";
         AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = "";
         AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = "";
         AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel = "";
         AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = "";
         AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel = "";
         AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini = (DateTime)(DateTime.MinValue);
         AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to = (DateTime)(DateTime.MinValue);
         AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = "";
         AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel = "";
         AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = "";
         AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel = "";
         scmdbuf = "";
         lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 = "";
         lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 = "";
         lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 = "";
         lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 = "";
         lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 = "";
         lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 = "";
         lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 = "";
         lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 = "";
         lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 = "";
         lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid = "";
         lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre = "";
         lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres = "";
         lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion = "";
         A2525TrabApePat = "";
         A2526TrabApeMat = "";
         A2527TrabNombres = "";
         A2592Reloj_Nombre = "";
         A2593HorarioDescripcion = "";
         A2431CodigoId = "";
         A2415Lectura_Ini = (DateTime)(DateTime.MinValue);
         P00H22_A2589RHTrabajadorCodigo = new string[] {""} ;
         P00H22_A2498Reloj_ID = new short[1] ;
         P00H22_A2591HorarioID = new short[1] ;
         P00H22_A2415Lectura_Ini = new DateTime[] {DateTime.MinValue} ;
         P00H22_A2431CodigoId = new string[] {""} ;
         P00H22_A2593HorarioDescripcion = new string[] {""} ;
         P00H22_A2592Reloj_Nombre = new string[] {""} ;
         P00H22_A2527TrabNombres = new string[] {""} ;
         P00H22_n2527TrabNombres = new bool[] {false} ;
         P00H22_A2526TrabApeMat = new string[] {""} ;
         P00H22_n2526TrabApeMat = new bool[] {false} ;
         P00H22_A2525TrabApePat = new string[] {""} ;
         P00H22_n2525TrabApePat = new bool[] {false} ;
         A2589RHTrabajadorCodigo = "";
         A2590RHTrabajadorNombres = "";
         AV32Option = "";
         P00H23_A2589RHTrabajadorCodigo = new string[] {""} ;
         P00H23_A2591HorarioID = new short[1] ;
         P00H23_A2498Reloj_ID = new short[1] ;
         P00H23_A2415Lectura_Ini = new DateTime[] {DateTime.MinValue} ;
         P00H23_A2431CodigoId = new string[] {""} ;
         P00H23_A2593HorarioDescripcion = new string[] {""} ;
         P00H23_A2592Reloj_Nombre = new string[] {""} ;
         P00H23_A2527TrabNombres = new string[] {""} ;
         P00H23_n2527TrabNombres = new bool[] {false} ;
         P00H23_A2526TrabApeMat = new string[] {""} ;
         P00H23_n2526TrabApeMat = new bool[] {false} ;
         P00H23_A2525TrabApePat = new string[] {""} ;
         P00H23_n2525TrabApePat = new bool[] {false} ;
         P00H24_A2589RHTrabajadorCodigo = new string[] {""} ;
         P00H24_A2498Reloj_ID = new short[1] ;
         P00H24_A2591HorarioID = new short[1] ;
         P00H24_A2590RHTrabajadorNombres = new string[] {""} ;
         P00H24_A2415Lectura_Ini = new DateTime[] {DateTime.MinValue} ;
         P00H24_A2431CodigoId = new string[] {""} ;
         P00H24_A2593HorarioDescripcion = new string[] {""} ;
         P00H24_A2592Reloj_Nombre = new string[] {""} ;
         P00H24_A2525TrabApePat = new string[] {""} ;
         P00H24_n2525TrabApePat = new bool[] {false} ;
         P00H24_A2526TrabApeMat = new string[] {""} ;
         P00H24_n2526TrabApeMat = new bool[] {false} ;
         P00H24_A2527TrabNombres = new string[] {""} ;
         P00H24_n2527TrabNombres = new bool[] {false} ;
         P00H25_A2589RHTrabajadorCodigo = new string[] {""} ;
         P00H25_A2498Reloj_ID = new short[1] ;
         P00H25_A2591HorarioID = new short[1] ;
         P00H25_A2415Lectura_Ini = new DateTime[] {DateTime.MinValue} ;
         P00H25_A2431CodigoId = new string[] {""} ;
         P00H25_A2593HorarioDescripcion = new string[] {""} ;
         P00H25_A2592Reloj_Nombre = new string[] {""} ;
         P00H25_A2527TrabNombres = new string[] {""} ;
         P00H25_n2527TrabNombres = new bool[] {false} ;
         P00H25_A2526TrabApeMat = new string[] {""} ;
         P00H25_n2526TrabApeMat = new bool[] {false} ;
         P00H25_A2525TrabApePat = new string[] {""} ;
         P00H25_n2525TrabApePat = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_codigoidwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00H22_A2589RHTrabajadorCodigo, P00H22_A2498Reloj_ID, P00H22_A2591HorarioID, P00H22_A2415Lectura_Ini, P00H22_A2431CodigoId, P00H22_A2593HorarioDescripcion, P00H22_A2592Reloj_Nombre, P00H22_A2527TrabNombres, P00H22_n2527TrabNombres, P00H22_A2526TrabApeMat,
               P00H22_n2526TrabApeMat, P00H22_A2525TrabApePat, P00H22_n2525TrabApePat
               }
               , new Object[] {
               P00H23_A2589RHTrabajadorCodigo, P00H23_A2591HorarioID, P00H23_A2498Reloj_ID, P00H23_A2415Lectura_Ini, P00H23_A2431CodigoId, P00H23_A2593HorarioDescripcion, P00H23_A2592Reloj_Nombre, P00H23_A2527TrabNombres, P00H23_n2527TrabNombres, P00H23_A2526TrabApeMat,
               P00H23_n2526TrabApeMat, P00H23_A2525TrabApePat, P00H23_n2525TrabApePat
               }
               , new Object[] {
               P00H24_A2589RHTrabajadorCodigo, P00H24_A2498Reloj_ID, P00H24_A2591HorarioID, P00H24_A2590RHTrabajadorNombres, P00H24_A2415Lectura_Ini, P00H24_A2431CodigoId, P00H24_A2593HorarioDescripcion, P00H24_A2592Reloj_Nombre, P00H24_A2525TrabApePat, P00H24_n2525TrabApePat,
               P00H24_A2526TrabApeMat, P00H24_n2526TrabApeMat, P00H24_A2527TrabNombres, P00H24_n2527TrabNombres
               }
               , new Object[] {
               P00H25_A2589RHTrabajadorCodigo, P00H25_A2498Reloj_ID, P00H25_A2591HorarioID, P00H25_A2415Lectura_Ini, P00H25_A2431CodigoId, P00H25_A2593HorarioDescripcion, P00H25_A2592Reloj_Nombre, P00H25_A2527TrabNombres, P00H25_n2527TrabNombres, P00H25_A2526TrabApeMat,
               P00H25_n2526TrabApeMat, P00H25_A2525TrabApePat, P00H25_n2525TrabApePat
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV47DynamicFiltersOperator1 ;
      private short AV53DynamicFiltersOperator2 ;
      private short AV59DynamicFiltersOperator3 ;
      private short AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ;
      private short AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ;
      private short AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ;
      private short A2498Reloj_ID ;
      private short A2591HorarioID ;
      private int AV65GXV1 ;
      private int AV31InsertIndex ;
      private long AV40count ;
      private string scmdbuf ;
      private DateTime AV16TFLectura_Ini ;
      private DateTime AV17TFLectura_Ini_To ;
      private DateTime AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ;
      private DateTime AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ;
      private DateTime A2415Lectura_Ini ;
      private bool returnInSub ;
      private bool AV51DynamicFiltersEnabled2 ;
      private bool AV57DynamicFiltersEnabled3 ;
      private bool AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ;
      private bool AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ;
      private bool n2527TrabNombres ;
      private bool n2526TrabApeMat ;
      private bool n2525TrabApePat ;
      private bool BRKH23 ;
      private bool BRKH25 ;
      private bool BRKH27 ;
      private string AV34OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV39OptionIndexesJson ;
      private string AV30DDOName ;
      private string AV28SearchTxt ;
      private string AV29SearchTxtTo ;
      private string AV10TFCodigoId ;
      private string AV11TFCodigoId_Sel ;
      private string AV14TFReloj_Nombre ;
      private string AV15TFReloj_Nombre_Sel ;
      private string AV22TFRHTrabajadorNombres ;
      private string AV23TFRHTrabajadorNombres_Sel ;
      private string AV26TFHorarioDescripcion ;
      private string AV27TFHorarioDescripcion_Sel ;
      private string AV46DynamicFiltersSelector1 ;
      private string AV48RHTrabajadorNombres1 ;
      private string AV49Reloj_Nombre1 ;
      private string AV50HorarioDescripcion1 ;
      private string AV52DynamicFiltersSelector2 ;
      private string AV54RHTrabajadorNombres2 ;
      private string AV55Reloj_Nombre2 ;
      private string AV56HorarioDescripcion2 ;
      private string AV58DynamicFiltersSelector3 ;
      private string AV60RHTrabajadorNombres3 ;
      private string AV61Reloj_Nombre3 ;
      private string AV62HorarioDescripcion3 ;
      private string AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ;
      private string AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ;
      private string AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ;
      private string AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ;
      private string AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ;
      private string AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ;
      private string AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ;
      private string AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ;
      private string AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ;
      private string AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ;
      private string AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ;
      private string AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ;
      private string AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ;
      private string AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ;
      private string AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ;
      private string AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ;
      private string AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ;
      private string AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ;
      private string AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ;
      private string AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ;
      private string lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ;
      private string lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ;
      private string lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ;
      private string lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ;
      private string lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ;
      private string lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ;
      private string lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ;
      private string lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ;
      private string lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ;
      private string lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ;
      private string lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ;
      private string lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ;
      private string lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ;
      private string A2525TrabApePat ;
      private string A2526TrabApeMat ;
      private string A2527TrabNombres ;
      private string A2592Reloj_Nombre ;
      private string A2593HorarioDescripcion ;
      private string A2431CodigoId ;
      private string A2589RHTrabajadorCodigo ;
      private string A2590RHTrabajadorNombres ;
      private string AV32Option ;
      private IGxSession AV41Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00H22_A2589RHTrabajadorCodigo ;
      private short[] P00H22_A2498Reloj_ID ;
      private short[] P00H22_A2591HorarioID ;
      private DateTime[] P00H22_A2415Lectura_Ini ;
      private string[] P00H22_A2431CodigoId ;
      private string[] P00H22_A2593HorarioDescripcion ;
      private string[] P00H22_A2592Reloj_Nombre ;
      private string[] P00H22_A2527TrabNombres ;
      private bool[] P00H22_n2527TrabNombres ;
      private string[] P00H22_A2526TrabApeMat ;
      private bool[] P00H22_n2526TrabApeMat ;
      private string[] P00H22_A2525TrabApePat ;
      private bool[] P00H22_n2525TrabApePat ;
      private string[] P00H23_A2589RHTrabajadorCodigo ;
      private short[] P00H23_A2591HorarioID ;
      private short[] P00H23_A2498Reloj_ID ;
      private DateTime[] P00H23_A2415Lectura_Ini ;
      private string[] P00H23_A2431CodigoId ;
      private string[] P00H23_A2593HorarioDescripcion ;
      private string[] P00H23_A2592Reloj_Nombre ;
      private string[] P00H23_A2527TrabNombres ;
      private bool[] P00H23_n2527TrabNombres ;
      private string[] P00H23_A2526TrabApeMat ;
      private bool[] P00H23_n2526TrabApeMat ;
      private string[] P00H23_A2525TrabApePat ;
      private bool[] P00H23_n2525TrabApePat ;
      private string[] P00H24_A2589RHTrabajadorCodigo ;
      private short[] P00H24_A2498Reloj_ID ;
      private short[] P00H24_A2591HorarioID ;
      private string[] P00H24_A2590RHTrabajadorNombres ;
      private DateTime[] P00H24_A2415Lectura_Ini ;
      private string[] P00H24_A2431CodigoId ;
      private string[] P00H24_A2593HorarioDescripcion ;
      private string[] P00H24_A2592Reloj_Nombre ;
      private string[] P00H24_A2525TrabApePat ;
      private bool[] P00H24_n2525TrabApePat ;
      private string[] P00H24_A2526TrabApeMat ;
      private bool[] P00H24_n2526TrabApeMat ;
      private string[] P00H24_A2527TrabNombres ;
      private bool[] P00H24_n2527TrabNombres ;
      private string[] P00H25_A2589RHTrabajadorCodigo ;
      private short[] P00H25_A2498Reloj_ID ;
      private short[] P00H25_A2591HorarioID ;
      private DateTime[] P00H25_A2415Lectura_Ini ;
      private string[] P00H25_A2431CodigoId ;
      private string[] P00H25_A2593HorarioDescripcion ;
      private string[] P00H25_A2592Reloj_Nombre ;
      private string[] P00H25_A2527TrabNombres ;
      private bool[] P00H25_n2527TrabNombres ;
      private string[] P00H25_A2526TrabApeMat ;
      private bool[] P00H25_n2526TrabApeMat ;
      private string[] P00H25_A2525TrabApePat ;
      private bool[] P00H25_n2525TrabApePat ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV33Options ;
      private GxSimpleCollection<string> AV36OptionsDesc ;
      private GxSimpleCollection<string> AV38OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV43GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV44GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV45GridStateDynamicFilter ;
   }

   public class reloj_codigoidwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00H22( IGxContext context ,
                                             string AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                             short AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                             string AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                             string AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                             string AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                             bool AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                             string AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                             short AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                             string AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                             string AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                             string AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                             bool AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                             string AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                             short AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                             string AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                             string AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                             string AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                             string AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                             string AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                             string AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                             string AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                             DateTime AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                             DateTime AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                             string AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                             string AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                             string AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                             string AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                             string A2525TrabApePat ,
                                             string A2526TrabApeMat ,
                                             string A2527TrabNombres ,
                                             string A2592Reloj_Nombre ,
                                             string A2593HorarioDescripcion ,
                                             string A2431CodigoId ,
                                             DateTime A2415Lectura_Ini )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[28];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [RHTrabajadorCodigo], NULL AS [Reloj_ID], NULL AS [HorarioID], NULL AS [Lectura_Ini], [CodigoId], NULL AS [HorarioDescripcion], NULL AS [Reloj_Nombre], NULL AS [TrabNombres], NULL AS [TrabApeMat], NULL AS [TrabApePat] FROM ( SELECT TOP(100) PERCENT T1.[RHTrabajadorCodigo] AS RHTrabajadorCodigo, T1.[Reloj_ID] AS Reloj_ID, T1.[HorarioID] AS HorarioID, T1.[Lectura_Ini], T1.[CodigoId], T4.[Horario_Dsc] AS HorarioDescripcion, T3.[Reloj_Nom] AS Reloj_Nombre, T2.[TrabNombres], T2.[TrabApeMat], T2.[TrabApePat] FROM ((([Reloj_CodigoID] T1 INNER JOIN [Trab_Trabajador] T2 ON T2.[TrabCodigo] = T1.[RHTrabajadorCodigo]) INNER JOIN [Reloj] T3 ON T3.[RelojID] = T1.[Reloj_ID]) INNER JOIN [Reloj_Horario] T4 ON T4.[Horario_ID] = T1.[HorarioID])";
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int1[10] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int1[11] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int1[12] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int1[13] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int1[14] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int1[15] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int1[16] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int1[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)) ) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] like @lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)");
         }
         else
         {
            GXv_int1[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] = @AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)");
         }
         else
         {
            GXv_int1[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)");
         }
         else
         {
            GXv_int1[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] = @AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)");
         }
         else
         {
            GXv_int1[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] >= @AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini)");
         }
         else
         {
            GXv_int1[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] <= @AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to)");
         }
         else
         {
            GXv_int1[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)");
         }
         else
         {
            GXv_int1[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) = @AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)");
         }
         else
         {
            GXv_int1[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)");
         }
         else
         {
            GXv_int1[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] = @AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)");
         }
         else
         {
            GXv_int1[27] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CodigoId]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [CodigoId]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00H23( IGxContext context ,
                                             string AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                             short AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                             string AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                             string AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                             string AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                             bool AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                             string AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                             short AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                             string AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                             string AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                             string AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                             bool AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                             string AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                             short AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                             string AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                             string AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                             string AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                             string AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                             string AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                             string AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                             string AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                             DateTime AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                             DateTime AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                             string AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                             string AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                             string AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                             string AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                             string A2525TrabApePat ,
                                             string A2526TrabApeMat ,
                                             string A2527TrabNombres ,
                                             string A2592Reloj_Nombre ,
                                             string A2593HorarioDescripcion ,
                                             string A2431CodigoId ,
                                             DateTime A2415Lectura_Ini )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[28];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[RHTrabajadorCodigo] AS RHTrabajadorCodigo, T1.[HorarioID] AS HorarioID, T1.[Reloj_ID] AS Reloj_ID, T1.[Lectura_Ini], T1.[CodigoId], T3.[Horario_Dsc] AS HorarioDescripcion, T4.[Reloj_Nom] AS Reloj_Nombre, T2.[TrabNombres], T2.[TrabApeMat], T2.[TrabApePat] FROM ((([Reloj_CodigoID] T1 INNER JOIN [Trab_Trabajador] T2 ON T2.[TrabCodigo] = T1.[RHTrabajadorCodigo]) INNER JOIN [Reloj_Horario] T3 ON T3.[Horario_ID] = T1.[HorarioID]) INNER JOIN [Reloj] T4 ON T4.[RelojID] = T1.[Reloj_ID])";
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Reloj_Nom] like @lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Reloj_Nom] like '%' + @lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Horario_Dsc] like @lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Horario_Dsc] like '%' + @lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Reloj_Nom] like @lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Reloj_Nom] like '%' + @lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int3[9] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Horario_Dsc] like @lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int3[10] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Horario_Dsc] like '%' + @lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int3[11] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int3[12] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int3[13] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Reloj_Nom] like @lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int3[14] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Reloj_Nom] like '%' + @lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int3[15] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Horario_Dsc] like @lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int3[16] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Horario_Dsc] like '%' + @lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int3[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)) ) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] like @lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)");
         }
         else
         {
            GXv_int3[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] = @AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)");
         }
         else
         {
            GXv_int3[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)) ) )
         {
            AddWhere(sWhereString, "(T4.[Reloj_Nom] like @lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)");
         }
         else
         {
            GXv_int3[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) )
         {
            AddWhere(sWhereString, "(T4.[Reloj_Nom] = @AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)");
         }
         else
         {
            GXv_int3[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] >= @AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini)");
         }
         else
         {
            GXv_int3[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] <= @AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to)");
         }
         else
         {
            GXv_int3[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)");
         }
         else
         {
            GXv_int3[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) = @AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)");
         }
         else
         {
            GXv_int3[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T3.[Horario_Dsc] like @lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)");
         }
         else
         {
            GXv_int3[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T3.[Horario_Dsc] = @AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)");
         }
         else
         {
            GXv_int3[27] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[Reloj_ID]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00H24( IGxContext context ,
                                             string AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                             short AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                             string AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                             string AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                             string AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                             bool AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                             string AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                             short AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                             string AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                             string AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                             string AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                             bool AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                             string AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                             short AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                             string AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                             string AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                             string AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                             string AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                             string AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                             string AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                             string AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                             DateTime AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                             DateTime AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                             string AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                             string AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                             string AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                             string AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                             string A2525TrabApePat ,
                                             string A2526TrabApeMat ,
                                             string A2527TrabNombres ,
                                             string A2592Reloj_Nombre ,
                                             string A2593HorarioDescripcion ,
                                             string A2431CodigoId ,
                                             DateTime A2415Lectura_Ini )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[28];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[RHTrabajadorCodigo] AS RHTrabajadorCodigo, T1.[Reloj_ID] AS Reloj_ID, T1.[HorarioID] AS HorarioID, RTRIM(LTRIM(COALESCE( T2.[TrabApePat], ''))) + ' ' + RTRIM(LTRIM(COALESCE( T2.[TrabApeMat], ''))) + ' ' + RTRIM(LTRIM(COALESCE( T2.[TrabNombres], ''))) AS RHTrabajadorNombres, T1.[Lectura_Ini], T1.[CodigoId], T4.[Horario_Dsc] AS HorarioDescripcion, T3.[Reloj_Nom] AS Reloj_Nombre, T2.[TrabApePat], T2.[TrabApeMat], T2.[TrabNombres] FROM ((([Reloj_CodigoID] T1 INNER JOIN [Trab_Trabajador] T2 ON T2.[TrabCodigo] = T1.[RHTrabajadorCodigo]) INNER JOIN [Reloj] T3 ON T3.[RelojID] = T1.[Reloj_ID]) INNER JOIN [Reloj_Horario] T4 ON T4.[Horario_ID] = T1.[HorarioID])";
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int5[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int5[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int5[9] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int5[10] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int5[11] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int5[12] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int5[13] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int5[14] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int5[15] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int5[16] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int5[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)) ) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] like @lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)");
         }
         else
         {
            GXv_int5[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] = @AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)");
         }
         else
         {
            GXv_int5[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)");
         }
         else
         {
            GXv_int5[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] = @AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)");
         }
         else
         {
            GXv_int5[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] >= @AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini)");
         }
         else
         {
            GXv_int5[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] <= @AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to)");
         }
         else
         {
            GXv_int5[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)");
         }
         else
         {
            GXv_int5[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) = @AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)");
         }
         else
         {
            GXv_int5[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)");
         }
         else
         {
            GXv_int5[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] = @AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)");
         }
         else
         {
            GXv_int5[27] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [RHTrabajadorNombres]";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      protected Object[] conditional_P00H25( IGxContext context ,
                                             string AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1 ,
                                             short AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 ,
                                             string AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1 ,
                                             string AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1 ,
                                             string AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1 ,
                                             bool AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 ,
                                             string AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2 ,
                                             short AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 ,
                                             string AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2 ,
                                             string AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2 ,
                                             string AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2 ,
                                             bool AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 ,
                                             string AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3 ,
                                             short AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 ,
                                             string AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3 ,
                                             string AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3 ,
                                             string AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3 ,
                                             string AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel ,
                                             string AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid ,
                                             string AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel ,
                                             string AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre ,
                                             DateTime AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini ,
                                             DateTime AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to ,
                                             string AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel ,
                                             string AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres ,
                                             string AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel ,
                                             string AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion ,
                                             string A2525TrabApePat ,
                                             string A2526TrabApeMat ,
                                             string A2527TrabNombres ,
                                             string A2592Reloj_Nombre ,
                                             string A2593HorarioDescripcion ,
                                             string A2431CodigoId ,
                                             DateTime A2415Lectura_Ini )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[28];
         Object[] GXv_Object8 = new Object[2];
         scmdbuf = "SELECT T1.[RHTrabajadorCodigo] AS RHTrabajadorCodigo, T1.[Reloj_ID] AS Reloj_ID, T1.[HorarioID] AS HorarioID, T1.[Lectura_Ini], T1.[CodigoId], T4.[Horario_Dsc] AS HorarioDescripcion, T3.[Reloj_Nom] AS Reloj_Nombre, T2.[TrabNombres], T2.[TrabApeMat], T2.[TrabApePat] FROM ((([Reloj_CodigoID] T1 INNER JOIN [Trab_Trabajador] T2 ON T2.[TrabCodigo] = T1.[RHTrabajadorCodigo]) INNER JOIN [Reloj] T3 ON T3.[RelojID] = T1.[Reloj_ID]) INNER JOIN [Reloj_Horario] T4 ON T4.[Horario_ID] = T1.[HorarioID])";
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int7[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RHTRABAJADORNOMBRES") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1)");
         }
         else
         {
            GXv_int7[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int7[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "RELOJ_NOMBRE") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Reloj_interface_reloj_codigoidwwds_1_dynamicfiltersselector1, "HORARIODESCRIPCION") == 0 ) && ( AV68Reloj_interface_reloj_codigoidwwds_2_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RHTRABAJADORNOMBRES") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "RELOJ_NOMBRE") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( AV72Reloj_interface_reloj_codigoidwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Reloj_interface_reloj_codigoidwwds_7_dynamicfiltersselector2, "HORARIODESCRIPCION") == 0 ) && ( AV74Reloj_interface_reloj_codigoidwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RHTRABAJADORNOMBRES") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like '%' + @lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3)");
         }
         else
         {
            GXv_int7[13] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int7[14] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "RELOJ_NOMBRE") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like '%' + @lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3)");
         }
         else
         {
            GXv_int7[15] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int7[16] = 1;
         }
         if ( AV78Reloj_interface_reloj_codigoidwwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Reloj_interface_reloj_codigoidwwds_13_dynamicfiltersselector3, "HORARIODESCRIPCION") == 0 ) && ( AV80Reloj_interface_reloj_codigoidwwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like '%' + @lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3)");
         }
         else
         {
            GXv_int7[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)) ) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] like @lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid)");
         }
         else
         {
            GXv_int7[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)) )
         {
            AddWhere(sWhereString, "(T1.[CodigoId] = @AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel)");
         }
         else
         {
            GXv_int7[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)) ) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] like @lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre)");
         }
         else
         {
            GXv_int7[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)) )
         {
            AddWhere(sWhereString, "(T3.[Reloj_Nom] = @AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel)");
         }
         else
         {
            GXv_int7[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] >= @AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini)");
         }
         else
         {
            GXv_int7[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to) )
         {
            AddWhere(sWhereString, "(T1.[Lectura_Ini] <= @AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to)");
         }
         else
         {
            GXv_int7[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)) ) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) like @lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres)");
         }
         else
         {
            GXv_int7[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)) )
         {
            AddWhere(sWhereString, "(RTRIM(LTRIM(T2.[TrabApePat])) + ' ' + RTRIM(LTRIM(T2.[TrabApeMat])) + ' ' + RTRIM(LTRIM(T2.[TrabNombres])) = @AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel)");
         }
         else
         {
            GXv_int7[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)) ) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] like @lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion)");
         }
         else
         {
            GXv_int7[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)) )
         {
            AddWhere(sWhereString, "(T4.[Horario_Dsc] = @AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel)");
         }
         else
         {
            GXv_int7[27] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[HorarioID]";
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
                     return conditional_P00H22(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (DateTime)dynConstraints[33] );
               case 1 :
                     return conditional_P00H23(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (DateTime)dynConstraints[33] );
               case 2 :
                     return conditional_P00H24(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (DateTime)dynConstraints[33] );
               case 3 :
                     return conditional_P00H25(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (DateTime)dynConstraints[33] );
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
          Object[] prmP00H22;
          prmP00H22 = new Object[] {
          new ParDef("@lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid",GXType.NVarChar,25,0) ,
          new ParDef("@AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel",GXType.NVarChar,25,0) ,
          new ParDef("@lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre",GXType.NVarChar,50,0) ,
          new ParDef("@AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel",GXType.NVarChar,50,0) ,
          new ParDef("@AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini",GXType.DateTime,10,8) ,
          new ParDef("@AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to",GXType.DateTime,10,8) ,
          new ParDef("@lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres",GXType.VarChar,300,0) ,
          new ParDef("@AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel",GXType.VarChar,300,0) ,
          new ParDef("@lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion",GXType.NVarChar,100,5) ,
          new ParDef("@AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel",GXType.NVarChar,100,5)
          };
          Object[] prmP00H23;
          prmP00H23 = new Object[] {
          new ParDef("@lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid",GXType.NVarChar,25,0) ,
          new ParDef("@AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel",GXType.NVarChar,25,0) ,
          new ParDef("@lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre",GXType.NVarChar,50,0) ,
          new ParDef("@AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel",GXType.NVarChar,50,0) ,
          new ParDef("@AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini",GXType.DateTime,10,8) ,
          new ParDef("@AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to",GXType.DateTime,10,8) ,
          new ParDef("@lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres",GXType.VarChar,300,0) ,
          new ParDef("@AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel",GXType.VarChar,300,0) ,
          new ParDef("@lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion",GXType.NVarChar,100,5) ,
          new ParDef("@AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel",GXType.NVarChar,100,5)
          };
          Object[] prmP00H24;
          prmP00H24 = new Object[] {
          new ParDef("@lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid",GXType.NVarChar,25,0) ,
          new ParDef("@AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel",GXType.NVarChar,25,0) ,
          new ParDef("@lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre",GXType.NVarChar,50,0) ,
          new ParDef("@AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel",GXType.NVarChar,50,0) ,
          new ParDef("@AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini",GXType.DateTime,10,8) ,
          new ParDef("@AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to",GXType.DateTime,10,8) ,
          new ParDef("@lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres",GXType.VarChar,300,0) ,
          new ParDef("@AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel",GXType.VarChar,300,0) ,
          new ParDef("@lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion",GXType.NVarChar,100,5) ,
          new ParDef("@AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel",GXType.NVarChar,100,5)
          };
          Object[] prmP00H25;
          prmP00H25 = new Object[] {
          new ParDef("@lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV69Reloj_interface_reloj_codigoidwwds_3_rhtrabajadornombres1",GXType.VarChar,300,0) ,
          new ParDef("@lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV70Reloj_interface_reloj_codigoidwwds_4_reloj_nombre1",GXType.NVarChar,50,0) ,
          new ParDef("@lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV71Reloj_interface_reloj_codigoidwwds_5_horariodescripcion1",GXType.NVarChar,100,5) ,
          new ParDef("@lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV75Reloj_interface_reloj_codigoidwwds_9_rhtrabajadornombres2",GXType.VarChar,300,0) ,
          new ParDef("@lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV76Reloj_interface_reloj_codigoidwwds_10_reloj_nombre2",GXType.NVarChar,50,0) ,
          new ParDef("@lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV77Reloj_interface_reloj_codigoidwwds_11_horariodescripcion2",GXType.NVarChar,100,5) ,
          new ParDef("@lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV81Reloj_interface_reloj_codigoidwwds_15_rhtrabajadornombres3",GXType.VarChar,300,0) ,
          new ParDef("@lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV82Reloj_interface_reloj_codigoidwwds_16_reloj_nombre3",GXType.NVarChar,50,0) ,
          new ParDef("@lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV83Reloj_interface_reloj_codigoidwwds_17_horariodescripcion3",GXType.NVarChar,100,5) ,
          new ParDef("@lV84Reloj_interface_reloj_codigoidwwds_18_tfcodigoid",GXType.NVarChar,25,0) ,
          new ParDef("@AV85Reloj_interface_reloj_codigoidwwds_19_tfcodigoid_sel",GXType.NVarChar,25,0) ,
          new ParDef("@lV86Reloj_interface_reloj_codigoidwwds_20_tfreloj_nombre",GXType.NVarChar,50,0) ,
          new ParDef("@AV87Reloj_interface_reloj_codigoidwwds_21_tfreloj_nombre_sel",GXType.NVarChar,50,0) ,
          new ParDef("@AV88Reloj_interface_reloj_codigoidwwds_22_tflectura_ini",GXType.DateTime,10,8) ,
          new ParDef("@AV89Reloj_interface_reloj_codigoidwwds_23_tflectura_ini_to",GXType.DateTime,10,8) ,
          new ParDef("@lV90Reloj_interface_reloj_codigoidwwds_24_tfrhtrabajadornombres",GXType.VarChar,300,0) ,
          new ParDef("@AV91Reloj_interface_reloj_codigoidwwds_25_tfrhtrabajadornombres_sel",GXType.VarChar,300,0) ,
          new ParDef("@lV92Reloj_interface_reloj_codigoidwwds_26_tfhorariodescripcion",GXType.NVarChar,100,5) ,
          new ParDef("@AV93Reloj_interface_reloj_codigoidwwds_27_tfhorariodescripcion_sel",GXType.NVarChar,100,5)
          };
          def= new CursorDef[] {
              new CursorDef("P00H22", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H22,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00H23", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H23,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00H24", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H24,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00H25", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H25,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
