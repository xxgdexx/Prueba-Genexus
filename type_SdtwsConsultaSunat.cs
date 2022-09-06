using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.XML;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [Serializable]
   public class SdtwsConsultaSunat : GxUserType
   {
      public SdtwsConsultaSunat( )
      {
         /* Constructor for serialization */
      }

      public SdtwsConsultaSunat( IGxContext context )
      {
         this.context = context;
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

      public string consultaruc( string gxTp_ruc )
      {
         string returnconsultaruc;
         sIncludeState = true;
         returnconsultaruc = "";
         context.nSOAPErr = 0;
         context.sSOAPErrMsg = "";
         GXSoapHTTPClient.Host = "sigerp.com";
         GXSoapHTTPClient.Port = 80;
         GXSoapHTTPClient.BaseURL = "/CONSULTARUC/";
         SoapParm.AssignLocationProperties( context, "wsConsultaSunat", GXSoapHTTPClient);
         if ( StringUtil.StrCmp(defaultExecute, "") == 0 )
         {
            targetResourceName = (string)(SoapParm.GetResourceName(context, "wsConsultaSunat"));
            if ( StringUtil.StrCmp(targetResourceName, "") == 0 )
            {
               execName = "WSCONSULTASUNAT.ASMX";
            }
            else
            {
               execName = targetResourceName;
            }
         }
         else
         {
            execName = defaultExecute;
         }
         GXSoapHTTPClient.AddHeader("Content-type", "text/xml;charset=utf-8");
         GXSoapHTTPClient.AddHeader("SOAPAction", "http://tempuri.org/ConsultaRUC");
         GXSoapXMLWriter.OpenRequest(GXSoapHTTPClient);
         GXSoapXMLWriter.WriteStartDocument("utf-8", 0);
         GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Envelope");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENV", "http://schemas.xmlsoap.org/soap/envelope/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
         GXSoapXMLWriter.WriteAttribute("xmlns:SOAP-ENC", "http://schemas.xmlsoap.org/soap/encoding/");
         GXSoapXMLWriter.WriteAttribute("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
         if ( ! ( soapHeaders == null ) )
         {
            if ( soapHeaders.Count > 0 )
            {
               soapHeaders.writexml(GXSoapXMLWriter, "SOAP-ENV:Header", "", false);
            }
         }
         else
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( soapHeadersRaw)) ) )
            {
               GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Header");
               GXSoapXMLWriter.WriteRawText(soapHeadersRaw);
               GXSoapXMLWriter.WriteEndElement();
            }
         }
         GXSoapXMLWriter.WriteStartElement("SOAP-ENV:Body");
         GXSoapXMLWriter.WriteStartElement("ConsultaRUC");
         GXSoapXMLWriter.WriteAttribute("xmlns", "http://tempuri.org/");
         GXSoapXMLWriter.WriteElement("ruc", StringUtil.RTrim( gxTp_ruc));
         GXSoapXMLWriter.WriteAttribute("xmlns", "http://tempuri.org/");
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.WriteEndElement();
         GXSoapXMLWriter.Close();
         GXSoapHTTPClient.Execute("POST", execName);
         if ( GXSoapHTTPClient.ErrCode != 0 )
         {
            currSoapErr = (short)(GXSoapHTTPClient.ErrCode*-1-10000);
            currSoapErrmsg = GXSoapHTTPClient.ErrDescription;
         }
         GXSoapXMLReader.OpenResponse(GXSoapHTTPClient);
         GXSoapError = GXSoapXMLReader.Read();
         while ( GXSoapError > 0 )
         {
            if ( StringUtil.StringSearch( GXSoapXMLReader.Name, "Envelope", 1) > 0 )
            {
               this.SetPrefixesFromReader( GXSoapXMLReader);
            }
            if ( StringUtil.StringSearch( GXSoapXMLReader.Name, "Body", 1) > 0 )
            {
               if (true) break;
            }
            GXSoapError = GXSoapXMLReader.Read();
         }
         if ( GXSoapError > 0 )
         {
            GXSoapError = GXSoapXMLReader.Read();
            this.SetPrefixesFromReader( GXSoapXMLReader);
            if ( ( GXSoapError > 0 ) && ( StringUtil.StrCmp(GXSoapXMLReader.LocalName, "Fault") == 0 ) )
            {
               soapFault = 1;
            }
         }
         formatError = false;
         sTagName = GXSoapXMLReader.Name;
         if ( GXSoapXMLReader.IsSimple == 0 )
         {
            if ( soapFault == 0 )
            {
               GXSoapError = GXSoapXMLReader.Read();
               if ( ( GXSoapError > 0 ) && ( StringUtil.StrCmp(GXSoapXMLReader.LocalName, "Fault") == 0 ) )
               {
                  soapFault = 1;
               }
            }
            if ( soapFault == 1 )
            {
               soapFaultHandling( ) ;
            }
            else
            {
               nOutParmCount = 0;
               while ( ( ( StringUtil.StrCmp(GXSoapXMLReader.Name, sTagName) != 0 ) || ( GXSoapXMLReader.NodeType == 1 ) ) && ( GXSoapError > 0 ) )
               {
                  readOk = 0;
                  readElement = false;
                  this.SetNamedPrefixesFromReader( GXSoapXMLReader);
                  if ( StringUtil.StrCmp2( GXSoapXMLReader.LocalName, "ConsultaRUCResult") && ( GXSoapXMLReader.NodeType != 2 ) && ( StringUtil.StrCmp(GXSoapXMLReader.NamespaceURI, "http://tempuri.org/") == 0 ) )
                  {
                     returnconsultaruc = GXSoapXMLReader.Value;
                     readElement = true;
                     if ( GXSoapError > 0 )
                     {
                        readOk = 1;
                     }
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  if ( ! readElement )
                  {
                     readOk = 1;
                     GXSoapError = GXSoapXMLReader.Read();
                  }
                  nOutParmCount = (short)(nOutParmCount+1);
                  if ( ( readOk == 0 ) || formatError )
                  {
                     context.sSOAPErrMsg += "Error reading " + sTagName + StringUtil.NewLine( );
                     context.sSOAPErrMsg += "Message: " + GXSoapXMLReader.ReadRawXML();
                     GXSoapError = (short)(nOutParmCount*-1);
                  }
               }
            }
         }
         GXSoapXMLReader.Close();
         if ( currSoapErr == 0 )
         {
            if ( GXSoapError < 0 )
            {
               currSoapErr = (short)(GXSoapError*-1);
               currSoapErrmsg = context.sSOAPErrMsg;
            }
            else
            {
               if ( GXSoapXMLReader.ErrCode > 0 )
               {
                  currSoapErr = (short)(GXSoapXMLReader.ErrCode*-1);
                  currSoapErrmsg = GXSoapXMLReader.ErrDescription;
               }
               else
               {
                  if ( GXSoapError == 0 )
                  {
                     currSoapErr = (short)(-20001);
                     currSoapErrmsg = "Malformed SOAP message.";
                  }
                  else
                  {
                     currSoapErr = 0;
                     currSoapErrmsg = "No error.";
                  }
               }
            }
         }
         if ( currSoapErr != 0 )
         {
            oLocation = SoapParm.getlocation( context, "wsConsultaSunat");
            if ( ( oLocation.CancelOnError == 0 ) || ( oLocation.CancelOnError == 1 ) )
            {
               throw new Exception( currSoapErrmsg+"("+StringUtil.LTrim( StringUtil.NToC( (decimal)(currSoapErr), 6, 0, ".", ""))+")") ;
            }
         }
         context.nSOAPErr = currSoapErr;
         context.sSOAPErrMsg = currSoapErrmsg;
         return returnconsultaruc ;
      }

      public void soapFaultHandling( )
      {
         GXSoapXMLReader.Read();
         while ( ! ( ( StringUtil.StrCmp(GXSoapXMLReader.LocalName, "Fault") == 0 ) && ( GXSoapXMLReader.NodeType == 2 ) ) )
         {
            if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapXMLReader.Name), "faultcode") == 0 )
            {
               sFaultCode = GXSoapXMLReader.Value;
            }
            else if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapXMLReader.Name), "faultstring") == 0 )
            {
               sFaultString = GXSoapXMLReader.Value;
            }
            else if ( StringUtil.StrCmp(StringUtil.Lower( GXSoapXMLReader.Name), "detail") == 0 )
            {
               if ( GXSoapXMLReader.IsSimple != 0 )
               {
                  GXSoapXMLReader.Read();
                  sDetail = GXSoapXMLReader.ReadRawXML();
               }
               else
               {
                  sDetail = GXSoapXMLReader.Value;
               }
            }
            if ( ! ( ( StringUtil.StrCmp(GXSoapXMLReader.LocalName, "Fault") == 0 ) && ( GXSoapXMLReader.NodeType == 2 ) ) )
            {
               GXSoapError = GXSoapXMLReader.Read();
               if ( GXSoapError == 0 )
               {
                  if (true) break;
               }
            }
         }
         if ( StringUtil.StringSearch( StringUtil.Lower( sFaultCode), "client", 1) > 0 )
         {
            currSoapErr = (short)(-20004);
            currSoapErrmsg += "SOAP Fault: Error in client request." + StringUtil.NewLine( ) + "Message: " + sFaultString + StringUtil.NewLine( ) + "Detail: " + sDetail;
         }
         else if ( StringUtil.StringSearch( StringUtil.Lower( sFaultCode), "server", 1) > 0 )
         {
            currSoapErr = (short)(-20005);
            currSoapErrmsg += "SOAP Fault: Error in server execution." + StringUtil.NewLine( ) + "Message: " + sFaultString + StringUtil.NewLine( ) + "Detail: " + sDetail;
         }
         else
         {
            currSoapErr = (short)(-20006);
            currSoapErrmsg += "Unknown error: " + sFaultCode + StringUtil.NewLine( ) + "Message: " + sFaultString + StringUtil.NewLine( ) + "Detail: " + sDetail;
         }
         return  ;
      }

      public string DefaultExecute
      {
         get {
            return defaultExecute ;
         }

         set {
            defaultExecute = (string)(value);
         }

      }

      public GxUnknownObjectCollection SoapHeaders
      {
         get {
            if ( soapHeaders == null )
            {
               soapHeaders = new GxUnknownObjectCollection();
            }
            return soapHeaders ;
         }

      }

      public string SoapHeadersRaw
      {
         get {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( soapHeadersRaw)) )
            {
               soapHeadersRaw = "";
            }
            return soapHeadersRaw ;
         }

         set {
            soapHeadersRaw = (string)(value);
         }

      }

      public void initialize( )
      {
         defaultExecute = "";
         GXSoapHTTPClient = new GxHttpClient( context);
         execName = "";
         targetResourceName = "";
         GXSoapXMLReader = new GXXMLReader(context.GetPhysicalPath());
         GXSoapXMLWriter = new GXXMLWriter(context.GetPhysicalPath());
         currSoapErrmsg = "";
         sTagName = "";
         oLocation = new GxLocation();
         sFaultCode = "";
         sFaultString = "";
         sDetail = "";
         return  ;
      }

      protected short GXSoapError ;
      protected short currSoapErr ;
      protected short soapFault ;
      protected short readOk ;
      protected short nOutParmCount ;
      protected string defaultExecute ;
      protected string execName ;
      protected string targetResourceName ;
      protected string currSoapErrmsg ;
      protected string soapHeadersRaw ;
      protected string sTagName ;
      protected string sFaultCode ;
      protected string sFaultString ;
      protected string sDetail ;
      protected bool sIncludeState ;
      protected bool readElement ;
      protected bool formatError ;
      protected GXXMLReader GXSoapXMLReader ;
      protected GXXMLWriter GXSoapXMLWriter ;
      protected GxHttpClient GXSoapHTTPClient ;
      protected GxLocation oLocation ;
      protected GxUnknownObjectCollection soapHeaders ;
   }

}
