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
namespace GeneXus.Programs.wwpbaseobjects {
   public class menuitemwwgetfilterdata : GXProcedure
   {
      public menuitemwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public menuitemwwgetfilterdata( IGxContext context )
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
         menuitemwwgetfilterdata objmenuitemwwgetfilterdata;
         objmenuitemwwgetfilterdata = new menuitemwwgetfilterdata();
         objmenuitemwwgetfilterdata.AV21DDOName = aP0_DDOName;
         objmenuitemwwgetfilterdata.AV19SearchTxt = aP1_SearchTxt;
         objmenuitemwwgetfilterdata.AV20SearchTxtTo = aP2_SearchTxtTo;
         objmenuitemwwgetfilterdata.AV25OptionsJson = "" ;
         objmenuitemwwgetfilterdata.AV28OptionsDescJson = "" ;
         objmenuitemwwgetfilterdata.AV30OptionIndexesJson = "" ;
         objmenuitemwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objmenuitemwwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmenuitemwwgetfilterdata);
         aP3_OptionsJson=this.AV25OptionsJson;
         aP4_OptionsDescJson=this.AV28OptionsDescJson;
         aP5_OptionIndexesJson=this.AV30OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((menuitemwwgetfilterdata)stateInfo).executePrivate();
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
         if ( StringUtil.StrCmp(StringUtil.Upper( AV21DDOName), "DDO_MENUITEMCAPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADMENUITEMCAPTIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(StringUtil.Upper( AV21DDOName), "DDO_MENUITEMFATHERCAPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADMENUITEMFATHERCAPTIONOPTIONS' */
            S131 ();
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
         if ( StringUtil.StrCmp(AV32Session.Get("WWPBaseObjects.MenuItemWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.MenuItemWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("WWPBaseObjects.MenuItemWWGridState"), null, "", "");
         }
         AV43GXV1 = 1;
         while ( AV43GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV43GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMENUITEMORDER") == 0 )
            {
               AV39TFMenuItemOrder = (short)(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."));
               AV40TFMenuItemOrder_To = (short)(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMENUITEMCAPTION") == 0 )
            {
               AV13TFMenuItemCaption = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMENUITEMCAPTION_SEL") == 0 )
            {
               AV14TFMenuItemCaption_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMENUITEMTYPE_SEL") == 0 )
            {
               AV15TFMenuItemType_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV16TFMenuItemType_Sels.FromJSonString(AV15TFMenuItemType_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMENUITEMFATHERCAPTION") == 0 )
            {
               AV17TFMenuItemFatherCaption = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFMENUITEMFATHERCAPTION_SEL") == 0 )
            {
               AV18TFMenuItemFatherCaption_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "PARM_&MENUITEMFATHERID") == 0 )
            {
               AV37MenuItemFatherId = (short)(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."));
            }
            AV43GXV1 = (int)(AV43GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADMENUITEMCAPTIONOPTIONS' Routine */
         returnInSub = false;
         AV13TFMenuItemCaption = AV19SearchTxt;
         AV14TFMenuItemCaption_Sel = "";
         AV45Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder = AV39TFMenuItemOrder;
         AV46Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to = AV40TFMenuItemOrder_To;
         AV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = AV13TFMenuItemCaption;
         AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel = AV14TFMenuItemCaption_Sel;
         AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels = AV16TFMenuItemType_Sels;
         AV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = AV17TFMenuItemFatherCaption;
         AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel = AV18TFMenuItemFatherCaption_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A352MenuItemId ,
                                              AV38MenuItemIdCollection ,
                                              A1232MenuItemType ,
                                              AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels ,
                                              AV45Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder ,
                                              AV46Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to ,
                                              AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel ,
                                              AV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption ,
                                              AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels.Count ,
                                              AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel ,
                                              AV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption ,
                                              A1229MenuItemOrder ,
                                              A1222MenuItemCaption ,
                                              A1223MenuItemFatherCaption } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = StringUtil.Concat( StringUtil.RTrim( AV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption), "%", "");
         lV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = StringUtil.Concat( StringUtil.RTrim( AV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption), "%", "");
         /* Using cursor P00222 */
         pr_default.execute(0, new Object[] {AV45Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder, AV46Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to, lV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption, AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel, lV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption, AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK222 = false;
            A353MenuItemFatherId = P00222_A353MenuItemFatherId[0];
            n353MenuItemFatherId = P00222_n353MenuItemFatherId[0];
            A1222MenuItemCaption = P00222_A1222MenuItemCaption[0];
            A352MenuItemId = P00222_A352MenuItemId[0];
            A1223MenuItemFatherCaption = P00222_A1223MenuItemFatherCaption[0];
            A1232MenuItemType = P00222_A1232MenuItemType[0];
            A1229MenuItemOrder = P00222_A1229MenuItemOrder[0];
            A1223MenuItemFatherCaption = P00222_A1223MenuItemFatherCaption[0];
            AV31count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00222_A1222MenuItemCaption[0], A1222MenuItemCaption) == 0 ) )
            {
               BRK222 = false;
               A352MenuItemId = P00222_A352MenuItemId[0];
               if ( (AV38MenuItemIdCollection.IndexOf(A352MenuItemId)>0) )
               {
                  AV31count = (long)(AV31count+1);
               }
               BRK222 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1222MenuItemCaption)) )
            {
               AV23Option = A1222MenuItemCaption;
               AV24Options.Add(AV23Option, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV24Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK222 )
            {
               BRK222 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMENUITEMFATHERCAPTIONOPTIONS' Routine */
         returnInSub = false;
         AV17TFMenuItemFatherCaption = AV19SearchTxt;
         AV18TFMenuItemFatherCaption_Sel = "";
         AV45Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder = AV39TFMenuItemOrder;
         AV46Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to = AV40TFMenuItemOrder_To;
         AV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = AV13TFMenuItemCaption;
         AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel = AV14TFMenuItemCaption_Sel;
         AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels = AV16TFMenuItemType_Sels;
         AV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = AV17TFMenuItemFatherCaption;
         AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel = AV18TFMenuItemFatherCaption_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A352MenuItemId ,
                                              AV38MenuItemIdCollection ,
                                              A1232MenuItemType ,
                                              AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels ,
                                              AV45Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder ,
                                              AV46Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to ,
                                              AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel ,
                                              AV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption ,
                                              AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels.Count ,
                                              AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel ,
                                              AV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption ,
                                              A1229MenuItemOrder ,
                                              A1222MenuItemCaption ,
                                              A1223MenuItemFatherCaption } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = StringUtil.Concat( StringUtil.RTrim( AV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption), "%", "");
         lV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = StringUtil.Concat( StringUtil.RTrim( AV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption), "%", "");
         /* Using cursor P00223 */
         pr_default.execute(1, new Object[] {AV45Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder, AV46Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to, lV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption, AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel, lV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption, AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK224 = false;
            A353MenuItemFatherId = P00223_A353MenuItemFatherId[0];
            n353MenuItemFatherId = P00223_n353MenuItemFatherId[0];
            A1223MenuItemFatherCaption = P00223_A1223MenuItemFatherCaption[0];
            A352MenuItemId = P00223_A352MenuItemId[0];
            A1232MenuItemType = P00223_A1232MenuItemType[0];
            A1222MenuItemCaption = P00223_A1222MenuItemCaption[0];
            A1229MenuItemOrder = P00223_A1229MenuItemOrder[0];
            A1223MenuItemFatherCaption = P00223_A1223MenuItemFatherCaption[0];
            AV31count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00223_A1223MenuItemFatherCaption[0], A1223MenuItemFatherCaption) == 0 ) )
            {
               BRK224 = false;
               A353MenuItemFatherId = P00223_A353MenuItemFatherId[0];
               n353MenuItemFatherId = P00223_n353MenuItemFatherId[0];
               A352MenuItemId = P00223_A352MenuItemId[0];
               if ( (AV38MenuItemIdCollection.IndexOf(A352MenuItemId)>0) )
               {
                  AV31count = (long)(AV31count+1);
               }
               BRK224 = true;
               pr_default.readNext(1);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1223MenuItemFatherCaption)) )
            {
               AV23Option = A1223MenuItemFatherCaption;
               AV24Options.Add(AV23Option, 0);
               AV29OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV24Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK224 )
            {
               BRK224 = true;
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
         AV13TFMenuItemCaption = "";
         AV14TFMenuItemCaption_Sel = "";
         AV15TFMenuItemType_SelsJson = "";
         AV16TFMenuItemType_Sels = new GxSimpleCollection<short>();
         AV17TFMenuItemFatherCaption = "";
         AV18TFMenuItemFatherCaption_Sel = "";
         AV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = "";
         AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel = "";
         AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels = new GxSimpleCollection<short>();
         AV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = "";
         AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel = "";
         scmdbuf = "";
         lV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption = "";
         lV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption = "";
         AV38MenuItemIdCollection = new GxSimpleCollection<short>();
         A1222MenuItemCaption = "";
         A1223MenuItemFatherCaption = "";
         P00222_A353MenuItemFatherId = new short[1] ;
         P00222_n353MenuItemFatherId = new bool[] {false} ;
         P00222_A1222MenuItemCaption = new string[] {""} ;
         P00222_A352MenuItemId = new short[1] ;
         P00222_A1223MenuItemFatherCaption = new string[] {""} ;
         P00222_A1232MenuItemType = new short[1] ;
         P00222_A1229MenuItemOrder = new short[1] ;
         AV23Option = "";
         P00223_A353MenuItemFatherId = new short[1] ;
         P00223_n353MenuItemFatherId = new bool[] {false} ;
         P00223_A1223MenuItemFatherCaption = new string[] {""} ;
         P00223_A352MenuItemId = new short[1] ;
         P00223_A1232MenuItemType = new short[1] ;
         P00223_A1222MenuItemCaption = new string[] {""} ;
         P00223_A1229MenuItemOrder = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.menuitemwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00222_A353MenuItemFatherId, P00222_n353MenuItemFatherId, P00222_A1222MenuItemCaption, P00222_A352MenuItemId, P00222_A1223MenuItemFatherCaption, P00222_A1232MenuItemType, P00222_A1229MenuItemOrder
               }
               , new Object[] {
               P00223_A353MenuItemFatherId, P00223_n353MenuItemFatherId, P00223_A1223MenuItemFatherCaption, P00223_A352MenuItemId, P00223_A1232MenuItemType, P00223_A1222MenuItemCaption, P00223_A1229MenuItemOrder
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV39TFMenuItemOrder ;
      private short AV40TFMenuItemOrder_To ;
      private short AV37MenuItemFatherId ;
      private short AV45Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder ;
      private short AV46Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to ;
      private short A352MenuItemId ;
      private short A1232MenuItemType ;
      private short A1229MenuItemOrder ;
      private short A353MenuItemFatherId ;
      private int AV43GXV1 ;
      private int AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels_Count ;
      private long AV31count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool BRK222 ;
      private bool n353MenuItemFatherId ;
      private bool BRK224 ;
      private string AV25OptionsJson ;
      private string AV28OptionsDescJson ;
      private string AV30OptionIndexesJson ;
      private string AV15TFMenuItemType_SelsJson ;
      private string AV21DDOName ;
      private string AV19SearchTxt ;
      private string AV20SearchTxtTo ;
      private string AV13TFMenuItemCaption ;
      private string AV14TFMenuItemCaption_Sel ;
      private string AV17TFMenuItemFatherCaption ;
      private string AV18TFMenuItemFatherCaption_Sel ;
      private string AV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption ;
      private string AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel ;
      private string AV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption ;
      private string AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel ;
      private string lV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption ;
      private string lV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption ;
      private string A1222MenuItemCaption ;
      private string A1223MenuItemFatherCaption ;
      private string AV23Option ;
      private GxSimpleCollection<short> AV16TFMenuItemType_Sels ;
      private GxSimpleCollection<short> AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels ;
      private GxSimpleCollection<short> AV38MenuItemIdCollection ;
      private IGxSession AV32Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00222_A353MenuItemFatherId ;
      private bool[] P00222_n353MenuItemFatherId ;
      private string[] P00222_A1222MenuItemCaption ;
      private short[] P00222_A352MenuItemId ;
      private string[] P00222_A1223MenuItemFatherCaption ;
      private short[] P00222_A1232MenuItemType ;
      private short[] P00222_A1229MenuItemOrder ;
      private short[] P00223_A353MenuItemFatherId ;
      private bool[] P00223_n353MenuItemFatherId ;
      private string[] P00223_A1223MenuItemFatherCaption ;
      private short[] P00223_A352MenuItemId ;
      private short[] P00223_A1232MenuItemType ;
      private string[] P00223_A1222MenuItemCaption ;
      private short[] P00223_A1229MenuItemOrder ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV24Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV29OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
   }

   public class menuitemwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00222( IGxContext context ,
                                             short A352MenuItemId ,
                                             GxSimpleCollection<short> AV38MenuItemIdCollection ,
                                             short A1232MenuItemType ,
                                             GxSimpleCollection<short> AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels ,
                                             short AV45Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder ,
                                             short AV46Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to ,
                                             string AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel ,
                                             string AV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption ,
                                             int AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels_Count ,
                                             string AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel ,
                                             string AV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption ,
                                             short A1229MenuItemOrder ,
                                             string A1222MenuItemCaption ,
                                             string A1223MenuItemFatherCaption )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[6];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[MenuItemFatherId] AS MenuItemFatherId, T1.[MenuItemCaption], T1.[MenuItemId], T2.[MenuItemCaption] AS MenuItemFatherCaption, T1.[MenuItemType], T1.[MenuItemOrder] FROM ([SIGERPMenu] T1 LEFT JOIN [SIGERPMenu] T2 ON T2.[MenuItemId] = T1.[MenuItemFatherId])";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV38MenuItemIdCollection, "T1.[MenuItemId] IN (", ")")+")");
         if ( ! (0==AV45Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemOrder] >= @AV45Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (0==AV46Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemOrder] <= @AV46Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption)) ) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemCaption] like @lV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel)) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemCaption] = @AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels, "T1.[MenuItemType] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption)) ) )
         {
            AddWhere(sWhereString, "(T2.[MenuItemCaption] like @lV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel)) )
         {
            AddWhere(sWhereString, "(T2.[MenuItemCaption] = @AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[MenuItemCaption]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_P00223( IGxContext context ,
                                             short A352MenuItemId ,
                                             GxSimpleCollection<short> AV38MenuItemIdCollection ,
                                             short A1232MenuItemType ,
                                             GxSimpleCollection<short> AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels ,
                                             short AV45Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder ,
                                             short AV46Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to ,
                                             string AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel ,
                                             string AV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption ,
                                             int AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels_Count ,
                                             string AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel ,
                                             string AV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption ,
                                             short A1229MenuItemOrder ,
                                             string A1222MenuItemCaption ,
                                             string A1223MenuItemFatherCaption )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T1.[MenuItemFatherId] AS MenuItemFatherId, T2.[MenuItemCaption] AS MenuItemFatherCaption, T1.[MenuItemId], T1.[MenuItemType], T1.[MenuItemCaption], T1.[MenuItemOrder] FROM ([SIGERPMenu] T1 LEFT JOIN [SIGERPMenu] T2 ON T2.[MenuItemId] = T1.[MenuItemFatherId])";
         AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV38MenuItemIdCollection, "T1.[MenuItemId] IN (", ")")+")");
         if ( ! (0==AV45Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemOrder] >= @AV45Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (0==AV46Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemOrder] <= @AV46Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption)) ) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemCaption] like @lV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel)) )
         {
            AddWhere(sWhereString, "(T1.[MenuItemCaption] = @AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV49Wwpbaseobjects_menuitemwwds_5_tfmenuitemtype_sels, "T1.[MenuItemType] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption)) ) )
         {
            AddWhere(sWhereString, "(T2.[MenuItemCaption] like @lV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel)) )
         {
            AddWhere(sWhereString, "(T2.[MenuItemCaption] = @AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[MenuItemCaption]";
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
                     return conditional_P00222(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
               case 1 :
                     return conditional_P00223(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (short)dynConstraints[2] , (GxSimpleCollection<short>)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] );
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
          Object[] prmP00222;
          prmP00222 = new Object[] {
          new ParDef("@AV45Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder",GXType.Int16,4,0) ,
          new ParDef("@AV46Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to",GXType.Int16,4,0) ,
          new ParDef("@lV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption",GXType.NVarChar,40,0) ,
          new ParDef("@AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel",GXType.NVarChar,40,0) ,
          new ParDef("@lV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption",GXType.NVarChar,40,0) ,
          new ParDef("@AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel",GXType.NVarChar,40,0)
          };
          Object[] prmP00223;
          prmP00223 = new Object[] {
          new ParDef("@AV45Wwpbaseobjects_menuitemwwds_1_tfmenuitemorder",GXType.Int16,4,0) ,
          new ParDef("@AV46Wwpbaseobjects_menuitemwwds_2_tfmenuitemorder_to",GXType.Int16,4,0) ,
          new ParDef("@lV47Wwpbaseobjects_menuitemwwds_3_tfmenuitemcaption",GXType.NVarChar,40,0) ,
          new ParDef("@AV48Wwpbaseobjects_menuitemwwds_4_tfmenuitemcaption_sel",GXType.NVarChar,40,0) ,
          new ParDef("@lV50Wwpbaseobjects_menuitemwwds_6_tfmenuitemfathercaption",GXType.NVarChar,40,0) ,
          new ParDef("@AV51Wwpbaseobjects_menuitemwwds_7_tfmenuitemfathercaption_sel",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00222", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00222,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00223", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00223,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
       }
    }

 }

}
