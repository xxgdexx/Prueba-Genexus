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
namespace GeneXus.Programs.configuracion {
   public class tipodocumento : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.tipodocumento.aspx")), "configuracion.tipodocumento.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.tipodocumento.aspx")))) ;
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
                  AV7TipCod = GetPar( "TipCod");
                  AssignAttri("", false, "AV7TipCod", AV7TipCod);
                  GxWebStd.gx_hidden_field( context, "gxhash_vTIPCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7TipCod, "")), context));
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
            Form.Meta.addItem("description", "Tipo Documento", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tipodocumento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipodocumento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_TipCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TipCod = aP1_TipCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkTipCxP = new GXCheckbox();
         chkTipBan = new GXCheckbox();
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
         A1909TipCxP = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1909TipCxP), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1909TipCxP", StringUtil.Str( (decimal)(A1909TipCxP), 1, 0));
         A1903TipBan = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1903TipBan), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1903TipBan", StringUtil.Str( (decimal)(A1903TipBan), 1, 0));
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCod_Internalname, StringUtil.RTrim( A149TipCod), StringUtil.RTrim( context.localUtil.Format( A149TipCod, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipCod_Enabled, 1, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoDocumento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipDsc_Internalname, "Tipo de Documento", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipDsc_Internalname, StringUtil.RTrim( A1910TipDsc), StringUtil.RTrim( context.localUtil.Format( A1910TipDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtTipDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoDocumento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipAbr_Internalname, "Codigo Sunat", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipAbr_Internalname, StringUtil.RTrim( A306TipAbr), StringUtil.RTrim( context.localUtil.Format( A306TipAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoDocumento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipSigno_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipSigno_Internalname, "Signo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipSigno_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A511TipSigno), 2, 0, ".", "")), StringUtil.LTrim( ((edtTipSigno_Enabled!=0) ? context.localUtil.Format( (decimal)(A511TipSigno), "Z9") : context.localUtil.Format( (decimal)(A511TipSigno), "Z9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipSigno_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipSigno_Enabled, 0, "text", "1", 2, "chr", 1, "row", 2, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\TipoDocumento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipVta_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipVta_Internalname, "Afecta Registro de Ventas", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipVta_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1921TipVta), 1, 0, ".", "")), StringUtil.LTrim( ((edtTipVta_Enabled!=0) ? context.localUtil.Format( (decimal)(A1921TipVta), "9") : context.localUtil.Format( (decimal)(A1921TipVta), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipVta_Jsonclick, 0, "AttributeCheckBox", "", "", "", "", 1, edtTipVta_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\TipoDocumento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipCmp_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipCmp_Internalname, "Afecta Registro de Compras", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipCmp_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1906TipCmp), 1, 0, ".", "")), StringUtil.LTrim( ((edtTipCmp_Enabled!=0) ? context.localUtil.Format( (decimal)(A1906TipCmp), "9") : context.localUtil.Format( (decimal)(A1906TipCmp), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipCmp_Jsonclick, 0, "AttributeCheckBox", "", "", "", "", 1, edtTipCmp_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\TipoDocumento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipRHo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipRHo_Internalname, "Afecta Honorarios", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipRHo_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1915TipRHo), 1, 0, ".", "")), StringUtil.LTrim( ((edtTipRHo_Enabled!=0) ? context.localUtil.Format( (decimal)(A1915TipRHo), "9") : context.localUtil.Format( (decimal)(A1915TipRHo), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipRHo_Jsonclick, 0, "AttributeCheckBox", "", "", "", "", 1, edtTipRHo_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\TipoDocumento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkTipCxP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTipCxP_Internalname, "Afecta Cuenta por Pagar", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTipCxP_Internalname, StringUtil.Str( (decimal)(A1909TipCxP), 1, 0), "", "Afecta Cuenta por Pagar", 1, chkTipCxP.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(57, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,57);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkTipBan_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkTipBan_Internalname, "Afecta Bancos", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkTipBan_Internalname, StringUtil.Str( (decimal)(A1903TipBan), 1, 0), "", "Afecta Bancos", 1, chkTipBan.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(62, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,62);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1919TipSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtTipSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1919TipSts), "9") : context.localUtil.Format( (decimal)(A1919TipSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,67);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\TipoDocumento.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoDocumento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoDocumento.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoDocumento.htm");
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
         E11602 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z149TipCod = cgiGet( "Z149TipCod");
               Z1910TipDsc = cgiGet( "Z1910TipDsc");
               Z306TipAbr = cgiGet( "Z306TipAbr");
               Z511TipSigno = (short)(context.localUtil.CToN( cgiGet( "Z511TipSigno"), ".", ","));
               Z1919TipSts = (short)(context.localUtil.CToN( cgiGet( "Z1919TipSts"), ".", ","));
               Z1921TipVta = (short)(context.localUtil.CToN( cgiGet( "Z1921TipVta"), ".", ","));
               Z1906TipCmp = (short)(context.localUtil.CToN( cgiGet( "Z1906TipCmp"), ".", ","));
               Z1915TipRHo = (short)(context.localUtil.CToN( cgiGet( "Z1915TipRHo"), ".", ","));
               Z1909TipCxP = (short)(context.localUtil.CToN( cgiGet( "Z1909TipCxP"), ".", ","));
               Z1903TipBan = (short)(context.localUtil.CToN( cgiGet( "Z1903TipBan"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7TipCod = cgiGet( "vTIPCOD");
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
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
               A149TipCod = cgiGet( edtTipCod_Internalname);
               AssignAttri("", false, "A149TipCod", A149TipCod);
               A1910TipDsc = cgiGet( edtTipDsc_Internalname);
               AssignAttri("", false, "A1910TipDsc", A1910TipDsc);
               A306TipAbr = cgiGet( edtTipAbr_Internalname);
               AssignAttri("", false, "A306TipAbr", A306TipAbr);
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipSigno_Internalname), ".", ",") < Convert.ToDecimal( -9 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipSigno_Internalname), ".", ",") > Convert.ToDecimal( 99 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPSIGNO");
                  AnyError = 1;
                  GX_FocusControl = edtTipSigno_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A511TipSigno = 0;
                  AssignAttri("", false, "A511TipSigno", StringUtil.LTrimStr( (decimal)(A511TipSigno), 2, 0));
               }
               else
               {
                  A511TipSigno = (short)(context.localUtil.CToN( cgiGet( edtTipSigno_Internalname), ".", ","));
                  AssignAttri("", false, "A511TipSigno", StringUtil.LTrimStr( (decimal)(A511TipSigno), 2, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipVta_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipVta_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPVTA");
                  AnyError = 1;
                  GX_FocusControl = edtTipVta_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1921TipVta = 0;
                  AssignAttri("", false, "A1921TipVta", StringUtil.Str( (decimal)(A1921TipVta), 1, 0));
               }
               else
               {
                  A1921TipVta = (short)(context.localUtil.CToN( cgiGet( edtTipVta_Internalname), ".", ","));
                  AssignAttri("", false, "A1921TipVta", StringUtil.Str( (decimal)(A1921TipVta), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipCmp_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipCmp_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPCMP");
                  AnyError = 1;
                  GX_FocusControl = edtTipCmp_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1906TipCmp = 0;
                  AssignAttri("", false, "A1906TipCmp", StringUtil.Str( (decimal)(A1906TipCmp), 1, 0));
               }
               else
               {
                  A1906TipCmp = (short)(context.localUtil.CToN( cgiGet( edtTipCmp_Internalname), ".", ","));
                  AssignAttri("", false, "A1906TipCmp", StringUtil.Str( (decimal)(A1906TipCmp), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipRHo_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipRHo_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPRHO");
                  AnyError = 1;
                  GX_FocusControl = edtTipRHo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1915TipRHo = 0;
                  AssignAttri("", false, "A1915TipRHo", StringUtil.Str( (decimal)(A1915TipRHo), 1, 0));
               }
               else
               {
                  A1915TipRHo = (short)(context.localUtil.CToN( cgiGet( edtTipRHo_Internalname), ".", ","));
                  AssignAttri("", false, "A1915TipRHo", StringUtil.Str( (decimal)(A1915TipRHo), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkTipCxP_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkTipCxP_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPCXP");
                  AnyError = 1;
                  GX_FocusControl = chkTipCxP_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1909TipCxP = 0;
                  AssignAttri("", false, "A1909TipCxP", StringUtil.Str( (decimal)(A1909TipCxP), 1, 0));
               }
               else
               {
                  A1909TipCxP = (short)(((StringUtil.StrCmp(cgiGet( chkTipCxP_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A1909TipCxP", StringUtil.Str( (decimal)(A1909TipCxP), 1, 0));
               }
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkTipBan_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkTipBan_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPBAN");
                  AnyError = 1;
                  GX_FocusControl = chkTipBan_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1903TipBan = 0;
                  AssignAttri("", false, "A1903TipBan", StringUtil.Str( (decimal)(A1903TipBan), 1, 0));
               }
               else
               {
                  A1903TipBan = (short)(((StringUtil.StrCmp(cgiGet( chkTipBan_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A1903TipBan", StringUtil.Str( (decimal)(A1903TipBan), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPSTS");
                  AnyError = 1;
                  GX_FocusControl = edtTipSts_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1919TipSts = 0;
                  AssignAttri("", false, "A1919TipSts", StringUtil.Str( (decimal)(A1919TipSts), 1, 0));
               }
               else
               {
                  A1919TipSts = (short)(context.localUtil.CToN( cgiGet( edtTipSts_Internalname), ".", ","));
                  AssignAttri("", false, "A1919TipSts", StringUtil.Str( (decimal)(A1919TipSts), 1, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TipoDocumento");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\tipodocumento:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A149TipCod = GetPar( "TipCod");
                  AssignAttri("", false, "A149TipCod", A149TipCod);
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
                     sMode129 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode129;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound129 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_600( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TIPCOD");
                        AnyError = 1;
                        GX_FocusControl = edtTipCod_Internalname;
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
                           E11602 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12602 ();
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
            E12602 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll60129( ) ;
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
            DisableAttributes60129( ) ;
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

      protected void CONFIRM_600( )
      {
         BeforeValidate60129( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls60129( ) ;
            }
            else
            {
               CheckExtendedTable60129( ) ;
               CloseExtendedTableCursors60129( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption600( )
      {
      }

      protected void E11602( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E12602( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV13SGAuDocGls = "Tipo de Documento N° " + StringUtil.Trim( A149TipCod) + " " + StringUtil.Trim( A1910TipDsc);
            AV14Codigo = A149TipCod;
            GXt_char1 = "CNF";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV13SGAuDocGls, ref  AV14Codigo, ref  AV14Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.tipodocumentoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM60129( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1910TipDsc = T00603_A1910TipDsc[0];
               Z306TipAbr = T00603_A306TipAbr[0];
               Z511TipSigno = T00603_A511TipSigno[0];
               Z1919TipSts = T00603_A1919TipSts[0];
               Z1921TipVta = T00603_A1921TipVta[0];
               Z1906TipCmp = T00603_A1906TipCmp[0];
               Z1915TipRHo = T00603_A1915TipRHo[0];
               Z1909TipCxP = T00603_A1909TipCxP[0];
               Z1903TipBan = T00603_A1903TipBan[0];
            }
            else
            {
               Z1910TipDsc = A1910TipDsc;
               Z306TipAbr = A306TipAbr;
               Z511TipSigno = A511TipSigno;
               Z1919TipSts = A1919TipSts;
               Z1921TipVta = A1921TipVta;
               Z1906TipCmp = A1906TipCmp;
               Z1915TipRHo = A1915TipRHo;
               Z1909TipCxP = A1909TipCxP;
               Z1903TipBan = A1903TipBan;
            }
         }
         if ( GX_JID == -8 )
         {
            Z149TipCod = A149TipCod;
            Z1910TipDsc = A1910TipDsc;
            Z306TipAbr = A306TipAbr;
            Z511TipSigno = A511TipSigno;
            Z1919TipSts = A1919TipSts;
            Z1921TipVta = A1921TipVta;
            Z1906TipCmp = A1906TipCmp;
            Z1915TipRHo = A1915TipRHo;
            Z1909TipCxP = A1909TipCxP;
            Z1903TipBan = A1903TipBan;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7TipCod)) )
         {
            A149TipCod = AV7TipCod;
            AssignAttri("", false, "A149TipCod", A149TipCod);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7TipCod)) )
         {
            edtTipCod_Enabled = 0;
            AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), true);
         }
         else
         {
            edtTipCod_Enabled = 1;
            AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7TipCod)) )
         {
            edtTipCod_Enabled = 0;
            AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A1919TipSts) && ( Gx_BScreen == 0 ) )
         {
            A1919TipSts = 1;
            AssignAttri("", false, "A1919TipSts", StringUtil.Str( (decimal)(A1919TipSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load60129( )
      {
         /* Using cursor T00604 */
         pr_default.execute(2, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound129 = 1;
            A1910TipDsc = T00604_A1910TipDsc[0];
            AssignAttri("", false, "A1910TipDsc", A1910TipDsc);
            A306TipAbr = T00604_A306TipAbr[0];
            AssignAttri("", false, "A306TipAbr", A306TipAbr);
            A511TipSigno = T00604_A511TipSigno[0];
            AssignAttri("", false, "A511TipSigno", StringUtil.LTrimStr( (decimal)(A511TipSigno), 2, 0));
            A1919TipSts = T00604_A1919TipSts[0];
            AssignAttri("", false, "A1919TipSts", StringUtil.Str( (decimal)(A1919TipSts), 1, 0));
            A1921TipVta = T00604_A1921TipVta[0];
            AssignAttri("", false, "A1921TipVta", StringUtil.Str( (decimal)(A1921TipVta), 1, 0));
            A1906TipCmp = T00604_A1906TipCmp[0];
            AssignAttri("", false, "A1906TipCmp", StringUtil.Str( (decimal)(A1906TipCmp), 1, 0));
            A1915TipRHo = T00604_A1915TipRHo[0];
            AssignAttri("", false, "A1915TipRHo", StringUtil.Str( (decimal)(A1915TipRHo), 1, 0));
            A1909TipCxP = T00604_A1909TipCxP[0];
            AssignAttri("", false, "A1909TipCxP", StringUtil.Str( (decimal)(A1909TipCxP), 1, 0));
            A1903TipBan = T00604_A1903TipBan[0];
            AssignAttri("", false, "A1903TipBan", StringUtil.Str( (decimal)(A1903TipBan), 1, 0));
            ZM60129( -8) ;
         }
         pr_default.close(2);
         OnLoadActions60129( ) ;
      }

      protected void OnLoadActions60129( )
      {
      }

      protected void CheckExtendedTable60129( )
      {
         nIsDirty_129 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A149TipCod)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Codigo T. Documento", "", "", "", "", "", "", "", ""), 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1910TipDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Tipo de Documento", "", "", "", "", "", "", "", ""), 1, "TIPDSC");
            AnyError = 1;
            GX_FocusControl = edtTipDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A306TipAbr)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "T/D", "", "", "", "", "", "", "", ""), 1, "TIPABR");
            AnyError = 1;
            GX_FocusControl = edtTipAbr_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors60129( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey60129( )
      {
         /* Using cursor T00605 */
         pr_default.execute(3, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound129 = 1;
         }
         else
         {
            RcdFound129 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00603 */
         pr_default.execute(1, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM60129( 8) ;
            RcdFound129 = 1;
            A149TipCod = T00603_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
            A1910TipDsc = T00603_A1910TipDsc[0];
            AssignAttri("", false, "A1910TipDsc", A1910TipDsc);
            A306TipAbr = T00603_A306TipAbr[0];
            AssignAttri("", false, "A306TipAbr", A306TipAbr);
            A511TipSigno = T00603_A511TipSigno[0];
            AssignAttri("", false, "A511TipSigno", StringUtil.LTrimStr( (decimal)(A511TipSigno), 2, 0));
            A1919TipSts = T00603_A1919TipSts[0];
            AssignAttri("", false, "A1919TipSts", StringUtil.Str( (decimal)(A1919TipSts), 1, 0));
            A1921TipVta = T00603_A1921TipVta[0];
            AssignAttri("", false, "A1921TipVta", StringUtil.Str( (decimal)(A1921TipVta), 1, 0));
            A1906TipCmp = T00603_A1906TipCmp[0];
            AssignAttri("", false, "A1906TipCmp", StringUtil.Str( (decimal)(A1906TipCmp), 1, 0));
            A1915TipRHo = T00603_A1915TipRHo[0];
            AssignAttri("", false, "A1915TipRHo", StringUtil.Str( (decimal)(A1915TipRHo), 1, 0));
            A1909TipCxP = T00603_A1909TipCxP[0];
            AssignAttri("", false, "A1909TipCxP", StringUtil.Str( (decimal)(A1909TipCxP), 1, 0));
            A1903TipBan = T00603_A1903TipBan[0];
            AssignAttri("", false, "A1903TipBan", StringUtil.Str( (decimal)(A1903TipBan), 1, 0));
            Z149TipCod = A149TipCod;
            sMode129 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load60129( ) ;
            if ( AnyError == 1 )
            {
               RcdFound129 = 0;
               InitializeNonKey60129( ) ;
            }
            Gx_mode = sMode129;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound129 = 0;
            InitializeNonKey60129( ) ;
            sMode129 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode129;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey60129( ) ;
         if ( RcdFound129 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound129 = 0;
         /* Using cursor T00606 */
         pr_default.execute(4, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00606_A149TipCod[0], A149TipCod) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00606_A149TipCod[0], A149TipCod) > 0 ) ) )
            {
               A149TipCod = T00606_A149TipCod[0];
               AssignAttri("", false, "A149TipCod", A149TipCod);
               RcdFound129 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound129 = 0;
         /* Using cursor T00607 */
         pr_default.execute(5, new Object[] {A149TipCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00607_A149TipCod[0], A149TipCod) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00607_A149TipCod[0], A149TipCod) < 0 ) ) )
            {
               A149TipCod = T00607_A149TipCod[0];
               AssignAttri("", false, "A149TipCod", A149TipCod);
               RcdFound129 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey60129( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert60129( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound129 == 1 )
            {
               if ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 )
               {
                  A149TipCod = Z149TipCod;
                  AssignAttri("", false, "A149TipCod", A149TipCod);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update60129( ) ;
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtTipCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert60129( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTipCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert60129( ) ;
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
         if ( StringUtil.StrCmp(A149TipCod, Z149TipCod) != 0 )
         {
            A149TipCod = Z149TipCod;
            AssignAttri("", false, "A149TipCod", A149TipCod);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPCOD");
            AnyError = 1;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency60129( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00602 */
            pr_default.execute(0, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPDOC"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1910TipDsc, T00602_A1910TipDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z306TipAbr, T00602_A306TipAbr[0]) != 0 ) || ( Z511TipSigno != T00602_A511TipSigno[0] ) || ( Z1919TipSts != T00602_A1919TipSts[0] ) || ( Z1921TipVta != T00602_A1921TipVta[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z1906TipCmp != T00602_A1906TipCmp[0] ) || ( Z1915TipRHo != T00602_A1915TipRHo[0] ) || ( Z1909TipCxP != T00602_A1909TipCxP[0] ) || ( Z1903TipBan != T00602_A1903TipBan[0] ) )
            {
               if ( StringUtil.StrCmp(Z1910TipDsc, T00602_A1910TipDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.tipodocumento:[seudo value changed for attri]"+"TipDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1910TipDsc);
                  GXUtil.WriteLogRaw("Current: ",T00602_A1910TipDsc[0]);
               }
               if ( StringUtil.StrCmp(Z306TipAbr, T00602_A306TipAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.tipodocumento:[seudo value changed for attri]"+"TipAbr");
                  GXUtil.WriteLogRaw("Old: ",Z306TipAbr);
                  GXUtil.WriteLogRaw("Current: ",T00602_A306TipAbr[0]);
               }
               if ( Z511TipSigno != T00602_A511TipSigno[0] )
               {
                  GXUtil.WriteLog("configuracion.tipodocumento:[seudo value changed for attri]"+"TipSigno");
                  GXUtil.WriteLogRaw("Old: ",Z511TipSigno);
                  GXUtil.WriteLogRaw("Current: ",T00602_A511TipSigno[0]);
               }
               if ( Z1919TipSts != T00602_A1919TipSts[0] )
               {
                  GXUtil.WriteLog("configuracion.tipodocumento:[seudo value changed for attri]"+"TipSts");
                  GXUtil.WriteLogRaw("Old: ",Z1919TipSts);
                  GXUtil.WriteLogRaw("Current: ",T00602_A1919TipSts[0]);
               }
               if ( Z1921TipVta != T00602_A1921TipVta[0] )
               {
                  GXUtil.WriteLog("configuracion.tipodocumento:[seudo value changed for attri]"+"TipVta");
                  GXUtil.WriteLogRaw("Old: ",Z1921TipVta);
                  GXUtil.WriteLogRaw("Current: ",T00602_A1921TipVta[0]);
               }
               if ( Z1906TipCmp != T00602_A1906TipCmp[0] )
               {
                  GXUtil.WriteLog("configuracion.tipodocumento:[seudo value changed for attri]"+"TipCmp");
                  GXUtil.WriteLogRaw("Old: ",Z1906TipCmp);
                  GXUtil.WriteLogRaw("Current: ",T00602_A1906TipCmp[0]);
               }
               if ( Z1915TipRHo != T00602_A1915TipRHo[0] )
               {
                  GXUtil.WriteLog("configuracion.tipodocumento:[seudo value changed for attri]"+"TipRHo");
                  GXUtil.WriteLogRaw("Old: ",Z1915TipRHo);
                  GXUtil.WriteLogRaw("Current: ",T00602_A1915TipRHo[0]);
               }
               if ( Z1909TipCxP != T00602_A1909TipCxP[0] )
               {
                  GXUtil.WriteLog("configuracion.tipodocumento:[seudo value changed for attri]"+"TipCxP");
                  GXUtil.WriteLogRaw("Old: ",Z1909TipCxP);
                  GXUtil.WriteLogRaw("Current: ",T00602_A1909TipCxP[0]);
               }
               if ( Z1903TipBan != T00602_A1903TipBan[0] )
               {
                  GXUtil.WriteLog("configuracion.tipodocumento:[seudo value changed for attri]"+"TipBan");
                  GXUtil.WriteLogRaw("Old: ",Z1903TipBan);
                  GXUtil.WriteLogRaw("Current: ",T00602_A1903TipBan[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CTIPDOC"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert60129( )
      {
         BeforeValidate60129( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable60129( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM60129( 0) ;
            CheckOptimisticConcurrency60129( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm60129( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert60129( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00608 */
                     pr_default.execute(6, new Object[] {A149TipCod, A1910TipDsc, A306TipAbr, A511TipSigno, A1919TipSts, A1921TipVta, A1906TipCmp, A1915TipRHo, A1909TipCxP, A1903TipBan});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPDOC");
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
                           ResetCaption600( ) ;
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
               Load60129( ) ;
            }
            EndLevel60129( ) ;
         }
         CloseExtendedTableCursors60129( ) ;
      }

      protected void Update60129( )
      {
         BeforeValidate60129( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable60129( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency60129( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm60129( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate60129( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00609 */
                     pr_default.execute(7, new Object[] {A1910TipDsc, A306TipAbr, A511TipSigno, A1919TipSts, A1921TipVta, A1906TipCmp, A1915TipRHo, A1909TipCxP, A1903TipBan, A149TipCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPDOC");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPDOC"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate60129( ) ;
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
            EndLevel60129( ) ;
         }
         CloseExtendedTableCursors60129( ) ;
      }

      protected void DeferredUpdate60129( )
      {
      }

      protected void delete( )
      {
         BeforeValidate60129( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency60129( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls60129( ) ;
            AfterConfirm60129( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete60129( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006010 */
                  pr_default.execute(8, new Object[] {A149TipCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CTIPDOC");
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
         sMode129 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel60129( ) ;
         Gx_mode = sMode129;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls60129( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T006011 */
            pr_default.execute(9, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos Liquidación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T006012 */
            pr_default.execute(10, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle de Letras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T006013 */
            pr_default.execute(11, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuenta Pagar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T006014 */
            pr_default.execute(12, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"ChequeDiferido Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T006015 */
            pr_default.execute(13, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuenta x Cobrar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T006016 */
            pr_default.execute(14, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos Bancos Otros"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T006017 */
            pr_default.execute(15, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuración de Venta por lotes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T006018 */
            pr_default.execute(16, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T006019 */
            pr_default.execute(17, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T006020 */
            pr_default.execute(18, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tip"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T006021 */
            pr_default.execute(19, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Asiento Contable Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T006022 */
            pr_default.execute(20, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T006023 */
            pr_default.execute(21, new Object[] {A149TipCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Mov. Almacen(Entradas,Salidas,Remision)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
         }
      }

      protected void EndLevel60129( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete60129( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.tipodocumento",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues600( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.tipodocumento",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart60129( )
      {
         /* Scan By routine */
         /* Using cursor T006024 */
         pr_default.execute(22);
         RcdFound129 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound129 = 1;
            A149TipCod = T006024_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext60129( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound129 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound129 = 1;
            A149TipCod = T006024_A149TipCod[0];
            AssignAttri("", false, "A149TipCod", A149TipCod);
         }
      }

      protected void ScanEnd60129( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm60129( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert60129( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate60129( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete60129( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete60129( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate60129( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes60129( )
      {
         edtTipCod_Enabled = 0;
         AssignProp("", false, edtTipCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCod_Enabled), 5, 0), true);
         edtTipDsc_Enabled = 0;
         AssignProp("", false, edtTipDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipDsc_Enabled), 5, 0), true);
         edtTipAbr_Enabled = 0;
         AssignProp("", false, edtTipAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipAbr_Enabled), 5, 0), true);
         edtTipSigno_Enabled = 0;
         AssignProp("", false, edtTipSigno_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipSigno_Enabled), 5, 0), true);
         edtTipVta_Enabled = 0;
         AssignProp("", false, edtTipVta_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipVta_Enabled), 5, 0), true);
         edtTipCmp_Enabled = 0;
         AssignProp("", false, edtTipCmp_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipCmp_Enabled), 5, 0), true);
         edtTipRHo_Enabled = 0;
         AssignProp("", false, edtTipRHo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipRHo_Enabled), 5, 0), true);
         chkTipCxP.Enabled = 0;
         AssignProp("", false, chkTipCxP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTipCxP.Enabled), 5, 0), true);
         chkTipBan.Enabled = 0;
         AssignProp("", false, chkTipBan_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkTipBan.Enabled), 5, 0), true);
         edtTipSts_Enabled = 0;
         AssignProp("", false, edtTipSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipSts_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes60129( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues600( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810262738", false, true);
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
         GXEncryptionTmp = "configuracion.tipodocumento.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7TipCod));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.tipodocumento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TipoDocumento");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\tipodocumento:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z149TipCod", StringUtil.RTrim( Z149TipCod));
         GxWebStd.gx_hidden_field( context, "Z1910TipDsc", StringUtil.RTrim( Z1910TipDsc));
         GxWebStd.gx_hidden_field( context, "Z306TipAbr", StringUtil.RTrim( Z306TipAbr));
         GxWebStd.gx_hidden_field( context, "Z511TipSigno", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z511TipSigno), 2, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1919TipSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1919TipSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1921TipVta", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1921TipVta), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1906TipCmp", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1906TipCmp), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1915TipRHo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1915TipRHo), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1909TipCxP", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1909TipCxP), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1903TipBan", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1903TipBan), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vTIPCOD", StringUtil.RTrim( AV7TipCod));
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPCOD", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7TipCod, "")), context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
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
         GXEncryptionTmp = "configuracion.tipodocumento.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7TipCod));
         return formatLink("configuracion.tipodocumento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.TipoDocumento" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo Documento" ;
      }

      protected void InitializeNonKey60129( )
      {
         A1910TipDsc = "";
         AssignAttri("", false, "A1910TipDsc", A1910TipDsc);
         A306TipAbr = "";
         AssignAttri("", false, "A306TipAbr", A306TipAbr);
         A511TipSigno = 0;
         AssignAttri("", false, "A511TipSigno", StringUtil.LTrimStr( (decimal)(A511TipSigno), 2, 0));
         A1921TipVta = 0;
         AssignAttri("", false, "A1921TipVta", StringUtil.Str( (decimal)(A1921TipVta), 1, 0));
         A1906TipCmp = 0;
         AssignAttri("", false, "A1906TipCmp", StringUtil.Str( (decimal)(A1906TipCmp), 1, 0));
         A1915TipRHo = 0;
         AssignAttri("", false, "A1915TipRHo", StringUtil.Str( (decimal)(A1915TipRHo), 1, 0));
         A1909TipCxP = 0;
         AssignAttri("", false, "A1909TipCxP", StringUtil.Str( (decimal)(A1909TipCxP), 1, 0));
         A1903TipBan = 0;
         AssignAttri("", false, "A1903TipBan", StringUtil.Str( (decimal)(A1903TipBan), 1, 0));
         A1919TipSts = 1;
         AssignAttri("", false, "A1919TipSts", StringUtil.Str( (decimal)(A1919TipSts), 1, 0));
         Z1910TipDsc = "";
         Z306TipAbr = "";
         Z511TipSigno = 0;
         Z1919TipSts = 0;
         Z1921TipVta = 0;
         Z1906TipCmp = 0;
         Z1915TipRHo = 0;
         Z1909TipCxP = 0;
         Z1903TipBan = 0;
      }

      protected void InitAll60129( )
      {
         A149TipCod = "";
         AssignAttri("", false, "A149TipCod", A149TipCod);
         InitializeNonKey60129( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1919TipSts = i1919TipSts;
         AssignAttri("", false, "A1919TipSts", StringUtil.Str( (decimal)(A1919TipSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810262759", true, true);
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
         context.AddJavascriptSource("configuracion/tipodocumento.js", "?202281810262759", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtTipCod_Internalname = "TIPCOD";
         edtTipDsc_Internalname = "TIPDSC";
         edtTipAbr_Internalname = "TIPABR";
         edtTipSigno_Internalname = "TIPSIGNO";
         edtTipVta_Internalname = "TIPVTA";
         edtTipCmp_Internalname = "TIPCMP";
         edtTipRHo_Internalname = "TIPRHO";
         chkTipCxP_Internalname = "TIPCXP";
         chkTipBan_Internalname = "TIPBAN";
         edtTipSts_Internalname = "TIPSTS";
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
         Form.Caption = "Tipo Documento";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtTipSts_Jsonclick = "";
         edtTipSts_Enabled = 1;
         chkTipBan.Enabled = 1;
         chkTipCxP.Enabled = 1;
         edtTipRHo_Jsonclick = "";
         edtTipRHo_Enabled = 1;
         edtTipCmp_Jsonclick = "";
         edtTipCmp_Enabled = 1;
         edtTipVta_Jsonclick = "";
         edtTipVta_Enabled = 1;
         edtTipSigno_Jsonclick = "";
         edtTipSigno_Enabled = 1;
         edtTipAbr_Jsonclick = "";
         edtTipAbr_Enabled = 1;
         edtTipDsc_Jsonclick = "";
         edtTipDsc_Enabled = 1;
         edtTipCod_Jsonclick = "";
         edtTipCod_Enabled = 1;
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
         chkTipCxP.Name = "TIPCXP";
         chkTipCxP.WebTags = "";
         chkTipCxP.Caption = "";
         AssignProp("", false, chkTipCxP_Internalname, "TitleCaption", chkTipCxP.Caption, true);
         chkTipCxP.CheckedValue = "0";
         A1909TipCxP = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1909TipCxP), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1909TipCxP", StringUtil.Str( (decimal)(A1909TipCxP), 1, 0));
         chkTipBan.Name = "TIPBAN";
         chkTipBan.WebTags = "";
         chkTipBan.Caption = "";
         AssignProp("", false, chkTipBan_Internalname, "TitleCaption", chkTipBan.Caption, true);
         chkTipBan.CheckedValue = "0";
         A1903TipBan = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A1903TipBan), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A1903TipBan", StringUtil.Str( (decimal)(A1903TipBan), 1, 0));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7TipCod',fld:'vTIPCOD',pic:'',hsh:true},{av:'A1909TipCxP',fld:'TIPCXP',pic:'9'},{av:'A1903TipBan',fld:'TIPBAN',pic:'9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A1909TipCxP',fld:'TIPCXP',pic:'9'},{av:'A1903TipBan',fld:'TIPBAN',pic:'9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7TipCod',fld:'vTIPCOD',pic:'',hsh:true},{av:'A1909TipCxP',fld:'TIPCXP',pic:'9'},{av:'A1903TipBan',fld:'TIPBAN',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A1909TipCxP',fld:'TIPCXP',pic:'9'},{av:'A1903TipBan',fld:'TIPBAN',pic:'9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E12602',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A149TipCod',fld:'TIPCOD',pic:''},{av:'A1910TipDsc',fld:'TIPDSC',pic:''},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A1909TipCxP',fld:'TIPCXP',pic:'9'},{av:'A1903TipBan',fld:'TIPBAN',pic:'9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A1909TipCxP',fld:'TIPCXP',pic:'9'},{av:'A1903TipBan',fld:'TIPBAN',pic:'9'}]}");
         setEventMetadata("VALID_TIPCOD","{handler:'Valid_Tipcod',iparms:[{av:'A1909TipCxP',fld:'TIPCXP',pic:'9'},{av:'A1903TipBan',fld:'TIPBAN',pic:'9'}]");
         setEventMetadata("VALID_TIPCOD",",oparms:[{av:'A1909TipCxP',fld:'TIPCXP',pic:'9'},{av:'A1903TipBan',fld:'TIPBAN',pic:'9'}]}");
         setEventMetadata("VALID_TIPDSC","{handler:'Valid_Tipdsc',iparms:[{av:'A1909TipCxP',fld:'TIPCXP',pic:'9'},{av:'A1903TipBan',fld:'TIPBAN',pic:'9'}]");
         setEventMetadata("VALID_TIPDSC",",oparms:[{av:'A1909TipCxP',fld:'TIPCXP',pic:'9'},{av:'A1903TipBan',fld:'TIPBAN',pic:'9'}]}");
         setEventMetadata("VALID_TIPABR","{handler:'Valid_Tipabr',iparms:[{av:'A1909TipCxP',fld:'TIPCXP',pic:'9'},{av:'A1903TipBan',fld:'TIPBAN',pic:'9'}]");
         setEventMetadata("VALID_TIPABR",",oparms:[{av:'A1909TipCxP',fld:'TIPCXP',pic:'9'},{av:'A1903TipBan',fld:'TIPBAN',pic:'9'}]}");
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
         wcpOAV7TipCod = "";
         Z149TipCod = "";
         Z1910TipDsc = "";
         Z306TipAbr = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A149TipCod = "";
         A1910TipDsc = "";
         A306TipAbr = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode129 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV13SGAuDocGls = "";
         AV14Codigo = "";
         GXt_char1 = "";
         GXt_char2 = "";
         GXt_char3 = "";
         T00604_A149TipCod = new string[] {""} ;
         T00604_A1910TipDsc = new string[] {""} ;
         T00604_A306TipAbr = new string[] {""} ;
         T00604_A511TipSigno = new short[1] ;
         T00604_A1919TipSts = new short[1] ;
         T00604_A1921TipVta = new short[1] ;
         T00604_A1906TipCmp = new short[1] ;
         T00604_A1915TipRHo = new short[1] ;
         T00604_A1909TipCxP = new short[1] ;
         T00604_A1903TipBan = new short[1] ;
         T00605_A149TipCod = new string[] {""} ;
         T00603_A149TipCod = new string[] {""} ;
         T00603_A1910TipDsc = new string[] {""} ;
         T00603_A306TipAbr = new string[] {""} ;
         T00603_A511TipSigno = new short[1] ;
         T00603_A1919TipSts = new short[1] ;
         T00603_A1921TipVta = new short[1] ;
         T00603_A1906TipCmp = new short[1] ;
         T00603_A1915TipRHo = new short[1] ;
         T00603_A1909TipCxP = new short[1] ;
         T00603_A1903TipBan = new short[1] ;
         T00606_A149TipCod = new string[] {""} ;
         T00607_A149TipCod = new string[] {""} ;
         T00602_A149TipCod = new string[] {""} ;
         T00602_A1910TipDsc = new string[] {""} ;
         T00602_A306TipAbr = new string[] {""} ;
         T00602_A511TipSigno = new short[1] ;
         T00602_A1919TipSts = new short[1] ;
         T00602_A1921TipVta = new short[1] ;
         T00602_A1906TipCmp = new short[1] ;
         T00602_A1915TipRHo = new short[1] ;
         T00602_A1909TipCxP = new short[1] ;
         T00602_A1903TipBan = new short[1] ;
         T006011_A270LiqCod = new string[] {""} ;
         T006011_A236LiqPrvCod = new string[] {""} ;
         T006011_A271LiqCodItem = new int[1] ;
         T006011_A282LiqDItem = new int[1] ;
         T006012_A265LetPLetCod = new string[] {""} ;
         T006012_A268LetPItem = new int[1] ;
         T006013_A260CPTipCod = new string[] {""} ;
         T006013_A261CPComCod = new string[] {""} ;
         T006013_A262CPPrvCod = new string[] {""} ;
         T006014_A238CheqDCod = new string[] {""} ;
         T006014_A241CheqDItem = new int[1] ;
         T006015_A184CCTipCod = new string[] {""} ;
         T006015_A185CCDocNum = new string[] {""} ;
         T006016_A387TSMovCod = new string[] {""} ;
         T006017_A224LotCliCod = new string[] {""} ;
         T006018_A149TipCod = new string[] {""} ;
         T006018_A243ComCod = new string[] {""} ;
         T006018_A244PrvCod = new string[] {""} ;
         T006019_A149TipCod = new string[] {""} ;
         T006019_A24DocNum = new string[] {""} ;
         T006019_n24DocNum = new bool[] {false} ;
         T006020_A348UsuCod = new string[] {""} ;
         T006020_A149TipCod = new string[] {""} ;
         T006020_A351UsuSerDet = new string[] {""} ;
         T006021_A127VouAno = new short[1] ;
         T006021_A128VouMes = new short[1] ;
         T006021_A126TASICod = new int[1] ;
         T006021_A129VouNum = new string[] {""} ;
         T006021_A130VouDSec = new int[1] ;
         T006022_A83ParTip = new string[] {""} ;
         T006022_A84ParCod = new int[1] ;
         T006023_A13MvATip = new string[] {""} ;
         T006023_A14MvACod = new string[] {""} ;
         T006024_A149TipCod = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipodocumento__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipodocumento__default(),
            new Object[][] {
                new Object[] {
               T00602_A149TipCod, T00602_A1910TipDsc, T00602_A306TipAbr, T00602_A511TipSigno, T00602_A1919TipSts, T00602_A1921TipVta, T00602_A1906TipCmp, T00602_A1915TipRHo, T00602_A1909TipCxP, T00602_A1903TipBan
               }
               , new Object[] {
               T00603_A149TipCod, T00603_A1910TipDsc, T00603_A306TipAbr, T00603_A511TipSigno, T00603_A1919TipSts, T00603_A1921TipVta, T00603_A1906TipCmp, T00603_A1915TipRHo, T00603_A1909TipCxP, T00603_A1903TipBan
               }
               , new Object[] {
               T00604_A149TipCod, T00604_A1910TipDsc, T00604_A306TipAbr, T00604_A511TipSigno, T00604_A1919TipSts, T00604_A1921TipVta, T00604_A1906TipCmp, T00604_A1915TipRHo, T00604_A1909TipCxP, T00604_A1903TipBan
               }
               , new Object[] {
               T00605_A149TipCod
               }
               , new Object[] {
               T00606_A149TipCod
               }
               , new Object[] {
               T00607_A149TipCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006011_A270LiqCod, T006011_A236LiqPrvCod, T006011_A271LiqCodItem, T006011_A282LiqDItem
               }
               , new Object[] {
               T006012_A265LetPLetCod, T006012_A268LetPItem
               }
               , new Object[] {
               T006013_A260CPTipCod, T006013_A261CPComCod, T006013_A262CPPrvCod
               }
               , new Object[] {
               T006014_A238CheqDCod, T006014_A241CheqDItem
               }
               , new Object[] {
               T006015_A184CCTipCod, T006015_A185CCDocNum
               }
               , new Object[] {
               T006016_A387TSMovCod
               }
               , new Object[] {
               T006017_A224LotCliCod
               }
               , new Object[] {
               T006018_A149TipCod, T006018_A243ComCod, T006018_A244PrvCod
               }
               , new Object[] {
               T006019_A149TipCod, T006019_A24DocNum
               }
               , new Object[] {
               T006020_A348UsuCod, T006020_A149TipCod, T006020_A351UsuSerDet
               }
               , new Object[] {
               T006021_A127VouAno, T006021_A128VouMes, T006021_A126TASICod, T006021_A129VouNum, T006021_A130VouDSec
               }
               , new Object[] {
               T006022_A83ParTip, T006022_A84ParCod
               }
               , new Object[] {
               T006023_A13MvATip, T006023_A14MvACod
               }
               , new Object[] {
               T006024_A149TipCod
               }
            }
         );
         Z1919TipSts = 1;
         A1919TipSts = 1;
         i1919TipSts = 1;
      }

      private short Z511TipSigno ;
      private short Z1919TipSts ;
      private short Z1921TipVta ;
      private short Z1906TipCmp ;
      private short Z1915TipRHo ;
      private short Z1909TipCxP ;
      private short Z1903TipBan ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1909TipCxP ;
      private short A1903TipBan ;
      private short A511TipSigno ;
      private short A1921TipVta ;
      private short A1906TipCmp ;
      private short A1915TipRHo ;
      private short A1919TipSts ;
      private short Gx_BScreen ;
      private short RcdFound129 ;
      private short GX_JID ;
      private short nIsDirty_129 ;
      private short gxajaxcallmode ;
      private short i1919TipSts ;
      private int trnEnded ;
      private int edtTipCod_Enabled ;
      private int edtTipDsc_Enabled ;
      private int edtTipAbr_Enabled ;
      private int edtTipSigno_Enabled ;
      private int edtTipVta_Enabled ;
      private int edtTipCmp_Enabled ;
      private int edtTipRHo_Enabled ;
      private int edtTipSts_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string wcpOAV7TipCod ;
      private string Z149TipCod ;
      private string Z1910TipDsc ;
      private string Z306TipAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string AV7TipCod ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipCod_Internalname ;
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
      private string A149TipCod ;
      private string edtTipCod_Jsonclick ;
      private string edtTipDsc_Internalname ;
      private string A1910TipDsc ;
      private string edtTipDsc_Jsonclick ;
      private string edtTipAbr_Internalname ;
      private string A306TipAbr ;
      private string edtTipAbr_Jsonclick ;
      private string edtTipSigno_Internalname ;
      private string edtTipSigno_Jsonclick ;
      private string edtTipVta_Internalname ;
      private string edtTipVta_Jsonclick ;
      private string edtTipCmp_Internalname ;
      private string edtTipCmp_Jsonclick ;
      private string edtTipRHo_Internalname ;
      private string edtTipRHo_Jsonclick ;
      private string chkTipCxP_Internalname ;
      private string chkTipBan_Internalname ;
      private string edtTipSts_Internalname ;
      private string edtTipSts_Jsonclick ;
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
      private string sMode129 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private string GXt_char3 ;
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
      private bool Gx_longc ;
      private string AV13SGAuDocGls ;
      private string AV14Codigo ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkTipCxP ;
      private GXCheckbox chkTipBan ;
      private IDataStoreProvider pr_default ;
      private string[] T00604_A149TipCod ;
      private string[] T00604_A1910TipDsc ;
      private string[] T00604_A306TipAbr ;
      private short[] T00604_A511TipSigno ;
      private short[] T00604_A1919TipSts ;
      private short[] T00604_A1921TipVta ;
      private short[] T00604_A1906TipCmp ;
      private short[] T00604_A1915TipRHo ;
      private short[] T00604_A1909TipCxP ;
      private short[] T00604_A1903TipBan ;
      private string[] T00605_A149TipCod ;
      private string[] T00603_A149TipCod ;
      private string[] T00603_A1910TipDsc ;
      private string[] T00603_A306TipAbr ;
      private short[] T00603_A511TipSigno ;
      private short[] T00603_A1919TipSts ;
      private short[] T00603_A1921TipVta ;
      private short[] T00603_A1906TipCmp ;
      private short[] T00603_A1915TipRHo ;
      private short[] T00603_A1909TipCxP ;
      private short[] T00603_A1903TipBan ;
      private string[] T00606_A149TipCod ;
      private string[] T00607_A149TipCod ;
      private string[] T00602_A149TipCod ;
      private string[] T00602_A1910TipDsc ;
      private string[] T00602_A306TipAbr ;
      private short[] T00602_A511TipSigno ;
      private short[] T00602_A1919TipSts ;
      private short[] T00602_A1921TipVta ;
      private short[] T00602_A1906TipCmp ;
      private short[] T00602_A1915TipRHo ;
      private short[] T00602_A1909TipCxP ;
      private short[] T00602_A1903TipBan ;
      private string[] T006011_A270LiqCod ;
      private string[] T006011_A236LiqPrvCod ;
      private int[] T006011_A271LiqCodItem ;
      private int[] T006011_A282LiqDItem ;
      private string[] T006012_A265LetPLetCod ;
      private int[] T006012_A268LetPItem ;
      private string[] T006013_A260CPTipCod ;
      private string[] T006013_A261CPComCod ;
      private string[] T006013_A262CPPrvCod ;
      private string[] T006014_A238CheqDCod ;
      private int[] T006014_A241CheqDItem ;
      private string[] T006015_A184CCTipCod ;
      private string[] T006015_A185CCDocNum ;
      private string[] T006016_A387TSMovCod ;
      private string[] T006017_A224LotCliCod ;
      private string[] T006018_A149TipCod ;
      private string[] T006018_A243ComCod ;
      private string[] T006018_A244PrvCod ;
      private string[] T006019_A149TipCod ;
      private string[] T006019_A24DocNum ;
      private bool[] T006019_n24DocNum ;
      private string[] T006020_A348UsuCod ;
      private string[] T006020_A149TipCod ;
      private string[] T006020_A351UsuSerDet ;
      private short[] T006021_A127VouAno ;
      private short[] T006021_A128VouMes ;
      private int[] T006021_A126TASICod ;
      private string[] T006021_A129VouNum ;
      private int[] T006021_A130VouDSec ;
      private string[] T006022_A83ParTip ;
      private int[] T006022_A84ParCod ;
      private string[] T006023_A13MvATip ;
      private string[] T006023_A14MvACod ;
      private string[] T006024_A149TipCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
   }

   public class tipodocumento__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tipodocumento__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
       ,new ForEachCursor(def[22])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00604;
        prmT00604 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT00605;
        prmT00605 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT00603;
        prmT00603 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT00606;
        prmT00606 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT00607;
        prmT00607 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT00602;
        prmT00602 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT00608;
        prmT00608 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0) ,
        new ParDef("@TipDsc",GXType.NChar,100,0) ,
        new ParDef("@TipAbr",GXType.NChar,5,0) ,
        new ParDef("@TipSigno",GXType.Int16,2,0) ,
        new ParDef("@TipSts",GXType.Int16,1,0) ,
        new ParDef("@TipVta",GXType.Int16,1,0) ,
        new ParDef("@TipCmp",GXType.Int16,1,0) ,
        new ParDef("@TipRHo",GXType.Int16,1,0) ,
        new ParDef("@TipCxP",GXType.Int16,1,0) ,
        new ParDef("@TipBan",GXType.Int16,1,0)
        };
        Object[] prmT00609;
        prmT00609 = new Object[] {
        new ParDef("@TipDsc",GXType.NChar,100,0) ,
        new ParDef("@TipAbr",GXType.NChar,5,0) ,
        new ParDef("@TipSigno",GXType.Int16,2,0) ,
        new ParDef("@TipSts",GXType.Int16,1,0) ,
        new ParDef("@TipVta",GXType.Int16,1,0) ,
        new ParDef("@TipCmp",GXType.Int16,1,0) ,
        new ParDef("@TipRHo",GXType.Int16,1,0) ,
        new ParDef("@TipCxP",GXType.Int16,1,0) ,
        new ParDef("@TipBan",GXType.Int16,1,0) ,
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT006010;
        prmT006010 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT006011;
        prmT006011 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT006012;
        prmT006012 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT006013;
        prmT006013 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT006014;
        prmT006014 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT006015;
        prmT006015 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT006016;
        prmT006016 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT006017;
        prmT006017 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT006018;
        prmT006018 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT006019;
        prmT006019 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT006020;
        prmT006020 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT006021;
        prmT006021 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT006022;
        prmT006022 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT006023;
        prmT006023 = new Object[] {
        new ParDef("@TipCod",GXType.NChar,3,0)
        };
        Object[] prmT006024;
        prmT006024 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00602", "SELECT [TipCod], [TipDsc], [TipAbr], [TipSigno], [TipSts], [TipVta], [TipCmp], [TipRHo], [TipCxP], [TipBan] FROM [CTIPDOC] WITH (UPDLOCK) WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00602,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00603", "SELECT [TipCod], [TipDsc], [TipAbr], [TipSigno], [TipSts], [TipVta], [TipCmp], [TipRHo], [TipCxP], [TipBan] FROM [CTIPDOC] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00603,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00604", "SELECT TM1.[TipCod], TM1.[TipDsc], TM1.[TipAbr], TM1.[TipSigno], TM1.[TipSts], TM1.[TipVta], TM1.[TipCmp], TM1.[TipRHo], TM1.[TipCxP], TM1.[TipBan] FROM [CTIPDOC] TM1 WHERE TM1.[TipCod] = @TipCod ORDER BY TM1.[TipCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00604,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00605", "SELECT [TipCod] FROM [CTIPDOC] WHERE [TipCod] = @TipCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00605,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00606", "SELECT TOP 1 [TipCod] FROM [CTIPDOC] WHERE ( [TipCod] > @TipCod) ORDER BY [TipCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00606,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00607", "SELECT TOP 1 [TipCod] FROM [CTIPDOC] WHERE ( [TipCod] < @TipCod) ORDER BY [TipCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00607,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00608", "INSERT INTO [CTIPDOC]([TipCod], [TipDsc], [TipAbr], [TipSigno], [TipSts], [TipVta], [TipCmp], [TipRHo], [TipCxP], [TipBan]) VALUES(@TipCod, @TipDsc, @TipAbr, @TipSigno, @TipSts, @TipVta, @TipCmp, @TipRHo, @TipCxP, @TipBan)", GxErrorMask.GX_NOMASK,prmT00608)
           ,new CursorDef("T00609", "UPDATE [CTIPDOC] SET [TipDsc]=@TipDsc, [TipAbr]=@TipAbr, [TipSigno]=@TipSigno, [TipSts]=@TipSts, [TipVta]=@TipVta, [TipCmp]=@TipCmp, [TipRHo]=@TipRHo, [TipCxP]=@TipCxP, [TipBan]=@TipBan  WHERE [TipCod] = @TipCod", GxErrorMask.GX_NOMASK,prmT00609)
           ,new CursorDef("T006010", "DELETE FROM [CTIPDOC]  WHERE [TipCod] = @TipCod", GxErrorMask.GX_NOMASK,prmT006010)
           ,new CursorDef("T006011", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem], [LiqDItem] FROM [CPLIQUIDACIONDOC] WHERE [LiqDTipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006011,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006012", "SELECT TOP 1 [LetPLetCod], [LetPItem] FROM [CPLETRASDET] WHERE [LetPTipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006012,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006013", "SELECT TOP 1 [CPTipCod], [CPComCod], [CPPrvCod] FROM [CPCUENTAPAGAR] WHERE [CPTipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006013,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006014", "SELECT TOP 1 [CheqDCod], [CheqDItem] FROM [CPCHEQUEDIFERIDODET] WHERE [CheqDTipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006014,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006015", "SELECT TOP 1 [CCTipCod], [CCDocNum] FROM [CLCUENTACOBRAR] WHERE [CCTipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006015,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006016", "SELECT TOP 1 [TSMovCod] FROM [TSMOVBANCOS] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006016,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006017", "SELECT TOP 1 [LotCliCod] FROM [CLVENTALOTES] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006017,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006018", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod] FROM [CPCOMPRAS] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006018,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006019", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006019,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006020", "SELECT TOP 1 [UsuCod], [TipCod], [UsuSerDet] FROM [SGUSUARIOSSERIES] WHERE [TipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006020,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006021", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE [VouDTipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006021,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006022", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParTipCod] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006022,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006023", "SELECT TOP 1 [MvATip], [MvACod] FROM [AGUIAS] WHERE [DocTip] = @TipCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006023,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006024", "SELECT [TipCod] FROM [CTIPDOC] ORDER BY [TipCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006024,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((short[]) buf[7])[0] = rslt.getShort(8);
              ((short[]) buf[8])[0] = rslt.getShort(9);
              ((short[]) buf[9])[0] = rslt.getShort(10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((string[]) buf[2])[0] = rslt.getString(3, 4);
              return;
           case 19 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              return;
     }
  }

}

}
