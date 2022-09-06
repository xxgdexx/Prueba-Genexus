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
   public class vendedores : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.vendedores.aspx")), "configuracion.vendedores.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.vendedores.aspx")))) ;
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
                  AV7VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
                  AssignAttri("", false, "AV7VenCod", StringUtil.LTrimStr( (decimal)(AV7VenCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vVENCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7VenCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Vendedores", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = cmbVenTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public vendedores( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public vendedores( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_VenCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7VenCod = aP1_VenCod;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbVenTipo = new GXCombobox();
         cmbVenSts = new GXCombobox();
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
         if ( cmbVenTipo.ItemCount > 0 )
         {
            A2049VenTipo = cmbVenTipo.getValidValue(A2049VenTipo);
            AssignAttri("", false, "A2049VenTipo", A2049VenTipo);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVenTipo.CurrentValue = StringUtil.RTrim( A2049VenTipo);
            AssignProp("", false, cmbVenTipo_Internalname, "Values", cmbVenTipo.ToJavascriptSource(), true);
         }
         if ( cmbVenSts.ItemCount > 0 )
         {
            A2047VenSts = (short)(NumberUtil.Val( cmbVenSts.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A2047VenSts), 1, 0))), "."));
            AssignAttri("", false, "A2047VenSts", StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbVenSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
            AssignProp("", false, cmbVenSts_Internalname, "Values", cmbVenSts.ToJavascriptSource(), true);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbVenTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbVenTipo_Internalname, "Tipo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbVenTipo, cmbVenTipo_Internalname, StringUtil.RTrim( A2049VenTipo), 1, cmbVenTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbVenTipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "", true, 1, "HLP_Configuracion\\Vendedores.htm");
         cmbVenTipo.CurrentValue = StringUtil.RTrim( A2049VenTipo);
         AssignProp("", false, cmbVenTipo_Internalname, "Values", (string)(cmbVenTipo.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVenCod_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVenCod_Internalname, "Codigo", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVenCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A309VenCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A309VenCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVenCod_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVenCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\Vendedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVenDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVenDsc_Internalname, "Nombres", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVenDsc_Internalname, StringUtil.RTrim( A2045VenDsc), StringUtil.RTrim( context.localUtil.Format( A2045VenDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVenDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtVenDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Vendedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVenDir_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVenDir_Internalname, "Dirección", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVenDir_Internalname, StringUtil.RTrim( A2044VenDir), StringUtil.RTrim( context.localUtil.Format( A2044VenDir, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVenDir_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtVenDir_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Vendedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVenTelf_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVenTelf_Internalname, "Telefono", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVenTelf_Internalname, StringUtil.RTrim( A2048VenTelf), StringUtil.RTrim( context.localUtil.Format( A2048VenTelf, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVenTelf_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVenTelf_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Vendedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVenCel_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVenCel_Internalname, "Celular", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVenCel_Internalname, StringUtil.RTrim( A2043VenCel), StringUtil.RTrim( context.localUtil.Format( A2043VenCel, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVenCel_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVenCel_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Vendedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVenRuc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVenRuc_Internalname, "R.U.C.", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVenRuc_Internalname, StringUtil.RTrim( A2046VenRuc), StringUtil.RTrim( context.localUtil.Format( A2046VenRuc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVenRuc_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVenRuc_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\Vendedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+cmbVenSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbVenSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbVenSts, cmbVenSts_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A2047VenSts), 1, 0)), 1, cmbVenSts_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbVenSts.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 1, "HLP_Configuracion\\Vendedores.htm");
         cmbVenSts.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
         AssignProp("", false, cmbVenSts_Internalname, "Values", (string)(cmbVenSts.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Vendedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Vendedores.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\Vendedores.htm");
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
         E115Q2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z309VenCod = (int)(context.localUtil.CToN( cgiGet( "Z309VenCod"), ".", ","));
               Z2045VenDsc = cgiGet( "Z2045VenDsc");
               Z2044VenDir = cgiGet( "Z2044VenDir");
               Z2048VenTelf = cgiGet( "Z2048VenTelf");
               Z2043VenCel = cgiGet( "Z2043VenCel");
               Z2046VenRuc = cgiGet( "Z2046VenRuc");
               Z2047VenSts = (short)(context.localUtil.CToN( cgiGet( "Z2047VenSts"), ".", ","));
               Z2049VenTipo = cgiGet( "Z2049VenTipo");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7VenCod = (int)(context.localUtil.CToN( cgiGet( "vVENCOD"), ".", ","));
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
               cmbVenTipo.CurrentValue = cgiGet( cmbVenTipo_Internalname);
               A2049VenTipo = cgiGet( cmbVenTipo_Internalname);
               AssignAttri("", false, "A2049VenTipo", A2049VenTipo);
               if ( ( ( context.localUtil.CToN( cgiGet( edtVenCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVenCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VENCOD");
                  AnyError = 1;
                  GX_FocusControl = edtVenCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A309VenCod = 0;
                  AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
               }
               else
               {
                  A309VenCod = (int)(context.localUtil.CToN( cgiGet( edtVenCod_Internalname), ".", ","));
                  AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
               }
               A2045VenDsc = cgiGet( edtVenDsc_Internalname);
               AssignAttri("", false, "A2045VenDsc", A2045VenDsc);
               A2044VenDir = cgiGet( edtVenDir_Internalname);
               AssignAttri("", false, "A2044VenDir", A2044VenDir);
               A2048VenTelf = cgiGet( edtVenTelf_Internalname);
               AssignAttri("", false, "A2048VenTelf", A2048VenTelf);
               A2043VenCel = cgiGet( edtVenCel_Internalname);
               AssignAttri("", false, "A2043VenCel", A2043VenCel);
               A2046VenRuc = cgiGet( edtVenRuc_Internalname);
               AssignAttri("", false, "A2046VenRuc", A2046VenRuc);
               cmbVenSts.CurrentValue = cgiGet( cmbVenSts_Internalname);
               A2047VenSts = (short)(NumberUtil.Val( cgiGet( cmbVenSts_Internalname), "."));
               AssignAttri("", false, "A2047VenSts", StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Vendedores");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A309VenCod != Z309VenCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\vendedores:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A309VenCod = (int)(NumberUtil.Val( GetPar( "VenCod"), "."));
                  AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
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
                     sMode138 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode138;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound138 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_5Q0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "VENCOD");
                        AnyError = 1;
                        GX_FocusControl = edtVenCod_Internalname;
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
                           E115Q2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E125Q2 ();
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
            E125Q2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll5Q138( ) ;
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
            DisableAttributes5Q138( ) ;
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

      protected void CONFIRM_5Q0( )
      {
         BeforeValidate5Q138( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls5Q138( ) ;
            }
            else
            {
               CheckExtendedTable5Q138( ) ;
               CloseExtendedTableCursors5Q138( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption5Q0( )
      {
      }

      protected void E115Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E125Q2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV11SGAuDocGls = "Vendedor N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A309VenCod), 10, 0)) + " " + StringUtil.Trim( A2045VenDsc);
            AV12Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A309VenCod), 10, 0));
            GXt_char1 = "CNF";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV11SGAuDocGls, ref  AV12Codigo, ref  AV12Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("configuracion.vendedoresww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM5Q138( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z2045VenDsc = T005Q3_A2045VenDsc[0];
               Z2044VenDir = T005Q3_A2044VenDir[0];
               Z2048VenTelf = T005Q3_A2048VenTelf[0];
               Z2043VenCel = T005Q3_A2043VenCel[0];
               Z2046VenRuc = T005Q3_A2046VenRuc[0];
               Z2047VenSts = T005Q3_A2047VenSts[0];
               Z2049VenTipo = T005Q3_A2049VenTipo[0];
            }
            else
            {
               Z2045VenDsc = A2045VenDsc;
               Z2044VenDir = A2044VenDir;
               Z2048VenTelf = A2048VenTelf;
               Z2043VenCel = A2043VenCel;
               Z2046VenRuc = A2046VenRuc;
               Z2047VenSts = A2047VenSts;
               Z2049VenTipo = A2049VenTipo;
            }
         }
         if ( GX_JID == -8 )
         {
            Z309VenCod = A309VenCod;
            Z2045VenDsc = A2045VenDsc;
            Z2044VenDir = A2044VenDir;
            Z2048VenTelf = A2048VenTelf;
            Z2043VenCel = A2043VenCel;
            Z2046VenRuc = A2046VenRuc;
            Z2047VenSts = A2047VenSts;
            Z2049VenTipo = A2049VenTipo;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7VenCod) )
         {
            A309VenCod = AV7VenCod;
            AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
         }
         if ( ! (0==AV7VenCod) )
         {
            edtVenCod_Enabled = 0;
            AssignProp("", false, edtVenCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVenCod_Enabled), 5, 0), true);
         }
         else
         {
            edtVenCod_Enabled = 1;
            AssignProp("", false, edtVenCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVenCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7VenCod) )
         {
            edtVenCod_Enabled = 0;
            AssignProp("", false, edtVenCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVenCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A2047VenSts) && ( Gx_BScreen == 0 ) )
         {
            A2047VenSts = 1;
            AssignAttri("", false, "A2047VenSts", StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load5Q138( )
      {
         /* Using cursor T005Q4 */
         pr_default.execute(2, new Object[] {A309VenCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound138 = 1;
            A2045VenDsc = T005Q4_A2045VenDsc[0];
            AssignAttri("", false, "A2045VenDsc", A2045VenDsc);
            A2044VenDir = T005Q4_A2044VenDir[0];
            AssignAttri("", false, "A2044VenDir", A2044VenDir);
            A2048VenTelf = T005Q4_A2048VenTelf[0];
            AssignAttri("", false, "A2048VenTelf", A2048VenTelf);
            A2043VenCel = T005Q4_A2043VenCel[0];
            AssignAttri("", false, "A2043VenCel", A2043VenCel);
            A2046VenRuc = T005Q4_A2046VenRuc[0];
            AssignAttri("", false, "A2046VenRuc", A2046VenRuc);
            A2047VenSts = T005Q4_A2047VenSts[0];
            AssignAttri("", false, "A2047VenSts", StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
            A2049VenTipo = T005Q4_A2049VenTipo[0];
            AssignAttri("", false, "A2049VenTipo", A2049VenTipo);
            ZM5Q138( -8) ;
         }
         pr_default.close(2);
         OnLoadActions5Q138( ) ;
      }

      protected void OnLoadActions5Q138( )
      {
      }

      protected void CheckExtendedTable5Q138( )
      {
         nIsDirty_138 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( (0==A309VenCod) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Codigo", "", "", "", "", "", "", "", ""), 1, "VENCOD");
            AnyError = 1;
            GX_FocusControl = edtVenCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2045VenDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Vendedor / Cobrador", "", "", "", "", "", "", "", ""), 1, "VENDSC");
            AnyError = 1;
            GX_FocusControl = edtVenDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2049VenTipo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Tipo", "", "", "", "", "", "", "", ""), 1, "VENTIPO");
            AnyError = 1;
            GX_FocusControl = cmbVenTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors5Q138( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey5Q138( )
      {
         /* Using cursor T005Q5 */
         pr_default.execute(3, new Object[] {A309VenCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound138 = 1;
         }
         else
         {
            RcdFound138 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T005Q3 */
         pr_default.execute(1, new Object[] {A309VenCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM5Q138( 8) ;
            RcdFound138 = 1;
            A309VenCod = T005Q3_A309VenCod[0];
            AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
            A2045VenDsc = T005Q3_A2045VenDsc[0];
            AssignAttri("", false, "A2045VenDsc", A2045VenDsc);
            A2044VenDir = T005Q3_A2044VenDir[0];
            AssignAttri("", false, "A2044VenDir", A2044VenDir);
            A2048VenTelf = T005Q3_A2048VenTelf[0];
            AssignAttri("", false, "A2048VenTelf", A2048VenTelf);
            A2043VenCel = T005Q3_A2043VenCel[0];
            AssignAttri("", false, "A2043VenCel", A2043VenCel);
            A2046VenRuc = T005Q3_A2046VenRuc[0];
            AssignAttri("", false, "A2046VenRuc", A2046VenRuc);
            A2047VenSts = T005Q3_A2047VenSts[0];
            AssignAttri("", false, "A2047VenSts", StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
            A2049VenTipo = T005Q3_A2049VenTipo[0];
            AssignAttri("", false, "A2049VenTipo", A2049VenTipo);
            Z309VenCod = A309VenCod;
            sMode138 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load5Q138( ) ;
            if ( AnyError == 1 )
            {
               RcdFound138 = 0;
               InitializeNonKey5Q138( ) ;
            }
            Gx_mode = sMode138;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound138 = 0;
            InitializeNonKey5Q138( ) ;
            sMode138 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode138;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey5Q138( ) ;
         if ( RcdFound138 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound138 = 0;
         /* Using cursor T005Q6 */
         pr_default.execute(4, new Object[] {A309VenCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T005Q6_A309VenCod[0] < A309VenCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T005Q6_A309VenCod[0] > A309VenCod ) ) )
            {
               A309VenCod = T005Q6_A309VenCod[0];
               AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
               RcdFound138 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound138 = 0;
         /* Using cursor T005Q7 */
         pr_default.execute(5, new Object[] {A309VenCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T005Q7_A309VenCod[0] > A309VenCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T005Q7_A309VenCod[0] < A309VenCod ) ) )
            {
               A309VenCod = T005Q7_A309VenCod[0];
               AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
               RcdFound138 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey5Q138( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = cmbVenTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert5Q138( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound138 == 1 )
            {
               if ( A309VenCod != Z309VenCod )
               {
                  A309VenCod = Z309VenCod;
                  AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "VENCOD");
                  AnyError = 1;
                  GX_FocusControl = edtVenCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = cmbVenTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update5Q138( ) ;
                  GX_FocusControl = cmbVenTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A309VenCod != Z309VenCod )
               {
                  /* Insert record */
                  GX_FocusControl = cmbVenTipo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert5Q138( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VENCOD");
                     AnyError = 1;
                     GX_FocusControl = edtVenCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = cmbVenTipo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert5Q138( ) ;
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
         if ( A309VenCod != Z309VenCod )
         {
            A309VenCod = Z309VenCod;
            AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "VENCOD");
            AnyError = 1;
            GX_FocusControl = edtVenCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = cmbVenTipo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency5Q138( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T005Q2 */
            pr_default.execute(0, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CVENDEDORES"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2045VenDsc, T005Q2_A2045VenDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z2044VenDir, T005Q2_A2044VenDir[0]) != 0 ) || ( StringUtil.StrCmp(Z2048VenTelf, T005Q2_A2048VenTelf[0]) != 0 ) || ( StringUtil.StrCmp(Z2043VenCel, T005Q2_A2043VenCel[0]) != 0 ) || ( StringUtil.StrCmp(Z2046VenRuc, T005Q2_A2046VenRuc[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z2047VenSts != T005Q2_A2047VenSts[0] ) || ( StringUtil.StrCmp(Z2049VenTipo, T005Q2_A2049VenTipo[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z2045VenDsc, T005Q2_A2045VenDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.vendedores:[seudo value changed for attri]"+"VenDsc");
                  GXUtil.WriteLogRaw("Old: ",Z2045VenDsc);
                  GXUtil.WriteLogRaw("Current: ",T005Q2_A2045VenDsc[0]);
               }
               if ( StringUtil.StrCmp(Z2044VenDir, T005Q2_A2044VenDir[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.vendedores:[seudo value changed for attri]"+"VenDir");
                  GXUtil.WriteLogRaw("Old: ",Z2044VenDir);
                  GXUtil.WriteLogRaw("Current: ",T005Q2_A2044VenDir[0]);
               }
               if ( StringUtil.StrCmp(Z2048VenTelf, T005Q2_A2048VenTelf[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.vendedores:[seudo value changed for attri]"+"VenTelf");
                  GXUtil.WriteLogRaw("Old: ",Z2048VenTelf);
                  GXUtil.WriteLogRaw("Current: ",T005Q2_A2048VenTelf[0]);
               }
               if ( StringUtil.StrCmp(Z2043VenCel, T005Q2_A2043VenCel[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.vendedores:[seudo value changed for attri]"+"VenCel");
                  GXUtil.WriteLogRaw("Old: ",Z2043VenCel);
                  GXUtil.WriteLogRaw("Current: ",T005Q2_A2043VenCel[0]);
               }
               if ( StringUtil.StrCmp(Z2046VenRuc, T005Q2_A2046VenRuc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.vendedores:[seudo value changed for attri]"+"VenRuc");
                  GXUtil.WriteLogRaw("Old: ",Z2046VenRuc);
                  GXUtil.WriteLogRaw("Current: ",T005Q2_A2046VenRuc[0]);
               }
               if ( Z2047VenSts != T005Q2_A2047VenSts[0] )
               {
                  GXUtil.WriteLog("configuracion.vendedores:[seudo value changed for attri]"+"VenSts");
                  GXUtil.WriteLogRaw("Old: ",Z2047VenSts);
                  GXUtil.WriteLogRaw("Current: ",T005Q2_A2047VenSts[0]);
               }
               if ( StringUtil.StrCmp(Z2049VenTipo, T005Q2_A2049VenTipo[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.vendedores:[seudo value changed for attri]"+"VenTipo");
                  GXUtil.WriteLogRaw("Old: ",Z2049VenTipo);
                  GXUtil.WriteLogRaw("Current: ",T005Q2_A2049VenTipo[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CVENDEDORES"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert5Q138( )
      {
         BeforeValidate5Q138( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5Q138( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM5Q138( 0) ;
            CheckOptimisticConcurrency5Q138( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5Q138( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert5Q138( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005Q8 */
                     pr_default.execute(6, new Object[] {A309VenCod, A2045VenDsc, A2044VenDir, A2048VenTelf, A2043VenCel, A2046VenRuc, A2047VenSts, A2049VenTipo});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CVENDEDORES");
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
                           ResetCaption5Q0( ) ;
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
               Load5Q138( ) ;
            }
            EndLevel5Q138( ) ;
         }
         CloseExtendedTableCursors5Q138( ) ;
      }

      protected void Update5Q138( )
      {
         BeforeValidate5Q138( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable5Q138( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5Q138( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm5Q138( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate5Q138( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T005Q9 */
                     pr_default.execute(7, new Object[] {A2045VenDsc, A2044VenDir, A2048VenTelf, A2043VenCel, A2046VenRuc, A2047VenSts, A2049VenTipo, A309VenCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CVENDEDORES");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CVENDEDORES"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate5Q138( ) ;
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
            EndLevel5Q138( ) ;
         }
         CloseExtendedTableCursors5Q138( ) ;
      }

      protected void DeferredUpdate5Q138( )
      {
      }

      protected void delete( )
      {
         BeforeValidate5Q138( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency5Q138( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls5Q138( ) ;
            AfterConfirm5Q138( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete5Q138( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T005Q10 */
                  pr_default.execute(8, new Object[] {A309VenCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CVENDEDORES");
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
         sMode138 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel5Q138( ) ;
         Gx_mode = sMode138;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls5Q138( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T005Q11 */
            pr_default.execute(9, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Usuarios"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T005Q12 */
            pr_default.execute(10, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Documentos de Venta"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T005Q13 */
            pr_default.execute(11, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Pedidos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T005Q14 */
            pr_default.execute(12, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera Documentos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T005Q15 */
            pr_default.execute(13, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cuenta x Cobrar"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T005Q16 */
            pr_default.execute(14, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cabecera de Cotizacion"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
            /* Using cursor T005Q17 */
            pr_default.execute(15, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(15) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cobranza - Cabecera"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(15);
            /* Using cursor T005Q18 */
            pr_default.execute(16, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Maestros de Clientes"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T005Q19 */
            pr_default.execute(17, new Object[] {A309VenCod});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Anticipos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void EndLevel5Q138( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete5Q138( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.vendedores",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues5Q0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.vendedores",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart5Q138( )
      {
         /* Scan By routine */
         /* Using cursor T005Q20 */
         pr_default.execute(18);
         RcdFound138 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound138 = 1;
            A309VenCod = T005Q20_A309VenCod[0];
            AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext5Q138( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound138 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound138 = 1;
            A309VenCod = T005Q20_A309VenCod[0];
            AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
         }
      }

      protected void ScanEnd5Q138( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm5Q138( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert5Q138( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate5Q138( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete5Q138( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete5Q138( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate5Q138( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes5Q138( )
      {
         cmbVenTipo.Enabled = 0;
         AssignProp("", false, cmbVenTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbVenTipo.Enabled), 5, 0), true);
         edtVenCod_Enabled = 0;
         AssignProp("", false, edtVenCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVenCod_Enabled), 5, 0), true);
         edtVenDsc_Enabled = 0;
         AssignProp("", false, edtVenDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVenDsc_Enabled), 5, 0), true);
         edtVenDir_Enabled = 0;
         AssignProp("", false, edtVenDir_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVenDir_Enabled), 5, 0), true);
         edtVenTelf_Enabled = 0;
         AssignProp("", false, edtVenTelf_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVenTelf_Enabled), 5, 0), true);
         edtVenCel_Enabled = 0;
         AssignProp("", false, edtVenCel_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVenCel_Enabled), 5, 0), true);
         edtVenRuc_Enabled = 0;
         AssignProp("", false, edtVenRuc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVenRuc_Enabled), 5, 0), true);
         cmbVenSts.Enabled = 0;
         AssignProp("", false, cmbVenSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbVenSts.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes5Q138( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues5Q0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281810261631", false, true);
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
         GXEncryptionTmp = "configuracion.vendedores.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7VenCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.vendedores.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Vendedores");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\vendedores:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z309VenCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z309VenCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2045VenDsc", StringUtil.RTrim( Z2045VenDsc));
         GxWebStd.gx_hidden_field( context, "Z2044VenDir", StringUtil.RTrim( Z2044VenDir));
         GxWebStd.gx_hidden_field( context, "Z2048VenTelf", StringUtil.RTrim( Z2048VenTelf));
         GxWebStd.gx_hidden_field( context, "Z2043VenCel", StringUtil.RTrim( Z2043VenCel));
         GxWebStd.gx_hidden_field( context, "Z2046VenRuc", StringUtil.RTrim( Z2046VenRuc));
         GxWebStd.gx_hidden_field( context, "Z2047VenSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z2047VenSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z2049VenTipo", StringUtil.RTrim( Z2049VenTipo));
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
         GxWebStd.gx_hidden_field( context, "vVENCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7VenCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vVENCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7VenCod), "ZZZZZ9"), context));
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
         GXEncryptionTmp = "configuracion.vendedores.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7VenCod,6,0));
         return formatLink("configuracion.vendedores.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.Vendedores" ;
      }

      public override string GetPgmdesc( )
      {
         return "Vendedores" ;
      }

      protected void InitializeNonKey5Q138( )
      {
         A2045VenDsc = "";
         AssignAttri("", false, "A2045VenDsc", A2045VenDsc);
         A2044VenDir = "";
         AssignAttri("", false, "A2044VenDir", A2044VenDir);
         A2048VenTelf = "";
         AssignAttri("", false, "A2048VenTelf", A2048VenTelf);
         A2043VenCel = "";
         AssignAttri("", false, "A2043VenCel", A2043VenCel);
         A2046VenRuc = "";
         AssignAttri("", false, "A2046VenRuc", A2046VenRuc);
         A2049VenTipo = "";
         AssignAttri("", false, "A2049VenTipo", A2049VenTipo);
         A2047VenSts = 1;
         AssignAttri("", false, "A2047VenSts", StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
         Z2045VenDsc = "";
         Z2044VenDir = "";
         Z2048VenTelf = "";
         Z2043VenCel = "";
         Z2046VenRuc = "";
         Z2047VenSts = 0;
         Z2049VenTipo = "";
      }

      protected void InitAll5Q138( )
      {
         A309VenCod = 0;
         AssignAttri("", false, "A309VenCod", StringUtil.LTrimStr( (decimal)(A309VenCod), 6, 0));
         InitializeNonKey5Q138( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A2047VenSts = i2047VenSts;
         AssignAttri("", false, "A2047VenSts", StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281810261652", true, true);
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
         context.AddJavascriptSource("configuracion/vendedores.js", "?202281810261652", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         cmbVenTipo_Internalname = "VENTIPO";
         edtVenCod_Internalname = "VENCOD";
         edtVenDsc_Internalname = "VENDSC";
         edtVenDir_Internalname = "VENDIR";
         edtVenTelf_Internalname = "VENTELF";
         edtVenCel_Internalname = "VENCEL";
         edtVenRuc_Internalname = "VENRUC";
         cmbVenSts_Internalname = "VENSTS";
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
         Form.Caption = "Vendedores";
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbVenSts_Jsonclick = "";
         cmbVenSts.Enabled = 1;
         edtVenRuc_Jsonclick = "";
         edtVenRuc_Enabled = 1;
         edtVenCel_Jsonclick = "";
         edtVenCel_Enabled = 1;
         edtVenTelf_Jsonclick = "";
         edtVenTelf_Enabled = 1;
         edtVenDir_Jsonclick = "";
         edtVenDir_Enabled = 1;
         edtVenDsc_Jsonclick = "";
         edtVenDsc_Enabled = 1;
         edtVenCod_Jsonclick = "";
         edtVenCod_Enabled = 1;
         cmbVenTipo_Jsonclick = "";
         cmbVenTipo.Enabled = 1;
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
         cmbVenTipo.Name = "VENTIPO";
         cmbVenTipo.WebTags = "";
         cmbVenTipo.addItem("T", "Ambos", 0);
         cmbVenTipo.addItem("V", "Vendedor", 0);
         cmbVenTipo.addItem("C", "Cobrador", 0);
         if ( cmbVenTipo.ItemCount > 0 )
         {
            A2049VenTipo = cmbVenTipo.getValidValue(A2049VenTipo);
            AssignAttri("", false, "A2049VenTipo", A2049VenTipo);
         }
         cmbVenSts.Name = "VENSTS";
         cmbVenSts.WebTags = "";
         cmbVenSts.addItem("1", "ACTIVO", 0);
         cmbVenSts.addItem("0", "INACTIVO", 0);
         if ( cmbVenSts.ItemCount > 0 )
         {
            if ( (0==A2047VenSts) )
            {
               A2047VenSts = 1;
               AssignAttri("", false, "A2047VenSts", StringUtil.Str( (decimal)(A2047VenSts), 1, 0));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7VenCod',fld:'vVENCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7VenCod',fld:'vVENCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E125Q2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A309VenCod',fld:'VENCOD',pic:'ZZZZZ9'},{av:'A2045VenDsc',fld:'VENDSC',pic:''},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_VENTIPO","{handler:'Valid_Ventipo',iparms:[]");
         setEventMetadata("VALID_VENTIPO",",oparms:[]}");
         setEventMetadata("VALID_VENCOD","{handler:'Valid_Vencod',iparms:[]");
         setEventMetadata("VALID_VENCOD",",oparms:[]}");
         setEventMetadata("VALID_VENDSC","{handler:'Valid_Vendsc',iparms:[]");
         setEventMetadata("VALID_VENDSC",",oparms:[]}");
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
         Z2045VenDsc = "";
         Z2044VenDir = "";
         Z2048VenTelf = "";
         Z2043VenCel = "";
         Z2046VenRuc = "";
         Z2049VenTipo = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A2049VenTipo = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A2045VenDsc = "";
         A2044VenDir = "";
         A2048VenTelf = "";
         A2043VenCel = "";
         A2046VenRuc = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode138 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV11SGAuDocGls = "";
         AV12Codigo = "";
         GXt_char1 = "";
         GXt_char2 = "";
         GXt_char3 = "";
         T005Q4_A309VenCod = new int[1] ;
         T005Q4_A2045VenDsc = new string[] {""} ;
         T005Q4_A2044VenDir = new string[] {""} ;
         T005Q4_A2048VenTelf = new string[] {""} ;
         T005Q4_A2043VenCel = new string[] {""} ;
         T005Q4_A2046VenRuc = new string[] {""} ;
         T005Q4_A2047VenSts = new short[1] ;
         T005Q4_A2049VenTipo = new string[] {""} ;
         T005Q5_A309VenCod = new int[1] ;
         T005Q3_A309VenCod = new int[1] ;
         T005Q3_A2045VenDsc = new string[] {""} ;
         T005Q3_A2044VenDir = new string[] {""} ;
         T005Q3_A2048VenTelf = new string[] {""} ;
         T005Q3_A2043VenCel = new string[] {""} ;
         T005Q3_A2046VenRuc = new string[] {""} ;
         T005Q3_A2047VenSts = new short[1] ;
         T005Q3_A2049VenTipo = new string[] {""} ;
         T005Q6_A309VenCod = new int[1] ;
         T005Q7_A309VenCod = new int[1] ;
         T005Q2_A309VenCod = new int[1] ;
         T005Q2_A2045VenDsc = new string[] {""} ;
         T005Q2_A2044VenDir = new string[] {""} ;
         T005Q2_A2048VenTelf = new string[] {""} ;
         T005Q2_A2043VenCel = new string[] {""} ;
         T005Q2_A2046VenRuc = new string[] {""} ;
         T005Q2_A2047VenSts = new short[1] ;
         T005Q2_A2049VenTipo = new string[] {""} ;
         T005Q11_A348UsuCod = new string[] {""} ;
         T005Q12_A149TipCod = new string[] {""} ;
         T005Q12_A24DocNum = new string[] {""} ;
         T005Q13_A210PedCod = new string[] {""} ;
         T005Q14_A191ImpItem = new long[1] ;
         T005Q15_A184CCTipCod = new string[] {""} ;
         T005Q15_A185CCDocNum = new string[] {""} ;
         T005Q16_A177CotCod = new string[] {""} ;
         T005Q17_A166CobTip = new string[] {""} ;
         T005Q17_A167CobCod = new string[] {""} ;
         T005Q18_A45CliCod = new string[] {""} ;
         T005Q19_A144CLAntTipCod = new string[] {""} ;
         T005Q19_A145CLAntDocNum = new string[] {""} ;
         T005Q20_A309VenCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.vendedores__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.vendedores__default(),
            new Object[][] {
                new Object[] {
               T005Q2_A309VenCod, T005Q2_A2045VenDsc, T005Q2_A2044VenDir, T005Q2_A2048VenTelf, T005Q2_A2043VenCel, T005Q2_A2046VenRuc, T005Q2_A2047VenSts, T005Q2_A2049VenTipo
               }
               , new Object[] {
               T005Q3_A309VenCod, T005Q3_A2045VenDsc, T005Q3_A2044VenDir, T005Q3_A2048VenTelf, T005Q3_A2043VenCel, T005Q3_A2046VenRuc, T005Q3_A2047VenSts, T005Q3_A2049VenTipo
               }
               , new Object[] {
               T005Q4_A309VenCod, T005Q4_A2045VenDsc, T005Q4_A2044VenDir, T005Q4_A2048VenTelf, T005Q4_A2043VenCel, T005Q4_A2046VenRuc, T005Q4_A2047VenSts, T005Q4_A2049VenTipo
               }
               , new Object[] {
               T005Q5_A309VenCod
               }
               , new Object[] {
               T005Q6_A309VenCod
               }
               , new Object[] {
               T005Q7_A309VenCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T005Q11_A348UsuCod
               }
               , new Object[] {
               T005Q12_A149TipCod, T005Q12_A24DocNum
               }
               , new Object[] {
               T005Q13_A210PedCod
               }
               , new Object[] {
               T005Q14_A191ImpItem
               }
               , new Object[] {
               T005Q15_A184CCTipCod, T005Q15_A185CCDocNum
               }
               , new Object[] {
               T005Q16_A177CotCod
               }
               , new Object[] {
               T005Q17_A166CobTip, T005Q17_A167CobCod
               }
               , new Object[] {
               T005Q18_A45CliCod
               }
               , new Object[] {
               T005Q19_A144CLAntTipCod, T005Q19_A145CLAntDocNum
               }
               , new Object[] {
               T005Q20_A309VenCod
               }
            }
         );
         Z2047VenSts = 1;
         A2047VenSts = 1;
         i2047VenSts = 1;
      }

      private short Z2047VenSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A2047VenSts ;
      private short Gx_BScreen ;
      private short RcdFound138 ;
      private short GX_JID ;
      private short nIsDirty_138 ;
      private short gxajaxcallmode ;
      private short i2047VenSts ;
      private int wcpOAV7VenCod ;
      private int Z309VenCod ;
      private int AV7VenCod ;
      private int trnEnded ;
      private int A309VenCod ;
      private int edtVenCod_Enabled ;
      private int edtVenDsc_Enabled ;
      private int edtVenDir_Enabled ;
      private int edtVenTelf_Enabled ;
      private int edtVenCel_Enabled ;
      private int edtVenRuc_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z2045VenDsc ;
      private string Z2044VenDir ;
      private string Z2048VenTelf ;
      private string Z2043VenCel ;
      private string Z2046VenRuc ;
      private string Z2049VenTipo ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string cmbVenTipo_Internalname ;
      private string A2049VenTipo ;
      private string cmbVenSts_Internalname ;
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
      private string cmbVenTipo_Jsonclick ;
      private string edtVenCod_Internalname ;
      private string edtVenCod_Jsonclick ;
      private string edtVenDsc_Internalname ;
      private string A2045VenDsc ;
      private string edtVenDsc_Jsonclick ;
      private string edtVenDir_Internalname ;
      private string A2044VenDir ;
      private string edtVenDir_Jsonclick ;
      private string edtVenTelf_Internalname ;
      private string A2048VenTelf ;
      private string edtVenTelf_Jsonclick ;
      private string edtVenCel_Internalname ;
      private string A2043VenCel ;
      private string edtVenCel_Jsonclick ;
      private string edtVenRuc_Internalname ;
      private string A2046VenRuc ;
      private string edtVenRuc_Jsonclick ;
      private string cmbVenSts_Jsonclick ;
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
      private string sMode138 ;
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
      private string AV11SGAuDocGls ;
      private string AV12Codigo ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbVenTipo ;
      private GXCombobox cmbVenSts ;
      private IDataStoreProvider pr_default ;
      private int[] T005Q4_A309VenCod ;
      private string[] T005Q4_A2045VenDsc ;
      private string[] T005Q4_A2044VenDir ;
      private string[] T005Q4_A2048VenTelf ;
      private string[] T005Q4_A2043VenCel ;
      private string[] T005Q4_A2046VenRuc ;
      private short[] T005Q4_A2047VenSts ;
      private string[] T005Q4_A2049VenTipo ;
      private int[] T005Q5_A309VenCod ;
      private int[] T005Q3_A309VenCod ;
      private string[] T005Q3_A2045VenDsc ;
      private string[] T005Q3_A2044VenDir ;
      private string[] T005Q3_A2048VenTelf ;
      private string[] T005Q3_A2043VenCel ;
      private string[] T005Q3_A2046VenRuc ;
      private short[] T005Q3_A2047VenSts ;
      private string[] T005Q3_A2049VenTipo ;
      private int[] T005Q6_A309VenCod ;
      private int[] T005Q7_A309VenCod ;
      private int[] T005Q2_A309VenCod ;
      private string[] T005Q2_A2045VenDsc ;
      private string[] T005Q2_A2044VenDir ;
      private string[] T005Q2_A2048VenTelf ;
      private string[] T005Q2_A2043VenCel ;
      private string[] T005Q2_A2046VenRuc ;
      private short[] T005Q2_A2047VenSts ;
      private string[] T005Q2_A2049VenTipo ;
      private string[] T005Q11_A348UsuCod ;
      private string[] T005Q12_A149TipCod ;
      private string[] T005Q12_A24DocNum ;
      private string[] T005Q13_A210PedCod ;
      private long[] T005Q14_A191ImpItem ;
      private string[] T005Q15_A184CCTipCod ;
      private string[] T005Q15_A185CCDocNum ;
      private string[] T005Q16_A177CotCod ;
      private string[] T005Q17_A166CobTip ;
      private string[] T005Q17_A167CobCod ;
      private string[] T005Q18_A45CliCod ;
      private string[] T005Q19_A144CLAntTipCod ;
      private string[] T005Q19_A145CLAntDocNum ;
      private int[] T005Q20_A309VenCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class vendedores__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class vendedores__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT005Q4;
        prmT005Q4 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q5;
        prmT005Q5 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q3;
        prmT005Q3 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q6;
        prmT005Q6 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q7;
        prmT005Q7 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q2;
        prmT005Q2 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q8;
        prmT005Q8 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0) ,
        new ParDef("@VenDsc",GXType.NChar,100,0) ,
        new ParDef("@VenDir",GXType.NChar,100,0) ,
        new ParDef("@VenTelf",GXType.NChar,15,0) ,
        new ParDef("@VenCel",GXType.NChar,15,0) ,
        new ParDef("@VenRuc",GXType.NChar,15,0) ,
        new ParDef("@VenSts",GXType.Int16,1,0) ,
        new ParDef("@VenTipo",GXType.NChar,1,0)
        };
        Object[] prmT005Q9;
        prmT005Q9 = new Object[] {
        new ParDef("@VenDsc",GXType.NChar,100,0) ,
        new ParDef("@VenDir",GXType.NChar,100,0) ,
        new ParDef("@VenTelf",GXType.NChar,15,0) ,
        new ParDef("@VenCel",GXType.NChar,15,0) ,
        new ParDef("@VenRuc",GXType.NChar,15,0) ,
        new ParDef("@VenSts",GXType.Int16,1,0) ,
        new ParDef("@VenTipo",GXType.NChar,1,0) ,
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q10;
        prmT005Q10 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q11;
        prmT005Q11 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q12;
        prmT005Q12 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q13;
        prmT005Q13 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q14;
        prmT005Q14 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q15;
        prmT005Q15 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q16;
        prmT005Q16 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q17;
        prmT005Q17 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q18;
        prmT005Q18 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q19;
        prmT005Q19 = new Object[] {
        new ParDef("@VenCod",GXType.Int32,6,0)
        };
        Object[] prmT005Q20;
        prmT005Q20 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T005Q2", "SELECT [VenCod], [VenDsc], [VenDir], [VenTelf], [VenCel], [VenRuc], [VenSts], [VenTipo] FROM [CVENDEDORES] WITH (UPDLOCK) WHERE [VenCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005Q3", "SELECT [VenCod], [VenDsc], [VenDir], [VenTelf], [VenCel], [VenRuc], [VenSts], [VenTipo] FROM [CVENDEDORES] WHERE [VenCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005Q4", "SELECT TM1.[VenCod], TM1.[VenDsc], TM1.[VenDir], TM1.[VenTelf], TM1.[VenCel], TM1.[VenRuc], TM1.[VenSts], TM1.[VenTipo] FROM [CVENDEDORES] TM1 WHERE TM1.[VenCod] = @VenCod ORDER BY TM1.[VenCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005Q5", "SELECT [VenCod] FROM [CVENDEDORES] WHERE [VenCod] = @VenCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T005Q6", "SELECT TOP 1 [VenCod] FROM [CVENDEDORES] WHERE ( [VenCod] > @VenCod) ORDER BY [VenCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005Q7", "SELECT TOP 1 [VenCod] FROM [CVENDEDORES] WHERE ( [VenCod] < @VenCod) ORDER BY [VenCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005Q8", "INSERT INTO [CVENDEDORES]([VenCod], [VenDsc], [VenDir], [VenTelf], [VenCel], [VenRuc], [VenSts], [VenTipo]) VALUES(@VenCod, @VenDsc, @VenDir, @VenTelf, @VenCel, @VenRuc, @VenSts, @VenTipo)", GxErrorMask.GX_NOMASK,prmT005Q8)
           ,new CursorDef("T005Q9", "UPDATE [CVENDEDORES] SET [VenDsc]=@VenDsc, [VenDir]=@VenDir, [VenTelf]=@VenTelf, [VenCel]=@VenCel, [VenRuc]=@VenRuc, [VenSts]=@VenSts, [VenTipo]=@VenTipo  WHERE [VenCod] = @VenCod", GxErrorMask.GX_NOMASK,prmT005Q9)
           ,new CursorDef("T005Q10", "DELETE FROM [CVENDEDORES]  WHERE [VenCod] = @VenCod", GxErrorMask.GX_NOMASK,prmT005Q10)
           ,new CursorDef("T005Q11", "SELECT TOP 1 [UsuCod] FROM [SGUSUARIOS] WHERE [UsuVend] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005Q12", "SELECT TOP 1 [TipCod], [DocNum] FROM [CLVENTAS] WHERE [DocVendCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005Q13", "SELECT TOP 1 [PedCod] FROM [CLPEDIDOS] WHERE [PedVendCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005Q14", "SELECT TOP 1 [ImpItem] FROM [CLDOCUMENTOS] WHERE [ImpVendCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005Q15", "SELECT TOP 1 [CCTipCod], [CCDocNum] FROM [CLCUENTACOBRAR] WHERE [CCVendCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005Q16", "SELECT TOP 1 [CotCod] FROM [CLCOTIZA] WHERE [CotVendCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005Q17", "SELECT TOP 1 [CobTip], [CobCod] FROM [CLCOBRANZA] WHERE [CobVendCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q17,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005Q18", "SELECT TOP 1 [CliCod] FROM [CLCLIENTES] WHERE [CliVend] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005Q19", "SELECT TOP 1 [CLAntTipCod], [CLAntDocNum] FROM [CLANTICIPOS] WHERE [CLAntVenCod] = @VenCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T005Q20", "SELECT [VenCod] FROM [CVENDEDORES] ORDER BY [VenCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT005Q20,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 100);
              ((string[]) buf[3])[0] = rslt.getString(4, 15);
              ((string[]) buf[4])[0] = rslt.getString(5, 15);
              ((string[]) buf[5])[0] = rslt.getString(6, 15);
              ((short[]) buf[6])[0] = rslt.getShort(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getString(1, 10);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 1);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 16 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((string[]) buf[1])[0] = rslt.getString(2, 12);
              return;
           case 18 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
