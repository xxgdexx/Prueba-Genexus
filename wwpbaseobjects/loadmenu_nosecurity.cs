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
   public class loadmenu_nosecurity : GXProcedure
   {
      public loadmenu_nosecurity( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public loadmenu_nosecurity( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_MenuItemCaption ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP1_DVelopMenu )
      {
         this.AV8MenuItemCaption = aP0_MenuItemCaption;
         this.AV10DVelopMenu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "SIGERP_ADVANCED") ;
         initialize();
         executePrivate();
         aP1_DVelopMenu=this.AV10DVelopMenu;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> executeUdp( string aP0_MenuItemCaption )
      {
         execute(aP0_MenuItemCaption, out aP1_DVelopMenu);
         return AV10DVelopMenu ;
      }

      public void executeSubmit( string aP0_MenuItemCaption ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP1_DVelopMenu )
      {
         loadmenu_nosecurity objloadmenu_nosecurity;
         objloadmenu_nosecurity = new loadmenu_nosecurity();
         objloadmenu_nosecurity.AV8MenuItemCaption = aP0_MenuItemCaption;
         objloadmenu_nosecurity.AV10DVelopMenu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "SIGERP_ADVANCED") ;
         objloadmenu_nosecurity.context.SetSubmitInitialConfig(context);
         objloadmenu_nosecurity.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objloadmenu_nosecurity);
         aP1_DVelopMenu=this.AV10DVelopMenu;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadmenu_nosecurity)stateInfo).executePrivate();
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
         AV22GXLvl2 = 0;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8MenuItemCaption ,
                                              A1222MenuItemCaption ,
                                              A353MenuItemFatherId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P001Z2 */
         pr_default.execute(0, new Object[] {AV8MenuItemCaption});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A353MenuItemFatherId = P001Z2_A353MenuItemFatherId[0];
            n353MenuItemFatherId = P001Z2_n353MenuItemFatherId[0];
            A1222MenuItemCaption = P001Z2_A1222MenuItemCaption[0];
            A352MenuItemId = P001Z2_A352MenuItemId[0];
            A1230MenuItemShowDeveloperMenuOptio = P001Z2_A1230MenuItemShowDeveloperMenuOptio[0];
            A1231MenuItemShowEditMenuOptions = P001Z2_A1231MenuItemShowEditMenuOptions[0];
            AV22GXLvl2 = 1;
            AV9MenuItemId = A352MenuItemId;
            AV16MenuItemShowDeveloperMenuOption = A1230MenuItemShowDeveloperMenuOptio;
            AV17MenuItemShowEditMenuOptions = A1231MenuItemShowEditMenuOptions;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P001Z4 */
         pr_default.execute(1);
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40000GXC1 = P001Z4_A40000GXC1[0];
            n40000GXC1 = P001Z4_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(1);
         if ( AV22GXLvl2 == 0 )
         {
            if ( A40000GXC1 == 0 )
            {
               AV13MenuItem = new GeneXus.Programs.wwpbaseobjects.SdtMenuItem(context);
               AV13MenuItem.gxTpr_Menuitemcaption = "MainMenu";
               AV13MenuItem.gxTpr_Menuitemshoweditmenuoptions = true;
               AV13MenuItem.gxTpr_Menuitemshowdevelopermenuoption = true;
               AV13MenuItem.gxTpr_Menuitemtype = 2;
               AV13MenuItem.Save();
               AV9MenuItemId = AV13MenuItem.gxTpr_Menuitemid;
               AV13MenuItem = new GeneXus.Programs.wwpbaseobjects.SdtMenuItem(context);
               AV13MenuItem.gxTpr_Menuitemcaption = "Home";
               AV13MenuItem.gxTpr_Menuitemtype = 1;
               AV13MenuItem.gxTpr_Menuitemlink = formatLink("wwpbaseobjects.home.aspx") ;
               AV13MenuItem.gxTpr_Menuitemfatherid = AV9MenuItemId;
               AV13MenuItem.gxTpr_Menuitemiconclass = "menu-icon fa fa-home";
               AV13MenuItem.Save();
               context.CommitDataStores("wwpbaseobjects.loadmenu_nosecurity",pr_default);
               /* Using cursor P001Z5 */
               pr_default.execute(2, new Object[] {AV8MenuItemCaption});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A353MenuItemFatherId = P001Z5_A353MenuItemFatherId[0];
                  n353MenuItemFatherId = P001Z5_n353MenuItemFatherId[0];
                  A1222MenuItemCaption = P001Z5_A1222MenuItemCaption[0];
                  A352MenuItemId = P001Z5_A352MenuItemId[0];
                  A1230MenuItemShowDeveloperMenuOptio = P001Z5_A1230MenuItemShowDeveloperMenuOptio[0];
                  A1231MenuItemShowEditMenuOptions = P001Z5_A1231MenuItemShowEditMenuOptions[0];
                  AV9MenuItemId = A352MenuItemId;
                  AV16MenuItemShowDeveloperMenuOption = A1230MenuItemShowDeveloperMenuOptio;
                  AV17MenuItemShowEditMenuOptions = A1231MenuItemShowEditMenuOptions;
                  pr_default.readNext(2);
               }
               pr_default.close(2);
            }
         }
         A352MenuItemId = AV13MenuItem.gxTpr_Menuitemid;
         if ( AV9MenuItemId > 0 )
         {
            GXt_objcol_SdtDVelop_Menu_Item1 = AV10DVelopMenu;
            new GeneXus.Programs.wwpbaseobjects.menuoptionsdata_nosecurity(context ).execute(  AV9MenuItemId,  true, out  GXt_objcol_SdtDVelop_Menu_Item1) ;
            AV10DVelopMenu = GXt_objcol_SdtDVelop_Menu_Item1;
         }
         if ( ( AV9MenuItemId == 0 ) || AV17MenuItemShowEditMenuOptions )
         {
            AV11DVelopMenuItem = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
            AV11DVelopMenuItem.gxTpr_Id = "Edit";
            AV11DVelopMenuItem.gxTpr_Link = formatLink("wwpbaseobjects.menuitemappmenuww.aspx") ;
            AV11DVelopMenuItem.gxTpr_Iconclass = "menu-icon fa fa-tasks";
            AV11DVelopMenuItem.gxTpr_Caption = "Edit Menu Options";
            AV10DVelopMenu.Add(AV11DVelopMenuItem, 0);
         }
         if ( ( AV9MenuItemId == 0 ) || AV16MenuItemShowDeveloperMenuOption )
         {
            AV11DVelopMenuItem = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
            AV11DVelopMenuItem.gxTpr_Id = "DeveloperMenu";
            AV11DVelopMenuItem.gxTpr_Iconclass = "menu-icon fa fa-edit";
            AV11DVelopMenuItem.gxTpr_Caption = "Developer Menu";
            AV14id = (short)(10000);
            AV25GXV2 = 1;
            GXt_objcol_SdtProgramNames_ProgramName2 = AV24GXV1;
            new GeneXus.Programs.wwpbaseobjects.listwwpprograms(context ).execute( out  GXt_objcol_SdtProgramNames_ProgramName2) ;
            AV24GXV1 = GXt_objcol_SdtProgramNames_ProgramName2;
            while ( AV25GXV2 <= AV24GXV1.Count )
            {
               AV15ProgramName = ((GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName)AV24GXV1.Item(AV25GXV2));
               AV12DVelopMenuItemDeveloperMenu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
               AV14id = (short)(AV14id+1);
               AV12DVelopMenuItemDeveloperMenu.gxTpr_Id = StringUtil.Str( (decimal)(AV14id), 4, 0);
               AV12DVelopMenuItemDeveloperMenu.gxTpr_Tooltip = "";
               AV12DVelopMenuItemDeveloperMenu.gxTpr_Link = AV15ProgramName.gxTpr_Link;
               AV12DVelopMenuItemDeveloperMenu.gxTpr_Linktarget = "";
               AV12DVelopMenuItemDeveloperMenu.gxTpr_Iconclass = "";
               AV12DVelopMenuItemDeveloperMenu.gxTpr_Caption = AV15ProgramName.gxTpr_Description;
               AV11DVelopMenuItem.gxTpr_Subitems.Add(AV12DVelopMenuItemDeveloperMenu, 0);
               AV25GXV2 = (int)(AV25GXV2+1);
            }
            AV10DVelopMenu.Add(AV11DVelopMenuItem, 0);
         }
         this.cleanup();
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
         AV10DVelopMenu = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "SIGERP_ADVANCED");
         scmdbuf = "";
         A1222MenuItemCaption = "";
         P001Z2_A353MenuItemFatherId = new short[1] ;
         P001Z2_n353MenuItemFatherId = new bool[] {false} ;
         P001Z2_A1222MenuItemCaption = new string[] {""} ;
         P001Z2_A352MenuItemId = new short[1] ;
         P001Z2_A1230MenuItemShowDeveloperMenuOptio = new bool[] {false} ;
         P001Z2_A1231MenuItemShowEditMenuOptions = new bool[] {false} ;
         P001Z4_A40000GXC1 = new int[1] ;
         P001Z4_n40000GXC1 = new bool[] {false} ;
         AV13MenuItem = new GeneXus.Programs.wwpbaseobjects.SdtMenuItem(context);
         P001Z5_A353MenuItemFatherId = new short[1] ;
         P001Z5_n353MenuItemFatherId = new bool[] {false} ;
         P001Z5_A1222MenuItemCaption = new string[] {""} ;
         P001Z5_A352MenuItemId = new short[1] ;
         P001Z5_A1230MenuItemShowDeveloperMenuOptio = new bool[] {false} ;
         P001Z5_A1231MenuItemShowEditMenuOptions = new bool[] {false} ;
         GXt_objcol_SdtDVelop_Menu_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "SIGERP_ADVANCED");
         AV11DVelopMenuItem = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         AV24GXV1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "SIGERP_ADVANCED");
         GXt_objcol_SdtProgramNames_ProgramName2 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "SIGERP_ADVANCED");
         AV15ProgramName = new GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName(context);
         AV12DVelopMenuItemDeveloperMenu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.loadmenu_nosecurity__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.loadmenu_nosecurity__default(),
            new Object[][] {
                new Object[] {
               P001Z2_A353MenuItemFatherId, P001Z2_n353MenuItemFatherId, P001Z2_A1222MenuItemCaption, P001Z2_A352MenuItemId, P001Z2_A1230MenuItemShowDeveloperMenuOptio, P001Z2_A1231MenuItemShowEditMenuOptions
               }
               , new Object[] {
               P001Z4_A40000GXC1, P001Z4_n40000GXC1
               }
               , new Object[] {
               P001Z5_A353MenuItemFatherId, P001Z5_n353MenuItemFatherId, P001Z5_A1222MenuItemCaption, P001Z5_A352MenuItemId, P001Z5_A1230MenuItemShowDeveloperMenuOptio, P001Z5_A1231MenuItemShowEditMenuOptions
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV22GXLvl2 ;
      private short A353MenuItemFatherId ;
      private short A352MenuItemId ;
      private short AV9MenuItemId ;
      private short AV14id ;
      private int A40000GXC1 ;
      private int AV25GXV2 ;
      private string scmdbuf ;
      private bool n353MenuItemFatherId ;
      private bool A1230MenuItemShowDeveloperMenuOptio ;
      private bool A1231MenuItemShowEditMenuOptions ;
      private bool AV16MenuItemShowDeveloperMenuOption ;
      private bool AV17MenuItemShowEditMenuOptions ;
      private bool n40000GXC1 ;
      private string AV8MenuItemCaption ;
      private string A1222MenuItemCaption ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P001Z2_A353MenuItemFatherId ;
      private bool[] P001Z2_n353MenuItemFatherId ;
      private string[] P001Z2_A1222MenuItemCaption ;
      private short[] P001Z2_A352MenuItemId ;
      private bool[] P001Z2_A1230MenuItemShowDeveloperMenuOptio ;
      private bool[] P001Z2_A1231MenuItemShowEditMenuOptions ;
      private int[] P001Z4_A40000GXC1 ;
      private bool[] P001Z4_n40000GXC1 ;
      private short[] P001Z5_A353MenuItemFatherId ;
      private bool[] P001Z5_n353MenuItemFatherId ;
      private string[] P001Z5_A1222MenuItemCaption ;
      private short[] P001Z5_A352MenuItemId ;
      private bool[] P001Z5_A1230MenuItemShowDeveloperMenuOptio ;
      private bool[] P001Z5_A1231MenuItemShowEditMenuOptions ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP1_DVelopMenu ;
      private IDataStoreProvider pr_datastore2 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> AV10DVelopMenu ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> GXt_objcol_SdtDVelop_Menu_Item1 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> AV24GXV1 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> GXt_objcol_SdtProgramNames_ProgramName2 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item AV11DVelopMenuItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item AV12DVelopMenuItemDeveloperMenu ;
      private GeneXus.Programs.wwpbaseobjects.SdtMenuItem AV13MenuItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName AV15ProgramName ;
   }

   public class loadmenu_nosecurity__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class loadmenu_nosecurity__default : DataStoreHelperBase, IDataStoreHelper
 {
    protected Object[] conditional_P001Z2( IGxContext context ,
                                           string AV8MenuItemCaption ,
                                           string A1222MenuItemCaption ,
                                           short A353MenuItemFatherId )
    {
       System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
       string scmdbuf;
       short[] GXv_int3 = new short[1];
       Object[] GXv_Object4 = new Object[2];
       scmdbuf = "SELECT [MenuItemFatherId], [MenuItemCaption], [MenuItemId], [MenuItemShowDeveloperMenuOptio], [MenuItemShowEditMenuOptions] FROM [SIGERPMenu]";
       AddWhere(sWhereString, "(([MenuItemFatherId] = convert(int, 0)) or [MenuItemFatherId] IS NULL)");
       if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8MenuItemCaption)) )
       {
          AddWhere(sWhereString, "(LOWER([MenuItemCaption]) = LOWER(@AV8MenuItemCaption))");
       }
       else
       {
          GXv_int3[0] = 1;
       }
       scmdbuf += sWhereString;
       scmdbuf += " ORDER BY [MenuItemId]";
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
                   return conditional_P001Z2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] );
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
        Object[] prmP001Z4;
        prmP001Z4 = new Object[] {
        };
        Object[] prmP001Z5;
        prmP001Z5 = new Object[] {
        new ParDef("@AV8MenuItemCaption",GXType.NVarChar,40,0)
        };
        Object[] prmP001Z2;
        prmP001Z2 = new Object[] {
        new ParDef("@AV8MenuItemCaption",GXType.NVarChar,40,0)
        };
        def= new CursorDef[] {
            new CursorDef("P001Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001Z2,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P001Z4", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM [SIGERPMenu] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001Z4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P001Z5", "SELECT [MenuItemFatherId], [MenuItemCaption], [MenuItemId], [MenuItemShowDeveloperMenuOptio], [MenuItemShowEditMenuOptions] FROM [SIGERPMenu] WHERE (LOWER([MenuItemCaption]) = LOWER(@AV8MenuItemCaption)) AND (([MenuItemFatherId] = convert(int, 0)) or [MenuItemFatherId] IS NULL) ORDER BY [MenuItemId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP001Z5,100, GxCacheFrequency.OFF ,false,false )
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
              ((bool[]) buf[4])[0] = rslt.getBool(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((short[]) buf[3])[0] = rslt.getShort(3);
              ((bool[]) buf[4])[0] = rslt.getBool(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              return;
     }
  }

}

}
