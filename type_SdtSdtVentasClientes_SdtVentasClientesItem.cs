/*
				   File: type_SdtSdtVentasClientes_SdtVentasClientesItem
			Description: SdtVentasClientes
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
	public class SdtSdtVentasClientes_SdtVentasClientesItem : GxUserType
	{
		public SdtSdtVentasClientes_SdtVentasClientesItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Clicod = "";

			gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Clidsc = "";

			gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Tipsabr = "";

			gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Uniabr = "";

			gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mvadlref1 = "";

			gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Tipcdsc = "";

		}

		public SdtSdtVentasClientes_SdtVentasClientesItem(IGxContext context)
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
			AddObjectProperty("CliCod", gxTpr_Clicod, false);


			AddObjectProperty("CliDsc", gxTpr_Clidsc, false);


			AddObjectProperty("Importe", gxTpr_Importe, false);


			AddObjectProperty("Cantidad", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Cantidad, 18, 4)), false);


			AddObjectProperty("TipSAbr", gxTpr_Tipsabr, false);


			AddObjectProperty("Importe1", gxTpr_Importe1, false);


			AddObjectProperty("Importe2", gxTpr_Importe2, false);


			AddObjectProperty("Importe3", gxTpr_Importe3, false);


			AddObjectProperty("UniAbr", gxTpr_Uniabr, false);


			AddObjectProperty("ComDPre", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Comdpre, 18, 6)), false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Comfec)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Comfec)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Comfec)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("ComFec", sDateCnv, false);



			AddObjectProperty("Porcentaje", gxTpr_Porcentaje, false);


			AddObjectProperty("Mes1", gxTpr_Mes1, false);


			AddObjectProperty("Mes2", gxTpr_Mes2, false);


			AddObjectProperty("Mes3", gxTpr_Mes3, false);


			AddObjectProperty("CantMes1", gxTpr_Cantmes1, false);


			AddObjectProperty("CantMes2", gxTpr_Cantmes2, false);


			AddObjectProperty("CantMes3", gxTpr_Cantmes3, false);


			AddObjectProperty("MVADLRef1", gxTpr_Mvadlref1, false);


			AddObjectProperty("TipCDsc", gxTpr_Tipcdsc, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="CliCod")]
		[XmlElement(ElementName="CliCod")]
		public string gxTpr_Clicod
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Clicod; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Clicod = value;
				SetDirty("Clicod");
			}
		}




		[SoapElement(ElementName="CliDsc")]
		[XmlElement(ElementName="CliDsc")]
		public string gxTpr_Clidsc
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Clidsc; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Clidsc = value;
				SetDirty("Clidsc");
			}
		}



		[SoapElement(ElementName="Importe")]
		[XmlElement(ElementName="Importe")]
		public string gxTpr_Importe_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Importe
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe = value;
				SetDirty("Importe");
			}
		}



		[SoapElement(ElementName="Cantidad")]
		[XmlElement(ElementName="Cantidad")]
		public string gxTpr_Cantidad_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantidad, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantidad = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Cantidad
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantidad; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantidad = value;
				SetDirty("Cantidad");
			}
		}




		[SoapElement(ElementName="TipSAbr")]
		[XmlElement(ElementName="TipSAbr")]
		public string gxTpr_Tipsabr
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Tipsabr; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Tipsabr = value;
				SetDirty("Tipsabr");
			}
		}



		[SoapElement(ElementName="Importe1")]
		[XmlElement(ElementName="Importe1")]
		public string gxTpr_Importe1_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe1, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe1 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Importe1
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe1; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe1 = value;
				SetDirty("Importe1");
			}
		}



		[SoapElement(ElementName="Importe2")]
		[XmlElement(ElementName="Importe2")]
		public string gxTpr_Importe2_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe2, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe2 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Importe2
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe2; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe2 = value;
				SetDirty("Importe2");
			}
		}



		[SoapElement(ElementName="Importe3")]
		[XmlElement(ElementName="Importe3")]
		public string gxTpr_Importe3_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe3, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe3 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Importe3
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe3; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe3 = value;
				SetDirty("Importe3");
			}
		}




		[SoapElement(ElementName="UniAbr")]
		[XmlElement(ElementName="UniAbr")]
		public string gxTpr_Uniabr
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Uniabr; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Uniabr = value;
				SetDirty("Uniabr");
			}
		}



		[SoapElement(ElementName="ComDPre")]
		[XmlElement(ElementName="ComDPre")]
		public string gxTpr_Comdpre_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Comdpre, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Comdpre = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Comdpre
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Comdpre; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Comdpre = value;
				SetDirty("Comdpre");
			}
		}



		[SoapElement(ElementName="ComFec")]
		[XmlElement(ElementName="ComFec" , IsNullable=true)]
		public string gxTpr_Comfec_Nullable
		{
			get {
				if ( gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Comfec == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Comfec).value ;
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Comfec = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Comfec
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Comfec; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Comfec = value;
				SetDirty("Comfec");
			}
		}


		[SoapElement(ElementName="Porcentaje")]
		[XmlElement(ElementName="Porcentaje")]
		public string gxTpr_Porcentaje_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Porcentaje, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Porcentaje = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Porcentaje
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Porcentaje; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Porcentaje = value;
				SetDirty("Porcentaje");
			}
		}



		[SoapElement(ElementName="Mes1")]
		[XmlElement(ElementName="Mes1")]
		public string gxTpr_Mes1_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mes1, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mes1 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Mes1
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mes1; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mes1 = value;
				SetDirty("Mes1");
			}
		}



		[SoapElement(ElementName="Mes2")]
		[XmlElement(ElementName="Mes2")]
		public string gxTpr_Mes2_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mes2, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mes2 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Mes2
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mes2; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mes2 = value;
				SetDirty("Mes2");
			}
		}



		[SoapElement(ElementName="Mes3")]
		[XmlElement(ElementName="Mes3")]
		public string gxTpr_Mes3_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mes3, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mes3 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Mes3
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mes3; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mes3 = value;
				SetDirty("Mes3");
			}
		}



		[SoapElement(ElementName="CantMes1")]
		[XmlElement(ElementName="CantMes1")]
		public string gxTpr_Cantmes1_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantmes1, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantmes1 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Cantmes1
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantmes1; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantmes1 = value;
				SetDirty("Cantmes1");
			}
		}



		[SoapElement(ElementName="CantMes2")]
		[XmlElement(ElementName="CantMes2")]
		public string gxTpr_Cantmes2_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantmes2, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantmes2 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Cantmes2
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantmes2; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantmes2 = value;
				SetDirty("Cantmes2");
			}
		}



		[SoapElement(ElementName="CantMes3")]
		[XmlElement(ElementName="CantMes3")]
		public string gxTpr_Cantmes3_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantmes3, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantmes3 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Cantmes3
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantmes3; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantmes3 = value;
				SetDirty("Cantmes3");
			}
		}




		[SoapElement(ElementName="MVADLRef1")]
		[XmlElement(ElementName="MVADLRef1")]
		public string gxTpr_Mvadlref1
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mvadlref1; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mvadlref1 = value;
				SetDirty("Mvadlref1");
			}
		}




		[SoapElement(ElementName="TipCDsc")]
		[XmlElement(ElementName="TipCDsc")]
		public string gxTpr_Tipcdsc
		{
			get {
				return gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Tipcdsc; 
			}
			set {
				gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Tipcdsc = value;
				SetDirty("Tipcdsc");
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
			gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Clicod = "";
			gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Clidsc = "";


			gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Tipsabr = "";



			gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Uniabr = "";









			gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mvadlref1 = "";
			gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Tipcdsc = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Clicod;
		 

		protected string gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Clidsc;
		 

		protected decimal gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe;
		 

		protected decimal gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantidad;
		 

		protected string gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Tipsabr;
		 

		protected decimal gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe1;
		 

		protected decimal gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe2;
		 

		protected decimal gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Importe3;
		 

		protected string gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Uniabr;
		 

		protected decimal gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Comdpre;
		 

		protected DateTime gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Comfec;
		 

		protected decimal gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Porcentaje;
		 

		protected decimal gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mes1;
		 

		protected decimal gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mes2;
		 

		protected decimal gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mes3;
		 

		protected decimal gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantmes1;
		 

		protected decimal gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantmes2;
		 

		protected decimal gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Cantmes3;
		 

		protected string gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Mvadlref1;
		 

		protected string gxTv_SdtSdtVentasClientes_SdtVentasClientesItem_Tipcdsc;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SdtVentasClientesItem", Namespace="SIGERP_ADVANCED")]
	public class SdtSdtVentasClientes_SdtVentasClientesItem_RESTInterface : GxGenericCollectionItem<SdtSdtVentasClientes_SdtVentasClientesItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdtVentasClientes_SdtVentasClientesItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdtVentasClientes_SdtVentasClientesItem_RESTInterface( SdtSdtVentasClientes_SdtVentasClientesItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="CliCod", Order=0)]
		public  string gxTpr_Clicod
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Clicod);

			}
			set { 
				 sdt.gxTpr_Clicod = value;
			}
		}

		[DataMember(Name="CliDsc", Order=1)]
		public  string gxTpr_Clidsc
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Clidsc);

			}
			set { 
				 sdt.gxTpr_Clidsc = value;
			}
		}

		[DataMember(Name="Importe", Order=2)]
		public  string gxTpr_Importe
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Importe, 15, 2));

			}
			set { 
				sdt.gxTpr_Importe =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Cantidad", Order=3)]
		public  string gxTpr_Cantidad
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Cantidad, 18, 4));

			}
			set { 
				sdt.gxTpr_Cantidad =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TipSAbr", Order=4)]
		public  string gxTpr_Tipsabr
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tipsabr);

			}
			set { 
				 sdt.gxTpr_Tipsabr = value;
			}
		}

		[DataMember(Name="Importe1", Order=5)]
		public  string gxTpr_Importe1
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Importe1, 15, 2));

			}
			set { 
				sdt.gxTpr_Importe1 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Importe2", Order=6)]
		public  string gxTpr_Importe2
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Importe2, 15, 2));

			}
			set { 
				sdt.gxTpr_Importe2 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Importe3", Order=7)]
		public  string gxTpr_Importe3
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Importe3, 15, 2));

			}
			set { 
				sdt.gxTpr_Importe3 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="UniAbr", Order=8)]
		public  string gxTpr_Uniabr
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Uniabr);

			}
			set { 
				 sdt.gxTpr_Uniabr = value;
			}
		}

		[DataMember(Name="ComDPre", Order=9)]
		public  string gxTpr_Comdpre
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Comdpre, 18, 6));

			}
			set { 
				sdt.gxTpr_Comdpre =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ComFec", Order=10)]
		public  string gxTpr_Comfec
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Comfec);

			}
			set { 
				sdt.gxTpr_Comfec = DateTimeUtil.CToD2(value);
			}
		}

		[DataMember(Name="Porcentaje", Order=11)]
		public decimal gxTpr_Porcentaje
		{
			get { 
				return sdt.gxTpr_Porcentaje;

			}
			set { 
				sdt.gxTpr_Porcentaje = value;
			}
		}

		[DataMember(Name="Mes1", Order=12)]
		public  string gxTpr_Mes1
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mes1, 15, 2));

			}
			set { 
				sdt.gxTpr_Mes1 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Mes2", Order=13)]
		public  string gxTpr_Mes2
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mes2, 15, 2));

			}
			set { 
				sdt.gxTpr_Mes2 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Mes3", Order=14)]
		public  string gxTpr_Mes3
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mes3, 15, 2));

			}
			set { 
				sdt.gxTpr_Mes3 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="CantMes1", Order=15)]
		public  string gxTpr_Cantmes1
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Cantmes1, 15, 4));

			}
			set { 
				sdt.gxTpr_Cantmes1 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="CantMes2", Order=16)]
		public  string gxTpr_Cantmes2
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Cantmes2, 15, 4));

			}
			set { 
				sdt.gxTpr_Cantmes2 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="CantMes3", Order=17)]
		public  string gxTpr_Cantmes3
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Cantmes3, 15, 4));

			}
			set { 
				sdt.gxTpr_Cantmes3 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MVADLRef1", Order=18)]
		public  string gxTpr_Mvadlref1
		{
			get { 
				return sdt.gxTpr_Mvadlref1;

			}
			set { 
				 sdt.gxTpr_Mvadlref1 = value;
			}
		}

		[DataMember(Name="TipCDsc", Order=19)]
		public  string gxTpr_Tipcdsc
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tipcdsc);

			}
			set { 
				 sdt.gxTpr_Tipcdsc = value;
			}
		}


		#endregion

		public SdtSdtVentasClientes_SdtVentasClientesItem sdt
		{
			get { 
				return (SdtSdtVentasClientes_SdtVentasClientesItem)Sdt;
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
				sdt = new SdtSdtVentasClientes_SdtVentasClientesItem() ;
			}
		}
	}
	#endregion
}