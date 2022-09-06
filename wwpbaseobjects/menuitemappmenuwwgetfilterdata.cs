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
   public class menuitemappmenuwwgetfilterdata : GXProcedure
   {
      public menuitemappmenuwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public menuitemappmenuwwgetfilterdata( IGxContext context )
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
         this.AV17DDOName = aP0_DDOName;
         this.AV15SearchTxt = aP1_SearchTxt;
         this.AV16SearchTxtTo = aP2_SearchTxtTo;
         this.AV21OptionsJson = "" ;
         this.AV24OptionsDescJson = "" ;
         this.AV26OptionIndexesJson = "" ;
         initialize();
         executePrivate();
         aP3_OptionsJson=this.AV21OptionsJson;
         aP4_OptionsDescJson=this.AV24OptionsDescJson;
         aP5_OptionIndexesJson=this.AV26OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxt ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxt, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV26OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxt ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         menuitemappmenuwwgetfilterdata objmenuitemappmenuwwgetfilterdata;
         objmenuitemappmenuwwgetfilterdata = new menuitemappmenuwwgetfilterdata();
         objmenuitemappmenuwwgetfilterdata.AV17DDOName = aP0_DDOName;
         objmenuitemappmenuwwgetfilterdata.AV15SearchTxt = aP1_SearchTxt;
         objmenuitemappmenuwwgetfilterdata.AV16SearchTxtTo = aP2_SearchTxtTo;
         objmenuitemappmenuwwgetfilterdata.AV21OptionsJson = "" ;
         objmenuitemappmenuwwgetfilterdata.AV24OptionsDescJson = "" ;
         objmenuitemappmenuwwgetfilterdata.AV26OptionIndexesJson = "" ;
         objmenuitemappmenuwwgetfilterdata.context.SetSubmitInitialConfig(context);
         objmenuitemappmenuwwgetfilterdata.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmenuitemappmenuwwgetfilterdata);
         aP3_OptionsJson=this.AV21OptionsJson;
         aP4_OptionsDescJson=this.AV24OptionsDescJson;
         aP5_OptionIndexesJson=this.AV26OptionIndexesJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((menuitemappmenuwwgetfilterdata)stateInfo).executePrivate();
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
         AV20Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S111 ();
         if ( returnInSub )
         {
            this.cleanup();
            if (true) return;
         }
         if ( StringUtil.StrCmp(StringUtil.Upper( AV17DDOName), "DDO_MENUITEMCAPTION") == 0 )
         {
            /* Execute user subroutine: 'LOADMENUITEMCAPTIONOPTIONS' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         AV21OptionsJson = AV20Options.ToJSonString(false);
         AV24OptionsDescJson = AV23OptionsDesc.ToJSonString(false);
         AV26OptionIndexesJson = AV25OptionIndexes.ToJSonString(false);
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("WWPBaseObjects.MenuItemAppMenuWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.MenuItemAppMenuWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("WWPBaseObjects.MenuItemAppMenuWWGridState"), null, "", "");
         }
         AV36GXV1 = 1;
         while ( AV36GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV36GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFMENUITEMCAPTION") == 0 )
            {
               AV11TFMenuItemCaption = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFMENUITEMCAPTION_SEL") == 0 )
            {
               AV12TFMenuItemCaption_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV36GXV1 = (int)(AV36GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADMENUITEMCAPTIONOPTIONS' Routine */
         returnInSub = false;
         AV11TFMenuItemCaption = AV15SearchTxt;
         AV12TFMenuItemCaption_Sel = "";
         AV38Wwpbaseobjects_menuitemappmenuwwds_1_tfmenuitemcaption = AV11TFMenuItemCaption;
         AV39Wwpbaseobjects_menuitemappmenuwwds_2_tfmenuitemcaption_sel = AV12TFMenuItemCaption_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV39Wwpbaseobjects_menuitemappmenuwwds_2_tfmenuitemcaption_sel ,
                                              AV38Wwpbaseobjects_menuitemappmenuwwds_1_tfmenuitemcaption ,
                                              A1222MenuItemCaption ,
                                              A353MenuItemFatherId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV38Wwpbaseobjects_menuitemappmenuwwds_1_tfmenuitemcaption = StringUtil.Concat( StringUtil.RTrim( AV38Wwpbaseobjects_menuitemappmenuwwds_1_tfmenuitemcaption), "%", "");
         /* Using cursor P001Y2 */
         pr_default.execute(0, new Object[] {lV38Wwpbaseobjects_menuitemappmenuwwds_1_tfmenuitemcaption, AV39Wwpbaseobjects_menuitemappmenuwwds_2_tfmenuitemcaption_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK1Y2 = false;
            A1222MenuItemCaption = P001Y2_A1222MenuItemCaption[0];
            A353MenuItemFatherId = P001Y2_A353MenuItemFatherId[0];
            n353MenuItemFatherId = P001Y2_n353MenuItemFatherId[0];
            A352MenuItemId = P001Y2_A352MenuItemId[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P001Y2_A1222MenuItemCaption[0], A1222MenuItemCaption) == 0 ) )
            {
               BRK1Y2 = false;
               A352MenuItemId = P001Y2_A352MenuItemId[0];
               AV27count = (long)(AV27count+1);
               BRK1Y2 = true;
               pr_default.readNext(0);
            }
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A1222MenuItemCaption)) )
            {
               AV19Option = A1222MenuItemCaption;
               AV20Options.Add(AV19Option, 0);
               AV25OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
            }
            if ( AV20Options.Count == 50 )
            {
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            if ( ! BRK1Y2 )
            {
               BRK1Y2 = true;
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
         AV21OptionsJson = "";
         AV24OptionsDescJson = "";
         AV26OptionIndexesJson = "";
         AV20Options = new GxSimpleCollection<string>();
         AV23OptionsDesc = new GxSimpleCollection<string>();
         AV25OptionIndexes = new GxSimpleCollection<string>();
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV28Session = context.GetSession();
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV11TFMenuItemCaption = "";
         AV12TFMenuItemCaption_Sel = "";
         AV38Wwpbaseobjects_menuitemappmenuwwds_1_tfmenuitemcaption = "";
         AV39Wwpbaseobjects_menuitemappmenuwwds_2_tfmenuitemcaption_sel = "";
         scmdbuf = "";
         lV38Wwpbaseobjects_menuitemappmenuwwds_1_tfmenuitemcaption = "";
         A1222MenuItemCaption = "";
         P001Y2_A1222MenuItemCaption = new string[] {""} ;
         P001Y2_A353MenuItemFatherId = new short[1] ;
         P001Y2_n353MenuItemFatherId = new bool[] {false} ;
         P001Y2_A352MenuItemId = new short[1] ;
         AV19Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.menuitemappmenuwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P001Y2_A1222MenuItemCaption, P001Y2_A353MenuItemFatherId, P001Y2_n353MenuItemFatherId, P001Y2_A352MenuItemId
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short A353MenuItemFatherId ;
      private short A352MenuItemId ;
      private int AV36GXV1 ;
      private long AV27count ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool BRK1Y2 ;
      private bool n353MenuItemFatherId ;
      private string AV21OptionsJson ;
      private string AV24OptionsDescJson ;
      private string AV26OptionIndexesJson ;
      private string AV17DDOName ;
      private string AV15SearchTxt ;
      private string AV16SearchTxtTo ;
      private string AV11TFMenuItemCaption ;
      private string AV12TFMenuItemCaption_Sel ;
      private string AV38Wwpbaseobjects_menuitemappmenuwwds_1_tfmenuitemcaption ;
      private string AV39Wwpbaseobjects_menuitemappmenuwwds_2_tfmenuitemcaption_sel ;
      private string lV38Wwpbaseobjects_menuitemappmenuwwds_1_tfmenuitemcaption ;
      private string A1222MenuItemCaption ;
      private string AV19Option ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P001Y2_A1222MenuItemCaption ;
      private short[] P001Y2_A353MenuItemFatherId ;
      private bool[] P001Y2_n353MenuItemFatherId ;
      private short[] P001Y2_A352MenuItemId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
      private GxSimpleCollection<string> AV20Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV25OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
   }

   public class menuitemappmenuwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001Y2( IGxContext context ,
                                             string AV39Wwpbaseobjects_menuitemappmenuwwds_2_tfmenuitemcaption_sel ,
                                             string AV38Wwpbaseobjects_menuitemappmenuwwds_1_tfmenuitemcaption ,
                                             string A1222MenuItemCaption ,
                                             short A353MenuItemFatherId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[2];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [MenuItemCaption], [MenuItemFatherId], [MenuItemId] FROM [SIGERPMenu]";
         AddWhere(sWhereString, "([MenuItemFatherId] IS NULL)");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39Wwpbaseobjects_menuitemappmenuwwds_2_tfmenuitemcaption_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38Wwpbaseobjects_menuitemappmenuwwds_1_tfmenuitemcaption)) ) )
         {
            AddWhere(sWhereString, "([MenuItemCaption] like @lV38Wwpbaseobjects_menuitemappmenuwwds_1_tfmenuitemcaption)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39Wwpbaseobjects_menuitemappmenuwwds_2_tfmenuitemcaption_sel)) )
         {
            AddWhere(sWhereString, "([MenuItemCaption] = @AV39Wwpbaseobjects_menuitemappmenuwwds_2_tfmenuitemcaption_sel)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MenuItemCaption]";
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
                     return conditional_P001Y2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] );
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
          Object[] prmP001Y2;
          prmP001Y2 = new Object[] {
          new ParDef("@lV38Wwpbaseobjects_menuitemappmenuwwds_1_tfmenuitemcaption",GXType.NVarChar,40,0) ,
          new ParDef("@AV39Wwpbaseobjects_menuitemappmenuwwds_2_tfmenuitemcaption_sel",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001Y2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
