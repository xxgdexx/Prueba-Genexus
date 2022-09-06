/*
				   File: type_SdtSdtBalance_SdtCuentaItem
			Description: SdtBalance
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
	[XmlRoot(ElementName="SdtCuentaItem")]
	[XmlType(TypeName="SdtCuentaItem" , Namespace="SIGERP_ADVANCED" )]
	[Serializable]
	public class SdtSdtBalance_SdtCuentaItem : GxUserType
	{
		public SdtSdtBalance_SdtCuentaItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdtBalance_SdtCuentaItem_Baltotales = "";

			gxTv_SdtSdtBalance_SdtCuentaItem_Balrubros = "";

			gxTv_SdtSdtBalance_SdtCuentaItem_Balconceptoactivo = "";

			gxTv_SdtSdtBalance_SdtCuentaItem_Baltrubros = "";

			gxTv_SdtSdtBalance_SdtCuentaItem_Balttotales = "";

		}

		public SdtSdtBalance_SdtCuentaItem(IGxContext context)
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
			AddObjectProperty("BalTipo", gxTpr_Baltipo, false);


			AddObjectProperty("BalTotales", gxTpr_Baltotales, false);


			AddObjectProperty("BalRubCod", gxTpr_Balrubcod, false);


			AddObjectProperty("BalRubros", gxTpr_Balrubros, false);


			AddObjectProperty("BalLinCod", gxTpr_Ballincod, false);


			AddObjectProperty("BalConceptoActivo", gxTpr_Balconceptoactivo, false);


			AddObjectProperty("BalImporteActivo", gxTpr_Balimporteactivo, false);


			AddObjectProperty("BalTRubros", gxTpr_Baltrubros, false);


			AddObjectProperty("BalTTotales", gxTpr_Balttotales, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="BalTipo")]
		[XmlElement(ElementName="BalTipo")]
		public short gxTpr_Baltipo
		{
			get {
				return gxTv_SdtSdtBalance_SdtCuentaItem_Baltipo; 
			}
			set {
				gxTv_SdtSdtBalance_SdtCuentaItem_Baltipo = value;
				SetDirty("Baltipo");
			}
		}




		[SoapElement(ElementName="BalTotales")]
		[XmlElement(ElementName="BalTotales")]
		public string gxTpr_Baltotales
		{
			get {
				return gxTv_SdtSdtBalance_SdtCuentaItem_Baltotales; 
			}
			set {
				gxTv_SdtSdtBalance_SdtCuentaItem_Baltotales = value;
				SetDirty("Baltotales");
			}
		}




		[SoapElement(ElementName="BalRubCod")]
		[XmlElement(ElementName="BalRubCod")]
		public int gxTpr_Balrubcod
		{
			get {
				return gxTv_SdtSdtBalance_SdtCuentaItem_Balrubcod; 
			}
			set {
				gxTv_SdtSdtBalance_SdtCuentaItem_Balrubcod = value;
				SetDirty("Balrubcod");
			}
		}




		[SoapElement(ElementName="BalRubros")]
		[XmlElement(ElementName="BalRubros")]
		public string gxTpr_Balrubros
		{
			get {
				return gxTv_SdtSdtBalance_SdtCuentaItem_Balrubros; 
			}
			set {
				gxTv_SdtSdtBalance_SdtCuentaItem_Balrubros = value;
				SetDirty("Balrubros");
			}
		}




		[SoapElement(ElementName="BalLinCod")]
		[XmlElement(ElementName="BalLinCod")]
		public int gxTpr_Ballincod
		{
			get {
				return gxTv_SdtSdtBalance_SdtCuentaItem_Ballincod; 
			}
			set {
				gxTv_SdtSdtBalance_SdtCuentaItem_Ballincod = value;
				SetDirty("Ballincod");
			}
		}




		[SoapElement(ElementName="BalConceptoActivo")]
		[XmlElement(ElementName="BalConceptoActivo")]
		public string gxTpr_Balconceptoactivo
		{
			get {
				return gxTv_SdtSdtBalance_SdtCuentaItem_Balconceptoactivo; 
			}
			set {
				gxTv_SdtSdtBalance_SdtCuentaItem_Balconceptoactivo = value;
				SetDirty("Balconceptoactivo");
			}
		}



		[SoapElement(ElementName="BalImporteActivo")]
		[XmlElement(ElementName="BalImporteActivo")]
		public string gxTpr_Balimporteactivo_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtBalance_SdtCuentaItem_Balimporteactivo, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtBalance_SdtCuentaItem_Balimporteactivo = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Balimporteactivo
		{
			get {
				return gxTv_SdtSdtBalance_SdtCuentaItem_Balimporteactivo; 
			}
			set {
				gxTv_SdtSdtBalance_SdtCuentaItem_Balimporteactivo = value;
				SetDirty("Balimporteactivo");
			}
		}




		[SoapElement(ElementName="BalTRubros")]
		[XmlElement(ElementName="BalTRubros")]
		public string gxTpr_Baltrubros
		{
			get {
				return gxTv_SdtSdtBalance_SdtCuentaItem_Baltrubros; 
			}
			set {
				gxTv_SdtSdtBalance_SdtCuentaItem_Baltrubros = value;
				SetDirty("Baltrubros");
			}
		}




		[SoapElement(ElementName="BalTTotales")]
		[XmlElement(ElementName="BalTTotales")]
		public string gxTpr_Balttotales
		{
			get {
				return gxTv_SdtSdtBalance_SdtCuentaItem_Balttotales; 
			}
			set {
				gxTv_SdtSdtBalance_SdtCuentaItem_Balttotales = value;
				SetDirty("Balttotales");
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
			gxTv_SdtSdtBalance_SdtCuentaItem_Baltotales = "";

			gxTv_SdtSdtBalance_SdtCuentaItem_Balrubros = "";

			gxTv_SdtSdtBalance_SdtCuentaItem_Balconceptoactivo = "";

			gxTv_SdtSdtBalance_SdtCuentaItem_Baltrubros = "";
			gxTv_SdtSdtBalance_SdtCuentaItem_Balttotales = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected short gxTv_SdtSdtBalance_SdtCuentaItem_Baltipo;
		 

		protected string gxTv_SdtSdtBalance_SdtCuentaItem_Baltotales;
		 

		protected int gxTv_SdtSdtBalance_SdtCuentaItem_Balrubcod;
		 

		protected string gxTv_SdtSdtBalance_SdtCuentaItem_Balrubros;
		 

		protected int gxTv_SdtSdtBalance_SdtCuentaItem_Ballincod;
		 

		protected string gxTv_SdtSdtBalance_SdtCuentaItem_Balconceptoactivo;
		 

		protected decimal gxTv_SdtSdtBalance_SdtCuentaItem_Balimporteactivo;
		 

		protected string gxTv_SdtSdtBalance_SdtCuentaItem_Baltrubros;
		 

		protected string gxTv_SdtSdtBalance_SdtCuentaItem_Balttotales;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SdtCuentaItem", Namespace="SIGERP_ADVANCED")]
	public class SdtSdtBalance_SdtCuentaItem_RESTInterface : GxGenericCollectionItem<SdtSdtBalance_SdtCuentaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdtBalance_SdtCuentaItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdtBalance_SdtCuentaItem_RESTInterface( SdtSdtBalance_SdtCuentaItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="BalTipo", Order=0)]
		public short gxTpr_Baltipo
		{
			get { 
				return sdt.gxTpr_Baltipo;

			}
			set { 
				sdt.gxTpr_Baltipo = value;
			}
		}

		[DataMember(Name="BalTotales", Order=1)]
		public  string gxTpr_Baltotales
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Baltotales);

			}
			set { 
				 sdt.gxTpr_Baltotales = value;
			}
		}

		[DataMember(Name="BalRubCod", Order=2)]
		public int gxTpr_Balrubcod
		{
			get { 
				return sdt.gxTpr_Balrubcod;

			}
			set { 
				sdt.gxTpr_Balrubcod = value;
			}
		}

		[DataMember(Name="BalRubros", Order=3)]
		public  string gxTpr_Balrubros
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Balrubros);

			}
			set { 
				 sdt.gxTpr_Balrubros = value;
			}
		}

		[DataMember(Name="BalLinCod", Order=4)]
		public int gxTpr_Ballincod
		{
			get { 
				return sdt.gxTpr_Ballincod;

			}
			set { 
				sdt.gxTpr_Ballincod = value;
			}
		}

		[DataMember(Name="BalConceptoActivo", Order=5)]
		public  string gxTpr_Balconceptoactivo
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Balconceptoactivo);

			}
			set { 
				 sdt.gxTpr_Balconceptoactivo = value;
			}
		}

		[DataMember(Name="BalImporteActivo", Order=6)]
		public  string gxTpr_Balimporteactivo
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Balimporteactivo, 15, 2));

			}
			set { 
				sdt.gxTpr_Balimporteactivo =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="BalTRubros", Order=7)]
		public  string gxTpr_Baltrubros
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Baltrubros);

			}
			set { 
				 sdt.gxTpr_Baltrubros = value;
			}
		}

		[DataMember(Name="BalTTotales", Order=8)]
		public  string gxTpr_Balttotales
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Balttotales);

			}
			set { 
				 sdt.gxTpr_Balttotales = value;
			}
		}


		#endregion

		public SdtSdtBalance_SdtCuentaItem sdt
		{
			get { 
				return (SdtSdtBalance_SdtCuentaItem)Sdt;
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
				sdt = new SdtSdtBalance_SdtCuentaItem() ;
			}
		}
	}
	#endregion
}