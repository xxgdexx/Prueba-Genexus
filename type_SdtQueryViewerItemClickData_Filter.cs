/*
				   File: type_SdtQueryViewerItemClickData_Filter
			Description: Filters
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


namespace GeneXus.Programs
{
	[XmlRoot(ElementName="QueryViewerItemClickData.Filter")]
	[XmlType(TypeName="QueryViewerItemClickData.Filter" , Namespace="SIGERP_ADVANCED" )]
	[Serializable]
	public class SdtQueryViewerItemClickData_Filter : GxUserType
	{
		public SdtQueryViewerItemClickData_Filter( )
		{
			/* Constructor for serialization */
			gxTv_SdtQueryViewerItemClickData_Filter_Name = "";

		}

		public SdtQueryViewerItemClickData_Filter(IGxContext context)
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
			AddObjectProperty("Name", gxTpr_Name, false);

			if (gxTv_SdtQueryViewerItemClickData_Filter_Values != null)
			{
				AddObjectProperty("Values", gxTv_SdtQueryViewerItemClickData_Filter_Values, false);
			}
			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="Name")]
		[XmlElement(ElementName="Name")]
		public string gxTpr_Name
		{
			get {
				return gxTv_SdtQueryViewerItemClickData_Filter_Name; 
			}
			set {
				gxTv_SdtQueryViewerItemClickData_Filter_Name = value;
				SetDirty("Name");
			}
		}




		[SoapElement(ElementName="Values" )]
		[XmlArray(ElementName="Values"  )]
		[XmlArrayItemAttribute(ElementName="Item" , IsNullable=false )]
		public GxSimpleCollection<string> gxTpr_Values_GxSimpleCollection
		{
			get {
				if ( gxTv_SdtQueryViewerItemClickData_Filter_Values == null )
				{
					gxTv_SdtQueryViewerItemClickData_Filter_Values = new GxSimpleCollection<string>( );
				}
				return gxTv_SdtQueryViewerItemClickData_Filter_Values;
			}
			set {
				gxTv_SdtQueryViewerItemClickData_Filter_Values_N = false;
				gxTv_SdtQueryViewerItemClickData_Filter_Values = value;
			}
		}

		[XmlIgnore]
		public GxSimpleCollection<string> gxTpr_Values
		{
			get {
				if ( gxTv_SdtQueryViewerItemClickData_Filter_Values == null )
				{
					gxTv_SdtQueryViewerItemClickData_Filter_Values = new GxSimpleCollection<string>();
				}
				gxTv_SdtQueryViewerItemClickData_Filter_Values_N = false;
				return gxTv_SdtQueryViewerItemClickData_Filter_Values ;
			}
			set {
				gxTv_SdtQueryViewerItemClickData_Filter_Values_N = false;
				gxTv_SdtQueryViewerItemClickData_Filter_Values = value;
				SetDirty("Values");
			}
		}

		public void gxTv_SdtQueryViewerItemClickData_Filter_Values_SetNull()
		{
			gxTv_SdtQueryViewerItemClickData_Filter_Values_N = true;
			gxTv_SdtQueryViewerItemClickData_Filter_Values = null;
		}

		public bool gxTv_SdtQueryViewerItemClickData_Filter_Values_IsNull()
		{
			return gxTv_SdtQueryViewerItemClickData_Filter_Values == null;
		}
		public bool ShouldSerializegxTpr_Values_GxSimpleCollection_Json()
		{
			return gxTv_SdtQueryViewerItemClickData_Filter_Values != null && gxTv_SdtQueryViewerItemClickData_Filter_Values.Count > 0;

		}

		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtQueryViewerItemClickData_Filter_Name = "";

			gxTv_SdtQueryViewerItemClickData_Filter_Values_N = true;

			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtQueryViewerItemClickData_Filter_Name;
		 
		protected bool gxTv_SdtQueryViewerItemClickData_Filter_Values_N;
		protected GxSimpleCollection<string> gxTv_SdtQueryViewerItemClickData_Filter_Values = null;  


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"QueryViewerItemClickData.Filter", Namespace="SIGERP_ADVANCED")]
	public class SdtQueryViewerItemClickData_Filter_RESTInterface : GxGenericCollectionItem<SdtQueryViewerItemClickData_Filter>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtQueryViewerItemClickData_Filter_RESTInterface( ) : base()
		{	
		}

		public SdtQueryViewerItemClickData_Filter_RESTInterface( SdtQueryViewerItemClickData_Filter psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="Name", Order=0)]
		public  string gxTpr_Name
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Name);

			}
			set { 
				 sdt.gxTpr_Name = value;
			}
		}

		[DataMember(Name="Values", Order=1, EmitDefaultValue=false)]
		public  GxSimpleCollection<string> gxTpr_Values
		{
			get { 
				if (sdt.ShouldSerializegxTpr_Values_GxSimpleCollection_Json())
					return sdt.gxTpr_Values;
				else
					return null;

			}
			set { 
				sdt.gxTpr_Values = value ;
			}
		}


		#endregion

		public SdtQueryViewerItemClickData_Filter sdt
		{
			get { 
				return (SdtQueryViewerItemClickData_Filter)Sdt;
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
				sdt = new SdtQueryViewerItemClickData_Filter() ;
			}
		}
	}
	#endregion
}