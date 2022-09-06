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
   [XmlRoot(ElementName = "Notificaciones" )]
   [XmlType(TypeName =  "Notificaciones" , Namespace = "SIGERP_ADVANCED" )]
   [Serializable]
   public class SdtNotificaciones : GxSilentTrnSdt
   {
      public SdtNotificaciones( )
      {
      }

      public SdtNotificaciones( IGxContext context )
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

      public void Load( long AV2237SGNotificacionID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV2237SGNotificacionID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SGNotificacionID", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Seguridad\\Notificaciones");
         metadata.Set("BT", "SGNOTIFICACIONES");
         metadata.Set("PK", "[ \"SGNotificacionID\" ]");
         metadata.Set("PKAssigned", "[ \"SGNotificacionID\" ]");
         metadata.Set("Levels", "[ \"Level1\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"UsuCod\" ],\"FKMap\":[ \"SGNotificacionUsuario-UsuCod\" ] } ]");
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
         state.Add("gxTpr_Sgnotificacionid_Z");
         state.Add("gxTpr_Sgnotificaciontitulo_Z");
         state.Add("gxTpr_Sgnotificaciondescripcion_Z");
         state.Add("gxTpr_Sgnotificacionfecha_Z_Nullable");
         state.Add("gxTpr_Sgnotificacionusuario_Z");
         state.Add("gxTpr_Sgnotificacionusuariodsc_Z");
         state.Add("gxTpr_Sgnotificacioniconclass_Z");
         state.Add("gxTpr_Sgnotificaciontusuario_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.seguridad.SdtNotificaciones sdt;
         sdt = (GeneXus.Programs.seguridad.SdtNotificaciones)(source);
         gxTv_SdtNotificaciones_Sgnotificacionid = sdt.gxTv_SdtNotificaciones_Sgnotificacionid ;
         gxTv_SdtNotificaciones_Sgnotificaciontitulo = sdt.gxTv_SdtNotificaciones_Sgnotificaciontitulo ;
         gxTv_SdtNotificaciones_Sgnotificaciondescripcion = sdt.gxTv_SdtNotificaciones_Sgnotificaciondescripcion ;
         gxTv_SdtNotificaciones_Sgnotificacionfecha = sdt.gxTv_SdtNotificaciones_Sgnotificacionfecha ;
         gxTv_SdtNotificaciones_Sgnotificacionusuario = sdt.gxTv_SdtNotificaciones_Sgnotificacionusuario ;
         gxTv_SdtNotificaciones_Sgnotificacionusuariodsc = sdt.gxTv_SdtNotificaciones_Sgnotificacionusuariodsc ;
         gxTv_SdtNotificaciones_Sgnotificacioniconclass = sdt.gxTv_SdtNotificaciones_Sgnotificacioniconclass ;
         gxTv_SdtNotificaciones_Sgnotificaciontusuario = sdt.gxTv_SdtNotificaciones_Sgnotificaciontusuario ;
         gxTv_SdtNotificaciones_Level1 = sdt.gxTv_SdtNotificaciones_Level1 ;
         gxTv_SdtNotificaciones_Mode = sdt.gxTv_SdtNotificaciones_Mode ;
         gxTv_SdtNotificaciones_Initialized = sdt.gxTv_SdtNotificaciones_Initialized ;
         gxTv_SdtNotificaciones_Sgnotificacionid_Z = sdt.gxTv_SdtNotificaciones_Sgnotificacionid_Z ;
         gxTv_SdtNotificaciones_Sgnotificaciontitulo_Z = sdt.gxTv_SdtNotificaciones_Sgnotificaciontitulo_Z ;
         gxTv_SdtNotificaciones_Sgnotificaciondescripcion_Z = sdt.gxTv_SdtNotificaciones_Sgnotificaciondescripcion_Z ;
         gxTv_SdtNotificaciones_Sgnotificacionfecha_Z = sdt.gxTv_SdtNotificaciones_Sgnotificacionfecha_Z ;
         gxTv_SdtNotificaciones_Sgnotificacionusuario_Z = sdt.gxTv_SdtNotificaciones_Sgnotificacionusuario_Z ;
         gxTv_SdtNotificaciones_Sgnotificacionusuariodsc_Z = sdt.gxTv_SdtNotificaciones_Sgnotificacionusuariodsc_Z ;
         gxTv_SdtNotificaciones_Sgnotificacioniconclass_Z = sdt.gxTv_SdtNotificaciones_Sgnotificacioniconclass_Z ;
         gxTv_SdtNotificaciones_Sgnotificaciontusuario_Z = sdt.gxTv_SdtNotificaciones_Sgnotificaciontusuario_Z ;
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
         AddObjectProperty("SGNotificacionID", gxTv_SdtNotificaciones_Sgnotificacionid, false, includeNonInitialized);
         AddObjectProperty("SGNotificacionTitulo", gxTv_SdtNotificaciones_Sgnotificaciontitulo, false, includeNonInitialized);
         AddObjectProperty("SGNotificacionDescripcion", gxTv_SdtNotificaciones_Sgnotificaciondescripcion, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtNotificaciones_Sgnotificacionfecha;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("SGNotificacionFecha", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("SGNotificacionUsuario", gxTv_SdtNotificaciones_Sgnotificacionusuario, false, includeNonInitialized);
         AddObjectProperty("SGNotificacionUsuarioDsc", gxTv_SdtNotificaciones_Sgnotificacionusuariodsc, false, includeNonInitialized);
         AddObjectProperty("SGNotificacionIconClass", gxTv_SdtNotificaciones_Sgnotificacioniconclass, false, includeNonInitialized);
         AddObjectProperty("SGNotificacionTUsuario", gxTv_SdtNotificaciones_Sgnotificaciontusuario, false, includeNonInitialized);
         if ( gxTv_SdtNotificaciones_Level1 != null )
         {
            AddObjectProperty("Level1", gxTv_SdtNotificaciones_Level1, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtNotificaciones_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtNotificaciones_Initialized, false, includeNonInitialized);
            AddObjectProperty("SGNotificacionID_Z", gxTv_SdtNotificaciones_Sgnotificacionid_Z, false, includeNonInitialized);
            AddObjectProperty("SGNotificacionTitulo_Z", gxTv_SdtNotificaciones_Sgnotificaciontitulo_Z, false, includeNonInitialized);
            AddObjectProperty("SGNotificacionDescripcion_Z", gxTv_SdtNotificaciones_Sgnotificaciondescripcion_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtNotificaciones_Sgnotificacionfecha_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("SGNotificacionFecha_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("SGNotificacionUsuario_Z", gxTv_SdtNotificaciones_Sgnotificacionusuario_Z, false, includeNonInitialized);
            AddObjectProperty("SGNotificacionUsuarioDsc_Z", gxTv_SdtNotificaciones_Sgnotificacionusuariodsc_Z, false, includeNonInitialized);
            AddObjectProperty("SGNotificacionIconClass_Z", gxTv_SdtNotificaciones_Sgnotificacioniconclass_Z, false, includeNonInitialized);
            AddObjectProperty("SGNotificacionTUsuario_Z", gxTv_SdtNotificaciones_Sgnotificaciontusuario_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.seguridad.SdtNotificaciones sdt )
      {
         if ( sdt.IsDirty("SGNotificacionID") )
         {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificacionid = sdt.gxTv_SdtNotificaciones_Sgnotificacionid ;
         }
         if ( sdt.IsDirty("SGNotificacionTitulo") )
         {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificaciontitulo = sdt.gxTv_SdtNotificaciones_Sgnotificaciontitulo ;
         }
         if ( sdt.IsDirty("SGNotificacionDescripcion") )
         {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificaciondescripcion = sdt.gxTv_SdtNotificaciones_Sgnotificaciondescripcion ;
         }
         if ( sdt.IsDirty("SGNotificacionFecha") )
         {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificacionfecha = sdt.gxTv_SdtNotificaciones_Sgnotificacionfecha ;
         }
         if ( sdt.IsDirty("SGNotificacionUsuario") )
         {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificacionusuario = sdt.gxTv_SdtNotificaciones_Sgnotificacionusuario ;
         }
         if ( sdt.IsDirty("SGNotificacionUsuarioDsc") )
         {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificacionusuariodsc = sdt.gxTv_SdtNotificaciones_Sgnotificacionusuariodsc ;
         }
         if ( sdt.IsDirty("SGNotificacionIconClass") )
         {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificacioniconclass = sdt.gxTv_SdtNotificaciones_Sgnotificacioniconclass ;
         }
         if ( sdt.IsDirty("SGNotificacionTUsuario") )
         {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificaciontusuario = sdt.gxTv_SdtNotificaciones_Sgnotificaciontusuario ;
         }
         if ( gxTv_SdtNotificaciones_Level1 != null )
         {
            GXBCLevelCollection<GeneXus.Programs.seguridad.SdtNotificaciones_Level1> newCollectionLevel1 = sdt.gxTpr_Level1;
            GeneXus.Programs.seguridad.SdtNotificaciones_Level1 currItemLevel1;
            GeneXus.Programs.seguridad.SdtNotificaciones_Level1 newItemLevel1;
            short idx = 1;
            while ( idx <= newCollectionLevel1.Count )
            {
               newItemLevel1 = ((GeneXus.Programs.seguridad.SdtNotificaciones_Level1)newCollectionLevel1.Item(idx));
               currItemLevel1 = gxTv_SdtNotificaciones_Level1.GetByKey(newItemLevel1.gxTpr_Sgnotificaciondetid);
               if ( StringUtil.StrCmp(currItemLevel1.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemLevel1.UpdateDirties(newItemLevel1);
                  if ( StringUtil.StrCmp(newItemLevel1.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemLevel1.gxTpr_Mode = "DLT";
                  }
                  currItemLevel1.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtNotificaciones_Level1.Add(newItemLevel1, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "SGNotificacionID" )]
      [  XmlElement( ElementName = "SGNotificacionID"   )]
      public long gxTpr_Sgnotificacionid
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificacionid ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            if ( gxTv_SdtNotificaciones_Sgnotificacionid != value )
            {
               gxTv_SdtNotificaciones_Mode = "INS";
               this.gxTv_SdtNotificaciones_Sgnotificacionid_Z_SetNull( );
               this.gxTv_SdtNotificaciones_Sgnotificaciontitulo_Z_SetNull( );
               this.gxTv_SdtNotificaciones_Sgnotificaciondescripcion_Z_SetNull( );
               this.gxTv_SdtNotificaciones_Sgnotificacionfecha_Z_SetNull( );
               this.gxTv_SdtNotificaciones_Sgnotificacionusuario_Z_SetNull( );
               this.gxTv_SdtNotificaciones_Sgnotificacionusuariodsc_Z_SetNull( );
               this.gxTv_SdtNotificaciones_Sgnotificacioniconclass_Z_SetNull( );
               this.gxTv_SdtNotificaciones_Sgnotificaciontusuario_Z_SetNull( );
               if ( gxTv_SdtNotificaciones_Level1 != null )
               {
                  GXBCLevelCollection<GeneXus.Programs.seguridad.SdtNotificaciones_Level1> collectionLevel1 = gxTv_SdtNotificaciones_Level1;
                  GeneXus.Programs.seguridad.SdtNotificaciones_Level1 currItemLevel1;
                  short idx = 1;
                  while ( idx <= collectionLevel1.Count )
                  {
                     currItemLevel1 = ((GeneXus.Programs.seguridad.SdtNotificaciones_Level1)collectionLevel1.Item(idx));
                     currItemLevel1.gxTpr_Mode = "INS";
                     currItemLevel1.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtNotificaciones_Sgnotificacionid = value;
            SetDirty("Sgnotificacionid");
         }

      }

      [  SoapElement( ElementName = "SGNotificacionTitulo" )]
      [  XmlElement( ElementName = "SGNotificacionTitulo"   )]
      public string gxTpr_Sgnotificaciontitulo
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificaciontitulo ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificaciontitulo = value;
            SetDirty("Sgnotificaciontitulo");
         }

      }

      [  SoapElement( ElementName = "SGNotificacionDescripcion" )]
      [  XmlElement( ElementName = "SGNotificacionDescripcion"   )]
      public string gxTpr_Sgnotificaciondescripcion
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificaciondescripcion ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificaciondescripcion = value;
            SetDirty("Sgnotificaciondescripcion");
         }

      }

      [  SoapElement( ElementName = "SGNotificacionFecha" )]
      [  XmlElement( ElementName = "SGNotificacionFecha"  , IsNullable=true )]
      public string gxTpr_Sgnotificacionfecha_Nullable
      {
         get {
            if ( gxTv_SdtNotificaciones_Sgnotificacionfecha == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNotificaciones_Sgnotificacionfecha).value ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNotificaciones_Sgnotificacionfecha = DateTime.MinValue;
            else
               gxTv_SdtNotificaciones_Sgnotificacionfecha = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Sgnotificacionfecha
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificacionfecha ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificacionfecha = value;
            SetDirty("Sgnotificacionfecha");
         }

      }

      [  SoapElement( ElementName = "SGNotificacionUsuario" )]
      [  XmlElement( ElementName = "SGNotificacionUsuario"   )]
      public string gxTpr_Sgnotificacionusuario
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificacionusuario ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificacionusuario = value;
            SetDirty("Sgnotificacionusuario");
         }

      }

      [  SoapElement( ElementName = "SGNotificacionUsuarioDsc" )]
      [  XmlElement( ElementName = "SGNotificacionUsuarioDsc"   )]
      public string gxTpr_Sgnotificacionusuariodsc
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificacionusuariodsc ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificacionusuariodsc = value;
            SetDirty("Sgnotificacionusuariodsc");
         }

      }

      [  SoapElement( ElementName = "SGNotificacionIconClass" )]
      [  XmlElement( ElementName = "SGNotificacionIconClass"   )]
      public string gxTpr_Sgnotificacioniconclass
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificacioniconclass ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificacioniconclass = value;
            SetDirty("Sgnotificacioniconclass");
         }

      }

      [  SoapElement( ElementName = "SGNotificacionTUsuario" )]
      [  XmlElement( ElementName = "SGNotificacionTUsuario"   )]
      public short gxTpr_Sgnotificaciontusuario
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificaciontusuario ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificaciontusuario = value;
            SetDirty("Sgnotificaciontusuario");
         }

      }

      [  SoapElement( ElementName = "Level1" )]
      [  XmlArray( ElementName = "Level1"  )]
      [  XmlArrayItemAttribute( ElementName= "Notificaciones.Level1"  , IsNullable=false)]
      public GXBCLevelCollection<GeneXus.Programs.seguridad.SdtNotificaciones_Level1> gxTpr_Level1_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtNotificaciones_Level1 == null )
            {
               gxTv_SdtNotificaciones_Level1 = new GXBCLevelCollection<GeneXus.Programs.seguridad.SdtNotificaciones_Level1>( context, "Notificaciones.Level1", "SIGERP_ADVANCED");
            }
            return gxTv_SdtNotificaciones_Level1 ;
         }

         set {
            if ( gxTv_SdtNotificaciones_Level1 == null )
            {
               gxTv_SdtNotificaciones_Level1 = new GXBCLevelCollection<GeneXus.Programs.seguridad.SdtNotificaciones_Level1>( context, "Notificaciones.Level1", "SIGERP_ADVANCED");
            }
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Level1 = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<GeneXus.Programs.seguridad.SdtNotificaciones_Level1> gxTpr_Level1
      {
         get {
            if ( gxTv_SdtNotificaciones_Level1 == null )
            {
               gxTv_SdtNotificaciones_Level1 = new GXBCLevelCollection<GeneXus.Programs.seguridad.SdtNotificaciones_Level1>( context, "Notificaciones.Level1", "SIGERP_ADVANCED");
            }
            gxTv_SdtNotificaciones_N = 0;
            return gxTv_SdtNotificaciones_Level1 ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Level1 = value;
            SetDirty("Level1");
         }

      }

      public void gxTv_SdtNotificaciones_Level1_SetNull( )
      {
         gxTv_SdtNotificaciones_Level1 = null;
         SetDirty("Level1");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Level1_IsNull( )
      {
         if ( gxTv_SdtNotificaciones_Level1 == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtNotificaciones_Mode ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtNotificaciones_Mode_SetNull( )
      {
         gxTv_SdtNotificaciones_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtNotificaciones_Initialized ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtNotificaciones_Initialized_SetNull( )
      {
         gxTv_SdtNotificaciones_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SGNotificacionID_Z" )]
      [  XmlElement( ElementName = "SGNotificacionID_Z"   )]
      public long gxTpr_Sgnotificacionid_Z
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificacionid_Z ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificacionid_Z = value;
            SetDirty("Sgnotificacionid_Z");
         }

      }

      public void gxTv_SdtNotificaciones_Sgnotificacionid_Z_SetNull( )
      {
         gxTv_SdtNotificaciones_Sgnotificacionid_Z = 0;
         SetDirty("Sgnotificacionid_Z");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Sgnotificacionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SGNotificacionTitulo_Z" )]
      [  XmlElement( ElementName = "SGNotificacionTitulo_Z"   )]
      public string gxTpr_Sgnotificaciontitulo_Z
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificaciontitulo_Z ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificaciontitulo_Z = value;
            SetDirty("Sgnotificaciontitulo_Z");
         }

      }

      public void gxTv_SdtNotificaciones_Sgnotificaciontitulo_Z_SetNull( )
      {
         gxTv_SdtNotificaciones_Sgnotificaciontitulo_Z = "";
         SetDirty("Sgnotificaciontitulo_Z");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Sgnotificaciontitulo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SGNotificacionDescripcion_Z" )]
      [  XmlElement( ElementName = "SGNotificacionDescripcion_Z"   )]
      public string gxTpr_Sgnotificaciondescripcion_Z
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificaciondescripcion_Z ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificaciondescripcion_Z = value;
            SetDirty("Sgnotificaciondescripcion_Z");
         }

      }

      public void gxTv_SdtNotificaciones_Sgnotificaciondescripcion_Z_SetNull( )
      {
         gxTv_SdtNotificaciones_Sgnotificaciondescripcion_Z = "";
         SetDirty("Sgnotificaciondescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Sgnotificaciondescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SGNotificacionFecha_Z" )]
      [  XmlElement( ElementName = "SGNotificacionFecha_Z"  , IsNullable=true )]
      public string gxTpr_Sgnotificacionfecha_Z_Nullable
      {
         get {
            if ( gxTv_SdtNotificaciones_Sgnotificacionfecha_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtNotificaciones_Sgnotificacionfecha_Z).value ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtNotificaciones_Sgnotificacionfecha_Z = DateTime.MinValue;
            else
               gxTv_SdtNotificaciones_Sgnotificacionfecha_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Sgnotificacionfecha_Z
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificacionfecha_Z ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificacionfecha_Z = value;
            SetDirty("Sgnotificacionfecha_Z");
         }

      }

      public void gxTv_SdtNotificaciones_Sgnotificacionfecha_Z_SetNull( )
      {
         gxTv_SdtNotificaciones_Sgnotificacionfecha_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Sgnotificacionfecha_Z");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Sgnotificacionfecha_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SGNotificacionUsuario_Z" )]
      [  XmlElement( ElementName = "SGNotificacionUsuario_Z"   )]
      public string gxTpr_Sgnotificacionusuario_Z
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificacionusuario_Z ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificacionusuario_Z = value;
            SetDirty("Sgnotificacionusuario_Z");
         }

      }

      public void gxTv_SdtNotificaciones_Sgnotificacionusuario_Z_SetNull( )
      {
         gxTv_SdtNotificaciones_Sgnotificacionusuario_Z = "";
         SetDirty("Sgnotificacionusuario_Z");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Sgnotificacionusuario_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SGNotificacionUsuarioDsc_Z" )]
      [  XmlElement( ElementName = "SGNotificacionUsuarioDsc_Z"   )]
      public string gxTpr_Sgnotificacionusuariodsc_Z
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificacionusuariodsc_Z ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificacionusuariodsc_Z = value;
            SetDirty("Sgnotificacionusuariodsc_Z");
         }

      }

      public void gxTv_SdtNotificaciones_Sgnotificacionusuariodsc_Z_SetNull( )
      {
         gxTv_SdtNotificaciones_Sgnotificacionusuariodsc_Z = "";
         SetDirty("Sgnotificacionusuariodsc_Z");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Sgnotificacionusuariodsc_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SGNotificacionIconClass_Z" )]
      [  XmlElement( ElementName = "SGNotificacionIconClass_Z"   )]
      public string gxTpr_Sgnotificacioniconclass_Z
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificacioniconclass_Z ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificacioniconclass_Z = value;
            SetDirty("Sgnotificacioniconclass_Z");
         }

      }

      public void gxTv_SdtNotificaciones_Sgnotificacioniconclass_Z_SetNull( )
      {
         gxTv_SdtNotificaciones_Sgnotificacioniconclass_Z = "";
         SetDirty("Sgnotificacioniconclass_Z");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Sgnotificacioniconclass_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SGNotificacionTUsuario_Z" )]
      [  XmlElement( ElementName = "SGNotificacionTUsuario_Z"   )]
      public short gxTpr_Sgnotificaciontusuario_Z
      {
         get {
            return gxTv_SdtNotificaciones_Sgnotificaciontusuario_Z ;
         }

         set {
            gxTv_SdtNotificaciones_N = 0;
            gxTv_SdtNotificaciones_Sgnotificaciontusuario_Z = value;
            SetDirty("Sgnotificaciontusuario_Z");
         }

      }

      public void gxTv_SdtNotificaciones_Sgnotificaciontusuario_Z_SetNull( )
      {
         gxTv_SdtNotificaciones_Sgnotificaciontusuario_Z = 0;
         SetDirty("Sgnotificaciontusuario_Z");
         return  ;
      }

      public bool gxTv_SdtNotificaciones_Sgnotificaciontusuario_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtNotificaciones_N = 1;
         gxTv_SdtNotificaciones_Sgnotificaciontitulo = "";
         gxTv_SdtNotificaciones_Sgnotificaciondescripcion = "";
         gxTv_SdtNotificaciones_Sgnotificacionfecha = (DateTime)(DateTime.MinValue);
         gxTv_SdtNotificaciones_Sgnotificacionusuario = "";
         gxTv_SdtNotificaciones_Sgnotificacionusuariodsc = "";
         gxTv_SdtNotificaciones_Sgnotificacioniconclass = "";
         gxTv_SdtNotificaciones_Mode = "";
         gxTv_SdtNotificaciones_Sgnotificaciontitulo_Z = "";
         gxTv_SdtNotificaciones_Sgnotificaciondescripcion_Z = "";
         gxTv_SdtNotificaciones_Sgnotificacionfecha_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtNotificaciones_Sgnotificacionusuario_Z = "";
         gxTv_SdtNotificaciones_Sgnotificacionusuariodsc_Z = "";
         gxTv_SdtNotificaciones_Sgnotificacioniconclass_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "seguridad.notificaciones", "GeneXus.Programs.seguridad.notificaciones_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtNotificaciones_N ;
      }

      private short gxTv_SdtNotificaciones_N ;
      private short gxTv_SdtNotificaciones_Sgnotificaciontusuario ;
      private short gxTv_SdtNotificaciones_Initialized ;
      private short gxTv_SdtNotificaciones_Sgnotificaciontusuario_Z ;
      private long gxTv_SdtNotificaciones_Sgnotificacionid ;
      private long gxTv_SdtNotificaciones_Sgnotificacionid_Z ;
      private string gxTv_SdtNotificaciones_Sgnotificacionusuario ;
      private string gxTv_SdtNotificaciones_Sgnotificacionusuariodsc ;
      private string gxTv_SdtNotificaciones_Mode ;
      private string gxTv_SdtNotificaciones_Sgnotificacionusuario_Z ;
      private string gxTv_SdtNotificaciones_Sgnotificacionusuariodsc_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtNotificaciones_Sgnotificacionfecha ;
      private DateTime gxTv_SdtNotificaciones_Sgnotificacionfecha_Z ;
      private DateTime datetime_STZ ;
      private string gxTv_SdtNotificaciones_Sgnotificaciontitulo ;
      private string gxTv_SdtNotificaciones_Sgnotificaciondescripcion ;
      private string gxTv_SdtNotificaciones_Sgnotificacioniconclass ;
      private string gxTv_SdtNotificaciones_Sgnotificaciontitulo_Z ;
      private string gxTv_SdtNotificaciones_Sgnotificaciondescripcion_Z ;
      private string gxTv_SdtNotificaciones_Sgnotificacioniconclass_Z ;
      private GXBCLevelCollection<GeneXus.Programs.seguridad.SdtNotificaciones_Level1> gxTv_SdtNotificaciones_Level1=null ;
   }

   [DataContract(Name = @"Seguridad\Notificaciones", Namespace = "SIGERP_ADVANCED")]
   public class SdtNotificaciones_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.seguridad.SdtNotificaciones>
   {
      public SdtNotificaciones_RESTInterface( ) : base()
      {
      }

      public SdtNotificaciones_RESTInterface( GeneXus.Programs.seguridad.SdtNotificaciones psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SGNotificacionID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Sgnotificacionid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Sgnotificacionid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Sgnotificacionid = (long)(NumberUtil.Val( value, "."));
         }

      }

      [DataMember( Name = "SGNotificacionTitulo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Sgnotificaciontitulo
      {
         get {
            return sdt.gxTpr_Sgnotificaciontitulo ;
         }

         set {
            sdt.gxTpr_Sgnotificaciontitulo = value;
         }

      }

      [DataMember( Name = "SGNotificacionDescripcion" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Sgnotificaciondescripcion
      {
         get {
            return sdt.gxTpr_Sgnotificaciondescripcion ;
         }

         set {
            sdt.gxTpr_Sgnotificaciondescripcion = value;
         }

      }

      [DataMember( Name = "SGNotificacionFecha" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Sgnotificacionfecha
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Sgnotificacionfecha) ;
         }

         set {
            sdt.gxTpr_Sgnotificacionfecha = DateTimeUtil.CToT2( value);
         }

      }

      [DataMember( Name = "SGNotificacionUsuario" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Sgnotificacionusuario
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Sgnotificacionusuario) ;
         }

         set {
            sdt.gxTpr_Sgnotificacionusuario = value;
         }

      }

      [DataMember( Name = "SGNotificacionUsuarioDsc" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Sgnotificacionusuariodsc
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Sgnotificacionusuariodsc) ;
         }

         set {
            sdt.gxTpr_Sgnotificacionusuariodsc = value;
         }

      }

      [DataMember( Name = "SGNotificacionIconClass" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Sgnotificacioniconclass
      {
         get {
            return sdt.gxTpr_Sgnotificacioniconclass ;
         }

         set {
            sdt.gxTpr_Sgnotificacioniconclass = value;
         }

      }

      [DataMember( Name = "SGNotificacionTUsuario" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Sgnotificaciontusuario
      {
         get {
            return sdt.gxTpr_Sgnotificaciontusuario ;
         }

         set {
            sdt.gxTpr_Sgnotificaciontusuario = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Level1" , Order = 8 )]
      public GxGenericCollection<GeneXus.Programs.seguridad.SdtNotificaciones_Level1_RESTInterface> gxTpr_Level1
      {
         get {
            return new GxGenericCollection<GeneXus.Programs.seguridad.SdtNotificaciones_Level1_RESTInterface>(sdt.gxTpr_Level1) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Level1);
         }

      }

      public GeneXus.Programs.seguridad.SdtNotificaciones sdt
      {
         get {
            return (GeneXus.Programs.seguridad.SdtNotificaciones)Sdt ;
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
            sdt = new GeneXus.Programs.seguridad.SdtNotificaciones() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 9 )]
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

   [DataContract(Name = @"Seguridad\Notificaciones", Namespace = "SIGERP_ADVANCED")]
   public class SdtNotificaciones_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.seguridad.SdtNotificaciones>
   {
      public SdtNotificaciones_RESTLInterface( ) : base()
      {
      }

      public SdtNotificaciones_RESTLInterface( GeneXus.Programs.seguridad.SdtNotificaciones psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SGNotificacionTitulo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Sgnotificaciontitulo
      {
         get {
            return sdt.gxTpr_Sgnotificaciontitulo ;
         }

         set {
            sdt.gxTpr_Sgnotificaciontitulo = value;
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

      public GeneXus.Programs.seguridad.SdtNotificaciones sdt
      {
         get {
            return (GeneXus.Programs.seguridad.SdtNotificaciones)Sdt ;
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
            sdt = new GeneXus.Programs.seguridad.SdtNotificaciones() ;
         }
      }

   }

}
