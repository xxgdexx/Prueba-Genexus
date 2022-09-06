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
   public class familia : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vCFAMCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASACFAMCOD5N80( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.familia.aspx")), "configuracion.familia.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.familia.aspx")))) ;
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
                  AV10FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  AssignAttri("", false, "AV10FamCod", StringUtil.LTrimStr( (decimal)(AV10FamCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vFAMCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10FamCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Familia", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFamDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public familia( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public familia( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_FamCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV10FamCod = aP1_FamCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbFamSts = new GXCombobox();
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
         if ( cmbFamSts.ItemCount > 0 )
         {
            A979FamSts = (short)(NumberUtil.Val( cmbFamSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A979FamSts), 1, 0))), "."));
            AssignAttri("", false, "A979FamSts", StringUtil.Str( (decimal)(A979FamSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbFamSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A979FamSts), 1, 0));
            AssignProp("", false, cmbFamSts_Internalname, "Values", cmbFamSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFamDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFamDsc_Internalname, "Familia", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFamDsc_Internalname, StringUtil.RTrim( A977FamDsc), StringUtil.RTrim( context.localUtil.Format( A977FamDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFamDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtFamDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Familia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFamAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFamAbr_Internalname, "Abreviatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFamAbr_Internalname, StringUtil.RTrim( A976FamAbr), StringUtil.RTrim( context.localUtil.Format( A976FamAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFamAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFamAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Familia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgFamFoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Foto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         A978FamFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000FamFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.PathToRelativeUrl( A978FamFoto));
         GxWebStd.gx_bitmap( context, imgFamFoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgFamFoto_Enabled, "", "", 1, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "", "", "", 0, A978FamFoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Configuracion\\Familia.htm");
         AssignProp("", false, imgFamFoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.PathToRelativeUrl( A978FamFoto)), true);
         AssignProp("", false, imgFamFoto_Internalname, "IsBlob", StringUtil.BoolToStr( A978FamFoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbFamSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbFamSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbFamSts, cmbFamSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A979FamSts), 1, 0)), 1, cmbFamSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbFamSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "", true, 1, "HLP_Configuracion\\Familia.htm");
         cmbFamSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A979FamSts), 1, 0));
         AssignProp("", false, cmbFamSts_Internalname, "Values", (string)(cmbFamSts.ToJavascriptSource()), true);
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Familia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Familia.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Familia.htm");
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
         GxWebStd.gx_single_line_edit( context, edtFamCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A50FamCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A50FamCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,50);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFamCod_Jsonclick, 0, "Attribute", "", "", "", "", edtFamCod_Visible, edtFamCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\Familia.htm");
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
         E115N2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z50FamCod = (int)(context.localUtil.CToN( cgiGet( "Z50FamCod"), ".", ","));
               Z977FamDsc = cgiGet( "Z977FamDsc");
               Z976FamAbr = cgiGet( "Z976FamAbr");
               Z979FamSts = (short)(context.localUtil.CToN( cgiGet( "Z979FamSts"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV10FamCod = (int)(context.localUtil.CToN( cgiGet( "vFAMCOD"), ".", ","));
               AV13cFamCod = (int)(context.localUtil.CToN( cgiGet( "vCFAMCOD"), ".", ","));
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               A40000FamFoto_GXI = cgiGet( "FAMFOTO_GXI");
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
               A977FamDsc = cgiGet( edtFamDsc_Internalname);
               AssignAttri("", false, "A977FamDsc", A977FamDsc);
               A976FamAbr = cgiGet( edtFamAbr_Internalname);
               AssignAttri("", false, "A976FamAbr", A976FamAbr);
               A978FamFoto = cgiGet( imgFamFoto_Internalname);
               AssignAttri("", false, "A978FamFoto", A978FamFoto);
               cmbFamSts.CurrentValue = cgiGet( cmbFamSts_Internalname);
               A979FamSts = (short)(NumberUtil.Val( cgiGet( cmbFamSts_Internalname), "."));
               AssignAttri("", false, "A979FamSts", StringUtil.Str( (decimal)(A979FamSts), 1, 0));
               if ( ( ( context.localUtil.CToN( cgiGet( edtFamCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFamCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FAMCOD");
                  AnyError = 1;
                  GX_FocusControl = edtFamCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A50FamCod = 0;
                  n50FamCod = false;
                  AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
               }
               else
               {
                  A50FamCod = (int)(context.localUtil.CToN( cgiGet( edtFamCod_Internalname), ".", ","));
                  n50FamCod = false;
                  AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgFamFoto_Internalname, ref  A978FamFoto, ref  A40000FamFoto_GXI);
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Familia");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A50FamCod != Z50FamCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\familia:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A50FamCod = (int)(NumberUtil.Val( GetPar( "FamCod"), "."));
                  n50FamCod = false;
                  AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
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
                     sMode80 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode80;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound80 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5N0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "FAMCOD");
                        AnyError = 1;
                        GX_FocusControl = edtFamCod_Internalname;
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
                           E115N2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E125N2 ();
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
            E125N2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5N80( ) ;
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
            DisableAttributes5N80( ) ;
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

      protected void CONFIRM_5N0( )
      {
         BeforeValidate5N80( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5N80( ) ;
            }
            else
            {
               CheckExtendedTable5N80( ) ;
               CloseExtendedTableCursors5N80( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5N0( )
      {
      }

      protected void E115N2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV7WWPContext) ;
         AV8TrnContext.FromXml(AV9WebSession.Get("TrnContext"), null, "", "");
         edtFamCod_Visible = 0;
         AssignProp("", false, edtFamCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtFamCod_Visible), 5, 0), true);
      }

      protected void E125N2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV11SGAuDocGls = "Familia N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A50FamCod), 10, 0)) + " " + StringUtil.Trim( A977FamDsc);
            AV12Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A50FamCod), 10, 0));
            GXt_char1 = "CNF";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV11SGAuDocGls, ref  AV12Codigo, ref  AV12Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV8TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.familiaww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM5N80( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z977FamDsc = T005N3_A977FamDsc[0];
               Z976FamAbr = T005N3_A976FamAbr[0];
               Z979FamSts = T005N3_A979FamSts[0];
            }
            else
            {
               Z977FamDsc = A977FamDsc;
               Z976FamAbr = A976FamAbr;
               Z979FamSts = A979FamSts;
            }
         }
         if ( GX_JID == -9 )
         {
            Z50FamCod = A50FamCod;
            Z977FamDsc = A977FamDsc;
            Z976FamAbr = A976FamAbr;
            Z979FamSts = A979FamSts;
            Z978FamFoto = A978FamFoto;
            Z40000FamFoto_GXI = A40000FamFoto_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV10FamCod) )
         {
            A50FamCod = AV10FamCod;
            n50FamCod = false;
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
         }
         if ( ! (0==AV10FamCod) )
         {
            edtFamCod_Enabled = 0;
            AssignProp("", false, edtFamCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFamCod_Enabled), 5, 0), true);
         }
         else
         {
            edtFamCod_Enabled = 1;
            AssignProp("", false, edtFamCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFamCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV10FamCod) )
         {
            edtFamCod_Enabled = 0;
            AssignProp("", false, edtFamCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFamCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A979FamSts) && ( Gx_BScreen == 0 ) )
         {
            A979FamSts = 1;
            AssignAttri("", false, "A979FamSts", StringUtil.Str( (decimal)(A979FamSts), 1, 0));
         }
      }

      protected void Load5N80( )
      {
         /* Using cursor T005N4 */
         pr_default.execute(2, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound80 = 1;
            A977FamDsc = T005N4_A977FamDsc[0];
            AssignAttri("", false, "A977FamDsc", A977FamDsc);
            A976FamAbr = T005N4_A976FamAbr[0];
            AssignAttri("", false, "A976FamAbr", A976FamAbr);
            A979FamSts = T005N4_A979FamSts[0];
            AssignAttri("", false, "A979FamSts", StringUtil.Str( (decimal)(A979FamSts), 1, 0));
            A40000FamFoto_GXI = T005N4_A40000FamFoto_GXI[0];
            AssignProp("", false, imgFamFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.convertURL( context.PathToRelativeUrl( A978FamFoto))), true);
            AssignProp("", false, imgFamFoto_Internalname, "SrcSet", context.GetImageSrcSet( A978FamFoto), true);
            A978FamFoto = T005N4_A978FamFoto[0];
            AssignAttri("", false, "A978FamFoto", A978FamFoto);
            AssignProp("", false, imgFamFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.convertURL( context.PathToRelativeUrl( A978FamFoto))), true);
            AssignProp("", false, imgFamFoto_Internalname, "SrcSet", context.GetImageSrcSet( A978FamFoto), true);
            ZM5N80( -9) ;
         }
         pr_default.close(2);
         OnLoadActions5N80( ) ;
      }

      protected void OnLoadActions5N80( )
      {
      }

      protected void CheckExtendedTable5N80( )
      {
         nIsDirty_80 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A977FamDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Familia", "", "", "", "", "", "", "", ""), 1, "FAMDSC");
            AnyError = 1;
            GX_FocusControl = edtFamDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A976FamAbr)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Abreviatura", "", "", "", "", "", "", "", ""), 1, "FAMABR");
            AnyError = 1;
            GX_FocusControl = edtFamAbr_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5N80( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey5N80( )
      {
         /* Using cursor T005N5 */
         pr_default.execute(3, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound80 = 1;
         }
         else
         {
            RcdFound80 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005N3 */
         pr_default.execute(1, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5N80( 9) ;
            RcdFound80 = 1;
            A50FamCod = T005N3_A50FamCod[0];
            n50FamCod = T005N3_n50FamCod[0];
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
            A977FamDsc = T005N3_A977FamDsc[0];
            AssignAttri("", false, "A977FamDsc", A977FamDsc);
            A976FamAbr = T005N3_A976FamAbr[0];
            AssignAttri("", false, "A976FamAbr", A976FamAbr);
            A979FamSts = T005N3_A979FamSts[0];
            AssignAttri("", false, "A979FamSts", StringUtil.Str( (decimal)(A979FamSts), 1, 0));
            A40000FamFoto_GXI = T005N3_A40000FamFoto_GXI[0];
            AssignProp("", false, imgFamFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.convertURL( context.PathToRelativeUrl( A978FamFoto))), true);
            AssignProp("", false, imgFamFoto_Internalname, "SrcSet", context.GetImageSrcSet( A978FamFoto), true);
            A978FamFoto = T005N3_A978FamFoto[0];
            AssignAttri("", false, "A978FamFoto", A978FamFoto);
            AssignProp("", false, imgFamFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.convertURL( context.PathToRelativeUrl( A978FamFoto))), true);
            AssignProp("", false, imgFamFoto_Internalname, "SrcSet", context.GetImageSrcSet( A978FamFoto), true);
            Z50FamCod = A50FamCod;
            sMode80 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load5N80( ) ;
            if ( AnyError == 1 )
            {
               RcdFound80 = 0;
               InitializeNonKey5N80( ) ;
            }
            Gx_mode = sMode80;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound80 = 0;
            InitializeNonKey5N80( ) ;
            sMode80 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode80;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5N80( ) ;
         if ( RcdFound80 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound80 = 0;
         /* Using cursor T005N6 */
         pr_default.execute(4, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T005N6_A50FamCod[0] < A50FamCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T005N6_A50FamCod[0] > A50FamCod ) ) )
            {
               A50FamCod = T005N6_A50FamCod[0];
               n50FamCod = T005N6_n50FamCod[0];
               AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
               RcdFound80 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound80 = 0;
         /* Using cursor T005N7 */
         pr_default.execute(5, new Object[] {n50FamCod, A50FamCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T005N7_A50FamCod[0] > A50FamCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T005N7_A50FamCod[0] < A50FamCod ) ) )
            {
               A50FamCod = T005N7_A50FamCod[0];
               n50FamCod = T005N7_n50FamCod[0];
               AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
               RcdFound80 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5N80( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFamDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5N80( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound80 == 1 )
            {
               if ( A50FamCod != Z50FamCod )
               {
                  A50FamCod = Z50FamCod;
                  n50FamCod = false;
                  AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FAMCOD");
                  AnyError = 1;
                  GX_FocusControl = edtFamCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFamDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5N80( ) ;
                  GX_FocusControl = edtFamDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A50FamCod != Z50FamCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtFamDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5N80( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FAMCOD");
                     AnyError = 1;
                     GX_FocusControl = edtFamCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtFamDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5N80( ) ;
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
         if ( A50FamCod != Z50FamCod )
         {
            A50FamCod = Z50FamCod;
            n50FamCod = false;
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FAMCOD");
            AnyError = 1;
            GX_FocusControl = edtFamCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFamDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5N80( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005N2 */
            pr_default.execute(0, new Object[] {n50FamCod, A50FamCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CFAMILIA"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z977FamDsc, T005N2_A977FamDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z976FamAbr, T005N2_A976FamAbr[0]) != 0 ) || ( Z979FamSts != T005N2_A979FamSts[0] ) )
            {
               if ( StringUtil.StrCmp(Z977FamDsc, T005N2_A977FamDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.familia:[seudo value changed for attri]"+"FamDsc");
                  GXUtil.WriteLogRaw("Old: ",Z977FamDsc);
                  GXUtil.WriteLogRaw("Current: ",T005N2_A977FamDsc[0]);
               }
               if ( StringUtil.StrCmp(Z976FamAbr, T005N2_A976FamAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.familia:[seudo value changed for attri]"+"FamAbr");
                  GXUtil.WriteLogRaw("Old: ",Z976FamAbr);
                  GXUtil.WriteLogRaw("Current: ",T005N2_A976FamAbr[0]);
               }
               if ( Z979FamSts != T005N2_A979FamSts[0] )
               {
                  GXUtil.WriteLog("configuracion.familia:[seudo value changed for attri]"+"FamSts");
                  GXUtil.WriteLogRaw("Old: ",Z979FamSts);
                  GXUtil.WriteLogRaw("Current: ",T005N2_A979FamSts[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CFAMILIA"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5N80( )
      {
         BeforeValidate5N80( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5N80( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5N80( 0) ;
            CheckOptimisticConcurrency5N80( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5N80( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5N80( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005N8 */
                     pr_default.execute(6, new Object[] {n50FamCod, A50FamCod, A977FamDsc, A976FamAbr, A979FamSts, A978FamFoto, A40000FamFoto_GXI});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CFAMILIA");
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
                           ResetCaption5N0( ) ;
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
               Load5N80( ) ;
            }
            EndLevel5N80( ) ;
         }
         CloseExtendedTableCursors5N80( ) ;
      }

      protected void Update5N80( )
      {
         BeforeValidate5N80( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5N80( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5N80( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5N80( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5N80( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005N9 */
                     pr_default.execute(7, new Object[] {A977FamDsc, A976FamAbr, A979FamSts, n50FamCod, A50FamCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CFAMILIA");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CFAMILIA"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5N80( ) ;
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
            EndLevel5N80( ) ;
         }
         CloseExtendedTableCursors5N80( ) ;
      }

      protected void DeferredUpdate5N80( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T005N10 */
            pr_default.execute(8, new Object[] {A978FamFoto, A40000FamFoto_GXI, n50FamCod, A50FamCod});
            pr_default.close(8);
            dsDefault.SmartCacheProvider.SetUpdated("CFAMILIA");
         }
      }

      protected void delete( )
      {
         BeforeValidate5N80( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5N80( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5N80( ) ;
            AfterConfirm5N80( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5N80( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005N11 */
                  pr_default.execute(9, new Object[] {n50FamCod, A50FamCod});
                  pr_default.close(9);
                  dsDefault.SmartCacheProvider.SetUpdated("CFAMILIA");
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
         sMode80 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5N80( ) ;
         Gx_mode = sMode80;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5N80( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T005N12 */
            pr_default.execute(10, new Object[] {n50FamCod, A50FamCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel5N80( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5N80( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.familia",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.familia",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5N80( )
      {
         /* Scan By routine */
         /* Using cursor T005N13 */
         pr_default.execute(11);
         RcdFound80 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound80 = 1;
            A50FamCod = T005N13_A50FamCod[0];
            n50FamCod = T005N13_n50FamCod[0];
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5N80( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound80 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound80 = 1;
            A50FamCod = T005N13_A50FamCod[0];
            n50FamCod = T005N13_n50FamCod[0];
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
         }
      }

      protected void ScanEnd5N80( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm5N80( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cFamCod;
            GXt_char3 = "FAMILIAS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cFamCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cFamCod", StringUtil.LTrimStr( (decimal)(AV13cFamCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A50FamCod = AV13cFamCod;
            n50FamCod = false;
            AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
         }
      }

      protected void BeforeInsert5N80( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5N80( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5N80( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5N80( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5N80( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5N80( )
      {
         edtFamDsc_Enabled = 0;
         AssignProp("", false, edtFamDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFamDsc_Enabled), 5, 0), true);
         edtFamAbr_Enabled = 0;
         AssignProp("", false, edtFamAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFamAbr_Enabled), 5, 0), true);
         imgFamFoto_Enabled = 0;
         AssignProp("", false, imgFamFoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgFamFoto_Enabled), 5, 0), true);
         cmbFamSts.Enabled = 0;
         AssignProp("", false, cmbFamSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbFamSts.Enabled), 5, 0), true);
         edtFamCod_Enabled = 0;
         AssignProp("", false, edtFamCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFamCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5N80( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5N0( )
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
         context.AddJavascriptSource("gxcfg.js", "?20228181026623", false, true);
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
         GXEncryptionTmp = "configuracion.familia.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV10FamCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.familia.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Familia");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\familia:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z50FamCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z50FamCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z977FamDsc", StringUtil.RTrim( Z977FamDsc));
         GxWebStd.gx_hidden_field( context, "Z976FamAbr", StringUtil.RTrim( Z976FamAbr));
         GxWebStd.gx_hidden_field( context, "Z979FamSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z979FamSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV8TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV8TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV8TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vFAMCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10FamCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFAMCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV10FamCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCFAMCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cFamCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FAMFOTO_GXI", A40000FamFoto_GXI);
         GXCCtlgxBlob = "FAMFOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A978FamFoto);
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
         GXEncryptionTmp = "configuracion.familia.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV10FamCod,6,0));
         return formatLink("configuracion.familia.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.Familia" ;
      }

      public override string GetPgmdesc( )
      {
         return "Familia" ;
      }

      protected void InitializeNonKey5N80( )
      {
         AV13cFamCod = 0;
         AssignAttri("", false, "AV13cFamCod", StringUtil.LTrimStr( (decimal)(AV13cFamCod), 6, 0));
         A977FamDsc = "";
         AssignAttri("", false, "A977FamDsc", A977FamDsc);
         A976FamAbr = "";
         AssignAttri("", false, "A976FamAbr", A976FamAbr);
         A978FamFoto = "";
         AssignAttri("", false, "A978FamFoto", A978FamFoto);
         AssignProp("", false, imgFamFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.convertURL( context.PathToRelativeUrl( A978FamFoto))), true);
         AssignProp("", false, imgFamFoto_Internalname, "SrcSet", context.GetImageSrcSet( A978FamFoto), true);
         A40000FamFoto_GXI = "";
         AssignProp("", false, imgFamFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A978FamFoto)) ? A40000FamFoto_GXI : context.convertURL( context.PathToRelativeUrl( A978FamFoto))), true);
         AssignProp("", false, imgFamFoto_Internalname, "SrcSet", context.GetImageSrcSet( A978FamFoto), true);
         A979FamSts = 1;
         AssignAttri("", false, "A979FamSts", StringUtil.Str( (decimal)(A979FamSts), 1, 0));
         Z977FamDsc = "";
         Z976FamAbr = "";
         Z979FamSts = 0;
      }

      protected void InitAll5N80( )
      {
         A50FamCod = 0;
         n50FamCod = false;
         AssignAttri("", false, "A50FamCod", StringUtil.LTrimStr( (decimal)(A50FamCod), 6, 0));
         InitializeNonKey5N80( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A979FamSts = i979FamSts;
         AssignAttri("", false, "A979FamSts", StringUtil.Str( (decimal)(A979FamSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20228181026645", true, true);
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
         context.AddJavascriptSource("configuracion/familia.js", "?20228181026645", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtFamDsc_Internalname = "FAMDSC";
         edtFamAbr_Internalname = "FAMABR";
         imgFamFoto_Internalname = "FAMFOTO";
         cmbFamSts_Internalname = "FAMSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtFamCod_Internalname = "FAMCOD";
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
         Form.Caption = "Familia";
         edtFamCod_Jsonclick = "";
         edtFamCod_Enabled = 1;
         edtFamCod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbFamSts_Jsonclick = "";
         cmbFamSts.Enabled = 1;
         imgFamFoto_Enabled = 1;
         edtFamAbr_Jsonclick = "";
         edtFamAbr_Enabled = 1;
         edtFamDsc_Jsonclick = "";
         edtFamDsc_Enabled = 1;
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

      protected void GX4ASACFAMCOD5N80( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV13cFamCod;
            GXt_char3 = "FAMILIAS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV13cFamCod = (int)(GXt_int4);
            AssignAttri("", false, "AV13cFamCod", StringUtil.LTrimStr( (decimal)(AV13cFamCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13cFamCod), 6, 0, ".", "")))+"\"") ;
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
         cmbFamSts.Name = "FAMSTS";
         cmbFamSts.WebTags = "";
         cmbFamSts.addItem("1", "ACTIVO", 0);
         cmbFamSts.addItem("0", "INACTIVO", 0);
         if ( cmbFamSts.ItemCount > 0 )
         {
            if ( (0==A979FamSts) )
            {
               A979FamSts = 1;
               AssignAttri("", false, "A979FamSts", StringUtil.Str( (decimal)(A979FamSts), 1, 0));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV10FamCod',fld:'vFAMCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV10FamCod',fld:'vFAMCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E125N2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A50FamCod',fld:'FAMCOD',pic:'ZZZZZ9'},{av:'A977FamDsc',fld:'FAMDSC',pic:''},{av:'AV8TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_FAMDSC","{handler:'Valid_Famdsc',iparms:[]");
         setEventMetadata("VALID_FAMDSC",",oparms:[]}");
         setEventMetadata("VALID_FAMABR","{handler:'Valid_Famabr',iparms:[]");
         setEventMetadata("VALID_FAMABR",",oparms:[]}");
         setEventMetadata("VALID_FAMCOD","{handler:'Valid_Famcod',iparms:[]");
         setEventMetadata("VALID_FAMCOD",",oparms:[]}");
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
         Z977FamDsc = "";
         Z976FamAbr = "";
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
         A977FamDsc = "";
         A976FamAbr = "";
         A978FamFoto = "";
         A40000FamFoto_GXI = "";
         sImgUrl = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode80 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV7WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9WebSession = context.GetSession();
         AV11SGAuDocGls = "";
         AV12Codigo = "";
         GXt_char1 = "";
         GXt_char2 = "";
         Z978FamFoto = "";
         Z40000FamFoto_GXI = "";
         T005N4_A50FamCod = new int[1] ;
         T005N4_n50FamCod = new bool[] {false} ;
         T005N4_A977FamDsc = new string[] {""} ;
         T005N4_A976FamAbr = new string[] {""} ;
         T005N4_A979FamSts = new short[1] ;
         T005N4_A40000FamFoto_GXI = new string[] {""} ;
         T005N4_A978FamFoto = new string[] {""} ;
         T005N5_A50FamCod = new int[1] ;
         T005N5_n50FamCod = new bool[] {false} ;
         T005N3_A50FamCod = new int[1] ;
         T005N3_n50FamCod = new bool[] {false} ;
         T005N3_A977FamDsc = new string[] {""} ;
         T005N3_A976FamAbr = new string[] {""} ;
         T005N3_A979FamSts = new short[1] ;
         T005N3_A40000FamFoto_GXI = new string[] {""} ;
         T005N3_A978FamFoto = new string[] {""} ;
         T005N6_A50FamCod = new int[1] ;
         T005N6_n50FamCod = new bool[] {false} ;
         T005N7_A50FamCod = new int[1] ;
         T005N7_n50FamCod = new bool[] {false} ;
         T005N2_A50FamCod = new int[1] ;
         T005N2_n50FamCod = new bool[] {false} ;
         T005N2_A977FamDsc = new string[] {""} ;
         T005N2_A976FamAbr = new string[] {""} ;
         T005N2_A979FamSts = new short[1] ;
         T005N2_A40000FamFoto_GXI = new string[] {""} ;
         T005N2_A978FamFoto = new string[] {""} ;
         T005N12_A28ProdCod = new string[] {""} ;
         T005N13_A50FamCod = new int[1] ;
         T005N13_n50FamCod = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXCCtlgxBlob = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.familia__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.familia__default(),
            new Object[][] {
                new Object[] {
               T005N2_A50FamCod, T005N2_A977FamDsc, T005N2_A976FamAbr, T005N2_A979FamSts, T005N2_A40000FamFoto_GXI, T005N2_A978FamFoto
               }
               , new Object[] {
               T005N3_A50FamCod, T005N3_A977FamDsc, T005N3_A976FamAbr, T005N3_A979FamSts, T005N3_A40000FamFoto_GXI, T005N3_A978FamFoto
               }
               , new Object[] {
               T005N4_A50FamCod, T005N4_A977FamDsc, T005N4_A976FamAbr, T005N4_A979FamSts, T005N4_A40000FamFoto_GXI, T005N4_A978FamFoto
               }
               , new Object[] {
               T005N5_A50FamCod
               }
               , new Object[] {
               T005N6_A50FamCod
               }
               , new Object[] {
               T005N7_A50FamCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005N12_A28ProdCod
               }
               , new Object[] {
               T005N13_A50FamCod
               }
            }
         );
         Z979FamSts = 1;
         A979FamSts = 1;
         i979FamSts = 1;
      }

      private short Z979FamSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A979FamSts ;
      private short Gx_BScreen ;
      private short RcdFound80 ;
      private short GX_JID ;
      private short nIsDirty_80 ;
      private short gxajaxcallmode ;
      private short i979FamSts ;
      private int wcpOAV10FamCod ;
      private int Z50FamCod ;
      private int AV10FamCod ;
      private int trnEnded ;
      private int edtFamDsc_Enabled ;
      private int edtFamAbr_Enabled ;
      private int imgFamFoto_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A50FamCod ;
      private int edtFamCod_Visible ;
      private int edtFamCod_Enabled ;
      private int AV13cFamCod ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int4 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z977FamDsc ;
      private string Z976FamAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtFamDsc_Internalname ;
      private string cmbFamSts_Internalname ;
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
      private string A977FamDsc ;
      private string edtFamDsc_Jsonclick ;
      private string edtFamAbr_Internalname ;
      private string A976FamAbr ;
      private string edtFamAbr_Jsonclick ;
      private string imgFamFoto_Internalname ;
      private string sImgUrl ;
      private string cmbFamSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtFamCod_Internalname ;
      private string edtFamCod_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode80 ;
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
      private string GXCCtlgxBlob ;
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
      private bool A978FamFoto_IsBlob ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool n50FamCod ;
      private bool returnInSub ;
      private string A40000FamFoto_GXI ;
      private string AV11SGAuDocGls ;
      private string AV12Codigo ;
      private string Z40000FamFoto_GXI ;
      private string A978FamFoto ;
      private string Z978FamFoto ;
      private IGxSession AV9WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbFamSts ;
      private IDataStoreProvider pr_default ;
      private int[] T005N4_A50FamCod ;
      private bool[] T005N4_n50FamCod ;
      private string[] T005N4_A977FamDsc ;
      private string[] T005N4_A976FamAbr ;
      private short[] T005N4_A979FamSts ;
      private string[] T005N4_A40000FamFoto_GXI ;
      private string[] T005N4_A978FamFoto ;
      private int[] T005N5_A50FamCod ;
      private bool[] T005N5_n50FamCod ;
      private int[] T005N3_A50FamCod ;
      private bool[] T005N3_n50FamCod ;
      private string[] T005N3_A977FamDsc ;
      private string[] T005N3_A976FamAbr ;
      private short[] T005N3_A979FamSts ;
      private string[] T005N3_A40000FamFoto_GXI ;
      private string[] T005N3_A978FamFoto ;
      private int[] T005N6_A50FamCod ;
      private bool[] T005N6_n50FamCod ;
      private int[] T005N7_A50FamCod ;
      private bool[] T005N7_n50FamCod ;
      private int[] T005N2_A50FamCod ;
      private bool[] T005N2_n50FamCod ;
      private string[] T005N2_A977FamDsc ;
      private string[] T005N2_A976FamAbr ;
      private short[] T005N2_A979FamSts ;
      private string[] T005N2_A40000FamFoto_GXI ;
      private string[] T005N2_A978FamFoto ;
      private string[] T005N12_A28ProdCod ;
      private int[] T005N13_A50FamCod ;
      private bool[] T005N13_n50FamCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV8TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV7WWPContext ;
   }

   public class familia__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class familia__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005N4;
        prmT005N4 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005N5;
        prmT005N5 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005N3;
        prmT005N3 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005N6;
        prmT005N6 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005N7;
        prmT005N7 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005N2;
        prmT005N2 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005N8;
        prmT005N8 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true} ,
        new ParDef("@FamDsc",GXType.NChar,100,0) ,
        new ParDef("@FamAbr",GXType.NChar,5,0) ,
        new ParDef("@FamSts",GXType.Int16,1,0) ,
        new ParDef("@FamFoto",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@FamFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="CFAMILIA", Fld="FamFoto"}
        };
        Object[] prmT005N9;
        prmT005N9 = new Object[] {
        new ParDef("@FamDsc",GXType.NChar,100,0) ,
        new ParDef("@FamAbr",GXType.NChar,5,0) ,
        new ParDef("@FamSts",GXType.Int16,1,0) ,
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005N10;
        prmT005N10 = new Object[] {
        new ParDef("@FamFoto",GXType.Blob,1024,0){InDB=false} ,
        new ParDef("@FamFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="CFAMILIA", Fld="FamFoto"} ,
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005N11;
        prmT005N11 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005N12;
        prmT005N12 = new Object[] {
        new ParDef("@FamCod",GXType.Int32,6,0){Nullable=true}
        };
        Object[] prmT005N13;
        prmT005N13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T005N2", "SELECT [FamCod], [FamDsc], [FamAbr], [FamSts], [FamFoto_GXI], [FamFoto] FROM [CFAMILIA] WITH (UPDLOCK) WHERE [FamCod] = @FamCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005N3", "SELECT [FamCod], [FamDsc], [FamAbr], [FamSts], [FamFoto_GXI], [FamFoto] FROM [CFAMILIA] WHERE [FamCod] = @FamCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005N4", "SELECT TM1.[FamCod], TM1.[FamDsc], TM1.[FamAbr], TM1.[FamSts], TM1.[FamFoto_GXI], TM1.[FamFoto] FROM [CFAMILIA] TM1 WHERE TM1.[FamCod] = @FamCod ORDER BY TM1.[FamCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005N4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005N5", "SELECT [FamCod] FROM [CFAMILIA] WHERE [FamCod] = @FamCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005N5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005N6", "SELECT TOP 1 [FamCod] FROM [CFAMILIA] WHERE ( [FamCod] > @FamCod) ORDER BY [FamCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005N6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005N7", "SELECT TOP 1 [FamCod] FROM [CFAMILIA] WHERE ( [FamCod] < @FamCod) ORDER BY [FamCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005N7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005N8", "INSERT INTO [CFAMILIA]([FamCod], [FamDsc], [FamAbr], [FamSts], [FamFoto], [FamFoto_GXI]) VALUES(@FamCod, @FamDsc, @FamAbr, @FamSts, @FamFoto, @FamFoto_GXI)", GxErrorMask.GX_NOMASK,prmT005N8)
           ,new CursorDef("T005N9", "UPDATE [CFAMILIA] SET [FamDsc]=@FamDsc, [FamAbr]=@FamAbr, [FamSts]=@FamSts  WHERE [FamCod] = @FamCod", GxErrorMask.GX_NOMASK,prmT005N9)
           ,new CursorDef("T005N10", "UPDATE [CFAMILIA] SET [FamFoto]=@FamFoto, [FamFoto_GXI]=@FamFoto_GXI  WHERE [FamCod] = @FamCod", GxErrorMask.GX_NOMASK,prmT005N10)
           ,new CursorDef("T005N11", "DELETE FROM [CFAMILIA]  WHERE [FamCod] = @FamCod", GxErrorMask.GX_NOMASK,prmT005N11)
           ,new CursorDef("T005N12", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE [FamCod] = @FamCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005N12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005N13", "SELECT [FamCod] FROM [CFAMILIA] ORDER BY [FamCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005N13,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(5));
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(5));
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((short[]) buf[3])[0] = rslt.getShort(4);
              ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
              ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(5));
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
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
