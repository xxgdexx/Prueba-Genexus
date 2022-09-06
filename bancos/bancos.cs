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
namespace GeneXus.Programs.bancos {
   public class bancos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vCBANCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASACBANCOD6A168( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "bancos.bancos.aspx")), "bancos.bancos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "bancos.bancos.aspx")))) ;
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
                  AV7BanCod = (int)(NumberUtil.Val( GetPar( "BanCod"), "."));
                  AssignAttri("", false, "AV7BanCod", StringUtil.LTrimStr( (decimal)(AV7BanCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vBANCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7BanCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Bancos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtBanDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public bancos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public bancos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_BanCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7BanCod = aP1_BanCod;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtBanDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBanDsc_Internalname, "Banco", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBanDsc_Internalname, StringUtil.RTrim( A482BanDsc), StringUtil.RTrim( context.localUtil.Format( A482BanDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBanDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtBanDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\Bancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtBanAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBanAbr_Internalname, "Abreviatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBanAbr_Internalname, StringUtil.RTrim( A481BanAbr), StringUtil.RTrim( context.localUtil.Format( A481BanAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBanAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBanAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\Bancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtBanSunat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBanSunat_Internalname, "Codigo Sunat", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBanSunat_Internalname, StringUtil.RTrim( A484BanSunat), StringUtil.RTrim( context.localUtil.Format( A484BanSunat, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBanSunat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBanSunat_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Bancos\\Bancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtBanSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtBanSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtBanSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A483BanSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtBanSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A483BanSts), "9") : context.localUtil.Format( (decimal)(A483BanSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBanSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtBanSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\Bancos.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\Bancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\Bancos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Bancos\\Bancos.htm");
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
         GxWebStd.gx_single_line_edit( context, edtBanCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A372BanCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A372BanCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtBanCod_Jsonclick, 0, "Attribute", "", "", "", "", edtBanCod_Visible, edtBanCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Bancos\\Bancos.htm");
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
         E116A2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z372BanCod = (int)(context.localUtil.CToN( cgiGet( "Z372BanCod"), ".", ","));
               Z482BanDsc = cgiGet( "Z482BanDsc");
               Z481BanAbr = cgiGet( "Z481BanAbr");
               Z484BanSunat = cgiGet( "Z484BanSunat");
               Z483BanSts = (short)(context.localUtil.CToN( cgiGet( "Z483BanSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7BanCod = (int)(context.localUtil.CToN( cgiGet( "vBANCOD"), ".", ","));
               AV13cBanCod = (int)(context.localUtil.CToN( cgiGet( "vCBANCOD"), ".", ","));
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
               A482BanDsc = cgiGet( edtBanDsc_Internalname);
               AssignAttri("", false, "A482BanDsc", A482BanDsc);
               A481BanAbr = cgiGet( edtBanAbr_Internalname);
               AssignAttri("", false, "A481BanAbr", A481BanAbr);
               A484BanSunat = cgiGet( edtBanSunat_Internalname);
               AssignAttri("", false, "A484BanSunat", A484BanSunat);
               if ( ( ( context.localUtil.CToN( cgiGet( edtBanSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBanSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BANSTS");
                  AnyError = 1;
                  GX_FocusControl = edtBanSts_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A483BanSts = 0;
                  AssignAttri("", false, "A483BanSts", StringUtil.Str( (decimal)(A483BanSts), 1, 0));
               }
               else
               {
                  A483BanSts = (short)(context.localUtil.CToN( cgiGet( edtBanSts_Internalname), ".", ","));
                  AssignAttri("", false, "A483BanSts", StringUtil.Str( (decimal)(A483BanSts), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtBanCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtBanCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "BANCOD");
                  AnyError = 1;
                  GX_FocusControl = edtBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A372BanCod = 0;
                  AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
               }
               else
               {
                  A372BanCod = (int)(context.localUtil.CToN( cgiGet( edtBanCod_Internalname), ".", ","));
                  AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Bancos");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A372BanCod != Z372BanCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("bancos\\bancos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A372BanCod = (int)(NumberUtil.Val( GetPar( "BanCod"), "."));
                  AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
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
                     sMode168 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode168;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound168 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_6A0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "BANCOD");
                        AnyError = 1;
                        GX_FocusControl = edtBanCod_Internalname;
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
                           E116A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E126A2 ();
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
            E126A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll6A168( ) ;
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
            DisableAttributes6A168( ) ;
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

      protected void CONFIRM_6A0( )
      {
         BeforeValidate6A168( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls6A168( ) ;
            }
            else
            {
               CheckExtendedTable6A168( ) ;
               CloseExtendedTableCursors6A168( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption6A0( )
      {
      }

      protected void E116A2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtBanCod_Visible = 0;
         AssignProp("", false, edtBanCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtBanCod_Visible), 5, 0), true);
      }

      protected void E126A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV14SGAuDocGls = "Banco N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A372BanCod), 10, 0)) + " " + StringUtil.Trim( A482BanDsc);
            AV15Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A372BanCod), 10, 0));
            GXt_char1 = "TES";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV14SGAuDocGls, ref  AV15Codigo, ref  AV15Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("bancos.bancosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM6A168( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z482BanDsc = T006A3_A482BanDsc[0];
               Z481BanAbr = T006A3_A481BanAbr[0];
               Z484BanSunat = T006A3_A484BanSunat[0];
               Z483BanSts = T006A3_A483BanSts[0];
            }
            else
            {
               Z482BanDsc = A482BanDsc;
               Z481BanAbr = A481BanAbr;
               Z484BanSunat = A484BanSunat;
               Z483BanSts = A483BanSts;
            }
         }
         if ( GX_JID == -10 )
         {
            Z372BanCod = A372BanCod;
            Z482BanDsc = A482BanDsc;
            Z481BanAbr = A481BanAbr;
            Z484BanSunat = A484BanSunat;
            Z483BanSts = A483BanSts;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7BanCod) )
         {
            A372BanCod = AV7BanCod;
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
         }
         if ( ! (0==AV7BanCod) )
         {
            edtBanCod_Enabled = 0;
            AssignProp("", false, edtBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanCod_Enabled), 5, 0), true);
         }
         else
         {
            edtBanCod_Enabled = 1;
            AssignProp("", false, edtBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7BanCod) )
         {
            edtBanCod_Enabled = 0;
            AssignProp("", false, edtBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A483BanSts) && ( Gx_BScreen == 0 ) )
         {
            A483BanSts = 1;
            AssignAttri("", false, "A483BanSts", StringUtil.Str( (decimal)(A483BanSts), 1, 0));
         }
      }

      protected void Load6A168( )
      {
         /* Using cursor T006A4 */
         pr_default.execute(2, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound168 = 1;
            A482BanDsc = T006A4_A482BanDsc[0];
            AssignAttri("", false, "A482BanDsc", A482BanDsc);
            A481BanAbr = T006A4_A481BanAbr[0];
            AssignAttri("", false, "A481BanAbr", A481BanAbr);
            A484BanSunat = T006A4_A484BanSunat[0];
            AssignAttri("", false, "A484BanSunat", A484BanSunat);
            A483BanSts = T006A4_A483BanSts[0];
            AssignAttri("", false, "A483BanSts", StringUtil.Str( (decimal)(A483BanSts), 1, 0));
            ZM6A168( -10) ;
         }
         pr_default.close(2);
         OnLoadActions6A168( ) ;
      }

      protected void OnLoadActions6A168( )
      {
      }

      protected void CheckExtendedTable6A168( )
      {
         nIsDirty_168 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A482BanDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Banco", "", "", "", "", "", "", "", ""), 1, "BANDSC");
            AnyError = 1;
            GX_FocusControl = edtBanDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A481BanAbr)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Abreviatura", "", "", "", "", "", "", "", ""), 1, "BANABR");
            AnyError = 1;
            GX_FocusControl = edtBanAbr_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A484BanSunat)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cod.Sunat", "", "", "", "", "", "", "", ""), 1, "BANSUNAT");
            AnyError = 1;
            GX_FocusControl = edtBanSunat_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors6A168( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey6A168( )
      {
         /* Using cursor T006A5 */
         pr_default.execute(3, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound168 = 1;
         }
         else
         {
            RcdFound168 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T006A3 */
         pr_default.execute(1, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM6A168( 10) ;
            RcdFound168 = 1;
            A372BanCod = T006A3_A372BanCod[0];
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            A482BanDsc = T006A3_A482BanDsc[0];
            AssignAttri("", false, "A482BanDsc", A482BanDsc);
            A481BanAbr = T006A3_A481BanAbr[0];
            AssignAttri("", false, "A481BanAbr", A481BanAbr);
            A484BanSunat = T006A3_A484BanSunat[0];
            AssignAttri("", false, "A484BanSunat", A484BanSunat);
            A483BanSts = T006A3_A483BanSts[0];
            AssignAttri("", false, "A483BanSts", StringUtil.Str( (decimal)(A483BanSts), 1, 0));
            Z372BanCod = A372BanCod;
            sMode168 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load6A168( ) ;
            if ( AnyError == 1 )
            {
               RcdFound168 = 0;
               InitializeNonKey6A168( ) ;
            }
            Gx_mode = sMode168;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound168 = 0;
            InitializeNonKey6A168( ) ;
            sMode168 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode168;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey6A168( ) ;
         if ( RcdFound168 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound168 = 0;
         /* Using cursor T006A6 */
         pr_default.execute(4, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T006A6_A372BanCod[0] < A372BanCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T006A6_A372BanCod[0] > A372BanCod ) ) )
            {
               A372BanCod = T006A6_A372BanCod[0];
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
               RcdFound168 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound168 = 0;
         /* Using cursor T006A7 */
         pr_default.execute(5, new Object[] {A372BanCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T006A7_A372BanCod[0] > A372BanCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T006A7_A372BanCod[0] < A372BanCod ) ) )
            {
               A372BanCod = T006A7_A372BanCod[0];
               AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
               RcdFound168 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey6A168( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtBanDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert6A168( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound168 == 1 )
            {
               if ( A372BanCod != Z372BanCod )
               {
                  A372BanCod = Z372BanCod;
                  AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "BANCOD");
                  AnyError = 1;
                  GX_FocusControl = edtBanCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtBanDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update6A168( ) ;
                  GX_FocusControl = edtBanDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A372BanCod != Z372BanCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtBanDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert6A168( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "BANCOD");
                     AnyError = 1;
                     GX_FocusControl = edtBanCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtBanDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert6A168( ) ;
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
         if ( A372BanCod != Z372BanCod )
         {
            A372BanCod = Z372BanCod;
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "BANCOD");
            AnyError = 1;
            GX_FocusControl = edtBanCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtBanDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency6A168( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T006A2 */
            pr_default.execute(0, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSBANCOS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z482BanDsc, T006A2_A482BanDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z481BanAbr, T006A2_A481BanAbr[0]) != 0 ) || ( StringUtil.StrCmp(Z484BanSunat, T006A2_A484BanSunat[0]) != 0 ) || ( Z483BanSts != T006A2_A483BanSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z482BanDsc, T006A2_A482BanDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("bancos.bancos:[seudo value changed for attri]"+"BanDsc");
                  GXUtil.WriteLogRaw("Old: ",Z482BanDsc);
                  GXUtil.WriteLogRaw("Current: ",T006A2_A482BanDsc[0]);
               }
               if ( StringUtil.StrCmp(Z481BanAbr, T006A2_A481BanAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("bancos.bancos:[seudo value changed for attri]"+"BanAbr");
                  GXUtil.WriteLogRaw("Old: ",Z481BanAbr);
                  GXUtil.WriteLogRaw("Current: ",T006A2_A481BanAbr[0]);
               }
               if ( StringUtil.StrCmp(Z484BanSunat, T006A2_A484BanSunat[0]) != 0 )
               {
                  GXUtil.WriteLog("bancos.bancos:[seudo value changed for attri]"+"BanSunat");
                  GXUtil.WriteLogRaw("Old: ",Z484BanSunat);
                  GXUtil.WriteLogRaw("Current: ",T006A2_A484BanSunat[0]);
               }
               if ( Z483BanSts != T006A2_A483BanSts[0] )
               {
                  GXUtil.WriteLog("bancos.bancos:[seudo value changed for attri]"+"BanSts");
                  GXUtil.WriteLogRaw("Old: ",Z483BanSts);
                  GXUtil.WriteLogRaw("Current: ",T006A2_A483BanSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"TSBANCOS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert6A168( )
      {
         BeforeValidate6A168( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6A168( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM6A168( 0) ;
            CheckOptimisticConcurrency6A168( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6A168( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert6A168( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006A8 */
                     pr_default.execute(6, new Object[] {A372BanCod, A482BanDsc, A481BanAbr, A484BanSunat, A483BanSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("TSBANCOS");
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
                           ResetCaption6A0( ) ;
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
               Load6A168( ) ;
            }
            EndLevel6A168( ) ;
         }
         CloseExtendedTableCursors6A168( ) ;
      }

      protected void Update6A168( )
      {
         BeforeValidate6A168( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable6A168( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6A168( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm6A168( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate6A168( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T006A9 */
                     pr_default.execute(7, new Object[] {A482BanDsc, A481BanAbr, A484BanSunat, A483BanSts, A372BanCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("TSBANCOS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"TSBANCOS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate6A168( ) ;
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
            EndLevel6A168( ) ;
         }
         CloseExtendedTableCursors6A168( ) ;
      }

      protected void DeferredUpdate6A168( )
      {
      }

      protected void delete( )
      {
         BeforeValidate6A168( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency6A168( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls6A168( ) ;
            AfterConfirm6A168( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete6A168( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T006A10 */
                  pr_default.execute(8, new Object[] {A372BanCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("TSBANCOS");
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
         sMode168 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel6A168( ) ;
         Gx_mode = sMode168;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls6A168( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T006A11 */
            pr_default.execute(9, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T006A12 */
            pr_default.execute(10, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TSTRANSFERENCIABANCOS"+" ("+"Bancos Destino"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T006A13 */
            pr_default.execute(11, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TSTRANSFERENCIABANCOS"+" ("+"Banco Origen"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T006A14 */
            pr_default.execute(12, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pagos a proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T006A15 */
            pr_default.execute(13, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos Bancos Otros"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T006A16 */
            pr_default.execute(14, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimiento de Libro Bancos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T006A17 */
            pr_default.execute(15, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuentas de Banco"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T006A18 */
            pr_default.execute(16, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T006A19 */
            pr_default.execute(17, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura Caja"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T006A20 */
            pr_default.execute(18, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Anticipos Proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T006A21 */
            pr_default.execute(19, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Datos Generales Proveedores"+" ("+"Banco"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T006A22 */
            pr_default.execute(20, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Datos Generales Proveedores"+" ("+"Banco"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
            /* Using cursor T006A23 */
            pr_default.execute(21, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(21) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Liquidación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(21);
            /* Using cursor T006A24 */
            pr_default.execute(22, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(22) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(22);
            /* Using cursor T006A25 */
            pr_default.execute(23, new Object[] {A372BanCod});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Cabecera"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
         }
      }

      protected void EndLevel6A168( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete6A168( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("bancos.bancos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues6A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("bancos.bancos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart6A168( )
      {
         /* Scan By routine */
         /* Using cursor T006A26 */
         pr_default.execute(24);
         RcdFound168 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound168 = 1;
            A372BanCod = T006A26_A372BanCod[0];
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext6A168( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound168 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound168 = 1;
            A372BanCod = T006A26_A372BanCod[0];
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
         }
      }

      protected void ScanEnd6A168( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm6A168( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cBanCod;
            GXt_char3 = "BANCOS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cBanCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cBanCod", StringUtil.LTrimStr( (decimal)(AV13cBanCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A372BanCod = AV13cBanCod;
            AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
         }
      }

      protected void BeforeInsert6A168( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate6A168( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete6A168( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete6A168( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate6A168( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes6A168( )
      {
         edtBanDsc_Enabled = 0;
         AssignProp("", false, edtBanDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanDsc_Enabled), 5, 0), true);
         edtBanAbr_Enabled = 0;
         AssignProp("", false, edtBanAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanAbr_Enabled), 5, 0), true);
         edtBanSunat_Enabled = 0;
         AssignProp("", false, edtBanSunat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanSunat_Enabled), 5, 0), true);
         edtBanSts_Enabled = 0;
         AssignProp("", false, edtBanSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanSts_Enabled), 5, 0), true);
         edtBanCod_Enabled = 0;
         AssignProp("", false, edtBanCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtBanCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes6A168( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues6A0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810262976", false, true);
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
         GXEncryptionTmp = "bancos.bancos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7BanCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("bancos.bancos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Bancos");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("bancos\\bancos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z372BanCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z372BanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z482BanDsc", StringUtil.RTrim( Z482BanDsc));
         GxWebStd.gx_hidden_field( context, "Z481BanAbr", StringUtil.RTrim( Z481BanAbr));
         GxWebStd.gx_hidden_field( context, "Z484BanSunat", StringUtil.RTrim( Z484BanSunat));
         GxWebStd.gx_hidden_field( context, "Z483BanSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z483BanSts), 1, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vBANCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7BanCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vBANCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7BanCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCBANCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cBanCod), 6, 0, ".", "")));
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
         GXEncryptionTmp = "bancos.bancos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7BanCod,6,0));
         return formatLink("bancos.bancos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Bancos.Bancos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Bancos" ;
      }

      protected void InitializeNonKey6A168( )
      {
         AV13cBanCod = 0;
         AssignAttri("", false, "AV13cBanCod", StringUtil.LTrimStr( (decimal)(AV13cBanCod), 6, 0));
         A482BanDsc = "";
         AssignAttri("", false, "A482BanDsc", A482BanDsc);
         A481BanAbr = "";
         AssignAttri("", false, "A481BanAbr", A481BanAbr);
         A484BanSunat = "";
         AssignAttri("", false, "A484BanSunat", A484BanSunat);
         A483BanSts = 1;
         AssignAttri("", false, "A483BanSts", StringUtil.Str( (decimal)(A483BanSts), 1, 0));
         Z482BanDsc = "";
         Z481BanAbr = "";
         Z484BanSunat = "";
         Z483BanSts = 0;
      }

      protected void InitAll6A168( )
      {
         A372BanCod = 0;
         AssignAttri("", false, "A372BanCod", StringUtil.LTrimStr( (decimal)(A372BanCod), 6, 0));
         InitializeNonKey6A168( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A483BanSts = i483BanSts;
         AssignAttri("", false, "A483BanSts", StringUtil.Str( (decimal)(A483BanSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810262994", true, true);
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
         context.AddJavascriptSource("bancos/bancos.js", "?202281810262995", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtBanDsc_Internalname = "BANDSC";
         edtBanAbr_Internalname = "BANABR";
         edtBanSunat_Internalname = "BANSUNAT";
         edtBanSts_Internalname = "BANSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtBanCod_Internalname = "BANCOD";
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
         Form.Caption = "Bancos";
         edtBanCod_Jsonclick = "";
         edtBanCod_Enabled = 1;
         edtBanCod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtBanSts_Jsonclick = "";
         edtBanSts_Enabled = 1;
         edtBanSunat_Jsonclick = "";
         edtBanSunat_Enabled = 1;
         edtBanAbr_Jsonclick = "";
         edtBanAbr_Enabled = 1;
         edtBanDsc_Jsonclick = "";
         edtBanDsc_Enabled = 1;
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

      protected void GX4ASACBANCOD6A168( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cBanCod;
            GXt_char3 = "BANCOS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cBanCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cBanCod", StringUtil.LTrimStr( (decimal)(AV13cBanCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cBanCod), 6, 0, ".", "")))+"\"") ;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7BanCod',fld:'vBANCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7BanCod',fld:'vBANCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E126A2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A372BanCod',fld:'BANCOD',pic:'ZZZZZ9'},{av:'A482BanDsc',fld:'BANDSC',pic:''},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_BANDSC","{handler:'Valid_Bandsc',iparms:[]");
         setEventMetadata("VALID_BANDSC",",oparms:[]}");
         setEventMetadata("VALID_BANABR","{handler:'Valid_Banabr',iparms:[]");
         setEventMetadata("VALID_BANABR",",oparms:[]}");
         setEventMetadata("VALID_BANSUNAT","{handler:'Valid_Bansunat',iparms:[]");
         setEventMetadata("VALID_BANSUNAT",",oparms:[]}");
         setEventMetadata("VALID_BANCOD","{handler:'Valid_Bancod',iparms:[]");
         setEventMetadata("VALID_BANCOD",",oparms:[]}");
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
         Z482BanDsc = "";
         Z481BanAbr = "";
         Z484BanSunat = "";
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
         A482BanDsc = "";
         A481BanAbr = "";
         A484BanSunat = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode168 = "";
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
         T006A4_A372BanCod = new int[1] ;
         T006A4_A482BanDsc = new string[] {""} ;
         T006A4_A481BanAbr = new string[] {""} ;
         T006A4_A484BanSunat = new string[] {""} ;
         T006A4_A483BanSts = new short[1] ;
         T006A5_A372BanCod = new int[1] ;
         T006A3_A372BanCod = new int[1] ;
         T006A3_A482BanDsc = new string[] {""} ;
         T006A3_A481BanAbr = new string[] {""} ;
         T006A3_A484BanSunat = new string[] {""} ;
         T006A3_A483BanSts = new short[1] ;
         T006A6_A372BanCod = new int[1] ;
         T006A7_A372BanCod = new int[1] ;
         T006A2_A372BanCod = new int[1] ;
         T006A2_A482BanDsc = new string[] {""} ;
         T006A2_A481BanAbr = new string[] {""} ;
         T006A2_A484BanSunat = new string[] {""} ;
         T006A2_A483BanSts = new short[1] ;
         T006A11_A348UsuCod = new string[] {""} ;
         T006A12_A423TSTransCod = new string[] {""} ;
         T006A13_A423TSTransCod = new string[] {""} ;
         T006A14_A412PagReg = new long[1] ;
         T006A15_A387TSMovCod = new string[] {""} ;
         T006A16_A379LBBanCod = new int[1] ;
         T006A16_A380LBCBCod = new string[] {""} ;
         T006A16_A381LBRegistro = new string[] {""} ;
         T006A17_A372BanCod = new int[1] ;
         T006A17_A377CBCod = new string[] {""} ;
         T006A18_A365EntCod = new int[1] ;
         T006A18_A366AperEntCod = new string[] {""} ;
         T006A19_A358CajCod = new int[1] ;
         T006A19_A359AperCajCod = new string[] {""} ;
         T006A20_A354TSAntCod = new string[] {""} ;
         T006A21_A244PrvCod = new string[] {""} ;
         T006A22_A244PrvCod = new string[] {""} ;
         T006A23_A270LiqCod = new string[] {""} ;
         T006A23_A236LiqPrvCod = new string[] {""} ;
         T006A23_A271LiqCodItem = new int[1] ;
         T006A24_A166CobTip = new string[] {""} ;
         T006A24_A167CobCod = new string[] {""} ;
         T006A24_A173Item = new int[1] ;
         T006A25_A166CobTip = new string[] {""} ;
         T006A25_A167CobCod = new string[] {""} ;
         T006A26_A372BanCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.bancos.bancos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancos.bancos__default(),
            new Object[][] {
                new Object[] {
               T006A2_A372BanCod, T006A2_A482BanDsc, T006A2_A481BanAbr, T006A2_A484BanSunat, T006A2_A483BanSts
               }
               , new Object[] {
               T006A3_A372BanCod, T006A3_A482BanDsc, T006A3_A481BanAbr, T006A3_A484BanSunat, T006A3_A483BanSts
               }
               , new Object[] {
               T006A4_A372BanCod, T006A4_A482BanDsc, T006A4_A481BanAbr, T006A4_A484BanSunat, T006A4_A483BanSts
               }
               , new Object[] {
               T006A5_A372BanCod
               }
               , new Object[] {
               T006A6_A372BanCod
               }
               , new Object[] {
               T006A7_A372BanCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T006A11_A348UsuCod
               }
               , new Object[] {
               T006A12_A423TSTransCod
               }
               , new Object[] {
               T006A13_A423TSTransCod
               }
               , new Object[] {
               T006A14_A412PagReg
               }
               , new Object[] {
               T006A15_A387TSMovCod
               }
               , new Object[] {
               T006A16_A379LBBanCod, T006A16_A380LBCBCod, T006A16_A381LBRegistro
               }
               , new Object[] {
               T006A17_A372BanCod, T006A17_A377CBCod
               }
               , new Object[] {
               T006A18_A365EntCod, T006A18_A366AperEntCod
               }
               , new Object[] {
               T006A19_A358CajCod, T006A19_A359AperCajCod
               }
               , new Object[] {
               T006A20_A354TSAntCod
               }
               , new Object[] {
               T006A21_A244PrvCod
               }
               , new Object[] {
               T006A22_A244PrvCod
               }
               , new Object[] {
               T006A23_A270LiqCod, T006A23_A236LiqPrvCod, T006A23_A271LiqCodItem
               }
               , new Object[] {
               T006A24_A166CobTip, T006A24_A167CobCod, T006A24_A173Item
               }
               , new Object[] {
               T006A25_A166CobTip, T006A25_A167CobCod
               }
               , new Object[] {
               T006A26_A372BanCod
               }
            }
         );
         Z483BanSts = 1;
         A483BanSts = 1;
         i483BanSts = 1;
      }

      private short Z483BanSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A483BanSts ;
      private short Gx_BScreen ;
      private short RcdFound168 ;
      private short GX_JID ;
      private short nIsDirty_168 ;
      private short gxajaxcallmode ;
      private short i483BanSts ;
      private int wcpOAV7BanCod ;
      private int Z372BanCod ;
      private int AV7BanCod ;
      private int trnEnded ;
      private int edtBanDsc_Enabled ;
      private int edtBanAbr_Enabled ;
      private int edtBanSunat_Enabled ;
      private int edtBanSts_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A372BanCod ;
      private int edtBanCod_Visible ;
      private int edtBanCod_Enabled ;
      private int AV13cBanCod ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int4 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z482BanDsc ;
      private string Z481BanAbr ;
      private string Z484BanSunat ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtBanDsc_Internalname ;
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
      private string A482BanDsc ;
      private string edtBanDsc_Jsonclick ;
      private string edtBanAbr_Internalname ;
      private string A481BanAbr ;
      private string edtBanAbr_Jsonclick ;
      private string edtBanSunat_Internalname ;
      private string A484BanSunat ;
      private string edtBanSunat_Jsonclick ;
      private string edtBanSts_Internalname ;
      private string edtBanSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtBanCod_Internalname ;
      private string edtBanCod_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode168 ;
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
      private IDataStoreProvider pr_default ;
      private int[] T006A4_A372BanCod ;
      private string[] T006A4_A482BanDsc ;
      private string[] T006A4_A481BanAbr ;
      private string[] T006A4_A484BanSunat ;
      private short[] T006A4_A483BanSts ;
      private int[] T006A5_A372BanCod ;
      private int[] T006A3_A372BanCod ;
      private string[] T006A3_A482BanDsc ;
      private string[] T006A3_A481BanAbr ;
      private string[] T006A3_A484BanSunat ;
      private short[] T006A3_A483BanSts ;
      private int[] T006A6_A372BanCod ;
      private int[] T006A7_A372BanCod ;
      private int[] T006A2_A372BanCod ;
      private string[] T006A2_A482BanDsc ;
      private string[] T006A2_A481BanAbr ;
      private string[] T006A2_A484BanSunat ;
      private short[] T006A2_A483BanSts ;
      private string[] T006A11_A348UsuCod ;
      private string[] T006A12_A423TSTransCod ;
      private string[] T006A13_A423TSTransCod ;
      private long[] T006A14_A412PagReg ;
      private string[] T006A15_A387TSMovCod ;
      private int[] T006A16_A379LBBanCod ;
      private string[] T006A16_A380LBCBCod ;
      private string[] T006A16_A381LBRegistro ;
      private int[] T006A17_A372BanCod ;
      private string[] T006A17_A377CBCod ;
      private int[] T006A18_A365EntCod ;
      private string[] T006A18_A366AperEntCod ;
      private int[] T006A19_A358CajCod ;
      private string[] T006A19_A359AperCajCod ;
      private string[] T006A20_A354TSAntCod ;
      private string[] T006A21_A244PrvCod ;
      private string[] T006A22_A244PrvCod ;
      private string[] T006A23_A270LiqCod ;
      private string[] T006A23_A236LiqPrvCod ;
      private int[] T006A23_A271LiqCodItem ;
      private string[] T006A24_A166CobTip ;
      private string[] T006A24_A167CobCod ;
      private int[] T006A24_A173Item ;
      private string[] T006A25_A166CobTip ;
      private string[] T006A25_A167CobCod ;
      private int[] T006A26_A372BanCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
   }

   public class bancos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class bancos__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT006A4;
        prmT006A4 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A5;
        prmT006A5 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A3;
        prmT006A3 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A6;
        prmT006A6 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A7;
        prmT006A7 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A2;
        prmT006A2 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A8;
        prmT006A8 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0) ,
        new ParDef("@BanDsc",GXType.NChar,100,0) ,
        new ParDef("@BanAbr",GXType.NChar,5,0) ,
        new ParDef("@BanSunat",GXType.NChar,5,0) ,
        new ParDef("@BanSts",GXType.Int16,1,0)
        };
        Object[] prmT006A9;
        prmT006A9 = new Object[] {
        new ParDef("@BanDsc",GXType.NChar,100,0) ,
        new ParDef("@BanAbr",GXType.NChar,5,0) ,
        new ParDef("@BanSunat",GXType.NChar,5,0) ,
        new ParDef("@BanSts",GXType.Int16,1,0) ,
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A10;
        prmT006A10 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A11;
        prmT006A11 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A12;
        prmT006A12 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A13;
        prmT006A13 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A14;
        prmT006A14 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A15;
        prmT006A15 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A16;
        prmT006A16 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A17;
        prmT006A17 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A18;
        prmT006A18 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A19;
        prmT006A19 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A20;
        prmT006A20 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A21;
        prmT006A21 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A22;
        prmT006A22 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A23;
        prmT006A23 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A24;
        prmT006A24 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A25;
        prmT006A25 = new Object[] {
        new ParDef("@BanCod",GXType.Int32,6,0)
        };
        Object[] prmT006A26;
        prmT006A26 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T006A2", "SELECT [BanCod], [BanDsc], [BanAbr], [BanSunat], [BanSts] FROM [TSBANCOS] WITH (UPDLOCK) WHERE [BanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006A3", "SELECT [BanCod], [BanDsc], [BanAbr], [BanSunat], [BanSts] FROM [TSBANCOS] WHERE [BanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006A4", "SELECT TM1.[BanCod], TM1.[BanDsc], TM1.[BanAbr], TM1.[BanSunat], TM1.[BanSts] FROM [TSBANCOS] TM1 WHERE TM1.[BanCod] = @BanCod ORDER BY TM1.[BanCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006A4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006A5", "SELECT [BanCod] FROM [TSBANCOS] WHERE [BanCod] = @BanCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T006A6", "SELECT TOP 1 [BanCod] FROM [TSBANCOS] WHERE ( [BanCod] > @BanCod) ORDER BY [BanCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006A6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A7", "SELECT TOP 1 [BanCod] FROM [TSBANCOS] WHERE ( [BanCod] < @BanCod) ORDER BY [BanCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT006A7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A8", "INSERT INTO [TSBANCOS]([BanCod], [BanDsc], [BanAbr], [BanSunat], [BanSts]) VALUES(@BanCod, @BanDsc, @BanAbr, @BanSunat, @BanSts)", GxErrorMask.GX_NOMASK,prmT006A8)
           ,new CursorDef("T006A9", "UPDATE [TSBANCOS] SET [BanDsc]=@BanDsc, [BanAbr]=@BanAbr, [BanSunat]=@BanSunat, [BanSts]=@BanSts  WHERE [BanCod] = @BanCod", GxErrorMask.GX_NOMASK,prmT006A9)
           ,new CursorDef("T006A10", "DELETE FROM [TSBANCOS]  WHERE [BanCod] = @BanCod", GxErrorMask.GX_NOMASK,prmT006A10)
           ,new CursorDef("T006A11", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE [UsuMosBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A12", "SELECT TOP 1 [TSTransCod] FROM [TSTRANSFERENCIABANCOS] WHERE [TSTransBanDestino] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A13", "SELECT TOP 1 [TSTransCod] FROM [TSTRANSFERENCIABANCOS] WHERE [TSTransBanOrigen] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A14", "SELECT TOP 1 [PagReg] FROM [TSPAGOS] WHERE [PagBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A15", "SELECT TOP 1 [TSMovCod] FROM [TSMOVBANCOS] WHERE [TSMovBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A16", "SELECT TOP 1 [LBBanCod], [LBCBCod], [LBRegistro] FROM [TSLIBROBANCOS] WHERE [LBBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A17", "SELECT TOP 1 [BanCod], [CBCod] FROM [TSCUENTABANCO] WHERE [BanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A18", "SELECT TOP 1 [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] WHERE [AperEBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A19", "SELECT TOP 1 [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] WHERE [AperBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A20", "SELECT TOP 1 [TSAntCod] FROM [TSANTICIPOS] WHERE [TSAntBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A21", "SELECT TOP 1 [PrvCod] FROM [CPPROVEEDORES] WHERE [PrvBanCod2] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A22", "SELECT TOP 1 [PrvCod] FROM [CPPROVEEDORES] WHERE [PrvBanCod1] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A23", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACION] WHERE [LiqBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A24", "SELECT TOP 1 [CobTip], [CobCod], [Item] FROM [CLCOBRANZADET] WHERE [CobDBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A25", "SELECT TOP 1 [CobTip], [CobCod] FROM [CLCOBRANZA] WHERE [CobBanCod] = @BanCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT006A25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T006A26", "SELECT [BanCod] FROM [TSBANCOS] ORDER BY [BanCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT006A26,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getString(4, 5);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getString(4, 5);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getString(4, 5);
              ((short[]) buf[4])[0] = rslt.getShort(5);
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              return;
           case 16 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 17 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 21 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 23 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 24 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
