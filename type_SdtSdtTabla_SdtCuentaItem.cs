/*
				   File: type_SdtSdtTabla_SdtCuentaItem
			Description: SdtTabla
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
	public class SdtSdtTabla_SdtCuentaItem : GxUserType
	{
		public SdtSdtTabla_SdtCuentaItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdtTabla_SdtCuentaItem_Tabnombre = "";

		}

		public SdtSdtTabla_SdtCuentaItem(IGxContext context)
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
			AddObjectProperty("TabItem", gxTpr_Tabitem, false);


			AddObjectProperty("TabNombre", gxTpr_Tabnombre, false);


			AddObjectProperty("TabMes1", gxTpr_Tabmes1, false);


			AddObjectProperty("TabMes11", gxTpr_Tabmes11, false);


			AddObjectProperty("TabMes2", gxTpr_Tabmes2, false);


			AddObjectProperty("TabMes22", gxTpr_Tabmes22, false);


			AddObjectProperty("TabMes3", gxTpr_Tabmes3, false);


			AddObjectProperty("TabMes33", gxTpr_Tabmes33, false);


			AddObjectProperty("TabMes4", gxTpr_Tabmes4, false);


			AddObjectProperty("TabMes44", gxTpr_Tabmes44, false);


			AddObjectProperty("TabMes5", gxTpr_Tabmes5, false);


			AddObjectProperty("TabMes55", gxTpr_Tabmes55, false);


			AddObjectProperty("TabMes6", gxTpr_Tabmes6, false);


			AddObjectProperty("TabMes66", gxTpr_Tabmes66, false);


			AddObjectProperty("TabMes7", gxTpr_Tabmes7, false);


			AddObjectProperty("TabMes77", gxTpr_Tabmes77, false);


			AddObjectProperty("TabMes8", gxTpr_Tabmes8, false);


			AddObjectProperty("TabMes88", gxTpr_Tabmes88, false);


			AddObjectProperty("TabMes9", gxTpr_Tabmes9, false);


			AddObjectProperty("TabMes99", gxTpr_Tabmes99, false);


			AddObjectProperty("TabMes10", gxTpr_Tabmes10, false);


			AddObjectProperty("TabMes1010", gxTpr_Tabmes1010, false);


			AddObjectProperty("TabMes011", gxTpr_Tabmes011, false);


			AddObjectProperty("TabMes01111", gxTpr_Tabmes01111, false);


			AddObjectProperty("TabMes012", gxTpr_Tabmes012, false);


			AddObjectProperty("TabMes01212", gxTpr_Tabmes01212, false);


			AddObjectProperty("TabTotal1", gxTpr_Tabtotal1, false);


			AddObjectProperty("TabTotal2", gxTpr_Tabtotal2, false);


			AddObjectProperty("TabPor1", gxTpr_Tabpor1, false);


			AddObjectProperty("TabPor2", gxTpr_Tabpor2, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="TabItem")]
		[XmlElement(ElementName="TabItem")]
		public int gxTpr_Tabitem
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabitem; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabitem = value;
				SetDirty("Tabitem");
			}
		}




		[SoapElement(ElementName="TabNombre")]
		[XmlElement(ElementName="TabNombre")]
		public string gxTpr_Tabnombre
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabnombre; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabnombre = value;
				SetDirty("Tabnombre");
			}
		}



		[SoapElement(ElementName="TabMes1")]
		[XmlElement(ElementName="TabMes1")]
		public string gxTpr_Tabmes1_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes1, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes1 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes1
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes1; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes1 = value;
				SetDirty("Tabmes1");
			}
		}



		[SoapElement(ElementName="TabMes11")]
		[XmlElement(ElementName="TabMes11")]
		public string gxTpr_Tabmes11_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes11, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes11 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes11
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes11; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes11 = value;
				SetDirty("Tabmes11");
			}
		}



		[SoapElement(ElementName="TabMes2")]
		[XmlElement(ElementName="TabMes2")]
		public string gxTpr_Tabmes2_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes2, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes2 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes2
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes2; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes2 = value;
				SetDirty("Tabmes2");
			}
		}



		[SoapElement(ElementName="TabMes22")]
		[XmlElement(ElementName="TabMes22")]
		public string gxTpr_Tabmes22_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes22, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes22 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes22
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes22; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes22 = value;
				SetDirty("Tabmes22");
			}
		}



		[SoapElement(ElementName="TabMes3")]
		[XmlElement(ElementName="TabMes3")]
		public string gxTpr_Tabmes3_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes3, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes3 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes3
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes3; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes3 = value;
				SetDirty("Tabmes3");
			}
		}



		[SoapElement(ElementName="TabMes33")]
		[XmlElement(ElementName="TabMes33")]
		public string gxTpr_Tabmes33_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes33, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes33 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes33
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes33; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes33 = value;
				SetDirty("Tabmes33");
			}
		}



		[SoapElement(ElementName="TabMes4")]
		[XmlElement(ElementName="TabMes4")]
		public string gxTpr_Tabmes4_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes4, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes4 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes4
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes4; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes4 = value;
				SetDirty("Tabmes4");
			}
		}



		[SoapElement(ElementName="TabMes44")]
		[XmlElement(ElementName="TabMes44")]
		public string gxTpr_Tabmes44_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes44, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes44 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes44
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes44; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes44 = value;
				SetDirty("Tabmes44");
			}
		}



		[SoapElement(ElementName="TabMes5")]
		[XmlElement(ElementName="TabMes5")]
		public string gxTpr_Tabmes5_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes5, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes5 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes5
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes5; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes5 = value;
				SetDirty("Tabmes5");
			}
		}



		[SoapElement(ElementName="TabMes55")]
		[XmlElement(ElementName="TabMes55")]
		public string gxTpr_Tabmes55_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes55, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes55 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes55
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes55; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes55 = value;
				SetDirty("Tabmes55");
			}
		}



		[SoapElement(ElementName="TabMes6")]
		[XmlElement(ElementName="TabMes6")]
		public string gxTpr_Tabmes6_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes6, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes6 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes6
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes6; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes6 = value;
				SetDirty("Tabmes6");
			}
		}



		[SoapElement(ElementName="TabMes66")]
		[XmlElement(ElementName="TabMes66")]
		public string gxTpr_Tabmes66_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes66, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes66 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes66
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes66; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes66 = value;
				SetDirty("Tabmes66");
			}
		}



		[SoapElement(ElementName="TabMes7")]
		[XmlElement(ElementName="TabMes7")]
		public string gxTpr_Tabmes7_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes7, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes7 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes7
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes7; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes7 = value;
				SetDirty("Tabmes7");
			}
		}



		[SoapElement(ElementName="TabMes77")]
		[XmlElement(ElementName="TabMes77")]
		public string gxTpr_Tabmes77_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes77, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes77 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes77
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes77; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes77 = value;
				SetDirty("Tabmes77");
			}
		}



		[SoapElement(ElementName="TabMes8")]
		[XmlElement(ElementName="TabMes8")]
		public string gxTpr_Tabmes8_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes8, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes8 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes8
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes8; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes8 = value;
				SetDirty("Tabmes8");
			}
		}



		[SoapElement(ElementName="TabMes88")]
		[XmlElement(ElementName="TabMes88")]
		public string gxTpr_Tabmes88_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes88, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes88 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes88
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes88; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes88 = value;
				SetDirty("Tabmes88");
			}
		}



		[SoapElement(ElementName="TabMes9")]
		[XmlElement(ElementName="TabMes9")]
		public string gxTpr_Tabmes9_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes9, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes9 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes9
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes9; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes9 = value;
				SetDirty("Tabmes9");
			}
		}



		[SoapElement(ElementName="TabMes99")]
		[XmlElement(ElementName="TabMes99")]
		public string gxTpr_Tabmes99_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes99, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes99 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes99
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes99; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes99 = value;
				SetDirty("Tabmes99");
			}
		}



		[SoapElement(ElementName="TabMes10")]
		[XmlElement(ElementName="TabMes10")]
		public string gxTpr_Tabmes10_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes10, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes10 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes10
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes10; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes10 = value;
				SetDirty("Tabmes10");
			}
		}



		[SoapElement(ElementName="TabMes1010")]
		[XmlElement(ElementName="TabMes1010")]
		public string gxTpr_Tabmes1010_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes1010, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes1010 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes1010
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes1010; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes1010 = value;
				SetDirty("Tabmes1010");
			}
		}



		[SoapElement(ElementName="TabMes011")]
		[XmlElement(ElementName="TabMes011")]
		public string gxTpr_Tabmes011_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes011, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes011 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes011
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes011; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes011 = value;
				SetDirty("Tabmes011");
			}
		}



		[SoapElement(ElementName="TabMes01111")]
		[XmlElement(ElementName="TabMes01111")]
		public string gxTpr_Tabmes01111_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes01111, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes01111 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes01111
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes01111; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes01111 = value;
				SetDirty("Tabmes01111");
			}
		}



		[SoapElement(ElementName="TabMes012")]
		[XmlElement(ElementName="TabMes012")]
		public string gxTpr_Tabmes012_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes012, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes012 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes012
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes012; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes012 = value;
				SetDirty("Tabmes012");
			}
		}



		[SoapElement(ElementName="TabMes01212")]
		[XmlElement(ElementName="TabMes01212")]
		public string gxTpr_Tabmes01212_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes01212, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes01212 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabmes01212
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes01212; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes01212 = value;
				SetDirty("Tabmes01212");
			}
		}



		[SoapElement(ElementName="TabTotal1")]
		[XmlElement(ElementName="TabTotal1")]
		public string gxTpr_Tabtotal1_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabtotal1, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabtotal1 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabtotal1
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabtotal1; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabtotal1 = value;
				SetDirty("Tabtotal1");
			}
		}



		[SoapElement(ElementName="TabTotal2")]
		[XmlElement(ElementName="TabTotal2")]
		public string gxTpr_Tabtotal2_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabtotal2, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabtotal2 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabtotal2
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabtotal2; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabtotal2 = value;
				SetDirty("Tabtotal2");
			}
		}



		[SoapElement(ElementName="TabPor1")]
		[XmlElement(ElementName="TabPor1")]
		public string gxTpr_Tabpor1_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabpor1, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabpor1 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabpor1
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabpor1; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabpor1 = value;
				SetDirty("Tabpor1");
			}
		}



		[SoapElement(ElementName="TabPor2")]
		[XmlElement(ElementName="TabPor2")]
		public string gxTpr_Tabpor2_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtTabla_SdtCuentaItem_Tabpor2, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabpor2 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Tabpor2
		{
			get {
				return gxTv_SdtSdtTabla_SdtCuentaItem_Tabpor2; 
			}
			set {
				gxTv_SdtSdtTabla_SdtCuentaItem_Tabpor2 = value;
				SetDirty("Tabpor2");
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
			gxTv_SdtSdtTabla_SdtCuentaItem_Tabnombre = "";




























			return  ;
		}



		#endregion

		#region Declaration

		protected int gxTv_SdtSdtTabla_SdtCuentaItem_Tabitem;
		 

		protected string gxTv_SdtSdtTabla_SdtCuentaItem_Tabnombre;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes1;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes11;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes2;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes22;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes3;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes33;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes4;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes44;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes5;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes55;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes6;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes66;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes7;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes77;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes8;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes88;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes9;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes99;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes10;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes1010;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes011;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes01111;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes012;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabmes01212;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabtotal1;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabtotal2;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabpor1;
		 

		protected decimal gxTv_SdtSdtTabla_SdtCuentaItem_Tabpor2;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SdtCuentaItem", Namespace="SIGERP_ADVANCED")]
	public class SdtSdtTabla_SdtCuentaItem_RESTInterface : GxGenericCollectionItem<SdtSdtTabla_SdtCuentaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdtTabla_SdtCuentaItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdtTabla_SdtCuentaItem_RESTInterface( SdtSdtTabla_SdtCuentaItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="TabItem", Order=0)]
		public int gxTpr_Tabitem
		{
			get { 
				return sdt.gxTpr_Tabitem;

			}
			set { 
				sdt.gxTpr_Tabitem = value;
			}
		}

		[DataMember(Name="TabNombre", Order=1)]
		public  string gxTpr_Tabnombre
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tabnombre);

			}
			set { 
				 sdt.gxTpr_Tabnombre = value;
			}
		}

		[DataMember(Name="TabMes1", Order=2)]
		public  string gxTpr_Tabmes1
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes1, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes1 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes11", Order=3)]
		public  string gxTpr_Tabmes11
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes11, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes11 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes2", Order=4)]
		public  string gxTpr_Tabmes2
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes2, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes2 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes22", Order=5)]
		public  string gxTpr_Tabmes22
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes22, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes22 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes3", Order=6)]
		public  string gxTpr_Tabmes3
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes3, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes3 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes33", Order=7)]
		public  string gxTpr_Tabmes33
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes33, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes33 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes4", Order=8)]
		public  string gxTpr_Tabmes4
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes4, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes4 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes44", Order=9)]
		public  string gxTpr_Tabmes44
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes44, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes44 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes5", Order=10)]
		public  string gxTpr_Tabmes5
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes5, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes5 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes55", Order=11)]
		public  string gxTpr_Tabmes55
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes55, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes55 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes6", Order=12)]
		public  string gxTpr_Tabmes6
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes6, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes6 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes66", Order=13)]
		public  string gxTpr_Tabmes66
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes66, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes66 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes7", Order=14)]
		public  string gxTpr_Tabmes7
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes7, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes7 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes77", Order=15)]
		public  string gxTpr_Tabmes77
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes77, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes77 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes8", Order=16)]
		public  string gxTpr_Tabmes8
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes8, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes8 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes88", Order=17)]
		public  string gxTpr_Tabmes88
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes88, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes88 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes9", Order=18)]
		public  string gxTpr_Tabmes9
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes9, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes9 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes99", Order=19)]
		public  string gxTpr_Tabmes99
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes99, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes99 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes10", Order=20)]
		public  string gxTpr_Tabmes10
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes10, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes10 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes1010", Order=21)]
		public  string gxTpr_Tabmes1010
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes1010, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes1010 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes011", Order=22)]
		public  string gxTpr_Tabmes011
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes011, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes011 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes01111", Order=23)]
		public  string gxTpr_Tabmes01111
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes01111, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes01111 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes012", Order=24)]
		public  string gxTpr_Tabmes012
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes012, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes012 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabMes01212", Order=25)]
		public  string gxTpr_Tabmes01212
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabmes01212, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabmes01212 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabTotal1", Order=26)]
		public  string gxTpr_Tabtotal1
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabtotal1, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabtotal1 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabTotal2", Order=27)]
		public  string gxTpr_Tabtotal2
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabtotal2, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabtotal2 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabPor1", Order=28)]
		public  string gxTpr_Tabpor1
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabpor1, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabpor1 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="TabPor2", Order=29)]
		public  string gxTpr_Tabpor2
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Tabpor2, 15, 2));

			}
			set { 
				sdt.gxTpr_Tabpor2 =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSdtTabla_SdtCuentaItem sdt
		{
			get { 
				return (SdtSdtTabla_SdtCuentaItem)Sdt;
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
				sdt = new SdtSdtTabla_SdtCuentaItem() ;
			}
		}
	}
	#endregion
}