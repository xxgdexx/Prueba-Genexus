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
   public class wwbusquedaproveedorgetfilterdata : GXProcedure
   {
      public wwbusquedaproveedorgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public wwbusquedaproveedorgetfilterdata( IGxContext context )
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
         this.AV18DDOName = aP0_DDOName;
         this.AV16SearchTxt = aP1_SearchTxt;
         this.AV17SearchTxtTo = aP2_SearchTxtTo;
         this.AV22OptionsJson = "" ;
         this.AV25OptionsDescJson = "" ;
         this.AV27OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV22OptionsJson;
         aP4_OptionsDescJson=this.AV25OptionsDescJson;
         aP5_OptionIndexesJson=this.AV27OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV27OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         wwbusquedaproveedorgetfilterdata objwwbusquedaproveedorgetfilterdata;
         objwwbusquedaproveedorgetfilterdata = new wwbusquedaproveedorgetfilterdata();
         objwwbusquedaproveedorgetfilterdata.AV18DDOName = aP0_DDOName;
         objwwbusquedaproveedorgetfilterdata.AV16SearchTxt = aP1_SearchTxt;
         objwwbusquedaproveedorgetfilterdata.AV17SearchTxtTo = aP2_SearchTxtTo;
         objwwbusquedaproveedorgetfilterdata.AV22OptionsJson = "" ;
         objwwbusquedaproveedorgetfilterdata.AV25OptionsDescJson = "" ;
         objwwbusquedaproveedorgetfilterdata.AV27OptionIndexesJson = "" ;
         objwwbusquedaproveedorgetfilterdata.context.SetSubmitInitialConfig(context);
         objwwbusquedaproveedorgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objwwbusquedaproveedorgetfilterdata);
         aP3_OptionsJson=this.AV22OptionsJson;
         aP4_OptionsDescJson=this.AV25OptionsDescJson;
         aP5_OptionIndexesJson=this.AV27OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((wwbusquedaproveedorgetfilterdata)stateInfo).executePrivate();
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
         AV21Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV18DDOName), "DDO_PRVCOD") == 0 )
         {
            /* Execute user subroutine: 'LOADPRVCODOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV18DDOName), "DDO_PRVDSC") == 0 )
         {
            /* Execute user subroutine: 'LOADPRVDSCOPTIONS' */
            S131 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV18DDOName), "DDO_PRVDIR") == 0 )
         {
            /* Execute user subroutine: 'LOADPRVDIROPTIONS' */
            S141 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV22OptionsJson = AV21Options.ToJSonString(false);
         AV25OptionsDescJson = AV24OptionsDesc.ToJSonString(false);
         AV27OptionIndexesJson = AV26OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get("Generales.WWBusquedaProveedorGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "Generales.WWBusquedaProveedorGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("Generales.WWBusquedaProveedorGridState"), null, "", "");
         }
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV43GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV34FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPRVCOD") == 0 )
            {
               AV35TFPrvCod = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPRVCOD_SEL") == 0 )
            {
               AV36TFPrvCod_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPRVDSC") == 0 )
            {
               AV37TFPrvDsc = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPRVDSC_SEL") == 0 )
            {
               AV38TFPrvDsc_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPRVDIR") == 0 )
            {
               AV39TFPrvDir = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFPRVDIR_SEL") == 0 )
            {
               AV40TFPrvDir_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            AV43GXV1 = (int)(AV43GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPRVCODOPTIONS' Routine */
         returnInSub = false;
         AV35TFPrvCod = AV16SearchTxt;
         AV36TFPrvCod_Sel = "";
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV34FilterFullText ,
                                              AV36TFPrvCod_Sel ,
                                              AV35TFPrvCod ,
                                              AV38TFPrvDsc_Sel ,
                                              AV37TFPrvDsc ,
                                              AV40TFPrvDir_Sel ,
                                              AV39TFPrvDir ,
                                              A244PrvCod ,
                                              A247PrvDsc ,
                                              A1763PrvDir ,
                                              A1777PrvSts } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         });
         lV34FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV34FilterFullText), "%", "");
         lV34FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV34FilterFullText), "%", "");
         lV34FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV34FilterFullText), "%", "");
         lV35TFPrvCod = StringUtil.PadR( StringUtil.RTrim( AV35TFPrvCod), 20, "%");
         lV37TFPrvDsc = StringUtil.PadR( StringUtil.RTrim( AV37TFPrvDsc), 100, "%");
         lV39TFPrvDir = StringUtil.PadR( StringUtil.RTrim( AV39TFPrvDir), 100, "%");
         /* Using cursor P007J2 */
         pr_default.execute(0, new Object[] {lV34FilterFullText, lV34FilterFullText, lV34FilterFullText, lV35TFPrvCod, AV36TFPrvCod_Sel, lV37TFPrvDsc, AV38TFPrvDsc_Sel, lV39TFPrvDir, AV40TFPrvDir_Sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7J2 = false;
            A244PrvCod = P007J2_A244PrvCod[0];
            A1777PrvSts = P007J2_A1777PrvSts[0];
            A1763PrvDir = P007J2_A1763PrvDir[0];
            A247PrvDsc = P007J2_A247PrvDsc[0];
            AV28count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007J2_A244PrvCod[0], A244PrvCod) == 0 ) )
            {
               BRK7J2 = false;
               AV28count = (long)(AV28count+1);
               BRK7J2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A244PrvCod)) )
            {
               AV20Option = A244PrvCod;
               AV23OptionDesc = StringUtil.Trim( StringUtil.RTrim( context.localUtil.Format( A244PrvCod, "@!")));
               AV21Options.Add(AV20Option, 0);
               AV24OptionsDesc.Add(AV23OptionDesc, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV21Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK7J2 )
            {
               BRK7J2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPRVDSCOPTIONS' Routine */
         returnInSub = false;
         AV37TFPrvDsc = AV16SearchTxt;
         AV38TFPrvDsc_Sel = "";
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV34FilterFullText ,
                                              AV36TFPrvCod_Sel ,
                                              AV35TFPrvCod ,
                                              AV38TFPrvDsc_Sel ,
                                              AV37TFPrvDsc ,
                                              AV40TFPrvDir_Sel ,
                                              AV39TFPrvDir ,
                                              A244PrvCod ,
                                              A247PrvDsc ,
                                              A1763PrvDir ,
                                              A1777PrvSts } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         });
         lV34FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV34FilterFullText), "%", "");
         lV34FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV34FilterFullText), "%", "");
         lV34FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV34FilterFullText), "%", "");
         lV35TFPrvCod = StringUtil.PadR( StringUtil.RTrim( AV35TFPrvCod), 20, "%");
         lV37TFPrvDsc = StringUtil.PadR( StringUtil.RTrim( AV37TFPrvDsc), 100, "%");
         lV39TFPrvDir = StringUtil.PadR( StringUtil.RTrim( AV39TFPrvDir), 100, "%");
         /* Using cursor P007J3 */
         pr_default.execute(1, new Object[] {lV34FilterFullText, lV34FilterFullText, lV34FilterFullText, lV35TFPrvCod, AV36TFPrvCod_Sel, lV37TFPrvDsc, AV38TFPrvDsc_Sel, lV39TFPrvDir, AV40TFPrvDir_Sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7J4 = false;
            A247PrvDsc = P007J3_A247PrvDsc[0];
            A1777PrvSts = P007J3_A1777PrvSts[0];
            A1763PrvDir = P007J3_A1763PrvDir[0];
            A244PrvCod = P007J3_A244PrvCod[0];
            AV28count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007J3_A247PrvDsc[0], A247PrvDsc) == 0 ) )
            {
               BRK7J4 = false;
               A244PrvCod = P007J3_A244PrvCod[0];
               AV28count = (long)(AV28count+1);
               BRK7J4 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A247PrvDsc)) )
            {
               AV20Option = A247PrvDsc;
               AV21Options.Add(AV20Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV21Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK7J4 )
            {
               BRK7J4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPRVDIROPTIONS' Routine */
         returnInSub = false;
         AV39TFPrvDir = AV16SearchTxt;
         AV40TFPrvDir_Sel = "";
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV34FilterFullText ,
                                              AV36TFPrvCod_Sel ,
                                              AV35TFPrvCod ,
                                              AV38TFPrvDsc_Sel ,
                                              AV37TFPrvDsc ,
                                              AV40TFPrvDir_Sel ,
                                              AV39TFPrvDir ,
                                              A244PrvCod ,
                                              A247PrvDsc ,
                                              A1763PrvDir ,
                                              A1777PrvSts } ,
                                              new int[]{
                                              TypeConstants.SHORT
                                              }
         });
         lV34FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV34FilterFullText), "%", "");
         lV34FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV34FilterFullText), "%", "");
         lV34FilterFullText = StringUtil.Concat( StringUtil.RTrim( AV34FilterFullText), "%", "");
         lV35TFPrvCod = StringUtil.PadR( StringUtil.RTrim( AV35TFPrvCod), 20, "%");
         lV37TFPrvDsc = StringUtil.PadR( StringUtil.RTrim( AV37TFPrvDsc), 100, "%");
         lV39TFPrvDir = StringUtil.PadR( StringUtil.RTrim( AV39TFPrvDir), 100, "%");
         /* Using cursor P007J4 */
         pr_default.execute(2, new Object[] {lV34FilterFullText, lV34FilterFullText, lV34FilterFullText, lV35TFPrvCod, AV36TFPrvCod_Sel, lV37TFPrvDsc, AV38TFPrvDsc_Sel, lV39TFPrvDir, AV40TFPrvDir_Sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK7J6 = false;
            A1777PrvSts = P007J4_A1777PrvSts[0];
            A1763PrvDir = P007J4_A1763PrvDir[0];
            A247PrvDsc = P007J4_A247PrvDsc[0];
            A244PrvCod = P007J4_A244PrvCod[0];
            AV28count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P007J4_A1763PrvDir[0], A1763PrvDir) == 0 ) )
            {
               BRK7J6 = false;
               A244PrvCod = P007J4_A244PrvCod[0];
               AV28count = (long)(AV28count+1);
               BRK7J6 = true;
               pr_default.readNext(2);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1763PrvDir)) )
            {
               AV20Option = A1763PrvDir;
               AV21Options.Add(AV20Option, 0);
               AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV21Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK7J6 )
            {
               BRK7J6 = true;
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
         AV22OptionsJson = "";
         AV25OptionsDescJson = "";
         AV27OptionIndexesJson = "";
         AV21Options = new GxSimpleCollection<string>();
         AV24OptionsDesc = new GxSimpleCollection<string>();
         AV26OptionIndexes = new GxSimpleCollection<string>();
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29Session = context.GetSession();
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV34FilterFullText = "";
         AV35TFPrvCod = "";
         AV36TFPrvCod_Sel = "";
         AV37TFPrvDsc = "";
         AV38TFPrvDsc_Sel = "";
         AV39TFPrvDir = "";
         AV40TFPrvDir_Sel = "";
         scmdbuf = "";
         lV34FilterFullText = "";
         lV35TFPrvCod = "";
         lV37TFPrvDsc = "";
         lV39TFPrvDir = "";
         A244PrvCod = "";
         A247PrvDsc = "";
         A1763PrvDir = "";
         P007J2_A244PrvCod = new string[] {""} ;
         P007J2_A1777PrvSts = new short[1] ;
         P007J2_A1763PrvDir = new string[] {""} ;
         P007J2_A247PrvDsc = new string[] {""} ;
         AV20Option = "";
         AV23OptionDesc = "";
         P007J3_A247PrvDsc = new string[] {""} ;
         P007J3_A1777PrvSts = new short[1] ;
         P007J3_A1763PrvDir = new string[] {""} ;
         P007J3_A244PrvCod = new string[] {""} ;
         P007J4_A1777PrvSts = new short[1] ;
         P007J4_A1763PrvDir = new string[] {""} ;
         P007J4_A247PrvDsc = new string[] {""} ;
         P007J4_A244PrvCod = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.generales.wwbusquedaproveedorgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007J2_A244PrvCod, P007J2_A1777PrvSts, P007J2_A1763PrvDir, P007J2_A247PrvDsc
               }
               , new Object[] {
               P007J3_A247PrvDsc, P007J3_A1777PrvSts, P007J3_A1763PrvDir, P007J3_A244PrvCod
               }
               , new Object[] {
               P007J4_A1777PrvSts, P007J4_A1763PrvDir, P007J4_A247PrvDsc, P007J4_A244PrvCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A1777PrvSts ;
      private int AV43GXV1 ;
      private long AV28count ;
      private string AV35TFPrvCod ;
      private string AV36TFPrvCod_Sel ;
      private string AV37TFPrvDsc ;
      private string AV38TFPrvDsc_Sel ;
      private string AV39TFPrvDir ;
      private string AV40TFPrvDir_Sel ;
      private string scmdbuf ;
      private string lV35TFPrvCod ;
      private string lV37TFPrvDsc ;
      private string lV39TFPrvDir ;
      private string A244PrvCod ;
      private string A247PrvDsc ;
      private string A1763PrvDir ;
      private bool returnInSub ;
      private bool BRK7J2 ;
      private bool BRK7J4 ;
      private bool BRK7J6 ;
      private string AV22OptionsJson ;
      private string AV25OptionsDescJson ;
      private string AV27OptionIndexesJson ;
      private string AV18DDOName ;
      private string AV16SearchTxt ;
      private string AV17SearchTxtTo ;
      private string AV34FilterFullText ;
      private string lV34FilterFullText ;
      private string AV20Option ;
      private string AV23OptionDesc ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P007J2_A244PrvCod ;
      private short[] P007J2_A1777PrvSts ;
      private string[] P007J2_A1763PrvDir ;
      private string[] P007J2_A247PrvDsc ;
      private string[] P007J3_A247PrvDsc ;
      private short[] P007J3_A1777PrvSts ;
      private string[] P007J3_A1763PrvDir ;
      private string[] P007J3_A244PrvCod ;
      private short[] P007J4_A1777PrvSts ;
      private string[] P007J4_A1763PrvDir ;
      private string[] P007J4_A247PrvDsc ;
      private string[] P007J4_A244PrvCod ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV24OptionsDesc ;
      private GxSimpleCollection<string> AV26OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
   }

   public class wwbusquedaproveedorgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007J2( IGxContext context ,
                                             string AV34FilterFullText ,
                                             string AV36TFPrvCod_Sel ,
                                             string AV35TFPrvCod ,
                                             string AV38TFPrvDsc_Sel ,
                                             string AV37TFPrvDsc ,
                                             string AV40TFPrvDir_Sel ,
                                             string AV39TFPrvDir ,
                                             string A244PrvCod ,
                                             string A247PrvDsc ,
                                             string A1763PrvDir ,
                                             short A1777PrvSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [PrvCod], [PrvSts], [PrvDir], [PrvDsc] FROM [CPPROVEEDORES]";
         AddWhere(sWhereString, "([PrvSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34FilterFullText)) )
         {
            AddWhere(sWhereString, "(( [PrvCod] like '%' + @lV34FilterFullText) or ( [PrvDsc] like '%' + @lV34FilterFullText) or ( [PrvDir] like '%' + @lV34FilterFullText))");
         }
         else
         {
            GXv_int1[0] = 1;
            GXv_int1[1] = 1;
            GXv_int1[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPrvCod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPrvCod)) ) )
         {
            AddWhere(sWhereString, "([PrvCod] like @lV35TFPrvCod)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPrvCod_Sel)) )
         {
            AddWhere(sWhereString, "([PrvCod] = @AV36TFPrvCod_Sel)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPrvDsc_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFPrvDsc)) ) )
         {
            AddWhere(sWhereString, "([PrvDsc] like @lV37TFPrvDsc)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPrvDsc_Sel)) )
         {
            AddWhere(sWhereString, "([PrvDsc] = @AV38TFPrvDsc_Sel)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFPrvDir_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFPrvDir)) ) )
         {
            AddWhere(sWhereString, "([PrvDir] like @lV39TFPrvDir)");
         }
         else
         {
            GXv_int1[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFPrvDir_Sel)) )
         {
            AddWhere(sWhereString, "([PrvDir] = @AV40TFPrvDir_Sel)");
         }
         else
         {
            GXv_int1[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PrvCod]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P007J3( IGxContext context ,
                                             string AV34FilterFullText ,
                                             string AV36TFPrvCod_Sel ,
                                             string AV35TFPrvCod ,
                                             string AV38TFPrvDsc_Sel ,
                                             string AV37TFPrvDsc ,
                                             string AV40TFPrvDir_Sel ,
                                             string AV39TFPrvDir ,
                                             string A244PrvCod ,
                                             string A247PrvDsc ,
                                             string A1763PrvDir ,
                                             short A1777PrvSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[9];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT [PrvDsc], [PrvSts], [PrvDir], [PrvCod] FROM [CPPROVEEDORES]";
         AddWhere(sWhereString, "([PrvSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34FilterFullText)) )
         {
            AddWhere(sWhereString, "(( [PrvCod] like '%' + @lV34FilterFullText) or ( [PrvDsc] like '%' + @lV34FilterFullText) or ( [PrvDir] like '%' + @lV34FilterFullText))");
         }
         else
         {
            GXv_int3[0] = 1;
            GXv_int3[1] = 1;
            GXv_int3[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPrvCod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPrvCod)) ) )
         {
            AddWhere(sWhereString, "([PrvCod] like @lV35TFPrvCod)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPrvCod_Sel)) )
         {
            AddWhere(sWhereString, "([PrvCod] = @AV36TFPrvCod_Sel)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPrvDsc_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFPrvDsc)) ) )
         {
            AddWhere(sWhereString, "([PrvDsc] like @lV37TFPrvDsc)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPrvDsc_Sel)) )
         {
            AddWhere(sWhereString, "([PrvDsc] = @AV38TFPrvDsc_Sel)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFPrvDir_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFPrvDir)) ) )
         {
            AddWhere(sWhereString, "([PrvDir] like @lV39TFPrvDir)");
         }
         else
         {
            GXv_int3[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFPrvDir_Sel)) )
         {
            AddWhere(sWhereString, "([PrvDir] = @AV40TFPrvDir_Sel)");
         }
         else
         {
            GXv_int3[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PrvDsc]";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P007J4( IGxContext context ,
                                             string AV34FilterFullText ,
                                             string AV36TFPrvCod_Sel ,
                                             string AV35TFPrvCod ,
                                             string AV38TFPrvDsc_Sel ,
                                             string AV37TFPrvDsc ,
                                             string AV40TFPrvDir_Sel ,
                                             string AV39TFPrvDir ,
                                             string A244PrvCod ,
                                             string A247PrvDsc ,
                                             string A1763PrvDir ,
                                             short A1777PrvSts )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[9];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT [PrvSts], [PrvDir], [PrvDsc], [PrvCod] FROM [CPPROVEEDORES]";
         AddWhere(sWhereString, "([PrvSts] = 1)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34FilterFullText)) )
         {
            AddWhere(sWhereString, "(( [PrvCod] like '%' + @lV34FilterFullText) or ( [PrvDsc] like '%' + @lV34FilterFullText) or ( [PrvDir] like '%' + @lV34FilterFullText))");
         }
         else
         {
            GXv_int5[0] = 1;
            GXv_int5[1] = 1;
            GXv_int5[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPrvCod_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPrvCod)) ) )
         {
            AddWhere(sWhereString, "([PrvCod] like @lV35TFPrvCod)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFPrvCod_Sel)) )
         {
            AddWhere(sWhereString, "([PrvCod] = @AV36TFPrvCod_Sel)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPrvDsc_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFPrvDsc)) ) )
         {
            AddWhere(sWhereString, "([PrvDsc] like @lV37TFPrvDsc)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPrvDsc_Sel)) )
         {
            AddWhere(sWhereString, "([PrvDsc] = @AV38TFPrvDsc_Sel)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV40TFPrvDir_Sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFPrvDir)) ) )
         {
            AddWhere(sWhereString, "([PrvDir] like @lV39TFPrvDir)");
         }
         else
         {
            GXv_int5[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFPrvDir_Sel)) )
         {
            AddWhere(sWhereString, "([PrvDir] = @AV40TFPrvDir_Sel)");
         }
         else
         {
            GXv_int5[8] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PrvDir]";
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
                     return conditional_P007J2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_P007J3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
               case 2 :
                     return conditional_P007J4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmP007J2;
          prmP007J2 = new Object[] {
          new ParDef("@lV34FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV34FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV34FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV35TFPrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV36TFPrvCod_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV37TFPrvDsc",GXType.NChar,100,0) ,
          new ParDef("@AV38TFPrvDsc_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV39TFPrvDir",GXType.NChar,100,0) ,
          new ParDef("@AV40TFPrvDir_Sel",GXType.NChar,100,0)
          };
          Object[] prmP007J3;
          prmP007J3 = new Object[] {
          new ParDef("@lV34FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV34FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV34FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV35TFPrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV36TFPrvCod_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV37TFPrvDsc",GXType.NChar,100,0) ,
          new ParDef("@AV38TFPrvDsc_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV39TFPrvDir",GXType.NChar,100,0) ,
          new ParDef("@AV40TFPrvDir_Sel",GXType.NChar,100,0)
          };
          Object[] prmP007J4;
          prmP007J4 = new Object[] {
          new ParDef("@lV34FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV34FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV34FilterFullText",GXType.NVarChar,100,0) ,
          new ParDef("@lV35TFPrvCod",GXType.NChar,20,0) ,
          new ParDef("@AV36TFPrvCod_Sel",GXType.NChar,20,0) ,
          new ParDef("@lV37TFPrvDsc",GXType.NChar,100,0) ,
          new ParDef("@AV38TFPrvDsc_Sel",GXType.NChar,100,0) ,
          new ParDef("@lV39TFPrvDir",GXType.NChar,100,0) ,
          new ParDef("@AV40TFPrvDir_Sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007J4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J4,100, GxCacheFrequency.OFF ,true,false )
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
