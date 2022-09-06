/*
				   File: type_SdtCambioDocumentoComprasData
			Description: CambioDocumentoComprasData
				 Author: Nemo 🐠 for C# (.NET) version 17.0.9.159740
		   Program type: Callable routine
			  Main DBMS: 
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;

using GeneXus.Programs;
namespace GeneXus.Programs.seguridad
{
	[XmlRoot(ElementName="CambioDocumentoComprasData")]
	[XmlType(TypeName="CambioDocumentoComprasData" , Namespace="SIGERP_ADVANCED" )]
	[Serializable]
	public class SdtCambioDocumentoComprasData : GxUserType
	{
		public SdtCambioDocumentoComprasData( )
		{
			/* Constructor for serialization */
		}

		public SdtCambioDocumentoComprasData(IGxContext context)
		{
			this.context = context;	
			initialize();
		}

		#region Json
		private static Hashtable mapper;
		public override string JsonMap(string value)
		{
			if (mapper == null)
			{
				mapper = new Hashtable();
			}
			return (string)mapper[value]; ;
		}

		public override void ToJSON()
		{
			ToJSON(true) ;
			return;
		}

		public override void ToJSON(bool includeState)
		{
			if (gxTv_SdtCambioDocumentoComprasData_Auxiliardata != null)
			{
				AddObjectProperty("AuxiliarData", gxTv_SdtCambioDocumentoComprasData_Auxiliardata, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="AuxiliarData" )]
		[XmlArray(ElementName="AuxiliarData"  )]
		[XmlArrayItemAttribute(ElementName="WizardAuxiliarDataItem" , IsNullable=false )]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata_GXBaseCollection
		{
			get {
				if ( gxTv_SdtCambioDocumentoComprasData_Auxiliardata == null )
				{
					gxTv_SdtCambioDocumentoComprasData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				return gxTv_SdtCambioDocumentoComprasData_Auxiliardata;
			}
			set {
				gxTv_SdtCambioDocumentoComprasData_Auxiliardata_N = false;
				gxTv_SdtCambioDocumentoComprasData_Auxiliardata = value;
			}
		}

		[XmlIgnore]
		public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTpr_Auxiliardata
		{
			get {
				if ( gxTv_SdtCambioDocumentoComprasData_Auxiliardata == null )
				{
					gxTv_SdtCambioDocumentoComprasData_Auxiliardata = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem>( context, "WizardAuxiliarData", "");
				}
				gxTv_SdtCambioDocumentoComprasData_Auxiliardata_N = false;
				return gxTv_SdtCambioDocumentoComprasData_Auxiliardata ;
			}
			set {
				gxTv_SdtCambioDocumentoComprasData_Auxiliardata_N = false;
				gxTv_SdtCambioDocumentoComprasData_Auxiliardata = value;
				SetDirty("Auxiliardata");
			}
		}

		public void gxTv_SdtCambioDocumentoComprasData_Auxiliardata_SetNull()
		{
			gxTv_SdtCambioDocumentoComprasData_Auxiliardata_N = true;
			gxTv_SdtCambioDocumentoComprasData_Auxiliardata = null;
		}

		public bool gxTv_SdtCambioDocumentoComprasData_Auxiliardata_IsNull()
		{
			return gxTv_SdtCambioDocumentoComprasData_Auxiliardata == null;
		}
		public bool ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()
		{
			return gxTv_SdtCambioDocumentoComprasData_Auxiliardata != null && gxTv_SdtCambioDocumentoComprasData_Auxiliardata.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return (
				 ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json()||  
				false);
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtCambioDocumentoComprasData_Auxiliardata_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected bool gxTv_SdtCambioDocumentoComprasData_Auxiliardata_N;
		protected GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem> gxTv_SdtCambioDocumentoComprasData_Auxiliardata = null;  


		#endregion
	}
	#region Rest interface
	[GxUnWrappedJson()]
	[DataContract(Name=@"CambioDocumentoComprasData", Namespace="SIGERP_ADVANCED")]
	public class SdtCambioDocumentoComprasData_RESTInterface : GxGenericCollectionItem<SdtCambioDocumentoComprasData>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtCambioDocumentoComprasData_RESTInterface( ) : base()
		{	
		}

		public SdtCambioDocumentoComprasData_RESTInterface( SdtCambioDocumentoComprasData psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="AuxiliarData", Order=0, EmitDefaultValue=false)]
		public  GxGenericCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface> gxTpr_Auxiliardata
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Auxiliardata_GXBaseCollection_Json())
					return new GxGenericCollection<GeneXus.Programs.wwpbaseobjects.SdtWizardAuxiliarData_WizardAuxiliarDataItem_RESTInterface>(sdt.gxTpr_Auxiliardata);
				else
					return null;

			}
			set { 
				value.LoadCollection(sdt.gxTpr_Auxiliardata);
			}
		}


		#endregion

		public SdtCambioDocumentoComprasData sdt
		{
			get { 
				return (SdtCambioDocumentoComprasData)Sdt;
			}
			set { 
				Sdt = value;
			}
		}

		[OnDeserializing]
		void checkSdt( StreamingContext ctx )
		{
			if ( sdt == null )
			{
				sdt = new SdtCambioDocumentoComprasData() ;
			}
		}
	}
	#endregion
}