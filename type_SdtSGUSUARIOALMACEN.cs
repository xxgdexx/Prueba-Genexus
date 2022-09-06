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
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "SGUSUARIOALMACEN" )]
   [XmlType(TypeName =  "SGUSUARIOALMACEN" , Namespace = "SIGERP_ADVANCED" )]
   [Serializable]
   public class SdtSGUSUARIOALMACEN : GxSilentTrnSdt
   {
      public SdtSGUSUARIOALMACEN( )
      {
      }

      public SdtSGUSUARIOALMACEN( IGxContext context )
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

      public void Load( string AV348UsuCod ,
                        int AV349UsuAlmCod )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(string)AV348UsuCod,(int)AV349UsuAlmCod});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"UsuCod", typeof(string)}, new Object[]{"UsuAlmCod", typeof(int)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "SGUSUARIOALMACEN");
         metadata.Set("BT", "SGUSUARIOALMACEN");
         metadata.Set("PK", "[ \"UsuCod\",\"UsuAlmCod\" ]");
         metadata.Set("PKAssigned", "[ \"UsuAlmCod\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"AlmCod\" ],\"FKMap\":[ \"UsuAlmCod-AlmCod\" ] },{ \"FK\":[ \"UsuCod\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Usucod_Z");
         state.Add("gxTpr_Usualmcod_Z");
         state.Add("gxTpr_Usualmdsc_Z");
         state.Add("gxTpr_Usualmsts_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSGUSUARIOALMACEN sdt;
         sdt = (SdtSGUSUARIOALMACEN)(source);
         gxTv_SdtSGUSUARIOALMACEN_Usucod = sdt.gxTv_SdtSGUSUARIOALMACEN_Usucod ;
         gxTv_SdtSGUSUARIOALMACEN_Usualmcod = sdt.gxTv_SdtSGUSUARIOALMACEN_Usualmcod ;
         gxTv_SdtSGUSUARIOALMACEN_Usualmdsc = sdt.gxTv_SdtSGUSUARIOALMACEN_Usualmdsc ;
         gxTv_SdtSGUSUARIOALMACEN_Usualmsts = sdt.gxTv_SdtSGUSUARIOALMACEN_Usualmsts ;
         gxTv_SdtSGUSUARIOALMACEN_Mode = sdt.gxTv_SdtSGUSUARIOALMACEN_Mode ;
         gxTv_SdtSGUSUARIOALMACEN_Initialized = sdt.gxTv_SdtSGUSUARIOALMACEN_Initialized ;
         gxTv_SdtSGUSUARIOALMACEN_Usucod_Z = sdt.gxTv_SdtSGUSUARIOALMACEN_Usucod_Z ;
         gxTv_SdtSGUSUARIOALMACEN_Usualmcod_Z = sdt.gxTv_SdtSGUSUARIOALMACEN_Usualmcod_Z ;
         gxTv_SdtSGUSUARIOALMACEN_Usualmdsc_Z = sdt.gxTv_SdtSGUSUARIOALMACEN_Usualmdsc_Z ;
         gxTv_SdtSGUSUARIOALMACEN_Usualmsts_Z = sdt.gxTv_SdtSGUSUARIOALMACEN_Usualmsts_Z ;
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
         AddObjectProperty("UsuCod", gxTv_SdtSGUSUARIOALMACEN_Usucod, false, includeNonInitialized);
         AddObjectProperty("UsuAlmCod", gxTv_SdtSGUSUARIOALMACEN_Usualmcod, false, includeNonInitialized);
         AddObjectProperty("UsuAlmDsc", gxTv_SdtSGUSUARIOALMACEN_Usualmdsc, false, includeNonInitialized);
         AddObjectProperty("UsuAlmSts", gxTv_SdtSGUSUARIOALMACEN_Usualmsts, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSGUSUARIOALMACEN_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSGUSUARIOALMACEN_Initialized, false, includeNonInitialized);
            AddObjectProperty("UsuCod_Z", gxTv_SdtSGUSUARIOALMACEN_Usucod_Z, false, includeNonInitialized);
            AddObjectProperty("UsuAlmCod_Z", gxTv_SdtSGUSUARIOALMACEN_Usualmcod_Z, false, includeNonInitialized);
            AddObjectProperty("UsuAlmDsc_Z", gxTv_SdtSGUSUARIOALMACEN_Usualmdsc_Z, false, includeNonInitialized);
            AddObjectProperty("UsuAlmSts_Z", gxTv_SdtSGUSUARIOALMACEN_Usualmsts_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSGUSUARIOALMACEN sdt )
      {
         if ( sdt.IsDirty("UsuCod") )
         {
            gxTv_SdtSGUSUARIOALMACEN_N = 0;
            gxTv_SdtSGUSUARIOALMACEN_Usucod = sdt.gxTv_SdtSGUSUARIOALMACEN_Usucod ;
         }
         if ( sdt.IsDirty("UsuAlmCod") )
         {
            gxTv_SdtSGUSUARIOALMACEN_N = 0;
            gxTv_SdtSGUSUARIOALMACEN_Usualmcod = sdt.gxTv_SdtSGUSUARIOALMACEN_Usualmcod ;
         }
         if ( sdt.IsDirty("UsuAlmDsc") )
         {
            gxTv_SdtSGUSUARIOALMACEN_N = 0;
            gxTv_SdtSGUSUARIOALMACEN_Usualmdsc = sdt.gxTv_SdtSGUSUARIOALMACEN_Usualmdsc ;
         }
         if ( sdt.IsDirty("UsuAlmSts") )
         {
            gxTv_SdtSGUSUARIOALMACEN_N = 0;
            gxTv_SdtSGUSUARIOALMACEN_Usualmsts = sdt.gxTv_SdtSGUSUARIOALMACEN_Usualmsts ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "UsuCod" )]
      [  XmlElement( ElementName = "UsuCod"   )]
      public string gxTpr_Usucod
      {
         get {
            return gxTv_SdtSGUSUARIOALMACEN_Usucod ;
         }

         set {
            gxTv_SdtSGUSUARIOALMACEN_N = 0;
            if ( StringUtil.StrCmp(gxTv_SdtSGUSUARIOALMACEN_Usucod, value) != 0 )
            {
               gxTv_SdtSGUSUARIOALMACEN_Mode = "INS";
               this.gxTv_SdtSGUSUARIOALMACEN_Usucod_Z_SetNull( );
               this.gxTv_SdtSGUSUARIOALMACEN_Usualmcod_Z_SetNull( );
               this.gxTv_SdtSGUSUARIOALMACEN_Usualmdsc_Z_SetNull( );
               this.gxTv_SdtSGUSUARIOALMACEN_Usualmsts_Z_SetNull( );
            }
            gxTv_SdtSGUSUARIOALMACEN_Usucod = value;
            SetDirty("Usucod");
         }

      }

      [  SoapElement( ElementName = "UsuAlmCod" )]
      [  XmlElement( ElementName = "UsuAlmCod"   )]
      public int gxTpr_Usualmcod
      {
         get {
            return gxTv_SdtSGUSUARIOALMACEN_Usualmcod ;
         }

         set {
            gxTv_SdtSGUSUARIOALMACEN_N = 0;
            if ( gxTv_SdtSGUSUARIOALMACEN_Usualmcod != value )
            {
               gxTv_SdtSGUSUARIOALMACEN_Mode = "INS";
               this.gxTv_SdtSGUSUARIOALMACEN_Usucod_Z_SetNull( );
               this.gxTv_SdtSGUSUARIOALMACEN_Usualmcod_Z_SetNull( );
               this.gxTv_SdtSGUSUARIOALMACEN_Usualmdsc_Z_SetNull( );
               this.gxTv_SdtSGUSUARIOALMACEN_Usualmsts_Z_SetNull( );
            }
            gxTv_SdtSGUSUARIOALMACEN_Usualmcod = value;
            SetDirty("Usualmcod");
         }

      }

      [  SoapElement( ElementName = "UsuAlmDsc" )]
      [  XmlElement( ElementName = "UsuAlmDsc"   )]
      public string gxTpr_Usualmdsc
      {
         get {
            return gxTv_SdtSGUSUARIOALMACEN_Usualmdsc ;
         }

         set {
            gxTv_SdtSGUSUARIOALMACEN_N = 0;
            gxTv_SdtSGUSUARIOALMACEN_Usualmdsc = value;
            SetDirty("Usualmdsc");
         }

      }

      [  SoapElement( ElementName = "UsuAlmSts" )]
      [  XmlElement( ElementName = "UsuAlmSts"   )]
      public short gxTpr_Usualmsts
      {
         get {
            return gxTv_SdtSGUSUARIOALMACEN_Usualmsts ;
         }

         set {
            gxTv_SdtSGUSUARIOALMACEN_N = 0;
            gxTv_SdtSGUSUARIOALMACEN_Usualmsts = value;
            SetDirty("Usualmsts");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSGUSUARIOALMACEN_Mode ;
         }

         set {
            gxTv_SdtSGUSUARIOALMACEN_N = 0;
            gxTv_SdtSGUSUARIOALMACEN_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSGUSUARIOALMACEN_Mode_SetNull( )
      {
         gxTv_SdtSGUSUARIOALMACEN_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSGUSUARIOALMACEN_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSGUSUARIOALMACEN_Initialized ;
         }

         set {
            gxTv_SdtSGUSUARIOALMACEN_N = 0;
            gxTv_SdtSGUSUARIOALMACEN_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSGUSUARIOALMACEN_Initialized_SetNull( )
      {
         gxTv_SdtSGUSUARIOALMACEN_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSGUSUARIOALMACEN_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuCod_Z" )]
      [  XmlElement( ElementName = "UsuCod_Z"   )]
      public string gxTpr_Usucod_Z
      {
         get {
            return gxTv_SdtSGUSUARIOALMACEN_Usucod_Z ;
         }

         set {
            gxTv_SdtSGUSUARIOALMACEN_N = 0;
            gxTv_SdtSGUSUARIOALMACEN_Usucod_Z = value;
            SetDirty("Usucod_Z");
         }

      }

      public void gxTv_SdtSGUSUARIOALMACEN_Usucod_Z_SetNull( )
      {
         gxTv_SdtSGUSUARIOALMACEN_Usucod_Z = "";
         SetDirty("Usucod_Z");
         return  ;
      }

      public bool gxTv_SdtSGUSUARIOALMACEN_Usucod_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuAlmCod_Z" )]
      [  XmlElement( ElementName = "UsuAlmCod_Z"   )]
      public int gxTpr_Usualmcod_Z
      {
         get {
            return gxTv_SdtSGUSUARIOALMACEN_Usualmcod_Z ;
         }

         set {
            gxTv_SdtSGUSUARIOALMACEN_N = 0;
            gxTv_SdtSGUSUARIOALMACEN_Usualmcod_Z = value;
            SetDirty("Usualmcod_Z");
         }

      }

      public void gxTv_SdtSGUSUARIOALMACEN_Usualmcod_Z_SetNull( )
      {
         gxTv_SdtSGUSUARIOALMACEN_Usualmcod_Z = 0;
         SetDirty("Usualmcod_Z");
         return  ;
      }

      public bool gxTv_SdtSGUSUARIOALMACEN_Usualmcod_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuAlmDsc_Z" )]
      [  XmlElement( ElementName = "UsuAlmDsc_Z"   )]
      public string gxTpr_Usualmdsc_Z
      {
         get {
            return gxTv_SdtSGUSUARIOALMACEN_Usualmdsc_Z ;
         }

         set {
            gxTv_SdtSGUSUARIOALMACEN_N = 0;
            gxTv_SdtSGUSUARIOALMACEN_Usualmdsc_Z = value;
            SetDirty("Usualmdsc_Z");
         }

      }

      public void gxTv_SdtSGUSUARIOALMACEN_Usualmdsc_Z_SetNull( )
      {
         gxTv_SdtSGUSUARIOALMACEN_Usualmdsc_Z = "";
         SetDirty("Usualmdsc_Z");
         return  ;
      }

      public bool gxTv_SdtSGUSUARIOALMACEN_Usualmdsc_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "UsuAlmSts_Z" )]
      [  XmlElement( ElementName = "UsuAlmSts_Z"   )]
      public short gxTpr_Usualmsts_Z
      {
         get {
            return gxTv_SdtSGUSUARIOALMACEN_Usualmsts_Z ;
         }

         set {
            gxTv_SdtSGUSUARIOALMACEN_N = 0;
            gxTv_SdtSGUSUARIOALMACEN_Usualmsts_Z = value;
            SetDirty("Usualmsts_Z");
         }

      }

      public void gxTv_SdtSGUSUARIOALMACEN_Usualmsts_Z_SetNull( )
      {
         gxTv_SdtSGUSUARIOALMACEN_Usualmsts_Z = 0;
         SetDirty("Usualmsts_Z");
         return  ;
      }

      public bool gxTv_SdtSGUSUARIOALMACEN_Usualmsts_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtSGUSUARIOALMACEN_Usucod = "";
         gxTv_SdtSGUSUARIOALMACEN_N = 1;
         gxTv_SdtSGUSUARIOALMACEN_Usualmdsc = "";
         gxTv_SdtSGUSUARIOALMACEN_Mode = "";
         gxTv_SdtSGUSUARIOALMACEN_Usucod_Z = "";
         gxTv_SdtSGUSUARIOALMACEN_Usualmdsc_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "sgusuarioalmacen", "GeneXus.Programs.sgusuarioalmacen_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtSGUSUARIOALMACEN_N ;
      }

      private short gxTv_SdtSGUSUARIOALMACEN_N ;
      private short gxTv_SdtSGUSUARIOALMACEN_Usualmsts ;
      private short gxTv_SdtSGUSUARIOALMACEN_Initialized ;
      private short gxTv_SdtSGUSUARIOALMACEN_Usualmsts_Z ;
      private int gxTv_SdtSGUSUARIOALMACEN_Usualmcod ;
      private int gxTv_SdtSGUSUARIOALMACEN_Usualmcod_Z ;
      private string gxTv_SdtSGUSUARIOALMACEN_Usucod ;
      private string gxTv_SdtSGUSUARIOALMACEN_Usualmdsc ;
      private string gxTv_SdtSGUSUARIOALMACEN_Mode ;
      private string gxTv_SdtSGUSUARIOALMACEN_Usucod_Z ;
      private string gxTv_SdtSGUSUARIOALMACEN_Usualmdsc_Z ;
   }

   [DataContract(Name = @"SGUSUARIOALMACEN", Namespace = "SIGERP_ADVANCED")]
   public class SdtSGUSUARIOALMACEN_RESTInterface : GxGenericCollectionItem<SdtSGUSUARIOALMACEN>
   {
      public SdtSGUSUARIOALMACEN_RESTInterface( ) : base()
      {
      }

      public SdtSGUSUARIOALMACEN_RESTInterface( SdtSGUSUARIOALMACEN psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UsuCod" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Usucod
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usucod) ;
         }

         set {
            sdt.gxTpr_Usucod = value;
         }

      }

      [DataMember( Name = "UsuAlmCod" , Order = 1 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Usualmcod
      {
         get {
            return sdt.gxTpr_Usualmcod ;
         }

         set {
            sdt.gxTpr_Usualmcod = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "UsuAlmDsc" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Usualmdsc
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usualmdsc) ;
         }

         set {
            sdt.gxTpr_Usualmdsc = value;
         }

      }

      [DataMember( Name = "UsuAlmSts" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Usualmsts
      {
         get {
            return sdt.gxTpr_Usualmsts ;
         }

         set {
            sdt.gxTpr_Usualmsts = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtSGUSUARIOALMACEN sdt
      {
         get {
            return (SdtSGUSUARIOALMACEN)Sdt ;
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
            sdt = new SdtSGUSUARIOALMACEN() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 4 )]
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

   [DataContract(Name = @"SGUSUARIOALMACEN", Namespace = "SIGERP_ADVANCED")]
   public class SdtSGUSUARIOALMACEN_RESTLInterface : GxGenericCollectionItem<SdtSGUSUARIOALMACEN>
   {
      public SdtSGUSUARIOALMACEN_RESTLInterface( ) : base()
      {
      }

      public SdtSGUSUARIOALMACEN_RESTLInterface( SdtSGUSUARIOALMACEN psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "UsuAlmDsc" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Usualmdsc
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usualmdsc) ;
         }

         set {
            sdt.gxTpr_Usualmdsc = value;
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

      public SdtSGUSUARIOALMACEN sdt
      {
         get {
            return (SdtSGUSUARIOALMACEN)Sdt ;
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
            sdt = new SdtSGUSUARIOALMACEN() ;
         }
      }

   }

}
