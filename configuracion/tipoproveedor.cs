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
   public class tipoproveedor : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vCTPRVCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASACTPRVCOD5Z133( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.tipoproveedor.aspx")), "configuracion.tipoproveedor.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.tipoproveedor.aspx")))) ;
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
                  AV7TprvCod = (int)(NumberUtil.Val( GetPar( "TprvCod"), "."));
                  AssignAttri("", false, "AV7TprvCod", StringUtil.LTrimStr( (decimal)(AV7TprvCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTPRVCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TprvCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Tipo Proveedor", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTprvDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tipoproveedor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipoproveedor( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_TprvCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TprvCod = aP1_TprvCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTprvSts = new GXCombobox();
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
         if ( cmbTprvSts.ItemCount > 0 )
         {
            A1942TprvSts = (short)(NumberUtil.Val( cmbTprvSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1942TprvSts), 1, 0))), "."));
            AssignAttri("", false, "A1942TprvSts", StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTprvSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
            AssignProp("", false, cmbTprvSts_Internalname, "Values", cmbTprvSts.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTprvDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTprvDsc_Internalname, "Tipo de Proveedor", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTprvDsc_Internalname, StringUtil.RTrim( A1941TprvDsc), StringUtil.RTrim( context.localUtil.Format( A1941TprvDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTprvDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtTprvDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoProveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTprvAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTprvAbr_Internalname, "Abreviatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTprvAbr_Internalname, StringUtil.RTrim( A1940TprvAbr), StringUtil.RTrim( context.localUtil.Format( A1940TprvAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTprvAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTprvAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoProveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbTprvSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTprvSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTprvSts, cmbTprvSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1942TprvSts), 1, 0)), 1, cmbTprvSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTprvSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 1, "HLP_Configuracion\\TipoProveedor.htm");
         cmbTprvSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
         AssignProp("", false, cmbTprvSts_Internalname, "Values", (string)(cmbTprvSts.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoProveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoProveedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoProveedor.htm");
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
         GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTprvCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A298TprvCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A298TprvCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTprvCod_Jsonclick, 0, "Attribute", "", "", "", "", edtTprvCod_Visible, edtTprvCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\TipoProveedor.htm");
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
         E115Z2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z298TprvCod = (int)(context.localUtil.CToN( cgiGet( "Z298TprvCod"), ".", ","));
               Z1941TprvDsc = cgiGet( "Z1941TprvDsc");
               Z1940TprvAbr = cgiGet( "Z1940TprvAbr");
               Z1942TprvSts = (short)(context.localUtil.CToN( cgiGet( "Z1942TprvSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7TprvCod = (int)(context.localUtil.CToN( cgiGet( "vTPRVCOD"), ".", ","));
               AV13cTprvCod = (int)(context.localUtil.CToN( cgiGet( "vCTPRVCOD"), ".", ","));
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
               A1941TprvDsc = cgiGet( edtTprvDsc_Internalname);
               AssignAttri("", false, "A1941TprvDsc", A1941TprvDsc);
               A1940TprvAbr = cgiGet( edtTprvAbr_Internalname);
               AssignAttri("", false, "A1940TprvAbr", A1940TprvAbr);
               cmbTprvSts.CurrentValue = cgiGet( cmbTprvSts_Internalname);
               A1942TprvSts = (short)(NumberUtil.Val( cgiGet( cmbTprvSts_Internalname), "."));
               AssignAttri("", false, "A1942TprvSts", StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtTprvCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTprvCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TPRVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTprvCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A298TprvCod = 0;
                  AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
               }
               else
               {
                  A298TprvCod = (int)(context.localUtil.CToN( cgiGet( edtTprvCod_Internalname), ".", ","));
                  AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TipoProveedor");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A298TprvCod != Z298TprvCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\tipoproveedor:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A298TprvCod = (int)(NumberUtil.Val( GetPar( "TprvCod"), "."));
                  AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
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
                     sMode133 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode133;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound133 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5Z0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TPRVCOD");
                        AnyError = 1;
                        GX_FocusControl = edtTprvCod_Internalname;
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
                           E115Z2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E125Z2 ();
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
            E125Z2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5Z133( ) ;
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
            DisableAttributes5Z133( ) ;
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

      protected void CONFIRM_5Z0( )
      {
         BeforeValidate5Z133( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5Z133( ) ;
            }
            else
            {
               CheckExtendedTable5Z133( ) ;
               CloseExtendedTableCursors5Z133( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5Z0( )
      {
      }

      protected void E115Z2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtTprvCod_Visible = 0;
         AssignProp("", false, edtTprvCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTprvCod_Visible), 5, 0), true);
      }

      protected void E125Z2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV14SGAuDocGls = "Tipo de Proveedor N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A298TprvCod), 10, 0)) + " " + StringUtil.Trim( A1941TprvDsc);
            AV15Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A298TprvCod), 10, 0));
            GXt_char1 = "CNF";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV14SGAuDocGls, ref  AV15Codigo, ref  AV15Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.tipoproveedorww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM5Z133( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1941TprvDsc = T005Z3_A1941TprvDsc[0];
               Z1940TprvAbr = T005Z3_A1940TprvAbr[0];
               Z1942TprvSts = T005Z3_A1942TprvSts[0];
            }
            else
            {
               Z1941TprvDsc = A1941TprvDsc;
               Z1940TprvAbr = A1940TprvAbr;
               Z1942TprvSts = A1942TprvSts;
            }
         }
         if ( GX_JID == -8 )
         {
            Z298TprvCod = A298TprvCod;
            Z1941TprvDsc = A1941TprvDsc;
            Z1940TprvAbr = A1940TprvAbr;
            Z1942TprvSts = A1942TprvSts;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TprvCod) )
         {
            A298TprvCod = AV7TprvCod;
            AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
         }
         if ( ! (0==AV7TprvCod) )
         {
            edtTprvCod_Enabled = 0;
            AssignProp("", false, edtTprvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTprvCod_Enabled), 5, 0), true);
         }
         else
         {
            edtTprvCod_Enabled = 1;
            AssignProp("", false, edtTprvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTprvCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7TprvCod) )
         {
            edtTprvCod_Enabled = 0;
            AssignProp("", false, edtTprvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTprvCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A1942TprvSts) && ( Gx_BScreen == 0 ) )
         {
            A1942TprvSts = 1;
            AssignAttri("", false, "A1942TprvSts", StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
         }
      }

      protected void Load5Z133( )
      {
         /* Using cursor T005Z4 */
         pr_default.execute(2, new Object[] {A298TprvCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound133 = 1;
            A1941TprvDsc = T005Z4_A1941TprvDsc[0];
            AssignAttri("", false, "A1941TprvDsc", A1941TprvDsc);
            A1940TprvAbr = T005Z4_A1940TprvAbr[0];
            AssignAttri("", false, "A1940TprvAbr", A1940TprvAbr);
            A1942TprvSts = T005Z4_A1942TprvSts[0];
            AssignAttri("", false, "A1942TprvSts", StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
            ZM5Z133( -8) ;
         }
         pr_default.close(2);
         OnLoadActions5Z133( ) ;
      }

      protected void OnLoadActions5Z133( )
      {
      }

      protected void CheckExtendedTable5Z133( )
      {
         nIsDirty_133 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1941TprvDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Tipo de Proveedor", "", "", "", "", "", "", "", ""), 1, "TPRVDSC");
            AnyError = 1;
            GX_FocusControl = edtTprvDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5Z133( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey5Z133( )
      {
         /* Using cursor T005Z5 */
         pr_default.execute(3, new Object[] {A298TprvCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound133 = 1;
         }
         else
         {
            RcdFound133 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005Z3 */
         pr_default.execute(1, new Object[] {A298TprvCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5Z133( 8) ;
            RcdFound133 = 1;
            A298TprvCod = T005Z3_A298TprvCod[0];
            AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
            A1941TprvDsc = T005Z3_A1941TprvDsc[0];
            AssignAttri("", false, "A1941TprvDsc", A1941TprvDsc);
            A1940TprvAbr = T005Z3_A1940TprvAbr[0];
            AssignAttri("", false, "A1940TprvAbr", A1940TprvAbr);
            A1942TprvSts = T005Z3_A1942TprvSts[0];
            AssignAttri("", false, "A1942TprvSts", StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
            Z298TprvCod = A298TprvCod;
            sMode133 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load5Z133( ) ;
            if ( AnyError == 1 )
            {
               RcdFound133 = 0;
               InitializeNonKey5Z133( ) ;
            }
            Gx_mode = sMode133;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound133 = 0;
            InitializeNonKey5Z133( ) ;
            sMode133 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode133;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5Z133( ) ;
         if ( RcdFound133 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound133 = 0;
         /* Using cursor T005Z6 */
         pr_default.execute(4, new Object[] {A298TprvCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T005Z6_A298TprvCod[0] < A298TprvCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T005Z6_A298TprvCod[0] > A298TprvCod ) ) )
            {
               A298TprvCod = T005Z6_A298TprvCod[0];
               AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
               RcdFound133 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound133 = 0;
         /* Using cursor T005Z7 */
         pr_default.execute(5, new Object[] {A298TprvCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T005Z7_A298TprvCod[0] > A298TprvCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T005Z7_A298TprvCod[0] < A298TprvCod ) ) )
            {
               A298TprvCod = T005Z7_A298TprvCod[0];
               AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
               RcdFound133 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5Z133( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTprvDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5Z133( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound133 == 1 )
            {
               if ( A298TprvCod != Z298TprvCod )
               {
                  A298TprvCod = Z298TprvCod;
                  AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TPRVCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTprvCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTprvDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5Z133( ) ;
                  GX_FocusControl = edtTprvDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A298TprvCod != Z298TprvCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtTprvDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5Z133( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TPRVCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTprvCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTprvDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5Z133( ) ;
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
         if ( A298TprvCod != Z298TprvCod )
         {
            A298TprvCod = Z298TprvCod;
            AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TPRVCOD");
            AnyError = 1;
            GX_FocusControl = edtTprvCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTprvDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5Z133( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005Z2 */
            pr_default.execute(0, new Object[] {A298TprvCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPOPROVEEDOR"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1941TprvDsc, T005Z2_A1941TprvDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1940TprvAbr, T005Z2_A1940TprvAbr[0]) != 0 ) || ( Z1942TprvSts != T005Z2_A1942TprvSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1941TprvDsc, T005Z2_A1941TprvDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.tipoproveedor:[seudo value changed for attri]"+"TprvDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1941TprvDsc);
                  GXUtil.WriteLogRaw("Current: ",T005Z2_A1941TprvDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1940TprvAbr, T005Z2_A1940TprvAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.tipoproveedor:[seudo value changed for attri]"+"TprvAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1940TprvAbr);
                  GXUtil.WriteLogRaw("Current: ",T005Z2_A1940TprvAbr[0]);
               }
               if ( Z1942TprvSts != T005Z2_A1942TprvSts[0] )
               {
                  GXUtil.WriteLog("configuracion.tipoproveedor:[seudo value changed for attri]"+"TprvSts");
                  GXUtil.WriteLogRaw("Old: ",Z1942TprvSts);
                  GXUtil.WriteLogRaw("Current: ",T005Z2_A1942TprvSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CTIPOPROVEEDOR"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5Z133( )
      {
         BeforeValidate5Z133( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5Z133( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5Z133( 0) ;
            CheckOptimisticConcurrency5Z133( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5Z133( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5Z133( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005Z8 */
                     pr_default.execute(6, new Object[] {A298TprvCod, A1941TprvDsc, A1940TprvAbr, A1942TprvSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPOPROVEEDOR");
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
                           ResetCaption5Z0( ) ;
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
               Load5Z133( ) ;
            }
            EndLevel5Z133( ) ;
         }
         CloseExtendedTableCursors5Z133( ) ;
      }

      protected void Update5Z133( )
      {
         BeforeValidate5Z133( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5Z133( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5Z133( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5Z133( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5Z133( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005Z9 */
                     pr_default.execute(7, new Object[] {A1941TprvDsc, A1940TprvAbr, A1942TprvSts, A298TprvCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPOPROVEEDOR");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPOPROVEEDOR"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5Z133( ) ;
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
            EndLevel5Z133( ) ;
         }
         CloseExtendedTableCursors5Z133( ) ;
      }

      protected void DeferredUpdate5Z133( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5Z133( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5Z133( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5Z133( ) ;
            AfterConfirm5Z133( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5Z133( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005Z10 */
                  pr_default.execute(8, new Object[] {A298TprvCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CTIPOPROVEEDOR");
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
         sMode133 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5Z133( ) ;
         Gx_mode = sMode133;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5Z133( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T005Z11 */
            pr_default.execute(9, new Object[] {A298TprvCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Datos Generales Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel5Z133( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5Z133( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.tipoproveedor",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5Z0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.tipoproveedor",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5Z133( )
      {
         /* Scan By routine */
         /* Using cursor T005Z12 */
         pr_default.execute(10);
         RcdFound133 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound133 = 1;
            A298TprvCod = T005Z12_A298TprvCod[0];
            AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5Z133( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound133 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound133 = 1;
            A298TprvCod = T005Z12_A298TprvCod[0];
            AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
         }
      }

      protected void ScanEnd5Z133( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm5Z133( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cTprvCod;
            GXt_char3 = "TPROVEEDOR";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cTprvCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cTprvCod", StringUtil.LTrimStr( (decimal)(AV13cTprvCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A298TprvCod = AV13cTprvCod;
            AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
         }
      }

      protected void BeforeInsert5Z133( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5Z133( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5Z133( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5Z133( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5Z133( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5Z133( )
      {
         edtTprvDsc_Enabled = 0;
         AssignProp("", false, edtTprvDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTprvDsc_Enabled), 5, 0), true);
         edtTprvAbr_Enabled = 0;
         AssignProp("", false, edtTprvAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTprvAbr_Enabled), 5, 0), true);
         cmbTprvSts.Enabled = 0;
         AssignProp("", false, cmbTprvSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTprvSts.Enabled), 5, 0), true);
         edtTprvCod_Enabled = 0;
         AssignProp("", false, edtTprvCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTprvCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5Z133( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5Z0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810261894", false, true);
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
         GXEncryptionTmp = "configuracion.tipoproveedor.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TprvCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.tipoproveedor.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TipoProveedor");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\tipoproveedor:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z298TprvCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z298TprvCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1941TprvDsc", StringUtil.RTrim( Z1941TprvDsc));
         GxWebStd.gx_hidden_field( context, "Z1940TprvAbr", StringUtil.RTrim( Z1940TprvAbr));
         GxWebStd.gx_hidden_field( context, "Z1942TprvSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1942TprvSts), 1, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vTPRVCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TprvCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTPRVCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TprvCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCTPRVCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cTprvCod), 6, 0, ".", "")));
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
         GXEncryptionTmp = "configuracion.tipoproveedor.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TprvCod,6,0));
         return formatLink("configuracion.tipoproveedor.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.TipoProveedor" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo Proveedor" ;
      }

      protected void InitializeNonKey5Z133( )
      {
         AV13cTprvCod = 0;
         AssignAttri("", false, "AV13cTprvCod", StringUtil.LTrimStr( (decimal)(AV13cTprvCod), 6, 0));
         A1941TprvDsc = "";
         AssignAttri("", false, "A1941TprvDsc", A1941TprvDsc);
         A1940TprvAbr = "";
         AssignAttri("", false, "A1940TprvAbr", A1940TprvAbr);
         A1942TprvSts = 1;
         AssignAttri("", false, "A1942TprvSts", StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
         Z1941TprvDsc = "";
         Z1940TprvAbr = "";
         Z1942TprvSts = 0;
      }

      protected void InitAll5Z133( )
      {
         A298TprvCod = 0;
         AssignAttri("", false, "A298TprvCod", StringUtil.LTrimStr( (decimal)(A298TprvCod), 6, 0));
         InitializeNonKey5Z133( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1942TprvSts = i1942TprvSts;
         AssignAttri("", false, "A1942TprvSts", StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810261911", true, true);
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
         context.AddJavascriptSource("configuracion/tipoproveedor.js", "?202281810261912", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtTprvDsc_Internalname = "TPRVDSC";
         edtTprvAbr_Internalname = "TPRVABR";
         cmbTprvSts_Internalname = "TPRVSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtTprvCod_Internalname = "TPRVCOD";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
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
         Form.Caption = "Tipo Proveedor";
         edtTprvCod_Jsonclick = "";
         edtTprvCod_Enabled = 1;
         edtTprvCod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbTprvSts_Jsonclick = "";
         cmbTprvSts.Enabled = 1;
         edtTprvAbr_Jsonclick = "";
         edtTprvAbr_Enabled = 1;
         edtTprvDsc_Jsonclick = "";
         edtTprvDsc_Enabled = 1;
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

      protected void GX4ASACTPRVCOD5Z133( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cTprvCod;
            GXt_char3 = "TPROVEEDOR";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cTprvCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cTprvCod", StringUtil.LTrimStr( (decimal)(AV13cTprvCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cTprvCod), 6, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         cmbTprvSts.Name = "TPRVSTS";
         cmbTprvSts.WebTags = "";
         cmbTprvSts.addItem("1", "ACTIVO", 0);
         cmbTprvSts.addItem("0", "INACTIVO", 0);
         if ( cmbTprvSts.ItemCount > 0 )
         {
            if ( (0==A1942TprvSts) )
            {
               A1942TprvSts = 1;
               AssignAttri("", false, "A1942TprvSts", StringUtil.Str( (decimal)(A1942TprvSts), 1, 0));
            }
         }
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7TprvCod',fld:'vTPRVCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7TprvCod',fld:'vTPRVCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E125Z2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A298TprvCod',fld:'TPRVCOD',pic:'ZZZZZ9'},{av:'A1941TprvDsc',fld:'TPRVDSC',pic:''},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_TPRVDSC","{handler:'Valid_Tprvdsc',iparms:[]");
         setEventMetadata("VALID_TPRVDSC",",oparms:[]}");
         setEventMetadata("VALID_TPRVCOD","{handler:'Valid_Tprvcod',iparms:[]");
         setEventMetadata("VALID_TPRVCOD",",oparms:[]}");
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
         Z1941TprvDsc = "";
         Z1940TprvAbr = "";
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
         A1941TprvDsc = "";
         A1940TprvAbr = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode133 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV10WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14SGAuDocGls = "";
         AV15Codigo = "";
         GXt_char1 = "";
         GXt_char2 = "";
         T005Z4_A298TprvCod = new int[1] ;
         T005Z4_A1941TprvDsc = new string[] {""} ;
         T005Z4_A1940TprvAbr = new string[] {""} ;
         T005Z4_A1942TprvSts = new short[1] ;
         T005Z5_A298TprvCod = new int[1] ;
         T005Z3_A298TprvCod = new int[1] ;
         T005Z3_A1941TprvDsc = new string[] {""} ;
         T005Z3_A1940TprvAbr = new string[] {""} ;
         T005Z3_A1942TprvSts = new short[1] ;
         T005Z6_A298TprvCod = new int[1] ;
         T005Z7_A298TprvCod = new int[1] ;
         T005Z2_A298TprvCod = new int[1] ;
         T005Z2_A1941TprvDsc = new string[] {""} ;
         T005Z2_A1940TprvAbr = new string[] {""} ;
         T005Z2_A1942TprvSts = new short[1] ;
         T005Z11_A244PrvCod = new string[] {""} ;
         T005Z12_A298TprvCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipoproveedor__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipoproveedor__default(),
            new Object[][] {
                new Object[] {
               T005Z2_A298TprvCod, T005Z2_A1941TprvDsc, T005Z2_A1940TprvAbr, T005Z2_A1942TprvSts
               }
               , new Object[] {
               T005Z3_A298TprvCod, T005Z3_A1941TprvDsc, T005Z3_A1940TprvAbr, T005Z3_A1942TprvSts
               }
               , new Object[] {
               T005Z4_A298TprvCod, T005Z4_A1941TprvDsc, T005Z4_A1940TprvAbr, T005Z4_A1942TprvSts
               }
               , new Object[] {
               T005Z5_A298TprvCod
               }
               , new Object[] {
               T005Z6_A298TprvCod
               }
               , new Object[] {
               T005Z7_A298TprvCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005Z11_A244PrvCod
               }
               , new Object[] {
               T005Z12_A298TprvCod
               }
            }
         );
         Z1942TprvSts = 1;
         A1942TprvSts = 1;
         i1942TprvSts = 1;
      }

      private short Z1942TprvSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1942TprvSts ;
      private short Gx_BScreen ;
      private short RcdFound133 ;
      private short GX_JID ;
      private short nIsDirty_133 ;
      private short gxajaxcallmode ;
      private short i1942TprvSts ;
      private int wcpOAV7TprvCod ;
      private int Z298TprvCod ;
      private int AV7TprvCod ;
      private int trnEnded ;
      private int edtTprvDsc_Enabled ;
      private int edtTprvAbr_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A298TprvCod ;
      private int edtTprvCod_Visible ;
      private int edtTprvCod_Enabled ;
      private int AV13cTprvCod ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int4 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z1941TprvDsc ;
      private string Z1940TprvAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTprvDsc_Internalname ;
      private string cmbTprvSts_Internalname ;
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
      private string A1941TprvDsc ;
      private string edtTprvDsc_Jsonclick ;
      private string edtTprvAbr_Internalname ;
      private string A1940TprvAbr ;
      private string edtTprvAbr_Jsonclick ;
      private string cmbTprvSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtTprvCod_Internalname ;
      private string edtTprvCod_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode133 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char1 ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string GXt_char3 ;
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
      private string AV14SGAuDocGls ;
      private string AV15Codigo ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTprvSts ;
      private IDataStoreProvider pr_default ;
      private int[] T005Z4_A298TprvCod ;
      private string[] T005Z4_A1941TprvDsc ;
      private string[] T005Z4_A1940TprvAbr ;
      private short[] T005Z4_A1942TprvSts ;
      private int[] T005Z5_A298TprvCod ;
      private int[] T005Z3_A298TprvCod ;
      private string[] T005Z3_A1941TprvDsc ;
      private string[] T005Z3_A1940TprvAbr ;
      private short[] T005Z3_A1942TprvSts ;
      private int[] T005Z6_A298TprvCod ;
      private int[] T005Z7_A298TprvCod ;
      private int[] T005Z2_A298TprvCod ;
      private string[] T005Z2_A1941TprvDsc ;
      private string[] T005Z2_A1940TprvAbr ;
      private short[] T005Z2_A1942TprvSts ;
      private string[] T005Z11_A244PrvCod ;
      private int[] T005Z12_A298TprvCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
   }

   public class tipoproveedor__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tipoproveedor__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005Z4;
        prmT005Z4 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT005Z5;
        prmT005Z5 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT005Z3;
        prmT005Z3 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT005Z6;
        prmT005Z6 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT005Z7;
        prmT005Z7 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT005Z2;
        prmT005Z2 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT005Z8;
        prmT005Z8 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0) ,
        new ParDef("@TprvDsc",GXType.NChar,100,0) ,
        new ParDef("@TprvAbr",GXType.NChar,5,0) ,
        new ParDef("@TprvSts",GXType.Int16,1,0)
        };
        Object[] prmT005Z9;
        prmT005Z9 = new Object[] {
        new ParDef("@TprvDsc",GXType.NChar,100,0) ,
        new ParDef("@TprvAbr",GXType.NChar,5,0) ,
        new ParDef("@TprvSts",GXType.Int16,1,0) ,
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT005Z10;
        prmT005Z10 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT005Z11;
        prmT005Z11 = new Object[] {
        new ParDef("@TprvCod",GXType.Int32,6,0)
        };
        Object[] prmT005Z12;
        prmT005Z12 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T005Z2", "SELECT [TprvCod], [TprvDsc], [TprvAbr], [TprvSts] FROM [CTIPOPROVEEDOR] WITH (UPDLOCK) WHERE [TprvCod] = @TprvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005Z2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005Z3", "SELECT [TprvCod], [TprvDsc], [TprvAbr], [TprvSts] FROM [CTIPOPROVEEDOR] WHERE [TprvCod] = @TprvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005Z3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005Z4", "SELECT TM1.[TprvCod], TM1.[TprvDsc], TM1.[TprvAbr], TM1.[TprvSts] FROM [CTIPOPROVEEDOR] TM1 WHERE TM1.[TprvCod] = @TprvCod ORDER BY TM1.[TprvCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005Z4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005Z5", "SELECT [TprvCod] FROM [CTIPOPROVEEDOR] WHERE [TprvCod] = @TprvCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005Z5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005Z6", "SELECT TOP 1 [TprvCod] FROM [CTIPOPROVEEDOR] WHERE ( [TprvCod] > @TprvCod) ORDER BY [TprvCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005Z6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005Z7", "SELECT TOP 1 [TprvCod] FROM [CTIPOPROVEEDOR] WHERE ( [TprvCod] < @TprvCod) ORDER BY [TprvCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005Z7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005Z8", "INSERT INTO [CTIPOPROVEEDOR]([TprvCod], [TprvDsc], [TprvAbr], [TprvSts]) VALUES(@TprvCod, @TprvDsc, @TprvAbr, @TprvSts)", GxErrorMask.GX_NOMASK,prmT005Z8)
           ,new CursorDef("T005Z9", "UPDATE [CTIPOPROVEEDOR] SET [TprvDsc]=@TprvDsc, [TprvAbr]=@TprvAbr, [TprvSts]=@TprvSts  WHERE [TprvCod] = @TprvCod", GxErrorMask.GX_NOMASK,prmT005Z9)
           ,new CursorDef("T005Z10", "DELETE FROM [CTIPOPROVEEDOR]  WHERE [TprvCod] = @TprvCod", GxErrorMask.GX_NOMASK,prmT005Z10)
           ,new CursorDef("T005Z11", "SELECT TOP 1 [PrvCod] FROM [CPPROVEEDORES] WHERE [TprvCod] = @TprvCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005Z11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005Z12", "SELECT [TprvCod] FROM [CTIPOPROVEEDOR] ORDER BY [TprvCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005Z12,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 3 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
