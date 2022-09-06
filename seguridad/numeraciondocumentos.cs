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
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.seguridad {
   public class numeraciondocumentos : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
         GXKey = Crypto.GetSiteKey( );
         if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "seguridad.numeraciondocumentos.aspx")), "seguridad.numeraciondocumentos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "seguridad.numeraciondocumentos.aspx")))) ;
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
         if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7CorDoc = GetPar( "CorDoc");
                  AssignAttri("", false, "AV7CorDoc", AV7CorDoc);
                  GxWebStd.gx_hidden_field( context, "gxhash_vCORDOC", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7CorDoc, "")), context));
                  AV8CorSerie = GetPar( "CorSerie");
                  AssignAttri("", false, "AV8CorSerie", AV8CorSerie);
                  GxWebStd.gx_hidden_field( context, "gxhash_vCORSERIE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8CorSerie, "")), context));
               }
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 17_0_9-159740", 0) ;
            }
            Form.Meta.addItem("description", "Numeracion Documentos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbCorDoc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public numeraciondocumentos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public numeraciondocumentos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_CorDoc ,
                           string aP2_CorSerie )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CorDoc = aP1_CorDoc;
         this.AV8CorSerie = aP2_CorSerie;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbCorDoc = new GXCombobox();
         chkCorFE = new GXCheckbox();
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
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

      protected void fix_multi_value_controls( )
      {
         if ( cmbCorDoc.ItemCount > 0 )
         {
            A339CorDoc = cmbCorDoc.getValidValue(A339CorDoc);
            AssignAttri("", false, "A339CorDoc", A339CorDoc);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCorDoc.CurrentValue = StringUtil.RTrim( A339CorDoc);
            AssignProp("", false, cmbCorDoc_Internalname, "Values", cmbCorDoc.ToJavascriptSource(), true);
         }
         A756CorFE = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A756CorFE), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A756CorFE", StringUtil.Str( (decimal)(A756CorFE), 1, 0));
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-9", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "TableContent", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "left", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "TableData", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbCorDoc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCorDoc_Internalname, "Documento", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCorDoc, cmbCorDoc_Internalname, StringUtil.RTrim( A339CorDoc), 1, cmbCorDoc_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbCorDoc.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 1, "HLP_Seguridad\\NumeracionDocumentos.htm");
         cmbCorDoc.CurrentValue = StringUtil.RTrim( A339CorDoc);
         AssignProp("", false, cmbCorDoc_Internalname, "Values", (string)(cmbCorDoc.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCorSerie_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCorSerie_Internalname, "Serie", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCorSerie_Internalname, StringUtil.RTrim( A340CorSerie), StringUtil.RTrim( context.localUtil.Format( A340CorSerie, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCorSerie_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorSerie_Enabled, 1, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\NumeracionDocumentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtNumDoc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNumDoc_Internalname, "Numero", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNumDoc_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1377NumDoc), 10, 0, ".", "")), StringUtil.LTrim( ((edtNumDoc_Enabled!=0) ? context.localUtil.Format( (decimal)(A1377NumDoc), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A1377NumDoc), "ZZZZZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNumDoc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtNumDoc_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\NumeracionDocumentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkCorFE_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkCorFE_Internalname, "Electronica", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkCorFE_Internalname, StringUtil.Str( (decimal)(A756CorFE), 1, 0), "", "Electronica", 1, chkCorFE.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(37, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,37);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCorFormato_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCorFormato_Internalname, "Formato", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCorFormato_Internalname, A757CorFormato, StringUtil.RTrim( context.localUtil.Format( A757CorFormato, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCorFormato_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCorFormato_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\NumeracionDocumentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         context.WriteHtmlText( "</div>") ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group TrnActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\NumeracionDocumentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\NumeracionDocumentos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\NumeracionDocumentos.htm");
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

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110J2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z339CorDoc = cgiGet( "Z339CorDoc");
               Z340CorSerie = cgiGet( "Z340CorSerie");
               Z1377NumDoc = (long)(context.localUtil.CToN( cgiGet( "Z1377NumDoc"), ".", ","));
               Z756CorFE = (short)(context.localUtil.CToN( cgiGet( "Z756CorFE"), ".", ","));
               Z757CorFormato = cgiGet( "Z757CorFormato");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7CorDoc = cgiGet( "vCORDOC");
               AV8CorSerie = cgiGet( "vCORSERIE");
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ".", ","));
               /* Read variables values. */
               cmbCorDoc.CurrentValue = cgiGet( cmbCorDoc_Internalname);
               A339CorDoc = cgiGet( cmbCorDoc_Internalname);
               AssignAttri("", false, "A339CorDoc", A339CorDoc);
               A340CorSerie = cgiGet( edtCorSerie_Internalname);
               AssignAttri("", false, "A340CorSerie", A340CorSerie);
               if ( ( ( context.localUtil.CToN( cgiGet( edtNumDoc_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNumDoc_Internalname), ".", ",") > Convert.ToDecimal( 9999999999L )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NUMDOC");
                  AnyError = 1;
                  GX_FocusControl = edtNumDoc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1377NumDoc = 0;
                  AssignAttri("", false, "A1377NumDoc", StringUtil.LTrimStr( (decimal)(A1377NumDoc), 10, 0));
               }
               else
               {
                  A1377NumDoc = (long)(context.localUtil.CToN( cgiGet( edtNumDoc_Internalname), ".", ","));
                  AssignAttri("", false, "A1377NumDoc", StringUtil.LTrimStr( (decimal)(A1377NumDoc), 10, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkCorFE_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkCorFE_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CORFE");
                  AnyError = 1;
                  GX_FocusControl = chkCorFE_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A756CorFE = 0;
                  AssignAttri("", false, "A756CorFE", StringUtil.Str( (decimal)(A756CorFE), 1, 0));
               }
               else
               {
                  A756CorFE = (short)(((StringUtil.StrCmp(cgiGet( chkCorFE_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A756CorFE", StringUtil.Str( (decimal)(A756CorFE), 1, 0));
               }
               A757CorFormato = cgiGet( edtCorFormato_Internalname);
               AssignAttri("", false, "A757CorFormato", A757CorFormato);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"NumeracionDocumentos");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A339CorDoc, Z339CorDoc) != 0 ) || ( StringUtil.StrCmp(A340CorSerie, Z340CorSerie) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("seguridad\\numeraciondocumentos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A339CorDoc = GetPar( "CorDoc");
                  AssignAttri("", false, "A339CorDoc", A339CorDoc);
                  A340CorSerie = GetPar( "CorSerie");
                  AssignAttri("", false, "A340CorSerie", A340CorSerie);
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode20 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode20;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound20 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0J0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CORDOC");
                        AnyError = 1;
                        GX_FocusControl = cmbCorDoc_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120J2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E120J2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0J20( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtntrn_delete_Visible = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtntrn_delete_Visible = 0;
            AssignProp("", false, bttBtntrn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0J20( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_0J0( )
      {
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0J20( ) ;
            }
            else
            {
               CheckExtendedTable0J20( ) ;
               CloseExtendedTableCursors0J20( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0J0( )
      {
      }

      protected void E110J2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV10TrnContext.FromXml(AV11WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E120J2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV10TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("seguridad.numeraciondocumentosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0J20( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1377NumDoc = T000J3_A1377NumDoc[0];
               Z756CorFE = T000J3_A756CorFE[0];
               Z757CorFormato = T000J3_A757CorFormato[0];
            }
            else
            {
               Z1377NumDoc = A1377NumDoc;
               Z756CorFE = A756CorFE;
               Z757CorFormato = A757CorFormato;
            }
         }
         if ( GX_JID == -9 )
         {
            Z339CorDoc = A339CorDoc;
            Z340CorSerie = A340CorSerie;
            Z1377NumDoc = A1377NumDoc;
            Z756CorFE = A756CorFE;
            Z757CorFormato = A757CorFormato;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7CorDoc)) )
         {
            A339CorDoc = AV7CorDoc;
            AssignAttri("", false, "A339CorDoc", A339CorDoc);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7CorDoc)) )
         {
            cmbCorDoc.Enabled = 0;
            AssignProp("", false, cmbCorDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCorDoc.Enabled), 5, 0), true);
         }
         else
         {
            cmbCorDoc.Enabled = 1;
            AssignProp("", false, cmbCorDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCorDoc.Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7CorDoc)) )
         {
            cmbCorDoc.Enabled = 0;
            AssignProp("", false, cmbCorDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCorDoc.Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CorSerie)) )
         {
            A340CorSerie = AV8CorSerie;
            AssignAttri("", false, "A340CorSerie", A340CorSerie);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CorSerie)) )
         {
            edtCorSerie_Enabled = 0;
            AssignProp("", false, edtCorSerie_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorSerie_Enabled), 5, 0), true);
         }
         else
         {
            edtCorSerie_Enabled = 1;
            AssignProp("", false, edtCorSerie_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorSerie_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8CorSerie)) )
         {
            edtCorSerie_Enabled = 0;
            AssignProp("", false, edtCorSerie_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorSerie_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0J20( )
      {
         /* Using cursor T000J4 */
         pr_default.execute(2, new Object[] {A339CorDoc, A340CorSerie});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound20 = 1;
            A1377NumDoc = T000J4_A1377NumDoc[0];
            AssignAttri("", false, "A1377NumDoc", StringUtil.LTrimStr( (decimal)(A1377NumDoc), 10, 0));
            A756CorFE = T000J4_A756CorFE[0];
            AssignAttri("", false, "A756CorFE", StringUtil.Str( (decimal)(A756CorFE), 1, 0));
            A757CorFormato = T000J4_A757CorFormato[0];
            AssignAttri("", false, "A757CorFormato", A757CorFormato);
            ZM0J20( -9) ;
         }
         pr_default.close(2);
         OnLoadActions0J20( ) ;
      }

      protected void OnLoadActions0J20( )
      {
      }

      protected void CheckExtendedTable0J20( )
      {
         nIsDirty_20 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A339CorDoc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Documento", "", "", "", "", "", "", "", ""), 1, "CORDOC");
            AnyError = 1;
            GX_FocusControl = cmbCorDoc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A340CorSerie)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Serie", "", "", "", "", "", "", "", ""), 1, "CORSERIE");
            AnyError = 1;
            GX_FocusControl = edtCorSerie_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0J20( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0J20( )
      {
         /* Using cursor T000J5 */
         pr_default.execute(3, new Object[] {A339CorDoc, A340CorSerie});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000J3 */
         pr_default.execute(1, new Object[] {A339CorDoc, A340CorSerie});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0J20( 9) ;
            RcdFound20 = 1;
            A339CorDoc = T000J3_A339CorDoc[0];
            AssignAttri("", false, "A339CorDoc", A339CorDoc);
            A340CorSerie = T000J3_A340CorSerie[0];
            AssignAttri("", false, "A340CorSerie", A340CorSerie);
            A1377NumDoc = T000J3_A1377NumDoc[0];
            AssignAttri("", false, "A1377NumDoc", StringUtil.LTrimStr( (decimal)(A1377NumDoc), 10, 0));
            A756CorFE = T000J3_A756CorFE[0];
            AssignAttri("", false, "A756CorFE", StringUtil.Str( (decimal)(A756CorFE), 1, 0));
            A757CorFormato = T000J3_A757CorFormato[0];
            AssignAttri("", false, "A757CorFormato", A757CorFormato);
            Z339CorDoc = A339CorDoc;
            Z340CorSerie = A340CorSerie;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0J20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0J20( ) ;
            }
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0J20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0J20( ) ;
         if ( RcdFound20 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound20 = 0;
         /* Using cursor T000J6 */
         pr_default.execute(4, new Object[] {A339CorDoc, A340CorSerie});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000J6_A339CorDoc[0], A339CorDoc) < 0 ) || ( StringUtil.StrCmp(T000J6_A339CorDoc[0], A339CorDoc) == 0 ) && ( StringUtil.StrCmp(T000J6_A340CorSerie[0], A340CorSerie) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000J6_A339CorDoc[0], A339CorDoc) > 0 ) || ( StringUtil.StrCmp(T000J6_A339CorDoc[0], A339CorDoc) == 0 ) && ( StringUtil.StrCmp(T000J6_A340CorSerie[0], A340CorSerie) > 0 ) ) )
            {
               A339CorDoc = T000J6_A339CorDoc[0];
               AssignAttri("", false, "A339CorDoc", A339CorDoc);
               A340CorSerie = T000J6_A340CorSerie[0];
               AssignAttri("", false, "A340CorSerie", A340CorSerie);
               RcdFound20 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound20 = 0;
         /* Using cursor T000J7 */
         pr_default.execute(5, new Object[] {A339CorDoc, A340CorSerie});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000J7_A339CorDoc[0], A339CorDoc) > 0 ) || ( StringUtil.StrCmp(T000J7_A339CorDoc[0], A339CorDoc) == 0 ) && ( StringUtil.StrCmp(T000J7_A340CorSerie[0], A340CorSerie) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000J7_A339CorDoc[0], A339CorDoc) < 0 ) || ( StringUtil.StrCmp(T000J7_A339CorDoc[0], A339CorDoc) == 0 ) && ( StringUtil.StrCmp(T000J7_A340CorSerie[0], A340CorSerie) < 0 ) ) )
            {
               A339CorDoc = T000J7_A339CorDoc[0];
               AssignAttri("", false, "A339CorDoc", A339CorDoc);
               A340CorSerie = T000J7_A340CorSerie[0];
               AssignAttri("", false, "A340CorSerie", A340CorSerie);
               RcdFound20 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0J20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbCorDoc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0J20( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( ( StringUtil.StrCmp(A339CorDoc, Z339CorDoc) != 0 ) || ( StringUtil.StrCmp(A340CorSerie, Z340CorSerie) != 0 ) )
               {
                  A339CorDoc = Z339CorDoc;
                  AssignAttri("", false, "A339CorDoc", A339CorDoc);
                  A340CorSerie = Z340CorSerie;
                  AssignAttri("", false, "A340CorSerie", A340CorSerie);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CORDOC");
                  AnyError = 1;
                  GX_FocusControl = cmbCorDoc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbCorDoc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0J20( ) ;
                  GX_FocusControl = cmbCorDoc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( StringUtil.StrCmp(A339CorDoc, Z339CorDoc) != 0 ) || ( StringUtil.StrCmp(A340CorSerie, Z340CorSerie) != 0 ) )
               {
                  /* Insert record */
                  GX_FocusControl = cmbCorDoc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0J20( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CORDOC");
                     AnyError = 1;
                     GX_FocusControl = cmbCorDoc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbCorDoc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0J20( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( ( StringUtil.StrCmp(A339CorDoc, Z339CorDoc) != 0 ) || ( StringUtil.StrCmp(A340CorSerie, Z340CorSerie) != 0 ) )
         {
            A339CorDoc = Z339CorDoc;
            AssignAttri("", false, "A339CorDoc", A339CorDoc);
            A340CorSerie = Z340CorSerie;
            AssignAttri("", false, "A340CorSerie", A340CorSerie);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CORDOC");
            AnyError = 1;
            GX_FocusControl = cmbCorDoc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbCorDoc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0J20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000J2 */
            pr_default.execute(0, new Object[] {A339CorDoc, A340CorSerie});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGCDOCUMENTOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z1377NumDoc != T000J2_A1377NumDoc[0] ) || ( Z756CorFE != T000J2_A756CorFE[0] ) || ( StringUtil.StrCmp(Z757CorFormato, T000J2_A757CorFormato[0]) != 0 ) )
            {
               if ( Z1377NumDoc != T000J2_A1377NumDoc[0] )
               {
                  GXUtil.WriteLog("seguridad.numeraciondocumentos:[seudo value changed for attri]"+"NumDoc");
                  GXUtil.WriteLogRaw("Old: ",Z1377NumDoc);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A1377NumDoc[0]);
               }
               if ( Z756CorFE != T000J2_A756CorFE[0] )
               {
                  GXUtil.WriteLog("seguridad.numeraciondocumentos:[seudo value changed for attri]"+"CorFE");
                  GXUtil.WriteLogRaw("Old: ",Z756CorFE);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A756CorFE[0]);
               }
               if ( StringUtil.StrCmp(Z757CorFormato, T000J2_A757CorFormato[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.numeraciondocumentos:[seudo value changed for attri]"+"CorFormato");
                  GXUtil.WriteLogRaw("Old: ",Z757CorFormato);
                  GXUtil.WriteLogRaw("Current: ",T000J2_A757CorFormato[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGCDOCUMENTOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0J20( )
      {
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0J20( 0) ;
            CheckOptimisticConcurrency0J20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0J20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J8 */
                     pr_default.execute(6, new Object[] {A339CorDoc, A340CorSerie, A1377NumDoc, A756CorFE, A757CorFormato});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("SGCDOCUMENTOS");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0J0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0J20( ) ;
            }
            EndLevel0J20( ) ;
         }
         CloseExtendedTableCursors0J20( ) ;
      }

      protected void Update0J20( )
      {
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0J20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0J20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000J9 */
                     pr_default.execute(7, new Object[] {A1377NumDoc, A756CorFE, A757CorFormato, A339CorDoc, A340CorSerie});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("SGCDOCUMENTOS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGCDOCUMENTOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0J20( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0J20( ) ;
         }
         CloseExtendedTableCursors0J20( ) ;
      }

      protected void DeferredUpdate0J20( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0J20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0J20( ) ;
            AfterConfirm0J20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0J20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000J10 */
                  pr_default.execute(8, new Object[] {A339CorDoc, A340CorSerie});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("SGCDOCUMENTOS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0J20( ) ;
         Gx_mode = sMode20;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0J20( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0J20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0J20( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("seguridad.numeraciondocumentos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0J0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("seguridad.numeraciondocumentos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0J20( )
      {
         /* Scan By routine */
         /* Using cursor T000J11 */
         pr_default.execute(9);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound20 = 1;
            A339CorDoc = T000J11_A339CorDoc[0];
            AssignAttri("", false, "A339CorDoc", A339CorDoc);
            A340CorSerie = T000J11_A340CorSerie[0];
            AssignAttri("", false, "A340CorSerie", A340CorSerie);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0J20( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound20 = 1;
            A339CorDoc = T000J11_A339CorDoc[0];
            AssignAttri("", false, "A339CorDoc", A339CorDoc);
            A340CorSerie = T000J11_A340CorSerie[0];
            AssignAttri("", false, "A340CorSerie", A340CorSerie);
         }
      }

      protected void ScanEnd0J20( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0J20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0J20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0J20( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0J20( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0J20( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0J20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0J20( )
      {
         cmbCorDoc.Enabled = 0;
         AssignProp("", false, cmbCorDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCorDoc.Enabled), 5, 0), true);
         edtCorSerie_Enabled = 0;
         AssignProp("", false, edtCorSerie_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorSerie_Enabled), 5, 0), true);
         edtNumDoc_Enabled = 0;
         AssignProp("", false, edtNumDoc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNumDoc_Enabled), 5, 0), true);
         chkCorFE.Enabled = 0;
         AssignProp("", false, chkCorFE_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkCorFE.Enabled), 5, 0), true);
         edtCorFormato_Enabled = 0;
         AssignProp("", false, edtCorFormato_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCorFormato_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0J20( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0J0( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
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
         MasterPageObj.master_styles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 194480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 194480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?202281811441842", false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.numeraciondocumentos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7CorDoc)) + "," + UrlEncode(StringUtil.RTrim(AV8CorSerie));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seguridad.numeraciondocumentos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Crypto.GetSiteKey( );
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"NumeracionDocumentos");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("seguridad\\numeraciondocumentos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z339CorDoc", StringUtil.RTrim( Z339CorDoc));
         GxWebStd.gx_hidden_field( context, "Z340CorSerie", StringUtil.RTrim( Z340CorSerie));
         GxWebStd.gx_hidden_field( context, "Z1377NumDoc", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1377NumDoc), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z756CorFE", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z756CorFE), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z757CorFormato", Z757CorFormato);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV10TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV10TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV10TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vCORDOC", StringUtil.RTrim( AV7CorDoc));
         GxWebStd.gx_hidden_field( context, "gxhash_vCORDOC", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7CorDoc, "")), context));
         GxWebStd.gx_hidden_field( context, "vCORSERIE", StringUtil.RTrim( AV8CorSerie));
         GxWebStd.gx_hidden_field( context, "gxhash_vCORSERIE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8CorSerie, "")), context));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Crypto.GetSiteKey( );
         GXEncryptionTmp = "seguridad.numeraciondocumentos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7CorDoc)) + "," + UrlEncode(StringUtil.RTrim(AV8CorSerie));
         return formatLink("seguridad.numeraciondocumentos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Seguridad.NumeracionDocumentos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Numeracion Documentos" ;
      }

      protected void InitializeNonKey0J20( )
      {
         A1377NumDoc = 0;
         AssignAttri("", false, "A1377NumDoc", StringUtil.LTrimStr( (decimal)(A1377NumDoc), 10, 0));
         A756CorFE = 0;
         AssignAttri("", false, "A756CorFE", StringUtil.Str( (decimal)(A756CorFE), 1, 0));
         A757CorFormato = "";
         AssignAttri("", false, "A757CorFormato", A757CorFormato);
         Z1377NumDoc = 0;
         Z756CorFE = 0;
         Z757CorFormato = "";
      }

      protected void InitAll0J20( )
      {
         A339CorDoc = "";
         AssignAttri("", false, "A339CorDoc", A339CorDoc);
         A340CorSerie = "";
         AssignAttri("", false, "A340CorSerie", A340CorSerie);
         InitializeNonKey0J20( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811441857", true, true);
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
         context.AddJavascriptSource("messages.spa.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("seguridad/numeraciondocumentos.js", "?202281811441857", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         cmbCorDoc_Internalname = "CORDOC";
         edtCorSerie_Internalname = "CORSERIE";
         edtNumDoc_Internalname = "NUMDOC";
         chkCorFE_Internalname = "CORFE";
         edtCorFormato_Internalname = "CORFORMATO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Numeracion Documentos";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCorFormato_Jsonclick = "";
         edtCorFormato_Enabled = 1;
         chkCorFE.Enabled = 1;
         edtNumDoc_Jsonclick = "";
         edtNumDoc_Enabled = 1;
         edtCorSerie_Jsonclick = "";
         edtCorSerie_Enabled = 1;
         cmbCorDoc_Jsonclick = "";
         cmbCorDoc.Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Información General";
         Dvpanel_tableattributes_Cls = "PanelFilled Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         divLayoutmaintable_Class = "Table";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         cmbCorDoc.Name = "CORDOC";
         cmbCorDoc.WebTags = "";
         cmbCorDoc.addItem("FACTURA", "FACTURA", 0);
         cmbCorDoc.addItem("NOTCREDITO", "NOTA DE CREDITO", 0);
         cmbCorDoc.addItem("NOTDEBITO", "NOTA DE DEBITO", 0);
         cmbCorDoc.addItem("BOLETA", "BOLETA", 0);
         cmbCorDoc.addItem("REMISION", "REMISION", 0);
         cmbCorDoc.addItem("LETRA", "LETRA DE CAMBIO", 0);
         cmbCorDoc.addItem("PERCEPCION", "PERCEPCION", 0);
         cmbCorDoc.addItem("RECIBO", "RECIBO", 0);
         cmbCorDoc.addItem("ENTRADA", "ENTRADA", 0);
         cmbCorDoc.addItem("SALIDA", "SALIDA", 0);
         cmbCorDoc.addItem("ORDENCOMPR", "ORDEN DE COMPRA", 0);
         cmbCorDoc.addItem("RETENCION", "RETENCION", 0);
         cmbCorDoc.addItem("TICKET", "TICKET", 0);
         if ( cmbCorDoc.ItemCount > 0 )
         {
            A339CorDoc = cmbCorDoc.getValidValue(A339CorDoc);
            AssignAttri("", false, "A339CorDoc", A339CorDoc);
         }
         chkCorFE.Name = "CORFE";
         chkCorFE.WebTags = "";
         chkCorFE.Caption = "";
         AssignProp("", false, chkCorFE_Internalname, "TitleCaption", chkCorFE.Caption, true);
         chkCorFE.CheckedValue = "0";
         A756CorFE = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A756CorFE), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A756CorFE", StringUtil.Str( (decimal)(A756CorFE), 1, 0));
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CorDoc',fld:'vCORDOC',pic:'',hsh:true},{av:'AV8CorSerie',fld:'vCORSERIE',pic:'',hsh:true},{av:'A756CorFE',fld:'CORFE',pic:'9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A756CorFE',fld:'CORFE',pic:'9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CorDoc',fld:'vCORDOC',pic:'',hsh:true},{av:'AV8CorSerie',fld:'vCORSERIE',pic:'',hsh:true},{av:'A756CorFE',fld:'CORFE',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A756CorFE',fld:'CORFE',pic:'9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E120J2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A756CorFE',fld:'CORFE',pic:'9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A756CorFE',fld:'CORFE',pic:'9'}]}");
         setEventMetadata("VALID_CORDOC","{handler:'Valid_Cordoc',iparms:[{av:'A756CorFE',fld:'CORFE',pic:'9'}]");
         setEventMetadata("VALID_CORDOC",",oparms:[{av:'A756CorFE',fld:'CORFE',pic:'9'}]}");
         setEventMetadata("VALID_CORSERIE","{handler:'Valid_Corserie',iparms:[{av:'A756CorFE',fld:'CORFE',pic:'9'}]");
         setEventMetadata("VALID_CORSERIE",",oparms:[{av:'A756CorFE',fld:'CORFE',pic:'9'}]}");
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
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7CorDoc = "";
         wcpOAV8CorSerie = "";
         Z339CorDoc = "";
         Z340CorSerie = "";
         Z757CorFormato = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A339CorDoc = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A340CorSerie = "";
         A757CorFormato = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode20 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV10TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV11WebSession = context.GetSession();
         T000J4_A339CorDoc = new string[] {""} ;
         T000J4_A340CorSerie = new string[] {""} ;
         T000J4_A1377NumDoc = new long[1] ;
         T000J4_A756CorFE = new short[1] ;
         T000J4_A757CorFormato = new string[] {""} ;
         T000J5_A339CorDoc = new string[] {""} ;
         T000J5_A340CorSerie = new string[] {""} ;
         T000J3_A339CorDoc = new string[] {""} ;
         T000J3_A340CorSerie = new string[] {""} ;
         T000J3_A1377NumDoc = new long[1] ;
         T000J3_A756CorFE = new short[1] ;
         T000J3_A757CorFormato = new string[] {""} ;
         T000J6_A339CorDoc = new string[] {""} ;
         T000J6_A340CorSerie = new string[] {""} ;
         T000J7_A339CorDoc = new string[] {""} ;
         T000J7_A340CorSerie = new string[] {""} ;
         T000J2_A339CorDoc = new string[] {""} ;
         T000J2_A340CorSerie = new string[] {""} ;
         T000J2_A1377NumDoc = new long[1] ;
         T000J2_A756CorFE = new short[1] ;
         T000J2_A757CorFormato = new string[] {""} ;
         T000J11_A339CorDoc = new string[] {""} ;
         T000J11_A340CorSerie = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.seguridad.numeraciondocumentos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.numeraciondocumentos__default(),
            new Object[][] {
                new Object[] {
               T000J2_A339CorDoc, T000J2_A340CorSerie, T000J2_A1377NumDoc, T000J2_A756CorFE, T000J2_A757CorFormato
               }
               , new Object[] {
               T000J3_A339CorDoc, T000J3_A340CorSerie, T000J3_A1377NumDoc, T000J3_A756CorFE, T000J3_A757CorFormato
               }
               , new Object[] {
               T000J4_A339CorDoc, T000J4_A340CorSerie, T000J4_A1377NumDoc, T000J4_A756CorFE, T000J4_A757CorFormato
               }
               , new Object[] {
               T000J5_A339CorDoc, T000J5_A340CorSerie
               }
               , new Object[] {
               T000J6_A339CorDoc, T000J6_A340CorSerie
               }
               , new Object[] {
               T000J7_A339CorDoc, T000J7_A340CorSerie
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000J11_A339CorDoc, T000J11_A340CorSerie
               }
            }
         );
      }

      private short Z756CorFE ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A756CorFE ;
      private short RcdFound20 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_20 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtCorSerie_Enabled ;
      private int edtNumDoc_Enabled ;
      private int edtCorFormato_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long Z1377NumDoc ;
      private long A1377NumDoc ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV7CorDoc ;
      private string wcpOAV8CorSerie ;
      private string Z339CorDoc ;
      private string Z340CorSerie ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV7CorDoc ;
      private string AV8CorSerie ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbCorDoc_Internalname ;
      private string A339CorDoc ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string cmbCorDoc_Jsonclick ;
      private string edtCorSerie_Internalname ;
      private string A340CorSerie ;
      private string edtCorSerie_Jsonclick ;
      private string edtNumDoc_Internalname ;
      private string edtNumDoc_Jsonclick ;
      private string chkCorFE_Internalname ;
      private string edtCorFormato_Internalname ;
      private string edtCorFormato_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode20 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private string Z757CorFormato ;
      private string A757CorFormato ;
      private IGxSession AV11WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCorDoc ;
      private GXCheckbox chkCorFE ;
      private IDataStoreProvider pr_default ;
      private string[] T000J4_A339CorDoc ;
      private string[] T000J4_A340CorSerie ;
      private long[] T000J4_A1377NumDoc ;
      private short[] T000J4_A756CorFE ;
      private string[] T000J4_A757CorFormato ;
      private string[] T000J5_A339CorDoc ;
      private string[] T000J5_A340CorSerie ;
      private string[] T000J3_A339CorDoc ;
      private string[] T000J3_A340CorSerie ;
      private long[] T000J3_A1377NumDoc ;
      private short[] T000J3_A756CorFE ;
      private string[] T000J3_A757CorFormato ;
      private string[] T000J6_A339CorDoc ;
      private string[] T000J6_A340CorSerie ;
      private string[] T000J7_A339CorDoc ;
      private string[] T000J7_A340CorSerie ;
      private string[] T000J2_A339CorDoc ;
      private string[] T000J2_A340CorSerie ;
      private long[] T000J2_A1377NumDoc ;
      private short[] T000J2_A756CorFE ;
      private string[] T000J2_A757CorFormato ;
      private string[] T000J11_A339CorDoc ;
      private string[] T000J11_A340CorSerie ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV10TrnContext ;
   }

   public class numeraciondocumentos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class numeraciondocumentos__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000J4;
        prmT000J4 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000J5;
        prmT000J5 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000J3;
        prmT000J3 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000J6;
        prmT000J6 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000J7;
        prmT000J7 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000J2;
        prmT000J2 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000J8;
        prmT000J8 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0) ,
        new ParDef("@NumDoc",GXType.Decimal,10,0) ,
        new ParDef("@CorFE",GXType.Int16,1,0) ,
        new ParDef("@CorFormato",GXType.NVarChar,50,0)
        };
        Object[] prmT000J9;
        prmT000J9 = new Object[] {
        new ParDef("@NumDoc",GXType.Decimal,10,0) ,
        new ParDef("@CorFE",GXType.Int16,1,0) ,
        new ParDef("@CorFormato",GXType.NVarChar,50,0) ,
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000J10;
        prmT000J10 = new Object[] {
        new ParDef("@CorDoc",GXType.NChar,10,0) ,
        new ParDef("@CorSerie",GXType.NChar,4,0)
        };
        Object[] prmT000J11;
        prmT000J11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000J2", "SELECT [CorDoc], [CorSerie], [NumDoc], [CorFE], [CorFormato] FROM [SGCDOCUMENTOS] WITH (UPDLOCK) WHERE [CorDoc] = @CorDoc AND [CorSerie] = @CorSerie ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J3", "SELECT [CorDoc], [CorSerie], [NumDoc], [CorFE], [CorFormato] FROM [SGCDOCUMENTOS] WHERE [CorDoc] = @CorDoc AND [CorSerie] = @CorSerie ",true, GxErrorMask.GX_NOMASK, false, this,prmT000J3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J4", "SELECT TM1.[CorDoc], TM1.[CorSerie], TM1.[NumDoc], TM1.[CorFE], TM1.[CorFormato] FROM [SGCDOCUMENTOS] TM1 WHERE TM1.[CorDoc] = @CorDoc and TM1.[CorSerie] = @CorSerie ORDER BY TM1.[CorDoc], TM1.[CorSerie]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J5", "SELECT [CorDoc], [CorSerie] FROM [SGCDOCUMENTOS] WHERE [CorDoc] = @CorDoc AND [CorSerie] = @CorSerie  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000J6", "SELECT TOP 1 [CorDoc], [CorSerie] FROM [SGCDOCUMENTOS] WHERE ( [CorDoc] > @CorDoc or [CorDoc] = @CorDoc and [CorSerie] > @CorSerie) ORDER BY [CorDoc], [CorSerie]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J7", "SELECT TOP 1 [CorDoc], [CorSerie] FROM [SGCDOCUMENTOS] WHERE ( [CorDoc] < @CorDoc or [CorDoc] = @CorDoc and [CorSerie] < @CorSerie) ORDER BY [CorDoc] DESC, [CorSerie] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000J8", "INSERT INTO [SGCDOCUMENTOS]([CorDoc], [CorSerie], [NumDoc], [CorFE], [CorFormato]) VALUES(@CorDoc, @CorSerie, @NumDoc, @CorFE, @CorFormato)", GxErrorMask.GX_NOMASK,prmT000J8)
           ,new CursorDef("T000J9", "UPDATE [SGCDOCUMENTOS] SET [NumDoc]=@NumDoc, [CorFE]=@CorFE, [CorFormato]=@CorFormato  WHERE [CorDoc] = @CorDoc AND [CorSerie] = @CorSerie", GxErrorMask.GX_NOMASK,prmT000J9)
           ,new CursorDef("T000J10", "DELETE FROM [SGCDOCUMENTOS]  WHERE [CorDoc] = @CorDoc AND [CorSerie] = @CorSerie", GxErrorMask.GX_NOMASK,prmT000J10)
           ,new CursorDef("T000J11", "SELECT [CorDoc], [CorSerie] FROM [SGCDOCUMENTOS] ORDER BY [CorDoc], [CorSerie]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000J11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 4);
              return;
     }
  }

}

}
