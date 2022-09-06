using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.seguridad {
   public class usuariosalmacen : GXWebComponent
   {
      public usuariosalmacen( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusTheme");
         }
      }

      public usuariosalmacen( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_UsuCod )
      {
         this.AV7UsuCod = aP0_UsuCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
         lstavNotassociatedrecords = new GXListbox();
         lstavAssociatedrecords = new GXListbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "UsuCod");
               gxfirstwebparm_bkp = gxfirstwebparm;
               gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
               toggleJsOutput = isJsOutputEnabled( );
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
               if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
               {
                  setAjaxCallMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  dyncall( GetNextPar( )) ;
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV7UsuCod = GetPar( "UsuCod");
                  AssignAttri(sPrefix, false, "AV7UsuCod", AV7UsuCod);
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(string)AV7UsuCod});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
                  return  ;
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "UsuCod");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "UsuCod");
               }
               else
               {
                  if ( ! IsValidAjaxCall( false) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = gxfirstwebparm_bkp;
               }
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0G2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               context.Gx_err = 0;
               WS0G2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Usuarios Almacen") ;
            context.WriteHtmlTextNl( "</title>") ;
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( StringUtil.Len( sDynURL) > 0 )
            {
               context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
            }
            define_styles( ) ;
         }
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 194480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202281816145890", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            GXKey = Crypto.GetSiteKey( );
            GXEncryptionTmp = "seguridad.usuariosalmacen.aspx"+UrlEncode(StringUtil.RTrim(AV7UsuCod));
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seguridad.usuariosalmacen.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Crypto.GetSiteKey( );
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV7UsuCod", StringUtil.RTrim( wcpOAV7UsuCod));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vADDEDKEYLIST", AV20AddedKeyList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vADDEDKEYLIST", AV20AddedKeyList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vADDEDDSCLIST", AV22AddedDscList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vADDEDDSCLIST", AV22AddedDscList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNOTADDEDKEYLIST", AV21NotAddedKeyList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNOTADDEDKEYLIST", AV21NotAddedKeyList);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vNOTADDEDDSCLIST", AV23NotAddedDscList);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vNOTADDEDDSCLIST", AV23NotAddedDscList);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vADDEDKEYLISTXML", AV16AddedKeyListXml);
         GxWebStd.gx_hidden_field( context, sPrefix+"vADDEDDSCLISTXML", AV18AddedDscListXml);
         GxWebStd.gx_hidden_field( context, sPrefix+"vNOTADDEDKEYLISTXML", AV17NotAddedKeyListXml);
         GxWebStd.gx_hidden_field( context, sPrefix+"vNOTADDEDDSCLISTXML", AV19NotAddedDscListXml);
         GxWebStd.gx_hidden_field( context, sPrefix+"USUCOD", StringUtil.RTrim( A348UsuCod));
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUCOD", StringUtil.RTrim( AV7UsuCod));
         GxWebStd.gx_hidden_field( context, sPrefix+"USUALMCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(A349UsuAlmCod), 6, 0, ".", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, sPrefix+"vSGUSUARIOALMACEN", AV11SGUSUARIOALMACEN);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(sPrefix+"vSGUSUARIOALMACEN", AV11SGUSUARIOALMACEN);
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"vUSUALMCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV8UsuAlmCod), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm0G2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
            SendComponentObjects();
            SendServerCommands();
            SendState();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            context.WriteHtmlTextNl( "</form>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            include_jscripts( ) ;
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "Seguridad.UsuariosAlmacen" ;
      }

      public override string GetPgmdesc( )
      {
         return "Usuarios Almacen" ;
      }

      protected void WB0G0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "seguridad.usuariosalmacen.aspx");
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablamensaje_Internalname, divTablamensaje_Visible, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTxtcontacmsj_Internalname, "Por favor, confirme primero los datos generales.", "", "", lblTxtcontacmsj_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "DataDescription", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\UsuariosAlmacen.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablacontenido_Internalname, divTablacontenido_Visible, 0, "px", 0, "px", "TableAssociation", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenotassociated_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 AssociationTitleCell", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNotassociatedrecordstitle_Internalname, "Registros No Asociados", "", "", lblNotassociatedrecordstitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "AssociationTitle", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\UsuariosAlmacen.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, lstavNotassociatedrecords_Internalname, "Not Associated Records", "col-sm-3 AssociationListAttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'" + sPrefix + "',false,'',0)\"";
            /* ListBox */
            GxWebStd.gx_listbox_ctrl1( context, lstavNotassociatedrecords, lstavNotassociatedrecords_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 6, 0)), 2, lstavNotassociatedrecords_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, lstavNotassociatedrecords.Enabled, 0, 0, 6, "em", 0, "row", "", "AssociationListAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "", true, 1, "HLP_Seguridad\\UsuariosAlmacen.htm");
            lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 6, 0));
            AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", (string)(lstavNotassociatedrecords.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-1 CellTableAssociationButtons", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableassociationbuttons_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-12 hidden-sm hidden-md hidden-lg", "left", "top", "", "", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-12 CellMarginTopAssociationButtons", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AssociationImage";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "6591e2a3-49b6-43b7-b8e3-a292564a32a4", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImageassociateall_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImageassociateall_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ASSOCIATE ALL\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\UsuariosAlmacen.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-12 CellMarginTopAssociationButtons", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AssociationImage";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "56a5f17b-0bc3-48b5-b303-afa6e0585b6d", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImageassociateselected_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImageassociateselected_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'ASSOCIATE SELECTED\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\UsuariosAlmacen.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-12 CellMarginTopAssociationButtons", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AssociationImage";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "a3800d0c-bf04-4575-bc01-11fe5d7b3525", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImagedisassociateselected_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImagedisassociateselected_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DISASSOCIATE SELECTED\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\UsuariosAlmacen.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-2 col-sm-12 CellMarginTopAssociationButtons", "left", "top", "", "", "div");
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'" + sPrefix + "',false,'',0)\"";
            ClassString = "AssociationImage";
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "c619e28f-4b32-4ff9-baaf-b3063fe4f782", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgImagedisassociateall_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgImagedisassociateall_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DISASSOCIATE ALL\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Seguridad\\UsuariosAlmacen.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-5", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableassociated_Internalname, 1, 0, "px", 0, "px", "", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 AssociationTitleCell", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblAssociatedrecordstitle_Internalname, "Registros Asociados", "", "", lblAssociatedrecordstitle_Jsonclick, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "AssociationTitle", 0, "", 1, 1, 0, 0, "HLP_Seguridad\\UsuariosAlmacen.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, lstavAssociatedrecords_Internalname, "Associated Records", "col-sm-3 AssociationListAttributeLabel", 0, true, "");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'" + sPrefix + "',false,'',0)\"";
            /* ListBox */
            GxWebStd.gx_listbox_ctrl1( context, lstavAssociatedrecords, lstavAssociatedrecords_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV24AssociatedRecords), 6, 0)), 2, lstavAssociatedrecords_Jsonclick, 0, "'"+sPrefix+"'"+",false,"+"'"+""+"'", "int", "", 1, lstavAssociatedrecords.Enabled, 0, 0, 6, "em", 0, "row", "", "AssociationListAttribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 1, "HLP_Seguridad\\UsuariosAlmacen.htm");
            lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24AssociatedRecords), 6, 0));
            AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", (string)(lstavAssociatedrecords.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnconfirm_Internalname, "", "Confirmar", bttBtnconfirm_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\UsuariosAlmacen.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'" + sPrefix + "',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Cancelar", bttBtncancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\UsuariosAlmacen.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0G2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) != 0 )
         {
            GXKey = Crypto.GetSiteKey( );
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 17_0_9-159740", 0) ;
               }
               Form.Meta.addItem("description", "Usuarios Almacen", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0G0( ) ;
            }
         }
      }

      protected void WS0G2( )
      {
         START0G2( ) ;
         EVT0G2( ) ;
      }

      protected void EVT0G2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E110G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E120G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E130G2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DISASSOCIATE SELECTED'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Disassociate Selected' */
                                    E140G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ASSOCIATE SELECTED'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Associate selected' */
                                    E150G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ASSOCIATE ALL'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Associate All' */
                                    E160G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DISASSOCIATE ALL'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'Disassociate All' */
                                    E170G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VASSOCIATEDRECORDS.DBLCLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E180G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VNOTASSOCIATEDRECORDS.DBLCLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E190G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E200G2 ();
                                 }
                              }
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    GX_FocusControl = lstavNotassociatedrecords_Internalname;
                                    AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VASSOCIATEDRECORDS.DBLCLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E180G2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VNOTASSOCIATEDRECORDS.DBLCLICK") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0G0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    E190G2 ();
                                 }
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0G2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0G2( ) ;
            }
         }
      }

      protected void PA0G2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            GXKey = Crypto.GetSiteKey( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
               {
                  GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
                  if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "seguridad.usuariosalmacen.aspx")), "seguridad.usuariosalmacen.aspx") == 0 ) )
                  {
                     SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "seguridad.usuariosalmacen.aspx")))) ;
                  }
                  else
                  {
                     GxWebError = 1;
                     context.HttpContext.Response.StatusCode = 403;
                     context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                     context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                     context.WriteHtmlText( "<p /><hr />") ;
                     GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  }
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( StringUtil.Len( sPrefix) == 0 )
               {
                  if ( nGotPars == 0 )
                  {
                     entryPointCalled = false;
                     gxfirstwebparm = GetFirstPar( "UsuCod");
                     toggleJsOutput = isJsOutputEnabled( );
                     if ( context.isSpaRequest( ) )
                     {
                        disableJsOutput();
                     }
                     if ( toggleJsOutput )
                     {
                        if ( context.isSpaRequest( ) )
                        {
                           enableJsOutput();
                        }
                     }
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = lstavNotassociatedrecords_Internalname;
               AssignAttri(sPrefix, false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( lstavNotassociatedrecords.ItemCount > 0 )
         {
            AV25NotAssociatedRecords = (int)(NumberUtil.Val( lstavNotassociatedrecords.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 6, 0))), "."));
            AssignAttri(sPrefix, false, "AV25NotAssociatedRecords", StringUtil.LTrimStr( (decimal)(AV25NotAssociatedRecords), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 6, 0));
            AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
         }
         if ( lstavAssociatedrecords.ItemCount > 0 )
         {
            AV24AssociatedRecords = (int)(NumberUtil.Val( lstavAssociatedrecords.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV24AssociatedRecords), 6, 0))), "."));
            AssignAttri(sPrefix, false, "AV24AssociatedRecords", StringUtil.LTrimStr( (decimal)(AV24AssociatedRecords), 6, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24AssociatedRecords), 6, 0));
            AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF0G2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E120G2 ();
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E200G2 ();
            WB0G0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0G2( )
      {
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0G0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110G2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOAV7UsuCod = cgiGet( sPrefix+"wcpOAV7UsuCod");
            /* Read variables values. */
            lstavNotassociatedrecords.CurrentValue = cgiGet( lstavNotassociatedrecords_Internalname);
            AV25NotAssociatedRecords = (int)(NumberUtil.Val( cgiGet( lstavNotassociatedrecords_Internalname), "."));
            AssignAttri(sPrefix, false, "AV25NotAssociatedRecords", StringUtil.LTrimStr( (decimal)(AV25NotAssociatedRecords), 6, 0));
            lstavAssociatedrecords.CurrentValue = cgiGet( lstavAssociatedrecords_Internalname);
            AV24AssociatedRecords = (int)(NumberUtil.Val( cgiGet( lstavAssociatedrecords_Internalname), "."));
            AssignAttri(sPrefix, false, "AV24AssociatedRecords", StringUtil.LTrimStr( (decimal)(AV24AssociatedRecords), 6, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Crypto.GetSiteKey( );
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E110G2 ();
         if (returnInSub) return;
      }

      protected void E110G2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         if ( StringUtil.StrCmp(AV9HTTPRequest.Method, "GET") == 0 )
         {
            AV29GXLvl8 = 0;
            /* Using cursor H000G2 */
            pr_default.execute(0, new Object[] {AV7UsuCod});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A348UsuCod = H000G2_A348UsuCod[0];
               AV29GXLvl8 = 1;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            if ( AV29GXLvl8 == 0 )
            {
               GX_msglist.addItem("Registro no encontrado");
            }
            /* Using cursor H000G3 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               A63AlmCod = H000G3_A63AlmCod[0];
               A436AlmDsc = H000G3_A436AlmDsc[0];
               AV8UsuAlmCod = A63AlmCod;
               AssignAttri(sPrefix, false, "AV8UsuAlmCod", StringUtil.LTrimStr( (decimal)(AV8UsuAlmCod), 6, 0));
               AV10Exist = false;
               /* Using cursor H000G4 */
               pr_default.execute(2, new Object[] {AV7UsuCod, AV8UsuAlmCod});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A349UsuAlmCod = H000G4_A349UsuAlmCod[0];
                  A348UsuCod = H000G4_A348UsuCod[0];
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7UsuCod)) )
                  {
                     divTablamensaje_Visible = 0;
                     AssignProp(sPrefix, false, divTablamensaje_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablamensaje_Visible), 5, 0), true);
                  }
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( AV7UsuCod)) )
                  {
                     divTablacontenido_Visible = 0;
                     AssignProp(sPrefix, false, divTablacontenido_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTablacontenido_Visible), 5, 0), true);
                  }
                  AV10Exist = true;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(2);
               AV13Description = A436AlmDsc;
               if ( AV10Exist )
               {
                  AV20AddedKeyList.Add(A63AlmCod, 0);
                  AV22AddedDscList.Add(AV13Description, 0);
               }
               else
               {
                  AV21NotAddedKeyList.Add(A63AlmCod, 0);
                  AV23NotAddedDscList.Add(AV13Description, 0);
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Execute user subroutine: 'SAVELISTS' */
            S112 ();
            if (returnInSub) return;
         }
      }

      protected void E120G2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         /* Execute user subroutine: 'UPDATEASSOCIATIONVARIABLES' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24AssociatedRecords), 6, 0));
         AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 6, 0));
         AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22AddedDscList", AV22AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20AddedKeyList", AV20AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21NotAddedKeyList", AV21NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23NotAddedDscList", AV23NotAddedDscList);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E130G2 ();
         if (returnInSub) return;
      }

      protected void E130G2( )
      {
         /* Enter Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTS' */
         S132 ();
         if (returnInSub) return;
         AV14i = 1;
         AV12Success = true;
         AV32GXV1 = 1;
         while ( AV32GXV1 <= AV20AddedKeyList.Count )
         {
            AV8UsuAlmCod = (int)(AV20AddedKeyList.GetNumeric(AV32GXV1));
            AssignAttri(sPrefix, false, "AV8UsuAlmCod", StringUtil.LTrimStr( (decimal)(AV8UsuAlmCod), 6, 0));
            if ( AV12Success )
            {
               AV10Exist = false;
               /* Using cursor H000G5 */
               pr_default.execute(3, new Object[] {AV7UsuCod, AV8UsuAlmCod});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A349UsuAlmCod = H000G5_A349UsuAlmCod[0];
                  A348UsuCod = H000G5_A348UsuCod[0];
                  AV10Exist = true;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(3);
               if ( ! AV10Exist )
               {
                  AV11SGUSUARIOALMACEN = new SdtSGUSUARIOALMACEN(context);
                  AV11SGUSUARIOALMACEN.gxTpr_Usucod = AV7UsuCod;
                  AV11SGUSUARIOALMACEN.gxTpr_Usualmcod = AV8UsuAlmCod;
                  AV11SGUSUARIOALMACEN.Save();
                  if ( ! AV11SGUSUARIOALMACEN.Success() )
                  {
                     AV12Success = false;
                  }
               }
            }
            AV14i = (int)(AV14i+1);
            AV32GXV1 = (int)(AV32GXV1+1);
         }
         AV14i = 1;
         AV34GXV2 = 1;
         while ( AV34GXV2 <= AV21NotAddedKeyList.Count )
         {
            AV8UsuAlmCod = (int)(AV21NotAddedKeyList.GetNumeric(AV34GXV2));
            AssignAttri(sPrefix, false, "AV8UsuAlmCod", StringUtil.LTrimStr( (decimal)(AV8UsuAlmCod), 6, 0));
            if ( AV12Success )
            {
               AV10Exist = false;
               /* Using cursor H000G6 */
               pr_default.execute(4, new Object[] {AV7UsuCod, AV8UsuAlmCod});
               while ( (pr_default.getStatus(4) != 101) )
               {
                  A349UsuAlmCod = H000G6_A349UsuAlmCod[0];
                  A348UsuCod = H000G6_A348UsuCod[0];
                  AV10Exist = true;
                  /* Exiting from a For First loop. */
                  if (true) break;
               }
               pr_default.close(4);
               if ( AV10Exist )
               {
                  AV11SGUSUARIOALMACEN = new SdtSGUSUARIOALMACEN(context);
                  AV11SGUSUARIOALMACEN.Load(AV7UsuCod, AV8UsuAlmCod);
                  if ( AV11SGUSUARIOALMACEN.Success() )
                  {
                     AV11SGUSUARIOALMACEN.Delete();
                  }
                  if ( ! AV11SGUSUARIOALMACEN.Success() )
                  {
                     AV12Success = false;
                  }
               }
            }
            AV14i = (int)(AV14i+1);
            AV34GXV2 = (int)(AV34GXV2+1);
         }
         if ( AV12Success )
         {
            context.CommitDataStores("seguridad.usuariosalmacen",pr_default);
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            /* Execute user subroutine: 'SHOW ERROR MESSAGES' */
            S142 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV11SGUSUARIOALMACEN", AV11SGUSUARIOALMACEN);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22AddedDscList", AV22AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20AddedKeyList", AV20AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21NotAddedKeyList", AV21NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23NotAddedDscList", AV23NotAddedDscList);
      }

      protected void E140G2( )
      {
         /* 'Disassociate Selected' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISASSOCIATESELECTED' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21NotAddedKeyList", AV21NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23NotAddedDscList", AV23NotAddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20AddedKeyList", AV20AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22AddedDscList", AV22AddedDscList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24AssociatedRecords), 6, 0));
         AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 6, 0));
         AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void E150G2( )
      {
         /* 'Associate selected' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ASSOCIATESELECTED' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20AddedKeyList", AV20AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22AddedDscList", AV22AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21NotAddedKeyList", AV21NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23NotAddedDscList", AV23NotAddedDscList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24AssociatedRecords), 6, 0));
         AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 6, 0));
         AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void E160G2( )
      {
         /* 'Associate All' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ASSOCIATEALL' */
         S172 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATEASSOCIATIONVARIABLES' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20AddedKeyList", AV20AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22AddedDscList", AV22AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21NotAddedKeyList", AV21NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23NotAddedDscList", AV23NotAddedDscList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24AssociatedRecords), 6, 0));
         AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 6, 0));
         AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void E170G2( )
      {
         /* 'Disassociate All' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ASSOCIATEALL' */
         S172 ();
         if (returnInSub) return;
         AV21NotAddedKeyList = (GxSimpleCollection<int>)(AV20AddedKeyList.Clone());
         AV23NotAddedDscList = (GxSimpleCollection<string>)(AV22AddedDscList.Clone());
         AV22AddedDscList.Clear();
         AV20AddedKeyList.Clear();
         /* Execute user subroutine: 'SAVELISTS' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'UPDATEASSOCIATIONVARIABLES' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21NotAddedKeyList", AV21NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23NotAddedDscList", AV23NotAddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22AddedDscList", AV22AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20AddedKeyList", AV20AddedKeyList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24AssociatedRecords), 6, 0));
         AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 6, 0));
         AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void E180G2( )
      {
         /* Associatedrecords_Dblclick Routine */
         returnInSub = false;
         /* Execute user subroutine: 'DISASSOCIATESELECTED' */
         S152 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21NotAddedKeyList", AV21NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23NotAddedDscList", AV23NotAddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20AddedKeyList", AV20AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22AddedDscList", AV22AddedDscList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24AssociatedRecords), 6, 0));
         AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 6, 0));
         AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void E190G2( )
      {
         /* Notassociatedrecords_Dblclick Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ASSOCIATESELECTED' */
         S162 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV20AddedKeyList", AV20AddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV22AddedDscList", AV22AddedDscList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV21NotAddedKeyList", AV21NotAddedKeyList);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri(sPrefix, false, "AV23NotAddedDscList", AV23NotAddedDscList);
         lstavAssociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV24AssociatedRecords), 6, 0));
         AssignProp(sPrefix, false, lstavAssociatedrecords_Internalname, "Values", lstavAssociatedrecords.ToJavascriptSource(), true);
         lstavNotassociatedrecords.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV25NotAssociatedRecords), 6, 0));
         AssignProp(sPrefix, false, lstavNotassociatedrecords_Internalname, "Values", lstavNotassociatedrecords.ToJavascriptSource(), true);
      }

      protected void S122( )
      {
         /* 'UPDATEASSOCIATIONVARIABLES' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTS' */
         S132 ();
         if (returnInSub) return;
         lstavAssociatedrecords.removeAllItems();
         lstavNotassociatedrecords.removeAllItems();
         AV14i = 1;
         AV36GXV3 = 1;
         while ( AV36GXV3 <= AV20AddedKeyList.Count )
         {
            AV8UsuAlmCod = (int)(AV20AddedKeyList.GetNumeric(AV36GXV3));
            AssignAttri(sPrefix, false, "AV8UsuAlmCod", StringUtil.LTrimStr( (decimal)(AV8UsuAlmCod), 6, 0));
            AV13Description = ((string)AV22AddedDscList.Item(AV14i));
            lstavAssociatedrecords.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV8UsuAlmCod), 6, 0)), StringUtil.Trim( AV13Description), 0);
            AV14i = (int)(AV14i+1);
            AV36GXV3 = (int)(AV36GXV3+1);
         }
         AV14i = 1;
         AV37GXV4 = 1;
         while ( AV37GXV4 <= AV21NotAddedKeyList.Count )
         {
            AV8UsuAlmCod = (int)(AV21NotAddedKeyList.GetNumeric(AV37GXV4));
            AssignAttri(sPrefix, false, "AV8UsuAlmCod", StringUtil.LTrimStr( (decimal)(AV8UsuAlmCod), 6, 0));
            AV13Description = ((string)AV23NotAddedDscList.Item(AV14i));
            lstavNotassociatedrecords.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV8UsuAlmCod), 6, 0)), StringUtil.Trim( AV13Description), 0);
            AV14i = (int)(AV14i+1);
            AV37GXV4 = (int)(AV37GXV4+1);
         }
      }

      protected void S142( )
      {
         /* 'SHOW ERROR MESSAGES' Routine */
         returnInSub = false;
         AV39GXV6 = 1;
         AV38GXV5 = AV11SGUSUARIOALMACEN.GetMessages();
         while ( AV39GXV6 <= AV38GXV5.Count )
         {
            AV15Message = ((GeneXus.Utils.SdtMessages_Message)AV38GXV5.Item(AV39GXV6));
            if ( AV15Message.gxTpr_Type == 1 )
            {
               GX_msglist.addItem(AV15Message.gxTpr_Description);
            }
            AV39GXV6 = (int)(AV39GXV6+1);
         }
      }

      protected void S132( )
      {
         /* 'LOADLISTS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16AddedKeyListXml)) )
         {
            AV22AddedDscList.FromXml(AV18AddedDscListXml, null, "Collection", "");
            AV20AddedKeyList.FromXml(AV16AddedKeyListXml, null, "Collection", "");
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV17NotAddedKeyListXml)) )
         {
            AV21NotAddedKeyList.FromXml(AV17NotAddedKeyListXml, null, "Collection", "");
            AV23NotAddedDscList.FromXml(AV19NotAddedDscListXml, null, "Collection", "");
         }
      }

      protected void S112( )
      {
         /* 'SAVELISTS' Routine */
         returnInSub = false;
         if ( AV20AddedKeyList.Count > 0 )
         {
            AV16AddedKeyListXml = AV20AddedKeyList.ToXml(false, true, "Collection", "");
            AssignAttri(sPrefix, false, "AV16AddedKeyListXml", AV16AddedKeyListXml);
            AV18AddedDscListXml = AV22AddedDscList.ToXml(false, true, "Collection", "");
            AssignAttri(sPrefix, false, "AV18AddedDscListXml", AV18AddedDscListXml);
         }
         else
         {
            AV16AddedKeyListXml = "";
            AssignAttri(sPrefix, false, "AV16AddedKeyListXml", AV16AddedKeyListXml);
            AV18AddedDscListXml = "";
            AssignAttri(sPrefix, false, "AV18AddedDscListXml", AV18AddedDscListXml);
         }
         if ( AV21NotAddedKeyList.Count > 0 )
         {
            AV17NotAddedKeyListXml = AV21NotAddedKeyList.ToXml(false, true, "Collection", "");
            AssignAttri(sPrefix, false, "AV17NotAddedKeyListXml", AV17NotAddedKeyListXml);
            AV19NotAddedDscListXml = AV23NotAddedDscList.ToXml(false, true, "Collection", "");
            AssignAttri(sPrefix, false, "AV19NotAddedDscListXml", AV19NotAddedDscListXml);
         }
         else
         {
            AV17NotAddedKeyListXml = "";
            AssignAttri(sPrefix, false, "AV17NotAddedKeyListXml", AV17NotAddedKeyListXml);
            AV19NotAddedDscListXml = "";
            AssignAttri(sPrefix, false, "AV19NotAddedDscListXml", AV19NotAddedDscListXml);
         }
      }

      protected void S172( )
      {
         /* 'ASSOCIATEALL' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTS' */
         S132 ();
         if (returnInSub) return;
         AV14i = 1;
         AV26InsertIndex = 1;
         AV40GXV7 = 1;
         while ( AV40GXV7 <= AV21NotAddedKeyList.Count )
         {
            AV8UsuAlmCod = (int)(AV21NotAddedKeyList.GetNumeric(AV40GXV7));
            AssignAttri(sPrefix, false, "AV8UsuAlmCod", StringUtil.LTrimStr( (decimal)(AV8UsuAlmCod), 6, 0));
            AV13Description = ((string)AV23NotAddedDscList.Item(AV14i));
            while ( ( AV26InsertIndex <= AV22AddedDscList.Count ) && ( StringUtil.StrCmp(((string)AV22AddedDscList.Item(AV26InsertIndex)), AV13Description) < 0 ) )
            {
               AV26InsertIndex = (int)(AV26InsertIndex+1);
            }
            AV20AddedKeyList.Add(AV8UsuAlmCod, AV26InsertIndex);
            AV22AddedDscList.Add(AV13Description, AV26InsertIndex);
            AV14i = (int)(AV14i+1);
            AV40GXV7 = (int)(AV40GXV7+1);
         }
         AV21NotAddedKeyList.Clear();
         AV23NotAddedDscList.Clear();
         /* Execute user subroutine: 'SAVELISTS' */
         S112 ();
         if (returnInSub) return;
      }

      protected void S162( )
      {
         /* 'ASSOCIATESELECTED' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTS' */
         S132 ();
         if (returnInSub) return;
         AV14i = 1;
         AV41GXV8 = 1;
         while ( AV41GXV8 <= AV21NotAddedKeyList.Count )
         {
            AV8UsuAlmCod = (int)(AV21NotAddedKeyList.GetNumeric(AV41GXV8));
            AssignAttri(sPrefix, false, "AV8UsuAlmCod", StringUtil.LTrimStr( (decimal)(AV8UsuAlmCod), 6, 0));
            if ( AV8UsuAlmCod == AV25NotAssociatedRecords )
            {
               if (true) break;
            }
            AV14i = (int)(AV14i+1);
            AV41GXV8 = (int)(AV41GXV8+1);
         }
         if ( AV14i <= AV21NotAddedKeyList.Count )
         {
            AV13Description = ((string)AV23NotAddedDscList.Item(AV14i));
            AV26InsertIndex = 1;
            while ( ( AV26InsertIndex <= AV22AddedDscList.Count ) && ( StringUtil.StrCmp(((string)AV22AddedDscList.Item(AV26InsertIndex)), AV13Description) < 0 ) )
            {
               AV26InsertIndex = (int)(AV26InsertIndex+1);
            }
            AV20AddedKeyList.Add(AV25NotAssociatedRecords, AV26InsertIndex);
            AV22AddedDscList.Add(AV13Description, AV26InsertIndex);
            AV21NotAddedKeyList.RemoveItem(AV14i);
            AV23NotAddedDscList.RemoveItem(AV14i);
            /* Execute user subroutine: 'SAVELISTS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'UPDATEASSOCIATIONVARIABLES' */
         S122 ();
         if (returnInSub) return;
      }

      protected void S152( )
      {
         /* 'DISASSOCIATESELECTED' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADLISTS' */
         S132 ();
         if (returnInSub) return;
         AV14i = 1;
         AV42GXV9 = 1;
         while ( AV42GXV9 <= AV20AddedKeyList.Count )
         {
            AV8UsuAlmCod = (int)(AV20AddedKeyList.GetNumeric(AV42GXV9));
            AssignAttri(sPrefix, false, "AV8UsuAlmCod", StringUtil.LTrimStr( (decimal)(AV8UsuAlmCod), 6, 0));
            if ( AV8UsuAlmCod == AV24AssociatedRecords )
            {
               if (true) break;
            }
            AV14i = (int)(AV14i+1);
            AV42GXV9 = (int)(AV42GXV9+1);
         }
         if ( AV14i <= AV20AddedKeyList.Count )
         {
            AV13Description = ((string)AV22AddedDscList.Item(AV14i));
            AV26InsertIndex = 1;
            while ( ( AV26InsertIndex <= AV23NotAddedDscList.Count ) && ( StringUtil.StrCmp(((string)AV23NotAddedDscList.Item(AV26InsertIndex)), AV13Description) < 0 ) )
            {
               AV26InsertIndex = (int)(AV26InsertIndex+1);
            }
            AV21NotAddedKeyList.Add(AV24AssociatedRecords, AV26InsertIndex);
            AV23NotAddedDscList.Add(AV13Description, AV26InsertIndex);
            AV20AddedKeyList.RemoveItem(AV14i);
            AV22AddedDscList.RemoveItem(AV14i);
            /* Execute user subroutine: 'SAVELISTS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'UPDATEASSOCIATIONVARIABLES' */
         S122 ();
         if (returnInSub) return;
      }

      protected void nextLoad( )
      {
      }

      protected void E200G2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7UsuCod = (string)getParm(obj,0);
         AssignAttri(sPrefix, false, "AV7UsuCod", AV7UsuCod);
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0G2( ) ;
         WS0G2( ) ;
         WE0G2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV7UsuCod = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0G2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "seguridad\\usuariosalmacen", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0G2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV7UsuCod = (string)getParm(obj,2);
            AssignAttri(sPrefix, false, "AV7UsuCod", AV7UsuCod);
         }
         wcpOAV7UsuCod = cgiGet( sPrefix+"wcpOAV7UsuCod");
         if ( ! GetJustCreated( ) && ( ( StringUtil.StrCmp(AV7UsuCod, wcpOAV7UsuCod) != 0 ) ) )
         {
            setjustcreated();
         }
         wcpOAV7UsuCod = AV7UsuCod;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV7UsuCod = cgiGet( sPrefix+"AV7UsuCod_CTRL");
         if ( StringUtil.Len( sCtrlAV7UsuCod) > 0 )
         {
            AV7UsuCod = cgiGet( sCtrlAV7UsuCod);
            AssignAttri(sPrefix, false, "AV7UsuCod", AV7UsuCod);
         }
         else
         {
            AV7UsuCod = cgiGet( sPrefix+"AV7UsuCod_PARM");
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0G2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0G2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0G2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV7UsuCod_PARM", StringUtil.RTrim( AV7UsuCod));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV7UsuCod)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV7UsuCod_CTRL", StringUtil.RTrim( sCtrlAV7UsuCod));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0G2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181615027", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("seguridad/usuariosalmacen.js", "?20228181615027", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         lstavNotassociatedrecords.Name = "vNOTASSOCIATEDRECORDS";
         lstavNotassociatedrecords.WebTags = "";
         if ( lstavNotassociatedrecords.ItemCount > 0 )
         {
         }
         lstavAssociatedrecords.Name = "vASSOCIATEDRECORDS";
         lstavAssociatedrecords.WebTags = "";
         if ( lstavAssociatedrecords.ItemCount > 0 )
         {
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblTxtcontacmsj_Internalname = sPrefix+"TXTCONTACMSJ";
         divTablamensaje_Internalname = sPrefix+"TABLAMENSAJE";
         lblNotassociatedrecordstitle_Internalname = sPrefix+"NOTASSOCIATEDRECORDSTITLE";
         lstavNotassociatedrecords_Internalname = sPrefix+"vNOTASSOCIATEDRECORDS";
         divTablenotassociated_Internalname = sPrefix+"TABLENOTASSOCIATED";
         imgImageassociateall_Internalname = sPrefix+"IMAGEASSOCIATEALL";
         imgImageassociateselected_Internalname = sPrefix+"IMAGEASSOCIATESELECTED";
         imgImagedisassociateselected_Internalname = sPrefix+"IMAGEDISASSOCIATESELECTED";
         imgImagedisassociateall_Internalname = sPrefix+"IMAGEDISASSOCIATEALL";
         divUnnamedtableassociationbuttons_Internalname = sPrefix+"UNNAMEDTABLEASSOCIATIONBUTTONS";
         lblAssociatedrecordstitle_Internalname = sPrefix+"ASSOCIATEDRECORDSTITLE";
         lstavAssociatedrecords_Internalname = sPrefix+"vASSOCIATEDRECORDS";
         divTableassociated_Internalname = sPrefix+"TABLEASSOCIATED";
         divTablacontenido_Internalname = sPrefix+"TABLACONTENIDO";
         bttBtnconfirm_Internalname = sPrefix+"BTNCONFIRM";
         bttBtncancel_Internalname = sPrefix+"BTNCANCEL";
         divTablemain_Internalname = sPrefix+"TABLEMAIN";
         divLayoutmaintable_Internalname = sPrefix+"LAYOUTMAINTABLE";
         Form.Internalname = sPrefix+"FORM";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("WorkWithPlusTheme");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         init_default_properties( ) ;
         lstavAssociatedrecords_Jsonclick = "";
         lstavAssociatedrecords.Enabled = 1;
         lstavNotassociatedrecords_Jsonclick = "";
         lstavNotassociatedrecords.Enabled = 1;
         divTablacontenido_Visible = 1;
         divTablamensaje_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lstavAssociatedrecords'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'lstavNotassociatedrecords'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''}]}");
         setEventMetadata("ENTER","{handler:'E130G2',iparms:[{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'A348UsuCod',fld:'USUCOD',pic:''},{av:'AV7UsuCod',fld:'vUSUCOD',pic:''},{av:'A349UsuAlmCod',fld:'USUALMCOD',pic:'ZZZZZ9'},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{av:'AV11SGUSUARIOALMACEN',fld:'vSGUSUARIOALMACEN',pic:''},{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV11SGUSUARIOALMACEN',fld:'vSGUSUARIOALMACEN',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''}]}");
         setEventMetadata("'DISASSOCIATE SELECTED'","{handler:'E140G2',iparms:[{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'lstavAssociatedrecords'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]");
         setEventMetadata("'DISASSOCIATE SELECTED'",",oparms:[{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{av:'lstavAssociatedrecords'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'lstavNotassociatedrecords'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'}]}");
         setEventMetadata("'ASSOCIATE SELECTED'","{handler:'E150G2',iparms:[{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'lstavNotassociatedrecords'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]");
         setEventMetadata("'ASSOCIATE SELECTED'",",oparms:[{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{av:'lstavAssociatedrecords'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'lstavNotassociatedrecords'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'}]}");
         setEventMetadata("'ASSOCIATE ALL'","{handler:'E160G2',iparms:[{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]");
         setEventMetadata("'ASSOCIATE ALL'",",oparms:[{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'lstavAssociatedrecords'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'lstavNotassociatedrecords'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]}");
         setEventMetadata("'DISASSOCIATE ALL'","{handler:'E170G2',iparms:[{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]");
         setEventMetadata("'DISASSOCIATE ALL'",",oparms:[{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{av:'lstavAssociatedrecords'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'lstavNotassociatedrecords'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'}]}");
         setEventMetadata("VASSOCIATEDRECORDS.DBLCLICK","{handler:'E180G2',iparms:[{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'lstavAssociatedrecords'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]");
         setEventMetadata("VASSOCIATEDRECORDS.DBLCLICK",",oparms:[{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{av:'lstavAssociatedrecords'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'lstavNotassociatedrecords'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'}]}");
         setEventMetadata("VNOTASSOCIATEDRECORDS.DBLCLICK","{handler:'E190G2',iparms:[{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'lstavNotassociatedrecords'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''}]");
         setEventMetadata("VNOTASSOCIATEDRECORDS.DBLCLICK",",oparms:[{av:'AV8UsuAlmCod',fld:'vUSUALMCOD',pic:'ZZZZZ9'},{av:'AV20AddedKeyList',fld:'vADDEDKEYLIST',pic:''},{av:'AV22AddedDscList',fld:'vADDEDDSCLIST',pic:''},{av:'AV21NotAddedKeyList',fld:'vNOTADDEDKEYLIST',pic:''},{av:'AV23NotAddedDscList',fld:'vNOTADDEDDSCLIST',pic:''},{av:'AV16AddedKeyListXml',fld:'vADDEDKEYLISTXML',pic:''},{av:'AV18AddedDscListXml',fld:'vADDEDDSCLISTXML',pic:''},{av:'AV17NotAddedKeyListXml',fld:'vNOTADDEDKEYLISTXML',pic:''},{av:'AV19NotAddedDscListXml',fld:'vNOTADDEDDSCLISTXML',pic:''},{av:'lstavAssociatedrecords'},{av:'AV24AssociatedRecords',fld:'vASSOCIATEDRECORDS',pic:'ZZZZZ9'},{av:'lstavNotassociatedrecords'},{av:'AV25NotAssociatedRecords',fld:'vNOTASSOCIATEDRECORDS',pic:'ZZZZZ9'}]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         wcpOAV7UsuCod = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sPrefix = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV20AddedKeyList = new GxSimpleCollection<int>();
         AV22AddedDscList = new GxSimpleCollection<string>();
         AV21NotAddedKeyList = new GxSimpleCollection<int>();
         AV23NotAddedDscList = new GxSimpleCollection<string>();
         AV16AddedKeyListXml = "";
         AV18AddedDscListXml = "";
         AV17NotAddedKeyListXml = "";
         AV19NotAddedDscListXml = "";
         A348UsuCod = "";
         AV11SGUSUARIOALMACEN = new SdtSGUSUARIOALMACEN(context);
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         lblTxtcontacmsj_Jsonclick = "";
         lblNotassociatedrecordstitle_Jsonclick = "";
         TempTags = "";
         sImgUrl = "";
         imgImageassociateall_Jsonclick = "";
         imgImageassociateselected_Jsonclick = "";
         imgImagedisassociateselected_Jsonclick = "";
         imgImagedisassociateall_Jsonclick = "";
         lblAssociatedrecordstitle_Jsonclick = "";
         bttBtnconfirm_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9HTTPRequest = new GxHttpRequest( context);
         scmdbuf = "";
         H000G2_A348UsuCod = new string[] {""} ;
         H000G3_A63AlmCod = new int[1] ;
         H000G3_A436AlmDsc = new string[] {""} ;
         A436AlmDsc = "";
         H000G4_A349UsuAlmCod = new int[1] ;
         H000G4_A348UsuCod = new string[] {""} ;
         AV13Description = "";
         H000G5_A349UsuAlmCod = new int[1] ;
         H000G5_A348UsuCod = new string[] {""} ;
         H000G6_A349UsuAlmCod = new int[1] ;
         H000G6_A348UsuCod = new string[] {""} ;
         AV38GXV5 = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV15Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV7UsuCod = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.seguridad.usuariosalmacen__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.usuariosalmacen__default(),
            new Object[][] {
                new Object[] {
               H000G2_A348UsuCod
               }
               , new Object[] {
               H000G3_A63AlmCod, H000G3_A436AlmDsc
               }
               , new Object[] {
               H000G4_A349UsuAlmCod, H000G4_A348UsuCod
               }
               , new Object[] {
               H000G5_A349UsuAlmCod, H000G5_A348UsuCod
               }
               , new Object[] {
               H000G6_A349UsuAlmCod, H000G6_A348UsuCod
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_7 ;
      private short nIsMod_7 ;
      private short nRcdExists_6 ;
      private short nIsMod_6 ;
      private short nRcdExists_4 ;
      private short nIsMod_4 ;
      private short nRcdExists_5 ;
      private short nIsMod_5 ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short AV29GXLvl8 ;
      private short nGXWrapped ;
      private int A349UsuAlmCod ;
      private int AV8UsuAlmCod ;
      private int divTablamensaje_Visible ;
      private int divTablacontenido_Visible ;
      private int AV25NotAssociatedRecords ;
      private int AV24AssociatedRecords ;
      private int A63AlmCod ;
      private int AV14i ;
      private int AV32GXV1 ;
      private int AV34GXV2 ;
      private int AV36GXV3 ;
      private int AV37GXV4 ;
      private int AV39GXV6 ;
      private int AV26InsertIndex ;
      private int AV40GXV7 ;
      private int AV41GXV8 ;
      private int AV42GXV9 ;
      private int idxLst ;
      private string AV7UsuCod ;
      private string wcpOAV7UsuCod ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string A348UsuCod ;
      private string GX_FocusControl ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablamensaje_Internalname ;
      private string lblTxtcontacmsj_Internalname ;
      private string lblTxtcontacmsj_Jsonclick ;
      private string divTablacontenido_Internalname ;
      private string divTablenotassociated_Internalname ;
      private string lblNotassociatedrecordstitle_Internalname ;
      private string lblNotassociatedrecordstitle_Jsonclick ;
      private string lstavNotassociatedrecords_Internalname ;
      private string TempTags ;
      private string lstavNotassociatedrecords_Jsonclick ;
      private string divUnnamedtableassociationbuttons_Internalname ;
      private string sImgUrl ;
      private string imgImageassociateall_Internalname ;
      private string imgImageassociateall_Jsonclick ;
      private string imgImageassociateselected_Internalname ;
      private string imgImageassociateselected_Jsonclick ;
      private string imgImagedisassociateselected_Internalname ;
      private string imgImagedisassociateselected_Jsonclick ;
      private string imgImagedisassociateall_Internalname ;
      private string imgImagedisassociateall_Jsonclick ;
      private string divTableassociated_Internalname ;
      private string lblAssociatedrecordstitle_Internalname ;
      private string lblAssociatedrecordstitle_Jsonclick ;
      private string lstavAssociatedrecords_Internalname ;
      private string lstavAssociatedrecords_Jsonclick ;
      private string bttBtnconfirm_Internalname ;
      private string bttBtnconfirm_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private string A436AlmDsc ;
      private string sCtrlAV7UsuCod ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV10Exist ;
      private bool AV12Success ;
      private string AV16AddedKeyListXml ;
      private string AV18AddedDscListXml ;
      private string AV17NotAddedKeyListXml ;
      private string AV19NotAddedDscListXml ;
      private string AV13Description ;
      private GxSimpleCollection<int> AV20AddedKeyList ;
      private GxSimpleCollection<int> AV21NotAddedKeyList ;
      private GXWebForm Form ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXListbox lstavNotassociatedrecords ;
      private GXListbox lstavAssociatedrecords ;
      private IDataStoreProvider pr_default ;
      private string[] H000G2_A348UsuCod ;
      private int[] H000G3_A63AlmCod ;
      private string[] H000G3_A436AlmDsc ;
      private int[] H000G4_A349UsuAlmCod ;
      private string[] H000G4_A348UsuCod ;
      private int[] H000G5_A349UsuAlmCod ;
      private string[] H000G5_A348UsuCod ;
      private int[] H000G6_A349UsuAlmCod ;
      private string[] H000G6_A348UsuCod ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_datastore2 ;
      private GxHttpRequest AV9HTTPRequest ;
      private GxSimpleCollection<string> AV22AddedDscList ;
      private GxSimpleCollection<string> AV23NotAddedDscList ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV38GXV5 ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private SdtSGUSUARIOALMACEN AV11SGUSUARIOALMACEN ;
      private GeneXus.Utils.SdtMessages_Message AV15Message ;
   }

   public class usuariosalmacen__datastore2 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE2";
    }

 }

 public class usuariosalmacen__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmH000G2;
        prmH000G2 = new Object[] {
        new ParDef("@AV7UsuCod",GXType.NChar,10,0)
        };
        Object[] prmH000G3;
        prmH000G3 = new Object[] {
        };
        Object[] prmH000G4;
        prmH000G4 = new Object[] {
        new ParDef("@AV7UsuCod",GXType.NChar,10,0) ,
        new ParDef("@AV8UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmH000G5;
        prmH000G5 = new Object[] {
        new ParDef("@AV7UsuCod",GXType.NChar,10,0) ,
        new ParDef("@AV8UsuAlmCod",GXType.Int32,6,0)
        };
        Object[] prmH000G6;
        prmH000G6 = new Object[] {
        new ParDef("@AV7UsuCod",GXType.NChar,10,0) ,
        new ParDef("@AV8UsuAlmCod",GXType.Int32,6,0)
        };
        def= new CursorDef[] {
            new CursorDef("H000G2", "SELECT [UsuCod] FROM [SGUSUARIOS] WHERE [UsuCod] = @AV7UsuCod ORDER BY [UsuCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G2,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H000G3", "SELECT [AlmCod], [AlmDsc] FROM [CALMACEN] ORDER BY [AlmDsc] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G3,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("H000G4", "SELECT [UsuAlmCod], [UsuCod] FROM [SGUSUARIOALMACEN] WHERE [UsuCod] = @AV7UsuCod and [UsuAlmCod] = @AV8UsuAlmCod ORDER BY [UsuCod], [UsuAlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G4,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H000G5", "SELECT [UsuAlmCod], [UsuCod] FROM [SGUSUARIOALMACEN] WHERE [UsuCod] = @AV7UsuCod and [UsuAlmCod] = @AV8UsuAlmCod ORDER BY [UsuCod], [UsuAlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G5,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("H000G6", "SELECT [UsuAlmCod], [UsuCod] FROM [SGUSUARIOALMACEN] WHERE [UsuCod] = @AV7UsuCod and [UsuAlmCod] = @AV8UsuAlmCod ORDER BY [UsuCod], [UsuAlmCod] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000G6,1, GxCacheFrequency.OFF ,false,true )
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
     switch ( cursor )
     {
           case 0 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
     }
  }

}

}
