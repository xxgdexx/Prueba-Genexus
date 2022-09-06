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
   public class locales : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vTIECOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASATIECOD0H18( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "seguridad.locales.aspx")), "seguridad.locales.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "seguridad.locales.aspx")))) ;
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
                  AV7TieCod = (int)(NumberUtil.Val( GetPar( "TieCod"), "."));
                  AssignAttri("", false, "AV7TieCod", StringUtil.LTrimStr( (decimal)(AV7TieCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vTIECOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TieCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Locales", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTieDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public locales( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public locales( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_TieCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TieCod = aP1_TieCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbTieSts = new GXCombobox();
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
         if ( cmbTieSts.ItemCount > 0 )
         {
            A1899TieSts = (short)(NumberUtil.Val( cmbTieSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A1899TieSts), 1, 0))), "."));
            AssignAttri("", false, "A1899TieSts", StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbTieSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
            AssignProp("", false, cmbTieSts_Internalname, "Values", cmbTieSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTieDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTieDsc_Internalname, "Local", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTieDsc_Internalname, StringUtil.RTrim( A1898TieDsc), StringUtil.RTrim( context.localUtil.Format( A1898TieDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTieDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtTieDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\Locales.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtTieAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTieAbr_Internalname, "Abreviatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTieAbr_Internalname, A1897TieAbr, StringUtil.RTrim( context.localUtil.Format( A1897TieAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTieAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtTieAbr_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Seguridad\\Locales.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbTieSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbTieSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbTieSts, cmbTieSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A1899TieSts), 1, 0)), 1, cmbTieSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbTieSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", true, 1, "HLP_Seguridad\\Locales.htm");
         cmbTieSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
         AssignProp("", false, cmbTieSts_Internalname, "Values", (string)(cmbTieSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\Locales.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\Locales.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Seguridad\\Locales.htm");
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
         GxWebStd.gx_single_line_edit( context, edtTieCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A178TieCod), 6, 0, ".", "")), StringUtil.LTrim( ((edtTieCod_Enabled!=0) ? context.localUtil.Format( (decimal)(A178TieCod), "ZZZZZ9") : context.localUtil.Format( (decimal)(A178TieCod), "ZZZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTieCod_Jsonclick, 0, "Attribute", "", "", "", "", edtTieCod_Visible, edtTieCod_Enabled, 0, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Seguridad\\Locales.htm");
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
         E110H2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z178TieCod = (int)(context.localUtil.CToN( cgiGet( "Z178TieCod"), ".", ","));
               Z1898TieDsc = cgiGet( "Z1898TieDsc");
               Z1897TieAbr = cgiGet( "Z1897TieAbr");
               Z1899TieSts = (short)(context.localUtil.CToN( cgiGet( "Z1899TieSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7TieCod = (int)(context.localUtil.CToN( cgiGet( "vTIECOD"), ".", ","));
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
               A1898TieDsc = cgiGet( edtTieDsc_Internalname);
               AssignAttri("", false, "A1898TieDsc", A1898TieDsc);
               A1897TieAbr = cgiGet( edtTieAbr_Internalname);
               AssignAttri("", false, "A1897TieAbr", A1897TieAbr);
               cmbTieSts.CurrentValue = cgiGet( cmbTieSts_Internalname);
               A1899TieSts = (short)(NumberUtil.Val( cgiGet( cmbTieSts_Internalname), "."));
               AssignAttri("", false, "A1899TieSts", StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
               A178TieCod = (int)(context.localUtil.CToN( cgiGet( edtTieCod_Internalname), ".", ","));
               n178TieCod = false;
               AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Locales");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A178TieCod != Z178TieCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("seguridad\\locales:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A178TieCod = (int)(NumberUtil.Val( GetPar( "TieCod"), "."));
                  n178TieCod = false;
                  AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
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
                     sMode18 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode18;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound18 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0H0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TIECOD");
                        AnyError = 1;
                        GX_FocusControl = edtTieCod_Internalname;
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
                           E110H2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120H2 ();
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
            E120H2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0H18( ) ;
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
            DisableAttributes0H18( ) ;
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

      protected void CONFIRM_0H0( )
      {
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0H18( ) ;
            }
            else
            {
               CheckExtendedTable0H18( ) ;
               CloseExtendedTableCursors0H18( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0H0( )
      {
      }

      protected void E110H2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         edtTieCod_Visible = 0;
         AssignProp("", false, edtTieCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTieCod_Visible), 5, 0), true);
      }

      protected void E120H2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("seguridad.localesww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0H18( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1898TieDsc = T000H3_A1898TieDsc[0];
               Z1897TieAbr = T000H3_A1897TieAbr[0];
               Z1899TieSts = T000H3_A1899TieSts[0];
            }
            else
            {
               Z1898TieDsc = A1898TieDsc;
               Z1897TieAbr = A1897TieAbr;
               Z1899TieSts = A1899TieSts;
            }
         }
         if ( GX_JID == -7 )
         {
            Z178TieCod = A178TieCod;
            Z1898TieDsc = A1898TieDsc;
            Z1897TieAbr = A1897TieAbr;
            Z1899TieSts = A1899TieSts;
         }
      }

      protected void standaloneNotModal( )
      {
         edtTieCod_Enabled = 0;
         AssignProp("", false, edtTieCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTieCod_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtTieCod_Enabled = 0;
         AssignProp("", false, edtTieCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTieCod_Enabled), 5, 0), true);
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7TieCod) )
         {
            A178TieCod = AV7TieCod;
            n178TieCod = false;
            AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
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
         if ( IsIns( )  && (0==A1899TieSts) && ( Gx_BScreen == 0 ) )
         {
            A1899TieSts = 1;
            AssignAttri("", false, "A1899TieSts", StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
         }
      }

      protected void Load0H18( )
      {
         /* Using cursor T000H4 */
         pr_default.execute(2, new Object[] {n178TieCod, A178TieCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound18 = 1;
            A1898TieDsc = T000H4_A1898TieDsc[0];
            AssignAttri("", false, "A1898TieDsc", A1898TieDsc);
            A1897TieAbr = T000H4_A1897TieAbr[0];
            AssignAttri("", false, "A1897TieAbr", A1897TieAbr);
            A1899TieSts = T000H4_A1899TieSts[0];
            AssignAttri("", false, "A1899TieSts", StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
            ZM0H18( -7) ;
         }
         pr_default.close(2);
         OnLoadActions0H18( ) ;
      }

      protected void OnLoadActions0H18( )
      {
      }

      protected void CheckExtendedTable0H18( )
      {
         nIsDirty_18 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1898TieDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Local", "", "", "", "", "", "", "", ""), 1, "TIEDSC");
            AnyError = 1;
            GX_FocusControl = edtTieDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0H18( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0H18( )
      {
         /* Using cursor T000H5 */
         pr_default.execute(3, new Object[] {n178TieCod, A178TieCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000H3 */
         pr_default.execute(1, new Object[] {n178TieCod, A178TieCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H18( 7) ;
            RcdFound18 = 1;
            A178TieCod = T000H3_A178TieCod[0];
            n178TieCod = T000H3_n178TieCod[0];
            AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
            A1898TieDsc = T000H3_A1898TieDsc[0];
            AssignAttri("", false, "A1898TieDsc", A1898TieDsc);
            A1897TieAbr = T000H3_A1897TieAbr[0];
            AssignAttri("", false, "A1897TieAbr", A1897TieAbr);
            A1899TieSts = T000H3_A1899TieSts[0];
            AssignAttri("", false, "A1899TieSts", StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
            Z178TieCod = A178TieCod;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0H18( ) ;
            if ( AnyError == 1 )
            {
               RcdFound18 = 0;
               InitializeNonKey0H18( ) ;
            }
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0H18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode18;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H18( ) ;
         if ( RcdFound18 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound18 = 0;
         /* Using cursor T000H6 */
         pr_default.execute(4, new Object[] {n178TieCod, A178TieCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000H6_A178TieCod[0] < A178TieCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000H6_A178TieCod[0] > A178TieCod ) ) )
            {
               A178TieCod = T000H6_A178TieCod[0];
               n178TieCod = T000H6_n178TieCod[0];
               AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
               RcdFound18 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound18 = 0;
         /* Using cursor T000H7 */
         pr_default.execute(5, new Object[] {n178TieCod, A178TieCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000H7_A178TieCod[0] > A178TieCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000H7_A178TieCod[0] < A178TieCod ) ) )
            {
               A178TieCod = T000H7_A178TieCod[0];
               n178TieCod = T000H7_n178TieCod[0];
               AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
               RcdFound18 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0H18( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTieDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0H18( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound18 == 1 )
            {
               if ( A178TieCod != Z178TieCod )
               {
                  A178TieCod = Z178TieCod;
                  n178TieCod = false;
                  AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TIECOD");
                  AnyError = 1;
                  GX_FocusControl = edtTieCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTieDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0H18( ) ;
                  GX_FocusControl = edtTieDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A178TieCod != Z178TieCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtTieDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0H18( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TIECOD");
                     AnyError = 1;
                     GX_FocusControl = edtTieCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTieDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0H18( ) ;
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
         if ( A178TieCod != Z178TieCod )
         {
            A178TieCod = Z178TieCod;
            n178TieCod = false;
            AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TIECOD");
            AnyError = 1;
            GX_FocusControl = edtTieCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTieDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0H18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000H2 */
            pr_default.execute(0, new Object[] {n178TieCod, A178TieCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGTIENDAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1898TieDsc, T000H2_A1898TieDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1897TieAbr, T000H2_A1897TieAbr[0]) != 0 ) || ( Z1899TieSts != T000H2_A1899TieSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z1898TieDsc, T000H2_A1898TieDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.locales:[seudo value changed for attri]"+"TieDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1898TieDsc);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A1898TieDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1897TieAbr, T000H2_A1897TieAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("seguridad.locales:[seudo value changed for attri]"+"TieAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1897TieAbr);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A1897TieAbr[0]);
               }
               if ( Z1899TieSts != T000H2_A1899TieSts[0] )
               {
                  GXUtil.WriteLog("seguridad.locales:[seudo value changed for attri]"+"TieSts");
                  GXUtil.WriteLogRaw("Old: ",Z1899TieSts);
                  GXUtil.WriteLogRaw("Current: ",T000H2_A1899TieSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"SGTIENDAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H18( )
      {
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H18( 0) ;
            CheckOptimisticConcurrency0H18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H8 */
                     pr_default.execute(6, new Object[] {n178TieCod, A178TieCod, A1898TieDsc, A1897TieAbr, A1899TieSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("SGTIENDAS");
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
                           ResetCaption0H0( ) ;
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
               Load0H18( ) ;
            }
            EndLevel0H18( ) ;
         }
         CloseExtendedTableCursors0H18( ) ;
      }

      protected void Update0H18( )
      {
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000H9 */
                     pr_default.execute(7, new Object[] {A1898TieDsc, A1897TieAbr, A1899TieSts, n178TieCod, A178TieCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("SGTIENDAS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"SGTIENDAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0H18( ) ;
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
            EndLevel0H18( ) ;
         }
         CloseExtendedTableCursors0H18( ) ;
      }

      protected void DeferredUpdate0H18( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H18( ) ;
            AfterConfirm0H18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000H10 */
                  pr_default.execute(8, new Object[] {n178TieCod, A178TieCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("SGTIENDAS");
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
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0H18( ) ;
         Gx_mode = sMode18;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0H18( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000H11 */
            pr_default.execute(9, new Object[] {n178TieCod, A178TieCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T000H12 */
            pr_default.execute(10, new Object[] {n178TieCod, A178TieCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000H13 */
            pr_default.execute(11, new Object[] {n178TieCod, A178TieCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000H14 */
            pr_default.execute(12, new Object[] {n178TieCod, A178TieCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel0H18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("seguridad.locales",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0H0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("seguridad.locales",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0H18( )
      {
         /* Scan By routine */
         /* Using cursor T000H15 */
         pr_default.execute(13);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound18 = 1;
            A178TieCod = T000H15_A178TieCod[0];
            n178TieCod = T000H15_n178TieCod[0];
            AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0H18( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound18 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound18 = 1;
            A178TieCod = T000H15_A178TieCod[0];
            n178TieCod = T000H15_n178TieCod[0];
            AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
         }
      }

      protected void ScanEnd0H18( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0H18( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int1 = AV7TieCod;
            GXt_char2 = "TIENDA";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char2, out  GXt_int1) ;
            AV7TieCod = (int)(GXt_int1);
            AssignAttri("", false, "AV7TieCod", StringUtil.LTrimStr( (decimal)(AV7TieCod), 6, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vTIECOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TieCod), "ZZZZZ9"), context));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A178TieCod = AV7TieCod;
            n178TieCod = false;
            AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
         }
      }

      protected void BeforeInsert0H18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H18( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H18( )
      {
         edtTieDsc_Enabled = 0;
         AssignProp("", false, edtTieDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTieDsc_Enabled), 5, 0), true);
         edtTieAbr_Enabled = 0;
         AssignProp("", false, edtTieAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTieAbr_Enabled), 5, 0), true);
         cmbTieSts.Enabled = 0;
         AssignProp("", false, cmbTieSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbTieSts.Enabled), 5, 0), true);
         edtTieCod_Enabled = 0;
         AssignProp("", false, edtTieCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTieCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0H18( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0H0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181144172", false, true);
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
         GXEncryptionTmp = "seguridad.locales.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TieCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("seguridad.locales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Locales");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("seguridad\\locales:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z178TieCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z178TieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1898TieDsc", StringUtil.RTrim( Z1898TieDsc));
         GxWebStd.gx_hidden_field( context, "Z1897TieAbr", Z1897TieAbr);
         GxWebStd.gx_hidden_field( context, "Z1899TieSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1899TieSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vTIECOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TieCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vTIECOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TieCod), "ZZZZZ9"), context));
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
         GXEncryptionTmp = "seguridad.locales.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7TieCod,6,0));
         return formatLink("seguridad.locales.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Seguridad.Locales" ;
      }

      public override string GetPgmdesc( )
      {
         return "Locales" ;
      }

      protected void InitializeNonKey0H18( )
      {
         A1898TieDsc = "";
         AssignAttri("", false, "A1898TieDsc", A1898TieDsc);
         A1897TieAbr = "";
         AssignAttri("", false, "A1897TieAbr", A1897TieAbr);
         A1899TieSts = 1;
         AssignAttri("", false, "A1899TieSts", StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
         Z1898TieDsc = "";
         Z1897TieAbr = "";
         Z1899TieSts = 0;
      }

      protected void InitAll0H18( )
      {
         A178TieCod = 0;
         n178TieCod = false;
         AssignAttri("", false, "A178TieCod", StringUtil.LTrimStr( (decimal)(A178TieCod), 6, 0));
         InitializeNonKey0H18( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1899TieSts = i1899TieSts;
         AssignAttri("", false, "A1899TieSts", StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811441716", true, true);
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
         context.AddJavascriptSource("seguridad/locales.js", "?202281811441717", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtTieDsc_Internalname = "TIEDSC";
         edtTieAbr_Internalname = "TIEABR";
         cmbTieSts_Internalname = "TIESTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtTieCod_Internalname = "TIECOD";
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
         Form.Caption = "Locales";
         edtTieCod_Jsonclick = "";
         edtTieCod_Enabled = 0;
         edtTieCod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbTieSts_Jsonclick = "";
         cmbTieSts.Enabled = 1;
         edtTieAbr_Jsonclick = "";
         edtTieAbr_Enabled = 1;
         edtTieDsc_Jsonclick = "";
         edtTieDsc_Enabled = 1;
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

      protected void GX4ASATIECOD0H18( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int1 = AV7TieCod;
            GXt_char2 = "TIENDA";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char2, out  GXt_int1) ;
            AV7TieCod = (int)(GXt_int1);
            AssignAttri("", false, "AV7TieCod", StringUtil.LTrimStr( (decimal)(AV7TieCod), 6, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_vTIECOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7TieCod), "ZZZZZ9"), context));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7TieCod), 6, 0, ".", "")))+"\"") ;
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
         cmbTieSts.Name = "TIESTS";
         cmbTieSts.WebTags = "";
         cmbTieSts.addItem("1", "ACTIVO", 0);
         cmbTieSts.addItem("0", "INACTIVO", 0);
         if ( cmbTieSts.ItemCount > 0 )
         {
            if ( (0==A1899TieSts) )
            {
               A1899TieSts = 1;
               AssignAttri("", false, "A1899TieSts", StringUtil.Str( (decimal)(A1899TieSts), 1, 0));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7TieCod',fld:'vTIECOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7TieCod',fld:'vTIECOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120H2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_TIEDSC","{handler:'Valid_Tiedsc',iparms:[]");
         setEventMetadata("VALID_TIEDSC",",oparms:[]}");
         setEventMetadata("VALID_TIECOD","{handler:'Valid_Tiecod',iparms:[]");
         setEventMetadata("VALID_TIECOD",",oparms:[]}");
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
         Z1898TieDsc = "";
         Z1897TieAbr = "";
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
         A1898TieDsc = "";
         A1897TieAbr = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode18 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         T000H4_A178TieCod = new int[1] ;
         T000H4_n178TieCod = new bool[] {false} ;
         T000H4_A1898TieDsc = new string[] {""} ;
         T000H4_A1897TieAbr = new string[] {""} ;
         T000H4_A1899TieSts = new short[1] ;
         T000H5_A178TieCod = new int[1] ;
         T000H5_n178TieCod = new bool[] {false} ;
         T000H3_A178TieCod = new int[1] ;
         T000H3_n178TieCod = new bool[] {false} ;
         T000H3_A1898TieDsc = new string[] {""} ;
         T000H3_A1897TieAbr = new string[] {""} ;
         T000H3_A1899TieSts = new short[1] ;
         T000H6_A178TieCod = new int[1] ;
         T000H6_n178TieCod = new bool[] {false} ;
         T000H7_A178TieCod = new int[1] ;
         T000H7_n178TieCod = new bool[] {false} ;
         T000H2_A178TieCod = new int[1] ;
         T000H2_n178TieCod = new bool[] {false} ;
         T000H2_A1898TieDsc = new string[] {""} ;
         T000H2_A1897TieAbr = new string[] {""} ;
         T000H2_A1899TieSts = new short[1] ;
         T000H11_A348UsuCod = new string[] {""} ;
         T000H12_A149TipCod = new string[] {""} ;
         T000H12_A24DocNum = new string[] {""} ;
         T000H13_A210PedCod = new string[] {""} ;
         T000H14_A177CotCod = new string[] {""} ;
         T000H15_A178TieCod = new int[1] ;
         T000H15_n178TieCod = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char2 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.seguridad.locales__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.seguridad.locales__default(),
            new Object[][] {
                new Object[] {
               T000H2_A178TieCod, T000H2_A1898TieDsc, T000H2_A1897TieAbr, T000H2_A1899TieSts
               }
               , new Object[] {
               T000H3_A178TieCod, T000H3_A1898TieDsc, T000H3_A1897TieAbr, T000H3_A1899TieSts
               }
               , new Object[] {
               T000H4_A178TieCod, T000H4_A1898TieDsc, T000H4_A1897TieAbr, T000H4_A1899TieSts
               }
               , new Object[] {
               T000H5_A178TieCod
               }
               , new Object[] {
               T000H6_A178TieCod
               }
               , new Object[] {
               T000H7_A178TieCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000H11_A348UsuCod
               }
               , new Object[] {
               T000H12_A149TipCod, T000H12_A24DocNum
               }
               , new Object[] {
               T000H13_A210PedCod
               }
               , new Object[] {
               T000H14_A177CotCod
               }
               , new Object[] {
               T000H15_A178TieCod
               }
            }
         );
         Z1899TieSts = 1;
         A1899TieSts = 1;
         i1899TieSts = 1;
      }

      private short Z1899TieSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1899TieSts ;
      private short Gx_BScreen ;
      private short RcdFound18 ;
      private short GX_JID ;
      private short nIsDirty_18 ;
      private short gxajaxcallmode ;
      private short i1899TieSts ;
      private int wcpOAV7TieCod ;
      private int Z178TieCod ;
      private int AV7TieCod ;
      private int trnEnded ;
      private int edtTieDsc_Enabled ;
      private int edtTieAbr_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A178TieCod ;
      private int edtTieCod_Enabled ;
      private int edtTieCod_Visible ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int1 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z1898TieDsc ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTieDsc_Internalname ;
      private string cmbTieSts_Internalname ;
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
      private string A1898TieDsc ;
      private string edtTieDsc_Jsonclick ;
      private string edtTieAbr_Internalname ;
      private string edtTieAbr_Jsonclick ;
      private string cmbTieSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtTieCod_Internalname ;
      private string edtTieCod_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode18 ;
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
      private string GXt_char2 ;
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
      private bool n178TieCod ;
      private bool returnInSub ;
      private string Z1897TieAbr ;
      private string A1897TieAbr ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbTieSts ;
      private IDataStoreProvider pr_default ;
      private int[] T000H4_A178TieCod ;
      private bool[] T000H4_n178TieCod ;
      private string[] T000H4_A1898TieDsc ;
      private string[] T000H4_A1897TieAbr ;
      private short[] T000H4_A1899TieSts ;
      private int[] T000H5_A178TieCod ;
      private bool[] T000H5_n178TieCod ;
      private int[] T000H3_A178TieCod ;
      private bool[] T000H3_n178TieCod ;
      private string[] T000H3_A1898TieDsc ;
      private string[] T000H3_A1897TieAbr ;
      private short[] T000H3_A1899TieSts ;
      private int[] T000H6_A178TieCod ;
      private bool[] T000H6_n178TieCod ;
      private int[] T000H7_A178TieCod ;
      private bool[] T000H7_n178TieCod ;
      private int[] T000H2_A178TieCod ;
      private bool[] T000H2_n178TieCod ;
      private string[] T000H2_A1898TieDsc ;
      private string[] T000H2_A1897TieAbr ;
      private short[] T000H2_A1899TieSts ;
      private string[] T000H11_A348UsuCod ;
      private string[] T000H12_A149TipCod ;
      private string[] T000H12_A24DocNum ;
      private string[] T000H13_A210PedCod ;
      private string[] T000H14_A177CotCod ;
      private int[] T000H15_A178TieCod ;
      private bool[] T000H15_n178TieCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
   }

   public class locales__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class locales__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000H4;
        prmT000H4 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000H5;
        prmT000H5 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000H3;
        prmT000H3 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000H6;
        prmT000H6 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000H7;
        prmT000H7 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000H2;
        prmT000H2 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000H8;
        prmT000H8 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@TieDsc",GXType.NChar,100,0) ,
        new ParDef("@TieAbr",GXType.NVarChar,10,0) ,
        new ParDef("@TieSts",GXType.Int16,1,0)
        };
        Object[] prmT000H9;
        prmT000H9 = new Object[] {
        new ParDef("@TieDsc",GXType.NChar,100,0) ,
        new ParDef("@TieAbr",GXType.NVarChar,10,0) ,
        new ParDef("@TieSts",GXType.Int16,1,0) ,
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000H10;
        prmT000H10 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000H11;
        prmT000H11 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000H12;
        prmT000H12 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000H13;
        prmT000H13 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000H14;
        prmT000H14 = new Object[] {
        new ParDef("@TieCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT000H15;
        prmT000H15 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000H2", "SELECT [TieCod], [TieDsc], [TieAbr], [TieSts] FROM [SGTIENDAS] WITH (UPDLOCK) WHERE [TieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H3", "SELECT [TieCod], [TieDsc], [TieAbr], [TieSts] FROM [SGTIENDAS] WHERE [TieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H4", "SELECT TM1.[TieCod], TM1.[TieDsc], TM1.[TieAbr], TM1.[TieSts] FROM [SGTIENDAS] TM1 WHERE TM1.[TieCod] = @TieCod ORDER BY TM1.[TieCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H5", "SELECT [TieCod] FROM [SGTIENDAS] WHERE [TieCod] = @TieCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000H6", "SELECT TOP 1 [TieCod] FROM [SGTIENDAS] WHERE ( [TieCod] > @TieCod) ORDER BY [TieCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H7", "SELECT TOP 1 [TieCod] FROM [SGTIENDAS] WHERE ( [TieCod] < @TieCod) ORDER BY [TieCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H8", "INSERT INTO [SGTIENDAS]([TieCod], [TieDsc], [TieAbr], [TieSts]) VALUES(@TieCod, @TieDsc, @TieAbr, @TieSts)", GxErrorMask.GX_NOMASK,prmT000H8)
           ,new CursorDef("T000H9", "UPDATE [SGTIENDAS] SET [TieDsc]=@TieDsc, [TieAbr]=@TieAbr, [TieSts]=@TieSts  WHERE [TieCod] = @TieCod", GxErrorMask.GX_NOMASK,prmT000H9)
           ,new CursorDef("T000H10", "DELETE FROM [SGTIENDAS]  WHERE [TieCod] = @TieCod", GxErrorMask.GX_NOMASK,prmT000H10)
           ,new CursorDef("T000H11", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE [UsuTieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H12", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [TieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H13", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE [TieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H14", "SELECT TOP 1 [CotCod] FROM [CLCOTIZA] WHERE [TieCod] = @TieCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000H14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000H15", "SELECT [TieCod] FROM [SGTIENDAS] ORDER BY [TieCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000H15,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
