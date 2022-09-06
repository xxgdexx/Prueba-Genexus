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
   public class menuoptionsdata_nosecurity : GXProcedure
   {
      public menuoptionsdata_nosecurity( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public menuoptionsdata_nosecurity( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_MenuItemId ,
                           bool aP1_IsRootFather ,
                           out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP2_Gxm2rootcol )
      {
         this.AV8MenuItemId = aP0_MenuItemId;
         this.AV7IsRootFather = aP1_IsRootFather;
         this.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "SIGERP_ADVANCED") ;
         initialize();
         executePrivate();
         aP2_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> executeUdp( short aP0_MenuItemId ,
                                                                                               bool aP1_IsRootFather )
      {
         execute(aP0_MenuItemId, aP1_IsRootFather, out aP2_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( short aP0_MenuItemId ,
                                 bool aP1_IsRootFather ,
                                 out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP2_Gxm2rootcol )
      {
         menuoptionsdata_nosecurity objmenuoptionsdata_nosecurity;
         objmenuoptionsdata_nosecurity = new menuoptionsdata_nosecurity();
         objmenuoptionsdata_nosecurity.AV8MenuItemId = aP0_MenuItemId;
         objmenuoptionsdata_nosecurity.AV7IsRootFather = aP1_IsRootFather;
         objmenuoptionsdata_nosecurity.Gxm2rootcol = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "SIGERP_ADVANCED") ;
         objmenuoptionsdata_nosecurity.context.SetSubmitInitialConfig(context);
         objmenuoptionsdata_nosecurity.initialize();
         ThreadPool.QueueUserWorkItem( PropagateCulture(new WaitCallback( executePrivateCatch )),objmenuoptionsdata_nosecurity);
         aP2_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((menuoptionsdata_nosecurity)stateInfo).executePrivate();
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
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV8MenuItemId ,
                                              A353MenuItemFatherId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         /* Using cursor P00032 */
         pr_default.execute(0, new Object[] {AV8MenuItemId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A353MenuItemFatherId = P00032_A353MenuItemFatherId[0];
            n353MenuItemFatherId = P00032_n353MenuItemFatherId[0];
            A352MenuItemId = P00032_A352MenuItemId[0];
            A1227MenuItemLinkParameters = P00032_A1227MenuItemLinkParameters[0];
            A1226MenuItemLink = P00032_A1226MenuItemLink[0];
            A1228MenuItemLinkTarget = P00032_A1228MenuItemLinkTarget[0];
            A1225MenuItemIconClass = P00032_A1225MenuItemIconClass[0];
            A1222MenuItemCaption = P00032_A1222MenuItemCaption[0];
            A1229MenuItemOrder = P00032_A1229MenuItemOrder[0];
            Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
            Gxm2rootcol.Add(Gxm1dvelop_menu, 0);
            Gxm1dvelop_menu.gxTpr_Id = StringUtil.Str( (decimal)(A352MenuItemId), 4, 0);
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A1227MenuItemLinkParameters))) )
            {
               AV11MenuItemLink = A1226MenuItemLink + "?" + A1227MenuItemLinkParameters;
            }
            else
            {
               AV11MenuItemLink = A1226MenuItemLink;
            }
            Gxm1dvelop_menu.gxTpr_Link = formatLink(AV11MenuItemLink) ;
            if ( StringUtil.StrCmp(A1228MenuItemLinkTarget, "_") != 0 )
            {
               Gxm1dvelop_menu.gxTpr_Linktarget = A1228MenuItemLinkTarget;
            }
            else
            {
               Gxm1dvelop_menu.gxTpr_Linktarget = "";
            }
            if ( AV7IsRootFather )
            {
               Gxm1dvelop_menu.gxTpr_Iconclass = A1225MenuItemIconClass;
            }
            else
            {
               Gxm1dvelop_menu.gxTpr_Iconclass = "";
            }
            Gxm1dvelop_menu.gxTpr_Caption = A1222MenuItemCaption;
            GXt_objcol_SdtDVelop_Menu_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>();
            new GeneXus.Programs.wwpbaseobjects.menuoptionsdata_nosecurity(context ).execute(  A352MenuItemId,  false, out  GXt_objcol_SdtDVelop_Menu_Item1) ;
            Gxm1dvelop_menu.gxTpr_Subitems = GXt_objcol_SdtDVelop_Menu_Item1;
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         scmdbuf = "";
         P00032_A353MenuItemFatherId = new short[1] ;
         P00032_n353MenuItemFatherId = new bool[] {false} ;
         P00032_A352MenuItemId = new short[1] ;
         P00032_A1227MenuItemLinkParameters = new string[] {""} ;
         P00032_A1226MenuItemLink = new string[] {""} ;
         P00032_A1228MenuItemLinkTarget = new string[] {""} ;
         P00032_A1225MenuItemIconClass = new string[] {""} ;
         P00032_A1222MenuItemCaption = new string[] {""} ;
         P00032_A1229MenuItemOrder = new short[1] ;
         A1227MenuItemLinkParameters = "";
         A1226MenuItemLink = "";
         A1228MenuItemLinkTarget = "";
         A1225MenuItemIconClass = "";
         A1222MenuItemCaption = "";
         Gxm1dvelop_menu = new GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item(context);
         AV11MenuItemLink = "";
         GXt_objcol_SdtDVelop_Menu_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item>( context, "Item", "SIGERP_ADVANCED");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.menuoptionsdata_nosecurity__default(),
            new Object[][] {
                new Object[] {
               P00032_A353MenuItemFatherId, P00032_n353MenuItemFatherId, P00032_A352MenuItemId, P00032_A1227MenuItemLinkParameters, P00032_A1226MenuItemLink, P00032_A1228MenuItemLinkTarget, P00032_A1225MenuItemIconClass, P00032_A1222MenuItemCaption, P00032_A1229MenuItemOrder
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8MenuItemId ;
      private short A353MenuItemFatherId ;
      private short A352MenuItemId ;
      private short A1229MenuItemOrder ;
      private string scmdbuf ;
      private bool AV7IsRootFather ;
      private bool n353MenuItemFatherId ;
      private string A1227MenuItemLinkParameters ;
      private string A1226MenuItemLink ;
      private string A1228MenuItemLinkTarget ;
      private string A1225MenuItemIconClass ;
      private string A1222MenuItemCaption ;
      private string AV11MenuItemLink ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P00032_A353MenuItemFatherId ;
      private bool[] P00032_n353MenuItemFatherId ;
      private short[] P00032_A352MenuItemId ;
      private string[] P00032_A1227MenuItemLinkParameters ;
      private string[] P00032_A1226MenuItemLink ;
      private string[] P00032_A1228MenuItemLinkTarget ;
      private string[] P00032_A1225MenuItemIconClass ;
      private string[] P00032_A1222MenuItemCaption ;
      private short[] P00032_A1229MenuItemOrder ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> aP2_Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> Gxm2rootcol ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item> GXt_objcol_SdtDVelop_Menu_Item1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVelop_Menu_Item Gxm1dvelop_menu ;
   }

   public class menuoptionsdata_nosecurity__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00032( IGxContext context ,
                                             short AV8MenuItemId ,
                                             short A353MenuItemFatherId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[1];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [MenuItemFatherId], [MenuItemId], [MenuItemLinkParameters], [MenuItemLink], [MenuItemLinkTarget], [MenuItemIconClass], [MenuItemCaption], [MenuItemOrder] FROM [SIGERPMenu]";
         if ( AV8MenuItemId > 0 )
         {
            AddWhere(sWhereString, "([MenuItemFatherId] = @AV8MenuItemId)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( AV8MenuItemId == 0 )
         {
            AddWhere(sWhereString, "([MenuItemFatherId] IS NULL or ([MenuItemFatherId] = convert(int, 0)))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MenuItemOrder]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00032(context, (short)dynConstraints[0] , (short)dynConstraints[1] );
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
          Object[] prmP00032;
          prmP00032 = new Object[] {
          new ParDef("@AV8MenuItemId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00032", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00032,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((short[]) buf[8])[0] = rslt.getShort(8);
                return;
       }
    }

 }

}
