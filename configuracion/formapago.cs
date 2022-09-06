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
   public class formapago : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vCFORCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASACFORCOD5K81( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.formapago.aspx")), "configuracion.formapago.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.formapago.aspx")))) ;
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
                  AV7ForCod = (int)(NumberUtil.Val( GetPar( "ForCod"), "."));
                  AssignAttri("", false, "AV7ForCod", StringUtil.LTrimStr( (decimal)(AV7ForCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vFORCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ForCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Forma Pago", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtForDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public formapago( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public formapago( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_ForCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ForCod = aP1_ForCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkForBanSts = new GXCheckbox();
         cmbForSts = new GXCombobox();
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
         A987ForBanSts = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A987ForBanSts), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A987ForBanSts", StringUtil.Str( (decimal)(A987ForBanSts), 1, 0));
         if ( cmbForSts.ItemCount > 0 )
         {
            A989ForSts = (short)(NumberUtil.Val( cmbForSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A989ForSts), 1, 0))), "."));
            AssignAttri("", false, "A989ForSts", StringUtil.Str( (decimal)(A989ForSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbForSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A989ForSts), 1, 0));
            AssignProp("", false, cmbForSts_Internalname, "Values", cmbForSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtForDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtForDsc_Internalname, "Forma de Pago", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtForDsc_Internalname, StringUtil.RTrim( A988ForDsc), StringUtil.RTrim( context.localUtil.Format( A988ForDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtForDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtForDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\FormaPago.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtForAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtForAbr_Internalname, "Abreviatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtForAbr_Internalname, StringUtil.RTrim( A986ForAbr), StringUtil.RTrim( context.localUtil.Format( A986ForAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtForAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtForAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\FormaPago.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtForSunat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtForSunat_Internalname, "Codigo Sunat", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtForSunat_Internalname, StringUtil.RTrim( A990ForSunat), StringUtil.RTrim( context.localUtil.Format( A990ForSunat, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtForSunat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtForSunat_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\FormaPago.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkForBanSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkForBanSts_Internalname, "Afecta Banco", "col-sm-3 AttributeCheckBoxLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "AttributeCheckBox";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkForBanSts_Internalname, StringUtil.Str( (decimal)(A987ForBanSts), 1, 0), "", "Afecta Banco", 1, chkForBanSts.Enabled, "1", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(37, this, 1, 0,"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,37);\"");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbForSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbForSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbForSts, cmbForSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A989ForSts), 1, 0)), 1, cmbForSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbForSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "", true, 1, "HLP_Configuracion\\FormaPago.htm");
         cmbForSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A989ForSts), 1, 0));
         AssignProp("", false, cmbForSts_Internalname, "Values", (string)(cmbForSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\FormaPago.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\FormaPago.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\FormaPago.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtForCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A143ForCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A143ForCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtForCod_Jsonclick, 0, "Attribute", "", "", "", "", edtForCod_Visible, edtForCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\FormaPago.htm");
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
         E115K2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z143ForCod = (int)(context.localUtil.CToN( cgiGet( "Z143ForCod"), ".", ","));
               Z988ForDsc = cgiGet( "Z988ForDsc");
               Z986ForAbr = cgiGet( "Z986ForAbr");
               Z990ForSunat = cgiGet( "Z990ForSunat");
               Z987ForBanSts = (short)(context.localUtil.CToN( cgiGet( "Z987ForBanSts"), ".", ","));
               Z989ForSts = (short)(context.localUtil.CToN( cgiGet( "Z989ForSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7ForCod = (int)(context.localUtil.CToN( cgiGet( "vFORCOD"), ".", ","));
               AV15cForCod = (int)(context.localUtil.CToN( cgiGet( "vCFORCOD"), ".", ","));
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
               A988ForDsc = cgiGet( edtForDsc_Internalname);
               AssignAttri("", false, "A988ForDsc", A988ForDsc);
               A986ForAbr = cgiGet( edtForAbr_Internalname);
               AssignAttri("", false, "A986ForAbr", A986ForAbr);
               A990ForSunat = cgiGet( edtForSunat_Internalname);
               AssignAttri("", false, "A990ForSunat", A990ForSunat);
               if ( ( ( ((StringUtil.StrCmp(cgiGet( chkForBanSts_Internalname), "1")==0) ? 1 : 0) < 0 ) ) || ( ( ((StringUtil.StrCmp(cgiGet( chkForBanSts_Internalname), "1")==0) ? 1 : 0) > 9 ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FORBANSTS");
                  AnyError = 1;
                  GX_FocusControl = chkForBanSts_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A987ForBanSts = 0;
                  AssignAttri("", false, "A987ForBanSts", StringUtil.Str( (decimal)(A987ForBanSts), 1, 0));
               }
               else
               {
                  A987ForBanSts = (short)(((StringUtil.StrCmp(cgiGet( chkForBanSts_Internalname), "1")==0) ? 1 : 0));
                  AssignAttri("", false, "A987ForBanSts", StringUtil.Str( (decimal)(A987ForBanSts), 1, 0));
               }
               cmbForSts.CurrentValue = cgiGet( cmbForSts_Internalname);
               A989ForSts = (short)(NumberUtil.Val( cgiGet( cmbForSts_Internalname), "."));
               AssignAttri("", false, "A989ForSts", StringUtil.Str( (decimal)(A989ForSts), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtForCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtForCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FORCOD");
                  AnyError = 1;
                  GX_FocusControl = edtForCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A143ForCod = 0;
                  AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
               }
               else
               {
                  A143ForCod = (int)(context.localUtil.CToN( cgiGet( edtForCod_Internalname), ".", ","));
                  AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"FormaPago");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A143ForCod != Z143ForCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\formapago:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A143ForCod = (int)(NumberUtil.Val( GetPar( "ForCod"), "."));
                  AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
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
                     sMode81 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode81;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound81 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5K0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "FORCOD");
                        AnyError = 1;
                        GX_FocusControl = edtForCod_Internalname;
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
                           E115K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E125K2 ();
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
            E125K2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5K81( ) ;
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
            DisableAttributes5K81( ) ;
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

      protected void CONFIRM_5K0( )
      {
         BeforeValidate5K81( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5K81( ) ;
            }
            else
            {
               CheckExtendedTable5K81( ) ;
               CloseExtendedTableCursors5K81( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5K0( )
      {
      }

      protected void E115K2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV10WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtForCod_Visible = 0;
         AssignProp("", false, edtForCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtForCod_Visible), 5, 0), true);
      }

      protected void E125K2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV13SGAuDocGls = "Forma de Pago N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A143ForCod), 10, 0)) + " " + StringUtil.Trim( A988ForDsc);
            AV14Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A143ForCod), 10, 0));
            GXt_char1 = "CNF";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV13SGAuDocGls, ref  AV14Codigo, ref  AV14Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.formapagoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM5K81( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z988ForDsc = T005K3_A988ForDsc[0];
               Z986ForAbr = T005K3_A986ForAbr[0];
               Z990ForSunat = T005K3_A990ForSunat[0];
               Z987ForBanSts = T005K3_A987ForBanSts[0];
               Z989ForSts = T005K3_A989ForSts[0];
            }
            else
            {
               Z988ForDsc = A988ForDsc;
               Z986ForAbr = A986ForAbr;
               Z990ForSunat = A990ForSunat;
               Z987ForBanSts = A987ForBanSts;
               Z989ForSts = A989ForSts;
            }
         }
         if ( GX_JID == -10 )
         {
            Z143ForCod = A143ForCod;
            Z988ForDsc = A988ForDsc;
            Z986ForAbr = A986ForAbr;
            Z990ForSunat = A990ForSunat;
            Z987ForBanSts = A987ForBanSts;
            Z989ForSts = A989ForSts;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ForCod) )
         {
            A143ForCod = AV7ForCod;
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
         }
         if ( ! (0==AV7ForCod) )
         {
            edtForCod_Enabled = 0;
            AssignProp("", false, edtForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtForCod_Enabled), 5, 0), true);
         }
         else
         {
            edtForCod_Enabled = 1;
            AssignProp("", false, edtForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtForCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7ForCod) )
         {
            edtForCod_Enabled = 0;
            AssignProp("", false, edtForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtForCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A989ForSts) && ( Gx_BScreen == 0 ) )
         {
            A989ForSts = 1;
            AssignAttri("", false, "A989ForSts", StringUtil.Str( (decimal)(A989ForSts), 1, 0));
         }
      }

      protected void Load5K81( )
      {
         /* Using cursor T005K4 */
         pr_default.execute(2, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound81 = 1;
            A988ForDsc = T005K4_A988ForDsc[0];
            AssignAttri("", false, "A988ForDsc", A988ForDsc);
            A986ForAbr = T005K4_A986ForAbr[0];
            AssignAttri("", false, "A986ForAbr", A986ForAbr);
            A990ForSunat = T005K4_A990ForSunat[0];
            AssignAttri("", false, "A990ForSunat", A990ForSunat);
            A987ForBanSts = T005K4_A987ForBanSts[0];
            AssignAttri("", false, "A987ForBanSts", StringUtil.Str( (decimal)(A987ForBanSts), 1, 0));
            A989ForSts = T005K4_A989ForSts[0];
            AssignAttri("", false, "A989ForSts", StringUtil.Str( (decimal)(A989ForSts), 1, 0));
            ZM5K81( -10) ;
         }
         pr_default.close(2);
         OnLoadActions5K81( ) ;
      }

      protected void OnLoadActions5K81( )
      {
      }

      protected void CheckExtendedTable5K81( )
      {
         nIsDirty_81 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A988ForDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Forma de pago", "", "", "", "", "", "", "", ""), 1, "FORDSC");
            AnyError = 1;
            GX_FocusControl = edtForDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A986ForAbr)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Abreviatura forma pago", "", "", "", "", "", "", "", ""), 1, "FORABR");
            AnyError = 1;
            GX_FocusControl = edtForAbr_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A990ForSunat)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cod.Sunat", "", "", "", "", "", "", "", ""), 1, "FORSUNAT");
            AnyError = 1;
            GX_FocusControl = edtForSunat_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5K81( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey5K81( )
      {
         /* Using cursor T005K5 */
         pr_default.execute(3, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound81 = 1;
         }
         else
         {
            RcdFound81 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005K3 */
         pr_default.execute(1, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5K81( 10) ;
            RcdFound81 = 1;
            A143ForCod = T005K3_A143ForCod[0];
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            A988ForDsc = T005K3_A988ForDsc[0];
            AssignAttri("", false, "A988ForDsc", A988ForDsc);
            A986ForAbr = T005K3_A986ForAbr[0];
            AssignAttri("", false, "A986ForAbr", A986ForAbr);
            A990ForSunat = T005K3_A990ForSunat[0];
            AssignAttri("", false, "A990ForSunat", A990ForSunat);
            A987ForBanSts = T005K3_A987ForBanSts[0];
            AssignAttri("", false, "A987ForBanSts", StringUtil.Str( (decimal)(A987ForBanSts), 1, 0));
            A989ForSts = T005K3_A989ForSts[0];
            AssignAttri("", false, "A989ForSts", StringUtil.Str( (decimal)(A989ForSts), 1, 0));
            Z143ForCod = A143ForCod;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load5K81( ) ;
            if ( AnyError == 1 )
            {
               RcdFound81 = 0;
               InitializeNonKey5K81( ) ;
            }
            Gx_mode = sMode81;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound81 = 0;
            InitializeNonKey5K81( ) ;
            sMode81 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode81;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5K81( ) ;
         if ( RcdFound81 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound81 = 0;
         /* Using cursor T005K6 */
         pr_default.execute(4, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T005K6_A143ForCod[0] < A143ForCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T005K6_A143ForCod[0] > A143ForCod ) ) )
            {
               A143ForCod = T005K6_A143ForCod[0];
               AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
               RcdFound81 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound81 = 0;
         /* Using cursor T005K7 */
         pr_default.execute(5, new Object[] {A143ForCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T005K7_A143ForCod[0] > A143ForCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T005K7_A143ForCod[0] < A143ForCod ) ) )
            {
               A143ForCod = T005K7_A143ForCod[0];
               AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
               RcdFound81 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5K81( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtForDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5K81( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound81 == 1 )
            {
               if ( A143ForCod != Z143ForCod )
               {
                  A143ForCod = Z143ForCod;
                  AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FORCOD");
                  AnyError = 1;
                  GX_FocusControl = edtForCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtForDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5K81( ) ;
                  GX_FocusControl = edtForDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A143ForCod != Z143ForCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtForDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5K81( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FORCOD");
                     AnyError = 1;
                     GX_FocusControl = edtForCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtForDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5K81( ) ;
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
         if ( A143ForCod != Z143ForCod )
         {
            A143ForCod = Z143ForCod;
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FORCOD");
            AnyError = 1;
            GX_FocusControl = edtForCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtForDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5K81( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005K2 */
            pr_default.execute(0, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CFORMAPAGO"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z988ForDsc, T005K2_A988ForDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z986ForAbr, T005K2_A986ForAbr[0]) != 0 ) || ( StringUtil.StrCmp(Z990ForSunat, T005K2_A990ForSunat[0]) != 0 ) || ( Z987ForBanSts != T005K2_A987ForBanSts[0] ) || ( Z989ForSts != T005K2_A989ForSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z988ForDsc, T005K2_A988ForDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.formapago:[seudo value changed for attri]"+"ForDsc");
                  GXUtil.WriteLogRaw("Old: ",Z988ForDsc);
                  GXUtil.WriteLogRaw("Current: ",T005K2_A988ForDsc[0]);
               }
               if ( StringUtil.StrCmp(Z986ForAbr, T005K2_A986ForAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.formapago:[seudo value changed for attri]"+"ForAbr");
                  GXUtil.WriteLogRaw("Old: ",Z986ForAbr);
                  GXUtil.WriteLogRaw("Current: ",T005K2_A986ForAbr[0]);
               }
               if ( StringUtil.StrCmp(Z990ForSunat, T005K2_A990ForSunat[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.formapago:[seudo value changed for attri]"+"ForSunat");
                  GXUtil.WriteLogRaw("Old: ",Z990ForSunat);
                  GXUtil.WriteLogRaw("Current: ",T005K2_A990ForSunat[0]);
               }
               if ( Z987ForBanSts != T005K2_A987ForBanSts[0] )
               {
                  GXUtil.WriteLog("configuracion.formapago:[seudo value changed for attri]"+"ForBanSts");
                  GXUtil.WriteLogRaw("Old: ",Z987ForBanSts);
                  GXUtil.WriteLogRaw("Current: ",T005K2_A987ForBanSts[0]);
               }
               if ( Z989ForSts != T005K2_A989ForSts[0] )
               {
                  GXUtil.WriteLog("configuracion.formapago:[seudo value changed for attri]"+"ForSts");
                  GXUtil.WriteLogRaw("Old: ",Z989ForSts);
                  GXUtil.WriteLogRaw("Current: ",T005K2_A989ForSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CFORMAPAGO"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5K81( )
      {
         BeforeValidate5K81( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5K81( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5K81( 0) ;
            CheckOptimisticConcurrency5K81( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5K81( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5K81( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005K8 */
                     pr_default.execute(6, new Object[] {A143ForCod, A988ForDsc, A986ForAbr, A990ForSunat, A987ForBanSts, A989ForSts});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CFORMAPAGO");
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
                           ResetCaption5K0( ) ;
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
               Load5K81( ) ;
            }
            EndLevel5K81( ) ;
         }
         CloseExtendedTableCursors5K81( ) ;
      }

      protected void Update5K81( )
      {
         BeforeValidate5K81( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5K81( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5K81( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5K81( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5K81( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005K9 */
                     pr_default.execute(7, new Object[] {A988ForDsc, A986ForAbr, A990ForSunat, A987ForBanSts, A989ForSts, A143ForCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CFORMAPAGO");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CFORMAPAGO"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5K81( ) ;
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
            EndLevel5K81( ) ;
         }
         CloseExtendedTableCursors5K81( ) ;
      }

      protected void DeferredUpdate5K81( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5K81( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5K81( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5K81( ) ;
            AfterConfirm5K81( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5K81( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005K10 */
                  pr_default.execute(8, new Object[] {A143ForCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CFORMAPAGO");
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
         sMode81 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5K81( ) ;
         Gx_mode = sMode81;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5K81( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T005K11 */
            pr_default.execute(9, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pagos a proveedores"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T005K12 */
            pr_default.execute(10, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T005K13 */
            pr_default.execute(11, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos de Caja Chica"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T005K14 */
            pr_default.execute(12, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Libro Bancos - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T005K15 */
            pr_default.execute(13, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimiento de Libro Bancos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T005K16 */
            pr_default.execute(14, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura de Entregas a Rendir"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T005K17 */
            pr_default.execute(15, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Apertura Caja"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T005K18 */
            pr_default.execute(16, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Liquidación"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T005K19 */
            pr_default.execute(17, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"TSTRANSFERENCIABANCOS"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T005K20 */
            pr_default.execute(18, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Movimientos Bancos Otros"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T005K21 */
            pr_default.execute(19, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Retención"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
            /* Using cursor T005K22 */
            pr_default.execute(20, new Object[] {A143ForCod});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Detalle"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void EndLevel5K81( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5K81( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.formapago",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5K0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.formapago",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5K81( )
      {
         /* Scan By routine */
         /* Using cursor T005K23 */
         pr_default.execute(21);
         RcdFound81 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound81 = 1;
            A143ForCod = T005K23_A143ForCod[0];
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5K81( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound81 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound81 = 1;
            A143ForCod = T005K23_A143ForCod[0];
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
         }
      }

      protected void ScanEnd5K81( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm5K81( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV15cForCod;
            GXt_char3 = "FORMAPAGO";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV15cForCod = (int)(GXt_int4);
            AssignAttri("", false, "AV15cForCod", StringUtil.LTrimStr( (decimal)(AV15cForCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A143ForCod = AV15cForCod;
            AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
         }
      }

      protected void BeforeInsert5K81( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5K81( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5K81( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5K81( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5K81( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5K81( )
      {
         edtForDsc_Enabled = 0;
         AssignProp("", false, edtForDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtForDsc_Enabled), 5, 0), true);
         edtForAbr_Enabled = 0;
         AssignProp("", false, edtForAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtForAbr_Enabled), 5, 0), true);
         edtForSunat_Enabled = 0;
         AssignProp("", false, edtForSunat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtForSunat_Enabled), 5, 0), true);
         chkForBanSts.Enabled = 0;
         AssignProp("", false, chkForBanSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkForBanSts.Enabled), 5, 0), true);
         cmbForSts.Enabled = 0;
         AssignProp("", false, cmbForSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbForSts.Enabled), 5, 0), true);
         edtForCod_Enabled = 0;
         AssignProp("", false, edtForCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtForCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5K81( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5K0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810261044", false, true);
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
         GXEncryptionTmp = "configuracion.formapago.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ForCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.formapago.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"FormaPago");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\formapago:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z143ForCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z143ForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z988ForDsc", StringUtil.RTrim( Z988ForDsc));
         GxWebStd.gx_hidden_field( context, "Z986ForAbr", StringUtil.RTrim( Z986ForAbr));
         GxWebStd.gx_hidden_field( context, "Z990ForSunat", StringUtil.RTrim( Z990ForSunat));
         GxWebStd.gx_hidden_field( context, "Z987ForBanSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z987ForBanSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z989ForSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z989ForSts), 1, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vFORCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ForCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFORCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ForCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCFORCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cForCod), 6, 0, ".", "")));
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
         GXEncryptionTmp = "configuracion.formapago.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7ForCod,6,0));
         return formatLink("configuracion.formapago.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.FormaPago" ;
      }

      public override string GetPgmdesc( )
      {
         return "Forma Pago" ;
      }

      protected void InitializeNonKey5K81( )
      {
         AV15cForCod = 0;
         AssignAttri("", false, "AV15cForCod", StringUtil.LTrimStr( (decimal)(AV15cForCod), 6, 0));
         A988ForDsc = "";
         AssignAttri("", false, "A988ForDsc", A988ForDsc);
         A986ForAbr = "";
         AssignAttri("", false, "A986ForAbr", A986ForAbr);
         A990ForSunat = "";
         AssignAttri("", false, "A990ForSunat", A990ForSunat);
         A987ForBanSts = 0;
         AssignAttri("", false, "A987ForBanSts", StringUtil.Str( (decimal)(A987ForBanSts), 1, 0));
         A989ForSts = 1;
         AssignAttri("", false, "A989ForSts", StringUtil.Str( (decimal)(A989ForSts), 1, 0));
         Z988ForDsc = "";
         Z986ForAbr = "";
         Z990ForSunat = "";
         Z987ForBanSts = 0;
         Z989ForSts = 0;
      }

      protected void InitAll5K81( )
      {
         A143ForCod = 0;
         AssignAttri("", false, "A143ForCod", StringUtil.LTrimStr( (decimal)(A143ForCod), 6, 0));
         InitializeNonKey5K81( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A989ForSts = i989ForSts;
         AssignAttri("", false, "A989ForSts", StringUtil.Str( (decimal)(A989ForSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810261062", true, true);
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
         context.AddJavascriptSource("configuracion/formapago.js", "?202281810261063", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtForDsc_Internalname = "FORDSC";
         edtForAbr_Internalname = "FORABR";
         edtForSunat_Internalname = "FORSUNAT";
         chkForBanSts_Internalname = "FORBANSTS";
         cmbForSts_Internalname = "FORSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtForCod_Internalname = "FORCOD";
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
         Form.Caption = "Forma Pago";
         edtForCod_Jsonclick = "";
         edtForCod_Enabled = 1;
         edtForCod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbForSts_Jsonclick = "";
         cmbForSts.Enabled = 1;
         chkForBanSts.Enabled = 1;
         edtForSunat_Jsonclick = "";
         edtForSunat_Enabled = 1;
         edtForAbr_Jsonclick = "";
         edtForAbr_Enabled = 1;
         edtForDsc_Jsonclick = "";
         edtForDsc_Enabled = 1;
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

      protected void GX4ASACFORCOD5K81( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV15cForCod;
            GXt_char3 = "FORMAPAGO";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV15cForCod = (int)(GXt_int4);
            AssignAttri("", false, "AV15cForCod", StringUtil.LTrimStr( (decimal)(AV15cForCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV15cForCod), 6, 0, ".", "")))+"\"") ;
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
         chkForBanSts.Name = "FORBANSTS";
         chkForBanSts.WebTags = "";
         chkForBanSts.Caption = "";
         AssignProp("", false, chkForBanSts_Internalname, "TitleCaption", chkForBanSts.Caption, true);
         chkForBanSts.CheckedValue = "0";
         A987ForBanSts = (short)(((StringUtil.StrCmp(StringUtil.LTrim( StringUtil.NToC( (decimal)(A987ForBanSts), 1, 0, ".", "")), "1")==0) ? 1 : 0));
         AssignAttri("", false, "A987ForBanSts", StringUtil.Str( (decimal)(A987ForBanSts), 1, 0));
         cmbForSts.Name = "FORSTS";
         cmbForSts.WebTags = "";
         cmbForSts.addItem("1", "ACTIVO", 0);
         cmbForSts.addItem("0", "INACTIVO", 0);
         if ( cmbForSts.ItemCount > 0 )
         {
            if ( (0==A989ForSts) )
            {
               A989ForSts = 1;
               AssignAttri("", false, "A989ForSts", StringUtil.Str( (decimal)(A989ForSts), 1, 0));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7ForCod',fld:'vFORCOD',pic:'ZZZZZ9',hsh:true},{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]");
         setEventMetadata("ENTER",",oparms:[{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ForCod',fld:'vFORCOD',pic:'ZZZZZ9',hsh:true},{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]}");
         setEventMetadata("AFTER TRN","{handler:'E125K2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A143ForCod',fld:'FORCOD',pic:'ZZZZZ9'},{av:'A988ForDsc',fld:'FORDSC',pic:''},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]}");
         setEventMetadata("VALID_FORDSC","{handler:'Valid_Fordsc',iparms:[{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]");
         setEventMetadata("VALID_FORDSC",",oparms:[{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]}");
         setEventMetadata("VALID_FORABR","{handler:'Valid_Forabr',iparms:[{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]");
         setEventMetadata("VALID_FORABR",",oparms:[{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]}");
         setEventMetadata("VALID_FORSUNAT","{handler:'Valid_Forsunat',iparms:[{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]");
         setEventMetadata("VALID_FORSUNAT",",oparms:[{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]}");
         setEventMetadata("VALID_FORCOD","{handler:'Valid_Forcod',iparms:[{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]");
         setEventMetadata("VALID_FORCOD",",oparms:[{av:'A987ForBanSts',fld:'FORBANSTS',pic:'9'}]}");
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
         Z988ForDsc = "";
         Z986ForAbr = "";
         Z990ForSunat = "";
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
         A988ForDsc = "";
         A986ForAbr = "";
         A990ForSunat = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode81 = "";
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
         T005K4_A143ForCod = new int[1] ;
         T005K4_A988ForDsc = new string[] {""} ;
         T005K4_A986ForAbr = new string[] {""} ;
         T005K4_A990ForSunat = new string[] {""} ;
         T005K4_A987ForBanSts = new short[1] ;
         T005K4_A989ForSts = new short[1] ;
         T005K5_A143ForCod = new int[1] ;
         T005K3_A143ForCod = new int[1] ;
         T005K3_A988ForDsc = new string[] {""} ;
         T005K3_A986ForAbr = new string[] {""} ;
         T005K3_A990ForSunat = new string[] {""} ;
         T005K3_A987ForBanSts = new short[1] ;
         T005K3_A989ForSts = new short[1] ;
         T005K6_A143ForCod = new int[1] ;
         T005K7_A143ForCod = new int[1] ;
         T005K2_A143ForCod = new int[1] ;
         T005K2_A988ForDsc = new string[] {""} ;
         T005K2_A986ForAbr = new string[] {""} ;
         T005K2_A990ForSunat = new string[] {""} ;
         T005K2_A987ForBanSts = new short[1] ;
         T005K2_A989ForSts = new short[1] ;
         T005K11_A412PagReg = new long[1] ;
         T005K12_A365EntCod = new int[1] ;
         T005K12_A403MVLEntCod = new string[] {""} ;
         T005K12_A404MVLEITem = new int[1] ;
         T005K13_A358CajCod = new int[1] ;
         T005K13_A391MVLCajCod = new string[] {""} ;
         T005K13_A392MVLITem = new int[1] ;
         T005K14_A379LBBanCod = new int[1] ;
         T005K14_A380LBCBCod = new string[] {""} ;
         T005K14_A381LBRegistro = new string[] {""} ;
         T005K14_A383LBDITem = new int[1] ;
         T005K15_A379LBBanCod = new int[1] ;
         T005K15_A380LBCBCod = new string[] {""} ;
         T005K15_A381LBRegistro = new string[] {""} ;
         T005K16_A365EntCod = new int[1] ;
         T005K16_A366AperEntCod = new string[] {""} ;
         T005K17_A358CajCod = new int[1] ;
         T005K17_A359AperCajCod = new string[] {""} ;
         T005K18_A270LiqCod = new string[] {""} ;
         T005K18_A236LiqPrvCod = new string[] {""} ;
         T005K18_A271LiqCodItem = new int[1] ;
         T005K19_A423TSTransCod = new string[] {""} ;
         T005K20_A387TSMovCod = new string[] {""} ;
         T005K21_A302CPRetCod = new string[] {""} ;
         T005K22_A166CobTip = new string[] {""} ;
         T005K22_A167CobCod = new string[] {""} ;
         T005K22_A173Item = new int[1] ;
         T005K23_A143ForCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.formapago__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.formapago__default(),
            new Object[][] {
                new Object[] {
               T005K2_A143ForCod, T005K2_A988ForDsc, T005K2_A986ForAbr, T005K2_A990ForSunat, T005K2_A987ForBanSts, T005K2_A989ForSts
               }
               , new Object[] {
               T005K3_A143ForCod, T005K3_A988ForDsc, T005K3_A986ForAbr, T005K3_A990ForSunat, T005K3_A987ForBanSts, T005K3_A989ForSts
               }
               , new Object[] {
               T005K4_A143ForCod, T005K4_A988ForDsc, T005K4_A986ForAbr, T005K4_A990ForSunat, T005K4_A987ForBanSts, T005K4_A989ForSts
               }
               , new Object[] {
               T005K5_A143ForCod
               }
               , new Object[] {
               T005K6_A143ForCod
               }
               , new Object[] {
               T005K7_A143ForCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005K11_A412PagReg
               }
               , new Object[] {
               T005K12_A365EntCod, T005K12_A403MVLEntCod, T005K12_A404MVLEITem
               }
               , new Object[] {
               T005K13_A358CajCod, T005K13_A391MVLCajCod, T005K13_A392MVLITem
               }
               , new Object[] {
               T005K14_A379LBBanCod, T005K14_A380LBCBCod, T005K14_A381LBRegistro, T005K14_A383LBDITem
               }
               , new Object[] {
               T005K15_A379LBBanCod, T005K15_A380LBCBCod, T005K15_A381LBRegistro
               }
               , new Object[] {
               T005K16_A365EntCod, T005K16_A366AperEntCod
               }
               , new Object[] {
               T005K17_A358CajCod, T005K17_A359AperCajCod
               }
               , new Object[] {
               T005K18_A270LiqCod, T005K18_A236LiqPrvCod, T005K18_A271LiqCodItem
               }
               , new Object[] {
               T005K19_A423TSTransCod
               }
               , new Object[] {
               T005K20_A387TSMovCod
               }
               , new Object[] {
               T005K21_A302CPRetCod
               }
               , new Object[] {
               T005K22_A166CobTip, T005K22_A167CobCod, T005K22_A173Item
               }
               , new Object[] {
               T005K23_A143ForCod
               }
            }
         );
         Z989ForSts = 1;
         A989ForSts = 1;
         i989ForSts = 1;
      }

      private short Z987ForBanSts ;
      private short Z989ForSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A987ForBanSts ;
      private short A989ForSts ;
      private short Gx_BScreen ;
      private short RcdFound81 ;
      private short GX_JID ;
      private short nIsDirty_81 ;
      private short gxajaxcallmode ;
      private short i989ForSts ;
      private int wcpOAV7ForCod ;
      private int Z143ForCod ;
      private int AV7ForCod ;
      private int trnEnded ;
      private int edtForDsc_Enabled ;
      private int edtForAbr_Enabled ;
      private int edtForSunat_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A143ForCod ;
      private int edtForCod_Visible ;
      private int edtForCod_Enabled ;
      private int AV15cForCod ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int4 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z988ForDsc ;
      private string Z986ForAbr ;
      private string Z990ForSunat ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtForDsc_Internalname ;
      private string cmbForSts_Internalname ;
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
      private string A988ForDsc ;
      private string edtForDsc_Jsonclick ;
      private string edtForAbr_Internalname ;
      private string A986ForAbr ;
      private string edtForAbr_Jsonclick ;
      private string edtForSunat_Internalname ;
      private string A990ForSunat ;
      private string edtForSunat_Jsonclick ;
      private string chkForBanSts_Internalname ;
      private string cmbForSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtForCod_Internalname ;
      private string edtForCod_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode81 ;
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
      private string AV13SGAuDocGls ;
      private string AV14Codigo ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkForBanSts ;
      private GXCombobox cmbForSts ;
      private IDataStoreProvider pr_default ;
      private int[] T005K4_A143ForCod ;
      private string[] T005K4_A988ForDsc ;
      private string[] T005K4_A986ForAbr ;
      private string[] T005K4_A990ForSunat ;
      private short[] T005K4_A987ForBanSts ;
      private short[] T005K4_A989ForSts ;
      private int[] T005K5_A143ForCod ;
      private int[] T005K3_A143ForCod ;
      private string[] T005K3_A988ForDsc ;
      private string[] T005K3_A986ForAbr ;
      private string[] T005K3_A990ForSunat ;
      private short[] T005K3_A987ForBanSts ;
      private short[] T005K3_A989ForSts ;
      private int[] T005K6_A143ForCod ;
      private int[] T005K7_A143ForCod ;
      private int[] T005K2_A143ForCod ;
      private string[] T005K2_A988ForDsc ;
      private string[] T005K2_A986ForAbr ;
      private string[] T005K2_A990ForSunat ;
      private short[] T005K2_A987ForBanSts ;
      private short[] T005K2_A989ForSts ;
      private long[] T005K11_A412PagReg ;
      private int[] T005K12_A365EntCod ;
      private string[] T005K12_A403MVLEntCod ;
      private int[] T005K12_A404MVLEITem ;
      private int[] T005K13_A358CajCod ;
      private string[] T005K13_A391MVLCajCod ;
      private int[] T005K13_A392MVLITem ;
      private int[] T005K14_A379LBBanCod ;
      private string[] T005K14_A380LBCBCod ;
      private string[] T005K14_A381LBRegistro ;
      private int[] T005K14_A383LBDITem ;
      private int[] T005K15_A379LBBanCod ;
      private string[] T005K15_A380LBCBCod ;
      private string[] T005K15_A381LBRegistro ;
      private int[] T005K16_A365EntCod ;
      private string[] T005K16_A366AperEntCod ;
      private int[] T005K17_A358CajCod ;
      private string[] T005K17_A359AperCajCod ;
      private string[] T005K18_A270LiqCod ;
      private string[] T005K18_A236LiqPrvCod ;
      private int[] T005K18_A271LiqCodItem ;
      private string[] T005K19_A423TSTransCod ;
      private string[] T005K20_A387TSMovCod ;
      private string[] T005K21_A302CPRetCod ;
      private string[] T005K22_A166CobTip ;
      private string[] T005K22_A167CobCod ;
      private int[] T005K22_A173Item ;
      private int[] T005K23_A143ForCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV10WWPContext ;
   }

   public class formapago__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class formapago__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005K4;
        prmT005K4 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K5;
        prmT005K5 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K3;
        prmT005K3 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K6;
        prmT005K6 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K7;
        prmT005K7 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K2;
        prmT005K2 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K8;
        prmT005K8 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0) ,
        new ParDef("@ForDsc",GXType.NChar,100,0) ,
        new ParDef("@ForAbr",GXType.NChar,5,0) ,
        new ParDef("@ForSunat",GXType.NChar,5,0) ,
        new ParDef("@ForBanSts",GXType.Int16,1,0) ,
        new ParDef("@ForSts",GXType.Int16,1,0)
        };
        Object[] prmT005K9;
        prmT005K9 = new Object[] {
        new ParDef("@ForDsc",GXType.NChar,100,0) ,
        new ParDef("@ForAbr",GXType.NChar,5,0) ,
        new ParDef("@ForSunat",GXType.NChar,5,0) ,
        new ParDef("@ForBanSts",GXType.Int16,1,0) ,
        new ParDef("@ForSts",GXType.Int16,1,0) ,
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K10;
        prmT005K10 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K11;
        prmT005K11 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K12;
        prmT005K12 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K13;
        prmT005K13 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K14;
        prmT005K14 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K15;
        prmT005K15 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K16;
        prmT005K16 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K17;
        prmT005K17 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K18;
        prmT005K18 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K19;
        prmT005K19 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K20;
        prmT005K20 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K21;
        prmT005K21 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K22;
        prmT005K22 = new Object[] {
        new ParDef("@ForCod",GXType.Int32,6,0)
        };
        Object[] prmT005K23;
        prmT005K23 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T005K2", "SELECT [ForCod], [ForDsc], [ForAbr], [ForSunat], [ForBanSts], [ForSts] FROM [CFORMAPAGO] WITH (UPDLOCK) WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005K3", "SELECT [ForCod], [ForDsc], [ForAbr], [ForSunat], [ForBanSts], [ForSts] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005K4", "SELECT TM1.[ForCod], TM1.[ForDsc], TM1.[ForAbr], TM1.[ForSunat], TM1.[ForBanSts], TM1.[ForSts] FROM [CFORMAPAGO] TM1 WHERE TM1.[ForCod] = @ForCod ORDER BY TM1.[ForCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005K4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005K5", "SELECT [ForCod] FROM [CFORMAPAGO] WHERE [ForCod] = @ForCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005K6", "SELECT TOP 1 [ForCod] FROM [CFORMAPAGO] WHERE ( [ForCod] > @ForCod) ORDER BY [ForCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005K6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005K7", "SELECT TOP 1 [ForCod] FROM [CFORMAPAGO] WHERE ( [ForCod] < @ForCod) ORDER BY [ForCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005K7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005K8", "INSERT INTO [CFORMAPAGO]([ForCod], [ForDsc], [ForAbr], [ForSunat], [ForBanSts], [ForSts]) VALUES(@ForCod, @ForDsc, @ForAbr, @ForSunat, @ForBanSts, @ForSts)", GxErrorMask.GX_NOMASK,prmT005K8)
           ,new CursorDef("T005K9", "UPDATE [CFORMAPAGO] SET [ForDsc]=@ForDsc, [ForAbr]=@ForAbr, [ForSunat]=@ForSunat, [ForBanSts]=@ForBanSts, [ForSts]=@ForSts  WHERE [ForCod] = @ForCod", GxErrorMask.GX_NOMASK,prmT005K9)
           ,new CursorDef("T005K10", "DELETE FROM [CFORMAPAGO]  WHERE [ForCod] = @ForCod", GxErrorMask.GX_NOMASK,prmT005K10)
           ,new CursorDef("T005K11", "SELECT TOP 1 [PagReg] FROM [TSPAGOS] WHERE [PagForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005K11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005K12", "SELECT TOP 1 [EntCod], [MVLEntCod], [MVLEITem] FROM [TSMOVENTREGA] WHERE [MVLEForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005K12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005K13", "SELECT TOP 1 [CajCod], [MVLCajCod], [MVLITem] FROM [TSMOVCAJACHICA] WHERE [MVLForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005K13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005K14", "SELECT TOP 1 [LBBanCod], [LBCBCod], [LBRegistro], [LBDITem] FROM [TSLIBROBANCOSDET] WHERE [LBDForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005K14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005K15", "SELECT TOP 1 [LBBanCod], [LBCBCod], [LBRegistro] FROM [TSLIBROBANCOS] WHERE [LBForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005K15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005K16", "SELECT TOP 1 [EntCod], [AperEntCod] FROM [TSAPERTURAENTREGA] WHERE [AperEForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005K16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005K17", "SELECT TOP 1 [CajCod], [AperCajCod] FROM [TSAPERTURACAJA] WHERE [AperForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005K17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005K18", "SELECT TOP 1 [LiqCod], [LiqPrvCod], [LiqCodItem] FROM [CPLIQUIDACION] WHERE [LiqForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005K18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005K19", "SELECT TOP 1 [TSTransCod] FROM [TSTRANSFERENCIABANCOS] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005K19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005K20", "SELECT TOP 1 [TSMovCod] FROM [TSMOVBANCOS] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005K20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005K21", "SELECT TOP 1 [CPRetCod] FROM [CPRETENCION] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005K21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005K22", "SELECT TOP 1 [CobTip], [CobCod], [Item] FROM [CLCOBRANZADET] WHERE [ForCod] = @ForCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005K22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005K23", "SELECT [ForCod] FROM [CFORMAPAGO] ORDER BY [ForCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005K23,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getString(4, 5);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getString(4, 5);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              ((int[]) buf[3])[0] = rslt.getInt(4);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 10);
              return;
           case 14 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 10);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 20 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 21 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
