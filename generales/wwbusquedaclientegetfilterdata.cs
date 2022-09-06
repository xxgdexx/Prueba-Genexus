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
namespace GeneXus.Programs.generales {
   public class wwbusquedaclientegetfilterdata : GXProcedure
   {
      public wwbusquedaclientegetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwbusquedaclientegetfilterdata( IGxContext context )
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
         wwbusquedaclientegetfilterdata objwwbusquedaclientegetfilterdata;
         objwwbusquedaclientegetfilterdata = new wwbusquedaclientegetfilterdata();
         objwwbusquedaclientegetfilterdata.AV24DDOName = aP0_DDOName;
         objwwbusquedaclientegetfilterdata.AV22SearchTxt = aP1_SearchTxt;
         objwwbusquedaclientegetfilterdata.AV23SearchTxtTo = aP2_SearchTxtTo;
         objwwbusquedaclientegetfilterdata.AV28OptionsJson = "" ;
         objwwbusquedaclientegetfilterdata.AV31OptionsDescJson = "" ;
         objwwbusquedaclientegetfilterdata.AV33OptionIndexesJson = "" ;
         objwwbusquedaclientegetfilterdata.context.SetSubmitInitialConfig(context);
         objwwbusquedaclientegetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwbusquedaclientegetfilterdata);
         aP3_OptionsJson=this.AV28OptionsJson;
         aP4_OptionsDescJson=this.AV31OptionsDescJson;
         aP5_OptionIndexesJson=this.AV33OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwbusquedaclientegetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_CLICOD") == 0 )
         {
            /* Execute user subroutine: 'LOADCLICODOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_CLIDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIDSCOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV24DDOName), "DDO_CLIDIR") == 0 )
         {
            /* Execute user subroutine: 'LOADCLIDIROPTIONS' */
            S141 ();
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
         if ( StringUtil.StrCmp(AV35Session.Get("Generales.WWBusquedaClienteGridState"), "") == 0 )
         {
            AV37GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Generales.WWBusquedaClienteGridState"), null, "", "");
         }
         else
         {
            AV37GridState.FromXml(AV35Session.Get("Generales.WWBusquedaClienteGridState"), null, "", "");
         }
         AV73GXV1 = 1;
         while ( AV73GXV1 <= AV37GridState.gxTpr_Filtervalues.Count )
         {
            AV38GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV37GridState.gxTpr_Filtervalues.Item(AV73GXV1));
            if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV60FilterFullText = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCLICOD") == 0 )
            {
               AV65TFCliCod = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCLICOD_SEL") == 0 )
            {
               AV66TFCliCod_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCLIDSC") == 0 )
            {
               AV67TFCliDsc = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCLIDSC_SEL") == 0 )
            {
               AV68TFCliDsc_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCLIDIR") == 0 )
            {
               AV69TFCliDir = AV38GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV38GridStateFilterValue.gxTpr_Name, "TFCLIDIR_SEL") == 0 )
            {
               AV70TFCliDir_Sel = AV38GridStateFilterValue.gxTpr_Value;
            }
            AV73GXV1 = (int)(AV73GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADCLICODOPTIONS' Routine */
         returnInSub = false;
         AV65TFCliCod = AV22SearchTxt;
         AV66TFCliCod_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV60FilterFullText ,
                                              AV66TFCliCod_Sel ,
                                              AV65TFCliCod ,
                                              AV68TFCliDsc_Sel ,
                                              AV67TFCliDsc ,
                                              AV70TFCliDir_Sel ,
                                              AV69TFCliDir ,
                                              A45CliCod ,
                                              A161CliDsc ,
                                              A596CliDir ,
                                              A627CliSts } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         });
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV65TFCliCod = StringUtil.PadR( StringUtil.RTrim( AV65TFCliCod), 20, "%");
         lV67TFCliDsc = StringUtil.PadR( StringUtil.RTrim( AV67TFCliDsc), 100, "%");
         lV69TFCliDir = StringUtil.PadR( StringUtil.RTrim( AV69TFCliDir), 100, "%");
         /* Using cursor P007I2 */
         pr_default.execute(0, new Object[] {lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV65TFCliCod, AV66TFCliCod_Sel, lV67TFCliDsc, AV68TFCliDsc_Sel, lV69TFCliDir, AV70TFCliDir_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7I2 = false;
            A45CliCod = P007I2_A45CliCod[0];
            A627CliSts = P007I2_A627CliSts[0];
            A596CliDir = P007I2_A596CliDir[0];
            A161CliDsc = P007I2_A161CliDsc[0];
            AV34count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007I2_A45CliCod[0], A45CliCod) == 0 ) )
            {
               BRK7I2 = false;
               AV34count = (long)(AV34count+1);
               BRK7I2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A45CliCod)) )
            {
               AV26Option = A45CliCod;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK7I2 )
            {
               BRK7I2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCLIDSCOPTIONS' Routine */
         returnInSub = false;
         AV67TFCliDsc = AV22SearchTxt;
         AV68TFCliDsc_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV60FilterFullText ,
                                              AV66TFCliCod_Sel ,
                                              AV65TFCliCod ,
                                              AV68TFCliDsc_Sel ,
                                              AV67TFCliDsc ,
                                              AV70TFCliDir_Sel ,
                                              AV69TFCliDir ,
                                              A45CliCod ,
                                              A161CliDsc ,
                                              A596CliDir ,
                                              A627CliSts } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         });
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV65TFCliCod = StringUtil.PadR( StringUtil.RTrim( AV65TFCliCod), 20, "%");
         lV67TFCliDsc = StringUtil.PadR( StringUtil.RTrim( AV67TFCliDsc), 100, "%");
         lV69TFCliDir = StringUtil.PadR( StringUtil.RTrim( AV69TFCliDir), 100, "%");
         /* Using cursor P007I3 */
         pr_default.execute(1, new Object[] {lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV65TFCliCod, AV66TFCliCod_Sel, lV67TFCliDsc, AV68TFCliDsc_Sel, lV69TFCliDir, AV70TFCliDir_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7I4 = false;
            A161CliDsc = P007I3_A161CliDsc[0];
            A627CliSts = P007I3_A627CliSts[0];
            A596CliDir = P007I3_A596CliDir[0];
            A45CliCod = P007I3_A45CliCod[0];
            AV34count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007I3_A161CliDsc[0], A161CliDsc) == 0 ) )
            {
               BRK7I4 = false;
               A45CliCod = P007I3_A45CliCod[0];
               AV34count = (long)(AV34count+1);
               BRK7I4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A161CliDsc)) )
            {
               AV26Option = A161CliDsc;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK7I4 )
            {
               BRK7I4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCLIDIROPTIONS' Routine */
         returnInSub = false;
         AV69TFCliDir = AV22SearchTxt;
         AV70TFCliDir_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV60FilterFullText ,
                                              AV66TFCliCod_Sel ,
                                              AV65TFCliCod ,
                                              AV68TFCliDsc_Sel ,
                                              AV67TFCliDsc ,
                                              AV70TFCliDir_Sel ,
                                              AV69TFCliDir ,
                                              A45CliCod ,
                                              A161CliDsc ,
                                              A596CliDir ,
                                              A627CliSts } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         });
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV60FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV60FilterFullText), "%", "");
         lV65TFCliCod = StringUtil.PadR( StringUtil.RTrim( AV65TFCliCod), 20, "%");
         lV67TFCliDsc = StringUtil.PadR( StringUtil.RTrim( AV67TFCliDsc), 100, "%");
         lV69TFCliDir = StringUtil.PadR( StringUtil.RTrim( AV69TFCliDir), 100, "%");
         /* Using cursor P007I4 */
         pr_default.execute(2, new Object[] {lV60FilterFullText, lV60FilterFullText, lV60FilterFullText, lV65TFCliCod, AV66TFCliCod_Sel, lV67TFCliDsc, AV68TFCliDsc_Sel, lV69TFCliDir, AV70TFCliDir_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK7I6 = false;
            A627CliSts = P007I4_A627CliSts[0];
            A596CliDir = P007I4_A596CliDir[0];
            A161CliDsc = P007I4_A161CliDsc[0];
            A45CliCod = P007I4_A45CliCod[0];
            AV34count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P007I4_A596CliDir[0], A596CliDir) == 0 ) )
            {
               BRK7I6 = false;
               A45CliCod = P007I4_A45CliCod[0];
               AV34count = (long)(AV34count+1);
               BRK7I6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A596CliDir)) )
            {
               AV26Option = A596CliDir;
               AV27Options.Add(AV26Option, 0);
               AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV34count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV27Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK7I6 )
            {
               BRK7I6 = true;
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
         AV60FilterFullText = "";
         AV65TFCliCod = "";
         AV66TFCliCod_Sel = "";
         AV67TFCliDsc = "";
         AV68TFCliDsc_Sel = "";
         AV69TFCliDir = "";
         AV70TFCliDir_Sel = "";
         scmdbuf = "";
         lV60FilterFullText = "";
         lV65TFCliCod = "";
         lV67TFCliDsc = "";
         lV69TFCliDir = "";
         A45CliCod = "";
         A161CliDsc = "";
         A596CliDir = "";
         P007I2_A45CliCod = new string[] {""} ;
         P007I2_A627CliSts = new short[1] ;
         P007I2_A596CliDir = new string[] {""} ;
         P007I2_A161CliDsc = new string[] {""} ;
         AV26Option = "";
         P007I3_A161CliDsc = new string[] {""} ;
         P007I3_A627CliSts = new short[1] ;
         P007I3_A596CliDir = new string[] {""} ;
         P007I3_A45CliCod = new string[] {""} ;
         P007I4_A627CliSts = new short[1] ;
         P007I4_A596CliDir = new string[] {""} ;
         P007I4_A161CliDsc = new string[] {""} ;
         P007I4_A45CliCod = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.generales.wwbusquedaclientegetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007I2_A45CliCod, P007I2_A627CliSts, P007I2_A596CliDir, P007I2_A161CliDsc
               }
               , new Object[] {
               P007I3_A161CliDsc, P007I3_A627CliSts, P007I3_A596CliDir, P007I3_A45CliCod
               }
               , new Object[] {
               P007I4_A627CliSts, P007I4_A596CliDir, P007I4_A161CliDsc, P007I4_A45CliCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A627CliSts ;
      private int AV73GXV1 ;
      private long AV34count ;
      private string AV65TFCliCod ;
      private string AV66TFCliCod_Sel ;
      private string AV67TFCliDsc ;
      private string AV68TFCliDsc_Sel ;
      private string AV69TFCliDir ;
      private string AV70TFCliDir_Sel ;
      private string scmdbuf ;
      private string lV65TFCliCod ;
      private string lV67TFCliDsc ;
      private string lV69TFCliDir ;
      private string A45CliCod ;
      private string A161CliDsc ;
      private string A596CliDir ;
      private bool returnInSub ;
      private bool BRK7I2 ;
      private bool BRK7I4 ;
      private bool BRK7I6 ;
      private string AV28OptionsJson ;
      private string AV31OptionsDescJson ;
      private string AV33OptionIndexesJson ;
      private string AV24DDOName ;
      private string AV22SearchTxt ;
      private string AV23SearchTxtTo ;
      private string AV60FilterFullText ;
      private string lV60FilterFullText ;
      private string AV26Option ;
      private IGxSession AV35Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P007I2_A45CliCod ;
      private short[] P007I2_A627CliSts ;
      private string[] P007I2_A596CliDir ;
      private string[] P007I2_A161CliDsc ;
      private string[] P007I3_A161CliDsc ;
      private short[] P007I3_A627CliSts ;
      private string[] P007I3_A596CliDir ;
      private string[] P007I3_A45CliCod ;
      private short[] P007I4_A627CliSts ;
      private string[] P007I4_A596CliDir ;
      private string[] P007I4_A161CliDsc ;
      private string[] P007I4_A45CliCod ;
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

   public class wwbusquedaclientegetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007I2( IGxContext context ,
                                             string AV60FilterFullText ,
                                             string AV66TFCliCod_Sel ,
                                             string AV65TFCliCod ,
                                             string AV68TFCliDsc_Sel ,
                                             string AV67TFCliDsc ,
                                             string AV70TFCliDir_Sel ,
                                             string AV69TFCliDir ,
                                             string A45CliCod ,
                                             string A161CliDsc ,
                                             string A596CliDir ,
                                             short A627CliSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [CliCod], [CliSts], [CliDir], [CliDsc] FROM [CLCLIENTES]";
         AddWhere(sWhereString, "([CliSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60FilterFullText)) )
         {
            AddWhere(sWhereString, "(( [CliCod] like '%' + @lV60FilterFullText) or ( [CliDsc] like '%' + @lV60FilterFullText) or ( [CliDir] like '%' + @lV60FilterFullText))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66TFCliCod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TFCliCod)) ) )
         {
            AddWhere(sWhereString, "([CliCod] like @lV65TFCliCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TFCliCod_Sel)) )
         {
            AddWhere(sWhereString, "([CliCod] = @AV66TFCliCod_Sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCliDsc_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFCliDsc)) ) )
         {
            AddWhere(sWhereString, "([CliDsc] like @lV67TFCliDsc)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCliDsc_Sel)) )
         {
            AddWhere(sWhereString, "([CliDsc] = @AV68TFCliDsc_Sel)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70TFCliDir_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69TFCliDir)) ) )
         {
            AddWhere(sWhereString, "([CliDir] like @lV69TFCliDir)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70TFCliDir_Sel)) )
         {
            AddWhere(sWhereString, "([CliDir] = @AV70TFCliDir_Sel)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CliCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007I3( IGxContext context ,
                                             string AV60FilterFullText ,
                                             string AV66TFCliCod_Sel ,
                                             string AV65TFCliCod ,
                                             string AV68TFCliDsc_Sel ,
                                             string AV67TFCliDsc ,
                                             string AV70TFCliDir_Sel ,
                                             string AV69TFCliDir ,
                                             string A45CliCod ,
                                             string A161CliDsc ,
                                             string A596CliDir ,
                                             short A627CliSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[9];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [CliDsc], [CliSts], [CliDir], [CliCod] FROM [CLCLIENTES]";
         AddWhere(sWhereString, "([CliSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60FilterFullText)) )
         {
            AddWhere(sWhereString, "(( [CliCod] like '%' + @lV60FilterFullText) or ( [CliDsc] like '%' + @lV60FilterFullText) or ( [CliDir] like '%' + @lV60FilterFullText))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66TFCliCod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TFCliCod)) ) )
         {
            AddWhere(sWhereString, "([CliCod] like @lV65TFCliCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TFCliCod_Sel)) )
         {
            AddWhere(sWhereString, "([CliCod] = @AV66TFCliCod_Sel)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCliDsc_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFCliDsc)) ) )
         {
            AddWhere(sWhereString, "([CliDsc] like @lV67TFCliDsc)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCliDsc_Sel)) )
         {
            AddWhere(sWhereString, "([CliDsc] = @AV68TFCliDsc_Sel)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70TFCliDir_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69TFCliDir)) ) )
         {
            AddWhere(sWhereString, "([CliDir] like @lV69TFCliDir)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70TFCliDir_Sel)) )
         {
            AddWhere(sWhereString, "([CliDir] = @AV70TFCliDir_Sel)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CliDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007I4( IGxContext context ,
                                             string AV60FilterFullText ,
                                             string AV66TFCliCod_Sel ,
                                             string AV65TFCliCod ,
                                             string AV68TFCliDsc_Sel ,
                                             string AV67TFCliDsc ,
                                             string AV70TFCliDir_Sel ,
                                             string AV69TFCliDir ,
                                             string A45CliCod ,
                                             string A161CliDsc ,
                                             string A596CliDir ,
                                             short A627CliSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[9];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [CliSts], [CliDir], [CliDsc], [CliCod] FROM [CLCLIENTES]";
         AddWhere(sWhereString, "([CliSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60FilterFullText)) )
         {
            AddWhere(sWhereString, "(( [CliCod] like '%' + @lV60FilterFullText) or ( [CliDsc] like '%' + @lV60FilterFullText) or ( [CliDir] like '%' + @lV60FilterFullText))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66TFCliCod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TFCliCod)) ) )
         {
            AddWhere(sWhereString, "([CliCod] like @lV65TFCliCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TFCliCod_Sel)) )
         {
            AddWhere(sWhereString, "([CliCod] = @AV66TFCliCod_Sel)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCliDsc_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFCliDsc)) ) )
         {
            AddWhere(sWhereString, "([CliDsc] like @lV67TFCliDsc)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCliDsc_Sel)) )
         {
            AddWhere(sWhereString, "([CliDsc] = @AV68TFCliDsc_Sel)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70TFCliDir_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69TFCliDir)) ) )
         {
            AddWhere(sWhereString, "([CliDir] like @lV69TFCliDir)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70TFCliDir_Sel)) )
         {
            AddWhere(sWhereString, "([CliDir] = @AV70TFCliDir_Sel)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CliDir]";
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
                     return conditional_P007I2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_P007I3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
               case 2 :
                     return conditional_P007I4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmP007I2;
          prmP007I2 = new Object[] {
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV65TFCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV66TFCliCod_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV67TFCliDsc",GXType.NChar,100,0) ,
          new ParDef("@AV68TFCliDsc_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV69TFCliDir",GXType.NChar,100,0) ,
          new ParDef("@AV70TFCliDir_Sel",GXType.NChar,100,0)
          };
          Object[] prmP007I3;
          prmP007I3 = new Object[] {
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV65TFCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV66TFCliCod_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV67TFCliDsc",GXType.NChar,100,0) ,
          new ParDef("@AV68TFCliDsc_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV69TFCliDir",GXType.NChar,100,0) ,
          new ParDef("@AV70TFCliDir_Sel",GXType.NChar,100,0)
          };
          Object[] prmP007I4;
          prmP007I4 = new Object[] {
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV60FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV65TFCliCod",GXType.NChar,20,0) ,
          new ParDef("@AV66TFCliCod_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV67TFCliDsc",GXType.NChar,100,0) ,
          new ParDef("@AV68TFCliDsc_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV69TFCliDir",GXType.NChar,100,0) ,
          new ParDef("@AV70TFCliDir_Sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007I2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007I3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007I4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007I4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                return;
       }
    }

 }

}
