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
namespace GeneXus.Programs.seguridad {
   [XmlRoot(ElementName = "Notificaciones.Level1" )]
   [XmlType(TypeName =  "Notificaciones.Level1" , Namespace = "SIGERP_ADVANCED" )]
   [Serializable]
   public class SdtNotificaciones_Level1 : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtNotificaciones_Level1( )
      {
      }

      public SdtNotificaciones_Level1( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SGNotificacionDetID", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Level1");
         metadata.Set("BT", "SGNOTIFICACIONESDET");
         metadata.Set("PK", "[ \"SGNotificacionDetID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SGNotificacionID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"UsuCod\" ],\"FKMap\":[ \"SGNotificacionDetUsuario-UsuCod\" ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Sgnotificaciondetid_Z");
         state.Add("gxTpr_Sgnotificaciondetusuario_Z");
         state.Add("gxTpr_Sgnotificaciondetusuariodsc_Z");
         state.Add("gxTpr_Sgnotificaciondetestado_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.seguridad.SdtNotificaciones_Level1 sdt;
         sdt = (GeneXus.Programs.seguridad.SdtNotificaciones_Level1)(source);
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid = sdt.gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid ;
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario = sdt.gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario ;
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc = sdt.gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc ;
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado = sdt.gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado ;
         gxTv_SdtNotificaciones_Level1_Mode = sdt.gxTv_SdtNotificaciones_Level1_Mode ;
         gxTv_SdtNotificaciones_Level1_Modified = sdt.gxTv_SdtNotificaciones_Level1_Modified ;
         gxTv_SdtNotificaciones_Level1_Initialized = sdt.gxTv_SdtNotificaciones_Level1_Initialized ;
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid_Z = sdt.gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid_Z ;
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario_Z = sdt.gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario_Z ;
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc_Z = sdt.gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc_Z ;
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado_Z = sdt.gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado_Z ;
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
         AddObjectProperty("SGNotificacionDetID", gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid, false, includeNonInitialized);
         AddObjectProperty("SGNotificacionDetUsuario", gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario, false, includeNonInitialized);
         AddObjectProperty("SGNotificacionDetUsuarioDsc", gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc, false, includeNonInitialized);
         AddObjectProperty("SGNotificacionDetEstado", gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtNotificaciones_Level1_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtNotificaciones_Level1_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtNotificaciones_Level1_Initialized, false, includeNonInitialized);
            AddObjectProperty("SGNotificacionDetID_Z", gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid_Z, false, includeNonInitialized);
            AddObjectProperty("SGNotificacionDetUsuario_Z", gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario_Z, false, includeNonInitialized);
            AddObjectProperty("SGNotificacionDetUsuarioDsc_Z", gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc_Z, false, includeNonInitialized);
            AddObjectProperty("SGNotificacionDetEstado_Z", gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.seguridad.SdtNotificaciones_Level1 sdt )
      {
         if ( sdt.IsDirty("SGNotificacionDetID") )
         {
            gxTv_SdtNotificaciones_Level1_N = 0;
            gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid = sdt.gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid ;
         }
         if ( sdt.IsDirty("SGNotificacionDetUsuario") )
         {
            gxTv_SdtNotificaciones_Level1_N = 0;
            gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario = sdt.gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario ;
         }
         if ( sdt.IsDirty("SGNotificacionDetUsuarioDsc") )
         {
            gxTv_SdtNotificaciones_Level1_N = 0;
            gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc = sdt.gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc ;
         }
         if ( sdt.IsDirty("SGNotificacionDetEstado") )
         {
            gxTv_SdtNotificaciones_Level1_N = 0;
            gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado = sdt.gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SGNotificacionDetID" )]
      [  XmlElement( ElementName = "SGNotificacionDetID"   )]
      public short gxTpr_Sgnotificaciondetid
      {
         get {
            return gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid ;
         }

         set {
            gxTv_SdtNotificaciones_Level1_N = 0;
            gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid = value;
            gxTv_SdtNotificaciones_Level1_Modified = 1;
            SetDirty("Sgnotificaciondetid");
         }

      }

      [  SoapElement( ElementName = "SGNotificacionDetUsuario" )]
      [  XmlElement( ElementName = "SGNotificacionDetUsuario"   )]
      public string gxTpr_Sgnotificaciondetusuario
      {
         get {
            return gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario ;
         }

         set {
            gxTv_SdtNotificaciones_Level1_N = 0;
            gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario = value;
            gxTv_SdtNotificaciones_Level1_Modified = 1;
            SetDirty("Sgnotificaciondetusuario");
         }

      }

      [  SoapElement( ElementName = "SGNotificacionDetUsuarioDsc" )]
      [  XmlElement( ElementName = "SGNotificacionDetUsuarioDsc"   )]
      public string gxTpr_Sgnotificaciondetusuariodsc
      {
         get {
            return gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc ;
         }

         set {
            gxTv_SdtNotificaciones_Level1_N = 0;
            gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc = value;
            gxTv_SdtNotificaciones_Level1_Modified = 1;
            SetDirty("Sgnotificaciondetusuariodsc");
         }

      }

      [  SoapElement( ElementName = "SGNotificacionDetEstado" )]
      [  XmlElement( ElementName = "SGNotificacionDetEstado"   )]
      public short gxTpr_Sgnotificaciondetestado
      {
         get {
            return gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado ;
         }

         set {
            gxTv_SdtNotificaciones_Level1_N = 0;
            gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado = value;
            gxTv_SdtNotificaciones_Level1_Modified = 1;
            SetDirty("Sgnotificaciondetestado");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtNotificaciones_Level1_Mode ;
         }

         set {
            gxTv_SdtNotificaciones_Level1_N = 0;
            gxTv_SdtNotificaciones_Level1_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtNotificaciones_Level1_Mode_SetNull( )
      {
         gxTv_SdtNotificaciones_Level1_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Level1_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtNotificaciones_Level1_Modified ;
         }

         set {
            gxTv_SdtNotificaciones_Level1_N = 0;
            gxTv_SdtNotificaciones_Level1_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtNotificaciones_Level1_Modified_SetNull( )
      {
         gxTv_SdtNotificaciones_Level1_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Level1_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtNotificaciones_Level1_Initialized ;
         }

         set {
            gxTv_SdtNotificaciones_Level1_N = 0;
            gxTv_SdtNotificaciones_Level1_Initialized = value;
            gxTv_SdtNotificaciones_Level1_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtNotificaciones_Level1_Initialized_SetNull( )
      {
         gxTv_SdtNotificaciones_Level1_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Level1_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SGNotificacionDetID_Z" )]
      [  XmlElement( ElementName = "SGNotificacionDetID_Z"   )]
      public short gxTpr_Sgnotificaciondetid_Z
      {
         get {
            return gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid_Z ;
         }

         set {
            gxTv_SdtNotificaciones_Level1_N = 0;
            gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid_Z = value;
            gxTv_SdtNotificaciones_Level1_Modified = 1;
            SetDirty("Sgnotificaciondetid_Z");
         }

      }

      public void gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid_Z_SetNull( )
      {
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid_Z = 0;
         SetDirty("Sgnotificaciondetid_Z");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SGNotificacionDetUsuario_Z" )]
      [  XmlElement( ElementName = "SGNotificacionDetUsuario_Z"   )]
      public string gxTpr_Sgnotificaciondetusuario_Z
      {
         get {
            return gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario_Z ;
         }

         set {
            gxTv_SdtNotificaciones_Level1_N = 0;
            gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario_Z = value;
            gxTv_SdtNotificaciones_Level1_Modified = 1;
            SetDirty("Sgnotificaciondetusuario_Z");
         }

      }

      public void gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario_Z_SetNull( )
      {
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario_Z = "";
         SetDirty("Sgnotificaciondetusuario_Z");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SGNotificacionDetUsuarioDsc_Z" )]
      [  XmlElement( ElementName = "SGNotificacionDetUsuarioDsc_Z"   )]
      public string gxTpr_Sgnotificaciondetusuariodsc_Z
      {
         get {
            return gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc_Z ;
         }

         set {
            gxTv_SdtNotificaciones_Level1_N = 0;
            gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc_Z = value;
            gxTv_SdtNotificaciones_Level1_Modified = 1;
            SetDirty("Sgnotificaciondetusuariodsc_Z");
         }

      }

      public void gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc_Z_SetNull( )
      {
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc_Z = "";
         SetDirty("Sgnotificaciondetusuariodsc_Z");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SGNotificacionDetEstado_Z" )]
      [  XmlElement( ElementName = "SGNotificacionDetEstado_Z"   )]
      public short gxTpr_Sgnotificaciondetestado_Z
      {
         get {
            return gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado_Z ;
         }

         set {
            gxTv_SdtNotificaciones_Level1_N = 0;
            gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado_Z = value;
            gxTv_SdtNotificaciones_Level1_Modified = 1;
            SetDirty("Sgnotificaciondetestado_Z");
         }

      }

      public void gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado_Z_SetNull( )
      {
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado_Z = 0;
         SetDirty("Sgnotificaciondetestado_Z");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtNotificaciones_Level1_N = 1;
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario = "";
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc = "";
         gxTv_SdtNotificaciones_Level1_Mode = "";
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario_Z = "";
         gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtNotificaciones_Level1_N ;
      }

      private short gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid ;
      private short gxTv_SdtNotificaciones_Level1_N ;
      private short gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado ;
      private short gxTv_SdtNotificaciones_Level1_Modified ;
      private short gxTv_SdtNotificaciones_Level1_Initialized ;
      private short gxTv_SdtNotificaciones_Level1_Sgnotificaciondetid_Z ;
      private short gxTv_SdtNotificaciones_Level1_Sgnotificaciondetestado_Z ;
      private string gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario ;
      private string gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc ;
      private string gxTv_SdtNotificaciones_Level1_Mode ;
      private string gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuario_Z ;
      private string gxTv_SdtNotificaciones_Level1_Sgnotificaciondetusuariodsc_Z ;
   }

   [DataContract(Name = @"Seguridad\Notificaciones.Level1", Namespace = "SIGERP_ADVANCED")]
   public class SdtNotificaciones_Level1_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.seguridad.SdtNotificaciones_Level1>
   {
      public SdtNotificaciones_Level1_RESTInterface( ) : base()
      {
      }

      public SdtNotificaciones_Level1_RESTInterface( GeneXus.Programs.seguridad.SdtNotificaciones_Level1 psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SGNotificacionDetID" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Sgnotificaciondetid
      {
         get {
            return sdt.gxTpr_Sgnotificaciondetid ;
         }

         set {
            sdt.gxTpr_Sgnotificaciondetid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "SGNotificacionDetUsuario" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Sgnotificaciondetusuario
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Sgnotificaciondetusuario) ;
         }

         set {
            sdt.gxTpr_Sgnotificaciondetusuario = value;
         }

      }

      [DataMember( Name = "SGNotificacionDetUsuarioDsc" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Sgnotificaciondetusuariodsc
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Sgnotificaciondetusuariodsc) ;
         }

         set {
            sdt.gxTpr_Sgnotificaciondetusuariodsc = value;
         }

      }

      [DataMember( Name = "SGNotificacionDetEstado" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Sgnotificaciondetestado
      {
         get {
            return sdt.gxTpr_Sgnotificaciondetestado ;
         }

         set {
            sdt.gxTpr_Sgnotificaciondetestado = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public GeneXus.Programs.seguridad.SdtNotificaciones_Level1 sdt
      {
         get {
            return (GeneXus.Programs.seguridad.SdtNotificaciones_Level1)Sdt ;
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
            sdt = new GeneXus.Programs.seguridad.SdtNotificaciones_Level1() ;
         }
      }

   }

   [DataContract(Name = @"Seguridad\Notificaciones.Level1", Namespace = "SIGERP_ADVANCED")]
   public class SdtNotificaciones_Level1_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.seguridad.SdtNotificaciones_Level1>
   {
      public SdtNotificaciones_Level1_RESTLInterface( ) : base()
      {
      }

      public SdtNotificaciones_Level1_RESTLInterface( GeneXus.Programs.seguridad.SdtNotificaciones_Level1 psdt ) : base(psdt)
      {
      }

      public GeneXus.Programs.seguridad.SdtNotificaciones_Level1 sdt
      {
         get {
            return (GeneXus.Programs.seguridad.SdtNotificaciones_Level1)Sdt ;
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
            sdt = new GeneXus.Programs.seguridad.SdtNotificaciones_Level1() ;
         }
      }

   }

}
