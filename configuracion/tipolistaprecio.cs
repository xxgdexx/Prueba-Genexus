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
   public class tipolistaprecio : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vCTIPLCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASACTIPLCOD62134( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.tipolistaprecio.aspx")), "configuracion.tipolistaprecio.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.tipolistaprecio.aspx")))) ;
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
                  AV7TipLCod = (int)(NumberUtil.Val( GetPar( "TipLCod"), "."));
                  AssignAttri("", false, "AV7TipLCod", StringUtil.LTrimStr( (decimal)(AV7TipLCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTIPLCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TipLCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Tipos de Listas de Precios", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTipLDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public tipolistaprecio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public tipolistaprecio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_TipLCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TipLCod = aP1_TipLCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTipLSts = new GXCombobox();
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
         if ( cmbTipLSts.ItemCount > 0 )
         {
            A1914TipLSts = (short)(NumberUtil.Val( cmbTipLSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1914TipLSts), 1, 0))), "."));
            AssignAttri("", false, "A1914TipLSts", StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTipLSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
            AssignProp("", false, cmbTipLSts_Internalname, "Values", cmbTipLSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipLDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipLDsc_Internalname, "Tipo de Lista", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipLDsc_Internalname, StringUtil.RTrim( A1912TipLDsc), StringUtil.RTrim( context.localUtil.Format( A1912TipLDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipLDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtTipLDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoListaPrecio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTipLAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTipLAbr_Internalname, "Abreviatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTipLAbr_Internalname, StringUtil.RTrim( A1911TipLAbr), StringUtil.RTrim( context.localUtil.Format( A1911TipLAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipLAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTipLAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\TipoListaPrecio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbTipLSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTipLSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTipLSts, cmbTipLSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1914TipLSts), 1, 0)), 1, cmbTipLSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTipLSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 1, "HLP_Configuracion\\TipoListaPrecio.htm");
         cmbTipLSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
         AssignProp("", false, cmbTipLSts_Internalname, "Values", (string)(cmbTipLSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoListaPrecio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoListaPrecio.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\TipoListaPrecio.htm");
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
         GxWebStd.gx_single_line_edit( context, edtTipLCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A202TipLCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A202TipLCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTipLCod_Jsonclick, 0, "Attribute", "", "", "", "", edtTipLCod_Visible, edtTipLCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\TipoListaPrecio.htm");
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
         E11622 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z202TipLCod = (int)(context.localUtil.CToN( cgiGet( "Z202TipLCod"), ".", ","));
               Z1912TipLDsc = cgiGet( "Z1912TipLDsc");
               Z1911TipLAbr = cgiGet( "Z1911TipLAbr");
               Z1914TipLSts = (short)(context.localUtil.CToN( cgiGet( "Z1914TipLSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7TipLCod = (int)(context.localUtil.CToN( cgiGet( "vTIPLCOD"), ".", ","));
               AV13cTipLCod = (int)(context.localUtil.CToN( cgiGet( "vCTIPLCOD"), ".", ","));
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
               A1912TipLDsc = cgiGet( edtTipLDsc_Internalname);
               AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
               A1911TipLAbr = cgiGet( edtTipLAbr_Internalname);
               AssignAttri("", false, "A1911TipLAbr", A1911TipLAbr);
               cmbTipLSts.CurrentValue = cgiGet( cmbTipLSts_Internalname);
               A1914TipLSts = (short)(NumberUtil.Val( cgiGet( cmbTipLSts_Internalname), "."));
               AssignAttri("", false, "A1914TipLSts", StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtTipLCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTipLCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "TIPLCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipLCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A202TipLCod = 0;
                  AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
               }
               else
               {
                  A202TipLCod = (int)(context.localUtil.CToN( cgiGet( edtTipLCod_Internalname), ".", ","));
                  AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TipoListaPrecio");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A202TipLCod != Z202TipLCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\tipolistaprecio:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A202TipLCod = (int)(NumberUtil.Val( GetPar( "TipLCod"), "."));
                  AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
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
                     sMode134 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode134;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound134 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_620( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TIPLCOD");
                        AnyError = 1;
                        GX_FocusControl = edtTipLCod_Internalname;
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
                           E11622 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12622 ();
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
            E12622 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll62134( ) ;
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
            DisableAttributes62134( ) ;
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

      protected void CONFIRM_620( )
      {
         BeforeValidate62134( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls62134( ) ;
            }
            else
            {
               CheckExtendedTable62134( ) ;
               CloseExtendedTableCursors62134( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption620( )
      {
      }

      protected void E11622( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtTipLCod_Visible = 0;
         AssignProp("", false, edtTipLCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTipLCod_Visible), 5, 0), true);
      }

      protected void E12622( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV14SGAuDocGls = "Tipo de Lista de Precios N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A202TipLCod), 10, 0)) + " " + StringUtil.Trim( A1912TipLDsc);
            AV15Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A202TipLCod), 10, 0));
            GXt_char1 = "CNF";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV14SGAuDocGls, ref  AV15Codigo, ref  AV15Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.tipolistaprecioww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM62134( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1912TipLDsc = T00623_A1912TipLDsc[0];
               Z1911TipLAbr = T00623_A1911TipLAbr[0];
               Z1914TipLSts = T00623_A1914TipLSts[0];
            }
            else
            {
               Z1912TipLDsc = A1912TipLDsc;
               Z1911TipLAbr = A1911TipLAbr;
               Z1914TipLSts = A1914TipLSts;
            }
         }
         if ( GX_JID == -8 )
         {
            Z202TipLCod = A202TipLCod;
            Z1912TipLDsc = A1912TipLDsc;
            Z1911TipLAbr = A1911TipLAbr;
            Z1914TipLSts = A1914TipLSts;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TipLCod) )
         {
            A202TipLCod = AV7TipLCod;
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
         }
         if ( ! (0==AV7TipLCod) )
         {
            edtTipLCod_Enabled = 0;
            AssignProp("", false, edtTipLCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLCod_Enabled), 5, 0), true);
         }
         else
         {
            edtTipLCod_Enabled = 1;
            AssignProp("", false, edtTipLCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7TipLCod) )
         {
            edtTipLCod_Enabled = 0;
            AssignProp("", false, edtTipLCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A1914TipLSts) && ( Gx_BScreen == 0 ) )
         {
            A1914TipLSts = 1;
            AssignAttri("", false, "A1914TipLSts", StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
         }
      }

      protected void Load62134( )
      {
         /* Using cursor T00624 */
         pr_default.execute(2, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound134 = 1;
            A1912TipLDsc = T00624_A1912TipLDsc[0];
            AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
            A1911TipLAbr = T00624_A1911TipLAbr[0];
            AssignAttri("", false, "A1911TipLAbr", A1911TipLAbr);
            A1914TipLSts = T00624_A1914TipLSts[0];
            AssignAttri("", false, "A1914TipLSts", StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
            ZM62134( -8) ;
         }
         pr_default.close(2);
         OnLoadActions62134( ) ;
      }

      protected void OnLoadActions62134( )
      {
      }

      protected void CheckExtendedTable62134( )
      {
         nIsDirty_134 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1912TipLDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Tipo de Lista", "", "", "", "", "", "", "", ""), 1, "TIPLDSC");
            AnyError = 1;
            GX_FocusControl = edtTipLDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors62134( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey62134( )
      {
         /* Using cursor T00625 */
         pr_default.execute(3, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound134 = 1;
         }
         else
         {
            RcdFound134 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00623 */
         pr_default.execute(1, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM62134( 8) ;
            RcdFound134 = 1;
            A202TipLCod = T00623_A202TipLCod[0];
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            A1912TipLDsc = T00623_A1912TipLDsc[0];
            AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
            A1911TipLAbr = T00623_A1911TipLAbr[0];
            AssignAttri("", false, "A1911TipLAbr", A1911TipLAbr);
            A1914TipLSts = T00623_A1914TipLSts[0];
            AssignAttri("", false, "A1914TipLSts", StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
            Z202TipLCod = A202TipLCod;
            sMode134 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load62134( ) ;
            if ( AnyError == 1 )
            {
               RcdFound134 = 0;
               InitializeNonKey62134( ) ;
            }
            Gx_mode = sMode134;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound134 = 0;
            InitializeNonKey62134( ) ;
            sMode134 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode134;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey62134( ) ;
         if ( RcdFound134 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound134 = 0;
         /* Using cursor T00626 */
         pr_default.execute(4, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00626_A202TipLCod[0] < A202TipLCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00626_A202TipLCod[0] > A202TipLCod ) ) )
            {
               A202TipLCod = T00626_A202TipLCod[0];
               AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
               RcdFound134 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound134 = 0;
         /* Using cursor T00627 */
         pr_default.execute(5, new Object[] {A202TipLCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00627_A202TipLCod[0] > A202TipLCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00627_A202TipLCod[0] < A202TipLCod ) ) )
            {
               A202TipLCod = T00627_A202TipLCod[0];
               AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
               RcdFound134 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey62134( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTipLDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert62134( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound134 == 1 )
            {
               if ( A202TipLCod != Z202TipLCod )
               {
                  A202TipLCod = Z202TipLCod;
                  AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIPLCOD");
                  AnyError = 1;
                  GX_FocusControl = edtTipLCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTipLDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update62134( ) ;
                  GX_FocusControl = edtTipLDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A202TipLCod != Z202TipLCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtTipLDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert62134( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIPLCOD");
                     AnyError = 1;
                     GX_FocusControl = edtTipLCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTipLDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert62134( ) ;
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
         if ( A202TipLCod != Z202TipLCod )
         {
            A202TipLCod = Z202TipLCod;
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIPLCOD");
            AnyError = 1;
            GX_FocusControl = edtTipLCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTipLDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency62134( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00622 */
            pr_default.execute(0, new Object[] {A202TipLCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPOSLISTAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1912TipLDsc, T00622_A1912TipLDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1911TipLAbr, T00622_A1911TipLAbr[0]) != 0 ) || ( Z1914TipLSts != T00622_A1914TipLSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1912TipLDsc, T00622_A1912TipLDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.tipolistaprecio:[seudo value changed for attri]"+"TipLDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1912TipLDsc);
                  GXUtil.WriteLogRaw("Current: ",T00622_A1912TipLDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1911TipLAbr, T00622_A1911TipLAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.tipolistaprecio:[seudo value changed for attri]"+"TipLAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1911TipLAbr);
                  GXUtil.WriteLogRaw("Current: ",T00622_A1911TipLAbr[0]);
               }
               if ( Z1914TipLSts != T00622_A1914TipLSts[0] )
               {
                  GXUtil.WriteLog("configuracion.tipolistaprecio:[seudo value changed for attri]"+"TipLSts");
                  GXUtil.WriteLogRaw("Old: ",Z1914TipLSts);
                  GXUtil.WriteLogRaw("Current: ",T00622_A1914TipLSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CTIPOSLISTAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert62134( )
      {
         BeforeValidate62134( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable62134( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM62134( 0) ;
            CheckOptimisticConcurrency62134( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm62134( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert62134( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00628 */
                     pr_default.execute(6, new Object[] {A202TipLCod, A1912TipLDsc, A1911TipLAbr, A1914TipLSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPOSLISTAS");
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
                           ResetCaption620( ) ;
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
               Load62134( ) ;
            }
            EndLevel62134( ) ;
         }
         CloseExtendedTableCursors62134( ) ;
      }

      protected void Update62134( )
      {
         BeforeValidate62134( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable62134( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency62134( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm62134( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate62134( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00629 */
                     pr_default.execute(7, new Object[] {A1912TipLDsc, A1911TipLAbr, A1914TipLSts, A202TipLCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CTIPOSLISTAS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CTIPOSLISTAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate62134( ) ;
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
            EndLevel62134( ) ;
         }
         CloseExtendedTableCursors62134( ) ;
      }

      protected void DeferredUpdate62134( )
      {
      }

      protected void delete( )
      {
         BeforeValidate62134( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency62134( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls62134( ) ;
            AfterConfirm62134( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete62134( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006210 */
                  pr_default.execute(8, new Object[] {A202TipLCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CTIPOSLISTAS");
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
         sMode134 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel62134( ) ;
         Gx_mode = sMode134;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls62134( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T006211 */
            pr_default.execute(9, new Object[] {A202TipLCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T006212 */
            pr_default.execute(10, new Object[] {A202TipLCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T006213 */
            pr_default.execute(11, new Object[] {A202TipLCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Lista de Precios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T006214 */
            pr_default.execute(12, new Object[] {A202TipLCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T006215 */
            pr_default.execute(13, new Object[] {A202TipLCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Maestros de Clientes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel62134( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete62134( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.tipolistaprecio",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues620( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.tipolistaprecio",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart62134( )
      {
         /* Scan By routine */
         /* Using cursor T006216 */
         pr_default.execute(14);
         RcdFound134 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound134 = 1;
            A202TipLCod = T006216_A202TipLCod[0];
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext62134( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound134 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound134 = 1;
            A202TipLCod = T006216_A202TipLCod[0];
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
         }
      }

      protected void ScanEnd62134( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm62134( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cTipLCod;
            GXt_char3 = "TLISTAS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cTipLCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cTipLCod", StringUtil.LTrimStr( (decimal)(AV13cTipLCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A202TipLCod = AV13cTipLCod;
            AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
         }
      }

      protected void BeforeInsert62134( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate62134( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete62134( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete62134( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate62134( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes62134( )
      {
         edtTipLDsc_Enabled = 0;
         AssignProp("", false, edtTipLDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLDsc_Enabled), 5, 0), true);
         edtTipLAbr_Enabled = 0;
         AssignProp("", false, edtTipLAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLAbr_Enabled), 5, 0), true);
         cmbTipLSts.Enabled = 0;
         AssignProp("", false, cmbTipLSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTipLSts.Enabled), 5, 0), true);
         edtTipLCod_Enabled = 0;
         AssignProp("", false, edtTipLCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTipLCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes62134( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues620( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810262099", false, true);
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
         GXEncryptionTmp = "configuracion.tipolistaprecio.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TipLCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.tipolistaprecio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TipoListaPrecio");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\tipolistaprecio:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z202TipLCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z202TipLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1912TipLDsc", StringUtil.RTrim( Z1912TipLDsc));
         GxWebStd.gx_hidden_field( context, "Z1911TipLAbr", StringUtil.RTrim( Z1911TipLAbr));
         GxWebStd.gx_hidden_field( context, "Z1914TipLSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1914TipLSts), 1, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vTIPLCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TipLCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTIPLCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TipLCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCTIPLCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cTipLCod), 6, 0, ".", "")));
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
         GXEncryptionTmp = "configuracion.tipolistaprecio.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TipLCod,6,0));
         return formatLink("configuracion.tipolistaprecio.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.TipoListaPrecio" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipos de Listas de Precios" ;
      }

      protected void InitializeNonKey62134( )
      {
         AV13cTipLCod = 0;
         AssignAttri("", false, "AV13cTipLCod", StringUtil.LTrimStr( (decimal)(AV13cTipLCod), 6, 0));
         A1912TipLDsc = "";
         AssignAttri("", false, "A1912TipLDsc", A1912TipLDsc);
         A1911TipLAbr = "";
         AssignAttri("", false, "A1911TipLAbr", A1911TipLAbr);
         A1914TipLSts = 1;
         AssignAttri("", false, "A1914TipLSts", StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
         Z1912TipLDsc = "";
         Z1911TipLAbr = "";
         Z1914TipLSts = 0;
      }

      protected void InitAll62134( )
      {
         A202TipLCod = 0;
         AssignAttri("", false, "A202TipLCod", StringUtil.LTrimStr( (decimal)(A202TipLCod), 6, 0));
         InitializeNonKey62134( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1914TipLSts = i1914TipLSts;
         AssignAttri("", false, "A1914TipLSts", StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810262116", true, true);
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
         context.AddJavascriptSource("configuracion/tipolistaprecio.js", "?202281810262117", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtTipLDsc_Internalname = "TIPLDSC";
         edtTipLAbr_Internalname = "TIPLABR";
         cmbTipLSts_Internalname = "TIPLSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtTipLCod_Internalname = "TIPLCOD";
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
         Form.Caption = "Tipos de Listas de Precios";
         edtTipLCod_Jsonclick = "";
         edtTipLCod_Enabled = 1;
         edtTipLCod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbTipLSts_Jsonclick = "";
         cmbTipLSts.Enabled = 1;
         edtTipLAbr_Jsonclick = "";
         edtTipLAbr_Enabled = 1;
         edtTipLDsc_Jsonclick = "";
         edtTipLDsc_Enabled = 1;
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

      protected void GX4ASACTIPLCOD62134( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cTipLCod;
            GXt_char3 = "TLISTAS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cTipLCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cTipLCod", StringUtil.LTrimStr( (decimal)(AV13cTipLCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cTipLCod), 6, 0, ".", "")))+"\"") ;
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
         cmbTipLSts.Name = "TIPLSTS";
         cmbTipLSts.WebTags = "";
         cmbTipLSts.addItem("1", "ACTIVO", 0);
         cmbTipLSts.addItem("0", "INACTIVO", 0);
         if ( cmbTipLSts.ItemCount > 0 )
         {
            if ( (0==A1914TipLSts) )
            {
               A1914TipLSts = 1;
               AssignAttri("", false, "A1914TipLSts", StringUtil.Str( (decimal)(A1914TipLSts), 1, 0));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7TipLCod',fld:'vTIPLCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7TipLCod',fld:'vTIPLCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12622',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A202TipLCod',fld:'TIPLCOD',pic:'ZZZZZ9'},{av:'A1912TipLDsc',fld:'TIPLDSC',pic:''},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_TIPLDSC","{handler:'Valid_Tipldsc',iparms:[]");
         setEventMetadata("VALID_TIPLDSC",",oparms:[]}");
         setEventMetadata("VALID_TIPLCOD","{handler:'Valid_Tiplcod',iparms:[]");
         setEventMetadata("VALID_TIPLCOD",",oparms:[]}");
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
         Z1912TipLDsc = "";
         Z1911TipLAbr = "";
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
         A1912TipLDsc = "";
         A1911TipLAbr = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode134 = "";
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
         T00624_A202TipLCod = new int[1] ;
         T00624_A1912TipLDsc = new string[] {""} ;
         T00624_A1911TipLAbr = new string[] {""} ;
         T00624_A1914TipLSts = new short[1] ;
         T00625_A202TipLCod = new int[1] ;
         T00623_A202TipLCod = new int[1] ;
         T00623_A1912TipLDsc = new string[] {""} ;
         T00623_A1911TipLAbr = new string[] {""} ;
         T00623_A1914TipLSts = new short[1] ;
         T00626_A202TipLCod = new int[1] ;
         T00627_A202TipLCod = new int[1] ;
         T00622_A202TipLCod = new int[1] ;
         T00622_A1912TipLDsc = new string[] {""} ;
         T00622_A1911TipLAbr = new string[] {""} ;
         T00622_A1914TipLSts = new short[1] ;
         T006211_A149TipCod = new string[] {""} ;
         T006211_A24DocNum = new string[] {""} ;
         T006212_A210PedCod = new string[] {""} ;
         T006213_A202TipLCod = new int[1] ;
         T006213_A203TipLItem = new int[1] ;
         T006214_A177CotCod = new string[] {""} ;
         T006215_A45CliCod = new string[] {""} ;
         T006216_A202TipLCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipolistaprecio__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.tipolistaprecio__default(),
            new Object[][] {
                new Object[] {
               T00622_A202TipLCod, T00622_A1912TipLDsc, T00622_A1911TipLAbr, T00622_A1914TipLSts
               }
               , new Object[] {
               T00623_A202TipLCod, T00623_A1912TipLDsc, T00623_A1911TipLAbr, T00623_A1914TipLSts
               }
               , new Object[] {
               T00624_A202TipLCod, T00624_A1912TipLDsc, T00624_A1911TipLAbr, T00624_A1914TipLSts
               }
               , new Object[] {
               T00625_A202TipLCod
               }
               , new Object[] {
               T00626_A202TipLCod
               }
               , new Object[] {
               T00627_A202TipLCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006211_A149TipCod, T006211_A24DocNum
               }
               , new Object[] {
               T006212_A210PedCod
               }
               , new Object[] {
               T006213_A202TipLCod, T006213_A203TipLItem
               }
               , new Object[] {
               T006214_A177CotCod
               }
               , new Object[] {
               T006215_A45CliCod
               }
               , new Object[] {
               T006216_A202TipLCod
               }
            }
         );
         Z1914TipLSts = 1;
         A1914TipLSts = 1;
         i1914TipLSts = 1;
      }

      private short Z1914TipLSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1914TipLSts ;
      private short Gx_BScreen ;
      private short RcdFound134 ;
      private short GX_JID ;
      private short nIsDirty_134 ;
      private short gxajaxcallmode ;
      private short i1914TipLSts ;
      private int wcpOAV7TipLCod ;
      private int Z202TipLCod ;
      private int AV7TipLCod ;
      private int trnEnded ;
      private int edtTipLDsc_Enabled ;
      private int edtTipLAbr_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A202TipLCod ;
      private int edtTipLCod_Visible ;
      private int edtTipLCod_Enabled ;
      private int AV13cTipLCod ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int4 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z1912TipLDsc ;
      private string Z1911TipLAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTipLDsc_Internalname ;
      private string cmbTipLSts_Internalname ;
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
      private string A1912TipLDsc ;
      private string edtTipLDsc_Jsonclick ;
      private string edtTipLAbr_Internalname ;
      private string A1911TipLAbr ;
      private string edtTipLAbr_Jsonclick ;
      private string cmbTipLSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtTipLCod_Internalname ;
      private string edtTipLCod_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode134 ;
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
      private GXCombobox cmbTipLSts ;
      private IDataStoreProvider pr_default ;
      private int[] T00624_A202TipLCod ;
      private string[] T00624_A1912TipLDsc ;
      private string[] T00624_A1911TipLAbr ;
      private short[] T00624_A1914TipLSts ;
      private int[] T00625_A202TipLCod ;
      private int[] T00623_A202TipLCod ;
      private string[] T00623_A1912TipLDsc ;
      private string[] T00623_A1911TipLAbr ;
      private short[] T00623_A1914TipLSts ;
      private int[] T00626_A202TipLCod ;
      private int[] T00627_A202TipLCod ;
      private int[] T00622_A202TipLCod ;
      private string[] T00622_A1912TipLDsc ;
      private string[] T00622_A1911TipLAbr ;
      private short[] T00622_A1914TipLSts ;
      private string[] T006211_A149TipCod ;
      private string[] T006211_A24DocNum ;
      private string[] T006212_A210PedCod ;
      private int[] T006213_A202TipLCod ;
      private int[] T006213_A203TipLItem ;
      private string[] T006214_A177CotCod ;
      private string[] T006215_A45CliCod ;
      private int[] T006216_A202TipLCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
   }

   public class tipolistaprecio__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class tipolistaprecio__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00624;
        prmT00624 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT00625;
        prmT00625 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT00623;
        prmT00623 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT00626;
        prmT00626 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT00627;
        prmT00627 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT00622;
        prmT00622 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT00628;
        prmT00628 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0) ,
        new ParDef("@TipLDsc",GXType.NChar,100,0) ,
        new ParDef("@TipLAbr",GXType.NChar,5,0) ,
        new ParDef("@TipLSts",GXType.Int16,1,0)
        };
        Object[] prmT00629;
        prmT00629 = new Object[] {
        new ParDef("@TipLDsc",GXType.NChar,100,0) ,
        new ParDef("@TipLAbr",GXType.NChar,5,0) ,
        new ParDef("@TipLSts",GXType.Int16,1,0) ,
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT006210;
        prmT006210 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT006211;
        prmT006211 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT006212;
        prmT006212 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT006213;
        prmT006213 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT006214;
        prmT006214 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT006215;
        prmT006215 = new Object[] {
        new ParDef("@TipLCod",GXType.Int32,6,0)
        };
        Object[] prmT006216;
        prmT006216 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00622", "SELECT [TipLCod], [TipLDsc], [TipLAbr], [TipLSts] FROM [CTIPOSLISTAS] WITH (UPDLOCK) WHERE [TipLCod] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00622,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00623", "SELECT [TipLCod], [TipLDsc], [TipLAbr], [TipLSts] FROM [CTIPOSLISTAS] WHERE [TipLCod] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00623,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00624", "SELECT TM1.[TipLCod], TM1.[TipLDsc], TM1.[TipLAbr], TM1.[TipLSts] FROM [CTIPOSLISTAS] TM1 WHERE TM1.[TipLCod] = @TipLCod ORDER BY TM1.[TipLCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00624,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00625", "SELECT [TipLCod] FROM [CTIPOSLISTAS] WHERE [TipLCod] = @TipLCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00625,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00626", "SELECT TOP 1 [TipLCod] FROM [CTIPOSLISTAS] WHERE ( [TipLCod] > @TipLCod) ORDER BY [TipLCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00626,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00627", "SELECT TOP 1 [TipLCod] FROM [CTIPOSLISTAS] WHERE ( [TipLCod] < @TipLCod) ORDER BY [TipLCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00627,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00628", "INSERT INTO [CTIPOSLISTAS]([TipLCod], [TipLDsc], [TipLAbr], [TipLSts]) VALUES(@TipLCod, @TipLDsc, @TipLAbr, @TipLSts)", GxErrorMask.GX_NOMASK,prmT00628)
           ,new CursorDef("T00629", "UPDATE [CTIPOSLISTAS] SET [TipLDsc]=@TipLDsc, [TipLAbr]=@TipLAbr, [TipLSts]=@TipLSts  WHERE [TipLCod] = @TipLCod", GxErrorMask.GX_NOMASK,prmT00629)
           ,new CursorDef("T006210", "DELETE FROM [CTIPOSLISTAS]  WHERE [TipLCod] = @TipLCod", GxErrorMask.GX_NOMASK,prmT006210)
           ,new CursorDef("T006211", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [DocLisp] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006211,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006212", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE [PedLisp] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006212,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006213", "SELECT TOP 1 [TipLCod], [TipLItem] FROM [CLISTAPRECIOS] WHERE [TipLCod] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006213,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006214", "SELECT TOP 1 [CotCod] FROM [CLCOTIZA] WHERE [CotLista] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006214,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006215", "SELECT TOP 1 [CliCod] FROM [CLCLIENTES] WHERE [CliTipLCod] = @TipLCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006215,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006216", "SELECT [TipLCod] FROM [CTIPOSLISTAS] ORDER BY [TipLCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006216,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
