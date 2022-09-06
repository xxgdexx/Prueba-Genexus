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
   public class lineasproductos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel4"+"_"+"vCLINCOD") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX4ASACLINCOD0G17( ) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "configuracion.lineasproductos.aspx")), "configuracion.lineasproductos.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "configuracion.lineasproductos.aspx")))) ;
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
                  AV13LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
                  AssignAttri("", false, "AV13LinCod", StringUtil.LTrimStr( (decimal)(AV13LinCod), 6, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vLINCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13LinCod), "ZZZZZ9"), context));
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
            Form.Meta.addItem("description", "Lineas", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtLinDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusTheme");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public lineasproductos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusTheme");
      }

      public lineasproductos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore2 = context.GetDataStore("DataStore2");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_LinCod )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV13LinCod = aP1_LinCod;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLinDsc_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLinDsc_Internalname, "Linea de Producto", "col-sm-3 AttributeRealWidthLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinDsc_Internalname, StringUtil.RTrim( A1153LinDsc), StringUtil.RTrim( context.localUtil.Format( A1153LinDsc, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinDsc_Jsonclick, 0, "AttributeRealWidth", "", "", "", "", 1, edtLinDsc_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\LineasProductos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLinAbr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLinAbr_Internalname, "Abreviatura", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinAbr_Internalname, StringUtil.RTrim( A1152LinAbr), StringUtil.RTrim( context.localUtil.Format( A1152LinAbr, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinAbr_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinAbr_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\LineasProductos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 RequiredDataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLinSunat_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLinSunat_Internalname, "Codigo Sunat", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinSunat_Internalname, A1160LinSunat, StringUtil.RTrim( context.localUtil.Format( A1160LinSunat, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinSunat_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinSunat_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\LineasProductos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLinRef1_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLinRef1_Internalname, "Referencia 1", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinRef1_Internalname, A1154LinRef1, StringUtil.RTrim( context.localUtil.Format( A1154LinRef1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,37);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinRef1_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinRef1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\LineasProductos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLinRef2_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLinRef2_Internalname, "Referencia 2", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 42,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinRef2_Internalname, A1155LinRef2, StringUtil.RTrim( context.localUtil.Format( A1155LinRef2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,42);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinRef2_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinRef2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\LineasProductos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLinRef3_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLinRef3_Internalname, "Referencia 3", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinRef3_Internalname, A1156LinRef3, StringUtil.RTrim( context.localUtil.Format( A1156LinRef3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinRef3_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinRef3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\LineasProductos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLinRef4_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLinRef4_Internalname, "Referencia 4", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinRef4_Internalname, A1157LinRef4, StringUtil.RTrim( context.localUtil.Format( A1157LinRef4, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinRef4_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinRef4_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 1, -1, -1, true, "", "left", true, "", "HLP_Configuracion\\LineasProductos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLinStk_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLinStk_Internalname, "Controla Stock", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinStk_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1158LinStk), 1, 0, ".", "")), StringUtil.LTrim( ((edtLinStk_Enabled!=0) ? context.localUtil.Format( (decimal)(A1158LinStk), "9") : context.localUtil.Format( (decimal)(A1158LinStk), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinStk_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinStk_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\LineasProductos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtLinSts_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtLinSts_Internalname, "Estado", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinSts_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A1159LinSts), 1, 0, ".", "")), StringUtil.LTrim( ((edtLinSts_Enabled!=0) ? context.localUtil.Format( (decimal)(A1159LinSts), "9") : context.localUtil.Format( (decimal)(A1159LinSts), "9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinSts_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtLinSts_Enabled, 0, "text", "1", 1, "chr", 1, "row", 1, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\LineasProductos.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\LineasProductos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Cancelar", bttBtntrn_cancel_Jsonclick, 1, "Cancelar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\LineasProductos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_delete_Internalname, "", "Eliminar", bttBtntrn_delete_Jsonclick, 5, "Eliminar", "", StyleString, ClassString, bttBtntrn_delete_Visible, bttBtntrn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Configuracion\\LineasProductos.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 75,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtLinCod_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A52LinCod), 6, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A52LinCod), "ZZZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,75);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtLinCod_Jsonclick, 0, "Attribute", "", "", "", "", edtLinCod_Visible, edtLinCod_Enabled, 1, "text", "1", 6, "chr", 1, "row", 6, 0, 0, 0, 1, -1, 0, true, "", "right", false, "", "HLP_Configuracion\\LineasProductos.htm");
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
         E110G2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z52LinCod = (int)(context.localUtil.CToN( cgiGet( "Z52LinCod"), ".", ","));
               Z1153LinDsc = cgiGet( "Z1153LinDsc");
               Z1152LinAbr = cgiGet( "Z1152LinAbr");
               Z1160LinSunat = cgiGet( "Z1160LinSunat");
               Z1158LinStk = (short)(context.localUtil.CToN( cgiGet( "Z1158LinStk"), ".", ","));
               Z1159LinSts = (short)(context.localUtil.CToN( cgiGet( "Z1159LinSts"), ".", ","));
               Z1154LinRef1 = cgiGet( "Z1154LinRef1");
               Z1155LinRef2 = cgiGet( "Z1155LinRef2");
               Z1156LinRef3 = cgiGet( "Z1156LinRef3");
               Z1157LinRef4 = cgiGet( "Z1157LinRef4");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV13LinCod = (int)(context.localUtil.CToN( cgiGet( "vLINCOD"), ".", ","));
               AV14cLinCod = (int)(context.localUtil.CToN( cgiGet( "vCLINCOD"), ".", ","));
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
               A1153LinDsc = cgiGet( edtLinDsc_Internalname);
               AssignAttri("", false, "A1153LinDsc", A1153LinDsc);
               A1152LinAbr = cgiGet( edtLinAbr_Internalname);
               AssignAttri("", false, "A1152LinAbr", A1152LinAbr);
               A1160LinSunat = cgiGet( edtLinSunat_Internalname);
               AssignAttri("", false, "A1160LinSunat", A1160LinSunat);
               A1154LinRef1 = cgiGet( edtLinRef1_Internalname);
               AssignAttri("", false, "A1154LinRef1", A1154LinRef1);
               A1155LinRef2 = cgiGet( edtLinRef2_Internalname);
               AssignAttri("", false, "A1155LinRef2", A1155LinRef2);
               A1156LinRef3 = cgiGet( edtLinRef3_Internalname);
               AssignAttri("", false, "A1156LinRef3", A1156LinRef3);
               A1157LinRef4 = cgiGet( edtLinRef4_Internalname);
               AssignAttri("", false, "A1157LinRef4", A1157LinRef4);
               if ( ( ( context.localUtil.CToN( cgiGet( edtLinStk_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLinStk_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LINSTK");
                  AnyError = 1;
                  GX_FocusControl = edtLinStk_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1158LinStk = 0;
                  AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
               }
               else
               {
                  A1158LinStk = (short)(context.localUtil.CToN( cgiGet( edtLinStk_Internalname), ".", ","));
                  AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtLinSts_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLinSts_Internalname), ".", ",") > Convert.ToDecimal( 9 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LINSTS");
                  AnyError = 1;
                  GX_FocusControl = edtLinSts_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A1159LinSts = 0;
                  AssignAttri("", false, "A1159LinSts", StringUtil.Str( (decimal)(A1159LinSts), 1, 0));
               }
               else
               {
                  A1159LinSts = (short)(context.localUtil.CToN( cgiGet( edtLinSts_Internalname), ".", ","));
                  AssignAttri("", false, "A1159LinSts", StringUtil.Str( (decimal)(A1159LinSts), 1, 0));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtLinCod_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtLinCod_Internalname), ".", ",") > Convert.ToDecimal( 999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "LINCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLinCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A52LinCod = 0;
                  AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
               }
               else
               {
                  A52LinCod = (int)(context.localUtil.CToN( cgiGet( edtLinCod_Internalname), ".", ","));
                  AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Crypto.GetSiteKey( );
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"LineasProductos");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A52LinCod != Z52LinCod ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("configuracion\\lineasproductos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A52LinCod = (int)(NumberUtil.Val( GetPar( "LinCod"), "."));
                  AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
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
                     sMode17 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode17;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound17 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0G0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "LINCOD");
                        AnyError = 1;
                        GX_FocusControl = edtLinCod_Internalname;
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
                           E110G2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120G2 ();
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
            E120G2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0G17( ) ;
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
            DisableAttributes0G17( ) ;
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

      protected void CONFIRM_0G0( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0G17( ) ;
            }
            else
            {
               CheckExtendedTable0G17( ) ;
               CloseExtendedTableCursors0G17( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0G0( )
      {
      }

      protected void E110G2( )
      {
         /* Start Routine */
         returnInSub = false;
         divLayoutmaintable_Class = divLayoutmaintable_Class+" "+"EditForm";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtLinCod_Visible = 0;
         AssignProp("", false, edtLinCod_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtLinCod_Visible), 5, 0), true);
      }

      protected void E120G2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV15SGAuDocGls = "Linea de Producto N° " + StringUtil.Trim( StringUtil.Str( (decimal)(A52LinCod), 10, 0)) + " " + StringUtil.Trim( A1153LinDsc);
            AV16Codigo = StringUtil.Trim( StringUtil.Str( (decimal)(A52LinCod), 10, 0));
            GXt_char1 = "CNF";
            GXt_char2 = "";
            GXt_char3 = "Eliminación";
            new GeneXus.Programs.configuracion.pgrabaauditoria(context ).execute( ref  GXt_char1, ref  AV15SGAuDocGls, ref  AV16Codigo, ref  AV16Codigo, ref  GXt_char2, ref  GXt_char3) ;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0G17( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z1153LinDsc = T000G3_A1153LinDsc[0];
               Z1152LinAbr = T000G3_A1152LinAbr[0];
               Z1160LinSunat = T000G3_A1160LinSunat[0];
               Z1158LinStk = T000G3_A1158LinStk[0];
               Z1159LinSts = T000G3_A1159LinSts[0];
               Z1154LinRef1 = T000G3_A1154LinRef1[0];
               Z1155LinRef2 = T000G3_A1155LinRef2[0];
               Z1156LinRef3 = T000G3_A1156LinRef3[0];
               Z1157LinRef4 = T000G3_A1157LinRef4[0];
            }
            else
            {
               Z1153LinDsc = A1153LinDsc;
               Z1152LinAbr = A1152LinAbr;
               Z1160LinSunat = A1160LinSunat;
               Z1158LinStk = A1158LinStk;
               Z1159LinSts = A1159LinSts;
               Z1154LinRef1 = A1154LinRef1;
               Z1155LinRef2 = A1155LinRef2;
               Z1156LinRef3 = A1156LinRef3;
               Z1157LinRef4 = A1157LinRef4;
            }
         }
         if ( GX_JID == -10 )
         {
            Z52LinCod = A52LinCod;
            Z1153LinDsc = A1153LinDsc;
            Z1152LinAbr = A1152LinAbr;
            Z1160LinSunat = A1160LinSunat;
            Z1158LinStk = A1158LinStk;
            Z1159LinSts = A1159LinSts;
            Z1154LinRef1 = A1154LinRef1;
            Z1155LinRef2 = A1155LinRef2;
            Z1156LinRef3 = A1156LinRef3;
            Z1157LinRef4 = A1157LinRef4;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         bttBtntrn_delete_Enabled = 0;
         AssignProp("", false, bttBtntrn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV13LinCod) )
         {
            A52LinCod = AV13LinCod;
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
         }
         if ( ! (0==AV13LinCod) )
         {
            edtLinCod_Enabled = 0;
            AssignProp("", false, edtLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinCod_Enabled), 5, 0), true);
         }
         else
         {
            edtLinCod_Enabled = 1;
            AssignProp("", false, edtLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinCod_Enabled), 5, 0), true);
         }
         if ( ! (0==AV13LinCod) )
         {
            edtLinCod_Enabled = 0;
            AssignProp("", false, edtLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinCod_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (0==A1159LinSts) && ( Gx_BScreen == 0 ) )
         {
            A1159LinSts = 1;
            AssignAttri("", false, "A1159LinSts", StringUtil.Str( (decimal)(A1159LinSts), 1, 0));
         }
      }

      protected void Load0G17( )
      {
         /* Using cursor T000G4 */
         pr_default.execute(2, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound17 = 1;
            A1153LinDsc = T000G4_A1153LinDsc[0];
            AssignAttri("", false, "A1153LinDsc", A1153LinDsc);
            A1152LinAbr = T000G4_A1152LinAbr[0];
            AssignAttri("", false, "A1152LinAbr", A1152LinAbr);
            A1160LinSunat = T000G4_A1160LinSunat[0];
            AssignAttri("", false, "A1160LinSunat", A1160LinSunat);
            A1158LinStk = T000G4_A1158LinStk[0];
            AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
            A1159LinSts = T000G4_A1159LinSts[0];
            AssignAttri("", false, "A1159LinSts", StringUtil.Str( (decimal)(A1159LinSts), 1, 0));
            A1154LinRef1 = T000G4_A1154LinRef1[0];
            AssignAttri("", false, "A1154LinRef1", A1154LinRef1);
            A1155LinRef2 = T000G4_A1155LinRef2[0];
            AssignAttri("", false, "A1155LinRef2", A1155LinRef2);
            A1156LinRef3 = T000G4_A1156LinRef3[0];
            AssignAttri("", false, "A1156LinRef3", A1156LinRef3);
            A1157LinRef4 = T000G4_A1157LinRef4[0];
            AssignAttri("", false, "A1157LinRef4", A1157LinRef4);
            ZM0G17( -10) ;
         }
         pr_default.close(2);
         OnLoadActions0G17( ) ;
      }

      protected void OnLoadActions0G17( )
      {
      }

      protected void CheckExtendedTable0G17( )
      {
         nIsDirty_17 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1153LinDsc)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Descripcion de Linea", "", "", "", "", "", "", "", ""), 1, "LINDSC");
            AnyError = 1;
            GX_FocusControl = edtLinDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1152LinAbr)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Abreviatura de Linea", "", "", "", "", "", "", "", ""), 1, "LINABR");
            AnyError = 1;
            GX_FocusControl = edtLinAbr_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A1160LinSunat)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 es requerido.", "Cod.Sunat", "", "", "", "", "", "", "", ""), 1, "LINSUNAT");
            AnyError = 1;
            GX_FocusControl = edtLinSunat_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0G17( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0G17( )
      {
         /* Using cursor T000G5 */
         pr_default.execute(3, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000G3 */
         pr_default.execute(1, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G17( 10) ;
            RcdFound17 = 1;
            A52LinCod = T000G3_A52LinCod[0];
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
            A1153LinDsc = T000G3_A1153LinDsc[0];
            AssignAttri("", false, "A1153LinDsc", A1153LinDsc);
            A1152LinAbr = T000G3_A1152LinAbr[0];
            AssignAttri("", false, "A1152LinAbr", A1152LinAbr);
            A1160LinSunat = T000G3_A1160LinSunat[0];
            AssignAttri("", false, "A1160LinSunat", A1160LinSunat);
            A1158LinStk = T000G3_A1158LinStk[0];
            AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
            A1159LinSts = T000G3_A1159LinSts[0];
            AssignAttri("", false, "A1159LinSts", StringUtil.Str( (decimal)(A1159LinSts), 1, 0));
            A1154LinRef1 = T000G3_A1154LinRef1[0];
            AssignAttri("", false, "A1154LinRef1", A1154LinRef1);
            A1155LinRef2 = T000G3_A1155LinRef2[0];
            AssignAttri("", false, "A1155LinRef2", A1155LinRef2);
            A1156LinRef3 = T000G3_A1156LinRef3[0];
            AssignAttri("", false, "A1156LinRef3", A1156LinRef3);
            A1157LinRef4 = T000G3_A1157LinRef4[0];
            AssignAttri("", false, "A1157LinRef4", A1157LinRef4);
            Z52LinCod = A52LinCod;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0G17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0G17( ) ;
            }
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0G17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G17( ) ;
         if ( RcdFound17 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound17 = 0;
         /* Using cursor T000G6 */
         pr_default.execute(4, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000G6_A52LinCod[0] < A52LinCod ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000G6_A52LinCod[0] > A52LinCod ) ) )
            {
               A52LinCod = T000G6_A52LinCod[0];
               AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound17 = 0;
         /* Using cursor T000G7 */
         pr_default.execute(5, new Object[] {A52LinCod});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000G7_A52LinCod[0] > A52LinCod ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000G7_A52LinCod[0] < A52LinCod ) ) )
            {
               A52LinCod = T000G7_A52LinCod[0];
               AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0G17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtLinDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0G17( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A52LinCod != Z52LinCod )
               {
                  A52LinCod = Z52LinCod;
                  AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "LINCOD");
                  AnyError = 1;
                  GX_FocusControl = edtLinCod_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtLinDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0G17( ) ;
                  GX_FocusControl = edtLinDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A52LinCod != Z52LinCod )
               {
                  /* Insert record */
                  GX_FocusControl = edtLinDsc_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0G17( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "LINCOD");
                     AnyError = 1;
                     GX_FocusControl = edtLinCod_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtLinDsc_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0G17( ) ;
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
         if ( A52LinCod != Z52LinCod )
         {
            A52LinCod = Z52LinCod;
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "LINCOD");
            AnyError = 1;
            GX_FocusControl = edtLinCod_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtLinDsc_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0G17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000G2 */
            pr_default.execute(0, new Object[] {A52LinCod});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLINEAPROD"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z1153LinDsc, T000G2_A1153LinDsc[0]) != 0 ) || ( StringUtil.StrCmp(Z1152LinAbr, T000G2_A1152LinAbr[0]) != 0 ) || ( StringUtil.StrCmp(Z1160LinSunat, T000G2_A1160LinSunat[0]) != 0 ) || ( Z1158LinStk != T000G2_A1158LinStk[0] ) || ( Z1159LinSts != T000G2_A1159LinSts[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z1154LinRef1, T000G2_A1154LinRef1[0]) != 0 ) || ( StringUtil.StrCmp(Z1155LinRef2, T000G2_A1155LinRef2[0]) != 0 ) || ( StringUtil.StrCmp(Z1156LinRef3, T000G2_A1156LinRef3[0]) != 0 ) || ( StringUtil.StrCmp(Z1157LinRef4, T000G2_A1157LinRef4[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z1153LinDsc, T000G2_A1153LinDsc[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.lineasproductos:[seudo value changed for attri]"+"LinDsc");
                  GXUtil.WriteLogRaw("Old: ",Z1153LinDsc);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A1153LinDsc[0]);
               }
               if ( StringUtil.StrCmp(Z1152LinAbr, T000G2_A1152LinAbr[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.lineasproductos:[seudo value changed for attri]"+"LinAbr");
                  GXUtil.WriteLogRaw("Old: ",Z1152LinAbr);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A1152LinAbr[0]);
               }
               if ( StringUtil.StrCmp(Z1160LinSunat, T000G2_A1160LinSunat[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.lineasproductos:[seudo value changed for attri]"+"LinSunat");
                  GXUtil.WriteLogRaw("Old: ",Z1160LinSunat);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A1160LinSunat[0]);
               }
               if ( Z1158LinStk != T000G2_A1158LinStk[0] )
               {
                  GXUtil.WriteLog("configuracion.lineasproductos:[seudo value changed for attri]"+"LinStk");
                  GXUtil.WriteLogRaw("Old: ",Z1158LinStk);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A1158LinStk[0]);
               }
               if ( Z1159LinSts != T000G2_A1159LinSts[0] )
               {
                  GXUtil.WriteLog("configuracion.lineasproductos:[seudo value changed for attri]"+"LinSts");
                  GXUtil.WriteLogRaw("Old: ",Z1159LinSts);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A1159LinSts[0]);
               }
               if ( StringUtil.StrCmp(Z1154LinRef1, T000G2_A1154LinRef1[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.lineasproductos:[seudo value changed for attri]"+"LinRef1");
                  GXUtil.WriteLogRaw("Old: ",Z1154LinRef1);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A1154LinRef1[0]);
               }
               if ( StringUtil.StrCmp(Z1155LinRef2, T000G2_A1155LinRef2[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.lineasproductos:[seudo value changed for attri]"+"LinRef2");
                  GXUtil.WriteLogRaw("Old: ",Z1155LinRef2);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A1155LinRef2[0]);
               }
               if ( StringUtil.StrCmp(Z1156LinRef3, T000G2_A1156LinRef3[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.lineasproductos:[seudo value changed for attri]"+"LinRef3");
                  GXUtil.WriteLogRaw("Old: ",Z1156LinRef3);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A1156LinRef3[0]);
               }
               if ( StringUtil.StrCmp(Z1157LinRef4, T000G2_A1157LinRef4[0]) != 0 )
               {
                  GXUtil.WriteLog("configuracion.lineasproductos:[seudo value changed for attri]"+"LinRef4");
                  GXUtil.WriteLogRaw("Old: ",Z1157LinRef4);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A1157LinRef4[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CLINEAPROD"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G17( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G17( 0) ;
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G8 */
                     pr_default.execute(6, new Object[] {A52LinCod, A1153LinDsc, A1152LinAbr, A1160LinSunat, A1158LinStk, A1159LinSts, A1154LinRef1, A1155LinRef2, A1156LinRef3, A1157LinRef4});
                     pr_default.close(6);
                     dsDefault.SmartCacheProvider.SetUpdated("CLINEAPROD");
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
                           ResetCaption0G0( ) ;
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
               Load0G17( ) ;
            }
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void Update0G17( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G9 */
                     pr_default.execute(7, new Object[] {A1153LinDsc, A1152LinAbr, A1160LinSunat, A1158LinStk, A1159LinSts, A1154LinRef1, A1155LinRef2, A1156LinRef3, A1157LinRef4, A52LinCod});
                     pr_default.close(7);
                     dsDefault.SmartCacheProvider.SetUpdated("CLINEAPROD");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CLINEAPROD"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G17( ) ;
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
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void DeferredUpdate0G17( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G17( ) ;
            AfterConfirm0G17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G17( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000G10 */
                  pr_default.execute(8, new Object[] {A52LinCod});
                  pr_default.close(8);
                  dsDefault.SmartCacheProvider.SetUpdated("CLINEAPROD");
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0G17( ) ;
         Gx_mode = sMode17;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0G17( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000G11 */
            pr_default.execute(9, new Object[] {A52LinCod});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"POCONCEPTOS"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor T000G12 */
            pr_default.execute(10, new Object[] {A52LinCod});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Linea de Productos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000G13 */
            pr_default.execute(11, new Object[] {A52LinCod});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Productos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel0G17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("configuracion.lineasproductos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("configuracion.lineasproductos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0G17( )
      {
         /* Scan By routine */
         /* Using cursor T000G14 */
         pr_default.execute(12);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound17 = 1;
            A52LinCod = T000G14_A52LinCod[0];
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0G17( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound17 = 1;
            A52LinCod = T000G14_A52LinCod[0];
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
         }
      }

      protected void ScanEnd0G17( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0G17( )
      {
         /* After Confirm Rules */
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV14cLinCod;
            GXt_char3 = "LINEAS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV14cLinCod = (int)(GXt_int4);
            AssignAttri("", false, "AV14cLinCod", StringUtil.LTrimStr( (decimal)(AV14cLinCod), 6, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            A52LinCod = AV14cLinCod;
            AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
         }
      }

      protected void BeforeInsert0G17( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0G17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G17( )
      {
         edtLinDsc_Enabled = 0;
         AssignProp("", false, edtLinDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinDsc_Enabled), 5, 0), true);
         edtLinAbr_Enabled = 0;
         AssignProp("", false, edtLinAbr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinAbr_Enabled), 5, 0), true);
         edtLinSunat_Enabled = 0;
         AssignProp("", false, edtLinSunat_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinSunat_Enabled), 5, 0), true);
         edtLinRef1_Enabled = 0;
         AssignProp("", false, edtLinRef1_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinRef1_Enabled), 5, 0), true);
         edtLinRef2_Enabled = 0;
         AssignProp("", false, edtLinRef2_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinRef2_Enabled), 5, 0), true);
         edtLinRef3_Enabled = 0;
         AssignProp("", false, edtLinRef3_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinRef3_Enabled), 5, 0), true);
         edtLinRef4_Enabled = 0;
         AssignProp("", false, edtLinRef4_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinRef4_Enabled), 5, 0), true);
         edtLinStk_Enabled = 0;
         AssignProp("", false, edtLinStk_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinStk_Enabled), 5, 0), true);
         edtLinSts_Enabled = 0;
         AssignProp("", false, edtLinSts_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinSts_Enabled), 5, 0), true);
         edtLinCod_Enabled = 0;
         AssignProp("", false, edtLinCod_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtLinCod_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0G17( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0G0( )
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
         context.AddJavascriptSource("gxcfg.js", "?202281811441611", false, true);
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
         GXEncryptionTmp = "configuracion.lineasproductos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV13LinCod,6,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("configuracion.lineasproductos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"LineasProductos");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("configuracion\\lineasproductos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z52LinCod", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z52LinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1153LinDsc", StringUtil.RTrim( Z1153LinDsc));
         GxWebStd.gx_hidden_field( context, "Z1152LinAbr", StringUtil.RTrim( Z1152LinAbr));
         GxWebStd.gx_hidden_field( context, "Z1160LinSunat", Z1160LinSunat);
         GxWebStd.gx_hidden_field( context, "Z1158LinStk", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1158LinStk), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1159LinSts", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z1159LinSts), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z1154LinRef1", Z1154LinRef1);
         GxWebStd.gx_hidden_field( context, "Z1155LinRef2", Z1155LinRef2);
         GxWebStd.gx_hidden_field( context, "Z1156LinRef3", Z1156LinRef3);
         GxWebStd.gx_hidden_field( context, "Z1157LinRef4", Z1157LinRef4);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vLINCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13LinCod), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vLINCOD", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13LinCod), "ZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vCLINCOD", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14cLinCod), 6, 0, ".", "")));
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
         GXEncryptionTmp = "configuracion.lineasproductos.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV13LinCod,6,0));
         return formatLink("configuracion.lineasproductos.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "Configuracion.LineasProductos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Lineas" ;
      }

      protected void InitializeNonKey0G17( )
      {
         AV14cLinCod = 0;
         AssignAttri("", false, "AV14cLinCod", StringUtil.LTrimStr( (decimal)(AV14cLinCod), 6, 0));
         A1153LinDsc = "";
         AssignAttri("", false, "A1153LinDsc", A1153LinDsc);
         A1152LinAbr = "";
         AssignAttri("", false, "A1152LinAbr", A1152LinAbr);
         A1160LinSunat = "";
         AssignAttri("", false, "A1160LinSunat", A1160LinSunat);
         A1158LinStk = 0;
         AssignAttri("", false, "A1158LinStk", StringUtil.Str( (decimal)(A1158LinStk), 1, 0));
         A1154LinRef1 = "";
         AssignAttri("", false, "A1154LinRef1", A1154LinRef1);
         A1155LinRef2 = "";
         AssignAttri("", false, "A1155LinRef2", A1155LinRef2);
         A1156LinRef3 = "";
         AssignAttri("", false, "A1156LinRef3", A1156LinRef3);
         A1157LinRef4 = "";
         AssignAttri("", false, "A1157LinRef4", A1157LinRef4);
         A1159LinSts = 1;
         AssignAttri("", false, "A1159LinSts", StringUtil.Str( (decimal)(A1159LinSts), 1, 0));
         Z1153LinDsc = "";
         Z1152LinAbr = "";
         Z1160LinSunat = "";
         Z1158LinStk = 0;
         Z1159LinSts = 0;
         Z1154LinRef1 = "";
         Z1155LinRef2 = "";
         Z1156LinRef3 = "";
         Z1157LinRef4 = "";
      }

      protected void InitAll0G17( )
      {
         A52LinCod = 0;
         AssignAttri("", false, "A52LinCod", StringUtil.LTrimStr( (decimal)(A52LinCod), 6, 0));
         InitializeNonKey0G17( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A1159LinSts = i1159LinSts;
         AssignAttri("", false, "A1159LinSts", StringUtil.Str( (decimal)(A1159LinSts), 1, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202281811441633", true, true);
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
         context.AddJavascriptSource("configuracion/lineasproductos.js", "?202281811441633", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtLinDsc_Internalname = "LINDSC";
         edtLinAbr_Internalname = "LINABR";
         edtLinSunat_Internalname = "LINSUNAT";
         edtLinRef1_Internalname = "LINREF1";
         edtLinRef2_Internalname = "LINREF2";
         edtLinRef3_Internalname = "LINREF3";
         edtLinRef4_Internalname = "LINREF4";
         edtLinStk_Internalname = "LINSTK";
         edtLinSts_Internalname = "LINSTS";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         bttBtntrn_delete_Internalname = "BTNTRN_DELETE";
         divTablemain_Internalname = "TABLEMAIN";
         edtLinCod_Internalname = "LINCOD";
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
         Form.Caption = "Lineas";
         edtLinCod_Jsonclick = "";
         edtLinCod_Enabled = 1;
         edtLinCod_Visible = 1;
         bttBtntrn_delete_Enabled = 0;
         bttBtntrn_delete_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtLinSts_Jsonclick = "";
         edtLinSts_Enabled = 1;
         edtLinStk_Jsonclick = "";
         edtLinStk_Enabled = 1;
         edtLinRef4_Jsonclick = "";
         edtLinRef4_Enabled = 1;
         edtLinRef3_Jsonclick = "";
         edtLinRef3_Enabled = 1;
         edtLinRef2_Jsonclick = "";
         edtLinRef2_Enabled = 1;
         edtLinRef1_Jsonclick = "";
         edtLinRef1_Enabled = 1;
         edtLinSunat_Jsonclick = "";
         edtLinSunat_Enabled = 1;
         edtLinAbr_Jsonclick = "";
         edtLinAbr_Enabled = 1;
         edtLinDsc_Jsonclick = "";
         edtLinDsc_Enabled = 1;
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

      protected void GX4ASACLINCOD0G17( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && true /* After */ )
         {
            GXt_int4 = AV14cLinCod;
            GXt_char3 = "LINEAS";
            new GeneXus.Programs.seguridad.pcorcatalogos(context ).execute( ref  GXt_char3, out  GXt_int4) ;
            AV14cLinCod = (int)(GXt_int4);
            AssignAttri("", false, "AV14cLinCod", StringUtil.LTrimStr( (decimal)(AV14cLinCod), 6, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14cLinCod), 6, 0, ".", "")))+"\"") ;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV13LinCod',fld:'vLINCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV13LinCod',fld:'vLINCOD',pic:'ZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120G2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'A52LinCod',fld:'LINCOD',pic:'ZZZZZ9'},{av:'A1153LinDsc',fld:'LINDSC',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_LINDSC","{handler:'Valid_Lindsc',iparms:[]");
         setEventMetadata("VALID_LINDSC",",oparms:[]}");
         setEventMetadata("VALID_LINABR","{handler:'Valid_Linabr',iparms:[]");
         setEventMetadata("VALID_LINABR",",oparms:[]}");
         setEventMetadata("VALID_LINSUNAT","{handler:'Valid_Linsunat',iparms:[]");
         setEventMetadata("VALID_LINSUNAT",",oparms:[]}");
         setEventMetadata("VALID_LINCOD","{handler:'Valid_Lincod',iparms:[]");
         setEventMetadata("VALID_LINCOD",",oparms:[]}");
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
         Z1153LinDsc = "";
         Z1152LinAbr = "";
         Z1160LinSunat = "";
         Z1154LinRef1 = "";
         Z1155LinRef2 = "";
         Z1156LinRef3 = "";
         Z1157LinRef4 = "";
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
         A1153LinDsc = "";
         A1152LinAbr = "";
         A1160LinSunat = "";
         A1154LinRef1 = "";
         A1155LinRef2 = "";
         A1156LinRef3 = "";
         A1157LinRef4 = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         bttBtntrn_delete_Jsonclick = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode17 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15SGAuDocGls = "";
         AV16Codigo = "";
         GXt_char1 = "";
         GXt_char2 = "";
         T000G4_A52LinCod = new int[1] ;
         T000G4_A1153LinDsc = new string[] {""} ;
         T000G4_A1152LinAbr = new string[] {""} ;
         T000G4_A1160LinSunat = new string[] {""} ;
         T000G4_A1158LinStk = new short[1] ;
         T000G4_A1159LinSts = new short[1] ;
         T000G4_A1154LinRef1 = new string[] {""} ;
         T000G4_A1155LinRef2 = new string[] {""} ;
         T000G4_A1156LinRef3 = new string[] {""} ;
         T000G4_A1157LinRef4 = new string[] {""} ;
         T000G5_A52LinCod = new int[1] ;
         T000G3_A52LinCod = new int[1] ;
         T000G3_A1153LinDsc = new string[] {""} ;
         T000G3_A1152LinAbr = new string[] {""} ;
         T000G3_A1160LinSunat = new string[] {""} ;
         T000G3_A1158LinStk = new short[1] ;
         T000G3_A1159LinSts = new short[1] ;
         T000G3_A1154LinRef1 = new string[] {""} ;
         T000G3_A1155LinRef2 = new string[] {""} ;
         T000G3_A1156LinRef3 = new string[] {""} ;
         T000G3_A1157LinRef4 = new string[] {""} ;
         T000G6_A52LinCod = new int[1] ;
         T000G7_A52LinCod = new int[1] ;
         T000G2_A52LinCod = new int[1] ;
         T000G2_A1153LinDsc = new string[] {""} ;
         T000G2_A1152LinAbr = new string[] {""} ;
         T000G2_A1160LinSunat = new string[] {""} ;
         T000G2_A1158LinStk = new short[1] ;
         T000G2_A1159LinSts = new short[1] ;
         T000G2_A1154LinRef1 = new string[] {""} ;
         T000G2_A1155LinRef2 = new string[] {""} ;
         T000G2_A1156LinRef3 = new string[] {""} ;
         T000G2_A1157LinRef4 = new string[] {""} ;
         T000G11_A313PoConcCod = new int[1] ;
         T000G12_A83ParTip = new string[] {""} ;
         T000G12_A84ParCod = new int[1] ;
         T000G12_A104ParDItem = new short[1] ;
         T000G13_A28ProdCod = new string[] {""} ;
         T000G14_A52LinCod = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         GXt_char3 = "";
         pr_datastore2 = new DataStoreProvider(context, new GeneXus.Programs.configuracion.lineasproductos__datastore2(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configuracion.lineasproductos__default(),
            new Object[][] {
                new Object[] {
               T000G2_A52LinCod, T000G2_A1153LinDsc, T000G2_A1152LinAbr, T000G2_A1160LinSunat, T000G2_A1158LinStk, T000G2_A1159LinSts, T000G2_A1154LinRef1, T000G2_A1155LinRef2, T000G2_A1156LinRef3, T000G2_A1157LinRef4
               }
               , new Object[] {
               T000G3_A52LinCod, T000G3_A1153LinDsc, T000G3_A1152LinAbr, T000G3_A1160LinSunat, T000G3_A1158LinStk, T000G3_A1159LinSts, T000G3_A1154LinRef1, T000G3_A1155LinRef2, T000G3_A1156LinRef3, T000G3_A1157LinRef4
               }
               , new Object[] {
               T000G4_A52LinCod, T000G4_A1153LinDsc, T000G4_A1152LinAbr, T000G4_A1160LinSunat, T000G4_A1158LinStk, T000G4_A1159LinSts, T000G4_A1154LinRef1, T000G4_A1155LinRef2, T000G4_A1156LinRef3, T000G4_A1157LinRef4
               }
               , new Object[] {
               T000G5_A52LinCod
               }
               , new Object[] {
               T000G6_A52LinCod
               }
               , new Object[] {
               T000G7_A52LinCod
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000G11_A313PoConcCod
               }
               , new Object[] {
               T000G12_A83ParTip, T000G12_A84ParCod, T000G12_A104ParDItem
               }
               , new Object[] {
               T000G13_A28ProdCod
               }
               , new Object[] {
               T000G14_A52LinCod
               }
            }
         );
         Z1159LinSts = 1;
         A1159LinSts = 1;
         i1159LinSts = 1;
      }

      private short Z1158LinStk ;
      private short Z1159LinSts ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A1158LinStk ;
      private short A1159LinSts ;
      private short Gx_BScreen ;
      private short RcdFound17 ;
      private short GX_JID ;
      private short nIsDirty_17 ;
      private short gxajaxcallmode ;
      private short i1159LinSts ;
      private int wcpOAV13LinCod ;
      private int Z52LinCod ;
      private int AV13LinCod ;
      private int trnEnded ;
      private int edtLinDsc_Enabled ;
      private int edtLinAbr_Enabled ;
      private int edtLinSunat_Enabled ;
      private int edtLinRef1_Enabled ;
      private int edtLinRef2_Enabled ;
      private int edtLinRef3_Enabled ;
      private int edtLinRef4_Enabled ;
      private int edtLinStk_Enabled ;
      private int edtLinSts_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int bttBtntrn_delete_Visible ;
      private int bttBtntrn_delete_Enabled ;
      private int A52LinCod ;
      private int edtLinCod_Visible ;
      private int edtLinCod_Enabled ;
      private int AV14cLinCod ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private long GXt_int4 ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z1153LinDsc ;
      private string Z1152LinAbr ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtLinDsc_Internalname ;
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
      private string A1153LinDsc ;
      private string edtLinDsc_Jsonclick ;
      private string edtLinAbr_Internalname ;
      private string A1152LinAbr ;
      private string edtLinAbr_Jsonclick ;
      private string edtLinSunat_Internalname ;
      private string edtLinSunat_Jsonclick ;
      private string edtLinRef1_Internalname ;
      private string edtLinRef1_Jsonclick ;
      private string edtLinRef2_Internalname ;
      private string edtLinRef2_Jsonclick ;
      private string edtLinRef3_Internalname ;
      private string edtLinRef3_Jsonclick ;
      private string edtLinRef4_Internalname ;
      private string edtLinRef4_Jsonclick ;
      private string edtLinStk_Internalname ;
      private string edtLinStk_Jsonclick ;
      private string edtLinSts_Internalname ;
      private string edtLinSts_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string bttBtntrn_delete_Internalname ;
      private string bttBtntrn_delete_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtLinCod_Internalname ;
      private string edtLinCod_Jsonclick ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode17 ;
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
      private bool Gx_longc ;
      private string Z1160LinSunat ;
      private string Z1154LinRef1 ;
      private string Z1155LinRef2 ;
      private string Z1156LinRef3 ;
      private string Z1157LinRef4 ;
      private string A1160LinSunat ;
      private string A1154LinRef1 ;
      private string A1155LinRef2 ;
      private string A1156LinRef3 ;
      private string A1157LinRef4 ;
      private string AV15SGAuDocGls ;
      private string AV16Codigo ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsDataStore2 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000G4_A52LinCod ;
      private string[] T000G4_A1153LinDsc ;
      private string[] T000G4_A1152LinAbr ;
      private string[] T000G4_A1160LinSunat ;
      private short[] T000G4_A1158LinStk ;
      private short[] T000G4_A1159LinSts ;
      private string[] T000G4_A1154LinRef1 ;
      private string[] T000G4_A1155LinRef2 ;
      private string[] T000G4_A1156LinRef3 ;
      private string[] T000G4_A1157LinRef4 ;
      private int[] T000G5_A52LinCod ;
      private int[] T000G3_A52LinCod ;
      private string[] T000G3_A1153LinDsc ;
      private string[] T000G3_A1152LinAbr ;
      private string[] T000G3_A1160LinSunat ;
      private short[] T000G3_A1158LinStk ;
      private short[] T000G3_A1159LinSts ;
      private string[] T000G3_A1154LinRef1 ;
      private string[] T000G3_A1155LinRef2 ;
      private string[] T000G3_A1156LinRef3 ;
      private string[] T000G3_A1157LinRef4 ;
      private int[] T000G6_A52LinCod ;
      private int[] T000G7_A52LinCod ;
      private int[] T000G2_A52LinCod ;
      private string[] T000G2_A1153LinDsc ;
      private string[] T000G2_A1152LinAbr ;
      private string[] T000G2_A1160LinSunat ;
      private short[] T000G2_A1158LinStk ;
      private short[] T000G2_A1159LinSts ;
      private string[] T000G2_A1154LinRef1 ;
      private string[] T000G2_A1155LinRef2 ;
      private string[] T000G2_A1156LinRef3 ;
      private string[] T000G2_A1157LinRef4 ;
      private int[] T000G11_A313PoConcCod ;
      private string[] T000G12_A83ParTip ;
      private int[] T000G12_A84ParCod ;
      private short[] T000G12_A104ParDItem ;
      private string[] T000G13_A28ProdCod ;
      private int[] T000G14_A52LinCod ;
      private IDataStoreProvider pr_datastore2 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
   }

   public class lineasproductos__datastore2 : DataStoreHelperBase, IDataStoreHelper
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

 public class lineasproductos__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000G4;
        prmT000G4 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT000G5;
        prmT000G5 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT000G3;
        prmT000G3 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT000G6;
        prmT000G6 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT000G7;
        prmT000G7 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT000G2;
        prmT000G2 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT000G8;
        prmT000G8 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0) ,
        new ParDef("@LinDsc",GXType.NChar,100,0) ,
        new ParDef("@LinAbr",GXType.NChar,5,0) ,
        new ParDef("@LinSunat",GXType.NVarChar,5,0) ,
        new ParDef("@LinStk",GXType.Int16,1,0) ,
        new ParDef("@LinSts",GXType.Int16,1,0) ,
        new ParDef("@LinRef1",GXType.NVarChar,20,0) ,
        new ParDef("@LinRef2",GXType.NVarChar,20,0) ,
        new ParDef("@LinRef3",GXType.NVarChar,20,0) ,
        new ParDef("@LinRef4",GXType.NVarChar,20,0)
        };
        Object[] prmT000G9;
        prmT000G9 = new Object[] {
        new ParDef("@LinDsc",GXType.NChar,100,0) ,
        new ParDef("@LinAbr",GXType.NChar,5,0) ,
        new ParDef("@LinSunat",GXType.NVarChar,5,0) ,
        new ParDef("@LinStk",GXType.Int16,1,0) ,
        new ParDef("@LinSts",GXType.Int16,1,0) ,
        new ParDef("@LinRef1",GXType.NVarChar,20,0) ,
        new ParDef("@LinRef2",GXType.NVarChar,20,0) ,
        new ParDef("@LinRef3",GXType.NVarChar,20,0) ,
        new ParDef("@LinRef4",GXType.NVarChar,20,0) ,
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT000G10;
        prmT000G10 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT000G11;
        prmT000G11 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT000G12;
        prmT000G12 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT000G13;
        prmT000G13 = new Object[] {
        new ParDef("@LinCod",GXType.Int32,6,0)
        };
        Object[] prmT000G14;
        prmT000G14 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000G2", "SELECT [LinCod], [LinDsc], [LinAbr], [LinSunat], [LinStk], [LinSts], [LinRef1], [LinRef2], [LinRef3], [LinRef4] FROM [CLINEAPROD] WITH (UPDLOCK) WHERE [LinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G3", "SELECT [LinCod], [LinDsc], [LinAbr], [LinSunat], [LinStk], [LinSts], [LinRef1], [LinRef2], [LinRef3], [LinRef4] FROM [CLINEAPROD] WHERE [LinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G4", "SELECT TM1.[LinCod], TM1.[LinDsc], TM1.[LinAbr], TM1.[LinSunat], TM1.[LinStk], TM1.[LinSts], TM1.[LinRef1], TM1.[LinRef2], TM1.[LinRef3], TM1.[LinRef4] FROM [CLINEAPROD] TM1 WHERE TM1.[LinCod] = @LinCod ORDER BY TM1.[LinCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G5", "SELECT [LinCod] FROM [CLINEAPROD] WHERE [LinCod] = @LinCod  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G6", "SELECT TOP 1 [LinCod] FROM [CLINEAPROD] WHERE ( [LinCod] > @LinCod) ORDER BY [LinCod]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G7", "SELECT TOP 1 [LinCod] FROM [CLINEAPROD] WHERE ( [LinCod] < @LinCod) ORDER BY [LinCod] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G8", "INSERT INTO [CLINEAPROD]([LinCod], [LinDsc], [LinAbr], [LinSunat], [LinStk], [LinSts], [LinRef1], [LinRef2], [LinRef3], [LinRef4]) VALUES(@LinCod, @LinDsc, @LinAbr, @LinSunat, @LinStk, @LinSts, @LinRef1, @LinRef2, @LinRef3, @LinRef4)", GxErrorMask.GX_NOMASK,prmT000G8)
           ,new CursorDef("T000G9", "UPDATE [CLINEAPROD] SET [LinDsc]=@LinDsc, [LinAbr]=@LinAbr, [LinSunat]=@LinSunat, [LinStk]=@LinStk, [LinSts]=@LinSts, [LinRef1]=@LinRef1, [LinRef2]=@LinRef2, [LinRef3]=@LinRef3, [LinRef4]=@LinRef4  WHERE [LinCod] = @LinCod", GxErrorMask.GX_NOMASK,prmT000G9)
           ,new CursorDef("T000G10", "DELETE FROM [CLINEAPROD]  WHERE [LinCod] = @LinCod", GxErrorMask.GX_NOMASK,prmT000G10)
           ,new CursorDef("T000G11", "SELECT TOP 1 [PoConcCod] FROM [POCONCEPTOS] WHERE [PoConcLinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G12", "SELECT TOP 1 [ParTip], [ParCod], [ParDItem] FROM [CBPARAMPROD] WHERE [ParDLinProd] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G13", "SELECT TOP 1 [ProdCod] FROM [APRODUCTOS] WHERE [LinCod] = @LinCod ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G14", "SELECT [LinCod] FROM [CLINEAPROD] ORDER BY [LinCod]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000G14,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 5);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getString(1, 3);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 15);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
