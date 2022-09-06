/*
				   File: type_SdtSdtEntrada_SdtEntradaItem
			Description: SdtEntrada
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
	[XmlRoot(ElementName="SdtEntradaItem")]
	[XmlType(TypeName="SdtEntradaItem" , Namespace="SIGERP_ADVANCED" )]
	[Serializable]
	public class SdtSdtEntrada_SdtEntradaItem : GxUserType
	{
		public SdtSdtEntrada_SdtEntradaItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdtEntrada_SdtEntradaItem_Proddsc = "";

			gxTv_SdtSdtEntrada_SdtEntradaItem_Prodcod = "";

			gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref1 = "";

			gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref2 = "";

			gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref3 = "";

			gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref4 = "";

			gxTv_SdtSdtEntrada_SdtEntradaItem_Uniabr = "";

			gxTv_SdtSdtEntrada_SdtEntradaItem_Docdobs = "";

			gxTv_SdtSdtEntrada_SdtEntradaItem_Prodbon = "";

		}

		public SdtSdtEntrada_SdtEntradaItem(IGxContext context)
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
			AddObjectProperty("ProdDsc", gxTpr_Proddsc, false);


			AddObjectProperty("Costo", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Costo, 18, 4)), false);


			AddObjectProperty("Item", gxTpr_Item, false);


			AddObjectProperty("ProdCod", gxTpr_Prodcod, false);


			AddObjectProperty("MVADRef1", gxTpr_Mvadref1, false);


			AddObjectProperty("MVADRef2", gxTpr_Mvadref2, false);


			AddObjectProperty("MVADLote", gxTpr_Mvadlote, false);


			AddObjectProperty("MVADSts", gxTpr_Mvadsts, false);


			AddObjectProperty("MVADBultos", gxTpr_Mvadbultos, false);


			AddObjectProperty("Precio", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Precio, 18, 6)), false);


			AddObjectProperty("Cantidad", StringUtil.LTrim( StringUtil.Str( (decimal)gxTpr_Cantidad, 18, 4)), false);


			AddObjectProperty("MVADRef3", gxTpr_Mvadref3, false);


			AddObjectProperty("MVADRef4", gxTpr_Mvadref4, false);


			AddObjectProperty("DocDIna", gxTpr_Docdina, false);


			AddObjectProperty("DocDAfecto", gxTpr_Docdafecto, false);


			AddObjectProperty("DocDInafecto", gxTpr_Docdinafecto, false);


			AddObjectProperty("UniAbr", gxTpr_Uniabr, false);


			AddObjectProperty("DocDDct", gxTpr_Docddct, false);


			AddObjectProperty("DocDDct2", gxTpr_Docddct2, false);


			AddObjectProperty("DocDPorSel", gxTpr_Docdporsel, false);


			AddObjectProperty("StkAct", gxTpr_Stkact, false);


			AddObjectProperty("DocDObs", gxTpr_Docdobs, false);


			AddObjectProperty("ProdBon", gxTpr_Prodbon, false);


			AddObjectProperty("ProdAfecICBPER", gxTpr_Prodafecicbper, false);


			AddObjectProperty("ProdValICBPER", gxTpr_Prodvalicbper, false);


			AddObjectProperty("DocDValSel", gxTpr_Docdvalsel, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="ProdDsc")]
		[XmlElement(ElementName="ProdDsc")]
		public string gxTpr_Proddsc
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Proddsc; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Proddsc = value;
				SetDirty("Proddsc");
			}
		}



		[SoapElement(ElementName="Costo")]
		[XmlElement(ElementName="Costo")]
		public string gxTpr_Costo_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtEntrada_SdtEntradaItem_Costo, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Costo = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Costo
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Costo; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Costo = value;
				SetDirty("Costo");
			}
		}




		[SoapElement(ElementName="Item")]
		[XmlElement(ElementName="Item")]
		public int gxTpr_Item
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Item; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Item = value;
				SetDirty("Item");
			}
		}




		[SoapElement(ElementName="ProdCod")]
		[XmlElement(ElementName="ProdCod")]
		public string gxTpr_Prodcod
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Prodcod; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Prodcod = value;
				SetDirty("Prodcod");
			}
		}




		[SoapElement(ElementName="MVADRef1")]
		[XmlElement(ElementName="MVADRef1")]
		public string gxTpr_Mvadref1
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref1; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref1 = value;
				SetDirty("Mvadref1");
			}
		}




		[SoapElement(ElementName="MVADRef2")]
		[XmlElement(ElementName="MVADRef2")]
		public string gxTpr_Mvadref2
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref2; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref2 = value;
				SetDirty("Mvadref2");
			}
		}



		[SoapElement(ElementName="MVADLote")]
		[XmlElement(ElementName="MVADLote")]
		public string gxTpr_Mvadlote_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadlote, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadlote = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Mvadlote
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadlote; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadlote = value;
				SetDirty("Mvadlote");
			}
		}




		[SoapElement(ElementName="MVADSts")]
		[XmlElement(ElementName="MVADSts")]
		public short gxTpr_Mvadsts
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadsts; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadsts = value;
				SetDirty("Mvadsts");
			}
		}



		[SoapElement(ElementName="MVADBultos")]
		[XmlElement(ElementName="MVADBultos")]
		public string gxTpr_Mvadbultos_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadbultos, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadbultos = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Mvadbultos
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadbultos; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadbultos = value;
				SetDirty("Mvadbultos");
			}
		}



		[SoapElement(ElementName="Precio")]
		[XmlElement(ElementName="Precio")]
		public string gxTpr_Precio_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtEntrada_SdtEntradaItem_Precio, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Precio = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Precio
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Precio; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Precio = value;
				SetDirty("Precio");
			}
		}



		[SoapElement(ElementName="Cantidad")]
		[XmlElement(ElementName="Cantidad")]
		public string gxTpr_Cantidad_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtEntrada_SdtEntradaItem_Cantidad, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Cantidad = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Cantidad
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Cantidad; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Cantidad = value;
				SetDirty("Cantidad");
			}
		}




		[SoapElement(ElementName="MVADRef3")]
		[XmlElement(ElementName="MVADRef3")]
		public string gxTpr_Mvadref3
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref3; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref3 = value;
				SetDirty("Mvadref3");
			}
		}




		[SoapElement(ElementName="MVADRef4")]
		[XmlElement(ElementName="MVADRef4")]
		public string gxTpr_Mvadref4
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref4; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref4 = value;
				SetDirty("Mvadref4");
			}
		}




		[SoapElement(ElementName="DocDIna")]
		[XmlElement(ElementName="DocDIna")]
		public short gxTpr_Docdina
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Docdina; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Docdina = value;
				SetDirty("Docdina");
			}
		}



		[SoapElement(ElementName="DocDAfecto")]
		[XmlElement(ElementName="DocDAfecto")]
		public string gxTpr_Docdafecto_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtEntrada_SdtEntradaItem_Docdafecto, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Docdafecto = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Docdafecto
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Docdafecto; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Docdafecto = value;
				SetDirty("Docdafecto");
			}
		}



		[SoapElement(ElementName="DocDInafecto")]
		[XmlElement(ElementName="DocDInafecto")]
		public string gxTpr_Docdinafecto_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtEntrada_SdtEntradaItem_Docdinafecto, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Docdinafecto = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Docdinafecto
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Docdinafecto; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Docdinafecto = value;
				SetDirty("Docdinafecto");
			}
		}




		[SoapElement(ElementName="UniAbr")]
		[XmlElement(ElementName="UniAbr")]
		public string gxTpr_Uniabr
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Uniabr; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Uniabr = value;
				SetDirty("Uniabr");
			}
		}



		[SoapElement(ElementName="DocDDct")]
		[XmlElement(ElementName="DocDDct")]
		public string gxTpr_Docddct_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtEntrada_SdtEntradaItem_Docddct, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Docddct = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Docddct
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Docddct; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Docddct = value;
				SetDirty("Docddct");
			}
		}



		[SoapElement(ElementName="DocDDct2")]
		[XmlElement(ElementName="DocDDct2")]
		public string gxTpr_Docddct2_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtEntrada_SdtEntradaItem_Docddct2, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Docddct2 = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Docddct2
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Docddct2; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Docddct2 = value;
				SetDirty("Docddct2");
			}
		}



		[SoapElement(ElementName="DocDPorSel")]
		[XmlElement(ElementName="DocDPorSel")]
		public string gxTpr_Docdporsel_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtEntrada_SdtEntradaItem_Docdporsel, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Docdporsel = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Docdporsel
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Docdporsel; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Docdporsel = value;
				SetDirty("Docdporsel");
			}
		}



		[SoapElement(ElementName="StkAct")]
		[XmlElement(ElementName="StkAct")]
		public string gxTpr_Stkact_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtEntrada_SdtEntradaItem_Stkact, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Stkact = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Stkact
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Stkact; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Stkact = value;
				SetDirty("Stkact");
			}
		}




		[SoapElement(ElementName="DocDObs")]
		[XmlElement(ElementName="DocDObs")]
		public string gxTpr_Docdobs
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Docdobs; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Docdobs = value;
				SetDirty("Docdobs");
			}
		}




		[SoapElement(ElementName="ProdBon")]
		[XmlElement(ElementName="ProdBon")]
		public string gxTpr_Prodbon
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Prodbon; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Prodbon = value;
				SetDirty("Prodbon");
			}
		}




		[SoapElement(ElementName="ProdAfecICBPER")]
		[XmlElement(ElementName="ProdAfecICBPER")]
		public short gxTpr_Prodafecicbper
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Prodafecicbper; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Prodafecicbper = value;
				SetDirty("Prodafecicbper");
			}
		}



		[SoapElement(ElementName="ProdValICBPER")]
		[XmlElement(ElementName="ProdValICBPER")]
		public string gxTpr_Prodvalicbper_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtEntrada_SdtEntradaItem_Prodvalicbper, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Prodvalicbper = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Prodvalicbper
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Prodvalicbper; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Prodvalicbper = value;
				SetDirty("Prodvalicbper");
			}
		}



		[SoapElement(ElementName="DocDValSel")]
		[XmlElement(ElementName="DocDValSel")]
		public string gxTpr_Docdvalsel_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtEntrada_SdtEntradaItem_Docdvalsel, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Docdvalsel = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Docdvalsel
		{
			get {
				return gxTv_SdtSdtEntrada_SdtEntradaItem_Docdvalsel; 
			}
			set {
				gxTv_SdtSdtEntrada_SdtEntradaItem_Docdvalsel = value;
				SetDirty("Docdvalsel");
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
			gxTv_SdtSdtEntrada_SdtEntradaItem_Proddsc = "";


			gxTv_SdtSdtEntrada_SdtEntradaItem_Prodcod = "";
			gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref1 = "";
			gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref2 = "";





			gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref3 = "";
			gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref4 = "";



			gxTv_SdtSdtEntrada_SdtEntradaItem_Uniabr = "";




			gxTv_SdtSdtEntrada_SdtEntradaItem_Docdobs = "";
			gxTv_SdtSdtEntrada_SdtEntradaItem_Prodbon = "";



			return  ;
		}



		#endregion

		#region Declaration

		protected string gxTv_SdtSdtEntrada_SdtEntradaItem_Proddsc;
		 

		protected decimal gxTv_SdtSdtEntrada_SdtEntradaItem_Costo;
		 

		protected int gxTv_SdtSdtEntrada_SdtEntradaItem_Item;
		 

		protected string gxTv_SdtSdtEntrada_SdtEntradaItem_Prodcod;
		 

		protected string gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref1;
		 

		protected string gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref2;
		 

		protected decimal gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadlote;
		 

		protected short gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadsts;
		 

		protected decimal gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadbultos;
		 

		protected decimal gxTv_SdtSdtEntrada_SdtEntradaItem_Precio;
		 

		protected decimal gxTv_SdtSdtEntrada_SdtEntradaItem_Cantidad;
		 

		protected string gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref3;
		 

		protected string gxTv_SdtSdtEntrada_SdtEntradaItem_Mvadref4;
		 

		protected short gxTv_SdtSdtEntrada_SdtEntradaItem_Docdina;
		 

		protected decimal gxTv_SdtSdtEntrada_SdtEntradaItem_Docdafecto;
		 

		protected decimal gxTv_SdtSdtEntrada_SdtEntradaItem_Docdinafecto;
		 

		protected string gxTv_SdtSdtEntrada_SdtEntradaItem_Uniabr;
		 

		protected decimal gxTv_SdtSdtEntrada_SdtEntradaItem_Docddct;
		 

		protected decimal gxTv_SdtSdtEntrada_SdtEntradaItem_Docddct2;
		 

		protected decimal gxTv_SdtSdtEntrada_SdtEntradaItem_Docdporsel;
		 

		protected decimal gxTv_SdtSdtEntrada_SdtEntradaItem_Stkact;
		 

		protected string gxTv_SdtSdtEntrada_SdtEntradaItem_Docdobs;
		 

		protected string gxTv_SdtSdtEntrada_SdtEntradaItem_Prodbon;
		 

		protected short gxTv_SdtSdtEntrada_SdtEntradaItem_Prodafecicbper;
		 

		protected decimal gxTv_SdtSdtEntrada_SdtEntradaItem_Prodvalicbper;
		 

		protected decimal gxTv_SdtSdtEntrada_SdtEntradaItem_Docdvalsel;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SdtEntradaItem", Namespace="SIGERP_ADVANCED")]
	public class SdtSdtEntrada_SdtEntradaItem_RESTInterface : GxGenericCollectionItem<SdtSdtEntrada_SdtEntradaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdtEntrada_SdtEntradaItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdtEntrada_SdtEntradaItem_RESTInterface( SdtSdtEntrada_SdtEntradaItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="ProdDsc", Order=0)]
		public  string gxTpr_Proddsc
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proddsc);

			}
			set { 
				 sdt.gxTpr_Proddsc = value;
			}
		}

		[DataMember(Name="Costo", Order=1)]
		public  string gxTpr_Costo
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Costo, 18, 4));

			}
			set { 
				sdt.gxTpr_Costo =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Item", Order=2)]
		public int gxTpr_Item
		{
			get { 
				return sdt.gxTpr_Item;

			}
			set { 
				sdt.gxTpr_Item = value;
			}
		}

		[DataMember(Name="ProdCod", Order=3)]
		public  string gxTpr_Prodcod
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Prodcod);

			}
			set { 
				 sdt.gxTpr_Prodcod = value;
			}
		}

		[DataMember(Name="MVADRef1", Order=4)]
		public  string gxTpr_Mvadref1
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mvadref1);

			}
			set { 
				 sdt.gxTpr_Mvadref1 = value;
			}
		}

		[DataMember(Name="MVADRef2", Order=5)]
		public  string gxTpr_Mvadref2
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mvadref2);

			}
			set { 
				 sdt.gxTpr_Mvadref2 = value;
			}
		}

		[DataMember(Name="MVADLote", Order=6)]
		public  string gxTpr_Mvadlote
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mvadlote, 15, 4));

			}
			set { 
				sdt.gxTpr_Mvadlote =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MVADSts", Order=7)]
		public short gxTpr_Mvadsts
		{
			get { 
				return sdt.gxTpr_Mvadsts;

			}
			set { 
				sdt.gxTpr_Mvadsts = value;
			}
		}

		[DataMember(Name="MVADBultos", Order=8)]
		public  string gxTpr_Mvadbultos
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mvadbultos, 15, 4));

			}
			set { 
				sdt.gxTpr_Mvadbultos =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Precio", Order=9)]
		public  string gxTpr_Precio
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Precio, 18, 6));

			}
			set { 
				sdt.gxTpr_Precio =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="Cantidad", Order=10)]
		public  string gxTpr_Cantidad
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Cantidad, 18, 4));

			}
			set { 
				sdt.gxTpr_Cantidad =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MVADRef3", Order=11)]
		public  string gxTpr_Mvadref3
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mvadref3);

			}
			set { 
				 sdt.gxTpr_Mvadref3 = value;
			}
		}

		[DataMember(Name="MVADRef4", Order=12)]
		public  string gxTpr_Mvadref4
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mvadref4);

			}
			set { 
				 sdt.gxTpr_Mvadref4 = value;
			}
		}

		[DataMember(Name="DocDIna", Order=13)]
		public short gxTpr_Docdina
		{
			get { 
				return sdt.gxTpr_Docdina;

			}
			set { 
				sdt.gxTpr_Docdina = value;
			}
		}

		[DataMember(Name="DocDAfecto", Order=14)]
		public  string gxTpr_Docdafecto
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Docdafecto, 15, 4));

			}
			set { 
				sdt.gxTpr_Docdafecto =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DocDInafecto", Order=15)]
		public  string gxTpr_Docdinafecto
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Docdinafecto, 15, 4));

			}
			set { 
				sdt.gxTpr_Docdinafecto =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="UniAbr", Order=16)]
		public  string gxTpr_Uniabr
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Uniabr);

			}
			set { 
				 sdt.gxTpr_Uniabr = value;
			}
		}

		[DataMember(Name="DocDDct", Order=17)]
		public  string gxTpr_Docddct
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Docddct, 10, 2));

			}
			set { 
				sdt.gxTpr_Docddct =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DocDDct2", Order=18)]
		public  string gxTpr_Docddct2
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Docddct2, 10, 2));

			}
			set { 
				sdt.gxTpr_Docddct2 =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DocDPorSel", Order=19)]
		public decimal gxTpr_Docdporsel
		{
			get { 
				return sdt.gxTpr_Docdporsel;

			}
			set { 
				sdt.gxTpr_Docdporsel = value;
			}
		}

		[DataMember(Name="StkAct", Order=20)]
		public  string gxTpr_Stkact
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Stkact, 15, 4));

			}
			set { 
				sdt.gxTpr_Stkact =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DocDObs", Order=21)]
		public  string gxTpr_Docdobs
		{
			get { 
				return sdt.gxTpr_Docdobs;

			}
			set { 
				 sdt.gxTpr_Docdobs = value;
			}
		}

		[DataMember(Name="ProdBon", Order=22)]
		public  string gxTpr_Prodbon
		{
			get { 
				return sdt.gxTpr_Prodbon;

			}
			set { 
				 sdt.gxTpr_Prodbon = value;
			}
		}

		[DataMember(Name="ProdAfecICBPER", Order=23)]
		public short gxTpr_Prodafecicbper
		{
			get { 
				return sdt.gxTpr_Prodafecicbper;

			}
			set { 
				sdt.gxTpr_Prodafecicbper = value;
			}
		}

		[DataMember(Name="ProdValICBPER", Order=24)]
		public  string gxTpr_Prodvalicbper
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Prodvalicbper, 15, 2));

			}
			set { 
				sdt.gxTpr_Prodvalicbper =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="DocDValSel", Order=25)]
		public  string gxTpr_Docdvalsel
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Docdvalsel, 15, 2));

			}
			set { 
				sdt.gxTpr_Docdvalsel =  NumberUtil.Val( value, ".");
			}
		}


		#endregion

		public SdtSdtEntrada_SdtEntradaItem sdt
		{
			get { 
				return (SdtSdtEntrada_SdtEntradaItem)Sdt;
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
				sdt = new SdtSdtEntrada_SdtEntradaItem() ;
			}
		}
	}
	#endregion
}