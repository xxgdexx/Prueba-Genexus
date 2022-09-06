/*
				   File: type_SdtSdtVentasZonas_SdtVentasClientesItem
			Description: SdtVentasZonas
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
	[XmlRoot(ElementName="SdtVentasClientesItem")]
	[XmlType(TypeName="SdtVentasClientesItem" , Namespace="SIGERP_ADVANCED" )]
	[Serializable]
	public class SdtSdtVentasZonas_SdtVentasClientesItem : GxUserType
	{
		public SdtSdtVentasZonas_SdtVentasClientesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Zondsc = "";

		}

		public SdtSdtVentasZonas_SdtVentasClientesItem(IGxContext context)
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
			AddObjectProperty("ZonCod", gxTpr_Zoncod, false);


			AddObjectProperty("ZonDsc", gxTpr_Zondsc, false);


			AddObjectProperty("Importe1", gxTpr_Importe1, false);


			AddObjectProperty("Importe2", gxTpr_Importe2, false);


			AddObjectProperty("Importe3", gxTpr_Importe3, false);


			AddObjectProperty("Importe4", gxTpr_Importe4, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ZonCod")]
		[XmlElement(ElementName="ZonCod")]
		public int gxTpr_Zoncod
		{
			get {
				return gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Zoncod; 
			}
			set {
				gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Zoncod = value;
				SetDirty("Zoncod");
			}
		}




		[SoapElement(ElementName="ZonDsc")]
		[XmlElement(ElementName="ZonDsc")]
		public string gxTpr_Zondsc
		{
			get {
				return gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Zondsc; 
			}
			set {
				gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Zondsc = value;
				SetDirty("Zondsc");
			}
		}



		[SoapElement(ElementName="Importe1")]
		[XmlElement(ElementName="Importe1")]
		public string gxTpr_Importe1_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe1, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe1 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Importe1
		{
			get {
				return gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe1; 
			}
			set {
				gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe1 = value;
				SetDirty("Importe1");
			}
		}



		[SoapElement(ElementName="Importe2")]
		[XmlElement(ElementName="Importe2")]
		public string gxTpr_Importe2_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe2, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe2 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Importe2
		{
			get {
				return gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe2; 
			}
			set {
				gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe2 = value;
				SetDirty("Importe2");
			}
		}



		[SoapElement(ElementName="Importe3")]
		[XmlElement(ElementName="Importe3")]
		public string gxTpr_Importe3_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe3, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe3 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Importe3
		{
			get {
				return gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe3; 
			}
			set {
				gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe3 = value;
				SetDirty("Importe3");
			}
		}



		[SoapElement(ElementName="Importe4")]
		[XmlElement(ElementName="Importe4")]
		public string gxTpr_Importe4_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe4, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe4 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Importe4
		{
			get {
				return gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe4; 
			}
			set {
				gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe4 = value;
				SetDirty("Importe4");
			}
		}



		public override bool ShouldSerializeSdtJson()
		{
			return true;
		}



		#endregion

		#region Initialization

		public void initialize( )
		{
			gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Zondsc = "";




			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Zoncod;
		 

		protected string gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Zondsc;
		 

		protected decimal gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe1;
		 

		protected decimal gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe2;
		 

		protected decimal gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe3;
		 

		protected decimal gxTv_SdtSdtVentasZonas_SdtVentasClientesItem_Importe4;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SdtVentasClientesItem", Namespace="SIGERP_ADVANCED")]
	public class SdtSdtVentasZonas_SdtVentasClientesItem_RESTInterface : GxGenericCollectionItem<SdtSdtVentasZonas_SdtVentasClientesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdtVentasZonas_SdtVentasClientesItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdtVentasZonas_SdtVentasClientesItem_RESTInterface( SdtSdtVentasZonas_SdtVentasClientesItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ZonCod", Order=0)]
		public int gxTpr_Zoncod
		{
			get { 
				return sdt.gxTpr_Zoncod;

			}
			set { 
				sdt.gxTpr_Zoncod = value;
			}
		}

		[DataMember(Name="ZonDsc", Order=1)]
		public  string gxTpr_Zondsc
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Zondsc);

			}
			set { 
				 sdt.gxTpr_Zondsc = value;
			}
		}

		[DataMember(Name="Importe1", Order=2)]
		public  string gxTpr_Importe1
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Importe1, 15, 2));

			}
			set { 
				sdt.gxTpr_Importe1 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Importe2", Order=3)]
		public  string gxTpr_Importe2
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Importe2, 15, 2));

			}
			set { 
				sdt.gxTpr_Importe2 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Importe3", Order=4)]
		public  string gxTpr_Importe3
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Importe3, 15, 2));

			}
			set { 
				sdt.gxTpr_Importe3 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Importe4", Order=5)]
		public  string gxTpr_Importe4
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Importe4, 15, 2));

			}
			set { 
				sdt.gxTpr_Importe4 =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSdtVentasZonas_SdtVentasClientesItem sdt
		{
			get { 
				return (SdtSdtVentasZonas_SdtVentasClientesItem)Sdt;
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
				sdt = new SdtSdtVentasZonas_SdtVentasClientesItem() ;
			}
		}
	}
	#endregion
}