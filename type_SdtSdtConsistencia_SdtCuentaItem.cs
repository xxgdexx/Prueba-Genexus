/*
				   File: type_SdtSdtConsistencia_SdtCuentaItem
			Description: SdtConsistencia
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
	public class SdtSdtConsistencia_SdtCuentaItem : GxUserType
	{
		public SdtSdtConsistencia_SdtCuentaItem( )
		{
			/* Constructor for serialization */
			gxTv_SdtSdtConsistencia_SdtCuentaItem_Ordcod = "";

			gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvacod = "";

			gxTv_SdtSdtConsistencia_SdtCuentaItem_Prodcod = "";

			gxTv_SdtSdtConsistencia_SdtCuentaItem_Proddsc = "";

			gxTv_SdtSdtConsistencia_SdtCuentaItem_Tipcod = "";

			gxTv_SdtSdtConsistencia_SdtCuentaItem_Comcod = "";

			gxTv_SdtSdtConsistencia_SdtCuentaItem_Movdsc = "";

		}

		public SdtSdtConsistencia_SdtCuentaItem(IGxContext context)
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
			AddObjectProperty("OrdCod", gxTpr_Ordcod, false);


			AddObjectProperty("MvACod", gxTpr_Mvacod, false);


			sDateCnv = "";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Year(gxTpr_Mvafec)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("0000", 1, 4-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Month(gxTpr_Mvafec)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			sDateCnv = sDateCnv + "-";
			sNumToPad = StringUtil.Trim(StringUtil.Str((decimal)(DateTimeUtil.Day(gxTpr_Mvafec)), 10, 0));
			sDateCnv = sDateCnv + StringUtil.Substring("00", 1, 2-StringUtil.Len(sNumToPad)) + sNumToPad;
			AddObjectProperty("MvAFec", sDateCnv, false);



			AddObjectProperty("ProdCod", gxTpr_Prodcod, false);


			AddObjectProperty("ProdDsc", gxTpr_Proddsc, false);


			AddObjectProperty("TipCod", gxTpr_Tipcod, false);


			AddObjectProperty("ComCod", gxTpr_Comcod, false);


			AddObjectProperty("MvADCant", gxTpr_Mvadcant, false);


			AddObjectProperty("MVADCosto", gxTpr_Mvadcosto, false);


			AddObjectProperty("ComDCant", gxTpr_Comdcant, false);


			AddObjectProperty("ComDTot", gxTpr_Comdtot, false);


			AddObjectProperty("MovDsc", gxTpr_Movdsc, false);

			return;
		}
		#endregion

		#region Properties

		[SoapElement(ElementName="OrdCod")]
		[XmlElement(ElementName="OrdCod")]
		public string gxTpr_Ordcod
		{
			get {
				return gxTv_SdtSdtConsistencia_SdtCuentaItem_Ordcod; 
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Ordcod = value;
				SetDirty("Ordcod");
			}
		}




		[SoapElement(ElementName="MvACod")]
		[XmlElement(ElementName="MvACod")]
		public string gxTpr_Mvacod
		{
			get {
				return gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvacod; 
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvacod = value;
				SetDirty("Mvacod");
			}
		}



		[SoapElement(ElementName="MvAFec")]
		[XmlElement(ElementName="MvAFec" , IsNullable=true)]
		public string gxTpr_Mvafec_Nullable
		{
			get {
				if ( gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvafec == DateTime.MinValue)
					return null;
				return new GxDateString(gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvafec).value ;
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvafec = DateTimeUtil.CToD2(value);
			}
		}

		[XmlIgnore]
		public DateTime gxTpr_Mvafec
		{
			get {
				return gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvafec; 
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvafec = value;
				SetDirty("Mvafec");
			}
		}



		[SoapElement(ElementName="ProdCod")]
		[XmlElement(ElementName="ProdCod")]
		public string gxTpr_Prodcod
		{
			get {
				return gxTv_SdtSdtConsistencia_SdtCuentaItem_Prodcod; 
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Prodcod = value;
				SetDirty("Prodcod");
			}
		}




		[SoapElement(ElementName="ProdDsc")]
		[XmlElement(ElementName="ProdDsc")]
		public string gxTpr_Proddsc
		{
			get {
				return gxTv_SdtSdtConsistencia_SdtCuentaItem_Proddsc; 
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Proddsc = value;
				SetDirty("Proddsc");
			}
		}




		[SoapElement(ElementName="TipCod")]
		[XmlElement(ElementName="TipCod")]
		public string gxTpr_Tipcod
		{
			get {
				return gxTv_SdtSdtConsistencia_SdtCuentaItem_Tipcod; 
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Tipcod = value;
				SetDirty("Tipcod");
			}
		}




		[SoapElement(ElementName="ComCod")]
		[XmlElement(ElementName="ComCod")]
		public string gxTpr_Comcod
		{
			get {
				return gxTv_SdtSdtConsistencia_SdtCuentaItem_Comcod; 
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Comcod = value;
				SetDirty("Comcod");
			}
		}



		[SoapElement(ElementName="MvADCant")]
		[XmlElement(ElementName="MvADCant")]
		public string gxTpr_Mvadcant_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvadcant, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvadcant = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Mvadcant
		{
			get {
				return gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvadcant; 
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvadcant = value;
				SetDirty("Mvadcant");
			}
		}



		[SoapElement(ElementName="MVADCosto")]
		[XmlElement(ElementName="MVADCosto")]
		public string gxTpr_Mvadcosto_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvadcosto, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvadcosto = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Mvadcosto
		{
			get {
				return gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvadcosto; 
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvadcosto = value;
				SetDirty("Mvadcosto");
			}
		}



		[SoapElement(ElementName="ComDCant")]
		[XmlElement(ElementName="ComDCant")]
		public string gxTpr_Comdcant_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtConsistencia_SdtCuentaItem_Comdcant, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Comdcant = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Comdcant
		{
			get {
				return gxTv_SdtSdtConsistencia_SdtCuentaItem_Comdcant; 
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Comdcant = value;
				SetDirty("Comdcant");
			}
		}



		[SoapElement(ElementName="ComDTot")]
		[XmlElement(ElementName="ComDTot")]
		public string gxTpr_Comdtot_double
		{
			get {
				return Convert.ToString(gxTv_SdtSdtConsistencia_SdtCuentaItem_Comdtot, System.Globalization.CultureInfo.InvariantCulture);
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Comdtot = (decimal)(Convert.ToDecimal(value, System.Globalization.CultureInfo.InvariantCulture));
			}
		}
		[XmlIgnore]
		public decimal gxTpr_Comdtot
		{
			get {
				return gxTv_SdtSdtConsistencia_SdtCuentaItem_Comdtot; 
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Comdtot = value;
				SetDirty("Comdtot");
			}
		}




		[SoapElement(ElementName="MovDsc")]
		[XmlElement(ElementName="MovDsc")]
		public string gxTpr_Movdsc
		{
			get {
				return gxTv_SdtSdtConsistencia_SdtCuentaItem_Movdsc; 
			}
			set {
				gxTv_SdtSdtConsistencia_SdtCuentaItem_Movdsc = value;
				SetDirty("Movdsc");
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
			gxTv_SdtSdtConsistencia_SdtCuentaItem_Ordcod = "";
			gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvacod = "";

			gxTv_SdtSdtConsistencia_SdtCuentaItem_Prodcod = "";
			gxTv_SdtSdtConsistencia_SdtCuentaItem_Proddsc = "";
			gxTv_SdtSdtConsistencia_SdtCuentaItem_Tipcod = "";
			gxTv_SdtSdtConsistencia_SdtCuentaItem_Comcod = "";




			gxTv_SdtSdtConsistencia_SdtCuentaItem_Movdsc = "";
			sDateCnv = "";
			sNumToPad = "";
			return  ;
		}



		#endregion

		#region Declaration

		protected string sDateCnv ;
		protected string sNumToPad ;
		protected string gxTv_SdtSdtConsistencia_SdtCuentaItem_Ordcod;
		 

		protected string gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvacod;
		 

		protected DateTime gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvafec;
		 

		protected string gxTv_SdtSdtConsistencia_SdtCuentaItem_Prodcod;
		 

		protected string gxTv_SdtSdtConsistencia_SdtCuentaItem_Proddsc;
		 

		protected string gxTv_SdtSdtConsistencia_SdtCuentaItem_Tipcod;
		 

		protected string gxTv_SdtSdtConsistencia_SdtCuentaItem_Comcod;
		 

		protected decimal gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvadcant;
		 

		protected decimal gxTv_SdtSdtConsistencia_SdtCuentaItem_Mvadcosto;
		 

		protected decimal gxTv_SdtSdtConsistencia_SdtCuentaItem_Comdcant;
		 

		protected decimal gxTv_SdtSdtConsistencia_SdtCuentaItem_Comdtot;
		 

		protected string gxTv_SdtSdtConsistencia_SdtCuentaItem_Movdsc;
		 


		#endregion
	}
	#region Rest interface
	[DataContract(Name=@"SdtCuentaItem", Namespace="SIGERP_ADVANCED")]
	public class SdtSdtConsistencia_SdtCuentaItem_RESTInterface : GxGenericCollectionItem<SdtSdtConsistencia_SdtCuentaItem>, System.Web.SessionState.IRequiresSessionState
	{
		public SdtSdtConsistencia_SdtCuentaItem_RESTInterface( ) : base()
		{	
		}

		public SdtSdtConsistencia_SdtCuentaItem_RESTInterface( SdtSdtConsistencia_SdtCuentaItem psdt ) : base(psdt)
		{	
		}

		#region Rest Properties
		[DataMember(Name="OrdCod", Order=0)]
		public  string gxTpr_Ordcod
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Ordcod);

			}
			set { 
				 sdt.gxTpr_Ordcod = value;
			}
		}

		[DataMember(Name="MvACod", Order=1)]
		public  string gxTpr_Mvacod
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Mvacod);

			}
			set { 
				 sdt.gxTpr_Mvacod = value;
			}
		}

		[DataMember(Name="MvAFec", Order=2)]
		public  string gxTpr_Mvafec
		{
			get { 
				return DateTimeUtil.DToC2( sdt.gxTpr_Mvafec);

			}
			set { 
				sdt.gxTpr_Mvafec = DateTimeUtil.CToD2(value);
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

		[DataMember(Name="ProdDsc", Order=4)]
		public  string gxTpr_Proddsc
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Proddsc);

			}
			set { 
				 sdt.gxTpr_Proddsc = value;
			}
		}

		[DataMember(Name="TipCod", Order=5)]
		public  string gxTpr_Tipcod
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Tipcod);

			}
			set { 
				 sdt.gxTpr_Tipcod = value;
			}
		}

		[DataMember(Name="ComCod", Order=6)]
		public  string gxTpr_Comcod
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Comcod);

			}
			set { 
				 sdt.gxTpr_Comcod = value;
			}
		}

		[DataMember(Name="MvADCant", Order=7)]
		public  string gxTpr_Mvadcant
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mvadcant, 15, 4));

			}
			set { 
				sdt.gxTpr_Mvadcant =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MVADCosto", Order=8)]
		public  string gxTpr_Mvadcosto
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Mvadcosto, 15, 2));

			}
			set { 
				sdt.gxTpr_Mvadcosto =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ComDCant", Order=9)]
		public  string gxTpr_Comdcant
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Comdcant, 15, 4));

			}
			set { 
				sdt.gxTpr_Comdcant =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="ComDTot", Order=10)]
		public  string gxTpr_Comdtot
		{
			get { 
				return StringUtil.LTrim( StringUtil.Str(  sdt.gxTpr_Comdtot, 15, 2));

			}
			set { 
				sdt.gxTpr_Comdtot =  NumberUtil.Val( value, ".");
			}
		}

		[DataMember(Name="MovDsc", Order=11)]
		public  string gxTpr_Movdsc
		{
			get { 
				return StringUtil.RTrim( sdt.gxTpr_Movdsc);

			}
			set { 
				 sdt.gxTpr_Movdsc = value;
			}
		}


		#endregion

		public SdtSdtConsistencia_SdtCuentaItem sdt
		{
			get { 
				return (SdtSdtConsistencia_SdtCuentaItem)Sdt;
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
				sdt = new SdtSdtConsistencia_SdtCuentaItem() ;
			}
		}
	}
	#endregion
}