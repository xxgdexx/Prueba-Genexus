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
   public class menuitemloaddvcombo : GXProcedure
   {
      public menuitemloaddvcombo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public menuitemloaddvcombo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ComboName ,
                           string aP1_TrnMode ,
                           bool aP2_IsDynamicCall ,
                           short aP3_MenuItemId ,
                           string aP4_SearchTxt ,
                           out string aP5_SelectedValue ,
                           out string aP6_SelectedText ,
                           out string aP7_Combo_DataJson )
      {
         this.AV16ComboName = aP0_ComboName;
         this.AV18TrnMode = aP1_TrnMode;
         this.AV21IsDynamicCall = aP2_IsDynamicCall;
         this.AV24MenuItemId = aP3_MenuItemId;
         this.AV11SearchTxt = aP4_SearchTxt;
         this.AV15SelectedValue = "" ;
         this.AV20SelectedText = "" ;
         this.AV12Combo_DataJson = "" ;
         initialize();
         executePrivate();
         aP5_SelectedValue=this.AV15SelectedValue;
         aP6_SelectedText=this.AV20SelectedText;
         aP7_Combo_DataJson=this.AV12Combo_DataJson;
      }

      public string executeUdp( string aP0_ComboName ,
                                string aP1_TrnMode ,
                                bool aP2_IsDynamicCall ,
                                short aP3_MenuItemId ,
                                string aP4_SearchTxt ,
                                out string aP5_SelectedValue ,
                                out string aP6_SelectedText )
      {
         execute(aP0_ComboName, aP1_TrnMode, aP2_IsDynamicCall, aP3_MenuItemId, aP4_SearchTxt, out aP5_SelectedValue, out aP6_SelectedText, out aP7_Combo_DataJson);
         return AV12Combo_DataJson ;
      }

      public void executeSubmit( string aP0_ComboName ,
                                 string aP1_TrnMode ,
                                 bool aP2_IsDynamicCall ,
                                 short aP3_MenuItemId ,
                                 string aP4_SearchTxt ,
                                 out string aP5_SelectedValue ,
                                 out string aP6_SelectedText ,
                                 out string aP7_Combo_DataJson )
      {
         menuitemloaddvcombo objmenuitemloaddvcombo;
         objmenuitemloaddvcombo = new menuitemloaddvcombo();
         objmenuitemloaddvcombo.AV16ComboName = aP0_ComboName;
         objmenuitemloaddvcombo.AV18TrnMode = aP1_TrnMode;
         objmenuitemloaddvcombo.AV21IsDynamicCall = aP2_IsDynamicCall;
         objmenuitemloaddvcombo.AV24MenuItemId = aP3_MenuItemId;
         objmenuitemloaddvcombo.AV11SearchTxt = aP4_SearchTxt;
         objmenuitemloaddvcombo.AV15SelectedValue = "" ;
         objmenuitemloaddvcombo.AV20SelectedText = "" ;
         objmenuitemloaddvcombo.AV12Combo_DataJson = "" ;
         objmenuitemloaddvcombo.context.SetSubmitInitialConfig(context);
         objmenuitemloaddvcombo.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmenuitemloaddvcombo);
         aP5_SelectedValue=this.AV15SelectedValue;
         aP6_SelectedText=this.AV20SelectedText;
         aP7_Combo_DataJson=this.AV12Combo_DataJson;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((menuitemloaddvcombo)stateInfo).executePrivate();
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
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10MaxItems = 100;
         if ( StringUtil.StrCmp(AV16ComboName, "MenuItemFatherId") == 0 )
         {
            /* Execute user subroutine: 'LOADCOMBOITEMS_MENUITEMFATHERID' */
            S111 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADCOMBOITEMS_MENUITEMFATHERID' Routine */
         returnInSub = false;
         if ( AV21IsDynamicCall )
         {
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11SearchTxt ,
                                                 A1222MenuItemCaption } ,
                                                 new int[]{
                                                 }
            });
            lV11SearchTxt = StringUtil.Concat( StringUtil.RTrim( AV11SearchTxt), "%", "");
            /* Using cursor P001F2 */
            pr_default.execute(0, new Object[] {lV11SearchTxt});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A1222MenuItemCaption = P001F2_A1222MenuItemCaption[0];
               A352MenuItemId = P001F2_A352MenuItemId[0];
               AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
               AV14Combo_DataItem.gxTpr_Id = StringUtil.Trim( StringUtil.Str( (decimal)(A352MenuItemId), 4, 0));
               AV14Combo_DataItem.gxTpr_Title = A1222MenuItemCaption;
               AV13Combo_Data.Add(AV14Combo_DataItem, 0);
               if ( AV13Combo_Data.Count > AV10MaxItems )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            AV12Combo_DataJson = AV13Combo_Data.ToJSonString(false);
         }
         else
         {
            if ( StringUtil.StrCmp(AV18TrnMode, "INS") != 0 )
            {
               if ( StringUtil.StrCmp(AV18TrnMode, "GET") != 0 )
               {
                  /* Using cursor P001F3 */
                  pr_default.execute(1, new Object[] {AV24MenuItemId});
                  while ( (pr_default.getStatus(1) != 101) )
                  {
                     A352MenuItemId = P001F3_A352MenuItemId[0];
                     A353MenuItemFatherId = P001F3_A353MenuItemFatherId[0];
                     n353MenuItemFatherId = P001F3_n353MenuItemFatherId[0];
                     AV15SelectedValue = ((0==A353MenuItemFatherId) ? "" : StringUtil.Trim( StringUtil.Str( (decimal)(A353MenuItemFatherId), 4, 0)));
                     AV23MenuItemIdAux = A353MenuItemFatherId;
                     /* Exiting from a For First loop. */
                     if (true) break;
                  }
                  pr_default.close(1);
               }
               else
               {
                  AV23MenuItemIdAux = (short)(NumberUtil.Val( AV11SearchTxt, "."));
               }
               /* Using cursor P001F4 */
               pr_default.execute(2, new Object[] {AV23MenuItemIdAux});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A352MenuItemId = P001F4_A352MenuItemId[0];
                  A1222MenuItemCaption = P001F4_A1222MenuItemCaption[0];
                  AV20SelectedText = A1222MenuItemCaption;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
            }
         }
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
         AV15SelectedValue = "";
         AV20SelectedText = "";
         AV12Combo_DataJson = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         lV11SearchTxt = "";
         A1222MenuItemCaption = "";
         P001F2_A1222MenuItemCaption = new string[] {""} ;
         P001F2_A352MenuItemId = new short[1] ;
         AV14Combo_DataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item(context);
         AV13Combo_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         P001F3_A352MenuItemId = new short[1] ;
         P001F3_A353MenuItemFatherId = new short[1] ;
         P001F3_n353MenuItemFatherId = new bool[] {false} ;
         P001F4_A352MenuItemId = new short[1] ;
         P001F4_A1222MenuItemCaption = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.menuitemloaddvcombo__default(),
            new Object[][] {
                new Object[] {
               P001F2_A1222MenuItemCaption, P001F2_A352MenuItemId
               }
               , new Object[] {
               P001F3_A352MenuItemId, P001F3_A353MenuItemFatherId, P001F3_n353MenuItemFatherId
               }
               , new Object[] {
               P001F4_A352MenuItemId, P001F4_A1222MenuItemCaption
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV24MenuItemId ;
      private short A352MenuItemId ;
      private short A353MenuItemFatherId ;
      private short AV23MenuItemIdAux ;
      private int AV10MaxItems ;
      private string AV18TrnMode ;
      private string scmdbuf ;
      private bool AV21IsDynamicCall ;
      private bool returnInSub ;
      private bool n353MenuItemFatherId ;
      private string AV12Combo_DataJson ;
      private string AV16ComboName ;
      private string AV11SearchTxt ;
      private string AV15SelectedValue ;
      private string AV20SelectedText ;
      private string lV11SearchTxt ;
      private string A1222MenuItemCaption ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P001F2_A1222MenuItemCaption ;
      private short[] P001F2_A352MenuItemId ;
      private short[] P001F3_A352MenuItemId ;
      private short[] P001F3_A353MenuItemFatherId ;
      private bool[] P001F3_n353MenuItemFatherId ;
      private short[] P001F4_A352MenuItemId ;
      private string[] P001F4_A1222MenuItemCaption ;
      private string aP5_SelectedValue ;
      private string aP6_SelectedText ;
      private string aP7_Combo_DataJson ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13Combo_Data ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item AV14Combo_DataItem ;
   }

   public class menuitemloaddvcombo__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P001F2( IGxContext context ,
                                             string AV11SearchTxt ,
                                             string A1222MenuItemCaption )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [MenuItemCaption], [MenuItemId] FROM [SIGERPMenu]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV11SearchTxt)) )
         {
            AddWhere(sWhereString, "([MenuItemCaption] like '%' + @lV11SearchTxt)");
         }
         else
         {
            GXv_int1[0] = 1;
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
                     return conditional_P001F2(context, (string)dynConstraints[0] , (string)dynConstraints[1] );
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
          Object[] prmP001F3;
          prmP001F3 = new Object[] {
          new ParDef("@AV24MenuItemId",GXType.Int16,4,0)
          };
          Object[] prmP001F4;
          prmP001F4 = new Object[] {
          new ParDef("@AV23MenuItemIdAux",GXType.Int16,4,0)
          };
          Object[] prmP001F2;
          prmP001F2 = new Object[] {
          new ParDef("@lV11SearchTxt",GXType.NVarChar,40,0)
          };
          def= new CursorDef[] {
              new CursorDef("P001F2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001F2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P001F3", "SELECT [MenuItemId], [MenuItemFatherId] FROM [SIGERPMenu] WHERE [MenuItemId] = @AV24MenuItemId ORDER BY [MenuItemId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001F3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P001F4", "SELECT TOP 1 [MenuItemId], [MenuItemCaption] FROM [SIGERPMenu] WHERE [MenuItemId] = @AV23MenuItemIdAux ORDER BY [MenuItemId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001F4,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
