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
   public class reloj_horariowwgetfilterdata : GXProcedure
   {
      public reloj_horariowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public reloj_horariowwgetfilterdata( IGxContext context )
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
         this.AV24DDOName = aP0_DDOName;
         this.AV22SearchTxt = aP1_SearchTxt;
         this.AV23SearchTxtTo = aP2_SearchTxtTo;
         this.AV28OptionsJson = "" ;
         this.AV31OptionsDescJson = "" ;
         this.AV33OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV33OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         reloj_horariowwgetfilterdata objreloj_horariowwgetfilterdata;
         objreloj_horariowwgetfilterdata = new reloj_horariowwgetfilterdata();
         objreloj_horariowwgetfilterdata.AV24DDOName = aP0_DDOName;
         objreloj_horariowwgetfilterdata.AV22SearchTxt = aP1_SearchTxt;
         objreloj_horariowwgetfilterdata.AV23SearchTxtTo = aP2_SearchTxtTo;
         objreloj_horariowwgetfilterdata.AV28OptionsJson = "" ;
         objreloj_horariowwgetfilterdata.AV31OptionsDescJson = "" ;
         objreloj_horariowwgetfilterdata.AV33OptionIndexesJson = "" ;
         objreloj_horariowwgetfilterdata.context.SetSubmitInitialConfig(context);
         objreloj_horariowwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objreloj_horariowwgetfilterdata);
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((reloj_horariowwgetfilterdata)stateInfo).executePrivate();
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
         AV27Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_HORARIO_DSC") == 0 )
         {
            /* Execute user subroutine: 'LOADHORARIO_DSCOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV28OptionsJson = AV27Options.ToJSonString(false);
         AV31OptionsDescJson = AV30OptionsDesc.ToJSonString(false);
         AV33OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV35Session.Get("Reloj_Interface.Reloj_HorarioWWGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Reloj_Interface.Reloj_HorarioWWGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("Reloj_Interface.Reloj_HorarioWWGridState"), null, "", "");
         }
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFHORARIO_ID") == 0 )
            {
               AV10TFHorario_ID = (short)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Value, "."));
               AV11TFHorario_ID_To = (short)(NumberUtil.Val( AV38GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFHORARIO_DSC") == 0 )
            {
               AV12TFHorario_Dsc = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFHORARIO_DSC_SEL") == 0 )
            {
               AV13TFHorario_Dsc_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFHORARIO_DIA_INI_01") == 0 )
            {
               AV14TFHorario_Dia_Ini_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Value, 2));
               AV15TFHorario_Dia_Ini_01_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Valueto, 2));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFHORARIO_DIA_FIN_01") == 0 )
            {
               AV16TFHorario_Dia_Fin_01 = DateTimeUtil.ResetDate(context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Value, 2));
               AV17TFHorario_Dia_Fin_01_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Valueto, 2));
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFHORARIO_VIGENCIA") == 0 )
            {
               AV18TFHorario_Vigencia = context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Value, 2);
               AV19TFHorario_Vigencia_To = context.localUtil.CToT( AV38GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADHORARIO_DSCOPTIONS' Routine */
         returnInSub = false;
         AV12TFHorario_Dsc = AV22SearchTxt;
         AV13TFHorario_Dsc_Sel = "";
         AV57Reloj_interface_reloj_horariowwds_1_tfhorario_id = AV10TFHorario_ID;
         AV58Reloj_interface_reloj_horariowwds_2_tfhorario_id_to = AV11TFHorario_ID_To;
         AV59Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = AV12TFHorario_Dsc;
         AV60Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel = AV13TFHorario_Dsc_Sel;
         AV61Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 = AV14TFHorario_Dia_Ini_01;
         AV62Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to = AV15TFHorario_Dia_Ini_01_To;
         AV63Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 = AV16TFHorario_Dia_Fin_01;
         AV64Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to = AV17TFHorario_Dia_Fin_01_To;
         AV65Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia = AV18TFHorario_Vigencia;
         AV66Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to = AV19TFHorario_Vigencia_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV57Reloj_interface_reloj_horariowwds_1_tfhorario_id ,
                                              AV58Reloj_interface_reloj_horariowwds_2_tfhorario_id_to ,
                                              AV60Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel ,
                                              AV59Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ,
                                              AV61Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 ,
                                              AV62Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to ,
                                              AV63Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 ,
                                              AV64Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to ,
                                              AV65Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia ,
                                              AV66Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to ,
                                              A2432Horario_ID ,
                                              A2433Horario_Dsc ,
                                              A2434Horario_Dia_Ini_01 ,
                                              A2441Horario_Dia_Fin_01 ,
                                              A2462Horario_Vigencia } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV59Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = StringUtil.Concat( StringUtil.RTrim( AV59Reloj_interface_reloj_horariowwds_3_tfhorario_dsc), "%", "");
         /* Using cursor P00GG2 */
         pr_default.execute(0, new Object[] {AV57Reloj_interface_reloj_horariowwds_1_tfhorario_id, AV58Reloj_interface_reloj_horariowwds_2_tfhorario_id_to, lV59Reloj_interface_reloj_horariowwds_3_tfhorario_dsc, AV60Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel, AV61Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01, AV62Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to, AV63Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01, AV64Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to, AV65Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia, AV66Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKGG2 = false;
            A2433Horario_Dsc = P00GG2_A2433Horario_Dsc[0];
            A2462Horario_Vigencia = P00GG2_A2462Horario_Vigencia[0];
            A2441Horario_Dia_Fin_01 = P00GG2_A2441Horario_Dia_Fin_01[0];
            A2434Horario_Dia_Ini_01 = P00GG2_A2434Horario_Dia_Ini_01[0];
            A2432Horario_ID = P00GG2_A2432Horario_ID[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00GG2_A2433Horario_Dsc[0], A2433Horario_Dsc) == 0 ) )
            {
               BRKGG2 = false;
               A2432Horario_ID = P00GG2_A2432Horario_ID[0];
               AV34count = (long)(AV34count+1);
               BRKGG2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A2433Horario_Dsc)) )
            {
               AV26Option = A2433Horario_Dsc;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRKGG2 )
            {
               BRKGG2 = true;
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
         AV28OptionsJson = "";
         AV31OptionsDescJson = "";
         AV33OptionIndexesJson = "";
         AV27Options = new GxSimpleCollection<string>();
         AV30OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV35Session = context.GetSession();
         AV37GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV38GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV12TFHorario_Dsc = "";
         AV13TFHorario_Dsc_Sel = "";
         AV14TFHorario_Dia_Ini_01 = (DateTime)(DateTime.MinValue);
         AV15TFHorario_Dia_Ini_01_To = (DateTime)(DateTime.MinValue);
         AV16TFHorario_Dia_Fin_01 = (DateTime)(DateTime.MinValue);
         AV17TFHorario_Dia_Fin_01_To = (DateTime)(DateTime.MinValue);
         AV18TFHorario_Vigencia = (DateTime)(DateTime.MinValue);
         AV19TFHorario_Vigencia_To = (DateTime)(DateTime.MinValue);
         AV59Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = "";
         AV60Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel = "";
         AV61Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 = (DateTime)(DateTime.MinValue);
         AV62Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to = (DateTime)(DateTime.MinValue);
         AV63Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 = (DateTime)(DateTime.MinValue);
         AV64Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to = (DateTime)(DateTime.MinValue);
         AV65Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia = (DateTime)(DateTime.MinValue);
         AV66Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         lV59Reloj_interface_reloj_horariowwds_3_tfhorario_dsc = "";
         A2433Horario_Dsc = "";
         A2434Horario_Dia_Ini_01 = (DateTime)(DateTime.MinValue);
         A2441Horario_Dia_Fin_01 = (DateTime)(DateTime.MinValue);
         A2462Horario_Vigencia = (DateTime)(DateTime.MinValue);
         P00GG2_A2433Horario_Dsc = new string[] {""} ;
         P00GG2_A2462Horario_Vigencia = new DateTime[] {DateTime.MinValue} ;
         P00GG2_A2441Horario_Dia_Fin_01 = new DateTime[] {DateTime.MinValue} ;
         P00GG2_A2434Horario_Dia_Ini_01 = new DateTime[] {DateTime.MinValue} ;
         P00GG2_A2432Horario_ID = new short[1] ;
         AV26Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reloj_interface.reloj_horariowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00GG2_A2433Horario_Dsc, P00GG2_A2462Horario_Vigencia, P00GG2_A2441Horario_Dia_Fin_01, P00GG2_A2434Horario_Dia_Ini_01, P00GG2_A2432Horario_ID
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV10TFHorario_ID ;
      private short AV11TFHorario_ID_To ;
      private short AV57Reloj_interface_reloj_horariowwds_1_tfhorario_id ;
      private short AV58Reloj_interface_reloj_horariowwds_2_tfhorario_id_to ;
      private short A2432Horario_ID ;
      private int AV55GXV1 ;
      private long AV34count ;
      private string scmdbuf ;
      private DateTime AV14TFHorario_Dia_Ini_01 ;
      private DateTime AV15TFHorario_Dia_Ini_01_To ;
      private DateTime AV16TFHorario_Dia_Fin_01 ;
      private DateTime AV17TFHorario_Dia_Fin_01_To ;
      private DateTime AV18TFHorario_Vigencia ;
      private DateTime AV19TFHorario_Vigencia_To ;
      private DateTime AV61Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 ;
      private DateTime AV62Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to ;
      private DateTime AV63Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 ;
      private DateTime AV64Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to ;
      private DateTime AV65Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia ;
      private DateTime AV66Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to ;
      private DateTime A2434Horario_Dia_Ini_01 ;
      private DateTime A2441Horario_Dia_Fin_01 ;
      private DateTime A2462Horario_Vigencia ;
      private bool returnInSub ;
      private bool BRKGG2 ;
      private string AV28OptionsJson ;
      private string AV31OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV24DDOName ;
      private string AV22SearchTxt ;
      private string AV23SearchTxtTo ;
      private string AV12TFHorario_Dsc ;
      private string AV13TFHorario_Dsc_Sel ;
      private string AV59Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ;
      private string AV60Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel ;
      private string lV59Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ;
      private string A2433Horario_Dsc ;
      private string AV26Option ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00GG2_A2433Horario_Dsc ;
      private DateTime[] P00GG2_A2462Horario_Vigencia ;
      private DateTime[] P00GG2_A2441Horario_Dia_Fin_01 ;
      private DateTime[] P00GG2_A2434Horario_Dia_Ini_01 ;
      private short[] P00GG2_A2432Horario_ID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV30OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV37GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV38GridStateFilterValue ;
   }

   public class reloj_horariowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00GG2( IGxContext context ,
                                             short AV57Reloj_interface_reloj_horariowwds_1_tfhorario_id ,
                                             short AV58Reloj_interface_reloj_horariowwds_2_tfhorario_id_to ,
                                             string AV60Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel ,
                                             string AV59Reloj_interface_reloj_horariowwds_3_tfhorario_dsc ,
                                             DateTime AV61Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01 ,
                                             DateTime AV62Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to ,
                                             DateTime AV63Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01 ,
                                             DateTime AV64Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to ,
                                             DateTime AV65Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia ,
                                             DateTime AV66Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to ,
                                             short A2432Horario_ID ,
                                             string A2433Horario_Dsc ,
                                             DateTime A2434Horario_Dia_Ini_01 ,
                                             DateTime A2441Horario_Dia_Fin_01 ,
                                             DateTime A2462Horario_Vigencia )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [Horario_Dsc], [Horario_Vigencia], [Horario_Dia_Fin_01], [Horario_Dia_Ini_01], [Horario_ID] FROM [Reloj_Horario]";
         if ( ! (0==AV57Reloj_interface_reloj_horariowwds_1_tfhorario_id) )
         {
            AddWhere(sWhereString, "([Horario_ID] >= @AV57Reloj_interface_reloj_horariowwds_1_tfhorario_id)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV58Reloj_interface_reloj_horariowwds_2_tfhorario_id_to) )
         {
            AddWhere(sWhereString, "([Horario_ID] <= @AV58Reloj_interface_reloj_horariowwds_2_tfhorario_id_to)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV60Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Reloj_interface_reloj_horariowwds_3_tfhorario_dsc)) ) )
         {
            AddWhere(sWhereString, "([Horario_Dsc] like @lV59Reloj_interface_reloj_horariowwds_3_tfhorario_dsc)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel)) )
         {
            AddWhere(sWhereString, "([Horario_Dsc] = @AV60Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV61Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Ini_01] >= @AV61Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV62Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Ini_01] <= @AV62Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV63Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Fin_01] >= @AV63Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( ! (DateTime.MinValue==AV64Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to) )
         {
            AddWhere(sWhereString, "([Horario_Dia_Fin_01] <= @AV64Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! (DateTime.MinValue==AV65Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia) )
         {
            AddWhere(sWhereString, "([Horario_Vigencia] >= @AV65Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV66Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to) )
         {
            AddWhere(sWhereString, "([Horario_Vigencia] <= @AV66Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to)");
         }
         else
         {
            GXv_int1[9] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [Horario_Dsc]";
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
                     return conditional_P00GG2(context, (short)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (DateTime)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] );
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
          Object[] prmP00GG2;
          prmP00GG2 = new Object[] {
          new ParDef("@AV57Reloj_interface_reloj_horariowwds_1_tfhorario_id",GXType.Int16,4,0) ,
          new ParDef("@AV58Reloj_interface_reloj_horariowwds_2_tfhorario_id_to",GXType.Int16,4,0) ,
          new ParDef("@lV59Reloj_interface_reloj_horariowwds_3_tfhorario_dsc",GXType.NVarChar,100,5) ,
          new ParDef("@AV60Reloj_interface_reloj_horariowwds_4_tfhorario_dsc_sel",GXType.NVarChar,100,5) ,
          new ParDef("@AV61Reloj_interface_reloj_horariowwds_5_tfhorario_dia_ini_01",GXType.DateTime,0,5) ,
          new ParDef("@AV62Reloj_interface_reloj_horariowwds_6_tfhorario_dia_ini_01_to",GXType.DateTime,0,5) ,
          new ParDef("@AV63Reloj_interface_reloj_horariowwds_7_tfhorario_dia_fin_01",GXType.DateTime,0,5) ,
          new ParDef("@AV64Reloj_interface_reloj_horariowwds_8_tfhorario_dia_fin_01_to",GXType.DateTime,0,5) ,
          new ParDef("@AV65Reloj_interface_reloj_horariowwds_9_tfhorario_vigencia",GXType.DateTime,10,8) ,
          new ParDef("@AV66Reloj_interface_reloj_horariowwds_10_tfhorario_vigencia_to",GXType.DateTime,10,8)
          };
          def= new CursorDef[] {
              new CursorDef("P00GG2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GG2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
       }
    }

 }

}
