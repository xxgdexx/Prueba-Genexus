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
namespace GeneXus.Programs.reloj_interface {
   [XmlRoot(ElementName = "Reloj" )]
   [XmlType(TypeName =  "Reloj" , Namespace = "SIGERP_ADVANCED" )]
   [Serializable]
   public class SdtReloj : GxSilentTrnSdt
   {
      public SdtReloj( )
      {
      }

      public SdtReloj( IGxContext context )
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

      public void Load( short AV2430RelojID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV2430RelojID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"RelojID", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Reloj_Interface\\Reloj");
         metadata.Set("BT", "Reloj");
         metadata.Set("PK", "[ \"RelojID\" ]");
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
         state.Add("gxTpr_Relojid_Z");
         state.Add("gxTpr_Reloj_nom_Z");
         state.Add("gxTpr_Reloj_dsc_Z");
         state.Add("gxTpr_Reloj_ip_Z");
         state.Add("gxTpr_Reloj_puerto_Z");
         state.Add("gxTpr_Reloj_estado_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.reloj_interface.SdtReloj sdt;
         sdt = (GeneXus.Programs.reloj_interface.SdtReloj)(source);
         gxTv_SdtReloj_Relojid = sdt.gxTv_SdtReloj_Relojid ;
         gxTv_SdtReloj_Reloj_nom = sdt.gxTv_SdtReloj_Reloj_nom ;
         gxTv_SdtReloj_Reloj_dsc = sdt.gxTv_SdtReloj_Reloj_dsc ;
         gxTv_SdtReloj_Reloj_ip = sdt.gxTv_SdtReloj_Reloj_ip ;
         gxTv_SdtReloj_Reloj_puerto = sdt.gxTv_SdtReloj_Reloj_puerto ;
         gxTv_SdtReloj_Reloj_estado = sdt.gxTv_SdtReloj_Reloj_estado ;
         gxTv_SdtReloj_Mode = sdt.gxTv_SdtReloj_Mode ;
         gxTv_SdtReloj_Initialized = sdt.gxTv_SdtReloj_Initialized ;
         gxTv_SdtReloj_Relojid_Z = sdt.gxTv_SdtReloj_Relojid_Z ;
         gxTv_SdtReloj_Reloj_nom_Z = sdt.gxTv_SdtReloj_Reloj_nom_Z ;
         gxTv_SdtReloj_Reloj_dsc_Z = sdt.gxTv_SdtReloj_Reloj_dsc_Z ;
         gxTv_SdtReloj_Reloj_ip_Z = sdt.gxTv_SdtReloj_Reloj_ip_Z ;
         gxTv_SdtReloj_Reloj_puerto_Z = sdt.gxTv_SdtReloj_Reloj_puerto_Z ;
         gxTv_SdtReloj_Reloj_estado_Z = sdt.gxTv_SdtReloj_Reloj_estado_Z ;
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
         AddObjectProperty("RelojID", gxTv_SdtReloj_Relojid, false, includeNonInitialized);
         AddObjectProperty("Reloj_Nom", gxTv_SdtReloj_Reloj_nom, false, includeNonInitialized);
         AddObjectProperty("Reloj_Dsc", gxTv_SdtReloj_Reloj_dsc, false, includeNonInitialized);
         AddObjectProperty("Reloj_IP", gxTv_SdtReloj_Reloj_ip, false, includeNonInitialized);
         AddObjectProperty("Reloj_Puerto", gxTv_SdtReloj_Reloj_puerto, false, includeNonInitialized);
         AddObjectProperty("Reloj_Estado", gxTv_SdtReloj_Reloj_estado, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtReloj_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtReloj_Initialized, false, includeNonInitialized);
            AddObjectProperty("RelojID_Z", gxTv_SdtReloj_Relojid_Z, false, includeNonInitialized);
            AddObjectProperty("Reloj_Nom_Z", gxTv_SdtReloj_Reloj_nom_Z, false, includeNonInitialized);
            AddObjectProperty("Reloj_Dsc_Z", gxTv_SdtReloj_Reloj_dsc_Z, false, includeNonInitialized);
            AddObjectProperty("Reloj_IP_Z", gxTv_SdtReloj_Reloj_ip_Z, false, includeNonInitialized);
            AddObjectProperty("Reloj_Puerto_Z", gxTv_SdtReloj_Reloj_puerto_Z, false, includeNonInitialized);
            AddObjectProperty("Reloj_Estado_Z", gxTv_SdtReloj_Reloj_estado_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.reloj_interface.SdtReloj sdt )
      {
         if ( sdt.IsDirty("RelojID") )
         {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Relojid = sdt.gxTv_SdtReloj_Relojid ;
         }
         if ( sdt.IsDirty("Reloj_Nom") )
         {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Reloj_nom = sdt.gxTv_SdtReloj_Reloj_nom ;
         }
         if ( sdt.IsDirty("Reloj_Dsc") )
         {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Reloj_dsc = sdt.gxTv_SdtReloj_Reloj_dsc ;
         }
         if ( sdt.IsDirty("Reloj_IP") )
         {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Reloj_ip = sdt.gxTv_SdtReloj_Reloj_ip ;
         }
         if ( sdt.IsDirty("Reloj_Puerto") )
         {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Reloj_puerto = sdt.gxTv_SdtReloj_Reloj_puerto ;
         }
         if ( sdt.IsDirty("Reloj_Estado") )
         {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Reloj_estado = sdt.gxTv_SdtReloj_Reloj_estado ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "RelojID" )]
      [  XmlElement( ElementName = "RelojID"   )]
      public short gxTpr_Relojid
      {
         get {
            return gxTv_SdtReloj_Relojid ;
         }

         set {
            gxTv_SdtReloj_N = 0;
            if ( gxTv_SdtReloj_Relojid != value )
            {
               gxTv_SdtReloj_Mode = "INS";
               this.gxTv_SdtReloj_Relojid_Z_SetNull( );
               this.gxTv_SdtReloj_Reloj_nom_Z_SetNull( );
               this.gxTv_SdtReloj_Reloj_dsc_Z_SetNull( );
               this.gxTv_SdtReloj_Reloj_ip_Z_SetNull( );
               this.gxTv_SdtReloj_Reloj_puerto_Z_SetNull( );
               this.gxTv_SdtReloj_Reloj_estado_Z_SetNull( );
            }
            gxTv_SdtReloj_Relojid = value;
            SetDirty("Relojid");
         }

      }

      [  SoapElement( ElementName = "Reloj_Nom" )]
      [  XmlElement( ElementName = "Reloj_Nom"   )]
      public string gxTpr_Reloj_nom
      {
         get {
            return gxTv_SdtReloj_Reloj_nom ;
         }

         set {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Reloj_nom = value;
            SetDirty("Reloj_nom");
         }

      }

      [  SoapElement( ElementName = "Reloj_Dsc" )]
      [  XmlElement( ElementName = "Reloj_Dsc"   )]
      public string gxTpr_Reloj_dsc
      {
         get {
            return gxTv_SdtReloj_Reloj_dsc ;
         }

         set {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Reloj_dsc = value;
            SetDirty("Reloj_dsc");
         }

      }

      [  SoapElement( ElementName = "Reloj_IP" )]
      [  XmlElement( ElementName = "Reloj_IP"   )]
      public string gxTpr_Reloj_ip
      {
         get {
            return gxTv_SdtReloj_Reloj_ip ;
         }

         set {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Reloj_ip = value;
            SetDirty("Reloj_ip");
         }

      }

      [  SoapElement( ElementName = "Reloj_Puerto" )]
      [  XmlElement( ElementName = "Reloj_Puerto"   )]
      public string gxTpr_Reloj_puerto
      {
         get {
            return gxTv_SdtReloj_Reloj_puerto ;
         }

         set {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Reloj_puerto = value;
            SetDirty("Reloj_puerto");
         }

      }

      [  SoapElement( ElementName = "Reloj_Estado" )]
      [  XmlElement( ElementName = "Reloj_Estado"   )]
      public short gxTpr_Reloj_estado
      {
         get {
            return gxTv_SdtReloj_Reloj_estado ;
         }

         set {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Reloj_estado = value;
            SetDirty("Reloj_estado");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtReloj_Mode ;
         }

         set {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtReloj_Mode_SetNull( )
      {
         gxTv_SdtReloj_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtReloj_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtReloj_Initialized ;
         }

         set {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtReloj_Initialized_SetNull( )
      {
         gxTv_SdtReloj_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtReloj_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RelojID_Z" )]
      [  XmlElement( ElementName = "RelojID_Z"   )]
      public short gxTpr_Relojid_Z
      {
         get {
            return gxTv_SdtReloj_Relojid_Z ;
         }

         set {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Relojid_Z = value;
            SetDirty("Relojid_Z");
         }

      }

      public void gxTv_SdtReloj_Relojid_Z_SetNull( )
      {
         gxTv_SdtReloj_Relojid_Z = 0;
         SetDirty("Relojid_Z");
         return  ;
      }

      public bool gxTv_SdtReloj_Relojid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Reloj_Nom_Z" )]
      [  XmlElement( ElementName = "Reloj_Nom_Z"   )]
      public string gxTpr_Reloj_nom_Z
      {
         get {
            return gxTv_SdtReloj_Reloj_nom_Z ;
         }

         set {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Reloj_nom_Z = value;
            SetDirty("Reloj_nom_Z");
         }

      }

      public void gxTv_SdtReloj_Reloj_nom_Z_SetNull( )
      {
         gxTv_SdtReloj_Reloj_nom_Z = "";
         SetDirty("Reloj_nom_Z");
         return  ;
      }

      public bool gxTv_SdtReloj_Reloj_nom_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Reloj_Dsc_Z" )]
      [  XmlElement( ElementName = "Reloj_Dsc_Z"   )]
      public string gxTpr_Reloj_dsc_Z
      {
         get {
            return gxTv_SdtReloj_Reloj_dsc_Z ;
         }

         set {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Reloj_dsc_Z = value;
            SetDirty("Reloj_dsc_Z");
         }

      }

      public void gxTv_SdtReloj_Reloj_dsc_Z_SetNull( )
      {
         gxTv_SdtReloj_Reloj_dsc_Z = "";
         SetDirty("Reloj_dsc_Z");
         return  ;
      }

      public bool gxTv_SdtReloj_Reloj_dsc_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Reloj_IP_Z" )]
      [  XmlElement( ElementName = "Reloj_IP_Z"   )]
      public string gxTpr_Reloj_ip_Z
      {
         get {
            return gxTv_SdtReloj_Reloj_ip_Z ;
         }

         set {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Reloj_ip_Z = value;
            SetDirty("Reloj_ip_Z");
         }

      }

      public void gxTv_SdtReloj_Reloj_ip_Z_SetNull( )
      {
         gxTv_SdtReloj_Reloj_ip_Z = "";
         SetDirty("Reloj_ip_Z");
         return  ;
      }

      public bool gxTv_SdtReloj_Reloj_ip_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Reloj_Puerto_Z" )]
      [  XmlElement( ElementName = "Reloj_Puerto_Z"   )]
      public string gxTpr_Reloj_puerto_Z
      {
         get {
            return gxTv_SdtReloj_Reloj_puerto_Z ;
         }

         set {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Reloj_puerto_Z = value;
            SetDirty("Reloj_puerto_Z");
         }

      }

      public void gxTv_SdtReloj_Reloj_puerto_Z_SetNull( )
      {
         gxTv_SdtReloj_Reloj_puerto_Z = "";
         SetDirty("Reloj_puerto_Z");
         return  ;
      }

      public bool gxTv_SdtReloj_Reloj_puerto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Reloj_Estado_Z" )]
      [  XmlElement( ElementName = "Reloj_Estado_Z"   )]
      public short gxTpr_Reloj_estado_Z
      {
         get {
            return gxTv_SdtReloj_Reloj_estado_Z ;
         }

         set {
            gxTv_SdtReloj_N = 0;
            gxTv_SdtReloj_Reloj_estado_Z = value;
            SetDirty("Reloj_estado_Z");
         }

      }

      public void gxTv_SdtReloj_Reloj_estado_Z_SetNull( )
      {
         gxTv_SdtReloj_Reloj_estado_Z = 0;
         SetDirty("Reloj_estado_Z");
         return  ;
      }

      public bool gxTv_SdtReloj_Reloj_estado_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtReloj_N = 1;
         gxTv_SdtReloj_Reloj_nom = "";
         gxTv_SdtReloj_Reloj_dsc = "";
         gxTv_SdtReloj_Reloj_ip = "";
         gxTv_SdtReloj_Reloj_puerto = "";
         gxTv_SdtReloj_Mode = "";
         gxTv_SdtReloj_Reloj_nom_Z = "";
         gxTv_SdtReloj_Reloj_dsc_Z = "";
         gxTv_SdtReloj_Reloj_ip_Z = "";
         gxTv_SdtReloj_Reloj_puerto_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "reloj_interface.reloj", "GeneXus.Programs.reloj_interface.reloj_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtReloj_N ;
      }

      private short gxTv_SdtReloj_Relojid ;
      private short gxTv_SdtReloj_N ;
      private short gxTv_SdtReloj_Reloj_estado ;
      private short gxTv_SdtReloj_Initialized ;
      private short gxTv_SdtReloj_Relojid_Z ;
      private short gxTv_SdtReloj_Reloj_estado_Z ;
      private string gxTv_SdtReloj_Mode ;
      private string gxTv_SdtReloj_Reloj_nom ;
      private string gxTv_SdtReloj_Reloj_dsc ;
      private string gxTv_SdtReloj_Reloj_ip ;
      private string gxTv_SdtReloj_Reloj_puerto ;
      private string gxTv_SdtReloj_Reloj_nom_Z ;
      private string gxTv_SdtReloj_Reloj_dsc_Z ;
      private string gxTv_SdtReloj_Reloj_ip_Z ;
      private string gxTv_SdtReloj_Reloj_puerto_Z ;
   }

   [DataContract(Name = @"Reloj_Interface\Reloj", Namespace = "SIGERP_ADVANCED")]
   public class SdtReloj_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.reloj_interface.SdtReloj>
   {
      public SdtReloj_RESTInterface( ) : base()
      {
      }

      public SdtReloj_RESTInterface( GeneXus.Programs.reloj_interface.SdtReloj psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RelojID" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Relojid
      {
         get {
            return sdt.gxTpr_Relojid ;
         }

         set {
            sdt.gxTpr_Relojid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Reloj_Nom" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Reloj_nom
      {
         get {
            return sdt.gxTpr_Reloj_nom ;
         }

         set {
            sdt.gxTpr_Reloj_nom = value;
         }

      }

      [DataMember( Name = "Reloj_Dsc" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Reloj_dsc
      {
         get {
            return sdt.gxTpr_Reloj_dsc ;
         }

         set {
            sdt.gxTpr_Reloj_dsc = value;
         }

      }

      [DataMember( Name = "Reloj_IP" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Reloj_ip
      {
         get {
            return sdt.gxTpr_Reloj_ip ;
         }

         set {
            sdt.gxTpr_Reloj_ip = value;
         }

      }

      [DataMember( Name = "Reloj_Puerto" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Reloj_puerto
      {
         get {
            return sdt.gxTpr_Reloj_puerto ;
         }

         set {
            sdt.gxTpr_Reloj_puerto = value;
         }

      }

      [DataMember( Name = "Reloj_Estado" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Reloj_estado
      {
         get {
            return sdt.gxTpr_Reloj_estado ;
         }

         set {
            sdt.gxTpr_Reloj_estado = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public GeneXus.Programs.reloj_interface.SdtReloj sdt
      {
         get {
            return (GeneXus.Programs.reloj_interface.SdtReloj)Sdt ;
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
            sdt = new GeneXus.Programs.reloj_interface.SdtReloj() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 6 )]
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

   [DataContract(Name = @"Reloj_Interface\Reloj", Namespace = "SIGERP_ADVANCED")]
   public class SdtReloj_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.reloj_interface.SdtReloj>
   {
      public SdtReloj_RESTLInterface( ) : base()
      {
      }

      public SdtReloj_RESTLInterface( GeneXus.Programs.reloj_interface.SdtReloj psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "Reloj_Nom" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Reloj_nom
      {
         get {
            return sdt.gxTpr_Reloj_nom ;
         }

         set {
            sdt.gxTpr_Reloj_nom = value;
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

      public GeneXus.Programs.reloj_interface.SdtReloj sdt
      {
         get {
            return (GeneXus.Programs.reloj_interface.SdtReloj)Sdt ;
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
            sdt = new GeneXus.Programs.reloj_interface.SdtReloj() ;
         }
      }

   }

}
