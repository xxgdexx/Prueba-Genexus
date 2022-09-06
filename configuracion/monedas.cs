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
   public class monedas : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vCMONCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASACMONCOD61103( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.monedas.aspx")), "configuracion.monedas.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.monedas.aspx")))) ;
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
                  AV7MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AssignAttri("", false, "AV7MonCod", StringUtil.LTrimStr( (decimal)(AV7MonCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vMONCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MonCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Monedas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtMonDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public monedas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public monedas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_MonCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7MonCod = aP1_MonCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMonDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMonDsc_Internalname, "Moneda", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonDsc_Internalname, StringUtil.RTrim( A1234MonDsc), StringUtil.RTrim( context.localUtil.Format( A1234MonDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtMonDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Monedas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMonAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMonAbr_Internalname, "Abreviatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonAbr_Internalname, StringUtil.RTrim( A1233MonAbr), StringUtil.RTrim( context.localUtil.Format( A1233MonAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMonAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Monedas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMonSunat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMonSunat_Internalname, "Codigo Sunat", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonSunat_Internalname, A1236MonSunat, StringUtil.RTrim( context.localUtil.Format( A1236MonSunat, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonSunat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMonSunat_Enabled, 0, "text", "", 3, "chr", 1, "row", 3, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Monedas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtMonSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtMonSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1235MonSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtMonSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1235MonSts), "9") : context.localUtil.Format( (decimal)(A1235MonSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtMonSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\Monedas.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Monedas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Monedas.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Monedas.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtMonCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A180MonCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A180MonCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtMonCod_Jsonclick, 0, "Attribute", "", "", "", "", edtMonCod_Visible, edtMonCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\Monedas.htm");
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
         E11612 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z180MonCod = (int)(context.localUtil.CToN( cgiGet( "Z180MonCod"), ".", ","));
               Z1234MonDsc = cgiGet( "Z1234MonDsc");
               Z1233MonAbr = cgiGet( "Z1233MonAbr");
               Z1235MonSts = (short)(context.localUtil.CToN( cgiGet( "Z1235MonSts"), ".", ","));
               Z1236MonSunat = cgiGet( "Z1236MonSunat");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7MonCod = (int)(context.localUtil.CToN( cgiGet( "vMONCOD"), ".", ","));
               AV13cMonCod = (int)(context.localUtil.CToN( cgiGet( "vCMONCOD"), ".", ","));
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
               A1234MonDsc = cgiGet( edtMonDsc_Internalname);
               AssignAttri("", false, "A1234MonDsc", A1234MonDsc);
               A1233MonAbr = cgiGet( edtMonAbr_Internalname);
               AssignAttri("", false, "A1233MonAbr", A1233MonAbr);
               A1236MonSunat = cgiGet( edtMonSunat_Internalname);
               AssignAttri("", false, "A1236MonSunat", A1236MonSunat);
               if ( ( ( context.localUtil.CToN( cgiGet( edtMonSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMonSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MONSTS");
                  AnyError = 1;
                  GX_FocusControl = edtMonSts_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1235MonSts = 0;
                  AssignAttri("", false, "A1235MonSts", StringUtil.Str( (decimal)(A1235MonSts), 1, 0));
               }
               else
               {
                  A1235MonSts = (short)(context.localUtil.CToN( cgiGet( edtMonSts_Internalname), ".", ","));
                  AssignAttri("", false, "A1235MonSts", StringUtil.Str( (decimal)(A1235MonSts), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "MONCOD");
                  AnyError = 1;
                  GX_FocusControl = edtMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A180MonCod = 0;
                  AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
               }
               else
               {
                  A180MonCod = (int)(context.localUtil.CToN( cgiGet( edtMonCod_Internalname), ".", ","));
                  AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Monedas");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A180MonCod != Z180MonCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\monedas:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A180MonCod = (int)(NumberUtil.Val( GetPar( "MonCod"), "."));
                  AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
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
                     sMode103 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode103;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound103 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_610( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "MONCOD");
                        AnyError = 1;
                        GX_FocusControl = edtMonCod_Internalname;
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
                           E11612 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12612 ();
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
            E12612 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll61103( ) ;
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
            DisableAttributes61103( ) ;
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

      protected void CONFIRM_610( )
      {
         BeforeValidate61103( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls61103( ) ;
            }
            else
            {
               CheckExtendedTable61103( ) ;
               CloseExtendedTableCursors61103( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption610( )
      {
      }

      protected void E11612( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtMonCod_Visible = 0;
         AssignProp("", false, edtMonCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMonCod_Visible), 5, 0), true);
      }

      protected void E12612( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV14SGAuDocGls = "Moneda N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A180MonCod), 10, 0)) + " " + StringUtil.Trim( A1234MonDsc);
            AV15Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A180MonCod), 10, 0));
            GXt_char1 = "CNF";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV14SGAuDocGls, ref  AV15Codigo, ref  AV15Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.monedasww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM61103( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1234MonDsc = T00613_A1234MonDsc[0];
               Z1233MonAbr = T00613_A1233MonAbr[0];
               Z1235MonSts = T00613_A1235MonSts[0];
               Z1236MonSunat = T00613_A1236MonSunat[0];
            }
            else
            {
               Z1234MonDsc = A1234MonDsc;
               Z1233MonAbr = A1233MonAbr;
               Z1235MonSts = A1235MonSts;
               Z1236MonSunat = A1236MonSunat;
            }
         }
         if ( GX_JID == -10 )
         {
            Z180MonCod = A180MonCod;
            Z1234MonDsc = A1234MonDsc;
            Z1233MonAbr = A1233MonAbr;
            Z1235MonSts = A1235MonSts;
            Z1236MonSunat = A1236MonSunat;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7MonCod) )
         {
            A180MonCod = AV7MonCod;
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         }
         if ( ! (0==AV7MonCod) )
         {
            edtMonCod_Enabled = 0;
            AssignProp("", false, edtMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonCod_Enabled), 5, 0), true);
         }
         else
         {
            edtMonCod_Enabled = 1;
            AssignProp("", false, edtMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7MonCod) )
         {
            edtMonCod_Enabled = 0;
            AssignProp("", false, edtMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A1235MonSts) && ( Gx_BScreen == 0 ) )
         {
            A1235MonSts = 1;
            AssignAttri("", false, "A1235MonSts", StringUtil.Str( (decimal)(A1235MonSts), 1, 0));
         }
      }

      protected void Load61103( )
      {
         /* Using cursor T00614 */
         pr_default.execute(2, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound103 = 1;
            A1234MonDsc = T00614_A1234MonDsc[0];
            AssignAttri("", false, "A1234MonDsc", A1234MonDsc);
            A1233MonAbr = T00614_A1233MonAbr[0];
            AssignAttri("", false, "A1233MonAbr", A1233MonAbr);
            A1235MonSts = T00614_A1235MonSts[0];
            AssignAttri("", false, "A1235MonSts", StringUtil.Str( (decimal)(A1235MonSts), 1, 0));
            A1236MonSunat = T00614_A1236MonSunat[0];
            AssignAttri("", false, "A1236MonSunat", A1236MonSunat);
            ZM61103( -10) ;
         }
         pr_default.close(2);
         OnLoadActions61103( ) ;
      }

      protected void OnLoadActions61103( )
      {
      }

      protected void CheckExtendedTable61103( )
      {
         nIsDirty_103 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1234MonDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Moneda", "", "", "", "", "", "", "", ""), 1, "MONDSC");
            AnyError = 1;
            GX_FocusControl = edtMonDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1233MonAbr)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Abr. Moneda", "", "", "", "", "", "", "", ""), 1, "MONABR");
            AnyError = 1;
            GX_FocusControl = edtMonAbr_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1236MonSunat)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cod.Sunat", "", "", "", "", "", "", "", ""), 1, "MONSUNAT");
            AnyError = 1;
            GX_FocusControl = edtMonSunat_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors61103( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey61103( )
      {
         /* Using cursor T00615 */
         pr_default.execute(3, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound103 = 1;
         }
         else
         {
            RcdFound103 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00613 */
         pr_default.execute(1, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM61103( 10) ;
            RcdFound103 = 1;
            A180MonCod = T00613_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            A1234MonDsc = T00613_A1234MonDsc[0];
            AssignAttri("", false, "A1234MonDsc", A1234MonDsc);
            A1233MonAbr = T00613_A1233MonAbr[0];
            AssignAttri("", false, "A1233MonAbr", A1233MonAbr);
            A1235MonSts = T00613_A1235MonSts[0];
            AssignAttri("", false, "A1235MonSts", StringUtil.Str( (decimal)(A1235MonSts), 1, 0));
            A1236MonSunat = T00613_A1236MonSunat[0];
            AssignAttri("", false, "A1236MonSunat", A1236MonSunat);
            Z180MonCod = A180MonCod;
            sMode103 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load61103( ) ;
            if ( AnyError == 1 )
            {
               RcdFound103 = 0;
               InitializeNonKey61103( ) ;
            }
            Gx_mode = sMode103;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound103 = 0;
            InitializeNonKey61103( ) ;
            sMode103 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode103;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey61103( ) ;
         if ( RcdFound103 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound103 = 0;
         /* Using cursor T00616 */
         pr_default.execute(4, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T00616_A180MonCod[0] < A180MonCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T00616_A180MonCod[0] > A180MonCod ) ) )
            {
               A180MonCod = T00616_A180MonCod[0];
               AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
               RcdFound103 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound103 = 0;
         /* Using cursor T00617 */
         pr_default.execute(5, new Object[] {A180MonCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00617_A180MonCod[0] > A180MonCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00617_A180MonCod[0] < A180MonCod ) ) )
            {
               A180MonCod = T00617_A180MonCod[0];
               AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
               RcdFound103 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey61103( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtMonDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert61103( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound103 == 1 )
            {
               if ( A180MonCod != Z180MonCod )
               {
                  A180MonCod = Z180MonCod;
                  AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "MONCOD");
                  AnyError = 1;
                  GX_FocusControl = edtMonCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtMonDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update61103( ) ;
                  GX_FocusControl = edtMonDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A180MonCod != Z180MonCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtMonDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert61103( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "MONCOD");
                     AnyError = 1;
                     GX_FocusControl = edtMonCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtMonDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert61103( ) ;
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
         if ( A180MonCod != Z180MonCod )
         {
            A180MonCod = Z180MonCod;
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "MONCOD");
            AnyError = 1;
            GX_FocusControl = edtMonCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtMonDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency61103( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00612 */
            pr_default.execute(0, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CMONEDAS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1234MonDsc, T00612_A1234MonDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1233MonAbr, T00612_A1233MonAbr[0]) != 0 ) || ( Z1235MonSts != T00612_A1235MonSts[0] ) || ( StringUtil.StrCmp(Z1236MonSunat, T00612_A1236MonSunat[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1234MonDsc, T00612_A1234MonDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.monedas:[seudo value changed for attri]"+"MonDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1234MonDsc);
                  GXUtil.WriteLogRaw("Current: ",T00612_A1234MonDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1233MonAbr, T00612_A1233MonAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.monedas:[seudo value changed for attri]"+"MonAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1233MonAbr);
                  GXUtil.WriteLogRaw("Current: ",T00612_A1233MonAbr[0]);
               }
               if ( Z1235MonSts != T00612_A1235MonSts[0] )
               {
                  GXUtil.WriteLog("configuracion.monedas:[seudo value changed for attri]"+"MonSts");
                  GXUtil.WriteLogRaw("Old: ",Z1235MonSts);
                  GXUtil.WriteLogRaw("Current: ",T00612_A1235MonSts[0]);
               }
               if ( StringUtil.StrCmp(Z1236MonSunat, T00612_A1236MonSunat[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.monedas:[seudo value changed for attri]"+"MonSunat");
                  GXUtil.WriteLogRaw("Old: ",Z1236MonSunat);
                  GXUtil.WriteLogRaw("Current: ",T00612_A1236MonSunat[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CMONEDAS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert61103( )
      {
         BeforeValidate61103( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable61103( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM61103( 0) ;
            CheckOptimisticConcurrency61103( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm61103( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert61103( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00618 */
                     pr_default.execute(6, new Object[] {A180MonCod, A1234MonDsc, A1233MonAbr, A1235MonSts, A1236MonSunat});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CMONEDAS");
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
                           ResetCaption610( ) ;
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
               Load61103( ) ;
            }
            EndLevel61103( ) ;
         }
         CloseExtendedTableCursors61103( ) ;
      }

      protected void Update61103( )
      {
         BeforeValidate61103( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable61103( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency61103( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm61103( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate61103( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00619 */
                     pr_default.execute(7, new Object[] {A1234MonDsc, A1233MonAbr, A1235MonSts, A1236MonSunat, A180MonCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CMONEDAS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CMONEDAS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate61103( ) ;
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
            EndLevel61103( ) ;
         }
         CloseExtendedTableCursors61103( ) ;
      }

      protected void DeferredUpdate61103( )
      {
      }

      protected void delete( )
      {
         BeforeValidate61103( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency61103( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls61103( ) ;
            AfterConfirm61103( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete61103( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006110 */
                  pr_default.execute(8, new Object[] {A180MonCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CMONEDAS");
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
         sMode103 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel61103( ) ;
         Gx_mode = sMode103;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls61103( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T006111 */
            pr_default.execute(9, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Costo Estandar Materias Primas"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T006112 */
            pr_default.execute(10, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pagos a proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T006113 */
            pr_default.execute(11, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T006114 */
            pr_default.execute(12, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Caja Chica"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T006115 */
            pr_default.execute(13, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T006116 */
            pr_default.execute(14, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura Caja"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T006117 */
            pr_default.execute(15, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tipo de Cambio"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T006118 */
            pr_default.execute(16, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Ordenes de Compra"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T006119 */
            pr_default.execute(17, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Liquidación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T006120 */
            pr_default.execute(18, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Letras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T006121 */
            pr_default.execute(19, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuenta Pagar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T006122 */
            pr_default.execute(20, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T006123 */
            pr_default.execute(21, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CPCHEQUEDIFERIDO"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T006124 */
            pr_default.execute(22, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T006125 */
            pr_default.execute(23, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Configuración de Venta por lotes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T006126 */
            pr_default.execute(24, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Letras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
            /* Using cursor T006127 */
            pr_default.execute(25, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(25) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(25);
            /* Using cursor T006128 */
            pr_default.execute(26, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(26) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuenta x Cobrar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(26);
            /* Using cursor T006129 */
            pr_default.execute(27, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(27) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Tipo de Presupuesto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(27);
            /* Using cursor T006130 */
            pr_default.execute(28, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(28) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuentas de Banco"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(28);
            /* Using cursor T006131 */
            pr_default.execute(29, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(29) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(29);
            /* Using cursor T006132 */
            pr_default.execute(30, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(30) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(30);
            /* Using cursor T006133 */
            pr_default.execute(31, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(31) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Cabecera"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(31);
            /* Using cursor T006134 */
            pr_default.execute(32, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(32) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CLCHEQUEDIFERIDO"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(32);
            /* Using cursor T006135 */
            pr_default.execute(33, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(33) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Anticipos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(33);
            /* Using cursor T006136 */
            pr_default.execute(34, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(34) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Asiento Contable Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(34);
            /* Using cursor T006137 */
            pr_default.execute(35, new Object[] {A180MonCod});
            if ( (pr_default.getStatus(35) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(35);
         }
      }

      protected void EndLevel61103( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete61103( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.monedas",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues610( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.monedas",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart61103( )
      {
         /* Scan By routine */
         /* Using cursor T006138 */
         pr_default.execute(36);
         RcdFound103 = 0;
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound103 = 1;
            A180MonCod = T006138_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext61103( )
      {
         /* Scan next routine */
         pr_default.readNext(36);
         RcdFound103 = 0;
         if ( (pr_default.getStatus(36) != 101) )
         {
            RcdFound103 = 1;
            A180MonCod = T006138_A180MonCod[0];
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         }
      }

      protected void ScanEnd61103( )
      {
         pr_default.close(36);
      }

      protected void AfterConfirm61103( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cMonCod;
            GXt_char3 = "MONEDAS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cMonCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cMonCod", StringUtil.LTrimStr( (decimal)(AV13cMonCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A180MonCod = AV13cMonCod;
            AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         }
      }

      protected void BeforeInsert61103( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate61103( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete61103( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete61103( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate61103( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes61103( )
      {
         edtMonDsc_Enabled = 0;
         AssignProp("", false, edtMonDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonDsc_Enabled), 5, 0), true);
         edtMonAbr_Enabled = 0;
         AssignProp("", false, edtMonAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonAbr_Enabled), 5, 0), true);
         edtMonSunat_Enabled = 0;
         AssignProp("", false, edtMonSunat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonSunat_Enabled), 5, 0), true);
         edtMonSts_Enabled = 0;
         AssignProp("", false, edtMonSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonSts_Enabled), 5, 0), true);
         edtMonCod_Enabled = 0;
         AssignProp("", false, edtMonCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtMonCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes61103( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues610( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810263123", false, true);
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
         GXEncryptionTmp = "configuracion.monedas.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MonCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.monedas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Monedas");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\monedas:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z180MonCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z180MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1234MonDsc", StringUtil.RTrim( Z1234MonDsc));
         GxWebStd.gx_hidden_field( context, "Z1233MonAbr", StringUtil.RTrim( Z1233MonAbr));
         GxWebStd.gx_hidden_field( context, "Z1235MonSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1235MonSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1236MonSunat", Z1236MonSunat);
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
         GxWebStd.gx_hidden_field( context, "vMONCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7MonCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vMONCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7MonCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCMONCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cMonCod), 6, 0, ".", "")));
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
         GXEncryptionTmp = "configuracion.monedas.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7MonCod,6,0));
         return formatLink("configuracion.monedas.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.Monedas" ;
      }

      public override string GetPgmdesc( )
      {
         return "Monedas" ;
      }

      protected void InitializeNonKey61103( )
      {
         AV13cMonCod = 0;
         AssignAttri("", false, "AV13cMonCod", StringUtil.LTrimStr( (decimal)(AV13cMonCod), 6, 0));
         A1234MonDsc = "";
         AssignAttri("", false, "A1234MonDsc", A1234MonDsc);
         A1233MonAbr = "";
         AssignAttri("", false, "A1233MonAbr", A1233MonAbr);
         A1236MonSunat = "";
         AssignAttri("", false, "A1236MonSunat", A1236MonSunat);
         A1235MonSts = 1;
         AssignAttri("", false, "A1235MonSts", StringUtil.Str( (decimal)(A1235MonSts), 1, 0));
         Z1234MonDsc = "";
         Z1233MonAbr = "";
         Z1235MonSts = 0;
         Z1236MonSunat = "";
      }

      protected void InitAll61103( )
      {
         A180MonCod = 0;
         AssignAttri("", false, "A180MonCod", StringUtil.LTrimStr( (decimal)(A180MonCod), 6, 0));
         InitializeNonKey61103( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1235MonSts = i1235MonSts;
         AssignAttri("", false, "A1235MonSts", StringUtil.Str( (decimal)(A1235MonSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810263142", true, true);
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
         context.AddJavascriptSource("configuracion/monedas.js", "?202281810263142", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtMonDsc_Internalname = "MONDSC";
         edtMonAbr_Internalname = "MONABR";
         edtMonSunat_Internalname = "MONSUNAT";
         edtMonSts_Internalname = "MONSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtMonCod_Internalname = "MONCOD";
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
         Form.Caption = "Monedas";
         edtMonCod_Jsonclick = "";
         edtMonCod_Enabled = 1;
         edtMonCod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtMonSts_Jsonclick = "";
         edtMonSts_Enabled = 1;
         edtMonSunat_Jsonclick = "";
         edtMonSunat_Enabled = 1;
         edtMonAbr_Jsonclick = "";
         edtMonAbr_Enabled = 1;
         edtMonDsc_Jsonclick = "";
         edtMonDsc_Enabled = 1;
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

      protected void GX4ASACMONCOD61103( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cMonCod;
            GXt_char3 = "MONEDAS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cMonCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cMonCod", StringUtil.LTrimStr( (decimal)(AV13cMonCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cMonCod), 6, 0, ".", "")))+"\"") ;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7MonCod',fld:'vMONCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7MonCod',fld:'vMONCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12612',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A180MonCod',fld:'MONCOD',pic:'ZZZZZ9'},{av:'A1234MonDsc',fld:'MONDSC',pic:''},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_MONDSC","{handler:'Valid_Mondsc',iparms:[]");
         setEventMetadata("VALID_MONDSC",",oparms:[]}");
         setEventMetadata("VALID_MONABR","{handler:'Valid_Monabr',iparms:[]");
         setEventMetadata("VALID_MONABR",",oparms:[]}");
         setEventMetadata("VALID_MONSUNAT","{handler:'Valid_Monsunat',iparms:[]");
         setEventMetadata("VALID_MONSUNAT",",oparms:[]}");
         setEventMetadata("VALID_MONCOD","{handler:'Valid_Moncod',iparms:[]");
         setEventMetadata("VALID_MONCOD",",oparms:[]}");
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
         Z1234MonDsc = "";
         Z1233MonAbr = "";
         Z1236MonSunat = "";
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
         A1234MonDsc = "";
         A1233MonAbr = "";
         A1236MonSunat = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode103 = "";
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
         T00614_A180MonCod = new int[1] ;
         T00614_A1234MonDsc = new string[] {""} ;
         T00614_A1233MonAbr = new string[] {""} ;
         T00614_A1235MonSts = new short[1] ;
         T00614_A1236MonSunat = new string[] {""} ;
         T00615_A180MonCod = new int[1] ;
         T00613_A180MonCod = new int[1] ;
         T00613_A1234MonDsc = new string[] {""} ;
         T00613_A1233MonAbr = new string[] {""} ;
         T00613_A1235MonSts = new short[1] ;
         T00613_A1236MonSunat = new string[] {""} ;
         T00616_A180MonCod = new int[1] ;
         T00617_A180MonCod = new int[1] ;
         T00612_A180MonCod = new int[1] ;
         T00612_A1234MonDsc = new string[] {""} ;
         T00612_A1233MonAbr = new string[] {""} ;
         T00612_A1235MonSts = new short[1] ;
         T00612_A1236MonSunat = new string[] {""} ;
         T006111_A2385ProCosProdCod = new string[] {""} ;
         T006112_A412PagReg = new long[1] ;
         T006113_A365EntCod = new int[1] ;
         T006113_A403MVLEntCod = new string[] {""} ;
         T006113_A404MVLEITem = new int[1] ;
         T006114_A358CajCod = new int[1] ;
         T006114_A391MVLCajCod = new string[] {""} ;
         T006114_A392MVLITem = new int[1] ;
         T006115_A365EntCod = new int[1] ;
         T006115_A366AperEntCod = new string[] {""} ;
         T006116_A358CajCod = new int[1] ;
         T006116_A359AperCajCod = new string[] {""} ;
         T006117_A307TipMonCod = new int[1] ;
         T006117_A308TipFech = new DateTime[] {DateTime.MinValue} ;
         T006118_A289OrdCod = new string[] {""} ;
         T006119_A270LiqCod = new string[] {""} ;
         T006119_A236LiqPrvCod = new string[] {""} ;
         T006119_A271LiqCodItem = new int[1] ;
         T006120_A265LetPLetCod = new string[] {""} ;
         T006121_A260CPTipCod = new string[] {""} ;
         T006121_A261CPComCod = new string[] {""} ;
         T006121_A262CPPrvCod = new string[] {""} ;
         T006122_A149TipCod = new string[] {""} ;
         T006122_A243ComCod = new string[] {""} ;
         T006122_A244PrvCod = new string[] {""} ;
         T006123_A238CheqDCod = new string[] {""} ;
         T006124_A149TipCod = new string[] {""} ;
         T006124_A24DocNum = new string[] {""} ;
         T006125_A224LotCliCod = new string[] {""} ;
         T006126_A204LetCLetCod = new string[] {""} ;
         T006127_A191ImpItem = new long[1] ;
         T006128_A184CCTipCod = new string[] {""} ;
         T006128_A185CCDocNum = new string[] {""} ;
         T006129_A2280CBTipPre = new int[1] ;
         T006130_A372BanCod = new int[1] ;
         T006130_A377CBCod = new string[] {""} ;
         T006131_A210PedCod = new string[] {""} ;
         T006132_A177CotCod = new string[] {""} ;
         T006133_A166CobTip = new string[] {""} ;
         T006133_A167CobCod = new string[] {""} ;
         T006134_A150CLCheqDCod = new string[] {""} ;
         T006135_A144CLAntTipCod = new string[] {""} ;
         T006135_A145CLAntDocNum = new string[] {""} ;
         T006136_A127VouAno = new short[1] ;
         T006136_A128VouMes = new short[1] ;
         T006136_A126TASICod = new int[1] ;
         T006136_A129VouNum = new string[] {""} ;
         T006136_A130VouDSec = new int[1] ;
         T006137_A83ParTip = new string[] {""} ;
         T006137_A84ParCod = new int[1] ;
         T006138_A180MonCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.monedas__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.monedas__default(),
            new Object[][] {
                new Object[] {
               T00612_A180MonCod, T00612_A1234MonDsc, T00612_A1233MonAbr, T00612_A1235MonSts, T00612_A1236MonSunat
               }
               , new Object[] {
               T00613_A180MonCod, T00613_A1234MonDsc, T00613_A1233MonAbr, T00613_A1235MonSts, T00613_A1236MonSunat
               }
               , new Object[] {
               T00614_A180MonCod, T00614_A1234MonDsc, T00614_A1233MonAbr, T00614_A1235MonSts, T00614_A1236MonSunat
               }
               , new Object[] {
               T00615_A180MonCod
               }
               , new Object[] {
               T00616_A180MonCod
               }
               , new Object[] {
               T00617_A180MonCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006111_A2385ProCosProdCod
               }
               , new Object[] {
               T006112_A412PagReg
               }
               , new Object[] {
               T006113_A365EntCod, T006113_A403MVLEntCod, T006113_A404MVLEITem
               }
               , new Object[] {
               T006114_A358CajCod, T006114_A391MVLCajCod, T006114_A392MVLITem
               }
               , new Object[] {
               T006115_A365EntCod, T006115_A366AperEntCod
               }
               , new Object[] {
               T006116_A358CajCod, T006116_A359AperCajCod
               }
               , new Object[] {
               T006117_A307TipMonCod, T006117_A308TipFech
               }
               , new Object[] {
               T006118_A289OrdCod
               }
               , new Object[] {
               T006119_A270LiqCod, T006119_A236LiqPrvCod, T006119_A271LiqCodItem
               }
               , new Object[] {
               T006120_A265LetPLetCod
               }
               , new Object[] {
               T006121_A260CPTipCod, T006121_A261CPComCod, T006121_A262CPPrvCod
               }
               , new Object[] {
               T006122_A149TipCod, T006122_A243ComCod, T006122_A244PrvCod
               }
               , new Object[] {
               T006123_A238CheqDCod
               }
               , new Object[] {
               T006124_A149TipCod, T006124_A24DocNum
               }
               , new Object[] {
               T006125_A224LotCliCod
               }
               , new Object[] {
               T006126_A204LetCLetCod
               }
               , new Object[] {
               T006127_A191ImpItem
               }
               , new Object[] {
               T006128_A184CCTipCod, T006128_A185CCDocNum
               }
               , new Object[] {
               T006129_A2280CBTipPre
               }
               , new Object[] {
               T006130_A372BanCod, T006130_A377CBCod
               }
               , new Object[] {
               T006131_A210PedCod
               }
               , new Object[] {
               T006132_A177CotCod
               }
               , new Object[] {
               T006133_A166CobTip, T006133_A167CobCod
               }
               , new Object[] {
               T006134_A150CLCheqDCod
               }
               , new Object[] {
               T006135_A144CLAntTipCod, T006135_A145CLAntDocNum
               }
               , new Object[] {
               T006136_A127VouAno, T006136_A128VouMes, T006136_A126TASICod, T006136_A129VouNum, T006136_A130VouDSec
               }
               , new Object[] {
               T006137_A83ParTip, T006137_A84ParCod
               }
               , new Object[] {
               T006138_A180MonCod
               }
            }
         );
         Z1235MonSts = 1;
         A1235MonSts = 1;
         i1235MonSts = 1;
      }

      private short Z1235MonSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1235MonSts ;
      private short Gx_BScreen ;
      private short RcdFound103 ;
      private short GX_JID ;
      private short nIsDirty_103 ;
      private short gxajaxcallmode ;
      private short i1235MonSts ;
      private int wcpOAV7MonCod ;
      private int Z180MonCod ;
      private int AV7MonCod ;
      private int trnEnded ;
      private int edtMonDsc_Enabled ;
      private int edtMonAbr_Enabled ;
      private int edtMonSunat_Enabled ;
      private int edtMonSts_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A180MonCod ;
      private int edtMonCod_Visible ;
      private int edtMonCod_Enabled ;
      private int AV13cMonCod ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int4 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z1234MonDsc ;
      private string Z1233MonAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtMonDsc_Internalname ;
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
      private string A1234MonDsc ;
      private string edtMonDsc_Jsonclick ;
      private string edtMonAbr_Internalname ;
      private string A1233MonAbr ;
      private string edtMonAbr_Jsonclick ;
      private string edtMonSunat_Internalname ;
      private string edtMonSunat_Jsonclick ;
      private string edtMonSts_Internalname ;
      private string edtMonSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtMonCod_Internalname ;
      private string edtMonCod_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode103 ;
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
      private string Z1236MonSunat ;
      private string A1236MonSunat ;
      private string AV14SGAuDocGls ;
      private string AV15Codigo ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00614_A180MonCod ;
      private string[] T00614_A1234MonDsc ;
      private string[] T00614_A1233MonAbr ;
      private short[] T00614_A1235MonSts ;
      private string[] T00614_A1236MonSunat ;
      private int[] T00615_A180MonCod ;
      private int[] T00613_A180MonCod ;
      private string[] T00613_A1234MonDsc ;
      private string[] T00613_A1233MonAbr ;
      private short[] T00613_A1235MonSts ;
      private string[] T00613_A1236MonSunat ;
      private int[] T00616_A180MonCod ;
      private int[] T00617_A180MonCod ;
      private int[] T00612_A180MonCod ;
      private string[] T00612_A1234MonDsc ;
      private string[] T00612_A1233MonAbr ;
      private short[] T00612_A1235MonSts ;
      private string[] T00612_A1236MonSunat ;
      private string[] T006111_A2385ProCosProdCod ;
      private long[] T006112_A412PagReg ;
      private int[] T006113_A365EntCod ;
      private string[] T006113_A403MVLEntCod ;
      private int[] T006113_A404MVLEITem ;
      private int[] T006114_A358CajCod ;
      private string[] T006114_A391MVLCajCod ;
      private int[] T006114_A392MVLITem ;
      private int[] T006115_A365EntCod ;
      private string[] T006115_A366AperEntCod ;
      private int[] T006116_A358CajCod ;
      private string[] T006116_A359AperCajCod ;
      private int[] T006117_A307TipMonCod ;
      private DateTime[] T006117_A308TipFech ;
      private string[] T006118_A289OrdCod ;
      private string[] T006119_A270LiqCod ;
      private string[] T006119_A236LiqPrvCod ;
      private int[] T006119_A271LiqCodItem ;
      private string[] T006120_A265LetPLetCod ;
      private string[] T006121_A260CPTipCod ;
      private string[] T006121_A261CPComCod ;
      private string[] T006121_A262CPPrvCod ;
      private string[] T006122_A149TipCod ;
      private string[] T006122_A243ComCod ;
      private string[] T006122_A244PrvCod ;
      private string[] T006123_A238CheqDCod ;
      private string[] T006124_A149TipCod ;
      private string[] T006124_A24DocNum ;
      private string[] T006125_A224LotCliCod ;
      private string[] T006126_A204LetCLetCod ;
      private long[] T006127_A191ImpItem ;
      private string[] T006128_A184CCTipCod ;
      private string[] T006128_A185CCDocNum ;
      private int[] T006129_A2280CBTipPre ;
      private int[] T006130_A372BanCod ;
      private string[] T006130_A377CBCod ;
      private string[] T006131_A210PedCod ;
      private string[] T006132_A177CotCod ;
      private string[] T006133_A166CobTip ;
      private string[] T006133_A167CobCod ;
      private string[] T006134_A150CLCheqDCod ;
      private string[] T006135_A144CLAntTipCod ;
      private string[] T006135_A145CLAntDocNum ;
      private short[] T006136_A127VouAno ;
      private short[] T006136_A128VouMes ;
      private int[] T006136_A126TASICod ;
      private string[] T006136_A129VouNum ;
      private int[] T006136_A130VouDSec ;
      private string[] T006137_A83ParTip ;
      private int[] T006137_A84ParCod ;
      private int[] T006138_A180MonCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
   }

   public class monedas__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class monedas__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
       ,new ForEachCursor(def[26])
       ,new ForEachCursor(def[27])
       ,new ForEachCursor(def[28])
       ,new ForEachCursor(def[29])
       ,new ForEachCursor(def[30])
       ,new ForEachCursor(def[31])
       ,new ForEachCursor(def[32])
       ,new ForEachCursor(def[33])
       ,new ForEachCursor(def[34])
       ,new ForEachCursor(def[35])
       ,new ForEachCursor(def[36])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00614;
        prmT00614 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT00615;
        prmT00615 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT00613;
        prmT00613 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT00616;
        prmT00616 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT00617;
        prmT00617 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT00612;
        prmT00612 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT00618;
        prmT00618 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0) ,
        new ParDef("@MonDsc",GXType.NChar,100,0) ,
        new ParDef("@MonAbr",GXType.NChar,5,0) ,
        new ParDef("@MonSts",GXType.Int16,1,0) ,
        new ParDef("@MonSunat",GXType.NVarChar,3,0)
        };
        Object[] prmT00619;
        prmT00619 = new Object[] {
        new ParDef("@MonDsc",GXType.NChar,100,0) ,
        new ParDef("@MonAbr",GXType.NChar,5,0) ,
        new ParDef("@MonSts",GXType.Int16,1,0) ,
        new ParDef("@MonSunat",GXType.NVarChar,3,0) ,
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006110;
        prmT006110 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006111;
        prmT006111 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006112;
        prmT006112 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006113;
        prmT006113 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006114;
        prmT006114 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006115;
        prmT006115 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006116;
        prmT006116 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006117;
        prmT006117 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006118;
        prmT006118 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006119;
        prmT006119 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006120;
        prmT006120 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006121;
        prmT006121 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006122;
        prmT006122 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006123;
        prmT006123 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006124;
        prmT006124 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006125;
        prmT006125 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006126;
        prmT006126 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006127;
        prmT006127 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006128;
        prmT006128 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006129;
        prmT006129 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006130;
        prmT006130 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006131;
        prmT006131 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006132;
        prmT006132 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006133;
        prmT006133 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006134;
        prmT006134 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006135;
        prmT006135 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006136;
        prmT006136 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006137;
        prmT006137 = new Object[] {
        new ParDef("@MonCod",GXType.Int32,6,0)
        };
        Object[] prmT006138;
        prmT006138 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00612", "SELECT [MonCod], [MonDsc], [MonAbr], [MonSts], [MonSunat] FROM [CMONEDAS] WITH (UPDLOCK) WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00612,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00613", "SELECT [MonCod], [MonDsc], [MonAbr], [MonSts], [MonSunat] FROM [CMONEDAS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT00613,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00614", "SELECT TM1.[MonCod], TM1.[MonDsc], TM1.[MonAbr], TM1.[MonSts], TM1.[MonSunat] FROM [CMONEDAS] TM1 WHERE TM1.[MonCod] = @MonCod ORDER BY TM1.[MonCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00614,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00615", "SELECT [MonCod] FROM [CMONEDAS] WHERE [MonCod] = @MonCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00615,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00616", "SELECT TOP 1 [MonCod] FROM [CMONEDAS] WHERE ( [MonCod] > @MonCod) ORDER BY [MonCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00616,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00617", "SELECT TOP 1 [MonCod] FROM [CMONEDAS] WHERE ( [MonCod] < @MonCod) ORDER BY [MonCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00617,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00618", "INSERT INTO [CMONEDAS]([MonCod], [MonDsc], [MonAbr], [MonSts], [MonSunat]) VALUES(@MonCod, @MonDsc, @MonAbr, @MonSts, @MonSunat)", GxErrorMask.GX_NOMASK,prmT00618)
           ,new CursorDef("T00619", "UPDATE [CMONEDAS] SET [MonDsc]=@MonDsc, [MonAbr]=@MonAbr, [MonSts]=@MonSts, [MonSunat]=@MonSunat  WHERE [MonCod] = @MonCod", GxErrorMask.GX_NOMASK,prmT00619)
           ,new CursorDef("T006110", "DELETE FROM [CMONEDAS]  WHERE [MonCod] = @MonCod", GxErrorMask.GX_NOMASK,prmT006110)
           ,new CursorDef("T006111", "SELECT TOP 1 [ProCosProdCod] FROM [PROCOSTOMATERIAS] WHERE [ProCosMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006111,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006112", "SELECT TOP 1 [PagReg] FROM [TSPAGOS] WHERE [PagMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006112,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006113", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE [MVLEMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006113,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006114", "SELECT TOP 1 [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE [MVLMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006114,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006115", "SELECT TOP 1 [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] WHERE [AperEMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006115,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006116", "SELECT TOP 1 [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] WHERE [AperMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006116,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006117", "SELECT TOP 1 [TipMonCod], [TipFech] FROM [CTIPOCAMBIO] WHERE [TipMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006117,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006118", "SELECT TOP 1 [OrdCod] FROM [CPORDEN] WHERE [OrdMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006118,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006119", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACION] WHERE [LiqMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006119,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006120", "SELECT TOP 1 [LetPLetCod] FROM [CPLETRAS] WHERE [LetPMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006120,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006121", "SELECT TOP 1 [CPTipCod], [CPComCod], [CPPrvCod] FROM [CPCUENTAPAGAR] WHERE [CPMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006121,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006122", "SELECT TOP 1 [TipCod], [ComCod], [PrvCod] FROM [CPCOMPRAS] WHERE [ComMon] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006122,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006123", "SELECT TOP 1 [CheqDCod] FROM [CPCHEQUEDIFERIDO] WHERE [CheqDMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006123,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006124", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [DocMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006124,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006125", "SELECT TOP 1 [LotCliCod] FROM [CLVENTALOTES] WHERE [LotMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006125,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006126", "SELECT TOP 1 [LetCLetCod] FROM [CLLETRAS] WHERE [LetCMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006126,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006127", "SELECT TOP 1 [ImpItem] FROM [CLDOCUMENTOS] WHERE [ImpMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006127,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006128", "SELECT TOP 1 [CCTipCod], [CCDocNum] FROM [CLCUENTACOBRAR] WHERE [CCmonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006128,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006129", "SELECT TOP 1 [CBTipPre] FROM [CBPRESUPUESTOTIPO] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006129,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006130", "SELECT TOP 1 [BanCod], [CBCod] FROM [TSCUENTABANCO] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006130,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006131", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006131,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006132", "SELECT TOP 1 [CotCod] FROM [CLCOTIZA] WHERE [MonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006132,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006133", "SELECT TOP 1 [CobTip], [CobCod] FROM [CLCOBRANZA] WHERE [CobMon] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006133,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006134", "SELECT TOP 1 [CLCheqDCod] FROM [CLCHEQUEDIFERIDO] WHERE [CLCheqDMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006134,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006135", "SELECT TOP 1 [CLAntTipCod], [CLAntDocNum] FROM [CLANTICIPOS] WHERE [CLAntMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006135,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006136", "SELECT TOP 1 [VouAno], [VouMes], [TASICod], [VouNum], [VouDSec] FROM [CBVOUCHERDET] WHERE [VouDMon] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006136,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006137", "SELECT TOP 1 [ParTip], [ParCod] FROM [CBPARAMDET] WHERE [ParMonCod] = @MonCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006137,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006138", "SELECT [MonCod] FROM [CMONEDAS] ORDER BY [MonCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006138,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
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
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 15);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 24 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 25 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 26 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 27 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 28 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 29 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
     }
     getresults30( cursor, rslt, buf) ;
  }

  public void getresults30( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
  {
     switch ( cursor )
     {
           case 30 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 31 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 32 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 33 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 34 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 10);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              return;
           case 35 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 36 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
