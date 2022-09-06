using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.wwpbaseobjects {
   [XmlRoot(ElementName = "MenuItem" )]
   [XmlType(TypeName =  "MenuItem" , Namespace = "SIGERP_ADVANCED" )]
   [Serializable]
   public class SdtMenuItem : GxSilentTrnSdt
   {
      public SdtMenuItem( )
      {
      }

      public SdtMenuItem( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( short AV352MenuItemId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV352MenuItemId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"MenuItemId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\MenuItem");
         metadata.Set("BT", "SIGERPMenu");
         metadata.Set("PK", "[ \"MenuItemId\" ]");
         metadata.Set("PKAssigned", "[ \"MenuItemId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"MenuItemId\" ],\"FKMap\":[ \"MenuItemFatherId-MenuItemId\" ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Menuitemid_Z");
         state.Add("gxTpr_Menuitemcaption_Z");
         state.Add("gxTpr_Menuitemorder_Z");
         state.Add("gxTpr_Menuitemfatherid_Z");
         state.Add("gxTpr_Menuitemfathercaption_Z");
         state.Add("gxTpr_Menuitemfathertype_Z");
         state.Add("gxTpr_Menuitemtype_Z");
         state.Add("gxTpr_Menuitemlink_Z");
         state.Add("gxTpr_Menuitemlinkparameters_Z");
         state.Add("gxTpr_Menuitemlinktarget_Z");
         state.Add("gxTpr_Menuitemiconclass_Z");
         state.Add("gxTpr_Menuitemshowdevelopermenuoption_Z");
         state.Add("gxTpr_Menuitemshoweditmenuoptions_Z");
         state.Add("gxTpr_Menuitemfatherid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.SdtMenuItem sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.SdtMenuItem)(source);
         gxTv_SdtMenuItem_Menuitemid = sdt.gxTv_SdtMenuItem_Menuitemid ;
         gxTv_SdtMenuItem_Menuitemcaption = sdt.gxTv_SdtMenuItem_Menuitemcaption ;
         gxTv_SdtMenuItem_Menuitemorder = sdt.gxTv_SdtMenuItem_Menuitemorder ;
         gxTv_SdtMenuItem_Menuitemfatherid = sdt.gxTv_SdtMenuItem_Menuitemfatherid ;
         gxTv_SdtMenuItem_Menuitemfathercaption = sdt.gxTv_SdtMenuItem_Menuitemfathercaption ;
         gxTv_SdtMenuItem_Menuitemfathertype = sdt.gxTv_SdtMenuItem_Menuitemfathertype ;
         gxTv_SdtMenuItem_Menuitemtype = sdt.gxTv_SdtMenuItem_Menuitemtype ;
         gxTv_SdtMenuItem_Menuitemlink = sdt.gxTv_SdtMenuItem_Menuitemlink ;
         gxTv_SdtMenuItem_Menuitemlinkparameters = sdt.gxTv_SdtMenuItem_Menuitemlinkparameters ;
         gxTv_SdtMenuItem_Menuitemlinktarget = sdt.gxTv_SdtMenuItem_Menuitemlinktarget ;
         gxTv_SdtMenuItem_Menuitemiconclass = sdt.gxTv_SdtMenuItem_Menuitemiconclass ;
         gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption = sdt.gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption ;
         gxTv_SdtMenuItem_Menuitemshoweditmenuoptions = sdt.gxTv_SdtMenuItem_Menuitemshoweditmenuoptions ;
         gxTv_SdtMenuItem_Mode = sdt.gxTv_SdtMenuItem_Mode ;
         gxTv_SdtMenuItem_Initialized = sdt.gxTv_SdtMenuItem_Initialized ;
         gxTv_SdtMenuItem_Menuitemid_Z = sdt.gxTv_SdtMenuItem_Menuitemid_Z ;
         gxTv_SdtMenuItem_Menuitemcaption_Z = sdt.gxTv_SdtMenuItem_Menuitemcaption_Z ;
         gxTv_SdtMenuItem_Menuitemorder_Z = sdt.gxTv_SdtMenuItem_Menuitemorder_Z ;
         gxTv_SdtMenuItem_Menuitemfatherid_Z = sdt.gxTv_SdtMenuItem_Menuitemfatherid_Z ;
         gxTv_SdtMenuItem_Menuitemfathercaption_Z = sdt.gxTv_SdtMenuItem_Menuitemfathercaption_Z ;
         gxTv_SdtMenuItem_Menuitemfathertype_Z = sdt.gxTv_SdtMenuItem_Menuitemfathertype_Z ;
         gxTv_SdtMenuItem_Menuitemtype_Z = sdt.gxTv_SdtMenuItem_Menuitemtype_Z ;
         gxTv_SdtMenuItem_Menuitemlink_Z = sdt.gxTv_SdtMenuItem_Menuitemlink_Z ;
         gxTv_SdtMenuItem_Menuitemlinkparameters_Z = sdt.gxTv_SdtMenuItem_Menuitemlinkparameters_Z ;
         gxTv_SdtMenuItem_Menuitemlinktarget_Z = sdt.gxTv_SdtMenuItem_Menuitemlinktarget_Z ;
         gxTv_SdtMenuItem_Menuitemiconclass_Z = sdt.gxTv_SdtMenuItem_Menuitemiconclass_Z ;
         gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption_Z = sdt.gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption_Z ;
         gxTv_SdtMenuItem_Menuitemshoweditmenuoptions_Z = sdt.gxTv_SdtMenuItem_Menuitemshoweditmenuoptions_Z ;
         gxTv_SdtMenuItem_Menuitemfatherid_N = sdt.gxTv_SdtMenuItem_Menuitemfatherid_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("MenuItemId", gxTv_SdtMenuItem_Menuitemid, false, includeNonInitialized);
         AddObjectProperty("MenuItemCaption", gxTv_SdtMenuItem_Menuitemcaption, false, includeNonInitialized);
         AddObjectProperty("MenuItemOrder", gxTv_SdtMenuItem_Menuitemorder, false, includeNonInitialized);
         AddObjectProperty("MenuItemFatherId", gxTv_SdtMenuItem_Menuitemfatherid, false, includeNonInitialized);
         AddObjectProperty("MenuItemFatherId_N", gxTv_SdtMenuItem_Menuitemfatherid_N, false, includeNonInitialized);
         AddObjectProperty("MenuItemFatherCaption", gxTv_SdtMenuItem_Menuitemfathercaption, false, includeNonInitialized);
         AddObjectProperty("MenuItemFatherType", gxTv_SdtMenuItem_Menuitemfathertype, false, includeNonInitialized);
         AddObjectProperty("MenuItemType", gxTv_SdtMenuItem_Menuitemtype, false, includeNonInitialized);
         AddObjectProperty("MenuItemLink", gxTv_SdtMenuItem_Menuitemlink, false, includeNonInitialized);
         AddObjectProperty("MenuItemLinkParameters", gxTv_SdtMenuItem_Menuitemlinkparameters, false, includeNonInitialized);
         AddObjectProperty("MenuItemLinkTarget", gxTv_SdtMenuItem_Menuitemlinktarget, false, includeNonInitialized);
         AddObjectProperty("MenuItemIconClass", gxTv_SdtMenuItem_Menuitemiconclass, false, includeNonInitialized);
         AddObjectProperty("MenuItemShowDeveloperMenuOption", gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption, false, includeNonInitialized);
         AddObjectProperty("MenuItemShowEditMenuOptions", gxTv_SdtMenuItem_Menuitemshoweditmenuoptions, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtMenuItem_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtMenuItem_Initialized, false, includeNonInitialized);
            AddObjectProperty("MenuItemId_Z", gxTv_SdtMenuItem_Menuitemid_Z, false, includeNonInitialized);
            AddObjectProperty("MenuItemCaption_Z", gxTv_SdtMenuItem_Menuitemcaption_Z, false, includeNonInitialized);
            AddObjectProperty("MenuItemOrder_Z", gxTv_SdtMenuItem_Menuitemorder_Z, false, includeNonInitialized);
            AddObjectProperty("MenuItemFatherId_Z", gxTv_SdtMenuItem_Menuitemfatherid_Z, false, includeNonInitialized);
            AddObjectProperty("MenuItemFatherCaption_Z", gxTv_SdtMenuItem_Menuitemfathercaption_Z, false, includeNonInitialized);
            AddObjectProperty("MenuItemFatherType_Z", gxTv_SdtMenuItem_Menuitemfathertype_Z, false, includeNonInitialized);
            AddObjectProperty("MenuItemType_Z", gxTv_SdtMenuItem_Menuitemtype_Z, false, includeNonInitialized);
            AddObjectProperty("MenuItemLink_Z", gxTv_SdtMenuItem_Menuitemlink_Z, false, includeNonInitialized);
            AddObjectProperty("MenuItemLinkParameters_Z", gxTv_SdtMenuItem_Menuitemlinkparameters_Z, false, includeNonInitialized);
            AddObjectProperty("MenuItemLinkTarget_Z", gxTv_SdtMenuItem_Menuitemlinktarget_Z, false, includeNonInitialized);
            AddObjectProperty("MenuItemIconClass_Z", gxTv_SdtMenuItem_Menuitemiconclass_Z, false, includeNonInitialized);
            AddObjectProperty("MenuItemShowDeveloperMenuOption_Z", gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption_Z, false, includeNonInitialized);
            AddObjectProperty("MenuItemShowEditMenuOptions_Z", gxTv_SdtMenuItem_Menuitemshoweditmenuoptions_Z, false, includeNonInitialized);
            AddObjectProperty("MenuItemFatherId_N", gxTv_SdtMenuItem_Menuitemfatherid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.SdtMenuItem sdt )
      {
         if ( sdt.IsDirty("MenuItemId") )
         {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemid = sdt.gxTv_SdtMenuItem_Menuitemid ;
         }
         if ( sdt.IsDirty("MenuItemCaption") )
         {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemcaption = sdt.gxTv_SdtMenuItem_Menuitemcaption ;
         }
         if ( sdt.IsDirty("MenuItemOrder") )
         {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemorder = sdt.gxTv_SdtMenuItem_Menuitemorder ;
         }
         if ( sdt.IsDirty("MenuItemFatherId") )
         {
            gxTv_SdtMenuItem_Menuitemfatherid_N = (short)(sdt.gxTv_SdtMenuItem_Menuitemfatherid_N);
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemfatherid = sdt.gxTv_SdtMenuItem_Menuitemfatherid ;
         }
         if ( sdt.IsDirty("MenuItemFatherCaption") )
         {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemfathercaption = sdt.gxTv_SdtMenuItem_Menuitemfathercaption ;
         }
         if ( sdt.IsDirty("MenuItemFatherType") )
         {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemfathertype = sdt.gxTv_SdtMenuItem_Menuitemfathertype ;
         }
         if ( sdt.IsDirty("MenuItemType") )
         {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemtype = sdt.gxTv_SdtMenuItem_Menuitemtype ;
         }
         if ( sdt.IsDirty("MenuItemLink") )
         {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemlink = sdt.gxTv_SdtMenuItem_Menuitemlink ;
         }
         if ( sdt.IsDirty("MenuItemLinkParameters") )
         {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemlinkparameters = sdt.gxTv_SdtMenuItem_Menuitemlinkparameters ;
         }
         if ( sdt.IsDirty("MenuItemLinkTarget") )
         {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemlinktarget = sdt.gxTv_SdtMenuItem_Menuitemlinktarget ;
         }
         if ( sdt.IsDirty("MenuItemIconClass") )
         {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemiconclass = sdt.gxTv_SdtMenuItem_Menuitemiconclass ;
         }
         if ( sdt.IsDirty("MenuItemShowDeveloperMenuOption") )
         {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption = sdt.gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption ;
         }
         if ( sdt.IsDirty("MenuItemShowEditMenuOptions") )
         {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemshoweditmenuoptions = sdt.gxTv_SdtMenuItem_Menuitemshoweditmenuoptions ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MenuItemId" )]
      [  XmlElement( ElementName = "MenuItemId"   )]
      public short gxTpr_Menuitemid
      {
         get {
            return gxTv_SdtMenuItem_Menuitemid ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            if ( gxTv_SdtMenuItem_Menuitemid != value )
            {
               gxTv_SdtMenuItem_Mode = "INS";
               this.gxTv_SdtMenuItem_Menuitemid_Z_SetNull( );
               this.gxTv_SdtMenuItem_Menuitemcaption_Z_SetNull( );
               this.gxTv_SdtMenuItem_Menuitemorder_Z_SetNull( );
               this.gxTv_SdtMenuItem_Menuitemfatherid_Z_SetNull( );
               this.gxTv_SdtMenuItem_Menuitemfathercaption_Z_SetNull( );
               this.gxTv_SdtMenuItem_Menuitemfathertype_Z_SetNull( );
               this.gxTv_SdtMenuItem_Menuitemtype_Z_SetNull( );
               this.gxTv_SdtMenuItem_Menuitemlink_Z_SetNull( );
               this.gxTv_SdtMenuItem_Menuitemlinkparameters_Z_SetNull( );
               this.gxTv_SdtMenuItem_Menuitemlinktarget_Z_SetNull( );
               this.gxTv_SdtMenuItem_Menuitemiconclass_Z_SetNull( );
               this.gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption_Z_SetNull( );
               this.gxTv_SdtMenuItem_Menuitemshoweditmenuoptions_Z_SetNull( );
            }
            gxTv_SdtMenuItem_Menuitemid = value;
            SetDirty("Menuitemid");
         }

      }

      [  SoapElement( ElementName = "MenuItemCaption" )]
      [  XmlElement( ElementName = "MenuItemCaption"   )]
      public string gxTpr_Menuitemcaption
      {
         get {
            return gxTv_SdtMenuItem_Menuitemcaption ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemcaption = value;
            SetDirty("Menuitemcaption");
         }

      }

      [  SoapElement( ElementName = "MenuItemOrder" )]
      [  XmlElement( ElementName = "MenuItemOrder"   )]
      public short gxTpr_Menuitemorder
      {
         get {
            return gxTv_SdtMenuItem_Menuitemorder ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemorder = value;
            SetDirty("Menuitemorder");
         }

      }

      [  SoapElement( ElementName = "MenuItemFatherId" )]
      [  XmlElement( ElementName = "MenuItemFatherId"   )]
      public short gxTpr_Menuitemfatherid
      {
         get {
            return gxTv_SdtMenuItem_Menuitemfatherid ;
         }

         set {
            gxTv_SdtMenuItem_Menuitemfatherid_N = 0;
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemfatherid = value;
            SetDirty("Menuitemfatherid");
         }

      }

      public void gxTv_SdtMenuItem_Menuitemfatherid_SetNull( )
      {
         gxTv_SdtMenuItem_Menuitemfatherid_N = 1;
         gxTv_SdtMenuItem_Menuitemfatherid = 0;
         SetDirty("Menuitemfatherid");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Menuitemfatherid_IsNull( )
      {
         return (gxTv_SdtMenuItem_Menuitemfatherid_N==1) ;
      }

      [  SoapElement( ElementName = "MenuItemFatherCaption" )]
      [  XmlElement( ElementName = "MenuItemFatherCaption"   )]
      public string gxTpr_Menuitemfathercaption
      {
         get {
            return gxTv_SdtMenuItem_Menuitemfathercaption ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemfathercaption = value;
            SetDirty("Menuitemfathercaption");
         }

      }

      [  SoapElement( ElementName = "MenuItemFatherType" )]
      [  XmlElement( ElementName = "MenuItemFatherType"   )]
      public short gxTpr_Menuitemfathertype
      {
         get {
            return gxTv_SdtMenuItem_Menuitemfathertype ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemfathertype = value;
            SetDirty("Menuitemfathertype");
         }

      }

      [  SoapElement( ElementName = "MenuItemType" )]
      [  XmlElement( ElementName = "MenuItemType"   )]
      public short gxTpr_Menuitemtype
      {
         get {
            return gxTv_SdtMenuItem_Menuitemtype ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemtype = value;
            SetDirty("Menuitemtype");
         }

      }

      [  SoapElement( ElementName = "MenuItemLink" )]
      [  XmlElement( ElementName = "MenuItemLink"   )]
      public string gxTpr_Menuitemlink
      {
         get {
            return gxTv_SdtMenuItem_Menuitemlink ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemlink = value;
            SetDirty("Menuitemlink");
         }

      }

      [  SoapElement( ElementName = "MenuItemLinkParameters" )]
      [  XmlElement( ElementName = "MenuItemLinkParameters"   )]
      public string gxTpr_Menuitemlinkparameters
      {
         get {
            return gxTv_SdtMenuItem_Menuitemlinkparameters ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemlinkparameters = value;
            SetDirty("Menuitemlinkparameters");
         }

      }

      [  SoapElement( ElementName = "MenuItemLinkTarget" )]
      [  XmlElement( ElementName = "MenuItemLinkTarget"   )]
      public string gxTpr_Menuitemlinktarget
      {
         get {
            return gxTv_SdtMenuItem_Menuitemlinktarget ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemlinktarget = value;
            SetDirty("Menuitemlinktarget");
         }

      }

      [  SoapElement( ElementName = "MenuItemIconClass" )]
      [  XmlElement( ElementName = "MenuItemIconClass"   )]
      public string gxTpr_Menuitemiconclass
      {
         get {
            return gxTv_SdtMenuItem_Menuitemiconclass ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemiconclass = value;
            SetDirty("Menuitemiconclass");
         }

      }

      [  SoapElement( ElementName = "MenuItemShowDeveloperMenuOption" )]
      [  XmlElement( ElementName = "MenuItemShowDeveloperMenuOption"   )]
      public bool gxTpr_Menuitemshowdevelopermenuoption
      {
         get {
            return gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption = value;
            SetDirty("Menuitemshowdevelopermenuoption");
         }

      }

      [  SoapElement( ElementName = "MenuItemShowEditMenuOptions" )]
      [  XmlElement( ElementName = "MenuItemShowEditMenuOptions"   )]
      public bool gxTpr_Menuitemshoweditmenuoptions
      {
         get {
            return gxTv_SdtMenuItem_Menuitemshoweditmenuoptions ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemshoweditmenuoptions = value;
            SetDirty("Menuitemshoweditmenuoptions");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtMenuItem_Mode ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtMenuItem_Mode_SetNull( )
      {
         gxTv_SdtMenuItem_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtMenuItem_Initialized ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtMenuItem_Initialized_SetNull( )
      {
         gxTv_SdtMenuItem_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MenuItemId_Z" )]
      [  XmlElement( ElementName = "MenuItemId_Z"   )]
      public short gxTpr_Menuitemid_Z
      {
         get {
            return gxTv_SdtMenuItem_Menuitemid_Z ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemid_Z = value;
            SetDirty("Menuitemid_Z");
         }

      }

      public void gxTv_SdtMenuItem_Menuitemid_Z_SetNull( )
      {
         gxTv_SdtMenuItem_Menuitemid_Z = 0;
         SetDirty("Menuitemid_Z");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Menuitemid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MenuItemCaption_Z" )]
      [  XmlElement( ElementName = "MenuItemCaption_Z"   )]
      public string gxTpr_Menuitemcaption_Z
      {
         get {
            return gxTv_SdtMenuItem_Menuitemcaption_Z ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemcaption_Z = value;
            SetDirty("Menuitemcaption_Z");
         }

      }

      public void gxTv_SdtMenuItem_Menuitemcaption_Z_SetNull( )
      {
         gxTv_SdtMenuItem_Menuitemcaption_Z = "";
         SetDirty("Menuitemcaption_Z");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Menuitemcaption_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MenuItemOrder_Z" )]
      [  XmlElement( ElementName = "MenuItemOrder_Z"   )]
      public short gxTpr_Menuitemorder_Z
      {
         get {
            return gxTv_SdtMenuItem_Menuitemorder_Z ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemorder_Z = value;
            SetDirty("Menuitemorder_Z");
         }

      }

      public void gxTv_SdtMenuItem_Menuitemorder_Z_SetNull( )
      {
         gxTv_SdtMenuItem_Menuitemorder_Z = 0;
         SetDirty("Menuitemorder_Z");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Menuitemorder_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MenuItemFatherId_Z" )]
      [  XmlElement( ElementName = "MenuItemFatherId_Z"   )]
      public short gxTpr_Menuitemfatherid_Z
      {
         get {
            return gxTv_SdtMenuItem_Menuitemfatherid_Z ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemfatherid_Z = value;
            SetDirty("Menuitemfatherid_Z");
         }

      }

      public void gxTv_SdtMenuItem_Menuitemfatherid_Z_SetNull( )
      {
         gxTv_SdtMenuItem_Menuitemfatherid_Z = 0;
         SetDirty("Menuitemfatherid_Z");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Menuitemfatherid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MenuItemFatherCaption_Z" )]
      [  XmlElement( ElementName = "MenuItemFatherCaption_Z"   )]
      public string gxTpr_Menuitemfathercaption_Z
      {
         get {
            return gxTv_SdtMenuItem_Menuitemfathercaption_Z ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemfathercaption_Z = value;
            SetDirty("Menuitemfathercaption_Z");
         }

      }

      public void gxTv_SdtMenuItem_Menuitemfathercaption_Z_SetNull( )
      {
         gxTv_SdtMenuItem_Menuitemfathercaption_Z = "";
         SetDirty("Menuitemfathercaption_Z");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Menuitemfathercaption_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MenuItemFatherType_Z" )]
      [  XmlElement( ElementName = "MenuItemFatherType_Z"   )]
      public short gxTpr_Menuitemfathertype_Z
      {
         get {
            return gxTv_SdtMenuItem_Menuitemfathertype_Z ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemfathertype_Z = value;
            SetDirty("Menuitemfathertype_Z");
         }

      }

      public void gxTv_SdtMenuItem_Menuitemfathertype_Z_SetNull( )
      {
         gxTv_SdtMenuItem_Menuitemfathertype_Z = 0;
         SetDirty("Menuitemfathertype_Z");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Menuitemfathertype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MenuItemType_Z" )]
      [  XmlElement( ElementName = "MenuItemType_Z"   )]
      public short gxTpr_Menuitemtype_Z
      {
         get {
            return gxTv_SdtMenuItem_Menuitemtype_Z ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemtype_Z = value;
            SetDirty("Menuitemtype_Z");
         }

      }

      public void gxTv_SdtMenuItem_Menuitemtype_Z_SetNull( )
      {
         gxTv_SdtMenuItem_Menuitemtype_Z = 0;
         SetDirty("Menuitemtype_Z");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Menuitemtype_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MenuItemLink_Z" )]
      [  XmlElement( ElementName = "MenuItemLink_Z"   )]
      public string gxTpr_Menuitemlink_Z
      {
         get {
            return gxTv_SdtMenuItem_Menuitemlink_Z ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemlink_Z = value;
            SetDirty("Menuitemlink_Z");
         }

      }

      public void gxTv_SdtMenuItem_Menuitemlink_Z_SetNull( )
      {
         gxTv_SdtMenuItem_Menuitemlink_Z = "";
         SetDirty("Menuitemlink_Z");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Menuitemlink_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MenuItemLinkParameters_Z" )]
      [  XmlElement( ElementName = "MenuItemLinkParameters_Z"   )]
      public string gxTpr_Menuitemlinkparameters_Z
      {
         get {
            return gxTv_SdtMenuItem_Menuitemlinkparameters_Z ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemlinkparameters_Z = value;
            SetDirty("Menuitemlinkparameters_Z");
         }

      }

      public void gxTv_SdtMenuItem_Menuitemlinkparameters_Z_SetNull( )
      {
         gxTv_SdtMenuItem_Menuitemlinkparameters_Z = "";
         SetDirty("Menuitemlinkparameters_Z");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Menuitemlinkparameters_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MenuItemLinkTarget_Z" )]
      [  XmlElement( ElementName = "MenuItemLinkTarget_Z"   )]
      public string gxTpr_Menuitemlinktarget_Z
      {
         get {
            return gxTv_SdtMenuItem_Menuitemlinktarget_Z ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemlinktarget_Z = value;
            SetDirty("Menuitemlinktarget_Z");
         }

      }

      public void gxTv_SdtMenuItem_Menuitemlinktarget_Z_SetNull( )
      {
         gxTv_SdtMenuItem_Menuitemlinktarget_Z = "";
         SetDirty("Menuitemlinktarget_Z");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Menuitemlinktarget_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MenuItemIconClass_Z" )]
      [  XmlElement( ElementName = "MenuItemIconClass_Z"   )]
      public string gxTpr_Menuitemiconclass_Z
      {
         get {
            return gxTv_SdtMenuItem_Menuitemiconclass_Z ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemiconclass_Z = value;
            SetDirty("Menuitemiconclass_Z");
         }

      }

      public void gxTv_SdtMenuItem_Menuitemiconclass_Z_SetNull( )
      {
         gxTv_SdtMenuItem_Menuitemiconclass_Z = "";
         SetDirty("Menuitemiconclass_Z");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Menuitemiconclass_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MenuItemShowDeveloperMenuOption_Z" )]
      [  XmlElement( ElementName = "MenuItemShowDeveloperMenuOption_Z"   )]
      public bool gxTpr_Menuitemshowdevelopermenuoption_Z
      {
         get {
            return gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption_Z ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption_Z = value;
            SetDirty("Menuitemshowdevelopermenuoption_Z");
         }

      }

      public void gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption_Z_SetNull( )
      {
         gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption_Z = false;
         SetDirty("Menuitemshowdevelopermenuoption_Z");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MenuItemShowEditMenuOptions_Z" )]
      [  XmlElement( ElementName = "MenuItemShowEditMenuOptions_Z"   )]
      public bool gxTpr_Menuitemshoweditmenuoptions_Z
      {
         get {
            return gxTv_SdtMenuItem_Menuitemshoweditmenuoptions_Z ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemshoweditmenuoptions_Z = value;
            SetDirty("Menuitemshoweditmenuoptions_Z");
         }

      }

      public void gxTv_SdtMenuItem_Menuitemshoweditmenuoptions_Z_SetNull( )
      {
         gxTv_SdtMenuItem_Menuitemshoweditmenuoptions_Z = false;
         SetDirty("Menuitemshoweditmenuoptions_Z");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Menuitemshoweditmenuoptions_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MenuItemFatherId_N" )]
      [  XmlElement( ElementName = "MenuItemFatherId_N"   )]
      public short gxTpr_Menuitemfatherid_N
      {
         get {
            return gxTv_SdtMenuItem_Menuitemfatherid_N ;
         }

         set {
            gxTv_SdtMenuItem_N = 0;
            gxTv_SdtMenuItem_Menuitemfatherid_N = value;
            SetDirty("Menuitemfatherid_N");
         }

      }

      public void gxTv_SdtMenuItem_Menuitemfatherid_N_SetNull( )
      {
         gxTv_SdtMenuItem_Menuitemfatherid_N = 0;
         SetDirty("Menuitemfatherid_N");
         return  ;
      }

      public bool gxTv_SdtMenuItem_Menuitemfatherid_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtMenuItem_N = 1;
         gxTv_SdtMenuItem_Menuitemcaption = "";
         gxTv_SdtMenuItem_Menuitemfathercaption = "";
         gxTv_SdtMenuItem_Menuitemlink = "";
         gxTv_SdtMenuItem_Menuitemlinkparameters = "";
         gxTv_SdtMenuItem_Menuitemlinktarget = "";
         gxTv_SdtMenuItem_Menuitemiconclass = "";
         gxTv_SdtMenuItem_Mode = "";
         gxTv_SdtMenuItem_Menuitemcaption_Z = "";
         gxTv_SdtMenuItem_Menuitemfathercaption_Z = "";
         gxTv_SdtMenuItem_Menuitemlink_Z = "";
         gxTv_SdtMenuItem_Menuitemlinkparameters_Z = "";
         gxTv_SdtMenuItem_Menuitemlinktarget_Z = "";
         gxTv_SdtMenuItem_Menuitemiconclass_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.menuitem", "GeneXus.Programs.wwpbaseobjects.menuitem_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtMenuItem_N ;
      }

      private short gxTv_SdtMenuItem_Menuitemid ;
      private short gxTv_SdtMenuItem_N ;
      private short gxTv_SdtMenuItem_Menuitemorder ;
      private short gxTv_SdtMenuItem_Menuitemfatherid ;
      private short gxTv_SdtMenuItem_Menuitemfathertype ;
      private short gxTv_SdtMenuItem_Menuitemtype ;
      private short gxTv_SdtMenuItem_Initialized ;
      private short gxTv_SdtMenuItem_Menuitemid_Z ;
      private short gxTv_SdtMenuItem_Menuitemorder_Z ;
      private short gxTv_SdtMenuItem_Menuitemfatherid_Z ;
      private short gxTv_SdtMenuItem_Menuitemfathertype_Z ;
      private short gxTv_SdtMenuItem_Menuitemtype_Z ;
      private short gxTv_SdtMenuItem_Menuitemfatherid_N ;
      private string gxTv_SdtMenuItem_Mode ;
      private bool gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption ;
      private bool gxTv_SdtMenuItem_Menuitemshoweditmenuoptions ;
      private bool gxTv_SdtMenuItem_Menuitemshowdevelopermenuoption_Z ;
      private bool gxTv_SdtMenuItem_Menuitemshoweditmenuoptions_Z ;
      private string gxTv_SdtMenuItem_Menuitemcaption ;
      private string gxTv_SdtMenuItem_Menuitemfathercaption ;
      private string gxTv_SdtMenuItem_Menuitemlink ;
      private string gxTv_SdtMenuItem_Menuitemlinkparameters ;
      private string gxTv_SdtMenuItem_Menuitemlinktarget ;
      private string gxTv_SdtMenuItem_Menuitemiconclass ;
      private string gxTv_SdtMenuItem_Menuitemcaption_Z ;
      private string gxTv_SdtMenuItem_Menuitemfathercaption_Z ;
      private string gxTv_SdtMenuItem_Menuitemlink_Z ;
      private string gxTv_SdtMenuItem_Menuitemlinkparameters_Z ;
      private string gxTv_SdtMenuItem_Menuitemlinktarget_Z ;
      private string gxTv_SdtMenuItem_Menuitemiconclass_Z ;
   }

   [DataContract(Name = @"WWPBaseObjects\MenuItem", Namespace = "SIGERP_ADVANCED")]
   public class SdtMenuItem_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtMenuItem>
   {
      public SdtMenuItem_RESTInterface( ) : base()
      {
      }

      public SdtMenuItem_RESTInterface( GeneXus.Programs.wwpbaseobjects.SdtMenuItem psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MenuItemId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Menuitemid
      {
         get {
            return sdt.gxTpr_Menuitemid ;
         }

         set {
            sdt.gxTpr_Menuitemid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MenuItemCaption" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Menuitemcaption
      {
         get {
            return sdt.gxTpr_Menuitemcaption ;
         }

         set {
            sdt.gxTpr_Menuitemcaption = value;
         }

      }

      [DataMember( Name = "MenuItemOrder" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Menuitemorder
      {
         get {
            return sdt.gxTpr_Menuitemorder ;
         }

         set {
            sdt.gxTpr_Menuitemorder = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MenuItemFatherId" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Menuitemfatherid
      {
         get {
            return sdt.gxTpr_Menuitemfatherid ;
         }

         set {
            sdt.gxTpr_Menuitemfatherid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MenuItemFatherCaption" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Menuitemfathercaption
      {
         get {
            return sdt.gxTpr_Menuitemfathercaption ;
         }

         set {
            sdt.gxTpr_Menuitemfathercaption = value;
         }

      }

      [DataMember( Name = "MenuItemFatherType" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Menuitemfathertype
      {
         get {
            return sdt.gxTpr_Menuitemfathertype ;
         }

         set {
            sdt.gxTpr_Menuitemfathertype = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MenuItemType" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Menuitemtype
      {
         get {
            return sdt.gxTpr_Menuitemtype ;
         }

         set {
            sdt.gxTpr_Menuitemtype = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MenuItemLink" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Menuitemlink
      {
         get {
            return sdt.gxTpr_Menuitemlink ;
         }

         set {
            sdt.gxTpr_Menuitemlink = value;
         }

      }

      [DataMember( Name = "MenuItemLinkParameters" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Menuitemlinkparameters
      {
         get {
            return sdt.gxTpr_Menuitemlinkparameters ;
         }

         set {
            sdt.gxTpr_Menuitemlinkparameters = value;
         }

      }

      [DataMember( Name = "MenuItemLinkTarget" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Menuitemlinktarget
      {
         get {
            return sdt.gxTpr_Menuitemlinktarget ;
         }

         set {
            sdt.gxTpr_Menuitemlinktarget = value;
         }

      }

      [DataMember( Name = "MenuItemIconClass" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Menuitemiconclass
      {
         get {
            return sdt.gxTpr_Menuitemiconclass ;
         }

         set {
            sdt.gxTpr_Menuitemiconclass = value;
         }

      }

      [DataMember( Name = "MenuItemShowDeveloperMenuOption" , Order = 11 )]
      [GxSeudo()]
      public bool gxTpr_Menuitemshowdevelopermenuoption
      {
         get {
            return sdt.gxTpr_Menuitemshowdevelopermenuoption ;
         }

         set {
            sdt.gxTpr_Menuitemshowdevelopermenuoption = value;
         }

      }

      [DataMember( Name = "MenuItemShowEditMenuOptions" , Order = 12 )]
      [GxSeudo()]
      public bool gxTpr_Menuitemshoweditmenuoptions
      {
         get {
            return sdt.gxTpr_Menuitemshoweditmenuoptions ;
         }

         set {
            sdt.gxTpr_Menuitemshoweditmenuoptions = value;
         }

      }

      public GeneXus.Programs.wwpbaseobjects.SdtMenuItem sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtMenuItem)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtMenuItem() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 13 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"WWPBaseObjects\MenuItem", Namespace = "SIGERP_ADVANCED")]
   public class SdtMenuItem_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtMenuItem>
   {
      public SdtMenuItem_RESTLInterface( ) : base()
      {
      }

      public SdtMenuItem_RESTLInterface( GeneXus.Programs.wwpbaseobjects.SdtMenuItem psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MenuItemCaption" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Menuitemcaption
      {
         get {
            return sdt.gxTpr_Menuitemcaption ;
         }

         set {
            sdt.gxTpr_Menuitemcaption = value;
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public GeneXus.Programs.wwpbaseobjects.SdtMenuItem sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtMenuItem)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtMenuItem() ;
         }
      }

   }

}
